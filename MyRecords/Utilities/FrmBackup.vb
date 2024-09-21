' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports HindlewareLib.Logging

Public Class FrmBackup
#Region "properties"

#End Region
#Region "constants"

#End Region
#Region "variables"
    Private backupPath As String
    Private dbBackupPath As String
    Private dataPath As String
    Private optionsPath As String
    Private isFormInitialised As Boolean
#End Region
#Region "form control handlers"
    Private Sub FrmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddProgress("Backup")
        isFormInitialised = True
        GetFormPos(Me, My.Settings.BackupFormPos)
        PbCopyProgress.Visible = False
        ApplySettings()
        AddProgress("Selecting Data", 1, 1)
        AddProgress("Filling dB Table Tree", 2)
        FillTableTree(TvDatatables)
        TvDatatables.ExpandAll()
    End Sub

    Friend Sub ApplySettings()
        TxtBackupPath.Text = My.Settings.BackupPath
        chkAddDate.Checked = My.Settings.BackupAddDate
        ChkIncludeDb.Checked = My.Settings.BackUpDb
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Dim isOKToBackup As Boolean = CheckPaths()
        If isOKToBackup Then
            AddProgress("Backup started", 1, 1)
            AddProgress("Backing up to " & backupPath, 2)
            If ChkIncludeDb.Checked Then
                DbBackup()
            End If
            If CountCheckedTableNodes() > 0 Then
                DataTableBackup()
            End If
            OptionsBackup()
            AddProgress("Backup complete", 1, 1)
        End If
        ClearAll()
    End Sub
    Private Sub BtnSavePath_Click(sender As Object, e As EventArgs) Handles BtnSavePath.Click
        My.Settings.BackupPath = TxtBackupPath.Text
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectPath_Click(sender As Object, e As EventArgs) Handles BtnSelectPath.Click
        SelectPath()
    End Sub
    Private Sub FrmBackup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.BackupFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnSelectAll_Click(sender As Object, e As EventArgs) Handles BtnSelectAll.Click
        SelectAll()
    End Sub

    Private Sub MnuClear_Click(sender As Object, e As EventArgs) Handles MnuClear.Click
        rtbProgress.Text = ""
    End Sub

