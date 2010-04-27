USE [Reference_manual]
GO
/****** Object:  Trigger [dbo].[OnUpdateTaal]    Script Date: 04/27/2010 16:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[OnUpdateTaal] 
   ON  [dbo].[tblTaal]
   AFTER UPDATE
AS 
DECLARE @oudeTaal Varchar(50)
DECLARE @NieuweTaal Varchar(50)
DECLARE @Var Varchar(50)

BEGIN
	SET NOCOUNT ON;
--EXECUTE dbo.Manual_MaakTalenTabel
SET @oudeTaal = (SELECT taal from DELETED)
SET @oudeTaal = '[tblVglTaal].['+ @oudeTaal + ']'
SET @NieuweTaal = (SELECT taal from INSERTED)
EXEC sp_rename  @oudeTaal , @NieuweTaal, 'COLUMN'  
print(@NieuweTaal)
print(@oudeTaal)
END
