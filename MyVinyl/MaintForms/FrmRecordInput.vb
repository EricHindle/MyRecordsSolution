' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyVinyl.Domain
Public Class FrmRecordInput
#Region "variables"
    Private CurrentRecord As New Record
    Private CurrentTrack As New Track
    Private isTrackChanged As Boolean
    Private isLoading As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmRecordInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Records", MyBase.Name)
        If GetFormPos(Me, My.Settings.RecordInputFormPos) Then
            LoadSplitterDistances()
        End If
        SplitContainer2.Panel2Collapsed = True
        InitialiseForm()
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
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If Not IsValidRecord() Then
            LogUtil.ShowStatus("Invalid values", LblStatus, MyBase.Name, False, Nothing, True)
        Else
            TxtRecNumber.Text = TxtRecNumber.Text.ToUpper
            CurrentRecord = BuildRecordFromForm()
            Dim _duplicateRecord As Record = GetDuplicateRecord()
            If _duplicateRecord Is Nothing Then
                CurrentRecord.RecordId = InsertRecord(CurrentRecord)
                LblRecordId.Text = CStr(CurrentRecord.RecordId)
                SplitContainer2.Panel2Collapsed = False
                BtnAdd.Visible = False
                BtnUpdate.Visible = True
                LogUtil.ShowStatus("Record Added", LblStatus, MyBase.Name)
            Else
                If IsIncrementCopies(_duplicateRecord) Then
                    UpdateRecordCopies(CurrentRecord)
                    NextRecord()
                    LogUtil.ShowStatus("Record Updated", LblStatus, MyBase.Name)
                Else
                    SplitContainer2.Panel2Collapsed = True
                    BtnAdd.Visible = True
                    BtnUpdate.Visible = False
                    LogUtil.ShowStatus("Record rejected", LblStatus, MyBase.Name)
                End If
            End If
            LoadRecords()
            FindRecordInList(CurrentRecord.RecordId)
        End If
    End Sub
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
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If Not isTrackChanged OrElse MsgBox("OK to lose changes?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Track not saved") = MsgBoxResult.Yes Then
            NextRecord()
        End If
    End Sub
    Private Sub DgvRecords_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRecords.SelectionChanged
        If Not isLoading AndAlso DgvRecords.SelectedRows.Count = 1 Then
            ClearForm()
            SplitContainer2.Panel2Collapsed = False
            Dim _row As DataGridViewRow = DgvRecords.SelectedRows(0)
            LoadFormFromDgv(_row)
            isLoading = True
            LoadTracks(_row.Cells(recId.Name).Value)
            isLoading = False
        End If
    End Sub
    Private Sub BtnSaveTrack_Click(sender As Object, e As EventArgs) Handles BtnSaveTrack.Click
        TrimValues()
        If Not IsValidTrack() Then
            LogUtil.ShowStatus("Invalid values", LblStatus, False, MyBase.Name, Nothing, True)
        Else
            CurrentTrack = BuildTrackFromForm()
            If Not IsTrackExists(CurrentTrack) Then
                If InsertTrack(CurrentTrack) Then
                    LblRecordId.Text = CStr(CurrentRecord.RecordId)
                    If DgvRecords.SelectedRows.Count = 1 AndAlso String.IsNullOrEmpty(DgvRecords.SelectedRows(0).Cells(recArtist.Name).Value) Then
                        DgvRecords.SelectedRows(0).Cells(recArtist.Name).Value = CurrentTrack.Artist.ArtistName
                        DgvRecords.SelectedRows(0).Cells(recArtistId.Name).Value = CurrentTrack.Artist.ArtistId
                    End If
                    LogUtil.ShowStatus("Track Added", LblStatus, MyBase.Name)
                Else
                    LogUtil.ShowStatus("Error saving track", LblStatus, True, MyBase.Name, TraceEventType.Error, True)
                End If
                ClearTrack()
            Else
                LogUtil.ShowStatus("Track already exists", LblStatus)
            End If
        End If
        isLoading = True
        LoadTracks(CurrentRecord.RecordId)
        isLoading = False
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
    Private Sub TxtTitle_DragEnter(sender As Object, e As DragEventArgs) Handles TxtTitle.DragEnter
        TextBox_DragEnter(sender, e)
    End Sub
    Private Sub TxtTitle_DragDrop(sender As Object, e As DragEventArgs) Handles TxtTitle.DragDrop
        TextBox_DragDrop(sender, e)
    End Sub
    Private Sub RbA_CheckedChanged(sender As Object, e As EventArgs) Handles RbA.CheckedChanged,
                                                                             RbAA.CheckedChanged,
                                                                             RbB.CheckedChanged,
                                                                             Rb1.CheckedChanged,
                                                                             Rb2.CheckedChanged,
                                                                             NudCopies.ValueChanged,
                                                                             CbArtists.SelectedIndexChanged,
                                                                             CbGenre.SelectedIndexChanged
        isTrackChanged = True
    End Sub
    Private Sub TxtYear_TextChanged(sender As Object, e As EventArgs) Handles TxtYear.TextChanged
        isTrackChanged = True
        If Not String.IsNullOrWhiteSpace(TxtYear.Text) AndAlso IsNumeric(TxtYear.Text) AndAlso CInt(TxtYear.Text) > 1900 AndAlso CInt(TxtYear.Text) < Today.Year Then
            If String.IsNullOrEmpty(TxtChartPos.Text) Then
                If DtpChartDate.Value.Year <> CInt(TxtYear.Text) Then
                    DtpChartDate.Value = New Date(CInt(TxtYear.Text), 1, 1)
                End If
            End If
        End If
    End Sub
    Private Sub DgvTracks_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTracks.CellDoubleClick
        If Not isLoading AndAlso DgvRecords.SelectedRows.Count = 1 Then
            Dim oRecordRow As DataGridViewRow = DgvRecords.SelectedRows(0)
            Dim oTrackRow As DataGridViewRow = DgvTracks.Rows(e.RowIndex)
            Dim oRecordId As Integer = oRecordRow.Cells(recId.Name).Value
            Dim oTrackSide As String = oTrackRow.Cells(trkSide.Name).Value
            Dim oTrackTrack As String = oTrackRow.Cells(trkTrack.Name).Value
        End If
    End Sub
    Private Sub DgvTracks_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTracks.SelectionChanged
        If Not isLoading AndAlso DgvRecords.SelectedRows.Count = 1 AndAlso DgvTracks.SelectedRows.Count = 1 Then
            Dim oRecordRow As DataGridViewRow = DgvRecords.SelectedRows(0)
            Dim oTrackRow As DataGridViewRow = DgvTracks.SelectedRows(0)
            Dim oTrack As Track = GetTrackForKey(oRecordRow.Cells(recId.Name).Value, oTrackRow.Cells(trkSide.Name).Value, oTrackRow.Cells(trkTrack.Name).Value)
            LoadTrackForm(oTrack)
        End If
    End Sub
    Private Sub BtnUpdateTrack_Click(sender As Object, e As EventArgs) Handles BtnUpdateTrack.Click
        TrimValues()
        If Not IsValidTrack() Then
            LogUtil.ShowStatus("Invalid values", LblStatus, True, MyBase.Name, True)
        Else
            CurrentTrack = BuildTrackFromForm()
            If UpdateTrack(CurrentTrack) Then
                LogUtil.ShowStatus("Track Updated", LblStatus, MyBase.Name)
            Else
                LogUtil.ShowStatus("Error saving track", LblStatus, True, MyBase.Name, TraceEventType.Error, True)
            End If
            isLoading = True
            LoadTracks(CurrentTrack.RecordId)
            isLoading = False
            ClearTrack()
        End If
    End Sub
    Private Sub BtnDateClear_Click(sender As Object, e As EventArgs) Handles BtnDateClear.Click
        DtpChartDate.Value = DtpChartDate.MinDate
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If Not IsValidRecord() Then
            LogUtil.ShowStatus("Invalid values", LblStatus, MyBase.Name, False, Nothing, True)
        Else
            CurrentRecord = BuildRecordFromForm()
            CurrentRecord.RecordId = CInt(LblRecordId.Text)
            If UpdateRecord(CurrentRecord) Then
                LogUtil.ShowStatus("Record Updated", LblStatus, MyBase.Name)
                LoadRecords()
                FindRecordInList(CurrentRecord.RecordId)
            Else
                LogUtil.ShowStatus("Record not Updated", LblStatus, MyBase.Name)
            End If
        End If
    End Sub

