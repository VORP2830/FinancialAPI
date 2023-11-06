using AutoMapper;
using Financial.Domain.Entities;

namespace Financial.Application.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Movement, MovementDTO>().ReverseMap();
        }
    }
}