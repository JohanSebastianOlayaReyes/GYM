using AutoMapper;
using Gym;
using Entity.Dtos.NotificationDTO;

namespace Utilities.Mappers.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
}
