using GenrarTurnoAPI.Negocio.Dto;
using GenrarTurnoAPI.Negocio.Servicio;
using GenrarTurnoAPI.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using Moq;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void GenerarTurnos_DeberiaDevolverTurnos()
        {
            IConfiguration configuration;
            // Arrange: Configurar el entorno de prueba, incluidos los mocks si es necesario
            var mockTurnoRepository = new Mock<ITurnoRepository>();
            var turnoService = new Turno(null, mockTurnoRepository.Object);

            var turnoRequestDto = new TurnoRequestDto
            {
                IdServicio = 2,
                 FechaInicio= new DateTime(2023, 12, 13),
                FechaFin = new DateTime(2023, 12, 13)
            };
            mockTurnoRepository.Setup(repo => repo.GenerarTurnos(turnoRequestDto))
          .Returns(new List<TurnoResponseDto>
          {
                new TurnoResponseDto { IdTurno = 2,FechaTurno="2023-12-13",HoraInicio=DateTime.Now.TimeOfDay ,HoraFin=DateTime.Now.TimeOfDay /* Otras propiedades */ },
                new TurnoResponseDto { IdTurno = 2,FechaTurno="2023-12-13",HoraInicio=DateTime.Now.TimeOfDay ,HoraFin=DateTime.Now.TimeOfDay  /* Otras propiedades */ },
              // Agregar más turnos según sea necesario para la prueba
          });


            List<TurnoResponseDto> result = turnoService.GenerarTurnos(turnoRequestDto);

            // Assert: Verificar que el resultado sea el esperado
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count); // Verificar que la lista no esté vacía

        }
    }
}