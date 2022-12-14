USE [master]
GO
/****** Object:  Database [db_bankingsystem]    Script Date: 27/8/2022 23:20:29 ******/
CREATE DATABASE [db_bankingsystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_bankingsystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_bankingsystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_bankingsystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_bankingsystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_bankingsystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_bankingsystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_bankingsystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_bankingsystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_bankingsystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_bankingsystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_bankingsystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_bankingsystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_bankingsystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_bankingsystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_bankingsystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_bankingsystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_bankingsystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_bankingsystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_bankingsystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_bankingsystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_bankingsystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_bankingsystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_bankingsystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_bankingsystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_bankingsystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_bankingsystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_bankingsystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_bankingsystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_bankingsystem] SET RECOVERY FULL 
GO
ALTER DATABASE [db_bankingsystem] SET  MULTI_USER 
GO
ALTER DATABASE [db_bankingsystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_bankingsystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_bankingsystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_bankingsystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_bankingsystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_bankingsystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_bankingsystem', N'ON'
GO
ALTER DATABASE [db_bankingsystem] SET QUERY_STORE = OFF
GO
USE [db_bankingsystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/8/2022 23:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/8/2022 23:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Contrasenia] [nvarchar](64) NOT NULL,
	[EsActivo] [bit] NOT NULL,
	[Nombre] [nvarchar](256) NOT NULL,
	[Genero] [nvarchar](max) NULL,
	[Edad] [int] NULL,
	[Identificacion] [nvarchar](16) NOT NULL,
	[Direccion] [nvarchar](256) NOT NULL,
	[Telefono] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 27/8/2022 23:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[IdCuenta] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [nvarchar](16) NOT NULL,
	[TipoCuenta] [nvarchar](16) NOT NULL,
	[SaldoDisponible] [decimal](10, 2) NOT NULL,
	[Estado] [nvarchar](32) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaModificacion] [datetime2](7) NULL,
	[IdCliente] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 27/8/2022 23:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[TipoMovimiento] [nvarchar](16) NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Saldo] [decimal](10, 2) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[IdCuenta] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 27/8/2022 23:20:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[IdParametro] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](32) NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612021730_Initial', N'5.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612022320_Ajustes', N'5.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612050316_CorreccionEntidades', N'5.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828040401_AgregaParametro', N'5.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828041756_CambioNOmbreParametro', N'5.0.16')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Contrasenia], [EsActivo], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'123456', 1, N'Veronica Vicente', NULL, NULL, N'1718870965', N'La Forestal', N'0939481555')
