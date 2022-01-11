using AutoMapper;
using MyTemplate.Domain.Entities;
using MyTemplate.Domain.Entities.Dtos;

namespace MyTemplate.Domain.ApplicationServices
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();

            CreateMap<EmployeeInfo, EmployeeInfoDTO>().ReverseMap();

            CreateMap<Unit, UnitDTO>().ReverseMap();
            CreateMap<Unit, CreateUnitDTO>().ReverseMap();

            CreateMap<OvertimeSettingOfficial, OvertimeSettingOfficialDTO>().ReverseMap();
            CreateMap<OvertimeSettingOfficial, CreateOvertimeSettingOfficialDTO>().ReverseMap();

            CreateMap<OvertimeSettingContractory, OvertimeSettingContractoryDTO>().ReverseMap();
            CreateMap<OvertimeSettingContractory, CreateOvertimeSettingContractoryDTO>().ReverseMap();
        }
    }
}
