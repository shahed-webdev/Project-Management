using AutoMapper;
using ProjectManagement.Data;
using System.Linq;

namespace ProjectManagement.ViewModel
{
    public class LogFrame2ndStepOutputMappingProfile : Profile
    {
        public LogFrame2ndStepOutputMappingProfile()
        {
            CreateMap<LogFrame2ndStepModel, LogFrame2ndStepOutput>()
                .ForMember(d => d.LogFrame2ndStepParticipants, opt => opt.MapFrom(c => c.ProjectParticipants))
                .ForMember(d => d.LogFrame2ndStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame2ndStepCity() { CityId = d }).ToList()))
                .ReverseMap();

            CreateMap<LogFrame2ndStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));
            CreateMap<LogFrameParticipantsModel, LogFrame2ndStepParticipant>();
        }
    }
}