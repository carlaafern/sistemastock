USE [centro_salud]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[contraseña] [varchar](50) NULL,
	[estado] [binary](10) NULL,
	[fechaVigencia] [datetime] NULL,
	[login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[codigoTipoMov] [int] NOT NULL,
	[descripcionTipoMov] [varchar](50) NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[codigoTipoMov] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoMedicamento]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoMedicamento](
	[codigoTipoMedicamento] [int] NOT NULL,
	[descripcionTipoMedicam] [varchar](50) NULL,
	[presentacion] [varchar](50) NOT NULL,
	[unidadMedida] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoMedicamento] PRIMARY KEY CLUSTERED 
(
	[codigoTipoMedicamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoComprobante]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoComprobante](
	[codigoTipoComp] [int] NOT NULL,
	[descripcionTipoComp] [varchar](50) NULL,
 CONSTRAINT [PK_TipoComprobante] PRIMARY KEY CLUSTERED 
(
	[codigoTipoComp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockMedicamento]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMedicamento](
	[fecha] [datetime] NULL,
	[stockActual] [float] NULL,
	[stockInicioMes] [float] NULL,
	[stockMinimo] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receta](
	[fechaEntrega] [datetime] NULL,
	[fechaVigencia] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilegio]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Privilegio](
	[codigoPrivilegio] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Privilegio] PRIMARY KEY CLUSTERED 
(
	[codigoPrivilegio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerfilPrivilegio]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilPrivilegio](
	[fechaDesde] [datetime] NULL,
	[fechaHasta] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[codigoPerfil] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[codigoPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paciente](
	[dni] [varchar](50) NULL,
	[domicilio] [varchar](50) NULL,
	[fechaNacimiento] [datetime] NULL,
	[nombrePaciente] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[tipoDocumento] [varchar](50) NULL,
	[nroPaciente] [int] NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[nroPaciente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientoStock]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientoStock](
	[fechaMovimiento] [datetime] NULL,
	[nroMovimiento] [int] NOT NULL,
 CONSTRAINT [PK_MovimientoStock] PRIMARY KEY CLUSTERED 
(
	[nroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medico](
	[legajo] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[matricula] [varchar](50) NULL,
	[dni] [varchar](50) NULL,
	[fechaIngreso] [datetime] NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medicamentos]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[codigo] [decimal](8, 2) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Medicamento] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lote]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lote](
	[fechaElaboracion] [datetime] NULL,
	[fechaVto] [datetime] NULL,
	[nroLote] [int] NOT NULL,
 CONSTRAINT [PK_Lote] PRIMARY KEY CLUSTERED 
(
	[nroLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidad]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especialidad](
	[añosEspecialidad] [int] NULL,
	[codigoEspecialidad] [int] NOT NULL,
	[complejidad] [int] NULL,
	[descripcionEspecialidad] [varchar](50) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[codigoEspecialidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enfermedad]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enfermedad](
	[codigoEnfermedad] [int] NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[descripcionEnfermedad] [varchar](50) NULL,
	[diasReposo] [int] NULL,
	[gravedad] [int] NULL,
	[requiereInternacion] [binary](10) NULL,
	[tratamiento] [varchar](50) NULL,
 CONSTRAINT [PK_Enfermedad] PRIMARY KEY CLUSTERED 
(
	[codigoEnfermedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[efectorDestino] [int] NULL,
	[efectorOrigen] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleReceta]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleReceta](
	[cant] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleDonacion]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleDonacion](
	[comentario] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleComprobante]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleComprobante](
	[cantidadEntregada] [int] NULL,
	[cantidadSolicitada] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 03/23/2014 20:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comprobante](
	[estado] [binary](10) NULL,
	[fechaComprobante] [datetime] NULL,
	[nroComprobante] [int] NOT NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[nroComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
