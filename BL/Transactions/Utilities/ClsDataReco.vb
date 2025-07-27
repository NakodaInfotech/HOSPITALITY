
Imports DB

Public Class ClsDataReco

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function RECO() As Integer
        Dim intResult As Integer
        Try
            'save NONPURCHASE 
            Dim strCommand As String = "SP_UTILITIES_RECOBOOKINGS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region


End Class
