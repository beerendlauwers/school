USE [Reference_manual]
GO
/****** Object:  Trigger [dbo].[OnDeleteTaal]    Script Date: 04/27/2010 16:12:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[OnDeleteTaal] 
   ON  [dbo].[tblTaal]
   AFTER DELETE
AS
DECLARE @Taal Varchar(50)
DECLARE @Var Varchar(200) 
DECLARE @VarD Varchar(200)
BEGIN
	SET NOCOUNT ON;
SET @Taal = (select taal from DELETED)
declare @table_name nvarchar(256)
declare @col_name nvarchar(256)
set @table_name = 'tblVglTaal'
set @col_name = @Taal



SET @VarD = (select  d.name from sys.tables t join
    sys.default_constraints d
        on d.parent_object_id = t.object_id
    join
    sys.columns c
        on c.object_id = t.object_id
        and c.column_id = d.parent_column_id
where t.name = @table_name
and c.name = @col_name)
IF @VarD IS NOT NULL
BEGIN
SET @VarD = 'ALTER TABLE tblVglTaal DROP ' + @VarD + ';'
exec(@VarD)
END
SET @Var = 'ALTER TABLE tblVglTaal DROP COLUMN ' + @Taal + ';'
exec(@Var)
END
