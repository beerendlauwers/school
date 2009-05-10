CREATE PROCEDURE STORED_PROCEDURE_tbldoetsportdatagrid
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT StudentNaam, SportNaam, Niveau
	FROM tblDoetSport inner join tblStudent ON (tblDoetSport.LidID = tblStudent.StudentID) 
	inner join tblSport ON (tblDoetSport.SportID = tblSport.SportID) 
	inner join tblNiveau ON (tblDoetSport.NiveauID = tblNiveau.NiveauID);
  
END