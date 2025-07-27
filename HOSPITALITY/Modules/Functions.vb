
Imports System.Windows.Forms
Imports System.Net.Mail
Imports BL
Imports System.IO
Imports System.Net
Imports System.Collections.Generic
Imports System.Text
Imports System.Web

Module Functions

    Function ErrHandle(ByVal Errcode As Integer) As Boolean
        Dim bln As Boolean = False
        If Errcode = -675406840 Then
            MsgBox("Check Internet Connection")
            bln = True
        End If
        Return bln
    End Function

    Function GETROE(ByVal CURCODE As String) As Decimal
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(ROE_RATE,0) AS ROE", "", " RATEOFEXCHANGEMASTER INNER JOIN CURRENCYMASTER ON CUR_ID = ROE_CURRENCYID ", " AND CUR_CODE = '" & CURCODE & "' AND ROE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then Return (Val(DT.Rows(0).Item("ROE"))) Else Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function SENDMSG(ByVal msg As String, ByVal MOBILENO As String, Optional ByVal GUESTCATEGORY As String = "", Optional ByVal GROUPDEP As String = "") As String
        Try
            Dim WEBREQUEST As HttpWebRequest = Nothing
            Dim WEBRESPONSE As HttpWebResponse = Nothing
            Dim USERNAME As String = ""
            Dim PASSWORD As String = ""
            Dim SENDER As String = ""
            'Dim objSMS As New routesmsdll.SMS
            'If MOBILENO <> "" Then MobileNo = MOBILENO

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If GUESTCATEGORY <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS CATEGORY
                DT = OBJCMN.search("ISNULL(GUEST_MOBILENO,'') AS MOBILENO ", "", " GUESTMASTER INNER JOIN GUESTCATEGORYMASTER ON GUEST_GUESTCATEGORYID = CATEGORY_ID", " AND ISNULL(GUEST_MOBILENO,'') <> '' AND CATEGORY_NAME = '" & GUESTCATEGORY & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If MOBILENO = "" Then
                            MOBILENO = DTROW("MOBILENO")
                        Else
                            MOBILENO = MOBILENO & "," & DTROW("MOBILENO")
                        End If
                    Next
                End If
            End If

            If GROUPDEP <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS GROUPDEP
                DT = OBJCMN.search("ISNULL(GUEST_MOBILENO,'') AS MOBILENO ", "", " GROUPDEPARTURE INNER JOIN HOLIDAYPACKAGEMASTER ON GROUPDEPARTURE.GROUPDEP_NO = HOLIDAYPACKAGEMASTER.BOOKING_GROUPDEPARTID AND GROUPDEPARTURE.GROUPDEP_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID ", " AND ISNULL(GUEST_MOBILENO,'') <> '' AND GROUPDEP_NAME = '" & GROUPDEP & "' AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If MOBILENO = "" Then
                            MOBILENO = DTROW("MOBILENO")
                        Else
                            MOBILENO = MOBILENO & "," & DTROW("MOBILENO")
                        End If
                    Next
                End If
            End If


            If ClientName = "RAMKRISHNA" Then
                USERNAME = "nako-ramkrishna"
                PASSWORD = "shreeram"
                SENDER = "SRKTRV"
            ElseIf ClientName = "KHANNA" Then
                USERNAME = "nako-khanna"
                PASSWORD = "khanna12"
                SENDER = "KHANNA"
            ElseIf ClientName = "APSARA" Then
                USERNAME = "nako-apsara"
                PASSWORD = "apsara12"
                SENDER = "APSARA"
            ElseIf ClientName = "KPNT" Then
                USERNAME = "nako-national"
                PASSWORD = "national"
                SENDER = "NATTRV"
            End If

            'old code
            'Message = msg
            'IPAddress = "103.16.101.52"
            'dlr = 1
            'MessageType = routesmsdll.MESSAGE_TYPE.mTEXT
            'Dim response As String = sendMessage()
            'Return (response.ToString.Substring(0, 4))

            If ClientName = "CLASSIC" Then
                Dim NEWMSG As String = System.Web.HttpUtility.UrlEncode(msg)
                WEBREQUEST = DirectCast(WEBREQUEST.Create("http://sms.technomate.mobi/api/swsendSingle.asp?username=t1classicholidays&password=bhinmal108&sender=CLASIC&sendto=" & MOBILENO & "&message=" & NEWMSG), HttpWebRequest)
                Try
                    WEBRESPONSE = DirectCast(WEBREQUEST.GetResponse(), HttpWebResponse)
                Catch ex As WebException
                    WEBRESPONSE = DirectCast(ex.Response, HttpWebResponse)
                End Try
            Else
                Dim NEWMSG As String = System.Web.HttpUtility.UrlEncode(msg)
                WEBREQUEST = DirectCast(WEBREQUEST.Create("http://nakoda.alert.ind.in/sms_api/sendsms.php?username=" & USERNAME & "&password=" & PASSWORD & "&mobile=" & MOBILENO & "&sendername=" & SENDER & "&message=" & NEWMSG), HttpWebRequest)
                Try
                    WEBRESPONSE = DirectCast(WEBREQUEST.GetResponse(), HttpWebResponse)
                Catch ex As WebException
                    WEBRESPONSE = DirectCast(ex.Response, HttpWebResponse)
                End Try
            End If
            Return "1701"

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub pcase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.ProperCase)
    End Sub

    Public Sub uppercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Uppercase)
    End Sub

    Public Sub lowercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Lowercase)
    End Sub

    Function getfirstdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function getlastdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub datefunction()

        'SQL Queries
        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)),@mydate),101) ,
        '        'Last Day of Previous Month'
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101) AS Date_Value,
        '            'First Day of Current Month' AS Date_Type
        'UNION
        'SELECT CONVERT(VARCHAR(25),@mydate,101) AS Date_Value, 'Today' AS Date_Type
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))),DATEADD(mm,1,@mydate)),101) ,
        '                    'Last Day of Current Month'
        'UNION
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))-1),DATEADD(mm,1,@mydate)),101) ,
        '                        'First Day of Next Month'


    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As System.Windows.Forms.TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        'If AscW(han.KeyChar) = 13 Then
        '    SendKeys.Send("{Tab}")
        '    han.KeyChar = ""
        'End If
        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Function getmax(ByVal fldname As String, ByVal tbname As String, Optional ByVal whereclause As String = "") As DataTable
        Try
            Dim DTTABLE As DataTable

            Dim objclscommon As New ClsCommon()
            DTTABLE = objclscommon.GETMAXNO(fldname, tbname, whereclause)

            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function datecheck(ByVal dateval As Date) As Boolean
        Dim bln As Boolean = True
        If dateval.Date > AccTo Or dateval.Date < AccFrom Then
            bln = False
        End If
        Return bln
    End Function

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub

    Sub fillregister(ByRef cmbregister As ComboBox, ByVal condition As String)
        Try
            If cmbregister.Text.Trim = "" Then

                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search(" Register_name ", "", "RegisterMaster ", condition & " and Register_cmpid=" & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Register_name"
                    cmbregister.DataSource = dt
                    cmbregister.DisplayMember = "Register_name"
                    cmbregister.Text = ""
                End If
                cmbregister.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAIRCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" FLIGHT_CODE ", "", " FLIGHTMASTER ", " and FLIGHT_cmpid=" & CmpId & " AND FLIGHT_LOCATIONID = " & Locationid & " AND FLIGHT_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "FLIGHT_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "FLIGHT_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AIRCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBAIRLINE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "", Optional ByRef COMM As String = "", Optional ByRef ISDOMESTIC As Boolean = True)
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FLIGHT_NAME ", "", " FLIGHTMASTER ", " and FLIGHT_CODE = '" & CMBCODE.Text.Trim & "' and FLIGHT_cmpid = " & CmpId & " and FLIGHT_LOCATIONid = " & Locationid & " and FLIGHT_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJAIRLINE As New FlightMaster
                        OBJAIRLINE.TEMPFLIGHTCODE = CMBCODE.Text.Trim()
                        OBJAIRLINE.ShowDialog()
                        dt = objclscommon.search("FLIGHT_CODE", "", "FLIGHTMASTER", " and FLIGHT_cODE = '" & CMBCODE.Text.Trim & "' and FLIGHT_cmpid = " & CmpId & " and FLIGHT_LOCATIONid = " & Locationid & " and FLIGHT_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBAIRLINE.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLVEHICLE(ByRef CMBVEHICLE As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If CMBVEHICLE.Text.Trim = "" Then
                dt = objclscommon.search(" VEHICLEMASTER.VEHICLE_NAME ", "", " VEHICLEMASTER LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLEMASTER.VEHICLE_TYPEID = VEHICLETYPEMASTER.VEHICLETYPE_ID AND VEHICLEMASTER.VEHICLE_CMPID = VEHICLETYPEMASTER.VEHICLETYPE_CMPID AND VEHICLEMASTER.VEHICLE_LOCATIONID = VEHICLETYPEMASTER.VEHICLETYPE_LOCATIONID AND VEHICLEMASTER.VEHICLE_YEARID = VEHICLETYPEMASTER.VEHICLETYPE_YEARID ", " and VEHICLEMASTER.VEHICLE_cmpid=" & CmpId & " and VEHICLEMASTER.VEHICLE_Locationid=" & Locationid & " and VEHICLEMASTER.VEHICLE_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.Rows.Add("")
                    dt.DefaultView.Sort = "VEHICLE_NAME"
                    CMBVEHICLE.DataSource = dt
                    CMBVEHICLE.DisplayMember = "VEHICLE_NAME"
                    If edit = False Then CMBVEHICLE.Text = ""
                End If
                CMBVEHICLE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub VEHICLEVALIDATE(ByRef CMBVEHICLE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBVEHICLE.Text.Trim <> "" Then
                uppercase(CMBVEHICLE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("isnull(VEHICLE_NAME,'') AS VEHICLE ", "", " VEHICLEMASTER ", " and VEHICLE_NAME = '" & CMBVEHICLE.Text.Trim & "' and VEHICLE_cmpid = " & CmpId & " and VEHICLE_LOCATIONid = " & Locationid & " and VEHICLE_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("VEHICLE not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJVEHICLE As New VehicleMaster
                        OBJVEHICLE.TEMPVEHICLENAME = CMBVEHICLE.Text.Trim()
                        OBJVEHICLE.ShowDialog()
                        dt = objclscommon.search("VEHICLE_NAME", "", " VEHICLEMASTER ", " and VEHICLE_NAME = '" & CMBVEHICLE.Text.Trim & "' and VEHICLE_cmpid = " & CmpId & " and VEHICLE_LOCATIONid = " & Locationid & " and VEHICLE_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBVEHICLE.Text.Trim
                            dt1 = CMBVEHICLE.DataSource
                            If CMBVEHICLE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBVEHICLE.Text.Trim)
                                    CMBVEHICLE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLAIRLINE(ByRef CMBAIRLINE As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAIRLINE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" FLIGHTMASTER.FLIGHT_NAME ", "", " FLIGHTMASTER ", " and FLIGHTMASTER.FLIGHT_cmpid=" & CmpId & " and FLIGHTMASTER.FLIGHT_Locationid=" & Locationid & " and FLIGHTMASTER.FLIGHT_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FLIGHT_NAME"
                    CMBAIRLINE.DataSource = dt
                    CMBAIRLINE.DisplayMember = "FLIGHT_NAME"
                    If edit = False Then CMBAIRLINE.Text = ""
                End If
                CMBAIRLINE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub AIRLINEVALIDATE(ByRef CMBAIRLINE As ComboBox, ByVal CMBCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "", Optional ByRef ISDOMESTIC As Boolean = True, Optional ByRef ISLCC As Boolean = True, Optional ByRef COMMBASIC As Double = 0, Optional ByRef COMMPSF As Double = 0, Optional ByRef COMMTAX As Double = 0)
        Try
            If CMBAIRLINE.Text.Trim <> "" Then
                pcase(CMBAIRLINE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("isnull(FLIGHT_CODE,''), isnull(FLIGHT_COMM,0), isnull(FLIGHT_DOMESTIC, 'FALSE'), isnull(FLIGHT_LCC,'FALSE'),isnull(FLIGHT_COMMPSF,0), isnull(FLIGHT_COMMTAX,0)  ", "", " FLIGHTMASTER ", " and FLIGHT_NAME = '" & CMBAIRLINE.Text.Trim & "' and FLIGHT_cmpid = " & CmpId & " and FLIGHT_LOCATIONid = " & Locationid & " and FLIGHT_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Flight not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJFLIGHT As New FlightMaster
                        OBJFLIGHT.TEMPFLIGHTNAME = CMBAIRLINE.Text.Trim()
                        OBJFLIGHT.ShowDialog()
                        dt = objclscommon.search("FLIGHT_NAME", "", " FLIGHTMASTER ", " and FLIGHT_NAME = '" & CMBAIRLINE.Text.Trim & "' and FLIGHT_cmpid = " & CmpId & " and FLIGHT_LOCATIONid = " & Locationid & " and FLIGHT_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBAIRLINE.Text.Trim
                            dt1 = CMBAIRLINE.DataSource
                            If CMBAIRLINE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBAIRLINE.Text.Trim)
                                    CMBAIRLINE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBCODE.Text = dt.Rows(0).Item(0)
                    'COMM = dt.Rows(0).Item(1) + dt.Rows(0).Item(4) + dt.Rows(0).Item(5)
                    COMMBASIC = dt.Rows(0).Item(1)
                    COMMPSF = dt.Rows(0).Item(4)
                    COMMTAX = dt.Rows(0).Item(5)
                    ISDOMESTIC = dt.Rows(0).Item(2)
                    ISLCC = dt.Rows(0).Item(3)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillACCCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ACC_CODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID ", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' AND ACC_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ACC_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "ACC_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID ", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' AND ACC_YEARID = " & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLEMP(ByRef CMBEMP As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" EMP_NAME ", "", " EMPLOYEEMASTER", " AND EMP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_NAME"
                    CMBEMP.DataSource = dt
                    CMBEMP.DisplayMember = "EMP_NAME"
                    If edit = False Then CMBEMP.Text = ""
                End If
                CMBEMP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub EMPVALIDATE(ByRef CMBEMP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim <> "" Then
                uppercase(CMBEMP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMP_NAME", "", "EMPLOYEEMASTER", " and EMP_NAME = '" & CMBEMP.Text.Trim & "' AND EMP_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBEMP.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        CMBEMP.Text = a
                        Dim OBJEMP As New EmployeeMaster
                        OBJEMP.TEMPEMPNAME = CMBEMP.Text.Trim()
                        OBJEMP.ShowDialog()
                        dt = objclscommon.search("EMP_NAME", "", "EMPLOYEEMASTER", " and EMP_name = '" & CMBEMP.Text.Trim & "' AND EMP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBEMP.DataSource
                            If CMBEMP.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBEMP.Text.Trim)
                                    CMBEMP.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillAGENT(ByRef CMBAGENT As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAGENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID  AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    CMBAGENT.DataSource = dt
                    CMBAGENT.DisplayMember = "ACC_cmpname"
                    If edit = False Then CMBAGENT.Text = ""
                End If
                CMBAGENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub AGENTVALIDATE(ByRef CMBAGENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAGENT.Text.Trim <> "" Then
                pcase(CMBAGENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,'')", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & CMBAGENT.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBAGENT.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBAGENT.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = CMBAGENT.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & CMBAGENT.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBAGENT.DataSource
                            If CMBAGENT.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBAGENT.Text.Trim)
                                    CMBAGENT.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLBANK(ByRef CMBBANK As ComboBox)
        Try
            If CMBBANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", " PARTYBANKMaster ", " and PARTYBANK_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PARTYBANK_name"
                    CMBBANK.DataSource = dt
                    CMBBANK.DisplayMember = "PARTYBANK_name"
                    CMBBANK.Text = ""
                End If
                CMBBANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PARTYBANKvalidate(ByRef CMBPARTYBANK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPARTYBANK.Text.Trim <> "" Then
                uppercase(CMBPARTYBANK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & CMBPARTYBANK.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PARTYBANK Name not present, Add New?", MsgBoxStyle.YesNo, "BROKERMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTYBANK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPARTYBANKMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        CMBPARTYBANK.Focus()
                        CMBPARTYBANK.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub FILLEMAIL(ByRef CMBEMAIL As ComboBox)
        Try
            If CMBEMAIL.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" EMAIL_name ", "", " EMAILMaster", " and EMAIL_cmpid=" & CmpId & " AND EMAIL_LOCATIONID = " & Locationid & " AND EMAIL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMAIL_name"
                    CMBEMAIL.DataSource = dt
                    CMBEMAIL.DisplayMember = "EMAIL_name"
                    CMBEMAIL.Text = ""
                End If
                CMBEMAIL.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EMAILVALIDATE(ByRef CMBEMAIL As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMAIL.Text.Trim <> "" Then
                lowercase(CMBEMAIL)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMAIL_id", "", "EMAILMaster", " and EMAIL_id = '" & CMBEMAIL.Text.Trim & "' and EMAIL_cmpid = " & CmpId & " and EMAIL_LOCATIONid = " & Locationid & " and EMAIL_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("EMAIL ID not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBEMAIL.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsEMAIL As New ClsEmailMaster
                        objclsEMAIL.alParaval = alParaval
                        Dim IntResult As Integer = objclsEMAIL.save()
                    Else
                        CMBEMAIL.Focus()
                        CMBEMAIL.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPREFIX(ByRef CMBPREFIX As ComboBox)
        Try
            If CMBPREFIX.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PREFIX_name ", "", " PREFIXMaster", " and PREFIX_cmpid=" & CmpId & " AND PREFIX_LOCATIONID = " & Locationid & " AND PREFIX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PREFIX_name"
                    CMBPREFIX.DataSource = dt
                    CMBPREFIX.DisplayMember = "PREFIX_name"
                    CMBPREFIX.Text = ""
                End If
                CMBPREFIX.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PREFIXvalidate(ByRef CMBPREFIX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPREFIX.Text.Trim <> "" Then
                pcase(CMBPREFIX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PREFIX_id", "", "PREFIXMaster", " and PREFIX_NAME = '" & CMBPREFIX.Text.Trim & "' and PREFIX_cmpid = " & CmpId & " and PREFIX_LOCATIONid = " & Locationid & " and PREFIX_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PREFIX NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPREFIX.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsPREFIX As New ClsPrefixMaster
                        objclsPREFIX.alParaval = alParaval
                        Dim IntResult As Integer = objclsPREFIX.SAVE()
                    Else
                        CMBPREFIX.Focus()
                        CMBPREFIX.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCRS(ByRef CMBCRS As ComboBox)
        Try
            If CMBCRS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CRS_name ", "", " CRSMaster", " and CRS_cmpid=" & CmpId & " AND CRS_LOCATIONID = " & Locationid & " AND CRS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CRS_name"
                    CMBCRS.DataSource = dt
                    CMBCRS.DisplayMember = "CRS_name"
                    CMBCRS.Text = ""
                End If
                CMBCRS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CRSvalidate(ByRef CMBCRS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCRS.Text.Trim <> "" Then
                uppercase(CMBCRS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CRS_id", "", "CRSMaster", " and CRS_NAME = '" & CMBCRS.Text.Trim & "' and CRS_cmpid = " & CmpId & " and CRS_LOCATIONid = " & Locationid & " and CRS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CRS TYPE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCRS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCRS As New ClsCRSMaster
                        objclsCRS.alParaval = alParaval
                        Dim IntResult As Integer = objclsCRS.SAVE()
                    Else
                        CMBCRS.Focus()
                        CMBCRS.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSECTOR(ByRef CMBSECTOR As ComboBox)
        Try
            If CMBSECTOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SECTOR_name ", "", " SECTORMaster", " and SECTOR_cmpid=" & CmpId & " AND SECTOR_LOCATIONID = " & Locationid & " AND SECTOR_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SECTOR_name"
                    CMBSECTOR.DataSource = dt
                    CMBSECTOR.DisplayMember = "SECTOR_name"
                    CMBSECTOR.Text = ""
                End If
                CMBSECTOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SECTORvalidate(ByRef CMBSECTOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSECTOR.Text.Trim <> "" Then
                uppercase(CMBSECTOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SECTOR_id", "", "SECTORMaster", " and SECTOR_NAME = '" & CMBSECTOR.Text.Trim & "' and SECTOR_cmpid = " & CmpId & " and SECTOR_LOCATIONid = " & Locationid & " and SECTOR_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SECTOR NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSECTOR.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSECTOR As New ClsSectorMaster
                        objclsSECTOR.alParaval = alParaval
                        Dim IntResult As Integer = objclsSECTOR.SAVE()
                    Else
                        CMBSECTOR.Focus()
                        CMBSECTOR.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLNATIONALITY(ByRef CMBNATIONALITY As ComboBox)
        Try
            If CMBNATIONALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" NAT_NAME AS NATIONALITY ", "", " NATIONALITYMASTER ", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NATIONALITY"
                    CMBNATIONALITY.DataSource = dt
                    CMBNATIONALITY.DisplayMember = "NATIONALITY"
                    CMBNATIONALITY.Text = ""
                End If
                CMBNATIONALITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATIONALITYVALIDATE(ByRef CMBNATIONALITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATIONALITY.Text.Trim <> "" Then
                uppercase(CMBNATIONALITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" NAT_NAME AS NAME", "", " NATIONALITYMASTER", " and NAT_NAME = '" & CMBNATIONALITY.Text.Trim & "' AND NAT_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBNATIONALITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Nationality not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBNATIONALITY.Text = a
                        Dim OBJNAT As New NationalityMaster
                        OBJNAT.tempname = CMBNATIONALITY.Text.Trim()
                        OBJNAT.ShowDialog()
                        dt = objclscommon.search(" NAT_NAME AS NAME", "", " NATIONALITYMASTER", " and NAT_NAME = '" & CMBNATIONALITY.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBNATIONALITY.DataSource
                            If CMBNATIONALITY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBNATIONALITY.Text.Trim)
                                    CMBNATIONALITY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    CMBNATIONALITY.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSTATION(ByRef CMBFROM As ComboBox)
        Try
            If CMBFROM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATION_NAME AS STATIONNAME ", "", " STATIONMASTER ", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATIONNAME"
                    CMBFROM.DataSource = dt
                    CMBFROM.DisplayMember = "STATIONNAME"
                    CMBFROM.Text = ""
                End If
                CMBFROM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATIONVALIDATE(ByRef CMBSTATION As ComboBox, ByRef CMBSTATIONCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATION.Text.Trim <> "" Then
                uppercase(CMBSTATION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATION_CODE AS CODE", "", " STATIONMASTER ", " and STATION_NAME = '" & CMBSTATION.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATION.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STATION NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBSTATION.Text = a
                        Dim OBJTRAIN As New StationMaster
                        OBJTRAIN.TEMPSTATIONNAME = CMBSTATION.Text.Trim()
                        OBJTRAIN.ShowDialog()
                        dt = objclscommon.search("STATION_CODE AS CODE", "", " STATIONMASTER ", " and STATION_NAME = '" & CMBSTATION.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBSTATIONCODE.DataSource
                            If CMBSTATIONCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSTATION.Text.Trim)
                                    CMBSTATION.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    CMBSTATIONCODE.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSTATIONCODE(ByRef CMBCODE As ComboBox)
        Try
            If CMBCODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATION_CODE AS STATIONCODE ", "", " STATIONMASTER ", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATIONCODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "STATIONCODE"
                    CMBCODE.Text = ""
                End If
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATIONCODEVALIDATE(ByRef CMBSTATIONCODE As ComboBox, ByRef CMBSTATION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATIONCODE.Text.Trim <> "" Then
                uppercase(CMBSTATIONCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATION_NAME AS STATIONNAME", "", " STATIONMASTER ", " and STATION_CODE = '" & CMBSTATIONCODE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATIONCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STATION CODE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBSTATIONCODE.Text = a
                        Dim OBJSTATION As New StationMaster
                        OBJSTATION.TEMPCODE = CMBSTATIONCODE.Text.Trim()
                        OBJSTATION.ShowDialog()
                        dt = objclscommon.search("STATION_NAME AS STATIONNAME", "", " STATIONMASTER ", " and STATION_CODE = '" & CMBSTATIONCODE.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBSTATIONCODE.DataSource
                            If CMBSTATIONCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSTATIONCODE.Text.Trim)
                                    CMBSTATIONCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    CMBSTATION.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLTRAINNAME(ByRef CMBTRAINNAME As ComboBox)
        Try
            If CMBTRAINNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TRAIN_NAME AS TRAINNAME ", "", " TRAINMASTER ", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TRAINNAME"
                    CMBTRAINNAME.DataSource = dt
                    CMBTRAINNAME.DisplayMember = "TRAINNAME"
                    CMBTRAINNAME.Text = ""
                End If
                CMBTRAINNAME.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRAINNAMEVALIDATE(ByRef CMBTRAINNAME As ComboBox, ByRef CMBTRAINNO As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTRAINNAME.Text.Trim <> "" Then
                uppercase(CMBTRAINNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TRAIN_NO AS TRAINNO", "", " TRAINMASTER ", " and TRAIN_NAME = '" & CMBTRAINNAME.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTRAINNAME.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TRAIN NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBTRAINNAME.Text = a
                        Dim OBJTRAIN As New TrainMaster
                        OBJTRAIN.TEMPTRAINNAME = CMBTRAINNAME.Text.Trim()
                        OBJTRAIN.ShowDialog()
                        dt = objclscommon.search("TRAIN_NO AS TRAINNO", "", " TRAINMASTER ", " and TRAIN_NAME = '" & CMBTRAINNAME.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBTRAINNAME.DataSource
                            If CMBTRAINNAME.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTRAINNAME.Text.Trim)
                                    CMBTRAINNAME.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    CMBTRAINNO.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLTRAINNO(ByRef CMBTRAINNO As ComboBox)
        Try
            If CMBTRAINNO.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TRAIN_NO AS TRAINNO ", "", " TRAINMASTER ", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TRAINNO"
                    CMBTRAINNO.DataSource = dt
                    CMBTRAINNO.DisplayMember = "TRAINNO"
                    CMBTRAINNO.Text = ""
                End If
                CMBTRAINNO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRAINNOVALIDATE(ByRef CMBTRAINNO As ComboBox, ByRef CMBTRAINNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTRAINNO.Text.Trim <> "" Then
                uppercase(CMBTRAINNO)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TRAIN_NAME AS TRAINNAME", "", " TRAINMASTER ", " and TRAIN_NO = '" & CMBTRAINNO.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTRAINNO.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TRAIN NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBTRAINNO.Text = a
                        Dim OBJTRAIN As New TrainMaster
                        OBJTRAIN.TEMPTRAINNO = CMBTRAINNO.Text.Trim()
                        OBJTRAIN.ShowDialog()
                        dt = objclscommon.search("TRAIN_NAME AS TRAINNAME", "", " TRAINMASTER ", " and TRAIN_NO = '" & CMBTRAINNO.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBTRAINNO.DataSource
                            If CMBTRAINNO.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTRAINNO.Text.Trim)
                                    CMBTRAINNO.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    CMBTRAINNAME.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcity(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" city_name ", "", " CityMaster", " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "city_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "city_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CITYVALIDATE(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                pcase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBCITY.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBCITY.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecity(CMBCITY.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBCITY.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub filllogin(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" login_name ", "", " loginMaster", " and login_cmpid=" & CmpId & " AND login_LOCATIONID = " & Locationid & " AND login_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "login_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "login_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillIdType(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" Id_name ", "", " IDMaster", " and ID_cmpid=" & CmpId & " AND ID_LOCATIONID = " & Locationid & " AND ID_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Id_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "Id_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub LOGINVALIDATE(ByRef CMBLOGIN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBLOGIN.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("LOGIN_name", "", "LOGINMaster", " and LOGIN_name = '" & CMBLOGIN.Text.Trim & "' AND LOGIN_CMPID = " & CmpId & " AND LOGIN_LOCATIONID = " & Locationid & " AND LOGIN_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBLOGIN.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Login Id not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBLOGIN.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savelogin(CMBLOGIN.Text.Trim, CmpId, Locationid, Userid, YearId, " and login_name = '" & CMBLOGIN.Text.Trim & "' AND login_CMPID = " & CmpId & " AND login_LOCATIONID = " & Locationid & " AND login_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub IDTYPEVALIDATE(ByRef CMBIDTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBIDTYPE.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("ID_name", "", "IDMaster", " and ID_name = '" & CMBIDTYPE.Text.Trim & "' AND ID_CMPID = " & CmpId & " AND ID_LOCATIONID = " & Locationid & " AND ID_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBIDTYPE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Id Type not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBIDTYPE.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.saveID(CMBIDTYPE.Text.Trim, CmpId, Locationid, Userid, YearId, " and id_name = '" & CMBIDTYPE.Text.Trim & "' AND id_CMPID = " & CmpId & " AND id_LOCATIONID = " & Locationid & " AND id_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub filltax(ByRef cmbname As ComboBox, ByRef edit As Boolean)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" tax_name ", "", " TaxMaster", " and Tax_cmpid=" & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "tax_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "tax_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TAXvalidate(ByRef CMBTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAX.Text.Trim <> "" Then
                pcase(CMBTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTAX.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TAX not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBTAX.Text = a
                        Dim OBJTAX As New Taxmaster
                        OBJTAX.TXTNAME.Text = CMBTAX.Text.Trim()
                        OBJTAX.ShowDialog()
                        dt = objclscommon.search("TAX_name", "", "TAXMaster", " and TAX_name = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBTAX.DataSource
                            If CMBTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTAX.Text.Trim)
                                    CMBTAX.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CURRENCYvalidate(ByRef CMBCURRENCY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCURRENCY.Text.Trim <> "" Then
                uppercase(CMBCURRENCY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CUR_CODE", "", " CURRENCYMASTER", " and CUR_CODE = '" & CMBCURRENCY.Text.Trim & "' and CUR_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCURRENCY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Currency not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBCURRENCY.Text = a
                        Dim OBJCURR As New CurrencyMaster
                        OBJCURR.TXTCODE.Text = CMBCURRENCY.Text.Trim()
                        OBJCURR.ShowDialog()
                        dt = objclscommon.search("CUR_CODE", "", " CURRENCYMASTER", " and CUR_CODE = '" & CMBCURRENCY.Text.Trim & "' and CUR_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBCURRENCY.DataSource
                            If CMBCURRENCY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCURRENCY.Text)
                                    CMBCURRENCY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLITINERARY(ByRef CMBITEINIRARY As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ITINERARY_NAME ", "", " ITINERARYMASTER", " AND ITINERARY_Yearid = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ITINERARY_NAME"
                CMBITEINIRARY.DataSource = dt
                CMBITEINIRARY.DisplayMember = "ITINERARY_NAME"
                CMBITEINIRARY.Text = ""
            End If
            CMBITEINIRARY.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ITEINIRARYVALIDATE(ByRef CMBITEINIRARY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBITEINIRARY.Text.Trim <> "" Then
                pcase(CMBITEINIRARY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" ITINERARY_NAME ", "", " ITINERARYMASTER ", " and ITINERARY_NAME = '" & CMBITEINIRARY.Text.Trim & "' AND ITINERARY_Yearid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBITEINIRARY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Itinerary not present, Add New?", MsgBoxStyle.YesNo, " TRAVELMATE ")
                    If tempmsg = vbYes Then
                        CMBITEINIRARY.Text = a
                        Dim OBJITI As New ItineraryMaster
                        OBJITI.TEMPPACKAGENAME = CMBITEINIRARY.Text.Trim()
                        OBJITI.ShowDialog()
                        dt = objclscommon.search(" ITINERARY_NAME ", "", " ITINERARYMASTER ", " and ITINERARY_NAME = '" & CMBITEINIRARY.Text.Trim & "' AND ITINERARY_Yearid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBITEINIRARY.DataSource
                            If CMBITEINIRARY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBITEINIRARY.Text)
                                    CMBITEINIRARY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CityCodeValidate(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                pcase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CAST(CITY_REMARK AS VARCHAR(100)) AS CITY_REMARK", "", " CITYMASTER", " and CAST(CITY_REMARK AS VARCHAR(100)) = '" & CMBCITY.Text.Trim & "' and CITY_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBCITY.Text = a
                        Dim OBJCURR As New citymaster
                        OBJCURR.frmstring = "CITYMASTER"
                        OBJCURR.txtremarks.Text = CMBCITY.Text.Trim()
                        OBJCURR.ShowDialog()
                        dt = objclscommon.search("CAST(CITY_REMARK AS VARCHAR(100)) AS CITY_REMARK", "", " CITYMASTER", " and CAST(CITY_REMARK AS VARCHAR(100)) = '" & CMBCITY.Text.Trim & "' and CITY_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBCITY.DataSource
                            If CMBCITY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCITY.Text)
                                    CMBCITY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CountryValidate(ByRef CMBCOUNTRY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRY.Text.Trim <> "" Then
                pcase(CMBCOUNTRY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COUNTRY_NAME", "", " COUNTRYMASTER", " and COUNTRY_NAME = '" & CMBCOUNTRY.Text.Trim & "' and COUNTRY_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCOUNTRY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("COUNTRY not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBCOUNTRY.Text = a
                        Dim OBJCURR As New citymaster
                        OBJCURR.frmstring = "COUNTRYMASTER"
                        OBJCURR.txtname.Text = CMBCOUNTRY.Text.Trim()
                        OBJCURR.ShowDialog()
                        dt = objclscommon.search("COUNTRY_NAME", "", " COUNTRYMASTER", " and COUNTRY_NAME = '" & CMBCOUNTRY.Text.Trim & "' and COUNTRY_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBCOUNTRY.DataSource
                            If CMBCOUNTRY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCOUNTRY.Text)
                                    CMBCOUNTRY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub FILLEXCLUSION(ByRef CMBEXCLUSION As ComboBox, ByRef edit As Boolean)
        Try
            If CMBEXCLUSION.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" EXCLUSION_name ", "", " EXCLUSIONMaster", " and EXCLUSION_cmpid=" & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EXCLUSION_name"
                    CMBEXCLUSION.DataSource = dt
                    CMBEXCLUSION.DisplayMember = "EXCLUSION_name"
                    If edit = False Then CMBEXCLUSION.Text = ""
                End If
                CMBEXCLUSION.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub FILLINCLUSION(ByRef CMBINCLUSION As ComboBox, ByRef edit As Boolean)
        Try
            If CMBINCLUSION.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" INCLUSION_name ", "", " INCLUSIONMaster", " and INCLUSION_cmpid=" & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "INCLUSION_name"
                    CMBINCLUSION.DataSource = dt
                    CMBINCLUSION.DisplayMember = "INCLUSION_name"
                    If edit = False Then CMBINCLUSION.Text = ""
                End If
                CMBINCLUSION.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLNOTE(ByRef CMBNOTE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBNOTE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" NOTE_name ", "", " NOTEMaster", " and NOTE_cmpid=" & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NOTE_name"
                    CMBNOTE.DataSource = dt
                    CMBNOTE.DisplayMember = "NOTE_name"
                    If edit = False Then CMBNOTE.Text = ""
                End If
                CMBNOTE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NOTEVALIDATE(ByRef CMBNOTE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNOTE.Text.Trim <> "" Then
                pcase(CMBNOTE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("NOTE_ID", "", " NOTEMASTER ", " and NOTE_name = '" & CMBNOTE.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBNOTE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("NOTE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBNOTE.Text = a
                        Dim OBJNOTE As New CancelPolicyMaster
                        OBJNOTE.FRMSTRING = "NOTES"
                        OBJNOTE.TempName = CMBNOTE.Text.Trim()
                        OBJNOTE.ShowDialog()
                        dt = objclscommon.search("NOTE_ID", "", " NOTEMASTER ", " and NOTE_name = '" & CMBNOTE.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBNOTE.DataSource
                            If CMBNOTE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBNOTE.Text.Trim)
                                    CMBNOTE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub EXCLUSIONVALIDATE(ByRef CMBEXCLUSION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEXCLUSION.Text.Trim <> "" Then
                pcase(CMBEXCLUSION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EXCLUSION_ID", "", " EXCLUSIONMASTER ", " and EXCLUSION_name = '" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBEXCLUSION.Text.Trim
                    Dim tempmsg As Integer = MsgBox("EXCLUSION not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBEXCLUSION.Text = a
                        Dim OBJEXCLUSION As New CancelPolicyMaster
                        OBJEXCLUSION.FRMSTRING = "EXCLUSIONS"
                        OBJEXCLUSION.TempName = CMBEXCLUSION.Text.Trim()
                        OBJEXCLUSION.ShowDialog()
                        dt = objclscommon.search("EXCLUSION_ID", "", " EXCLUSIONMASTER ", " and EXCLUSION_name = '" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBEXCLUSION.DataSource
                            If CMBEXCLUSION.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBEXCLUSION.Text.Trim)
                                    CMBEXCLUSION.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub INCLUSIONVALIDATE(ByRef CMBINCLUSION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBINCLUSION.Text.Trim <> "" Then
                pcase(CMBINCLUSION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("INCLUSION_ID", "", " INCLUSIONMASTER ", " and INCLUSION_name = '" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBINCLUSION.Text.Trim
                    Dim tempmsg As Integer = MsgBox("INCLUSION not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBINCLUSION.Text = a
                        Dim OBJINCLUSION As New CancelPolicyMaster
                        OBJINCLUSION.FRMSTRING = "INCLUSIONS"
                        OBJINCLUSION.TempName = CMBINCLUSION.Text.Trim()
                        OBJINCLUSION.ShowDialog()
                        dt = objclscommon.search("INCLUSION_ID", "", " INCLUSIONMASTER ", " and INCLUSION_name = '" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBINCLUSION.DataSource
                            If CMBINCLUSION.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBINCLUSION.Text.Trim)
                                    CMBINCLUSION.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPOLICY(ByRef CMBPOLICY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBPOLICY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" POLICY_name ", "", " POLICYMaster", " and POLICY_cmpid=" & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "POLICY_name"
                    CMBPOLICY.DataSource = dt
                    CMBPOLICY.DisplayMember = "POLICY_name"
                    If edit = False Then CMBPOLICY.Text = ""
                End If
                CMBPOLICY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub POLICYvalidate(ByRef CMBPOLICY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPOLICY.Text.Trim <> "" Then
                pcase(CMBPOLICY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("POLICY_ID", "", " POLICYMASTER ", " and POLICY_name = '" & CMBPOLICY.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBPOLICY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Policy not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBPOLICY.Text = a
                        Dim OBJPOLICY As New CancelPolicyMaster
                        OBJPOLICY.FRMSTRING = "POLICY"
                        OBJPOLICY.TempName = CMBPOLICY.Text.Trim()
                        OBJPOLICY.ShowDialog()
                        dt = objclscommon.search("POLICY_ID", "", " POLICYMASTER ", " and POLICY_name = '" & CMBPOLICY.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBPOLICY.DataSource
                            If CMBPOLICY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBPOLICY.Text.Trim)
                                    CMBPOLICY.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCLASS(ByRef CMBCLASS As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCLASS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CLASS_name ", "", " CLASSMaster", " and CLASS_cmpid=" & CmpId & " AND CLASS_LOCATIONID = " & Locationid & " AND CLASS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CLASS_name"
                    CMBCLASS.DataSource = dt
                    CMBCLASS.DisplayMember = "CLASS_name"
                    If edit = False Then CMBCLASS.Text = ""
                End If
                CMBCLASS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLASSvalidate(ByRef CMBCLASS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCLASS.Text.Trim <> "" Then
                pcase(CMBCLASS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CLASS_id", "", "CLASSMaster", " and CLASS_NAME = '" & CMBCLASS.Text.Trim & "' and CLASS_cmpid = " & CmpId & " and CLASS_LOCATIONid = " & Locationid & " and CLASS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CLASS ID not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCLASS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCLASS As New ClsClassMaster
                        objclsCLASS.alParaval = alParaval
                        Dim IntResult As Integer = objclsCLASS.SAVE()
                    Else
                        CMBCLASS.Focus()
                        CMBCLASS.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLVEHICLETYPE(ByRef CMBVEHICLETYPE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBVEHICLETYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" VEHICLETYPE_name ", "", " VEHICLETYPEMaster", " and VEHICLETYPE_cmpid=" & CmpId & " AND VEHICLETYPE_LOCATIONID = " & Locationid & " AND VEHICLETYPE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "VEHICLETYPE_name"
                    CMBVEHICLETYPE.DataSource = dt
                    CMBVEHICLETYPE.DisplayMember = "VEHICLETYPE_name"
                    If edit = False Then CMBVEHICLETYPE.Text = ""
                End If
                CMBVEHICLETYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub VEHICLETYPEvalidate(ByRef CMBVEHICLETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBVEHICLETYPE.Text.Trim <> "" Then
                uppercase(CMBVEHICLETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("VEHICLETYPE_id", "", "VEHICLETYPEMaster", " and VEHICLETYPE_NAME = '" & CMBVEHICLETYPE.Text.Trim & "' and VEHICLETYPE_cmpid = " & CmpId & " and VEHICLETYPE_LOCATIONid = " & Locationid & " and VEHICLETYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("VEHICLETYPE ID not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBVEHICLETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsVEHICLETYPE As New ClsVehicleTypeMaster
                        objclsVEHICLETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsVEHICLETYPE.SAVE()
                    Else
                        CMBVEHICLETYPE.Focus()
                        CMBVEHICLETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSOURCE(ByRef CMBSOURCE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSOURCE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SOURCE_name ", "", " SOURCEMaster", " and SOURCE_cmpid=" & CmpId & " AND SOURCE_LOCATIONID = " & Locationid & " AND SOURCE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SOURCE_name"
                    CMBSOURCE.DataSource = dt
                    CMBSOURCE.DisplayMember = "SOURCE_name"
                    CMBSOURCE.Text = ""
                End If
                CMBSOURCE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SOURCEvalidate(ByRef CMBSOURCE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSOURCE.Text.Trim <> "" Then
                pcase(CMBSOURCE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SOURCE_id", "", "SOURCEMaster", " and SOURCE_NAME = '" & CMBSOURCE.Text.Trim & "' and SOURCE_cmpid = " & CmpId & " and SOURCE_LOCATIONid = " & Locationid & " and SOURCE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SOURCE ID not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSOURCE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSOURCE As New ClsSourceMaster
                        objclsSOURCE.alParaval = alParaval
                        Dim IntResult As Integer = objclsSOURCE.SAVE()
                    Else
                        CMBSOURCE.Focus()
                        CMBSOURCE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPLAN(ByRef CMBPLAN As ComboBox, ByRef edit As Boolean)
        Try
            If CMBPLAN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PLAN_name ", "", " PLANMaster", " and PLAN_cmpid=" & CmpId & " AND PLAN_LOCATIONID = " & Locationid & " AND PLAN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PLAN_name"
                    CMBPLAN.DataSource = dt
                    CMBPLAN.DisplayMember = "PLAN_name"
                    If edit = False Then CMBPLAN.Text = ""
                End If
                CMBPLAN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PLANvalidate(ByRef CMBPLAN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByRef INCLUSIONS As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPLAN.Text.Trim <> "" Then
                uppercase(CMBPLAN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PLAN_id, ISNULL(PLAN_REMARKS,'')", "", "PLANMaster", " and PLAN_NAME = '" & CMBPLAN.Text.Trim & "' and PLAN_cmpid = " & CmpId & " and PLAN_LOCATIONid = " & Locationid & " and PLAN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PLAN NAME not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPLAN.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsPLAN As New ClsPlanMaster
                        objclsPLAN.alParaval = alParaval
                        Dim IntResult As Integer = objclsPLAN.SAVE()
                    Else
                        CMBPLAN.Focus()
                        CMBPLAN.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    INCLUSIONS = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGUESTNAME(ByRef CMBGUEST As ComboBox, ByRef edit As Boolean)
        Try
            If CMBGUEST.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TOP 100 PERCENT GUEST_name ", "", " GUESTMaster", " AND ISNULL(GUEST_BLOCKED,0) = 'FALSE' AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GUEST_name"
                    CMBGUEST.DataSource = dt
                    CMBGUEST.DisplayMember = "GUEST_name"
                    If edit = False Then CMBGUEST.Text = ""
                End If
                CMBGUEST.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGUEST(ByRef CMBGUEST As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBGUEST.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GUEST_name ", "", " GUESTMaster", " and GUEST_YEARID = " & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GUEST_name"
                    CMBGUEST.DataSource = dt
                    CMBGUEST.DisplayMember = "GUEST_name"
                    If edit = False Then CMBGUEST.Text = ""
                End If
                CMBGUEST.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGUESTCATEGORY(ByRef CMBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CATEGORY_name ", "", " GUESTCATEGORYMASTER", " AND CATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CATEGORY_name"
                    CMBCATEGORY.DataSource = dt
                    CMBCATEGORY.DisplayMember = "CATEGORY_name"
                    If edit = False Then CMBCATEGORY.Text = ""
                End If
                CMBCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GUESTCATEGORYVALIDATE(ByRef CMBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCATEGORY.Text.Trim <> "" Then
                pcase(CMBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CATEGORY_id", "", "GUESTCATEGORYMASTER", " and CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' and CATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Guest Category not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCATEGORY.Text.Trim)
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim objclsCATEGORY As New ClsGuestCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.SAVE()
                    Else
                        CMBCATEGORY.Focus()
                        CMBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLTOURNAME(ByRef CMBTOURNAME As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBTOURNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TOUR_name ", "", " TOURMaster", " and TOUR_YEARID = " & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TOUR_name"
                    CMBTOURNAME.DataSource = dt
                    CMBTOURNAME.DisplayMember = "TOUR_name"
                    If edit = False Then CMBTOURNAME.Text = ""
                End If
                CMBTOURNAME.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCOUNTRYTAX(ByRef CMBCOUNTRYTAX As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBCOUNTRYTAX.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TAX_name ", "", " COUNTRYTAXMASTER", " and TAX_YEARID = " & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TAX_name"
                    CMBCOUNTRYTAX.DataSource = dt
                    CMBCOUNTRYTAX.DisplayMember = "TAX_name"
                    If edit = False Then CMBCOUNTRYTAX.Text = ""
                End If
                CMBCOUNTRYTAX.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub GUESTNAMEVALIDATE(ByRef CMBGUEST As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGUEST.Text.Trim <> "" Then
                pcase(CMBGUEST)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GUEST_ADD", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GUEST not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New GuestMaster
                        OBJGUEST.TEMPGUESTNAME = CMBGUEST.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search("GUEST_ADD", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBGUEST.Text.Trim
                            dt1 = CMBGUEST.DataSource
                            If CMBGUEST.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBGUEST.Text.Trim)
                                    CMBGUEST.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBGUEST.Focus()
                        CMBGUEST.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    If TXTADD.Text.Trim = "" Then TXTADD.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CORDINATORVALIDATE(ByRef CMBGUEST As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGUEST.Text.Trim <> "" Then
                pcase(CMBGUEST)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GUEST_NAME", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' AND GUEST_CORDINATOR=1 and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GUEST not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New GuestMaster
                        OBJGUEST.TEMPGUESTNAME = CMBGUEST.Text.Trim()
                        OBJGUEST.RDBCORDINATOR.Checked = True
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search("GUEST_NAME", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' and GUEST_CORDINATOR=1 and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBGUEST.Text.Trim
                            dt1 = CMBGUEST.DataSource
                            If CMBGUEST.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBGUEST.Text.Trim)
                                    CMBGUEST.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBGUEST.Focus()
                        CMBGUEST.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBGUEST.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub LEADERVALIDATE(ByRef CMBGUEST As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGUEST.Text.Trim <> "" Then
                pcase(CMBGUEST)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GUEST_NAME", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' AND GUEST_LEADER=1 and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GUEST not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New GuestMaster
                        OBJGUEST.TEMPGUESTNAME = CMBGUEST.Text.Trim()
                        OBJGUEST.RDBLEADER.Checked = True
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search("GUEST_NAME", "", "GUESTMASTER", " and GUEST_NAME = '" & CMBGUEST.Text.Trim & "' and GUEST_LEADER=1 and GUEST_cmpid = " & CmpId & " and GUEST_LOCATIONid = " & Locationid & " and GUEST_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBGUEST.Text.Trim
                            dt1 = CMBGUEST.DataSource
                            If CMBGUEST.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBGUEST.Text.Trim)
                                    CMBGUEST.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBGUEST.Focus()
                        CMBGUEST.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBGUEST.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MISCVALIDATE(ByRef CMBMISC As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBMISC.Text.Trim <> "" Then
                pcase(CMBMISC)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" MISC_NAME", "", " MISCEXPMASTER", " and MISC_NAME = '" & CMBMISC.Text.Trim & "' and MISC_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Misc Exp. not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "MISCEXP"
                        OBJGUEST.tempname = CMBMISC.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search("MISC_NAME", "", " MISCEXPMASTER", " and MISC_NAME = '" & CMBMISC.Text.Trim & "' and MISC_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBMISC.Text.Trim
                            dt1 = CMBMISC.DataSource
                            If CMBMISC.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBMISC.Text.Trim)
                                    CMBMISC.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBMISC.Focus()
                        CMBMISC.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBMISC.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ADDSERVICEVALIDATE(ByRef CMBADDSERVICE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBADDSERVICE.Text.Trim <> "" Then
                pcase(CMBADDSERVICE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SERVICE_NAME", "", " SERVICEMASTER", " and SERVICE_NAME = '" & CMBADDSERVICE.Text.Trim & "' and SERVICE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Add. Services not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "ADDSERVICE"
                        OBJGUEST.tempname = CMBADDSERVICE.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" SERVICE_NAME", "", " SERVICEMASTER", " and SERVICE_NAME = '" & CMBADDSERVICE.Text.Trim & "' and SERVICE_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBADDSERVICE.Text.Trim
                            dt1 = CMBADDSERVICE.DataSource
                            If CMBADDSERVICE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBADDSERVICE.Text.Trim)
                                    CMBADDSERVICE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBADDSERVICE.Focus()
                        CMBADDSERVICE.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBADDSERVICE.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub LAWAZIMVALIDATE(ByRef CMBLAWAZIM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBLAWAZIM.Text.Trim <> "" Then
                pcase(CMBLAWAZIM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("LWZM_NAME", "", " LAWAZIMMASTER", " and LWZM_NAME = '" & CMBLAWAZIM.Text.Trim & "' and LWZM_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Lawazim not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "LAWAZIM"
                        OBJGUEST.tempname = CMBLAWAZIM.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" LWZM_NAME", "", " LAWAZIMMASTER", " and LWZM_NAME = '" & CMBLAWAZIM.Text.Trim & "' and LWZM_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBLAWAZIM.Text.Trim
                            dt1 = CMBLAWAZIM.DataSource
                            If CMBLAWAZIM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBLAWAZIM.Text.Trim)
                                    CMBLAWAZIM.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBLAWAZIM.Focus()
                        CMBLAWAZIM.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBLAWAZIM.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub VISAVALIDATE(ByRef CMBVISA As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBVISA.Text.Trim <> "" Then
                pcase(CMBVISA)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("VISA_NAME", "", " VISAMASTER", " and VISA_NAME = '" & CMBVISA.Text.Trim & "' and VISA_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Visa not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "VISA"
                        OBJGUEST.tempname = CMBVISA.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" VISA_NAME", "", " VISAMASTER", " and VISA_NAME = '" & CMBVISA.Text.Trim & "' and VISA_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBVISA.Text.Trim
                            dt1 = CMBVISA.DataSource
                            If CMBVISA.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBVISA.Text.Trim)
                                    CMBVISA.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBVISA.Focus()
                        CMBVISA.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBVISA.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub COUNTRYTAXVALIDATE(ByRef CMBCOUNTRYTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRYTAX.Text.Trim <> "" Then
                pcase(CMBCOUNTRYTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", " COUNTRYTAXMASTER", " and TAX_NAME = '" & CMBCOUNTRYTAX.Text.Trim & "' and TAX_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Country tax not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "TAX"
                        OBJGUEST.tempname = CMBCOUNTRYTAX.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" TAX_NAME", "", " COUNTRYTAXMASTER", " and TAX_NAME = '" & CMBCOUNTRYTAX.Text.Trim & "' and TAX_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCOUNTRYTAX.Text.Trim
                            dt1 = CMBCOUNTRYTAX.DataSource
                            If CMBCOUNTRYTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCOUNTRYTAX.Text.Trim)
                                    CMBCOUNTRYTAX.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBCOUNTRYTAX.Focus()
                        CMBCOUNTRYTAX.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBCOUNTRYTAX.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TRANSPORTVALIDATE(ByRef CMBTRANSPORT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTRANSPORT.Text.Trim <> "" Then
                pcase(CMBTRANSPORT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TRANS_NAME", "", " TRANSPORTMASTER", " and TRANS_NAME = '" & CMBTRANSPORT.Text.Trim & "' and TRANS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Transport not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "TRANSPORT"
                        OBJGUEST.tempname = CMBTRANSPORT.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" TRANS_NAME", "", " TRANSMASTER", " and TRANS_NAME = '" & CMBTRANSPORT.Text.Trim & "' and TRANS_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBTRANSPORT.Text.Trim
                            dt1 = CMBTRANSPORT.DataSource
                            If CMBTRANSPORT.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTRANSPORT.Text.Trim)
                                    CMBTRANSPORT.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBTRANSPORT.Focus()
                        CMBTRANSPORT.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBTRANSPORT.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOURVALIDATE(ByRef CMBTOUR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTOUR.Text.Trim <> "" Then
                pcase(CMBTOUR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TOUR_NAME", "", " TOURMASTER", " and TOUR_NAME = '" & CMBTOUR.Text.Trim & "' and TOUR_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Tour not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New TourMaster
                        OBJGUEST.TXTTOURNAME.Text = CMBTOUR.Text.Trim()

                        OBJGUEST.ShowDialog()
                        OBJGUEST.BringToFront()
                        dt = objclscommon.search(" TOUR_NAME", "", " TOURMASTER", " and TOUR_NAME = '" & CMBTOUR.Text.Trim & "' and TOUR_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBTOUR.Text.Trim
                            dt1 = CMBTOUR.DataSource
                            If CMBTOUR.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTOUR.Text.Trim)
                                    CMBTOUR.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBTOUR.Focus()
                        CMBTOUR.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBTOUR.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GIFTVALIDATE(ByRef CMBGIFT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGIFT.Text.Trim <> "" Then
                pcase(CMBGIFT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GIFT_NAME", "", " GIFTMASTER", " and GIFT_NAME = '" & CMBGIFT.Text.Trim & "' and GIFT_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Gift not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New LawazimMaster
                        OBJGUEST.frmstring = "GIFT"
                        OBJGUEST.tempname = CMBGIFT.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" GIFT_NAME", "", " GIFTMASTER", " and GIFT_NAME = '" & CMBGIFT.Text.Trim & "' and GIFT_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBGIFT.Text.Trim
                            dt1 = CMBGIFT.DataSource
                            If CMBGIFT.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBGIFT.Text.Trim)
                                    CMBGIFT.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBGIFT.Focus()
                        CMBGIFT.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBGIFT.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MEALPLANVALIDATE(ByRef CMBPLAN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPLAN.Text.Trim <> "" Then
                pcase(CMBPLAN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PLAN_NAME", "", "  PLANMASTER INNER JOIN MEALCONGIGMASTER ON PLANMASTER.PLAN_ID = MEALCONGIGMASTER.MEAL_mealid AND PLANMASTER.PLAN_YEARID = MEALCONGIGMASTER.MEAL_yearid", " and PLAN_NAME = '" & CMBPLAN.Text.Trim & "' and PLAN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Meal Plan not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New MealConfigurator
                        OBJGUEST.frmstring = "MEALMASTER"
                        OBJGUEST.tempname = CMBPLAN.Text.Trim()
                        OBJGUEST.ShowDialog()
                        dt = objclscommon.search(" PLAN_NAME", "", "  PLANMASTER INNER JOIN MEALCONGIGMASTER ON PLANMASTER.PLAN_ID = MEALCONGIGMASTER.MEAL_mealid AND PLANMASTER.PLAN_YEARID = MEALCONGIGMASTER.MEAL_yearid", " and PLAN_NAME = '" & CMBPLAN.Text.Trim & "' and PLAN_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBPLAN.Text.Trim
                            dt1 = CMBPLAN.DataSource
                            If CMBPLAN.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBPLAN.Text.Trim)
                                    CMBPLAN.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBPLAN.Focus()
                        CMBPLAN.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBPLAN.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLDRIVERNAME(ByRef CMBDRIVER As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBDRIVER.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DRIVER_name ", "", " DRIVERMaster", " and DRIVER_cmpid=" & CmpId & " AND DRIVER_LOCATIONID = " & Locationid & " AND DRIVER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DRIVER_name"
                    CMBDRIVER.DataSource = dt
                    CMBDRIVER.DisplayMember = "DRIVER_name"
                    If edit = False Then CMBDRIVER.Text = ""
                End If
                CMBDRIVER.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DRIVERNAMEVALIDATE(ByRef CMBDRIVER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDRIVER.Text.Trim <> "" Then
                pcase(CMBDRIVER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DRIVER_ADD", "", "DRIVERMASTER", " and DRIVER_NAME = '" & CMBDRIVER.Text.Trim & "' and DRIVER_cmpid = " & CmpId & " and DRIVER_LOCATIONid = " & Locationid & " and DRIVER_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DRIVER not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJDRIVER As New DriverMaster
                        OBJDRIVER.TEMPDRIVERNAME = CMBDRIVER.Text.Trim()
                        OBJDRIVER.ShowDialog()
                        dt = objclscommon.search("DRIVER_ADD", "", "DRIVERMASTER", " and DRIVER_NAME = '" & CMBDRIVER.Text.Trim & "' and DRIVER_cmpid = " & CmpId & " and DRIVER_LOCATIONid = " & Locationid & " and DRIVER_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBDRIVER.Text.Trim
                            dt1 = CMBDRIVER.DataSource
                            If CMBDRIVER.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBDRIVER.Text.Trim)
                                    CMBDRIVER.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBDRIVER.Focus()
                        CMBDRIVER.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLBOOKEDBY(ByRef CMBBOOKEDBY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" BOOKEDBY_name ", "", " BOOKEDBYMaster", " AND BOOKEDBY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "BOOKEDBY_name"
                    CMBBOOKEDBY.DataSource = dt
                    CMBBOOKEDBY.DisplayMember = "BOOKEDBY_name"
                    If edit = False Then CMBBOOKEDBY.Text = ""
                End If
                CMBBOOKEDBY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillDoc(ByRef CHKDOC As CheckedListBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CHKDOC.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" doc_name ", "", " DOCMASTER ", " AND DOC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Doc_name"
                    CHKDOC.DataSource = dt
                    CHKDOC.DisplayMember = "Doc_name"
                    If edit = False Then CHKDOC.Text = ""
                End If
                ''CHKDOC.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BOOKEDBYvalidate(ByRef CMBBOOKEDBY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBBOOKEDBY.Text.Trim <> "" Then
                pcase(CMBBOOKEDBY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("BOOKEDBY_id", "", "BOOKEDBYMaster", " and BOOKEDBY_NAME = '" & CMBBOOKEDBY.Text.Trim & "' and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_LOCATIONid = " & Locationid & " and BOOKEDBY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("BOOKEDBY ID not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBBOOKEDBY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsBOOKEDBY As New ClsBookedByMaster
                        objclsBOOKEDBY.alParaval = alParaval
                        Dim IntResult As Integer = objclsBOOKEDBY.SAVE()
                    Else
                        CMBBOOKEDBY.Focus()
                        CMBBOOKEDBY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUPOFHOTELS(ByRef CMBGROUPOFHOTELS As ComboBox)
        Try
            If CMBGROUPOFHOTELS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GROUPOFHOTELS_name ", "", " GROUPOFHOTELSMaster", " and GROUPOFHOTELS_cmpid=" & CmpId & " AND GROUPOFHOTELS_LOCATIONID = " & Locationid & " AND GROUPOFHOTELS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GROUPOFHOTELS_name"
                    CMBGROUPOFHOTELS.DataSource = dt
                    CMBGROUPOFHOTELS.DisplayMember = "GROUPOFHOTELS_name"
                    CMBGROUPOFHOTELS.Text = ""
                End If
                CMBGROUPOFHOTELS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GROUPOFHOTELSVALIDATE(ByRef CMBGROUPOFHOTELS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGROUPOFHOTELS.Text.Trim <> "" Then
                uppercase(CMBGROUPOFHOTELS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GROUPOFHOTELS_id", "", "GROUPOFHOTELSMaster", " and GROUPOFHOTELS_NAME = '" & CMBGROUPOFHOTELS.Text.Trim & "' and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_LOCATIONid = " & Locationid & " and GROUPOFHOTELS_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Group Of Hotels not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGROUPOFHOTELS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJGROUP As New ClsGroupOfHotelsMaster
                        OBJGROUP.alParaval = alParaval
                        Dim IntResult As Integer = OBJGROUP.SAVE()
                    Else
                        CMBGROUPOFHOTELS.Focus()
                        CMBGROUPOFHOTELS.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ALPHEBETKEYPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If (AscW(han.KeyChar) >= 65 And AscW(han.KeyChar) <= 90) Or (AscW(han.KeyChar) >= 97 And AscW(han.KeyChar) <= 122) Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If
        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub ACCCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBACCNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_CMPNAME, ACC_ADD", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsCode = CMBCODE.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_CODE", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBACCNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub namevalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If cmbname.Text.Trim <> "" Then
                UCase(cmbname.Text.Trim)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull(ACC_CODE,'') ", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cmpname = '" & cmbname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME

                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_cmpname", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cmpname = '" & cmbname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = cmbname.Text.Trim
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    CMBACCCODE.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ledgervalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                pcase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,'')", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID ", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    CMBACCCODE.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillROOMTYPE(ByRef CMBROOMTYPE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ROOMTYPE_NAME ", "", " ROOMTYPEMASTER", " and ROOMTYPE_cmpid=" & CmpId & " AND ROOMTYPE_LOCATIONID = " & Locationid & " AND ROOMTYPE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ROOMTYPE_NAME"
                CMBROOMTYPE.DataSource = dt
                CMBROOMTYPE.DisplayMember = "ROOMTYPE_NAME"
                CMBROOMTYPE.Text = ""
            End If
            CMBROOMTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ROOMTYPEVALIDATE(ByRef CMBROOMTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBROOMTYPE.Text.Trim <> "" Then
                uppercase(CMBROOMTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ROOMTYPE_id", "", "ROOMTYPEMaster", " and ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' and ROOMTYPE_cmpid = " & CmpId & " and ROOMTYPE_LOCATIONid = " & Locationid & " and ROOMTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("ROOMTYPE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBROOMTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsROOMTYPE As New ClsRoomTypeMaster
                        objclsROOMTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsROOMTYPE.SAVE()
                    Else
                        CMBROOMTYPE.Focus()
                        CMBROOMTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLROUTE(ByRef CMBROUTE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ROUTE_NAME ", "", " ROUTEMASTER", " and ROUTE_cmpid=" & CmpId & " AND ROUTE_LOCATIONID = " & Locationid & " AND ROUTE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ROUTE_NAME"
                CMBROUTE.DataSource = dt
                CMBROUTE.DisplayMember = "ROUTE_NAME"
                CMBROUTE.Text = ""
            End If
            CMBROUTE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ROUTEVALIDATE(ByRef CMBROUTE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBROUTE.Text.Trim <> "" Then
                uppercase(CMBROUTE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ROUTE_id", "", "ROUTEMaster", " and ROUTE_NAME = '" & CMBROUTE.Text.Trim & "' and ROUTE_cmpid = " & CmpId & " and ROUTE_LOCATIONid = " & Locationid & " and ROUTE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("ROUTE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBROUTE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsROUTE As New ClsRouteMaster
                        objclsROUTE.alParaval = alParaval
                        Dim IntResult As Integer = objclsROUTE.SAVE()
                    Else
                        CMBROUTE.Focus()
                        CMBROUTE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillHOTELTYPE(ByRef CMBHOTELTYPE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTELTYPE_NAME ", "", " HOTELTYPEMASTER", " and HOTELTYPE_cmpid=" & CmpId & " AND HOTELTYPE_LOCATIONID = " & Locationid & " AND HOTELTYPE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTELTYPE_NAME"
                CMBHOTELTYPE.DataSource = dt
                CMBHOTELTYPE.DisplayMember = "HOTELTYPE_NAME"
                CMBHOTELTYPE.Text = ""
            End If
            CMBHOTELTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELTYPEVALIDATE(ByRef CMBHOTELTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHOTELTYPE.Text.Trim <> "" Then
                uppercase(CMBHOTELTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("HOTELTYPE_id", "", "HOTELTYPEMaster", " and HOTELTYPE_NAME = '" & CMBHOTELTYPE.Text.Trim & "' and HOTELTYPE_cmpid = " & CmpId & " and HOTELTYPE_LOCATIONid = " & Locationid & " and HOTELTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("HOTELTYPE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBHOTELTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsHOTELTYPE As New ClsHotelTypeMaster
                        objclsHOTELTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsHOTELTYPE.SAVE()
                    Else
                        CMBHOTELTYPE.Focus()
                        CMBHOTELTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLDEPARTMENT(ByRef CMBDEPARTMENT As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEPARTMENT_NAME ", "", " DEPARTMENTMASTER", " and DEPARTMENT_cmpid=" & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEPARTMENT_NAME"
                CMBDEPARTMENT.DataSource = dt
                CMBDEPARTMENT.DisplayMember = "DEPARTMENT_NAME"
                CMBDEPARTMENT.Text = ""
            End If
            CMBDEPARTMENT.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                uppercase(CMBDEPARTMENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEPARTMENT_id", "", "DEPARTMENTMaster", " and DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_LOCATIONid = " & Locationid & " and DEPARTMENT_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEPARTMENT not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEPARTMENT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEPARTMENT As New ClsDepartmentMaster
                        objclsDEPARTMENT.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEPARTMENT.SAVE()
                    Else
                        CMBDEPARTMENT.Focus()
                        CMBDEPARTMENT.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLLEADTYPE(ByRef CMBLEADTYPE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" LEADTYPE_NAME ", "", " LEADTYPEMASTER", " and LEADTYPE_cmpid=" & CmpId & " AND LEADTYPE_LOCATIONID = " & Locationid & " AND LEADTYPE_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "LEADTYPE_NAME"
                CMBLEADTYPE.DataSource = dt
                CMBLEADTYPE.DisplayMember = "LEADTYPE_NAME"
                CMBLEADTYPE.Text = ""
            End If
            CMBLEADTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub LEADTYPEVALIDATE(ByRef CMBLEADTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBLEADTYPE.Text.Trim <> "" Then
                uppercase(CMBLEADTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("LEADTYPE_id", "", "LEADTYPEMaster", " and LEADTYPE_NAME = '" & CMBLEADTYPE.Text.Trim & "' and LEADTYPE_cmpid = " & CmpId & " and LEADTYPE_LOCATIONid = " & Locationid & " and LEADTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("LEADTYPE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBLEADTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsLEADTYPE As New ClsLeadTypeMaster
                        objclsLEADTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsLEADTYPE.SAVE()
                    Else
                        CMBLEADTYPE.Focus()
                        CMBLEADTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDESIGNATION(ByRef CMBDESIGNATION As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DESIGNATION_NAME ", "", " DESIGNATIONMASTER", " and DESIGNATION_cmpid=" & CmpId & " AND DESIGNATION_LOCATIONID = " & Locationid & " AND DESIGNATION_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DESIGNATION_NAME"
                CMBDESIGNATION.DataSource = dt
                CMBDESIGNATION.DisplayMember = "DESIGNATION_NAME"
                CMBDESIGNATION.Text = ""
            End If
            CMBDESIGNATION.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DESIGNATIONVALIDATE(ByRef CMBDESIGNATION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDESIGNATION.Text.Trim <> "" Then
                uppercase(CMBDESIGNATION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DESIGNATION_id", "", "DESIGNATIONMaster", " and DESIGNATION_NAME = '" & CMBDESIGNATION.Text.Trim & "' and DESIGNATION_cmpid = " & CmpId & " and DESIGNATION_LOCATIONid = " & Locationid & " and DESIGNATION_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DESIGNATION not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDESIGNATION.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDESIGNATION As New ClsDesignationMaster
                        objclsDESIGNATION.alParaval = alParaval
                        Dim IntResult As Integer = objclsDESIGNATION.SAVE()
                    Else
                        CMBDESIGNATION.Focus()
                        CMBDESIGNATION.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillHOTELCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTEL_CODE ", "", " HOTELMASTER", " and HOTEL_cmpid=" & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTEL_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "HOTEL_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBHOTELNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox)
        Try

            If CMBCODE.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" HOTEL_NAME, HOTEL_ADD ", "", "HOTELMASTER", " and HOTEL_CODE = '" & CMBCODE.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJHOTEL As New HotelMaster
                        OBJHOTEL.cmbcode.Text = CMBCODE.Text.Trim()
                        OBJHOTEL.ShowDialog()
                        dt = objclscommon.search(" HOTEL_CODE ", "", "HOTELMASTER", " and HOTEL_CODE = '" & CMBCODE.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBHOTELNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLNATURE(ByRef CMBNATURE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" PAY_name ", "", " NATUREOFPAYMENTMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PAY_name"
                CMBNATURE.DataSource = dt
                CMBNATURE.DisplayMember = "PAY_name"
                CMBNATURE.Text = ""
            End If
            CMBNATURE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATUREVALIDATE(ByRef CMBNATURE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATURE.Text.Trim <> "" Then
                uppercase(CMBNATURE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAY_id", "", "NATUREOFPAYMENTMASTER", " and PAY_NAME = '" & CMBNATURE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("NATURE OF PAYMENT not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBNATURE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJNATUREOFPAYMENT As New ClsNatureOfPayment
                        OBJNATUREOFPAYMENT.alParaval = alParaval
                        Dim IntResult As Integer = OBJNATUREOFPAYMENT.SAVE()
                    Else
                        CMBNATURE.Focus()
                        CMBNATURE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub HSNITEMDESCVALIDATE(ByRef CMBHSNCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHSNCODE.Text.Trim <> "" Then
                uppercase(CMBHSNCODE)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", "and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHSNCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("HSN/SAC Code Not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBHSNCODE.Text = a
                        Dim OBJDELIVERY As New HSNMaster
                        OBJDELIVERY.TEMPHSNCODE = CMBHSNCODE.Text.Trim()

                        OBJDELIVERY.ShowDialog()
                        dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", " and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHSNCODE.DataSource
                            If CMBHSNCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHSNCODE.Text.Trim)
                                    CMBHSNCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDEDUCTEETYPE(ByRef cmbDEDUCTEE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEDUCTEETYPE_name ", "", " DEDUCTEETYPEMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.DataSource = dt
                cmbDEDUCTEE.DisplayMember = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.Text = ""
            End If
            cmbDEDUCTEE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEDUCTEETYPEVALIDATE(ByRef CMBDEDUCTEETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                uppercase(CMBDEDUCTEETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEDUCTEETYPE_id", "", "DEDUCTEETYPEMASTER", " and DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEDUCTEETYPE not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEDUCTEETYPE As New ClsDeducteetypeMaster
                        objclsDEDUCTEETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEDUCTEETYPE.SAVE()
                    Else
                        CMBDEDUCTEETYPE.Focus()
                        CMBDEDUCTEETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUP(ByRef CMBGROUP As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "Group_name"
                CMBGROUP.DataSource = dt
                CMBGROUP.DisplayMember = "group_name"
                CMBGROUP.Text = ""
            End If
            CMBGROUP.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GROUPVALIDATE(ByRef CMBGROUP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBGROUP.Text.Trim <> "" Then
                pcase(CMBGROUP)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & CMBGROUP.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBGROUP.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        CMBGROUP.Text = a
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = CMBGROUP.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & CMBGROUP.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBGROUP.DataSource
                            If CMBGROUP.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(CMBGROUP.Text)
                                CMBGROUP.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLGROUPNAME(ByRef CMBGROUP As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" GROUPDEP_NAME ", "", " GROUPDEPARTURE", " AND GROUPDEP_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "GROUPDEP_NAME"
                CMBGROUP.DataSource = dt
                CMBGROUP.DisplayMember = "GROUPDEP_NAME"
                CMBGROUP.Text = ""
            End If
            CMBGROUP.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GROUPNAMEVALIDATE(ByRef CMBGROUPNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal CONDITION As String)
        Try

            If CMBGROUPNAME.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GROUPDEP_NAME ", "", " GROUPDEPARTURE ", CONDITION & " and GROUPDEP_NAME = '" & CMBGROUPNAME.Text.Trim & "' AND GROUPDEP_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Group Departure not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJGROUP As New GroupDeparture
                        OBJGROUP.TEMPGROUPNAME = CMBGROUPNAME.Text.Trim()
                        OBJGROUP.ShowDialog()
                        dt = objclscommon.search(" GROUPDEP_NAME ", "", "GROUPDEPARTURE", CONDITION & " and GROUPDEP_NAME = '" & CMBGROUPNAME.Text.Trim & "' AND GROUPDEP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBGROUPNAME.Text.Trim
                            dt1 = CMBGROUPNAME.DataSource
                            If CMBGROUPNAME.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBGROUPNAME.Text.Trim)
                                    CMBGROUPNAME.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillHOTEL(ByRef CMBHOTELNAME As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" HOTEL_NAME ", "", " HOTELMASTER", " AND ISNULL(HOTEL_BLOCKED,0) = 'FALSE' AND HOTEL_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HOTEL_NAME"
                CMBHOTELNAME.DataSource = dt
                CMBHOTELNAME.DisplayMember = "HOTEL_NAME"
                CMBHOTELNAME.Text = ""
            End If
            CMBHOTELNAME.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HOTELvalidate(ByRef CMBHOTEL As ComboBox, ByVal CMBCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox)
        Try

            If CMBHOTEL.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" HOTEL_CODE, HOTEL_ADD ", "", "HOTELMASTER", " and HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Hotel not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim OBJHOTEL As New HotelMaster
                        OBJHOTEL.CMBHOTELNAME.Text = CMBHOTEL.Text.Trim()
                        OBJHOTEL.ShowDialog()
                        dt = objclscommon.search(" HOTEL_NAME ", "", "HOTELMASTER", " and HOTEL_NAME = '" & CMBHOTEL.Text.Trim & "' and HOTEL_cmpid = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBHOTEL.Text.Trim
                            dt1 = CMBHOTEL.DataSource
                            If CMBHOTEL.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHOTEL.Text.Trim)
                                    CMBHOTEL.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBCODE.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLCURRENCY(ByRef CMBCURRENCY As ComboBox)
        Try
            If cmbCurrency.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CUR_CODE ", "", " CurrencyMaster ", " and cur_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CUR_CODE"
                    cmbCurrency.DataSource = dt
                    cmbCurrency.DisplayMember = "CUR_CODE"
                    cmbCurrency.Text = ""
                End If
                cmbCurrency.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCountry(ByRef cmbcountry As ComboBox)
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" COUNTRY_NAME ", "", " CountryMaster ", " and Country_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COUNTRY_NAME"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "COUNTRY_NAME"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCityCode(ByRef cmbcity As ComboBox)
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CITY_REMARK ", "", " CITYMaster ", " and CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CITY_REMARK"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "CITY_REMARK"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillLAWAZIM(ByRef CMBLAWAZIM As ComboBox)
        Try
            If CMBLAWAZIM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" LWZM_NAME", "", " LAWAZIMMASTER ", " and LWZM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "LWZM_NAME"
                    CMBLAWAZIM.DataSource = dt
                    CMBLAWAZIM.DisplayMember = "LWZM_NAME"
                    CMBLAWAZIM.Text = ""
                End If
                CMBLAWAZIM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillVISA(ByRef CMBVISA As ComboBox)
        Try
            If CMBVISA.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" VISA_NAME", "", " VISAMASTER ", " and VISA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "VISA_NAME"
                    CMBVISA.DataSource = dt
                    CMBVISA.DisplayMember = "VISA_NAME"
                    CMBVISA.Text = ""
                End If
                CMBVISA.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillTRANSPORT(ByRef CMBTRANSPORT As ComboBox)
        Try
            If CMBTRANSPORT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TRANS_NAME", "", " TRANSPORTMASTER ", " and TRANS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TRANS_NAME"
                    CMBTRANSPORT.DataSource = dt
                    CMBTRANSPORT.DisplayMember = "TRANS_NAME"
                    CMBTRANSPORT.Text = ""
                End If
                CMBTRANSPORT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillGIFT(ByRef CMBGIFT As ComboBox)
        Try
            If CMBGIFT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GIFT_NAME", "", " GIFTMASTER ", " and GIFT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GIFT_NAME"
                    CMBGIFT.DataSource = dt
                    CMBGIFT.DisplayMember = "GIFT_NAME"
                    CMBGIFT.Text = ""
                End If
                CMBGIFT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillMISCEXP(ByRef CMBMISCEXP As ComboBox)
        Try
            If CMBMISCEXP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" MISC_NAME", "", " MISCEXPMASTER ", " and MISC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "MISC_NAME"
                    CMBMISCEXP.DataSource = dt
                    CMBMISCEXP.DisplayMember = "MISC_NAME"
                    CMBMISCEXP.Text = ""
                End If
                CMBMISCEXP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillSERVICE(ByRef CMBSERVICE As ComboBox)
        Try
            If CMBSERVICE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SERVICE_NAME", "", " SERVICEMASTER ", " and SERVICE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SERVICE_NAME"
                    CMBSERVICE.DataSource = dt
                    CMBSERVICE.DisplayMember = "SERVICE_NAME"
                    CMBSERVICE.Text = ""
                End If
                CMBSERVICE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillunit(ByRef cmbunit As ComboBox)
        Try
            If cmbunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", " UnitMaster ", " and unit_cmpid=" & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "unit_abbr"
                    cmbunit.DataSource = dt
                    cmbunit.DisplayMember = "unit_abbr"
                    cmbunit.Text = ""
                End If
                cmbunit.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub unitvalidate(ByRef cmbunit As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbunit.Text.Trim <> "" Then
                lowercase(cmbunit)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Unit not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objunitmaster As New UnitMaster
                        objunitmaster.frmString = "UNIT"
                        objunitmaster.txtabbr.Text = cmbunit.Text.Trim()
                        objunitmaster.ShowDialog()
                        dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " AND UNIT_LOCATIONID = " & Locationid & " AND UNIT_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = cmbunit.Text.Trim
                            dt1 = cmbunit.DataSource
                            If cmbunit.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbunit.Text.Trim)
                                    cmbunit.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLSTAGE(ByRef CMBSTAGE As ComboBox)
        Try
            If CMBSTAGE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STAGE_name, STAGE_NO ", "", " STAGEMASTER ", " AND STAGE_YEARID =" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STAGE_NO"
                    CMBSTAGE.DataSource = dt
                    CMBSTAGE.DisplayMember = "STAGE_name"
                    CMBSTAGE.Text = ""
                End If
                CMBSTAGE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "FUNCTION FOR EMAIL"

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal GUESTCATEGORY As String = "", Optional ByVal GROUPDEP As String = "", Optional ByVal ATTACHMENT1 As String = "", Optional ByVal SMTPPORT As Integer = 587, Optional ByVal ENABLESSL As Boolean = True, Optional ByVal CMPLOGO() As Byte = Nothing, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0)

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment
            Dim MAILATTACHMENT1 As Attachment

            'set the addresses
            If ClientName = "TOPCOMM" Then
                mail.From = New MailAddress("info@indiatravelite.com", "Top Communications - Indiatravelite.com")
                mail.CC.Add("indiatravelite@gmail.com")
            ElseIf ClientName = "SHREEJI" Then
                mail.From = New MailAddress("noreply.shreejitravelsmumbai@gmail.com", "Shreeji Travels")
            ElseIf ClientName = "BARODA" Then
                mail.From = New MailAddress("noreply.shreejitravelsvadodara@gmail.com", "Shreeji Travels")
            ElseIf ClientName = "RAMKRISHNA" Then
                mail.From = New MailAddress("shreeramkrishnatravels@gmail.com", "Shree Ram Krishna Travels")
            ElseIf ClientName = "URMI" Then
                mail.From = New MailAddress("urmitravel@gmail.com", CmpName)
            ElseIf ClientName = "WAHWAH" Then
                mail.From = New MailAddress("tours@travelwahwah.com", CmpName)
            Else
                mail.From = New MailAddress("noreply.travelmate@gmail.com", "TRAVELMATE")
            End If

            If toMail <> "" Then mail.To.Add(toMail)

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If GUESTCATEGORY <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS CATEGORY
                DT = OBJCMN.search("ISNULL(GUEST_EMAIL,'') AS EMAILID", "", " GUESTMASTER INNER JOIN GUESTCATEGORYMASTER ON GUEST_GUESTCATEGORYID = CATEGORY_ID", " AND CATEGORY_NAME = '" & GUESTCATEGORY & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        mail.Bcc.Add(DTROW("EMAILID"))
                    Next
                End If
            End If

            If GROUPDEP <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS GROUPDEP
                DT = OBJCMN.search("ISNULL(GUEST_EMAIL,'') AS EMAILID", "", " GROUPDEPARTURE INNER JOIN HOLIDAYPACKAGEMASTER ON GROUPDEPARTURE.GROUPDEP_NO = HOLIDAYPACKAGEMASTER.BOOKING_GROUPDEPARTID AND GROUPDEPARTURE.GROUPDEP_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID ", " AND GROUPDEP_NAME = '" & GROUPDEP & "' AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        mail.Bcc.Add(DTROW("EMAILID"))
                    Next
                End If
            End If

            'set the content
            mail.Subject = subject
            mail.Body = mailbody
            mail.IsBodyHtml = True

            If NOOFATTACHMENTS <= 1 Then
                If tempattachment <> "" Then
                    MAILATTACHMENT = New Attachment(tempattachment)
                    mail.Attachments.Add(MAILATTACHMENT)
                End If

                If ATTACHMENT1 <> "" Then
                    MAILATTACHMENT1 = New Attachment(ATTACHMENT1)
                    mail.Attachments.Add(MAILATTACHMENT1)
                End If
            Else
                For I As Integer = 0 To NOOFATTACHMENTS - 1
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
                    mail.Attachments.Add(MAILATTACHMENT)
                Next
            End If





            Dim myMailHTMLBody = "<html><head></head><body>" & mailbody & "<br/><img src=cid:ThePictureID></body></html>"


            'CREATE LINKED RESOURCE FOR ALT VIEW
            Using MYSTREAM As New MemoryStream(CMPLOGO)

                If CMPLOGO.Length > 0 Then
                    Dim myAltView As AlternateView = AlternateView.CreateAlternateViewFromString(myMailHTMLBody, New System.Net.Mime.ContentType("text/html"))
                    Dim myLinkedResouce = New LinkedResource(MYSTREAM, "image/jpeg")

                    'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                    myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                    'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                    myAltView.LinkedResources.Add(myLinkedResouce)
                    mail.AlternateViews.Add(myAltView)
                End If


                Dim smtp As New SmtpClient
                Dim nc As New System.Net.NetworkCredential


                'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
                DT = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")

                    'in shreeji PORT IS 465 SOMETIMES BUT IOF IT TAKES TIME TO SEND MAIL THEN CHANGE IT TO 25
                    'If (ClientName = "SHREEJI" Or ClientName = "BARODA") Then smtp.Port = (25) Else smtp.Port = (25) CHANGED ON 17-10-2016
                    'If ClientName = "BARODA" Then smtp.Port = (25) Else smtp.Port = (25)
                    'If ClientName = "SHREEJI" Then smtp.Port = (587)
                    smtp.Port = SMTPPORT

                    ' ADDED SHREEJI ON 17-10-2016 If ClientName = "LUXCREST" Or ClientName = "URMI" Or ClientName = "SCC" Or ClientName = "AERO" Then smtp.EnableSsl = True Else smtp.EnableSsl = False
                    If ClientName = "LUXCREST" Or ClientName = "URMI" Or ClientName = "SCC" Or ClientName = "AERO" Or ClientName = "SHREEJI" Then smtp.EnableSsl = True Else smtp.EnableSsl = False
                    smtp.EnableSsl = ENABLESSL

                    If DT.Rows(0).Item("EMAIL") = "" Then
                        nc.UserName = "noreply.travelmate@gmail.com"
                        nc.Password = "infosys123"
                        smtp.Host = "smtp.gmail.com"
                        smtp.Port = (587)
                        smtp.EnableSsl = True
                    Else
                        nc.UserName = DT.Rows(0).Item("EMAIL")
                        nc.Password = DT.Rows(0).Item("PASS")
                    End If
                Else

                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = (587)
                    smtp.EnableSsl = True

                    nc.UserName = "noreply.travelmate@gmail.com"
                    nc.Password = "infosys123"

                End If
                mail.From = New MailAddress(nc.UserName, CmpName)

                smtp.Credentials = nc
                smtp.Timeout = 500000
                smtp.Send(mail)
                mail.Dispose()

            End Using


        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

    Function checkrowlinedel(ByVal gridsrno As Integer, ByVal txtno As System.Windows.Forms.TextBox) As Boolean
        Dim bln As Boolean = True
        If gridsrno = txtno.Text.Trim Then
            bln = False
        End If
        Return bln
    End Function

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and " + cWord3(CDbl(strNumDec)) + " Paise", "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord
    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        Dim i As Integer
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

    Sub RELATIONVALIDATE(ByRef CMBRELATION As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBRELATION.Text.Trim <> "" Then
                uppercase(CMBRELATION)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("RELATION_id", "", "RELATIONMaster", " and RELATION_NAME = '" & CMBRELATION.Text.Trim & "' and RELATION_cmpid = " & CmpId & " and RELATION_LOCATIONid = " & Locationid & " and RELATION_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Relation not present, Add New?", MsgBoxStyle.YesNo, "ENGG")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBRELATION.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsRELATION As New ClsRelationMaster
                        objclsRELATION.alParaval = alParaval
                        Dim IntResult As Integer = objclsRELATION.SAVE()
                    Else
                        CMBRELATION.Focus()
                        CMBRELATION.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCATEGORY(ByRef CMBCATEGORY As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable = objclscommon.search(" CATEGORY_NAME ", "", " CATEGORYMASTER", " and CATEGORY_cmpid=" & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "CATEGORY_NAME"
                CMBCATEGORY.DataSource = dt
                CMBCATEGORY.DisplayMember = "CATEGORY_NAME"
                CMBCATEGORY.Text = ""
            End If
            CMBCATEGORY.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CATEGORYVALIDATE(ByRef CMBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCATEGORY.Text.Trim <> "" Then
                uppercase(CMBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CATEGORY_id", "", "CATEGORYMaster", " and CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_LOCATIONid = " & Locationid & " and CATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CATEGORY not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCATEGORY.Text.Trim)
                        alParaval.Add("")   'REMARKS
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCATEGORY As New ClsCustomerCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.SAVE()
                    Else
                        CMBCATEGORY.Focus()
                        CMBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillUSER(ByRef CMBUSER As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT User_Name as [UserName]", "", "USERMASTER", " and USERMASTER.USER_cmpid= " & CmpId & " ORDER BY USER_NAME ")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "USERNAME"
                CMBUSER.DataSource = dt
                CMBUSER.DisplayMember = "USERNAME"
                CMBUSER.Text = ""
            End If
            CMBUSER.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Class DateDifference
        ''' <summary>
        ''' defining Number of days in month; index 0=> january and 11=> December
        ''' february contain either 28 or 29 days, that's why here value is -1
        ''' which wil be calculate later.
        ''' </summary>
        Private monthDay As Integer() = New Integer(11) {31, -1, 31, 30, 31, 30,
         31, 31, 30, 31, 30, 31}

        ''' <summary>
        ''' contain from date
        ''' </summary>
        Private fromDate As DateTime

        ''' <summary>
        ''' contain To Date
        ''' </summary>
        Private toDate As DateTime

        ''' <summary>
        ''' this three variable for output representation..
        ''' </summary>
        Private year As Integer
        Private month As Integer
        Private day As Integer

        Public Sub New(ByVal d1 As DateTime, ByVal d2 As DateTime)
            Dim increment As Integer

            If d1 > d2 Then
                Me.fromDate = d2
                Me.toDate = d1
            Else
                Me.fromDate = d1
                Me.toDate = d2
            End If

            ''' 
            ''' Day Calculation
            ''' 
            increment = 0

            If Me.fromDate.Day > Me.toDate.Day Then

                increment = Me.monthDay(Me.fromDate.Month - 1)
            End If
            ''' if it is february month
            ''' if it's to day is less then from day
            If increment = -1 Then
                If DateTime.IsLeapYear(Me.fromDate.Year) Then
                    ' leap year february contain 29 days
                    increment = 29
                Else
                    increment = 28
                End If
            End If
            If increment <> 0 Then
                day = (Me.toDate.Day + increment) - Me.fromDate.Day
                increment = 1
            Else
                day = Me.toDate.Day - Me.fromDate.Day
            End If

            '''
            '''month calculation
            '''
            If (Me.fromDate.Month + increment) > Me.toDate.Month Then
                Me.month = (Me.toDate.Month + 12) - (Me.fromDate.Month + increment)
                increment = 1
            Else
                Me.month = (Me.toDate.Month) - (Me.fromDate.Month + increment)
                increment = 0
            End If

            '''
            ''' year calculation
            '''

            Me.year = Me.toDate.Year - (Me.fromDate.Year + increment)
        End Sub

        Public Overrides Function ToString() As String
            'return base.ToString();
            Return Me.year & " Year(s)-" & Me.month & " month(s)-" & Me.day & " day(s)"
        End Function

        Public ReadOnly Property Years() As Integer
            Get
                Return Me.year
            End Get
        End Property

        Public ReadOnly Property Months() As Integer
            Get
                Return Me.month
            End Get
        End Property

        Public ReadOnly Property Days() As Integer
            Get
                Return Me.day
            End Get
        End Property

    End Class

    Sub FILLPARTICULAR(ByRef CMBPARTICULAR As ComboBox, ByRef EDIT As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPARTICULAR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" ISNULL(PARTICULARMASTER.PARTICULAR_NAME,'') AS PARTICULAR ", "", " PARTICULARMASTER ", " AND PARTICULAR_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PARTICULAR"
                    CMBPARTICULAR.DataSource = dt
                    CMBPARTICULAR.DisplayMember = "PARTICULAR"
                    CMBPARTICULAR.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PARTICULARVALIDATE(ByVal CMBPARTICULARS As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs)
        Try
            If CMBPARTICULARS.Text.Trim <> "" Then
                uppercase(CMBPARTICULARS)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" particular_name ", "", " PARTICULARMASTER ", " and particular_name = '" & CMBPARTICULARS.Text.Trim & "' and particular_cmpid =" & CmpId & " and particular_locationid =" & Locationid & " and particular_yearid =" & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Particulars not present, Add New?", MsgBoxStyle.YesNo, "HOSPITALITY")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTICULARS.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objparticular As New ClsParticularMaster
                        objparticular.alParaval = alParaval
                        Dim INTRESULT As Integer = objparticular.save()
                    Else
                        CMBPARTICULARS.Focus()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Module
