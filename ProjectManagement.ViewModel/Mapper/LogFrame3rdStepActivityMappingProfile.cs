using AutoMapper;
using ProjectManagement.Data;
using System.Linq;

namespace ProjectManagement.ViewModel
{
    public class LogFrame3rdStepActivityMappingProfile : Profile
    {
        public LogFrame3rdStepActivityMappingProfile()
        {
            CreateMap<LogFrame3rdStepModel, LogFrame3rdStepActivity>()
                .ForMember(d => d.LogFrame3rdStepParticipants, opt => opt.MapFrom(c => c.ProjectParticipants))
                .ForMember(d => d.LogFrame3rdStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame3rdStepCity() { CityId = d }).ToList()))
                .ReverseMap();

            CreateMap<LogFrame3rdStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));
            CreateMap<LogFrameParticipantsModel, LogFrame3rdStepParticipant>();
        }
    }
}