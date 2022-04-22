create database SystemCitas

use SystemCitas

create table Usuarios(
IdUsuarios int identity(1,1) primary key,
UserName nvarchar(50),
Password nvarchar(15)
)

create table Doctor(
IdDoctor int identity(1,1) primary key,
Nombre nvarchar(30),
Apellido nvarchar(50),
Direccion nvarchar(80),
FechaNacimiento datetime,
NumeroDeTelefono nvarchar(20),
CorreoElectronico nvarchar(40),
Cedula nvarchar(30)
)

create table Pacientes(
IdPacientes int identity(1,1) primary key,
Nombre nvarchar(30),
Apellido nvarchar(50),
Direccion nvarchar(80),
FechaNacimiento datetime,
NumeroDeTelefono nvarchar(20),
CorreoElectronico nvarchar(40),
Cedula nvarchar(30),
FechaIngreso datetime
)

create table Citas(
IdCitas int identity(1,1) primary key,
IdDoctor int foreign key references Doctor(IdDoctor),
IdPacientes int foreign key references Pacientes(IdPacientes),
FechaCitas datetime DEFAULT GETDATE(),
Diagnostico text DEFAULT '',
Estado char(1) DEFAULT 'I'
)