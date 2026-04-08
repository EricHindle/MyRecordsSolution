' Hindleware
' Copyright (c) 2024-25 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports HindlewareLib.Logging
Imports MyVinyl.VinylDataSet

Namespace Domain
    Public Module ModDataFunctions
#Region "constants"
        '       Private Const MethodBase.GetCurrentMethod.Name As String = "DataFunctions"
        Friend Const TABLE_TAG As String = "T~"
        Public Const DATA_EXT As String = ".hrx"
        Public Const GENRE_TABLE As String = "Music Genre Table"
        Public Const ARTIST_TABLE As String = "Artists Table"
        Public Const RECORDLABEL_TABLE As String = "Record Labels Table"
        Public Const RECORDFORMAT_TABLE As String = "Record Format Table"
        Public Const RECORD_TABLE As String = "Record Table"
        Public Const TRACKS_TABLE As String = "Tracks Table"
        Public Const SETTINGS_TABLE As String = "Settings Table"
#End Region
#Region "variables"
        Public oDataFolderName As String
#End Region
#Region "enum"
        Public Enum Tables
            Records
            Tracks
            Artists
            RecordLabels
            RecordFormat
            MusicGenre
            Settings
        End Enum
#End Region
#Region "dataset"
        Private ReadOnly oSettingsTable As New settingsDataTable
        Private ReadOnly oRecordsTable As New RecordsDataTable
        Private ReadOnly oRecordLabelsTable As New RecordLabelsDataTable
        Private ReadOnly oRecordFormatTable As New RecordFormatDataTable
        Private ReadOnly oMusicGenreTable As New MusicGenreDataTable
        Private ReadOnly oTracksTable As New TracksDataTable
        Private ReadOnly oArtistsTable As New ArtistsDataTable
        '       Private ReadOnly oRecordTracksView As New vRecordTracksDataTable
        Public tableList As New List(Of String)
#End Region
#Region "common"
        Public Sub InitialiseData()
            LogUtil.Info("Initialising data", MethodBase.GetCurrentMethod.Name)
            FillTableListFromTableEnum()
            oDataFolderName = My.Settings.DataFilePath
            Try
                LoadDataTables()
            Catch ex As ApplicationException
                LogUtil.DisplayException(ex, "Loading Data", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub
        Public Sub FillTableTree(ByRef tvtables As TreeView)
            tvtables.Nodes.Clear()
            tvtables.Nodes.Add("Tables")
            For Each oTable As String In tableList
                If Not oTable.Equals("Files") Then
                    tvtables.Nodes(0).Nodes.Add(TABLE_TAG & oTable, oTable)
                End If
            Next
        End Sub
        Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
            Dim rowCount As Integer = 0
            Try
                LoadDataTableFromXml(tableType, datapath)
                Select Case tableType
                    Case "Settings"
                        WriteXmlFromTable(oSettingsTable)
                        rowCount = oSettingsTable.Rows.Count
                    Case "Tracks"
                        WriteXmlFromTable(oTracksTable)
                        rowCount = oTracksTable.Rows.Count
                    Case "Records"
                        WriteXmlFromTable(oRecordsTable)
                        rowCount = oRecordsTable.Rows.Count
                    Case "RecordFormat"
                        WriteXmlFromTable(oRecordFormatTable)
                        rowCount = oRecordFormatTable.Rows.Count
                    Case "RecordLabels"
                        WriteXmlFromTable(oRecordLabelsTable)
                        rowCount = oRecordLabelsTable.Rows.Count
                    Case "Artists"
                        WriteXmlFromTable(oArtistsTable)
                        rowCount = oArtistsTable.Rows.Count
                    Case "MusicGenres"
                        WriteXmlFromTable(oMusicGenreTable)
                        rowCount = oMusicGenreTable.Rows.Count
                End Select
            Catch ex As Exception
                MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
            End Try
            Return rowCount
        End Function
        Private Function GetMessage(ex As Exception) As String
            Return If(ex Is Nothing, "", "Exception:  " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message))
        End Function
