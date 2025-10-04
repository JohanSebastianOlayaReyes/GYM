using Utilities.Interfaces;
using System.Globalization;

namespace Utilities.Helpers
{
    /// <summary>
    /// Implementación de la interfaz IDatetimeHelper que proporciona funcionalidades
    /// para manipular fechas y horas en diferentes formatos y zonas horarias.
    /// </summary>
    public class DatetimeHelper : IDatetimeHelper
    {
        /// <summary>
        /// Obtiene la fecha y hora actual en UTC (Tiempo Universal Coordinado).
        /// </summary>
        /// <returns>Un objeto DateTime que representa la fecha y hora actual en formato UTC.</returns>
        public DateTime GetCurrentUtcDateTime()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Convierte una fecha y hora UTC a una zona horaria local específica.
        /// </summary>
        /// <param name="utcDateTime">La fecha y hora en formato UTC que se va a convertir.</param>
        /// <param name="timeZoneId">El identificador de la zona horaria de destino.</param>
        /// <returns>Un objeto DateTime que representa la fecha y hora convertida a la zona. 
        /// "Cent horaria especificada.</returns>
        /// <exception cref="TimeZoneNotFoundException">Se lanza cuando no se encuentra la zona horaria especificada.</exception>
        /// <exception cref="InvalidTimeZoneException">Se lanza cuando la zona horaria especificada contiene datos no válidos.</exception>
        public DateTime ConvertToLocalTime(DateTime utcDateTime, string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
        }

        /// <summary>
        /// Convierte una fecha y hora local a UTC (Tiempo Universal Coordinado).
        /// </summary>
        /// <param name="localDateTime">La fecha y hora local que se va a convertir.</param>
        /// <param name="timeZoneId">El identificador de la zona horaria de origen.</param>
        /// <returns>Un objeto DateTime que representa la fecha y hora convertida a UTC.</returns>
        /// <exception cref="TimeZoneNotFoundException">Se lanza cuando no se encuentra la zona horaria especificada.</exception>
        /// <exception cref="InvalidTimeZoneException">Se lanza cuando la zona horaria especificada contiene datos no válidos.</exception>
        public DateTime ConvertToUtc(DateTime localDateTime, string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZone);
        }

        /// <summary>
        /// Formatea una fecha y hora según el formato especificado.
        /// </summary>
        /// <param name="dateTime">La fecha y hora que se va a formatear.</param>
        /// <param name="format">El formato de salida (opcional). Si no se especifica, se utiliza "yyyy-MM-dd HH:mm:ss".</param>
        /// <returns>Una cadena que representa la fecha y hora con el formato especificado.</returns>
        public string FormatDateTime(DateTime dateTime, string format = null)
        {
            if (string.IsNullOrWhiteSpace(format))
                format = "yyyy-MM-dd HH:mm:ss";

            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Calcula la edad en años a partir de una fecha de nacimiento.
        /// </summary>
        /// <param name="birthDate">La fecha de nacimiento para calcular la edad.</param>
        /// <returns>Un entero que representa la edad en años.</returns>
        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            // Ajustar si el cumpleaños aún no ha ocurrido este año
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        /// <summary>
        /// Determina si una fecha corresponde a un fin de semana (sábado o domingo).
        /// </summary>
        /// <param name="date">La fecha a evaluar.</param>
        /// <returns>True si la fecha es un fin de semana, False en caso contrario.</returns>
        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determina si una fecha y hora corresponde a un horario laboral.
        /// </summary>
        /// <param name="dateTime">La fecha y hora a evaluar.</param>
        /// <param name="startHour">La hora de inicio del horario laboral (predeterminada: 9).</param>
        /// <param name="endHour">La hora de fin del horario laboral (predeterminada: 17).</param>
        /// <returns>True si es horario laboral, False en caso contrario.</returns>
        public bool IsBusinessHour(DateTime dateTime, int startHour = 9, int endHour = 17)
        {
            if (IsWeekend(dateTime))
                return false;

            int hour = dateTime.Hour;
            return hour >= startHour && hour < endHour;
        }
    }
}