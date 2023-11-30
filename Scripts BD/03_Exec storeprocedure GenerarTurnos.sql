
DECLARE @FechaInicio DATETIME = GETDATE(); 
DECLARE @FechaFin DATETIME = DATEADD(HOUR, 5, @FechaInicio); 
DECLARE @IdServicio INT = 1; 


EXEC GenerarTurnos @FechaInicio, @FechaFin, @IdServicio;

