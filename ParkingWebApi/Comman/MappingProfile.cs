using AutoMapper;
using ParkingApp_Core.Models;
using ParkingWebApi.Application.UserOperations.Commands.LoginUser;
using ParkingWebApi.Application.UserOperations.Queries.GetUsers;

namespace ParkingWebApi.Comman
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Point, opt => opt
                .MapFrom(src => src.Score.Point));
            
        }
    }
}
