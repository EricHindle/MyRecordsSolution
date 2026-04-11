' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging

Public Module ModCommon
#Region "enum"
#End Region
#Region "variables"
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
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
#End Region
#Region "subroutines"
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
    Public Function GetFormPos(ByRef oForm As Form, ByVal sPos As String) As Boolean
        LogUtil.Info("Getting form position for " & oForm.Name, MethodBase.GetCurrentMethod.Name)
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
        LogUtil.Debug("Generated form position: " & sPos, MethodBase.GetCurrentMethod.Name)
        Return sPos
    End Function
#End Region
End Module