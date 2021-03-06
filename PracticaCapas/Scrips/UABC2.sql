USE [UsuariosUABC]
GO
/****** Object:  StoredProcedure [dbo].[ListadoUsuariosUABC]    Script Date: 11/29/2017 1:16:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListadoUsuariosUABC]

AS
  SELECT * FROM Usuario ORDER BY Email
RETURN
GO
/****** Object:  StoredProcedure [dbo].[SeleccionaUsuario]    Script Date: 11/29/2017 1:16:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionaUsuario]
(
@Email varchar(50),
@Contraseña varchar(50)
)
AS
BEGIN 
SELECT     
Usuario.Nombre,
Usuario.Apellido, 
Usuario.Email,
Usuario.Numero_Empleado,
Usuario.Contraseña

FROM Usuario
WHERE     
(Usuario.Email = @Email) AND (Usuario.Contraseña = @Contraseña)
END
RETURN
GO
