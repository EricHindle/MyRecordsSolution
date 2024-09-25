' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Class FrmGenreMaint
    Private CurrentGenre As Genre
    Private isLoading As Boolean
    Private Sub FrmGenreMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Genre maintenance", MyBase.Name)
        GetFormPos(Me, My.Settings.GenreFormPos)
        LoadGenreList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmGenreMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.GenreFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub


    Private Sub InsertNewGenre()
        If Not String.IsNullOrWhiteSpace(TxtGenre.Text) Then
            ShowStatus("Adding new Genre", LblStatus, MyBase.Name)
            Dim oGenre As Genre = GenreBuilder.AGenre.StartingWithNothing _
                                                    .WithId(-1) _
                                                    .WithGenreName(TxtGenre.Text) _
                                                    .Build
            oGenre.GenreId = InsertGenre(oGenre)
            ShowStatus("Added Genre", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not added.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub UpdateGenreDetails()
        If Not String.IsNullOrWhiteSpace(TxtGenre.Text) Then
            ShowStatus("Updating Genre", LblStatus, MyBase.Name)
            Dim oGenre As Genre = GenreBuilder.AGenre.StartingWithNothing _
                                                    .WithId(CurrentGenre.GenreId) _
                                                    .WithGenreName(TxtGenre.Text) _
                                                    .Build
            UpdateGenre(oGenre)
            ShowStatus("Updated Genre", LblStatus, MyBase.Name)
        Else
            ShowStatus("No Name. Not changed.", LblStatus, , False, IsBeep:=True)
        End If
    End Sub
    Private Sub LoadGenreList()
        isLoading = True
        Dim oGenreList As List(Of Genre) = GetAllGenres()
        DgvGenre.Rows.Clear()
        For Each oGenre As Genre In oGenreList
            AddGenreRow(oGenre)
        Next
        DgvGenre.ClearSelection()
        isLoading = False
    End Sub
    Private Sub AddGenreRow(oGenre As Genre)
        Dim oRow As DataGridViewRow = DgvGenre.Rows(DgvGenre.Rows.Add())
        oRow.Cells(genname.Name).Value = oGenre.GenreName
        oRow.Cells(genId.Name).Value = oGenre.GenreId
    End Sub
    Private Sub LoadGenreForm(pGenre As Genre)
        With pGenre
            LblGenreId.Text = CStr(.GenreId)
            TxtGenre.Text = .GenreName
        End With
    End Sub

    Private Sub LoadGenreForm(pRow As DataGridViewRow)
        With pRow
            LblGenreId.Text = .Cells(genId.Name).Value
            TxtGenre.Text = .Cells(genname.Name).Value
            CurrentGenre = GenreBuilder.AGenre.StartingWithNothing.WithId(LblGenreId.Text).WithGenreName(TxtGenre.Text).Build
            BtnUpdate.Enabled = True

        End With
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If isValidGenre() Then
            If GetGenreFromName(TxtGenre.Text).IsExists Then
                ShowStatus("Looks like the Genre already exists", LblStatus, MyBase.Name, False,,, True,, True)
            Else
                InsertNewGenre()
                LoadGenreList()
                ClearForm()
            End If
        Else
            ShowStatus("Invalid Values", LblStatus,, False)
        End If
    End Sub

    Private Function isValidGenre() As Boolean
        Dim isValid As Boolean = True
        If String.IsNullOrEmpty(TxtGenre.Text) Then
            isValid = False
        End If
        Return isValid
    End Function

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If DgvGenre.SelectedRows.Count = 1 Then
            UpdateGenreDetails()
            LoadGenreList()
            ClearForm()
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        LblGenreId.Text = "-1"
        TxtGenre.Text = String.Empty
        CurrentGenre = New Genre
        DgvGenre.ClearSelection()
        BtnUpdate.Enabled = False
    End Sub

    Private Sub DgvGenre_SelectionChanged(sender As Object, e As EventArgs) Handles DgvGenre.SelectionChanged
        If Not isLoading Then
            If DgvGenre.SelectedRows.Count = 1 Then
                LoadGenreForm(DgvGenre.SelectedRows(0))
            End If
        End If
    End Sub

End Class