' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmSearch
    Private ReadOnly oRecordLabelsTa As New RecordsDataSetTableAdapters.RecordLabelsTableAdapter
    Private ReadOnly oRecordLabelsTable As New RecordsDataSet.RecordLabelsDataTable

    Private ReadOnly oMusicGenreTa As New RecordsDataSetTableAdapters.MusicGenreTableAdapter
    Private ReadOnly oMusicGenreTable As New RecordsDataSet.MusicGenreDataTable

    Private ReadOnly oArtistsTa As New RecordsDataSetTableAdapters.ArtistsTableAdapter
    Private ReadOnly oArtistsTable As New RecordsDataSet.ArtistsDataTable

    Private Sub InitialiseForm()
        InitialiseDataSources()
        LoadLabelList()
        LoadGenreList()
        LoadArtistList()
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
    End Sub

    Private Sub LoadLabelList()
        oRecordLabelsTa.Fill(oRecordLabelsTable)
        CbRecordLabel.SelectedIndex = -1
    End Sub

    Private Sub LoadArtistList()
        oArtistsTa.Fill(oArtistsTable)
        CbArtists.SelectedIndex = -1
    End Sub

    Private Sub LoadGenreList()
        oMusicGenreTa.Fill(oMusicGenreTable)
        CbGenre.SelectedIndex = -1
    End Sub

    Private Sub FrmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Records", MyBase.Name)
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
            _searchList = GetTracksForSearch(CbArtists.Text, _labelId, TxtRecNumber.Text, TxtTitle.Text, _year, _genreId)
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