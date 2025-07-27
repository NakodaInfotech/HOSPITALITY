
Imports BL

Public Class SendMail
    Public attachment As String
    Public attachment1 As String
    Public subject, GUESTNAME, BODY As String
    Public ALATTACHMENT As New ArrayList

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            'get FOOTERIMAGE
            Dim DT As DataTable = OBJCMN.search("USER_PHOTO AS FOOTERIMG", "", "USERMASTER", " AND USER_NAME ='" & UserName & "' AND USER_CMPID = " & CmpId)
            If IsDBNull(DT.Rows(0).Item("FOOTERIMG")) = False Then PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("FOOTERIMG"), Byte())))

            Dim IC As New ImageConverter
            Dim CMPLOGO() As Byte= DirectCast(IC.ConvertTo(PBIMG.Image, GetType(Byte())), Byte())

            If ClientName = "KHANNA" Then txtmailbody.Text = "<span style=""font-family:Comic Sans MS;font-size: 12pt;"">" & txtmailbody.Text & "</span>" Else txtmailbody.Text = "<span style=""font-family:Tahoma;font-size: 10pt;"">" & txtmailbody.Text & "</span>"
            txtmailbody.Text = txtmailbody.Text.Replace(vbNewLine, "<br/>")
            If cmbfirstadd.Text.Trim <> Nothing Then sendemail(cmbfirstadd.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            If cmbsecondadd.Text.Trim <> Nothing Then sendemail(cmbsecondadd.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            If cmbthirdadd.Text.Trim <> Nothing Then sendemail(cmbthirdadd.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            If cmbfourthadd.Text.Trim <> Nothing Then sendemail(cmbfourthadd.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            If cmbfifthadd.Text.Trim <> Nothing Then sendemail(cmbfifthadd.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            If TXTAUTOCCEMAIL.Text.Trim <> Nothing Then sendemail(TXTAUTOCCEMAIL.Text.Trim, attachment, txtmailbody.Text.Trim, subject, "", "", attachment1, Val(TXTSMTPPORT.Text.Trim), CHKSSL.Checked, CMPLOGO, ALATTACHMENT, ALATTACHMENT.Count)
            'txtmailbody.Text = txtmailbody.Text.Replace("<br/>", vbNewLine)
            MsgBox("Mails sent successfully")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbfirstadd.Text.Trim.Length = 0 And cmbsecondadd.Text.Trim.Length = 0 And cmbthirdadd.Text.Trim.Length = 0 And cmbfourthadd.Text.Trim.Length = 0 And cmbfifthadd.Text.Trim.Length = 0 Then
            Ep.SetError(cmbfirstadd, "Enter Email Address")
            bln = False
        End If

        If Val(TXTSMTPPORT.Text.Trim) = 0 Then
            Ep.SetError(TXTSMTPPORT, "Enter Port No, Either 587 or 25")
            bln = False
        End If

        Return bln
    End Function

    Private Sub SendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Top = 100

            Dim OBJCMN As New ClsCommon

            'get CMPADDRESS
            Dim DT As DataTable = OBJCMN.search("CMP_ADD1 AS ADD1, CMP_ADD2 AS ADD2, ISNULL(CMP_WEBSITE,'') AS WEBSITE, ISNULL(CMP_EMAIL,'') AS EMAIL, ISNULL(CMPBANK_BANKNAME,'') AS BANKNAME, ISNULL(CMPBANK_ACCNO,'') AS ACCNO, ISNULL(CMPBANK_BRANCH,'') AS BRANCH, ISNULL(CMPBANK_IFSC,'') AS IFSCCODE", "", " CMPMASTER LEFT OUTER JOIN CMPBANKDETAILS ON CMP_ID = CMPBANK_CMPID ", " AND CMP_ID = " & CmpId)

            FILLAUTOCC(TXTAUTOCCEMAIL)
            If GUESTNAME = "" Then GUESTNAME = "Sir/Madam"

            If ClientName = "TOPCOMM" Then
                txtmailbody.Text = "Dear Customer, enclosed your Confirmation / Voucher for above subject as requested." & vbCrLf & vbCrLf & "From: Customer Service " & vbCrLf & "Top Communications - Indiatravelite.com " & vbCrLf & "22, Godavari Chambers, Opp. Saraswat Bank, S.V. Road, " & vbCrLf & "Kandivli (west) , Mumbai - 400067, Maharashtra, India." & vbCrLf & "Tel: (91-22) 2807 9270, 2807 9992, 2807 9995, 6695 9447, 2808 1162, 2808 1159, 6725 5444 " & vbCrLf & "Fax: (91-22) 6725 5444 & " & vbCrLf & "Email: indiatravelite@vsnl.com, info@indiatravelite.com, indiatravelite@gmail.com ," & vbCrLf & "Website :http://www.indiatravelite.com" & vbCrLf & "Skype : Indiatravelite" & vbCrLf & "LIVEHELP- on our homepage." & vbCrLf & vbCrLf & "Services: Hotel Booking, Rent-A-Car, Tour Packages For India, Nepal, Dubai, Maldives, Mauritius, " & vbCrLf & "Sri Lanka, Kenya, Singapore, Thailand, Malaysia."
            ElseIf ClientName = "CLASSIC" Then
                txtmailbody.Text = "Please find the document as an attachment." & vbCrLf & "From" & vbCrLf & "CLASSIC TRAVEL SHOPPE PVT. LTD." & vbCrLf & "+91 022-40888888" & vbCrLf & "accounts@classicholidays.in"
            ElseIf ClientName = "SHREEJI" Then
                txtmailbody.Text = "REGARDS," & vbCrLf & vbCrLf & "SHREEJI TRAVELS, MUMBAI" & vbCrLf & "TEL: 022-25067776" & vbCrLf & "email: shreejitravels@rocketmail.com" & vbCrLf & vbCrLf & "NOTE:- THIS IS A SYSTEM GENERATED EMAIL, SO PLEASE DO NOT RESPOND OR REPLY"
            ElseIf ClientName = "BARODA" Then
                txtmailbody.Text = "REGARDS," & vbCrLf & vbCrLf & "SHREEJI TRAVELS, VADODARA" & vbCrLf & "MOB:- +919824077805 , +919824310600, +918000270504" & vbCrLf & "email: doshimahesh66@gmail.com" & vbCrLf & "             doshimahesh66@ymail.com" & vbCrLf & vbCrLf & "NOTE:- THIS IS A SYSTEM GENERATED EMAIL, SO PLEASE DO NOT RESPOND OR REPLY"
            ElseIf ClientName = "AIRTRINITY" Or ClientName = "WAHWAH" Then
                txtmailbody.Text = "Dear " & GUESTNAME & "," & vbCrLf & vbCrLf & "<b>Greetings from " & CmpName & "!!!</b>" & vbCrLf & "Please find the attached document for your kind perusal." & vbCrLf & vbCrLf & " Should you need any further assistance please feel free to call the undersigned " & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UserName & vbCrLf & UserTelNo & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("WEBSITE")
            ElseIf ClientName = "KHANNA" Then
                txtmailbody.Text = "Dear " & GUESTNAME & "," & vbCrLf & vbCrLf & "<b>Greetings from " & CmpName & "!!!</b>" & vbCrLf & "We Thank you for providing us the opportunity to plan and arrange your forthcoming holidays." & vbCrLf & "With your support, Over the years we have grown to become one of finest holiday planners." & vbCrLf & "we promise to make your holiday an unparalleled experience, " & vbCrLf & vbCrLf & "Please find the attached document for your kind perusal." & vbCrLf & vbCrLf & "Do not hesitate to contact us for any further assistance " & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UserName & vbCrLf & UserTelNo & vbCrLf & USEREMAIL & vbCrLf & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("WEBSITE")

            ElseIf ClientName = "STARVISA" Then
                txtmailbody.Text = BODY & vbCrLf & vbCrLf & "<b>" & CmpName & vbCrLf & vbCrLf & "VISA SERVICE / AIR TICKETING / IMMIGRATION / INTERNATIONAL TOUR PACKAGES" & vbCrLf & vbCrLf & DT.Rows(0).Item("ADD1") & vbCrLf & DT.Rows(0).Item("ADD2") & vbCrLf & DT.Rows(0).Item("EMAIL") & vbCrLf & "MEMBER : ETAA, IAAI." & vbCrLf & vbCrLf & "SABIR TINWALA  MOB 09820494895" & vbCrLf & "(PROPRIETOR)" & vbCrLf & vbCrLf & "RAZZAQUE = 09920640208" & vbCrLf & vbCrLf & CmpName & vbCrLf & DT.Rows(0).Item("BANKNAME") & vbCrLf & "BRANCH - " & DT.Rows(0).Item("BRANCH") & vbCrLf & "CURRENT A/C NO - " & DT.Rows(0).Item("ACCNO") & vbCrLf & "RTGS / NEFT IFSC CODE - " & DT.Rows(0).Item("IFSCCODE") & vbCrLf & vbCrLf & "GSTIN NO 27ANFPT8848K2Z2</b>"
            Else
                If BODY <> "" Then txtmailbody.Text = BODY Else txtmailbody.Text = "Please find the document as an attachment." & vbCrLf & CmpName
            End If
            'TXTBODY.Text = txtmailbody.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfifthadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfifthadd.GotFocus
        Try
            fillcmb(cmbfifthadd)
        Catch ex As Exception
            Throw ex
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
            Throw ex
        End Try
    End Sub

    Sub FILLAUTOCC(ByRef TXT As System.Windows.Forms.TextBox)
        Try
            If TXT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" USER_EMAIL ", "", " USERMASTER ", " AND USER_NAME = '" & UserName & "'")
                If dt.Rows.Count > 0 Then
                    TXT.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AUTOCCVALIDATE(ByRef TXT As System.Windows.Forms.TextBox)
        Try
            Dim intresult As Integer
            If TXT.Text.Trim <> "" Then
                lowercase(TXT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" USER_EMAIL ", "", " USERMASTER ", " and USER_EMAIL = '" & TXT.Text.Trim & "' AND USER_NAME = '" & UserName & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Email Address not present, Update?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim OBJ As New ClsCommon
                        Dim DTR As DataTable = OBJ.Execute_Any_String(" UPDATE USERMASTER SET USER_EMAIL = '" & TXT.Text.Trim & "' WHERE USER_NAME = '" & UserName & "'", "", "")
                        MsgBox("Email Updated")
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfirstadd.GotFocus
        Try
            fillcmb(cmbfirstadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfourthadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbfourthadd.GotFocus
        Try
            fillcmb(cmbfourthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbsecondadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsecondadd.GotFocus
        Try
            fillcmb(cmbsecondadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbthirdadd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbthirdadd.GotFocus
        Try
            fillcmb(cmbthirdadd)
        Catch ex As Exception
            Throw ex
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
                    Dim tempmsg As Integer = MsgBox("Email Address not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
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
                        IntResult = objEmailmaster.save()
                        'e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfifthadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfifthadd.Validating
        Try
            cmbvalidate(cmbfifthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfirstadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfirstadd.Validating
        Try
            cmbvalidate(cmbfirstadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbfourthadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbfourthadd.Validating
        Try
            cmbvalidate(cmbfourthadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbsecondadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsecondadd.Validating
        Try
            cmbvalidate(cmbsecondadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbthirdadd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbthirdadd.Validating
        Try
            cmbvalidate(cmbthirdadd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSMTPPORT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSMTPPORT.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTAUTOCCEMAIL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAUTOCCEMAIL.Validating
        If TXTAUTOCCEMAIL.Text.Trim <> "" Then AUTOCCVALIDATE(TXTAUTOCCEMAIL)
    End Sub
End Class