﻿
Partial Class App_Presentation_zoekresultaten
    Inherits System.Web.UI.Page
    Dim artikeldal As New ArtikelDAL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Dim zoekterm As String = Page.Request.Form("ctl00$txtZoek")
            zoekterm = Trim(zoekterm)
            If Session("tag") = zoekterm Then
            Else
                hiddenZoekterm.Value = zoekterm
                lblZoekterm.Text = zoekterm
            End If

            If zoekterm IsNot Nothing And Not zoekterm = "%%" Then
                Session("tag") = zoekterm

            End If
        End If

        If Page.Request.Form("ctl00$lnkZoeken.x") IsNot Nothing Then
            Dim zoekterm As String = Page.Request.Form("ctl00$txtZoek")
            zoekterm = Trim(zoekterm)
            If zoekterm IsNot Nothing And Not zoekterm = "%%" Then
                If Session("tag") = zoekterm Then
                Else
                    hiddenZoekterm.Value = zoekterm
                    lblZoekterm.Text = zoekterm
                End If
                Session("tag") = zoekterm
                JavaScript.ShadowBoxLaderSluiten(Me)
            End If
        End If
        If checkpaginapostback() Then
            Session("tag") = hiddenZoekterm.Value
            Session("tag") = lblZoekterm.Text
            grdResultaten.DataBind()
            JavaScript.ShadowBoxLaderSluiten(Me)
        End If
        If lblZoekterm.Text IsNot String.Empty Then
            Page.Title = "Zoekresultaten voor de term '" + lblZoekterm.Text + "'"
        End If
        If grdResultaten.Rows.Count > 0 Then
            lblSort.Visible = True
        End If

        If Session("tag") IsNot Nothing Then
            Page.Title = String.Concat("Zoekresultaten voor de term '", Session("tag"), "'")

        End If

        Dim control As String = Page.Request.Params.Get("__EVENTTARGET")

        If control IsNot Nothing And Not control = String.Empty Then
            If TryCast(Page.FindControl(control), LinkButton) IsNot Nothing Then
                Dim ctl As LinkButton = Page.FindControl(control)
                grdResultaten.PageIndex = Integer.Parse(ctl.Text) - 1
            End If
        End If

        JavaScript.ShadowBoxLaderTonenBijElkePostback(Me)
    End Sub

    Protected Sub grdResultaten_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResultaten.DataBinding
        GenereerGelokaliseerdeTekst()
    End Sub

    Protected Sub grdResultaten_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResultaten.DataBound
        Dim r As GridViewRow = grdResultaten.BottomPagerRow

        For index As Integer = 0 To grdResultaten.PageCount - 1
            Dim ctl As WebControl = Nothing

            If index = grdResultaten.PageIndex Then
                Dim label As New Label
                label.Text = index + 1
                label.CssClass = "gridview_bignumber"
                label.ID = String.Concat("lblPaginaNummer_" + label.Text)
                ctl = label
            Else
                Dim linkbutton As New LinkButton()
                linkbutton.Text = index + 1
                linkbutton.ID = String.Concat("lnbPaginaNummer_" + linkbutton.Text)
                ctl = linkbutton
            End If

            r.Cells(0).Controls.Add(ctl)
        Next index
    End Sub

    Protected Sub grdResultaten_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdResultaten.RowCommand
        If e.CommandName = "Select" Then
            Dim row As GridViewRow = grdResultaten.Rows(e.CommandArgument)
            Dim tag As String = row.Cells(1).Text
            Dim qst As String = "~/App_Presentation/page.aspx?tag=" + tag
            Response.Redirect(qst)
        ElseIf e.CommandName = "BekijkArtikel" Then

        End If

        JavaScript.ShadowBoxLaderSluiten(Me)

    End Sub

    Protected Sub grdResultaten_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultaten.RowDataBound
        Dim titel As String = e.Row.Cells(0).Text
        If titel = "" And e.Row.Cells.Count > 2 Then
            e.Row.Cells(1).Visible = False
        Else
            Server.HtmlEncode(titel)
            e.Row.Cells(0).Text = Server.HtmlDecode(titel)
        End If

        If e.Row.Cells.Count > 2 Then
            If e.Row.Cells(1).Text = "Tag" Or e.Row.Cells(1).Text = "" Then
            Else
                Dim zoekterm As String = Session("tag")
                Dim artikelTag As String = e.Row.Cells(1).Text

                e.Row.Cells(2).Text = artikeldal.getArtikelTekst(zoekterm, artikelTag)
                Dim tekst As String = e.Row.Cells(2).Text
                Dim tekster As String = Regex.Replace(tekst, "<!--[^.]*", "")
                Dim teksta As String = Regex.Replace(tekster, "<[^>]*>", "")
                Dim tekst1 As String = Regex.Replace(teksta, "<[^>]*", "")
                Dim tekst2 As String = Regex.Replace(tekst1, "<\[^>]*>", "")
                Dim tekstb As String = Regex.Replace(tekst2, "<\[^>]*", "")
                Dim tekstaa As String = Regex.Replace(tekstb, "[^>]*>", "")
                Dim tekst3 As String = Regex.Replace(tekstaa, "[</]", "")
                Dim tekst4 As String = Regex.Replace(tekst3, "[>]", "")
                If tekst4.Length >= 150 Then
                    e.Row.Cells(2).Text = tekst4 + "..."
                Else
                    e.Row.Cells(2).Text = "..." + tekst4 + "..."
                End If
            End If
            e.Row.Cells(1).Visible = False
           
        End If

    End Sub

    Private Sub GenereerGelokaliseerdeTekst()
        Master.CheckVoorTaalWijziging()
        headerArtikels.InnerHtml = Lokalisatie.GetString("ZOEKEN_GEVONDENARTIKELS")
        lblSort.Text = Lokalisatie.GetString("ZOEKEN_UITLEGKOLOMMEN")
        grdResultaten.EmptyDataText = Lokalisatie.GetString("GEENDATAGEVONDEN")
        For Each d As DataControlField In grdResultaten.Columns
            If d.SortExpression = "titel" Then d.HeaderText = Lokalisatie.GetString("ZOEKEN_TITEL")
            If d.SortExpression = "tag" Then d.HeaderText = Lokalisatie.GetString("ZOEKEN_TAG")
        Next
    End Sub
    Public Function checkpaginapostback() As Boolean
        Dim str(100) As String
        For i As Integer = 1 To Page.Request.Form.Count - 1
            str(i) = Page.Request.Form(i)
        Next
        For i As Integer = 0 To str.Length - 1
            Dim strsplit() As String = Split(str(i), "$")
            If strsplit.Length > 3 Then
                Dim strcheck() As String = Split(strsplit(4), "_")
                If strcheck(0) = "lnbPaginaNummer" Or strcheck(0) = "ctl00$ContentPlaceHolder1$GridView3$ctl16$lnbPaginaNummer" Then
                    Return True
                End If
            End If
        Next
    End Function
End Class
