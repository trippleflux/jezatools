USE [jcTBot]
GO
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[ResourcesId] [int] NULL,
	[ResourcesName] [nvarchar](50) NULL,
	[ResourcesLevel] [int] NULL,
 CONSTRAINT [PK_Resources_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillageID] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[BuildLevel] [int] NOT NULL,
	[NextCheck] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskList_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVillages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVillages] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[Villages]
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBuildingsGIDs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBuildingsGIDs] 
	-- Add the parameters for the stored procedure here
	-- <@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	-- <@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[BuildingGIDs]
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
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
	SELECT * FROM [dbo].[TaskList]
END
' 
END
