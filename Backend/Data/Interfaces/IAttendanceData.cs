using Gym;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones de datos específicas de asistencias del gimnasio
    /// </summary>
    public interface IAttendanceData : IBaseModelData<Attendance>
    {
        /// <summary>
        /// Obtiene todas las asistencias de un usuario específico
        /// </summary>
        Task<IEnumerable<Attendance>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Obtiene todas las asistencias de una fecha específica
        /// </summary>
        Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date);

        /// <summary>
        /// Obtiene asistencias dentro de un rango de fechas
        /// </summary>
        Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene el conteo de asistencias de un usuario en un rango de fechas
        /// </summary>
        Task<int> GetAttendanceCountByUserAsync(int userId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Registra una nueva asistencia para un usuario
        /// </summary>
        Task<Attendance> RegisterAttendanceAsync(int userId, string registrationMethod);

        /// <summary>
        /// Verifica si un usuario ya registró asistencia hoy
        /// </summary>
        Task<bool> HasAttendanceTodayAsync(int userId);

        /// <summary>
        /// Obtiene el total de asistencias del día actual
        /// </summary>
        Task<int> GetTodayAttendanceCountAsync();

        /// <summary>
        /// Obtiene usuarios con más asistencias en un rango de fechas
        /// </summary>
        Task<IEnumerable<(int UserId, string UserName, int AttendanceCount)>> GetTopAttendingUsersAsync(DateTime startDate, DateTime endDate, int topCount);

        /// <summary>
        /// Obtiene el promedio de asistencias diarias en un mes
        /// </summary>
        Task<double> GetAverageDailyAttendanceAsync(int month, int year);
    }
}
