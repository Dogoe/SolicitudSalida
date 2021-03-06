USE [master]
GO
/****** Object:  Database [dbSS]    Script Date: 11/29/2017 7:54:36 AM ******/
CREATE DATABASE [dbSS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbSS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbSS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbSS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbSS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSS] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbSS] SET  MULTI_USER 
GO
ALTER DATABASE [dbSS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbSS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbSS]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CACEI] [bit] NULL,
	[Licenciatura] [bit] NULL,
	[Personal] [bit] NULL,
	[ISO] [bit] NULL,
	[Posgrado] [bit] NULL,
	[Otro] [nvarchar](100) NULL,
 CONSTRAINT [PK_Actividad_Asociada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[Id] [int] NOT NULL,
	[Nombre_Carrera] [nvarchar](50) NOT NULL,
	[Id_Usuario_Coordinador] [int] NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Carrera__75E3EFCFACC810FA] UNIQUE NONCLUSTERED 
(
	[Nombre_Carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Carrera__EDD6CF929DD2F4C3] UNIQUE NONCLUSTERED 
(
	[Id_Usuario_Coordinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL,
	[Nombre_Categoria] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Categori__75E3EFCF78421EC5] UNIQUE NONCLUSTERED 
(
	[Nombre_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evento]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Evento] [nvarchar](150) NOT NULL,
	[Costo] [float] NULL,
	[Lugar] [nvarchar](150) NOT NULL,
	[Fecha_Hora_Salida] [datetime2](7) NOT NULL,
	[Fecha_Hora_Regreso] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recurso]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hospedaje] [bit] NULL,
	[Transporte] [int] NULL,
	[Combustible] [bit] NULL,
	[Viatico] [bit] NULL,
	[Oficio_Comision] [bit] NULL,
	[Otro] [nvarchar](250) NULL,
 CONSTRAINT [PK_Recurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] NOT NULL,
	[Nombre_Rol] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Rol__92C53B6C7139F234] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Folio] [nvarchar](max) NOT NULL,
	[Nombre_Solicitante] [nvarchar](50) NOT NULL,
	[Numero_Empleado] [int] NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Id_Carrera] [int] NOT NULL,
	[Id_Evento] [int] NOT NULL,
	[Id_Recurso_Solicitado] [int] NOT NULL,
	[Id_Actividad] [int] NOT NULL,
	[Id_Validacion] [int] NOT NULL,
	[Id_Estado] [int] NOT NULL,
	[Fecha_Creacion] [datetime2](7) NOT NULL,
	[Fecha_Modificacion] [datetime2](7) NOT NULL,
	[URL_Reporte] [nvarchar](50) NULL,
	[Correo_Solicitante] [nchar](250) NOT NULL,
	[Comentario_Rechazado] [nvarchar](max) NOT NULL,
	[Leido] [bit] NOT NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Id_Rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Usuario__60695A19A9C6705E] UNIQUE NONCLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Validacion]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Coordinador] [bit] NOT NULL,
	[Subdirector] [bit] NOT NULL,
	[Administrador] [bit] NOT NULL,
	[Director] [bit] NOT NULL,
	[Posgrado] [bit] NOT NULL,
	[Unica] [bit] NOT NULL,
 CONSTRAINT [PK_Validaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Usuario] FOREIGN KEY([Id_Usuario_Coordinador])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [FK_Carrera_Usuario]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Actividad] FOREIGN KEY([Id_Actividad])
