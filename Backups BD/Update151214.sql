USE [centro_salud]
GO
--Crear DetalleMovimientoStock

/****** Object:  Table [dbo].[DetalleMovimientoStock]    Script Date: 12/15/2014 21:23:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetalleMovimientoStock](
	[nroMovimiento] [int] NOT NULL,
	[codigoMedicamento] [int] NULL,
	[cantidad] [int] NULL,
	[nroLote] [int] NULL,
 CONSTRAINT [PK_DetalleMovimientoStock] PRIMARY KEY CLUSTERED 
(
	[nroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DetalleMovimientoStock]  WITH CHECK ADD  CONSTRAINT [FK_DetalleMovimientoStock_MovimientoStock] FOREIGN KEY([nroMovimiento])
REFERENCES [dbo].[MovimientoStock] ([nroMovimiento])
GO

ALTER TABLE [dbo].[DetalleMovimientoStock] CHECK CONSTRAINT [FK_DetalleMovimientoStock_MovimientoStock]
GO
--Create Medicamento

CREATE TABLE [dbo].[Medicamento](
	[codigo] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[monoDroga] [varchar](50) NULL,
	[descripcionAmpliada] [varchar](50) NULL,
	[formato] [int] NULL,
	[unidadMedida] [int] NULL,
 CONSTRAINT [PK_Medicamento] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Medicamento]  WITH CHECK ADD  CONSTRAINT [FK_Medicamento_Formato] FOREIGN KEY([formato])
REFERENCES [dbo].[Formato] ([codigoPresentacion])
GO

ALTER TABLE [dbo].[Medicamento] CHECK CONSTRAINT [FK_Medicamento_Formato]
GO

ALTER TABLE [dbo].[Medicamento]  WITH CHECK ADD  CONSTRAINT [FK_Medicamento_UnidadMedida] FOREIGN KEY([unidadMedida])
REFERENCES [dbo].[UnidadMedida] ([codigoUnidadMed])
GO

ALTER TABLE [dbo].[Medicamento] CHECK CONSTRAINT [FK_Medicamento_UnidadMedida]
GO

--Crear Unidad de Medida

CREATE TABLE [dbo].[UnidadMedida](
	[codigoUnidadMed] [int] NOT NULL,
	[descripcionUnidadMed] [varchar](50) NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[codigoUnidadMed] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--Crear Entrada

CREATE TABLE [dbo].[Entrada](
	[nroRemito] [int] NULL,
	[nroMovimiento] [int] NULL
) ON [PRIMARY]

GO

---Crear Baja

CREATE TABLE [dbo].[Baja](
	[motivoBaja] [varchar](50) NULL,
	[nroMovimiento] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO