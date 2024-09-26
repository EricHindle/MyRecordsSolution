' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text.RegularExpressions
Imports HindlewareLib.Logging

Public Class FrmRecordInput
    Private CurrentRecord As New Record
    Private CurrentTrack As New Track

    Private isLoading As Boolean
    Private Sub FrmRecordInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Records", MyBase.Name)
        If GetFormPos(Me, My.Settings.RecordInputFormPos) Then
            LoadSplitterDistances()
        End If
        SplitContainer2.Panel2Collapsed = True
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
        LoadGenreList()
        LoadArtistList()
        ClearForm()
        DgvTracks.Rows.Clear()
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
        Dim _tracks As List(Of Track) = GetTracksForRecord(pRecord.RecordId)
        If _tracks.Count > 0 Then
            _row.Cells(recArtist.Name).Value = _tracks(0).Artist.ArtistName
        End If
    End Sub

    Private Sub LoadFormatList()
        Me.RecordFormatTableAdapter.Fill(Me.RecordsDataSet.RecordFormat)
        CbRecordFormat.SelectedIndex = -1
    End Sub
    Private Sub LoadLabelList()
        Me.RecordLabelsTableAdapter.Fill(Me.RecordsDataSet.RecordLabels)
        CbRecordLabel.SelectedIndex = -1
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
        My.Settings.RecordInputFormPos = SetFormPos(Me)
        SaveSplitterDistances()
        My.Settings.Save()
    End Sub
    Private Sub SaveSplitterDistances()
        My.Settings.RecSplitDist1 = SplitContainer1.SplitterDistance
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim IsExists As Boolean = False
        If Not IsValidRecord(IsExists) Then
            ShowStatus("Invalid values", LblStatus, MyBase.Name, False,,,,, True)
        Else
            CurrentRecord = BuildRecordFromForm()
            If IsExists Then
                CurrentRecord.RecordId = CInt(LblRecordId.Text)
                UpdateRecordCopies(CurrentRecord)
                ShowStatus("Record Updated", LblStatus, MyBase.Name, False)
            Else
                CurrentRecord.RecordId = InsertRecord(CurrentRecord)
                LblRecordId.Text = CStr(CurrentRecord.RecordId)
                SplitContainer2.Panel2Collapsed = False
                BtnAdd.Enabled = False
                ShowStatus("Record Added", LblStatus, MyBase.Name, False)
            End If
            LoadRecords()
        End If
    End Sub
    Private Function IsValidRecord(ByRef IsExists As Boolean) As Boolean
        Dim isOK As Boolean = True
        If String.IsNullOrWhiteSpace(TxtRecNumber.Text) Then
            isOK = False
        Else
            Dim recordList As System.Data.EnumerableRowCollection(Of RecordsDataSet.vRecordTracksRow) = FindExistingRecordByLabelAndNumber(TxtRecNumber.Text, CbRecordLabel.SelectedValue)
            If recordList.Count > 0 Then
                If MsgBox("Looks like this record is already on file" & vbCrLf & "Accept and add a copy?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Match Found") = MsgBoxResult.Yes Then
                    Dim oRow As RecordsDataSet.vRecordTracksRow = TryCast(recordList(0), RecordsDataSet.vRecordTracksRow)
                    LblRecordId.Text = oRow.RecordId
                    NudCopies.Value = oRow.Copies + 1
                    IsExists = True
                Else
                    isOK = False
                End If
            End If
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
        Using _format As New FrmFormatMaint
            _format.ShowDialog()
        End Using
        LoadFormatList()
    End Sub

    Private Sub BtnAddLabel_Click(sender As Object, e As EventArgs) Handles BtnAddLabel.Click
        Using _label As New FrmLabelMaint
            _label.IsSaveAndExit = True
            _label.ShowDialog()
            LoadLabelList()
            CbRecordLabel.SelectedValue = _label.RecordLabel.LabelId
        End Using
    End Sub

    Private Sub BtnAddTracks_Click(sender As Object, e As EventArgs)
        Using _trackInput As New FrmTrackInput
            LogUtil.Info("Opening Track Input", MyBase.Name)
            _trackInput.Record = CurrentRecord
            _trackInput.ShowDialog()
        End Using
        LoadRecords()
        FindRecordInList(CurrentRecord.RecordId)
    End Sub

    Private Sub FindRecordInList(recordId As Integer)
        For Each oRow As DataGridViewRow In DgvRecords.Rows
            If oRow.Cells(recId.Name).Value = recordId Then
                oRow.Selected = True
                DgvRecords.FirstDisplayedScrollingRowIndex = Math.Max(0, oRow.Index - 3)
                Exit For
            End If
        Next
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
        _row.Cells(trkArtist.Name).Value = pTrack.Artist.ArtistName
        _row.Cells(trkTitle.Name).Value = pTrack.Title
        _row.Cells(trkYear.Name).Value = pTrack.Year
        _row.Cells(trkGenre.Name).Value = pTrack.Genre.GenreName
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        DgvTracks.Rows.Clear()
        ClearTrackForm()
        LoadRecords()
        FindRecordInList(CurrentRecord.RecordId)
        CurrentRecord = New Record
        CbRecordLabel.SelectedIndex = -1
        LblRecordId.Text = "-1"
        TxtRecNumber.Text = String.Empty
        NudCopies.Value = 1
        Rb45.Checked = True
        Rb7.Checked = True
        BtnAdd.Enabled = True
        SplitContainer2.Panel2Collapsed = True
    End Sub
    Private Sub ClearTrackForm()
        RbA.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
        TxtYear.Text = String.Empty
        CbGenre.SelectedIndex = -1
        CbArtists.SelectedIndex = -1
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
            .WithCopies(NudCopies.Value) _
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
            SplitContainer2.Panel2Collapsed = False
            Dim _row As DataGridViewRow = DgvRecords.SelectedRows(0)
            LoadFormFromDgv(_row)
            LoadTracks(_row.Cells(recId.Name).Value)
        End If
    End Sub

    Private Sub LoadFormFromDgv(pRow As DataGridViewRow)
        CurrentRecord = GetRecordFromId(pRow.Cells(recId.Name).Value)
        LblRecordId.Text = CurrentRecord.RecordId
        CbRecordFormat.SelectedValue = CurrentRecord.RecordFormat.FormatId
        CbRecordLabel.SelectedValue = CurrentRecord.Label.LabelId
        TxtRecNumber.Text = CurrentRecord.RecordNumber
        NudCopies.Value = CurrentRecord.Copies
        CheckSize(CurrentRecord.Size)
        CheckSpeed(CurrentRecord.Speed)
        BtnAdd.Enabled = False
    End Sub

    Private Sub CheckSpeed(speed As String)
        Select Case speed
            Case "45"
                Rb45.Checked = True
            Case "33"
                Rb33.Checked = True
            Case "78"
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
        NudCopies.Value = 1
        Rb7.Checked = True
        Rb45.Checked = True
        ClearTrackForm()
    End Sub

    Private Function FindExistingRecordByLabelAndNumber(pRecordNo As String, pLabelId As Integer) As System.Data.EnumerableRowCollection(Of RecordsDataSet.vRecordTracksRow)
        Dim oRecordListTable As New RecordsDataSet.vRecordTracksDataTable
        Dim oRecordListTa As New RecordsDataSetTableAdapters.vRecordTracksTableAdapter
        oRecordListTa.Fill(oRecordListTable)
        Dim recordList As System.Data.EnumerableRowCollection(Of RecordsDataSet.vRecordTracksRow)
        Dim _recNo As String = RecNoChars(pRecordNo)
        recordList = From record In oRecordListTable
                     Where record.LabelId = pLabelId And RecNoChars(record.RecordNo) = RecNoChars(pRecordNo)
        Return recordList
    End Function
    Private Function RecNoChars(pRecNo As String) As String
        Dim rtnVal As String = String.Empty
        For Each _char As Char In pRecNo.ToLower
            If Regex.IsMatch(CStr(_char), "[a-z0-9]") Then
                rtnVal &= _char
            End If
        Next
        Return rtnVal
    End Function
    Private Sub BtnSaveTrack_Click(sender As Object, e As EventArgs) Handles BtnSaveTrack.Click
        If Not IsValidTrack() Then
            ShowStatus("Invalid values", LblStatus, MyBase.Name, False,,,,, True)
        Else
            CurrentTrack = BuildTrackFromForm()
            Dim response As Integer = InsertTrack(CurrentTrack)
            If response = 1 Then
                LblRecordId.Text = CStr(CurrentRecord.RecordId)
                ShowStatus("Track Added", LblStatus, MyBase.Name, False)
            Else
                ShowStatus("Error saving track", LblStatus, MyBase.Name, False, TraceEventType.Error, , ,, True)
            End If
            ClearTrack()

        End If
    End Sub
    Private Sub ClearTrack()
        RbB.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
    End Sub

    Private Sub BtnTracks_Click(sender As Object, e As EventArgs) Handles BtnTracks.Click
        Using _artist As New FrmArtistMaint
            _artist.IsSaveAndExit = True
            _artist.ShowDialog()
            LoadArtistList()
            CbArtists.SelectedValue = _artist.Artist.ArtistId
        End Using
    End Sub

    Private Sub BtnAddGenre_Click(sender As Object, e As EventArgs) Handles BtnAddGenre.Click
        Using _genre As New FrmGenreMaint
            _genre.IsSaveAndExit = True
            _genre.ShowDialog()
            LoadGenreList()
            CbGenre.SelectedValue = _genre.Genre.GenreId
        End Using
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
            .WithId(CurrentRecord.RecordId) _
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

End Class
