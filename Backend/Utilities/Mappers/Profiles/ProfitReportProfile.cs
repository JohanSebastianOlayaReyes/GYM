using AutoMapper;
using Gym;
using Entity.Dtos.ProfitReportDTO;

namespace Utilities.Mappers.Profiles
{
    public class ProfitReportProfile : Profile
    {
        public ProfitReportProfile()
        {
            CreateMap<ProfitReport, ProfitReportDto>().ReverseMap();
        }
    }
}
