' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging


Public Module ModDataFunctions
#Region "constants"
    Private Const MODULE_NAME As String = "DataFunctions"
    Friend Const TABLE_TAG As String = "T~"

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
    Private ReadOnly oSettingsTa As New RecordsDataSetTableAdapters.settingsTableAdapter
    Private ReadOnly oSettingsTable As New RecordsDataSet.settingsDataTable
    Private ReadOnly oRecordsTa As New RecordsDataSetTableAdapters.RecordsTableAdapter
    Private ReadOnly oRecordsTable As New RecordsDataSet.RecordsDataTable

    Private ReadOnly oRecordLabelsTa As New RecordsDataSetTableAdapters.RecordLabelsTableAdapter
    Private ReadOnly oRecordLabelsTable As New RecordsDataSet.RecordLabelsDataTable

    Private ReadOnly oRecordFormatTa As New RecordsDataSetTableAdapters.RecordFormatTableAdapter
    Private ReadOnly oRecordFormatTable As New RecordsDataSet.RecordFormatDataTable

    Private ReadOnly oMusicGenreTa As New RecordsDataSetTableAdapters.MusicGenreTableAdapter
    Private ReadOnly oMusicGenreTable As New RecordsDataSet.MusicGenreDataTable

    Private ReadOnly oTracksTa As New RecordsDataSetTableAdapters.TracksTableAdapter
    Private ReadOnly oTracksTable As New RecordsDataSet.TracksDataTable

    Private ReadOnly oArtistsTa As New RecordsDataSetTableAdapters.ArtistsTableAdapter
    Private ReadOnly oArtistsTable As New RecordsDataSet.ArtistsDataTable

    Private ReadOnly oRecordTracksViewTa As New RecordsDataSetTableAdapters.vRecordTracksTableAdapter
    Private ReadOnly oRecordTracksViewTable As New RecordsDataSet.vRecordTracksDataTable
#End Region
#Region "variables"
    Public tableList As New List(Of String)
    Public auditActionList As New List(Of String)
