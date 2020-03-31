using AutoMapper;
using ThreeAPIDemo.Dtos;
using ThreeAPIDemo.Models;
using ThreeAPIDemo.Services;

namespace ThreeAPIDemo.Profiles
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<User, UserDto>();
        }

    }
}