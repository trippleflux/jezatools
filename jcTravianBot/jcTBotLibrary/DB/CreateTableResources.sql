USE [jcTBot]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 09/08/2008 14:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[VillageId] [int] NULL,
	[ResourceId] [nvarchar](50) NULL,
	[ResourceName] [nvarchar](50) NULL
) ON [PRIMARY]
