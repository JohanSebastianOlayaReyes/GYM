using Business.Interfaces;
using Entity.Dtos.AttendanceDTO;
using Gym;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de asistencias del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceBusiness _attendanceBusiness;

        public AttendanceController(IAttendanceBusiness attendanceBusiness)
        {
            _attendanceBusiness = attendanceBusiness;
        }

        /// <summary>
        /// Obtiene todas las asistencias.
        /// </summary>
        /// <returns>Lista de asistencias.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var attendances = await _attendanceBusiness.GetAllAsync();
                return Ok(new { success = true, data = attendances });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene una asistencia por su ID.
        /// </summary>
        /// <param name="id">ID de la asistencia.</param>
        /// <returns>Datos de la asistencia.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var attendance = await _attendanceBusiness.GetByIdAsync(id);
                if (attendance == null)
                    return NotFound(new { success = false, message = "Asistencia no encontrada" });

                return Ok(new { success = true, data = attendance });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene asistencias por usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de asistencias del usuario.</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var attendances = await _attendanceBusiness.GetByUserIdAsync(userId);
                return Ok(new { success = true, data = attendances });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene asistencias de una fecha específica.
        /// </summary>
        /// <param name="date">Fecha a consultar.</param>
        /// <returns>Lista de asistencias de la fecha.</returns>
        [HttpGet("date")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
        {
            try
            {
                var attendances = await _attendanceBusiness.GetByDateAsync(date);
                return Ok(new { success = true, data = attendances });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene las asistencias del día de hoy.
        /// </summary>
        /// <returns>Lista de asistencias de hoy.</returns>
        [HttpGet("today")]
        public async Task<IActionResult> GetToday()
        {
            try
            {
                var today = DateTime.Today;
                var attendances = await _attendanceBusiness.GetByDateAsync(today);
                return Ok(new { success = true, data = attendances });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el conteo de asistencias del día.
        /// </summary>
        /// <returns>Número de asistencias registradas hoy.</returns>
        [HttpGet("today/count")]
        public async Task<IActionResult> GetTodayCount()
        {
            try
            {
                var count = await _attendanceBusiness.GetTodayAttendanceCountAsync();
                return Ok(new { success = true, data = count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Verifica si un usuario ya registró asistencia hoy.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>True si ya asistió hoy, false en caso contrario.</returns>
        [HttpGet("user/{userId}/has-attended-today")]
        public async Task<IActionResult> HasAttendedToday(int userId)
        {
            try
            {
                var hasAttended = await _attendanceBusiness.HasAttendanceTodayAsync(userId);
                return Ok(new { success = true, data = hasAttended });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene asistencias por rango de fechas.
        /// </summary>
        /// <param name="startDate">Fecha inicial.</param>
        /// <param name="endDate">Fecha final.</param>
        /// <returns>Lista de asistencias en el rango.</returns>
        [HttpGet("range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var attendances = await _attendanceBusiness.GetByDateRangeAsync(startDate, endDate);
                return Ok(new { success = true, data = attendances });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el conteo de asistencias de un usuario en un rango de fechas.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="startDate">Fecha inicial.</param>
        /// <param name="endDate">Fecha final.</param>
        /// <returns>Número de asistencias del usuario en el rango.</returns>
        [HttpGet("user/{userId}/count")]
        public async Task<IActionResult> GetCountByUser(int userId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var count = await _attendanceBusiness.GetAttendanceCountByUserAsync(userId, startDate, endDate);
                return Ok(new { success = true, data = count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Registra una nueva asistencia para un usuario.
        /// Simplificado para el frontend: solo marca asistencia del día actual.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <param name="registrationMethod">Método de registro (opcional, default: "Manual").</param>
        /// <returns>Asistencia registrada.</returns>
        [HttpPost("register/{userId}")]
        public async Task<IActionResult> RegisterAttendance(int userId, [FromQuery] string registrationMethod = "Manual")
        {
            try
            {
                // Verificar si ya tiene asistencia hoy
                var hasAttended = await _attendanceBusiness.HasAttendanceTodayAsync(userId);
                if (hasAttended)
                {
                    return BadRequest(new { success = false, message = "El usuario ya registró asistencia hoy" });
                }

                var attendance = await _attendanceBusiness.RegisterAttendanceAsync(userId, registrationMethod);
                return Ok(new { success = true, data = attendance, message = "Asistencia registrada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva asistencia manualmente (con todos los datos).
        /// </summary>
        /// <param name="attendanceDto">Datos de la asistencia a crear.</param>
        /// <returns>Asistencia creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttendanceDto attendanceDto)
        {
            try
            {
                var createdAttendance = await _attendanceBusiness.CreateAsync(attendanceDto);
                return CreatedAtAction(nameof(GetById), new { id = createdAttendance.Id },
                    new { success = true, data = createdAttendance, message = "Asistencia creada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza una asistencia existente.
        /// </summary>
        /// <param name="id">ID de la asistencia a actualizar.</param>
        /// <param name="updateDto">Datos actualizados de la asistencia.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AttendanceUpdateDto updateDto)
        {
            try
            {
                var attendanceDto = new AttendanceDto
                {
                    Id = id,
                    UserId = updateDto.UserId,
                    Date = updateDto.Date,
                    Time = updateDto.Time,
                    RegistrationMethod = updateDto.RegistrationMethod,
                    Status = updateDto.Status
                };
                var result = await _attendanceBusiness.UpdateAsync(attendanceDto);

                if (result != null)
                    return Ok(new { success = true, message = "Asistencia actualizada exitosamente", data = result });

                return BadRequest(new { success = false, message = "No se pudo actualizar la asistencia" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente una asistencia.
        /// </summary>
        /// <param name="id">ID de la asistencia a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _attendanceBusiness.DeleteAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Asistencia eliminada exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar la asistencia" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
