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
-- Description:	Insert new task
-- =============================================
CREATE PROCEDURE InsertTask 
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
GO
