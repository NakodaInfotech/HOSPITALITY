
Imports DB

Public Class ClsFlightMaster

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

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try
            Dim I As Integer = 0
            'save CategoryMaster
            strcommand = "SP_MASTER_FLIGHTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINEPREF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINECODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BSP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOMESTIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LCC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_FLIGHTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@std", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@crdays", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@crlimit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PHONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POLICY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINEPREF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AIRLINECODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BSP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSRCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOMESTIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LCC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BASIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMPSF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMMTAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUTENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEPARTURE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ARRIVAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FLIGHTID", alParaval(I)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function getFLIGHT() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_FLIGHT"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_FLIGHTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@FLIGHTNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))


            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

#End Region

End Class
