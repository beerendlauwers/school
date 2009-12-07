﻿Imports Microsoft.VisualBasic

Public Class AutoBLL
    Private _adapterAuto As New AutosTableAdapters.tblAutoTableAdapter
    Private _autodal As New AutoDAL

    Public Function GetAllAutos() As Autos.tblAutoDataTable
        Try
            Return _adapterAuto.GetData()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoByAutoID(ByVal autoID As Integer) As Autos.tblAutoDataTable
        Try
            Return _autodal.GetAutoByAutoID(autoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNaamByAutoID(ByVal id As Integer) As String
        Try
            Return _autodal.GetAutoNaamByAutoID(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckOfKentekenReedsBestaat(ByVal kenteken As String) As Boolean
        Try
            If (_autodal.getAutoIDByKenteken(kenteken) = 0) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteAuto(ByVal autoID As Integer) As Boolean
        Try
            If (_adapterAuto.Delete(autoID)) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UpdateAuto(ByRef autorow As Autos.tblAutoRow) As Boolean
        Try
            If (_adapterAuto.Update(autorow)) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AddAuto(ByRef a As Autos.tblAutoRow) As Boolean
        Try
            If (_adapterAuto.Insert(a.categorieID, a.modelID, a.autoKleur, a.autoBouwjaar, a.brandstofID, a.autoKenteken, a.autoDagTarief, a.autoKMTotOlieVerversing, a.statusID, a.filiaalID, a.parkeerPlaatsID)) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetBeschikbareAutosBy(ByVal gewensteBegindatum As Date, ByVal gewensteEinddatum As Date, ByVal filterOpties() As String) As Autos.tblAutoDataTable
        Try

            'Alle auto's van een bepaalde categorie opvragen.
            Dim autodata As Autos.tblAutoDataTable = _autodal.GetAutosBy(filterOpties)

            autodata = FilterAutosByExtraOpties(autodata, filterOpties)

            'Auto-variabelen.
            Dim returneddata As New Autos.tblAutoDataTable
            Dim dr As Autos.tblAutoRow
            Dim autoID As Integer

            'Logica-variabelen.
            Dim autonummer As Integer = 0
            Dim autobeschikbaar As Boolean = True

            'Variabelen om de reservatiereeksen op te vangen.
            Dim reservatiedata As New Reservaties.tblReservatieDataTable
            Dim reservatiebll As New ReservatieBLL
            Dim reservatierow As Reservaties.tblReservatieRow

            'We gaan voor elke auto binnen onze gewenste categorie
            'de reeks reservaties ophalen en nakijken of de auto beschikbaar is.
            For autonummer = 0 To autodata.Rows.Count

                'Nakijken of er wel auto's zitten in onze selectie.
                If (autodata.Rows.Count = 0 Or autonummer >= autodata.Rows.Count) Then
                    Return returneddata
                Else 'Indien er nog een volgende auto is,
                    'lezen we een nieuwe rij uit de autodata.
                    dr = autodata.Rows(autonummer)
                    'We slaan het autoID uit deze rij op.
                    autoID = dr.autoID
                End If


                'Nu gaan we de reservaties nakijken.

                'Reservatiedata voor deze auto ophalen.
                reservatiedata = reservatiebll.GetAllReservatiesByAutoID(autoID)

                'Even nakijken of er wel reservaties voor deze auto zijn.
                If reservatiedata.Rows.Count = 0 Then
                    'Deze auto toevoegen aan de lijst van beschikbare auto's,
                    'er zijn immers geen reservaties voor deze auto.
                    returneddata.ImportRow(dr)

                Else 'er zijn reservaties.

                    'Voor elke reservatie gaan we checken of deze reservatie
                    'de auto heeft gereserveerd voor onze gewenste datum
                    For Each reservatierow In reservatiedata
                        Dim rowBegindatum As Date = CType(reservatierow.reservatieBegindat, Date)
                        Dim rowEinddatum As Date = CType(reservatierow.reservatieEinddat, Date)

                        'Overlapt deze reservatie met onze gewenste reservatiedatum?
                        If (rowBegindatum <= gewensteEinddatum And gewensteBegindatum <= rowEinddatum) Then

                            'Dikke pech, deze auto kunnen we niet weergeven!
                            autobeschikbaar = False
                            Exit For
                        End If
                    Next

                    'We hebben alle reservaties voor deze auto nagekeken. Is hij 
                    'beschikbaar? Zoja, dan voegen we hem toe aan onze lijst.
                    If (autobeschikbaar) Then
                        returneddata.ImportRow(dr)
                    End If

                End If

            Next autonummer

            Return returneddata

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetKleurenByCategorie(ByVal categorieID As Integer) As String()
        Try
            Return _autodal.GetKleurenByCategorieID(categorieID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getAutoIDByKenteken(ByVal autoKenteken As String) As Integer
        Try
            Return _autodal.getAutoIDByKenteken(autoKenteken)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FilterAutosByExtraOpties(ByRef autodata As Autos.tblAutoDataTable, ByRef filterOpties() As String) As Autos.tblAutoDataTable

        'Kijk na of er wel filters voor extra opties zijn.
        Dim erZijnFilters As Boolean = CheckVoorFilters(filterOpties)

        If (erZijnFilters) Then

            'Stel een int-array op van de filters.
            Dim optieFilter() As Integer = MaakFilterArray(filterOpties)

            'Deze datatable gaat alle geldige waardes bevatten.
            Dim returneddt As New Autos.tblAutoDataTable

            'Voor elke auto in de ongefilterde data gaan we hierdoor gaan
            For i = 0 To autodata.Rows.Count - 1

                'Nieuwe auto ophalen
                Dim a As Autos.tblAutoRow = autodata.Rows(i)

                'Opties van de auto in een int-array steken
                Dim aanwezigeOpties() As Integer = MaakAanwezigeOptiesArray(a)

                'Vergelijk beide int-arrays en steek de resultaten in een bool-array
                Dim optieCheck() As Boolean = VergelijkArrays(optieFilter, aanwezigeOpties)

                'Nu gaan we nakijken of de auto alle gewenste opties heeft.
                Dim heeftNietAlleOpties As Boolean = False
                For Each val As Boolean In optieCheck
                    If (val = False) Then
                        heeftNietAlleOpties = True
                        Exit For
                    End If
                Next val

                If (Not heeftNietAlleOpties) Then returneddt.ImportRow(a)

            Next

            Return returneddt
        Else
            Return autodata
        End If

    End Function

    Private Function CheckVoorFilters(ByRef filterOpties() As String) As Boolean
        For i As Integer = 20 To 39
            If (Not filterOpties(i) = String.Empty) Then
                Return True
            End If
        Next i
    End Function

    Private Function MaakFilterArray(ByRef filterOpties() As String) As Integer()
        Dim optiebll As New OptieBLL
        Dim optieFilter(20) As Integer

        Dim aantalItems As Integer = 0
        For i As Integer = 20 To 39
            If (Not filterOpties(i) = String.Empty) Then
                Dim optie As Autos.tblOptieRow = optiebll.GetOptieByNaam(filterOpties(i)).Rows(0)
                optieFilter(aantalItems) = optie.optieID
                aantalItems = aantalItems + 1
            End If
        Next i

        optiebll = Nothing

        ReDim Preserve optieFilter(aantalItems - 1)
        Return optieFilter
    End Function

    Private Function MaakAanwezigeOptiesArray(ByRef a As Autos.tblAutoRow) As Integer()
        Dim autoOptiebll As New AutoOptieBLL
        Dim dt As Autos.tblAutoOptieDataTable = autoOptiebll.GetAutoOptieByAutoID(a.autoID)

        'Even checken of er deze auto wel opties heeft
        If (dt.Rows.Count = 0) Then
            Dim dummyint() As Integer = {0}
            Return dummyint
        End If

        Dim aanwezigeOpties(dt.Rows.Count - 1) As Integer
        aanwezigeOpties(0) = dt.Rows(0).Item("optieID")
        For optie As Integer = 1 To dt.Rows.Count - 1
            Dim o As Autos.tblAutoOptieRow = dt.Rows(optie)
            aanwezigeOpties(optie) = o.optieID
        Next optie

        autoOptiebll = Nothing

        Return aanwezigeOpties
    End Function

    Private Function VergelijkArrays(ByRef optieFilter() As Integer, ByRef aanwezigeOpties() As Integer) As Boolean()

        'Deze array gaat bijhouden of deze auto alle gewenste extra opties heeft.
        Dim optieCheck(optieFilter.Length - 1) As Boolean

        Dim optieNr As Integer = 0
        For Each gewensteOptie As Integer In optieFilter
            For Each autoOptie As Integer In aanwezigeOpties

                If (gewensteOptie = autoOptie) Then
                    optieCheck(optieNr) = True
                    'We gaan uit de binnenste loop want we hebben de optie gevonden
                    Exit For
                End If

            Next autoOptie

            optieNr = optieNr + 1
        Next gewensteOptie

        Return optieCheck
    End Function

    Public Function getAutoGrid() As Data.DataTable
        Dim dt As New Data.DataTable
        dt = _autodal.getAutoGrid()
        Return (dt)
    End Function

    Function getdistinctBouwjaar() As Data.DataTable
        Dim dt As New Data.DataTable

        dt = _autodal.GetDistinctBouwJaar
        Return dt
    End Function

    Function getdistinctKleur() As Data.DataTable
        Dim dt As New Data.DataTable

        dt = _autodal.GetDistinctAutoKleur
        Return dt
    End Function
End Class
