Imports DB

Public Class ClsDelete

    Private objDBOperation As DBOperation
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

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_DELETEDETAILS_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DELID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With

            'intResult = objDBOperation.execute(strCommand, alParameter).Tables(0)
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            'Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete_DATE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_DELETEDETAILS_DELETE_DATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(1)))
            End With

            'intResult = objDBOperation.execute(strCommand, alParameter).Tables(0)
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            'Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region
End Class
