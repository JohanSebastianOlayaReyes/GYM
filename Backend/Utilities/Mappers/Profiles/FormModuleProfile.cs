using AutoMapper;
using Entity.Dtos.FormModuleDto;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class FormModuleProfile : Profile
    {
        public FormModuleProfile() { 
            CreateMap<FormModule, FormModuleDto>().ReverseMap();
        }
    }
}
