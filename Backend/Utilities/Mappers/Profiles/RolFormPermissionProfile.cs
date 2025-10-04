using AutoMapper;
using Entity.Dtos.RolFormPermissionDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
     public class RolFormPermissionProfile : Profile
    {
        public RolFormPermissionProfile() 
        {
            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();
        }
    }
}
