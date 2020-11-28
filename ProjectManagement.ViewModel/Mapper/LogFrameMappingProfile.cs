using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrameMappingProfile : Profile
    {
        public LogFrameMappingProfile()
        {
            CreateMap<LogFrame, LogFrameModel>().ReverseMap();
        }
    }
}