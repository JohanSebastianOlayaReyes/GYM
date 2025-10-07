using AutoMapper;
using Gym;
using Entity.Dtos.MembershipDTO;

namespace Utilities.Mappers.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<Membership, MembershipDto>().ReverseMap();
        }
    }
}
