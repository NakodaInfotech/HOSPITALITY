
Imports DB

Public Class ClsAirlineStockMaster

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

#Region "Function"

    Public Function SAVE() As DataTable
        'Dim intResult As Integer
        Dim dtTable As DataTable

        Try

            'save GROUP OF HOTELS
            Dim strCommand As String = "SP_MASTER_AIRLINESTOCK_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1

                'PUR CODE AND NAME
                .Add(New SqlClient.SqlParameter("@PURCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISSUED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PTA", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPECIAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
            End With

            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable

    End Function

    Public Function update() As DataTable
        'Dim intResult As Integer
        Dim dtTable As DataTable
        Try

            'save gradeMaster
            Dim strCommand As String = "SP_MASTER_AIRLINESTOCK_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1

                'PUR CODE AND NAME
                .Add(New SqlClient.SqlParameter("@PURCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISSUED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PTA", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPECIAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TICKETNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AIRLINEID", alParaval(I)))
                I += 1

            End With

            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable

    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer

        Try

            'save gradeMaster
            Dim strCommand As String = "SP_MASTER_AIRLINESTOCK_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@AIRLINEID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
