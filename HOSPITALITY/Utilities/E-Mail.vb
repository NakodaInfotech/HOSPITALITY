
Imports BL
Imports System.Net.Mail
Imports System.IO

Public Class E_Mail

    Public attachment As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            If MsgBox("Send Mail to Selected Receipients?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim TOMAIL As String = cmbfirstadd.Text.Trim

            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If TOMAIL = "" Then TOMAIL = dtrow("EMAILID") Else TOMAIL = TOMAIL & "," & dtrow("EMAILID")
                End If
            Next


            If cmbfirstadd.Text.Trim.Length = 0 And CMBGUESTCATEGORY.Text.Trim = "" And CMBGROUPDEPARTURE.Text.Trim = "" And TOMAIL = "" Then
                EP.SetError(cmbfirstadd, "Enter Email Address")
                Exit Sub
            End If

            txtmailbody.Text = "<span style=""font-family:Tahoma;font-size: 10pt;"">" & txtmailbody.Text & "</span>"
            txtmailbody.Text = txtmailbody.Text.Replace(vbNewLine, "<br/>")


            'create the mail message
            Dim mail As New MailMessage
            mail.Bcc.Add(TOMAIL)

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If CMBGUESTCATEGORY.Text.Trim <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS CATEGORY
                DT = OBJCMN.search("ISNULL(GUEST_EMAIL,'') AS EMAILID", "", " GUESTMASTER INNER JOIN GUESTCATEGORYMASTER ON GUEST_GUESTCATEGORYID = CATEGORY_ID", " AND CATEGORY_NAME = '" & CMBGUESTCATEGORY.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        mail.Bcc.Add(DTROW("EMAILID"))
                    Next
                End If
            End If

            If CMBGROUPDEPARTURE.Text.Trim <> "" Then
                'SEND SAME MAIL TO ALL THE GUEST IN THIS GROUPDEP
                DT = OBJCMN.search("ISNULL(GUEST_EMAIL,'') AS EMAILID", "", " GROUPDEPARTURE INNER JOIN HOLIDAYPACKAGEMASTER ON GROUPDEPARTURE.GROUPDEP_NO = HOLIDAYPACKAGEMASTER.BOOKING_GROUPDEPARTID AND GROUPDEPARTURE.GROUPDEP_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID ", " AND GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        mail.Bcc.Add(DTROW("EMAILID"))
                    Next
                End If
            End If

            'get FOOTERIMAGE
            DT = OBJCMN.search("USER_PHOTO AS FOOTERIMG", "", "USERMASTER", " AND USER_NAME ='" & UserName & "' AND USER_CMPID = " & CmpId)
            If IsDBNull(DT.Rows(0).Item("FOOTERIMG")) = False Then PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("FOOTERIMG"), Byte())))
            Dim IC As New ImageConverter
            Dim CMPLOGO() As Byte = DirectCast(IC.ConvertTo(PBIMG.Image, GetType(Byte())), Byte())


            'set the content
            mail.Subject = txtsubject.Text.Trim
            mail.Body = txtmailbody.Text.Trim
            mail.IsBodyHtml = True

            If TXTATTACHMENT1.Text.Trim <> "" Then
                Dim MAILATTACHMENT1 As New Attachment(TXTATTACHMENT1.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT1)
            End If
            If TXTATTACHMENT2.Text.Trim <> "" Then
                Dim MAILATTACHMENT2 As New Attachment(TXTATTACHMENT2.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT2)
            End If
            If TXTATTACHMENT3.Text.Trim <> "" Then
                Dim MAILATTACHMENT3 As New Attachment(TXTATTACHMENT3.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT3)
            End If
            If TXTATTACHMENT4.Text.Trim <> "" Then
                Dim MAILATTACHMENT4 As New Attachment(TXTATTACHMENT4.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT4)
            End If
            If TXTATTACHMENT5.Text.Trim <> "" Then
                Dim MAILATTACHMENT5 As New Attachment(TXTATTACHMENT5.Text.Trim)
                mail.Attachments.Add(MAILATTACHMENT5)
            End If

            Dim myMailHTMLBody = "<html><head></head><body>" & txtmailbody.Text.Trim & "<br/><img src=cid:ThePictureID></body></html>"


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

                    smtp.Port = Val(TXTSMTPPORT.Text.Trim)
                    smtp.EnableSsl = CHKSSL.Checked

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
                smtp.Send(mail)
                mail.Dispose()

            End Using

            MsgBox("Mail sent successfully")
            CLEAR()
            cmbfirstadd.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'CHECK THIS ON SAVE CLICK
        'DONE BY GULKIT
        'COZ SOMETIME WE MIGHT JUST SELECT NAMES IN THE GRID AND WONT WRITE ANYTHING IN COMBO
        'SO WE HAVE WRITTEN CODE ON SAVE
        'If cmbfirstadd.Text.Trim.Length = 0 And CMBGUESTCATEGORY.Text.Trim = "" And CMBGROUPDEPARTURE.Text.Trim = "" Then
        '    EP.SetError(cmbfirstadd, "Enter Email Address")
        '    bln = False
        'End If

        If txtsubject.Text.Trim = "" Then
            EP.SetError(txtsubject, "Enter Subject")
            bln = False
        End If

        If CMBGROUPDEPARTURE.Text.Trim <> "" And CMBGUESTCATEGORY.Text.Trim <> "" Then
            EP.SetError(CMBGROUPDEPARTURE, "Group Name and Guest Category cannot be selected together")
            bln = False
        End If

        If txtmailbody.Text.Trim = "" Then
            EP.SetError(txtsubject, "Enter Message")
            bln = False
        End If
        Return bln
    End Function

    Private Sub SendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.M Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            If cmb.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("email_id", "", "EmailMaster", " and email_cmpid = " & CmpId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Email_id"
                    cmb.DataSource = dt
                    cmb.DisplayMember = "Email_id"
                    cmb.Text = ""
                End If
                cmb.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfirstadd.GotFocus
        Try
            fillcmb(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub cmbvalidate(ByRef cmb As System.Windows.Forms.ComboBox)
        Try
            Dim intresult As Integer
            If cmb.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("Email_id", "", "EmailMaster", " and Email_id = '" & cmb.Text.Trim & "' and Email_cmpid = " & CmpId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Email Address not present, Add New?", MsgBoxStyle.YesNo, "Office Manager")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmb.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objEmailmaster As New ClsEmailMaster
                        objEmailmaster.alParaval = alParaval
                        intresult = objEmailmaster.save()
                        'e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfirstadd.Validating
        Try
            cmbvalidate(cmbfirstadd)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdbrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE1.Click
        TXTATTACHMENT1.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE2.Click
        TXTATTACHMENT2.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT2.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE3.Click
        TXTATTACHMENT3.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT3.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE4.Click
        TXTATTACHMENT4.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT4.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub cmdbrowse5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBROWSE5.Click
        TXTATTACHMENT5.Clear()
        OpenFileDialog1.ShowDialog()
        TXTATTACHMENT5.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub E_Mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID()
        CLEAR()
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBACCOUNT.Checked = True Then dt = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(LEDGERS.ACC_EMAIL,'') AS EMAILID, ISNULL(CITY_NAME,'') AS CITY ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') AND ISNULL(LEDGERS.ACC_EMAIL,'') <> '' AND (LEDGERS.ACC_YEARID = " & YearId & ") ORDER BY LEDGERS.Acc_cmpname") Else dt = objclsCMST.search(" CAST (0 AS BIT) AS CHK, GUEST_NAME AS NAME, '' AS UNDER, ISNULL(GUEST_EMAIL,'') AS EMAILID, ISNULL(CITY_NAME,'') AS CITY ", " ", " GUESTMASTER LEFT OUTER JOIN CITYMASTER ON CITY_ID = GUEST_CITYID", " AND ISNULL(GUEST_EMAIL,'') <> '' AND (GUEST_YEARID = " & YearId & ") ORDER BY GUEST_NAME")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            Dim OBJCMN As New ClsCommon

            'get CMPADDRESS
            Dim DT As DataTable = OBJCMN.search("CMP_ADD1 AS ADD1, CMP_ADD2 AS ADD2, ISNULL(CMP_WEBSITE,'') AS WEBSITE, ISNULL(CMP_EMAIL,'') AS EMAIL, ISNULL(CMPBANK_BANKNAME,'') AS BANKNAME, ISNULL(CMPBANK_ACCNO,'') AS ACCNO, ISNULL(CMPBANK_BRANCH,'') AS BRANCH, ISNULL(CMPBANK_IFSC,'') AS IFSCCODE", "", " CMPMASTER LEFT OUTER JOIN CMPBANKDETAILS ON CMP_ID = CMPBANK_CMPID ", " AND CMP_ID = " & CmpId)

            If ClientName = "TOPCOMM" Then
                txtmailbody.Text = "Dear Customer, enclosed your Confirmation / Voucher for above subject as requested." & vbCrLf & vbCrLf & "From: Customer Service " & vbCrLf & "Top Communications - Indiatravelite.com " & vbCrLf & "22, Godavari Chambers, Opp. Saraswat Bank, S.V. Road, " & vbCrLf & "Kandivli (west) , Mumbai - 400067, Maharashtra, India." & vbCrLf & "Tel: (91-22) 2807 9270, 2807 9992, 2807 9995, 6695 9447, 2808 1162, 2808 1159, 6725 5444 " & vbCrLf & "Fax: (91-22) 6725 5444 & " & vbCrLf & "Email: indiatravelite@vsnl.com, info@indiatravelite.com, indiatravelite@gmail.com ," & vbCrLf & "Website :http://www.indiatravelite.com" & vbCrLf & "Skype : Indiatravelite" & vbCrLf & "LIVEHELP- on our homepage." & vbCrLf & vbCrLf & "Services: Hotel Booking, Rent-A-Car, Tour Packages For India, Nepal, Dubai, Maldives, Mauritius, " & vbCrLf & "Sri Lanka, Kenya, Singapore, Thailand, Malaysia."
            ElseIf ClientName = "CLASSIC" Then
                txtmailbody.Text = "Please find the document as an attachment." & vbCrLf & "From" & vbCrLf & "CLASSIC TRAVEL SHOPPE PVT. LTD." & vbCrLf & "+91 022-40888888" & vbCrLf & "accounts@classicholidays.in"
            ElseIf ClientName = "SHREEJI" Then
                txtmailbody.Text = "REGARDS," & vbCrLf & vbCrLf & "SHREEJI TRAVELS, MUMBAI" & vbCrLf & "TEL: 022-25067776" & vbCrLf & "email: shreejitravels@rocketmail.com" & vbCrLf & vbCrLf & "NOTE:- THIS IS A SYSTEM GENERATED EMAIL, SO PLEASE DO NOT RESPOND OR REPLY"
            ElseIf ClientName = "BARODA" Then
                txtmailbody.Text = "REGARDS," & vbCrLf & vbCrLf & "SHREEJI TRAVELS, VADODARA" & vbCrLf & "MOB:- +919824077805 , +919824310600, +918000270504" & vbCrLf & "email: doshimahesh66@gmail.com" & vbCrLf & "             doshimahesh66@ymail.com" & vbCrLf & vbCrLf & "NOTE:- THIS IS A SYSTEM GENERATED EMAIL, SO PLEASE DO NOT RESPOND OR REPLY"
            ElseIf ClientName = "AIRTRINITY" Or ClientName = "WAHWAH" Then
                txtmailbody.Text = "Dear Sir/Madam," & vbCrLf & vbCrLf & "<b>Greetings from " & CmpName & "!!!</b>" & vbCrLf & "Please find the attached document for your kind perusal." & vbCrLf & vbCrLf & " Should you need any further assistance please feel free to call the undersigned " & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UserName & vbCrLf & UserTelNo & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("WEBSITE")
            ElseIf ClientName = "KHANNA" Then
                txtmailbody.Text = "Dear Sir/Madam," & vbCrLf & vbCrLf & "<b>Greetings from " & CmpName & "!!!</b>" & vbCrLf & "We Thank you for providing us the opportunity to plan and arrange your forthcoming holidays." & vbCrLf & "With your support, Over the years we have grown to become one of finest holiday planners." & vbCrLf & "we promise to make your holiday an unparalleled experience, " & vbCrLf & vbCrLf & "Please find the attached document for your kind perusal." & vbCrLf & vbCrLf & "Do not hesitate to contact us for any further assistance " & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UserName & vbCrLf & UserTelNo & vbCrLf & USEREMAIL & vbCrLf & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("WEBSITE")
            ElseIf ClientName = "STARVISA" Then
                'txtmailbody.Text = "Dear Sir/Madam," & vbCrLf & vbCrLf & "<b>Greetings from " & CmpName & "!!!</b>" & vbCrLf & "VISA SERVICE / AIR TICKETING / IMMIGRATION / INTERNATIONAL TOUR PACKAGES" & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UserName & vbCrLf & UserTelNo & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("EMAIL") & vbCrLf & "MEMBER : ETAA, IAAI." & vbCrLf & vbCrLf & "SABIR TINWALA  MOB 09820494895" & vbCrLf & "(PROPRIETOR)" & vbCrLf & vbCrLf & "RAZZAQUE = 09920640208" & vbCrLf & "SUMIT           = 09049496526 / 09769282618" & vbCrLf & vbCrLf & "STAR VISA SERVICE" & vbCrLf & "ICICI BANK, BRANCH BHAT BAZAR," & vbCrLf & "CURRENT A/C NO 122305000111," & vbCrLf & "RTGS/NEFT IFSC CODD - ICIC0001223"
                txtmailbody.Text = "<b>" & CmpName & vbCrLf & vbCrLf & "VISA SERVICE / AIR TICKETING / IMMIGRATION / INTERNATIONAL TOUR PACKAGES" & vbCrLf & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("EMAIL") & vbCrLf & "MEMBER : ETAA, IAAI, TAFI." & vbCrLf & vbCrLf & "SABIR TINWALA  MOB 09820494895" & vbCrLf & "(PROPRIETOR)" & vbCrLf & vbCrLf & "RAZZAQUE = 09920640208" & vbCrLf & vbCrLf & CmpName & vbCrLf & DT.Rows(0).Item("BANKNAME") & vbCrLf & "BRANCH - " & DT.Rows(0).Item("BRANCH") & vbCrLf & "CURRENT A/C NO - " & DT.Rows(0).Item("ACCNO") & vbCrLf & "RTGS / NEFT IFSC CODE - " & DT.Rows(0).Item("IFSCCODE") & vbCrLf & vbCrLf & "GSTIN NO 27ANFPT8848K2Z2</b>"
            Else
                If txtmailbody.Text.Trim <> "" Then txtmailbody.Text = txtmailbody.Text.Trim Else txtmailbody.Text = "Please find the document as an attachment." & vbCrLf & CmpName
            End If
            CMBGROUPDEPARTURE.Text = ""
            CMBGUESTCATEGORY.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub E_Mail_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        fillcmb(cmbfirstadd)
        FILLGUESTCATEGORY(CMBGUESTCATEGORY, False)
        FILLGROUPNAME(CMBGROUPDEPARTURE, "")
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, "")
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

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBACCOUNT.CheckedChanged, RBGUEST.CheckedChanged
        FILLGRID()
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class