CREATE PROCEDURE STORED_PROCEDURE_nieuwedeelname
	-- Add the parameters for the stored procedure here
	@tempSportID INT, @tempStudentID  INT, @tempNiveauID INT
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO tblDoetSport(SportID,LidID,NiveauID)
	SELECT A.SportID, B.StudentID, C.NiveauID
	FROM (SELECT SportID FROM tblSport WHERE SportID = @tempSportID) A,
	(SELECT StudentID FROM tblStudent WHERE StudentID = @tempStudentID) B,
	(SELECT NiveauID FROM tblNiveau WHERE NiveauID = @tempNiveauID) C
END