using GenrarTurnoAPI.Negocio.Dto;

namespace GenrarTurnoAPI.Negocio.Interface
{
    public interface ITurno
    {
        List<TurnoResponseDto> GenerarTurnos(TurnoRequestDto turnorequest);
    }
}
