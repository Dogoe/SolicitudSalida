USE [UsuariosFIAD]
GO
/****** Object:  StoredProcedure [dbo].[SeleccionaUsuario]    Script Date: 11/29/2017 1:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SeleccionaUsuario]
(
@Email varchar(50)
)
AS
BEGIN 
SELECT     
Usuario.Nombre,
Usuario.Email,
Usuario.Numero_Empleado

FROM Usuario
WHERE     
(Usuario.Email = @Email)
END
RETURN

GO
