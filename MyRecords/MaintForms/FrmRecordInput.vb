' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmRecordInput
    Private Sub FrmRecordInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Add Records", MyBase.Name)
        GetFormPos(Me, My.Settings.RecordInputFormPos)
        InitialiseForm()

        KeyPreview = True
    End Sub

    Private Sub InitialiseForm()
        LblRecordId.Text = -1
        LoadFormatList()
        LoadLabelList()
        CbRecordFormat.SelectedIndex = -1
        CbRecordLabel.SelectedIndex = -1
        TxtRecNumber.Text = String.Empty
        Rb7.Checked = True
        Rb45.Checked = True
        DgvTracks.Rows.Clear()
        BtnAddTracks.Enabled = False
    End Sub

    Private Sub LoadFormatList()
        Me.RecordFormatTableAdapter.Fill(Me.RecordsDataSet.RecordFormat)
    End Sub
    Private Sub LoadLabelList()
        Me.RecordLabelsTableAdapter.Fill(Me.RecordsDataSet.RecordLabels)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmRecordInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.RecordInputFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

    End Sub

    Private Sub BtnAddFormat_Click(sender As Object, e As EventArgs) Handles BtnAddFormat.Click

    End Sub

    Private Sub BtnAddLabel_Click(sender As Object, e As EventArgs) Handles BtnAddLabel.Click

    End Sub

    Private Sub BtnAddTracks_Click(sender As Object, e As EventArgs) Handles BtnAddTracks.Click

    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        TxtRecNumber.Text = String.Empty
        LblRecordId.Text = "-1"
        DgvTracks.Rows.Clear()
        BtnAddTracks.Enabled = False
        CbRecordLabel.SelectedIndex = -1
    End Sub
End Class
