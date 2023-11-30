using GenrarTurnoAPI.Negocio.Dto;
using GenrarTurnoAPI.Negocio.Servicio;

namespace GenrarTurnoAPI.Repositorio.Interface
{
    public interface ITurnoRepository
    {
        List<TurnoResponseDto> GenerarTurnos(TurnoRequestDto turnoRequestDto);
    }
}
