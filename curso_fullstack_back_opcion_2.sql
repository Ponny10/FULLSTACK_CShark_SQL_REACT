USE [master]
GO
/****** Object:  Database [curso_fullstack]    Script Date: 12/01/2025 11:42:43 p. m. ******/
CREATE DATABASE [curso_fullstack]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'curso_fullstack', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\curso_fullstack.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'curso_fullstack_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\curso_fullstack_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [curso_fullstack] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [curso_fullstack].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [curso_fullstack] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [curso_fullstack] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [curso_fullstack] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [curso_fullstack] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [curso_fullstack] SET ARITHABORT OFF 
GO
ALTER DATABASE [curso_fullstack] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [curso_fullstack] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [curso_fullstack] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [curso_fullstack] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [curso_fullstack] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [curso_fullstack] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [curso_fullstack] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [curso_fullstack] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [curso_fullstack] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [curso_fullstack] SET  DISABLE_BROKER 
GO
ALTER DATABASE [curso_fullstack] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [curso_fullstack] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [curso_fullstack] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [curso_fullstack] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [curso_fullstack] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [curso_fullstack] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [curso_fullstack] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [curso_fullstack] SET RECOVERY FULL 
GO
ALTER DATABASE [curso_fullstack] SET  MULTI_USER 
GO
ALTER DATABASE [curso_fullstack] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [curso_fullstack] SET DB_CHAINING OFF 
GO
ALTER DATABASE [curso_fullstack] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [curso_fullstack] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [curso_fullstack] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [curso_fullstack] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'curso_fullstack', N'ON'
GO
ALTER DATABASE [curso_fullstack] SET QUERY_STORE = ON
GO
ALTER DATABASE [curso_fullstack] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [curso_fullstack]
GO
/****** Object:  User [curso_fullstack]    Script Date: 12/01/2025 11:42:43 p. m. ******/
CREATE USER [curso_fullstack] FOR LOGIN [curso_fullstack] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_datareader] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [curso_fullstack]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [curso_fullstack]
GO
/****** Object:  Table [dbo].[alumno]    Script Date: 12/01/2025 11:42:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[direccion] [varchar](120) NOT NULL,
	[edad] [int] NOT NULL,
	[email] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[asignatura]    Script Date: 12/01/2025 11:42:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignatura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[creditos] [int] NOT NULL,
	[profesor] [varchar](120) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calificacion]    Script Date: 12/01/2025 11:42:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calificacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](120) NOT NULL,
	[nota] [real] NOT NULL,
	[porcentaje] [int] NOT NULL,
	[matriculaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[matricula]    Script Date: 12/01/2025 11:42:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matricula](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[alumnoId] [int] NOT NULL,
	[asignaturaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profesor]    Script Date: 12/01/2025 11:42:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profesor](
	[usuario] [varchar](120) NOT NULL,
	[pass] [varchar](12) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[email] [varchar](120) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[asignatura] ADD  DEFAULT ((0)) FOR [creditos]
GO
ALTER TABLE [dbo].[asignatura]  WITH CHECK ADD FOREIGN KEY([profesor])
REFERENCES [dbo].[profesor] ([usuario])
GO
ALTER TABLE [dbo].[calificacion]  WITH CHECK ADD FOREIGN KEY([matriculaId])
REFERENCES [dbo].[matricula] ([id])
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD FOREIGN KEY([alumnoId])
REFERENCES [dbo].[alumno] ([id])
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD FOREIGN KEY([asignaturaId])
REFERENCES [dbo].[asignatura] ([id])
GO
USE [master]
GO
ALTER DATABASE [curso_fullstack] SET  READ_WRITE 
GO
