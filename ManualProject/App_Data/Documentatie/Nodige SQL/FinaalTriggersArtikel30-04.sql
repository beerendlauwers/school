
CREATE TRIGGER [dbo].[OnDeleteArtikel] 
   ON  [dbo].[tblArtikel]
   FOR DELETE
AS 
DECLARE @Tag NVarchar(MAX)
DECLARE @bool int
DECLARE @TaalID int
DECLARE @Taal NVarchar(MAX)
DECLARE @BedrijfID NVarchar(MAX)
DECLARE @VersieID NVarchar(MAX)
DECLARE @Var NVarchar(MAX)
DECLARE cDeleted cursor for SELECT FK_Versie,FK_Bedrijf,FK_taal,tag FROM DELETED
BEGIN
open cDeleted;
FETCH NEXT FROM cDeleted into @VersieID, @BedrijfID,@TaalID,@Tag
WHILE @@FETCH_STATUS=0
BEGIN
DECLARE c1 cursor for SELECT taalID from tblTaal
SET @Tag = (select dbo.getSimpleTag(@Tag))
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
FETCH NEXT FROM cDeleted into @VersieID, @BedrijfID,@TaalID,@Tag
END
close cDeleted
DEALLOCATE cDeleted
END




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
DECLARE cInserted cursor for Select FK_Versie,FK_Bedrijf,ArtikelID from INSERTED
BEGIN

SET NOCOUNT ON

open cInserted;
FETCH NEXT FROM cInserted INTO @VersieID,@BedrijfID,@ArtikelID
WHILE @@FETCH_STATUS = 0
BEGIN
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
FETCH NEXT FROM cInserted INTO @VersieID,@BedrijfID,@ArtikelID
END
close cInserted
DEALLOCATE cInserted
END





CREATE TRIGGER [dbo].[OnUpdateArtikel]
   ON  [dbo].[tblArtikel]
   AFTER UPDATE
AS 

DECLARE @Tag Varchar(1000)
DECLARE @bool int
DECLARE @TaalIDn int
DECLARE @TaalID int
DECLARE @Tagn Varchar(1000)
DECLARE @Taal Varchar(1000)
DECLARE @Var NVarchar(2000)
DECLARE @Teller int
DECLARE @Count Varchar(1000)
DECLARE @FK_Taal int
DECLARE @speshal Varchar(1000)
DECLARE @BedrijfID Varchar(1000)
DECLARE @VersieID Varchar(1000)
DECLARE @BedrijfIDn Varchar(1000)
DECLARE @VersieIDn Varchar(1000)
DECLARE @Test Varchar(1000)
DECLARE cInserted cursor for select I.tag,I.FK_Versie,I.FK_Bedrijf,I.FK_Taal,D.tag,D.FK_Versie,D.FK_Bedrijf,D.FK_Taal from INSERTED I, DELETED D
BEGIN	

SET NOCOUNT ON

