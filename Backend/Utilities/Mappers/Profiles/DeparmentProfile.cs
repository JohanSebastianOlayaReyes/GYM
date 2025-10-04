using AutoMapper;
using Entity.Dtos.DeparmentDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class DeparmentProfile : Profile
    {
        public DeparmentProfile()
        {

            CreateMap<Deparment, DeparmentDto>().ReverseMap();
        }
    }
}
