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
            CreateMap<ProjectDonor, DonorViewModel>()
                .ForMember(d => d.Email, opt => opt.MapFrom(c => c.Donor.Email))
                .ForMember(d => d.Name, opt => opt.MapFrom(c => c.Donor.Name))
                .ForMember(d => d.Phone, opt => opt.MapFrom(c => c.Donor.Phone))
                .ReverseMap();

        }

    }
}