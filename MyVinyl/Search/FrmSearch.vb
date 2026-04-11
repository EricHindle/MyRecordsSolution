' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyVinyl.Domain
Public Class FrmSearch
    Private oRecordLabelsTable As New List(Of RecordLabel)
    Private oMusicGenreTable As New List(Of Genre)
    Private oArtistsTable As New List(Of Artist)
    Private Sub InitialiseForm()
        LoadLabelList()
        LoadGenreList()
        LoadArtistList()
        InitialiseDataSources()
    End Sub

    Private Sub InitialiseDataSources()
        CbArtists.DataSource = oArtistsTable
        CbArtists.ValueMember = "ArtistId"
        CbArtists.DisplayMember = "ArtistName"
        CbRecordLabel.DataSource = oRecordLabelsTable
        CbRecordLabel.ValueMember = "LabelId"
        CbRecordLabel.DisplayMember = "LabelName"
        CbGenre.DataSource = oMusicGenreTable
        CbGenre.ValueMember = "GenreId"
        CbGenre.DisplayMember = "GenreName"
        CbRecordLabel.SelectedIndex = -1
        CbArtists.SelectedIndex = -1
        CbGenre.SelectedIndex = -1
    End Sub

    Private Sub LoadLabelList()
        oRecordLabelsTable = GetAllLabels()
    End Sub

    Private Sub LoadArtistList()
        oArtistsTable = GetAllArtists()
    End Sub

    Private Sub LoadGenreList()
        oMusicGenreTable = GetAllGenres()
    End Sub

    Private Sub FrmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Search", MyBase.Name)
        If GetFormPos(Me, My.Settings.SearchFormPos) Then

        End If
        InitialiseForm()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.SearchFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim _searchList As New List(Of FullRecord)
        If Not String.IsNullOrWhiteSpace(TxtId.Text) AndAlso IsNumeric(TxtId.Text) Then
            Dim _fullrecord As FullRecord = FullRecordBuilder.AFullRecord.StartingWith(CInt(TxtId.Text)).Build
            If _fullrecord.IsExists Then
                _searchList.Add(_fullrecord)
            End If
        Else
            Dim _labelId As Integer = If(CbRecordLabel.SelectedIndex > -1, CbRecordLabel.SelectedValue, -1)
            Dim _genreId As Integer = If(CbGenre.SelectedIndex > -1, CbGenre.SelectedValue, -1)
            Dim _year As Integer = If(String.IsNullOrWhiteSpace(TxtYear.Text), -1, TxtYear.Text)
            Dim _artistId As Integer = If(CbArtists.SelectedIndex > -1, CbArtists.SelectedValue(), -1)
            _searchList = GetTracksForSearch(_artistId, _labelId, TxtRecNumber.Text, TxtTitle.Text, _year, _genreId)
        End If
        LoadViewFromList(_searchList)
    End Sub

    Private Sub LoadViewFromList(_searchList As List(Of FullRecord))
        DgvRecords.Rows.Clear()
        For Each _fullrecord As FullRecord In _searchList
            Dim oRow As DataGridViewRow = DgvRecords.Rows(DgvRecords.Rows.Add())
            With _fullrecord.Record
                oRow.Cells(recId.Name).Value = .RecordId
                oRow.Cells(recLabel.Name).Value = .Label.LabelName
                oRow.Cells(recNumber.Name).Value = .RecordNumber
            End With
            If _fullrecord.Tracks.Count > 0 Then
                With _fullrecord.Tracks(0)
                    oRow.Cells(recArtist.Name).Value = .Artist.ArtistName
                    oRow.Cells(recTitle.Name).Value = .Title
                    oRow.Cells(recSide.Name).Value = .Side
                    oRow.Cells(recChartPos.Name).Value = If(.PeakChartPosition > 0, .PeakChartPosition, "")
                    If .ChartDate IsNot Nothing Then
                        oRow.Cells(recDate.Name).Value = Format(.ChartDate, "dd MMM yyyy")
                    End If
                End With
            End If
        Next

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm
    End Sub
    Private Sub ClearForm()
        TxtId.Text = String.Empty
        CbArtists.SelectedIndex = -1
        TxtTitle.Text = String.Empty
        TxtRecNumber.Text = String.Empty
        CbRecordLabel.SelectedIndex = -1
        TxtYear.Text = String.Empty
        CbGenre.SelectedIndex = -1
    End Sub
End Class