INSERT [dbo].[Clientes] ([IdCliente], [Contrasenia], [EsActivo], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'65432845', 1, N'Ramiro Montalvo', NULL, NULL, N'0712345652', N'La Y', N'0234545815')
INSERT [dbo].[Clientes] ([IdCliente], [Contrasenia], [EsActivo], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (3, N'1234', 1, N'Jose Lema', NULL, NULL, N'1234567820', N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[Clientes] ([IdCliente], [Contrasenia], [EsActivo], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (4, N'5678', 1, N'Marianela Montalvo', NULL, NULL, N'56789013452', N'Amazonas y NNUU', N'097548965')
INSERT [dbo].[Clientes] ([IdCliente], [Contrasenia], [EsActivo], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (5, N'1245', 1, N'Juan Osorio', NULL, NULL, N'9876541237', N'13 junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (1, N'987456321', N'AHORROS', CAST(160.35 AS Decimal(10, 2)), N'ACTIVA', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-12T01:05:35.8184100' AS DateTime2), 1)
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (4, N'478758', N'AHORROS', CAST(1425.00 AS Decimal(10, 2)), N'ACTIVA', CAST(N'2022-08-27T19:38:40.1380329' AS DateTime2), CAST(N'2022-08-27T20:14:21.2218576' AS DateTime2), 3)
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (5, N'225487', N'AHORROS', CAST(100.00 AS Decimal(10, 2)), N'ACTIVA', CAST(N'2022-08-27T19:38:59.5157049' AS DateTime2), CAST(N'2022-08-27T20:14:42.1852227' AS DateTime2), 4)
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (6, N'495878', N'AHORROS', CAST(0.00 AS Decimal(10, 2)), N'ACTIVA', CAST(N'2022-08-27T19:39:16.5748676' AS DateTime2), CAST(N'2022-08-27T20:14:52.1657855' AS DateTime2), 5)
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (7, N'496825', N'AHORROS', CAST(540.00 AS Decimal(10, 2)), N'ACTIVA', CAST(N'2022-08-27T19:39:28.3657963' AS DateTime2), CAST(N'2022-08-27T20:14:56.7520552' AS DateTime2), 4)
INSERT [dbo].[Cuentas] ([IdCuenta], [NumeroCuenta], [TipoCuenta], [SaldoDisponible], [Estado], [FechaCreacion], [FechaModificacion], [IdCliente]) VALUES (8, N'585545', N'CORRIENTE', CAST(0.00 AS Decimal(10, 2)), N'ACTIVA', CAST(N'2022-08-27T20:20:09.2235515' AS DateTime2), NULL, 4)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (1, N'RETIRO', CAST(50.00 AS Decimal(10, 2)), CAST(200.35 AS Decimal(10, 2)), CAST(N'2022-06-18T23:06:07.5626603' AS DateTime2), 1)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (2, N'DEPOSITO', CAST(1960.00 AS Decimal(10, 2)), CAST(2160.35 AS Decimal(10, 2)), CAST(N'2022-06-18T23:15:20.3674890' AS DateTime2), 1)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (3, N'RETIRO', CAST(500.00 AS Decimal(10, 2)), CAST(1660.35 AS Decimal(10, 2)), CAST(N'2022-06-26T20:48:03.3367334' AS DateTime2), 1)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (4, N'RETIRO', CAST(400.00 AS Decimal(10, 2)), CAST(1260.35 AS Decimal(10, 2)), CAST(N'2022-06-26T20:48:14.2238813' AS DateTime2), 1)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (5, N'RETIRO', CAST(100.00 AS Decimal(10, 2)), CAST(1160.35 AS Decimal(10, 2)), CAST(N'2022-06-26T20:48:23.6757666' AS DateTime2), 1)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (6, N'DEPOSITO', CAST(2000.00 AS Decimal(10, 2)), CAST(2000.00 AS Decimal(10, 2)), CAST(N'2022-08-27T20:17:53.8992465' AS DateTime2), 4)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (7, N'DEPOSITO', CAST(100.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(N'2022-08-27T20:18:45.4566420' AS DateTime2), 5)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (8, N'DEPOSITO', CAST(540.00 AS Decimal(10, 2)), CAST(540.00 AS Decimal(10, 2)), CAST(N'2022-08-27T20:19:16.8687933' AS DateTime2), 7)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (9, N'RETIRO', CAST(575.00 AS Decimal(10, 2)), CAST(1425.00 AS Decimal(10, 2)), CAST(N'2022-08-27T20:20:56.9303034' AS DateTime2), 4)
INSERT [dbo].[Movimientos] ([IdMovimiento], [TipoMovimiento], [Valor], [Saldo], [Fecha], [IdCuenta]) VALUES (10, N'RETIRO', CAST(1000.00 AS Decimal(10, 2)), CAST(160.35 AS Decimal(10, 2)), CAST(N'2022-08-27T23:18:49.5787354' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[Parametros] ON 

INSERT [dbo].[Parametros] ([IdParametro], [Codigo], [Valor]) VALUES (1, N'CUPODIARIO', CAST(1000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Parametros] OFF
GO
/****** Object:  Index [IX_Cuentas_IdCliente]    Script Date: 27/8/2022 23:20:29 ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_IdCliente] ON [dbo].[Cuentas]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_IdCuenta]    Script Date: 27/8/2022 23:20:29 ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_IdCuenta] ON [dbo].[Movimientos]
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT (N'') FOR [NumeroCuenta]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT (N'') FOR [TipoCuenta]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT ((0.0)) FOR [SaldoDisponible]
GO
ALTER TABLE [dbo].[Cuentas] ADD  DEFAULT (N'') FOR [Estado]
GO
ALTER TABLE [dbo].[Movimientos] ADD  DEFAULT ((0.0)) FOR [Valor]
GO
ALTER TABLE [dbo].[Movimientos] ADD  DEFAULT ((0.0)) FOR [Saldo]
GO
ALTER TABLE [dbo].[Parametros] ADD  DEFAULT ((0.0)) FOR [Valor]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_IdCliente]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_IdCuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuentas] ([IdCuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_IdCuenta]
GO
USE [master]
GO
ALTER DATABASE [db_bankingsystem] SET  READ_WRITE 
GO
