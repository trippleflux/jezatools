-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Andrej Jeznik
-- Create date: 11.09.2008
-- Description:	Insert new village
-- =============================================
CREATE PROCEDURE InsertVillage 
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
GO
