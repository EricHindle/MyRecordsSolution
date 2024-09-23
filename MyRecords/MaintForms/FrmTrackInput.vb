' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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
        LblRecordId.Text = _currentRecord.RecordId
        LblRecordNo.Text = _currentRecord.RecordNumber
        RbA.Checked = True
        NudTrackNo.Value = 1
        TxtArtist.Text = String.Empty
        TxtTitle.Text = String.Empty
        TxtYear.Text = String.Empty
        CbGenre.SelectedIndex = -1
        BtnNextTrack.Enabled = False
    End Sub

    Private Sub LoadGenreList()
        Me.MusicGenreTableAdapter.Fill(Me.RecordsDataSet.MusicGenre)
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
            InsertTrack(CurrentTrack)
            LblRecordId.Text = CStr(_currentRecord.RecordId)
            BtnNextTrack.Enabled = True
            BtnSaveTrack.Enabled = False
            ShowStatus("Track Added", LblStatus, MyBase.Name, False)
        End If
    End Sub

    Private Function BuildTrackFromForm() As Track
        Return TrackBuilder.ATrack.StartingWithNothing _
            .WithId(_currentRecord.RecordId) _
            .WithSide(GetSideFromForm) _
            .WithTrack(NudTrackNo.Value) _
            .WithArtist(TxtArtist.Text) _
            .WithTitle(TxtTitle.Text) _
            .WithYear(TxtYear.Text) _
            .WithGenre(GetGenreFromId(CInt(CbGenre.SelectedValue))).Build
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
        If String.IsNullOrWhiteSpace(TxtArtist.Text) Then
            isOK = False
        End If
        If String.IsNullOrWhiteSpace(TxtTitle.Text) Then
            isOK = False
        End If
        If CbGenre.SelectedIndex < 0 Then
            isOK = False
        End If
        Return isOK
    End Function

    Private Sub BtnNextTrack_Click(sender As Object, e As EventArgs) Handles BtnNextTrack.Click

    End Sub
End Class