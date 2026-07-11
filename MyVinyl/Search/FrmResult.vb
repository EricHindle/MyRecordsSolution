' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports HindlewareLib.Logging
Imports MyVinyl.Domain
Public Class FrmResult
    Private oRecord As Record
    Private oTrack As Track
    Private oArtist As Artist
    Private oGenre As Genre
    Private oLabel As RecordLabel
    Private _recordId As Integer
    Private _side As String
    Private _track As Integer
    Public Property Track() As Integer
        Get
            Return _track
        End Get
        Set(ByVal value As Integer)
            _track = value
        End Set
    End Property
    Public Property Side() As String
        Get
            Return _side
        End Get
        Set(ByVal value As String)
            _side = value
        End Set
    End Property
    Public Property RecordId() As Integer
        Get
            Return _recordId
        End Get
        Set(ByVal value As Integer)
            _recordId = value
        End Set
    End Property
    Private Sub FrmResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Record Details", MyBase.Name)
        If GetFormPos(Me, My.Settings.DetailsFormPos) Then

        End If
        InitialiseForm()
    End Sub

    Private Sub InitialiseForm()
        oRecord = GetRecordFromId(_recordId)
        oTrack = GetTrackForKey(_recordId, _side, _track)
        oArtist = oTrack.Artist
        oGenre = oTrack.Genre
        oLabel = oRecord.Label
        LblId.Text = _recordId
        TxtArtist.Text = oArtist.ArtistName
        TxtTitle.Text = oTrack.Title
        TxtSide.Text = oTrack.Side
        TxtTrack.Text = oTrack.Track
        PicImage.ImageLocation = Path.Combine(My.Settings.ImagePath, oArtist.ArtistImage)
        TxtRecNumber.Text = oRecord.RecordNumber
        TxtLabel.Text = oLabel.LabelName
        TxtGenre.Text = oGenre.GenreName
        TxtSize.Text = oRecord.Size
        TxtSpeed.Text = oRecord.Speed
        TxtCopies.Text = oRecord.Copies
        TxtYear.Text = oTrack.Year
        TxtChartPos.Text = oTrack.PeakChartPosition
        TxtChartDate.Text = Format(oTrack.ChartDate, "dd MMM yyyy")
        TxtSongFile.Text = oTrack.SongFile

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmResult_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        StopAudio(ProgressBar1, BtnPlay, BtnStop)
        My.Settings.DetailsFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        If IsValidSongFileName(TxtSongFile.Text) Then
            PlaySong(TxtSongFile.Text, ProgressBar1, BtnPlay, BtnStop)
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        StopAudio(ProgressBar1, BtnPlay, BtnStop)
    End Sub

    Private Sub BtnMetadata_Click(sender As Object, e As EventArgs) Handles BtnMetadata.Click
        Dim oMetaData As New StringBuilder
        oMetaData.Append(TxtArtist.Text) _
                .Append(vbTab) _
                .Append(vbTab) _
                .Append(TxtTitle.Text) _
                .Append(vbTab) _
                .Append(vbTab) _
                .Append("Singles") _
                .Append(vbTab) _
                .Append(vbTab) _
                .Append(TxtTrack.Text) _
                .Append(vbTab) _
                .Append(vbTab) _
                .Append(TxtYear.Text) _
                .Append(vbTab) _
                .Append(vbTab) _
                .Append("Pop")
        SendKeys.Send("%{ESC}")
        SendKeys.Send(oMetaData.ToString)
    End Sub
End Class