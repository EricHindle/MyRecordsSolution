' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmFormatMaint
    Private CurrentFormat As RecordFormat
    Private isLoading As Boolean
    Private Sub FrmFormatMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Format maintenance", MyBase.Name)
        GetFormPos(Me, My.Settings.FormatFormPos)
        LoadFormatList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmFormatMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.FormatFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub


    Private Sub InsertNewFormat()
        If Not String.IsNullOrWhiteSpace(TxtFormat.Text) Then
            ShowStatus("Adding new Format", LblStatus, MyBase.Name)
            Dim oFormat As RecordFormat = RecordFormatBuilder.ARecordFormat.StartingWithNothing _
                                                    .WithId(TxtFormatId.Text) _
                                                    .WithFormatName(TxtFormat.Text) _
                                                    .Build
            InsertFormat(oFormat)
            ShowStatus("Added Format", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not added.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub UpdateFormatDetails()
        If Not String.IsNullOrWhiteSpace(TxtFormat.Text) Then
            ShowStatus("Updating Format", LblStatus, MyBase.Name)
            Dim oFormat As RecordFormat = RecordFormatBuilder.ARecordFormat.StartingWithNothing _
                                                    .WithId(CurrentFormat.FormatId) _
                                                    .WithFormatName(TxtFormat.Text) _
                                                    .Build
            UpdateFormat(oFormat)
            ShowStatus("Updated Format", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not changed.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub LoadFormatList()
        isLoading = True
        Dim oFormatList As List(Of RecordFormat) = GetAllFormats()
        DgvFormat.Rows.Clear()
        For Each oFormat As RecordFormat In oFormatList
            AddFormatRow(oFormat)
        Next
        DgvFormat.ClearSelection()
        isLoading = False
    End Sub
    Private Sub AddFormatRow(oFormat As RecordFormat)
        Dim oRow As DataGridViewRow = DgvFormat.Rows(DgvFormat.Rows.Add())
        oRow.Cells(fmtname.Name).Value = oFormat.FormatName
        oRow.Cells(fmtId.Name).Value = oFormat.FormatId
    End Sub
    Private Sub LoadFormatForm(pFormat As RecordFormat)
        With pFormat
            TxtFormatId.Text = CStr(.FormatId)
            TxtFormat.Text = .FormatName
        End With
    End Sub

    Private Sub LoadFormatForm(pRow As DataGridViewRow)
        With pRow
            TxtFormatId.Text = .Cells(fmtId.Name).Value
            TxtFormat.Text = .Cells(fmtname.Name).Value
            CurrentFormat = RecordFormatBuilder.ARecordFormat.StartingWithNothing.WithId(TxtFormatId.Text).WithFormatName(TxtFormat.Text).Build
        End With
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If isValidFormat Then
            InsertNewFormat()
            LoadFormatList()
        Else
            ShowStatus("Invalid Values", LblStatus,, False)
        End If
    End Sub

    Private Function isValidFormat() As Boolean
        Dim isValid As Boolean = True
        If String.IsNullOrEmpty(TxtFormatId.Text) OrElse TxtFormatId.TextLength > 3 Then
            isValid = False
        End If
        If String.IsNullOrEmpty(TxtFormat.Text) Then
            isValid = False
        End If
        Return isValid
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If DgvFormat.SelectedRows.Count = 1 Then
            UpdateFormatDetails()
            LoadFormatList()
            ClearForm()
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        TxtFormatId.Text = String.Empty
        TxtFormat.Text = String.Empty
        CurrentFormat = New RecordFormat
        DgvFormat.ClearSelection()
    End Sub

    Private Sub DgvFormat_SelectionChanged(sender As Object, e As EventArgs) Handles DgvFormat.SelectionChanged
        If Not isLoading Then
            If DgvFormat.SelectedRows.Count = 1 Then
                LoadFormatForm(DgvFormat.SelectedRows(0))
            End If
        End If
    End Sub
End Class