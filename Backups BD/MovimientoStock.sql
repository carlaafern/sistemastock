USE [centro_salud]
GO

/****** Object:  Table [dbo].[MovimientoStock]    Script Date: 01/31/2015 17:58:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovimientoStock](
	[fechaMovimiento] [datetime] NULL,
	[nroMovimiento] [int] NOT NULL,
	[tipoMovimiento] [int] NULL,
	[nroComprobante] [int] NULL,
 CONSTRAINT [PK_MovimientoStock] PRIMARY KEY CLUSTERED 
(
	[nroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

