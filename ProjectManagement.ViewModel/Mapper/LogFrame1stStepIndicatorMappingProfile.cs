using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame1stStepIndicatorMappingProfile : Profile
    {
        public LogFrame1stStepIndicatorMappingProfile()
        {
            CreateMap<LogFrame1stStepIndicator, LogFrame1stStepModel>().ReverseMap();
        }
    }
}