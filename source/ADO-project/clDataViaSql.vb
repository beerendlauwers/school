﻿Imports System.Data.SqlClient

Public Class clDataViaSql
    Private mDataSet As DataSet = New DataSet
    Private mDT_Student As DataTable = New DataTable
    Private mDT_Niveau As DataTable = New DataTable
    Private mDT_DoetSport As DataTable = New DataTable
    Private mDT_Sport As DataTable = New DataTable
    Private mDV_Student As DataView = New DataView
    Private mDV_Sport As DataView = New DataView
    Private mDV_Niveau As DataView = New DataView
    Private mDV_DoetSport As DataView = New DataView
    Private mDV_access As DataView = New DataView
    Private mConnectionString As String
    Private mDataSetIsInitialized As Boolean = False
    Private mtblDeelnameIsInitialized As Boolean = False

    Public Property p_dataset() As DataSet
        Get
            Return mDataSet
        End Get
        Set(ByVal value As DataSet)
            mDataSet = value
        End Set
    End Property

    Public Property p_datavStud() As DataView
        Get
            Return mDV_Student
        End Get
        Set(ByVal value As DataView)
            mDV_Student = value
        End Set
    End Property

    Public Property p_datavSport() As DataView
        Get
            Return mDV_Sport
        End Get
        Set(ByVal value As DataView)
            mDV_Sport = value
        End Set
    End Property

    Public Property p_datavDoetSport() As DataView
        Get
            Return mDV_DoetSport
        End Get
        Set(ByVal value As DataView)
            mDV_DoetSport = value
        End Set
    End Property

    Public Property p_datavNiveau() As DataView
        Get
            Return mDV_Niveau
        End Get
        Set(ByVal value As DataView)
            mDV_Niveau = value
        End Set
    End Property

    Public Property p_mConnectionString() As String
        Get
            Return mConnectionString
        End Get
        Set(ByVal value As String)
            mConnectionString = value
        End Set
    End Property

    Public Sub New()
        'mConnectionString = "Data Source=BEERDUDE-46D334\SQLEXPRESS;Initial Catalog=SPORTIMS2A5;Integrated Security=True"
        'Data Source=BEERDUDE-46D334\SQLEXPRESS;Initial Catalog=SPORTIMS2A5;Persist Security Info=True;User ID=tester2;Password=CBA2W-DIS
        'mConnectionString = "Data Source=PC_VAN_FRANK;Initial Catalog=SPORTIMS2A5;Integrated Security=True"
        'dbconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\frank\Documents\ADOdbEmailadressen.mdb"
    End Sub


    Public Function f_HaalDeelnameDataOp() As Boolean

        Dim SQLConnection As New SqlConnection(mConnectionString)

        Try
            SQLConnection.Open()
        Catch ex As SqlException
            MessageBox.Show("Er is een fout gebeurd tijdens het verbinden met de database.")
            SQLConnection.Dispose()
            Return False
        End Try

        If (mtblDeelnameIsInitialized) Then
            If (mDataSet.Tables("tblDeelname").Rows.Count > 0) Then
                mDataSet.Tables("tblDeelname").Clear()
            End If
        End If

        Dim SQLdeelname As String = "STORED_PROCEDURE_tbldoetsportdatagrid"
        Dim deelnameAdapter As SqlDataAdapter = New SqlDataAdapter()
        deelnameAdapter.TableMappings.Add("Table", "tblDeelname")
        Dim deelnameCmd As SqlCommand = New SqlCommand(SQLdeelname, SQLConnection)
        deelnameCmd.CommandType = CommandType.StoredProcedure
        deelnameAdapter.SelectCommand = deelnameCmd
        deelnameAdapter.Fill(mDataSet, "tblDeelname")
        SQLConnection.Close()
        SQLConnection.Dispose()
        deelnameAdapter.Dispose()
        deelnameCmd.Dispose()

        mtblDeelnameIsInitialized = True

        Return True

    End Function

    Public Function f_VerbindMetDatabase() As Boolean

        Dim SQLConnection As New SqlConnection(mConnectionString)

        Try
            SQLConnection.Open()
        Catch ex As SqlException
            MessageBox.Show("Er is een fout gebeurd tijdens het verbinden met de database.")
            SQLConnection.Dispose()
            Return False
        End Try

        Dim SQLstudent As String = "STORED_PROCEDURE_tblstudentinlezen"
        Dim SQLsport As String = "STORED_PROCEDURE_tblsportinlezen"
        Dim SQLniveau As String = "STORED_PROCEDURE_tblniveauinlezen"
        Dim SQLdoetsport As String = "STORED_PROCEDURE_tbldoetsportinlezen"


        Dim studentAdapter As SqlDataAdapter = New SqlDataAdapter()
        Dim sportAdapter As SqlDataAdapter = New SqlDataAdapter()
        Dim niveauAdapter As SqlDataAdapter = New SqlDataAdapter()
        Dim doetsportAdapter As SqlDataAdapter = New SqlDataAdapter()

        studentAdapter.TableMappings.Add("Table", "tblStudent")
        sportAdapter.TableMappings.Add("Table", "tblSport")
        niveauAdapter.TableMappings.Add("Table", "tblNiveau")
        doetsportAdapter.TableMappings.Add("Table", "tblDoetSport")

        Dim studentCmd As SqlCommand = New SqlCommand(SQLstudent, SQLConnection)
        Dim sportCmd As SqlCommand = New SqlCommand(SQLsport, SQLConnection)
        Dim niveauCmd As SqlCommand = New SqlCommand(SQLniveau, SQLConnection)
        Dim doetsportCmd As SqlCommand = New SqlCommand(SQLdoetsport, SQLConnection)

        studentCmd.CommandType = CommandType.StoredProcedure
        sportCmd.CommandType = CommandType.StoredProcedure
        niveauCmd.CommandType = CommandType.StoredProcedure
        doetsportCmd.CommandType = CommandType.StoredProcedure

        studentAdapter.SelectCommand = studentCmd
        sportAdapter.SelectCommand = sportCmd
        niveauAdapter.SelectCommand = niveauCmd
        doetsportAdapter.SelectCommand = doetsportCmd

        studentAdapter.Fill(mDataSet, "tblStudent")
        sportAdapter.Fill(mDataSet, "tblSport")
        niveauAdapter.Fill(mDataSet, "tblNiveau")
        doetsportAdapter.Fill(mDataSet, "tblDoetSport")

        SQLConnection.Close()
        SQLConnection.Dispose()

        mDT_Student = mDataSet.Tables("tblStudent")
        mDT_Sport = mDataSet.Tables("tblSport")
        mDT_Niveau = mDataSet.Tables("tblNiveau")
        mDT_DoetSport = mDataSet.Tables("tblDoetSport")

        mDV_Student = mDT_Student.DefaultView
        mDV_Sport = mDT_Sport.DefaultView
        mDV_Niveau = mDT_Niveau.DefaultView
        mDV_DoetSport = mDT_DoetSport.DefaultView

        mDV_Sport.Sort = "SportNaam"
        mDV_Niveau.Sort = "Niveau"
        mDV_DoetSport.Sort = "DoetSportID"

        ' Create a DataRelation to link the two tables
        ' based on the SupplierID.
        Dim parentColumn As DataColumn = _
           mDataSet.Tables("tblNiveau").Columns("NiveauID")
        Dim childColumn As DataColumn = _
           mDataSet.Tables("tblDoetSport").Columns("NiveauID")
        Dim relation As DataRelation = New  _
           System.Data.DataRelation("Niveau_DoetSport", _
           parentColumn, childColumn)
        mDataSet.Relations.Add(relation)


        studentAdapter.Dispose()
        sportAdapter.Dispose()
        niveauAdapter.Dispose()
        doetsportAdapter.Dispose()

        studentCmd.Dispose()
        sportCmd.Dispose()
        niveauCmd.Dispose()
        doetsportCmd.Dispose()

        mDataSetIsInitialized = True

        Return True

    End Function

    Public Sub s_FilterStudentOp(ByVal naamfilter As String)
        If mDataSetIsInitialized Then
            If (naamfilter = "Naam") Then
                mDV_Student.Sort = "StudentNaam"
            Else
                mDV_Student.Sort = "StudentVoornaam"
            End If
        End If
    End Sub

    Public Function f_ToonStudentDetails(ByVal i_id As Int16) As DataRowView
        Dim dataview As DataView
        Dim anyrow As DataRowView
        dataview = New DataView
        With dataview
            .Table = mDataSet.Tables("tblStudent")
            .AllowDelete = True
            .AllowEdit = True
            .AllowNew = True
            .RowFilter = "StudentID = " & i_id
        End With

        anyrow = dataview.Item(0)
        dataview.Dispose()
        Return anyrow
    End Function

    Public Function f_NieuweStudent(ByVal strNaam As String, ByVal strVoornaam As String, ByVal strGSM As String, ByVal strSchoolmail As String, ByVal strPrivemail As String, ByVal datGebDat As Date, ByVal strFinRek As String) As Int16
        Dim iNewID As Int16

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)

        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_nieuwestudent", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempNaam", SqlDbType.NVarChar, 50)).Value = strNaam
        AdoCommand.Parameters("@tempNaam").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempVoornaam", SqlDbType.NVarChar, 50)).Value = strVoornaam
        AdoCommand.Parameters("@tempVoornaam").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempGSM", SqlDbType.NVarChar, 50)).Value = strGSM
        AdoCommand.Parameters("@tempGSM").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempSchoolmail", SqlDbType.NVarChar, 50)).Value = strSchoolmail
        AdoCommand.Parameters("@tempSchoolmail").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempPrivemail", SqlDbType.NVarChar, 50)).Value = strPrivemail
        AdoCommand.Parameters("@tempPrivemail").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempGebDat", SqlDbType.DateTime, 50)).Value = datGebDat
        AdoCommand.Parameters("@tempGebDat").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempFinRek", SqlDbType.NVarChar, 50)).Value = strFinRek
        AdoCommand.Parameters("@tempFinRek").Direction = ParameterDirection.Input

        'ID meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempStudentID", SqlDbType.Int, iNewID))
        'Welk type input is dit (vanuit het zicht van de database) ?
        AdoCommand.Parameters("@tempStudentID").Direction = ParameterDirection.Output

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        AdoCommand.ExecuteNonQuery()

        'Het ADoCommand geeft een array door (en terug), en we willen
        'de ID van de nieuwe employee te pakken krijgen
        iNewID = AdoCommand.Parameters(7).Value

        'DB-connectie sluiten
        MyDBconnection.Close()


        'We hebben alles in de echte database gestoken,
        'nu moeten we ook de nagebootste database in het
        'RAM-geheugen updaten.

        'DataRow klaarmaken en invullen met data.
        Dim temp_datarow As DataRow = mDT_Student.NewRow
        temp_datarow("StudentNaam") = strNaam
        temp_datarow("StudentVoornaam") = strVoornaam
        temp_datarow("StudentGSM") = strGSM
        temp_datarow("StudentSchoolEmail") = strSchoolmail
        temp_datarow("StudentPriveEmail") = strPrivemail
        temp_datarow("StudentGebDat") = datGebDat
        temp_datarow("StudentFinRek") = strFinRek
        temp_datarow("StudentID") = iNewID
        'DataTable updaten.
        mDT_Student.Rows.Add(temp_datarow)

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()
        temp_datarow = Nothing

        Return iNewID
    End Function

    Public Function f_VerwijderStudent(ByVal ID_ForDataBase As Int16, ByVal ID_ForComboBox As Int16) As Boolean
        Dim bGelukt As Boolean = True

        'Echte database updaten:

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)
        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_verwijderstudent", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameter ID_ForDataBase meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempStudentID", SqlDbType.Int, 4)).Value = ID_ForDataBase
        AdoCommand.Parameters("@tempStudentID").Direction = ParameterDirection.Input

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        Try
            AdoCommand.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Deze student kon niet verwijderd worden.")
            bGelukt = False
        End Try

        'DB-connectie sluiten
        MyDBconnection.Close()

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()

        If (bGelukt) Then
            'Database in RAM updaten:
            mDV_Student.Delete(ID_ForComboBox)
        End If

        Return bGelukt
    End Function


    Public Function f_UpdateStudent(ByVal strNaam As String, ByVal strVoornaam As String, ByVal strGSM As String, ByVal strSchoolmail As String, ByVal strPrivemail As String, ByVal datGebDat As Date, ByVal strFinRek As String, ByVal ID_ForDataBase As Int16, ByVal ID_ForComboBox As Int16) As Boolean
        Dim bGelukt As Boolean = True

        'Echte database updaten:

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)
        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_updatestudent", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven

        AdoCommand.Parameters.Add(New SqlParameter("@tempNaam", SqlDbType.NVarChar, 50)).Value = strNaam
        AdoCommand.Parameters("@tempNaam").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempVoornaam", SqlDbType.NVarChar, 50)).Value = strVoornaam
        AdoCommand.Parameters("@tempVoornaam").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempGSM", SqlDbType.NVarChar, 50)).Value = strGSM
        AdoCommand.Parameters("@tempGSM").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempSchoolmail", SqlDbType.NVarChar, 50)).Value = strSchoolmail
        AdoCommand.Parameters("@tempSchoolmail").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempPrivemail", SqlDbType.NVarChar, 50)).Value = strPrivemail
        AdoCommand.Parameters("@tempPrivemail").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempGebDat", SqlDbType.DateTime, 50)).Value = datGebDat
        AdoCommand.Parameters("@tempGebDat").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempFinRek", SqlDbType.NVarChar, 50)).Value = strFinRek
        AdoCommand.Parameters("@tempFinRek").Direction = ParameterDirection.Input

        'ID meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempStudentID", SqlDbType.Int, 4)).Value = ID_ForDataBase
        'Welk type input is dit (vanuit het zicht van de database) ?
        AdoCommand.Parameters("@tempStudentID").Direction = ParameterDirection.Input

        'DB-connectie openen
        MyDBconnection.Open()

        'ADO-Command uitvoeren
        Try
            AdoCommand.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Deze student kon niet gewijzigd worden.")
            bGelukt = False
        End Try

        'DB-connectie sluiten
        MyDBconnection.Close()

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()

        If (bGelukt) Then
            'Database in RAM updaten:
            'DataRow klaarmaken en invullen met data.
            'Opgelet: temp_datarow moet als een array omdat mogelijk meerdere records zullen gefilterd worden.
            Dim temp_datarow() As DataRow
            temp_datarow = mDataSet.Tables("tblStudent").Select("StudentID = " & ID_ForDataBase)
            temp_datarow(0)("StudentNaam") = strNaam
            temp_datarow(0)("StudentVoornaam") = strVoornaam
            temp_datarow(0)("StudentGSM") = strGSM
            temp_datarow(0)("StudentSchoolEmail") = strSchoolmail
            temp_datarow(0)("StudentPriveEmail") = strPrivemail
            temp_datarow(0)("StudentGebDat") = datGebDat
            temp_datarow(0)("StudentFinRek") = strFinRek
        End If

        Return bGelukt
    End Function


    Public Function f_ToonSportDetails(ByVal i_id As Int16) As DataRowView
        Dim dataview As DataView
        Dim anyrow As DataRowView
        dataview = New DataView
        With dataview
            .Table = mDataSet.Tables("tblSport")
            .AllowDelete = True
            .AllowEdit = True
            .AllowNew = True
            .RowFilter = "SportID = " & i_id
        End With

        anyrow = dataview.Item(0)
        dataview.Dispose()
        Return anyrow
    End Function

    Public Function f_NieuweSport(ByVal strNaam As String) As Int16
        Dim iNewID As Int16

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)

        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_nieuwesport", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempSport", SqlDbType.NVarChar, 50)).Value = strNaam
        AdoCommand.Parameters("@tempSport").Direction = ParameterDirection.Input

        'ID meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempSportID", SqlDbType.Int, iNewID))
        'Welk type input is dit (vanuit het zicht van de database) ?
        AdoCommand.Parameters("@tempSportID").Direction = ParameterDirection.Output

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        AdoCommand.ExecuteNonQuery()

        'Het ADoCommand geeft een array door (en terug), en we willen
        'de ID van de nieuwe employee te pakken krijgen
        iNewID = AdoCommand.Parameters(1).Value

        'DB-connectie sluiten
        MyDBconnection.Close()


        'We hebben alles in de echte database gestoken,
        'nu moeten we ook de nagebootste database in het
        'RAM-geheugen updaten.

        'DataRow klaarmaken en invullen met data.
        Dim temp_datarow As DataRow = mDT_Sport.NewRow
        temp_datarow("SportNaam") = strNaam
        temp_datarow("SportID") = iNewID
        'DataTable updaten.
        mDT_Sport.Rows.Add(temp_datarow)

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()
        temp_datarow = Nothing

        Return iNewID
    End Function

    Public Function f_VerwijderSport(ByVal ID_ForDataBase As Int16, ByVal ID_ForComboBox As Int16) As Boolean
        Dim bGelukt As Boolean = True

        'Echte database updaten:

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)
        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_verwijdersport", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameter ID_ForDataBase meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempSportID", SqlDbType.Int, 4)).Value = ID_ForDataBase
        AdoCommand.Parameters("@tempSportID").Direction = ParameterDirection.Input

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        Try
            AdoCommand.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Deze sport kon niet verwijderd worden.")
            bGelukt = False
        End Try

        'DB-connectie sluiten
        MyDBconnection.Close()

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()

        If (bGelukt) Then
            'Database in RAM updaten:
            mDV_Sport.Delete(ID_ForComboBox)
        End If

        Return bGelukt
    End Function


    Public Function f_UpdateSport(ByVal strNaam As String, ByVal ID_ForDataBase As Int16, ByVal ID_ForComboBox As Int16) As Boolean
        Dim bGelukt As Boolean = True

        'Echte database updaten:

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)
        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_updatesport", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven

        AdoCommand.Parameters.Add(New SqlParameter("@tempSport ", SqlDbType.NVarChar, 50)).Value = strNaam
        AdoCommand.Parameters("@tempSport ").Direction = ParameterDirection.Input

        'ID meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempSportID ", SqlDbType.Int, 4)).Value = ID_ForDataBase
        'Welk type input is dit (vanuit het zicht van de database) ?
        AdoCommand.Parameters("@tempSportID ").Direction = ParameterDirection.Input

        'DB-connectie openen
        MyDBconnection.Open()

        'ADO-Command uitvoeren
        Try
            AdoCommand.ExecuteNonQuery()
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Deze sport kon niet gewijzigd worden.")
            bGelukt = False
        End Try

        'DB-connectie sluiten
        MyDBconnection.Close()

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()

        If (bGelukt) Then
            'Database in RAM updaten:
            'DataRow klaarmaken en invullen met data.
            'Opgelet: temp_datarow moet als een array omdat mogelijk meerdere records zullen gefilterd worden.
            Dim temp_datarow() As DataRow
            temp_datarow = mDataSet.Tables("tblSport").Select("SportID = " & ID_ForDataBase)
            temp_datarow(0)("SportNaam") = strNaam
        End If

        Return bGelukt
    End Function

    Public Function f_NieuwNiveau(ByVal strNaam As String) As Int16
        Dim iNewID As Int16

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)

        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_nieuwniveau", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempNiveau", SqlDbType.NVarChar, 50)).Value = strNaam
        AdoCommand.Parameters("@tempNiveau").Direction = ParameterDirection.Input

        'ID meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempNiveauID", SqlDbType.Int, iNewID))
        'Welk type input is dit (vanuit het zicht van de database) ?
        AdoCommand.Parameters("@tempNiveauID").Direction = ParameterDirection.Output

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        AdoCommand.ExecuteNonQuery()

        'Het ADoCommand geeft een array door (en terug), en we willen
        'de ID van de nieuwe employee te pakken krijgen
        iNewID = AdoCommand.Parameters(1).Value

        'DB-connectie sluiten
        MyDBconnection.Close()


        'We hebben alles in de echte database gestoken,
        'nu moeten we ook de nagebootste database in het
        'RAM-geheugen updaten.

        'DataRow klaarmaken en invullen met data.
        Dim temp_datarow As DataRow = mDT_Niveau.NewRow
        temp_datarow("Niveau") = strNaam
        temp_datarow("NiveauID") = iNewID
        'DataTable updaten.
        mDT_Niveau.Rows.Add(temp_datarow)

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()
        temp_datarow = Nothing

        Return iNewID
    End Function

    Public Function f_NieuweDeelname(ByVal ID_DB_StudentID As Int16, ByVal ID_DB_SportID As Int16, ByVal ID_DB_NiveauID As Int16)
        Dim iNewID As Int16

        ' SQL-connectie openen
        Dim MyDBconnection As SqlConnection = New SqlConnection(mConnectionString)

        ' Een object van de SqlCommand-klasse maken
        Dim AdoCommand As SqlCommand = New SqlCommand("STORED_PROCEDURE_nieuwedeelname", MyDBconnection)
        ' Aan het object vertellen welk type commando het is
        AdoCommand.CommandType = CommandType.StoredProcedure

        ' De parameters meegeven
        AdoCommand.Parameters.Add(New SqlParameter("@tempStudentID", SqlDbType.Int, 4)).Value = ID_DB_StudentID
        AdoCommand.Parameters("@tempStudentID").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempSportID", SqlDbType.Int, 4)).Value = ID_DB_SportID
        AdoCommand.Parameters("@tempSportID").Direction = ParameterDirection.Input
        AdoCommand.Parameters.Add(New SqlParameter("@tempNiveauID", SqlDbType.Int, 4)).Value = ID_DB_NiveauID
        AdoCommand.Parameters("@tempNiveauID").Direction = ParameterDirection.Input

        'DB-connectie openen
        MyDBconnection.Open()
        'ADO-Command uitvoeren
        AdoCommand.ExecuteNonQuery()

        'Het ADoCommand geeft een array door (en terug), en we willen
        'de ID van de nieuwe employee te pakken krijgen
        'iNewID = AdoCommand.Parameters(1).Value

        'DB-connectie sluiten
        MyDBconnection.Close()


        'We hebben alles in de echte database gestoken,
        'nu moeten we ook de nagebootste database in het
        'RAM-geheugen updaten.

        'DataRow klaarmaken en invullen met data.
        Dim temp_datarow As DataRow = mDT_DoetSport.NewRow
        temp_datarow("SportID") = ID_DB_SportID
        temp_datarow("LidID") = ID_DB_StudentID
        temp_datarow("NiveauID") = ID_DB_NiveauID
        'DataTable updaten.
        mDT_DoetSport.Rows.Add(temp_datarow)

        'Gebruikt geheugen vrijmaken.
        AdoCommand.Dispose()
        MyDBconnection.Dispose()
        temp_datarow = Nothing

        Return iNewID
    End Function

    Public Function f_TestSQL(ByVal SQLServer As String, ByVal SQLDatabase As String, ByVal SQLGebruiker As String, ByVal SQLPaswoord As String, ByVal UsesIntegratedSecurity As Boolean) As Boolean
        Dim connectiestring As String

        connectiestring = String.Concat("Data Source=", SQLServer, ";Initial Catalog=", SQLDatabase)
        If (UsesIntegratedSecurity) Then
            connectiestring = String.Concat(connectiestring, ";Integrated Security=True")
        Else
            connectiestring = String.Concat(connectiestring, ";Persist Security Info=True;User ID=", SQLGebruiker, ";Password=", SQLPaswoord)
        End If

        Dim SQLConnection As New SqlConnection(connectiestring)

        Try
            SQLConnection.Open()

        Catch ex As SqlException
            SQLConnection.Dispose()
            Return False
        End Try

        Dim SQLTestString1 As String = String.Concat("SELECT TOP 5 * INTO tbl", SQLGebruiker, " FROM tblStudent")
        Dim SQLTestString2 As String = String.Concat("DROP TABLE tbl", SQLGebruiker)

        Dim SQLTest1 As SqlCommand = New SqlCommand(SQLTestString1, SQLConnection)
        Dim SQLTest2 As SqlCommand = New SqlCommand(SQLTestString2, SQLConnection)

        Try
            SQLTest1.ExecuteNonQuery()
            SQLTest2.ExecuteNonQuery()
        Catch ex As SqlException
            SQLConnection.Close()
            SQLConnection.Dispose()
            Return False
        End Try

        SQLConnection.Close()
        SQLConnection.Dispose()

        Return True
    End Function
End Class
