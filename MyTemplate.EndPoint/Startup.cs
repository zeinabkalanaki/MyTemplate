using MyTemplate.APIs.Extentions;
using MyTemplate.Domain.Abstracts.ApplicationServices;
using MyTemplate.Domain.Abstracts.DomainServices;
using MyTemplate.Domain.Abstracts.Repositories;
using MyTemplate.Domain.ApplicationServices;
using MyTemplate.Domain.Services;
using MyTemplate.Infrastructures.DataAccess.DbContexts;
using MyTemplate.Infrastructures.DataAccess.Repositories;
using MyTemplate.Infrastructures.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace MyTemplate.APIs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //*******************************************************************************//
            //Logger Config
            //*******************************************************************************//
            services.AddSingleton(Log.Logger);

            //*******************************************************************************//
            //Access APIs Config
            //*******************************************************************************//
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAllPolicy", builder =>
                                                builder.AllowAnyOrigin()
                                                       .AllowAnyMethod()
                                                       .AllowAnyHeader());
            });

            //*******************************************************************************//
            //Auto Mapper Config
            //*******************************************************************************//
            services.AddAutoMapper(typeof(MapperInitilizer));

            //*******************************************************************************//
            // Connection Config
            //*******************************************************************************//
            var secsqloptionsBuilder = new DbContextOptionsBuilder();
            secsqloptionsBuilder.UseSqlServer(Configuration.GetConnectionString("sqlSecurityConnection"));
            services.AddDbContext<ClockWebSecurityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlSecurityConnection")));

            var sqlOptionsBuilder = new DbContextOptionsBuilder();
            sqlOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("sqlAppConnection"));

            //*******************************************************************************//
            //Services Injection Config
            //*******************************************************************************//
            //Repositories

            services.AddScoped<IEmployeeRepository>(s =>
            {
                return new EmployeeRepository(
                    new ClockWebDbContext(sqlOptionsBuilder.Options,
                          new UserResolverService(
                              new HttpContextAccessor(),
                              new ClockWebSecurityDbContext(secsqloptionsBuilder.Options)
                              )
                          ));
            });
           
        

            //Application service
            services.AddScoped<IEmployeeService, EmployeeService>();
         
            //Domain service
            services.AddScoped<ICheckEmployeeNumber, CheckEmployeeNumber>();
           
            //*******************************************************************************//
            //Controllers Config
            //*******************************************************************************//
            services.AddControllers()
                    .AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //*******************************************************************************//
            //Security Config
            //*******************************************************************************//
            // For Identity  
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ClockWebSecurityDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //*******************************************************************************//
            //Swagger Config
            //*******************************************************************************//
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyTemplate.APIs",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTemplate.APIs v1"));

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseCors("AllowAllPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization(); 
            });
        }
    }
}
