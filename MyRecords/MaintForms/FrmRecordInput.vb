' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports HindlewareLib.Logging

Public Class FrmRecordInput
    Private CurrentRecord As New Record
    Private isLoading As Boolean
    Private Sub FrmRecordInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Records", MyBase.Name)
        If GetFormPos(Me, My.Settings.RecordInputFormPos) Then
            LoadSplitterDistances()
        End If
        InitialiseForm()
    End Sub

    Private Sub LoadSplitterDistances()
        Try
            If My.Settings.RecSplitDist1 > 0 Then
                SplitContainer1.SplitterDistance = My.Settings.RecSplitDist1
            End If
        Catch ex As Exception
            DisplayException(ex, "Settings",, MyBase.Name)
        End Try
    End Sub

    Private Sub InitialiseForm()
        LoadFormatList()
        LoadLabelList()
        ClearForm()
        DgvTracks.Rows.Clear()
        BtnAddTracks.Enabled = False
        LoadRecords()
    End Sub

    Private Sub LoadRecords()
        isLoading = True
        DgvRecords.Rows.Clear()
        Dim _records As List(Of Record) = GetAllRecords()
        For Each _record As Record In _records
            AddRecordToTable(_record)
        Next
        DgvRecords.ClearSelection()
        isLoading = False
    End Sub

    Private Sub AddRecordToTable(pRecord As Record)
        Dim _row As DataGridViewRow = DgvRecords.Rows(DgvRecords.Rows.Add())
        _row.Cells(recId.Name).Value = pRecord.RecordId
        _row.Cells(recFormat.Name).Value = pRecord.RecordFormat.FormatName
        _row.Cells(recLabel.Name).Value = pRecord.Label.LabelName
        _row.Cells(recNumber.Name).Value = pRecord.RecordNumber
        _row.Cells(recSize.Name).Value = pRecord.Size
        _row.Cells(recSpeed.Name).Value = pRecord.Speed
    End Sub

    Private Sub LoadFormatList()
        Me.RecordFormatTableAdapter.Fill(Me.RecordsDataSet.RecordFormat)
    End Sub
    Private Sub LoadLabelList()
        Me.RecordLabelsTableAdapter.Fill(Me.RecordsDataSet.RecordLabels)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmRecordInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.RecordInputFormPos = SetFormPos(Me)
        SaveSplitterDistances()
        My.Settings.Save()
    End Sub
    Private Sub SaveSplitterDistances()
        My.Settings.RecSplitDist1 = SplitContainer1.SplitterDistance
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If Not IsValidRecord Then
            ShowStatus("Invalid values", LblStatus, MyBase.Name, False,,,,, True)
        Else
            CurrentRecord = BuildRecordFromForm()
            CurrentRecord.RecordId = InsertRecord(CurrentRecord)
            LblRecordId.Text = CStr(CurrentRecord.RecordId)
            BtnAddTracks.Enabled = True
            BtnAdd.Enabled = False
            ShowStatus("Record Added", LblStatus, MyBase.Name, False)
            LoadRecords()
        End If
    End Sub
    Private Function IsValidRecord() As Boolean
        Dim isOK As Boolean = True
        If String.IsNullOrWhiteSpace(TxtRecNumber.Text) Then
            isOK = False
        End If
        If CbRecordFormat.SelectedIndex < 0 Then
            isOK = False
        End If
        If CbRecordLabel.SelectedIndex < 0 Then
            isOK = False
        End If
        Return isOK
    End Function
    Private Sub BtnAddFormat_Click(sender As Object, e As EventArgs) Handles BtnAddFormat.Click
        Using _format As New frmFormatMaint
            _format.showdialog
        End Using
        LoadFormatList()
    End Sub

    Private Sub BtnAddLabel_Click(sender As Object, e As EventArgs) Handles BtnAddLabel.Click
        Using _label As New FrmLabelMaint
            _label.ShowDialog()
        End Using
        LoadLabelList()
    End Sub

    Private Sub BtnAddTracks_Click(sender As Object, e As EventArgs) Handles BtnAddTracks.Click
        Using _trackInput As New FrmTrackInput
            LogUtil.Info("Opening Track Input", MyBase.Name)
            _trackInput.Record = CurrentRecord
            _trackInput.ShowDialog()
        End Using
        LoadTracks(CurrentRecord.RecordId)
    End Sub

    Private Sub LoadTracks(pRecordId)
        DgvTracks.Rows.Clear()
        Dim _tracks As List(Of Track) = GetTracksForRecord(pRecordId)
        For Each _track As Track In _tracks
            AddTrackToTable(_track)
        Next
    End Sub

    Private Sub AddTrackToTable(pTrack As Track)
        Dim _row As DataGridViewRow = DgvTracks.Rows(DgvTracks.Rows.Add())
        _row.Cells(trkSide.Name).Value = pTrack.Side
        _row.Cells(trkTrack.Name).Value = pTrack.Track
        _row.Cells(trkArtist.Name).Value = pTrack.Artist
        _row.Cells(trkTitle.Name).Value = pTrack.Title
        _row.Cells(trkYear.Name).Value = pTrack.Year
        _row.Cells(trkGenre.Name).Value = pTrack.Genre.GenreName
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        TxtRecNumber.Text = String.Empty
        LblRecordId.Text = "-1"
        DgvTracks.Rows.Clear()
        BtnAddTracks.Enabled = False
        CbRecordLabel.SelectedIndex = -1
        BtnAdd.Enabled = True
        BtnAddTracks.Enabled = False
    End Sub
    Private Function BuildRecordFromForm() As Record
        Dim _formatId As String = CbRecordFormat.SelectedValue
        Dim _labelId As Integer = CbRecordLabel.SelectedValue

        Return RecordBuilder.ARecord.StartingWithNothing _
            .WithFormat(_formatId) _
            .WithLabel(_labelId) _
            .WithRecordNumber(TxtRecNumber.Text) _
            .WithSize(GetSizeFromForm()) _
            .WithSpeed(GetSpeedFromForm()) _
            .Build
    End Function
    Private Function GetSizeFromForm() As Integer
        Dim _size As Integer
        Select Case True
            Case Rb7.Checked
                _size = 7
            Case Rb12.Checked
                _size = 12
            Case Else
                _size = -1
        End Select
        Return _size
    End Function
    Private Function GetSpeedFromForm() As String
        Dim _speed As String
        Select Case True
            Case Rb45.Checked
                _speed = "45"
            Case Rb33.Checked
                _speed = "33"
            Case Rb78.Checked
                _speed = "78"
            Case Else
                _speed = "n/a"
        End Select
        Return _speed
    End Function
    Private Sub DgvRecords_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRecords.SelectionChanged
        If Not isLoading AndAlso DgvRecords.SelectedRows.Count = 1 Then
            ClearForm()
            Dim _row As DataGridViewRow = DgvRecords.SelectedRows(0)
            LoadFormFromDgv(_row)
            LoadTracks(_row.Cells(recId.Name).Value)
        End If
    End Sub

    Private Sub LoadFormFromDgv(pRow As DataGridViewRow)
        CurrentRecord = GetRecordFromId(pRow.Cells(recId.Name).Value)
        LblRecordId.Text = CurrentRecord.RecordId
        CbRecordFormat.SelectedIndex = FindFormat(CurrentRecord.RecordFormat)
        CbRecordLabel.SelectedIndex = FindLabel(CurrentRecord.Label)
        TxtRecNumber.Text = CurrentRecord.RecordNumber
        CheckSize(CurrentRecord.Size)
        CheckSpeed(CurrentRecord.Speed)
        BtnAdd.Enabled = False
        BtnAddTracks.Enabled = True
    End Sub

    Private Function FindLabel(label As RecordLabel) As Integer
        Return CbRecordLabel.FindString(label.LabelName)
    End Function

    Private Function FindFormat(recordFormat As RecordFormat) As Integer
        Return CbRecordFormat.FindString(recordFormat.FormatId)
    End Function

    Private Sub CheckSpeed(speed As String)
        Select Case speed
            Case "45 "
                Rb45.Checked = True
            Case "33 "
                Rb33.Checked = True
            Case "78 "
                Rb78.Checked = True
            Case Else
                RbNoSpeed.Checked = True
        End Select
    End Sub

    Private Sub CheckSize(size As Integer)
        Select Case size
            Case 7
                Rb7.Checked = True
            Case 12
                Rb12.Checked = True
            Case 0
                RbNoSize.Checked = True
        End Select
    End Sub

    Private Sub ClearForm()
        LblRecordId.Text = -1
        CbRecordFormat.SelectedIndex = -1
        CbRecordLabel.SelectedIndex = -1
        TxtRecNumber.Text = String.Empty
        Rb7.Checked = True
        Rb45.Checked = True
    End Sub
End Class
