
Imports BL
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class FlightMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public TEMPFLIGHTNAME As String
    Public TEMPFLIGHTCODE As String
    Dim TEMPFLIGHTID As Integer
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub FLIGHTMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Write Code here
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLFLIGHTNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("FLIGHT_NAME", "", " FLIGHTMASTER ", " and FLIGHT_cmpid = " & CmpId & " and FLIGHT_locationid = " & Locationid & " and FLIGHT_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "FLIGHT_NAME"
                CMBNAME.DataSource = dt
                CMBNAME.DisplayMember = "FLIGHT_NAME"
            End If
            CMBNAME.Text = TEMPFLIGHTNAME
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLFLIGHTCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("FLIGHT_CODE", "", " FLIGHTMASTER ", " and FLIGHT_cmpid = " & CmpId & " and FLIGHT_locationid = " & Locationid & " and FLIGHT_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "FLIGHT_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "FLIGHT_CODE"
            End If
            CMBCODE.Text = TEMPFLIGHTCODE
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid =" & CmpId & " and area_Locationid =" & Locationid & " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_name"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

    End Sub

    Private Sub FLIGHTMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'FLIGHT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            FILLFLIGHTNAME()
            FILLFLIGHTCODE()
            'clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJFLIGHT As New ClsFlightMaster
                OBJFLIGHT.alParaval.Add(TEMPFLIGHTNAME)
                OBJFLIGHT.alParaval.Add(CmpId)
                OBJFLIGHT.alParaval.Add(Locationid)
                OBJFLIGHT.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJFLIGHT.getFLIGHT

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        TEMPFLIGHTID = ROW("FLIGHTID")
                        CMBNAME.Text = ROW("NAME")
                        CMBCODE.Text = ROW("CODE")
                        TEMPFLIGHTCODE = ROW("CODE")
                        TXTPERSON.Text = ROW("CONTACT")

                        txtadd.Text = ROW("ADD")
                        txtadd1.Text = ROW("ADD1")
                        txtadd2.Text = ROW("ADD2")

                        cmbarea.Text = ROW("AREA")
                        txtstd.Text = ROW("STD")
                        cmbcity.Text = ROW("CITY")
                        txtzipcode.Text = ROW("ZIPCODE")
                        cmbstate.Text = ROW("STATE")
                        cmbcountry.Text = ROW("COUNTRY")
                        txtcrdays.Text = ROW("CRDAYS")
                        txtcrlimit.Text = ROW("CRLIMIT")

                        txtresino.Text = ROW("RESINO")
                        txtaltno.Text = ROW("ALTNO")
                        TXTPHONE.Text = ROW("PHONE")
                        txtmobile.Text = ROW("MOBILE")
                        txtfax.Text = ROW("FAX")
                        txtwebsite.Text = ROW("WEBSITE")
                        cmbemail.Text = ROW("EMAIL")
                        TXTPOLICY.Text = ROW("POLICY")

                        TXTAIRLINEPREF.Text = ROW("PREF")
                        TXTAIRLINECODE.Text = ROW("AIRLINECODE")

                        If Convert.ToBoolean(ROW("BSPSTOCK")) = True Then
                            CMBBSP.Text = "YES"
                        Else
                            CMBBSP.Text = "NO"
                        End If

                        TXTPSRCODE.Text = ROW("PSRCODE")

                        If Convert.ToBoolean(ROW("DOMESTIC")) = True Then
                            CMBDOMESTIC.Text = "YES"
                        Else
                            CMBDOMESTIC.Text = "NO"
                        End If

                        If Convert.ToBoolean(ROW("LCC")) = True Then
                            CMBLCC.Text = "YES"
                        Else
                            CMBLCC.Text = "NO"
                        End If

                        TXTBASIC.Text = ROW("BASIC")
                        TXTCOMM.Text = ROW("COMM")
                        TXTCOMMPSF.Text = ROW("COMMPSF")
                        TXTCOMMTAXES.Text = ROW("COMMTAX")
                        txtremarks.Text = ROW("REMARKS")

                        txtimgpath.Text = ROW("IMGPATH").ToString
                        TXTOURLOCATION.Text = ROW("OURLOCATION").ToString

                        GETIMG()

                        If ROW("GRIDSRNO") <> 0 Then GRIDFLIGHT.Rows.Add(ROW("GRIDSRNO"), ROW("ROUTENAME"), ROW("FROMCITY"), ROW("TOCITY"), ROW("DEPARTURE"), ROW("ARRIVAL"))
                    Next

                End If
            Else
                clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETIMG()
        On Error Resume Next
        PBIMG.ImageLocation = ""
        If txtimgpath.Text.Trim <> "" Then
            PBIMG.ImageLocation = txtimgpath.Text.Trim
            PBIMG.Load(txtimgpath.Text.Trim)
        ElseIf TXTOURLOCATION.Text.Trim <> "" Then
            PBIMG.ImageLocation = TXTOURLOCATION.Text.Trim
            PBIMG.Load(TXTOURLOCATION.Text.Trim)
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBCODE.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTPERSON.Text.Trim)

            alParaval.Add(txtadd.Text.Trim)
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
            alParaval.Add(TXTPHONE.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(TXTPOLICY.Text.Trim)

            alParaval.Add(TXTAIRLINEPREF.Text.Trim)
            alParaval.Add(TXTAIRLINECODE.Text.Trim)

            If CMBBSP.Text = "Yes" Then
                alParaval.Add("1")
            Else
                alParaval.Add("0")
            End If

            alParaval.Add(TXTPSRCODE.Text.Trim)

            If CMBDOMESTIC.Text = "Yes" Then
                alParaval.Add("1")
            Else
                alParaval.Add("0")
            End If

            If CMBLCC.Text = "Yes" Then
                alParaval.Add("1")
            Else
                alParaval.Add("0")
            End If

            alParaval.Add(TXTBASIC.Text.Trim)
            alParaval.Add(TXTCOMM.Text.Trim)
            alParaval.Add(TXTCOMMPSF.Text.Trim)
            alParaval.Add(TXTCOMMTAXES.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtimgpath.Text.Trim)
            alParaval.Add(TXTOURLOCATION.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim ROUTENAME As String = ""
            Dim FROMCITY As String = ""
            Dim TOCITY As String = ""
            Dim DEPARTURE As String = ""
            Dim ARRIVAL As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        ROUTENAME = row.Cells(GROUTENAME.Index).Value
                        FROMCITY = row.Cells(GFROM.Index).Value.ToString
                        TOCITY = row.Cells(GTO.Index).Value
                        DEPARTURE = row.Cells(GDEPARTURE.Index).Value
                        ARRIVAL = row.Cells(GARRIVAL.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        ROUTENAME = ROUTENAME & "," & row.Cells(GROUTENAME.Index).Value
                        FROMCITY = FROMCITY & "," & row.Cells(GFROM.Index).Value.ToString
                        TOCITY = TOCITY & "," & row.Cells(GTO.Index).Value
                        DEPARTURE = DEPARTURE & "," & row.Cells(GDEPARTURE.Index).Value
                        ARRIVAL = ARRIVAL & "," & row.Cells(GARRIVAL.Index).Value

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ROUTENAME)
            alParaval.Add(FROMCITY)
            alParaval.Add(TOCITY)
            alParaval.Add(DEPARTURE)
            alParaval.Add(ARRIVAL)

            Dim OBJFLIGHT As New ClsFlightMaster
            OBJFLIGHT.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJFLIGHT.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPFLIGHTID)
                IntResult = OBJFLIGHT.update()
                MsgBox("Details Updated")
            End If

            clear()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        CMBCODE.Text = ""
        CMBNAME.Text = ""
        TXTPERSON.Clear()
        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        cmbarea.Text = ""
        txtstd.Clear()
        cmbcity.Text = ""
        txtzipcode.Clear()
        cmbstate.Text = ""
        cmbcountry.Text = ""
        txtcrdays.Clear()
        txtcrlimit.Clear()

        txtresino.Clear()
        txtaltno.Clear()
        TXTPHONE.Clear()
        txtfax.Clear()
        txtmobile.Clear()
        txtwebsite.Clear()
        cmbemail.Text = ""
        TXTPOLICY.Clear()

        TXTAIRLINEPREF.Clear()
        TXTPSRCODE.Clear()
        TXTAIRLINECODE.Clear()

        CMBBSP.Text = "No"
        CMBLCC.Text = "No"
        CMBDOMESTIC.Text = "No"
        txtremarks.Clear()
        TXTBASIC.Text = 0
        TXTCOMM.Text = 0
        TXTCOMMPSF.Text = 0
        TXTCOMMTAXES.Text = 0

        txtsrno.Clear()
        CMBROUTENAME.Text = ""
        CMBFROM.Text = ""
        CMBTO.Text = ""
        TXTDEPARTURE.Clear()
        TXTARRIVAL.Clear()

        GRIDFLIGHT.RowCount = 0
        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        PBIMG.ImageLocation = ""

        edit = False

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Name")
            bln = False
        End If

        If CMBCODE.Text.Trim.Length = 0 Then
            EP.SetError(CMBCODE, "Fill Code")
            bln = False
        End If

        'If GRIDFLIGHT.RowCount = 0 Then
        '    EP.SetError(TXTARRIVAL, "Enter Flight Details")
        '    bln = False
        'End If

        'If txtadd.Text.Trim.Length = 0 Then
        '    EP.SetError(txtadd, "Fill Address")
        '    bln = False
        'End If

        'If txtmobile.Text.Trim.Length = 0 Then
        '    EP.SetError(txtmobile, "Enter Contact No.")
        '    bln = False
        'End If

        'If TXTAIRLINEPREF.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTAIRLINEPREF, "Enter Airline Pref.")
        '    bln = False
        'End If

        'If TXTAIRLINECODE.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTAIRLINECODE, "Enter Airline Code")
        '    bln = False
        'End If

        If CMBBSP.Text.Trim.Length = 0 Then
            EP.SetError(CMBBSP, "Select BSP Stock")
            bln = False
        End If
        If CMBBSP.Text = "Yes" Then
            If TXTPSRCODE.Text.Trim.Length = 0 Then
                EP.SetError(TXTPSRCODE, "Enter PSR Code")
                bln = False
            End If
        End If
        If CMBDOMESTIC.Text.Trim.Length = 0 Then
            EP.SetError(CMBDOMESTIC, "Select Flight Type")
            bln = False
        End If

        If CMBLCC.Text.Trim.Length = 0 Then
            EP.SetError(CMBLCC, "Select LCC")
            bln = False
        End If

        If TXTBASIC.Text.Trim.Length = 0 Then
            EP.SetError(TXTBASIC, "Enter Basic Comm")
            bln = False
        End If

        If TXTCOMM.Text.Trim.Length = 0 Then
            EP.SetError(TXTCOMM, "Enter Commission")
            bln = False
        End If

        If TXTCOMMPSF.Text.Trim.Length = 0 Then
            EP.SetError(TXTCOMMPSF, "Enter PSF Commission")
            bln = False
        End If


        If TXTCOMMTAXES.Text.Trim.Length = 0 Then
            EP.SetError(TXTCOMMTAXES, "Enter TAX Commission")
            bln = False
        End If


        Return bln
    End Function

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
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

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

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPERSON.Validating
        pcase(TXTPERSON)
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

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPHONE.KeyPress
        numdotkeypress(e, TXTPHONE, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                FILLFLIGHTNAME()
                CMBNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                pcase(CMBNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPFLIGHTNAME)) Then
                    dt = objclscommon.search("FLIGHT_NAME", "", " FLIGHTMASTER", " AND FLIGHT_NAME = '" & CMBNAME.Text.Trim & "' AND FLIGHT_CMPID = " & CmpId & " AND FLIGHT_LOCATIONID = " & Locationid & " AND FLIGHT_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Flight?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPFLIGHTNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                Dim OBJFLIGHT As New ClsFlightMaster
                OBJFLIGHT.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJFLIGHT.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    If FileIO.FileSystem.FileExists(Application.StartupPath & "\FLIGHT_LOGO") = True Then System.IO.File.Delete(TXTOURLOCATION.Text.Trim)
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
                FILLFLIGHTCODE()
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                uppercase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBCODE.Text) <> LCase(TEMPFLIGHTCODE)) Then
                    dt = objclscommon.search("FLIGHT_CODE", "", " FLIGHTMASTER", " AND FLIGHT_CODE = '" & CMBCODE.Text.Trim & "' AND FLIGHT_CMPID = " & CmpId & " AND FLIGHT_LOCATIONID = " & Locationid & " AND FLIGHT_YEARID = " & YearId)
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

    Private Sub TXTARRIVAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTARRIVAL.Validating
        Try

            If CMBROUTENAME.Text.Trim <> "" And CMBFROM.Text.Trim <> "" And CMBTO.Text.Trim <> "" Then
                EP.Clear()
                If Not CHECKROUTE() Then
                    Exit Sub
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKROUTE() As Boolean
        Try
            Dim BLN As Boolean = True

            For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                If (ROW.Cells(GROUTENAME.Index).Value = CMBROUTENAME.Text.Trim And gridDoubleClick = False) Or (gridDoubleClick = True And temprow <> Val(txtsrno.Text.Trim) - 1) Then
                    EP.SetError(TXTARRIVAL, "Route Name Already Present in Grid Below")
                    BLN = False
                End If
            Next

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDFLIGHT.Rows.Add(Val(txtsrno.Text.Trim), CMBROUTENAME.Text.Trim, CMBFROM.Text.Trim, CMBTO.Text.Trim, TXTDEPARTURE.Text.Trim, TXTARRIVAL.Text.Trim)
            getsrno(GRIDFLIGHT)
        ElseIf gridDoubleClick = True Then

            GRIDFLIGHT.Item(0, temprow).Value = txtsrno.Text.Trim
            GRIDFLIGHT.Item(1, temprow).Value = CMBROUTENAME.Text.Trim
            GRIDFLIGHT.Item(2, temprow).Value = CMBFROM.Text.Trim
            GRIDFLIGHT.Item(3, temprow).Value = CMBTO.Text.Trim
            GRIDFLIGHT.Item(4, temprow).Value = TXTDEPARTURE.Text.Trim
            GRIDFLIGHT.Item(GARRIVAL.Index, temprow).Value = TXTARRIVAL.Text.Trim

            gridDoubleClick = False

        End If
        GRIDFLIGHT.FirstDisplayedScrollingRowIndex = GRIDFLIGHT.RowCount - 1

        txtsrno.Clear()
        CMBROUTENAME.Text = ""
        CMBFROM.Text = ""
        CMBTO.Text = ""
        TXTDEPARTURE.Clear()
        TXTARRIVAL.Clear()
        txtsrno.Focus()

    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDFLIGHT.RowCount > 0 Then
                txtsrno.Text = Val(GRIDFLIGHT.Rows(GRIDFLIGHT.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub gridflight_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFLIGHT.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDFLIGHT.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                txtsrno.Text = GRIDFLIGHT.Item(GSRNO.Index, e.RowIndex).Value
                CMBROUTENAME.Text = GRIDFLIGHT.Item(GROUTENAME.Index, e.RowIndex).Value
                CMBFROM.Text = GRIDFLIGHT.Item(GFROM.Index, e.RowIndex).Value.ToString
                CMBTO.Text = GRIDFLIGHT.Item(GTO.Index, e.RowIndex).Value.ToString
                TXTDEPARTURE.Text = GRIDFLIGHT.Item(GDEPARTURE.Index, e.RowIndex).Value.ToString
                TXTARRIVAL.Text = GRIDFLIGHT.Rows(e.RowIndex).Cells(GARRIVAL.Index).Value
                temprow = e.RowIndex
                txtsrno.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridflight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFLIGHT.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFLIGHT.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDFLIGHT.Rows.RemoveAt(GRIDFLIGHT.CurrentRow.Index)
                getsrno(GRIDFLIGHT)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROUTENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROUTENAME.Enter
        Try
            If CMBROUTENAME.Text.Trim = "" Then FILLROUTE(CMBROUTENAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROUTENAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBROUTENAME.Validating
        Try
            If CMBROUTENAME.Text.Trim <> "" Then ROUTEVALIDATE(CMBROUTENAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Enter
        Try
            If CMBFROM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    CMBFROM.DataSource = dt
                    CMBFROM.DisplayMember = "city_name"
                    CMBFROM.Text = ""
                End If
                CMBFROM.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTO.Enter
        Try
            If CMBTO.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    CMBTO.DataSource = dt
                    CMBTO.DisplayMember = "city_name"
                    CMBTO.Text = ""
                End If
                CMBTO.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROM.Validating
        Try
            If CMBFROM.Text.Trim <> "" Then
                pcase(CMBFROM)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBFROM.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBFROM.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        CMBFROM.Text = a
                        objyearmaster.savecity(CMBFROM.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBFROM.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBFROM.DataSource
                        If CMBFROM.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(CMBFROM.Text)
                                CMBFROM.Text = a
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

    Private Sub CMBTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTO.Validating
        Try
            If CMBTO.Text.Trim <> "" Then
                pcase(CMBTO)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBTO.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTO.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        CMBTO.Text = a
                        objyearmaster.savecity(CMBTO.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBTO.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = CMBTO.DataSource
                        If CMBTO.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(CMBTO.Text)
                                CMBTO.Text = a
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

    Private Sub FlightMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "TOPCOMM" Then Me.Close()
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

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.PNG;*.bmp;*.JPEG;*.JPG)|*.png;*.bmp;*.jpeg;*.jpg"
        OpenFileDialog1.ShowDialog()

        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\FLIGHT_LOGO") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\FLIGHT_LOGO")
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        TXTOURLOCATION.Text = Application.StartupPath & "\FLIGHT_LOGO\" & TXTFILENAME.Text.Trim
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then PBIMG.ImageLocation = txtimgpath.Text.Trim

        'COPY SCANNED DOCS FILES 
        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\FLIGHT_LOGO") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\FLIGHT_LOGO")
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\FLIGHT_LOGO") = False Then System.IO.File.Copy(txtimgpath.Text.Trim, TXTOURLOCATION.Text.Trim, True)
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        PBIMG.ImageLocation = ""
        txtimgpath.Clear()
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\FLIGHT_LOGO") = True Then System.IO.File.Delete(TXTOURLOCATION.Text.Trim)
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBIMG.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class