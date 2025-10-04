using System;

namespace Utilities.Interfaces
{
    /// <summary>
    /// Interfaz para operaciones relacionadas con fechas y horas
    /// </summary>
    public interface IDatetimeHelper
    {
        /// <summary>
        /// Obtiene la fecha y hora actual en UTC
        /// </summary>
        /// <returns>La fecha y hora UTC actual</returns>
        DateTime GetCurrentUtcDateTime();

        /// <summary>
        /// Convierte una fecha y hora UTC a la zona horaria local especificada
        /// </summary>
        /// <param name="utcDateTime">La fecha y hora UTC</param>
        /// <param name="timeZoneId">El identificador de la zona horaria</param>
        /// <returns>La fecha y hora convertida a la zona horaria local</returns>
        DateTime ConvertToLocalTime(DateTime utcDateTime, string timeZoneId);

        /// <summary>
        /// Convierte una fecha y hora local a UTC
        /// </summary>
        /// <param name="localDateTime">La fecha y hora local</param>
        /// <param name="timeZoneId">El identificador de la zona horaria</param>
        /// <returns>La fecha y hora convertida a UTC</returns>
        DateTime ConvertToUtc(DateTime localDateTime, string timeZoneId);

        /// <summary>
        /// Formatea una fecha y hora según el formato especificado
        /// </summary>
        /// <param name="dateTime">La fecha y hora a formatear</param>
        /// <param name="format">El formato de salida (opcional)</param>
        /// <returns>La fecha y hora formateada como cadena</returns>
        string FormatDateTime(DateTime dateTime, string format = null);

        /// <summary>
        /// Calcula la edad en años a partir de una fecha de nacimiento
        /// </summary>
        /// <param name="birthDate">La fecha de nacimiento</param>
        /// <returns>La edad en años</returns>
        int CalculateAge(DateTime birthDate);

        /// <summary>
        /// Determina si una fecha corresponde a un fin de semana (sábado o domingo)
        /// </summary>
        /// <param name="date">La fecha a evaluar</param>
        /// <returns>True si es fin de semana, False en caso contrario</returns>
        bool IsWeekend(DateTime date);

        /// <summary>
        /// Determina si una fecha y hora corresponde a un horario laboral
        /// </summary>
        /// <param name="dateTime">La fecha y hora a evaluar</param>
        /// <param name="startHour">La hora de inicio del horario laboral (predeterminada: 9)</param>
        /// <param name="endHour">La hora de fin del horario laboral (predeterminada: 17)</param>
        /// <returns>True si es horario laboral, False en caso contrario</returns>
        bool IsBusinessHour(DateTime dateTime, int startHour = 9, int endHour = 17);
    }
}