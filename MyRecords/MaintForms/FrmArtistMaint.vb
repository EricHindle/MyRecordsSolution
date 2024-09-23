' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmArtistMaint
    Private CurrentArtist As Artist
    Private isLoading As Boolean
    Private Sub FrmArtistMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Artist maintenance", MyBase.Name)
        GetFormPos(Me, My.Settings.ArtistFormPos)
        LoadArtistList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmArtistMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.ArtistFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub


    Private Sub InsertNewArtist()
        If Not String.IsNullOrWhiteSpace(TxtArtist.Text) Then
            ShowStatus("Adding new Artist", LblStatus, MyBase.Name)
            Dim oArtist As Artist = ArtistBuilder.AnArtist.StartingWithNothing _
                                                    .WithId(-1) _
                                                    .WithArtistName(TxtArtist.Text) _
                                                    .Build
            oArtist.ArtistId = InsertArtist(oArtist)
            ShowStatus("Added Artist", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not added.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub UpdateArtistDetails()
        If Not String.IsNullOrWhiteSpace(TxtArtist.Text) Then
            ShowStatus("Updating Artist", LblStatus, MyBase.Name)
            Dim oArtist As Artist = ArtistBuilder.AnArtist.StartingWithNothing _
                                                    .WithId(CurrentArtist.ArtistId) _
                                                    .WithArtistName(TxtArtist.Text) _
                                                    .Build
            UpdateArtist(oArtist)
            ShowStatus("Updated Artist", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not changed.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub LoadArtistList()
        isLoading = True
        Dim oArtistList As List(Of Artist) = GetAllArtists()
        DgvArtist.Rows.Clear()
        For Each oArtist As Artist In oArtistList
            AddArtistRow(oArtist)
        Next
        DgvArtist.ClearSelection()
        isLoading = False
    End Sub
    Private Sub AddArtistRow(oArtist As Artist)
        Dim oRow As DataGridViewRow = DgvArtist.Rows(DgvArtist.Rows.Add())
        oRow.Cells(labname.Name).Value = oArtist.ArtistName
        oRow.Cells(LabId.Name).Value = oArtist.ArtistId
    End Sub
    Private Sub LoadArtistForm(pArtist As Artist)
        With pArtist
            LblArtistId.Text = CStr(.ArtistId)
            TxtArtist.Text = .ArtistName
        End With
    End Sub

    Private Sub LoadArtistForm(pRow As DataGridViewRow)
        With pRow
            LblArtistId.Text = .Cells(LabId.Name).Value
            TxtArtist.Text = .Cells(labname.Name).Value
            CurrentArtist = ArtistBuilder.AnArtist.StartingWithNothing.WithId(LblArtistId.Text).WithArtistName(TxtArtist.Text).Build
            BtnUpdate.Enabled = True

        End With
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If isValidArtist() Then
            InsertNewArtist()
            LoadArtistList()
            ClearForm()
        Else
            ShowStatus("Invalid Values", LblStatus,, False)
        End If
    End Sub

    Private Function isValidArtist() As Boolean
        Dim isValid As Boolean = True
        If String.IsNullOrEmpty(TxtArtist.Text) Then
            isValid = False
        End If
        Return isValid
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If DgvArtist.SelectedRows.Count = 1 Then
            UpdateArtistDetails()
            LoadArtistList()
            ClearForm()
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        LblArtistId.Text = "-1"
        TxtArtist.Text = String.Empty
        CurrentArtist = New Artist
        DgvArtist.ClearSelection()
        BtnUpdate.Enabled = False
    End Sub

    Private Sub DgvArtist_SelectionChanged(sender As Object, e As EventArgs) Handles DgvArtist.SelectionChanged
        If Not isLoading Then
            If DgvArtist.SelectedRows.Count = 1 Then
                LoadArtistForm(DgvArtist.SelectedRows(0))
            End If
        End If
    End Sub

End Class