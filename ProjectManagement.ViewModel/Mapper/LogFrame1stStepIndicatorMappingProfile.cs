using AutoMapper;
using ProjectManagement.Data;
using System.Linq;

namespace ProjectManagement.ViewModel
{
    public class LogFrame1stStepIndicatorMappingProfile : Profile
    {
        public LogFrame1stStepIndicatorMappingProfile()
        {
            CreateMap<LogFrame1stStepModel, LogFrame1stStepIndicator>()
                .ForMember(d => d.LogFrame1stStepParticipants, opt => opt.MapFrom(c => c.ProjectParticipants))
                .ForMember(d => d.LogFrame1stStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame1stStepCity() { CityId = d }).ToList()))
                .ReverseMap();

            CreateMap<LogFrame1stStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));

            CreateMap<LogFrameParticipantsModel, LogFrame1stStepParticipant>();

        }
    }
}