' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports HindlewareLib.Imaging.ImageUtil
Imports HindlewareLib.Logging
Imports MyVinyl.Domain

Public Class FrmArtistMaint
    Private oCurrentArtist As Artist
    Private oCurrentImage As String
    Private oNewImage As String
    Private isLoading As Boolean
    Private _isSaveAndExit As Boolean
    Private _artist As New Artist
    Public Property Artist() As Artist
        Get
            Return _artist
        End Get
        Set(ByVal value As Artist)
            _artist = value
        End Set
    End Property
    Public Property IsSaveAndExit() As Boolean
        Get
            Return _isSaveAndExit
        End Get
        Set(ByVal value As Boolean)
            _isSaveAndExit = value
        End Set
    End Property

    Private Sub FrmArtistMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Artist maintenance", MyBase.Name)
        GetFormPos(Me, My.Settings.ArtistFormPos)
        LblImageMissing.Visible = False
        LoadArtistList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        _artist = New Artist
        Close()
    End Sub

    Private Sub FrmArtistMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", Name)
        My.Settings.ArtistFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub InsertNewArtist()
        If Not String.IsNullOrWhiteSpace(TxtArtist.Text) Then
            LogUtil.ShowStatus("Adding new Artist", LblStatus, Name)
            Artist = ArtistBuilder.AnArtist.StartingWithNothing _
                                                    .WithId(-1) _
                                                    .WithArtistName(TxtArtist.Text) _
                                                    .Build
            Artist.ArtistId = InsertArtist(Artist)
            If Not String.IsNullOrEmpty(oNewImage) Then
                TryCopyFile(oNewImage, oCurrentImage, True)
            End If
            LogUtil.ShowStatus("Added Artist", LblStatus, Name)
        Else
            LogUtil.ShowStatus("No Name. Not added.", LblStatus, False, Nothing, True)
        End If
    End Sub
    Private Sub UpdateArtistDetails()
        If Not String.IsNullOrWhiteSpace(TxtArtist.Text) Then
            LogUtil.ShowStatus("Updating Artist", LblStatus, MyBase.Name)
            Dim oArtist As Artist = ArtistBuilder.AnArtist.StartingWithNothing _
                                                    .WithId(oCurrentArtist.ArtistId) _
                                                    .WithArtistName(TxtArtist.Text) _
                                                    .WithArtistImage(TxtImageFile.Text) _
                                                    .Build
            UpdateArtist(oArtist)
            If Not String.IsNullOrEmpty(oNewImage) Then
                If String.IsNullOrEmpty(oCurrentImage) Then
                    oCurrentImage = Path.Combine(My.Settings.ImagePath, Path.GetFileName(oNewImage))
                End If
                TryCopyFile(oNewImage, oCurrentImage, True)
            End If
            LogUtil.ShowStatus("Updated Artist", LblStatus, MyBase.Name)
        Else
            LogUtil.ShowStatus("No Name. Not changed.", LblStatus, False, Nothing, True)
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
        oRow.Cells(artName.Name).Value = oArtist.ArtistName
        oRow.Cells(artId.Name).Value = oArtist.ArtistId
    End Sub
    Private Sub LoadArtistForm(pArtist As Artist)
        With pArtist
            LblArtistId.Text = CStr(.ArtistId)
            TxtArtist.Text = .ArtistName
        End With
    End Sub

    Private Sub LoadArtistForm(pRow As DataGridViewRow)
        With pRow
            LblArtistId.Text = .Cells(artId.Name).Value
            oCurrentArtist = GetArtistFromId(.Cells(artId.Name).Value)
            If Not String.IsNullOrEmpty(oCurrentArtist.ArtistImage) Then
                oCurrentImage = Path.Combine(My.Settings.ImagePath, oCurrentArtist.ArtistImage)
            Else
                oCurrentImage = String.Empty
            End If
            oNewImage = String.Empty
            TxtArtist.Text = oCurrentArtist.ArtistName
            TxtImageFile.Text = oCurrentArtist.ArtistImage
            If Not String.IsNullOrEmpty(TxtImageFile.Text) Then
                LoadArtistImage(TxtImageFile.Text)
            Else
                PicImage.Image = Nothing
            End If
            BtnUpdate.Enabled = True
        End With
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        If IsValidArtist() Then
            If GetArtistFromName(TxtArtist.Text).IsExists Then
                LogUtil.DisplayStatus("Looks like the Artist already exists", LblStatus, True)
            Else
                InsertNewArtist()

                If IsSaveAndExit Then
                    Close()
                Else
                    LoadArtistList()
                    ClearForm()
                End If
            End If
        Else
            LogUtil.ShowStatus("Invalid Values", LblStatus, False, Nothing, True)
        End If
    End Sub

    Private Function IsValidArtist() As Boolean
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
        TxtImageFile.Text = String.Empty
        oCurrentArtist = New Artist
        oCurrentImage = String.Empty
        oNewImage = String.Empty
        PicImage.Image = Nothing
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

    Private Sub TxtArtist_DragEnter(sender As Object, e As DragEventArgs) Handles TxtArtist.DragEnter
        TextBox_DragEnter(sender, e)
    End Sub

    Private Sub TxtArtist_DragDrop(sender As Object, e As DragEventArgs) Handles TxtArtist.DragDrop
        TextBox_DragDrop(sender, e)
    End Sub

    Private Sub TxtArtist_TextChanged(sender As Object, e As EventArgs) Handles TxtArtist.TextChanged
        If Not String.IsNullOrEmpty(TxtArtist.Text) Then
            FindArtistInList(TxtArtist.Text.Trim)
        End If
    End Sub
    Private Sub FindArtistInList(pName As String)
        For Each oRow As DataGridViewRow In DgvArtist.Rows
            If CStr(oRow.Cells(artName.Name).Value).ToLower.StartsWith(pName.ToLower) Then
                DgvArtist.FirstDisplayedScrollingRowIndex = oRow.Index
                Exit For
            End If
        Next
    End Sub

    Private Sub PicImage_Click(sender As Object, e As EventArgs) Handles PicImage.Click
        Dim _newImageFile As String = GetImageFileName(OpenOrSave.Open, ImageType.ALL, TxtImageFile.Text)
        If Not String.IsNullOrWhiteSpace(_newImageFile) Then
            Try
                TxtImageFile.Text = Path.GetFileName(_newImageFile)
                LoadArtistImage(_newImageFile)
                PicImage.Refresh()
                Dim oArtistImageFile As String = Path.Combine(My.Settings.ImagePath, TxtImageFile.Text)
                If _newImageFile <> oArtistImageFile Then
                    If My.Computer.FileSystem.FileExists(oArtistImageFile) Then
                        If MsgBox("Replace image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "New Image") = MsgBoxResult.Yes Then
                            oNewImage = _newImageFile
                        End If
                    Else
                        If MsgBox("Use new image?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "New Image") = MsgBoxResult.Yes Then
                            oNewImage = _newImageFile
                        Else
                            TxtImageFile.Text = String.Empty
                            oNewImage = String.Empty
                        End If
                    End If
                End If
            Catch ex As Exception
                LogUtil.Info("Error obtaining new image", MyBase.Name)
            End Try
        End If
    End Sub
    Private Sub LoadArtistImage(pFilename As String)
        Dim fullFilename As String = Path.Combine(My.Settings.ImagePath, pFilename)
        LogUtil.ShowStatus("Finding Image " & fullFilename, LblStatus, MyBase.Name)
        If My.Computer.FileSystem.FileExists(fullFilename) Then
            PicImage.Image = System.Drawing.Image.FromFile(fullFilename)
            LblImageMissing.Visible = False
        Else
            LogUtil.ShowStatus("File " & fullFilename & " does not exist", LblStatus, True, MyBase.Name, IsBeep:=True)
            PicImage.Image = Nothing
            LblImageMissing.Visible = True
        End If
    End Sub


End Class