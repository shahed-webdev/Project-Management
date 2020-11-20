using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class DonorMappingProfile : Profile
    {
        public DonorMappingProfile()
        {
            CreateMap<Donor, DonorAddModel>().ReverseMap();
            CreateMap<Donor, DonorViewModel>().ReverseMap();

        }

    }
}