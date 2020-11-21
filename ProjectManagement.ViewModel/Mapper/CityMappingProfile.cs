using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityAddModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();

        }
    }
}