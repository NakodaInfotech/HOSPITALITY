Imports db


Public Class ClsYearMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim areaid, cityid, stateid, countryid, currencyid, Giftid, DocID As Integer
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

    Public Function savearea(ByVal areaname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal arearemark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("area_id", "", "AreaMaster", whereclause & " AND AREA_NAME = '" & areaname & "' AND AREA_YEARID = " & YEAR)
        If (dt.Rows.Count) > 0 Then
            areaid = dt.Rows.Item(0).Item("area_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_AREAMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@area_name", areaname))
                .Add(New SqlClient.SqlParameter("@area_remark", arearemark))
                .Add(New SqlClient.SqlParameter("@area_cmpid", CMP))
                .Add(New SqlClient.SqlParameter("@area_locationid", LOCATION))
                .Add(New SqlClient.SqlParameter("@area_userid", userid))
                .Add(New SqlClient.SqlParameter("@area_yearid", YEAR))
                .Add(New SqlClient.SqlParameter("@area_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If

    End Function

    Public Function savecity(ByVal cityname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal cityremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("city_id", "", "citymaster", whereclause & " AND CITY_NAME = '" & cityname & "' AND CITY_YEARID = " & YEAR)
        If (dt.Rows.Count) > 0 Then
            cityid = dt.Rows.Item(0).Item("city_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_CITYMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@city_name", cityname))
                .Add(New SqlClient.SqlParameter("@city_remark", cityremark))
                .Add(New SqlClient.SqlParameter("@city_CMPID", CMP))
                .Add(New SqlClient.SqlParameter("@city_LOCATIONID", LOCATION))
                .Add(New SqlClient.SqlParameter("@city_userid", userid))
                .Add(New SqlClient.SqlParameter("@city_YEARID", YEAR))
                .Add(New SqlClient.SqlParameter("@city_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If

    End Function

    Public Function savegift(ByVal giftname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal giftremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("gift_id", "", "giftmaster", whereclause)
        If (dt.Rows.Count) > 0 Then
            Giftid = dt.Rows.Item(0).Item("gift_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_GIFTMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@GIFT_name", giftname))
                .Add(New SqlClient.SqlParameter("@GIFT_remark", giftremark))
                .Add(New SqlClient.SqlParameter("@GIFT_CMPID", CMP))
                .Add(New SqlClient.SqlParameter("@GIFT_LOCATIONID", LOCATION))
                .Add(New SqlClient.SqlParameter("@GIFT_userid", userid))
                .Add(New SqlClient.SqlParameter("@GIFT_YEARID", YEAR))
                .Add(New SqlClient.SqlParameter("@GIFT_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If

    End Function

    Public Function savecurrency() As Integer
        Try
            Dim strCmd As String = "SP_MASTER_CURRENCYMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@cur_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CUR_CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CUR_IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cur_transfer", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function savelogin(ByVal LOGINname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal LOGINremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("LOGIN_id", "", "LOGINmaster", whereclause)
        If (dt.Rows.Count) > 0 Then
            cityid = dt.Rows.Item(0).Item("LOGIN_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_LOGINMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@login_name", LOGINname))
                .Add(New SqlClient.SqlParameter("@login_remark", LOGINremark))
                .Add(New SqlClient.SqlParameter("@login_CMPID", CMP))
                .Add(New SqlClient.SqlParameter("@login_LOCATIONID", LOCATION))
                .Add(New SqlClient.SqlParameter("@login_userid", userid))
                .Add(New SqlClient.SqlParameter("@login_YEARID", YEAR))
                .Add(New SqlClient.SqlParameter("@login_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If

    End Function

    Public Function saveID(ByVal Idname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal IDremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("ID_id", "", "IDmaster", whereclause)
        If (dt.Rows.Count) > 0 Then
            cityid = dt.Rows.Item(0).Item("ID_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_IDMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@ID_name", Idname))
                .Add(New SqlClient.SqlParameter("@ID_remark", IDremark))
                .Add(New SqlClient.SqlParameter("@ID_CMPID", CMP))
                .Add(New SqlClient.SqlParameter("@ID_LOCATIONID", LOCATION))
                .Add(New SqlClient.SqlParameter("@ID_userid", userid))
                .Add(New SqlClient.SqlParameter("@ID_YEARID", YEAR))
                .Add(New SqlClient.SqlParameter("@ID_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If

    End Function

    Public Function savestate(ByVal statename As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal stateremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("state_id", "", "statemaster", whereclause & " AND STATE_NAME = '" & statename & "' AND STATE_YEARID = " & YEAR)
        If (dt.Rows.Count) > 0 Then
            stateid = dt.Rows.Item(0).Item("state_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_STATEMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@state_name", statename))
                .Add(New SqlClient.SqlParameter("@state_remark", stateremark))
                .Add(New SqlClient.SqlParameter("@state_cmpid", CMP))
                .Add(New SqlClient.SqlParameter("@state_locationid", LOCATION))
                .Add(New SqlClient.SqlParameter("@state_userid", userid))
                .Add(New SqlClient.SqlParameter("@state_yearid", YEAR))
                .Add(New SqlClient.SqlParameter("@state_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If
    End Function

    Public Function savecountry(ByVal countryname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal countryremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("country_id", "", "countrymaster", whereclause & " AND COUNTRY_NAME = '" & countryname & "' AND COUNTRY_YEARID = " & YEAR)
        If (dt.Rows.Count) > 0 Then
            countryid = dt.Rows.Item(0).Item("country_id").ToString
        Else

            Dim strCmd As String = "SP_MASTER_COUNTRYMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@country_name", countryname))
                .Add(New SqlClient.SqlParameter("@country_remark", countryremark))
                .Add(New SqlClient.SqlParameter("@country_cmpid", CMP))
                .Add(New SqlClient.SqlParameter("@country_locationid", LOCATION))
                .Add(New SqlClient.SqlParameter("@country_userid", userid))
                .Add(New SqlClient.SqlParameter("@country_yearid", YEAR))
                .Add(New SqlClient.SqlParameter("@country_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If
    End Function

    Public Function savedocument(ByVal docname As String, ByVal CMP As Integer, ByVal LOCATION As Integer, ByVal userid As Integer, ByVal YEAR As Integer, Optional ByVal whereclause As String = "", Optional ByVal docremark As String = "") As Integer

line1:
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("Doc_id", "", "DOCMASTER", whereclause)
        If (dt.Rows.Count) > 0 Then
            DocID = dt.Rows.Item(0).Item("Doc_id").ToString
        Else
            Dim strCmd As String = "SP_MASTER_DOCMASTER_SAVE"
            Dim alpara As New ArrayList
            With alpara
                .Add(New SqlClient.SqlParameter("@doc_name", docname))
                .Add(New SqlClient.SqlParameter("@doc_remark", docremark))
                .Add(New SqlClient.SqlParameter("@doc_cmpid", CMP))
                .Add(New SqlClient.SqlParameter("@doc_locationid", LOCATION))
                .Add(New SqlClient.SqlParameter("@doc_userid", userid))
                .Add(New SqlClient.SqlParameter("@doc_yearid", YEAR))
                .Add(New SqlClient.SqlParameter("@doc_transfer", 0))
            End With

            intResult = objDBOperation.executeNonQuery(strCmd, alpara)
            GoTo line1
        End If
    End Function


    Public Function SAVE() As Integer

        Try

            'search whether city is present or not
            If alParaval(8).ToString <> "" Then
                savecity(alParaval(8), alParaval(48), 0, 0, 0)
            End If

            'search whether state is present or not
            If alParaval(10).ToString <> "" Then
                savestate(alParaval(10), alParaval(48), 0, 0, 0)
            End If


            'search whether Country is present or not
            If alParaval(11).ToString <> "" Then
                savecountry(alParaval(11), alParaval(48), 0, 0, 0)
            End If



            'save cmpdetails
            Dim strCommand As String = "SP_MASTER_CMPMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpperson", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmppersontype", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpdisplayedname", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpinvinitials", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpinvfooter", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpadd1", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cmpadd2", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@cmpcityid", cityid))
                .Add(New SqlClient.SqlParameter("@cmpzipcode", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@cmpstateid", stateid))
                .Add(New SqlClient.SqlParameter("@cmpcountryid", countryid))
                .Add(New SqlClient.SqlParameter("@cmptel", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@cmpfax", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@cmpemail", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@cmpwebsite", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@HEIGHT", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@ALLOWGST", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@APPLYCESS", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@SAMESTATE", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@cmpvatno", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@cmpcstno", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@cmpstno", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@cmppanno", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@cmpeccno", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@cmpexciseno", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@cmpplano", alParaval(30)))
                .Add(New SqlClient.SqlParameter("@cmprange", alParaval(31)))
                .Add(New SqlClient.SqlParameter("@cmpdivision", alParaval(32)))
                .Add(New SqlClient.SqlParameter("@cmpexciseoff", alParaval(33)))
                .Add(New SqlClient.SqlParameter("@cmpdivisionoff", alParaval(34)))
                .Add(New SqlClient.SqlParameter("@cmpcommissionerate", alParaval(35)))
                .Add(New SqlClient.SqlParameter("@cmpheadingno", alParaval(36)))
                .Add(New SqlClient.SqlParameter("@cmpGSTIN", alParaval(37)))
                .Add(New SqlClient.SqlParameter("@TAXASSNO", alParaval(38)))
                .Add(New SqlClient.SqlParameter("@ITWARDNO", alParaval(39)))
                .Add(New SqlClient.SqlParameter("@DEDUCTORTYPE", alParaval(40)))
                .Add(New SqlClient.SqlParameter("@RESPONSIBLE", alParaval(41)))
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(42)))
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(43)))
                .Add(New SqlClient.SqlParameter("@CMPEWBUSER", alParaval(44)))
                .Add(New SqlClient.SqlParameter("@CMPEWBPASS", alParaval(45)))
                .Add(New SqlClient.SqlParameter("@DISPATCHFROM", alParaval(46)))
                .Add(New SqlClient.SqlParameter("@cmppassword", alParaval(47)))
                .Add(New SqlClient.SqlParameter("@cmpuserid", alParaval(48)))
                .Add(New SqlClient.SqlParameter("@cmptransfer", alParaval(49)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)


            'save yearmaster
            strCommand = "SP_MASTER_YEARMASTER_SAVE"
            alParameter.Clear()
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearstart", alParaval(50)))
                .Add(New SqlClient.SqlParameter("@yearend", alParaval(51)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(48)))
                .Add(New SqlClient.SqlParameter("@locationid", "0"))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(49)))
                .Add(New SqlClient.SqlParameter("@cmpwithotsp", alParaval(53)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)



        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function saveyear() As Integer

        Try

            'save cmpdetails
            Dim strCommand As String = "SP_MASTER_YEARMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearstart", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@yearend", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", "0"))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpwithotsp", alParaval(5)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            Return intResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer

        Try

            'search whether city is present or not
            If alParaval(8).ToString <> "" Then
                savecity(alParaval(8), alParaval(48), 0, 0, 0)
            End If

            'search whether state is present or not
            If alParaval(10).ToString <> "" Then
                savestate(alParaval(10), alParaval(48), 0, 0, 0)
            End If


            'search whether Country is present or not
            If alParaval(11).ToString <> "" Then
                savecountry(alParaval(11), alParaval(48), 0, 0, 0)
            End If



            'save cmpdetails
            Dim strCommand As String = "SP_MASTER_CMPMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpperson", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmppersontype", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpdisplayedname", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpinvinitials", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpinvfooter", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpadd1", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cmpadd2", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@cmpcityid", cityid))
                .Add(New SqlClient.SqlParameter("@cmpzipcode", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@cmpstateid", stateid))
                .Add(New SqlClient.SqlParameter("@cmpcountryid", countryid))
                .Add(New SqlClient.SqlParameter("@cmptel", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@cmpfax", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@cmpemail", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@cmpwebsite", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@HEIGHT", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@ALLOWGST", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@APPLYCESS", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@SAMESTATE", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@cmpvatno", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@cmpcstno", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@cmpstno", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@cmppanno", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@cmpeccno", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@cmpexciseno", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@cmpplano", alParaval(30)))
                .Add(New SqlClient.SqlParameter("@cmprange", alParaval(31)))
                .Add(New SqlClient.SqlParameter("@cmpdivision", alParaval(32)))
                .Add(New SqlClient.SqlParameter("@cmpexciseoff", alParaval(33)))
                .Add(New SqlClient.SqlParameter("@cmpdivisionoff", alParaval(34)))
                .Add(New SqlClient.SqlParameter("@cmpcommissionerate", alParaval(35)))
                .Add(New SqlClient.SqlParameter("@cmpheadingno", alParaval(36)))
                .Add(New SqlClient.SqlParameter("@cmpGSTIN", alParaval(37)))
                .Add(New SqlClient.SqlParameter("@TAXASSNO", alParaval(38)))
                .Add(New SqlClient.SqlParameter("@ITWARDNO", alParaval(39)))
                .Add(New SqlClient.SqlParameter("@DEDUCTORTYPE", alParaval(40)))
                .Add(New SqlClient.SqlParameter("@RESPONSIBLE", alParaval(41)))
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(42)))
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(43)))
                .Add(New SqlClient.SqlParameter("@CMPEWBUSER", alParaval(44)))
                .Add(New SqlClient.SqlParameter("@CMPEWBPASS", alParaval(45)))
                .Add(New SqlClient.SqlParameter("@DISPATCHFROM", alParaval(46)))
                .Add(New SqlClient.SqlParameter("@cmppassword", alParaval(47)))
                .Add(New SqlClient.SqlParameter("@TEMPCMPNAME", alParaval(53)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CMPDELETE() As Integer
        Try
            Dim strCommand As String = "SP_MASTER_CMPMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(0)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function YEARDELETE() As Integer
        Try
            Dim strCommand As String = "SP_MASTER_YEARMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

End Class


