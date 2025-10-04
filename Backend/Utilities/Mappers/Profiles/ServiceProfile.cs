using AutoMapper;
using Entity.Dtos.ServiceDTO;
using Gym;

namespace Utilities.Mappers.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDTO>().ReverseMap();
        }
    }
}
