using MyTemplate.Domain.Abstracts.Repositories;
using MyTemplate.Domain.Entities;
using MyTemplate.Domain.Entities.Dtos;
using MyTemplate.Infrastructures.DataAccess.DbContexts;
using MyTemplate.Infrastructures.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace MyTemplate.Infrastructures.DataAccess.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly ClockWebDbContext _context;
        protected readonly DbSet<T> _db;

        public GenericRepository(ClockWebDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] including)
        {
            var query = _db.AsQueryable();

            if (including != null)
            {
                including.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            }

            return query;
        }

        public async Task<int> Insert(T entity)
        {
            //_context.Set<T>().Add(entity);
            //return _context.SaveChanges();

            var result = _db.AddAsync(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
            _context.SaveChanges();
        }

        public async Task Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            var inDB = _context.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
            var inDbProps = _context.Entry(inDB).Properties;

            Type type = entity.GetType();

            var dbEntityEntry = _context.Set<T>().Attach(inDB);
            dbEntityEntry.State = EntityState.Modified;

            foreach (var entry in inDbProps)
            {
                if (entry.Metadata.Name.ToLower() != "id" &&
                    entry.Metadata.Name.ToLower() != "inserttime" &&
                    entry.Metadata.Name.ToLower() != "insertby"

                    )
                {
                    var originalValue = entry.OriginalValue;

                    PropertyInfo prop = type.GetProperty(entry.Metadata.Name);
                    var currentValue = prop.GetValue(entity);

                    if (originalValue.Equals(currentValue) == false &&
                        IsDefultValue(entry, currentValue) == false)
                    {
                        dbEntityEntry.Property(entry.Metadata.Name).CurrentValue = currentValue;
                        dbEntityEntry.Property(entry.Metadata.Name).IsModified = true;
                    }
                }
            }

            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    PropertyInfo prop = type.GetProperty(property.Name);
                    var currentValue = prop.GetValue(entity);

                    dbEntityEntry.Property(property).CurrentValue = currentValue;
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }


            await _context.SaveChangesAsync();

        }

        private bool IsDefultValue(PropertyEntry entry, object currentValue)
        {
            if(currentValue == null)
            {
                return true;
            }

            if (entry.Metadata.ClrType.IsEnum == true && currentValue.ToString() == "0")
            {
                return true;
            }

            switch (entry.Metadata.ClrType.Name)
            {
                case "String":
                    {
                        if((string)currentValue.ToString() == string.Empty)
                        {
                            return true;
                        }
                        break;
                    }
                case "int16":
                case "int32":
                case "int64":
                case "decimal":
                case "double":
                    {
                        if((int)currentValue == 0)
                        {
                            return true;
                        }
                        break;
                    }
                case "Guid":
                    {
                        if (currentValue == null || (Guid)currentValue == Guid.Empty)
                        {
                            return true;
                        }
                        break;
                    }
            }

            return false;
        }

        public async void Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
            _context.SaveChanges();
        }

        public SearchResult<T, BaseSearchParameter> GetList(BaseSearchParameter searchParameters)
        {
            var result = new SearchResult<T, BaseSearchParameter>
            {
                SearchParameter = searchParameters
            };
            var query = _context.Set<T>().AsNoTracking().OrderByDescending(c => c.Id).AsQueryable();

            if (searchParameters.SearchParameter != default(DateTime))
            {
                query = query.Where(c => c.InsertTime <= searchParameters.SearchParameter);
            }

            if (searchParameters.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }
            if (searchParameters.LastLoadedId.HasValue)
                query = query.Where(c => c.Id < searchParameters.LastLoadedId);
            result.Result = query.Take(searchParameters.PageSize).ToList();
            return result;
        }
    }
}
