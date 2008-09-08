USE [jcTBot]
GO
/****** Object:  Table [dbo].[Villages]    Script Date: 09/08/2008 14:52:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Villages](
	[VillageId] [int] NULL,
	[VillageName] [nvarchar](50) NULL,
	[Warehouse] [int] NULL,
	[Granary] [int] NULL,
	[Wood] [int] NULL,
	[Clay] [int] NULL,
	[Iron] [int] NULL,
	[Crop] [int] NULL,
	[WoodProduction] [int] NULL,
	[ClayProduction] [int] NULL,
	[IronProduction] [int] NULL,
	[CropProduction] [int] NULL
) ON [PRIMARY]
