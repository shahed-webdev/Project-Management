using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class ReportTypeMappingProfile : Profile
    {
        public ReportTypeMappingProfile()
        {
            CreateMap<ReportType, ReportTypeAddModel>().ReverseMap();
            CreateMap<ReportType, ReportTypeViewModel>().ReverseMap();

        }
    }
}