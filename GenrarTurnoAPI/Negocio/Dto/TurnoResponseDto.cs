namespace GenrarTurnoAPI.Negocio.Dto
{
    public class TurnoResponseDto
    {

        public int IdTurno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int IdServicio { get; set; }

        public string FechaTurno { get; set; }

    }
}
