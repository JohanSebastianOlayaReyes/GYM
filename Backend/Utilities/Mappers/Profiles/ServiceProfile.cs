using AutoMapper;
using Gym;
using Entity.Dtos.ServiceDTO;

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
