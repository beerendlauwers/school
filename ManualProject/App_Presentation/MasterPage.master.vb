﻿
Partial Class App_Presentation_MasterPage
    Inherits System.Web.UI.MasterPage
    Private taaldal As New TaalDAL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Nakijken of gebruiker deze pagina wel mag zien
        If Session("isIngelogd") Is Nothing Or Session("isIngelogd") = False Then
            Session("vorigePagina") = Page.Request.Url.AbsolutePath
            Response.Redirect("~/Default.aspx")
        End If

        CheckDataStructures()

        PopuleerLinks()

        If MasterBody.Attributes.Item("onload") Is Nothing Then
            MasterBody.Attributes.Add("onload", String.Concat("SetButtonStatus(document.getElementById('", txtZoek.ClientID, "')); "))
        Else
            MasterBody.Attributes.Item("onload") = String.Concat(MasterBody.Attributes.Item("onload"), "SetButtonStatus(document.getElementById('", txtZoek.ClientID, "')); ")
        End If

		A2.HRef = "~/App_Presentation/VideoUploaden.aspx"
        A3.HRef = "~/App_Presentation/VideoAfspelen.aspx"

        'Taal ophalen
        Dim str1(100) As String
        For i As Integer = 0 To Page.Request.Form.Count - 1
            str1(i) = Page.Request.Form(i)
            Dim taal() As String = Split(str1(i), "$")
            If taal.Length > 1 Then
                If taal(1).Length > 3 Then
                    taal(1) = taal(1).Substring(3)
                    If taaldal.getTaalByNaam(taal(1)) IsNot Nothing Then
                        Dim tr As Manual.tblTaalRow
                        tr = taaldal.getTaalByNaam(taal(1))
                        Session("taal") = tr("taalID")
                        Exit For
                    End If
                End If
            End If
        Next

        Dim taalID As Integer = Session("taal")
        If taalID = 0 Then
            lblZoek.Text = "Zoek op: "
        ElseIf taalID = 5 Then
            lblZoek.Text = "Cherchez sur: "
        Else
            lblZoek.Text = "Search: "
        End If

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

        If Session("login") = 0 Then
            livideobewerken.Visible = False
            liVideoVerwijderen.Visible = False
            liBeheer.Visible = False
            liArtikelBeheer.Visible = False
            liArtikelBewerken.Visible = False
        End If

        If Session("login") = 1 Then
            liAanmeld.Visible = False
        End If


        Dim dt As Manual.tblTaalDataTable
        Dim ul As HtmlGenericControl = Me.FindControl("ul")
        Dim str As String = ""
        str = str + "<li style=""float:right;""" + " runat=""server""" + " id=""talenli""" + " visible=""true""" + "><a runat=""server""" + " ><span class=""l""" + "></span><span class=""r""" + "></span><span class=""t""" + ">Talen/Languages</span></a><ul> "
        dt = taaldal.GetAllTaal()

        For i As Integer = 0 To dt.Rows.Count - 1
            str = str + "<li><a id=""ctl00_lnk" + dt.Rows(i)("taal") + """ href=""javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$lnk" + dt.Rows(i)("taal") + "&quot;, &quot;&quot;, false, &quot;&quot;, &quot;Default.aspx&quot;, false, true))""""" + ">" + dt.Rows(i)("taal") + "</a></li>"
        Next
        Dim li As New HtmlGenericControl
        str = str + "</ul></li>"
        li.InnerHtml = str
        ul.Controls.Add(li)


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

    End Sub

    Private Function Genereerstructuur(ByVal taal As Integer, ByVal versie As Integer, ByVal bedrijf As Integer, ByRef html As String) As String

        Dim t As Tree = Tree.GetTree(taal, versie, bedrijf)
        Dim root As Node = t.RootNode

        html = String.Concat(html, "<br/><div>", t.Bedrijf.Naam, "</div>")
        html = t.BeginNieuweLijst(html, root, -1)

        Return html
    End Function
End Class

