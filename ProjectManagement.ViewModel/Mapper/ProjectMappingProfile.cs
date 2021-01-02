using AutoMapper;
using ProjectManagement.Data;
using System.Linq;

namespace ProjectManagement.ViewModel
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectListViewModel>().ReverseMap();
            CreateMap<Project, ProjectEditViewModel>().ReverseMap();

            CreateMap<ProjectBeneficiary, ProjectBeneficiaryAddModel>().ReverseMap();
            CreateMap<ProjectReports, ProjectReportsAddModel>().ReverseMap();

            CreateMap<ProjectAddModel, Project>()
                .ForMember(d => d.ProjectReports, opt => opt.MapFrom(c => c.ProjectReports))
                .ForMember(d => d.ProjectBeneficiaries, opt => opt.MapFrom(c => c.ProjectBeneficiaries))
                .ForMember(d => d.ProjectDonors, opt => opt.MapFrom(c => c.ProjectDonors.Select(d => new ProjectDonor { DonorId = d }).ToList()))
                .ForMember(d => d.ProjectCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new ProjectCity { CityId = d }).ToList())).ReverseMap();


        }

    }
}