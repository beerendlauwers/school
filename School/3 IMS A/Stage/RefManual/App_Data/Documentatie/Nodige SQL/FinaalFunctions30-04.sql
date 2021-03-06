SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getTaalTag]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[getTaalTag]
(	
	@String NVarchar(1000)
)
RETURNS NVarchar(1000)
AS
BEGIN
DECLARE @NextString NVARCHAR(1000)
DECLARE @Pos INT
DECLARE @NextPos INT
DECLARE @Delimiter NVARCHAR(1000)
DECLARE @Tag NVarchar(1000)

BEGIN
	SET @Delimiter = ''_''
	SET @String = @String + @Delimiter
	SET @Pos = charindex(@Delimiter,@String)
	WHILE (@pos <> 0)
		BEGIN
		SET @NextString = substring(@String,1,@Pos - 1)
		IF len(@Nextstring)>3
		BEGIN	
		SET @TAG = @Nextstring
		END 
		SET @String = substring(@String,@pos+1,len(@String))
		SET @pos = charindex(@Delimiter,@String)
		
		END
	END
RETURN @TAG
END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitTekst]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[SplitTekst](@data NVARCHAR(MAX), @delimiter NVARCHAR(5))
RETURNS @tValues TABLE (id int IDENTITY (1, 1), data NVARCHAR(max))
AS
BEGIN
    DECLARE @textXML XML;
    SELECT    @textXML = CAST(''<d>'' + REPLACE(@data, @delimiter, ''</d><d>'') + ''</d>'' AS XML);

	INSERT INTO @tValues(data)
	SELECT 
		t.value(''.'',''varchar(MAX)'') AS data
	FROM @textXML.nodes(''/d'') AS a(t)


    RETURN
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getModule]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[getModule] 
(	
	@String NVarchar(1000)
)
RETURNS NVarchar(1000)
AS
BEGIN
DECLARE @NextString VARCHAR(1000)
DECLARE @Pos INT
DECLARE @NextPos INT
DECLARE @Delimiter VARCHAR(1000)
DECLARE @Tag Varchar(1000)
DECLARE @Teller int
DECLARE @whatiwant Varchar(1000)
BEGIN
SET @whatiwant = ''''
	SET @Teller = 0
	SET @Delimiter = ''_''
	SET @String = @String + @Delimiter
	SET @Pos = charindex(@Delimiter,@String)
	WHILE (@pos <> 0)
		BEGIN
		SET @NextString = substring(@String,1,@Pos - 1)
		SET @TAG = @Nextstring
		SET @String = substring(@String,@pos+1,len(@String))
		IF @Teller = 3
		Begin
		SET @whatiwant = @Tag
		
		END
		SET @pos = charindex(@Delimiter,@String)
		SET @Teller = @Teller + 1
		END
	END
	--SET @whatiwant = substring(@whatiwant,2,len(@whatiwant))
RETURN @whatiwant
END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getSimpleTag]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[getSimpleTag] 
(	
	@String NVarchar(1000)
)
RETURNS NVarchar(1000)
AS
BEGIN
DECLARE @NextString VARCHAR(1000)
DECLARE @Pos INT
DECLARE @NextPos INT
DECLARE @Delimiter VARCHAR(1000)
DECLARE @Tag Varchar(1000)
DECLARE @Teller int
DECLARE @whatiwant Varchar(1000)
BEGIN
SET @whatiwant = ''''
	SET @Teller = 0
	SET @Delimiter = ''_''
	SET @String = @String + @Delimiter
	SET @Pos = charindex(@Delimiter,@String)
	WHILE (@pos <> 0)
		BEGIN
		SET @NextString = substring(@String,1,@Pos - 1)
		SET @TAG = @Nextstring
		SET @String = substring(@String,@pos+1,len(@String))
		IF @Teller > 2
		Begin
		SET @whatiwant = @whatiwant + ''_'' + @Tag
		
		END
		SET @pos = charindex(@Delimiter,@String)
		SET @Teller = @Teller + 1
		END
	END
	SET @whatiwant = substring(@whatiwant,2,len(@whatiwant))
RETURN @whatiwant
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[Split](
	@s NVARCHAR(MAX),
	@delimiter VARCHAR(1)
	)

RETURNS @tValues TABLE(IDAux INT)

AS
BEGIN

DECLARE @xml XML
SET @xml = N''<root><r>'' + replace(@s,@delimiter,''</r><r>'') + ''</r></root>''

INSERT INTO @tValues
SELECT
  t.value(''.'',''varchar(5)'') AS [delimited items]
FROM @xml.nodes(''//root/r'') AS a(t)

RETURN

END

' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getTitelMetTag]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[getTitelMetTag] 
(
	@Tag varchar(1000)
)
RETURNS Varchar(1000)
AS

BEGIN
DECLARE @TaalID int
DECLARE @VersieID int
DECLARE @BedrijfID int
DECLARE @TITEL AS VARCHAR(1000)
DECLARE cBedrijf cursor for select BedrijfID from tblBedrijf

open cBedrijf;
FETCH NEXT FROM cBedrijf into @BedrijfID
WHILE @@FETCH_STatus = 0
BEGIN
DECLARE cVersie cursor for select VersieID from tblVersie
open cVersie
FETCH NEXT FROM cVersie into @VersieID
WHILE @@FETCH_STatus = 0 
BEGIN
DECLARE c1 cursor for select TaalID from tblTaal
	open c1;
	FETCH NEXT FROM c1 INTO @TaalID
	WHILE @@FETCH_STATUS = 0
	BEGIN
	SET @TITEL = (SELECT TOP 1 titel FROM tblArtikel where dbo.getSimpleTag(tag) = @Tag AND FK_Taal = @TaalID AND FK_Versie=@VersieID and FK_Bedrijf=@BedrijfID)
	IF @TITEL IS NOT NULL
	BREAK
	FETCH NEXT FROM c1 INTO @TaalID
	END

close c1;
DEALLOCATE c1;
IF @TITEL IS NOT NULL
	BREAK
FETCH NEXT FROM cVersie into @VersieID
END
close cVersie
DEALLOCATE cVersie
IF @TITEL IS NOT NULL
	BREAK
FETCH NEXT FROM cBedrijf into @BedrijfID
END
close cBedrijf
DEALLOCATE cBedrijf
return @Titel
END



' 
END

