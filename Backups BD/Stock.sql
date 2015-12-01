USE [centro_salud]
GO

/****** Object:  Table [dbo].[StockMedicamento]    Script Date: 01/31/2015 19:43:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockMedicamento](
	[stockActual] [float] NULL,
	[stockInicioMes] [float] NULL,
	[stockMinimo] [float] NOT NULL,
	[stockAlerta] [float] NULL,
	[codigoStock] [int] NOT NULL,
	[codigoMedicamento] [int] NULL,
 CONSTRAINT [PK_StockMedicamento] PRIMARY KEY CLUSTERED 
(
	[codigoStock] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

