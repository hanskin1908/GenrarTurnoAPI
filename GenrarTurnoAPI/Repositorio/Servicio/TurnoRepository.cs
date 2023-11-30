using GenrarTurnoAPI.Negocio.Dto;
using GenrarTurnoAPI.Negocio.Servicio;
using GenrarTurnoAPI.Repositorio.Interface;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GenrarTurnoAPI.Repositorio.Servicio
{
    public class TurnoRepository : ITurnoRepository
    {
        IConfiguration _configuration;
        private string _connectionString;
  
      

       public TurnoRepository(IConfiguration config)
        {
            _configuration = config;
            

        }
        public List<TurnoResponseDto> GenerarTurnos(TurnoRequestDto turnoRequestDto)

        {
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            var turnosGenerados = new List<TurnoResponseDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GenerarTurnos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros requeridos por el procedimiento almacenado
                    command.Parameters.AddWithValue("@FechaInicio", turnoRequestDto.FechaInicio );
                    command.Parameters.AddWithValue("@FechaFin", turnoRequestDto.FechaFin);
                    command.Parameters.AddWithValue("@IdServicio",turnoRequestDto.IdServicio);

                    try
                    {
                        // Ejecutar el procedimiento almacenado
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var turno = new TurnoResponseDto
                                {
                                    IdTurno = Convert.ToInt32(reader["IdTurno"]),
                                    FechaTurno= Convert.ToDateTime(reader["fecha_turno"]).ToShortDateString(),
                                    HoraInicio= (TimeSpan)(reader["hora_inicio"]),
                                      HoraFin = (TimeSpan)(reader["hora_fin"]),
                                      IdServicio = Convert.ToInt32(reader["IdServicio"]),
                                  
                                };

                                turnosGenerados.Add(turno);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejar la excepción según tus necesidades
                        throw new Exception($"Error al ejecutar el procedimiento almacenado: {ex.Message}");
                    }
                }
            }

            return turnosGenerados;
        }

     
    }
}
