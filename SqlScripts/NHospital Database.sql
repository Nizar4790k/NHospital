
DROP DATABASE NHospital;
CREATE DATABASE NHospital;
USE NHospital;


CREATE TABLE TipoHabitacion(

IdTipo int primary key identity(1,1) NOT NULL,
Nombre varchar(10)NOT NULL
);



CREATE TABLE Medico(
IdMedico int primary key identity(1,1) NOT NULL,
Nombre varchar(max) NOT NULL,
Exequatur varchar(max) NOT NULL,
Especialidad varchar(max) NOT NULL	 
);


CREATE TABLE Paciente(
IdPaciente int primary key identity(1,1) NOT NULL ,
Nombre varchar(max) NOT NULL,
Cedula varchar(9) NOT NULL,
Asegurado bit NOT NULL

);


CREATE TABLE Habitacion(
IdHabitacion int primary key identity(1,1) NOT NULL,
Numero int UNIQUE NOT NULL ,
IdTipo int FOREIGN KEY REFERENCES TipoHabitacion(IdTipo) ON DELETE CASCADE NOT NULL ,
Precio decimal(10,4) NOT NULL

);

CREATE TABLE Cita(

IdCita int primary key identity(1,1) NOT NULL,
Fecha DATETIME NOT NULL,
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente) ON DELETE CASCADE NOT NULL,
IdMedico int FOREIGN KEY REFERENCES Medico(IdMedico) ON DELETE CASCADE NOT NULL

);



CREATE TABLE Ingreso(
IdIngreso int primary key identity(1,1) NOT NULL,
FechaIngreso datetime NOT NULL ,
IdHabitacion int FOREIGN KEY REFERENCES Habitacion(IdHabitacion) ON DELETE CASCADE NOT NULL,
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente) ON DELETE CASCADE NOT NULL

);

CREATE TABLE Alta(
IdIngreso int FOREIGN KEY REFERENCES Ingreso(IdIngreso) ON DELETE CASCADE UNIQUE   NOT NULL,
IdAlta int primary key identity(1,1) NOT NULL,
FechaSalida datetime2 NOT NULL ,
MontoTotal decimal(10,4) NOT NULL

);


DROP TABLE ALTA;
DROP TABLE Ingreso;



INSERT INTO TipoHabitacion (Nombre) VALUES ('Doble');
INSERT INTO TipoHabitacion (Nombre) VALUES ('Privada');
INSERT INTO TipoHabitacion (Nombre) VALUES ('Suite');



/*
SELECT * FROM TipoHabitacion;



DROP TABLE Alta;
DROP TABLE Ingreso;
DROP TABLE Habitacion;


*/


CREATE UNIQUE NONCLUSTERED INDEX index_cedula on Paciente(Cedula) WHere cEDULA is not null;

CREATE UNIQUE INDEX index_cedula ON dbo.Paciente(Cedula) WHERE Cedula IS NOT NULL;


insert into Alta(IdIngreso,FechaSalida,MontoTotal) values(5,'10/02/1998',1460);
SELECT * FROM Alta;
SELECT * FROM TipoHabitacion;
SELECT * FROM Ingreso;
SELECT * FROM Paciente;
SELECT * FROM Ingreso;