#End Region
#Region "common"
    Public Sub InitialiseData()
        LogUtil.Info("Initialising data", MODULE_NAME)
        Dim _enumArray As Array
        _enumArray = [Enum].GetValues(GetType(Tables))
        For Each _enum In _enumArray
            tableList.Add(_enum.ToString)
        Next
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
    Public Sub BackupDataTable(backupDataTable As DataTable, datapath As String)
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = datapath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        backupDataTable.WriteXml(sBackupFile, XmlWriteMode.WriteSchema)
    End Sub
    Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
        Return RestoreDataTable(tableType, datapath, False)
    End Function
    Public Function RestoreDataTable(tableType As String, datapath As String, isSuppressMessage As Boolean) As Integer
        Dim rowCount As Integer = 0
        Try
            Select Case tableType
                Case "Settings"
                    If RecreateTable(oSettingsTable, datapath, isSuppressMessage) Then
                        oSettingsTa.TruncateSettings()
                        oSettingsTa.Update(oSettingsTable)
                        rowCount = oSettingsTa.GetData.Rows.Count
                    End If
                Case "Tracks"
                    If RecreateTable(oTracksTable, datapath, isSuppressMessage) Then
                        oTracksTa.TruncateTracks()
                        oTracksTa.Update(oTracksTable)
                        rowCount = oTracksTa.GetData.Rows.Count
                    End If
                Case "Records"
                    If RecreateTable(oRecordsTable, datapath, isSuppressMessage) Then
                        oRecordsTa.TruncateRecords()
                        rowCount = oRecordsTa.GetData.Rows.Count
                    End If
                Case "RecordFormat"
                    If RecreateTable(oRecordFormatTable, datapath, isSuppressMessage) Then
                        oRecordFormatTa.TruncateRecordFormat()
                        oRecordFormatTa.Update(oRecordFormatTable)
                        rowCount = oRecordFormatTa.GetData.Rows.Count
                    End If
                Case "RecordLabels"
                    If RecreateTable(oRecordLabelsTable, datapath, isSuppressMessage) Then
                        oRecordLabelsTa.TruncateRecordLabels()
                        For Each _row As RecordsDataSet.RecordLabelsRow In oRecordsTable.Rows
                            Dim _recordLabel As RecordLabel = RecordLabelBuilder.ARecordLabel.StartingWith(_row).Build
                            InsertLabel(_recordLabel, _recordLabel.LabelId)
                        Next
                        rowCount = oRecordLabelsTa.GetData.Rows.Count
                    End If
                Case "Artists"
                    If RecreateTable(oArtistsTable, datapath, isSuppressMessage) Then
                        oArtistsTa.TruncateArtists()
                        For Each _row As RecordsDataSet.ArtistsRow In oArtistsTable.Rows
                            Dim _Artist As Artist = ArtistBuilder.AnArtist.StartingWith(_row).Build
                            InsertArtist(_Artist, _Artist.ArtistId)
                        Next
                        rowCount = oArtistsTa.GetData.Rows.Count
                    End If
                Case "Genres"
                    If RecreateTable(oMusicGenreTable, datapath, isSuppressMessage) Then
                        oMusicGenreTa.TruncateMusicGenre()
                        For Each _row As RecordsDataSet.MusicGenreRow In oMusicGenreTable.Rows
                            Dim _Genre As Genre = GenreBuilder.AGenre.StartingWith(_row).Build
                            InsertGenre(_Genre, _Genre.GenreId)
                        Next
                        rowCount = oMusicGenreTa.GetData.Rows.Count
                    End If
            End Select
        Catch ex As Exception
            MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
        End Try
        Return rowCount
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String) As Boolean
        Return RecreateTable(restoredDataTable, datapath, False)
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String, isSuppressMessage As Boolean) As Boolean
        Dim isTableOK As Boolean = False
        Dim sTableName As String = restoredDataTable.TableName
        Dim sBackupFile As String = Path.Combine(datapath, sTableName & ".xml")
        If My.Computer.FileSystem.FileExists(sBackupFile) Then
            Try
                restoredDataTable.Clear()
                restoredDataTable.ReadXml(sBackupFile)
                Dim rowCount As Integer = restoredDataTable.Rows.Count
                If isSuppressMessage Then
                    isTableOK = True
                Else
                    If MsgBox(CStr(rowCount) & " records recovered. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Continue") = MsgBoxResult.Yes Then
                        isTableOK = True
                    End If
                End If
            Catch ex As Exception
                MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        Return isTableOK
    End Function
    Private Function GetMessage(ex As Exception) As String
        Return If(ex Is Nothing, "", "Exception:  " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message))
    End Function
