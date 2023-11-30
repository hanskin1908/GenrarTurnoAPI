using GenrarTurnoAPI.Negocio.Dto;
using GenrarTurnoAPI.Negocio.Interface;
using GenrarTurnoAPI.Repositorio.Interface;
using GenrarTurnoAPI.Repositorio.Servicio;
using Microsoft.AspNetCore.Identity;

namespace GenrarTurnoAPI.Negocio.Servicio
{
    public class Turno:ITurno
    {
      private readonly  IConfiguration _configuration;
        private readonly ITurnoRepository _turnoRepository;
        public Turno( IConfiguration configuration, ITurnoRepository turnoRepository)
        {
          
            _configuration = configuration;
           _turnoRepository = turnoRepository;
        }




        public List<TurnoResponseDto> GenerarTurnos(TurnoRequestDto   turnorequest)
        {
            
            if (turnorequest.FechaInicio > turnorequest.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio debe ser anterior o igual a la fecha de fin.");
            }

         
            // Llamar al método del repositorio
            List<TurnoResponseDto> turnoResponse = _turnoRepository.GenerarTurnos(turnorequest);

            return turnoResponse;
        }
    }
}
