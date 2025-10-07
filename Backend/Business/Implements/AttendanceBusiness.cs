using AutoMapper;
using Business.Implements;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.AttendanceDTO;
using Gym;
using Microsoft.Extensions.Logging;
using Utilities.Interfaces;

namespace Business.Implements
{
    public class AttendanceBusiness : BaseBusiness<Attendance, AttendanceDto>, IAttendanceBusiness
    {
        private readonly IAttendanceData _attendanceData;

        public AttendanceBusiness(
            IAttendanceData data,
            IMapper mapper,
            ILogger<AttendanceBusiness> logger,
            IGenericIHelpers helpers)
            : base(data, mapper, logger, helpers)
        {
            _attendanceData = data;
        }

        public async Task<IEnumerable<AttendanceDto>> GetByUserIdAsync(int userId)
        {
            try
            {
                var attendances = await _attendanceData.GetByUserIdAsync(userId);
                return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener asistencias del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AttendanceDto>> GetByDateAsync(DateTime date)
        {
            try
            {
                var attendances = await _attendanceData.GetByDateAsync(date);
                return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener asistencias de la fecha {date}: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<AttendanceDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var attendances = await _attendanceData.GetByDateRangeAsync(startDate, endDate);
                return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener asistencias por rango de fechas: {ex.Message}");
                throw;
            }
        }

        public async Task<int> GetAttendanceCountByUserAsync(int userId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _attendanceData.GetAttendanceCountByUserAsync(userId, startDate, endDate);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al contar asistencias del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Registra una nueva asistencia para un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <param name="registrationMethod">Método de registro (manual, QR, biométrico, etc.)</param>
        /// <returns>La asistencia registrada</returns>
        public async Task<AttendanceDto> RegisterAttendanceAsync(int userId, string registrationMethod)
        {
            try
            {
                var attendance = await _attendanceData.RegisterAttendanceAsync(userId, registrationMethod);
                return _mapper.Map<AttendanceDto>(attendance);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al registrar asistencia del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica si un usuario ya registró asistencia el día de hoy
        /// </summary>
        /// <param name="userId">ID del usuario a verificar</param>
        /// <returns>True si ya registró asistencia hoy, false en caso contrario</returns>
        public async Task<bool> HasAttendanceTodayAsync(int userId)
        {
            try
            {
                return await _attendanceData.HasAttendanceTodayAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al verificar asistencia del día del usuario {userId}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el número total de asistencias registradas el día de hoy
        /// </summary>
        /// <returns>Cantidad de asistencias del día</returns>
        public async Task<int> GetTodayAttendanceCountAsync()
        {
            try
            {
                return await _attendanceData.GetTodayAttendanceCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener cantidad de asistencias del día: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene los usuarios con mayor asistencia en un rango de fechas
        /// </summary>
        /// <param name="startDate">Fecha inicial</param>
        /// <param name="endDate">Fecha final</param>
        /// <param name="topCount">Cantidad de usuarios a retornar</param>
        /// <returns>Diccionario con el ID del usuario como clave y el conteo de asistencias como valor</returns>
        public async Task<IEnumerable<(int UserId, string UserName, int AttendanceCount)>> GetTopAttendingUsersAsync(DateTime startDate, DateTime endDate, int topCount)
        {
            try
            {
                return await _attendanceData.GetTopAttendingUsersAsync(startDate, endDate, topCount);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener top {topCount} usuarios con mayor asistencia: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el promedio de asistencia diaria para un mes específico
        /// </summary>
        /// <param name="month">Mes a consultar</param>
        /// <param name="year">Año a consultar</param>
        /// <returns>Promedio de asistencias diarias</returns>
        public async Task<double> GetAverageDailyAttendanceAsync(int month, int year)
        {
            try
            {
                return await _attendanceData.GetAverageDailyAttendanceAsync(month, year);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener promedio de asistencia diaria del mes {month}/{year}: {ex.Message}");
                throw;
            }
        }
    }
}
