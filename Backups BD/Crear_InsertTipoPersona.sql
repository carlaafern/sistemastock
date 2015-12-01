USE [centro_salud]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 04/26/2014 22:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[codigo] [int] NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
	
) 
INSERT INTO [centro_salud].[dbo].[TipoPersona]
           ([codigo]
           ,[tipo])
     VALUES
           (1,'Administrativo');


INSERT INTO [centro_salud].[dbo].[TipoPersona]
           ([codigo]
           ,[tipo])
     VALUES
           (2,'Medico');
           INSERT INTO [centro_salud].[dbo].[TipoPersona]
           ([codigo]
           ,[tipo])
     VALUES
           (3,'Paciente');
           
select * from centro_salud.dbo.TipoPersona;


