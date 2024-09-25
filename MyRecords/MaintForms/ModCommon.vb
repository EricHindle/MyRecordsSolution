' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging

Public Module ModCommon
#Region "constants"
    Private Const MODULE_NAME As String = "ModCommon"
    Public Const SYMBOL_WIDTH As Integer = 20
    Public Const SYMBOL_HEIGHT As Integer = 20
    Public Const SYMBOL_WIDTH_LARGE As Integer = 38
    Public Const SYMBOL_HEIGHT_LARGE As Integer = 38
    Public Const SYMBOL_SPACING As Integer = 2
    Public ReadOnly DEFAULT_DATETIME As New Date(1881, 9, 1, 12, 0, 0)
    Public Const FILE_FILTER As String = "Documents (*.odt)|*.odt|Word (*.docx)|*.docx|Rich text (*.rtf)|*.rtf|Text files (*.txt)|*.txt|all files (*.*)|*.*"
    Public VDARK_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(60, Byte), Integer))
    Public DARK_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(120, Byte), Integer))
    Public LIGHT_TEXT As Color = Color.SteelBlue
    Public INACTIVE_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer))
    Public DARK_BOOK_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Public INACTIVE_BOOK_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Public DARK_EVENT_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(30, Byte), Integer))
    Public LIGHT_EVENT_TEXT As Color = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(132, Byte), Integer))

    Public CHAPTER_TREE_BKGRD As Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
    Public CHAPTER_TREE_SELECTED_BKGRD As Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(110, Byte), Integer))
#End Region
#Region "enum"
    Public Enum SettingSection
        MainSplitterDist
    End Enum
    Public Enum ControlGroup
        Main
        Book
        Person
        Place
        PlotEvent
        Source
        Voice
        Beats
        Chapter
        Parts
        None
    End Enum
    Public Enum Colour
        none
        blue
        red
        green
        yellow
    End Enum
    Public Enum Shape
        none
        circle
        square
        lozenge
    End Enum
    Public Enum FamilyMemberType
        unknown
        parent
        child
        spouse
        sibling
    End Enum
#End Region
#Region "variables"
    Public PlannerMinimumDate As DateTime
    Public TodaysDate As New DateTime(Today.Year, Today.Month, Today.Day, 0, 0, 0)
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public gSourceImagePath As String
    Public gChapterFilePath As String
    Public gTextFilePath As String
    Public gSoundFilePath As String
    Public gOtherFilePath As String
    Public gRecordingsPath As String
    Public gArchiveFilePath As String
    Public gZipFolderPath As String
    Public isHelpOn As Boolean
    Public isDebugOn As Boolean
    Public isBookUndocked As Boolean
    Public isEventUndocked As Boolean
    Public isPersonUndocked As Boolean
    Public isPlaceUndocked As Boolean
    Public isSourceUndocked As Boolean
    Public isVoiceUndocked As Boolean
#End Region
#Region "forms"
    Public Sub ShowLog()
        Using _logView As New FrmLogViewer
            _logView.FormPosition = My.Settings.LogViewPos
            _logView.ZoomValue = My.Settings.logZoomValue
            _logView.IsZoomOn = My.Settings.logZoomOn
            _logView.ShowDialog()
            My.Settings.LogViewPos = _logView.FormPosition
            My.Settings.logZoomValue = _logView.ZoomValue
            My.Settings.logZoomOn = _logView.IsZoomOn
            My.Settings.Save()
        End Using
    End Sub

    'Public Sub OpenBackupForm()
    '    LogUtil.Info("Open Backup", MODULE_NAME)

    '    Using _backup As New FrmBackup
    '        _backup.ShowDialog()
    '    End Using

    'End Sub


    'Public Sub OpenOptionsForm()
    '    OpenOptionsForm(-1, Nothing)
    'End Sub
    'Public Sub OpenOptionsForm(pFormType As Integer, pForm As Form)
    '    LogUtil.Info("Open Options", MODULE_NAME)

    '    Using _options As New FrmOptions
    '        _options.FormType = pFormType
    '        _options.SourceForm = pForm
    '        _options.ShowDialog()
    '    End Using

    'End Sub
    'Public Sub OpenSettingsForm()
    '    LogUtil.Info("Open My Settings", MODULE_NAME)

    '    Using _sett As New FrmMySettings
    '        _sett.ShowDialog()
    '    End Using

    'End Sub