REFERENCES [dbo].[Actividad] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Actividad]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_C] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_C]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Carrera] FOREIGN KEY([Id_Carrera])
REFERENCES [dbo].[Carrera] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Carrera]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Estado] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Estado]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Evento] FOREIGN KEY([Id_Evento])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Evento]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Recurso] FOREIGN KEY([Id_Recurso_Solicitado])
REFERENCES [dbo].[Recurso] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Recurso]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Validacion] FOREIGN KEY([Id_Validacion])
REFERENCES [dbo].[Validacion] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Validacion]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
/****** Object:  StoredProcedure [dbo].[ABCActividad]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCActividad]
(
  @Accion		nvarchar(10),
  @Id	int,
  @CACEI bit,
  @Licenciatura bit,
  @Personal bit,
  @ISO bit,
  @Posgrado bit,
  @Otro nchar(100)
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Actividad(CACEI, Licenciatura, Personal, ISO, Posgrado, Otro)
  VALUES 
  (@CACEI, @Licenciatura, @Personal, @ISO, @Posgrado, @Otro) 
	Declare @new_identity int;
	SELECT @new_identity = SCOPE_IDENTITY()
	SELECT @new_identity AS id

return @new_identity;
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Actividad WHERE Id = @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Actividad SET 
	CACEI = @CACEI, 
	Licenciatura = @Licenciatura,
	Personal = @Personal,
	ISO = @ISO,
	Posgrado = @Posgrado, 
	Otro = @Otro

	WHERE Id = @Id;
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT * FROM Actividad
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ABCEvento]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCEvento]
(
  @Accion nvarchar(10),
  @Id	int,
  @Nombre_Evento nvarchar(150),
  @Costo float,
  @Lugar nvarchar(150),
  @Fecha_Hora_Salida datetime2(7),
  @Fecha_Hora_Regreso datetime2(7)
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Evento(Nombre_Evento, Costo,Lugar, Fecha_Hora_Salida, Fecha_Hora_Regreso)
  VALUES 
  (@Nombre_Evento, @Costo,@Lugar, @Fecha_Hora_Salida, @Fecha_Hora_Regreso) 
  Declare @new_identity int;
	SELECT @new_identity = SCOPE_IDENTITY()
	SELECT @new_identity AS id

return @new_identity;
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Evento WHERE Id = @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Evento SET 
	Nombre_Evento = @Nombre_Evento,
	Costo = @Costo,
	Lugar = @Lugar, 
	Fecha_Hora_Salida = @Fecha_Hora_Salida, 
	Fecha_Hora_Regreso = @Fecha_Hora_Regreso

	WHERE Id = @Id;
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT * FROM Evento
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ABCRecurso]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCRecurso]
(
  @Accion		nvarchar(10),
  @Id int,
  @Hospedaje bit,
  @Transporte bit,
  @Combustible bit,
  @Viatico bit,
  @Oficio_Comision bit,
  @Otro nchar(250)
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Recurso(Hospedaje,Transporte,Combustible,Viatico,Oficio_Comision,Otro)
  VALUES 
  (@Hospedaje,@Transporte,@Combustible,@Viatico,@Oficio_Comision,@Otro)
 Declare @new_identity int;
	SELECT @new_identity = SCOPE_IDENTITY()
	SELECT @new_identity AS id

return @new_identity;
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Recurso WHERE Id = @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Recurso SET 
	Hospedaje = @Hospedaje,
	Transporte = @Transporte,
	Combustible = @Combustible,
	Viatico = @Viatico,
	Oficio_Comision = @Oficio_Comision,
	Otro = @Otro
	WHERE Id = @Id;
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT * FROM Recurso
END
RETURN
GO
INSERT [dbo].[Rol] ([Id], [Nombre_Rol], [Descripcion]) VALUES (1, N'Académico', N'Coordinador')
INSERT [dbo].[Rol] ([Id], [Nombre_Rol], [Descripcion]) VALUES (2, N'Académico', N'Posgrado')
INSERT [dbo].[Rol] ([Id], [Nombre_Rol], [Descripcion]) VALUES (3, N'Académico', N'Administradora')
INSERT [dbo].[Rol] ([Id], [Nombre_Rol], [Descripcion]) VALUES (4, N'Administrador', N'Subdirector')
INSERT [dbo].[Rol] ([Id], [Nombre_Rol], [Descripcion]) VALUES (5, N'Administrador', N'Director')
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (1, N'efren.cabrera@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (2, N'david.evans@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (3, N'jesus.augusto.garcia.caro@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (4, N'sancheze82@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (5, N'lugardo.diaz@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (6, N'asumuano@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (7, N'ivan.antillon@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (8, N'josue.jimenez@uabc.edu.mx ', 2)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (9, N'yarithza.perez@uabc.edu.mx', 3)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (10, N'a338694@uabc.edu.mx', 4)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (11, N'rlopez1@uabc.edu.mx', 5)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (1, N'Bioingeniería', 1)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (2, N'Ingeniería en Computación', 2)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (3, N'Ingeniería Civil', 3)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (4, N'Ingeniería Industrial', 4)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (5, N'Nanotecnología', 5)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (6, N'Ingeniería en Electrónica', 6)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (7, N'Arquitectura', 7)
INSERT [dbo].[Carrera] ([Id], [Nombre_Carrera], [Id_Usuario_Coordinador]) VALUES (8, N'Tronco Comun', 8)
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (1, N'Asignatura')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (2, N'Tiempo Completo Asociado A')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (3, N'Tiempo Completo Asociado B')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (4, N'Tiempo Completo Asociado C')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (5, N'Tiempo Completo Tecnico Academico')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (6, N'Tiempo Completo Titular A')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (7, N'Tiempo Completo Titular B')
INSERT [dbo].[Categoria] ([Id], [Nombre_Categoria]) VALUES (8, N'Tiempo Completo Titular C')
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (1, N'Procceso')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (2, N'Aceptado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (3, N'Rechazado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (4, N'Cancelado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (5, N'Reporte')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (6, N'Terminado')
SET IDENTITY_INSERT [dbo].[Estado] OFF

/****** Object:  StoredProcedure [dbo].[ABCUSolicitud]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCUSolicitud]
(
  @Accion		nvarchar(10),
  @Id	int,
  @Folio	nvarchar(max),
  @Nombre_Solicitante nvarchar(50),
  @Numero_Empleado int,
  @Id_Categoria int,
  @Id_Carrera int,
  @Id_Evento int,
  @Id_Recurso_Solicitado int,
  @Id_Actividad int,
  @Id_Validacion int,
  @Id_Estado int,
  @Fecha_Creacion datetime2(7),
  @Fecha_Modificacion datetime2(7),
  @URL_Reporte nvarchar(50),
  @Correo_Solicitante nchar(250),
  @Comentario_Rechazado nvarchar(max),
  @Leido bit
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Solicitud(Folio,Nombre_Solicitante, Numero_Empleado, Id_Categoria, Id_Carrera, 
  Id_Evento, Id_Recurso_Solicitado, Id_Actividad, Id_Validacion, Id_Estado, 
  Fecha_Creacion, Fecha_Modificacion, URL_Reporte, Correo_Solicitante, 
  Comentario_Rechazado, Leido)
  VALUES 
  (@Folio,@Nombre_Solicitante, @Numero_Empleado, @Id_Categoria, @Id_Carrera, 
  @Id_Evento, @Id_Recurso_Solicitado, @Id_Actividad, @Id_Validacion, @Id_Estado, 
  @Fecha_Creacion, @Fecha_Modificacion, @URL_Reporte, @Correo_Solicitante, 
  @Comentario_Rechazado, @Leido) 
Declare @new_identity int;
	SELECT @new_identity = SCOPE_IDENTITY()
	SELECT @new_identity AS id

return @new_identity;
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Solicitud WHERE Id	= @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Solicitud SET 
	Folio = @Folio,
	Nombre_Solicitante = @Nombre_Solicitante, 
	Numero_Empleado = @Numero_Empleado, 
	Id_Categoria = @Id_Categoria, 
	Id_Carrera = @Id_Carrera, 
	Id_Evento = @Id_Evento, 
	Id_Recurso_Solicitado = @Id_Recurso_Solicitado, 
	Id_Actividad = @Id_Actividad, 
	Id_Validacion = @Id_Validacion, 
	Id_Estado = @Id_Estado, 
	Fecha_Creacion = @Fecha_Creacion, 
	Fecha_Modificacion = @Fecha_Modificacion, 
	URL_Reporte = @URL_Reporte, 
	Correo_Solicitante = @Correo_Solicitante, 
	Comentario_Rechazado = @Comentario_Rechazado, 
	Leido = @Leido
    WHERE Id	= @Id	
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT * FROM Solicitud
INNER JOIN Categoria
ON (Solicitud.Id_Categoria = Categoria.Id)
INNER JOIN Carrera
ON(Solicitud.Id_Carrera=Carrera.Id)
INNER JOIN Evento
ON(Solicitud.Id_Evento = Evento.Id)
INNER JOIN Recurso
ON(Solicitud.Id_Recurso_Solicitado=Recurso.Id)
INNER JOIN Actividad
ON(Solicitud.Id_Actividad=Actividad.Id)
INNER JOIN Validacion
ON(Solicitud.Id_Validacion=Validacion.Id)
INNER JOIN Estado
ON(Solicitud.Id_Estado=Estado.Id)
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ABCUsuario]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCUsuario]
(
  @Accion		nvarchar(10),
  @Id	int,
  @Correo	nvarchar(50),
  @Id_Rol	int
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Usuario(Correo,Id_Rol)
  VALUES 
  (@Correo,@Id_Rol) 
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Usuario WHERE Id	= @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Usuario SET 
    Correo=   @Correo,
	Id_Rol= @Id_Rol
    WHERE Id	= @Id	
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT     
Usuario.Id,
Usuario.Correo,
Usuario.Id_Rol

FROM Usuario
WHERE     
(Usuario.Correo = @Correo)
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ABCValidacion]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*********************** [abcTipoUsuario] **************************************/
CREATE PROCEDURE [dbo].[ABCValidacion]
(
  @Accion nvarchar(10),
  @Id	int,
  @Coordinador bit,
  @Subdirector bit,
  @Administrador bit,
  @Director bit,
  @Posgrado bit,
  @Unica bit
)

