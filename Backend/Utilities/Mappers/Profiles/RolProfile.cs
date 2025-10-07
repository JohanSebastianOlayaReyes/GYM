using AutoMapper;
using Entity.Model;
using Entity.Dtos.RolDTO;

namespace Utilities.Mappers.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            // Mapeo de Role a RoleDto y viceversa
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}