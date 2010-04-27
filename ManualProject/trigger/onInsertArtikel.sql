USE [Reference_manual]
GO
/****** Object:  Trigger [dbo].[OnInsertArtikel]    Script Date: 04/27/2010 16:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[OnInsertArtikel]
ON [dbo].[tblArtikel]
AFTER INSERT
AS
DECLARE @ArtikelID int
DECLARE @Tag Varchar(50)
DECLARE @Teller int
DECLARE @BedrijfID Varchar(50)
DECLARE @VersieID Varchar(50)
DECLARE @Var Varchar(500)
DECLARE @Count Varchar(50)
DECLARE @Taal Varchar(50)
DECLARE @FK_Taal int

BEGIN
SET NOCOUNT ON;
SET @VersieID = (select FK_Versie from INSERTED)
SET @BedrijfID = (select FK_Bedrijf from INSERTED)
SET @ArtikelID = (select ArtikelID from INSERTED)
SET @Tag = (select dbo.getSimpleTag(tag) from tblArtikel where ArtikelID=@ArtikelID)
SET @Teller = (select count(*) from tblVglTaal where tag=@Tag and VersieID=@VersieID and BedrijfID=@BedrijfID)
IF @Teller = 0
BEGIN
	DECLARE cTalen cursor FOR select TaalID from tblTaal
	SET @Var = 'INSERT into tblVglTaal VALUES(' + @VersieID + ',' + @BedrijfID + ',' + ''''  + @Tag + '''' 
	open cTalen;
	FETCH NEXT FROM cTalen into @FK_Taal
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @Count = (select count(*) from tblArtikel where dbo.getSimpleTag(tag)=@Tag AND FK_Taal=@FK_taal and FK_Bedrijf=@BedrijfID and 
FK_Versie=@VersieID)
		SET @Var = @Var + ',' + @Count
		FETCH NEXT FROM cTalen into @FK_Taal
	END
	SET @Var = @Var + ')'
	exec(@Var)
	close cTalen
	DEALLOCATE cTalen
END
IF @Teller = 1
BEGIN
	DECLARE cTalen cursor FOR select TaalID from tblTaal
	SET @Var = 'UPDATE tblVglTaal SET tag=''' + @Tag + ''''  
	open cTalen;
	FETCH NEXT FROM cTalen into @FK_Taal
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @Taal= (select Taal from tblTaal where TaalID=@FK_Taal)
		SET @count = (select count(*) from tblArtikel where dbo.getSimpleTag(tag)=@Tag AND FK_Taal=@FK_taal)
		SET @Var = @Var + ', ' + @Taal + '=' + @Count
		FETCH NEXT FROM cTalen into @FK_Taal
	END
	SET @Var = @Var + 'where tag=''' + @Tag + '''' + ' and BedrijfID=' + @BedrijfID  +' and VersieID=' + @VersieID
	exec(@Var)
	close cTalen
	DEALLOCATE cTalen
END
END