AS

if @Accion = 'INSERTAR'
BEGIN
  INSERT INTO 
  Validacion(Coordinador, Subdirector, Administrador, Director, Posgrado, Unica)
  VALUES 
  (@Coordinador, @Subdirector, @Administrador, @Director, @Posgrado, @Unica) 
  Declare @new_identity int;
	SELECT @new_identity = SCOPE_IDENTITY()
	SELECT @new_identity AS id

return @new_identity;
END

if @Accion = 'BORRAR'
BEGIN
  DELETE FROM dbo.Validacion WHERE Id = @Id
END

if @Accion = 'MODIFICAR'
BEGIN
    UPDATE dbo.Validacion SET 
	Coordinador = @Coordinador, 
	Subdirector = @Subdirector, 
	Administrador = @Administrador, 
	Director = @Director, 
	Posgrado = @Posgrado, 
	Unica = @Unica

	WHERE Id = @Id;
END
if @Accion = 'CONSULTAR'
BEGIN 
SELECT * FROM Validacion
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ConsultasSolicitudes]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultasSolicitudes]
(
  @Accion		nvarchar(10)

)
AS

if @Accion = 'CONSULTAR_TODO'
BEGIN
SELECT * FROM Solicitud
INNER JOIN Categoria
ON (Solicitud.Id_Categoria = Categoria.Id)
INNER JOIN Carrera
ON(Solicitud.Id_Carrera=Carrera.Id)
INNER JOIN Evento
ON(Solicitud.Id_Evento = Evento.Id)
INNER JOIN Recurso
ON(Solicitud.Id_Recurso_Solicitado=Recurso.Id)
INNER JOIN Actividad
ON(Solicitud.Id_Actividad=Actividad.Id)
INNER JOIN Validacion
ON(Solicitud.Id_Validacion=Validacion.Id)
INNER JOIN Estado
ON(Solicitud.Id_Estado=Estado.Id) 
END


