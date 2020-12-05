using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class RegistrationMappingProfile : Profile
    {
        public RegistrationMappingProfile()
        {
            CreateMap<Registration, SubAdminRegisterViewModel>().ReverseMap();
            CreateMap<Registration, UserViewModel>()
                .ForMember(d => d.Sector, opt => opt.MapFrom(c => c.ProjectSector.Sector))
                .ReverseMap();


        }
    }
}