USE master
go
CREATE DATABASE CINE
on
( NAME = CINE_dat,
FILENAME = 'Direccion\CINE.mdf' )
GO



use CINE
go

Create table Generos
(
	Codigo_De_Genero varchar(20) NOT NULL,
	Descripcion varchar(20) NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Generos primary key (Codigo_De_Genero)
)
go

Create table Peliculas
(
	Cod_Pelicula varchar(20) NOT NULL,
	Nombre_Pelicula varchar(20) NOT NULL,
	Edad varchar(20) NOT NULL,
	Duracion varchar(20) NOT NULL,
	Estrenos bit NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Peliculas primary key (Cod_Pelicula)
)
go

Create Table Clientes
(
	Email varchar(50) NOT NULL,
	Dni varchar(20) NOT NULL,
	Nombre varchar(20) NOT NULL,
	Apellido varchar(20) NOT NULL,
	Contrase�a varchar(20) NOT NULL,
	Tipo_gerente bit NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Clientes primary key (Email)
)
go

Create Table Tipos_De_Funcion
(
	Cod_Tipo varchar(20) NOT NULL,
	Descripcion varchar(20) NOT NULL,
	Precio int NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Tipo_De_Funcion primary key (Cod_Tipo)
)
go

Create Table Salas(
	Cod_Sala varchar(20) NOT NULL,
	Descripcion varchar(20) NOT NULL,
	S_Cod_Tipo varchar(20) NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Salas primary key (Cod_Sala)
)
go


Create Table Funciones(
	Cod_Funcion varchar(20) NOT NULL,
	Cod_Pelicula varchar(20) NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Funciones Primary Key(Cod_Funcion)
 )
 go
	
Create Table Facturas(
	Cod_Factura varchar(20) NOT NULL,
	Total int NOT NULL,
	Email varchar(50) NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Factura Primary Key(Cod_Factura)
 )
 go

Create Table GenerosxPelicula(
	Gp_Cod_G varchar(20) NOT NULL,
	Gp_Cod_P varchar(20) NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_GenerosxPelicula Primary Key(Gp_Cod_G, Gp_Cod_P)
)
go

Create Table FuncionXSala(
	Cod_Funcion varchar(20) NOT NULL,
	Cod_Sala varchar(20) NOT NULL,
	Estado bit NOT NULL default 1,
 Constraint PK_FuncionxSala Primary Key(Cod_Funcion, Cod_Sala)
 )
go

Create Table FuncionXDia(
	Cod_Funcion varchar(20) NOT NULL,
	Fecha date NOT NULL,
	Horario date NOT NULL,
	Estado bit NOT NULL default 1,
 Constraint PK_FuncionxDia Primary Key(Cod_Funcion, Fecha)
)
go

Create Table AsientosxSalaxFuncion(
	Cod_Sala varchar(20) NOT NULL,
	Cod_Funcion varchar(20) NOT NULL,
	Cod_Butaca int identity(1, 1) Not null,
	Disponible bit NOT NULL default 1,
 Constraint PK_AsientosxSalasxFuncion Primary Key(Cod_Sala, Cod_Funcion, Cod_Butaca)
)
go

Create Table DetallexFactura(
	Cod_Detalle varchar(20) NOT NULL,
	Cod_Factura varchar(20) NOT NULL,
	Cod_Sala varchar(20) NOT NULL,
	Cod_Funcion varchar(20) NOT NULL,
	Cod_Butaca int NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_DetallexFactura Primary Key(Cod_Detalle, Cod_Factura)
)
go


Alter Table AsientosxSalaxFuncion
ADD Constraint FK_AsientosxSalaxFuncion_FuncionXSala Foreign Key([Cod_Funcion], [Cod_Sala])
References FuncionXSala (Cod_Funcion, Cod_Sala)
go

