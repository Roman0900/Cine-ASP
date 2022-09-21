USE master
go
CREATE DATABASE CINE
on
( NAME = CINE_dat,
 FILENAME = 'C:\Users\Adm\Desktop\TIF PROG3\Nueva carpeta\CINE.mdf' )
 ---Cambiar la ruta a la carpeta donde se encuentre el repositorio---
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
	Nombre_Pelicula varchar(50) NOT NULL,
	Duracion varchar(20) NOT NULL,
	ImagenURL varchar(2048) NOT NULL,
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
	Contraseña varchar(20) NOT NULL,
	Tipo_gerente bit NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_Clientes primary key (Email)
)
go

Create Table Tipos_De_Funcion
(
	Cod_Tipo varchar(20) NOT NULL,
	Descripcion varchar(20) NOT NULL,
	Precio float NOT NULL,
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
	Cod_Factura int identity (1,1) NOT NULL,
	Total float NOT NULL default 0,
	Email varchar(50) NOT NULL,
	Fecha date not null,
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
	Horario varchar(20) NOT NULL,
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
	Cod_Detalle int identity (1,1) NOT NULL,
	Cod_Factura int NOT NULL,
	Cod_Sala varchar(20) NOT NULL,
	Cod_Funcion varchar(20) NOT NULL,
	Cod_Butaca int NOT NULL,
	Estado bit NOT NULL default 1,
	Constraint PK_DetallexFactura Primary Key(Cod_Detalle, Cod_Factura)
)
go

Create Table Edades(
	Ed_Cod_Edad varchar(20) not null,
	Ed_Edad varchar(20) not null,
	Estado bit NOT NULL default 1,
	constraint PK_Edades primary key (Ed_Cod_Edad)
)
go

Create Table EdadXPelicula
(
	ExP_Cod_Edad varchar(20) not null,
	ExP_Cod_Pelicula varchar(20) not null,
	Estado bit NOT NULL default 1,
	constraint PK_EdadxPel primary key (ExP_Cod_Pelicula)	
)




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

Alter Table EdadXPelicula
Add Constraint FK_ExP_Pelicula Foreign Key (ExP_Cod_Pelicula)
References Peliculas (Cod_Pelicula)
go

Alter Table EdadXPelicula
Add Constraint FK_ExP_Edad Foreign Key (ExP_Cod_Edad)
References Edades (Ed_Cod_Edad)
go





Create Procedure Nuevo_Cliente
@N_Email varchar(50), @N_Dni varchar(20), @N_Nombre varchar(20), @N_Apellido varchar(20), @N_Contraseña varchar(20), @N_Tipo_gerente bit, @N_Estado bit
as
Insert into Clientes (Email, Dni, Nombre, Apellido, Contraseña, Tipo_gerente, Estado)
select @N_Email, @N_Dni, @N_Nombre, @N_Apellido, @N_Contraseña, @N_Tipo_gerente, @N_Estado
go


Create Procedure Eliminar_Cliente
@E_Email varchar(50)
as
Update Clientes set Estado=0 where Email = @E_Email
go



Create Procedure Agregar_Pelicula
@N_CodPelicula varchar(20), @N_Nombre_Pelicula varchar(50), @N_Duracion varchar(20), @N_ImagenURL varchar(2048), @N_Estrenos bit
as
Insert into Peliculas (Cod_Pelicula, Nombre_Pelicula, Duracion, Estrenos, ImagenURL, Estado)
select @N_CodPelicula, @N_Nombre_Pelicula, @N_Duracion, @N_Estrenos, @N_ImagenURL, 1
go



Create Procedure Nuevo_EdadXPeli
@N_Cod_Pelicula varchar(20), @N_Cod_Edad varchar(20)
as
insert into EdadXPelicula (ExP_Cod_Edad, ExP_Cod_Pelicula, Estado)
select @N_Cod_Edad, @N_Cod_Pelicula, 1
go




Create Procedure Agregar_Genero
@N_Codigo_De_Genero varchar(20), @N_Descripcion varchar(20)
as
Insert into Generos(Codigo_De_Genero, Descripcion)
select @N_Codigo_De_Genero, @N_Descripcion
go

Create Procedure Agregar_GeneroxPelicula
@N_CodPelicula varchar(20), @N_CodGenero varchar(20)
as
Insert into GenerosxPelicula(Gp_Cod_P, Gp_Cod_G)
select @N_CodPelicula, @N_CodGenero
go



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