#End Region
#Region "Record"
    Public Function GetRecordsTable() As RecordsDataSet.RecordsDataTable
        LogUtil.Info("Getting records table", MODULE_NAME)
        Return oRecordsTa.GetData()
    End Function
    Public Function GetAllRecords() As List(Of Record)
        LogUtil.Info("Getting Records", MODULE_NAME)
        Dim _list As New List(Of Record)
        Try
            oRecordsTa.Fill(oRecordsTable)
            For Each oRow As RecordsDataSet.RecordsRow In oRecordsTable.Rows
                _list.Add(RecordBuilder.ARecord.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list
    End Function
    Public Function GetRecordFromId(pId As Integer) As Record
        LogUtil.Info("Getting Record " & CStr(pId), MODULE_NAME)
        Dim _rec As New Record
        Try
            oRecordsTa.FillbyId(oRecordsTable, pId)
            If oRecordsTable.Rows.Count > 0 Then
                Dim oRow As RecordsDataSet.RecordsRow = oRecordsTable.Rows(0)
                _rec = RecordBuilder.ARecord.StartingWith(oRow).Build
            End If
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _rec
    End Function
    Public Function InsertRecord(pRecord As Record) As Integer
        Return InsertRecord(pRecord, -1)
    End Function
    Public Function InsertRecord(pRecord As Record, pId As Integer) As Integer
        LogUtil.Info("Inserting record " & pRecord.RecordNumber, MODULE_NAME)
        Dim newId As Integer = -1
        Try
            With pRecord
                If pId < 0 Then
                    newId = oRecordsTa.InsertRecord(.RecordFormat.FormatId, .Label.LabelId, .RecordNumber, .Size, .Speed, .Copies)
                Else
                    newId = oRecordsTa.InsertRecordWithId(.RecordId, .RecordFormat.FormatId, .Label.LabelId, .RecordNumber, .Size, .Speed, .Copies)
                End If
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return newId
    End Function
    Public Function UpdateRecordCopies(pRecord As Record) As Integer
        LogUtil.Info("Inserting record copies for" & pRecord.RecordNumber, MODULE_NAME)
        Dim response As Integer = 0
        Try
            With pRecord
                response = oRecordsTa.UpdateRecordCopies(pRecord.Copies, pRecord.RecordId)
            End With
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
#End Region
#Region "Track"
    Public Function GetTracksTable() As RecordsDataSet.TracksDataTable
        LogUtil.Info("Getting tracks table", MODULE_NAME)
        Return oTracksTa.GetData()
    End Function
    Public Function InsertTrack(pTrack As Track) As Integer
        LogUtil.Info("Inserting Track " & pTrack.RecordId & "-" & CStr(pTrack.Track), MODULE_NAME)
        Dim response As Integer = -1
        Try
            With pTrack
                response = oTracksTa.InsertTrack(.RecordId, .Side, .Track, .Title, .Year, .Genre.GenreId, .Artist.ArtistId)
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function GetTracksForRecord(pId As Integer) As List(Of Track)
        LogUtil.Info("Getting Tracks for " & pId, MODULE_NAME)
        Dim _list As New List(Of Track)
        Try
            oRecordTracksViewTa.FillByRecord(oRecordTracksViewTable, pId)
            For Each oRow As RecordsDataSet.vRecordTracksRow In oRecordTracksViewTable.Rows
                _list.Add(TrackBuilder.ATrack.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list
    End Function
#End Region
#Region "Artist"
    Public Function GetArtistsTable() As RecordsDataSet.ArtistsDataTable
        LogUtil.Info("Getting artists table", MODULE_NAME)
        Return oArtistsTa.GetData()
    End Function
    Public Function GetArtistFromId(pId As Integer) As Artist
        LogUtil.Debug("Getting artist " & pId, MODULE_NAME)
        Dim oArtist As New Artist
        Try
            oArtistsTa.FillById(oArtistsTable, pId)
            If oArtistsTable.Rows.Count > 0 Then
                oArtist = ArtistBuilder.AnArtist.StartingWith(oArtistsTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oArtist
    End Function
    Public Function GetArtistFromName(pName As String) As Artist
        LogUtil.Debug("Getting artist " & pName, MODULE_NAME)
        Dim oArtist As New Artist
        Try
            oArtistsTa.FillByName(oArtistsTable, pName)
            If oArtistsTable.Rows.Count > 0 Then
                oArtist = ArtistBuilder.AnArtist.StartingWith(oArtistsTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oArtist
    End Function
    Public Function InsertArtist(pArtist As Artist) As Integer
        Return InsertArtist(pArtist, -1)
    End Function
    Public Function InsertArtist(pArtist As Artist, pId As Integer) As Integer

        LogUtil.Info("Inserting artist " & CStr(pArtist.ArtistName), MODULE_NAME)
        Dim response As Integer = -1
        Try
            With pArtist
                If GetArtistFromId(pArtist.ArtistId).ArtistId < 0 Then
                    If pId < 0 Then
                        response = oArtistsTa.InsertArtist(.ArtistName)
                    Else
                        response = oArtistsTa.InsertArtistWithId(.ArtistId, .ArtistName)
                    End If
                End If
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function UpdateArtist(pArtist As Artist) As Integer
        LogUtil.Info("Updating artist " & pArtist.ArtistName, MODULE_NAME)
        Dim _response As Integer = -1
        Try
            With pArtist
                _response = oArtistsTa.UpdateArtist(.ArtistName, pArtist.ArtistId)
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _response
    End Function
    Public Function GetAllArtists() As List(Of Artist)
        LogUtil.Info("Getting artists", MODULE_NAME)
        Dim _list As New List(Of Artist)
        Try
            oArtistsTa.Fill(oArtistsTable)
            For Each oRow As RecordsDataSet.ArtistsRow In oArtistsTable.Rows
                _list.Add(ArtistBuilder.AnArtist.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list

    End Function

#End Region
#Region "Label"
    Public Function GetRecordLabelsTable() As RecordsDataSet.RecordLabelsDataTable
        LogUtil.Info("Getting record format table", MODULE_NAME)
        Return oRecordLabelsTa.GetData()
    End Function
    Public Function GetLabelbyId(pId As Integer) As RecordLabel
        LogUtil.Debug("Getting Label " & pId, MODULE_NAME)
        Dim olabel As New RecordLabel
        Try
            oRecordLabelsTa.FillById(oRecordLabelsTable, pId)
            If oRecordLabelsTable.Rows.Count > 0 Then
                olabel = RecordLabelBuilder.ARecordLabel.StartingWith(oRecordLabelsTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return olabel
    End Function
    Public Function GetLabelFromName(pName As String) As RecordLabel
        LogUtil.Debug("Getting Label " & pName, MODULE_NAME)
        Dim olabel As New RecordLabel
        Try
            oRecordLabelsTa.FillByName(oRecordLabelsTable, pName)
            If oRecordLabelsTable.Rows.Count > 0 Then
                olabel = RecordLabelBuilder.ARecordLabel.StartingWith(oRecordLabelsTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return olabel
    End Function
    Public Function InsertLabel(pLabel As RecordLabel) As Integer
        Return InsertLabel(pLabel, -1)
    End Function
    Public Function InsertLabel(pLabel As RecordLabel, pId As Integer) As Integer

        LogUtil.Info("Inserting Label " & CStr(pLabel.LabelId), MODULE_NAME)
        Dim response As Integer = -1
        Try
            With pLabel
                If GetLabelbyId(pLabel.LabelId).LabelId < 0 Then
                    If pId < 0 Then
                        response = oRecordLabelsTa.InsertLabel(.LabelName)
                    Else
                        response = oRecordLabelsTa.InsertLabelWithId(.LabelId, .LabelName)
                    End If
                End If
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function UpdateLabel(pLabel As RecordLabel) As Integer
        LogUtil.Info("Updating Label " & pLabel.LabelName, MODULE_NAME)
        Dim _response As Integer = -1
        Try
            With pLabel
                _response = oRecordLabelsTa.UpdateLabel(.LabelName, pLabel.LabelId)
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _response
    End Function
    Public Function GetAllLabels() As List(Of RecordLabel)
        LogUtil.Info("Getting Labels", MODULE_NAME)
        Dim _list As New List(Of RecordLabel)
        Try
            oRecordLabelsTa.Fill(oRecordLabelsTable)
            For Each oRow As RecordsDataSet.RecordLabelsRow In oRecordLabelsTable.Rows
                _list.Add(RecordLabelBuilder.ARecordLabel.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list

    End Function

#End Region
#Region "Genre"
    Public Function GetMusicGenreTable() As RecordsDataSet.MusicGenreDataTable
        LogUtil.Info("Getting music genre table", MODULE_NAME)
        Return oMusicGenreTa.GetData()
    End Function
    Public Function GetGenreFromId(pId As Integer) As Genre
        LogUtil.Debug("Getting Genre " & pId, MODULE_NAME)
        Dim olabel As New Genre
        Try
            oMusicGenreTa.FillById(oMusicGenreTable, pId)
            If oMusicGenreTable.Rows.Count > 0 Then
                olabel = GenreBuilder.AGenre.StartingWith(oMusicGenreTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return olabel
    End Function
    Public Function GetGenreFromName(pName As String) As Genre
        LogUtil.Debug("Getting Genre " & pName, MODULE_NAME)
        Dim olabel As New Genre
        Try
            oMusicGenreTa.FillByName(oMusicGenreTable, pName)
            If oMusicGenreTable.Rows.Count > 0 Then
                olabel = GenreBuilder.AGenre.StartingWith(oMusicGenreTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return olabel
    End Function
    Public Function InsertGenre(pGenre As Genre) As Integer
        Return InsertGenre(pGenre, -1)
    End Function
    Public Function InsertGenre(pGenre As Genre, pId As Integer) As Integer
        LogUtil.Info("Inserting Genre " & CStr(pGenre.GenreId), MODULE_NAME)
        Dim response As Integer = -1
        Try
            With pGenre
                If GetGenreFromId(pGenre.GenreId).GenreId < 0 Then
                    If pId < 0 Then
                        response = oMusicGenreTa.InsertGenre(.GenreName)
                    Else
                        response = oMusicGenreTa.InsertGenreWithId(.GenreId, .GenreName)
                    End If
                End If
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function UpdateGenre(pGenre As Genre) As Integer
        LogUtil.Info("Updating Genre " & pGenre.GenreName, MODULE_NAME)
        Dim _response As Integer = -1
        Try
            With pGenre
                _response = oMusicGenreTa.UpdateGenre(.GenreName, pGenre.GenreId)
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _response
    End Function
    Public Function GetAllGenres() As List(Of Genre)
        LogUtil.Info("Getting Genres", MODULE_NAME)
        Dim _list As New List(Of Genre)
        Try
            oMusicGenreTa.Fill(oMusicGenreTable)
            For Each oRow As RecordsDataSet.MusicGenreRow In oMusicGenreTable.Rows
                _list.Add(GenreBuilder.AGenre.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list

    End Function
#End Region
#Region "Format"
    Public Function GetRecordFormatTable() As RecordsDataSet.RecordFormatDataTable
        LogUtil.Info("Getting record format table", MODULE_NAME)
        Return oRecordFormatTa.GetData()
    End Function
    Public Function InsertFormat(pFormat As RecordFormat) As Integer
        LogUtil.Info("Inserting Format " & pFormat.FormatId, MODULE_NAME)
        Dim response As Integer = -1
        Try
            With pFormat
                If String.IsNullOrEmpty(GetFormatbyId(pFormat.FormatId).FormatId) Then
                    response = oRecordFormatTa.InsertFormat(.FormatId, .FormatName)
                End If
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return response
    End Function
    Public Function UpdateFormat(pFormat As RecordFormat) As Integer
        LogUtil.Info("Updating format " & pFormat.FormatName, MODULE_NAME)
        Dim _response As Integer = -1
        Try
            With pFormat
                _response = oRecordFormatTa.UpdateFormat(.FormatName, pFormat.FormatId)
            End With
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _response
    End Function
    Public Function GetAllFormats() As List(Of RecordFormat)
        LogUtil.Info("Getting Formats", MODULE_NAME)
        Dim _list As New List(Of RecordFormat)
        Try
            oRecordFormatTa.Fill(oRecordFormatTable)
            For Each oRow As RecordsDataSet.RecordFormatRow In oRecordFormatTable.Rows
                _list.Add(RecordFormatBuilder.ARecordFormat.StartingWith(oRow).Build)
            Next
        Catch ex As Exception
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _list

    End Function
    Public Function GetFormatbyId(pId As String) As RecordFormat
        LogUtil.Debug("Getting format " & pId, MODULE_NAME)
        Dim oformat As New RecordFormat
        Try
            oRecordFormatTa.FillById(oRecordFormatTable, pId)
            If oRecordFormatTable.Rows.Count > 0 Then
                oformat = RecordFormatBuilder.ARecordFormat.StartingWith(oRecordFormatTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oformat
    End Function
    Public Function GetFormatFromName(pName As String) As RecordFormat
        LogUtil.Debug("Getting format " & pName, MODULE_NAME)
        Dim oformat As New RecordFormat
        Try
            oRecordFormatTa.FillByName(oRecordFormatTable, pName)
            If oRecordFormatTable.Rows.Count > 0 Then
                oformat = RecordFormatBuilder.ARecordFormat.StartingWith(oRecordFormatTable.Rows(0)).Build
            End If
        Catch ex As SqlException
            DisplayException(ex, "dB",, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oformat
    End Function

#End Region
#Region "settings"
    Public Function GetSettingsTable() As RecordsDataSet.settingsDataTable
        LogUtil.Info("Getting storyarc table", MODULE_NAME)
        Return oSettingsTa.GetData()
    End Function
    Public Function GetSettingByName(settingName As String) As GlobalSetting
        Return GetSettingByName(settingName, "", "")
    End Function
    Public Function GetSettingByName(settingName As String, defaultValue As String, defaultType As String) As GlobalSetting
        LogUtil.Info("Get setting " & settingName, MODULE_NAME)
        Dim rtnValue As GlobalSetting = GlobalSettingBuilder.AGlobalSetting.StartingWithNothing _
                                                                            .WithName(settingName) _
                                                                            .WithValue(defaultValue) _
                                                                            .WithType(defaultType).Build
        Try
            If oSettingsTa.FillByName(oSettingsTable, settingName) = 1 Then
                Dim oRow As RecordsDataSet.settingsRow = oSettingsTable.Rows(0)
                rtnValue = GlobalSettingBuilder.AGlobalSetting.StartingWith(oRow).Build
            End If
        Catch ex As Exception
            LogUtil.Exception("Exception getting setting " & settingName, ex, MODULE_NAME)
        End Try
        Return rtnValue
    End Function
    Public Function IsSettingExists(settingName As String) As Boolean
        LogUtil.Info("Find setting " & settingName, MODULE_NAME)
        Dim isFound As Boolean
        Try
            oSettingsTa.FillByName(oSettingsTable, settingName)
            isFound = oSettingsTable.Rows.Count > 0
        Catch ex As Exception
            isFound = False
        End Try
        Return isFound
    End Function
    Public Function ChangeSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        LogUtil.Info("Change setting " & settingName, MODULE_NAME)
        Dim rtnVal As Boolean
        Try
            rtnVal = oSettingsTa.UpdateSetting(settingValue, settingType, settingGroup, settingName) = 1
        Catch ex As DbException
            rtnVal = False
        End Try
        Return rtnVal
    End Function
    Public Function AddSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        LogUtil.Info("Add setting " & settingName, MODULE_NAME)
        Dim rtnVal As Boolean
        Try
            Dim _ct As Integer = oSettingsTa.InsertSetting(settingName, settingValue, settingType, settingGroup)
            rtnVal = _ct = 1
        Catch ex As DbException
            rtnVal = False
        End Try
        Return rtnVal
    End Function
    Public Function GetSettingGroupRows(pGroup As String) As DataRowCollection
        Dim oRows As DataRowCollection = Nothing
        If oSettingsTa.FillByGroup(oSettingsTable, pGroup) > 0 Then
            oRows = oSettingsTable.Rows
        End If
        Return oRows
    End Function
#End Region

End Module
