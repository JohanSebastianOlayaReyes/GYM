using AutoMapper;
using Entity.Dtos.ProfitReportDTO;
using Gym;

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
