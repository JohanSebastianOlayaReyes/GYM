using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Gym;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.AttendanceData
{
    /// <summary>
    /// Implementación de operaciones de acceso a datos para asistencias del gimnasio
    /// </summary>
    public class AttendanceData : BaseModelData<Attendance>, IAttendanceData
    {
        public AttendanceData(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todas las asistencias de un usuario específico
        /// </summary>
        public async Task<IEnumerable<Attendance>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(a => a.UserId == userId && a.Status)
                .OrderByDescending(a => a.Date)
                .ThenByDescending(a => a.Time)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las asistencias de una fecha específica
        /// </summary>
        public async Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(a => a.Status && a.Date.Date == date.Date)
                .Include(a => a.User)
                .OrderBy(a => a.Time)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene asistencias dentro de un rango de fechas
        /// </summary>
        public async Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(a => a.Status && a.Date >= startDate && a.Date <= endDate)
                .Include(a => a.User)
                .OrderByDescending(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el conteo de asistencias de un usuario en un rango de fechas
        /// </summary>
        public async Task<int> GetAttendanceCountByUserAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(a => a.UserId == userId && a.Status && a.Date >= startDate && a.Date <= endDate)
                .CountAsync();
        }

        /// <summary>
        /// Registra una nueva asistencia para un usuario
        /// </summary>
        public async Task<Attendance> RegisterAttendanceAsync(int userId, string registrationMethod)
        {
            var now = DateTime.UtcNow;
            var attendance = new Attendance
            {
                UserId = userId,
                Date = now,
                Time = now.TimeOfDay,
                RegistrationMethod = registrationMethod,
                Status = true,
                CreatedAt = now
            };

            await _dbSet.AddAsync(attendance);
            await _context.SaveChangesAsync();

            return attendance;
        }

        /// <summary>
        /// Verifica si un usuario ya registró asistencia hoy
        /// </summary>
        public async Task<bool> HasAttendanceTodayAsync(int userId)
        {
            var today = DateTime.UtcNow.Date;
            return await _dbSet
                .AnyAsync(a => a.UserId == userId && a.Status && a.Date.Date == today);
        }

        /// <summary>
        /// Obtiene el total de asistencias del día actual
        /// </summary>
        public async Task<int> GetTodayAttendanceCountAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _dbSet
                .CountAsync(a => a.Status && a.Date.Date == today);
        }

        /// <summary>
        /// Obtiene usuarios con más asistencias en un rango de fechas
        /// </summary>
        public async Task<IEnumerable<(int UserId, string UserName, int AttendanceCount)>> GetTopAttendingUsersAsync(DateTime startDate, DateTime endDate, int topCount)
        {
            return await _dbSet
                .Where(a => a.Status && a.Date >= startDate && a.Date <= endDate)
                .Include(a => a.User)
                .GroupBy(a => new { a.UserId, UserName = a.User.FirstName + " " + a.User.LastName })
                .Select(g => new
                {
                    g.Key.UserId,
                    g.Key.UserName,
                    AttendanceCount = g.Count()
                })
                .OrderByDescending(x => x.AttendanceCount)
                .Take(topCount)
                .AsEnumerable()
                .Select(x => (x.UserId, x.UserName, x.AttendanceCount))
                .ToList();
        }

        /// <summary>
        /// Obtiene el promedio de asistencias diarias en un mes
        /// </summary>
        public async Task<double> GetAverageDailyAttendanceAsync(int month, int year)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var startDate = new DateTime(year, month, 1);
            var endDate = new DateTime(year, month, daysInMonth);

            var totalAttendances = await _dbSet
                .CountAsync(a => a.Status && a.Date >= startDate && a.Date <= endDate);

            return (double)totalAttendances / daysInMonth;
        }
    }
}
