using AutoMapper;
using Entity.Dtos.NeighborhoodDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class NeighborhoodProfile : Profile
    {
        public NeighborhoodProfile()
        {
             CreateMap<Neighborhood, NeighborhoodDto>().ReverseMap();
        }
    }
}
