' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.SqlClient
Imports HindlewareLib.Logging

Public Class FrmTrackInput
    Private _currentRecord As Record
    Public Property Record() As Record
        Get
            Return _currentRecord
        End Get
        Set(ByVal value As Record)
            _currentRecord = value
        End Set
    End Property

    Private CurrentTrack As New Track

    Private Sub FrmTrackInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Tracks", MyBase.Name)
        GetFormPos(Me, My.Settings.TrackInputFormPos)
        If _currentRecord.RecordId < 0 Then
            MsgBox("No selected Record", MsgBoxStyle.Exclamation, "Error")
            Close()
        End If
        InitialiseForm()
    End Sub
    Private Sub InitialiseForm()
        LblRecordId.Text = -1
        LoadGenreList()
        LoadArtistList()
        LblRecordId.Text = _currentRecord.RecordId
        LblRecordNo.Text = _currentRecord.RecordNumber
        RbA.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
        TxtYear.Text = String.Empty
        CbGenre.SelectedIndex = -1
        CbArtists.SelectedIndex = -1
        BtnNextTrack.Enabled = False
    End Sub

    Private Sub LoadArtistList()
        Me.ArtistsTableAdapter.Fill(Me.RecordsDataSet.Artists)
        CbArtists.SelectedIndex = -1
    End Sub

    Private Sub LoadGenreList()
        Me.MusicGenreTableAdapter.Fill(Me.RecordsDataSet.MusicGenre)
        CbGenre.SelectedIndex = -1
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmRecordInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.TrackInputFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnSaveTrack_Click(sender As Object, e As EventArgs) Handles BtnSaveTrack.Click
        If Not IsValidTrack() Then
            ShowStatus("Invalid values", LblStatus, MyBase.Name, False,,,,, True)
        Else
            CurrentTrack = BuildTrackFromForm()
            Dim response As Integer = InsertTrack(CurrentTrack)
            If response = 1 Then
                LblRecordId.Text = CStr(_currentRecord.RecordId)
                BtnNextTrack.Enabled = True
                BtnSaveTrack.Enabled = False
                ShowStatus("Track Added", LblStatus, MyBase.Name, False)
            Else
                ShowStatus("Error saving track", LblStatus, MyBase.Name, False, TraceEventType.Error, , ,, True)
            End If


        End If
    End Sub

    Private Function BuildTrackFromForm() As Track
        Dim _artist As New Artist
        If CbArtists.SelectedIndex > -1 Then
            _artist = ArtistBuilder.AnArtist.StartingWith(CType(CbArtists.SelectedItem.row, RecordsDataSet.ArtistsRow)).Build
        End If
        Dim _genre As New Genre
        If CbGenre.SelectedIndex > -1 Then
            _genre = GenreBuilder.AGenre.StartingWith(CType(CbGenre.SelectedItem.row, RecordsDataSet.MusicGenreRow)).Build
        End If
        Return TrackBuilder.ATrack.StartingWithNothing _
            .WithId(_currentRecord.RecordId) _
            .WithSide(GetSideFromForm) _
            .WithTrack(NudTrackNo.Value) _
            .WithArtist(_artist) _
            .WithTitle(TxtTitle.Text) _
            .WithYear(TxtYear.Text) _
            .WithGenre(_genre).Build
    End Function

    Private Function GetSideFromForm() As String
        Dim _side As String = "A"
        Select Case True
            Case RbA.Checked
                _side = "A"
            Case RbB.Checked
                _side = "B"
            Case RbAA.Checked
                _side = "AA"
            Case Rb1.Checked
                _side = "1"
            Case Rb2.Checked
                _side = "2"

        End Select
        Return _side
    End Function

    Private Function IsValidTrack() As Boolean
        Dim isOK As Boolean = True
        'If String.IsNullOrWhiteSpace(TxtArtist.Text) Then
        '    isOK = False
        'End If
        If String.IsNullOrWhiteSpace(TxtTitle.Text) Then
            isOK = False
        End If
        If CbGenre.SelectedIndex < 0 Then
            isOK = False
        End If
        If CbArtists.SelectedIndex < 0 Then
            isOK = False
        End If
        Return isOK
    End Function

    Private Sub BtnNextTrack_Click(sender As Object, e As EventArgs) Handles BtnNextTrack.Click
        ClearTrack()
    End Sub

    Private Sub ClearTrack()
        RbB.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
        BtnNextTrack.Enabled = False
        BtnSaveTrack.Enabled = True
    End Sub

    Private Sub BtnTracks_Click(sender As Object, e As EventArgs) Handles BtnTracks.Click
        Using _artist As New FrmArtistMaint
            _artist.ShowDialog()
        End Using
        LoadArtistList()
    End Sub
End Class