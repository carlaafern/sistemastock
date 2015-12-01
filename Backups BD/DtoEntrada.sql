USE [centro_salud]
GO

/****** Object:  Table [dbo].[DtoEntrada]    Script Date: 01/31/2015 18:00:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DtoEntrada](
	[item] [int] NULL,
	[codigoMedicamenteo] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[cantidad] [int] NULL,
	[codigo] [int] NOT NULL,
 CONSTRAINT [PK_DtoEntrada] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

