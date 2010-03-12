﻿
Partial Class App_Presentation_invoerenTest
    Inherits System.Web.UI.Page

    Private artikel As Manual.tblArtikelRow
    Private adapter As New ManualTableAdapters.tblArtikelTableAdapter

    Protected Sub btnVoegtoe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoegtoe.Click
        Dim titel As String
        Dim tekst As String
        Dim tag As String
        Dim FK_categorie As Integer
        Dim FK_taal As Integer
        Dim FK_versie As Integer
        Dim finaal As Integer
        Dim FK_Bedrijf As Integer
        Dim res As Boolean
        tekst = Editor1.Content
        tag = txtTag.Text
        titel = txtTitel.Text
        FK_versie = Integer.Parse(txtVersie.Text)
        FK_Bedrijf = ddlBedrijf.SelectedValue
        FK_categorie = ddlCategorie.SelectedValue
        FK_taal = ddlTaal.SelectedValue
        If ckbFinaal.Checked = True Then
            finaal = 1
        Else
            finaal = 0
        End If


        res = adapter.Insert(titel, FK_categorie, FK_taal, FK_Bedrijf, FK_versie, tekst, tag, finaal)
        If res = True Then
            lblresultaat.Text = "Gelukt."
        Else
            lblresultaat.Text = "Toevoegen mislukt."
        End If

    End Sub

    'Protected Sub btnTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTest.Click
    '   lblTest.Text = Editor1.Content

    'End Sub
End Class
