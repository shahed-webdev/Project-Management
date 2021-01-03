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
                .ForMember(d => d.LogFrame3rdStepCities, opt => opt.MapFrom(c => c.CityIds.Select(d => new LogFrame3rdStepCity() { CityId = d }).ToList()));

            CreateMap<LogFrame3rdStepActivity, LogFrame3rdStepModel>()
                .ForMember(d => d.ProjectParticipants, opt => opt.MapFrom(c => c.LogFrame3rdStepParticipants))
                .ForMember(d => d.Locations, opt => opt.MapFrom(c => c.LogFrame3rdStepCities))
                .ForMember(d => d.CityIds, opt => opt.MapFrom(c => c.LogFrame3rdStepCities.Select(l => l.CityId).ToArray()));



            CreateMap<LogFrame3rdStepParticipant, LogFrameParticipantsModel>()
                .ForMember(d => d.BeneficiaryType, opt => opt.MapFrom(c => c.ProjectBeneficiaryType.BeneficiaryType));
            CreateMap<LogFrameParticipantsModel, LogFrame3rdStepParticipant>();

            CreateMap<LogFrame3rdStepCity, CityWithStateCountryViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(c => c.City.CityName))
                .ForMember(d => d.StateName, opt => opt.MapFrom(c => c.City.State.StateName))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(c => c.City.State.Country.CountryName));

        }
    }
}