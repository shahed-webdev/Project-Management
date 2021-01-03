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
                .ForMember(d => d.LogFrame2ndStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame2ndStepCity() { CityId = d }).ToList()));

            CreateMap<LogFrame2ndStepOutput, LogFrame2ndStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame2ndStepParticipants))
                .ForMember(d => d.Locations, opt => opt.MapFrom(c => c.LogFrame2ndStepCities))
                .ForMember(d => d.CityIds, opt => opt.MapFrom(c => c.LogFrame2ndStepCities.Select(l => l.CityId).ToArray()));


            CreateMap<LogFrame2ndStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));
            CreateMap<LogFrameParticipantsModel, LogFrame2ndStepParticipant>();

            CreateMap<LogFrame2ndStepCity, CityWithStateCountryViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(c => c.City.CityName))
                .ForMember(d => d.StateName, opt => opt.MapFrom(c => c.City.State.StateName))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(c => c.City.State.Country.CountryName));

        }
    }
}