﻿
Partial Class App_Presentation_MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Nakijken of gebruiker deze pagina wel mag zien
        If Session("isIngelogd") Is Nothing Or Session("isIngelogd") = False Then
            Session("vorigePagina") = Page.Request.Url.AbsolutePath
            Response.Redirect("~/Default.aspx")
        End If

        CheckDataStructures()

        PopuleerLinks()
		
		A2.HRef = "~/App_Presentation/VideoUploaden.aspx"
        A3.HRef = "~/App_Presentation/VideoAfspelen.aspx"

        'Taal ophalen
        Dim taalID As Integer = Session("taal")

        'Versie ophalen
        Dim versieID As Integer = Session("versie")

        'Bedrijven ophalen

        'De Appligen-structuur krijgen we altijd te zien
        Dim appligen As Bedrijf = Bedrijf.GetBedrijf("Appligen")

        Dim anderBedrijfID As Integer
        'Kijken of we een geldige bedrijftag hadden binnengekregen
        If Not Session("bedrijf") = -1000 Then
            anderBedrijfID = Session("bedrijf")
            'Even checken of het geldige bedrijf dat we hebben binnengekregen niet nog eens Appligen is
            If appligen.ID = anderBedrijfID Then
                anderBedrijfID = -1000
            End If
        Else
            anderBedrijfID = -1000
        End If

        'Lijststructuren genereren voor bedrijven
        Dim htmlcode As String = String.Empty

        'Appligen-structuur genereren
        htmlcode = Genereerstructuur(taalID, versieID, appligen.ID, htmlcode)

        'Ander bedrijf genereren
        If Not anderBedrijfID = -1000 Then
            htmlcode = Genereerstructuur(taalID, versieID, anderBedrijfID, htmlcode)
        End If

        'HTML-code in de linkerzijbalk plaatsen
        Dim boomdiv As HtmlGenericControl = Me.FindControl("divBoomStructuur")
        boomdiv.InnerHtml = htmlcode

    End Sub

    Protected Sub lnkZoeken_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkZoeken.Click
        Response.Redirect("~/App_Presentation/zoekresultaten.aspx?tag=" + txtZoek.Text + "&bedrijfID=" + "4" + "&versieID=" + "0" + "&taalID=" + "0")
    End Sub

    Private Sub CheckDataStructures()

        If (Tree.GetTrees() Is Nothing) Then
            Tree.BouwTrees()
        End If

        If (Bedrijf.GetBedrijven() Is Nothing) Then
            Bedrijf.BouwBedrijfLijst()
        End If

        If (Taal.GetTalen() Is Nothing) Then
            Taal.BouwTaalLijst()
        End If

        If (Versie.GetVersies() Is Nothing) Then
            Versie.BouwVersieLijst()
        End If

    End Sub

    Private Sub PopuleerLinks()

        ArtikelToevoegen.HRef = "~/App_Presentation/ArtikelToevoegen.aspx"
        ArtikelBewerken.HRef = "~/App_Presentation/ArtikelBewerken.aspx"
        ArtikelVerwijderen.HRef = "~/App_Presentation/ArtikelVerwijderen.aspx"

        If Session("Login") = 0 Then
            'Dim divArtikelbeheer As HtmlGenericControl = Me.FindControl("beheerArtikels")
            'divArtikelbeheer.Visible = False

            'Dim divBeheer As HtmlGenericControl = Me.FindControl("beheer")
            'divBeheer.Visible = False

        End If

    End Sub

    Private Function Genereerstructuur(ByVal taal As Integer, ByVal versie As Integer, ByVal bedrijf As Integer, ByRef html As String) As String

        Dim t As Tree = Tree.GetTree(taal, versie, bedrijf)
        Dim root As Node = t.RootNode

        html = String.Concat(html, "<br/><div>", t.Bedrijf.Naam, "</div>")
        html = t.BeginNieuweLijst(html, root, -1)

        Return html
    End Function
End Class