Alter Table DetallexFactura  
ADD Constraint FK_DetallexFactura_AsientosxSalaxFuncion Foreign Key(Cod_Sala, Cod_Funcion, Cod_Butaca)
References AsientosxSalaxFuncion (Cod_Sala, Cod_Funcion, Cod_Butaca)
go

Alter Table DetallexFactura 
ADD  Constraint FK_DetallexFactura_Factura Foreign Key(Cod_Factura)
References Facturas (Cod_Factura)
go

Alter Table Facturas
ADD  Constraint FK_Factura_Clientes Foreign Key(Email)
References Clientes (Email)
go

Alter Table Funciones
ADD  Constraint FK_Funciones_Peliculas Foreign Key(Cod_Pelicula)
References Peliculas (Cod_Pelicula)
go

Alter Table FuncionXDia
ADD  Constraint FK_FuncionXDia_Funciones Foreign Key(Cod_Funcion)
References Funciones (Cod_Funcion)
go

Alter Table FuncionXSala
ADD  Constraint FK_FuncionXSala_Funciones Foreign Key(Cod_Funcion)
References Funciones (Cod_Funcion)
go

Alter Table FuncionXSala
ADD  Constraint FK_FuncionXSala_Salas Foreign Key(Cod_Sala)
References Salas (Cod_Sala)
go

Alter Table GenerosxPelicula 
ADD  Constraint FK_GenerosxPelicula_Generos Foreign Key(Gp_Cod_G)
References Generos (Codigo_De_Genero)
go

Alter Table GenerosxPelicula
ADD  Constraint FK_GenerosxPelicula_Peliculas Foreign Key(Gp_Cod_P)
References Peliculas (Cod_Pelicula)
go

Alter Table Salas
ADD Constraint FK_Salas_Tipo_De_Funcion Foreign Key(S_Cod_Tipo)
References Tipos_De_Funcion (Cod_Tipo)
go

Insert Into Generos (Codigo_De_Genero, Descripcion, Estado)
Select 'G1', 'Terror', 1 union
Select 'G2', 'Accion', 1 union
Select 'G3', 'Drama', 1 union
Select 'G4', 'Ciencia Ficcion', 1 union
Select 'G5', 'Romance', 1 union
Select 'G6', 'Suspenso', 1
go

Insert Into Tipos_De_Funcion (Cod_Tipo, Descripcion, Precio, Estado)
Select 'T1', '2d', 100, 1 union
Select 'T2', '3d', 150, 1 union
Select 'T3', '4d', 200, 1 
Go

Insert into Salas (Cod_Sala, Descripcion, S_Cod_Tipo, Estado)
Select 'S1', 'Sala Uno', 'T1', 1 union
Select 'S2', 'Sala Dos', 'T1', 1 union
Select 'S3', 'Sala Tres', 'T1', 1 union
Select 'S4', 'Sala Cuatro', 'T2', 1 union
Select 'S5', 'Sala Cinco', 'T3', 1
Go

Insert Into Clientes (Email, Dni, Nombre, Apellido, Contrase�a, Tipo_gerente, Estado)
select 'FedeCrov@hotmail.com', 40192780, 'Federico', 'Crovetto', 'Kronos', 0, 1 union
select 'AltoMail@gmail.com', 1276982, 'Se�or', 'Burns', 'igualamacri', 0, 1 union
select 'Gerente@hotmail.com', 5555555, 'Gerente', 'Uno', 'gerente', 1, 1 union
select 'MirthaLegrand@hotmail.com', '0000001', 'Mirtha', 'Legrand', 'mirtha', 0, 1
go

Create Procedure Nuevo_Cliente
@N_Email varchar(50), @N_Dni varchar(20), @N_Nombre varchar(20), @N_Apellido varchar(20), @N_Contrase�a varchar(20), @N_Tipo_gerente bit, @N_Estado bit
as
Insert into Clientes (Email, Dni, Nombre, Apellido, Contrase�a, Tipo_gerente, Estado)
select @N_Email, @N_Dni, @N_Nombre, @N_Apellido, @N_Contrase�a, @N_Tipo_gerente, @N_Estado
go

