using Business.Interfaces;
using Entity.Dtos.ProfitReportDTO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de reportes de ganancias del gimnasio.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfitReportController : ControllerBase
    {
        private readonly IProfitReportBusiness _profitReportBusiness;

        public ProfitReportController(IProfitReportBusiness profitReportBusiness)
        {
            _profitReportBusiness = profitReportBusiness;
        }

        /// <summary>
        /// Obtiene todos los reportes de ganancias.
        /// </summary>
        /// <returns>Lista de reportes.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var reports = await _profitReportBusiness.GetAllAsync();
                return Ok(new { success = true, data = reports });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un reporte de ganancias por su ID.
        /// </summary>
        /// <param name="id">ID del reporte.</param>
        /// <returns>Datos del reporte.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var report = await _profitReportBusiness.GetByIdAsync(id);
                if (report == null)
                    return NotFound(new { success = false, message = "Reporte no encontrado" });

                return Ok(new { success = true, data = report });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el reporte de un mes y año específicos.
        /// </summary>
        /// <param name="month">Mes (1-12).</param>
        /// <param name="year">Año.</param>
        /// <returns>Reporte del mes especificado.</returns>
        [HttpGet("month/{year}/{month}")]
        public async Task<IActionResult> GetByMonthYear(int year, int month)
        {
            try
            {
                var report = await _profitReportBusiness.GetByMonthYearAsync(month, year);
                if (report == null)
                    return NotFound(new { success = false, message = "Reporte no encontrado para el mes y año especificados" });

                return Ok(new { success = true, data = report });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene todos los reportes de un año específico.
        /// </summary>
        /// <param name="year">Año a consultar.</param>
        /// <returns>Lista de reportes del año.</returns>
        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetByYear(int year)
        {
            try
            {
                var reports = await _profitReportBusiness.GetByYearAsync(year);
                return Ok(new { success = true, data = reports });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el total de ganancias de un año.
        /// </summary>
        /// <param name="year">Año a consultar.</param>
        /// <returns>Total de ganancias del año.</returns>
        [HttpGet("year/{year}/total")]
        public async Task<IActionResult> GetYearlyTotal(int year)
        {
            try
            {
                var total = await _profitReportBusiness.GetYearlyTotalAsync(year);
                return Ok(new { success = true, data = total });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene el mes con mayores ganancias de un año.
        /// </summary>
        /// <param name="year">Año a consultar.</param>
        /// <returns>Reporte del mejor mes.</returns>
        [HttpGet("year/{year}/best-month")]
        public async Task<IActionResult> GetBestMonth(int year)
        {
            try
            {
                var report = await _profitReportBusiness.GetBestMonthAsync(year);
                if (report == null)
                    return NotFound(new { success = false, message = "No se encontraron reportes para el año especificado" });

                return Ok(new { success = true, data = report });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Compara los reportes de dos años.
        /// </summary>
        /// <param name="year1">Primer año a comparar.</param>
        /// <param name="year2">Segundo año a comparar.</param>
        /// <returns>Datos de comparación.</returns>
        [HttpGet("compare/{year1}/{year2}")]
        public async Task<IActionResult> CompareYears(int year1, int year2)
        {
            try
            {
                var comparison = await _profitReportBusiness.GetComparisonByYearAsync(year1, year2);
                return Ok(new { success = true, data = comparison });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Genera un nuevo reporte de ganancias para un mes y año específicos.
        /// </summary>
        /// <param name="month">Mes (1-12).</param>
        /// <param name="year">Año.</param>
        /// <returns>Reporte generado.</returns>
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var report = await _profitReportBusiness.GenerateReportAsync(month, year);
                return Ok(new { success = true, data = report, message = "Reporte generado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo reporte de ganancias.
        /// </summary>
        /// <param name="reportDto">Datos del reporte a crear.</param>
        /// <returns>Reporte creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfitReportDto reportDto)
        {
            try
            {
                var createdReport = await _profitReportBusiness.CreateAsync(reportDto);
                return CreatedAtAction(nameof(GetById), new { id = createdReport.Id },
                    new { success = true, data = createdReport, message = "Reporte creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un reporte de ganancias existente.
        /// </summary>
        /// <param name="id">ID del reporte a actualizar.</param>
        /// <param name="reportDto">Datos actualizados del reporte.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfitReportDto reportDto)
        {
            try
            {
                reportDto.Id = id;
                var result = await _profitReportBusiness.UpdateAsync(reportDto);

                if (result != null)
                    return Ok(new { success = true, message = "Reporte actualizado exitosamente", data = result });

                return BadRequest(new { success = false, message = "No se pudo actualizar el reporte" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un reporte de ganancias.
        /// </summary>
        /// <param name="id">ID del reporte a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _profitReportBusiness.DeleteAsync(id);

                if (result)
                    return Ok(new { success = true, message = "Reporte eliminado exitosamente" });

                return BadRequest(new { success = false, message = "No se pudo eliminar el reporte" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
