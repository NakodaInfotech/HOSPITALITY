Imports DB

Public Class ClsTariffMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function SAVE() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_TARIFFMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TARIFFPLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''**GRID PARAMETER**

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEEKDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEEKENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAX", alParaval(I)))
                I = I + 1

                'SCAN DOCS
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_TARIFFMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TARIFFPLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''**GRID PARAMETER**

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEEKDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEEKENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COMM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAX", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAX", alParaval(I)))
                I = I + 1

                'SCAN DOCS
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TARIFFID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_TARIFFMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TARIFFNAME", alParaval(0)))
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

    Public Function GETTARIFF() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_TARIFF"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TARIFFNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
