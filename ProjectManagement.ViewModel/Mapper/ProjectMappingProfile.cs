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
            CreateMap<ProjectReportsAddModel, ProjectReports>();
            CreateMap<ProjectReports, ProjectReportsAddModel>()
                .ForMember(d => d.ReportName, opt => opt.MapFrom(c => c.ReportType.ReportName));

            CreateMap<ProjectAddModel, Project>()
                .ForMember(d => d.ProjectDonors, opt => opt.MapFrom(c => c.ProjectDonors.Select(d => new ProjectDonor { DonorId = d }).ToList()))
                .ForMember(d => d.ProjectCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new ProjectCity { CityId = d }).ToList())).ReverseMap();



            CreateMap<Project, ProjectEditViewModel>()
                .ForMember(d => d.CityIds, opt => opt.MapFrom(c => c.ProjectCities.Select(d => d.CityId).ToArray()))
                .ForMember(d => d.ProjectDonorIds, opt => opt.MapFrom(c => c.ProjectDonors.Select(d => d.DonorId).ToArray()))
                .ForMember(d => d.Locations, opt => opt.MapFrom(c => c.ProjectCities))
                .ForMember(d => d.FilePhotoUrl, opt => opt.MapFrom(c => c.Photo));

            CreateMap<ProjectCity, CityWithStateCountryViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(c => c.City.CityName))
                .ForMember(d => d.StateName, opt => opt.MapFrom(c => c.City.State.StateName))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(c => c.City.State.Country.CountryName));



        }

    }
}