USE [master]
GO
/****** Object:  Database [jcTBot]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'jcTBot')
BEGIN
CREATE DATABASE [jcTBot] ON  PRIMARY 
( NAME = N'jcTBot', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\jcTBot.mdf' , SIZE = 2240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'jcTBot_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\jcTBot_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'jcTBot', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [jcTBot].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [jcTBot] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [jcTBot] SET ANSI_NULLS OFF
GO
ALTER DATABASE [jcTBot] SET ANSI_PADDING OFF
GO
ALTER DATABASE [jcTBot] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [jcTBot] SET ARITHABORT OFF
GO
ALTER DATABASE [jcTBot] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [jcTBot] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [jcTBot] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [jcTBot] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [jcTBot] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [jcTBot] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [jcTBot] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [jcTBot] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [jcTBot] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [jcTBot] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [jcTBot] SET  ENABLE_BROKER
GO
ALTER DATABASE [jcTBot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [jcTBot] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [jcTBot] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [jcTBot] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [jcTBot] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [jcTBot] SET  READ_WRITE
GO
ALTER DATABASE [jcTBot] SET RECOVERY FULL
GO
ALTER DATABASE [jcTBot] SET  MULTI_USER
GO
ALTER DATABASE [jcTBot] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [jcTBot] SET DB_CHAINING OFF
GO
USE [jcTBot]
GO
/****** Object:  ForeignKey [FK_TaskList_Tasks]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Tasks]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList] DROP CONSTRAINT [FK_TaskList_Tasks]
GO
/****** Object:  ForeignKey [FK_TaskList_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList] DROP CONSTRAINT [FK_TaskList_Villages]
GO
/****** Object:  ForeignKey [FK_Production_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Production_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Production]'))
ALTER TABLE [dbo].[Production] DROP CONSTRAINT [FK_Production_Villages]
GO
/****** Object:  ForeignKey [FK_Resources_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Resources_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Resources]'))
ALTER TABLE [dbo].[Resources] DROP CONSTRAINT [FK_Resources_Villages]
GO
/****** Object:  ForeignKey [FK_Buildings_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Villages]
GO
/****** Object:  StoredProcedure [dbo].[GetVillagesNamesAndIDs]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillagesNamesAndIDs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetVillagesNamesAndIDs]
GO
/****** Object:  StoredProcedure [dbo].[GetTaskList]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetTaskList]
GO
/****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertVillage]
GO
/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertTask]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertTask]
GO
/****** Object:  StoredProcedure [dbo].[GetProductionForVillages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductionForVillages]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetProductionForVillages]
GO
/****** Object:  StoredProcedure [dbo].[GetTaskNames]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNames]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetTaskNames]
GO
/****** Object:  StoredProcedure [dbo].[InsertVillageResourceLevel]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillageResourceLevel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertVillageResourceLevel]
GO
/****** Object:  StoredProcedure [dbo].[InsertVillageBuildingsLevel]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillageBuildingsLevel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertVillageBuildingsLevel]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBuildingsLevel]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteBuildingsLevel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteBuildingsLevel]
GO
/****** Object:  StoredProcedure [dbo].[DeleteResourceLevel]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteResourceLevel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteResourceLevel]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
DROP TABLE [dbo].[Priority]
GO
/****** Object:  Table [dbo].[BuildingGIDs]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildingGIDs]') AND type in (N'U'))
DROP TABLE [dbo].[BuildingGIDs]
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
DROP TABLE [dbo].[Villages]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
DROP TABLE [dbo].[Tasks]
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
DROP TABLE [dbo].[TaskList]
GO
/****** Object:  Table [dbo].[Production]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
DROP TABLE [dbo].[Production]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
DROP TABLE [dbo].[Resources]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 09/16/2008 15:04:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[BuildingGIDs]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuildingGIDs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BuildingGIDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[BuildingGID] [int] NOT NULL,
 CONSTRAINT [PK_BuildingGIDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Priority](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [nchar](10) NOT NULL,
	[PriorityLevel] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Villages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Villages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageId] [int] NOT NULL,
	[VillageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Villages_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[BuildLevel] [int] NOT NULL,
	[NextCheck] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskList_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Production]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Production]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Production](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
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
 CONSTRAINT [PK_Production_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[ResourcesId] [int] NULL,
	[ResourcesName] [nvarchar](50) NULL,
	[ResourcesLevel] [int] NULL,
 CONSTRAINT [PK_Resources_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[BuildingId] [int] NULL,
	[BuildingName] [nvarchar](50) NULL,
	[BuildingLevel] [int] NULL,
 CONSTRAINT [PK_Buildings_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVillageBuildingsLevel]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillageBuildingsLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 16.09.2008
-- Description:	Insert new village buildings level
-- =============================================
CREATE PROCEDURE [dbo].[InsertVillageBuildingsLevel]
	-- Add the parameters for the stored procedure here
	 (@VillageID int
	 ,@BuildingId int
     ,@BuildingName nvarchar(50)
     ,@BuildingLevel int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[Buildings]
           ([VillageID]
           ,[BuildingId]
           ,[BuildingName]
           ,[BuildingLevel])
     VALUES
           (@VillageID
           ,@BuildingId
           ,@BuildingName
           ,@BuildingLevel)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBuildingsLevel]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteBuildingsLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 16.09.2008
-- Description:	Delete verything from Buildings
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBuildingsLevel]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE FROM [jcTBot].[dbo].[Buildings]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new task
-- =============================================
CREATE PROCEDURE [dbo].[InsertTask] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@TaskId int
	,@BuildLevel int 
	,@NextCheck datetime)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[TaskList]
           ([VillageID]
           ,[TaskId]
           ,[BuildLevel]
           ,[NextCheck])
     VALUES
           (@VillageId
           ,@TaskId
           ,@BuildLevel
           ,@NextCheck)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskList]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Get current tasks list
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskList]
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[TaskList].[VillageID]) AS VillageName
      ,(SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks] WHERE [jcTBot].[dbo].[Tasks].[Id] = [jcTBot].[dbo].[TaskList].[TaskId]) AS TaskName
      ,[BuildLevel]
      ,[NextCheck]
  FROM [jcTBot].[dbo].[TaskList]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTaskNames]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaskNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get available task names
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskNames] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [TaskName] FROM [jcTBot].[dbo].[Tasks]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductionForVillages]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProductionForVillages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 12.09.2008
-- Description:	Get production, warehouse and granary capacity
-- =============================================
CREATE PROCEDURE [dbo].[GetProductionForVillages] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,(SELECT [VillageName] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageName
      ,(SELECT [VillageId] FROM [jcTBot].[dbo].[Villages] WHERE [jcTBot].[dbo].[Villages].[Id] = [jcTBot].[dbo].[Production].[VillageID]) AS VillageId
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
  FROM [jcTBot].[dbo].[Production]	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVillage]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new village
-- =============================================
CREATE PROCEDURE [dbo].[InsertVillage] 
	-- Add the parameters for the stored procedure here
	(@VillageId int
	,@VillageName nvarchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[Villages]
           ([VillageId]
           ,[VillageName])
     VALUES
           (@VillageId
           ,@VillageName)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetVillagesNamesAndIDs]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillagesNamesAndIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Gets Villages (Names and IDs) list
-- =============================================
CREATE PROCEDURE [dbo].[GetVillagesNamesAndIDs] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [VillageId], [VillageName] FROM [dbo].[Villages]
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVillageResourceLevel]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertVillageResourceLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 16.09.2008
-- Description:	Insert new village resource level
-- =============================================
CREATE PROCEDURE [dbo].[InsertVillageResourceLevel]
	-- Add the parameters for the stored procedure here
	 (@VillageID int
	 ,@ResourceId int
     ,@ResourceName nvarchar(50)
     ,@ResourceLevel int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [jcTBot].[dbo].[Resources]
           ([VillageID]
           ,[ResourcesId]
           ,[ResourcesName]
           ,[ResourcesLevel])
     VALUES
           (@VillageID
           ,@ResourceId
           ,@ResourceName
           ,@ResourceLevel)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteResourceLevel]    Script Date: 09/16/2008 15:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteResourceLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 16.09.2008
-- Description:	Delete verything from Resources
-- =============================================
CREATE PROCEDURE [dbo].[DeleteResourceLevel]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DELETE FROM [jcTBot].[dbo].[Resources]
END
' 
END
GO
/****** Object:  ForeignKey [FK_TaskList_Tasks]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Tasks]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Tasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[TaskList] CHECK CONSTRAINT [FK_TaskList_Tasks]
GO
/****** Object:  ForeignKey [FK_TaskList_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskList_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskList]'))
ALTER TABLE [dbo].[TaskList]  WITH CHECK ADD  CONSTRAINT [FK_TaskList_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
ALTER TABLE [dbo].[TaskList] CHECK CONSTRAINT [FK_TaskList_Villages]
GO
/****** Object:  ForeignKey [FK_Production_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Production_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Production]'))
ALTER TABLE [dbo].[Production]  WITH CHECK ADD  CONSTRAINT [FK_Production_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
ALTER TABLE [dbo].[Production] CHECK CONSTRAINT [FK_Production_Villages]
GO
/****** Object:  ForeignKey [FK_Resources_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Resources_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Resources]'))
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [FK_Resources_Villages]
GO
/****** Object:  ForeignKey [FK_Buildings_Villages]    Script Date: 09/16/2008 15:04:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Buildings_Villages]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Villages] FOREIGN KEY([VillageID])
REFERENCES [dbo].[Villages] ([Id])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Villages]
GO
