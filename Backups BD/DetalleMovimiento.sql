USE [centro_salud]
GO

/****** Object:  Table [dbo].[DetalleMovimientoStock]    Script Date: 01/31/2015 17:56:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetalleMovimientoStock](
	[nroMovimiento] [int] NOT NULL,
	[codigoMedicamento] [int] NULL,
	[cantidad] [int] NULL,
	[nroLote] [int] NULL,
	[codDetalle] [int] NOT NULL,
 CONSTRAINT [PK_DetalleMovimientoStock] PRIMARY KEY CLUSTERED 
(
	[codDetalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DetalleMovimientoStock]  WITH CHECK ADD  CONSTRAINT [FK_DetalleMovimientoStock_MovimientoStock] FOREIGN KEY([nroMovimiento])
REFERENCES [dbo].[MovimientoStock] ([nroMovimiento])
GO

ALTER TABLE [dbo].[DetalleMovimientoStock] CHECK CONSTRAINT [FK_DetalleMovimientoStock_MovimientoStock]
GO