GO
/****** Object:  StoredProcedure [dbo].[EliminarSolicitudPorID]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarSolicitudPorID]
(
@Id int
)
AS
BEGIN
  DELETE FROM dbo.Solicitud WHERE Id	= @Id
END
RETURN


GO
/****** Object:  StoredProcedure [dbo].[ListaCarrera]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaCarrera]

AS
  SELECT * FROM Carrera
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ListaCategoria]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaCategoria]

AS
  SELECT * FROM Categoria
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ListadoUsuarioRolCarrera]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListadoUsuarioRolCarrera]

AS
SELECT Usuario.Id, Correo,Nombre_Rol,Descripcion,Nombre_carrera FROM Usuario
INNER JOIN Rol 
ON (Usuario.Id_Rol = Rol.Id)
FULL JOIN Carrera
ON(Usuario.Id=Carrera.Id_Usuario_Coordinador)


RETURN

GO
/****** Object:  StoredProcedure [dbo].[ListaEstado]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaEstado]

AS
  SELECT * FROM Estado
RETURN

GO
/****** Object:  StoredProcedure [dbo].[ListaRol]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaRol]

AS
  SELECT * FROM Rol
RETURN

GO
/****** Object:  StoredProcedure [dbo].[OptenerRolUsuarioPorID]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OptenerRolUsuarioPorID]
(
@Id_Rol int
)
AS
BEGIN 
SELECT * FROM Rol
WHERE     
(Rol.Id = @Id_Rol) 
END
RETURN

GO
/****** Object:  StoredProcedure [dbo].[SeleccionaCarreraCoordinador]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionaCarreraCoordinador]
(
  @Id_Usuario_Coordinador int
)

AS
  SELECT * FROM Carrera WHERE  Id_Usuario_Coordinador = @Id_Usuario_Coordinador
RETURN


GO
/****** Object:  StoredProcedure [dbo].[SeleccionaUsuarioRol]    Script Date: 11/29/2017 7:54:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionaUsuarioRol]
(
  @Id int
)

AS
  SELECT * FROM Rol WHERE Id = @Id
RETURN


GO
USE [master]
GO
ALTER DATABASE [dbSS] SET  READ_WRITE 
GO
