using AutoMapper;
using Entity.Dtos.ModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mappers.Profiles
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile() { 
        
           CreateMap<Module, ModuleDto>().ReverseMap();
        }
      }
  }

