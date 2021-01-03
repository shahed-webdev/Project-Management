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
                .ForMember(d => d.LogFrame1stStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame1stStepCity() { CityId = d }).ToList()));

            CreateMap<LogFrame1stStepIndicator, LogFrame1stStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame1stStepParticipants))
                .ForMember(d => d.Locations, opt => opt.MapFrom(c => c.LogFrame1stStepCities))
                .ForMember(d => d.CityIds, opt => opt.MapFrom(c => c.LogFrame1stStepCities.Select(l => l.CityId).ToArray()));

            CreateMap<LogFrame1stStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));

            CreateMap<LogFrameParticipantsModel, LogFrame1stStepParticipant>();

            CreateMap<LogFrame1stStepCity, CityWithStateCountryViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(c => c.City.CityName))
                .ForMember(d => d.StateName, opt => opt.MapFrom(c => c.City.State.StateName))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(c => c.City.State.Country.CountryName));





        }
    }
}