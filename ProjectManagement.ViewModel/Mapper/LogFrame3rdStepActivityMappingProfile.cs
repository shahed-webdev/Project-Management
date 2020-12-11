using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class LogFrame3rdStepActivityMappingProfile : Profile
    {
        public LogFrame3rdStepActivityMappingProfile()
        {
            CreateMap<LogFrame3rdStepActivity, LogFrame3rdStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame3rdStepParticipants))
                .ReverseMap();

            CreateMap<LogFrame3rdStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));
            CreateMap<LogFrameParticipantsModel, LogFrame3rdStepParticipant>();
        }
    }
}