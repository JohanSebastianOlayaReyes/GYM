using AutoMapper;
using Entity.Dtos.NotificationDTO;
using Gym;

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
