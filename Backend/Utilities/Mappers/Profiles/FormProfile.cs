using AutoMapper;
using Entity.Dtos.FormDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
     public class FormProfile : Profile
    {
        public FormProfile() { 
            CreateMap<Form, FormDto>().ReverseMap();
        }
    }
}
