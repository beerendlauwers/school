USE [Reference_manual]
GO
/****** Object:  StoredProcedure [dbo].[Manual_HerstelTags]    Script Date: 04/28/2010 09:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Manual_HerstelTags]
	@teGebruikenModule NVARCHAR(255)
AS
	DECLARE cArtikels CURSOR FOR SELECT tag, artikelID FROM tblArtikel A WHERE ( SELECT count(data) FROM dbo.SplitTekst( A.tag, '_' ) ) < 5
	DECLARE @artikelID INT
	DECLARE @huidigeTag NVARCHAR(255)
	DECLARE @versie NVARCHAR(255)
	DECLARE @taal NVARCHAR(255)
	DECLARE @bedrijf NVARCHAR(255)
	DECLARE @tag NVARCHAR(255)
BEGIN
	
	OPEN cArtikels;
	FETCH NEXT FROM cArtikels INTO @huidigeTag, @artikelID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @versie = data FROM dbo.SplitTekst( @huidigeTag, '_' ) WHERE id = 1;
		SELECT @taal = data FROM dbo.SplitTekst( @huidigeTag, '_' ) WHERE id = 2;
		SELECT @bedrijf = data FROM dbo.SplitTekst( @huidigeTag, '_' ) WHERE id = 3;
		SELECT @tag = data FROM dbo.SplitTekst( @huidigeTag, '_' ) WHERE id = 4;
		SET @huidigeTag = @versie + '_' + @taal + '_' + @bedrijf + '_' + @teGebruikenModule + '_' + @tag;
		UPDATE tblArtikel SET tag = @huidigeTag WHERE artikelID = @artikelID

		FETCH NEXT FROM cArtikels INTO @huidigeTag, @artikelID
	END

	CLOSE cArtikels;
	DEALLOCATE cArtikels;

END