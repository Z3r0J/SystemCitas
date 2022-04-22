/*Procedure de Listar Citas*/
create Procedure SP_Listar_Citas
as
begin
Select c.IdCitas,p.Nombre as 'Paciente', d.Nombre as 'Doctor', c.Estado, c.FechaCitas from Citas c inner join Pacientes p
on p.IdPacientes =  c.IdPacientes inner join Doctor d
on d.IdDoctor = c.IdDoctor where c.Estado = 'I'
end


/*Procedure de Listar Citas Completadas*/
create Procedure SP_Listar_Citas_Completadas
as
begin
Select c.IdCitas,p.Nombre as 'Paciente', d.Nombre as 'Doctor', c.Estado,c.Diagnostico, c.FechaCitas from Citas c inner join Pacientes p
on p.IdPacientes =  c.IdPacientes inner join Doctor d
on d.IdDoctor = c.IdDoctor Where c.Estado='C'
end

/*Procedure de Insertar*/
create procedure SP_InsertarCitas
@IdDoctor int,
@IdPacientes int,
@FechaCitas datetime,
@Diagnostico text,
@Estado char
as
begin
insert into Citas values(@IdDoctor,@IdPacientes,@FechaCitas,@Diagnostico,@Estado)
end

/*Procedure de Completar Citas*/
create procedure SP_CompletarCitas
@IdCitas int,
@Diagnostico text,
@Estado char
as
begin
Update Citas set Diagnostico=@Diagnostico,Estado=@Estado where IdCitas = @IdCitas
end