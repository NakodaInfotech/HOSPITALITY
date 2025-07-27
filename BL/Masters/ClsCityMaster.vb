Imports DB

Public Class ClsCityMaster

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

    Public Function save() As Integer

        Dim intResult As Integer
        'Dim cityid, stateid, countryid As Integer

        'Dim objTrans As SqlClient.SqlTransaction
        'objTrans = objDBOperation.StartNewTransaction
        Try

            Dim strCommand As String = "SP_MASTER_CMPMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                '.Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                '.Add(New SqlClient.SqlParameter("@cmpperson", alParaval(1)))
                '.Add(New SqlClient.SqlParameter("@cmppersontype", alParaval(2)))
                '.Add(New SqlClient.SqlParameter("@cmpdisplayedname", alParaval(3)))
                '.Add(New SqlClient.SqlParameter("@cmpinvinitials", alParaval(4)))
                '.Add(New SqlClient.SqlParameter("@cmpinvfooter", alParaval(5)))
                '.Add(New SqlClient.SqlParameter("@cmpadd1", alParaval(6)))
                '.Add(New SqlClient.SqlParameter("@cmpadd2", alParaval(7)))
                '.Add(New SqlClient.SqlParameter("@cmpcityid", cityid))
                '.Add(New SqlClient.SqlParameter("@cmpzipcode", alParaval(9)))
                '.Add(New SqlClient.SqlParameter("@cmpstateid", stateid))
                '.Add(New SqlClient.SqlParameter("@cmpcountryid", countryid))
                '.Add(New SqlClient.SqlParameter("@cmptel", alParaval(12)))
                '.Add(New SqlClient.SqlParameter("@cmpfax", alParaval(13)))
                '.Add(New SqlClient.SqlParameter("@cmpemail", alParaval(14)))
                '.Add(New SqlClient.SqlParameter("@cmpwebsite", alParaval(15)))
                '.Add(New SqlClient.SqlParameter("@cmpvatno", alParaval(16)))
                '.Add(New SqlClient.SqlParameter("@cmpcstno", alParaval(17)))
                '.Add(New SqlClient.SqlParameter("@cmpstno", alParaval(18)))
                '.Add(New SqlClient.SqlParameter("@cmppanno", alParaval(19)))
                '.Add(New SqlClient.SqlParameter("@cmpeccno", alParaval(20)))
                '.Add(New SqlClient.SqlParameter("@cmpexciseno", alParaval(21)))
                '.Add(New SqlClient.SqlParameter("@cmpplano", alParaval(22)))
                '.Add(New SqlClient.SqlParameter("@cmprange", alParaval(23)))
                '.Add(New SqlClient.SqlParameter("@cmpdivision", alParaval(24)))
                '.Add(New SqlClient.SqlParameter("@cmpexciseoff", alParaval(25)))
                '.Add(New SqlClient.SqlParameter("@cmpdivisionoff", alParaval(26)))
                '.Add(New SqlClient.SqlParameter("@cmpcommissionerate", alParaval(27)))
                '.Add(New SqlClient.SqlParameter("@cmpheadingno", alParaval(28)))
                '.Add(New SqlClient.SqlParameter("@cmpnotificationno", alParaval(29)))
                '.Add(New SqlClient.SqlParameter("@cmppassword", alParaval(30)))
                '.Add(New SqlClient.SqlParameter("@cmpuserid", alParaval(31)))
                '.Add(New SqlClient.SqlParameter("@cmptransfer", alParaval(32)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@fld2", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UpdateCity() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cityid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateGift() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_GIFTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GIFT_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@GIFT_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@GIFT_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@GIFT_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@GIFT_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@GIFT_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@GIFT_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@GIFTid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateCcrrency() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CURRENCYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cur_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CUR_CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CUR_IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_transfer", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@curid", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateLogin() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_LOGINMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@login_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@login_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@login_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@login_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@login_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@login_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@login_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@loginid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateIDType() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_IDMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ID_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ID_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@ID_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@ID_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@ID_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@ID_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@ID_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@IDid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


    Public Function UpdateArea() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@area_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@area_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@area_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@area_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@area_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@area_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@area_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@areaid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateState() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_STATEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@state_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@state_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@state_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@state_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@state_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@state_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@state_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@stateid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateCountry() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@Country_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Country_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Country_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Country_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Country_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Country_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@Country_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@Countryid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateDocument() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_DOCMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@doc_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@doc_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@doc_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@doc_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@doc_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@doc_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@doc_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@docid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


    Public Function DELETEAREA() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@AREANAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function DELETECURRENCY() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_CURRENCYMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CURRENCYNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETECITY() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CITYNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETEGIFT() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GIFTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GIFTNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function DELETLOGIN() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_LOGINMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@LOGINNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETID() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_IDMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@IDNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1

            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function DELETESTATE() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_STATEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1


            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETECOUNTRY() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@COUNTRYNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETEDOC() As DataTable
        Dim DT As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_DOCMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DOCNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
