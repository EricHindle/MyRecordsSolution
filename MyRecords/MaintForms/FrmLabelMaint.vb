' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmLabelMaint
    Private CurrentLabel As RecordLabel
    Private isLoading As Boolean
    Private Sub FrmLabelMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Label maintenance", MyBase.Name)
        GetFormPos(Me, My.Settings.LabelFormPos)
        LoadLabelList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmLabelMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.LabelFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub


    Private Sub InsertNewLabel()
        If Not String.IsNullOrWhiteSpace(TxtLabel.Text) Then
            ShowStatus("Adding new Label", LblStatus, MyBase.Name)
            Dim oLabel As RecordLabel = RecordLabelBuilder.ARecordLabel.StartingWithNothing _
                                                    .WithId(-1) _
                                                    .WithLabelName(TxtLabel.Text) _
                                                    .Build
            oLabel.LabelId = InsertLabel(oLabel)
            ShowStatus("Added Label", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not added.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub UpdateLabelDetails()
        If Not String.IsNullOrWhiteSpace(TxtLabel.Text) Then
            ShowStatus("Updating Label", LblStatus, MyBase.Name)
            Dim oLabel As RecordLabel = RecordLabelBuilder.ARecordLabel.StartingWithNothing _
                                                    .WithId(CurrentLabel.LabelId) _
                                                    .WithLabelName(TxtLabel.Text) _
                                                    .Build
            UpdateLabel(oLabel)
            ShowStatus("Updated Label", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not changed.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub LoadLabelList()
        isLoading = True
        Dim oLabelList As List(Of RecordLabel) = GetAllLabels()
        DgvLabel.Rows.Clear()
        For Each oLabel As RecordLabel In oLabelList
            AddLabelRow(oLabel)
        Next
        DgvLabel.ClearSelection()
        isLoading = False
    End Sub
    Private Sub AddLabelRow(oLabel As RecordLabel)
        Dim oRow As DataGridViewRow = DgvLabel.Rows(DgvLabel.Rows.Add())
        oRow.Cells(labname.Name).Value = oLabel.LabelName
        oRow.Cells(LabId.Name).Value = oLabel.LabelId
    End Sub
    Private Sub LoadLabelForm(pLabel As RecordLabel)
        With pLabel
            LblLabelId.Text = CStr(.LabelId)
            TxtLabel.Text = .LabelName
        End With
    End Sub

    Private Sub LoadLabelForm(pRow As DataGridViewRow)
        With pRow
            LblLabelId.Text = .Cells(LabId.Name).Value
            TxtLabel.Text = .Cells(labname.Name).Value
            CurrentLabel = RecordLabelBuilder.ARecordLabel.StartingWithNothing.WithId(LblLabelId.Text).WithLabelName(TxtLabel.Text).Build
            BtnUpdate.Enabled = True

        End With
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If isValidLabel() Then
            If GetLabelFromName(TxtLabel.Text).IsExists Then
                ShowStatus("Looks like the Label already exists", LblStatus, MyBase.Name, False,,, True,, True)
            Else
                InsertNewLabel()
            LoadLabelList()
                ClearForm()
            End If
        Else
            ShowStatus("Invalid Values", LblStatus,, False)
        End If
    End Sub

    Private Function isValidLabel() As Boolean
        Dim isValid As Boolean = True
        If String.IsNullOrEmpty(TxtLabel.Text) Then
            isValid = False
        End If
        Return isValid
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If DgvLabel.SelectedRows.Count = 1 Then
            UpdateLabelDetails()
            LoadLabelList()
            ClearForm()
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        LblLabelId.Text = "-1"
        TxtLabel.Text = String.Empty
        CurrentLabel = New RecordLabel
        DgvLabel.ClearSelection()
        BtnUpdate.Enabled = False
    End Sub

    Private Sub DgvLabel_SelectionChanged(sender As Object, e As EventArgs) Handles DgvLabel.SelectionChanged
        If Not isLoading Then
            If DgvLabel.SelectedRows.Count = 1 Then
                LoadLabelForm(DgvLabel.SelectedRows(0))
            End If
        End If
    End Sub

End Class