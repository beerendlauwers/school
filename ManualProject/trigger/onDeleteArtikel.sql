USE [Reference_manual]
GO
/****** Object:  Trigger [dbo].[OnDeleteArtikel]    Script Date: 04/27/2010 16:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[OnDeleteArtikel] 
   ON  [dbo].[tblArtikel]
   FOR DELETE
AS 
DECLARE @Tag Varchar(50)
DECLARE @bool int
DECLARE @TaalID int
DECLARE @Taal Varchar(50)
DECLARE @BedrijfID Varchar(50)
DECLARE @VersieID Varchar(50)
DECLARE @Var Nchar(255)
DECLARE c1 cursor for SELECT taalID from tblTaal
BEGIN
	SET NOCOUNT ON;
SET @VersieID = (select FK_Versie from DELETED)
SET @BedrijfID = (select FK_Bedrijf from DELETED)
SET @Tag = (select tag from DELETED)
SET @Tag = (select dbo.getSimpleTag(@Tag))
SET @TaalID = (select FK_taal from DELETED)
SET @Taal = (select Taal from tblTaal where TaalID=@TaalID)
SET @Var = 'Update tblVglTaal SET ' + @Taal + '=0 where tag='''+ @Tag + '''' + '  and BedrijfID=' + @BedrijfID  +' and VersieID=' + @VersieID 
EXEC(@Var)
SET @Bool = 1
open c1;
FETCH NEXT FROM c1 INTO @TaalID
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @Taal = (select taal from tblTaal where taalID=@TaalID)
	DECLARE @A VARCHAR(100)	
	SELECT @Var = 'SELECT @A = '+@Taal+' FROM tblVglTaal WHERE tag ='''+ @Tag + '''' + ' and BedrijfID=' + @BedrijfID + ' and VersieID=' + @VersieID
	EXEC SP_EXECUTESQL @Var, N'@A VARCHAR(100) OUTPUT', @A OUTPUT
	SET @bool = @A
	IF @bool = 1
		BREAK
	FETCH NEXT FROM c1 INTO @TaalID
END
CLOSE c1
DEALLOCATE c1
IF @bool = 0
	BEGIN
	DELETE FROM tblVglTaal where tag=@Tag and versieID=@VersieID and BedrijfID=@BedrijfID
	END
END

