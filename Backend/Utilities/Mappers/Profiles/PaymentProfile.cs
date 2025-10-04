using AutoMapper;
using Entity.Dtos.PaymentDTO;
using Gym;

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
