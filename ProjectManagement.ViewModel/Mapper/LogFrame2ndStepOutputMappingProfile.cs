using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame2ndStepOutputMappingProfile : Profile
    {
        public LogFrame2ndStepOutputMappingProfile()
        {
            CreateMap<LogFrame2ndStepOutput, LogFrame2ndStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame2ndStepParticipants))
                .ReverseMap();

            CreateMap<LogFrame2ndStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType))
                .ReverseMap();
        }
    }
}