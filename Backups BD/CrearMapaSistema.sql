USE [centro_salud]
GO

/****** Object:  Table [dbo].[MapaSistema]    Script Date: 01/12/2015 23:12:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MapaSistema](
	[codigomapa] [int] NULL,
	[modulo] [int] NULL,
	[opcion] [int] NULL,
	[descripcion] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