Create Procedure Agregar_Funciones
@N_Cod_Funcion varchar(20), @N_Cod_Pelicula varchar(20)
as
insert Funciones (Cod_Funcion, Cod_Pelicula)
select @N_Cod_Funcion, @N_Cod_Pelicula
go





Create Procedure Agregar_FuncionXSala
@N_Cod_Funcion varchar(20), @N_Cod_Sala varchar(20)
as
insert FuncionXSala (Cod_Funcion, Cod_Sala)
select @N_Cod_Funcion, @N_Cod_Sala
go


Create Procedure Agregar_FuncionxDia
@N_Cod_Funcion varchar(20), @N_Fecha date,@N_Horario varchar(20)
as
Insert into FuncionXDia(Cod_Funcion, Fecha, Horario)
select @N_Cod_Funcion, @N_Fecha ,@N_Horario
go


Create Procedure Agregar_Tipos_Funcion
@N_Cod_Tipo varchar(20), @N_Descripcion varchar(20),@N_Precio float 
as
Insert into Tipos_De_Funcion(Cod_Tipo, Descripcion,Precio,Estado)
select @N_Cod_Tipo, @N_Descripcion ,@N_Precio, 1
go



-------------------------------------------------------------------------

Create Trigger TR_SeVendioButaca
on AsientosxSalaxFuncion
after update
as
begin
set nocount on;
if ((select Disponible from inserted) = 0)
begin
declare @N_Cod_Factura int = IDENT_Current('Facturas')
insert into DetallexFactura (Cod_Factura, Cod_Sala, Cod_Funcion, Cod_Butaca)
select @N_Cod_Factura, Cod_Sala, Cod_Funcion, Cod_Butaca from inserted
end
end
go

Create Trigger TR_ActualizarTotal
on DetallexFactura
after insert
as
begin
set nocount on;
update Facturas set Total = Total + (select Precio from Tipos_De_Funcion inner join Salas on (Tipos_De_Funcion.Cod_Tipo = S_Cod_Tipo) inner join inserted on (inserted.Cod_Sala = Salas.Cod_Sala))
where Facturas.Cod_Factura = (select inserted.Cod_Factura from inserted)
end
go

Create Trigger TR_ActualizarIdentityDxF
on Facturas
after insert
as
begin 
set nocount on;
DBCC CHECKIDENT ('DetallexFactura', RESEED, 0)
end
go


Create Procedure NuevaFactura
@N_Email varchar(50)
as
insert into Facturas (Email, Fecha)
select @N_Email, GETDATE()
go
-------------------------------------------------------------------------------



Create Procedure ActualizarButacas
(
@N_Cod_Funcion varchar(20),
@N_Cod_Sala varchar(20),
@N_Cod_Butaca int,
@N_Estado bit
)
as
update AsientosxSalaxFuncion
set
Disponible = @N_Estado
where Cod_Butaca = @N_Cod_Butaca and Cod_Funcion = @N_Cod_Funcion and Cod_Sala = Cod_Sala
go

Create Procedure ActualizarClientes
(
@N_Email varchar(50),
@N_Dni varchar(20),
@N_Nombre varchar(20),
@N_Apellido varchar(20),
@N_Contraseña varchar(20),
@N_Tipo_Gerente bit,
@N_Estado bit
)
as
update Clientes
set
Dni = @N_Dni,
Nombre = @N_Nombre,
Apellido = @N_Apellido,
Contraseña = @N_Contraseña,
Tipo_gerente = @N_Tipo_Gerente,
Estado = @N_Estado
where Email = @N_Email
go

Create Procedure ActualizarEdades
(
@N_Edad varchar(20),
@N_Cod_Edad varchar(20),
@N_Estado bit
)
as
update Edades
set
Ed_Edad = @N_Edad,
Estado = @N_Estado
where Ed_Cod_Edad = @N_Cod_Edad
go

Create Procedure ActualizarEdadXPelicula
(
@N_Cod_Pelicula varchar(20),
@N_Cod_Edad varchar(20),
@N_Estado bit
)
as
update EdadXPelicula
set
ExP_Cod_Edad = @N_Cod_Edad,
Estado = @N_Estado
where ExP_Cod_Pelicula = @N_Cod_Pelicula
go

 
 Create PROCEDURE ActualizarFunciones
