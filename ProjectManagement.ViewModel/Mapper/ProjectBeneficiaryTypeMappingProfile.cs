using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class ProjectBeneficiaryTypeMappingProfile : Profile
    {
        public ProjectBeneficiaryTypeMappingProfile()
        {
            CreateMap<ProjectBeneficiaryType, ProjectBeneficiaryTypeAddModel>().ReverseMap();
            CreateMap<ProjectBeneficiaryType, ProjectBeneficiaryTypeViewModel>().ReverseMap();
        }
    }
}