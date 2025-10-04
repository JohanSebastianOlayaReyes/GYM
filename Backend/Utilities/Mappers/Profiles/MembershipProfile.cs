using AutoMapper;
using Entity.Dtos.MembershipDTO;
using Gym;

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
