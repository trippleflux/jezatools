USE [master]
GO

CREATE DATABASE [Coordinator] ON  PRIMARY
GO

USE [Coordinator]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Map](
	[Id] [int] NOT NULL,
	[Xcoord] [int] NOT NULL,
	[Ycoord] [int] NOT NULL,
	[Tid] [int] NOT NULL,
	[Vid] [int] NOT NULL,
	[Village] [nvarchar](50) NOT NULL,
	[Uid] [int] NOT NULL,
	[Player] [nvarchar](50) NOT NULL,
	[Aid] [int] NOT NULL,
	[Alliance] [nvarchar](50) NOT NULL,
	[Population] [int] NOT NULL
) ON [PRIMARY]
GO

