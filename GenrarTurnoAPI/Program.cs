using GenrarTurnoAPI.Negocio.Interface;
using GenrarTurnoAPI.Negocio.Servicio;
using GenrarTurnoAPI.Repositorio.Interface;
using GenrarTurnoAPI.Repositorio.Servicio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<ITurno, Turno>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
