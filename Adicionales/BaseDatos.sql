USE [master]
GO
/****** Object:  Database [db_bankingsystem]    Script Date: 27/8/2022 21:13:06 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/8/2022 21:13:06 ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/8/2022 21:13:06 ******/
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
/****** Object:  Table [dbo].[Cuentas]    Script Date: 27/8/2022 21:13:06 ******/
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
/****** Object:  Table [dbo].[Movimientos]    Script Date: 27/8/2022 21:13:06 ******/
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
/****** Object:  Index [IX_Cuentas_IdCliente]    Script Date: 27/8/2022 21:13:06 ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_IdCliente] ON [dbo].[Cuentas]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_IdCuenta]    Script Date: 27/8/2022 21:13:06 ******/
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
