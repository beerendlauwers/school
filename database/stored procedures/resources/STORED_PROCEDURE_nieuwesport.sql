CREATE PROCEDURE STORED_PROCEDURE_nieuwesport
	@tempSport VARCHAR(50), @tempSportID INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO tblSport(SportNaam) VALUES(@tempSport)
	SELECT @@IDENTITY AS [@@IDENTITY]
	SET @tempSportID = @@IDENTITY
END
