using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class ProjectSectorMappingProfile : Profile
    {
        public ProjectSectorMappingProfile()
        {
            CreateMap<ProjectSector, ProjectSectorAddModel>().ReverseMap();
            CreateMap<ProjectSector, ProjectSectorViewModel>().ReverseMap();
        }
    }
}