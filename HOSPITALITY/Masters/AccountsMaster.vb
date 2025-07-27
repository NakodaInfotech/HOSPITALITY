
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class AccountsMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master, Travel Agent
    Public edit As Boolean
    Public tempAccountsName As String
    Public TEMPGROUPNAME As String
    Public tempAccountsCode As String
    Dim tempAccountId As Integer
    Dim TEMPCONTACTROW As Integer
    Dim TEMPFAMILYROW As Integer
    Dim gridContactDoubleClick As Boolean
    Dim gridFAMILYDoubleClick As Boolean
    Dim GRIDBANKDOUBLECLICK As Boolean
    Dim TEMPBANKROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AccountsMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Dim OBJINVDTLS As New AccountsDetails
            OBJINVDTLS.MdiParent = MDIMain
            OBJINVDTLS.Show()
        End If
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_cmpname", "", " ACCOUNTSMaster ", " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_cmpname"
                cmbcmpname.DataSource = dt
                cmbcmpname.DisplayMember = "acc_cmpname"
                cmbcmpname.Text = tempAccountsName
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMPCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_CODE", "", " ACCOUNTSMaster ", " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "acc_CODE"
                CMBCODE.Text = tempAccountsCode
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        If ClientName = "FINASTA" Then
            CMBTYPE.Text = "Walk In"
            txtadd.Text = "Mumbai"
        End If

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            CMBBANKCITY.DataSource = dt
            cmbcity.DataSource = dt
            CMBBANKCITY.DisplayMember = "city_name"
            cmbcity.DisplayMember = "city_name"
            CMBBANKCITY.Text = ""
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            CMBBANKCOUNTRY.DataSource = dt
            cmbcountry.DataSource = dt
            CMBBANKCOUNTRY.DisplayMember = "country_name"
            cmbcountry.DisplayMember = "country_name"
            CMBBANKCOUNTRY.Text = ""
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If


        If CMBREFFERED.Text.Trim = "" And ClientName = "CLASSIC" Then fillname(CMBREFFERED, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        CMBREFFERED.Text = ""

        If cmbcategory.Text.Trim = "" Then FILLCATEGORY(cmbcategory)
        'If CMBRELATION.Text.Trim = "" Then FILLRELATION(CMBRELATION)

        If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME, "")
        If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
        fillDEDUCTEETYPE(CMBDEDUCTEETYPE)



    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Validated
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Details of " & CMBHOTELNAME.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(HOTELMASTER.HOTEL_ADD,'') AS [ADD], ISNULL(HOTELMASTER.HOTEL_ADD1,'') AS ADD1, ISNULL(HOTELMASTER.HOTEL_ADD2,'') AS ADD2, ISNULL(AREAMASTER.area_name,'') AS AREANAME, ISNULL(HOTELMASTER.HOTEL_STD,'') AS STD, ISNULL(CITYMASTER.city_name,'') AS CITYNAME, ISNULL(HOTELMASTER.HOTEL_ZIPCODE,'') AS ZIPCODE, ISNULL(STATEMASTER.state_name,'') AS STATENAME, ISNULL(COUNTRYMASTER.country_name,'') AS COUNTRYNAME, ISNULL(HOTELMASTER.HOTEL_ALTNO,'') AS ALTNO, ISNULL(HOTELMASTER.HOTEL_PHONENO,'') AS PHONENO, ISNULL(HOTELMASTER.HOTEL_MOBILENO,'') AS MOBILENO, ISNULL(HOTELMASTER.HOTEL_FAXNO,'') AS FAXNO, ISNULL(HOTELMASTER.HOTEL_WEBSITE,'') AS WEBSITE, ISNULL(HOTELMASTER.HOTEL_EMAILID,'') AS EMAILADD ", "", " HOTELMASTER LEFT OUTER JOIN COUNTRYMASTER ON HOTELMASTER.HOTEL_YEARID = COUNTRYMASTER.country_yearid AND HOTELMASTER.HOTEL_CMPID = COUNTRYMASTER.country_cmpid AND HOTELMASTER.HOTEL_LOCATIONID = COUNTRYMASTER.country_locationid AND HOTELMASTER.HOTEL_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON HOTELMASTER.HOTEL_YEARID = STATEMASTER.state_yearid AND HOTELMASTER.HOTEL_LOCATIONID = STATEMASTER.state_locationid AND HOTELMASTER.HOTEL_CMPID = STATEMASTER.state_cmpid AND HOTELMASTER.HOTEL_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON HOTELMASTER.HOTEL_YEARID = AREAMASTER.area_yearid AND HOTELMASTER.HOTEL_LOCATIONID = AREAMASTER.area_locationid AND HOTELMASTER.HOTEL_CMPID = AREAMASTER.area_cmpid AND HOTELMASTER.HOTEL_AREAID = AREAMASTER.area_id", " AND HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        txtadd.Text = DT.Rows(0).Item("ADD")
                        txtadd1.Text = DT.Rows(0).Item("ADD1")
                        txtadd2.Text = DT.Rows(0).Item("ADD2")
                        cmbarea.Text = DT.Rows(0).Item("AREANAME")
                        txtstd.Text = DT.Rows(0).Item("STD")
                        cmbcity.Text = DT.Rows(0).Item("CITYNAME")
                        txtzipcode.Text = DT.Rows(0).Item("ZIPCODE")
                        cmbstate.Text = DT.Rows(0).Item("STATENAME")
                        cmbcountry.Text = DT.Rows(0).Item("COUNTRYNAME")
                        txtaltno.Text = DT.Rows(0).Item("ALTNO")
                        txttel1.Text = DT.Rows(0).Item("PHONENO")
                        txtmobile.Text = DT.Rows(0).Item("MOBILENO")
                        txtfax.Text = DT.Rows(0).Item("FAXNO")
                        txtwebsite.Text = DT.Rows(0).Item("WEBSITE")
                        cmbemail.Text = DT.Rows(0).Item("EMAILADD")
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, cmbhotelcode, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMEMBERID()
        Try
            'If edit = False Then
            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_MEMBERID,1) AS MEMBERID ", "", " LEDGERS ", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " AND ACC_ID = (SELECT MAX(ACC_ID) FROM LEDGERS WHERE ACC_YEARID = " & YearId & ")")
            '    If DT.Rows.Count > 0 Then
            '        TXTMEMBERID.Text = Format(DT.Rows(0).Item("MEMBERID"), "00000000")
            '        'get DIVISION AS PREFIX
            '        DT = OBJCMN.search("ISNULL(CMP_DIVISION,'')", "", "CMPMASTER ", " AND CMP_ID = " & CmpId)
            '        TXTMEMBERID.Text = DT.Rows(0).Item(0) & "-" & TXTMEMBERID.Text
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccountsMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            FILLCMPNAME()
            FILLCMPCODE()
            cmbgroup.Text = TEMPGROUPNAME

            'GETMEMBERID()
            EXPDT.Value = DateAdd(DateInterval.Year, 5, Mydate)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                Me.Text = "Accounts Master"
                Dim OBJACC As New ClsAccountsMaster
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempAccountsName)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJACC.alParaval = ALPARAVAL
                dttable = OBJACC.GETACCOUNTS

                If dttable.Rows.Count > 0 Then
                    tempAccountId = Val(dttable.Rows(0).Item(0))
                    cmbcmpname.Text = dttable.Rows(0).Item(1).ToString
                    txtname.Text = dttable.Rows(0).Item(2).ToString
                    cmbgroup.Text = dttable.Rows(0).Item(3).ToString
                    txtopbal.Text = Val(dttable.Rows(0).Item(4).ToString)
                    cmbdrcrrs.Text = dttable.Rows(0).Item(5).ToString
                    txtadd1.Text = dttable.Rows(0).Item(6).ToString
                    txtadd2.Text = dttable.Rows(0).Item(7).ToString
                    cmbarea.Text = dttable.Rows(0).Item(8).ToString
                    cmbcity.Text = dttable.Rows(0).Item(9).ToString
                    cmbstate.Text = dttable.Rows(0).Item(10).ToString

                    txtzipcode.Text = dttable.Rows(0).Item(11).ToString

                    cmbcountry.Text = dttable.Rows(0).Item(12).ToString
                    txtstd.Text = dttable.Rows(0).Item(13).ToString

                    txtresino.Text = dttable.Rows(0).Item(14).ToString
                    txtaltno.Text = dttable.Rows(0).Item(15).ToString

                    txttel1.Text = dttable.Rows(0).Item(16).ToString
                    txtmobile.Text = dttable.Rows(0).Item(17).ToString

                    txtfax.Text = dttable.Rows(0).Item(18).ToString
                    txtwebsite.Text = dttable.Rows(0).Item(19).ToString
                    cmbemail.Text = dttable.Rows(0).Item(20).ToString
                    txtcrdays.Text = Val(dttable.Rows(0).Item(21).ToString)
                    txtcrlimit.Text = Val(dttable.Rows(0).Item(22).ToString)
                    txtpanno.Text = dttable.Rows(0).Item(23).ToString
                    txtexciseno.Text = dttable.Rows(0).Item(24).ToString
                    txtrange.Text = dttable.Rows(0).Item(25).ToString
                    txtdivision.Text = dttable.Rows(0).Item(26).ToString
                    txtcstno.Text = dttable.Rows(0).Item(27).ToString
                    txttinno.Text = dttable.Rows(0).Item(28).ToString
                    txtstno.Text = dttable.Rows(0).Item(29).ToString
                    txtvatno.Text = dttable.Rows(0).Item(30).ToString
                    TXTGSTIN.Text = dttable.Rows(0).Item(31).ToString
                    txtadd.Text = dttable.Rows(0).Item(32).ToString
                    txtshipadd.Text = dttable.Rows(0).Item(33).ToString
                    txtremarks.Text = dttable.Rows(0).Item(34).ToString

                    CMBCODE.Text = dttable.Rows(0).Item("CODE").ToString
                    tempAccountsCode = dttable.Rows(0).Item("CODE").ToString


                    If dttable.Rows(0).Item("TDSPER") > 0 Then
                        CHKTDSAPP.CheckState = CheckState.Checked
                        CMBTDSDEDUCTEDAC.Text = dttable.Rows(0).Item("TDSDEDUCTEDAC")
                        CMBTDSFORM.Text = dttable.Rows(0).Item("TDSFORM")
                        CMBDEDUCTEETYPE.Text = dttable.Rows(0).Item("DEDUCTEETYPE")
                        If dttable.Rows(0).Item("ISLOWER") = True Then
                            CMBISLOWER.Text = "Yes"
                            CMBSECTION.Enabled = True
                        Else
                            CMBISLOWER.Text = "No"
                        End If
                        CMBSECTION.Text = dttable.Rows(0).Item("SECTION")

                        TXTTDSRATE.Text = Format(Val(dttable.Rows(0).Item("TDSRATE")), "0.00")
                        TXTTDSPER.Text = Format(Val(dttable.Rows(0).Item("TDSPER")), "0.00")
                        If CMBSECTION.Text.Trim = "197" Then
                            TXTTDSRATE.Enabled = True
                        Else
                            TXTTDSRATE.Enabled = False
                        End If

                        If dttable.Rows(0).Item("SURCHARGE") = True Then
                            CMBSURCHARGE.Text = "Yes"
                        Else
                            CMBSURCHARGE.Text = "No"
                        End If
                        CMBTDSCOMPANY.Text = dttable.Rows(0).Item("TDSCOMPANY")
                        TXTLIMIT.Text = dttable.Rows(0).Item("LIMIT")
                    Else
                        CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If

                    CHKTDS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSAC"))
                    CMBNATURE.Text = dttable.Rows(0).Item("NATURE")
                    If Convert.ToDateTime(dttable.Rows(0).Item("ACC_DOB")) <> "01/01/1900" Then dtpdob.Text = Format(Convert.ToDateTime(dttable.Rows(0).Item("ACC_DOB")).Date, "dd/MM/yyyy")

                    CMBTYPE.Text = dttable.Rows(0).Item("TYPE")
                    CMBREFFERED.Text = dttable.Rows(0).Item("REFBY")
                    TXTMEMBERID.Text = dttable.Rows(0).Item("MEMBERID")
                    cmbcategory.Text = dttable.Rows(0).Item("CATEGORY")
                    EXPDT.Value = dttable.Rows(0).Item("EXPDATE")
                    TXTOPPOINTS.Text = dttable.Rows(0).Item("OPPOINTS")
                    CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))

                    If Convert.ToBoolean(dttable.Rows(0).Item("LOCKED")) = True Then cmbcmpname.Enabled = False Else cmbcmpname.Enabled = True


                    Dim DT As DataTable = objCommon.search("  ACCOUNTSMASTER_CONTACTDESC.ACC_CONTACT AS NAME, DESIGNATIONMASTER.DESIGNATION_NAME AS DESIGNATION, ACCOUNTSMASTER_CONTACTDESC.ACC_DOB AS DOB, ACCOUNTSMASTER_CONTACTDESC.ACC_MOBILE AS MOBILENO, ACCOUNTSMASTER_CONTACTDESC.ACC_EMAIL AS EMAIL ", "", " DESIGNATIONMASTER INNER JOIN ACCOUNTSMASTER_CONTACTDESC ON DESIGNATIONMASTER.DESIGNATION_ID = ACCOUNTSMASTER_CONTACTDESC.ACC_DESIGNATIONID AND DESIGNATIONMASTER.DESIGNATION_CMPID = ACCOUNTSMASTER_CONTACTDESC.ACC_CMPID AND DESIGNATIONMASTER.DESIGNATION_LOCATIONID = ACCOUNTSMASTER_CONTACTDESC.ACC_LOCATIONID AND DESIGNATIONMASTER.DESIGNATION_YEARID = ACCOUNTSMASTER_CONTACTDESC.ACC_YEARID", " AND ACC_ID = " & tempAccountId & " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            If Convert.ToDateTime(DTR("DOB")).Date <> "01/01/1900" Then
                                GRIDCONTACT.Rows.Add(DTR("NAME"), Format(DTR("DOB"), "dd/MM/yyyy"), DTR("DESIGNATION"), DTR("MOBILENO"), DTR("EMAIL"))
                            Else
                                GRIDCONTACT.Rows.Add(DTR("NAME"), "__/__/____", DTR("DESIGNATION"), DTR("MOBILENO"), DTR("EMAIL"))
                            End If
                        Next
                    End If


                    DT = objCommon.search("  ACCOUNTSMASTER_BANKDETAILS.ACC_ACNAME AS ACNAME, ACCOUNTSMASTER_BANKDETAILS.ACC_ACNO AS ACNO, ACCOUNTSMASTER_BANKDETAILS.ACC_ACTYPE AS ACTYPE, ACCOUNTSMASTER_BANKDETAILS.ACC_BANKNAME AS BANKNAME, ACCOUNTSMASTER_BANKDETAILS.ACC_BRANCH AS BRANCH, ACCOUNTSMASTER_BANKDETAILS.ACC_IFSC AS IFSC, ACCOUNTSMASTER_BANKDETAILS.ACC_SWIFT AS SWIFT, CITYMASTER.city_name AS CITY, ACCOUNTSMASTER_BANKDETAILS.ACC_PINCODE AS PINCODE, COUNTRYMASTER.country_name AS COUNTRY ", "", " ACCOUNTSMASTER INNER JOIN ACCOUNTSMASTER_BANKDETAILS ON ACCOUNTSMASTER.Acc_id = ACCOUNTSMASTER_BANKDETAILS.ACC_ID AND ACCOUNTSMASTER.Acc_cmpid = ACCOUNTSMASTER_BANKDETAILS.ACC_CMPID AND ACCOUNTSMASTER.Acc_locationid = ACCOUNTSMASTER_BANKDETAILS.ACC_LOCATIONID AND ACCOUNTSMASTER.Acc_yearid = ACCOUNTSMASTER_BANKDETAILS.ACC_YEARID LEFT OUTER JOIN CITYMASTER ON ACCOUNTSMASTER_BANKDETAILS.ACC_CITYID = CITYMASTER.city_id LEFT OUTER JOIN COUNTRYMASTER ON ACCOUNTSMASTER_BANKDETAILS.ACC_COUNTRYID = COUNTRYMASTER.country_id ", " AND ACCOUNTSMASTER.ACC_ID = " & tempAccountId & " AND ACCOUNTSMASTER.ACC_CMPID = " & CmpId & " AND ACCOUNTSMASTER.ACC_LOCATIONID = " & Locationid & " AND ACCOUNTSMASTER.ACC_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDBANK.Rows.Add(DTR("ACNAME"), DTR("ACNO"), DTR("ACTYPE"), DTR("BANKNAME"), DTR("BRANCH"), DTR("IFSC"), DTR("SWIFT"), DTR("CITY"), DTR("PINCODE"), DTR("COUNTRY"))
                        Next
                    End If


                    DT = objCommon.search(" ISNULL(ACCOUNTSMASTER_FAMILYDETAILS.ACC_NAME,'') AS NAME, ACCOUNTSMASTER_FAMILYDETAILS.ACC_DOB AS DOB, ISNULL(ACCOUNTSMASTER_FAMILYDETAILS.ACC_AGE,0) AS AGE, ISNULL(RELATION_NAME,'') AS RELATION, ISNULL(ACCOUNTSMASTER_FAMILYDETAILS.ACC_MOBILENO,'') AS MOBILENO, ISNULL(ACCOUNTSMASTER_FAMILYDETAILS.ACC_EMAIL,'') AS EMAILID, ISNULL(ACCOUNTSMASTER_FAMILYDETAILS.ACC_SEX,'M') AS SEX ", "", " ACCOUNTSMASTER INNER JOIN ACCOUNTSMASTER_FAMILYDETAILS ON ACCOUNTSMASTER.Acc_id = ACCOUNTSMASTER_FAMILYDETAILS.ACC_ID AND ACCOUNTSMASTER.Acc_cmpid = ACCOUNTSMASTER_FAMILYDETAILS.ACC_CMPID AND ACCOUNTSMASTER.Acc_locationid = ACCOUNTSMASTER_FAMILYDETAILS.ACC_LOCATIONID AND ACCOUNTSMASTER.Acc_yearid = ACCOUNTSMASTER_FAMILYDETAILS.ACC_YEARID LEFT OUTER JOIN RELATIONMASTER ON ACCOUNTSMASTER_FAMILYDETAILS.ACC_RELATIONID = RELATIONMASTER.RELATION_id AND ACCOUNTSMASTER_FAMILYDETAILS.ACC_CMPID = RELATIONMASTER.RELATION_CMPid AND ACCOUNTSMASTER_FAMILYDETAILS.ACC_LOCATIONID = RELATIONMASTER.RELATION_LOCATIONID AND ACCOUNTSMASTER_FAMILYDETAILS.ACC_YEARID = RELATIONMASTER.RELATION_YEARid ", " AND ACCOUNTSMASTER.ACC_ID = " & tempAccountId & " AND ACCOUNTSMASTER.ACC_CMPID = " & CmpId & " AND ACCOUNTSMASTER.ACC_LOCATIONID = " & Locationid & " AND ACCOUNTSMASTER.ACC_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDFAMILY.Rows.Add(DTR("NAME"), Format(Convert.ToDateTime(DTR("DOB")).Date, "dd/MM/yyyy"), DTR("AGE"), DTR("RELATION"), DTR("MOBILENO"), DTR("EMAILID"), DTR("SEX"))
                        Next
                    End If

                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub add()
        txtadd.Clear()
        If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
        If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

        If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

        txtadd.Text = txtadd.Text & "" & cmbcity.Text.Trim

        If txtzipcode.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & vbNewLine
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbstate.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim
        Else
            txtadd.Text = txtadd.Text & vbNewLine

        End If

        If cmbcountry.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'Ep.Clear()
            'If Not DELETEERRORVALID() Then
            '    Exit Sub
            'End If
            If CHKCOMMON.CheckState = CheckState.Unchecked Then
                If edit = False Then SAVEUPDATE(CmpId, YearId, 0) Else SAVEUPDATE(CmpId, YearId, tempAccountId)
            Else
                Dim OBJCMN As New ClsCommon
                Dim DTCMP As DataTable = OBJCMN.search("YEAR_CMPID AS CMPID, YEAR_ID AS YEARID ", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(Convert.ToDateTime(AccFrom.Date), "MM/dd/yyyy") & "' ORDER BY YEAR_ID")
                For Each DTROW As DataRow In DTCMP.Rows
                    'BEFORE SAVING WE WILL CHECK WHETHER CMPNAME OR GROUPNAME AND STATE IS PRESENT IN THAY UYEAR OR NOT
                    'IF NOT THEN GOTONEXTLINE
                    'IF CMPNAME IS ALREADY PRESENT THEN SKIP
                    Dim DTTEMP As DataTable
                    Dim OBJYEAR As New ClsYearMaster

                    DTTEMP = OBJCMN.search("GROUP_ID AS GROUPID", "", "GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then GoTo NEXTLINE



                    'CHECK AREA
                    DTTEMP = OBJCMN.search("AREA_ID AS AREAID", "", "AREAMASTER ", " AND AREA_NAME = '" & cmbarea.Text.Trim & "' AND AREA_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        OBJYEAR.savearea(cmbarea.Text.Trim, DTROW("CMPID"), 0, Userid, DTROW("YEARID"))
                    End If


                    'CHECK CITY
                    DTTEMP = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", " AND CITY_NAME = '" & cmbcity.Text.Trim & "' AND CITY_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        OBJYEAR.savecity(cmbcity.Text.Trim, DTROW("CMPID"), 0, Userid, DTROW("YEARID"))
                    End If


                    'CHECK STATE
                    DTTEMP = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", " AND STATE_NAME = '" & cmbstate.Text.Trim & "' AND STATE_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        OBJYEAR.savestate(cmbstate.Text.Trim, DTROW("CMPID"), 0, Userid, DTROW("YEARID"))
                    End If


                    'CHECK COUNTRY
                    DTTEMP = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", " AND COUNTRY_NAME = '" & cmbcountry.Text.Trim & "' AND COUNTRY_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        OBJYEAR.savecountry(cmbcountry.Text.Trim, DTROW("CMPID"), 0, Userid, DTROW("YEARID"))
                    End If


                    'CHECK CATEGORY, IF NOT PRESENT THEN ADD NEW
                    DTTEMP = OBJCMN.search("CATEGORY_id", "", "CATEGORYMaster", " and CATEGORY_NAME = '" & cmbcategory.Text.Trim & "' and CATEGORY_YEARid = " & Val(DTROW("YearId")))
                    If DTTEMP.Rows.Count = 0 Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(cmbcategory.Text.Trim)
                        alParaval.Add("")   'REMARKS
                        alParaval.Add(DTROW("CMPID"))
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(DTROW("YearId"))
                        alParaval.Add(0)
                        Dim objclsCATEGORY As New ClsCustomerCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.SAVE()
                    End If


                    'CHECK DESIGNATION IN GRID LOOP
                    For Each ROW As DataGridViewRow In GRIDCONTACT.Rows
                        DTTEMP = OBJCMN.search("DESIGNATION_id", "", "DESIGNATIONMaster", " and DESIGNATION_NAME = '" & ROW.Cells(GDESIGNATION.Index).Value & "' and DESIGNATION_YEARid = " & Val(DTROW("YearId")))
                        If DTTEMP.Rows.Count = 0 Then
                            Dim alParaval As New ArrayList
                            alParaval.Add(ROW.Cells(GDESIGNATION.Index).Value)
                            alParaval.Add("")   'REMARKS
                            alParaval.Add(DTROW("CMPID"))
                            alParaval.Add(0)
                            alParaval.Add(Userid)
                            alParaval.Add(DTROW("YearId"))
                            alParaval.Add(0)
                            Dim objclsDESIGNATION As New ClsDesignationMaster
                            objclsDESIGNATION.alParaval = alParaval
                            Dim IntResult As Integer = objclsDESIGNATION.SAVE()
                        End If
                    Next



                    'CHECK RELATION IN GRID LOOP
                    For Each ROW As DataGridViewRow In GRIDFAMILY.Rows
                        DTTEMP = OBJCMN.search("RELATION_id", "", "RELATIONMaster", " and RELATION_NAME = '" & ROW.Cells(GFRELATION.Index).Value & "' and RELATION_YEARid = " & Val(DTROW("YearId")))
                        If DTTEMP.Rows.Count = 0 Then
                            Dim alParaval As New ArrayList
                            alParaval.Add(ROW.Cells(GFRELATION.Index).Value)
                            alParaval.Add("")   'REMARKS
                            alParaval.Add(DTROW("CMPID"))
                            alParaval.Add(0)
                            alParaval.Add(Userid)
                            alParaval.Add(DTROW("YearId"))
                            alParaval.Add(0)
                            Dim objclsRELATION As New ClsRelationMaster
                            objclsRELATION.alParaval = alParaval
                            Dim IntResult As Integer = objclsRELATION.SAVE()
                        End If
                    Next



                    If edit = False Then
                        If YearId <> DTROW("YEARID") Then
                            DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                            If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE
                        End If
                        SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), 0)
                    Else

                        'DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_ID <> " & tempAccountId & " AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        'If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE

                        'FIRST GET THE ACCOUNTID FROM YEARID AND THEN PASS IT IN THE UPDATE QUERY
                        DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & tempAccountsName & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), Val(DTTEMP.Rows(0).Item("ACCID")))
                    End If
NEXTLINE:
                Next
            End If

            If edit = False Then MsgBox("Details Added") Else MsgBox("Details Updated")
            clear()
            tempAccountsName = ""
            edit = False
            cmbcmpname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPDATE(ByVal TCMPID As Integer, ByVal TYEARID As Integer, ByVal TACCID As Integer)
        Try

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(cmbcmpname.Text.Trim)
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbgroup.Text.Trim)
            alParaval.Add(txtopbal.Text.Trim)
            alParaval.Add(cmbdrcrrs.Text.Trim)
            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtcrdays.Text.Trim)
            alParaval.Add(txtcrlimit.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(txtpanno.Text.Trim)
            alParaval.Add(txtexciseno.Text.Trim)
            alParaval.Add(txtrange.Text.Trim)
            alParaval.Add(txtdivision.Text.Trim)
            alParaval.Add(txtcstno.Text.Trim)
            alParaval.Add(txttinno.Text.Trim)
            alParaval.Add(txtstno.Text.Trim)
            alParaval.Add(txtvatno.Text.Trim)
            alParaval.Add(TXTGSTIN.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtshipadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TCMPID)
            alParaval.Add(0)
            alParaval.Add(Userid)
            alParaval.Add(TYEARID)
            alParaval.Add(0)
            alParaval.Add(CMBCODE.Text.Trim)


            'TDS
            '*******************************
            alParaval.Add(CHKTDSAPP.CheckState)
            alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)

            If CMBISLOWER.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSECTION.Text.Trim)
            alParaval.Add(Val(TXTTDSRATE.Text.Trim))

            If CMBSURCHARGE.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Val(TXTLIMIT.Text.Trim))
            '*******************************

            alParaval.Add(CHKTDS.CheckState)
            alParaval.Add(CMBNATURE.Text.Trim)


            ''NEWLY ADDED FIELDS*******************(AS PER CLASSIC REQUIREMENTS)
            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(CMBREFFERED.Text.Trim)
            alParaval.Add(TXTMEMBERID.Text.Trim)
            alParaval.Add(cmbcategory.Text.Trim)
            alParaval.Add(EXPDT.Value.Date)
            alParaval.Add(TXTOPPOINTS.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)

            'CONTACT DETAILS
            '********************************
            Dim CNAME As String = ""
            Dim CDOB As String = ""
            Dim DESIGNATION As String = ""
            Dim CMOB As String = ""
            Dim CEMAIL As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONTACT.Rows
                If row.Cells(GNAME.Index).Value <> Nothing Then
                    If CNAME = "" Then

                        CNAME = row.Cells(GNAME.Index).Value.ToString
                        If row.Cells(GDOB.Index).Value <> "__/__/____" Then
                            CDOB = Format(Convert.ToDateTime(row.Cells(GDOB.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            CDOB = ""
                        End If
                        DESIGNATION = row.Cells(GDESIGNATION.Index).Value
                        CMOB = row.Cells(GMOBILENO.Index).Value.ToString
                        CEMAIL = row.Cells(GEMAIL.Index).Value

                    Else

                        CNAME = CNAME & "|" & row.Cells(GNAME.Index).Value.ToString
                        If row.Cells(GDOB.Index).Value <> "__/__/____" Then
                            CDOB = CDOB & "|" & Format(Convert.ToDateTime(row.Cells(GDOB.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            CDOB = CDOB & "|"
                        End If
                        DESIGNATION = DESIGNATION & "|" & row.Cells(GDESIGNATION.Index).Value
                        CMOB = CMOB & "|" & row.Cells(GMOBILENO.Index).Value.ToString
                        CEMAIL = CEMAIL & "|" & row.Cells(GEMAIL.Index).Value

                    End If
                End If
            Next

            alParaval.Add(CNAME)
            alParaval.Add(CDOB)
            alParaval.Add(DESIGNATION)
            alParaval.Add(CMOB)
            alParaval.Add(CEMAIL)
            '********************************


            'BANK DETAILS
            '********************************
            Dim ACNAME As String = ""
            Dim ACNO As String = ""
            Dim ACTYPE As String = ""
            Dim BANKNAME As String = ""
            Dim BRANCH As String = ""
            Dim IFSC As String = ""
            Dim SWIFT As String = ""
            Dim CITY As String = ""
            Dim PINCODE As String = ""
            Dim COUNTRY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBANK.Rows
                If row.Cells(GNAME.Index).Value <> Nothing Then
                    If ACNAME = "" Then

                        ACNAME = row.Cells(GACNAME.Index).Value.ToString
                        ACNO = row.Cells(GACNO.Index).Value.ToString
                        ACTYPE = row.Cells(GACTYPE.Index).Value.ToString
                        BANKNAME = row.Cells(GBANKNAME.Index).Value
                        BRANCH = row.Cells(GBRANCH.Index).Value.ToString
                        IFSC = row.Cells(GIFSC.Index).Value
                        SWIFT = row.Cells(GSWIFT.Index).Value
                        CITY = row.Cells(GCITY.Index).Value
                        PINCODE = row.Cells(GPINCODE.Index).Value
                        COUNTRY = row.Cells(GCOUNTRY.Index).Value

                    Else

                        ACNAME = ACNAME & "|" & row.Cells(GACNAME.Index).Value.ToString
                        ACNO = ACNO & "|" & row.Cells(GACNO.Index).Value.ToString
                        ACTYPE = ACTYPE & "|" & row.Cells(GACTYPE.Index).Value.ToString
                        BANKNAME = BANKNAME & "|" & row.Cells(GBANKNAME.Index).Value
                        BRANCH = BRANCH & "|" & row.Cells(GBRANCH.Index).Value.ToString
                        IFSC = IFSC & "|" & row.Cells(GIFSC.Index).Value
                        SWIFT = SWIFT & "|" & row.Cells(GSWIFT.Index).Value
                        CITY = CITY & "|" & row.Cells(GCITY.Index).Value
                        PINCODE = PINCODE & "|" & row.Cells(GPINCODE.Index).Value
                        COUNTRY = COUNTRY & "|" & row.Cells(GCOUNTRY.Index).Value

                    End If
                End If
            Next

            alParaval.Add(ACNAME)
            alParaval.Add(ACNO)
            alParaval.Add(ACTYPE)
            alParaval.Add(BANKNAME)
            alParaval.Add(BRANCH)
            alParaval.Add(IFSC)
            alParaval.Add(SWIFT)
            alParaval.Add(CITY)
            alParaval.Add(PINCODE)
            alParaval.Add(COUNTRY)
            '********************************


            'FAMILY DETAILS
            '********************************
            Dim FNAME As String = ""
            Dim FDOB As String = ""
            Dim FAGE As String = ""
            Dim FRELATION As String = ""
            Dim FMOBILE As String = ""
            Dim FEMAIL As String = ""
            Dim FSEX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFAMILY.Rows
                If row.Cells(GFNAME.Index).Value <> Nothing Then
                    If FNAME = "" Then

                        FNAME = row.Cells(GFNAME.Index).Value.ToString
                        FDOB = Format(Convert.ToDateTime(row.Cells(GFDOB.Index).Value).Date, "MM/dd/yyyy")
                        FAGE = row.Cells(GFAGE.Index).Value.ToString
                        FRELATION = row.Cells(GFRELATION.Index).Value.ToString
                        FMOBILE = row.Cells(GFMob.Index).Value.ToString
                        FEMAIL = row.Cells(GFEmailid.Index).Value.ToString
                        FSEX = row.Cells(GFSEX.Index).Value.ToString
                    Else

                        FNAME = FNAME & "|" & row.Cells(GFNAME.Index).Value.ToString
                        FDOB = FDOB & "|" & Format(Convert.ToDateTime(row.Cells(GFDOB.Index).Value).Date, "MM/dd/yyyy")
                        FAGE = FAGE & "|" & row.Cells(GFAGE.Index).Value.ToString
                        FRELATION = FRELATION & "|" & row.Cells(GFRELATION.Index).Value.ToString
                        FMOBILE = FMOBILE & "|" & row.Cells(GFMob.Index).Value.ToString
                        FEMAIL = FEMAIL & "|" & row.Cells(GFEmailid.Index).Value.ToString
                        FSEX = FSEX & "|" & row.Cells(GFSEX.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(FNAME)
            alParaval.Add(FDOB)
            alParaval.Add(FAGE)
            alParaval.Add(FRELATION)
            alParaval.Add(FMOBILE)
            alParaval.Add(FEMAIL)
            alParaval.Add(FSEX)

            '********************************

            If dtpdob.Text <> "__/__/____" Then
                alParaval.Add(Format(Convert.ToDateTime(dtpdob.Text), "MM/dd/yyyy"))
            Else
                alParaval.Add("")
            End If


            alParaval.Add(CMBTDSDEDUCTEDAC.Text.Trim)
            alParaval.Add(CMBTDSFORM.Text.Trim)
            alParaval.Add(Val(TXTTDSPER.Text.Trim))
            alParaval.Add(CMBTDSCOMPANY.Text.Trim)


            Dim objAccountsMaster As New ClsAccountsMaster
            objAccountsMaster.alParaval = alParaval
            objAccountsMaster.frmstring = frmstring

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAccountsMaster.save()
                'MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TACCID)
                IntResult = objAccountsMaster.update()
                'MsgBox("Details Updated")
            End If

            'clear()
            'cmbcmpname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then
                Throw ex
            End If
        End Try
    End Sub

    Sub clear()

        'TDS
        CHKTDS.CheckState = CheckState.Unchecked
        CMBNATURE.Text = ""
        CMBTDSDEDUCTEDAC.Text = ""
        TXTTDSPER.Clear()
        CMBTDSCOMPANY.Text = ""

        CHKTDSAPP.CheckState = CheckState.Unchecked
        GROUPTDS.Enabled = False
        CMBDEDUCTEETYPE.Text = ""
        CMBISLOWER.SelectedIndex = 0
        CMBSECTION.SelectedIndex = 0
        TXTTDSRATE.Clear()
        CMBSURCHARGE.SelectedIndex = 0
        TXTTDSRATE.Enabled = False
        CMBSECTION.Enabled = False

        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtaltno.Clear()
        cmbcmpname.Text = ""
        cmbcmpname.Enabled = True
        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtcstno.Clear()
        txtdivision.Clear()
        cmbemail.Text = ""
        txtexciseno.Clear()
        txtfax.Clear()
        TXTGSTIN.Clear()
        txtmobile.Clear()
        txtname.Clear()
        txtopbal.Clear()
        txtpanno.Clear()
        txtrange.Clear()
        txtremarks.Clear()
        txtresino.Clear()
        txtshipadd.Clear()
        txtstd.Clear()
        txtstno.Clear()
        txttel1.Clear()
        txttinno.Clear()
        txtvatno.Clear()
        txtwebsite.Clear()
        txtzipcode.Clear()
        cmbarea.Text = ""
        cmbcity.Text = ""
        cmbcountry.Text = ""
        cmbdrcrrs.Text = ""
        cmbgroup.Text = ""
        cmbstate.Text = ""
        CMBCODE.Text = ""
        tempAccountsName = ""
        cmbcmpname.Text = ""
        edit = False
        CMBHOTELNAME.Text = ""
        CMBREFFERED.Text = ""
        TXTMEMBERID.Clear()
        cmbcategory.Text = ""
        TXTOPPOINTS.Clear()

        EXPDT.Value = Mydate
        dtpdob.Clear()

        GRIDCONTACT.RowCount = 0
        TXTCNAME.Clear()
        DTPCDOB.Text = ""
        CMBDESIGNATION.Text = ""
        TXTCMOB.Clear()
        TXTCEMAIL.Clear()

        CHKBLOCKED.CheckState = CheckState.Unchecked

        TXTACNAME.Clear()
        TXTACNO.Clear()
        CMBACTYPE.SelectedIndex = 0
        TXTBANKNAME.Clear()
        TXTBRANCH.Clear()
        TXTIFSC.Clear()
        TXTSWIFT.Clear()
        CMBBANKCITY.Text = ""
        TXTBANKPIN.Clear()
        CMBBANKCOUNTRY.Text = ""
        GRIDBANK.RowCount = 0


        TXTFAMILYNAME.Clear()
        FAMILYDOB.Clear()
        TXTFAMILYAGE.Clear()
        CMBRELATION.Text = ""
        TXTMOBILENO.Clear()
        TXTEMAILID.Clear()
        GRIDFAMILY.RowCount = 0

        If frmstring = "CUSTOMER" Then
            Me.Text = "Customer Master"
            cmbgroup.Text = "Sundry Debtors"
        ElseIf frmstring = "VENDOR" Then
            Me.Text = "Supplier Master"
            cmbgroup.Text = "Sundry Creditors"
        ElseIf frmstring = "ACCOUNTS" Then
            Me.Text = "Accounts Master"
        ElseIf frmstring = "EMPLOYEE" Then
            Me.Text = "Employee Master"
        End If
        GETMEMBERID()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbcmpname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcmpname, "Fill Company Name")
            bln = False
        End If


        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group Name")
            bln = False
        End If



        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbcmpname, "Name Already Exists")
            bln = False
        End If

        If UserName <> "Admin" Then
            If txtpanno.Text.Trim <> "" Then
                If txtpanno.Text.Trim.Length <> 10 Then
                    Ep.SetError(txtpanno, "Insert Proper PAN No")
                    bln = False
                Else
                    'validating PAN NO
                    For x = 1 To Len(txtpanno.Text.Trim)
                        If x <= 5 Or x = 10 Then
                            If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If
                        Else
                            If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If
                        End If
                    Next x
                End If
            End If
        End If

        If CHKTDS.CheckState = CheckState.Unchecked Then CMBNATURE.Text = ""

        If CHKTDS.CheckState = CheckState.Checked And CMBNATURE.Text.Trim = "" Then
            Ep.SetError(CMBNATURE, "Select Nature Of Payment")
            bln = False
        End If

        If cmbcmpname.Text = CMBREFFERED.Text Then
            Ep.SetError(CMBREFFERED, "Same Name Refference Not Allowed")
            bln = False
        End If

        If CMBCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCODE, "Fill Company Code")
            bln = False
        End If

        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group")
            bln = False
        End If



        'IF GROUPNAME = CREDITORS OR DEBTORS THEN ONLY
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("GROUP_SECONDARY AS GROUPNAME", "", " GROUPMASTER", " AND GROUP_NAME ='" & cmbgroup.Text.Trim & "' AND GROUP_CMPID =  " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then

            If DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors" Then
                If txtadd.Text.Trim.Length = 0 Then
                    Ep.SetError(txtadd, "Fill Address")
                    bln = False
                End If

                If ClientName = "TRAVELBRIDGE" And DT.Rows(0).Item(0) = "Sundry Debtors" And cmbcategory.Text.Trim = "" Then
                    Ep.SetError(cmbcategory, "Fill Company Group")
                    bln = False
                End If

                If ClientName = "CLASSIC" Then
                    If txtmobile.Text.Trim.Length = 0 Then
                        Ep.SetError(txtmobile, "Enter Contact No.")
                        bln = False
                    End If
                End If
            End If

            If DT.Rows(0).Item("GROUPNAME") = "Sundry Debtors" Then
                If CMBTYPE.Text.Trim.Length = 0 Then
                    Ep.SetError(CMBTYPE, "Select Type")
                    bln = False
                End If


            End If


            'AS PER ASHOK SIR'S REQUIREMENT
            If ClientName = "CLASSIC" And ((DT.Rows(0).Item("GROUPNAME") = "Sundry Debtors" Or DT.Rows(0).Item("GROUPNAME") = "Sundry Creditors")) Then

                If DT.Rows(0).Item("GROUPNAME") = "Sundry Debtors" Then
                    GETMEMBERID()
                    If CMBTYPE.Text.Trim = "" Then
                        Ep.SetError(CMBTYPE, "Select Account Type")
                        bln = False
                    ElseIf CMBTYPE.Text.Trim = "Hotel" Then
                        Ep.SetError(CMBTYPE, "Select Proper Account Type, only Walk-In or Agent Allowed")
                        bln = False
                    End If
                ElseIf DT.Rows(0).Item("GROUPNAME") = "Sundry Creditors" Then
                    If CMBTYPE.Text.Trim = "" Then
                        Ep.SetError(CMBTYPE, "Select Account Type")
                        bln = False
                    ElseIf CMBTYPE.Text.Trim = "Walk In" Then
                        Ep.SetError(CMBTYPE, "Select Proper Account Type, only Hotel or Agent Allowed")
                        bln = False
                    End If
                End If

                If cmbemail.Text.Trim.Length = 0 Then
                    Ep.SetError(cmbemail, "Enter Email Address")
                    bln = False
                End If

                If txtadd1.Text.Trim.Length = 0 Then
                    Ep.SetError(txtadd1, "Enter Address")
                    bln = False
                End If

                If cmbcity.Text.Trim.Length = 0 Then
                    Ep.SetError(cmbcity, "Enter City")
                    bln = False
                End If

                If cmbstate.Text.Trim.Length = 0 Then
                    Ep.SetError(cmbstate, "Enter State")
                    bln = False
                End If

                If txtmobile.Text.Trim.Length < 8 Then
                    Ep.SetError(txtmobile, "Enter Proper Contact No.")
                    bln = False
                End If
            End If
        End If

        If cmbstate.Text.Trim.Length = 0 Then
            Ep.SetError(cmbstate, "Select State")
            bln = False
        End If

        If txtpanno.Text.Trim <> "" Then

            If CMBDEDUCTEETYPE.Text.Trim = "" Then
                Ep.SetError(txtpanno, "Select Company Type")
                bln = False
            End If

            If txtpanno.Text.Trim.Length <> 10 Then
                Ep.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            Else
                'validating PAN NO
                For x = 1 To Len(txtpanno.Text.Trim)
                    If x <= 5 Or x = 10 Then
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    Else
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    End If
                    'CHECKING 4TH ALPHABET WITH DEDUCTEETYPE
                    'THIS CODE IS COMMENTED BY GULKIT, NO NEED OF VALIDATION
                    'If x = 4 Then
                    '    If CMBDEDUCTEETYPE.Text.Trim = "Individual" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "P" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text.Trim = "Firm" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "F" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Company" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "C" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "HUF" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "H" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Association of Persons" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "A" And txtpanno.Text.Substring(x - 1, 1) <> "T" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Local Authority" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "L" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Artificial Juridical Person" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "J" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    ElseIf CMBDEDUCTEETYPE.Text = "Government" Then
                    '        If txtpanno.Text.Substring(x - 1, 1) <> "G" Then
                    '            Ep.SetError(txtpanno, "Insert Proper PAN No")
                    '            bln = False
                    '        End If
                    '    End If
                    'End If
                Next x
            End If
        End If


        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If cmbstate.Text.Trim <> "" And TXTGSTIN.Text.Trim <> "" Then
            'Dim OBJCMN As New ClsCommon
            DT = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & cmbstate.Text.Trim & "' AND state_yearid = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTIN.Text.Substring(0, 2) Then
                Ep.SetError(TXTGSTIN, "State Code does not match with GST No")
                bln = False
            End If
        End If


        If TXTGSTIN.Text.Trim.Length > 0 Then
            If txtpanno.Text.Trim = "" Then
                Ep.SetError(txtpanno, "Enter Pan No")
                bln = False
            End If

            If txtpanno.Text.Trim.Length <> 10 Then
                Ep.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            End If

            'CHECKING 2ND TO 11TH ALPHABETS WITH PANNO
            If txtpanno.Text.Trim <> TXTGSTIN.Text.Substring(2, 10) Then
                Ep.SetError(txtpanno, "Enter Proper PAN Details")
                bln = False
            End If

            If TXTGSTIN.Text.Trim.Length <> 15 Then
                Ep.SetError(TXTGSTIN, "Enter Proper GST No")
                bln = False
            End If
        End If



        'Code for checking ...User should not allow to edit Build In Ledger which we were Create through Store Procedure
        'If cmbcmpname.Text.Trim = "Opening A/C" Or cmbcmpname.Text.Trim = "Profit & Loss A/C" Then
        '    Ep.SetError(cmbcmpname, "Build In Ledger Can't edit")
        '    bln = False
        'End If

        If UserName <> "Admin" Then
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "S.T. 1.03%"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "PACKAGE PURCHASE"
                    bln_4_case = False
                Case "INTERNATIONAL PURCHASE"
                    bln_4_case = False
                Case "AIRLINE PURCHASE"
                    bln_4_case = False
                Case "TRANSFER PURCHASE"
                    bln_4_case = False
                Case "BRANCH TRANSFER"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "PACKAGE SALE"
                    bln_4_case = False
                Case "Sale Book Return"
                    bln_4_case = False
                Case "Pur Book Return"
                    bln_4_case = False
                Case "INTERNATIONAL SALE"
                    bln_4_case = False
                Case "AIRLINE SALE"
                    bln_4_case = False
                Case "TRANSFER SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Agent Commission"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
                Case "Direct Payment"
                    bln_4_case = False
                Case "Pur Disc"
                    bln_4_case = False
                Case "Pur Comm"
                    bln_4_case = False
                Case "Pur Tax"
                    bln_4_case = False
                Case "Pur Add-Tax"
                    bln_4_case = False
                Case "Pur Other Chgs"
                    bln_4_case = False
                Case "Pur Round Off"
                    bln_4_case = False

            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot edit")
                bln = False
            End If
        End If



        Return bln
    End Function

    Private Sub cmbgroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.GotFocus
        Try
            If cmbgroup.Text.Trim = "" Then FILLGROUP(cmbgroup, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.GotFocus
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(cmbcountry.Text)
                                cmbcountry.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo Line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub txtcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try

    '        pcase(cmbcmpname)
    '        If (edit = False) Or (edit = True And tempAccountsName <> cmbcmpname.Text.Trim) Then
    '            'for search
    '            Dim objclscommon As New ClsCommonMaster
    '            Dim dt As New DataTable
    '            If frmstring = "CUSTOMER" Then
    '                dt = objclscommon.search("customer_cmpname", "", "CustomerMaster", " and customer_cmpname = '" & cmbcmpname.Text.Trim & "' and customer_cmpid =" & CmpId & " and customer_Locationid =" & Locationid & " and customer_Yearid =" & YearId)
    '            ElseIf frmstring = "VENDOR" Then
    '                dt = objclscommon.search("Vendor_cmpname", "", "VendorMaster", " and Vendor_cmpname = '" & cmbcmpname.Text.Trim & "' and Vendor_cmpid = " & CmpId & " and Vendor_Locationid = " & Locationid & " and Vendor_Yearid = " & YearId)
    '            ElseIf frmstring = "ACCOUNTS" Then
    '                dt = objclscommon.search("acc_cmpname", "", "AccountsMaster", " and acc_cmpname = '" & cmbcmpname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_Locationid = " & Locationid & " and acc_Yearid = " & YearId)
    '            ElseIf frmstring = "EMPLOYEE" Then
    '                dt = objclscommon.search("Emp_cmpname", "", "EmployeeMaster", " and Emp_cmpname = '" & cmbcmpname.Text.Trim & "' and Emp_cmpid = " & CmpId & " and Emp_Locationid = " & Locationid & " and Emp_Yearid = " & YearId)
    '            End If
    '            If dt.Rows.Count > 0 Then
    '                MsgBox("Company Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
    '                e.Cancel = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbarea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.GotFocus
        Try
            If cmbarea.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    cmbarea.DataSource = dt
                    cmbarea.DisplayMember = "area_name"
                    cmbarea.Text = ""
                End If
                cmbarea.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then
                pcase(cmbarea)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbarea.Text.Trim
                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbarea.Text = a
                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbarea.DataSource
                        If cmbarea.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbarea.Text)
                                cmbarea.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then GROUPVALIDATE(cmbgroup, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        pcase(txtname)
    End Sub

    Private Sub txtadd1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd1.Validating
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd2.Validating
        pcase(txtadd2)
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress
        numdotkeypress(e, txtcrdays, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdotkeypress(e, txtcrlimit, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numdotkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numdotkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub cmbcmpname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcmpname.Enter
        Try
            If cmbcmpname.Text.Trim = "" Then
                FILLCMPNAME()
                cmbcmpname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcmpname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcmpname.Validating
        Try
            If tempAccountsName = "Cash In Hand" And LCase(cmbcmpname.Text.Trim) <> LCase(tempAccountsName) Then
                MsgBox("Name Cannot Be Changed", MsgBoxStyle.Critical)
                e.Cancel = True
                Exit Sub
            End If
            If Not CHECKDUPLICATE() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If cmbcmpname.Text.Trim <> "" Then
                pcase(cmbcmpname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then
                    dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False

                    'ALLOW USER TO CHANGE OPENING ONLY
                    'Case "S.T. 1.24%"
                    '    bln_4_case = False
                    'Case "S.T. 3.09%"
                    '    bln_4_case = False
                    'Case "S.T. 0.65%"
                    '    bln_4_case = False
                    'Case "S.T. 1.236%"
                    '    bln_4_case = False
                    'Case "Cash In Hand"
                    '    bln_4_case = False
                    'Case "Petty Cash"
                    '    bln_4_case = False

                Case "PURCHASE"
                    bln_4_case = False
                Case "PACKAGE PURCHASE"
                    bln_4_case = False
                Case "INTERNATIONAL PURCHASE"
                    bln_4_case = False
                Case "AIRLINE PURCHASE"
                    bln_4_case = False
                Case "TRANSFER PURCHASE"
                    bln_4_case = False
                Case "BRANCH TRANSFER"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "PACKAGE SALE"
                    bln_4_case = False
                Case "INTERNATIONAL SALE"
                    bln_4_case = False
                Case "Sale Book Return"
                    bln_4_case = False
                Case "Pur Book Return"
                    bln_4_case = False
                Case "AIRLINE SALE"
                    bln_4_case = False
                Case "TRANSFER SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Add Discount Given"
                    bln_4_case = False
                Case "Add Discount Recd"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Agent Commission"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Profit & Loss (Opening)"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
                Case "Direct Payment"
                    bln_4_case = False
                Case "Pur Disc"
                    bln_4_case = False
                Case "Pur Comm"
                    bln_4_case = False
                Case "Pur Tax"
                    bln_4_case = False
                Case "Pur Add-Tax"
                    bln_4_case = False
                Case "Pur Other Chgs"
                    bln_4_case = False
                Case "Pur Round Off"
                    bln_4_case = False

            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot Delete Or Modify")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Ledger?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Ep.Clear()
                If Not DELETEERRORVALID() Then
                    Exit Sub
                End If

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempAccountsName)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)



                Dim OBJACC As New ClsAccountsMaster
                OBJACC.alParaval = ALPARAVAL
                OBJACC.frmstring = frmstring
                Dim DT As DataTable = OBJACC.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                FILLCMPCODE()
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBCODE.Text) <> LCase(tempAccountsCode)) Then
                    dt = objclscommon.search("ACC_CODE", "", " LEDGERS", " AND ACC_CODE = '" & CMBCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Code Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkcopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcopy.CheckedChanged
        Try
            txtadd.Clear()
            If chkcopy.CheckState = CheckState.Checked Then
                If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
                If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

                If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

                If cmbcity.Text.Trim <> "" Then txtadd.Text = txtadd.Text & ", " & cmbcity.Text.Trim

                If txtzipcode.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & "," & vbNewLine
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbstate.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim & ","
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbcountry.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim & "."
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBILL.Click
        Try
            If edit = True Then
                Dim OBJOPENING As New OpeningBills
                OBJOPENING.MdiParent = MDIMain
                OBJOPENING.TEMPNAME = cmbcmpname.Text.Trim
                OBJOPENING.Show()
            Else
                MsgBox("Entry Allowed in Edit mode only", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTDSAPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTDSAPP.CheckedChanged
        Try
            If cmbgroup.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable = objcmn.search(" GROUP_SECONDARY", "", " GROUPMASTER", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        GROUPTDS.Enabled = CHKTDSAPP.CheckState
                    Else
                        MsgBox("Not Applicable for this Group")
                        CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTEETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEDUCTEETYPE.Enter
        Try
            If CMBDEDUCTEETYPE.Text.Trim = "" Then fillDEDUCTEETYPE(CMBDEDUCTEETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBISLOWER_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBISLOWER.Validating
        Try
            CMBSECTION.Text = ""
            If CMBISLOWER.Text = "Yes" Then
                CMBSECTION.Enabled = True
                CMBSECTION.Focus()
            Else
                CMBSECTION.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSECTION_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSECTION.Validating
        Try
            TXTTDSRATE.Clear()
            If CMBSECTION.Text = "197" Then
                TXTTDSRATE.Enabled = True
                TXTTDSRATE.Focus()
            Else
                TXTTDSRATE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEDUCTEETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEDUCTEETYPE.Validating
        Try
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DEDUCTEETYPE_NAME", "", " DEDUCTEETYPEMASTER", " AND DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If DT.Rows.Count = 0 Then
                    MsgBox("Select Proper Deductee", MsgBoxStyle.Critical)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub TXTTDSRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTDSRATE.KeyPress
        numdotkeypress(e, TXTTDSRATE, Me)
    End Sub

    Private Sub TXTLIMIT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLIMIT.KeyPress
        numdotkeypress(e, TXTLIMIT, Me)
    End Sub

    Private Sub txtpanno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpanno.Validating
        Try
            If txtpanno.Text.Trim > "" Then

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNATURE.Enter
        Try
            If CMBNATURE.Text.Trim = "" Then FILLNATURE(CMBNATURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNATURE.Validating
        Try
            If CMBNATURE.Text.Trim <> "" Then NATUREVALIDATE(CMBNATURE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNATION_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNATION.Enter
        Try
            If CMBDESIGNATION.Text.Trim = "" Then fillDESIGNATION(CMBDESIGNATION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNATION_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNATION.Validating
        Try
            If CMBDESIGNATION.Text.Trim <> "" Then DESIGNATIONVALIDATE(CMBDESIGNATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCEMAIL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCEMAIL.Validating
        Try
            If TXTCNAME.Text.Trim <> "" And TXTCMOB.Text.Trim <> "" Then
                fillCONTACTgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCONTACTgrid()

        If gridContactDoubleClick = False Then
            If DTPCDOB.Text <> "__/__/____" Then
                GRIDCONTACT.Rows.Add(TXTCNAME.Text.Trim, Format(Convert.ToDateTime(DTPCDOB.Text).Date, "dd/MM/yyyy"), CMBDESIGNATION.Text.Trim, TXTCMOB.Text.Trim, TXTCEMAIL.Text.Trim)
            Else
                GRIDCONTACT.Rows.Add(TXTCNAME.Text.Trim, "__/__/____", CMBDESIGNATION.Text.Trim, TXTCMOB.Text.Trim, TXTCEMAIL.Text.Trim)
            End If

            'getsrno(GRIDCONTACT)
        ElseIf gridContactDoubleClick = True Then
            GRIDCONTACT.Item(0, TEMPCONTACTROW).Value = TXTCNAME.Text.Trim
            If DTPCDOB.Text <> "__/__/____" Then
                GRIDCONTACT.Item(1, TEMPCONTACTROW).Value = Format(Convert.ToDateTime(DTPCDOB.Text).Date, "dd/MM/yyyy")
            Else
                GRIDCONTACT.Item(1, TEMPCONTACTROW).Value = "__/__/____"
            End If
            GRIDCONTACT.Item(2, TEMPCONTACTROW).Value = CMBDESIGNATION.Text.Trim
            GRIDCONTACT.Item(3, TEMPCONTACTROW).Value = TXTCMOB.Text.Trim
            GRIDCONTACT.Item(4, TEMPCONTACTROW).Value = TXTCEMAIL.Text.Trim

            gridContactDoubleClick = False
        End If
        GRIDCONTACT.FirstDisplayedScrollingRowIndex = GRIDCONTACT.RowCount - 1

        TXTCNAME.Clear()
        DTPCDOB.Clear()
        CMBDESIGNATION.Text = ""
        TXTCMOB.Clear()
        TXTCEMAIL.Clear()
        TXTCNAME.Focus()

    End Sub

    Private Sub GRIDCONTACT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONTACT.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDCONTACT.Item(GNAME.Index, e.RowIndex).Value <> Nothing Then

                gridContactDoubleClick = True
                TXTCNAME.Text = GRIDCONTACT.Item(GNAME.Index, e.RowIndex).Value
                DTPCDOB.Text = GRIDCONTACT.Item(GDOB.Index, e.RowIndex).Value
                CMBDESIGNATION.Text = GRIDCONTACT.Item(GDESIGNATION.Index, e.RowIndex).Value
                TXTCMOB.Text = GRIDCONTACT.Item(GMOBILENO.Index, e.RowIndex).Value.ToString
                TXTCEMAIL.Text = GRIDCONTACT.Item(GEMAIL.Index, e.RowIndex).Value.ToString
                TEMPCONTACTROW = e.RowIndex
                TXTCNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCONTACT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONTACT.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCONTACT.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridContactDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCONTACT.Rows.RemoveAt(GRIDCONTACT.CurrentRow.Index)
                'getsrno(GRIDCONTACT)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Details of " & CMBGUESTNAME.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(GUESTMASTER.GUEST_ADD1,'') AS ADD1, ISNULL(GUESTMASTER.GUEST_ADD2,'') AS ADD2, ISNULL(AREAMASTER.area_name,'') AS AREANAME, ISNULL(GUESTMASTER.GUEST_STD,'') AS STD, ISNULL(CITYMASTER.city_name,'') AS CITYNAME, ISNULL(GUESTMASTER.GUEST_ZIPCODE,'') AS ZIPCODE, ISNULL(STATEMASTER.state_name,'') AS STATENAME, ISNULL(COUNTRYMASTER.country_name,'') AS COUNTRYNAME, ISNULL(GUESTMASTER.GUEST_ALTNO,'') AS ALTNO, ISNULL(GUESTMASTER.GUEST_PHONENO,'') AS PHONENO, ISNULL(GUESTMASTER.GUEST_MOBILENO,'') AS MOBILENO, ISNULL(GUESTMASTER.GUEST_FAXNO,'') AS FAXNO, ISNULL(GUESTMASTER.GUEST_WEBSITE,'') AS WEBSITE, ISNULL(GUESTMASTER.GUEST_EMAIL,'') AS EMAILADD, GUEST_ISDOB AS ISDOB, GUEST_DOB AS DOB ", "", " GUESTMASTER LEFT OUTER JOIN COUNTRYMASTER ON GUESTMASTER.GUEST_YEARID = COUNTRYMASTER.country_yearid AND GUESTMASTER.GUEST_CMPID = COUNTRYMASTER.country_cmpid AND GUESTMASTER.GUEST_LOCATIONID = COUNTRYMASTER.country_locationid AND GUESTMASTER.GUEST_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON GUESTMASTER.GUEST_YEARID = STATEMASTER.state_yearid AND GUESTMASTER.GUEST_LOCATIONID = STATEMASTER.state_locationid AND GUESTMASTER.GUEST_CMPID = STATEMASTER.state_cmpid AND GUESTMASTER.GUEST_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON GUESTMASTER.GUEST_YEARID = CITYMASTER.city_yearid AND GUESTMASTER.GUEST_LOCATIONID = CITYMASTER.city_locationid AND GUESTMASTER.GUEST_CMPID = CITYMASTER.city_cmpid AND GUESTMASTER.GUEST_CITYID = CITYMASTER.city_id LEFT OUTER JOIN AREAMASTER ON GUESTMASTER.GUEST_YEARID = AREAMASTER.area_yearid AND GUESTMASTER.GUEST_LOCATIONID = AREAMASTER.area_locationid AND GUESTMASTER.GUEST_CMPID = AREAMASTER.area_cmpid AND GUESTMASTER.GUEST_AREAID = AREAMASTER.area_id", " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "' AND GUEST_CMPID = " & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        txtadd1.Text = DT.Rows(0).Item("ADD1")
                        txtadd2.Text = DT.Rows(0).Item("ADD2")
                        txtadd.Text = ""
                        cmbarea.Text = DT.Rows(0).Item("AREANAME")
                        txtstd.Text = DT.Rows(0).Item("STD")
                        cmbcity.Text = DT.Rows(0).Item("CITYNAME")
                        txtzipcode.Text = DT.Rows(0).Item("ZIPCODE")
                        cmbstate.Text = DT.Rows(0).Item("STATENAME")
                        cmbcountry.Text = DT.Rows(0).Item("COUNTRYNAME")
                        txtaltno.Text = DT.Rows(0).Item("ALTNO")
                        txttel1.Text = DT.Rows(0).Item("PHONENO")
                        txtmobile.Text = DT.Rows(0).Item("MOBILENO")
                        txtfax.Text = DT.Rows(0).Item("FAXNO")
                        txtwebsite.Text = DT.Rows(0).Item("WEBSITE")
                        cmbemail.Text = DT.Rows(0).Item("EMAILADD")
                        If Convert.ToBoolean(DT.Rows(0).Item("ISDOB")) = True Then
                            dtpdob.Text = Format(Convert.ToDateTime(DT.Rows(0).Item("DOB")).Date, "dd/MM/yyyy")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKCITY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANKCITY.GotFocus
        Try
            If CMBBANKCITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    CMBBANKCITY.DataSource = dt
                    CMBBANKCITY.DisplayMember = "city_name"
                    CMBBANKCITY.Text = ""
                End If
                CMBBANKCITY.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbBANKcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANKCITY.Validating
        Try
            If CMBBANKCITY.Text.Trim <> "" Then
                pcase(CMBBANKCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBBANKCITY.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBBANKCITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        CMBBANKCITY.Text = a
                        objyearmaster.savecity(CMBBANKCITY.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBBANKCITY.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBBANKCITY.DataSource
                        If CMBBANKCITY.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(CMBBANKCITY.Text)
                                CMBBANKCITY.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbBANKcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANKCOUNTRY.GotFocus
        Try
            If CMBBANKCOUNTRY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    CMBBANKCOUNTRY.DataSource = dt
                    CMBBANKCOUNTRY.DisplayMember = "country_name"
                    CMBBANKCOUNTRY.Text = ""
                End If
                CMBBANKCOUNTRY.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDBANK()

        If GRIDBANKDOUBLECLICK = False Then
            GRIDBANK.Rows.Add(TXTACNAME.Text.Trim, TXTACNO.Text.Trim, CMBACTYPE.Text.Trim, TXTBANKNAME.Text.Trim, TXTBRANCH.Text.Trim, TXTIFSC.Text.Trim, TXTSWIFT.Text.Trim, CMBBANKCITY.Text.Trim, TXTBANKPIN.Text.Trim, CMBBANKCOUNTRY.Text.Trim)

        ElseIf GRIDBANKDOUBLECLICK = True Then
            GRIDBANK.Item(GACNAME.Index, TEMPBANKROW).Value = TXTACNAME.Text.Trim
            GRIDBANK.Item(GACNO.Index, TEMPBANKROW).Value = TXTACNO.Text.Trim
            GRIDBANK.Item(GACTYPE.Index, TEMPBANKROW).Value = CMBACTYPE.Text.Trim
            GRIDBANK.Item(GBANKNAME.Index, TEMPBANKROW).Value = TXTBANKNAME.Text.Trim
            GRIDBANK.Item(GBRANCH.Index, TEMPBANKROW).Value = TXTBRANCH.Text.Trim
            GRIDBANK.Item(GIFSC.Index, TEMPBANKROW).Value = TXTIFSC.Text.Trim
            GRIDBANK.Item(GSWIFT.Index, TEMPBANKROW).Value = TXTSWIFT.Text.Trim
            GRIDBANK.Item(GCITY.Index, TEMPBANKROW).Value = CMBBANKCITY.Text.Trim
            GRIDBANK.Item(GPINCODE.Index, TEMPBANKROW).Value = TXTBANKPIN.Text.Trim
            GRIDBANK.Item(GCOUNTRY.Index, TEMPBANKROW).Value = CMBBANKCOUNTRY.Text.Trim

            GRIDBANKDOUBLECLICK = False
        End If
        GRIDBANK.FirstDisplayedScrollingRowIndex = GRIDBANK.RowCount - 1

        TXTACNAME.Clear()
        TXTACNO.Clear()
        CMBACTYPE.SelectedIndex = 0
        TXTBANKNAME.Clear()
        TXTBRANCH.Clear()
        TXTIFSC.Clear()
        TXTSWIFT.Clear()
        CMBBANKCITY.Text = ""
        TXTBANKPIN.Clear()
        CMBBANKCOUNTRY.Text = ""
        TXTACNAME.Focus()

    End Sub

    Private Sub GRIDBANK_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBANK.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDBANK.Item(GNAME.Index, e.RowIndex).Value <> Nothing Then

                GRIDBANKDOUBLECLICK = True
                TXTACNAME.Text = GRIDBANK.Item(GACNAME.Index, e.RowIndex).Value
                TXTACNO.Text = GRIDBANK.Item(GACNO.Index, e.RowIndex).Value
                CMBACTYPE.Text = GRIDBANK.Item(GACTYPE.Index, e.RowIndex).Value
                TXTBANKNAME.Text = GRIDBANK.Item(GBANKNAME.Index, e.RowIndex).Value.ToString
                TXTBRANCH.Text = GRIDBANK.Item(GBRANCH.Index, e.RowIndex).Value.ToString
                TXTIFSC.Text = GRIDBANK.Item(GIFSC.Index, e.RowIndex).Value.ToString
                TXTSWIFT.Text = GRIDBANK.Item(GSWIFT.Index, e.RowIndex).Value.ToString
                CMBBANKCITY.Text = GRIDBANK.Item(GCITY.Index, e.RowIndex).Value.ToString
                TXTBANKPIN.Text = GRIDBANK.Item(GPINCODE.Index, e.RowIndex).Value.ToString
                CMBBANKCOUNTRY.Text = GRIDBANK.Item(GCOUNTRY.Index, e.RowIndex).Value.ToString
                TEMPBANKROW = e.RowIndex
                TXTACNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBANK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBANK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBANK.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDBANKDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBANK.Rows.RemoveAt(GRIDBANK.CurrentRow.Index)
                'getsrno(GRIDBANK)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKCOUNTRY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANKCOUNTRY.Validated
        Try
            If TXTACNAME.Text.Trim <> "" And TXTACNO.Text.Trim <> "" And CMBACTYPE.Text.Trim <> "" And TXTBANKNAME.Text.Trim <> "" And TXTBRANCH.Text.Trim <> "" And CMBBANKCITY.Text.Trim <> "" Then
                FILLGRIDBANK()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbBANKcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANKCOUNTRY.Validating
        Try
            If CMBBANKCOUNTRY.Text.Trim <> "" Then
                pcase(CMBBANKCOUNTRY)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & CMBBANKCOUNTRY.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBBANKCOUNTRY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        CMBBANKCOUNTRY.Text = a
                        objyearmaster.savecountry(CMBBANKCOUNTRY.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & CMBBANKCOUNTRY.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBBANKCOUNTRY.DataSource
                        If CMBBANKCOUNTRY.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(CMBBANKCOUNTRY.Text)
                                CMBBANKCOUNTRY.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo Line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBREFFERED_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBREFFERED.Enter
        Try
            If CMBREFFERED.Text.Trim = "" And ClientName = "CLASSIC" Then
                fillname(CMBREFFERED, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
                CMBREFFERED.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBREFFERED_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBREFFERED.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBREFFERED.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLRELATION(ByRef CMBRELATION As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" RELATION_NAME ", "", " RELATIONMASTER", " and RELATION_cmpid=" & CmpId & " AND RELATION_LOCATIONID = " & Locationid & " AND RELATION_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "RELATION_NAME"
                CMBRELATION.DataSource = dt
                CMBRELATION.DisplayMember = "RELATION_NAME"
                CMBRELATION.Text = ""
            End If
            CMBRELATION.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBREFFERED_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBREFFERED.Validating
        Try
            If CMBREFFERED.Text.Trim <> "" And ClientName = "CLASSIC" Then namevalidate(CMBREFFERED, CMBACCCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRELATION_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRELATION.Validating
        Try
            If CMBRELATION.Text.Trim <> "" Then RELATIONVALIDATE(CMBRELATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFAMILYGRID()
        If gridFAMILYDoubleClick = False Then
            If FAMILYDOB.Text <> "__/__/____" Then
                GRIDFAMILY.Rows.Add(TXTFAMILYNAME.Text.Trim, Format(Convert.ToDateTime(FAMILYDOB.Text).Date, "dd/MM/yyyy"), Val(TXTFAMILYAGE.Text.Trim), CMBRELATION.Text.Trim, TXTMOBILENO.Text.Trim, TXTEMAILID.Text.Trim, CMBFAMILYSEX.Text.Trim)
            Else
                GRIDFAMILY.Rows.Add(TXTFAMILYNAME.Text.Trim, "__/__/____", Val(TXTFAMILYAGE.Text.Trim), CMBRELATION.Text.Trim, CMBFAMILYSEX.Text.Trim)
            End If

        ElseIf gridFAMILYDoubleClick = True Then
            GRIDFAMILY.Item(GFNAME.Index, TEMPFAMILYROW).Value = TXTFAMILYNAME.Text.Trim
            If FAMILYDOB.Text <> "__/__/____" Then
                GRIDFAMILY.Item(GFDOB.Index, TEMPFAMILYROW).Value = Format(Convert.ToDateTime(FAMILYDOB.Text).Date, "dd/MM/yyyy")
            Else
                GRIDFAMILY.Item(GFDOB.Index, TEMPFAMILYROW).Value = "__/__/____"
            End If
            GRIDFAMILY.Item(GFAGE.Index, TEMPFAMILYROW).Value = Val(TXTFAMILYAGE.Text.Trim)
            GRIDFAMILY.Item(GFRELATION.Index, TEMPFAMILYROW).Value = CMBRELATION.Text.Trim
            GRIDFAMILY.Item(GFMob.Index, TEMPFAMILYROW).Value = TXTMOBILENO.Text.Trim
            GRIDFAMILY.Item(GFEmailid.Index, TEMPFAMILYROW).Value = TXTEMAILID.Text.Trim
            GRIDFAMILY.Item(GFSEX.Index, TEMPFAMILYROW).Value = CMBFAMILYSEX.Text.Trim

            gridFAMILYDoubleClick = False
        End If
        GRIDFAMILY.FirstDisplayedScrollingRowIndex = GRIDFAMILY.RowCount - 1

        TXTFAMILYNAME.Clear()
        FAMILYDOB.Clear()
        TXTFAMILYAGE.Clear()
        CMBRELATION.Text = ""
        TXTMOBILENO.Clear()
        TXTEMAILID.Clear()
        CMBFAMILYSEX.Text = ""
        TXTFAMILYNAME.Focus()
    End Sub

    Private Sub CMBFAMILYSEX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFAMILYSEX.Validating
        Try
            If TXTFAMILYNAME.Text.Trim <> "" And CMBRELATION.Text.Trim <> "" And CMBFAMILYSEX.Text.Trim <> "" And Val(TXTFAMILYAGE.Text.Trim) > 0 Then
                FILLFAMILYGRID()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFAMILYAGE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFAMILYAGE.KeyPress
        numkeypress(e, TXTFAMILYAGE, Me)
    End Sub

    Private Sub TXTMOBILENO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMOBILENO.KeyPress
        numkeypress(e, TXTMOBILENO, Me)
    End Sub

    Private Sub CMBRELATION_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRELATION.Enter
        Try
            If CMBRELATION.Text.Trim <> "" Then FILLRELATION(CMBRELATION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOPENINGPOINT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOPPOINTS.KeyPress
        numkeypress(e, TXTOPPOINTS, Me)
    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then FILLCATEGORY(cmbcategory)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFAMILY_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFAMILY.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And GRIDFAMILY.Item(GFNAME.Index, e.RowIndex).Value <> Nothing Then

                gridFAMILYDoubleClick = True
                TXTFAMILYNAME.Text = GRIDFAMILY.Item(GFNAME.Index, e.RowIndex).Value
                FAMILYDOB.Text = GRIDFAMILY.Item(GFDOB.Index, e.RowIndex).Value
                TXTFAMILYAGE.Text = GRIDFAMILY.Item(GFAGE.Index, e.RowIndex).Value
                CMBRELATION.Text = GRIDFAMILY.Item(GFRELATION.Index, e.RowIndex).Value.ToString
                TXTMOBILENO.Text = GRIDFAMILY.Item(GFMob.Index, e.RowIndex).Value
                TXTEMAILID.Text = GRIDFAMILY.Item(GFEmailid.Index, e.RowIndex).Value
                CMBFAMILYSEX.Text = GRIDFAMILY.Item(GFSEX.Index, e.RowIndex).Value.ToString
                TEMPFAMILYROW = e.RowIndex
                TXTFAMILYNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFAMILY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFAMILY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFAMILY.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridFAMILYDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDFAMILY.Rows.RemoveAt(GRIDFAMILY.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating_1(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AccountsMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "TRAVELBRIDGE" Then CHKCOMMON.Checked = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtkstno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGSTIN.KeyPress
        If ClientName = "SCC" Then numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim objform As New PrintBlankForm
            objform.MdiParent = MDIMain
            If edit = True And ClientName = "SCC" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPCARRATE WHERE YEARID =  " & YearId & " AND NAME = '" & tempAccountsName & "'", "", "")
                DT = OBJCMN.search("T.VEHICLENAME, T.NAME, SUM(T.LOCAL)  AS [LOCAL], SUM(T.KMRATE) AS KMRATE, SUM(T.HRRATE) AS HRRATE, SUM(T.AIRPORT) AS AIRPORT, SUM(T.OUTSTATION) AS OUTSTATION, SUM(T.DRIVERALLOWANCE) AS ALLOWANCE", "", "(SELECT     ISNULL(VEHICLEMASTER.VEHICLE_NAME,'') AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS LOCAL, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, 0 AS AIRPORT, 0 AS OUTSTATION, ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS DRIVERALLOWANCE, 'LOCAL' AS TYPE FROM LEDGERS INNER JOIN VEHICLERATE ON LEDGERS.Acc_id = VEHICLERATE.VEHICLERATE_LEDGERID INNER JOIN VEHICLEMASTER ON VEHICLERATE.VEHICLERATE_VEHICLEID = VEHICLEMASTER.VEHICLE_ID WHERE VEHICLERATE_TYPE = 'LOCAL' AND LEDGERS.ACC_CMPNAME = '" & tempAccountsName & "' AND VEHICLERATE_YEARID = " & YearId & " UNION ALL SELECT ISNULL(VEHICLEMASTER.VEHICLE_NAME,'') AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, 0 AS LOCAL, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, 0 AS AIRPORT, ISNULL(VEHICLERATE.VEHICLERATE_RATE,0) AS OUTSTATION, ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS DRIVERALLOWANCE, 'OUTSTATION' AS TYPE FROM LEDGERS INNER JOIN VEHICLERATE ON LEDGERS.Acc_id = VEHICLERATE.VEHICLERATE_LEDGERID INNER JOIN VEHICLEMASTER ON VEHICLERATE.VEHICLERATE_VEHICLEID = VEHICLEMASTER.VEHICLE_ID WHERE VEHICLERATE_TYPE = 'OUTSTATION' AND LEDGERS.ACC_CMPNAME = '" & tempAccountsName & "' AND VEHICLERATE_YEARID = " & YearId & " UNION ALL SELECT ISNULL(VEHICLEMASTER.VEHICLE_NAME,'') AS VEHICLENAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, 0 AS LOCAL, ISNULL(VEHICLERATE.VEHICLERATE_KMRATE,0) AS KMRATE, ISNULL(VEHICLERATE.VEHICLERATE_HRRATE,0) AS HRRATE, ISNULL(VEHICLERATE.VEHICLERATE_RATE,0)  AS AIRPORT, 0 AS OUTSTATION, ISNULL(VEHICLERATE.VEHICLERATE_ALLOWANCE,0) AS DRIVERALLOWANCE, '4HRS 40KMS' AS TYPE FROM LEDGERS INNER JOIN VEHICLERATE ON LEDGERS.Acc_id = VEHICLERATE.VEHICLERATE_LEDGERID INNER JOIN VEHICLEMASTER ON VEHICLERATE.VEHICLERATE_VEHICLEID = VEHICLEMASTER.VEHICLE_ID WHERE VEHICLERATE_TYPE = '4HRS 40KMS' AND LEDGERS.ACC_CMPNAME = '" & tempAccountsName & "' AND VEHICLERATE_YEARID = " & YearId & ") AS T", " GROUP BY T.VEHICLENAME, T.NAME")
                For Each ROW As DataRow In DT.Rows
                    Dim DT1 As DataTable = OBJCMN.Execute_Any_String("INSERT INTO TEMPCARRATE VALUES ('" & tempAccountsName & "','" & ROW("VEHICLENAME") & "'," & Val(ROW("LOCAL")) & "," & Val(ROW("KMRATE")) & "," & Val(ROW("HRRATE")) & "," & Val(ROW("AIRPORT")) & "," & Val(ROW("OUTSTATION")) & "," & Val(ROW("ALLOWANCE")) & "," & CmpId & "," & YearId & ")", "", "")
                Next
                objform.STRSEARCH = " {TEMPCARRATE.NAME} = '" & tempAccountsName & "' AND {TEMPCARRATE.YEARID} = " & YearId
            End If
            objform.FRMSTRING = "CARQUOTE"
            objform.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcmpname.Validated
        Try
            If edit = False Then
                CMBCODE.Text = cmbcmpname.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class