#End Region
#Region "subroutines"
    Public Sub LogSettings(pSection As SettingSection, psub As String)
        Select Case pSection
            Case SettingSection.MainSplitterDist
                LogMainSplitterDist(psub)
        End Select
    End Sub
    Private Sub LogMainSplitterDist(psub As String)
        'LogUtil.Info("Main BookBeat Split Dist : " & My.Settings.MainBookBeatSplitDist, psub)
        'LogUtil.Info("Main People/Places Split Dist : " & My.Settings.MainPeoplePlacesSplitDist, psub)
        'LogUtil.Info("Main Pages Split Dist : " & My.Settings.MainPagesSplitDist, psub)
        'LogUtil.Info("Main Chapters Split Dist : " & My.Settings.MainChaptersSplitDist, psub)
        'LogUtil.Info("Main Files Split Dist : " & My.Settings.MainFilesSplitDist, psub)
        'LogUtil.Info("Main Chapter Plan Split Dist : " & My.Settings.MainChapterPlanSplitDist, psub)
        'LogUtil.Info("Main Diary Split Dist : " & My.Settings.MainDiarySplitDist, psub)
        'LogUtil.Info("Main Split Dist : " & My.Settings.MainSplitDist, psub)
    End Sub

    Public Sub ClearStatus(pStatus As ToolStripStatusLabel)
        ShowStatus("", pStatus,, False)
    End Sub
    Public Sub LoadFileListDgv(ByRef pDgv As DataGridView, ByRef pFilePath As String, pColName As String)
        pDgv.Rows.Clear()
        Dim fileList As IReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(pFilePath)
        For Each _filename As String In fileList
            Dim _fname As String = Path.GetFileName(_filename)
            Dim newRow As DataGridViewRow = pDgv.Rows(pDgv.Rows.Add())
            newRow.Cells(pColName).Value = _fname
            newRow.Cells(pColName).ToolTipText = _filename
        Next
        pDgv.ClearSelection()
        pDgv.Refresh()
    End Sub

    Public Sub TextBox_DragDrop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = item.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = item.TrimStart
                Else
                    If oBox.Text.Substring(startpos - 1, 1) = "." Then
                        oBox.SelectedText = " " & item.TrimStart
                    Else
                        oBox.SelectedText = item
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub TextBox_DragEnter(sender As Object, e As DragEventArgs)
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
#End Region
#Region "functions"
    Public Function SwapEvents(ByRef fromIx As DataGridViewRow, ByRef toIx As DataGridViewRow, ByRef dgv As DataGridView) As Boolean
        Dim _index As Integer = toIx.Index
        Dim _id As Integer = fromIx.Cells(0).Value
        Dim _seq As Integer = fromIx.Cells(1).Value
        Dim _chapter As String = fromIx.Cells(2).Value
        Dim _summary As String = fromIx.Cells(3).Value
        Dim _timeline As String = fromIx.Cells(4).Value
        Dim _isDeleted As String = fromIx.Cells(5).Value
        Dim _visible As Boolean = fromIx.Visible
        fromIx.Cells(0).Value = toIx.Cells(0).Value
        fromIx.Cells(1).Value = toIx.Cells(1).Value
        fromIx.Cells(2).Value = toIx.Cells(2).Value
        fromIx.Cells(3).Value = toIx.Cells(3).Value
        fromIx.Cells(4).Value = toIx.Cells(4).Value
        fromIx.Cells(5).Value = toIx.Cells(5).Value
        fromIx.Visible = toIx.Visible
        toIx.Cells(0).Value = _id
        toIx.Cells(1).Value = _seq
        toIx.Cells(2).Value = _chapter
        toIx.Cells(3).Value = _summary
        toIx.Cells(4).Value = _timeline
        toIx.Cells(5).Value = _isDeleted
        toIx.Visible = _visible
        dgv.ClearSelection()
        dgv.Rows(_index).Selected = True
        Return fromIx.Visible
    End Function
    Public Function ShowStatus(pText As String,
                               ByRef pStatus As Label,
                               Optional pSource As String = "",
                               Optional isLogged As Boolean = True,
                               Optional IsBeep As Boolean = False) As MsgBoxResult
        If pStatus IsNot Nothing AndAlso pStatus.GetType Is GetType(Label) Then
            pStatus.Text = pText
            pStatus.Refresh()
        End If
        Return ShowStatus(pText, pSource:=pSource, isLogged:=isLogged, IsBeep:=IsBeep)
    End Function
    Public Function ShowStatus(pText As String,
                               ByRef pStatus As ToolStripStatusLabel,
                               Optional pSource As String = "",
                               Optional isLogged As Boolean = True,
                               Optional pLevel As TraceEventType = TraceEventType.Information,
                               Optional pEx As Exception = Nothing,
                               Optional isMessageBox As Boolean = False,
                               Optional pBoxStyle As MsgBoxStyle = MsgBoxStyle.Exclamation,
                               Optional IsBeep As Boolean = False) As MsgBoxResult
        If pStatus IsNot Nothing AndAlso pStatus.GetType Is GetType(ToolStripStatusLabel) Then
            pStatus.Text = pText
            pStatus.Owner.Refresh()
        End If
        Return ShowStatus(pText, pSource, isLogged, pLevel, pEx, isMessageBox, pBoxStyle, IsBeep)
    End Function
    Public Function ShowStatus(pText As String,
                               Optional pSource As String = "",
                               Optional isLogged As Boolean = True,
                               Optional pLevel As TraceEventType = TraceEventType.Information,
                               Optional pEx As Exception = Nothing,
                               Optional isMessageBox As Boolean = False,
                               Optional pBoxStyle As MsgBoxStyle = MsgBoxStyle.Exclamation,
                               Optional IsBeep As Boolean = False) As MsgBoxResult
        Dim rtnResult As MsgBoxResult = MsgBoxResult.Ok

        If IsBeep Then Beep()
        If isLogged Then
            If pEx Is Nothing Then
                LogUtil.AddLog(pText, pLevel, pSource)
            Else
                LogUtil.Exception(pText, pEx, pSource)
            End If
        End If
        If isMessageBox Then
            Dim _message As String = pText & If(pEx Is Nothing, "", vbCrLf & "Exception:  " & pEx.Message & vbCrLf & If(pEx.InnerException Is Nothing, "", pEx.InnerException.Message))
            rtnResult = MsgBox(_message, pBoxStyle, "Status")
        End If
        Return rtnResult
    End Function


    Public Function PadSequence(_seq As Integer, _maxSeq As Integer) As String
        Dim _paddedSeq As String = CStr(_seq).PadLeft(CStr(_maxSeq).Length, "0")
        Return _paddedSeq
    End Function

    Public Function GetFileNameFromList(dgv As DataGridView) As String
        Dim _fileName As String = ""
        If dgv IsNot Nothing Then
            If dgv.SelectedRows.Count = 1 Then
                Try
                    _fileName = dgv.SelectedRows(0).Cells(0).Value
                Catch ex As ArgumentException
                    DisplayException(ex, "Arguement", , "GetFileNameFromList")
                Catch ex As IOException
                    DisplayException(ex, "IO", , "GetFileNameFromList")
                End Try
            End If
        End If
        Return _fileName
    End Function

    Public Function GetFormPos(ByRef oForm As Form, ByVal sPos As String) As Boolean
        LogUtil.Info("Getting form position for " & oForm.Name, MODULE_NAME)
        Dim isOK As Boolean = True
        If sPos = "max" Then
            oForm.WindowState = FormWindowState.Maximized
        ElseIf sPos = "min" Then
            oForm.WindowState = FormWindowState.Minimized
        Else
            Dim pos As String() = sPos.Split("~")
            If pos.Length = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))
                oForm.Height = CInt(pos(2))
                oForm.Width = CInt(pos(3))
            Else
                isOK = False
            End If
        End If
        Return isOK
    End Function
    Public Function SetFormPos(ByRef oForm As Form) As String
        Dim sPos As String
        If oForm.WindowState = FormWindowState.Maximized Then
            sPos = "max"
        ElseIf oForm.WindowState = FormWindowState.Minimized Then
            sPos = "min"
        Else
            sPos = oForm.Top & "~" & oForm.Left & "~" & oForm.Height & "~" & oForm.Width
        End If
        LogUtil.Debug("Generated form position: " & sPos, MODULE_NAME)
        Return sPos
    End Function
    Public Function DisplayException(pException As Exception, pExceptionType As String, Optional isAsk As Boolean = False, Optional pSub As String = "") As MsgBoxResult
        LogUtil.Exception(pExceptionType, pException, pSub)
        Return MsgBox(pSub & " : " & pExceptionType & " exception" & vbCrLf _
            & pException.Message & vbCrLf _
            & If(pException.InnerException Is Nothing, "", pException.InnerException.Message) _
            & If(isAsk, vbCrLf & "OK to continue?", ""),
                   If(isAsk, MsgBoxStyle.YesNo, MsgBoxStyle.OkOnly) Or MsgBoxStyle.Exclamation,
                      pExceptionType & " exception")
    End Function
    Public Function GetUniqueFname(ByVal filename As String, ByVal Optional pPath As String = Nothing, Optional pPrefix As String = "", Optional pSuffix As String = "_#") As String
        If pPath Is Nothing Then pPath = Path.GetDirectoryName(filename)
        Dim newfilename As String = Path.Combine(pPath, Path.GetFileName(filename))
        Dim _suffix As String
        Dim _prefix As String
        If My.Computer.FileSystem.FileExists(newfilename) Then
            Try
                For subs As Integer = 0 To 999
                    _prefix = pPrefix.Replace("#", subs)
                    _suffix = pSuffix.Replace("#", subs)
                    newfilename = Path.Combine(pPath, _prefix & Path.GetFileNameWithoutExtension(filename) & _suffix & Path.GetExtension(filename))
                    If My.Computer.FileSystem.FileExists(newfilename) = False Then
                        Exit For
                    End If
                Next
            Catch ex As ArgumentException
                DisplayException(ex, "Argument", , MethodBase.GetCurrentMethod.Name)
            End Try
        End If
        LogUtil.Info("Generated new filename: " & newfilename, MODULE_NAME)
        Return newfilename
    End Function
    Public Function GetFileName(Optional ByVal pFolder As String = Nothing, Optional fileFilter As String = FILE_FILTER, Optional isFileExists As Boolean = True) As String
        Dim sFilename As String = ""
        Using fbd As New OpenFileDialog
            fbd.Filter = fileFilter
            fbd.FilterIndex = 0S
            fbd.RestoreDirectory = False
            fbd.CheckFileExists = isFileExists
            If Not String.IsNullOrEmpty(pFolder) Then
                fbd.InitialDirectory = pFolder
            End If
            If fbd.ShowDialog() = DialogResult.OK Then
                sFilename = fbd.FileName
            End If
        End Using
        Return sFilename
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function ToIcon(img As Bitmap) As Icon
        Dim iconHandle = img.GetHicon()
        Return Icon.FromHandle(iconHandle)
    End Function
