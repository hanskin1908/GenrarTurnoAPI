--CREATE DATABASE nombre_bd
--USE nombre_bd

CREATE TABLE comercios (
    id_comercio INT PRIMARY KEY identity,
	nom_comercio varchar(100),
	aforo_maximo INT
	
);

CREATE TABLE Servicios (
    id_servicio INT PRIMARY KEY,
	id_comercio INT FOREIGN KEY REFERENCES comercios(id_comercio),
    nom_servicio varchar(50),
    hora_apertura TIME,
	hora_cierre TIME,
    duracion INT
);

-- Tabla de Turnos
CREATE TABLE Turnos (
    IdTurno INT,
    IdServicio INT FOREIGN KEY REFERENCES Servicios(id_servicio),
    fecha_turno DATE,
    hora_inicio TIME,
    hora_fin TIME
	PRIMARY KEY (IdTurno, IdServicio));



	INSERT INTO comercios (nom_comercio, aforo_maximo)
VALUES ('ABC', 100),
       ('XYZ', 50),
       ('Restaurante 123', 30);


INSERT INTO Servicios (id_servicio, id_comercio, nom_servicio, hora_apertura, hora_cierre, duracion)
VALUES (1, 1, 'ABC', '09:00:00', '18:00:00', 30),
       (2, 2, 'XYZ', '10:00:00', '20:00:00', 60),
       (3, 3, 'Restaurante 123', '12:00:00', '22:00:00', 45);


	
