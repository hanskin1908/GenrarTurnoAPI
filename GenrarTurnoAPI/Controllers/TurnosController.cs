using GenrarTurnoAPI.Negocio.Dto;
using GenrarTurnoAPI.Negocio.Interface;
using GenrarTurnoAPI.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenrarTurnoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private  ITurno _turnosservicio;
        IConfiguration _configuration;
        ITurnoRepository TurnoRepository;

        public TurnosController(ITurno turno, IConfiguration configuration,ITurnoRepository turnoRepository)
        {
            _turnosservicio = turno;
            _configuration = configuration;
            TurnoRepository = turnoRepository;
        }


        [HttpPost]
        [Route("GenerarTurnos")]
        public IActionResult GenerarTurnos([FromBody]
        TurnoDTO turnodto)
        {
            try
            {
               
             
                if (!IsValidDateFormat(turnodto.FechaInicio.ToString()) || !IsValidDateFormat(turnodto.FechaFin.ToString() ))
                {
                    return BadRequest("El formato de la fecha debe ser dd/mm/yyyy.");
                }
                string format = "dd/mm/yyyy";

                DateTime fechainicio = DateTime.Parse(turnodto.FechaInicio);
                DateTime fechafin = DateTime.Parse(turnodto.FechaFin);
                // Validar las fechas y otros parámetros según sea
                TurnoRequestDto turnoRequestDto = new TurnoRequestDto()
                {
                    FechaFin=fechafin,
                    FechaInicio=fechainicio,
                    IdServicio=turnodto.IdServicio,
                };
                if (fechainicio > fechafin)
                {
                    return BadRequest("La fecha de inicio debe ser anterior o igual a la fecha de fin.");
                }

             

                List<TurnoResponseDto> turnosGenerados = _turnosservicio.GenerarTurnos (turnoRequestDto);
                // Llamar al procedimiento almacenado
                //   _context.GenerarTurnos(fechaInicio, fechaFin, idServicio);

                return Ok(turnosGenerados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al generar turnos: {ex.Message}");
            }
        }


        private bool IsValidDateFormat(string date)
        {
           
            bool isvalid= DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out _);
            return isvalid;
        }




    }
}
