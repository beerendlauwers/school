﻿Imports Microsoft.VisualBasic

Public Class Categorie
    Private _CategorieID As Integer
    Private _Categorie As String
    Private _Diepte As Integer
    Private _Hoogte As Integer
    Private _FK_Parent As Integer
    Private _FK_Taal As Integer

  
    Public Property CategorieID() As Integer
        Get
            Return _CategorieID
        End Get
        Set(ByVal value As Integer)
            _CategorieID = value
        End Set
    End Property

    Public Property Categorie() As String
        Get
            Return _Categorie
        End Get
        Set(ByVal value As String)
            _Categorie = value
        End Set
    End Property

    Public Property Diepte() As String
        Get
            Return _Diepte
        End Get
        Set(ByVal value As String)
            _Diepte = value
        End Set
    End Property

    
    Public Property Hoogte() As Integer
        Get
            Return _Hoogte
        End Get
        Set(ByVal value As Integer)
            _Hoogte = value
        End Set
    End Property

    Public Property FK_Parent() As Integer
        Get
            Return _FK_Parent
        End Get
        Set(ByVal value As Integer)
            _FK_Parent = value
        End Set
    End Property

 
    Public Property FK_Taal() As Integer
        Get
            Return _FK_Taal
        End Get
        Set(ByVal value As Integer)
            _FK_Taal = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal CategoryID As Integer, ByVal Categorie As String, ByVal Hoogte As Integer, ByVal Diepte As Integer, ByVal FK_parent As Integer, ByVal FK_Taal As Integer)
        _CategorieID = CategorieID
        _Categorie = Categorie
        _Hoogte = Hoogte
        _Diepte = Diepte
        _FK_Parent = FK_Parent
        _FK_Taal = FK_Taal
    End Sub
End Class