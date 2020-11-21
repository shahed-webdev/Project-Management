using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryAddModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();

        }
    }
}