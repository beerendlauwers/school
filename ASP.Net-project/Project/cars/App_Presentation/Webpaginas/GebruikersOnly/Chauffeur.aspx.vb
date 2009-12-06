﻿
Partial Class App_Presentation_Chauffeur
    Inherits System.Web.UI.Page

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        Dim dt As New Klanten.tblChauffeurDataTable
        Dim c As Klanten.tblChauffeurRow = dt.NewRow
        'Dim username As String
        c.chauffeurNaam = txtNaam.Text
        c.chauffeurVoornaam = txtVoornaam.Text
        c.chauffeurRijbewijs = txtRijbewijs.Text
        c.userID = New Guid(Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString())
        Dim chauffeurbll As New ChauffeurBLL
        chauffeurbll.AddChauffeur(c)

        UpdateChauffeurDropdowns()

        ClearTextBoxes()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            UpdateChauffeurDropdowns()

        End If

    End Sub

    Protected Sub ddlChauffeurWijzig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlChauffeurWijzig.SelectedIndexChanged
        Dim chauffeurid As Integer

        If Not ddlChauffeurWijzig.SelectedValue = "Kies chauffeur" Then
            chauffeurid = ddlChauffeurWijzig.SelectedValue
            Dim bllChauffeur As New ChauffeurBLL
            Dim dt As Klanten.tblChauffeurDataTable
            dt = bllChauffeur.GetChauffeurByChauffeurID(chauffeurid)

            txtNaamup.Text = dt.Rows(0)("chauffeurNaam")
            txtVoornaamup.Text = dt.Rows(0)("chauffeurVoornaam")
            txtRijbewijsup.Text = dt.Rows(0)("chauffeurRijbewijs")
        Else
            txtNaamup.Text = String.Empty
            txtVoornaamup.Text = String.Empty
            txtRijbewijsup.Text = String.Empty
        End If

    End Sub

    Protected Sub btnWijzig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWijzig.Click
        Dim cbll As New ChauffeurBLL
        Dim strID As String
        strID = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString()
        Dim UserID As New Guid(strID)
        Dim dt As New Klanten.tblChauffeurDataTable
        Dim dr As Klanten.tblChauffeurRow = dt.NewRow

        dr.chauffeurNaam = txtNaamup.Text
        dr.chauffeurVoornaam = txtVoornaamup.Text
        dr.chauffeurRijbewijs = txtRijbewijsup.Text
        dr.chauffeurID = ddlChauffeurWijzig.SelectedValue

        cbll.UpdateChauffeur(dr)

        UpdateChauffeurDropdowns()

        ClearTextBoxes()

        ddlChauffeurWijzig.SelectedValue = "Kies chauffeur"
    End Sub

    Protected Sub btnVerwijder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerwijder.Click
        Dim cbll As New ChauffeurBLL
        Dim chauffeurid As New Integer
        chauffeurid = ddlChauffeurdelete.SelectedValue
        cbll.DeleteChauffeurByID(chauffeurid)

        UpdateChauffeurDropdowns()

        ClearTextBoxes()

    End Sub

    Private Sub UpdateChauffeurDropdowns()

        ddlChauffeurWijzig.Items.Clear()
        ddlChauffeurdelete.Items.Clear()

        Dim chauffeurbll As New ChauffeurBLL

        Dim strID As String
        strID = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString()
        Dim UserID As New Guid(strID)
        Dim dt As Klanten.tblChauffeurDataTable = chauffeurbll.GetChauffeurByUserID(UserID)
        Dim list As New ListItem
        ddlChauffeurWijzig.Items.Add(New ListItem("Kies chauffeur", "Kies chauffeur"))
        ddlChauffeurdelete.Items.Add(New ListItem("Kies chauffeur", "Kies chauffeur"))
        For i As Integer = 0 To dt.Rows.Count - 1
            ddlChauffeurWijzig.Items.Add(New ListItem((dt.Rows(i)("chauffeurNaam")), (dt.Rows(i)("chauffeurID"))))
            ddlChauffeurdelete.Items.Add(New ListItem((dt.Rows(i)("chauffeurNaam")), (dt.Rows(i)("chauffeurID"))))
        Next
    End Sub

    Private Sub ClearTextBoxes()
        txtNaamup.Text = String.Empty
        txtVoornaamup.Text = String.Empty
        txtRijbewijsup.Text = String.Empty

        txtNaam.Text = String.Empty
        txtVoornaam.Text = String.Empty
        txtRijbewijs.Text = String.Empty
    End Sub
End Class
