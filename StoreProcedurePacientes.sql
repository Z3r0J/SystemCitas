/*Procedure Listar Pacientes*/
create procedure SP_ListarPacientes
as
begin
Select * from Pacientes
end

/*Procedure Buscar Pacientes*/
create procedure SP_BuscarPacientes
@BUSCAR int
as
begin
Select * from Pacientes where IdPacientes=@BUSCAR
end

/*Procedure Insertar Pacientes*/
create procedure SP_InsertarPacientes
@Nombre nvarchar(30),
@Apellido nvarchar(50),
@Direccion nvarchar(80),
@FechaNacimiento datetime,
@NumeroDeTelefono nvarchar(20),
@CorreoElectronico nvarchar(40),
@Cedula nvarchar(30),
@FechaIngreso datetime
as
begin
insert into Pacientes values(@Nombre,@Apellido,@Direccion,@FechaNacimiento,@NumeroDeTelefono,@CorreoElectronico,@Cedula,@FechaIngreso)
end

/*Procedure Editar Pacientes*/
create procedure SP_EditarPacientes
@IdPacientes int,
@Nombre nvarchar(30),
@Apellido nvarchar(50),
@Direccion nvarchar(80),
@FechaNacimiento datetime,
@NumeroDeTelefono nvarchar(20),
@CorreoElectronico nvarchar(40),
@Cedula nvarchar(30),
@FechaIngreso datetime
as
begin
Update Pacientes set Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, NumeroDeTelefono = @NumeroDeTelefono, CorreoElectronico = @CorreoElectronico, Cedula = @Cedula, FechaIngreso = @FechaIngreso where IdPacientes=@IdPacientes
end

/*Procedure Eliminar Pacientes*/
create procedure SP_EliminarPacientes
@IdPacientes int
as
begin
Delete Pacientes where IdPacientes=@IdPacientes
end