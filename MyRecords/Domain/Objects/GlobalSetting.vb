' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class GlobalSetting
#Region "properties"
    Private _name As String
    Private _type As String
    Private _value As String
    Private _group As String
    Public Property Group() As String
        Get
            Return _group
        End Get
        Set(ByVal value As String)
            _group = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _name = ""
        _type = ""
        _value = ""
        _group = ""
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pName As String, pType As String, pValue As String, pGroup As String)
        _name = pName
        _type = pType
        _value = pValue
        _group = pGroup
    End Sub
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb _
            .Append("GlobalSetting=[") _
            .Append("Name=[") _
            .Append(_name) _
            .Append("], Type=[") _
            .Append(_type) _
            .Append("], Value=[") _
            .Append(_value) _
            .Append("], Group=[") _
            .Append(_group) _
            .Append("]]")
        Return sb.ToString
    End Function
#End Region
End Class
