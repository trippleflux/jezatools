USE [master]
GO
/****** Object:  Database [Coordinator]    Script Date: 12/20/2009 16:13:15 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Coordinator')
BEGIN
CREATE DATABASE [Coordinator]
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Coordinator', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coordinator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coordinator] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Coordinator] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Coordinator] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Coordinator] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Coordinator] SET ARITHABORT OFF
GO
ALTER DATABASE [Coordinator] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Coordinator] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Coordinator] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Coordinator] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Coordinator] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Coordinator] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Coordinator] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Coordinator] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Coordinator] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Coordinator] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Coordinator] SET  DISABLE_BROKER
GO
ALTER DATABASE [Coordinator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Coordinator] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Coordinator] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Coordinator] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Coordinator] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Coordinator] SET  READ_WRITE
GO
ALTER DATABASE [Coordinator] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Coordinator] SET  MULTI_USER
GO
ALTER DATABASE [Coordinator] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Coordinator] SET DB_CHAINING OFF
GO
USE [Coordinator]
GO
/****** Object:  StoredProcedure [dbo].[SelectUsers]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectUsers]
GO
/****** Object:  StoredProcedure [dbo].[SelectMap]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectMap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectMap]
GO
/****** Object:  StoredProcedure [dbo].[UpdateNotes]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNotes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateNotes]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Units]') AND type in (N'U'))
DROP TABLE [dbo].[Units]
GO
/****** Object:  Table [dbo].[AttackType]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttackType]') AND type in (N'U'))
DROP TABLE [dbo].[AttackType]
GO
/****** Object:  StoredProcedure [dbo].[UpdateMap]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateMap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateMap]
GO
/****** Object:  StoredProcedure [dbo].[SelectExcludedPlayers]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectExcludedPlayers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectExcludedPlayers]
GO
/****** Object:  StoredProcedure [dbo].[SelectExcludedAlliances]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectExcludedAlliances]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectExcludedAlliances]
GO
/****** Object:  StoredProcedure [dbo].[UpdateExcludedPlayer]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateExcludedPlayer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateExcludedPlayer]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSettings]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateSettings]
GO
/****** Object:  StoredProcedure [dbo].[SelectSettings]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectSettings]
GO
/****** Object:  StoredProcedure [dbo].[DeleteVillage]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteVillage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteVillage]
GO
/****** Object:  StoredProcedure [dbo].[DeleteExcludedPlayer]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteExcludedPlayer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteExcludedPlayer]
GO
/****** Object:  StoredProcedure [dbo].[DeleteExcludedAlliance]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteExcludedAlliance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteExcludedAlliance]
GO
/****** Object:  StoredProcedure [dbo].[UpdateExcludedAlliance]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateExcludedAlliance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateExcludedAlliance]
GO
/****** Object:  StoredProcedure [dbo].[UpdateReportUnits]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateReportUnits]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateReportUnits]
GO
/****** Object:  StoredProcedure [dbo].[SelectLast100Reports]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectLast100Reports]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SelectLast100Reports]
GO
/****** Object:  StoredProcedure [dbo].[UpdateReports]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateReports]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateReports]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[ExcludedPlayers]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcludedPlayers]') AND type in (N'U'))
DROP TABLE [dbo].[ExcludedPlayers]
GO
/****** Object:  Table [dbo].[Map]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Map]') AND type in (N'U'))
DROP TABLE [dbo].[Map]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notes]') AND type in (N'U'))
DROP TABLE [dbo].[Notes]
GO
/****** Object:  Table [dbo].[ExcludedAlliances]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcludedAlliances]') AND type in (N'U'))
DROP TABLE [dbo].[ExcludedAlliances]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Settings]
GO
/****** Object:  Table [dbo].[ReportInfo]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportInfo]') AND type in (N'U'))
DROP TABLE [dbo].[ReportInfo]
GO
/****** Object:  Table [dbo].[ReportGoods]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGoods]') AND type in (N'U'))
DROP TABLE [dbo].[ReportGoods]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[ReportUnits]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportUnits]') AND type in (N'U'))
DROP TABLE [dbo].[ReportUnits]
GO
/****** Object:  User [ANUBIS\ASPNET]    Script Date: 12/20/2009 16:13:15 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ANUBIS\ASPNET')
DROP USER [ANUBIS\ASPNET]
GO
/****** Object:  User [ANUBIS\ASPNET]    Script Date: 12/20/2009 16:13:15 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ANUBIS\ASPNET')
CREATE USER [ANUBIS\ASPNET] FOR LOGIN [ANUBIS\ASPNET] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[UpdateNotes]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNotes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateNotes] 
	@VillageCoordinates int,
	@Notes ntext
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
			 (SELECT Id 
			  FROM [Notes]
			  WHERE VillageCoordinates = @VillageCoordinates
			 )
		BEGIN
			INSERT INTO [Notes]
					   ([VillageCoordinates]
					   ,[Notes])
				 VALUES
					   (@VillageCoordinates
					   ,@Notes)
		END
	ELSE
		BEGIN
			UPDATE [Notes]
			   SET [Notes] = @Notes
			 WHERE [VillageCoordinates] = @VillageCoordinates
		END
END
' 
END
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoordinatesX] [int] NULL,
	[CoordinatesY] [int] NULL,
	[NextFarm] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DistanceX] [int] NULL,
	[DistanceY] [int] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageCoordinates] [int] NOT NULL,
	[Notes] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UnitCount] [int] NULL,
	[AttackType] [int] NULL,
	[UnitId] [int] NULL,
	[RiskyLevel] [int] NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Units]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Units]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TribeId] [int] NOT NULL,
	[UnitName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UnitId] [int] NOT NULL,
	[CultureInfo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AttackType]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttackType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AttackType](
	[Id] [int] NOT NULL,
	[AttackId] [int] NOT NULL,
	[AttackName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CultureInfo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ExcludedAlliances]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcludedAlliances]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExcludedAlliances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AllianceId] [int] NOT NULL,
	[AllianceName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExludedType] [int] NOT NULL,
 CONSTRAINT [PK_ExcludedAlliances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Map]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Map](
	[VillageId] [int] NOT NULL,
	[VillageName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[VillageLink] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserLink] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AllianceId] [int] NOT NULL,
	[AllianceName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AllianceLink] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Population] [int] NOT NULL,
	[CoordinateX] [int] NOT NULL,
	[CoordinateY] [int] NOT NULL,
	[TribeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PlayerStatus] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlayerStatusLink] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ExcludedPlayers]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcludedPlayers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExcludedPlayers](
	[PlayerId] [int] NOT NULL,
	[PlayerName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExcludedType] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[ReportLink] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportText] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReportDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReportInfo]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[AttackerId] [int] NULL,
	[AttackerName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefenderId] [int] NULL,
	[DefenderName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AttackerVillageId] [int] NULL,
	[AttackerVillageName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefenderVillageId] [int] NULL,
	[DefenderVillageName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReportInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReportUnits]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportUnits]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[TribeId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Unit1] [int] NOT NULL,
	[Unit2] [int] NOT NULL,
	[Unit3] [int] NOT NULL,
	[Unit4] [int] NOT NULL,
	[Unit5] [int] NOT NULL,
	[Unit6] [int] NOT NULL,
	[Unit7] [int] NOT NULL,
	[Unit8] [int] NOT NULL,
	[Unit9] [int] NOT NULL,
	[Unit10] [int] NOT NULL,
	[UnitHero] [int] NOT NULL,
 CONSTRAINT [PK_ReportUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReportGoods]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGoods]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportGoods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Wood] [int] NOT NULL,
	[Clay] [int] NOT NULL,
	[Iron] [int] NOT NULL,
	[Crop] [int] NOT NULL,
	[Carry] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportDate] [datetime] NULL,
	[AttackerId] [int] NULL,
	[DefenderVillageId] [int] NULL,
 CONSTRAINT [PK_ReportGoods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSettings]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSettings]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateSettings]
	@CoordinatesX int,
	@CoordinatesY int,
	@NextFarm nvarchar(max),
	@DistanceX int,
	@DistanceY int
AS
BEGIN
	SET NOCOUNT ON;
UPDATE [Settings]
   SET [CoordinatesX] = @CoordinatesX
      ,[CoordinatesY] = @CoordinatesY
      ,[NextFarm] = @NextFarm
      ,[DistanceX] = @DistanceX
      ,[DistanceY] = @DistanceY
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectSettings]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectSettings]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SelectSettings] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [CoordinatesX]
		  ,[CoordinatesY]
		  ,[NextFarm]
		  ,[DistanceX]
		  ,[DistanceY]
	  FROM [Settings]
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectMap]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectMap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE PROCEDURE [dbo].[SelectMap] 
	-- Add the parameters for the stored procedure here
	@CoordinateX int,
	@CoordinateY int,
	@DistanceX int,
	@DistanceY int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [VillageId]
      ,[VillageName]
      ,[VillageLink]
      ,[UserId]
      ,[UserName]
      ,[UserLink]
      ,[AllianceId]
      ,[AllianceName]
      ,[AllianceLink]
      ,[Population]
      ,[CoordinateX]
      ,[CoordinateY]
      ,[TribeName]
      ,( ROUND(SQRT((@CoordinateX-[CoordinateX])*(@CoordinateX-[CoordinateX]) + (@CoordinateY-[CoordinateY])*(@CoordinateY-[CoordinateY])), 0) ) AS Distance
      ,(SELECT [Notes] FROM [Notes] WHERE [Map].[VillageId]=[Notes].[VillageCoordinates]) AS Notes
      ,[PlayerStatus]
      ,[PlayerStatusLink]
  FROM [Map]
WHERE (NOT EXISTS (SELECT [PlayerId] FROM [ExcludedPlayers] WHERE [Map].[UserId]=[ExcludedPlayers].[PlayerId])) AND 
      (NOT EXISTS (SELECT [AllianceId] FROM [ExcludedAlliances] WHERE [Map].[AllianceId]=[ExcludedAlliances].[AllianceId])) AND 
      (([CoordinateX] > @CoordinateX-@DistanceX) AND ([CoordinateX] < @CoordinateX+@DistanceX) AND ([CoordinateY] > @CoordinateY-@DistanceY) AND ([CoordinateY] < @CoordinateY+@DistanceY))
ORDER BY Distance ASC
END






' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectExcludedAlliances]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectExcludedAlliances]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SelectExcludedAlliances]
	@ExludedType nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [AllianceId], [AllianceName] FROM [ExcludedAlliances] 
     WHERE [ExludedType]=@ExludedType
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteExcludedAlliance]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteExcludedAlliance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteExcludedAlliance]
	@AllianceId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [ExcludedAlliances] WHERE [AllianceId] = @AllianceId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateExcludedAlliance]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateExcludedAlliance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateExcludedAlliance] 
	@AllianceId int, 
	@AllianceName nvarchar(50),
	@ExludedType int
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
				 (SELECT [AllianceId] FROM [ExcludedAlliances]
				  WHERE AllianceId = @AllianceId
				 )
		BEGIN
			INSERT INTO [ExcludedAlliances]
					   ([AllianceId]
					   ,[AllianceName]
					   ,[ExludedType])
				 VALUES
					   (@AllianceId
					   ,@AllianceName
					   ,@ExludedType)
		END
	ELSE
		BEGIN
			UPDATE [ExcludedAlliances]
			   SET [AllianceName] = @AllianceName
				  ,[ExludedType] = @ExludedType
			 WHERE [AllianceId] = @AllianceId
		END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteVillage]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteVillage]
	@VillageId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [Map] WHERE [VillageId]=@VillageId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMap]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateMap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[UpdateMap] 
					   @VillageId int,
					   @VillageName nvarchar(50),
					   @VillageLink nvarchar(max),
					   @UserId int,
					   @UserName nvarchar(50),
					   @UserLink nvarchar(max),
					   @AllianceId int,
					   @AllianceName nvarchar(50) = NULL,
					   @AllianceLink nvarchar(max),
					   @Population int,
					   @CoordinateX int,
					   @CoordinateY int,
					   @TribeName nvarchar(50),
					   @PlayerStatus nvarchar(max),
					   @PlayerStatusLink nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
			 (SELECT VillageId 
			  FROM [Map]
			  WHERE VillageId = @VillageId
			 )
		BEGIN
			INSERT INTO [Map]
					   ([VillageId]
					   ,[VillageName]
					   ,[VillageLink]
					   ,[UserId]
					   ,[UserName]
					   ,[UserLink]
					   ,[AllianceId]
					   ,[AllianceName]
					   ,[AllianceLink]
					   ,[Population]
					   ,[CoordinateX]
					   ,[CoordinateY]
					   ,[TribeName]
					   ,[PlayerStatus]
					   ,[PlayerStatusLink])
				 VALUES
					   (@VillageId
					   ,@VillageName
					   ,@VillageLink
					   ,@UserId
					   ,@UserName
					   ,@UserLink
					   ,@AllianceId
					   ,@AllianceName
					   ,@AllianceLink
					   ,@Population
					   ,@CoordinateX
					   ,@CoordinateY
					   ,@TribeName
					   ,@PlayerStatus
					   ,@PlayerStatusLink)
		END
	ELSE
		BEGIN
			UPDATE [Map]
			   SET [VillageName] = @VillageName
				  ,[VillageLink] = @VillageLink
				  ,[UserId] = @UserId
				  ,[UserName] = @UserName
				  ,[UserLink] = @UserLink
				  ,[AllianceId] = @AllianceId
				  ,[AllianceName] = @AllianceName
				  ,[AllianceLink] = @AllianceLink
				  ,[Population] = @Population
				  ,[CoordinateX] = @CoordinateX
				  ,[CoordinateY] = @CoordinateY
				  ,[TribeName] = @TribeName
				  ,[PlayerStatus] = @PlayerStatus
				  ,[PlayerStatusLink] = @PlayerStatusLink
			 WHERE [VillageId] = @VillageId
		END
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateExcludedPlayer]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateExcludedPlayer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateExcludedPlayer]
	@PlayerId int, 
	@PlayerName nvarchar(50),
	@ExludedType int
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
				 (SELECT [PlayerId] FROM [ExcludedPlayers]
				  WHERE PlayerId = @PlayerId
				 )
		BEGIN
		INSERT INTO [ExcludedPlayers]
				   ([PlayerId]
				   ,[PlayerName]
				   ,[ExcludedType])
			 VALUES
				   (@PlayerId
				   ,@PlayerName
				   ,@ExludedType)
		END
	ELSE
		BEGIN
		UPDATE [ExcludedPlayers]
		   SET [PlayerName] = @PlayerName
		      ,[ExcludedType] = @ExludedType
		 WHERE [PlayerId] = @PlayerId
		END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectExcludedPlayers]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectExcludedPlayers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SelectExcludedPlayers]
	@ExludedType int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [PlayerId], [PlayerName] FROM [Coordinator].[dbo].[ExcludedPlayers]
     WHERE [ExcludedType]=@ExludedType
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteExcludedPlayer]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteExcludedPlayer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteExcludedPlayer] 
	@PlayerId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [ExcludedPlayers] WHERE [PlayerId] = @PlayerId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateReports]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateReports]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateReports] 
	@ReportId int,
	@ReportLink nvarchar(max),
	@ReportText nvarchar(50),
	@ReportDate datetime,
	@AttackerId int,
	@AttackerName nvarchar(50),
	@DefenderId int,
	@DefenderName nvarchar(50),
	@AttackerVillageId int,
	@AttackerVillageName nvarchar(50),
	@DefenderVillageId int,
	@DefenderVillageName nvarchar(50),
	@GoodsWood int,
	@GoodsClay int,
	@GoodsIron int,
	@GoodsCrop int,
	@Carry nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
			 (SELECT Id 
			  FROM [Reports]
			  WHERE [ReportId] = @ReportId
			 )
		BEGIN
			INSERT INTO [Reports]
					   ([ReportId]
					   ,[ReportLink]
					   ,[ReportText]
					   ,[ReportDate])
				 VALUES
					   (@ReportId
					   ,@ReportLink
					   ,@ReportText
					   ,@ReportDate)
		END
	IF NOT EXISTS
			 (SELECT Id 
			  FROM [ReportInfo]
			  WHERE [ReportId] = @ReportId
			 )
		BEGIN
			INSERT INTO [ReportInfo]
					   ([ReportId]
					   ,[AttackerId]
					   ,[AttackerName]
					   ,[DefenderId]
					   ,[DefenderName]
					   ,[AttackerVillageId]
					   ,[AttackerVillageName]
					   ,[DefenderVillageId]
					   ,[DefenderVillageName])
				 VALUES
					   (@ReportId
					   ,@AttackerId
					   ,@AttackerName
					   ,@DefenderId
					   ,@DefenderName
					   ,@AttackerVillageId
					   ,@AttackerVillageName
					   ,@DefenderVillageId
					   ,@DefenderVillageName)
		END
	IF NOT EXISTS
			 (SELECT Id 
			  FROM [ReportGoods]
			  WHERE [ReportId] = @ReportId
			 )
		BEGIN
INSERT INTO [Coordinator].[dbo].[ReportGoods]
           ([ReportId]
           ,[Wood]
           ,[Clay]
           ,[Iron]
           ,[Crop]
           ,[Carry]
           ,[ReportDate]
           ,[AttackerId]
           ,[DefenderVillageId])
     VALUES
           (@ReportId
           ,@GoodsWood
           ,@GoodsClay
           ,@GoodsIron
           ,@GoodsCrop
           ,@Carry
           ,@ReportDate
           ,@AttackerId
           ,@DefenderVillageId)
		END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectLast100Reports]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectLast100Reports]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SelectLast100Reports]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 100 [ReportLink]
		  ,[ReportText]
		  ,[ReportDate]
	  FROM [Reports]
	ORDER BY [ReportDate] DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateReportUnits]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateReportUnits]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateReportUnits]
	@ReportId int,
	@TribeId int,
	@Type int,
	@Unit1 int,
	@Unit2 int,
	@Unit3 int,
	@Unit4 int,
	@Unit5 int,
	@Unit6 int,
	@Unit7 int,
	@Unit8 int,
	@Unit9 int,
	@Unit10 int,
	@UnitHero int
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS
			 (SELECT Id 
			  FROM [ReportUnits]
			  WHERE [ReportId] = @ReportId AND [Type] = @Type
			 )
		BEGIN
INSERT INTO [ReportUnits]
           ([ReportId]
           ,[TribeId]
           ,[Type]
           ,[Unit1]
           ,[Unit2]
           ,[Unit3]
           ,[Unit4]
           ,[Unit5]
           ,[Unit6]
           ,[Unit7]
           ,[Unit8]
           ,[Unit9]
           ,[Unit10]
           ,[UnitHero])
     VALUES
           (@ReportId
           ,@TribeId
           ,@Type
           ,@Unit1
           ,@Unit2
           ,@Unit3
           ,@Unit4
           ,@Unit5
           ,@Unit6
           ,@Unit7
           ,@Unit8
           ,@Unit9
           ,@Unit10
           ,@UnitHero)
		END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SelectUsers]    Script Date: 12/20/2009 16:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SelectUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SelectUsers]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id]
      ,[Name]
      ,[Password]
      ,(SELECT [RoleName] FROM Roles WHERE [Roles].[RoleId]=[Users].[RoleId]) AS RoleName
  FROM Users
END
' 
END
GO
