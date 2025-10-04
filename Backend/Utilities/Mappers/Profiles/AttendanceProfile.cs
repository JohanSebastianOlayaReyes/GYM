using AutoMapper;
using Entity.Dtos.AttendanceDTO;
using Gym;

namespace Utilities.Mappers.Profiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
        }
    }
}