--exec Nuevo_Cliente 'prueba', 'prueba', 'prueba', 'prueba', '1/1/1', 'prueba', 1, 1
--go

Create Procedure Eliminar_Cliente
@E_Email varchar(50)
as
Update Clientes set Estado=0 where Email = @E_Email
go

exec Eliminar_Cliente 'MirthaLegrand@hotmail.com'
go

Create Procedure Agregar_Pelicula
@N_CodPelicula varchar(20), @N_Nombre_Pelicula varchar(20), @N_Edad varchar(20), @N_Duracion varchar(20), @N_Estrenos bit
as
Insert into Peliculas (Cod_Pelicula, Nombre_Pelicula, Edad, Duracion, Estrenos, Estado)
select @N_CodPelicula, @N_Nombre_Pelicula, @N_Edad, @N_Duracion, @N_Estrenos, 1
go

exec Agregar_Pelicula 'Peli_1', 'AbPeli', '18', '100', 1
go

exec Agregar_Pelicula 'Peli_2', 'Duro de matar', '16', '98', 0
go

Create Procedure Asociar_Con_Genero
@N_CodPelicula varchar(20), @N_CodGenero varchar(20)
as
Insert into GenerosxPelicula(Gp_Cod_P, Gp_Cod_G, Estado)
select @N_CodPelicula, @N_CodGenero, 1
go

exec Asociar_Con_Genero 'Peli_2', 'G2'
go

exec Asociar_Con_Genero 'Peli_2', 'G3'
go

exec Asociar_Con_Genero 'Peli_2', 'G6'
go

/*Create Trigger TR_50_Butacas
on AsientosxSalaxFuncion
after insert
as
begin
set nocount on;
if IDENT_Current('AsientosxSalaXFuncion') <= 50
begin
declare @N_Cod_Sala varchar(20) = (select Cod_Sala from inserted)
declare @N_Cod_Funcion varchar(20) = (select Cod_Funcion from inserted)
exec PC_Nuevas_Butacas @N_Cod_Sala, @N_Cod_Funcion
end
--DBCC CHECKIDENT ('AsientosxSalaxFuncion', RESEED, 0)
end
go*/


create procedure PC_Nuevas_Butacas
@Cod_Sala varchar(20), @Cod_Funcion varchar(20)
as
while IDENT_Current('AsientosxSalaXFuncion') < 50
begin
Insert into AsientosxSalaxFuncion (Cod_Sala, Cod_Funcion)
select @Cod_Sala, @Cod_Funcion
end
DBCC CHECKIDENT ('AsientosxSalaxFuncion', RESEED, 0)
go



Create Trigger TR_Nuevas_Butacas
on FuncionXSala
after insert
as
begin
set nocount on;
declare @N_Cod_Sala varchar(20) = (select Cod_Sala from inserted)
declare @N_Cod_Funcion varchar(20) = (select Cod_Funcion from inserted)
exec PC_Nuevas_Butacas @N_Cod_Sala, @N_Cod_Funcion
end
go




Create Procedure Nueva_Funcion
@Cod_Funcion varchar(20), @Cod_Pelicula varchar(20)
as
insert Funciones (Cod_Funcion, Cod_Pelicula)
select @Cod_Funcion, @Cod_Pelicula
go

Exec Nueva_Funcion 'F001', 'Peli_2'
go

Exec Nueva_Funcion 'F002', 'Peli_2'
go

Create Procedure Nueva_FuncionXSala
@Cod_Funcion varchar(20), @Cod_Sala varchar(20)
as
insert FuncionXSala (Cod_Funcion, Cod_Sala)
select @Cod_Funcion, @Cod_Sala
go

Exec Nueva_FuncionXSala 'F001', 'S1'
go

Exec Nueva_FuncionXSala 'F002', 'S1'
go

