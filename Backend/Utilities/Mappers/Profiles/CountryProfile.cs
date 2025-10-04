using AutoMapper;
using Entity.Dtos.CountryDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {

            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