(
@Cod_Funcion varchar(20),
 @Cod_Pelicula varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE Funciones
 set
 Cod_Funcion=@Cod_Funcion,
 Cod_Pelicula=@Cod_Pelicula,
 Estado = @N_Estado
 where Cod_Funcion=@Cod_Funcion 
 go
 
  Create PROCEDURE AtualizarFuncionxSala
( 
 @Cod_Funcion varchar(20),
 @Cod_Sala varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE FuncionXSala
 set
 Cod_Funcion=@Cod_Funcion,
 Cod_Sala=@Cod_Sala,
 Estado=@N_Estado
 where Cod_Funcion=@Cod_Funcion and Cod_Sala=@Cod_Sala
 Go
 
 
 Create PROCEDURE AtualizarFuncionxDia
 ( 
 @Cod_Funcion varchar(20),
 @N_Fecha date,
 @N_Horario varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE FuncionXDia
 set
 Fecha=@N_Fecha,
 Horario=@N_Horario,
 Estado = @N_Estado
 where Cod_Funcion=@Cod_Funcion
 go
 
  Create PROCEDURE ActualizarGeneros
 ( 
 @N_Codigo_De_Genero varchar(20),
 @N_Descripcion varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE Generos
 set
 Descripcion=@N_Descripcion,
 Estado = @N_Estado
 where Codigo_De_Genero=@N_Codigo_De_Genero
 go
 
 
create PROCEDURE ActualizarGenerosxPelicula
( 
 @Cod_G_V varchar(20),
 @Cod_P_V varchar(20),
 @N_Gp_Cod_G varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE GenerosxPelicula
 set
 Gp_Cod_G=@N_Gp_Cod_G,
 Estado = @N_Estado
 where Gp_Cod_G=@Cod_G_V and Gp_Cod_P=@Cod_P_V
 go
 
 
Create PROCEDURE ActualizarPeliculas
(
 @N_CodPelicula varchar(20),
 @N_Nombre_Pelicula varchar(50),
 @N_Duracion varchar(20),
 @N_URL varchar(2048),
 @N_Estrenos bit,
 @N_Estado bit
 )
 AS
 UPDATE Peliculas
 set
 Duracion=@N_Duracion,
 Nombre_Pelicula=@N_Nombre_Pelicula,
 ImagenURL = @N_URL,
 Estrenos=@N_Estrenos,
 Estado = @N_Estado
 where Cod_Pelicula=@N_CodPelicula
 go
  
 Create PROCEDURE ActualizarSalas
(
 @N_Cod_Sala varchar(20),
 @N_Descripcion varchar(20),
 @N_S_Cod_Tipo varchar(20),
 @N_Estado bit
 )
 AS
 UPDATE Salas
 set
 Descripcion=@N_Descripcion,
 S_Cod_Tipo=@N_S_Cod_Tipo,
 Estado = @N_Estado
 where  Cod_Sala=@N_Cod_Sala
 go
 
 Create PROCEDURE AtualizarTipoFuncion
( 
@N_Cod_Tipo varchar(20),
 @N_Descripcion varchar(20),
 @N_Precio float,
 @N_Estado bit
 )
 AS
 UPDATE Tipos_De_Funcion
 set
 Descripcion=@N_Descripcion,
 Precio=@N_Precio,
 Estado = @N_Estado
 where  Cod_Tipo=@N_Cod_Tipo
 go
 
Create PROCEDURE ActualizarEstadoFactura
(
@Cod_Factura int ,@Estado bit
)
AS
update Facturas
set Estado = @Estado
where Cod_Factura = @Cod_Factura
go

create PROCEDURE ActualizarEstadoDetalleXFactura
(
@N_Cod_Detalle int,
@N_Cod_Factura int,
@N_Cod_Sala varchar(20),
@N_Cod_Funcion varchar(20),
@N_Cod_Butaca int,
@N_Estado bit
)
AS
update DetallexFactura
set Estado = @N_Estado
where Cod_Detalle = @N_Cod_Detalle and Cod_Factura = @N_Cod_Factura and Cod_Sala = @N_Cod_Sala
and Cod_Funcion = @N_Cod_Funcion and Cod_Butaca = @N_Cod_Butaca
go

-- CARGANDO DATOS --
Insert Into Generos (Codigo_De_Genero, Descripcion, Estado)
Select 'G1', 'Terror', 1 union
Select 'G2', 'Accion', 1 union
Select 'G3', 'Drama', 1 union
Select 'G4', 'Ciencia Ficcion', 1 union
Select 'G5', 'Romance', 1 union
Select 'G6', 'Suspenso', 1 union
Select 'G7', 'Infantil', 1
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

Insert Into Clientes (Email, Dni, Nombre, Apellido, Contraseña, Tipo_gerente, Estado)
select 'FedeCrov@hotmail.com', 40192780, 'Federico', 'Crovetto', 'Kronos', 0, 1 union
select 'AltoMail@gmail.com', 1276982, 'Señor', 'Burns', 'igualamacri', 0, 1 union
select 'Gerente@hotmail.com', 5555555, 'Gerente', 'Uno', 'gerente', 1, 1 union
select 'MirthaLegrand@hotmail.com', '0000001', 'Mirtha', 'Legrand', 'mirtha', 0, 1
go

exec Eliminar_Cliente 'MirthaLegrand@hotmail.com'
go

Insert Into Edades (Ed_Cod_Edad, Ed_Edad)
select 'Edad_1', 'Atp' union
select 'Edad_2', '13' union
select 'Edad_3', '16' union
select 'Edad_4', '18'
go

exec Agregar_Pelicula 'Peli_1', 'Rapido Y furioso', '100', 'https://vignette.wikia.nocookie.net/doblaje/images/4/47/RFCartelOriginal.jpg/revision/latest?cb=20171125061739&path-prefix=es', 1
go

exec Agregar_Pelicula 'Peli_2', 'Duro de matar', '98', 'https://http2.mlstatic.com/duro-de-matar-die-hard-tetralogia-1-2-3-4-peliculas-dvd-D_NQ_NP_418405-MLM25018537643_082016-F.jpg', 0
go

exec Agregar_Pelicula 'Peli_3', 'Shrek', '113', 'https://www.cartelera.com.uy/imagenes_espectaculos/moviedetail13/8207.jpg', 0
go

exec Agregar_Pelicula 'Peli_4', 'Yo antes de ti', '105', 'https://s3.amazonaws.com/statics3.cinemex.com/movie_posters/XLJf8WPg0IbotvQ-182x272.jpg', 1
go

exec Agregar_Pelicula 'Peli_5', 'La bella y la bestia', '130', 'http://es.web.img2.acsta.net/c_215_290/pictures/17/01/09/09/56/256507.jpg', 1
go

exec Agregar_Pelicula 'Peli_6', 'El conjuro', '117', 'https://www.bases123.com.ar/posters/5276_poster2.jpg', 0
go

exec Agregar_Pelicula 'Peli_7', 'El Cubo', '93', 'http://es.web.img2.acsta.net/c_215_290/medias/nmedia/18/91/21/77/20134937.jpg', 1
go


exec Nuevo_EdadXPeli 'Peli_1', 'Edad_2'
go

exec Nuevo_EdadXPeli 'Peli_2', 'Edad_3'
go

exec Nuevo_EdadXPeli 'Peli_3', 'Edad_1'
go

exec Nuevo_EdadXPeli 'Peli_4', 'Edad_3'
go

exec Nuevo_EdadXPeli 'Peli_5', 'Edad_1'
go

exec Nuevo_EdadXPeli 'Peli_6', 'Edad_4'
go

exec Nuevo_EdadXPeli 'Peli_7', 'Edad_4'
go

exec Agregar_GeneroxPelicula 'Peli_2', 'G2'
go

exec Agregar_GeneroxPelicula 'Peli_2', 'G3'
go

exec Agregar_GeneroxPelicula 'Peli_2', 'G6'
go

exec Agregar_GeneroxPelicula 'Peli_3', 'G7'
go

exec Agregar_GeneroxPelicula 'Peli_4', 'G3'
go

exec Agregar_GeneroxPelicula 'Peli_4', 'G5'
go

exec Agregar_GeneroxPelicula 'Peli_5', 'G7'
go

exec Agregar_GeneroxPelicula 'Peli_5', 'G5'
go

exec Agregar_GeneroxPelicula 'Peli_6', 'G1'
go

exec Agregar_GeneroxPelicula 'Peli_6', 'G6'
go

exec Agregar_GeneroxPelicula 'Peli_7', 'G1'
go

exec Agregar_GeneroxPelicula 'Peli_7', 'G6'
go

exec Agregar_GeneroxPelicula 'Peli_7', 'G4'
go

Exec Agregar_Funciones 'F001', 'Peli_2'
go

Exec Agregar_Funciones 'F002', 'Peli_2'
go

insert into Funciones (Cod_Funcion, Cod_Pelicula)
Select 'F003', 'Peli_2' union
Select 'F004', 'Peli_3' union
Select 'F005', 'Peli_4' union
Select 'F006', 'Peli_4' union
Select 'F007', 'Peli_5' union
Select 'F008', 'Peli_6' union
Select 'F009', 'Peli_7' union
Select 'F010', 'Peli_7' union
Select 'F011', 'Peli_1'
go

Exec Agregar_FuncionXSala 'F001', 'S1'
go

Exec Agregar_FuncionXSala 'F002', 'S1'
go

Exec Agregar_FuncionXSala 'F003', 'S2' 
go

Exec Agregar_FuncionXSala 'F004', 'S3'
go

Exec Agregar_FuncionXSala 'F005', 'S2'
go

Exec Agregar_FuncionXSala 'F006', 'S4' 
go

Exec Agregar_FuncionXSala 'F007', 'S5' 
go

Exec Agregar_FuncionXSala 'F008', 'S4' 
go

Exec Agregar_FuncionXSala 'F009', 'S1' 
go

Exec Agregar_FuncionXSala 'F010', 'S5'
go
Exec Agregar_FuncionXSala 'F011', 'S1'
go

insert into FuncionXDia (Cod_Funcion, Fecha, Horario)
Select 'F003', '23/2/2018', '12:00' union
Select 'F004', '14/6/2019', '13:00' union
Select 'F005', '14/6/2019', '13:20' union
Select 'F006', '15/6/2019', '16:00' union
Select 'F007', '13/6/2019', '20:00' union
Select 'F008', '13/6/2019', '11:00' union
Select 'F009', '14/6/2019', '09:00' union
Select 'F010', '15/6/2019', '22:30' union
Select 'F011', '14/6/2019', '04:00'
go

exec NuevaFactura 'FedeCrov@hotmail.com'
go

Exec ActualizarButacas'F001', 'S1', 1, 0
go

Exec ActualizarButacas 'F001', 'S1', 2, 0
go

Exec ActualizarButacas 'F001', 'S1', 3, 0
go

Exec ActualizarButacas 'F001', 'S1', 4, 0
go

exec NuevaFactura 'AltoMail@gmail.com'
go

Exec ActualizarButacas 'F003', 'S2', 23, 0
go

Exec ActualizarButacas 'F003', 'S2', 24, 0
go

Exec ActualizarButacas 'F003', 'S2', 25, 0
go

Exec ActualizarButacas 'F003', 'S2', 26, 0
go

Exec ActualizarButacas 'F003', 'S2', 27, 0
go

exec NuevaFactura 'MirthaLegrand@hotmail.com'
go

Exec ActualizarButacas 'F003', 'S2', 34, 0
go

Exec ActualizarButacas 'F003', 'S2', 35, 0
go

Exec ActualizarButacas 'F003', 'S2', 36, 0
go

Exec ActualizarButacas 'F003', 'S2', 37, 0
go


/*
 Create Procedure Eliminar_Genero
@N_Codigo_De_Genero varchar(20)
as
Update Generos set Estado=0 where Codigo_De_Genero=@N_Codigo_De_Genero
go

 Create Procedure Eliminar_Salas
@N_Cod_Sala varchar(20)
as
Update Salas set Estado=0 where Cod_Sala=@N_Cod_Sala
go

Create Procedure Eliminar_Funciones
@Cod_Funcion varchar(20)
as
Update Funciones set Estado=0 where Cod_Funcion=@Cod_Funcion
go

 Create Procedure Eliminar_FuncionxDia
@Cod_Funcion varchar(20),
 @N_Fecha date
as
Update FuncionXDia set Estado=0 where Cod_Funcion=@Cod_Funcion and Fecha=@N_Fecha
go

 Create Procedure Eliminar_FuncionxSala
@Cod_Funcion varchar(20),
 @Cod_Sala varchar(20)
as
Update FuncionXSala set Estado=0 where Cod_Sala=@Cod_Sala and Cod_Funcion=@Cod_Funcion
go

Create Procedure Eliminar_Tipo_De_Funcion
@N_Cod_Tipo varchar(20)
as
Update Tipos_De_Funcion set Estado=0 where Cod_Tipo=@N_Cod_Tipo
go

Create Procedure Eliminar_GenerosxPelicula
@N_Gp_Cod_G varchar(20),
 @Gp_Cod_P varchar(20) 
as
Update GenerosxPelicula set Estado=0 where Gp_Cod_G=@N_Gp_Cod_G and Gp_Cod_P=@Gp_Cod_P
go*/
