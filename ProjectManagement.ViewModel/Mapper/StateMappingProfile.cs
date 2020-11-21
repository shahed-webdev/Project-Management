using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.ViewModel
{
    public class StateMappingProfile : Profile
    {
        public StateMappingProfile()
        {
            CreateMap<State, StateAddModel>().ReverseMap();
            CreateMap<State, StateViewModel>().ReverseMap();
        }
    }
}