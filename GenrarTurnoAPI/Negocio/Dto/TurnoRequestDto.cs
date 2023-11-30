using Microsoft.VisualBasic;

namespace GenrarTurnoAPI.Negocio.Dto
{
    public class TurnoRequestDto
    {

   
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdServicio { get; set; }

   
    }
}
