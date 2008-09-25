USE [master]
GO
/****** Object:  Database [TravianBot]    Script Date: 09/25/2008 15:05:24 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TravianBot')
BEGIN
CREATE DATABASE [TravianBot] ON  PRIMARY 
( NAME = N'TravianBot', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TravianBot.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TravianBot_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TravianBot_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
END
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'TravianBot', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TravianBot].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [TravianBot] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TravianBot] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TravianBot] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TravianBot] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TravianBot] SET ARITHABORT OFF
GO
ALTER DATABASE [TravianBot] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TravianBot] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TravianBot] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TravianBot] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TravianBot] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TravianBot] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TravianBot] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TravianBot] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TravianBot] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TravianBot] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TravianBot] SET  ENABLE_BROKER
GO
ALTER DATABASE [TravianBot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TravianBot] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TravianBot] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TravianBot] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TravianBot] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TravianBot] SET  READ_WRITE
GO
ALTER DATABASE [TravianBot] SET RECOVERY FULL
GO
ALTER DATABASE [TravianBot] SET  MULTI_USER
GO
ALTER DATABASE [TravianBot] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TravianBot] SET DB_CHAINING OFF
GO
USE [TravianBot]
GO
/****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertVillage]
GO
/****** Object:  StoredProcedure [dbo].[InsertProduction]    Script Date: 09/25/2008 15:05:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertProduction]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertProduction]
GO
/****** Object:  StoredProcedure [dbo].[InsertResources]    Script Date: 09/25/2008 15:05:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertResources]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertResources]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 09/25/2008 15:05:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
DROP TABLE [dbo].[Players]
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 09/25/2008 15:05:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
DROP TABLE [dbo].[TaskList]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
DROP TABLE [dbo].[Resources]
GO
/****** Object:  Table [dbo].[Production]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
DROP TABLE [dbo].[Production]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
DROP TABLE [dbo].[Priority]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/25/2008 15:05:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
DROP TABLE [dbo].[Tasks]
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/25/2008 15:05:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
DROP TABLE [dbo].[Villages]
GO
/****** Object:  StoredProcedure [dbo].[InsertProduction]    Script Date: 09/25/2008 15:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertProduction]
           (@VillageId int
           ,@Warehouse int
           ,@Granary int
           ,@Wood int
           ,@Clay int
           ,@Iron int
           ,@Crop int
           ,@WoodPerHour int
           ,@ClayPerHour int
           ,@IronPerHour int
           ,@CropPerHour int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId)
IF NOT EXISTS (SELECT [VillageId] FROM [TravianBot].[dbo].[Production] WHERE [TravianBot].[dbo].[Production].[VillageID] = @VillId)
INSERT INTO [TravianBot].[dbo].[Production]
           ([VillageId]
           ,[Warehouse]
           ,[Granary]
           ,[Wood]
           ,[Clay]
           ,[Iron]
           ,[Crop]
           ,[WoodPerHour]
           ,[ClayPerHour]
           ,[IronPerHour]
           ,[CropPerHour])
     VALUES
           (@villId
           ,@Warehouse
           ,@Granary
           ,@Wood
           ,@Clay
           ,@Iron
           ,@Crop
           ,@WoodPerHour
           ,@ClayPerHour
           ,@IronPerHour
           ,@CropPerHour)
ELSE
UPDATE [TravianBot].[dbo].[Production]
   SET [Warehouse] = @Warehouse
      ,[Granary] = @Granary
      ,[Wood] = @Wood
      ,[Clay] = @Clay
      ,[Iron] = @Iron
      ,[Crop] = @Crop
      ,[WoodPerHour] = @WoodPerHour
      ,[ClayPerHour] = @ClayPerHour
      ,[IronPerHour] = @IronPerHour
      ,[CropPerHour] = @CropPerHour
 WHERE [VillageId] = @villId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertResources]    Script Date: 09/25/2008 15:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertResources]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertResources]
           (@VillageId int
           ,@ResourcesFullName nvarchar(50)
           ,@ResourcesId int
           ,@ResourcesName nvarchar(50)
           ,@ResourcesLevel int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId);
	DECLARE @resourceVillageId int;
	SET @resourceVillageId = (SELECT [VillageId] FROM [TravianBot].[dbo].[Resources] WHERE [TravianBot].[dbo].[Resources].[VillageId] = @VillId);
	DECLARE @resourceId int;
	SET @resourceId = (SELECT [ResourcesId] FROM [TravianBot].[dbo].[Resources] WHERE [TravianBot].[dbo].[Resources].[ResourcesId] = @ResourcesId);

IF @resourceVillageId > 0 AND @resourceId > 0
INSERT INTO [TravianBot].[dbo].[Resources]
           ([VillageId]
           ,[ResourcesFullName]
           ,[ResourcesId]
           ,[ResourcesName]
           ,[ResourcesLevel])
     VALUES
           (@villId
           ,@ResourcesFullName
           ,@ResourcesId
           ,@ResourcesName
           ,@ResourcesLevel)
ELSE
UPDATE [TravianBot].[dbo].[Resources]
   SET [ResourcesLevel] = @ResourcesLevel
      ,[ResourcesFullName] = @ResourcesFullName
      ,[ResourcesName] = @ResourcesName
 WHERE [VillageId] = @villId AND [ResourcesId] = @ResourcesId
END
' 
END
GO
/****** Object:  Table [dbo].[Players]    Script Date: 09/25/2008 15:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Players](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[PlayerName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/25/2008 15:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Villages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[VillageName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PlayerId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 09/25/2008 15:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[VillageId] [int] NOT NULL,
	[BuildId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[BuildLevel] [int] NOT NULL,
	[NextCheck] [datetime] NOT NULL,
	[Enabled] [int] NOT NULL,
	[PlayerId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resources](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[ResourcesFullName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ResourcesId] [int] NOT NULL,
	[ResourcesName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ResourcesLevel] [int] NOT NULL,
	[PlayerId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Production]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Production](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[Warehouse] [int] NULL,
	[Granary] [int] NULL,
	[Wood] [int] NULL,
	[Clay] [int] NULL,
	[Iron] [int] NULL,
	[Crop] [int] NULL,
	[WoodPerHour] [int] NULL,
	[ClayPerHour] [int] NULL,
	[IronPerHour] [int] NULL,
	[CropPerHour] [int] NULL,
	[PlayerId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[BuildingFullName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BuildingId] [int] NOT NULL,
	[BuildingName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BuildingLevel] [int] NOT NULL,
	[PlayerId] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Priority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PriorityLevel] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/25/2008 15:05:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertVillage] 
	(@VillageId int
	,@VillageName nvarchar(50))
AS
BEGIN
	SET NOCOUNT ON;
IF NOT EXISTS (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE @VillageId = [dbo].[Villages].[VillageId])
INSERT INTO [TravianBot].[dbo].[Villages]
           ([VillageId]
           ,[VillageName])
     VALUES
           (@VillageId
           ,@VillageName)
ELSE
UPDATE [jcTBot].[dbo].[Villages]
   SET [VillageName] = @VillageName
 WHERE [VillageId] = @VillageId
END
' 
END
GO
