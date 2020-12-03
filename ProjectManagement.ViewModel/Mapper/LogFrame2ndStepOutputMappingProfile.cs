using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame2ndStepOutputMappingProfile : Profile
    {
        public LogFrame2ndStepOutputMappingProfile()
        {
            CreateMap<LogFrame2ndStepOutput, LogFrame2ndStepModel>().ReverseMap();
        }
    }
}