Imports DB

Public Class ClsHotelMaster

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

    Public Function save() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_HOTELMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPOFHOTELS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AREANAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ZIPCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNTRYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ALTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAXNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEBSITE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@AMENITIESID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEMAIL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVENTORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_HOTELMASTER_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PERSON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROUPOFHOTELS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKIN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADD2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AREANAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ZIPCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNTRYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ALTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TEL1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FAXNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEBSITE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@AMENITIESID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROOMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFROOMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CEMAIL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVENTORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOTELID", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_HOTELMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@HOTELNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function getHOTEL() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_HOTEL"

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

#End Region



End Class
