

ALTER PROCEDURE [dbo].[GenerarTurnos]
    @FechaInicio DATE,
     @FechaFin DATE ,
     @IdServicio INT 
AS
BEGIN
    -- Verificar si ya existen turnos para el servicio y el rango de fechas proporcionados
    IF EXISTS (
        SELECT 1
        FROM Turnos
        WHERE IdServicio = @IdServicio
        AND fecha_turno BETWEEN @FechaInicio AND @FechaFin
    )
    BEGIN
        -- Puedes generar una excepción o simplemente salir sin hacer nada más
        -- Generar excepción
       print'Ya existen turnos para el servicio y el rango de fechas proporcionados.'
        -- O simplemente salir y mostrar los registros creados para este servicio anteriormente
	select IdTurno, IdServicio, fecha_turno, hora_inicio, hora_fin from turnos where IdServicio =@IdServicio 
        RETURN;
    END

    DECLARE @HoraApertura TIME, @HoraCierre TIME, @DuracionServicioMinutos INT;
    
    SELECT @HoraApertura = hora_apertura, @HoraCierre = hora_cierre, @DuracionServicioMinutos = duracion
    FROM Servicios
    WHERE id_servicio = @IdServicio;

    DECLARE @FechaTurno DATE, @HoraInicio TIME, @HoraFin TIME;

    -- Obtener el máximo IdTurno para el servicio actual
    DECLARE @MaxIdTurno INT;
    SELECT @MaxIdTurno = ISNULL(MAX(IdTurno), 0) FROM Turnos WHERE IdServicio = @IdServicio;

    SET @FechaTurno = @FechaInicio;

    WHILE @FechaTurno <= @FechaFin
    BEGIN
        SET @HoraInicio = @HoraApertura;
        
        WHILE DATEADD(MINUTE, @DuracionServicioMinutos, @HoraInicio) <= @HoraCierre
        BEGIN
            SET @HoraFin = DATEADD(MINUTE, @DuracionServicioMinutos, @HoraInicio);

            -- Incrementar el IdTurno específico para el servicio actual
            SET @MaxIdTurno = @MaxIdTurno + 1;

            -- Insertar en la tabla Turnos con la doble llave primaria
            INSERT INTO Turnos (IdTurno, IdServicio, fecha_turno, hora_inicio, hora_fin)
            VALUES (@MaxIdTurno, @IdServicio, @FechaTurno, @HoraInicio, @HoraFin);

            SET @HoraInicio = @HoraFin;

		
        END
		
        SET @FechaTurno = DATEADD(DAY, 1, @FechaTurno);
		
    END
	select *from turnos where IdServicio =@IdServicio and fecha_turno BETWEEN @FechaInicio AND @FechaFin
	END
	