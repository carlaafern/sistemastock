USE [centro_salud]
GO

/****** Object:  Table [dbo].[Pagina]    Script Date: 01/31/2015 19:44:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pagina](
	[idPagina] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[url] [varchar](440) NULL,
	[esAccion] [bit] NULL,
	[rowVersionColumn] [timestamp] NULL,
 CONSTRAINT [PK_Pagina] PRIMARY KEY CLUSTERED 
(
	[idPagina] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 01/31/2015 19:44:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Perfil](
	[codigoPerfil] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[privilegio] [int] NULL,
	[rowVersionColumn] [timestamp] NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[codigoPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[PerfilPagina]    Script Date: 01/31/2015 19:45:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PerfilPagina](
	[codigoPerfil] [int] NOT NULL,
	[codigoPagina] [int] NOT NULL,
	[rowVersionColumn] [timestamp] NULL
) ON [PRIMARY]

GO