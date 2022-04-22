/*Procedure Login*/
create procedure SP_Login
@UserName nvarchar(50),
@Password nvarchar(15)
as
begin
select * from Usuarios where UserName=@UserName and Password = @Password
end


/*Procedure Listar Usuarios*/
create procedure SP_ListarUsuarios
as
begin
Select * from Usuarios
end

/*Procedure Buscar Usuarios*/
create procedure SP_BuscarUsuarios
@BUSCAR int
as
begin
select * from Usuarios where IdUsuarios=@BUSCAR
end

/*Procedure Insertar Usuarios*/
create procedure SP_InsertarUsuarios
@UserName nvarchar(50),
@Password nvarchar(15)
as
begin
insert into Usuarios values(@UserName,@Password)
end

/*Procedure Eliminar Usuario*/
create procedure SP_EliminarUsuario
@IdUsuarios int
as
begin
Delete Usuarios where IdUsuarios =@IdUsuarios
end

/*Procedure Editar Usuario*/
create procedure SP_EditarUsuario
@IdUsuarios int,
@UserName nvarchar(50),
@Password nvarchar(15)
as
begin
Update Usuarios set UserName = @UserName,Password = @Password where IdUsuarios = @IdUsuarios
end