#End Region
#Region "subroutines"

    Private Sub LoadSplitterDistances()
        Try
            If My.Settings.RecSplitDist1 > 0 Then
                SplitContainer1.SplitterDistance = My.Settings.RecSplitDist1
            End If
        Catch ex As Exception
            LogUtil.DisplayException(ex, "Settings", MyBase.Name)
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
        BtnAdd.Visible = True
        BtnUpdate.Visible = False
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
        _row.Cells(recLabelId.Name).Value = pRecord.Label.LabelId
        _row.Cells(recNumber.Name).Value = pRecord.RecordNumber
        Dim _tracks As List(Of Track) = GetTracksForRecord(pRecord.RecordId)
        If _tracks.Count > 0 Then
            _row.Cells(recArtist.Name).Value = _tracks(0).Artist.ArtistName
            _row.Cells(recArtistId.Name).Value = _tracks(0).Artist.ArtistId
        End If
    End Sub
    Private Sub LoadFormatList()
        CbRecordFormat.DataSource = GetAllFormats()
        CbRecordFormat.ValueMember = "FormatId"
        CbRecordFormat.DisplayMember = "FormatName"
        CbRecordFormat.SelectedIndex = -1
    End Sub
    Private Sub LoadLabelList()
        CbRecordLabel.DataSource = GetAllLabels()
        CbRecordLabel.ValueMember = "LabelId"
        CbRecordLabel.DisplayMember = "LabelName"
        CbRecordLabel.SelectedIndex = -1
    End Sub
    Private Sub LoadArtistList()
        CbArtists.DataSource = GetAllArtists()
        CbArtists.ValueMember = "ArtistId"
        CbArtists.DisplayMember = "ArtistName"
        CbArtists.SelectedIndex = -1
    End Sub
    Private Sub LoadGenreList()
        CbGenre.DataSource = GetAllGenres()
        CbGenre.ValueMember = "GenreId"
        CbGenre.DisplayMember = "GenreName"
        CbGenre.SelectedIndex = -1
    End Sub
