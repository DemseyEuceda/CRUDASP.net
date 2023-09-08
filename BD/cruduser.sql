create database usuarioCrud; 

use usuarioCrud;

create table usuario( id int identity(1, 1) primary key , 
nombre varchar(50), 
correo varchar(50), 
direccion varchar(50), 
apodo varchar(50) );

create procedure sp_listar 
as 
begin 
select * from usuario 
end; 


create procedure sp_get_user(@id int) as begin select * from usuario where id = @id end ;

create procedure sp_crear_usuario(@nombre varchar(50),
@correo varchar(50),
@direccion varchar(50),
@apodo varchar(50)) as
begin
insert into usuario (nombre, correo, direccion, apodo) values (@nombre, @correo, @direccion, @apodo) 
end ;

create procedure sp_update_usuario(@id int,
@nombre varchar(50),
@correo varchar(50),
@direccion varchar(50),
@apodo varchar(50)) as
begin
update usuario set nombre = @nombre, correo = @correo, direccion = @direccion, apodo = @apodo where id = @id
end;


create procedure sp_delete_usuario(@id int)
as begin
delete from usuario where id = @id 
end;


exec sp_get_user @id = 2