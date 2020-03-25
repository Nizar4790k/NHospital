CREATE DATABASE NHospital;
USE NHospital;



DROP DATABASE NHospital;

CREATE TABLE Medico(
IdMedico int primary key identity(1,1),
Nombre varchar(max),
Exequatur varchar(max),
Especialidad varchar(max)	 
);


CREATE TABLE Paciente(
IdPaciente int primary key identity(1,1),
Nombre varchar(max),
Cedula varchar(9) UNIQUE,
Asegurado bit

);

CREATE TABLE Habitacion(
IdHabitacion int primary key,
Numero varchar(8),
Tipo varchar(8),
Precio decimal(10,4)

);

CREATE TABLE Cita(

IdCita int primary key identity(1,1),
Fecha DATETIME,
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente),
IdMedico int FOREIGN KEY REFERENCES Medico(IdMedico)

);

CREATE TABLE Ingreso(
IdIngreso int primary key identity(1,1),
FechaIngreso datetime,
IdHabitacion int FOREIGN KEY REFERENCES Habitacion(IdHabitacion),
IdPaciente int FOREIGN KEY REFERENCES Paciente(IdPaciente)

);

CREATE TABLE Alta(
IdIngreso int FOREIGN KEY REFERENCES Ingreso(IdIngreso),
IdAlta int primary key identity(1,1),
FechaSalida datetime,
MontoTotal decimal(10,4)

);





