USE [master]
GO
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
USE [TravianBot]
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaskId] [int] NOT NULL
) ON [PRIMARY]
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBuildIds]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetBuildIds]
AS
BEGIN
	SET NOCOUNT ON;

SELECT [ID]
      ,[BuildId]
      ,[BuildIdName]
  FROM [TravianBot].[dbo].[BuildIds]
ORDER BY [BuildId] ASC
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBuildsGIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetBuildsGIDs]
AS
BEGIN
	SET NOCOUNT ON;

SELECT [ID]
      ,[BuildingGIDId]
      ,[BuildingsGIDName]
  FROM [TravianBot].[dbo].[BuildingsGIDs]
ORDER BY [BuildingGIDId] ASC
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAtackInProgressId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateAtackInProgressId]
	(@FarmListId int
	,@AtackInProgress int)
AS
BEGIN
	SET NOCOUNT ON;

UPDATE [TravianBot].[dbo].[FarmList]
   SET [AtackInProgress] = @AtackInProgress
 WHERE [ID] = @FarmListId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FarmList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FarmList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[DestinationX] [int] NOT NULL,
	[DestinationY] [int] NOT NULL,
	[AttackType] [int] NOT NULL,
	[TroopsList] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TroopType] [int] NOT NULL,
	[TroopUnits] [int] NOT NULL,
	[Enabled] [int] NOT NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlayerId] [int] NOT NULL,
	[AtackInProgress] [int] NOT NULL,
	[TribeId] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttackTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AttackTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttackId] [int] NOT NULL,
	[AttackName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tribes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tribes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TribeId] [int] NOT NULL,
	[TribeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TroopTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TroopTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TribeId] [int] NOT NULL,
	[TroopId] [int] NOT NULL,
	[TroopName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildingsGIDs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuildingsGIDs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuildingGIDId] [int] NOT NULL,
	[BuildingsGIDName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildIds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuildIds](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BuildId] [int] NOT NULL,
	[BuildIdName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
END
GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetFarmList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetFarmList]
      (@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)
SELECT [ID]
      ,(SELECT [VillageId] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[ID] = [TravianBot].[dbo].[FarmList].[VillageId]) AS VillageId
      ,[DestinationX]
      ,[DestinationY]
      ,(SELECT [AttackId] FROM [TravianBot].[dbo].[AttackTypes] WHERE [TravianBot].[dbo].[AttackTypes].[ID] = [TravianBot].[dbo].[FarmList].[AttackType]) AS AttackTypeId
      ,[TroopsList]
      ,(SELECT [TroopName] FROM [TravianBot].[dbo].[TroopTypes] WHERE [TravianBot].[dbo].[TroopTypes].[ID] = [TravianBot].[dbo].[FarmList].[TroopType]) AS TroopName
      ,[TroopUnits]
      ,[Description]
  FROM [TravianBot].[dbo].[FarmList]
WHERE [Enabled] > 0 AND [PlayerId] = @playerVillageId AND [AtackInProgress] < 1
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertNewFarm]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertNewFarm]
           (@VillageId int
           ,@DestinationX int
           ,@DestinationY int
           ,@AttackType int
           ,@TroopList nvarchar(150)
           ,@TroopType int
           ,@TroopUnits int
           ,@Description nvarchar(max)
           ,@PlayerId int
           ,@TribeId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId);
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)
	DECLARE @idOfAttackType int;
	SET @idOfAttackType = (SELECT [ID] FROM [TravianBot].[dbo].[AttackTypes] WHERE [TravianBot].[dbo].[AttackTypes].[AttackId] = @AttackType)
	DECLARE @idOfTroopType int;
	SET @idOfTroopType = (SELECT [ID] FROM [TravianBot].[dbo].[TroopTypes] WHERE [TravianBot].[dbo].[TroopTypes].[TroopId] = @TroopType)
	DECLARE @idOfTribe int;
	SET @idOfTribe = (SELECT [ID] FROM [TravianBot].[dbo].[Tribes] WHERE [TravianBot].[dbo].[Tribes].[TribeId] = @TribeId)

INSERT INTO [TravianBot].[dbo].[FarmList]
           ([VillageId]
           ,[DestinationX]
           ,[DestinationY]
           ,[AttackType]
           ,[TroopsList]
           ,[TroopType]
           ,[TroopUnits]
           ,[Enabled]
           ,[Description]
           ,[PlayerId]
           ,[AtackInProgress]
           ,[TribeId])
     VALUES
           (@villId
           ,@DestinationX
           ,@DestinationY
           ,@idOfAttackType
           ,@TroopList
           ,@idOfTroopType
           ,@TroopUnits
           ,1
           ,@Description
           ,@playerVillageId
           ,0
           ,@idOfTribe)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetVillages]
      (@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

SELECT [ID]
      ,[VillageId]
      ,[VillageName]
      ,[PlayerId]
  FROM [TravianBot].[dbo].[Villages]
WHERE [PlayerId] = @playerVillageId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertNewTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[InsertNewTask]
           (@TaskId int
           ,@VillageId int
           ,@BuildId int
           ,@PriorityId int
           ,@BuildLevel int
           ,@NextCheck datetime
           ,@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId);
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)
	DECLARE @idOfTask int;
	SET @idOfTask = (SELECT [ID] FROM [TravianBot].[dbo].[Tasks] WHERE [TravianBot].[dbo].[Tasks].[TaskId] = @TaskId)

