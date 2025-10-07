using Business.Interfaces;
using Entity.Dtos.PaymentDTO;
using Gym;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de pagos del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentController(IPaymentBusiness paymentBusiness)
        {
            _paymentBusiness = paymentBusiness;
        }

        /// <summary>
        /// Obtiene todos los pagos.
        /// </summary>
        /// <returns>Lista de pagos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var payments = await _paymentBusiness.GetAllAsync();
                return Ok(new { success = true, data = payments });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un pago por su ID.
        /// </summary>
        /// <param name="id">ID del pago.</param>
        /// <returns>Datos del pago.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var payment = await _paymentBusiness.GetByIdAsync(id);
                if (payment == null)
                    return NotFound(new { success = false, message = "Pago no encontrado" });

                return Ok(new { success = true, data = payment });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene pagos por usuario.
        /// </summary>
        /// <param name="userId">ID del usuario.</param>
        /// <returns>Lista de pagos del usuario.</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var payments = await _paymentBusiness.GetByUserIdAsync(userId);
                return Ok(new { success = true, data = payments });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene pagos por membresía.
        /// </summary>
        /// <param name="membershipId">ID de la membresía.</param>
        /// <returns>Lista de pagos de la membresía.</returns>
        [HttpGet("membership/{membershipId}")]
        public async Task<IActionResult> GetByMembershipId(int membershipId)
        {
            try
            {
                var payments = await _paymentBusiness.GetByMembershipIdAsync(membershipId);
                return Ok(new { success = true, data = payments });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene pagos por rango de fechas.
        /// </summary>
        /// <param name="startDate">Fecha inicial.</param>
        /// <param name="endDate">Fecha final.</param>
        /// <returns>Lista de pagos en el rango.</returns>
        [HttpGet("range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var payments = await _paymentBusiness.GetPaymentsByDateRangeAsync(startDate, endDate);
                return Ok(new { success = true, data = payments });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene los pagos más recientes.
        /// </summary>
        /// <param name="count">Cantidad de pagos a retornar.</param>
        /// <returns>Lista de pagos recientes.</returns>
        [HttpGet("recent/{count}")]
        public async Task<IActionResult> GetRecent(int count = 10)
        {
            try
            {
                var payments = await _paymentBusiness.GetRecentPaymentsAsync(count);
                return Ok(new { success = true, data = payments });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el ingreso total de un mes.
        /// </summary>
        /// <param name="month">Mes (1-12).</param>
        /// <param name="year">Año.</param>
        /// <returns>Total de ingresos del mes.</returns>
        [HttpGet("income/month")]
        public async Task<IActionResult> GetMonthlyIncome([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var total = await _paymentBusiness.GetTotalIncomeByMonthAsync(month, year);
                return Ok(new { success = true, data = total });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene estadísticas de pagos por método.
        /// </summary>
        /// <param name="month">Mes (1-12).</param>
        /// <param name="year">Año.</param>
        /// <returns>Estadísticas agrupadas por método de pago.</returns>
        [HttpGet("stats/method")]
        public async Task<IActionResult> GetStatsByMethod([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var stats = await _paymentBusiness.GetPaymentStatsByMethodAsync(month, year);
                return Ok(new { success = true, data = stats });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo pago.
        /// </summary>
        /// <param name="paymentDto">Datos del pago a crear.</param>
        /// <returns>Pago creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentDto paymentDto)
        {
            try
            {
                var createdPayment = await _paymentBusiness.CreateAsync(paymentDto);
                return CreatedAtAction(nameof(GetById), new { id = createdPayment.Id },
                    new { success = true, data = createdPayment, message = "Pago registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un pago existente.
        /// </summary>
        /// <param name="id">ID del pago a actualizar.</param>
        /// <param name="updateDto">Datos actualizados del pago.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentUpdateDto updateDto)
        {
            try
            {
                updateDto.Id = id;
                var result = await _paymentBusiness.UpdateAsync(updateDto);

                if (result)
                    return Ok(new { success = true, message = "Pago actualizado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo actualizar el pago" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina lógicamente un pago.
        /// </summary>
        /// <param name="id">ID del pago a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteDto = new DeleteLogicalPaymentDto { Id = id, Status = false };
                var result = await _paymentBusiness.DeleteAsync(deleteDto);

                if (result)
                    return Ok(new { success = true, message = "Pago eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el pago" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
