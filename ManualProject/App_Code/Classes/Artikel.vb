﻿Imports Microsoft.VisualBasic

Public Class Artikel
    Private _ID As Integer
    Private _titel As String
    Private _categorie As Integer
    Private _versie As Integer
    Private _taal As Integer
    Private _bedrijf As Integer
    Private _tekst As String
    Private _tag As String
    Private _isfinal As Integer

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Public Property Titel() As String
        Get
            Return _titel
        End Get
        Set(ByVal value As String)
            _titel = value
        End Set
    End Property

    Public Property Categorie() As Integer
        Get
            Return _categorie
        End Get
        Set(ByVal value As Integer)
            _categorie = value
        End Set
    End Property

    Public Property Versie() As Integer
        Get
            Return _versie
        End Get
        Set(ByVal value As Integer)
            _versie = value
        End Set
    End Property

    Public Property Bedrijf() As Integer
        Get
            Return _bedrijf
        End Get
        Set(ByVal value As Integer)
            _bedrijf = value
        End Set
    End Property

    Public Property Tekst() As String
        Get
            Return _tekst
        End Get
        Set(ByVal value As String)
            _tekst = value
        End Set
    End Property

    Public Property Tag() As String
        Get
            Return _tag
        End Get
        Set(ByVal value As String)
            _tag = value
        End Set
    End Property

    Public Property IsFinal() As Integer
        Get
            Return _isfinal
        End Get
        Set(ByVal value As Integer)
            _isfinal = value
        End Set
    End Property
    Public Property Taal() As Integer
        Get
            Return _taal
        End Get
        Set(ByVal value As Integer)
            _taal = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal titel As String, ByVal categorie As Integer, ByVal versie As Integer, ByVal bedrijf As Integer, ByVal tekst As String, ByVal tag As String, ByVal isfinal As Integer)
        _ID = id
        _titel = titel
        _categorie = categorie
        _versie = versie
        _bedrijf = bedrijf
        _tekst = tekst
        _tag = tag
        _isfinal = isfinal
        _taal = Taal
    End Sub

    Public Sub New(ByRef row As Manual.tblArtikelRow)
        _ID = row.ArtikelID
        _titel = row.Titel
        _categorie = row.FK_Categorie
        _versie = row.FK_Versie
        _bedrijf = row.FK_Bedrijf
        _tekst = row.Tekst
        _tag = row.Tag
        _isfinal = row.Is_final
    End Sub
End Class