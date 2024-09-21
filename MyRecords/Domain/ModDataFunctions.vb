' Hindleware
' Copyright (c) 2023-24 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
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
        Settings
    End Enum
#End Region
#Region "dataset"
    Private ReadOnly oSettingsTa As New RecordsDataSetTableAdapters.settingsTableAdapter
    Private ReadOnly oSettingsTable As New RecordsDataSet.settingsDataTable
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
