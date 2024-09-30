' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullRecord
    Private _record As Record
    Private _tracks As List(Of Track)
    Public Property Tracks() As List(Of Track)
        Get
            Return _tracks
        End Get
        Set(ByVal value As List(Of Track))
            _tracks = value
        End Set
    End Property
    Public Property Record() As Record
        Get
            Return _record
        End Get
        Set(ByVal value As Record)
            _record = value
        End Set
    End Property
    Private Sub Initialise()
        _record = New Record
        _tracks = New List(Of Track)
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pRecord As Record, pTracks As List(Of Track))
        _record = pRecord
        _tracks = pTracks
    End Sub
    Public Function IsExists() As Boolean
        Return _record.RecordId > -1
    End Function
    Public Sub AddTrack(pTrack As Track)
        _tracks.Add(pTrack)
    End Sub
    Public Sub AddTracks(pTracks As List(Of Track))
        _tracks.AddRange(pTracks)
    End Sub
End Class