#End Region
#Region "contrls"
    Public Function CloneTabPage(pTemplate As TabPage)
        Dim _tabpage As New TabPage
        With _tabpage
            .Padding = pTemplate.Padding
            .Size = pTemplate.Size
            .BackColor = pTemplate.BackColor
        End With
        Return _tabpage
    End Function
    Public Function CreateDataGridView(pLocation As Point,
                                        pSize As Size,
                                        pAnchor As AnchorStyles,
                                        pBackColor As Color,
                                        pForeColor As Color) As DataGridView
        Dim _dgv As New DataGridView With {
                                            .Location = pLocation,
                                            .Size = pSize
                                            }
        With _dgv
            .BackgroundColor = pBackColor
            .DefaultCellStyle.BackColor = pBackColor
            .DefaultCellStyle.ForeColor = pForeColor
            .Anchor = pAnchor
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
        End With
        Return _dgv
    End Function
    Public Function CloneDataGridView(pTemplate As DataGridView) As DataGridView
        Dim _dgv As New DataGridView With {
                                            .Location = pTemplate.Location,
                                            .Size = pTemplate.Size
            }
        With _dgv
            .BackgroundColor = pTemplate.BackgroundColor
            .DefaultCellStyle = pTemplate.DefaultCellStyle
            .ColumnHeadersDefaultCellStyle = pTemplate.ColumnHeadersDefaultCellStyle
            .RowTemplate = pTemplate.RowTemplate
            .Anchor = pTemplate.Anchor
            .AllowUserToAddRows = pTemplate.AllowUserToAddRows
            .AllowUserToDeleteRows = pTemplate.AllowUserToDeleteRows
            .SelectionMode = pTemplate.SelectionMode
            .ReadOnly = pTemplate.ReadOnly
        End With
        Return _dgv

    End Function
    Public Function CreateTextBox(pLocation As System.Drawing.Point,
                            pSize As System.Drawing.Size,
                            pAnchor As AnchorStyles,
                            pFont As Font) As TextBox
        Dim _newTextBox As New TextBox()
        With _newTextBox
            .Anchor = pAnchor
            .Font = pFont
            .Location = pLocation
            .Size = pSize
            .Text = String.Empty
        End With
        Return _newTextBox
    End Function
    Public Function CloneTextBox(pTemplate As TextBox) As TextBox
        Dim _newTextBox As New TextBox()
        With _newTextBox
            .BackColor = pTemplate.BackColor
            .ForeColor = pTemplate.ForeColor
            .BorderStyle = pTemplate.BorderStyle
            .Anchor = pTemplate.Anchor
            .Font = pTemplate.Font
            .Location = pTemplate.Location
            .Size = pTemplate.Size
            .Text = String.Empty
        End With
        Return _newTextBox
    End Function
    Public Function CreatePanel(pName As String, pBackColor As Color, pForeColor As Color, pMargin As Padding, pSize As Size) As Panel
        Dim oPanel As New Panel With {
            .BackColor = pBackColor,
            .ForeColor = pForeColor,
            .Margin = pMargin,
            .Name = pName,
            .Size = pSize
        }
        Return oPanel
    End Function
    Public Function CreateLabel(pLocation As System.Drawing.Point,
                                pText As String,
                                pBackColor As Color,
                                pForeColor As Color,
                                pFont As Font) As Label
        Dim _label1 As New Label
        With _label1
            .Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left
            .AutoSize = True
            .Location = pLocation
            .Text = pText
            If pBackColor <> Nothing Then .ForeColor = pForeColor
            If pForeColor <> Nothing Then .BackColor = pBackColor
            If pFont IsNot Nothing Then .Font = pFont
        End With
        Return _label1
    End Function
    Public Function CloneLabel(pTemplate As Label) As Label
        Dim _label1 As New Label
        With _label1
            .Anchor = pTemplate.Anchor
            .AutoSize = pTemplate.AutoSize
            .Location = pTemplate.Location
            .Text = pTemplate.Text
            .ForeColor = pTemplate.ForeColor
            .BackColor = pTemplate.BackColor
            .Font = pTemplate.Font
        End With
        Return _label1
    End Function
    Public Function CreateButton(pLocation As Point,
                           pSize As Size,
                           pText As String,
                           pFont As Font) As Button
        Dim _button As New Button
        With _button
            If pFont IsNot Nothing Then .Font = pFont
            .Location = pLocation
            .Size = pSize
            .Text = pText
        End With
        Return _button
    End Function
    Public Function YYMM(pDate As Date) As Integer
        Return Format(pDate, "yyMM")
    End Function
#End Region
End Module