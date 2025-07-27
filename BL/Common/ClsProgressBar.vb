Imports DB

Public Class ClsProgressBar

    Private objDBOperation As DBOperation
    Dim intResult As Integer
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function CREATEUSER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEUSER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEGROUP() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEGROUP"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATELEDGER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATELEDGER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEREGISTER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEREGISTER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATECONFIG() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATECONFIG"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATETAX() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATETAX"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATESTATE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATESTATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATECURRENCY() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATECURRENCY"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(4)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
