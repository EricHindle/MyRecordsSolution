' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging
Imports MyVinyl.Domain

Public Class FrmMenu
#Region "form control handlers"
    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        InitialiseApplication()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing My Vinyl", MyBase.Name)
    End Sub
    Private Sub BtnOptions_Click(sender As Object, e As EventArgs)
        'Hide()
        'Using _options As New FrmOptions
        '    LogUtil.Info("Opening Options", MyBase.Name)
        '    _options.ShowDialog()
        'End Using
        'Show()
    End Sub
    Private Sub BtnInputRecords_Click(sender As Object, e As EventArgs) Handles BtnInputRecords.Click
        Hide()
        Using _recordInput As New FrmRecordInput
            _recordInput.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Hide()
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Hide()
        Using _restore As New FrmRestore
            _restore.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnFormats_Click(sender As Object, e As EventArgs) Handles BtnFormats.Click
        Hide()
        Using _format As New FrmFormatMaint
            _format.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnLabels_Click(sender As Object, e As EventArgs) Handles BtnLabels.Click
        Hide()
        Using _label As New FrmLabelMaint
            _label.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnArtists_Click(sender As Object, e As EventArgs) Handles BtnArtists.Click
        Hide()
        Using _artist As New FrmArtistMaint
            _artist.IsSaveAndExit = False
            _artist.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnGenres_Click(sender As Object, e As EventArgs) Handles BtnGenres.Click
        Hide()
        Using _genre As New FrmGenreMaint
            _genre.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles BtnViewLog.Click
        ShowLog()
        Show()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Hide()
        Using _search As New FrmSearch
            _search.ShowDialog()
        End Using
        Show()
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseApplication()
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
        Dim _runtime As List(Of String) = {My.Application.Info.Title & " version " & My.Application.Info.Version.ToString,
                                            "Computer name : " & My.Computer.Name,
                                            "Application path is " & My.Application.Info.DirectoryPath}.ToList
        For Each _rt As String In _runtime
            LogUtil.Info(_rt, MyBase.Name)
        Next
        InitialiseData()
    End Sub
#End Region

End Class