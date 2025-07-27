Imports BL
Imports System.IO
Imports System.Drawing
Imports System.ComponentModel

Public Class Cmpmaster

    Public edit As Boolean
    Public TEMPCMPNAME As String

    Private Sub cmdleave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdleave.Click
        End
    End Sub

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Try
            Ep.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If
            Dim arrparameter As New ArrayList
            CmpName = txtcmpname.Text
            CmpName = CmpName.Replace(" ", "")

            arrparameter.Add(txtcmpname.Text.Trim)
            arrparameter.Add(txtlegalname.Text.Trim)

            If rbprop.Checked = True Then
                arrparameter.Add("Proprietor")
            ElseIf rbpartner.Checked = True Then
                arrparameter.Add("Director")
            ElseIf rbautho.Checked = True Then
                arrparameter.Add("Authorised Signatory")
            ElseIf rbpropautho.Checked = True Then
                arrparameter.Add("Proprietor/Authorised Sign.")
            Else
                arrparameter.Add("Partner/Authorised Sign.")
            End If

            arrparameter.Add(txtdisplayedname.Text.Trim)
            arrparameter.Add(txtinvinitials.Text.Trim)
            arrparameter.Add(txtinvfooter.Text.Trim)
            arrparameter.Add(txtadd1.Text.Trim)
            arrparameter.Add(txtadd2.Text.Trim)
            arrparameter.Add(cmbcity.Text.Trim)
            arrparameter.Add(txtzipcode.Text.Trim)
            arrparameter.Add(cmbstate.Text.Trim)
            arrparameter.Add(cmbcountry.Text.Trim)
            arrparameter.Add(txttel1.Text.Trim)
            arrparameter.Add(txtfax.Text.Trim)
            arrparameter.Add(txtemail.Text.Trim)
            arrparameter.Add(txtwebsite.Text.Trim)

            Dim imagepath As String
            imagepath = PBIMG.ImageLocation
            If imagepath = Nothing Then imagepath = ""

            arrparameter.Add(txtimgpath.Text.Trim)
            arrparameter.Add(TXTOURLOCATION.Text.Trim)

            arrparameter.Add(Val(TXTWIDTH.Text))
            arrparameter.Add(Val(TXTHEIGHT.Text))
            arrparameter.Add(CMBCURRENCY.Text.Trim)
            arrparameter.Add(CHKGST.CheckState)
            arrparameter.Add(CHKAPPLYCESS.CheckState)
            arrparameter.Add(CHKSTATE.CheckState)

            CmpExciseInf.alParaval = arrparameter
            CmpExciseInf.EDIT = edit
            CmpExciseInf.TEMPCMPNAME = TEMPCMPNAME
            Me.Hide()
            CmpExciseInf.TEMPSTATENAME = cmbstate.Text.Trim
            CmpExciseInf.ShowDialog()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtcmpname.Text.Trim.Length = 0 Then
            Ep.SetError(txtcmpname, "Enter Company Name")
            bln = False
        End If

        If txtdisplayedname.Text.Trim.Length = 0 Then
            Ep.SetError(txtdisplayedname, "Fill Displayed Name")
            bln = False
        End If

        If txtinvfooter.Text.Trim.Length = 0 Then
            Ep.SetError(txtinvfooter, "Enter Invoice Footer")
            bln = False
        End If

        If CMBCURRENCY.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCURRENCY, "Fill Currency")
            bln = False
        End If

        If txtadd1.Text.Trim.Length = 0 Then
            Ep.SetError(txtadd1, "Fill Address1")
            bln = False
        End If

        If cmbcity.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcity, "Select City")
            bln = False
        End If

        If cmbstate.Text.Trim.Length = 0 Then
            Ep.SetError(cmbstate, "Select State")
            bln = False
        End If

        If cmbcountry.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcountry, "Select Country")
            bln = False
        End If
        Return bln
    End Function

    Private Sub txtlegalname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlegalname.Validated
        pcase(txtlegalname)
    End Sub

    Private Sub txtadd1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadd1.Validated
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtadd2.Validated
        pcase(txtadd2)
    End Sub

    Private Sub txtcmpname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcmpname.Validating
        Try
            If (edit = False) Or (edit = True And TEMPCMPNAME <> txtcmpname.Text.Trim) Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("cmp_name", "", "CmpMaster", " and cmp_name = '" & txtcmpname.Text.Trim & "'")
                If dt.Rows.Count > 0 Then
                    MsgBox("Company Name Already Exists", MsgBoxStyle.Critical, "")
                    e.Cancel = True
                End If
                txtdisplayedname.Text = txtcmpname.Text.Trim
                txtinvfooter.Text = "FOR " & txtcmpname.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("city_name", "", "CityMaster")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim OBJCMN As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = OBJCMN.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
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

    Private Sub cmbstate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.Enter
        Try
            If cmbstate.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("state_name", "", "StateMaster")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then
                pcase(cmbstate)
                Dim OBJCMN As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = OBJCMN.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
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

    Private Sub cmbcountry_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.Enter
        Try
            If cmbcountry.Text = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("country_name", "", "CountryMaster")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim OBJCMN As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = OBJCMN.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
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

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub Cmpmaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New Cmpdetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cmpmaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If edit = True Then
                Dim objcmn As New ClsCommon
                Dim dt As DataTable = objcmn.search("CMP_NAME, CMP_PERSON, CMP_PERSONTYPE, CMP_DISPLAYEDNAME, CMP_INVINITIALS, CMP_INVFOOTER, CMP_ADD1, CMP_ADD2, CITYMASTER.CITY_NAME,CMP_ZIPCODE, STATEMASTER.STATE_NAME, COUNTRYMASTER.COUNTRY_NAME, CMP_TEL, CMP_FAX, CMP_EMAIL, CMP_WEBSITE, ISNULL(CMP_IMGPATH,'') AS IMGPATH, ISNULL(CMP_OURLOCATION,'') AS OURLOCATION,  CAST(CMP_LOGO AS VARBINARY(MAX)) AS LOGO, ISNULL(CMP_WIDTH,0) AS WIDTH, ISNULL(CMP_HEIGHT,0) AS HEIGHT, ISNULL(CUR_CODE,'') AS CURRENCY, ISNULL(CMP_ALLOWGST,0) AS ALLOWGST, ISNULL(CMP_APPLYCESS,0) AS APPLYCESS, ISNULL(CMP_SAMESTATE,0) AS SAMESTATE", "", "CMPMASTER LEFT OUTER JOIN CITYMASTER ON CITYMASTER.CITY_ID = CMPMASTER.CMP_CITYID LEFT OUTER JOIN COUNTRYMASTER ON COUNTRYMASTER.COUNTRY_ID = CMPMASTER.CMP_COUNTRYID LEFT OUTER JOIN STATEMASTER ON STATEMASTER.STATE_ID = CMPMASTER.CMP_STATEID LEFT OUTER JOIN CURRENCYMASTER ON CMP_CURID = CURRENCYMASTER.CUR_ID ", " AND CMPMASTER.CMP_NAME = '" & TEMPCMPNAME & "'")

                Dim DTROW As DataRow = dt.Rows(0)

                txtcmpname.Text = DTROW(0).ToString
                txtlegalname.Text = DTROW(1).ToString

                If DTROW(2) = "Proprietor" Then
                    rbprop.Checked = True
                ElseIf DTROW(2) = "Authorised Signatory" Then
                    rbautho.Checked = True
                ElseIf DTROW(2) = "Director" Then
                    rbpartner.Checked = True
                ElseIf DTROW(2) = "Proprietor/Authorised Sign." Then
                    rbpropautho.Checked = True
                ElseIf DTROW(2) = "Partner/Authorised Sign." Then
                    RBPARTNERAUTHO.Checked = True
                End If


                txtdisplayedname.Text = DTROW(3).ToString
                txtinvinitials.Text = DTROW(4).ToString
                txtinvfooter.Text = DTROW(5).ToString
                txtadd1.Text = DTROW(6).ToString
                txtadd2.Text = DTROW(7).ToString
                cmbcity.Text = DTROW(8).ToString
                txtzipcode.Text = DTROW(9).ToString
                cmbstate.Text = DTROW(10).ToString
                cmbcountry.Text = DTROW(11).ToString
                txttel1.Text = DTROW(12).ToString
                txtfax.Text = DTROW(13).ToString
                txtemail.Text = DTROW(14).ToString
                txtwebsite.Text = DTROW(15).ToString


                'Dim bImage As Byte() = New Byte(-1) {}

                'bImage = DirectCast(DTROW("LOGO"), Byte())
                'Dim ms As New MemoryStream(bImage)
                'PBIMG.Image = Image.FromStream(ms)


                txtimgpath.Text = DTROW("IMGPATH").ToString
                TXTOURLOCATION.Text = DTROW("OURLOCATION").ToString

                GETIMG()


                TXTWIDTH.Text = Val(DTROW("WIDTH"))
                TXTHEIGHT.Text = Val(DTROW("HEIGHT"))
                CMBCURRENCY.Text = DTROW("CURRENCY")
                CHKGST.Checked = Convert.ToBoolean(DTROW("ALLOWGST"))
                CHKAPPLYCESS.Checked = Convert.ToBoolean(DTROW("APPLYCESS"))
                CHKSTATE.Checked = Convert.ToBoolean(DTROW("SAMESTATE"))

            End If
        Catch ex As Exception
            Throw ex
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

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.PNG;*.bmp;*.JPEG;*.JPG)|*.png;*.bmp;*.jpeg;*.jpg"
        OpenFileDialog1.ShowDialog()

        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\COMPANY_LOGO") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\COMPANY_LOGO")
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        TXTOURLOCATION.Text = Application.StartupPath & "\COMPANY_LOGO\" & txtcmpname.Text.Trim & TXTFILENAME.Text.Trim
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If txtimgpath.Text.Trim.Length <> 0 Then PBIMG.ImageLocation = txtimgpath.Text.Trim

        'COPY SCANNED DOCS FILES 
        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\COMPANY_LOGO") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\COMPANY_LOGO")
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\COMPANY_LOGO") = False Then System.IO.File.Copy(txtimgpath.Text.Trim, TXTOURLOCATION.Text.Trim, True)


        'txtimgpath.Text = OpenFileDialog1.FileName
        'On Error Resume Next

        'If txtimgpath.Text.Trim.Length <> 0 Then
        '    pbsoftcopy.ImageLocation = txtimgpath.Text.Trim
        '    pbsoftcopy.Load(txtimgpath.Text.Trim)

        '    If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\COMPANY LOGO") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\COMPANY LOGO")
        '    TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        '    TXTOURLOCATION.Text = Application.StartupPath & "\COMPANY LOGO\" & CMBEMPNAME.Text.Trim & TXTFILENAME.Text.Trim
        '    txtimgpath.Text = OpenFileDialog1.FileName

        '    If System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files\") = False Then
        '        System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\Uploaded Files")
        '    End If

        '    If System.IO.File.Exists(txtimgpath.Text.Trim) = True Then
        '        Dim EXTENSION As String = Path.GetExtension(txtimgpath.Text.Trim)
        '        If EXTENSION <> ".pdf" Then
        '            System.IO.File.Copy(txtimgpath.Text.Trim, System.AppDomain.CurrentDomain.BaseDirectory & "Uploaded Files\logo", True)
        '            MsgBox("File Uploaded Successfully", MsgBoxStyle.OkOnly, "Tex Pro")
        '        Else
        '            pbsoftcopy.Load(System.AppDomain.CurrentDomain.BaseDirectory & "PDF.jpg")
        '        End If
        '    End If

        'End If
    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        PBIMG.ImageLocation = ""
        txtimgpath.Clear()
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

    Private Sub CMBCURRENCY_Enter(sender As Object, e As EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As New DataTable
                dt = OBJCMN.search("CUR_CODE", "", "CURRENCYMASTER")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CUR_CODE"
                    CMBCURRENCY.DataSource = dt
                    CMBCURRENCY.DisplayMember = "CUR_CODE"
                    CMBCURRENCY.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class