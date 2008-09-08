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
	[WarehouseCapacety] [int] NULL,
	[GranaryCapacety] [int] NULL,
	[WoodAvailable] [int] NULL,
	[ClayAvailable] [int] NULL,
	[IronAvailable] [int] NULL,
	[CropAvailable] [int] NULL,
	[WoodProduction] [int] NULL,
	[ClayProduction] [int] NULL,
	[IronProduction] [int] NULL,
	[CropProduction] [int] NULL
) ON [PRIMARY]
