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
Cedula varchar(9) UNIQUE,
Asegurado bit NOT NULL

);


CREATE TABLE Habitacion(
IdHabitacion int primary key identity(1,1) NOT NULL,
Numero int UNIQUE NOT NULL ,
IdTipo int FOREIGN KEY REFERENCES TipoHabitacion(IdTipo) NOT NULL,
Precio decimal(10,4) NOT NULL

);

CREATE TABLE Cita(

IdCita int primary key identity(1,1) NOT NULL,
Fecha DATETIME NOT NULL,
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
IdMedico int FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL

);



CREATE TABLE Ingreso(
IdIngreso int primary key identity(1,1) NOT NULL,
FechaIngreso datetime NOT NULL ,
IdHabitacion int FOREIGN KEY REFERENCES Habitacion(IdHabitacion) NOT NULL,
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL

);

CREATE TABLE Alta(
IdIngreso int FOREIGN KEY REFERENCES Ingreso(IdIngreso) UNIQUE  NOT NULL,
IdAlta int primary key identity(1,1) NOT NULL,
FechaSalida datetime NOT NULL ,
MontoTotal decimal(10,4) NOT NULL

);



INSERT INTO TipoHabitacion (Nombre) VALUES ('Doble');
INSERT INTO TipoHabitacion (Nombre) VALUES ('Privada');
INSERT INTO TipoHabitacion (Nombre) VALUES ('Suite');

SELECT * FROM TipoHabitacion;



DROP TABLE Alta;
DROP TABLE Ingreso;
DROP TABLE Habitacion;