#End Region

    Private Sub SaveSplitterDistances()
        My.Settings.RecSplitDist1 = SplitContainer1.SplitterDistance
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
    Private Function GetDuplicateRecord() As Record
        Dim oFirstDup As Record = Nothing
        Dim oRecordList As List(Of Record) = GetPossibleMatchingRecords(TxtRecNumber.Text, CbRecordLabel.SelectedValue)
        If oRecordList.Count > 0 Then
            DgvRecords.ClearSelection()
            For Each _duplicate As Record In oRecordList
                For Each oRow As DataGridViewRow In DgvRecords.Rows
                    If oRow.Cells(recId.Name).Value = _duplicate.RecordId Then
                        oRow.Selected = True
                        DgvRecords.FirstDisplayedScrollingRowIndex = Math.Max(0, oRow.Index - 3)
                        If oFirstDup Is Nothing Then
                            oFirstDup = _duplicate
                        End If
                        Exit For
                    End If
                Next
            Next
        End If
        Return oFirstDup
    End Function
    Private Function IsIncrementCopies(_duplicate As Record) As Boolean
        Dim isAddCopy As Boolean = False
        If MsgBox("Looks like this record is already on file" & vbCrLf & "Accept and add a copy?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Match Found") = MsgBoxResult.Yes Then
            LblRecordId.Text = _duplicate.RecordId
            NudCopies.Value = _duplicate.Copies + 1
            isAddCopy = True
        End If
        Return isAddCopy
    End Function
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
        DgvTracks.ClearSelection()
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
    Private Sub NextRecord()
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
        BtnAdd.Visible = True
        BtnUpdate.Visible = False
        SplitContainer2.Panel2Collapsed = True
    End Sub
    Private Sub ClearTrackForm()
        RbA.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
        TxtYear.Text = String.Empty
        CbGenre.SelectedIndex = -1
        CbArtists.SelectedIndex = -1
        TxtChartPos.Text = String.Empty
        DtpChartDate.Value = DtpChartDate.MinDate
        isTrackChanged = False
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
    Private Sub LoadFormFromDgv(pRow As DataGridViewRow)
        CurrentRecord = GetRecordFromId(pRow.Cells(recId.Name).Value)
        LblRecordId.Text = CurrentRecord.RecordId
        CbRecordFormat.SelectedValue = CurrentRecord.RecordFormat.FormatId
        CbRecordLabel.SelectedValue = CurrentRecord.Label.LabelId
        TxtRecNumber.Text = CurrentRecord.RecordNumber
        NudCopies.Value = CurrentRecord.Copies
        CheckSize(CurrentRecord.Size)
        CheckSpeed(CurrentRecord.Speed)
        BtnAdd.Visible = False
        BtnUpdate.Visible = True
        isTrackChanged = False
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
        LogUtil.ClearStatus(LblStatus)
        LblRecordId.Text = -1
        CbRecordFormat.SelectedIndex = -1
        CbRecordLabel.SelectedIndex = -1
        TxtRecNumber.Text = String.Empty
        NudCopies.Value = 1
        Rb7.Checked = True
        Rb45.Checked = True
        ClearTrackForm()
    End Sub

    Private Sub TrimValues()
        TxtTitle.Text = TxtTitle.Text.Replace(vbTab, "").Trim
        TxtYear.Text = TxtYear.Text.Replace(vbTab, "").Trim
    End Sub
    Private Function IsTrackExists(pTrack As Track) As Boolean
        Dim _track As Track
        With pTrack
            _track = GetTrackForKey(.RecordId, .Side, .Track)
        End With
        Return _track.IsExists
    End Function
    Private Sub ClearTrack()
        RbB.Checked = True
        NudTrackNo.Value = 1
        TxtTitle.Text = String.Empty
        TxtChartPos.Text = String.Empty
        isTrackChanged = False
    End Sub
    Private Function BuildTrackFromForm() As Track
        Dim _artist As New Artist
        If CbArtists.SelectedIndex > -1 Then
            _artist = GetArtistFromId(CbArtists.SelectedValue)
        End If
        Dim _genre As New Genre
        If CbGenre.SelectedIndex > -1 Then
            _genre = GetGenreFromId(CbGenre.SelectedValue)
        End If
        Dim _chartpos As Integer = -1
        If Not String.IsNullOrWhiteSpace(TxtChartPos.Text) AndAlso IsNumeric(TxtChartPos.Text) Then
            _chartpos = CInt(TxtChartPos.Text)
        End If
        Dim _chartDate As DateTime? = Nothing
        If _chartpos > 0 Then
            If DtpChartDate.Value > DtpChartDate.MinDate Then
                _chartDate = DtpChartDate.Value
            End If
        End If
        Dim _track As Track = TrackBuilder.ATrack.StartingWithNothing _
            .WithId(CurrentRecord.RecordId) _
            .WithSide(GetSideFromForm) _
            .WithTrack(NudTrackNo.Value) _
            .WithArtist(_artist) _
            .WithTitle(TxtTitle.Text) _
            .WithYear(TxtYear.Text) _
            .WithGenre(_genre) _
            .WithChartPos(_chartpos) _
            .WithChartDate(_chartDate) _
            .Build
        Return _track
    End Function
    Private Function GetSideFromForm() As String
        Dim _side As String = "A"
        Select Case True
            Case RbA.Checked
                _side = "A "
            Case RbB.Checked
                _side = "B "
            Case RbAA.Checked
                _side = "AA"
            Case Rb1.Checked
                _side = "1 "
            Case Rb2.Checked
                _side = "2 "
        End Select
        Return _side
    End Function
    Private Function IsValidTrack() As Boolean
        Dim isOK As Boolean = True
        If String.IsNullOrWhiteSpace(TxtTitle.Text) Then
            isOK = False
        End If
        If CbGenre.SelectedIndex < 0 Then
            isOK = False
        End If
        If CbArtists.SelectedIndex < 0 Then
            isOK = False
        End If
        If Not IsNumeric(TxtYear.Text) Or String.IsNullOrWhiteSpace(TxtYear.Text) Then
            isOK = False
        End If
        Return isOK
    End Function
    Private Sub LoadTrackForm(pTrack As Track)
        With pTrack
            Select Case .Side
                Case "A "
                    RbA.Checked = True
                Case "B "
                    RbB.Checked = True
                Case "AA"
                    RbAA.Checked = True
                Case "1 "
                    Rb1.Checked = True
                Case "2 "
                    Rb2.Checked = True
            End Select
            NudTrackNo.Value = .Track
            CbArtists.SelectedValue = .Artist.ArtistId
            TxtTitle.Text = .Title
            TxtYear.Text = .Year
            CbGenre.SelectedValue = .Genre.GenreId
            TxtChartPos.Text = If(.PeakChartPosition > 0, .PeakChartPosition, "")
            If .ChartDate IsNot Nothing Then
                DtpChartDate.Value = .ChartDate
            End If
        End With
    End Sub
End Class

