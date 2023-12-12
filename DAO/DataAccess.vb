Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.Data.SqlClient
Public Class DataAccess
    Public Shared Function SQL(comandoSQL As String) As DataView
        Dim conString = ConfigurationManager.ConnectionStrings("ConnetionString").ConnectionString
        Dim connection As SqlConnection = New SqlConnection(conString)

        Dim command As New SqlCommand(comandoSQL, connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataSet

        connection.Open()
        sd.Fill(dt)

        Return dt.Tables(0).DefaultView

    End Function

    Public Shared Sub ExecuteReader(comandoSQL As String)
        Dim conString = ConfigurationManager.ConnectionStrings("ConnetionString").ConnectionString
        Dim connection As SqlConnection = New SqlConnection(conString)
        Dim command As New SqlCommand(comandoSQL, connection)
        Try
            connection.Open()
            command.ExecuteReader()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            command = Nothing
            connection.Close()
            connection = Nothing
        End Try
    End Sub

End Class
