using AutoMapper;
using Entity.Dtos.Permission;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile() 
        { 
              CreateMap<Permission, PermissionDto>().ReverseMap();
        }
    }
}