INSERT INTO [TravianBot].[dbo].[TaskList]
           ([TaskId]
           ,[VillageId]
           ,[BuildId]
           ,[PriorityId]
           ,[BuildLevel]
           ,[NextCheck]
           ,[Enabled]
           ,[PlayerId])
     VALUES
           (@idOfTask
           ,@VillId
           ,@BuildId
           ,@PriorityId
           ,@BuildLevel
           ,@NextCheck
           ,1
           ,@playerVillageId)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[InsertProduction]
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
           ,@CropPerHour int
           ,@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId)
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

IF NOT EXISTS (SELECT [VillageId] FROM [TravianBot].[dbo].[Production] WHERE [TravianBot].[dbo].[Production].[VillageId] = @VillId AND [TravianBot].[dbo].[Production].[PlayerId] = @playerVillageId)
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
           ,[CropPerHour]
           ,[PlayerId])
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
           ,@CropPerHour
           ,@playerVillageId)
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
 WHERE [VillageId] = @villId AND [PlayerId] = @playerVillageId
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskListForGUI]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[GetTaskListForGUI]
      (@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

SELECT [ID]
      ,(SELECT [TaskName] FROM [TravianBot].[dbo].[Tasks] WHERE [TravianBot].[dbo].[Tasks].[ID] = [TravianBot].[dbo].[TaskList].[TaskId]) AS TaskName
      ,(SELECT [VillageName] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[ID] = [TravianBot].[dbo].[TaskList].[VillageId]) AS VillageName
      ,(SELECT [BuildIdName] FROM [TravianBot].[dbo].[BuildIds] WHERE [TravianBot].[dbo].[BuildIds].[ID] = [TravianBot].[dbo].[TaskList].[BuildId]) AS BuildId
      ,(SELECT [PriorityName] FROM [TravianBot].[dbo].[Priority] WHERE [TravianBot].[dbo].[Priority].[ID] = [TravianBot].[dbo].[TaskList].[PriorityId]) AS Priority
      ,[BuildLevel]
      ,[NextCheck]
  FROM [TravianBot].[dbo].[TaskList]
WHERE [PlayerId] = @playerVillageId AND [Enabled] > 0
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GetProduction]
      (@PlayerId int)

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

SELECT [ID]
      ,(SELECT [VillageName] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[Id] = [TravianBot].[dbo].[Production].[VillageId]) AS VillageName
      ,(SELECT [VillageId] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[Id] = [TravianBot].[dbo].[Production].[VillageId]) AS VillageId
      ,[Warehouse]
      ,[Granary]
      ,[Wood]
      ,[Clay]
      ,[Iron]
      ,[Crop]
      ,[WoodPerHour]
      ,[ClayPerHour]
      ,[IronPerHour]
      ,[CropPerHour]
      -- ,(SELECT [PlayerName] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[ID] = @playerVillageId) AS PlayerName
  FROM [TravianBot].[dbo].[Production]
WHERE [PlayerId] = @playerVillageId
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertVillage]
           (@VillageId int
           ,@VillageName nvarchar(50)
           ,@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

IF EXISTS (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE @VillageId = [TravianBot].[dbo].[Villages].[VillageId] AND @playerVillageId = [TravianBot].[dbo].[Villages].[PlayerId]) 
UPDATE [TravianBot].[dbo].[Villages]
   SET [VillageName] = @VillageName
 WHERE [VillageId] = @VillageId AND [PlayerId] = @playerVillageId
ELSE
INSERT INTO [TravianBot].[dbo].[Villages]
           ([VillageId]
           ,[VillageName]
           ,[PlayerId])
     VALUES
           (@VillageId
           ,@VillageName
           ,@playerVillageId)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[GetTaskList]
      (@PlayerId int
      ,@NextCheck datetime)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

SELECT [ID]
      ,(SELECT [TaskId] FROM [TravianBot].[dbo].[Tasks] WHERE [TravianBot].[dbo].[Tasks].[ID] = [TravianBot].[dbo].[TaskList].[TaskId]) AS TaskId
      ,(SELECT [VillageId] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[ID] = [TravianBot].[dbo].[TaskList].[VillageId]) AS VillageId
      ,(SELECT [BuildIdName] FROM [TravianBot].[dbo].[BuildIds] WHERE [TravianBot].[dbo].[BuildIds].[ID] = [TravianBot].[dbo].[TaskList].[BuildId]) AS BuildIdName
      ,[PriorityId]
      ,[BuildLevel]
      ,[NextCheck]
      ,[Enabled]
      ,(SELECT [VillageName] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[ID] = [TravianBot].[dbo].[TaskList].[VillageId]) AS VillageName
      ,(SELECT [BuildId] FROM [TravianBot].[dbo].[BuildIds] WHERE [TravianBot].[dbo].[BuildIds].[ID] = [TravianBot].[dbo].[TaskList].[BuildId]) AS BuildId
  FROM [TravianBot].[dbo].[TaskList]
WHERE [Enabled] > 0 AND [PlayerId] = @playerVillageId AND [NextCheck] < @NextCheck
ORDER BY [PriorityId] DESC
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertResources]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[InsertResources]
           (@VillageId int
           ,@ResourcesFullName nvarchar(50)
           ,@ResourcesId int
           ,@ResourcesName nvarchar(50)
           ,@ResourcesLevel int
           ,@PlayerId int)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId);
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

