﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class AutoOptieDAL
    Private conn As String = ConfigurationManager.ConnectionStrings("frankRemoteDB").ConnectionString()
    Private _myConnection As New SqlConnection(conn)
    Private _f As New DALFunctions

    Public Function GetAllAutoOptie() As Autos.tblAutoOptieDataTable

        Dim myCommand As New SqlCommand("SELECT * FROM tblAutoOptie")
        myCommand.Connection = _myConnection

        Dim dt As New Autos.tblAutoOptieDataTable
        Return CType(_f.ReadDataTable(myCommand, dt), Autos.tblAutoOptieDataTable)
    End Function

    Public Function GetAutoOptieByAutoID(ByVal autoID As Integer) As Autos.tblAutoOptieDataTable

        Dim myCommand As New SqlCommand("SELECT * FROM tblAutoOptie WHERE autoID = @autoID")
        myCommand.Parameters.Add("@autoID", SqlDbType.Int).Value = autoID
        myCommand.Connection = _myConnection

        Dim dt As New Autos.tblAutoOptieDataTable
        Return CType(_f.ReadDataTable(myCommand, dt), Autos.tblAutoOptieDataTable)
    End Function

End Class