#End Region
#Region "Tables"
        Public Sub LoadDataTables()
            LogUtil.LogInfo("Loading Data Tables", MethodBase.GetCurrentMethod.Name)
            Try
                For Each oTable As String In tableList
                    LoadDataTableFromXml(oTable)
                Next
                LogUtil.LogInfo("Data Loaded OK", MethodBase.GetCurrentMethod.Name)
            Catch ex As ApplicationException
                Throw ex
            End Try
        End Sub
        'Public Sub LoadRecordView()
        '    oRecordTracksView.Rows.Clear()
        '    For Each oRow As RecordsRow In oRecordsTable.Rows
        '        Dim oFullRecord As FullRecord = FullRecordBuilder.AFullRecord.StartingWith(oRow.RecordId).Build
        '        Dim oViewRow As vRecordTracksRow = oRecordTracksView.NewRow
        '        For Each _track As Track In oFullRecord.Tracks
        '            oViewRow = SetViewRowValues(oFullRecord.Record, _track, oViewRow)
        '            oRecordTracksView.Rows.Add(oViewRow)
        '        Next
        '    Next
        'End Sub

        Public Sub FillTableListFromTableEnum()
            tableList.Clear()
            Dim _enumArray As Array = [Enum].GetValues(GetType(Tables))
            For Each _enum In _enumArray
                tableList.Add(_enum.ToString)
            Next
        End Sub
        Public Sub LoadDataTableFromXml(pTable As String)
            Dim oFolder As String = oDataFolderName
            CreateFolder(oDataFolderName, True)
            LoadDataTableFromXml(pTable, oFolder)
        End Sub
        Public Sub LoadDataTableFromXml(otable As String, pFolder As String)
            LogUtil.Debug("Loading table " & otable, MethodBase.GetCurrentMethod.Name)
            Dim oXmlFileName As String
            If My.Computer.FileSystem.DirectoryExists(pFolder) Then
                Select Case otable
                    Case "Records"
                        oXmlFileName = Path.Combine(pFolder, oRecordsTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oRecordsTable.Clear()
                            oRecordsTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Records data file missing.")
                        End If
                    Case "Tracks"
                        oXmlFileName = Path.Combine(pFolder, oTracksTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oTracksTable.Clear()
                            oTracksTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Tracks data file missing.")
                        End If
                    Case "Artists"
                        oXmlFileName = Path.Combine(pFolder, oArtistsTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oArtistsTable.Clear()
                            oArtistsTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Projects data file missing.")
                        End If
                    Case "RecordLabels"
                        oXmlFileName = Path.Combine(pFolder, oRecordLabelsTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oRecordLabelsTable.Clear()
                            oRecordLabelsTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Projects data file missing.")
                        End If
                    Case "RecordFormat"
                        oXmlFileName = Path.Combine(pFolder, oRecordFormatTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oRecordFormatTable.Clear()
                            oRecordFormatTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Projects data file missing.")
                        End If
                    Case "MusicGenre"
                        oXmlFileName = Path.Combine(pFolder, oMusicGenreTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oMusicGenreTable.Clear()
                            oMusicGenreTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Projects data file missing.")
                        End If
                    Case "Settings"
                        oXmlFileName = Path.Combine(pFolder, oSettingsTable.TableName & DATA_EXT)
                        If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            oSettingsTable.Clear()
                            oSettingsTable.ReadXml(oXmlFileName)
                        Else
                            Throw New ApplicationException("Projects data file missing.")
                        End If
                    Case Else
                        LogUtil.LogInfo("Unknown table " & otable & " cannot be loaded", MethodBase.GetCurrentMethod.Name)
                End Select
            Else
                Throw New ApplicationException("Restore folder missing.")
            End If
        End Sub
        Private Function WriteXmlFromTable(pDataTable As DataTable) As String
            Dim sTableName As String = pDataTable.TableName
            LogUtil.Debug("Writing XML file", MethodBase.GetCurrentMethod.Name)
            Dim sTableFile As String
            Try
                sTableFile = Path.Combine(oDataFolderName, sTableName & DATA_EXT)
                pDataTable.WriteXml(sTableFile, XmlWriteMode.WriteSchema)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is InvalidOperationException)
                LogUtil.HandleStatus("Error saving " & sTableName, ex, False, Nothing, Nothing, True, MethodBase.GetCurrentMethod.Name, TraceEventType.Critical, "", 3, False, False, True)
                Throw New ApplicationException("Problem writing XML file for " & sTableName, ex)
            End Try
            Return sTableFile
        End Function
        Public Sub CreateFolder(pFoldername As String, pAllowLogging As Boolean)
            If Not My.Computer.FileSystem.DirectoryExists(pFoldername) Then
                If pAllowLogging Then
                    LogUtil.LogInfo("Creating " & pFoldername, MethodBase.GetCurrentMethod.Name)
                End If
                Try
                    My.Computer.FileSystem.CreateDirectory(pFoldername)
                Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IO.PathTooLongException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException)
                    If pAllowLogging Then
                        LogUtil.DisplayException(ex, "Create Folder", MethodBase.GetCurrentMethod.Name)
                    End If
                    Throw New ApplicationException("CreateDirectory Failed for " & pFoldername, ex)
                End Try
            End If
        End Sub
#End Region
#Region "Record"
        Public Function GetRecordsTable() As RecordsDataTable
            Return oRecordsTable
        End Function
        Public Function GetAllRecords() As List(Of Record)
            LogUtil.Info("Getting Records", MethodBase.GetCurrentMethod.Name)
            Dim oList As New List(Of Record)
            Try
                For Each oRow As RecordsRow In oRecordsTable.Rows
                    oList.Add(RecordBuilder.ARecord.StartingWith(oRow).Build)
                Next
                oList.Sort()
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oList
        End Function
        Public Function GetRecordFromId(pId As Integer) As Record
            LogUtil.Debug("Getting Record " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oRecord As New Record
            Try
                Dim oRecordRows = From Record In oRecordsTable.AsEnumerable()
                                  Select Record
                                  Where Record.RecordId = pId
                If oRecordRows.Count > 0 Then
                    oRecord = RecordBuilder.ARecord.StartingWith(oRecordRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oRecord
        End Function
        Public Function GetRecordRowFromId(pId As Integer) As RecordsRow
            LogUtil.Debug("Getting Record Row " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oRecord As RecordsRow = Nothing
            Try
                Dim oRecordRows = From Record In oRecordsTable.AsEnumerable()
                                  Select Record
                                  Where Record.RecordId = pId
                If oRecordRows.Count > 0 Then
                    oRecord = oRecordRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oRecord
        End Function
        Public Function GetRecordsByLabelAndNumber(pRecordNo As String, pLabelId As Integer) As List(Of Record)
            LogUtil.Debug("Getting Record " & pRecordNo, MethodBase.GetCurrentMethod.Name)
            Dim oRecords As New List(Of Record)
            Try
                Dim oRecordRows = From Record In oRecordsTable.AsEnumerable()
                                  Select Record
                                  Where Record.RecordNo = pRecordNo And Record.Label = pLabelId
                For Each _recordRow As RecordsRow In oRecordRows
                    oRecords.Add(RecordBuilder.ARecord.StartingWith(oRecordRows.First).Build)
                Next
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oRecords
        End Function
        Public Function InsertRecord(pRecord As Record) As Integer
            LogUtil.Info("Inserting Record " & CStr(pRecord.RecordNumber), MethodBase.GetCurrentMethod.Name)
            Try
                With pRecord
                    Dim oRecordRow As RecordsRow = oRecordsTable.NewRow
                    pRecord.RecordId = oRecordRow.RecordId
                    oRecordRow = SetRecordRowValues(pRecord, oRecordRow)
                    oRecordsTable.Rows.Add(oRecordRow)
                    WriteXmlFromTable(oRecordsTable)
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return pRecord.RecordId
        End Function
        Public Function UpdateRecord(pRecord As Record) As Integer
            LogUtil.Info("Updating Record", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pRecord IsNot Nothing Then
                Try
                    Dim oRecordRow As RecordsRow = GetRecordRowFromId(pRecord.RecordId)
                    If oRecordRow IsNot Nothing Then
                        SetRecordRowValues(pRecord, oRecordRow)
                        WriteXmlFromTable(oRecordsTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, RECORD_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null Record", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Public Function UpdateRecordCopies(pRecord As Record) As Integer
            LogUtil.Info("Updating Record Copies", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pRecord IsNot Nothing Then
                Try
                    Dim oRecordRow As RecordsRow = GetRecordRowFromId(pRecord.RecordId)
                    If oRecordRow IsNot Nothing Then
                        oRecordRow.Copies = pRecord.Copies
                        WriteXmlFromTable(oRecordsTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, RECORD_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null Record", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function

        Private Function SetRecordRowValues(pRecord As Record, pRecordRow As RecordsRow) As RecordsRow
            With pRecord
                pRecordRow.RecordId = .RecordId
                pRecordRow.RecordNo = .RecordNumber
                pRecordRow.Copies = .Copies
                pRecordRow.Format = .RecordFormat.FormatId
                pRecordRow.Size = .Size
                pRecordRow.Label = .Label.LabelId
                pRecordRow.Speed = .Speed
            End With
            Return pRecordRow
        End Function
#End Region
#Region "Track"
        Public Function GetTracksTable() As VinylDataSet.TracksDataTable
            LogUtil.Info("Getting tracks table", MethodBase.GetCurrentMethod.Name)
            Return oTracksTable
        End Function
        Public Function InsertTrack(pTrack As Track) As Integer
            LogUtil.Info("Inserting Track", MethodBase.GetCurrentMethod.Name)
            Dim isInserted As Boolean = False
            Try
                With pTrack
                    Dim oTrackRow As TracksRow = oTracksTable.NewRow
                    oTrackRow = SetTrackRowValues(pTrack, oTrackRow)
                    oTracksTable.Rows.Add(oTrackRow)
                    WriteXmlFromTable(oTracksTable)
                    isInserted = True
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return isInserted
        End Function
        Private Function SetTrackRowValues(pTrack As Track, pTrackRow As TracksRow) As TracksRow
            With pTrack
                pTrackRow.RecordId = .RecordId
                pTrackRow.Side = .Side
                pTrackRow.Track = .Track
                pTrackRow.Title = .Title
                pTrackRow.Year = .Year
                pTrackRow.Genre = .Genre.GenreId
                pTrackRow.ArtistId = .Artist.ArtistId
                pTrackRow.PeakChartPosition = .PeakChartPosition
                If .ChartDate IsNot Nothing Then
                    pTrackRow.ChartDate = .ChartDate
                End If
            End With
            Return pTrackRow
        End Function
        Public Function UpdateTrack(pTrack As Track) As Integer
            LogUtil.Info("Updating Track", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pTrack IsNot Nothing Then
                Try
                    Dim oTrackRow As TracksRow = GetTrackRowForKey(pTrack.RecordId, pTrack.Side, pTrack.Track)
                    If oTrackRow IsNot Nothing Then
                        SetTrackRowValues(pTrack, oTrackRow)
                        WriteXmlFromTable(oTracksTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, TRACKS_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null Track", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Public Function GetTracksForRecord(pId As Integer) As List(Of Track)
            LogUtil.Debug("Getting Tracks for " & pId, MethodBase.GetCurrentMethod.Name)
            Dim _results As New List(Of Track)
            Try
                Dim oTrackRows = From Track In oTracksTable.AsEnumerable()
                                 Select Track
                                 Where Track.RecordId = pId
                For Each orow As TracksRow In oTrackRows
                    Dim _result As Track = TrackBuilder.ATrack.StartingWith(orow).Build
                    If _result.IsExists Then
                        _results.Add(_result)
                    End If
                Next
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return _results
        End Function
        Public Function GetTracksForSearch(pArtistId As Integer, pLabelId As Integer, pRecordNumber As String, pTitle As String, pYear As Integer, pGenreId As Integer) As List(Of FullRecord)
            Dim _list As New List(Of FullRecord)
            For Each oRow As RecordsRow In oRecordsTable.Rows
                If pLabelId = -1 OrElse oRow.Label = pLabelId Then
                    If String.IsNullOrEmpty(pRecordNumber) OrElse oRow.RecordNo = pRecordNumber Then
                        Dim oFullRecord As FullRecord = FullRecordBuilder.AFullRecord.StartingWith(oRow.RecordId).Build
                        For Each _track In oFullRecord.Tracks
                            If pArtistId = -1 OrElse _track.Artist.ArtistId = pArtistId Then
                                If String.IsNullOrEmpty(pTitle) OrElse _track.Title = pTitle Then
                                    If pYear = -1 OrElse _track.Year = pYear Then
                                        If pGenreId = -1 OrElse _track.Genre.GenreId = pGenreId Then
                                            Dim _fullTrack As FullRecord = FullRecordBuilder.AFullRecord.StartingWith(_track.RecordId, _track.Side, _track.Track).Build
                                            _list.Add(_fullTrack)
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            Return _list

        End Function
        Public Function GetTrackForKey(pRecordId As Integer, pSide As String, pTrackNo As Integer) As Track
            Dim _track As New Track
            Try
                Dim _trackRow As TracksRow = GetTrackRowForKey(pRecordId, pSide, pTrackNo)
                If _trackRow IsNot Nothing Then
                    _track = TrackBuilder.ATrack.StartingWith(_trackRow).Build
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return _track
        End Function
        Public Function GetTrackRowForKey(pRecordId As Integer, pSide As String, pTrackNo As Integer) As TracksRow
            Dim _track As TracksRow = Nothing
            Try
                Dim oTrackRows = From Track In oTracksTable.AsEnumerable()
                                 Select Track
                                 Where Track.RecordId = pRecordId And Track.Side = pSide And Track.Track = pTrackNo
                If oTrackRows.Count > 0 Then
                    _track = oTrackRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return _track
        End Function
#End Region
#Region "Artist"
        Public Function GetArtistsTable() As VinylDataSet.ArtistsDataTable
            LogUtil.Info("Getting artists table", MethodBase.GetCurrentMethod.Name)
            Return oArtistsTable
        End Function
        Public Function GetArtistFromId(pId As Integer) As Artist
            LogUtil.Debug("Getting Artist " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oArtist As New Artist
            Try
                Dim oArtistRows = From Artist In oArtistsTable.AsEnumerable()
                                  Select Artist
                                  Where Artist.ArtistId = pId

                If oArtistRows.Count > 0 Then
                    oArtist = ArtistBuilder.AnArtist.StartingWith(oArtistRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oArtist
        End Function
        Public Function GetArtistFromName(pName As String) As Artist
            LogUtil.Debug("Getting Artist " & pName, MethodBase.GetCurrentMethod.Name)
            Dim oArtist As New Artist
            Try
                Dim oArtistRows = From Artist In oArtistsTable.AsEnumerable()
                                  Select Artist
                                  Where Artist.ArtistName = pName
                If oArtistRows.Count > 0 Then
                    oArtist = ArtistBuilder.AnArtist.StartingWith(oArtistsTable.Rows(0)).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oArtist
        End Function
        Public Function InsertArtist(pArtist As Artist) As Integer
            LogUtil.Info("Inserting Artist " & CStr(pArtist.ArtistName), MethodBase.GetCurrentMethod.Name)
            Dim response As Integer = -1
            Try
                With pArtist
                    Dim oArtistRow As ArtistsRow = oArtistsTable.NewRow
                    oArtistRow = SetArtistRowValues(pArtist, oArtistRow)
                    response = oArtistRow.ArtistId
                    oArtistsTable.Rows.Add(oArtistRow)
                    WriteXmlFromTable(oArtistsTable)
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return response
        End Function
        Public Function UpdateArtist(pArtist As Artist) As Integer
            LogUtil.Info("Updating Artist " & pArtist.ArtistName, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pArtist IsNot Nothing Then
                Try
                    Dim oArtistRow As ArtistsRow = GetArtistRow(pArtist.ArtistId)
                    If oArtistRow IsNot Nothing Then
                        SetArtistRowValues(pArtist, oArtistRow)
                        WriteXmlFromTable(oArtistsTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, ARTIST_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null Artist", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetArtistRowValues(pArtist As Artist, pArtistRow As ArtistsRow) As ArtistsRow
            With pArtist
                pArtistRow.ArtistName = .ArtistName
            End With
            Return pArtistRow
        End Function
        Public Function GetAllArtists() As List(Of Artist)
            LogUtil.Info("Getting artists", MethodBase.GetCurrentMethod.Name)
            Dim oList As New List(Of Artist)
            Try
                For Each oRow As ArtistsRow In oArtistsTable.Rows
                    oList.Add(ArtistBuilder.AnArtist.StartingWith(oRow).Build)
                Next
                oList.Sort()
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oList
        End Function
        Public Function GetArtistRow(pArtistId As Integer) As ArtistsRow
            Dim oArtistRow As ArtistsRow = Nothing
            Try
                Dim oArtistRows = From Artist In oArtistsTable.AsEnumerable()
                                  Select Artist
                                  Where Artist.ArtistId = pArtistId
                If oArtistRows.Count = 1 Then
                    oArtistRow = oArtistRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, ARTIST_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return oArtistRow
        End Function
#End Region
#Region "Label"
        Public Function GetRecordLabelsTable() As VinylDataSet.RecordLabelsDataTable
            LogUtil.Info("Getting record format table", MethodBase.GetCurrentMethod.Name)
            Return oRecordLabelsTable
        End Function
        Public Function GetLabelbyId(pId As Integer) As RecordLabel
            LogUtil.Debug("Getting Label " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oLabel As New RecordLabel
            Try
                Dim oLabelRows = From Label In oRecordLabelsTable.AsEnumerable()
                                 Select Label
                                 Where Label.LabelId = pId
                If oLabelRows.Count > 0 Then
                    oLabel = RecordLabelBuilder.ARecordLabel.StartingWith(oLabelRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oLabel
        End Function
        Public Function InsertLabel(pLabel As RecordLabel) As Integer
            LogUtil.Info("Inserting Record Label " & CStr(pLabel.LabelName), MethodBase.GetCurrentMethod.Name)
            Dim response As Integer = -1
            Try
                With pLabel
                    Dim oLabelRow As RecordLabelsRow = oRecordLabelsTable.NewRow
                    oLabelRow = SetLabelRowValues(pLabel, oLabelRow)
                    response = oLabelRow.LabelId
                    oRecordLabelsTable.Rows.Add(oLabelRow)
                    WriteXmlFromTable(oRecordLabelsTable)
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return response
        End Function
        Public Function UpdateLabel(pLabel As RecordLabel) As Integer
            LogUtil.Info("Updating RecordLabel " & pLabel.LabelName, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pLabel IsNot Nothing Then
                Try
                    Dim oLabelRow As RecordLabelsRow = GetLabelRow(pLabel.LabelId)
                    If oLabelRow IsNot Nothing Then
                        SetLabelRowValues(pLabel, oLabelRow)
                        WriteXmlFromTable(oRecordLabelsTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, RECORDLABEL_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null RecordLabel", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetLabelRowValues(pLabel As RecordLabel, pLabelRow As RecordLabelsRow) As RecordLabelsRow
            With pLabel
                pLabelRow.LabelName = .LabelName
            End With
            Return pLabelRow
        End Function
        Public Function GetLabelRow(pLabelId As Integer) As RecordLabelsRow
            Dim oLabelRow As RecordLabelsRow = Nothing
            Try
                Dim oLabelRows = From RecordLabel In oRecordLabelsTable.AsEnumerable()
                                 Select RecordLabel
                                 Where RecordLabel.LabelId = pLabelId
                If oLabelRows.Count = 1 Then
                    oLabelRow = oLabelRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, RECORDLABEL_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return oLabelRow
        End Function
        Public Function GetAllLabels() As List(Of RecordLabel)
            LogUtil.Info("Getting Labels", MethodBase.GetCurrentMethod.Name)
            Dim oList As New List(Of RecordLabel)
            Try
                For Each oRow As RecordLabelsRow In oRecordLabelsTable.Rows
                    oList.Add(RecordLabelBuilder.ARecordLabel.StartingWith(oRow).Build)
                Next
                oList.Sort()
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oList
        End Function
        Public Function GetLabelFromName(pName As String) As RecordLabel
            LogUtil.Debug("Getting Label " & pName, MethodBase.GetCurrentMethod.Name)
            Dim oLabel As New RecordLabel
            Try
                Dim oLabelRows = From Label In oRecordLabelsTable.AsEnumerable()
                                 Select Label
                                 Where Label.LabelName = pName
                If oLabelRows.Count > 0 Then
                    oLabel = RecordLabelBuilder.ARecordLabel.StartingWith(oRecordLabelsTable.Rows(0)).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oLabel
        End Function
#End Region
#Region "Genre"
        Public Function GetMusicGenreTable() As MusicGenreDataTable
            LogUtil.Info("Getting music genre table", MethodBase.GetCurrentMethod.Name)
            Return oMusicGenreTable
        End Function
        Public Function GetGenreFromId(pId As Integer) As Genre
            LogUtil.Debug("Getting Genre " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oGenre As New Genre
            Try
                Dim oGenreRows = From Genre In oMusicGenreTable.AsEnumerable()
                                 Select Genre
                                 Where Genre.GenreId = pId

                If oGenreRows.Count > 0 Then
                    oGenre = GenreBuilder.AGenre.StartingWith(oGenreRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oGenre
        End Function
        Public Function GetGenreFromName(pName As String) As Genre
            LogUtil.Debug("Getting Genre " & pName, MethodBase.GetCurrentMethod.Name)
            Dim oGenre As New Genre
            Try
                Dim oGenreRows = From Genre In oMusicGenreTable.AsEnumerable()
                                 Select Genre
                                 Where Genre.GenreName = pName

                If oGenreRows.Count > 0 Then
                    oGenre = GenreBuilder.AGenre.StartingWith(oMusicGenreTable.Rows(0)).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oGenre
        End Function
        Public Function InsertGenre(pGenre As Genre) As Integer
            LogUtil.Info("Inserting Genre " & CStr(pGenre.GenreId), MethodBase.GetCurrentMethod.Name)
            Dim response As Integer = -1
            Try
                With pGenre
                    Dim oGenreRow As MusicGenreRow = oMusicGenreTable.NewRow
                    oGenreRow = SetGenreRowValues(pGenre, oGenreRow)
                    response = oGenreRow.GenreId
                    oMusicGenreTable.Rows.Add(oGenreRow)
                    WriteXmlFromTable(oMusicGenreTable)
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return response
        End Function
        Public Function UpdateGenre(pGenre As Genre) As Boolean
            LogUtil.Info("Updating Genre " & pGenre.GenreName, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pGenre IsNot Nothing Then
                Try
                    Dim oGenreRow As MusicGenreRow = GetGenreRow(pGenre.GenreId)
                    If oGenreRow IsNot Nothing Then
                        SetGenreRowValues(pGenre, oGenreRow)
                        WriteXmlFromTable(oMusicGenreTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, GENRE_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null Genre", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Public Function GetAllGenres() As List(Of Genre)
            LogUtil.Info("Getting Genres", MethodBase.GetCurrentMethod.Name)
            Dim oList As New List(Of Genre)
            Try
                For Each oRow As MusicGenreRow In oMusicGenreTable.Rows
                    oList.Add(GenreBuilder.AGenre.StartingWith(oRow).Build)
                Next
                oList.Sort()
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oList
        End Function
        Public Function GetGenreRow(pGenreId As Integer) As MusicGenreRow
            Dim oGenreRow As MusicGenreRow = Nothing
            Try
                Dim oGenreRows = From Genre In oMusicGenreTable.AsEnumerable()
                                 Select Genre
                                 Where Genre.GenreId = pGenreId
                If oGenreRows.Count = 1 Then
                    oGenreRow = oGenreRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, GENRE_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return oGenreRow
        End Function
        Private Function SetGenreRowValues(pGenre As Genre, pGenreRow As MusicGenreRow) As MusicGenreRow
            With pGenre
                pGenreRow.GenreName = .GenreName
            End With
            Return pGenreRow
        End Function
#End Region
#Region "Format"
        Public Function GetRecordFormatTable() As RecordFormatDataTable
            LogUtil.Info("Getting record format table", MethodBase.GetCurrentMethod.Name)
            Return oRecordFormatTable
        End Function
        Public Function GetFormatFromId(pId As String) As RecordFormat
            LogUtil.Debug("Getting Format " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oFormat As New RecordFormat
            Try
                Dim oFormatRows = From Format In oRecordFormatTable.AsEnumerable()
                                  Select Format
                                  Where Format.FormatId = pId
                If oFormatRows.Count > 0 Then
                    oFormat = RecordFormatBuilder.ARecordFormat.StartingWith(oFormatRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oFormat
        End Function

        Public Function InsertFormat(pFormat As RecordFormat) As Boolean
            LogUtil.Info("Inserting Record Format " & CStr(pFormat.FormatName), MethodBase.GetCurrentMethod.Name)
            Dim response As Boolean = False
            Try
                With pFormat
                    Dim oFormatRow As RecordFormatRow = oRecordFormatTable.NewRow
                    oFormatRow = SetFormatRowValues(pFormat, oFormatRow)
                    oRecordFormatTable.Rows.Add(oFormatRow)
                    WriteXmlFromTable(oRecordFormatTable)
                    response = True
                End With
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return response
        End Function
        Public Function UpdateFormat(pFormat As RecordFormat) As Integer
            LogUtil.Info("Updating RecordFormat " & pFormat.FormatName, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            If pFormat IsNot Nothing Then
                Try
                    Dim oFormatRow As RecordFormatRow = GetFormatRow(pFormat.FormatId)
                    If oFormatRow IsNot Nothing Then
                        SetFormatRowValues(pFormat, oFormatRow)
                        WriteXmlFromTable(oRecordFormatTable)
                        isUpdated = True
                    End If
                Catch ex As Exception
                    LogUtil.DisplayException(ex, RECORDFORMAT_TABLE, MethodBase.GetCurrentMethod.Name)
                End Try
            Else
                LogUtil.Problem("Trying to change null RecordFormat", MethodBase.GetCurrentMethod.Name)
            End If
            Return isUpdated
        End Function
        Private Function SetFormatRowValues(pFormat As RecordFormat, pFormatRow As RecordFormatRow) As RecordFormatRow
            With pFormat
                pFormatRow.FormatName = .FormatName
                pFormatRow.FormatId = .FormatId
            End With
            Return pFormatRow
        End Function
        Public Function GetFormatRow(pFormatId As Integer) As RecordFormatRow
            Dim oFormatRow As RecordFormatRow = Nothing
            Try
                Dim oFormatRows = From RecordFormat In oRecordFormatTable.AsEnumerable()
                                  Select RecordFormat
                                  Where RecordFormat.FormatId = pFormatId
                If oFormatRows.Count = 1 Then
                    oFormatRow = oFormatRows.First
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, RECORDFORMAT_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return oFormatRow
        End Function
        Public Function GetAllFormats() As List(Of RecordFormat)
            LogUtil.Info("Getting Formats", MethodBase.GetCurrentMethod.Name)
            Dim oList As New List(Of RecordFormat)
            Try
                For Each oRow As RecordFormatRow In oRecordFormatTable.Rows
                    oList.Add(RecordFormatBuilder.ARecordFormat.StartingWith(oRow).Build)
                Next
            Catch ex As Exception
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oList
        End Function
        Public Function GetFormatFromName(pName As String) As RecordFormat
            LogUtil.Debug("Getting Format " & pName, MethodBase.GetCurrentMethod.Name)
            Dim oFormat As New RecordFormat
            Try
                Dim oFormatRows = From Format In oRecordFormatTable.AsEnumerable()
                                  Select Format
                                  Where Format.FormatName = pName
                If oFormatRows.Count > 0 Then
                    oFormat = RecordFormatBuilder.ARecordFormat.StartingWith(oRecordFormatTable.Rows(0)).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oFormat
        End Function
#End Region
#Region "settings"
        Public Function GetSettingsTable() As settingsDataTable
            LogUtil.Info("Getting settings table", MethodBase.GetCurrentMethod.Name)
            Return oSettingsTable
        End Function
        '    '  <--ToDo -->
        'Public Function GetSettingByName(settingName As String) As GlobalSetting
        '    '        Return GetSettingByName(settingName, "", "")
        'End Function
        '    '  <--ToDo -->
        'Public Function GetSettingByName(settingName As String, defaultValue As String, defaultType As String) As GlobalSetting
        '    '        LogUtil.Info("Get setting " & settingName, MethodBase.GetCurrentMethod.Name)
        '    '        Dim rtnValue As GlobalSetting = GlobalSettingBuilder.AGlobalSetting.StartingWithNothing _
        '    '                                                                            .WithName(settingName) _
        '    '                                                                            .WithValue(defaultValue) _
        '    '                                                                            .WithType(defaultType).Build
        '    '        Try
        '    '            If oSettingsTa.FillByName(oSettingsTable, settingName) = 1 Then
        '    '                Dim oRow As RecordsDataSet.settingsRow = oSettingsTable.Rows(0)
        '    '                rtnValue = GlobalSettingBuilder.AGlobalSetting.StartingWith(oRow).Build
        '    '            End If
        '    '        Catch ex As Exception
        '    '            LogUtil.Exception("Exception getting setting " & settingName, ex, MethodBase.GetCurrentMethod.Name)
        '    '        End Try
        '    '        Return rtnValue
        'End Function
        '    '  <--ToDo -->
        'Public Function IsSettingExists(settingName As String) As Boolean
        '    '        LogUtil.Info("Find setting " & settingName, MethodBase.GetCurrentMethod.Name)
        '    '        Dim isFound As Boolean
        '    '        Try
        '    '            oSettingsTa.FillByName(oSettingsTable, settingName)
        '    '            isFound = oSettingsTable.Rows.Count > 0
        '    '        Catch ex As Exception
        '    '            isFound = False
        '    '        End Try
        '    '        Return isFound
        'End Function
        '    '  <--ToDo -->
        'Public Function ChangeSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        '    '        LogUtil.Info("Change setting " & settingName, MethodBase.GetCurrentMethod.Name)
        '    '        Dim rtnVal As Boolean
        '    '        Try
        '    '            rtnVal = oSettingsTa.UpdateSetting(settingValue, settingType, settingGroup, settingName) = 1
        '    '        Catch ex As DbException
        '    '            rtnVal = False
        '    '        End Try
        '    '        Return rtnVal
        'End Function
        '    '  <--ToDo -->
        'Public Function AddSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        '    '        LogUtil.Info("Add setting " & settingName, MethodBase.GetCurrentMethod.Name)
        '    '        Dim rtnVal As Boolean
        '    '        Try
        '    '            Dim _ct As Integer = oSettingsTa.InsertSetting(settingName, settingValue, settingType, settingGroup)
        '    '            rtnVal = _ct = 1
        '    '        Catch ex As DbException
        '    '            rtnVal = False
        '    '        End Try
        '    '        Return rtnVal
        'End Function
        '    '  <--ToDo -->
        'Public Function GetSettingGroupRows(pGroup As String) As DataRowCollection
        '    '        Dim oRows As DataRowCollection = Nothing
        '    '        If oSettingsTa.FillByGroup(oSettingsTable, pGroup) > 0 Then
        '    '            oRows = oSettingsTable.Rows
        '    '        End If
        '    '        Return oRows
        'End Function
#End Region

    End Module
End Namespace