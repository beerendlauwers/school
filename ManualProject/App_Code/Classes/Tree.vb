﻿Imports Microsoft.VisualBasic
Imports Manual
Imports ContentType

Public Class Tree
    Private _naam As String
    Private _taal As Integer
    Private _versie As Integer
    Private _bedrijf As Integer
    Private _rootnode As Node

    Private Shared FTrees As List(Of Tree) = Nothing

    Public Sub New(ByVal naam As String, ByVal taal As Integer, ByVal versie As Integer, ByVal bedrijf As Integer, ByVal rootnode As Node)
        _naam = naam
        _taal = taal
        _versie = versie
        _bedrijf = bedrijf
        _rootnode = rootnode
    End Sub

    Public Property RootNode() As Node
        Get
            Return _rootnode
        End Get
        Set(ByVal node As Node)
            _rootnode = node
        End Set
    End Property

    ''' <summary>
    ''' Doorzoek recursief de tree om een node te vinden op bassi van id en type.
    ''' </summary>
    Public Function DoorzoekTreeVoorNode(ByVal id As Integer, ByVal type As ContentType) As Node

        If (_rootnode.ID = id And _rootnode.Type = ContentType.Categorie) Then
            Return _rootnode
        End If

        Return _rootnode.GetChildBy(id, type)
    End Function

    ''' <summary>
    ''' Haal een tree op op basis van de unieke combinatie van taal, versie en het bedrijf.
    ''' </summary>
    Public Shared Function GetTree(ByVal taal As Integer, ByVal versie As Integer, ByVal bedrijf As Integer) As Tree

        If FTrees Is Nothing Then
            BouwTrees()
        End If

        For Each t As Tree In FTrees
            If (t._taal = taal And t._versie = versie And t._bedrijf = bedrijf) Then
                Return t
            End If
        Next t

        Return Nothing
    End Function

    ''' <summary>
    ''' Haal een tree op op basis van de unieke combinatie van taal, versie en het bedrijf.
    ''' </summary>
    Public Shared Function GetTree(ByRef tree As Tree) As Tree
        For Each t As Tree In FTrees
            If (t._taal = tree._taal And t._versie = tree._versie And t._bedrijf = tree._bedrijf) Then
                Return t
            End If
        Next t

        Return Nothing
    End Function

    ''' <summary>
    ''' Voeg een tree toe.
    ''' </summary>
    Public Shared Sub AddTree(ByVal tree As Tree)
        'Als de treelijst niet bestaat, maken we deze aan
        If (FTrees Is Nothing) Then
            FTrees = New List(Of Tree)
        End If

        'Als de tree niet bestaat, voegen we hem toe
        If (GetTree(tree) Is Nothing) Then
            FTrees.Add(tree)
        End If
    End Sub

    ''' <summary>
    ''' Vraag de verzameling trees op.
    ''' </summary>
    Public Shared Function GetTrees() As List(Of Tree)
        Return FTrees
    End Function

    ''' <summary>
    ''' (Her)bouw de volledige treeverzameling. Dit is zeer intensief voor de server, dus gebruik dit zo weinig mogelijk.
    ''' </summary>
    Public Shared Sub BouwTrees()

        'Als er reeds een verzameling van trees is, maken we deze terug leeg
        If FTrees IsNot Nothing Then
            FTrees = Nothing
        End If

        'Databasefuncties ophalen
        Dim dblink As DatabaseLink = DatabaseLink.GetInstance

        Dim dbcategorie As CategorieDAL = dblink.GetCategorieFuncties
        Dim dbtaal As TaalDAL = dblink.GetTaalFuncties
        Dim dbbedrijf As BedrijfDAL = dblink.GetBedrijfFuncties
        Dim dbversie As VersieDAL = dblink.GetVersieFuncties
        Dim dbartikel As ArtikelDAL = dblink.GetArtikelFuncties

        'Alle tabellen ophalen
        Dim taaldt As tblTaalDataTable = dbtaal.GetAllTaal
        Dim bedrijfdt As tblBedrijfDataTable = dbbedrijf.GetAllBedrijf
        Dim versiedt As tblVersieDataTable = dbversie.GetAllVersie
        Dim categoriedt As tblCategorieDataTable
        Dim artikeldt As tblArtikelDataTable

        For Each taal As tblTaalRow In taaldt
            For Each bedrijf As tblBedrijfRow In bedrijfdt
                For Each versie As tblVersieRow In versiedt

                    categoriedt = dbcategorie.GetAllCategorieBy(taal.TaalID, bedrijf.BedrijfID, versie.VersieID)

                    'Root node ophalen en aanmaken
                    Dim rootnode As Node
                    Dim rootnoderij As tblCategorieRow = categoriedt.Rows(0)
                    If rootnoderij.Categorie = "root_node" Then
                        rootnode = New Node(rootnoderij.CategorieID, ContentType.Categorie, bedrijf.Naam)
                    Else
                        MsgBox("Er is een fout gebeurd tijdens het genereren van de categoriestructuren: De basis (of root node) van de boomstructuur bestaat niet.")
                        Return
                    End If

                    Dim treenaam As String = String.Concat("TREE_", taal.Taal, "_", bedrijf.Naam, "_", versie.Versie)
                    Dim t As New Tree(treenaam, taal.TaalID, versie.VersieID, bedrijf.BedrijfID, rootnode)
                    Dim huidigeParent As Node

                    For Each categorie As tblCategorieRow In categoriedt

                        'De root node heeft geen parent, dus in dit geval kunnen we gewoon verdergaan.
                        If categorie.FK_parent = categorie.CategorieID Then Continue For

                        'Haal de juiste parent op van dit kind.
                        huidigeParent = t.DoorzoekTreeVoorNode(categorie.FK_parent, ContentType.Categorie)

                        'Check of huidigeParent geldig is
                        If (huidigeParent Is Nothing) Then
                            MsgBox(String.Concat("Er is een fout gebeurd tijdens het genereren van de categoriestructuren: De parent met nummer ", categorie.FK_parent, " bestaat niet."))
                            Return
                        End If

                        'Maak een kind aan
                        Dim kind As New Node(categorie.CategorieID, ContentType.Categorie, categorie.Categorie)

                        'Plaats het kind onder de parent
                        huidigeParent.AddChild(kind)

                        'En nu alle artikels die onder deze categorie staan ophalen
                        artikeldt = dbartikel.GetArtikelsByParent(categorie.CategorieID)

                        'De huidige parent is nu het kind
                        huidigeParent = kind
                        For Each artikel As tblArtikelRow In artikeldt
                            Dim art As New Node(artikel.ArtikelID, ContentType.Artikel, artikel.Titel)
                            huidigeParent.AddChild(art)
                        Next artikel

                    Next categorie

                    Tree.AddTree(t)

                Next versie
            Next bedrijf
        Next taal
    End Sub

    ''' <summary>
    ''' Deze functie leest een volledige tree uit en geeft alles weer in unordered list formaat.
    ''' </summary>
    Public Function BeginNieuweLijst(ByVal htmlcode As String, ByVal parent As Node, ByVal diepte As Integer) As String

        Dim huidigediepte As Integer = diepte + 1

        If Not parent.GetChildCount = 0 Then
            If parent.ID = 0 Then
                htmlcode = String.Concat(htmlcode, "<div id=""parent_", parent.ID, """><div>")
            Else
                htmlcode = String.Concat(htmlcode, "<div id=""parent_", parent.ID, """ style=""display:none;""><div>")
            End If
        End If

        For Each kind As Node In parent.GetChildren

            For i = 0 To huidigediepte
                htmlcode = String.Concat(htmlcode, "&nbsp;&nbsp;")
            Next i

            If kind.Type = Categorie Then
                htmlcode = String.Concat(htmlcode, "<a href=""#"" onclick=""Effect.toggle('parent_", kind.ID, "', 'slide', { duration: 0.5 }); veranderDropdown('imgtab_", kind.ID, "'); return false;""><img src=""CSS/images/add.png"" border=""0"" id=""imgtab_", kind.ID, """> ", kind.Titel, "</a><br/>")
            Else
                htmlcode = String.Concat(htmlcode, kind.Titel, "<br/>")
            End If

            If kind.Type = Categorie Then
                htmlcode = BeginNieuweLijst(htmlcode, kind, huidigediepte)
            End If

        Next kind

            If Not parent.GetChildCount = 0 Then
                htmlcode = String.Concat(htmlcode, "</div></div>")
            End If

            Return htmlcode
    End Function

    ''' <summary>
    ''' Voegt een artikel toe aan een categorie. Geeft de string "OK" terug indien gelukt, foutboodschap bij een fout.
    ''' </summary>
    Public Function VoegArtikelToeAanCategorie(ByVal tag As String, ByRef categorieID As Integer) As String

        Dim categorie As Node = DoorzoekTreeVoorNode(categorieID, ContentType.Categorie)

        'Even checken of deze categorie wel bestaat
        If (categorie Is Nothing) Then
            Return String.Concat("De categorie met nummer """, categorieID, """ bestaat niet in de boomstructuur """, Me._naam, """")
        End If

        'Artikel ophalen uit de database
        Dim dt As tblArtikelDataTable = DatabaseLink.GetInstance.GetArtikelFuncties.GetArtikelByTag(tag)

        If dt.Rows.Count > 0 Then
            'Artikel toevoegen aan de categorie
            Dim artikel As New Artikel(dt.Rows(0))
            categorie.AddChild(New Node(artikel))
        Else
            Return String.Concat("Het artikel met de tag """, tag, """ werd niet gevonden in de database.")
        End If

        Return "OK"
    End Function
End Class