IF EXISTS (SELECT [VillageId] FROM [TravianBot].[dbo].[Resources] WHERE [TravianBot].[dbo].[Resources].[VillageId] = @villId AND [TravianBot].[dbo].[Resources].[ResourcesId] = @ResourcesId AND [TravianBot].[dbo].[Resources].[PlayerId] = @playerVillageId) 
UPDATE [TravianBot].[dbo].[Resources]
   SET [ResourcesLevel] = @ResourcesLevel
      ,[ResourcesFullName] = @ResourcesFullName
      ,[ResourcesName] = @ResourcesName
 WHERE [VillageId] = @villId AND [ResourcesId] = @ResourcesId AND [PlayerId] = @playerVillageId
ELSE
INSERT INTO [TravianBot].[dbo].[Resources]
           ([VillageId]
           ,[ResourcesFullName]
           ,[ResourcesId]
           ,[ResourcesName]
           ,[ResourcesLevel]
           ,[PlayerId])
     VALUES
           (@villId
           ,@ResourcesFullName
           ,@ResourcesId
           ,@ResourcesName
           ,@ResourcesLevel
           ,@playerVillageId)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetResources]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GetResources]
      (@PlayerId int
      ,@VillageId int)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @villId int;
	SET @villId = (SELECT [ID] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[VillageId] = @VillageId);
	DECLARE @playerVillageId int;
	SET @playerVillageId = (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[PlayerId] = @PlayerId)

SELECT [ID]
      -- ,(SELECT [VillageName] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[Id] = [TravianBot].[dbo].[Resources].[VillageId]) AS VillageName
      -- ,(SELECT [VillageId] FROM [TravianBot].[dbo].[Villages] WHERE [TravianBot].[dbo].[Villages].[Id] = [TravianBot].[dbo].[Resources].[VillageId]) AS VillageId
      ,[ResourcesId]
      ,[ResourcesFullName]
      -- ,[ResourcesName]
      -- ,[ResourcesLevel]
      -- ,(SELECT [PlayerName] FROM [TravianBot].[dbo].[Players] WHERE [TravianBot].[dbo].[Players].[ID] = @playerVillageId) AS PlayerName
  FROM [TravianBot].[dbo].[Resources]
WHERE [PlayerId] = @playerVillageId AND [VillageId] = @villId
ORDER BY [ResourcesId] ASC
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNextCheckForTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateNextCheckForTask]
	(@TaskId int
	,@NextCheck datetime)
AS
BEGIN
	SET NOCOUNT ON;

UPDATE [TravianBot].[dbo].[TaskList]
   SET [NextCheck] = @NextCheck
 WHERE [ID] = @TaskId
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTasks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetTasks]
AS
BEGIN
	SET NOCOUNT ON;

SELECT [ID]
      ,[TaskId]
      ,[TaskName]
  FROM [TravianBot].[dbo].[Tasks]
ORDER BY [TaskId] ASC
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPriority]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetPriority]
AS
BEGIN
	SET NOCOUNT ON;

SELECT [ID]
      ,[PriorityLevel]
      ,[PriorityName]
  FROM [TravianBot].[dbo].[Priority]
ORDER BY [PriorityLevel] ASC
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPlayer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertPlayer]
           (@PlayerId int
           ,@PlayerName nvarchar(50))
AS
BEGIN
	SET NOCOUNT ON;
IF NOT EXISTS (SELECT [ID] FROM [TravianBot].[dbo].[Players] WHERE @PlayerId = [TravianBot].[dbo].[Players].[PlayerId])
INSERT INTO [TravianBot].[dbo].[Players]
           ([PlayerId]
           ,[PlayerName])
     VALUES
           (@PlayerId
           ,@PlayerName)
ELSE
UPDATE [TravianBot].[dbo].[Players]
   SET [PlayerName] = @PlayerName
 WHERE [PlayerId] = @PlayerId
END
' 
END