open cInserted;
FETCH NEXT FROM cInserted INTO @Tagn,@VersieIDn,@BedrijfIDn,@TaalIDn,@Tag,@VersieID,@BedrijfID,@TaalID
WHILE @@FETCH_STATUS = 0
BEGIN

	--ALS ER EEN TAG OF VERSIE OF BEDRIJF GEUPDATE WERD IN HET GEUPDATE ARTIKEL
	IF UPDATE( tag ) or UPDATE(FK_Versie) or UPDATE(FK_Bedrijf)
	BEGIN
	--UPDATE DE RIJ EN GA NA OF ER NOG 1'TJES STAAN IN DIE RIJ
		DECLARE cTaalID cursor for SELECT taalID from tblTaal
		SET NOCOUNT ON;
		SELECT @Tag = dbo.getSimpleTag(@Tag)
		SELECT @Taal = Taal from tblTaal where TaalID=@TaalID
		SET @Var = 'Update tblVglTaal SET ' + @Taal + '=0 where tag='''+ @Tag + '''' + ' and BedrijfID=' + @BedrijfID + ' and VersieID=' + @VersieID
		EXEC(@Var)
		--insert into tblTestTag(ArtikelID,NieuweTag) VALUES(1,@Var)
		SET @Bool = 1
		open cTaalID;
		FETCH NEXT FROM cTaalID INTO @TaalID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @Taal = taal from tblTaal where taalID=@TaalID
			DECLARE @A VARCHAR(100)	
			SELECT @Var = 'SELECT @A = '+@Taal+' FROM tblVglTaal WHERE tag ='''+ @Tag + '''' + ' and BedrijfID=' + @BedrijfID +' and VersieID=' + @VersieID
			EXEC SP_EXECUTESQL @Var, N'@A VARCHAR(100) OUTPUT', @A OUTPUT
			SET @bool = @A
			IF @bool = 1
				BREAK
			FETCH NEXT FROM cTaalID INTO @TaalID
		END
		close cTaalID
		DEALLOCATE cTaalID
	END
	--ALS ER VOOR ALLE TALEN HET AANTAL GEVONDEN TAGS 0 IS DELETE DIE RIJ
	IF @bool = 0
	BEGIN
		DELETE FROM tblVglTaal where tag=@Tag and bedrijfID=@bedrijfID and VersieID=@VersieID
		--SET @Test='DELETE FROM tblVglTaal where tag=''' + @Tag + '''' + ' and bedrijfID=' + @bedrijfID + 'and VersieID= ' + @VersieID
		--insert into tblTestTag(ArtikelID,NieuweTag) VALUES(1,@Test)
	END



	--INSERT NIEUWE RIJ ALS TAG NOG NIET IN TBL VOORKOMT
	SELECT @Tagn = dbo.getSimpleTag(@Tagn)
	SELECT @Teller = count(*) from tblVglTaal where tag=@Tagn AND bedrijfID=@BedrijfIDn and VersieID=@VersieIDn
	IF @Teller = 0
	BEGIN
		SET @speshal = 'INSERT into tblVglTaal VALUES(' + @VersieIDn + ',' + @BedrijfIDn + ',' + ''''  + @Tagn + '''' 
		DECLARE cTalen cursor FOR select TaalID from tblTaal
		open cTalen;
		FETCH NEXT FROM cTalen into @FK_Taal
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @Count = count(*) from tblArtikel where dbo.getSimpleTag(tag)=@Tagn AND FK_Taal=@FK_taal AND FK_Bedrijf=@BedrijfIDn AND FK_Versie=@VersieIDn
			SET @speshal = @speshal + ',' + @Count
			FETCH NEXT FROM cTalen into @FK_Taal
		END
		close cTalen
		DEALLOCATE cTalen
		SET @Var = @speshal + ')'
		--insert into tblTestTag(ArtikelID,NieuweTag) VALUES(1,@Var)
		exec(@Var)
	END
	--UPDATE RIJ ALS TAG AL IN TBL VOORKOMT VOOR BEDRIJF EN VERSIE
	IF @Teller > 0
	BEGIN
		DECLARE cTalen cursor FOR select TaalID from tblTaal
		SET @Var = 'UPDATE tblVglTaal SET '  
		open cTalen;
		FETCH NEXT FROM cTalen into @FK_Taal
		WHILE @@FETCH_STATUS = 0
		BEGIN
			select @Taal = Taal from tblTaal where TaalID=@FK_Taal
			select @count = count(*) from tblArtikel where dbo.getSimpleTag(tag)=@Tagn AND FK_Taal=@FK_taal  AND FK_Bedrijf=@BedrijfIDn AND FK_Versie=@VersieIDn
			SET @Var = @Var + @Taal + '=' + @Count + ', '
			FETCH NEXT FROM cTalen into @FK_Taal
		END
		SET @Var = RTRIM(LTRIM(@Var))
		SET @Var= left(@Var,len(@Var)-1)
		SET @Var = @Var + ' where tag=''' + @Tagn + '''' + ' and BedrijfID=' + @BedrijfIDn +' and VersieID=' + @VersieIDn
		--insert into tblTestTag(ArtikelID,NieuweTag) VALUES(1,@Var)
		exec(@Var)
		--select @Var
		close cTalen
		DEALLOCATE cTalen
	END
FETCH NEXT FROM cInserted INTO @Tagn,@VersieIDn,@BedrijfIDn,@TaalIDn,@Tag,@VersieID,@BedrijfID,@TaalID

END
close cInserted
DEALLOCATE cInserted
END
