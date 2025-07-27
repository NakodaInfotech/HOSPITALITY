
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class HotelMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridContactDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPCONTACTROW As Integer
    Public edit As Boolean
    Public TEMPHOTELNAME As String
    Dim TEMPCODE As String
    Public TEMPHOTELID As Integer

    Private Sub pb1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb1.Click
        SETIMAGE(1)
    End Sub

    Private Sub pb2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb2.Click
        SETIMAGE(2)
    End Sub

    Sub SETIMAGE(ByVal I As Integer)
        Try
            pb1.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb2.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb3.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb4.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb5.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb6.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb7.Image = Global.HOSPITALITY.My.Resources.star_grey

            TXTGRADE.Text = I

            Select Case I
                Case 1
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 2
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 3
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 4
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 5
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 6
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb6.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 7
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb6.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb7.Image = Global.HOSPITALITY.My.Resources.star_yellow

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub pb3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb3.Click
        SETIMAGE(3)
    End Sub

    Private Sub pb4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb4.Click
        SETIMAGE(4)
    End Sub

    Private Sub pb5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb5.Click
        SETIMAGE(5)
    End Sub

    Private Sub pb6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb6.Click
        SETIMAGE(6)
    End Sub

    Private Sub pb7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pb7.Click
        SETIMAGE(7)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.U Then       'for UPLOAD
                Call cmdupload_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.R Then       'for REMOVE
                Call cmdremove_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                clear()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommon
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " AND AREA_YEARID = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_NAME", "", "CityMaster", " AND CITY_YEARID = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_NAME"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_NAME"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " AND COUNTRY_YEARID =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " AND STATE_YEARID =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

        dt = objclscommon.search("GROUPOFHOTELS_name", "", "GROUPOFHOTELSMASTER", " and GROUPOFHOTELS_cmpid = " & CmpId & " and GROUPOFHOTELS_LOCATIONid = " & Locationid & " and GROUPOFHOTELS_YEARid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "GROUPOFHOTELS_name"
            cmbgroupofhotels.DataSource = dt
            cmbgroupofhotels.DisplayMember = "GROUPOFHOTELS_name"
            cmbgroupofhotels.Text = ""
        End If

        If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        fillHOTELTYPE(CMBHOTELTYPE)
        fillROOMTYPE(cmbroomtype)
        FILLAMNETIES()

    End Sub

    Sub FILLAMNETIES()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("AMENITIES_ID AS ID,AMENITIES_NAME AS NAME", "", "AMENITIESMASTER", " AND AMENITIES_YEARID = " & YearId & " ORDER BY AMENITIES_NAME")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    'CHECKING WHETHER IT IS PRESENT IN GRID OR NOT
                    If GRIDAMNETIES.RowCount > 0 Then
                        For Each ROW As DataGridViewRow In GRIDAMNETIES.Rows
                            If ROW.Cells(GAMENITIES.Index).Value = DTROW("NAME") Then
                                GoTo LINE1
                            End If
                        Next
                    End If
                    GRIDAMNETIES.Rows.Add(0, DTROW("ID"), DTROW("NAME"))
LINE1:
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click


        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()

        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\ROOM IMAGES") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\ROOM IMAGES")

        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        TXTOURLOCATION.Text = Application.StartupPath & "\ROOM IMAGES\" & CMBHOTELNAME.Text.Trim & cmbroomtype.Text.Trim & TXTFILENAME.Text.Trim
        txtimgpath.Text = OpenFileDialog1.FileName

        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBIMG.ImageLocation = txtimgpath.Text.Trim
            txtsrno.Focus()
        End If

        'If gridroomdesc.RowCount > 0 Then
        '    UPLOADIMG(gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GROOMTYPE.Index).Value, gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GSRNO.Index).Value)
        'End If
    End Sub

    'Sub UPLOADIMG(ByVal ROOMTYPE As String, ByVal SRNO As Integer)
    '    OpenFileDialog1.Filter = "Pictures (*.pdf;*.doc;*.JPEG;*.JPG)|*.pdf;*.doc;*.jpeg;*.jpg"
    '    OpenFileDialog1.ShowDialog()

    '    txtimgpath.Text = OpenFileDialog1.FileName
    '    On Error Resume Next

    '    If txtimgpath.Text.Trim.Length <> 0 Then
    '        PBIMG.ImageLocation = txtimgpath.Text.Trim
    '        PBIMG.Load(txtimgpath.Text.Trim)

    '        'code to upload image on server (now just copy file locally)
    '        'Dim clsRequest As System.Net.FtpWebRequest = _
    '        '             DirectCast(System.Net.WebRequest.Create("ftp://ftp.hemindnet00.web705.discountasp.net/WO/" & txtsono.Text), System.Net.FtpWebRequest)
    '        'clsRequest.Credentials = New System.Net.NetworkCredential("0094814|hemindnet00", "infosys123")
    '        'clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

    '        '' read in file...
    '        ''Dim bFile() As Byte = System.IO.File.ReadAllBytes(gridupload.Rows(0).Cells(3).Value)
    '        'Dim bFile() As Byte = System.IO.File.ReadAllBytes(txtimgpath.Text.Trim)
    '        '' upload file...
    '        'Dim clsStream As System.IO.Stream = _
    '        '    clsRequest.GetRequestStream()
    '        'clsStream.Write(bFile, 0, bFile.Length)
    '        'clsStream.Close()
    '        'clsStream.Dispose()

    '        If System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files\") = False Then
    '            System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files")
    '        End If

    '        If System.IO.File.Exists(txtimgpath.Text.Trim) = True Then
    '            Dim EXTENSION As String = Path.GetExtension(txtimgpath.Text.Trim)
    '            If EXTENSION <> ".pdf" Then
    '                System.IO.File.Copy(txtimgpath.Text.Trim, System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\" & CMBHOTELNAME.Text.Trim & " " & ROOMTYPE & " " & SRNO & EXTENSION, True)
    '                MsgBox("File Uploaded Successfully", MsgBoxStyle.OkOnly, "TRAVELMATE")
    '            Else
    '                PBIMG.Load(System.AppDomain.CurrentDomain.BaseDirectory & "PDF.jpg")
    '            End If
    '        End If

    '        gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(gimgpath.Index).Value = txtimgpath.Text.Trim

    '    End If
    'End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            PBIMG.ImageLocation = ""
            txtimgpath.Clear()
            TXTOURLOCATION.Clear()
            TXTFILENAME.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If CHKCOMMON.CheckState = CheckState.Unchecked Then
                If edit = False Then SAVEUPDATE(CmpId, YearId, 0) Else SAVEUPDATE(CmpId, YearId, TEMPHOTELID)
            Else
                Dim OBJCMN As New ClsCommon
                Dim DTCMP As DataTable = OBJCMN.search("YEAR_CMPID AS CMPID, YEAR_ID AS YEARID ", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(Convert.ToDateTime(AccFrom.Date), "MM/dd/yyyy") & "' ORDER BY YEAR_ID")
                For Each DTROW As DataRow In DTCMP.Rows

                    Dim DTTEMP As DataTable
                    Dim OBJYEAR As New ClsYearMaster

                    'CHECK HOTELTYPE
                    DTTEMP = OBJCMN.search("HOTELTYPE_id", "", "HOTELTYPEMaster", " and HOTELTYPE_NAME = '" & CMBHOTELTYPE.Text.Trim & "' and HOTELTYPE_YEARid = " & Val(DTROW("YearId")))
                    If DTTEMP.Rows.Count = 0 Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(CMBHOTELTYPE.Text.Trim)
                        alParaval.Add("")   'REMARKS
                        alParaval.Add(DTROW("CMPID"))
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(DTROW("YearId"))
                        alParaval.Add(0)
                        Dim objclsHOTELTYPE As New ClsHotelTypeMaster
                        objclsHOTELTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsHOTELTYPE.SAVE()
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


                    'GROUP OF HOTELS
                    DTTEMP = OBJCMN.search("GROUPOFHOTELS_ID AS GROUPID", "", "GROUPOFHOTELSMASTER ", " AND GROUPOFHOTELS_NAME = '" & cmbgroupofhotels.Text.Trim & "' AND GROUPOFHOTELS_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(cmbgroupofhotels.Text.Trim)
                        alParaval.Add("")   'REMARKS
                        alParaval.Add(DTROW("CMPID"))
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(DTROW("YearId"))
                        alParaval.Add(0)
                        Dim OBJ As New ClsGroupOfHotelsMaster
                        OBJ.alParaval = alParaval
                        Dim IntResult As Integer = OBJ.SAVE()
                    End If



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


                    'CHECK ROOMTYPE IN GRID LOOP
                    For Each ROW As DataGridViewRow In gridroomdesc.Rows
                        DTTEMP = OBJCMN.search("ROOMTYPE_id", "", "ROOMTYPEMaster", " and ROOMTYPE_NAME = '" & ROW.Cells(GROOMTYPE.Index).Value & "' and ROOMTYPE_YEARid = " & Val(DTROW("YearId")))
                        If DTTEMP.Rows.Count = 0 Then
                            Dim alParaval As New ArrayList
                            alParaval.Add(ROW.Cells(GROOMTYPE.Index).Value)
                            alParaval.Add("")   'REMARKS
                            alParaval.Add(DTROW("CMPID"))
                            alParaval.Add(0)
                            alParaval.Add(Userid)
                            alParaval.Add(DTROW("YearId"))
                            alParaval.Add(0)
                            Dim objclsROOMTYPE As New ClsRoomTypeMaster
                            objclsROOMTYPE.alParaval = alParaval
                            Dim IntResult As Integer = objclsROOMTYPE.SAVE()
                        End If
                    Next


                    If edit = False Then
                        If YearId <> DTROW("YEARID") Then
                            DTTEMP = OBJCMN.search("HOTEL_ID AS HOTELID", "", "HOTELMASTER", " AND HOTEL_NAME= '" & CMBHOTELNAME.Text.Trim & "' AND HOTEL_YEARID = " & Val(DTROW("YEARID")))
                            If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE
                        End If
                        SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), 0)
                    Else
                        'FIRST GET THE ACCOUNTID FROM YEARID AND THEN PASS IT IN THE UPDATE QUERY
                        DTTEMP = OBJCMN.search("HOTEL_ID AS HOTELID", "", "HOTELMASTER", " AND HOTEL_NAME = '" & TEMPHOTELNAME & "' AND HOTEL_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), Val(DTTEMP.Rows(0).Item("HOTELID")))
                    End If
NEXTLINE:
                Next
            End If


            If edit = False Then MsgBox("Details Added") Else MsgBox("Details Updated")
            clear()
            TEMPHOTELNAME = ""
            edit = False
            CMBHOTELNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SAVEUPDATE(ByVal TCMPID As Integer, ByVal TYEARID As Integer, ByVal THOTELID As Integer)
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBHOTELNAME.Text.Trim)
            alParaval.Add(CMBHOTELTYPE.Text.Trim)
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbcode.Text.Trim)
            alParaval.Add(TXTGRADE.Text.Trim)
            alParaval.Add(cmbgroupofhotels.Text.Trim)
            alParaval.Add(txtcheckin.Text.Trim)
            alParaval.Add(txtcheckout.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)
            alParaval.Add(TCMPID)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(TYEARID)
            alParaval.Add(0)


            Dim AMENITIESID As String = ""
            For Each row As Windows.Forms.DataGridViewRow In GRIDAMNETIES.Rows
                If Convert.ToBoolean(row.Cells(GCHK.Index).Value) = True Then
                    If AMENITIESID = "" Then
                        AMENITIESID = row.Cells(GID.Index).Value
                    Else
                        AMENITIESID = AMENITIESID & "|" & row.Cells(GID.Index).Value
                    End If
                End If
            Next

            alParaval.Add(AMENITIESID)


            Dim GRIDSRNO As String = ""
            Dim ROOMTYPE As String = ""
            Dim NOOFROOMS As String = ""
            Dim rate As String = ""
            Dim IMGPATH As String = ""
            Dim NEWIMGPATH As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridroomdesc.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        ROOMTYPE = row.Cells(GROOMTYPE.Index).Value
                        NOOFROOMS = row.Cells(GNOOFROOMS.Index).Value.ToString
                        rate = row.Cells(GRATE.Index).Value
                        IMGPATH = row.Cells(gimgpath.Index).Value
                        NEWIMGPATH = row.Cells(GOURIMGPATH.Index).Value.ToString

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                        ROOMTYPE = ROOMTYPE & "|" & row.Cells(GROOMTYPE.Index).Value
                        NOOFROOMS = NOOFROOMS & "|" & row.Cells(GNOOFROOMS.Index).Value.ToString
                        rate = rate & "|" & row.Cells(GRATE.Index).Value
                        IMGPATH = IMGPATH & "|" & row.Cells(gimgpath.Index).Value
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GOURIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(NOOFROOMS)
            alParaval.Add(rate)
            alParaval.Add(IMGPATH)
            alParaval.Add(NEWIMGPATH)



            Dim CNAME As String = ""
            Dim DESIGNATION As String = ""
            Dim CMOB As String = ""
            Dim CEMAIL As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONTACT.Rows
                If row.Cells(GNAME.Index).Value <> Nothing Then
                    If CNAME = "" Then

                        CNAME = row.Cells(GNAME.Index).Value.ToString
                        DESIGNATION = row.Cells(GDESIGNATION.Index).Value
                        CMOB = row.Cells(GMOBILENO.Index).Value.ToString
                        CEMAIL = row.Cells(GEMAIL.Index).Value

                    Else

                        CNAME = CNAME & "|" & row.Cells(GNAME.Index).Value.ToString
                        DESIGNATION = DESIGNATION & "|" & row.Cells(GDESIGNATION.Index).Value
                        CMOB = CMOB & "|" & row.Cells(GMOBILENO.Index).Value.ToString
                        CEMAIL = CEMAIL & "|" & row.Cells(GEMAIL.Index).Value

                    End If
                End If
            Next

            alParaval.Add(CNAME)
            alParaval.Add(DESIGNATION)
            alParaval.Add(CMOB)
            alParaval.Add(CEMAIL)
            alParaval.Add(CHKINVENTORY.Checked)
            alParaval.Add(CHKBLOCKED.CheckState)

            Dim OBJHOTEL As New ClsHotelMaster
            OBJHOTEL.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJHOTEL.save()
                'MsgBox("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(THOTELID)
                IntResult = OBJHOTEL.update()
                'MsgBox("Details Updated")

            End If


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridroomdesc.Rows
                If ROW.Cells(gimgpath.Index).Value <> "" Then
                    If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\ROOM IMAGES") = False Then
                        FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\ROOM IMAGES")
                    End If
                    If FileIO.FileSystem.FileExists(Application.StartupPath & "\ROOM IMAGES") = False Then
                        System.IO.File.Copy(ROW.Cells(gimgpath.Index).Value, ROW.Cells(GOURIMGPATH.Index).Value, True)
                    End If
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        CHKINVENTORY.CheckState = CheckState.Unchecked
        CMBHOTELNAME.Text = ""
        CMBHOTELTYPE.Text = ""
        SETIMAGE(0)
        txtname.Clear()
        cmbcode.Text = ""
        cmbgroupofhotels.Text = ""
        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()

        cmbarea.Text = ""
        txtstd.Clear()
        cmbcity.Text = ""
        txtzipcode.Clear()
        cmbcountry.Text = ""
        cmbstate.Text = ""

        txtaltno.Clear()
        cmbemail.Text = ""
        txtfax.Clear()
        txtmobile.Clear()
        txttel1.Clear()
        txtwebsite.Clear()

        txtsrno.Clear()
        cmbroomtype.Text = ""
        txtnoofrooms.Clear()
        txtrate.Clear()
        txtimgpath.Clear()

        GRIDAMNETIES.RowCount = 0
        FILLAMNETIES()
        gridroomdesc.RowCount = 0

        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        TXTFILENAME.Clear()
        PBIMG.ImageLocation = ""

        'GRID TXTBOXES
        TXTCNAME.Clear()
        CMBDESIGNATION.Text = ""
        TXTCMOB.Clear()
        TXTCEMAIL.Clear()
        GRIDCONTACT.RowCount = 0
        gridDoubleClick = False
        gridContactDoubleClick = False

        CHKBLOCKED.CheckState = CheckState.Unchecked
        edit = False

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBHOTELNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBHOTELNAME, "Fill Hotel Name")
            bln = False
        End If

        If ClientName = "TRAVELBRIDGE" And cmbstate.Text.Trim.Length = 0 Then
            EP.SetError(cmbstate, "Select State")
            bln = False
        End If


        If cmbcode.Text.Trim.Length = 0 Then
            EP.SetError(cmbcode, "Fill Hotel Code")
            bln = False
        End If

        If cmbcity.Text.Trim.Length = 0 Then
            EP.SetError(cmbcity, "Select City Name")
            bln = False
        End If

        If gridroomdesc.RowCount = 0 Then
            EP.SetError(txtrate, "Enter Room Details")
            bln = False
        End If

        If txtadd.Text.Trim.Length = 0 Then
            EP.SetError(txtadd, "Fill Address")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If txtmobile.Text.Trim.Length = 0 Then
                EP.SetError(txtmobile, "Enter Contact No.")
                bln = False
            End If
        Else
            If txttel1.Text.Trim.Length = 0 Then
                EP.SetError(txttel1, "Enter Contact No.")
                bln = False
            End If
        End If
        Return bln
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True And CMBHOTELNAME.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJHOTEL As New ClsHotelMaster
                Dim DT As DataTable

                ALPARAVAL.Add(TEMPHOTELNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                OBJHOTEL.alParaval = ALPARAVAL

                Dim tempmsg As Integer = MsgBox("Delete Area Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJHOTEL.DELETE() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOTEL MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            If ClientName = "TRAVELBRIDGE" Then CHKCOMMON.CheckState = CheckState.Checked

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim dttable As New DataTable
                Dim objhotel As New ClsHotelMaster

                objhotel.alParaval.Add(TEMPHOTELNAME)
                objhotel.alParaval.Add(CmpId)
                objhotel.alParaval.Add(Locationid)
                objhotel.alParaval.Add(YearId)

                dttable = objhotel.getHOTEL()

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        TEMPHOTELID = ROW("HOTELID")

                        CHKINVENTORY.Checked = Convert.ToBoolean(ROW("INVENTORY"))

                        CMBHOTELNAME.Text = ROW("HOTELNAME")
                        CMBHOTELTYPE.Text = ROW("HOTELTYPE")
                        txtname.Text = ROW("PERSON")
                        cmbcode.Text = ROW("CODE")
                        TEMPCODE = ROW("CODE")
                        SETIMAGE(ROW("GRADE"))
                        cmbgroupofhotels.Text = ROW("GROUPOFHOTELS")
                        txtcheckin.Text = ROW("CHECKIN")
                        txtcheckout.Text = ROW("CHECKOUT")
                        txtadd.Text = ROW("ADD")
                        txtadd1.Text = ROW("ADD1")
                        txtadd2.Text = ROW("ADD2")
                        cmbarea.Text = ROW("AREA")
                        txtstd.Text = ROW("STD")
                        cmbcity.Text = ROW("CITY")
                        txtzipcode.Text = ROW("ZIPCODE")
                        cmbstate.Text = ROW("STATE")
                        cmbcountry.Text = ROW("COUNTRY")
                        txtaltno.Text = ROW("ALTNO")
                        txttel1.Text = ROW("PHONENO")
                        txtmobile.Text = ROW("MOBILENO")
                        txtfax.Text = ROW("FAXNO")
                        txtwebsite.Text = ROW("WEBSITE")
                        cmbemail.Text = ROW("EMAILID")
                        If ROW("GRIDSRNO") <> 0 Then gridroomdesc.Rows.Add(ROW("GRIDSRNO"), ROW("ROOMTYPE"), ROW("NOOFROOMS"), ROW("RATE"), ROW("IMGPATH"), ROW("NEWIMGPATH"))

                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                    Next

                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("AMENITIESMASTER.AMENITIES_ID AS AMENITIESID, AMENITIESMASTER.AMENITIES_NAME AS AMENITIES", "", "HOTELMASTER_AMENITIES INNER JOIN AMENITIESMASTER ON HOTELMASTER_AMENITIES.HOTEL_AMENITIESID = AMENITIESMASTER.AMENITIES_ID AND HOTELMASTER_AMENITIES.HOTEL_CMPID = AMENITIESMASTER.AMENITIES_CMPID AND HOTELMASTER_AMENITIES.HOTEL_LOCATIONID = AMENITIESMASTER.AMENITIES_LOCATIONID AND HOTELMASTER_AMENITIES.HOTEL_YEARID = AMENITIESMASTER.AMENITIES_YEARID INNER JOIN HOTELMASTER ON HOTELMASTER_AMENITIES.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELMASTER_AMENITIES.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_AMENITIES.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_AMENITIES.HOTEL_ID = HOTELMASTER.HOTEL_ID", " AND HOTELMASTER.HOTEL_NAME = '" & TEMPHOTELNAME & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            For Each row As DataGridViewRow In GRIDAMNETIES.Rows
                                If row.Cells(GAMENITIES.Index).Value = DTR("AMENITIES") Then row.Cells(GCHK.Index).Value = True
                            Next
                        Next
                    End If

                    DT = OBJCMN.search("  HOTELMASTER_CONTACTDESC.HOTEL_CONTACT AS NAME, DESIGNATIONMASTER.DESIGNATION_NAME AS DESIGNATION, HOTELMASTER_CONTACTDESC.HOTEL_MOBILENO AS MOBILENO, HOTELMASTER_CONTACTDESC.HOTEL_EMAIL AS EMAIL ", "", " DESIGNATIONMASTER INNER JOIN HOTELMASTER_CONTACTDESC ON DESIGNATIONMASTER.DESIGNATION_ID = HOTELMASTER_CONTACTDESC.HOTEL_DESIGNATIONID AND DESIGNATIONMASTER.DESIGNATION_CMPID = HOTELMASTER_CONTACTDESC.HOTEL_CMPID AND DESIGNATIONMASTER.DESIGNATION_LOCATIONID = HOTELMASTER_CONTACTDESC.HOTEL_LOCATIONID AND DESIGNATIONMASTER.DESIGNATION_YEARID = HOTELMASTER_CONTACTDESC.HOTEL_YEARID", " AND HOTEL_ID = " & TEMPHOTELID & " AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDCONTACT.Rows.Add(DTR("NAME"), DTR("DESIGNATION"), DTR("MOBILENO"), DTR("EMAIL"))
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex
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

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
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
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then
                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
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
            If cmbcountry.Text = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
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
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
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

    Private Sub cmbemail_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbemail.Enter
        Try
            If cmbemail.Text.Trim = "" Then FILLEMAIL(cmbemail)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroupofhotels_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroupofhotels.Enter
        Try
            If cmbgroupofhotels.Text.Trim = "" Then FILLGROUPOFHOTELS(cmbgroupofhotels)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbemail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbemail.Validating
        Try
            If cmbemail.Text.Trim <> "" Then EMAILVALIDATE(cmbemail, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroupofhotels_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroupofhotels.Validating
        Try
            If cmbgroupofhotels.Text.Trim <> "" Then GROUPOFHOTELSVALIDATE(cmbgroupofhotels, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTELNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBHOTELNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                pcase(CMBHOTELNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBHOTELNAME.Text) <> LCase(TEMPHOTELNAME)) Then
                    dt = objclscommon.search("HOTEL_name", "", "HOTELMaster", " and HOTEL_name = '" & CMBHOTELNAME.Text.Trim & "' And HOTEL_cmpid = " & CmpId & " And HOTEL_locationid = " & Locationid & " And HOTEL_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Hotel Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELTYPE.Enter
        Try
            If CMBHOTELTYPE.Text.Trim = "" Then fillHOTELTYPE(CMBHOTELTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELTYPE.Validating
        Try
            If CMBHOTELTYPE.Text.Trim <> "" Then HOTELTYPEVALIDATE(CMBHOTELTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbroomtype_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbroomtype.Enter
        Try
            If cmbroomtype.Text.Trim = "" Then fillROOMTYPE(cmbroomtype)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbroomtype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbroomtype.Validating
        Try
            If cmbroomtype.Text.Trim <> "" Then ROOMTYPEVALIDATE(cmbroomtype, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridroomdesc.RowCount > 0 Then
                txtsrno.Text = Val(gridroomdesc.Rows(gridroomdesc.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try

            If cmbroomtype.Text.Trim <> "" And Val(txtnoofrooms.Text.Trim) > 0 Then
                EP.Clear()
                If Not CHECKROOM() Then
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

    Function CHECKROOM() As Boolean
        Try
            Dim BLN As Boolean = True

            For Each ROW As DataGridViewRow In gridroomdesc.Rows
                If (ROW.Cells(GROOMTYPE.Index).Value = cmbroomtype.Text.Trim And gridDoubleClick = False) Or (gridDoubleClick = True And temprow <> Val(ROW.Index)) Then
                    EP.SetError(txtrate, "Room Type Already Present in Grid Below")
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
            gridroomdesc.Rows.Add(Val(txtsrno.Text.Trim), cmbroomtype.Text.Trim, Val(txtnoofrooms.Text.Trim), Val(txtrate.Text.Trim), txtimgpath.Text.Trim, TXTOURLOCATION.Text.Trim)
            getsrno(gridroomdesc)
        ElseIf gridDoubleClick = True Then

            gridroomdesc.Item(0, temprow).Value = txtsrno.Text.Trim
            gridroomdesc.Item(1, temprow).Value = cmbroomtype.Text.Trim
            gridroomdesc.Item(2, temprow).Value = txtnoofrooms.Text.Trim
            gridroomdesc.Item(3, temprow).Value = txtrate.Text.Trim
            gridroomdesc.Item(4, temprow).Value = txtimgpath.Text.Trim
            gridroomdesc.Item(GOURIMGPATH.Index, temprow).Value = TXTOURLOCATION.Text.Trim

            gridDoubleClick = False

        End If
        gridroomdesc.FirstDisplayedScrollingRowIndex = gridroomdesc.RowCount - 1

        txtsrno.Clear()
        cmbroomtype.Text = ""
        txtnoofrooms.Clear()
        txtrate.Clear()
        txtimgpath.Clear()
        TXTOURLOCATION.Clear()
        TXTFILENAME.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub gridroomdesc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridroomdesc.CellClick
        On Error Resume Next
        If gridroomdesc.RowCount > 0 Then
            PBIMG.ImageLocation = ""
            If gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value)
            ElseIf gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value)
            End If
        End If
    End Sub

    Private Sub gridroomdesc_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridroomdesc.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridroomdesc.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                txtsrno.Text = gridroomdesc.Item(GSRNO.Index, e.RowIndex).Value
                cmbroomtype.Text = gridroomdesc.Item(GROOMTYPE.Index, e.RowIndex).Value
                txtnoofrooms.Text = gridroomdesc.Item(GNOOFROOMS.Index, e.RowIndex).Value.ToString
                txtrate.Text = gridroomdesc.Item(GRATE.Index, e.RowIndex).Value.ToString
                txtimgpath.Text = gridroomdesc.Item(gimgpath.Index, e.RowIndex).Value.ToString
                TXTOURLOCATION.Text = gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value
                temprow = e.RowIndex
                txtsrno.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridroomdesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridroomdesc.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridroomdesc.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                If FileIO.FileSystem.FileExists(gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GOURIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GOURIMGPATH.Index).Value)
                gridroomdesc.Rows.RemoveAt(gridroomdesc.CurrentRow.Index)
                getsrno(gridroomdesc)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDAMNETIES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAMNETIES.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDAMNETIES.Rows(e.RowIndex).Cells(GCHK.Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcode.Enter
        Try
            If cmbcode.Text.Trim = "" Then fillHOTELCODE(cmbcode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcode.Validating
        Try
            If cmbcode.Text.Trim <> "" Then
                uppercase(cmbcode)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(cmbcode.Text) <> LCase(TEMPCODE)) Then
                    dt = objclscommon.search("HOTEL_CODE", "", "HOTELMaster", " and HOTEL_CODE = '" & cmbcode.Text.Trim & "' And HOTEL_cmpid = " & CmpId & " And HOTEL_locationid = " & Locationid & " And HOTEL_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Hotel Code Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridroomdesc_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridroomdesc.RowEnter

        On Error Resume Next
        If gridroomdesc.RowCount > 0 Then
            PBIMG.ImageLocation = ""
            If gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value)
            ElseIf gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value)
            End If
        End If
    End Sub

    Private Sub CMDADDAMN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDAMN.Click
        Try
            Dim OBJROOMTYPE As New RoomTypeMaster
            OBJROOMTYPE.MdiParent = MDIMain
            OBJROOMTYPE.FRMSTRING = "AMENITIES"
            OBJROOMTYPE.Show()
            OBJROOMTYPE.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLAMNETIES()
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
            GRIDCONTACT.Rows.Add(TXTCNAME.Text.Trim, CMBDESIGNATION.Text.Trim, TXTCMOB.Text.Trim, TXTCEMAIL.Text.Trim)
            'getsrno(GRIDCONTACT)
        ElseIf gridContactDoubleClick = True Then

            GRIDCONTACT.Item(0, TEMPCONTACTROW).Value = TXTCNAME.Text.Trim
            GRIDCONTACT.Item(1, TEMPCONTACTROW).Value = CMBDESIGNATION.Text.Trim
            GRIDCONTACT.Item(2, TEMPCONTACTROW).Value = TXTCMOB.Text.Trim
            GRIDCONTACT.Item(3, TEMPCONTACTROW).Value = TXTCEMAIL.Text.Trim

            gridContactDoubleClick = False

        End If
        GRIDCONTACT.FirstDisplayedScrollingRowIndex = GRIDCONTACT.RowCount - 1

        TXTCNAME.Clear()
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

    Private Sub HotelMaster_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            GBMAIN.Left = (Me.Width - GBMAIN.Width) / 2
            GBMAIN.Top = (Me.Height - GBMAIN.Height) / 2 - 10
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCNAME.Validated
        Try
            pcase(TXTCNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdotkeypress(e, txtrate, Me)
    End Sub

    Private Sub txtnoofrooms_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnoofrooms.KeyPress
        numkeypress(e, txtnoofrooms, Me)
    End Sub

    Private Sub CMBHOTELNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Validated
        Try
            If edit = False Then
                cmbcode.Text = CMBHOTELNAME.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TRAVELBRIDGE" Then
                CHKCOMMON.Checked = True
                LBLFAX.Text = "Ratings"
                cmbstate.BackColor = Color.LemonChiffon
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class