using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame1stStepIndicatorMappingProfile : Profile
    {
        public LogFrame1stStepIndicatorMappingProfile()
        {
            CreateMap<LogFrame1stStepIndicator, LogFrame1stStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame1stStepParticipants))
                .ReverseMap();

            CreateMap<LogFrame1stStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType))
                .ReverseMap();
        }
    }
}