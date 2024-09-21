' Hindleware
' Copyright (c) 2024 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Logging

Public Module ModGlobalSettings
#Region "constants"
    Private Const MODULE_NAME As String = "Global Settings"
#End Region
#Region "subroutines"
    Public Function GetGlobalSetting(ByVal settingName As String) As Object
        Return GetGlobalSetting(settingName, "", "")
    End Function
    Public Function GetGlobalSetting(ByVal settingName As String, defaultValue As String, defaultType As String) As Object
        LogUtil.Info("Get global setting " & settingName, MODULE_NAME)
        Dim rtnValue As Object
        Dim _setting As GlobalSetting = GetSettingByName(settingName, defaultValue, defaultType)
        Dim _default As String = ""
        Try
            rtnValue = ConvertSettingValue(_setting.Value, _setting.Type)
        Catch ex As ArgumentNullException
            LogUtil.Problem("Global value " & settingName & " cannot be converted correctly", "GetSetting")
            rtnValue = ConvertSettingValue(_default, _setting.Type)
        End Try
        Return rtnValue
    End Function

    Private Function ConvertSettingValue(pValue As String, pType As String) As Object
        Dim rtnValue As Object = pValue
        Try
            Select Case pType.ToLower(myCultureInfo)
                Case "string"
                    rtnValue = pValue
                Case "integer"
                    rtnValue = CInt(pValue)
                Case "date"
                    rtnValue = CDate(pValue)
                Case "boolean"
                    rtnValue = CBool(pValue)
                Case "decimal"
                    rtnValue = CDec(pValue)
                Case "char"
                    rtnValue = CChar(pValue)
            End Select
        Catch ex As Exception
        End Try
        Return rtnValue
    End Function
    Public Function StoreGlobalSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "", ByVal Optional isAddMissingSetting As Boolean = False) As Boolean
        LogUtil.Info("Storing global setting " & settingName, MODULE_NAME)
        Dim rtnVal As Boolean = False
        If IsSettingExists(settingName) Then
            rtnVal = ChangeSetting(settingName, settingType, settingValue, settingGroup)
        ElseIf isAddMissingSetting Then
            rtnVal = AddSetting(settingName, settingType, settingValue, settingGroup)
        End If
        Return rtnVal
    End Function
    Public Function SetSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        LogUtil.Info("Changing setting " & settingName, MODULE_NAME)
        Return ChangeSetting(settingName, settingType, settingValue, settingGroup)
    End Function
    Public Function NewSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        LogUtil.Info("New setting " & settingName, MODULE_NAME)
        Return AddSetting(settingName, settingType, settingValue, settingGroup)
    End Function
    Public Sub LoadGlobalSettings()
        My.Settings.Save()
    End Sub
#End Region
End Module
