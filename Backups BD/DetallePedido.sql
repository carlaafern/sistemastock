USE [centro_salud]
GO

/****** Object:  Table [dbo].[DetallePedido]    Script Date: 02/16/2015 20:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetallePedido](
	[nroPedido] [int] NULL,
	[cantidad] [int] NULL,
	[nroDetallePedido] [int] NOT NULL,
	[codigoMedicamento] [int] NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[nroDetallePedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_DetallePedido] FOREIGN KEY([nroPedido])
REFERENCES [dbo].[Pedido] ([nroPedido])
GO

ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_DetallePedido]
GO

