' Hindleware
' Copyright (c) 2024-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Windows.Forms
Imports WMPLib

Module ModSongPlayer
    Private isPlaying As Boolean
    Private isPaused As Boolean
    Private ReadOnly oPlayer As New WindowsMediaPlayer
    Public Sub PlaySong(pFilename As String, ByRef pProgressBar As ProgressBar, ByRef pPlayButton As Button, ByRef pStopButton As Button)
        If isPlaying Then
            PauseAudio(pProgressBar, pPlayButton)
        Else
            Try
                If isPaused Then
                    oPlayer.controls.play()
                Else
                    Dim SongLocation = pFilename
                    oPlayer.URL = SongLocation
                    oPlayer.controls.play()
                End If
                PlayAudio(pProgressBar, pPlayButton, pStopButton)
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub StopAudio(pProgressBar As ProgressBar, pPlayButton As Button, pStopButton As Button)
        oPlayer.controls.stop()
        isPlaying = False
        isPaused = False
        pPlayButton.Image = My.Resources.play
        pStopButton.Enabled = False
        pProgressBar.Visible = False
    End Sub
    Public Sub PauseAudio(ByRef pProgressBar As ProgressBar, ByRef pPlayButton As Button)
        oPlayer.controls.pause()
        isPlaying = False
        isPaused = True
        pPlayButton.Image = My.Resources.play
        pProgressBar.Style = ProgressBarStyle.Continuous
        pProgressBar.Value = 0
    End Sub
    Private Sub PlayAudio(ByRef pProgressBar As ProgressBar, ByRef pPlayButton As Button, ByRef pStopButton As Button)
        pProgressBar.Style = ProgressBarStyle.Marquee
        pProgressBar.MarqueeAnimationSpeed = 20
        pProgressBar.Visible = True
        pPlayButton.Image = My.Resources.pause
        pStopButton.Enabled = True
        isPlaying = True
        isPaused = False

    End Sub

    Public Function IsValidSongFileName(pFilename As String)
        Dim isValid As Boolean = False
        If Not String.IsNullOrEmpty(pFilename) Then
            If pFilename.EndsWith(".wav") Or pFilename.EndsWith(".mp3") Then
                If My.Computer.FileSystem.FileExists(pFilename) Then
                    isValid = True
                End If
            End If
        End If
        Return isValid
    End Function

End Module
