
Imports DB

Public Class ClsDriverMaster
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

            'save DRIVERMASTER
            strcommand = "SP_MASTER_DRIVERMASTER_SAVE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MEMBERSHIPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISDOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@NATIONALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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

            'Update DRIVERMASTER
            strcommand = "SP_MASTER_DRIVERMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MEMBERSHIPNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISDOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@tel1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@faxno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@website", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@REFBY", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@NATIONALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DRIVERID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTDRIVERDETAILS() As DataTable

        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'Update GUESTMASTER
            strcommand = "SP_MASTER_SELECT_DRIVER"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE
    End Function

#End Region

End Class
