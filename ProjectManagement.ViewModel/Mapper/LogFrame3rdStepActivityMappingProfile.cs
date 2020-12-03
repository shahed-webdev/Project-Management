using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame3rdStepActivityMappingProfile : Profile
    {
        public LogFrame3rdStepActivityMappingProfile()
        {
            CreateMap<LogFrame3rdStepActivity, LogFrame3rdStepModel>().ReverseMap();
        }
    }
}