using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class ProjectStatusMappingProfile : Profile
    {
        public ProjectStatusMappingProfile()
        {
            CreateMap<ProjectStatus, ProjectStatusAddModel>().ReverseMap();
            CreateMap<ProjectStatus, ProjectStatusViewModel>().ReverseMap();

        }
    }
}