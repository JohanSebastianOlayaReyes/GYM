using AutoMapper;
using Entity.Dtos.Employed;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class EmployedProfile : Profile
    {
        public EmployedProfile()
        {

            CreateMap<Employed, EmployedDto>().ReverseMap();
        }  
    }
}
