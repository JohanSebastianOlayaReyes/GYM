using AutoMapper;
using Gym;
using Entity.Dtos.PaymentDTO;

namespace Utilities.Mappers.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
