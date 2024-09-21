' Hindleware
' Copyright (c) 2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
Imports HindlewareLib.Logging

''' <summary>
''' Form to maintain Global Settings values
''' </summary>
''' <remarks>Global Settings are settings which must be the same for all system users.
''' The Keys for the settings are hardcoded so the records must not be deleted from the table.
''' New setting records are not needed unless the code changes, so they cannot be created here.</remarks>
Public Class FrmGlobalSettings
#Region "Private variable instances"
    Private ReadOnly oTa As New RecordsDataSetTableAdapters.settingsTableAdapter
#End Region
#Region "Form"
    Private ReadOnly oTable As New RecordsDataSet.settingsDataTable
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.GlobalSettingsPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Global settings", MyBase.Name)
        GetFormPos(Me, My.Settings.GlobalSettingsPos)
        Try
            oTa.Fill(oTable)
        Catch ex As DbException
            LogUtil.Problem("Exception during Global Settings table load : " & ex.Message)
        End Try
        cbSelect.DataSource = oTable
        cbSelect.DisplayMember = "pKey"
        cbSelect.ValueMember = "pKey"
        ClearForm()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub ClearForm()
        cbSelect.SelectedIndex = -1
        cbType.SelectedValue = 0
        txtValue.Text = ""
        TxtGroup.Text = ""
    End Sub
    Private Sub FillForm(ByVal _name As String)
        Dim _table As New RecordsDataSet.settingsDataTable
        oTa.FillByName(_table, _name)
        If _table.Rows.Count > 0 Then
            Dim oRow As RecordsDataSet.settingsRow = _table.Rows(0)
            txtValue.Text = oRow.pValue
            cbType.SelectedIndex = cbType.FindString(oRow.pType)
            TxtGroup.Text = If(oRow.IspGroupNull, "", oRow.pGroup)
        Else
            ShowStatus("Error: No single record", lblStatus, MyBase.Name, IsBeep:=True)
        End If
        _table.Dispose()
    End Sub
    Private Sub CbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            If TypeOf cbSelect.SelectedValue Is String Then
                FillForm(cbSelect.SelectedValue)
            End If
        Else
            ClearForm()
        End If
    End Sub
#End Region
#Region "Update"
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbSelect.SelectedIndex > -1 Then
            Dim recordId As String = cbSelect.SelectedValue
            Dim isUpdated As Boolean = ModGlobalSettings.SetSetting(recordId, cbType.SelectedItem, txtValue.Text, TxtGroup.Text)
            LogStatus(recordId & If(isUpdated, " updated", " NOT updated"))
        Else
            MsgBox("Pick an item from the list", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Selection error")
        End If
        oTa.Fill(oTable)
        ClearForm()
    End Sub
#End Region
#Region "Subroutines"
    Private Sub LogStatus(ByVal sText As String)
        lblStatus.Text = sText
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing Then
                oTa.Dispose()
                oTable.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Private Sub FrmGlobalSettings_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
#End Region
End Class