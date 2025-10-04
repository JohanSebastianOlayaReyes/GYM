using Business.Interfaces;
using Entity.Dtos.AttendanceDTO;
using Gym;

namespace Business.Interfaces
{
    public interface IAttendanceBusiness : IBaseBusiness<Attendance, AttendanceDto>
    {
        Task<IEnumerable<AttendanceDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<AttendanceDto>> GetByDateAsync(DateTime date);
        Task<IEnumerable<AttendanceDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<int> GetAttendanceCountByUserAsync(int userId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Registra una nueva asistencia para un usuario
        /// </summary>
        /// <param name="userId">ID del usuario</param>
        /// <param name="registrationMethod">Método de registro (manual, QR, biométrico, etc.)</param>
        /// <returns>La asistencia registrada</returns>
        Task<AttendanceDto> RegisterAttendanceAsync(int userId, string registrationMethod);

        /// <summary>
        /// Verifica si un usuario ya registró asistencia el día de hoy
        /// </summary>
        /// <param name="userId">ID del usuario a verificar</param>
        /// <returns>True si ya registró asistencia hoy, false en caso contrario</returns>
        Task<bool> HasAttendanceTodayAsync(int userId);

        /// <summary>
        /// Obtiene el número total de asistencias registradas el día de hoy
        /// </summary>
        /// <returns>Cantidad de asistencias del día</returns>
        Task<int> GetTodayAttendanceCountAsync();

        /// <summary>
        /// Obtiene los usuarios con mayor asistencia en un rango de fechas
        /// </summary>
        /// <param name="startDate">Fecha inicial</param>
        /// <param name="endDate">Fecha final</param>
        /// <param name="topCount">Cantidad de usuarios a retornar</param>
        /// <returns>Diccionario con el ID del usuario como clave y el conteo de asistencias como valor</returns>
        Task<Dictionary<int, int>> GetTopAttendingUsersAsync(DateTime startDate, DateTime endDate, int topCount);

        /// <summary>
        /// Obtiene el promedio de asistencia diaria para un mes específico
        /// </summary>
        /// <param name="month">Mes a consultar</param>
        /// <param name="year">Año a consultar</param>
        /// <returns>Promedio de asistencias diarias</returns>
        Task<double> GetAverageDailyAttendanceAsync(int month, int year);
    }
}
