
Imports System.Drawing
Imports System.IO
Imports BL

Public Class GuestMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPGUESTNAME As String
    Public TEMPGUESTID As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GuestMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
                TXTDISPLAYNAME.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
                TXTPASSPORTNO.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
                TabControl1.SelectedIndex = 2
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("GUEST_NAME", "", " GUESTMASTER ", " and GUEST_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "GUEST_NAME"
                CMBNAME.DataSource = dt
                CMBNAME.DisplayMember = "GUEST_NAME"
                CMBNAME.Text = TEMPGUESTNAME
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
        End If

        fillCountry(cmbcountry)
        fillCountry(CMBISSUECOUNTRY)
        fillcity(cmbcity)

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
        End If

        FILLNATIONALITY(CMBNATIONALITY)
        FILLGUESTCATEGORY(CMBGUESTCATEGORY, False)
    End Sub

    Private Sub GuestMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim dttable As New DataTable
            Dim OBJGUEST As New ClsGuestMaster

            fillcmb()
            CMBISSUECOUNTRY.Text = ""

            'GET UNIQUE NO
            Dim DT As DataTable = getmax(" isnull(max(GUEST_ID),0) + 1 ", " GUESTMASTER", "")
            TXTUNIQUENO.Text = DT.Rows(0).Item(0)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPGUESTNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJGUEST.alParaval = ALPARAVAL
                dttable = OBJGUEST.SELECTGUESTDETAILS()
                If dttable.Rows.Count > 0 Then

                    TEMPGUESTID = Val(dttable.Rows(0).Item("GUESTID"))
                    TXTUNIQUENO.Text = Val(dttable.Rows(0).Item("UNIQUENO"))
                    TXTCOPYID.Enabled = False

                    CMBNAME.Text = dttable.Rows(0).Item("NAME").ToString
                    TXTDISPLAYNAME.Text = dttable.Rows(0).Item("DISPLAYNAME").ToString
                    txtadd1.Text = dttable.Rows(0).Item("ADD1").ToString
                    txtadd2.Text = dttable.Rows(0).Item("ADD2").ToString

                    cmbarea.Text = dttable.Rows(0).Item("AREANAME").ToString
                    txtstd.Text = dttable.Rows(0).Item("STD").ToString
                    cmbcity.Text = dttable.Rows(0).Item("CITYNAME").ToString
                    txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString
                    cmbstate.Text = dttable.Rows(0).Item("STATENAME").ToString
                    cmbcountry.Text = dttable.Rows(0).Item("COUNTRYNAME").ToString

                    TXTMEMBERSHIPNO.Text = dttable.Rows(0).Item("MEMBERSHIPNO").ToString

                    txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
                    txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString
                    txttel1.Text = dttable.Rows(0).Item("PHONE").ToString
                    txtmobile.Text = dttable.Rows(0).Item("MOBILE").ToString
                    txtfax.Text = dttable.Rows(0).Item("FAX").ToString
                    txtwebsite.Text = dttable.Rows(0).Item("WEBSITE").ToString
                    cmbemail.Text = dttable.Rows(0).Item("EMAIL").ToString

                    CMBREF.Text = dttable.Rows(0).Item("REF").ToString
                    CMBNATIONALITY.Text = dttable.Rows(0).Item("NATIONALITY").ToString

                    If Convert.ToBoolean(dttable.Rows(0).Item("ISDOB")) = True Then
                        chkdob.CheckState = CheckState.Checked
                        DOB.Value = dttable.Rows(0).Item("DOB")
                    End If


                    If Convert.ToBoolean(dttable.Rows(0).Item("ISDOA")) = True Then
                        chkdoa.CheckState = CheckState.Checked
                        DOA.Value = dttable.Rows(0).Item("DOA")
                    End If

                    TXTPLACEOFBIRTH.Text = dttable.Rows(0).Item("PLACEOFBIRTH").ToString
                    txtadd.Text = dttable.Rows(0).Item("ADD").ToString
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString

                    TXTPASSPORTNAME.Text = dttable.Rows(0).Item("PASSPORTNAME").ToString
                    TXTPASSPORTNO.Text = dttable.Rows(0).Item("PASSPORTNO").ToString
                    ISSUEDATE.Value = dttable.Rows(0).Item("ISSUEDATE")
                    EXPIRYDATE.Value = dttable.Rows(0).Item("EXPIRYDATE")
                    TXTGIVENNAME.Text = dttable.Rows(0).Item("GIVENNAME").ToString
                    TXTSURNAME.Text = dttable.Rows(0).Item("SURNAME").ToString
                    CMBGENDER.Text = dttable.Rows(0).Item("GENDER").ToString
                    CMBSTATUS.Text = dttable.Rows(0).Item("STATUS").ToString
                    TXTPLACEOFISSUE.Text = dttable.Rows(0).Item("PLACEOFISSUE").ToString
                    CMBISSUECOUNTRY.Text = dttable.Rows(0).Item("COUNTRYOFISSUE").ToString
                    CMBPREFIX.Text = dttable.Rows(0).Item("PREFIX").ToString

                    TXTADULD.Text = dttable.Rows(0).Item("ADULT").ToString
                    TXTCHILD.Text = dttable.Rows(0).Item("CHILD").ToString
                    TXTINFANT.Text = dttable.Rows(0).Item("INFANT").ToString
                    TXTFATHER.Text = dttable.Rows(0).Item("FATHER").ToString
                    TXTMOTHER.Text = dttable.Rows(0).Item("MOTHER").ToString
                    TXTSPOUSE.Text = dttable.Rows(0).Item("SPOUSE").ToString

                    TXTREFFVIA.Text = dttable.Rows(0).Item("REFFVIA").ToString
                    CMBCORDINATORVIA.Text = dttable.Rows(0).Item("CORDINATORVIA").ToString
                    CMBGUESTCATEGORY.Text = dttable.Rows(0).Item("GUESTCATEGORY")
                    CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))

                    If dttable.Rows(0).Item("CHKPASSPORT").ToString = True Then
                        CHKPASSPORT.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKSAFAI").ToString = True Then
                        CHKSAFAI.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKITS").ToString = True Then
                        CHKITS.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKPHOTO").ToString = True Then
                        CHKPHOTO.Checked = True
                    End If

                    If Convert.ToBoolean(dttable.Rows(0).Item("GUEST")) = True Then
                        RDBGUEST.Checked = True
                    End If
                    If Convert.ToBoolean(dttable.Rows(0).Item("LEADER")) = True Then
                        RDBLEADER.Checked = True
                    End If
                    If Convert.ToBoolean(dttable.Rows(0).Item("CORDINATOR")) = True Then
                        RDBCORDINATOR.Checked = True
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        txtimgpath.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        PBIMG.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH1")) = False Then
                        PBIMG1.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH1"), Byte())))
                        txtimgpath1.Text = dttable.Rows(0).Item("IMGPATH1").ToString
                    Else
                        PBIMG1.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH2")) = False Then
                        PBIMG2.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH2"), Byte())))
                        txtimgpath2.Text = dttable.Rows(0).Item("IMGPATH2").ToString
                    Else
                        PBIMG2.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH3")) = False Then
                        PBIMG3.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH3"), Byte())))
                        txtimgpath3.Text = dttable.Rows(0).Item("IMGPATH3").ToString
                    Else
                        PBIMG3.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH4")) = False Then
                        PBIMG4.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH4"), Byte())))
                        txtimgpath4.Text = dttable.Rows(0).Item("IMGPATH4").ToString
                    Else
                        PBIMG4.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH5")) = False Then
                        PBIMG5.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH5"), Byte())))
                        txtimgpath5.Text = dttable.Rows(0).Item("IMGPATH5").ToString
                    Else
                        PBIMG5.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH6")) = False Then
                        PBIMG6.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH6"), Byte())))
                        txtimgpath6.Text = dttable.Rows(0).Item("IMGPATH6").ToString
                    Else
                        PBIMG6.Image = Nothing
                    End If


                End If

            Else
                edit = False
                CMBNAME.Text = TEMPGUESTNAME
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then PBIMG.ImageLocation = txtimgpath.Text.Trim
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            PBIMG.Image = Nothing
            txtimgpath.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            If CHKCOMMON.CheckState = CheckState.Unchecked Then
                If edit = False Then SAVEUPDATE(CmpId, YearId, 0) Else SAVEUPDATE(CmpId, YearId, TEMPGUESTID)
            Else
                Dim OBJCMN As New ClsCommon
                Dim DTCMP As DataTable = OBJCMN.search("YEAR_CMPID AS CMPID, YEAR_ID AS YEARID ", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(Convert.ToDateTime(AccFrom.Date), "MM/dd/yyyy") & "' ORDER BY YEAR_ID")
                For Each DTROW As DataRow In DTCMP.Rows

                    Dim DTTEMP As DataTable
                    Dim OBJYEAR As New ClsYearMaster


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
                    DTTEMP = OBJCMN.search("CATEGORY_id", "", "GUESTCATEGORYMaster", " and CATEGORY_NAME = '" & CMBGUESTCATEGORY.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_YEARid = " & DTROW("YearId"))
                    If DTTEMP.Rows.Count = 0 Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(CMBGUESTCATEGORY.Text.Trim)
                        alParaval.Add(DTROW("CMPID"))
                        alParaval.Add(Userid)
                        alParaval.Add(DTROW("YearId"))
                        Dim OBJ As New ClsGuestCategoryMaster
                        OBJ.alParaval = alParaval
                        Dim IntResult As Integer = OBJ.save()
                    End If


                    'CHECK ISSUECOUNTRY
                    DTTEMP = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", " AND COUNTRY_NAME = '" & CMBISSUECOUNTRY.Text.Trim & "' AND COUNTRY_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        OBJYEAR.savecountry(CMBISSUECOUNTRY.Text.Trim, DTROW("CMPID"), 0, Userid, DTROW("YEARID"))
                    End If


                    If edit = False Then
                        If YearId <> DTROW("YEARID") Then
                            DTTEMP = OBJCMN.search("GUEST_ID AS GUESTID", "", "GUESTMASTER", " AND GUEST_NAME = '" & CMBNAME.Text.Trim & "' AND GUEST_YEARID = " & Val(DTROW("YEARID")))
                            If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE
                        End If
                        SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), 0)
                    Else

                        'FIRST GET THE ACCOUNTID FROM YEARID AND THEN PASS IT IN THE UPDATE QUERY
                        DTTEMP = OBJCMN.search("GUEST_ID AS GUESTID", "", "GUESTMASTER", " AND GUEST_NAME = '" & TEMPGUESTNAME & "' AND GUEST_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), Val(DTTEMP.Rows(0).Item("GUESTID")))
                    End If
NEXTLINE:
                Next
            End If

            If edit = False Then MsgBox("Details Added") Else MsgBox("Details Updated")
            clear()
            TEMPGUESTNAME = ""
            edit = False
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPDATE(ByVal TCMPID As Integer, ByVal TYEARID As Integer, ByVal TGUESTID As Integer)
        Try
            EP.Clear()
            If Not errorvalid(TYEARID) Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)

            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)

            alParaval.Add(TXTMEMBERSHIPNO.Text.Trim)
            alParaval.Add(chkdob.CheckState)
            alParaval.Add(Format(DOB.Value.Date, "MM/dd/yyyy"))

            alParaval.Add(chkdoa.CheckState)
            alParaval.Add(Format(DOA.Value.Date, "MM/dd/yyyy"))


            alParaval.Add(TXTPLACEOFBIRTH.Text.Trim)

            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(CMBREF.Text.Trim)
            alParaval.Add(CMBNATIONALITY.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTDISPLAYNAME.Text.Trim)
            alParaval.Add(TXTPASSPORTNAME.Text.Trim)
            alParaval.Add(TXTPASSPORTNO.Text.Trim)
            alParaval.Add(Format(ISSUEDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(Format(EXPIRYDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTGIVENNAME.Text.Trim)
            alParaval.Add(TXTSURNAME.Text.Trim)
            alParaval.Add(CMBGENDER.Text.Trim)
            alParaval.Add(CMBSTATUS.Text.Trim)
            alParaval.Add(TXTPLACEOFISSUE.Text.Trim)
            alParaval.Add(CMBISSUECOUNTRY.Text.Trim)
            alParaval.Add(CMBPREFIX.Text.Trim)

            alParaval.Add(Val(TXTADULD.Text.Trim))
            alParaval.Add(Val(TXTCHILD.Text.Trim))
            alParaval.Add(Val(TXTINFANT.Text.Trim))
            alParaval.Add(TXTFATHER.Text.Trim)
            alParaval.Add(TXTMOTHER.Text.Trim)
            alParaval.Add(TXTSPOUSE.Text.Trim)
            alParaval.Add(TXTREFFVIA.Text.Trim)
            alParaval.Add(CMBCORDINATORVIA.Text.Trim)
            alParaval.Add(CMBGUESTCATEGORY.Text.Trim)

            alParaval.Add(CHKPASSPORT.CheckState)
            alParaval.Add(CHKSAFAI.CheckState)
            alParaval.Add(CHKITS.CheckState)
            alParaval.Add(CHKPHOTO.CheckState)


            If RDBGUEST.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If RDBLEADER.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If RDBCORDINATOR.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If PBIMG.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(TXTOURLOCATION.Text.Trim)

            If PBIMG1.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG1.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION1.Text.Trim)


            If PBIMG2.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG2.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION2.Text.Trim)

            If PBIMG3.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG3.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION3.Text.Trim)

            If PBIMG4.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG4.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION4.Text.Trim)

            If PBIMG5.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG5.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION5.Text.Trim)

            If PBIMG6.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBIMG6.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTOURLOCATION6.Text.Trim)


            alParaval.Add(Val(TXTCOPYID.Text.Trim))

            alParaval.Add(TCMPID)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(TYEARID)
            alParaval.Add(0)
            alParaval.Add(CHKBLOCKED.CheckState)


            Dim OBJGUEST As New ClsGuestMaster
            OBJGUEST.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJGUEST.SAVE()
                'MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TGUESTID)
                IntResult = OBJGUEST.UPDATE()
                'MsgBox("Details Updated")
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        CMBENQ.Text = ""
        CMBNAME.Text = ""
        CMBPREFIX.Text = ""
        TXTCOPYID.Clear()
        TXTCOPYID.Enabled = True
        TXTUNIQUENO.Clear()

        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        CMBREF.Text = ""
        cmbarea.Text = ""
        txtstd.Clear()
        cmbcity.Text = ""
        txtzipcode.Clear()
        cmbstate.Text = ""
        cmbcountry.Text = ""
        TXTMEMBERSHIPNO.Clear()

        TXTADULD.Clear()
        TXTCHILD.Clear()
        TXTINFANT.Clear()
        TXTFATHER.Clear()
        TXTMOTHER.Clear()
        TXTSPOUSE.Clear()

        chkdob.CheckState = CheckState.Unchecked
        DOB.Value = Mydate

        chkdoa.CheckState = CheckState.Unchecked
        DOA.Value = Mydate

        TXTPLACEOFBIRTH.Clear()
      
        TXTDISPLAYNAME.Clear()
        TXTPASSPORTNAME.Clear()
        TXTPASSPORTNO.Clear()
        ISSUEDATE.Value = Mydate
        EXPIRYDATE.Value = Mydate
        TXTGIVENNAME.Clear()
        TXTSURNAME.Clear()
        CMBGENDER.Text = ""
        CMBSTATUS.Text = ""
        TXTPLACEOFISSUE.Clear()
        CMBISSUECOUNTRY.Text = ""

        txtresino.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        cmbemail.Text = ""
        txtremarks.Clear()
        TXTREFFVIA.Clear()
        CMBCORDINATORVIA.Text = ""
        CMBGUESTCATEGORY.Text = ""

        CHKPASSPORT.Checked = False
        CHKSAFAI.Checked = False
        CHKITS.Checked = False
        CHKPHOTO.Checked = False

        RDBGUEST.Checked = True
        CMBNATIONALITY.Text = ""

        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        TXTFILENAME.Clear()
        PBIMG.Image = Nothing

        txtimgpath1.Clear()
        TXTOURLOCATION1.Clear()
        TXTFILENAME1.Clear()
        PBIMG1.Image = Nothing

        txtimgpath2.Clear()
        TXTOURLOCATION2.Clear()
        TXTFILENAME2.Clear()
        PBIMG2.Image = Nothing

        txtimgpath3.Clear()
        TXTOURLOCATION3.Clear()
        TXTFILENAME3.Clear()
        PBIMG3.Image = Nothing

        txtimgpath4.Clear()
        TXTOURLOCATION4.Clear()
        TXTFILENAME4.Clear()
        PBIMG4.Image = Nothing

        txtimgpath5.Clear()
        TXTOURLOCATION5.Clear()
        TXTFILENAME5.Clear()
        PBIMG5.Image = Nothing

        txtimgpath6.Clear()
        TXTOURLOCATION6.Clear()
        TXTFILENAME6.Clear()
        PBIMG6.Image = Nothing

        CMBNAME.Text = ""
        CMBLEDGERS.Text = ""
        edit = False
        CHKBLOCKED.CheckState = CheckState.Unchecked
    End Sub

    Private Function errorvalid(TYEARID) As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Guest Name")
            bln = False
        End If

        If ClientName = "FINASTA" And EXPIRYDATE.Value.Date < Mydate.Date Then
            EP.SetError(EXPIRYDATE, "Passport Expired")
            bln = False
        End If

        If ClientName = "RAMKRISHNA" And TXTREFFVIA.Text.Trim.Length = 0 Then
            EP.SetError(TXTREFFVIA, "Enter Refference Via")
            bln = False
        End If


        'CHECK NAME
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        If CMBNAME.Text.Trim <> "" Then
            pcase(CMBNAME)
            If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPGUESTNAME)) Then
                dt = objclscommon.search("GUEST_NAME", "", " GUESTMASTER", " AND GUEST_NAME = '" & CMBNAME.Text.Trim & "' AND GUEST_YEARID = " & TYEARID)
                If dt.Rows.Count > 0 Then
                    EP.SetError(CMBNAME, "Name Already Exists")
                    bln = False
                End If
            End If
        End If



        'CHECK PASSPORT NO
        If TXTPASSPORTNO.Text.Trim <> "" Then
            pcase(TXTPASSPORTNO)
            If (edit = False) Then
                dt = objclscommon.search("GUEST_PASSPORTNO", "", " GUESTMASTER", " AND GUEST_PASSPORTNO = '" & TXTPASSPORTNO.Text.Trim & "' AND GUEST_YEARID = " & TYEARID)
                If dt.Rows.Count > 0 Then
                    EP.SetError(CMBNAME, " Passport No. Already Exists")
                    bln = False
                End If
            End If
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

    Private Sub txtadd1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd1.Validating
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd2.Validating
        pcase(txtadd2)
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress, txtresino.KeyPress, txtaltno.KeyPress, txttel1.KeyPress, txtmobile.KeyPress, txtfax.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                FILLCMPNAME()
                CMBNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then
                pcase(CMBNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBNAME.Text) <> LCase(TEMPGUESTNAME)) Then
                    dt = objclscommon.search("GUEST_NAME", "", " GUESTMASTER", " AND GUEST_NAME = '" & CMBNAME.Text.Trim & "' AND GUEST_CMPID = " & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
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

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete Guest?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

               If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPGUESTNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                Dim OBJGUEST As New ClsGuestMaster
                OBJGUEST.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJGUEST.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBREF_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBREF.Enter
        Try
            If CMBREF.Text.Trim = "" Then FILLGUESTNAME(CMBREF, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBREF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBREF.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 0
            TXTREFFVIA.Focus()
        End If
    End Sub

    Private Sub CMBREF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBREF.Validating
        Try
            If CMBREF.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBREF, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
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

    Private Sub CMBNATIONALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNATIONALITY.Enter
        Try
            If CMBNATIONALITY.Text.Trim = "" Then
                FILLNATIONALITY(CMBNATIONALITY)
                CMBNATIONALITY.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNATIONALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNATIONALITY.Validating
        Try
            If CMBNATIONALITY.Text.Trim <> "" Then NATIONALITYVALIDATE(CMBNATIONALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTITSNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISPLAYNAME.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 1
            TXTPASSPORTNO.Focus()
        End If
    End Sub

    Private Sub TXTPASSPORTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPASSPORTNO.Validating
        Try
            If TXTPASSPORTNO.Text.Trim <> "" Then
                pcase(TXTPASSPORTNO)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Then
                    dt = objclscommon.search("GUEST_PASSPORTNO", "", " GUESTMASTER", " AND GUEST_PASSPORTNO = '" & TXTPASSPORTNO.Text.Trim & "' AND GUEST_CMPID = " & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox(" Passport No. Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPREFIX.Enter
        Try
            If CMBPREFIX.Text.Trim = "" Then FILLPREFIX(CMBPREFIX)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPREFIX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPREFIX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPREFIX.Validating
        Try
            If CMBPREFIX.Text.Trim <> "" Then PREFIXvalidate(CMBPREFIX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBCORDINATOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBCORDINATOR.CheckedChanged
        Try
            If RDBCORDINATOR.Checked = True Then
                LBLADULT.Visible = True
                TXTADULD.Visible = True
                LBLCHILD.Visible = True
                TXTCHILD.Visible = True
                LBLINFANT.Visible = True
                TXTINFANT.Visible = True
            Else
                LBLADULT.Visible = False
                TXTADULD.Visible = False
                LBLCHILD.Visible = False
                TXTCHILD.Visible = False
                LBLINFANT.Visible = False
                TXTINFANT.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADULD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULD.KeyPress
        Try
            numdotkeypress(e, TXTADULD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILD.KeyPress
        Try
            numdotkeypress(e, TXTCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINFANT.KeyPress
        Try
            numdotkeypress(e, TXTINFANT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload1.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath1.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath1.Text.Trim.Length <> 0 Then PBIMG1.ImageLocation = txtimgpath1.Text.Trim
    End Sub

    Private Sub cmdupload2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload2.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath2.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath2.Text.Trim.Length <> 0 Then PBIMG2.ImageLocation = txtimgpath2.Text.Trim
    End Sub

    Private Sub cmdupload3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload3.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath3.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath3.Text.Trim.Length <> 0 Then PBIMG3.ImageLocation = txtimgpath3.Text.Trim
    End Sub

    Private Sub cmdupload4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload4.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath4.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath4.Text.Trim.Length <> 0 Then PBIMG4.ImageLocation = txtimgpath4.Text.Trim
    End Sub

    Private Sub cmdupload5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload5.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath5.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath5.Text.Trim.Length <> 0 Then PBIMG5.ImageLocation = txtimgpath5.Text.Trim
    End Sub

    Private Sub cmdupload6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload6.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        txtimgpath6.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath6.Text.Trim.Length <> 0 Then PBIMG6.ImageLocation = txtimgpath6.Text.Trim
    End Sub

    Private Sub cmdremove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove1.Click
        Try
            PBIMG1.Image = Nothing
            txtimgpath1.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdremove2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove2.Click
        Try
            PBIMG2.Image = Nothing
            txtimgpath2.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdremove3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove3.Click
        Try
            PBIMG3.Image = Nothing
            txtimgpath3.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdremove4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove4.Click
        Try
            PBIMG4.Image = Nothing
            txtimgpath4.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdremove5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove5.Click
        Try
            PBIMG5.Image = Nothing
            txtimgpath5.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdremove6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove6.Click
        Try
            PBIMG6.Image = Nothing
            txtimgpath6.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW1.Click
        Try
            If txtimgpath1.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath1.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath1.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG1.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW2.Click
        Try
            If txtimgpath2.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath2.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath2.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG2.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW3.Click
        Try
            If txtimgpath3.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath3.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath3.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG3.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW4.Click
        Try
            If txtimgpath4.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath4.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath4.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG4.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW5.Click
        Try
            If txtimgpath5.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath5.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath5.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG5.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW6.Click
        Try
            If txtimgpath6.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath6.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath6.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBIMG6.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtremarks.Validating
        Try
            If ClientName = "FINASTA" Then
                TabControl1.SelectedIndex = 2
                cmdupload1.Focus()
            Else
                TabControl1.SelectedIndex = 1
                TXTPASSPORTNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSPOUSE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSPOUSE.Validating
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 0
            chkdoa.Focus()
        Else
            TabControl1.SelectedIndex = 2
            cmdupload1.Focus()
        End If
    End Sub

    Private Sub GuestMaster_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FILLCMPNAME()
            If ClientName = "TRAVELBRIDGE" Then CHKCOMMON.CheckState = CheckState.Checked

            'GET DATA FROM MISCENQ WHERE GUESTNAME NOT PRESENT IN GUESTMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT MISC_GUESTNAME AS GUESTNAME ", "", "  MISCENQUIRY ", " AND MISC_YEARID = " & YearId & " AND MISC_GUESTNAME NOT IN (SELECT GUEST_NAME FROM GUESTMASTER WHERE GUEST_YEARID = " & YearId & ")")
            If DT.Rows.Count > 0 Then
                CMBENQ.DataSource = DT
                CMBENQ.DisplayMember = "GUESTNAME"
                CMBENQ.Text = ""
            End If


            GroupBox14.Text = "AADHAR CARD"
            GroupBox15.Text = "VOTING CARD"
            GroupBox13.Text = "PAN CARD"
            Label38.Text = "AADHAR CARD UPLOAD"
            Label39.Text = "VOTING CARD UPLOAD"
            Label37.Text = "PAN CARD UPLOAD"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim objform As New PrintBlankForm
            objform.MdiParent = MDIMain
            If edit = True And ClientName = "FINASTA" Then objform.STRSEARCH = " {GUESTMASTER.GUEST_NAME} = '" & TEMPGUESTNAME & "' AND {GUESTMASTER.GUEST_YEARID} = " & YearId
            objform.FRMSTRING = "GUESTFORM"
            objform.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTCATEGORY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTCATEGORY.Enter
        Try
            If CMBGUESTCATEGORY.Text.Trim = "" Then FILLGUESTCATEGORY(CMBGUESTCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTCATEGORY.Validating
        Try
            If CMBGUESTCATEGORY.Text.Trim <> "" Then GUESTCATEGORYVALIDATE(CMBGUESTCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        CMBPREFIX.Focus()
    End Sub

    Private Sub TXTCOPYID_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPYID.Validating
        Try
            'COPY GUEST DETAILS
            If Val(TXTCOPYID.Text.Trim) > 0 Then
                Dim OBJGUEST As New ClsGuestMaster
                Dim dttable As DataTable = OBJGUEST.COPYGUESTDETAILS(Val(TXTCOPYID.Text.Trim))
                If dttable.Rows.Count > 0 Then
                    TXTCOPYID.Enabled = False
                    TXTUNIQUENO.Text = Val(dttable.Rows(0).Item("UNIQUENO"))

                    CMBNAME.Text = dttable.Rows(0).Item("NAME").ToString
                    txtadd1.Text = dttable.Rows(0).Item("ADD1").ToString
                    txtadd2.Text = dttable.Rows(0).Item("ADD2").ToString

                    cmbarea.Text = dttable.Rows(0).Item("AREANAME").ToString
                    txtstd.Text = dttable.Rows(0).Item("STD").ToString
                    cmbcity.Text = dttable.Rows(0).Item("CITYNAME").ToString
                    txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString
                    cmbstate.Text = dttable.Rows(0).Item("STATENAME").ToString
                    cmbcountry.Text = dttable.Rows(0).Item("COUNTRYNAME").ToString

                    TXTMEMBERSHIPNO.Text = dttable.Rows(0).Item("MEMBERSHIPNO").ToString

                    txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
                    txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString
                    txttel1.Text = dttable.Rows(0).Item("PHONE").ToString
                    txtmobile.Text = dttable.Rows(0).Item("MOBILE").ToString
                    txtfax.Text = dttable.Rows(0).Item("FAX").ToString
                    txtwebsite.Text = dttable.Rows(0).Item("WEBSITE").ToString
                    cmbemail.Text = dttable.Rows(0).Item("EMAIL").ToString

                    CMBREF.Text = dttable.Rows(0).Item("REF").ToString
                    CMBNATIONALITY.Text = dttable.Rows(0).Item("NATIONALITY").ToString

                    If Convert.ToBoolean(dttable.Rows(0).Item("ISDOB")) = True Then
                        chkdob.CheckState = CheckState.Checked
                        DOB.Value = dttable.Rows(0).Item("DOB")
                    End If


                    If Convert.ToBoolean(dttable.Rows(0).Item("ISDOA")) = True Then
                        chkdoa.CheckState = CheckState.Checked
                        DOA.Value = dttable.Rows(0).Item("DOA")
                    End If

                    TXTPLACEOFBIRTH.Text = dttable.Rows(0).Item("PLACEOFBIRTH").ToString
                    txtadd.Text = dttable.Rows(0).Item("ADD").ToString
                    txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString

                    TXTDISPLAYNAME.Text = dttable.Rows(0).Item("ITSNO").ToString
                    TXTPASSPORTNAME.Text = dttable.Rows(0).Item("PASSPORTNAME").ToString
                    TXTPASSPORTNO.Text = dttable.Rows(0).Item("PASSPORTNO").ToString
                    ISSUEDATE.Value = dttable.Rows(0).Item("ISSUEDATE")
                    EXPIRYDATE.Value = dttable.Rows(0).Item("EXPIRYDATE")
                    TXTGIVENNAME.Text = dttable.Rows(0).Item("GIVENNAME").ToString
                    TXTSURNAME.Text = dttable.Rows(0).Item("SURNAME").ToString
                    CMBGENDER.Text = dttable.Rows(0).Item("GENDER").ToString
                    CMBSTATUS.Text = dttable.Rows(0).Item("STATUS").ToString
                    TXTPLACEOFISSUE.Text = dttable.Rows(0).Item("PLACEOFISSUE").ToString
                    CMBISSUECOUNTRY.Text = dttable.Rows(0).Item("COUNTRYOFISSUE").ToString
                    CMBPREFIX.Text = dttable.Rows(0).Item("PREFIX").ToString

                    TXTADULD.Text = dttable.Rows(0).Item("ADULT").ToString
                    TXTCHILD.Text = dttable.Rows(0).Item("CHILD").ToString
                    TXTINFANT.Text = dttable.Rows(0).Item("INFANT").ToString
                    TXTFATHER.Text = dttable.Rows(0).Item("FATHER").ToString
                    TXTMOTHER.Text = dttable.Rows(0).Item("MOTHER").ToString
                    TXTSPOUSE.Text = dttable.Rows(0).Item("SPOUSE").ToString

                    TXTREFFVIA.Text = dttable.Rows(0).Item("REFFVIA").ToString
                    CMBCORDINATORVIA.Text = dttable.Rows(0).Item("CORDINATORVIA").ToString
                    CMBGUESTCATEGORY.Text = dttable.Rows(0).Item("GUESTCATEGORY")

                    If dttable.Rows(0).Item("CHKPASSPORT").ToString = True Then
                        CHKPASSPORT.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKSAFAI").ToString = True Then
                        CHKSAFAI.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKITS").ToString = True Then
                        CHKITS.Checked = True
                    End If

                    If dttable.Rows(0).Item("CHKPHOTO").ToString = True Then
                        CHKPHOTO.Checked = True
                    End If

                    If Convert.ToBoolean(dttable.Rows(0).Item("GUEST")) = True Then
                        RDBGUEST.Checked = True
                    End If
                    If Convert.ToBoolean(dttable.Rows(0).Item("LEADER")) = True Then
                        RDBLEADER.Checked = True
                    End If
                    If Convert.ToBoolean(dttable.Rows(0).Item("CORDINATOR")) = True Then
                        RDBCORDINATOR.Checked = True
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        txtimgpath.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        PBIMG.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH1")) = False Then
                        PBIMG1.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH1"), Byte())))
                        txtimgpath1.Text = dttable.Rows(0).Item("IMGPATH1").ToString
                    Else
                        PBIMG1.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH2")) = False Then
                        PBIMG2.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH2"), Byte())))
                        txtimgpath2.Text = dttable.Rows(0).Item("IMGPATH2").ToString
                    Else
                        PBIMG2.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH3")) = False Then
                        PBIMG3.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH3"), Byte())))
                        txtimgpath3.Text = dttable.Rows(0).Item("IMGPATH3").ToString
                    Else
                        PBIMG3.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH4")) = False Then
                        PBIMG4.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH4"), Byte())))
                        txtimgpath4.Text = dttable.Rows(0).Item("IMGPATH4").ToString
                    Else
                        PBIMG4.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH5")) = False Then
                        PBIMG5.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH5"), Byte())))
                        txtimgpath5.Text = dttable.Rows(0).Item("IMGPATH5").ToString
                    Else
                        PBIMG5.Image = Nothing
                    End If

                    If IsDBNull(dttable.Rows(0).Item("IMGPATH6")) = False Then
                        PBIMG6.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH6"), Byte())))
                        txtimgpath6.Text = dttable.Rows(0).Item("IMGPATH6").ToString
                    Else
                        PBIMG6.Image = Nothing
                    End If

                Else
                    TXTCOPYID.Clear()
                    MsgBox("Invalid Unique No", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPYID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPYID.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGIVENNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGIVENNAME.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 0
            CMBNATIONALITY.Focus()
        End If
    End Sub

    Private Sub CMBNATIONALITY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNATIONALITY.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 0
            CMBGENDER.Focus()
        End If
    End Sub

    Private Sub CMBGENDER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGENDER.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 0
            chkdob.Focus()
        End If
    End Sub

    Private Sub DOB_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOB.Validated
        If ClientName = "FINASTA" Then
            TabControl1.SelectedIndex = 1
            TXTPLACEOFBIRTH.Focus()
        End If
    End Sub

    Private Sub CMDPRINTDOCS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINTDOCS.Click
        Try
            PRINTDOCS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTDOCS()
        Try
            If edit = True Then
                If MsgBox("Print Selected Docs?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                
                If CHKPRINTPASSPORT.CheckState = CheckState.Checked Then
                    Dim OBJPRINT As New PrintBlankForm
                    OBJPRINT.STRSEARCH = " {GUESTMASTER.GUEST_ID} = " & TEMPGUESTID
                    OBJPRINT.FRMSTRING = "PASSPORT"
                    OBJPRINT.MdiParent = MDIMain
                    OBJPRINT.Show()
                End If
                If CHKPRINTITS.CheckState = CheckState.Checked Then
                    Dim OBJPRINT As New PrintBlankForm
                    OBJPRINT.STRSEARCH = " {GUESTMASTER.GUEST_ID} = " & TEMPGUESTID
                    OBJPRINT.FRMSTRING = "ITSCOPY"
                    OBJPRINT.MdiParent = MDIMain
                    OBJPRINT.Show()
                End If
                If CHKPRINTSAFAI.CheckState = CheckState.Checked Then
                    Dim OBJPRINT As New PrintBlankForm
                    OBJPRINT.STRSEARCH = " {GUESTMASTER.GUEST_ID} = " & TEMPGUESTID
                    OBJPRINT.FRMSTRING = "SAFAICHITTI"
                    OBJPRINT.MdiParent = MDIMain
                    OBJPRINT.Show()
                End If
                
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLEDGERS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLEDGERS.Enter
        Try
            If CMBLEDGERS.Text.Trim = "" Then fillname(CMBLEDGERS, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLEDGERS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBLEDGERS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBLEDGERS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLEDGERS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBLEDGERS.Validated
        Try
            If CMBLEDGERS.Text.Trim <> "" Then
                Dim TEMPMSG As Integer = MsgBox("Copy Details of " & CMBLEDGERS.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(LEDGERS.Acc_id,0) AS ID, ISNULL(LEDGERS.Acc_cmpname,'') AS CMPNAME, ISNULL(LEDGERS.Acc_name,'') AS NAME, ISNULL(GROUPMASTER.group_name,'') AS GROUPNAME, ISNULL(LEDGERS.Acc_opbal,0) AS OPBAL, ISNULL(LEDGERS.Acc_drcr,0) AS DRCR, ISNULL(LEDGERS.Acc_add1,'') AS ADD1, ISNULL(LEDGERS.Acc_add2,'') AS ADD2, ISNULL(AREAMASTER.area_name, '') AS AREANAME, ISNULL(CITYMASTER.city_name, '') AS CITYNAME, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(LEDGERS.Acc_zipcode,0) AS ZIPCODE, ISNULL(COUNTRYMASTER.country_name, '') AS COUNTRYNAME, ISNULL(LEDGERS.Acc_std,0) AS STD, ISNULL(LEDGERS.Acc_resino,0) AS RESINO, ISNULL(LEDGERS.Acc_altno,0) AS ALTNO, ISNULL(LEDGERS.Acc_phone,0) AS PHONENO, ISNULL(LEDGERS.Acc_mobile,0) AS MOBILENO, ISNULL(LEDGERS.Acc_fax,0) AS FAXNO, ISNULL(LEDGERS.Acc_website,'') AS WEBSITE, ISNULL(LEDGERS.Acc_email,'') AS EMAILADD, ISNULL(LEDGERS.Acc_crdays,0) AS CRDAYS, ISNULL(LEDGERS.ACC_DOB, '') AS ACC_DOB, ISNULL(LEDGERS.ACC_TYPE, 'Agent') AS TYPE, ISNULL(REFLEDGERS.Acc_cmpname, '') AS REFBY, ISNULL(LEDGERS.ACC_MEMBERID, '') AS MEMBERID, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY, ISNULL(LEDGERS.ACC_EXPIRY, GETDATE()) AS EXPDATE, ISNULL(LEDGERS.ACC_OPPOINTS, 0) AS OPPOINTS, ISNULL(LEDGERS.ACC_ISLOCKED,0) AS LOCKED ", "", " GROUPMASTER RIGHT OUTER JOIN LEDGERS LEFT OUTER JOIN CATEGORYMASTER ON LEDGERS.ACC_MEMBERCATEGORYID = CATEGORYMASTER.CATEGORY_ID  LEFT OUTER JOIN LEDGERS AS REFLEDGERS ON LEDGERS.ACC_REFID = REFLEDGERS.Acc_id LEFT OUTER JOIN NATUREOFPAYMENTMASTER ON LEDGERS.ACC_NATUREID = NATUREOFPAYMENTMASTER.PAY_ID LEFT OUTER JOIN DEDUCTEETYPEMASTER INNER JOIN ACCOUNTSMASTER_TDS ON DEDUCTEETYPEMASTER.DEDUCTEETYPE_ID = ACCOUNTSMASTER_TDS.ACC_DEDUCTEETYPEID ON LEDGERS.Acc_id = ACCOUNTSMASTER_TDS.ACC_ID LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id ON GROUPMASTER.group_id = LEDGERS.Acc_groupid LEFT OUTER JOIN COUNTRYMASTER ON LEDGERS.Acc_countryid = COUNTRYMASTER.country_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN AREAMASTER ON LEDGERS.Acc_areaid = AREAMASTER.area_id", " AND LEDGERS.Acc_cmpname = '" & CMBLEDGERS.Text.Trim & "' AND LEDGERS.Acc_yearid = " & YearId)
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
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBENQ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBENQ.Validated
        Try
            If CMBENQ.Text.Trim <> "" And edit = False Then
                If MsgBox("Copy Data of " & CMBENQ.Text.Trim & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1  MISC_GUESTNAME AS GUESTNAME, MISC_MOBILENO AS MOBILENO, MISC_EMAILID AS EMAILID", "", " MISCENQUIRY ", " AND MISC_GUESTNAME = '" & CMBENQ.Text.Trim & "' AND MISC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    CMBNAME.Text = DT.Rows(0).Item("GUESTNAME")
                    txtmobile.Text = DT.Rows(0).Item("MOBILENO")
                    cmbemail.Text = DT.Rows(0).Item("EMAILID")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If TXTDISPLAYNAME.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then TXTDISPLAYNAME.Text = CMBNAME.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class