#End Region
#Region "subroutines"
    Private Function CountCheckedTableNodes() As Integer
        Dim _tablesnode As TreeNode = TvDatatables.Nodes(0)
        Return CountCheckedNodes(_tablesnode)
    End Function

    Private Function CountCheckedNodes(pNode As TreeNode) As Integer
        Dim checkedNodeCount As Integer = 0
        For Each _subnode As TreeNode In pNode.Nodes
            If _subnode.Checked Then
                checkedNodeCount += 1
            End If
        Next
        Return checkedNodeCount
    End Function

    Friend Sub SelectPath()
        Using fbd As New FolderBrowserDialog
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
            If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                fbd.SelectedPath = TxtBackupPath.Text
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtBackupPath.Text = fbd.SelectedPath
            End If
        End Using
    End Sub
    Friend Sub SelectAll()
        TvDatatables.Nodes(0).Checked = True
    End Sub
    Private Sub TreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TvDatatables.AfterCheck
        Dim node As TreeNode = e.Node
        Dim ischecked As Boolean = node.Checked
        For Each subNode As TreeNode In node.Nodes
            If Not subNode.Checked = ischecked Then
                subNode.Checked = ischecked
            End If
        Next
        StatusStrip1.Refresh()
    End Sub

    Friend Sub ClearAll()
        TvDatatables.Nodes(0).Checked = False
    End Sub
    Private Function CheckPaths() As Boolean
        AddProgress("Checking paths", 1, 1)
        Dim isOKToBackup As Boolean = True
        If Not TxtBackupPath.Text.Contains(":") Then
            AddProgress("No drive specified")
            isOKToBackup = False
        Else
            Dim _driveLetter As String = Split(TxtBackupPath.Text, ":", 2)(0)
            If Not My.Computer.FileSystem.DirectoryExists(_driveLetter & ":\") Then
                AddProgress("Drive does not exist.")
                isOKToBackup = False
            Else
                If Not String.IsNullOrEmpty(TxtBackupPath.Text) Then
                    backupPath = If(chkAddDate.Checked, Path.Combine(TxtBackupPath.Text.Trim, Format(Today, "yyyyMMdd")), TxtBackupPath.Text.Trim)
                    If Not CheckPathExists(backupPath) Then isOKToBackup = False
                    If ChkIncludeDb.Checked Then
                        dbBackupPath = Path.Combine(backupPath, "MSSQL")
                        If Not CheckPathExists(dbBackupPath) Then isOKToBackup = False
                    End If
                    If CountCheckedTableNodes() > 0 Then
                        dataPath = Path.Combine(backupPath, "data")
                        If Not CheckPathExists(dataPath) Then isOKToBackup = False
                    End If
                    '    optionsPath = Path.Combine(backupPath, "options")
                    '    If Not CheckPathExists(optionsPath) Then isOKToBackup = False
                Else
                    AddProgress("No destination. No backup.")
                    isOKToBackup = False
                End If
            End If
        End If
        Return isOKToBackup
    End Function
    Private Function CheckPathExists(_path As String) As Boolean
        Dim isOK As Boolean = True
        Try
            If Not My.Computer.FileSystem.DirectoryExists(_path) Then
                AddProgress("Creating folder " & _path, 2)
                My.Computer.FileSystem.CreateDirectory(_path)
            End If
        Catch ex As ArgumentException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As PathTooLongException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As NotSupportedException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As IOException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        Catch ex As UnauthorizedAccessException
            DisplayException(ex, "File creation", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 2, 4)
            isOK = False
        End Try
        Return isOK
    End Function
    Private Sub DbBackup()
        AddProgress("dB backup", 2, 2)
        Dim _initBackup As String = If(My.Settings.AppendDbBackup, "NOINIT", "INIT")
        Dim _dbName As String = GetGlobalSetting("DbName", "MyNovel", "string")
        Dim _bakFileName As String = Path.Combine(dbBackupPath, _dbName & "_" & Format(Today, "yyyyMMdd") & ".bak")
        Dim _commandSQL As New StringBuilder
        _commandSQL.Append("BACKUP DATABASE [") _
            .Append(_dbName) _
            .Append("] TO  DISK = N'") _
            .Append(_bakFileName) _
            .Append("' WITH NOFORMAT, ") _
            .Append(_initBackup) _
            .Append(",  NAME = N'") _
            .Append(_dbName) _
            .Append("-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10")
        Dim _command As New Global.System.Data.SqlClient.SqlCommand
        _command.Connection = New Global.System.Data.SqlClient.SqlConnection With {
            .ConnectionString = Global.MyRecords.My.MySettings.Default.RecordsConnectionString
        }
        _command.CommandText = _commandSQL.ToString
        _command.CommandType = Global.System.Data.CommandType.Text
        Dim previousConnectionState As Global.System.Data.ConnectionState = _command.Connection.State
        If ((_command.Connection.State And Global.System.Data.ConnectionState.Open) _
                        <> Global.System.Data.ConnectionState.Open) Then
            AddProgress("Opening dB connection to " & _dbName, 4)
            _command.Connection.Open()
        End If
        Dim returnValue As Integer
        Try
            AddProgress("Executing SQL", 4)
            returnValue = _command.ExecuteNonQuery
        Catch ex As InvalidCastException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As SqlClient.SqlException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As IOException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Catch ex As InvalidOperationException
            DisplayException(ex, "Backup SQL", False, MyBase.Name)
            AddProgress("Failed : " & ex.Message, 4, 4)
        Finally
            If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                AddProgress("Closing dB connection", 4)
                _command.Connection.Close()
            End If
        End Try
    End Sub
    Private Sub OptionsBackup()

    End Sub
    Private Sub DisplayProgressBar(pNode As TreeNode)
        PbCopyProgress.Value = 0
        Dim _selct As Integer = 0
        For Each oNode As TreeNode In pNode.Nodes
            If oNode.Checked Then
                _selct += 1
            End If
        Next
        PbCopyProgress.Maximum = _selct
        PbCopyProgress.Visible = True
    End Sub
    Private Sub DataTableBackup()
        Dim _itemList As New List(Of String)
        AddProgress("Data backup", 2, 2)
        DisplayProgressBar(TvDatatables.Nodes(0))
        For Each oNode As TreeNode In TvDatatables.Nodes(0).Nodes
            If oNode.Checked Then
                Dim _table As String = oNode.Text.Replace(TABLE_TAG, "")
                AddProgress(_table, 3)
                Dim _isTableSaved As Boolean = False
                Select Case _table
                    Case Tables.Records.ToString
                        _itemList.Add(BackupTable(GetRecordsTable))
                        _isTableSaved = True
                    Case Tables.Tracks.ToString
                        _itemList.Add(BackupTable(GetTracksTable))
                        _isTableSaved = True
                    Case Tables.MusicGenre.ToString
                        _itemList.Add(BackupTable(GetMusicGenreTable))
                        _isTableSaved = True
                    Case Tables.RecordFormat.ToString
                        _itemList.Add(BackupTable(GetRecordFormatTable))
                        _isTableSaved = True
                    Case Tables.RecordLabels.ToString
                        _itemList.Add(BackupTable(GetRecordLabelsTable))
                        _isTableSaved = True
                    Case Tables.Settings.ToString
                        _itemList.Add(BackupTable(GetSettingsTable))
                        _isTableSaved = True
                End Select
                If _isTableSaved Then
                    oNode.Checked = False
                Else
                    AddProgress(_table & " unrecognised. Not backed up.", 12, 4)
                End If
            End If
        Next
        PbCopyProgress.Visible = False
        TvDatatables.Nodes(0).Checked = False
    End Sub
    Private Sub AddProgress(pText As String, Optional pTextLevel As Integer = 0, Optional pHeadingLevel As Integer = 0)
        Dim _padchar As Char = " "
        Select Case pHeadingLevel
            Case 1
                _padchar = "="c
            Case 2
                _padchar = "-"c
            Case 4
                _padchar = "!"c
        End Select
        LogUtil.Info(pText, MyBase.Name)
        pText = pText.PadLeft(pText.Length + pTextLevel, " "c)
        rtbProgress.Text &= vbCrLf & pText
        rtbProgress.SelectionStart = rtbProgress.Text.Length
        rtbProgress.ScrollToCaret()
        rtbProgress.Refresh()
    End Sub
    Private Function BackupTable(backupDataTable As DataTable) As String
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = dataPath
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        backupDataTable.WriteXml(sBackupFile, XmlWriteMode.WriteSchema)
        AddProgress(sBackupFile & " complete", 12)
        PbCopyProgress.PerformStep()
        StatusStrip1.Refresh()
        Return sTableName
    End Function

#End Region
End Class