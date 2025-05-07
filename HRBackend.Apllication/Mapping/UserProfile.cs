using AutoMapper;
using HRBackend.Domain.Entities;
using HRBackend.Application.DTO;

namespace HRBackend.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>(); 
        }
    }
}
