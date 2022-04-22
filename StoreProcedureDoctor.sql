/*Procedure Listar Doctor*/
create procedure SP_ListarDoctor
as
begin
Select * from Doctor
end

/*Procedure Buscar Doctor*/
create procedure SP_BuscarDoctor
@BUSCAR int
as
begin
select * from Doctor where IdDoctor=@BUSCAR
end

/*Procedure Insertar Doctor*/
create procedure SP_InsertarDoctor
@Nombre nvarchar(30),
@Apellido nvarchar(50),
@Direccion nvarchar(80),
@FechaNacimiento datetime,
@NumeroDeTelefono nvarchar(20),
@CorreoElectronico nvarchar(40),
@Cedula nvarchar(30)
as
begin
insert into Doctor values(@Nombre,@Apellido,@Direccion,@FechaNacimiento,@NumeroDeTelefono,@CorreoElectronico,@Cedula)
end

/*Procedure Editar Usuario*/
create procedure SP_EditarDoctor
@IdDoctor int,
@Nombre nvarchar(30),
@Apellido nvarchar(50),
@Direccion nvarchar(80),
@FechaNacimiento datetime,
@NumeroDeTelefono nvarchar(20),
@CorreoElectronico nvarchar(40),
@Cedula nvarchar(30)
as
begin
Update Doctor set Nombre = @Nombre,Apellido=@Apellido,Direccion=@Direccion,FechaNacimiento=@FechaNacimiento,NumeroDeTelefono=@NumeroDeTelefono,CorreoElectronico=@CorreoElectronico,Cedula=@Cedula where IdDoctor=@IdDoctor
end

/*Procedure Eliminar Doctor*/
create procedure SP_EliminarDoctor
@IdDoctor int
as
begin
Delete Doctor where IdDoctor=@IdDoctor
end