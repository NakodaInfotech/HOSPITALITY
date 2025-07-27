
Imports BL
Imports System.IO
Imports System.ComponentModel
Imports System.Net
Imports RestSharp
Imports Newtonsoft.Json
Imports TaxProEInvoice.API

Public Class HolidayPackage

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridGUESTDoubleClick As Boolean
    Dim gridTOURDoubleClick As Boolean
    Dim gridPURCHASEDoubleClick As Boolean
    Dim gridUPLOADdoubleclick, GRIDAIRDOUBLECLICK As Boolean
    Dim GRIDCARDOUBLECLICK As Boolean
    Dim GRIDMISCDOUBLECLICK As Boolean
    Dim tempMISCrow As Integer

    Dim temprow As Integer
    Dim tempGUESTrow As Integer
    Dim tempTOURrow, tempFLIGHTrow As Integer
    Dim tempPURCHASErow As Integer
    Dim tempUPLOADrow As Integer
    Dim TEMPCARROW As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Dim TEMPMSG As Integer
    Public Shared dt_amd As New DataTable
    Public Shared SELECTENQ As New DataTable
    Public TEMPGROUPNAME As String

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)



                'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                'PBQRCODE.ImageLocation = Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                'PBQRCODE.Refresh()


                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\HS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\HS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()



                'If PBQRCODE.Image IsNot Nothing Then
                '    Dim OBJINVOICE As New ClsInvoiceMaster
                '    Dim MS As New IO.MemoryStream
                '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                '    OBJINVOICE.alParaval.Add(MS.ToArray)
                '    OBJINVOICE.alParaval.Add(YearId)
                '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                'End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""
            'Dim KOTHARIPLACE As String = ""  'THIS VARIABLE IS USED TO FETCH RANGE COLUMN ONLY FOR KOTHARI, THEY WILL ENTER FULL SHIPTO ADDRESS THERE
            Dim DISPATCHFROM As String = ""
            Dim DISPATCHFROMGSTIN As String = ""
            Dim DISPATCHFROMPINCODE As String = ""
            Dim DISPATCHFROMSTATECODE As String = ""
            Dim DISPATCHFROMSTATENAME As String = ""
            Dim DISPATCHFROMKMS As Double = 0
            Dim DISPATCHFROMADD1 As String = ""
            Dim DISPATCHFROMADD2 As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")
            DISPATCHFROM = CmpName
            DISPATCHFROMGSTIN = CMPGSTIN
            DISPATCHFROMPINCODE = CMPPINCODE
            DISPATCHFROMSTATECODE = CMPSTATECODE
            DISPATCHFROMSTATENAME = CMPSTATENAME


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2  ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","
                j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " HOLIDAYPACKAGEMASTER ", " AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & BOOKINGDATE.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & "," 'CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & DISPATCHFROM & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & DISPATCHFROMPINCODE & "" & ","
                j = j & """Stcd"":""" & DISPATCHFROMSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"

                Dim TEMPOTHERAMT As Double = 0.0
                Dim TEMPTOTALITEMAMT As Double = 0.0
                If CHKTAXSERVCHGS.Checked = True Then
                    TEMPOTHERAMT = Val(TXTTOTALSALEAMT.Text.Trim) - Val(TXTDISCRS.Text.Trim) + Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTOURCOMMRS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                Else
                    TEMPOTHERAMT = Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTSUBTOTAL.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                End If


                j = j & """ItemList"":[{"
                j = j & """SlNo"": """ & "1" & """" & ","
                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
                j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
                'j = j & """Barcde"":""REC9999"","
                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                'j = j & """FreeQty"":" & "0" & "" & ","
                'j = j & """Unit"":""" & "MTR" & """" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTOURCOMMRS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTOURCOMMRS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTOURCOMMRS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                If APPLYCESS = True Then
                    j = j & """CesRt"":" & Val(TXTCESSPER.Text.Trim) & "" & ","
                    j = j & """CesAmt"":" & Val(TXTCESSAMT.Text.Trim) & "" & ","
                Else
                    j = j & """CesRt"":" & "0" & "" & ","
                    j = j & """CesAmt"":" & "0" & "" & ","
                End If
                j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """StateCesRt"":" & "0" & "" & ","
                j = j & """StateCesAmt"":" & "0" & "" & ","
                j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """OthChrg"":" & "0" & "" & ","

                j = j & """TotItemVal"":" & Val(TEMPTOTALITEMAMT) & "" & ","
                j = j & """OrdLineRef"":"" "","
                j = j & """OrgCntry"":""IN"","
                j = j & """PrdSlNo"":""123"","

                j = j & """BchDtls"": {"
                j = j & """Nm"":""123"","
                j = j & """Expdt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """wrDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTOURCOMMRS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","

                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TEMPOTHERAMT) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & "0" & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & BOOKINGDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"



                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10

                'WE HAVE REMOVED CREATING EWAY DIRECTLY FORM EINVOICE
                'USER HAVE TO MANUALLY CREATE EWAY SEPERATELY
                'If TXTVEHICLENO.Text.Trim <> "" Then
                '    j = j & ","
                '    j = j & """EwbDtls"": {"
                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                '    j = j & """Distance"":""" & PARTYKMS & """" & ","
                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                '    j = j & """VehType"":""" & "R" & """" & ","
                '    j = j & """TransMode"":""1""" & "}"
                'End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()



            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                'Dim ERRORMSG As String = ""
                'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                'ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO


            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE HOLIDAYPACKAGEMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\HS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\HS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsCarBooking
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'PACKAGE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True And txtmobileno.Text.Trim <> "" Then
            If SENDMSG("Dear " & CMBGUESTNAME.Text.Trim & ", Your booking for " & TXTTOURNAME.Text.Trim & " is Confirmed. Booking No HS-" & Val(TEMPBOOKINGNO) & ", Check In " & Format(PACKAGEFROM.Value.Date, "dd/MM/yyyy") & ", Check Out " & Format(PACKAGETO.Value.Date, "dd/MM/yyyy") & ", Total Pax " & Val(TXTTOTALPAX.Text.Trim), txtmobileno.Text.Trim) = "1701" Then MsgBox("Message Sent") Else MsgBox("Error Sending Message")
        End If
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_no),0) + 1 ", "HOLIDAYPACKAGEMASTER", " AND BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then txtbookingno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try
            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "MILONI" Or ClientName = "SKYMAPS" Or ClientName = "BARODA" Or ClientName = "NAMASTE" Or ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then txtbookingno.ReadOnly = False

            CMBCANCEL.Text = ""
            CMBNOTES.Text = ""
            TXTPOLICY.Clear()
            TXTNOTES.Clear()

            CMBPACKAGETYPE.SelectedIndex = 0
            CMBQUOTECALC.SelectedIndex = 0

            TXTTOURNAME.Clear()
            TXTSALEMOBILE.Clear()
            LBLGROUPNAME.Visible = False
            TXTTOURNAME.Visible = True
            LBLTOUR.Visible = True

            TXTENQNO.Clear()
            TXTCOPY.Clear()
            tstxtbillno.Clear()
            TXTTOURNAME.Clear()
            CMBNAME.Text = ""
            CMBACCCODE.Text = ""
            LBLACCBAL.Text = 0.0
            TXTADULTS.Clear()
            TXTCHILDS.Clear()
            TXTNCCHILDS.Clear()
            TXTTOTALPAX.Clear()
            TXTGUESTADD.Clear()
            TXTADD.Clear()
            txtrefno.Clear()
            BOOKINGDATE.Text = Mydate
            txtbookingno.Clear()
            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True

            TXTGUESTSRNO.Clear()
            CMBGUESTNAME.Text = ""
            TXTAGE.Clear()
            CMBSEX.SelectedIndex = 0
            txtmobileno.Clear()
            txtemailadd.Clear()
            TXTARRIVALFROM.Clear()
            TXTDEPARTURETO.Clear()
            TXTARRFLIGHTNO.Clear()
            TXTDEPARTFLIGHTNO.Clear()
            GRIDGUESTDETAILS.RowCount = 0


            txtsrno.Clear()
            CMBHOTELCODE.Text = ""
            CMBHOTELNAME.Text = ""
            TXTCONFIRMATIONNO.Clear()
            TXTCONFIRMEDBY.Clear()
            PACKAGEFROM.Value = Mydate
            PACKAGETO.Value = Mydate
            CHECKINDATE.Value = Mydate
            CHECKOUTDATE.Value = Mydate.Date.AddDays(1)
            CMBROOMTYPE.Text = ""
            CMBPLAN.Text = ""
            TXTNOOFROOMS.Clear()
            TXTRATE.Clear()
            TXTCHILDRATE.Clear()
            TXTINFANTRATE.Clear()
            TXTTOTAL.Clear()
            GRIDBOOKINGS.RowCount = 0
            TXTTOTALROOMS.Clear()
            TXTTOTALAMT.Clear()

            TXTTOURSRNO.Clear()
            'TOURDATE.Value = Mydate
            'TXTTOURDETAILS.Clear()
            GRIDTOUR.RowCount = 0

            TXTCARSRNO.Clear()
            TXTCONTACTPERSON.Clear()
            TXTCONTACTNO.Clear()
            CMBCARTYPE.Text = ""
            CMBCARNAME.Text = ""
            TXTCARADULTS.Text = 0.0
            TXTCARCHILDS.Text = 0.0
            TXTCARTOTALPAX.Text = 0
            TXTCARTOTALAMT.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate.Date.AddDays(1)
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTROUTE.Clear()
            TXTCARITINERARY.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            GRIDTRANS.RowCount = 0

            TXTPURSRNO.Clear()
            CMBPURCODE.Text = ""
            CMBPURNAME.Text = ""
            PURDATE.Value = Mydate
            TXTPUREXTRAADULTRATE.Text = 0.0
            TXTPUREXTRACHILDRATE.Text = 0.0
            TXTPURAMT.Text = 0.0
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURSUBTOTAL.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTPURNETTAMT.Text = 0.0
            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0
            CMBPURADDTAX.Text = ""
            TXTPURADDTAX.Text = 0.0
            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0
            TXTPURHSNCODE.Clear()
            GRIDPURCHASE.RowCount = 0

            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTFILENAME.Clear()
            TXTNEWIMGPATH.Clear()
            txtimgpath.Clear()
            gridupload.RowCount = 0

            TXTBOOKING_AMD.Clear()
            TXTAMDNO.Clear()
            txtpapa.Clear()
            TXTAMDREMARKS.Clear()

            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblamd.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False
            PBCN.Visible = False
            PBDN.Visible = False
            LBLEINVGENERATED.Visible = False

            txttax.ReadOnly = True


            btnselectpo.Enabled = True

            TBDETAILS.SelectedIndex = 0

            TXTTOTALSALEAMT.Text = 0.0

            'THIS FIELD IS JUST FOR CLASSIC
            TXTOURCOMM.Text = 0.0

            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            cmbtax.Text = ""
            txttax.Text = 0.0
            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0


            TXTEXTRAADULT.Clear()
            TXTEXTRACHILD.Clear()
            TXTEXTRAADULTRATE.Text = 0.0
            TXTEXTRACHILDRATE.Text = 0.0
            TXTTOTALNIGHTS.Text = 1

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            CMBAGENTNAME.Text = ""
            TXTAGENTCOMMPER.Text = 0.0
            TXTAGENTCOMMRS.Text = 0.0
            TXTAGENTTDSPER.Text = 0.0
            TXTAGENTTDSRS.Text = 0.0
            CMBEXCLUSION.Text = ""
            CMBINCLUSION.Text = ""


            TXTBTOTALNIGHTS.Clear()
            TXTBADULTS.Clear()
            TXTBCHILDS.Clear()
            TXTBINFANTS.Clear()
            TXTBEXTRAADULT.Clear()
            TXTBEXTRAADULTRATE.Clear()
            TXTBEXTRACHILD.Clear()
            TXTBEXTRACHILDRATE.Clear()
            TXTBTOTPAX.Clear()
            CMBPACKAGE.Text = "Yes"

            If ClientName = "CLASSIC" Then
                txtremarks.Text = "Room bill to " & CmpName & " & Extra or Direct Payment if any, payment to be collected directly from Guest."
            ElseIf ClientName = "TOPCOMM" Then
                txtremarks.Clear()
            ElseIf ClientName = "TRISHA" Then
                txtremarks.Text = "Bill to " & CmpName & " & all Extras direct."
            Else
                txtremarks.Text = "As per Standard Rates billed to " & CmpName & " & Extra if any, payment to be collected direct from Guest."
            End If

            If ClientName = "BELLA" Then TXTBOOKINGDESC.Text = " This booking is under cancellation." & vbNewLine & " No Show will be charged at 100 % of the total booking." & vbNewLine & " Early checkout will be charged at 100 % of the total booked period." & vbNewLine & " Name change /Date change will be treated as a cancellation if falling within the cancellation period."

            TXTSPECIALREMARKS.Clear()
            TXTPICKUP.Clear()

            txtinwords.Clear()
            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked
            CHKREFUNDED.CheckState = CheckState.Unchecked
            CHKFAILED.CheckState = CheckState.Unchecked
            CHKREVERSE.CheckState = CheckState.Unchecked
            CHKTAXSERVCHGS.CheckState = CheckState.Unchecked

            EP.Clear()
            gridDoubleClick = False
            gridGUESTDoubleClick = False
            gridTOURDoubleClick = False
            gridPURCHASEDoubleClick = False
            gridUPLOADdoubleclick = False
            GRIDAIRDOUBLECLICK = False

            getmax_BOOKING_no()

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            TXTGUESTSRNO.Text = 1
            txtsrno.Text = 1
            TXTTOURSRNO.Text = 1
            TXTCARSRNO.Text = 1
            TXTPURSRNO.Text = 1

            'GridAir
            GRIDAIRLINE.RowCount = 0
            GRIDSECTOR.RowCount = 0
            TXTAIRSRNO.Text = 1
            TXTSECTOR.Clear()
            TXTTEMPSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBAIRLINETYPE.SelectedIndex = 0
            TXTBASIC.Clear()
            TXTPSF.Clear()
            TXTGRIDTAX.Clear()
            TXTAIRAMT.Clear()
            TXTTOTALBASIC.Clear()
            TXTTOTALPSF.Clear()
            TXTTOTALTAXES.Clear()
            TXTAIRTOTAL.Text = 0.0

            SECTORGROUP.Visible = False
            SECTORGROUP.SendToBack()

            GRIDFLIGHT.RowCount = 0



            'GridMisc
            GRIDMISC.RowCount = 0
            TXTMISCSRNO.Text = 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()
            TXTMISCAMT.Clear()
            'TBDETAILS.SelectedIndex = 0
            GRIDMISCDOUBLECLICK = False

            TXTMISCSRNO.Text = 1
            txtuploadsrno.Text = 1

            TXTSTATECODE.Clear()
            TXTHSNCODE.Clear()
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTCESSPER.Text = 1
            TXTCESSAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURSGSTPER.Text = 0.0
            TXTPURSGSTAMT.Text = 0.0
            TXTPURIGSTPER.Text = 0.0
            TXTPURIGSTAMT.Text = 0.0
            TXTPURCESSPER.Text = 1
            TXTPURCESSAMT.Text = 0.0
            TXTSERVCHGS.Text = 0.0
            CHKSERVTAX.CheckState = CheckState.Unchecked
            TXTPURSTATECODE.Clear()
            TXTPURHSNCODE.Clear()

            'EINVOICE 
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing

            CHKMANUAL.CheckState = CheckState.Unchecked
            CHKPURMANUAL.CheckState = CheckState.Unchecked
            CHKDONTPOSTSERVCHGS.CheckState = CheckState.Unchecked

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        BOOKINGDATE.Focus()
    End Sub

    Private Sub HotelBookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripprint_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New HolidayPackageDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, "")
            If CMBHOTELCODE.Text.Trim = "" Then fillHOTELCODE(CMBHOTELCODE, "")
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME, "")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBAGENTNAME.Text.Trim = "" Then fillAGENT(CMBAGENTNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
            If CMBPURADDTAX.Text.Trim = "" Then filltax(CMBPURADDTAX, edit)
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBCARTYPE.Text.Trim = "" Then FILLVEHICLETYPE(CMBCARTYPE, edit)
            If CMBCARNAME.Text.Trim = "" Then FILLVEHICLE(CMBCARNAME, edit, "")
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, edit)
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, edit)
            'If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, edit, "")



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub HolidayPackage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                txtbookingno.ReadOnly = False
            End If

            fillcmb()
            Cursor.Current = Cursors.WaitCursor
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
            'If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE)

            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsHolidayPackages()

                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows


                        TXTUSERPOINTS.Text = Val(dr("USERPOINTS"))
                        TXTREFPOINTS.Text = Val(dr("REFPOINTS"))

                        txtbookingno.ReadOnly = True
                        txtbookingno.Text = TEMPBOOKINGNO
                        TXTSTATECODE.Text = dr("STATECODE")
                        CMBHSNITEMDESC.Text = dr("ITEMDESC")

                        BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")

                        txtemailadd.Text = dr("EMAILADD")
                        txtmobileno.Text = dr("MOBILENO")
                        TXTGUESTADD.Text = dr("GUESTADD")
                        TXTADD.Text = dr("SALEADD")
                        txtrefno.Text = dr("REFNO")

                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                        TXTTOURNAME.Text = dr("TOURNAME")
                        CMBPACKAGETYPE.Text = dr("PACKAGETYPE")
                        CMBQUOTECALC.Text = dr("QUOTETYPE")
                        PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                        TXTARRIVALFROM.Text = Convert.ToString(dr("ARRIVALFROM"))
                        TXTDEPARTURETO.Text = Convert.ToString(dr("DEPARTTO"))
                        TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                        TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))

                        CMBGUESTNAME.Text = dr("GUEST")
                        CMBGROUPDEPARTURE.Text = Convert.ToString(dr("GROUPDEPART"))
                        ''If dr("GROUPDEPART") <> "" Then CMBGROUPDEPARTURE.Enabled = False

                        TXTADULTS.Text = dr("ADULTS")
                        TXTCHILDS.Text = dr("CHILDS")
                        TXTNCCHILDS.Text = dr("NCCHILDS")
                        TXTTOTALPAX.Text = dr("TOTALPAX")

                        TXTEXTRAADULT.Text = dr("EXTRAADULT")
                        TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                        TXTEXTRACHILD.Text = dr("EXTRACHILD")
                        TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        CMBAGENTNAME.Text = dr("AGENTNAME")

                        TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                        TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                        TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                        TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = Val(dr("OURCOMMRS"))

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))

                        CHKDONTPOSTSERVCHGS.Checked = Convert.ToBoolean(dr("DONTPOSTPURSERVCHGS"))

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                        TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))
                        TXTPICKUP.Text = Convert.ToString(dr("PICKUP"))
                        CMBNOTES.Text = Convert.ToString(dr("NOTESNAME"))
                        TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                        CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                        TXTPOLICY.Text = Convert.ToString(dr("POLICY"))

                        TXTHSNCODE.Text = dr("HSNCODE")
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")
                        TXTCESSPER.Text = dr("CESSPER")
                        TXTCESSAMT.Text = dr("CESSAMT")

                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                        End If

                        TXTSALEAMTREC.Text = dr("SALEAMTREC")
                        TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                        TXTSALERETURN.Text = dr("SALERETURN")
                        TXTSALEBAL.Text = dr("SALEBAL")


                        If Val(dr("SALEAMTREC")) > 0 Or Val(dr("SALEEXTRAAMT")) > 0 Then
                            PBRECD.Visible = True
                            cmdshowdetails.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Val(dr("SALERETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If dr("AMDDONE").ToString = True Then
                            TXTAMDNO.Text = dr("AMDNO").ToString()
                            TXTAMDREMARKS.Text = dr("AMDREMARKS").ToString()
                            btnselectpo.Enabled = False
                            lblamd.Visible = True
                        End If

                        TXTAMDNO.Text = dr("AMDNO").ToString()


                        If Convert.ToBoolean(dr("CANCELLED")) = True Then
                            lblcancelled.Visible = True
                            PBCancelled.Visible = True
                        End If

                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                        CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                        CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))


                        'BOOKING DETAILS
                        GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE"), Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                        CMBINCLUSION.Text = Convert.ToString(dr("CINCLUSION"))
                        TXTINCLUSION.Text = Convert.ToString(dr("TINCLUSION"))
                        CMBEXCLUSION.Text = Convert.ToString(dr("CEXCLUSION"))
                        TXTEXCLUSION.Text = Convert.ToString(dr("TEXCLUSION"))
                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    BOOKINGDATE.Focus()
                End If


                'GUEST DETAILS
                dt = OBJBOOKING.SELECTBOOKINGGUESTDETAILS()
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        CMBGUESTNAME.Text = (DR("GUESTNAME"))
                        GRIDGUESTDETAILS.Rows.Add(DR("GUESTSRNO"), DR("GUESTNAME"), DR("AGE"), DR("SEX"))
                    Next
                End If



                'TOUR DETAILS
                dt = OBJBOOKING.SELECTBOOKINGTOURDETAILS()
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDTOUR.Rows.Add(DR("TOURSRNO"), DR("TOURHEADER"), DR("TOURDETAILS"))
                    Next
                End If



                'TRANS DETAILS
                dt = OBJBOOKING.SELECTBOOKINGTRANSDETAILS()
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDTRANS.Rows.Add(DR("CARSRNO"), DR("CONTACTPERSON"), DR("CONTACTNO"), DR("CARTYPE"), DR("CARNAME"), Val(DR("CARADULTS")), Val(DR("CARCHILDS")), Val(DR("CARTOTALPAX")), Format(DR("PICKUPON"), "dd/MM/yyyy"), DR("PICKUPFROM"), DR("PICKUPTIME"), DR("PICKUPDTLS"), Format(DR("DROPON"), "dd/MM/yyyy"), DR("DROPAT"), DR("DROPTIME"), DR("DROPDTLS"), Val(DR("CARDAYS")), DR("ROUTE"), DR("CARITINERARY"), DR("CARNOTE"), Format(Val(DR("CARAMT")), "0.00"))
                    Next
                End If



                'PURCHASE DETAILS
                dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()
                If dt.Rows.Count > 0 Then
                    For Each DR As DataRow In dt.Rows
                        GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(DR("PURDATE"), "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PUREXTRAADULTRATE"), DR("PUREXTRACHILDRATE"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("ADDTAXNAME"), DR("ADDTAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PURCESSPER"), DR("PURCESSAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), DR("PURAMTPAID"), DR("PUREXTRAAMT"), DR("PURRETURN"), DR("PURBALANCE"))
                        'GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(DR("PURDATE"), "dd/MM/yyyy"), DR("PURHSNCODE"), DR("PUREXTRAADULTRATE"), DR("PUREXTRACHILDRATE"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("ADDTAXNAME"), DR("ADDTAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), DR("PURAMTPAID"), DR("PUREXTRAAMT"), DR("PURRETURN"), DR("PURBALANCE"))

                        If Convert.ToBoolean(DR("PURBILLCHECKED")) = True Then GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen

                        If Convert.ToBoolean(DR("COMMINVRAISED")) = True Then
                            GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("PURAMTPAID")) > 0 Or Val(DR("PUREXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("PURRETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                    Next
                    GRIDPURCHASE.ClearSelection()
                End If

                'GET AIRLINE DATA
                Dim OBJAIR1 As New ClsCommon
                Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(BOOKING_NO, 0) AS GROUPDEPNO, ISNULL(BOOKING_GRIDSRNO, 0) AS AIRSRNO, ISNULL(BOOKING_SECTOR, '') AS SECTOR, ISNULL(BOOKING_FLTNO, '') AS FLTNO, ISNULL(BOOKING_TYPE, '') AS AIRLINETYPE, ISNULL(BOOKING_BASIC, 0) AS BASIC, ISNULL(BOOKING_PSF, 0) AS PSF, ISNULL(BOOKING_TAXES, 0) AS TAXES, ISNULL(BOOKING_AMT, 0) AS AIRAMT ", "", " HOLIDAYPACKAGEMASTER_AIRLINE ", " AND HOLIDAYPACKAGEMASTER_AIRLINE.BOOKING_NO = " & TEMPBOOKINGNO & " AND BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_AIRLINE.BOOKING_GRIDSRNO")
                If DTA1.Rows.Count > 0 Then
                    For Each DR1 As DataRow In DTA1.Rows
                        GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("AIRLINETYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                    Next
                    total()
                End If

                'GET GRIDFLIGHT DATA
                Dim OBJAIR2 As New ClsCommon
                Dim DTA2 As DataTable = OBJAIR2.search(" HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE, ISNULL(HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN HOLIDAYPACKAGEMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_YEARID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_BOOKSRNO ASC, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_GRIDSRNO ASC")
                If DTA2.Rows.Count > 0 Then
                    For Each DR2 As DataRow In DTA2.Rows
                        GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                    Next
                    total()
                End If


                'MISC GRID
                Dim OBJMISC As New ClsCommon
                Dim DTM As DataTable = OBJMISC.search("  ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_REMARKS, '') AS REMARKS, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_AMOUNT, 0) AS MISCAMOUNT ", "", "  HOLIDAYPACKAGEMASTER INNER JOIN HOLIDAYPACKAGEMASTER_MISC ON HOLIDAYPACKAGEMASTER.BOOKING_NO = HOLIDAYPACKAGEMASTER_MISC.ENQ_NO AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = HOLIDAYPACKAGEMASTER_MISC.ENQ_YEARID ", " AND HOLIDAYPACKAGEMASTER_MISC.ENQ_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_MISC.ENQ_SRNO ")
                If DTM.Rows.Count > 0 Then
                    For Each DR As DataRow In DTM.Rows
                        GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"), Val(DR("MISCAMOUNT")))
                    Next
                End If

                'GET SCAN DOCS DATA
                Dim OBJCMN As New ClsCommon
                dt = OBJCMN.search(" HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NAME AS NAME, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " HOLIDAYPACKAGEMASTER_UPLOAD ", " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_GRIDSRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If

                total()
                chkchange.CheckState = CheckState.Checked

            End If
            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'EP.Clear()
            'If Not CALDAYS() Then
            '    Exit Sub
            'End If

            Dim alParaval As New ArrayList
            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "SKYMAPS" Or ClientName = "BARODA" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add("PACKAGE PURCHASE REGISTER")
            alParaval.Add("PACKAGE SALE REGISTER")

            alParaval.Add(Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(txtemailadd.Text.Trim)
            alParaval.Add(txtmobileno.Text.Trim)
            alParaval.Add(TXTGUESTADD.Text.Trim)
            alParaval.Add(txtrefno.Text.Trim)

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTTOURNAME.Text.Trim)

            alParaval.Add(CMBPACKAGETYPE.Text.Trim)
            alParaval.Add(CMBQUOTECALC.Text.Trim)

            alParaval.Add(PACKAGEFROM.Value.Date)
            alParaval.Add(PACKAGETO.Value.Date)
            alParaval.Add(TXTARRIVALFROM.Text.Trim)
            alParaval.Add(TXTDEPARTURETO.Text.Trim)
            alParaval.Add(TXTARRFLIGHTNO.Text.Trim)
            alParaval.Add(TXTDEPARTFLIGHTNO.Text.Trim)

            alParaval.Add(TXTADULTS.Text.Trim)
            alParaval.Add(TXTCHILDS.Text.Trim)
            alParaval.Add(TXTNCCHILDS.Text.Trim)
            alParaval.Add(TXTTOTALPAX.Text.Trim)
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)
            alParaval.Add(Val(TXTTOTALMISCAMT.Text.Trim))


            'GUEST DETAILS
            Dim GUESTSRNO As String = ""
            Dim GUESTNAME As String = ""
            Dim AGE As String = ""
            Dim SEX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDGUESTDETAILS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GUESTSRNO = "" Then
                        GUESTSRNO = row.Cells(GGUESTSRNO.Index).Value.ToString
                        GUESTNAME = row.Cells(GGUESTNAME.Index).Value.ToString
                        AGE = row.Cells(GAGE.Index).Value.ToString
                        SEX = row.Cells(GSEX.Index).Value.ToString

                    Else

                        GUESTSRNO = GUESTSRNO & "|" & row.Cells(GGUESTSRNO.Index).Value
                        GUESTNAME = GUESTNAME & "|" & row.Cells(GGUESTNAME.Index).Value
                        AGE = AGE & "|" & row.Cells(GAGE.Index).Value.ToString
                        SEX = SEX & "|" & row.Cells(GSEX.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GUESTSRNO)
            alParaval.Add(GUESTNAME)
            alParaval.Add(AGE)
            alParaval.Add(SEX)



            'BOOKING DETAILS
            Dim gridsrno As String = ""
            Dim HOTELNAME As String = ""
            Dim CONFNO As String = ""
            Dim CONFBY As String = ""
            Dim INCLUSIONS As String = ""
            Dim CHECKIN As String = ""
            Dim CHECKOUT As String = ""
            Dim ROOMTYPE As String = ""
            Dim PLAN As String = ""
            Dim BADULTS As String = ""
            Dim BCHILDS As String = ""
            Dim BINFANTS As String = ""
            Dim BEXTRAADULTS As String = ""
            Dim BEXTRAADULTSRATE As String = ""
            Dim BEXTRACHILDS As String = ""
            Dim BEXTRACHILDSRATE As String = ""
            Dim BTOTALPAX As String = ""
            Dim NOOFROOMS As String = ""
            Dim PACKAGE As String = ""
            Dim RATE As String = ""
            Dim CHILDRATE As String = ""
            Dim INFANTRATE As String = ""
            Dim CURCODE As String = ""
            Dim ROE As String = ""
            Dim AMT As String = ""
            Dim TOTALNIGHTS As String = ""
            Dim ACCDATE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        HOTELNAME = row.Cells(GHOTELNAME.Index).Value.ToString
                        CONFNO = row.Cells(GCONFIRMATIONNO.Index).Value.ToString
                        CONFBY = row.Cells(GCONFIRMEDBY.Index).Value.ToString
                        INCLUSIONS = row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        ACCDATE = Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = row.Cells(groomtype.Index).Value.ToString
                        PLAN = row.Cells(gplan.Index).Value.ToString
                        BADULTS = row.Cells(GADULTS.Index).Value.ToString
                        BCHILDS = row.Cells(GCHILD.Index).Value.ToString
                        BINFANTS = row.Cells(GINFANT.Index).Value.ToString
                        BEXTRAADULTS = row.Cells(GEXTADU.Index).Value.ToString
                        BEXTRAADULTSRATE = row.Cells(GEXADURATE.Index).Value.ToString
                        BEXTRACHILDS = row.Cells(GEXCHILD.Index).Value.ToString
                        BEXTRACHILDSRATE = row.Cells(GEXCHDRATE.Index).Value.ToString
                        BTOTALPAX = row.Cells(GTOTALPAX.Index).Value.ToString
                        NOOFROOMS = row.Cells(gnoofRooms.Index).Value.ToString
                        PACKAGE = row.Cells(gpack.Index).Value.ToString
                        RATE = Val(row.Cells(grate.Index).Value)
                        CHILDRATE = Val(row.Cells(GCHILDRATE.Index).Value)
                        INFANTRATE = Val(row.Cells(GINFANTRATE.Index).Value)
                        CURCODE = row.Cells(GCURCODE.Index).Value.ToString
                        ROE = row.Cells(GROE.Index).Value.ToString
                        AMT = row.Cells(gamt.Index).Value
                        TOTALNIGHTS = row.Cells(GNIGHTS.Index).Value

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value
                        HOTELNAME = HOTELNAME & "|" & row.Cells(GHOTELNAME.Index).Value
                        CONFNO = CONFNO & "|" & row.Cells(GCONFIRMATIONNO.Index).Value.ToString
                        CONFBY = CONFBY & "|" & row.Cells(GCONFIRMEDBY.Index).Value.ToString
                        INCLUSIONS = INCLUSIONS & "|" & row.Cells(GINCLUSIONS.Index).Value.ToString
                        CHECKIN = CHECKIN & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, "MM/dd/yyyy")
                        CHECKOUT = CHECKOUT & "|" & Format(Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date, "MM/dd/yyyy")
                        ROOMTYPE = ROOMTYPE & "|" & row.Cells(groomtype.Index).Value
                        PLAN = PLAN & "|" & row.Cells(gplan.Index).Value.ToString
                        BADULTS = BADULTS & "|" & row.Cells(GADULTS.Index).Value.ToString
                        BCHILDS = BCHILDS & "|" & row.Cells(GCHILD.Index).Value.ToString
                        BINFANTS = BINFANTS & "|" & row.Cells(GINFANT.Index).Value.ToString
                        BEXTRAADULTS = BEXTRAADULTS & "|" & row.Cells(GEXTADU.Index).Value.ToString
                        BEXTRAADULTSRATE = BEXTRAADULTSRATE & "|" & row.Cells(GEXADURATE.Index).Value.ToString
                        BEXTRACHILDS = BEXTRACHILDS & "|" & row.Cells(GEXCHILD.Index).Value.ToString
                        BEXTRACHILDSRATE = BEXTRACHILDSRATE & "|" & row.Cells(GEXCHDRATE.Index).Value.ToString
                        BTOTALPAX = BTOTALPAX & "|" & row.Cells(GTOTALPAX.Index).Value.ToString
                        NOOFROOMS = NOOFROOMS & "|" & row.Cells(gnoofRooms.Index).Value.ToString
                        PACKAGE = PACKAGE & "|" & row.Cells(gpack.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(grate.Index).Value)
                        CHILDRATE = CHILDRATE & "|" & Val(row.Cells(GCHILDRATE.Index).Value)
                        INFANTRATE = INFANTRATE & "|" & Val(row.Cells(GINFANTRATE.Index).Value)
                        CURCODE = CURCODE & "|" & row.Cells(GCURCODE.Index).Value
                        ROE = ROE & "|" & row.Cells(GROE.Index).Value
                        AMT = AMT & "|" & row.Cells(gamt.Index).Value
                        TOTALNIGHTS = TOTALNIGHTS & "|" & row.Cells(GNIGHTS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(ACCDATE)
            alParaval.Add(gridsrno)
            alParaval.Add(HOTELNAME)
            alParaval.Add(CONFNO)
            alParaval.Add(CONFBY)
            alParaval.Add(INCLUSIONS)
            alParaval.Add(CHECKIN)
            alParaval.Add(CHECKOUT)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(PLAN)
            alParaval.Add(BADULTS)
            alParaval.Add(BCHILDS)
            alParaval.Add(BINFANTS)
            alParaval.Add(BEXTRAADULTS)
            alParaval.Add(BEXTRAADULTSRATE)
            alParaval.Add(BEXTRACHILDS)
            alParaval.Add(BEXTRACHILDSRATE)
            alParaval.Add(BTOTALPAX)
            alParaval.Add(NOOFROOMS)
            alParaval.Add(PACKAGE)
            alParaval.Add(RATE)
            alParaval.Add(CHILDRATE)
            alParaval.Add(INFANTRATE)
            alParaval.Add(CURCODE)
            alParaval.Add(ROE)
            alParaval.Add(AMT)
            alParaval.Add(TOTALNIGHTS)



            'TRANS DETAILS
            Dim CARSRNO As String = ""
            Dim CONTACTPERSON As String = ""
            Dim CONTACTNO As String = ""
            Dim CARTYPE As String = ""
            Dim CARNAME As String = ""
            Dim CARADULT As String = ""
            Dim CARCHILD As String = ""
            Dim CARTOTALPAX As String = ""
            Dim PICKUPON As String = ""
            Dim PICKUPFROM As String = ""
            Dim PICKUPTIME As String = ""
            Dim PICKUPDTLS As String = ""
            Dim DROPON As String = ""
            Dim DROPAT As String = ""
            Dim DROPTIME As String = ""
            Dim DROPDTLS As String = ""
            Dim CARDAYS As String = ""
            Dim ROUTE As String = ""
            Dim CARITINERARY As String = ""
            Dim CARNOTE As String = ""
            Dim CARAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(GCARSRNO.Index).Value <> Nothing Then
                    If CARSRNO = "" Then
                        CARSRNO = row.Cells(GCARSRNO.Index).Value.ToString
                        CONTACTPERSON = row.Cells(GCARCONTACTNAME.Index).Value.ToString
                        CONTACTNO = row.Cells(GCARCONTACTNO.Index).Value.ToString
                        CARTYPE = row.Cells(GCARTYPE.Index).Value.ToString
                        CARNAME = row.Cells(GCARNAME.Index).Value.ToString
                        CARADULT = row.Cells(GCARADULTS.Index).Value.ToString
                        CARCHILD = row.Cells(GCARCHILDS.Index).Value.ToString
                        CARTOTALPAX = row.Cells(GCARPAX.Index).Value.ToString
                        PICKUPON = Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = row.Cells(GCARPICKUPDTLS.Index).Value.ToString

                        DROPON = Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = row.Cells(GCARDAYS.Index).Value.ToString

                        ROUTE = row.Cells(GCARROUTE.Index).Value.ToString
                        CARITINERARY = row.Cells(GCARITINERARY.Index).Value.ToString
                        CARNOTE = row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = row.Cells(GCARAMT.Index).Value.ToString

                    Else

                        CARSRNO = CARSRNO & "|" & row.Cells(GCARSRNO.Index).Value.ToString
                        CONTACTPERSON = CONTACTPERSON & "|" & row.Cells(GCARCONTACTNAME.Index).Value.ToString
                        CONTACTNO = CONTACTNO & "|" & row.Cells(GCARCONTACTNO.Index).Value.ToString
                        CARTYPE = CARTYPE & "|" & row.Cells(GCARTYPE.Index).Value.ToString
                        CARNAME = CARNAME & "|" & row.Cells(GCARNAME.Index).Value.ToString
                        CARADULT = CARADULT & "|" & row.Cells(GCARADULTS.Index).Value.ToString
                        CARCHILD = CARCHILD & "|" & row.Cells(GCARCHILDS.Index).Value.ToString
                        CARTOTALPAX = CARTOTALPAX & "|" & row.Cells(GCARPAX.Index).Value.ToString
                        PICKUPON = PICKUPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARPICKUP.Index).Value).Date, "MM/dd/yyyy")
                        PICKUPFROM = PICKUPFROM & "|" & row.Cells(GCARPICKUPFROM.Index).Value.ToString
                        PICKUPTIME = PICKUPTIME & "|" & row.Cells(GCARPICKUPTIME.Index).Value.ToString
                        PICKUPDTLS = PICKUPDTLS & "|" & row.Cells(GCARPICKUPDTLS.Index).Value.ToString

                        DROPON = DROPON & "|" & Format(Convert.ToDateTime(row.Cells(GCARDROP.Index).Value).Date, "MM/dd/yyyy")
                        DROPAT = DROPAT & "|" & row.Cells(GCARDROPTO.Index).Value.ToString
                        DROPTIME = DROPTIME & "|" & row.Cells(GCARDROPTIME.Index).Value.ToString
                        DROPDTLS = DROPDTLS & "|" & row.Cells(GCARDROPDTLS.Index).Value.ToString
                        CARDAYS = CARDAYS & "|" & row.Cells(GCARDAYS.Index).Value.ToString

                        ROUTE = ROUTE & "|" & row.Cells(GCARROUTE.Index).Value.ToString
                        CARITINERARY = CARITINERARY & "|" & row.Cells(GCARITINERARY.Index).Value.ToString
                        CARNOTE = CARNOTE & "|" & row.Cells(GCARNOTE.Index).Value.ToString
                        CARAMT = CARAMT & "|" & Val(row.Cells(GCARAMT.Index).Value.ToString)

                    End If
                End If
            Next


            alParaval.Add(CARSRNO)
            alParaval.Add(CONTACTPERSON)
            alParaval.Add(CONTACTNO)
            alParaval.Add(CARTYPE)
            alParaval.Add(CARNAME)
            alParaval.Add(CARADULT)
            alParaval.Add(CARCHILD)
            alParaval.Add(CARTOTALPAX)
            alParaval.Add(PICKUPON)
            alParaval.Add(PICKUPFROM)
            alParaval.Add(PICKUPTIME)
            alParaval.Add(PICKUPDTLS)
            alParaval.Add(DROPON)
            alParaval.Add(DROPAT)
            alParaval.Add(DROPTIME)
            alParaval.Add(DROPDTLS)
            alParaval.Add(CARDAYS)
            alParaval.Add(ROUTE)
            alParaval.Add(CARITINERARY)
            alParaval.Add(CARNOTE)
            alParaval.Add(CARAMT)


            'PURCHASE DETAILS
            Dim PURBILLCHECKED As String = ""
            Dim PURSRNO As String = ""
            Dim PURNAME As String = ""
            Dim PURDATE As String = ""
            'Dim PURHSNITEMDESC As String = ""
            Dim PURHSNCODE As String = ""
            Dim PUREXTRAADULTRATE As String = ""
            Dim PUREXTRACHILDRATE As String = ""
            Dim PURAMT As String = ""
            Dim PURDISCPER As String = ""
            Dim PURDISC As String = ""
            Dim PURSUBTOTAL As String = ""
            Dim PURCOMMPER As String = ""
            Dim PURCOMM As String = ""
            Dim PURTDSPER As String = ""
            Dim PURTDS As String = ""
            Dim PURSERVTAX As String = ""
            Dim PURSERVCHGS As String = ""
            Dim PURNETT As String = ""
            Dim PURTAXNAME As String = ""
            Dim PURTAX As String = ""
            Dim PURADDTAXNAME As String = ""
            Dim PURADDTAX As String = ""
            Dim PURCGSTPER As String = ""
            Dim PURCGSTAMT As String = ""
            Dim PURSGSTPER As String = ""
            Dim PURSGSTAMT As String = ""
            Dim PURIGSTPER As String = ""
            Dim PURIGSTAMT As String = ""
            Dim PURCESSPER As String = ""
            Dim PURCESSAMT As String = ""
            Dim PUROTHERCHGSNAME As String = ""
            Dim PUROTHERCHGS As String = ""
            Dim PURROUNDOFF As String = ""
            Dim PURGTOTAL As String = ""
            Dim PURAMTPAID As String = ""
            Dim PUREXTRAAMT As String = ""
            Dim PURRETURN As String = ""
            Dim PURBALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GPURSRNO.Index).Value <> Nothing Then
                    If PURSRNO = "" Then

                        PURBILLCHECKED = row.Cells(GCHK.Index).Value
                        PURSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = row.Cells(GPURNAME.Index).Value.ToString
                        PURDATE = Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        'PURHSNITEMDESC = row.Cells(GPURHSNITEMDESC.Index).Value.ToString
                        PURHSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        PUREXTRAADULTRATE = row.Cells(GEXTRAADULTRATE.Index).Value.ToString
                        PUREXTRACHILDRATE = row.Cells(GEXTRACHILDRATE.Index).Value.ToString
                        PURAMT = row.Cells(GPURAMT.Index).Value.ToString
                        PURDISCPER = row.Cells(GDISCPER.Index).Value.ToString
                        PURDISC = row.Cells(GDISC.Index).Value.ToString
                        PURSUBTOTAL = row.Cells(GSUBTOTAL.Index).Value.ToString
                        PURCOMMPER = row.Cells(GCOMMPER.Index).Value.ToString
                        PURCOMM = row.Cells(GCOMM.Index).Value.ToString
                        PURTDSPER = row.Cells(GTDSPER.Index).Value.ToString
                        PURTDS = row.Cells(GTDS.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GSERVTAX.Index).Value) = True Then
                            PURSERVTAX = 1
                        Else
                            PURSERVTAX = 0
                        End If
                        'PURSERVTAX = row.Cells(GSERVTAX.Index).Value
                        PURSERVCHGS = row.Cells(GSERVCHGS.Index).Value.ToString
                        PURNETT = row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = row.Cells(GTAX.Index).Value.ToString
                        PURTAX = row.Cells(GTAXAMT.Index).Value.ToString
                        PURADDTAXNAME = row.Cells(GADDTAX.Index).Value.ToString
                        PURADDTAX = row.Cells(GADDTAXAMT.Index).Value.ToString
                        PURCGSTPER = row.Cells(GCGSTPER.Index).Value.ToString
                        PURCGSTAMT = row.Cells(GCGSTAMT.Index).Value.ToString
                        PURSGSTPER = row.Cells(GSGSTPER.Index).Value.ToString
                        PURSGSTAMT = row.Cells(GSGSTAMT.Index).Value.ToString
                        PURIGSTPER = row.Cells(GIGSTPER.Index).Value.ToString
                        PURIGSTAMT = row.Cells(GIGSTAMT.Index).Value.ToString
                        PURCESSPER = row.Cells(GPURCESSPER.Index).Value.ToString
                        PURCESSAMT = row.Cells(GPURCESSAMT.Index).Value.ToString

                        PUROTHERCHGSNAME = row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = row.Cells(GOTHERCHGS.Index).Value.ToString
                        PURROUNDOFF = row.Cells(GROUNDOFF.Index).Value.ToString
                        PURGTOTAL = row.Cells(GGRANDTOTAL.Index).Value.ToString
                        PURAMTPAID = row.Cells(GPURAMTPAID.Index).Value.ToString
                        PUREXTRAAMT = row.Cells(GPUREXTRAAMT.Index).Value.ToString
                        PURRETURN = row.Cells(GPURRETURN.Index).Value.ToString
                        PURBALANCE = row.Cells(GPURBAL.Index).Value.ToString

                    Else

                        PURBILLCHECKED = PURBILLCHECKED & "|" & row.Cells(GCHK.Index).Value
                        PURSRNO = PURSRNO & "|" & row.Cells(GPURSRNO.Index).Value
                        PURNAME = PURNAME & "|" & row.Cells(GPURNAME.Index).Value
                        PURDATE = PURDATE & "|" & Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        'PURHSNITEMDESC = PURHSNITEMDESC & "|" & row.Cells(GPURHSNITEMDESC.Index).Value.ToString
                        PURHSNCODE = PURHSNCODE & " |" & row.Cells(GHSNCODE.Index).Value.ToString
                        PUREXTRAADULTRATE = PUREXTRAADULTRATE & "|" & row.Cells(GEXTRAADULTRATE.Index).Value.ToString
                        PUREXTRACHILDRATE = PUREXTRACHILDRATE & "|" & row.Cells(GEXTRACHILDRATE.Index).Value.ToString
                        PURAMT = PURAMT & "|" & row.Cells(GPURAMT.Index).Value.ToString
                        PURDISCPER = PURDISCPER & "|" & row.Cells(GDISCPER.Index).Value.ToString
                        PURDISC = PURDISC & "|" & row.Cells(GDISC.Index).Value.ToString
                        PURSUBTOTAL = PURSUBTOTAL & "|" & row.Cells(GSUBTOTAL.Index).Value.ToString
                        PURCOMMPER = PURCOMMPER & "|" & row.Cells(GCOMMPER.Index).Value.ToString
                        PURCOMM = PURCOMM & "|" & row.Cells(GCOMM.Index).Value.ToString
                        PURTDSPER = PURTDSPER & "|" & row.Cells(GTDSPER.Index).Value.ToString
                        PURTDS = PURTDS & "|" & row.Cells(GTDS.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GSERVTAX.Index).Value) = True Then
                            PURSERVTAX = PURSERVTAX & "|" & 1
                        Else
                            PURSERVTAX = PURSERVTAX & "|" & 0
                        End If
                        'PURSERVTAX = PURSERVTAX & "|" & row.Cells(GSERVTAX.Index).Value
                        PURSERVCHGS = PURSERVCHGS & "|" & row.Cells(GSERVCHGS.Index).Value.ToString


                        PURNETT = PURNETT & "|" & row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = PURTAXNAME & "|" & row.Cells(GTAX.Index).Value.ToString
                        PURTAX = PURTAX & "|" & row.Cells(GTAXAMT.Index).Value.ToString
                        PURADDTAXNAME = PURADDTAXNAME & "|" & row.Cells(GADDTAX.Index).Value.ToString
                        PURADDTAX = PURADDTAX & "|" & row.Cells(GADDTAXAMT.Index).Value.ToString
                        PURCGSTPER = PURCGSTPER & "|" & row.Cells(GCGSTPER.Index).Value.ToString
                        PURCGSTAMT = PURCGSTAMT & "|" & row.Cells(GCGSTAMT.Index).Value.ToString
                        PURSGSTPER = PURSGSTPER & "|" & row.Cells(GSGSTPER.Index).Value.ToString
                        PURSGSTAMT = PURSGSTAMT & "|" & row.Cells(GSGSTAMT.Index).Value.ToString
                        PURIGSTPER = PURIGSTPER & "|" & row.Cells(GIGSTPER.Index).Value.ToString
                        PURIGSTAMT = PURIGSTAMT & "|" & row.Cells(GIGSTAMT.Index).Value.ToString
                        PURCESSPER = PURCESSPER & "|" & row.Cells(GPURCESSPER.Index).Value.ToString
                        PURCESSAMT = PURCESSAMT & "|" & row.Cells(GPURCESSAMT.Index).Value.ToString


                        PUROTHERCHGSNAME = PUROTHERCHGSNAME & "|" & row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = PUROTHERCHGS & "|" & row.Cells(GOTHERCHGS.Index).Value.ToString
                        PURROUNDOFF = PURROUNDOFF & "|" & row.Cells(GROUNDOFF.Index).Value.ToString
                        PURGTOTAL = PURGTOTAL & "|" & row.Cells(GGRANDTOTAL.Index).Value.ToString
                        PURAMTPAID = PURAMTPAID & "|" & row.Cells(GPURAMTPAID.Index).Value.ToString
                        PUREXTRAAMT = PUREXTRAAMT & "|" & row.Cells(GPUREXTRAAMT.Index).Value.ToString
                        PURRETURN = PURRETURN & "|" & row.Cells(GPURRETURN.Index).Value.ToString
                        PURBALANCE = PURBALANCE & "|" & row.Cells(GPURBAL.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(PURBILLCHECKED)
            alParaval.Add(PURSRNO)
            alParaval.Add(PURNAME)
            alParaval.Add(PURDATE)
            'alParaval.Add(PURHSNITEMDESC)
            alParaval.Add(PURHSNCODE)
            alParaval.Add(PUREXTRAADULTRATE)
            alParaval.Add(PUREXTRACHILDRATE)
            alParaval.Add(PURAMT)
            alParaval.Add(PURDISCPER)
            alParaval.Add(PURDISC)
            alParaval.Add(PURSUBTOTAL)
            alParaval.Add(PURCOMMPER)
            alParaval.Add(PURCOMM)
            alParaval.Add(PURTDSPER)
            alParaval.Add(PURTDS)
            alParaval.Add(PURSERVTAX)
            alParaval.Add(PURSERVCHGS)
            alParaval.Add(PURNETT)
            alParaval.Add(PURTAXNAME)
            alParaval.Add(PURTAX)
            alParaval.Add(PURADDTAXNAME)
            alParaval.Add(PURADDTAX)
            alParaval.Add(PURCGSTPER)
            alParaval.Add(PURCGSTAMT)
            alParaval.Add(PURSGSTPER)
            alParaval.Add(PURSGSTAMT)
            alParaval.Add(PURIGSTPER)
            alParaval.Add(PURIGSTAMT)
            alParaval.Add(PURCESSPER)
            alParaval.Add(PURCESSAMT)


            alParaval.Add(PUROTHERCHGSNAME)
            alParaval.Add(PUROTHERCHGS)
            alParaval.Add(PURROUNDOFF)
            alParaval.Add(PURGTOTAL)
            alParaval.Add(PURAMTPAID)
            alParaval.Add(PUREXTRAAMT)
            alParaval.Add(PURRETURN)
            alParaval.Add(PURBALANCE)
            alParaval.Add(Val(TXTFINALPURAMT.Text.Trim))




            'SALE DETAILS
            alParaval.Add(Val(TXTEXTRAADULT.Text.Trim))
            alParaval.Add(Val(TXTEXTRAADULTRATE.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHILD.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHILDRATE.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)


            alParaval.Add(TXTTOTALNIGHTS.Text.Trim)
            alParaval.Add(TXTTOTALROOMS.Text.Trim)



            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(CMBAGENTNAME.Text.Trim)
            alParaval.Add(Val(TXTAGENTCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTAGENTCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTAGENTTDSPER.Text.Trim))
            alParaval.Add(Val(TXTAGENTTDSRS.Text.Trim))


            'SALE VALUES
            alParaval.Add(Val(TXTCARTOTALAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(CMBADDTAX.Text.Trim)
            alParaval.Add(Val(TXTADDTAX.Text.Trim))
            alParaval.Add(CHKTAXSERVCHGS.CheckState)

            alParaval.Add(CMBOTHERCHGS.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBOOKINGDESC.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            alParaval.Add(TXTPICKUP.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(Val(TXTSALEAMTREC.Text.Trim))
            alParaval.Add(Val(TXTSALEEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTSALERETURN.Text.Trim))
            alParaval.Add(Val(TXTSALEBAL.Text.Trim))

            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(CHKREFUNDED.CheckState)
            alParaval.Add(CHKFAILED.CheckState)

            alParaval.Add(Val(TXTUSERPOINTS.Text.Trim))
            alParaval.Add(Val(TXTREFPOINTS.Text.Trim))
            alParaval.Add(CHKDONTPOSTSERVCHGS.CheckState)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(ClientName)
            alParaval.Add(Val(TXTENQNO.Text.Trim))
            alParaval.Add(CMBNOTES.Text.Trim)
            alParaval.Add(CMBCANCEL.Text.Trim)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(CHKMANUAL.CheckState)
            alParaval.Add(CHKPURMANUAL.CheckState)


            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTCESSPER.Text.Trim))
            alParaval.Add(Val(TXTCESSAMT.Text.Trim))

            'GRID AIRLINE
            Dim AIRSRNO As String = ""
            Dim SECTOR As String = ""
            Dim FLTNO As String = ""
            Dim AIRLINETYPE As String = ""
            Dim BASIC As String = ""
            Dim PSF As String = ""
            Dim TAXES As String = ""
            Dim AIRAMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
                If row.Cells(GAIRSRNO.Index).Value <> Nothing Then
                    If AIRSRNO = "" Then
                        AIRSRNO = row.Cells(GAIRSRNO.Index).Value.ToString
                        SECTOR = row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = row.Cells(GFLTNO.Index).Value.ToString
                        AIRLINETYPE = row.Cells(GTYPE.Index).Value.ToString
                        BASIC = row.Cells(GBASIC.Index).Value.ToString
                        PSF = row.Cells(GPSF.Index).Value.ToString
                        TAXES = row.Cells(GTAXES.Index).Value.ToString
                        AIRAMT = row.Cells(GTOTAL.Index).Value

                    Else
                        AIRSRNO = AIRSRNO & "|" & row.Cells(GAIRSRNO.Index).Value.ToString
                        SECTOR = SECTOR & "|" & row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = FLTNO & "|" & row.Cells(GFLTNO.Index).Value.ToString
                        AIRLINETYPE = AIRLINETYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        BASIC = BASIC & "|" & row.Cells(GBASIC.Index).Value.ToString
                        PSF = PSF & "|" & row.Cells(GPSF.Index).Value.ToString
                        TAXES = TAXES & "|" & row.Cells(GTAXES.Index).Value.ToString
                        AIRAMT = AIRAMT & "|" & row.Cells(GTOTAL.Index).Value

                    End If
                End If
            Next

            alParaval.Add(AIRSRNO)
            alParaval.Add(SECTOR)
            alParaval.Add(FLTNO)
            alParaval.Add(AIRLINETYPE)
            alParaval.Add(BASIC)
            alParaval.Add(PSF)
            alParaval.Add(TAXES)
            alParaval.Add(AIRAMT)

            'FLIGHT GRID
            Dim FLIGHTSRNO As String = ""
            Dim BOOKSRNO As String = ""
            Dim FROMSEC As String = ""
            Dim TOSEC As String = ""
            Dim FLIGHTNO As String = ""
            Dim FLIGHTDATE As String = ""
            Dim ARRIVES As String = ""
            Dim FLIGHTCLASS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If row.Cells(GFLIGHTSRNO.Index).Value <> Nothing Then
                    If FLIGHTSRNO = "" Then
                        FLIGHTSRNO = row.Cells(GFLIGHTSRNO.Index).Value.ToString
                        BOOKSRNO = row.Cells(GBOOKSRNO.Index).Value.ToString
                        FROMSEC = row.Cells(GFROM.Index).Value.ToString
                        TOSEC = row.Cells(GTO.Index).Value.ToString
                        FLIGHTNO = row.Cells(GFLIGHTNO.Index).Value.ToString
                        FLIGHTDATE = row.Cells(GFLTDATE.Index).Value.ToString
                        If row.Cells(GFLTARR.Index).Value = Nothing Then ARRIVES = "" Else ARRIVES = row.Cells(GFLTARR.Index).Value.ToString
                        FLIGHTCLASS = row.Cells(GCLASS.Index).Value.ToString
                    Else
                        FLIGHTSRNO = FLIGHTSRNO & "|" & row.Cells(GFLIGHTSRNO.Index).Value.ToString
                        BOOKSRNO = BOOKSRNO & "|" & row.Cells(GBOOKSRNO.Index).Value.ToString
                        FROMSEC = FROMSEC & "|" & row.Cells(GFROM.Index).Value.ToString
                        TOSEC = TOSEC & "|" & row.Cells(GTO.Index).Value.ToString
                        FLIGHTNO = FLIGHTNO & "|" & row.Cells(GFLIGHTNO.Index).Value.ToString
                        FLIGHTDATE = FLIGHTDATE & "|" & row.Cells(GFLTDATE.Index).Value.ToString
                        If row.Cells(GFLTARR.Index).Value = Nothing Then ARRIVES = ARRIVES & "|" & "" Else ARRIVES = ARRIVES & "|" & row.Cells(GFLTARR.Index).Value.ToString
                        FLIGHTCLASS = FLIGHTCLASS & "|" & row.Cells(GCLASS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(FLIGHTSRNO)
            alParaval.Add(BOOKSRNO)
            alParaval.Add(FROMSEC)
            alParaval.Add(TOSEC)
            alParaval.Add(FLIGHTNO)
            alParaval.Add(FLIGHTDATE)
            alParaval.Add(ARRIVES)
            alParaval.Add(FLIGHTCLASS)



            'GRID MISC
            Dim MISCSRNO As String = ""
            Dim MISCSERVICETYPE As String = ""
            Dim MISCREMARKS As String = ""
            Dim MISCAMOUNT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDMISC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If MISCSRNO = "" Then
                        MISCSRNO = Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = row.Cells(GMISCREMARKS.Index).Value.ToString
                        MISCAMOUNT = Val(row.Cells(GMISCAMOUNT.Index).Value)

                    Else
                        MISCSRNO = MISCSRNO & "|" & Val(row.Cells(GMISCSRNO.Index).Value)
                        MISCSERVICETYPE = MISCSERVICETYPE & "|" & row.Cells(GMISCSERVICETYPE.Index).Value.ToString
                        MISCREMARKS = MISCREMARKS & "|" & row.Cells(GMISCREMARKS.Index).Value.ToString
                        MISCAMOUNT = MISCAMOUNT & "|" & Val(row.Cells(GMISCAMOUNT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(MISCSRNO)
            alParaval.Add(MISCSERVICETYPE)
            alParaval.Add(MISCREMARKS)
            alParaval.Add(MISCAMOUNT)

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(CMBINCLUSION.Text.Trim)
            alParaval.Add(CMBEXCLUSION.Text.Trim)
            alParaval.Add(TXTINCLUSION.Text.Trim)
            alParaval.Add(TXTEXCLUSION.Text.Trim)

            Dim OBJBOOKING As New ClsHolidayPackages()
            OBJBOOKING.alParaval = alParaval


            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTNO As DataTable = OBJBOOKING.save()
                MessageBox.Show("Details Added")
                PRINTREPORT(DTNO.Rows(0).Item(0))
                TEMPBOOKINGNO = DTNO.Rows(0).Item(0)
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.update()
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(TEMPBOOKINGNO)
            End If

            'SEND SMS
            If chkmobile.CheckState = CheckState.Checked Then SMSCODE()


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\HOLIDAY") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\HOLIDAY")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\HOLIDAY") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next
            If GRIDTOUR.RowCount > 0 Then SAVETOUR()

            clear()
            BOOKINGDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub SAVETOUR()
        Try
            'GRID TOUR
            Dim OBJTOUR As New ClsHolidayPackages
            For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GTOURSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(row.Cells(GTOURSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GHEADER.Index).Value)
                    ALPARAVAL.Add(row.Cells(GDETAILS.Index).Value)



                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)

                    OBJTOUR.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJTOUR.SAVETOUR()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDAIRDOUBLECLICK = True
                TXTAIRSRNO.Text = GRIDAIRLINE.Item(GAIRSRNO.Index, e.RowIndex).Value.ToString
                TXTSECTOR.Text = GRIDAIRLINE.Item(GSECTOR.Index, e.RowIndex).Value.ToString
                TXTFLTNO.Text = GRIDAIRLINE.Item(GFLTNO.Index, e.RowIndex).Value.ToString
                CMBAIRLINETYPE.Text = GRIDAIRLINE.Item(GTYPE.Index, e.RowIndex).Value.ToString
                TXTBASIC.Text = GRIDAIRLINE.Item(GBASIC.Index, e.RowIndex).Value.ToString
                TXTPSF.Text = GRIDAIRLINE.Item(GPSF.Index, e.RowIndex).Value.ToString
                TXTGRIDTAX.Text = GRIDAIRLINE.Item(GTAXES.Index, e.RowIndex).Value.ToString
                TXTAIRAMT.Text = GRIDAIRLINE.Item(GTOTAL.Index, e.RowIndex).Value.ToString
                tempFLIGHTrow = e.RowIndex
                FILLGRIDSECTOR()
                TXTSECTOR.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDAIRLINE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDAIRLINE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDAIRLINE.RowCount > 0 Then


                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDAIRDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim TINDEX As Integer = GRIDAIRLINE.CurrentRow.Index

                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = TINDEX Then GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                    If ROW.Cells(GBOOKSRNO.Index).Value > TINDEX Then ROW.Cells(GBOOKSRNO.Index).Value = ROW.Cells(GBOOKSRNO.Index).Value - 1
                Next

                GRIDAIRLINE.Rows.RemoveAt(TINDEX)
                getsrno(GRIDAIRLINE)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDSECTOR()
        Try
            Dim FROMSECNAME As String = ""
            Dim TOSECNAME As String = ""
            Dim STARTPOS As Integer = 0
            Dim J As Integer = 1
            TXTTEMPSECTOR.Clear()
            GRIDSECTOR.RowCount = 0
LINE1:
            For I As Integer = 0 To 6
                FROMSECNAME = TXTSECTOR.Text.Substring(STARTPOS, 3)
                If TXTSECTOR.Text.Length > STARTPOS + 4 Then TOSECNAME = TXTSECTOR.Text.Substring(STARTPOS + 4, 3)
                If TOSECNAME.Trim = "" Then Exit For
                If TXTTEMPSECTOR.Text.Trim = "" Then
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & FROMSECNAME & "/" & TOSECNAME
                Else
                    TXTTEMPSECTOR.Text = TXTTEMPSECTOR.Text.Trim & "/" & TOSECNAME
                End If
                Dim flight_number As String = getFlightNumber(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_arrives As String = getFlightArrives(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_class As String = getFlightClass(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)
                Dim flight_date As String = getFlightDate(Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, J, TXTSECTOR.Text, STARTPOS)

                If flight_date = "" Then
                    flight_date = Format(PACKAGEFROM.Value.Date, "dd/MM/yyyy").ToString
                Else
                    flight_date = Format(Convert.ToDateTime(flight_date).Date, "dd/MM/yyyy").ToString
                End If

                GRIDSECTOR.Rows.Add(0, Val(TXTAIRSRNO.Text.Trim), FROMSECNAME, TOSECNAME, flight_number, flight_date, flight_arrives, flight_class)
                STARTPOS += 4
                J += 1
                TOSECNAME = ""
            Next

            If GRIDSECTOR.Rows.Count = 0 And TXTSECTOR.Text.Substring(4, 3).Trim <> "" Then GoTo LINE1
            getsrno(GRIDSECTOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function splitSectors(ByVal SECTORS As String) As String
        Try

            Dim TRIMMED As String() = SECTORS.Split("/")
            Dim I As Integer = 0
            Dim STR As String = ""
            For I = 0 To TRIMMED.Length - 1
                If TRIMMED(I).Trim.ToString <> "" Then
                    STR = STR & TRIMMED(I) & "/"
                End If
            Next

            STR = Mid(STR, 1, STR.Length - 1)

            Return STR
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Function getFlightNumber(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_num As String = ""
        POS += 4
        'If gridDoubleClick = False Then
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLIGHTNO.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_num = drow.Cells(GFLIGHTNO.Index).Value
                Exit For
            End If
        Next
        ' If ClientName = "MAYUR" Then

        If return_flight_num.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLIGHTNO.Index).Value.ToString.Trim <> "" Then
                    return_flight_num = drow.Cells(GFLIGHTNO.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        'End If
        Return return_flight_num
    End Function

    Function getBookingSr(ByVal trimSECTORS As String) As Integer
        Dim booksrno As Integer = 0
        For Each dbrows As System.Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
            If dbrows.Cells(GSECTOR.Index).Value.ToString.Trim = trimSECTORS Then
                booksrno = Convert.ToInt32(dbrows.Cells(GAIRSRNO.Index).Value)
            End If
        Next
        Return booksrno
    End Function

    Function getFlightArrives(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_arrives As String = ""
        POS += 4
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_arrives = drow.Cells(GARRIVAL.Index).Value
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_arrives.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" Then
                    return_flight_arrives = drow.Cells(GARRIVAL.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        If ClientName = "JAIN" Then
            If return_flight_arrives.Trim.Length = 0 Then return_flight_arrives = "Y"
        End If
        Return return_flight_arrives
    End Function

    Function getFlightClass(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_class As String = ""
        POS += 4
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_class = drow.Cells(GCLASS.Index).Value
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_class.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GCLASS.Index).Value.ToString.Trim <> "" Then
                    return_flight_class = drow.Cells(GCLASS.Index).Value
                    Exit For
                End If
            Next
        End If


        Return return_flight_class
    End Function

    Function getFlightDate(ByVal booksrno As Integer, ByVal sec_from As String, ByVal sec_to As String, ByVal J As Integer, ByVal SECTORS As String, ByVal POS As Integer) As String
        Dim return_flight_date As String = ""
        POS += 4
        'If gridDoubleClick = False Then
        For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
            If drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And Convert.ToString(drow.Cells(GFLTDATE.Index).Value).ToString <> "" And drow.Cells(GFLIGHTSRNO.Index).Value = J Then
                return_flight_date = Convert.ToString(drow.Cells(GFLTDATE.Index).Value).ToString
                Exit For
            End If
        Next
        'If ClientName = "MAYUR" Then
        If return_flight_date.Trim = "" And GRIDFLIGHT.Rows.Count > 0 Then
            Dim trimSECTORS As String = splitSectors(SECTORS)
            booksrno = getBookingSr(trimSECTORS)
            Dim flight_sr_no As Integer = 0
            If POS > 0 Then flight_sr_no = (POS / 4)

            For Each drow As System.Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If flight_sr_no = Convert.ToInt32(drow.Cells(GFLIGHTSRNO.Index).Value) And drow.Cells(GBOOKSRNO.Index).Value = booksrno And drow.Cells(GFROM.Index).Value = sec_from And drow.Cells(GTO.Index).Value = sec_to And drow.Cells(GFLTDATE.Index).Value.ToString.Trim <> "" Then
                    return_flight_date = drow.Cells(GFLTDATE.Index).Value
                    Exit For
                End If
            Next
        End If
        'End If
        ' End If
        Return return_flight_date
    End Function

    Private Sub TXTAIRAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRAMT.Validating
        Try
            If TXTSECTOR.Text <> "   /   /   /   /   /" Then
                FILLAIRLINEGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLAIRLINEGRID()
        Try
            GRIDAIRLINE.Enabled = True
            If GRIDAIRDOUBLECLICK = False Then
                GRIDAIRLINE.Rows.Add(Val(TXTAIRSRNO.Text.Trim), TXTTEMPSECTOR.Text.Trim, TXTFLTNO.Text.Trim, CMBAIRLINETYPE.Text.Trim, Format(Val(TXTBASIC.Text.Trim), "0.00"), Format(Val(TXTPSF.Text.Trim), "0.00"), Format(Val(TXTGRIDTAX.Text.Trim), "0.00"), Format(Val(TXTAIRAMT.Text.Trim), "0.00"), 0)
                getsrno(GRIDAIRLINE)

                'ADD IN FLIGHT ALSO
                For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
                Next

            ElseIf GRIDAIRDOUBLECLICK = True Then
                GRIDAIRLINE.Item(GAIRSRNO.Index, tempFLIGHTrow).Value = Val(TXTAIRSRNO.Text.Trim)
                GRIDAIRLINE.Item(GSECTOR.Index, tempFLIGHTrow).Value = TXTTEMPSECTOR.Text.Trim
                GRIDAIRLINE.Item(GFLTNO.Index, tempFLIGHTrow).Value = TXTFLTNO.Text.Trim
                GRIDAIRLINE.Item(GTYPE.Index, tempFLIGHTrow).Value = CMBAIRLINETYPE.Text.Trim
                GRIDAIRLINE.Item(GBASIC.Index, tempFLIGHTrow).Value = Format(Val(TXTBASIC.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GPSF.Index, tempFLIGHTrow).Value = Format(Val(TXTPSF.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTAXES.Index, tempFLIGHTrow).Value = Format(Val(TXTGRIDTAX.Text.Trim), "0.00")
                GRIDAIRLINE.Item(GTOTAL.Index, tempFLIGHTrow).Value = Format(Val(TXTAIRAMT.Text.Trim), "0.00")


                'FIRST REMOVE OLD RECORDS AND THEN ADD NEW 
LINE1:
                For Each ROW As DataGridViewRow In GRIDFLIGHT.Rows
                    If ROW.Cells(GBOOKSRNO.Index).Value = tempFLIGHTrow + 1 Then
                        GRIDFLIGHT.Rows.RemoveAt(ROW.Index)
                        GoTo LINE1
                    End If
                Next
                For Each ROW As DataGridViewRow In GRIDSECTOR.Rows
                    GRIDFLIGHT.Rows.Add(ROW.Cells(GSECSRNO.Index).Value, ROW.Cells(GSECBOOKSRNO.Index).Value, ROW.Cells(GSECFROM.Index).Value, ROW.Cells(GSECTO.Index).Value, ROW.Cells(GSECFLTNO.Index).Value, ROW.Cells(GSECFLTDATE.Index).Value, ROW.Cells(GARRIVAL.Index).Value, ROW.Cells(GSECCLASS.Index).Value)
                Next

                GRIDAIRDOUBLECLICK = False
            End If
            total()
            GRIDAIRLINE.FirstDisplayedScrollingRowIndex = GRIDAIRLINE.RowCount - 1

            TXTAIRSRNO.Text = GRIDAIRLINE.RowCount + 1
            TXTSECTOR.Clear()
            TXTFLTNO.Clear()
            CMBAIRLINETYPE.Text = ""
            TXTBASIC.Clear()
            TXTPSF.Clear()
            TXTGRIDTAX.Clear()
            TXTAIRAMT.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        If BOOKINGDATE.Text = "__/__/____" Then
            EP.SetError(BOOKINGDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BOOKINGDATE.Text) Then
                EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        If TXTTOURNAME.Text.Trim = "" Then
            EP.SetError(TXTTOURNAME, " Please Fill Tour name")
            bln = False
        End If

        If ClientName = "URMI" And txtrefno.Text.Trim.Length = 0 Then
            EP.SetError(txtrefno, "Enter Ref No")
            bln = False
        End If

        If CMBGUESTNAME.Text.Trim <> "" Then
            GRIDGUESTDETAILS.RowCount = 0
            GRIDGUESTDETAILS.Rows.Add(1, CMBGUESTNAME.Text.Trim, 0, "Male")
        Else
            EP.SetError(CMBGUESTNAME, " Please Fill Guest Name ")
            bln = False
        End If

        If CMBSOURCE.Text.Trim.Length = 0 And ClientName = "WORLDSPIN" Then
            EP.SetError(CMBSOURCE, "Select Source")
            bln = False
        End If


        If (ClientName = "CLASSIC" And edit = False And UserName = "Admin") Or ((ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Or ClientName = "SKYMAPS") And edit = False) Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim dt1 As DataTable
                Dim OBJSEARCH As New ClsCommon
                dt1 = OBJSEARCH.search(" BOOKING_NO", "", " HOLIDAYPACKAGEMASTER", " AND HOLIDAYPACKAGEMASTER.BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = " & CmpId & " AND  HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId)
                If dt1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Allready Used !")
                    bln = False
                End If

            End If

            If txtrefno.Text.Trim.Length = 0 Then
                EP.SetError(txtrefno, " Enter Branch Name")
                bln = False
            End If
        End If

        If (ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If Val(txtbookingno.Text.Trim) = 0 Then
            EP.SetError(txtbookingno, "Booking No Cannot Be 0!")
            bln = False
        End If


        If CHECKPURCHASEBALANCES() Then
            EP.SetError(CMBNAME, "User Cancelled the save operation due to Creditors Credit Issues")
            bln = False
        End If

        If LBLACCBAL.ForeColor = Color.Red Then
            EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            bln = False
        End If

        If txtmobileno.Text.Trim.Length = 0 Then
            DT = OBJCMN.search(" ISNULL(ACC_MOBILE,'')", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                txtmobileno.Text = DT.Rows(0).Item(0)
            End If
        End If


        If txtmobileno.Text.Trim.Length = 0 And ClientName <> "HEENKAR" Then
            EP.SetError(txtmobileno, " Please Fill Guest's Mobile No ")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If



        If ClientName = "CLASSIC" Then

            If UserName <> "Admin" And edit = False Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < Now.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If

            If Val(txtgrandtotal.Text.Trim) >= 50001 Then
                DT = OBJCMN.search(" ACC_ADD, ACC_PANNO AS PANNO", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("PANNO") = "" Then
                        EP.SetError(CMBNAME, "Insert PAN No")
                        bln = False
                    End If
                End If
            End If

        End If
        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amount cannot be 0")
            bln = False
        End If

        If ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" Then
            If Val(TXTFINALPURAMT.Text.Trim) = 0 Then
                EP.SetError(TXTFINALPURAMT, "Amount Cannot be 0")
                bln = False
            End If
        End If


        If TXTGUESTADD.Text.Trim.Length = 0 Then
            DT = OBJCMN.search(" ISNULL(ACC_ADD,'')", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TXTGUESTADD.Text = DT.Rows(0).Item(0)
            End If
        End If


        If ClientName <> "TOPCOMM" And ClientName <> "RAMKRISHNA" And ClientName <> "KHANNA" Then
            If GRIDPURCHASE.RowCount = 0 Then
                EP.SetError(TXTTOURNAME, " Please Fill Purchase Details ")
                TBDETAILS.SelectedIndex = 4
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Account Name ")
                bln = False
            End If
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOURNAME, "Enter Hotel Details")
            TBDETAILS.SelectedIndex = 1
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If



        'CHECKING WHETHER NAME IS PRESENT IN DATABASE OR NOT
        'DONT DELETE THIS CODE IT IS NECESSARY COZ SOMETIMES FORM IS OPEN AND USER CHANGES THE NAME FROM BEHIND
        If ClientName <> "TOPCOMM" Then
            DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                EP.SetError(CMBNAME, "Change Name")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & ROW.Cells(GPURNAME.Index).Value & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    EP.SetError(CMBNAME, "Change Purchase Name")
                    bln = False
                End If
            Next
        End If
        '***************************************************

        If ClientName <> "LUXCREST" Then
            If UserName <> "Admin" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, " Booking Locked, Payment/Receipt Made")
                    bln = False
                End If
            End If

            If PBCN.Visible = True Then
                EP.SetError(PBCN, " Booking Locked, Credit Note Raised")
                bln = False
            End If

            If PBDN.Visible = True Then
                EP.SetError(PBDN, " Booking Locked, Debit Note Raised")
                bln = False
            End If

            If lblamd.Visible = True Then
                EP.SetError(lblamd, " Booking Locked, Booking Amended")
                bln = False
            End If

            If lblcancelled.Visible = True Then
                EP.SetError(PBCancelled, " Booking Locked, Booking Cancelled")
                bln = False
            End If
        End If

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If


        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If

        If BOOKINGDATE.Text = "__/__/____" Then
            EP.SetError(BOOKINGDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BOOKINGDATE.Text) Then
                EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date < PACKAGEFROM.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Check In Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date > PACKAGETO.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Check Out Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCHECKIN.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCHECKOUT.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Check In Cannot be greater than Check Out Date")
            End If
        Next

        For Each ROW As DataGridViewRow In GRIDTRANS.Rows
            If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date < PACKAGEFROM.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Pickup Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date > PACKAGETO.Value.Date Then
                bln = False
                EP.SetError(PACKAGETO, "Invalid Drop Date")
            End If
            If Convert.ToDateTime(ROW.Cells(GCARPICKUP.Index).Value).Date > Convert.ToDateTime(ROW.Cells(GCARDROP.Index).Value).Date Then
                bln = False
                EP.SetError(PACKAGETO, "Pick-up Date Cannot be greater than Drop Date")
            End If
        Next


        If ClientName = "CLASSIC" Then
            'AS PER ASHOK BHAI REQ
            'If Not datecheck(PACKAGEFROM.Value) Then
            '    EP.SetError(PACKAGEFROM, "Date Not in Current Accounting Year")
            '    bln = False
            'End If

            'DONE TEMPORARILY
            'If Not datecheck(PACKAGETO.Value) Then
            '    EP.SetError(PACKAGETO, "Date Not in Current Accounting Year")
            '    bln = False
            'End If
        End If
        Return bln
    End Function

    Sub TOTAL()

        Try
            Dim net_purchase As Double = 0

            TXTTOTALROOMS.Text = "0.00"
            TXTTOTALAMT.Text = "0.00"
            TXTTOTALSALEAMT.Text = "0.00"
            TXTFINALPURAMT.Text = 0.0

            TXTTOTALNIGHTS.Text = 0
            ' TXTBTOTALNIGHTS.Text = 0
            TXTTOTALROOMS.Text = 0

            CMBADDTAX.Text = ""
            TXTADDTAX.Clear()

            TXTCARTOTALPAX.Text = 0
            TXTCARTOTALAMT.Text = 0.0
            TXTTOTALMISCAMT.Text = "0.00"
            TXTCESSAMT.Clear()


            For Each row As DataGridViewRow In GRIDPURCHASE.Rows
                If Val(row.Cells(GGRANDTOTAL.Index).Value) > 0 Then TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text) + Val(row.Cells(GGRANDTOTAL.Index).Value), "0.00")
            Next

            If GRIDBOOKINGS.RowCount > 0 Then

                TXTSUBTOTAL.Text = 0.0
                '  txttax.Text = 0.0
                TXTADDTAX.Text = 0.0
                If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
                txtroundoff.Text = 0.0
                txtgrandtotal.Text = 0.0

                For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                    If Val(row.Cells(gnoofRooms.Index).Value) > 0 Then TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text) + Val(row.Cells(gnoofRooms.Index).Value)
                    row.Cells(GNIGHTS.Index).Value = DateDiff(DateInterval.Day, Convert.ToDateTime(row.Cells(GCHECKIN.Index).Value).Date, Convert.ToDateTime(row.Cells(GCHECKOUT.Index).Value).Date)
                    If Val(row.Cells(gamt.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
                    TXTTOTALNIGHTS.Text = Val(TXTTOTALNIGHTS.Text.Trim) + Val(row.Cells(GNIGHTS.Index).Value)
                Next

                If GRIDTRANS.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                        If Val(ROW.Cells(GCARADULTS.Index).Value) > 0 Then TXTCARTOTALPAX.Text = Val(TXTCARTOTALPAX.Text) + Val(ROW.Cells(GCARADULTS.Index).Value)
                        If Val(ROW.Cells(GCARCHILDS.Index).Value) > 0 Then TXTCARTOTALPAX.Text = Val(TXTCARTOTALPAX.Text) + Val(ROW.Cells(GCARCHILDS.Index).Value)
                        If Val(ROW.Cells(GCARAMT.Index).Value) > 0 Then TXTCARTOTALAMT.Text = Format(Val(TXTCARTOTALAMT.Text) + Val(ROW.Cells(GCARAMT.Index).Value), "0.00")
                    Next
                End If


                If GRIDPURCHASE.RowCount > 0 Then
                    For Each row As DataGridViewRow In GRIDPURCHASE.Rows
                        net_purchase = net_purchase + Val(row.Cells(GEXTRAADULTRATE.Index).Value) + Val(row.Cells(GEXTRACHILDRATE.Index).Value) + Val(row.Cells(GPURAMT.Index).Value) - Val(row.Cells(GDISC.Index).Value) - Val(row.Cells(GCOMM.Index).Value)
                    Next
                End If

                'GRID AIRLINE
                TXTAIRTOTAL.Text = "0.00"
                TXTTOTALBASIC.Text = "0.00"
                TXTTOTALPSF.Text = "0.00"
                TXTTOTALTAXES.Text = "0.00"
                If GRIDAIRLINE.RowCount > 0 Then
                    For Each row As DataGridViewRow In GRIDAIRLINE.Rows
                        If Val(row.Cells(GBASIC.Index).Value) > 0 Then TXTTOTALBASIC.Text = Val(TXTTOTALBASIC.Text) + Val(row.Cells(GBASIC.Index).Value)
                        If Val(row.Cells(GPSF.Index).Value) > 0 Then TXTTOTALPSF.Text = Val(TXTTOTALPSF.Text) + Val(row.Cells(GPSF.Index).Value)
                        If Val(row.Cells(GTAXES.Index).Value) > 0 Then TXTTOTALTAXES.Text = Val(TXTTOTALTAXES.Text) + Val(row.Cells(GTAXES.Index).Value)
                        If Val(row.Cells(GTOTAL.Index).Value) > 0 Then TXTAIRTOTAL.Text = Format(Val(TXTAIRTOTAL.Text) + Val(row.Cells(GTOTAL.Index).Value), "0.00")
                    Next
                End If

                If GRIDMISC.RowCount > 0 Then
                    For Each ROW As DataGridViewRow In GRIDMISC.Rows
                        If Val(ROW.Cells(GMISCAMOUNT.Index).Value) > 0 Then TXTTOTALMISCAMT.Text = Val(TXTTOTALMISCAMT.Text) + Val(ROW.Cells(GMISCAMOUNT.Index).Value)
                    Next
                End If


                TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(TXTCARTOTALAMT.Text.Trim) + Val(TXTTOTALMISCAMT.Text.Trim), "0.00")
                If Val(TXTEXTRAADULT.Text.Trim) > 0 And Val(TXTEXTRAADULTRATE.Text.Trim) > 0 Then
                    'as per ashok sir dont multiply with nights
                    'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim)), "0.00")
                End If

                If Val(TXTEXTRACHILD.Text.Trim) > 0 And Val(TXTEXTRACHILDRATE.Text.Trim) > 0 Then
                    'as per ashok sir dont multiply with nights
                    'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim)), "0.00")
                End If


                'WORKING CODE TILL 24-05-207, NEW CODE WRITTEN BELOW AS PER AERO N ALL
                'If CHKREVERSE.Checked = True Then
                '    Dim objclscmn As New ClsCommonMaster
                '    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                '    If dt1.Rows.Count > 0 Then
                '        TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALSALEAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                '    End If
                'End If


                'TESTING FOR AERO 24-05-2017
                '24-05-2017
                If CHKREVERSE.Checked = True Then
                    If CHKTAXSERVCHGS.Checked = False Then
                        Dim objclscmn As New ClsCommonMaster
                        Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt1.Rows.Count > 0 Then
                            TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                        Else
                            TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                        End If
                    Else
                        Dim objclscmn As New ClsCommonMaster
                        Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt1.Rows.Count > 0 Then
                            TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMRS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                        End If
                        TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                    End If
                Else
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim) + Val(TXTCARTOTALAMT.Text.Trim), "0.00")
                End If




                If Val(TXTAGENTCOMMPER.Text) > 0 Then
                    TXTAGENTCOMMRS.Text = Format((Val(TXTAGENTCOMMPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
                Else
                    'TXTAGENTCOMMPER.Text = Format((Val(TXTAGENTCOMMRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
                End If


                If Val(TXTAGENTTDSPER.Text) > 0 Then
                    TXTAGENTTDSRS.Text = Format((Val(TXTAGENTTDSPER.Text) * Val(TXTAGENTCOMMRS.Text)) / 100, "0.00")
                Else
                    'TXTAGENTTDSPER.Text = Format((Val(TXTAGENTTDSRS.Text) * 100) / Val(TXTAGENTCOMMRS.Text), "0.00")
                End If


                If Val(TXTDISCPER.Text) > 0 Then
                    TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
                Else
                    ' TXTDISCPER.Text = Format((Val(TXTDISCRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
                End If


                'FOR SSR/CLASSIC/HBAZAAR/KHANNA OURCOMM IS SERVICE CHARGES, HERE THEY ENTER SERVICE CHGS MANUALLY
                TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text)) - Val(TXTDISCRS.Text) + Val(TXTOURCOMMRS.Text.Trim), "0.00")



                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < "01/07/2017" Then
                    dt = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                            If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTOURCOMMRS.Text))) / 100, "0.00")
                        Else
                            If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        End If
                    End If
                Else


                    If CHKMANUAL.CheckState = CheckState.Unchecked Then
                        If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                            TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                            TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                            TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                            If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                                'IF GSTNO IS BLANK THEN APPLYCESS
                                Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                                If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                            End If

                        Else
                            TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                            TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                            TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                            If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                                'IF GSTNO IS BLANK THEN APPLYCESS
                                Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                                If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                            End If

                        End If
                    End If

                    dt = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim))) / 100, "0.00")



                End If

                dt = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")


                If cmbaddsub.Text = "Add" Then
                    txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                    txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
                Else
                    txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                    txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
                End If

                txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

                'as per ASHOK BHAI'S RECOMMENDATION
                'If (ClientName <> "SSR" And ClientName <> "KHANNA" And ClientName <> "CLASSIC" And ClientName <> "HBAZAAR" And ClientName <> "MAHARAJA" And ClientName <> "AERO") Then TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - net_purchase, "0.00")

                'SHOW COMM FOR JUST CLASSIC/KHANNA
                TXTOURCOMM.Text = Format(Val(TXTSUBTOTAL.Text) - net_purchase, "0.00")


                If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub PURCHASECALC()

        Try
            TXTPURSUBTOTAL.Text = 0.0
            TXTPURTAX.Text = 0.0
            TXTPURADDTAX.Text = 0.0
            TXTPURNETTAMT.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTPURCESSAMT.Clear()

            If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
            If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
            If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0


            'If Val(TXTPUREXTRAADULTRATE.Text.Trim) > 0 Then
            '    TXTPURAMT.Text = Format(Val(TXTPURAMT.Text.Trim) + Val(TXTPUREXTRAADULTRATE.Text.Trim), "0.00")
            'End If

            'If Val(TXTPUREXTRACHILDRATE.Text.Trim) > 0 Then
            '    TXTPURAMT.Text = Format(Val(TXTPURAMT.Text.Trim) + Val(TXTPUREXTRACHILDRATE.Text.Trim), "0.00")
            'End If

            If Val(TXTDISCRECDPER.Text) > 0 Then
                TXTDISCRECDRS.Text = Format((Val(TXTDISCRECDPER.Text) * Val(TXTPURAMT.Text)) / 100, "0.00")
            Else
                'TXTDISCRECDPER.Text = Format((Val(TXTDISCRECDRS.Text) * 100) / Val(TXTPURAMT.Text), "0.00")
            End If

            TXTPURSUBTOTAL.Text = Format(Val(TXTPURAMT.Text) - Val(TXTDISCRECDRS.Text), "0.00")

            If Val(TXTCOMMRECDPER.Text) > 0 Then
                TXTCOMMRECDRS.Text = Format((Val(TXTCOMMRECDPER.Text) * Val(TXTPURSUBTOTAL.Text)) / 100, "0.00")
            Else
                'TXTCOMMRECDPER.Text = Format((Val(TXTCOMMRECDRS.Text) * 100) / Val(TXTPURSUBTOTAL.Text), "0.00")
            End If

            If Val(TXTPURTDSPER.Text) > 0 Then
                TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(TXTCOMMRECDRS.Text)) / 100, "0.00")
            Else
                'TXTPURTDSPER.Text = Format((Val(TXTPURTDSRS.Text) * 100) / Val(TXTCOMMRECDRS.Text), "0.00")
            End If

            TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) - Val(TXTCOMMRECDRS.Text), "0.00")
            TXTPURNETTAMT.Text = Format(Val(TXTPURNETTAMT.Text.Trim) + Val(TXTSERVCHGS.Text.Trim) + Val(TXTPUREXTRAADULTRATE.Text.Trim) + Val(TXTPUREXTRACHILDRATE.Text.Trim), "0.00")

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If Convert.ToDateTime(PURDATE.Value.Date).Date < "01/07/2017" Then
                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If CHKSERVTAX.CheckState = CheckState.Checked Then
                    If dt.Rows.Count > 0 Then
                        TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    End If
                End If
            Else




                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKSERVTAX.CheckState = CheckState.Checked Then
                        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTSERVCHGS.Text)) / 100, "0.00")
                        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTSERVCHGS.Text)) / 100, "0.00")
                        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTSERVCHGS.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTSERVCHGS.Text)) / 100, "0.00")
                        End If

                    Else
                        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        End If

                    End If
                End If

                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTPURNETTAMT.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim))) / 100, "0.00")

            End If



            TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text), "0")
            TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")

            TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtGUESTsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGUESTSRNO.GotFocus
        If gridGUESTDoubleClick = False Then
            If GRIDGUESTDETAILS.RowCount > 0 Then
                TXTGUESTSRNO.Text = Val(GRIDGUESTDETAILS.Rows(GRIDGUESTDETAILS.RowCount - 1).Cells(GGUESTSRNO.Index).Value) + 1
            Else
                TXTGUESTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub txtPURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURSRNO.GotFocus
        If gridPURCHASEDoubleClick = False Then
            If GRIDPURCHASE.RowCount > 0 Then
                TXTPURSRNO.Text = Val(GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).Cells(GPURSRNO.Index).Value) + 1
            Else
                TXTPURSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And Val(TXTBADULTS.Text) > 0 And CMBPACKAGE.Text.Trim <> "" Then
            fillgrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                If grid.Name = "GRIDPURCHASE" Then
                    row.Cells(1).Value = row.Index + 1
                Else
                    row.Cells(0).Value = row.Index + 1
                End If
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKTOTALPAX() As Boolean
        Try
            Dim BLN As Boolean = True
            If gridDoubleClick = False Then
                If GRIDBOOKINGS.RowCount > 0 Then
                    For Each ROWS As System.Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                        If Val(TXTBTOTPAX.Text.Trim) > Val(ROWS.Cells(GTOTALPAX.Index).Value) Or Val(TXTBTOTPAX.Text.Trim) < Val(ROWS.Cells(GTOTALPAX.Index).Value) Then
                            BLN = False
                            Exit For
                        End If
                    Next
                End If
            Else
                For Each ROWS As System.Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                    If (Val(TXTBTOTPAX.Text.Trim) > Val(ROWS.Cells(GTOTALPAX.Index).Value) Or Val(TXTBTOTPAX.Text.Trim) < Val(ROWS.Cells(GTOTALPAX.Index).Value)) And temprow <> ROWS.Index Then
                        BLN = False
                        Exit For
                    End If
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        EP.Clear()
        If Not CALDAYS() Then
            Exit Sub
        End If

        TXTBTOTPAX.Text = Val(TXTBADULTS.Text.Trim) + Val(TXTBCHILDS.Text.Trim) + Val(TXTBINFANTS.Text.Trim) + Val(TXTBEXTRAADULT.Text.Trim) + Val(TXTBEXTRACHILD.Text.Trim)

        'NO NEED AS THERE MAY BE DIFF ADULTS AND CHILDS FOR DIFF HOTELS
        'If Not CHECKTOTALPAX() Then
        '    MsgBox("Please check the Total Pax in this booking.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        GRIDBOOKINGS.Enabled = True
        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTCONFIRMATIONNO.Text.Trim, TXTCONFIRMEDBY.Text.Trim, TXTINCLUSIONS.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTBADULTS.Text.Trim), Val(TXTBCHILDS.Text.Trim), Val(TXTBINFANTS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Val(TXTBEXTRACHILD.Text.Trim), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTBTOTPAX.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTCHILDRATE.Text.Trim), "0.00"), Format(Val(TXTINFANTRATE.Text.Trim), "0.00"), CMBCURCODE.Text.Trim, Val(TXTROE.Text.Trim), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))
            'GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBHOTELNAME.Text.Trim, TXTCONFIRMATIONNO.Text.Trim, TXTCONFIRMEDBY.Text.Trim, TXTINCLUSIONS.Text.Trim, Format(CHECKINDATE.Value.Date, "dd/MM/yyyy"), Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy"), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTBADULTS.Text.Trim), Val(TXTBCHILDS.Text.Trim), Val(TXTBINFANTS.Text.Trim), Val(TXTBEXTRAADULT.Text.Trim), Format(Val(TXTBEXTRAADULTRATE.Text.Trim), "0.00"), Val(TXTBEXTRACHILD.Text.Trim), Format(Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00"), Val(TXTBTOTPAX.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date))
            getsrno(GRIDBOOKINGS)
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(GHOTELNAME.Index, temprow).Value = CMBHOTELNAME.Text.Trim
            GRIDBOOKINGS.Item(GCONFIRMATIONNO.Index, temprow).Value = TXTCONFIRMATIONNO.Text.Trim
            GRIDBOOKINGS.Item(GCONFIRMEDBY.Index, temprow).Value = TXTCONFIRMEDBY.Text.Trim
            GRIDBOOKINGS.Item(GINCLUSIONS.Index, temprow).Value = TXTINCLUSIONS.Text.Trim
            GRIDBOOKINGS.Item(GCHECKIN.Index, temprow).Value = Format(CHECKINDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(GCHECKOUT.Index, temprow).Value = Format(CHECKOUTDATE.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Item(groomtype.Index, temprow).Value = CMBROOMTYPE.Text.Trim
            GRIDBOOKINGS.Item(gplan.Index, temprow).Value = CMBPLAN.Text.Trim
            GRIDBOOKINGS.Item(GADULTS.Index, temprow).Value = TXTBADULTS.Text.Trim
            GRIDBOOKINGS.Item(GCHILD.Index, temprow).Value = TXTBCHILDS.Text.Trim
            GRIDBOOKINGS.Item(GINFANT.Index, temprow).Value = TXTBINFANTS.Text.Trim
            GRIDBOOKINGS.Item(GEXTADU.Index, temprow).Value = TXTBEXTRAADULT.Text.Trim
            GRIDBOOKINGS.Item(GEXADURATE.Index, temprow).Value = TXTBEXTRAADULTRATE.Text.Trim
            GRIDBOOKINGS.Item(GEXCHILD.Index, temprow).Value = TXTBEXTRACHILD.Text.Trim
            GRIDBOOKINGS.Item(GEXCHDRATE.Index, temprow).Value = TXTBEXTRACHILDRATE.Text.Trim
            GRIDBOOKINGS.Item(GTOTALPAX.Index, temprow).Value = TXTBTOTPAX.Text.Trim
            GRIDBOOKINGS.Item(gnoofRooms.Index, temprow).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDBOOKINGS.Item(gpack.Index, temprow).Value = CMBPACKAGE.Text.Trim
            GRIDBOOKINGS.Item(grate.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GCHILDRATE.Index, temprow).Value = Format(Val(TXTCHILDRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GINFANTRATE.Index, temprow).Value = Format(Val(TXTINFANTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GCURCODE.Index, temprow).Value = CMBCURCODE.Text.Trim
            GRIDBOOKINGS.Item(GROE.Index, temprow).Value = Format(Val(TXTROE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(gamt.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GNIGHTS.Index, temprow).Value = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)
            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        txtsrno.Clear()
        CMBHOTELNAME.Text = ""
        TXTCONFIRMATIONNO.Clear()
        TXTCONFIRMEDBY.Clear()
        CHECKINDATE.Value = CHECKOUTDATE.Value.Date
        CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value.Date)
        CMBROOMTYPE.Text = ""
        'CMBPLAN.Text = ""
        'TXTNOOFROOMS.Text = ""
        TXTRATE.Clear()
        TXTCHILDRATE.Clear()
        TXTINFANTRATE.Clear()
        CMBCURCODE.Text = ""
        TXTROE.Clear()
        TXTTOTAL.Clear()
        TXTBTOTALNIGHTS.Clear()
        'TXTBADULTS.Clear()
        'TXTBCHILDS.Clear()
        TXTBINFANTS.Clear()
        'TXTBEXTRAADULT.Clear()
        TXTBEXTRAADULTRATE.Clear()
        'TXTBEXTRACHILD.Clear()
        TXTBEXTRACHILDRATE.Clear()
        TXTBTOTPAX.Clear()
        'CMBPACKAGE.Text = "Yes"
        temprow = 0


        txtsrno.Focus()

    End Sub

    Sub fillgridguest()

        GRIDGUESTDETAILS.Enabled = True

        If gridGUESTDoubleClick = False Then
            GRIDGUESTDETAILS.Rows.Add(Val(TXTGUESTSRNO.Text.Trim), CMBGUESTNAME.Text.Trim, TXTAGE.Text.Trim, CMBSEX.Text.Trim)
            getsrno(GRIDGUESTDETAILS)
        ElseIf gridGUESTDoubleClick = True Then
            GRIDGUESTDETAILS.Item(GGUESTSRNO.Index, tempGUESTrow).Value = Val(TXTGUESTSRNO.Text.Trim)
            GRIDGUESTDETAILS.Item(GGUESTNAME.Index, tempGUESTrow).Value = CMBGUESTNAME.Text.Trim
            GRIDGUESTDETAILS.Item(GAGE.Index, tempGUESTrow).Value = TXTAGE.Text.Trim
            GRIDGUESTDETAILS.Item(GSEX.Index, tempGUESTrow).Value = CMBSEX.Text.Trim
            gridGUESTDoubleClick = False
        End If

        GRIDGUESTDETAILS.FirstDisplayedScrollingRowIndex = GRIDGUESTDETAILS.RowCount - 1

        TXTGUESTSRNO.Clear()
        ' CMBGUESTNAME.Text = ""
        TXTAGE.Clear()
        CMBSEX.Text = ""
        TXTGUESTSRNO.Focus()

    End Sub

    Sub fillgridTOUR()

        Try
            If gridTOURDoubleClick = False Then
                GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), TXTHEADER.Text.Trim, TXTDETAILS.Text.Trim)
                getsrno(GRIDTOUR)

            ElseIf gridTOURDoubleClick = True Then

                GRIDTOUR.Item(GTOURSRNO.Index, tempTOURrow).Value = TXTTOURSRNO.Text.Trim
                GRIDTOUR.Item(GHEADER.Index, tempTOURrow).Value = TXTHEADER.Text.Trim
                GRIDTOUR.Item(GDETAILS.Index, tempTOURrow).Value = TXTDETAILS.Text.Trim
                gridTOURDoubleClick = False
            End If

            GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1
            TXTTOURSRNO.Text = GRIDTOUR.RowCount + 1
            TXTHEADER.Clear()
            TXTDETAILS.Clear()
            TXTHEADER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridPURCHASE()

        GRIDPURCHASE.Enabled = True

        If gridPURCHASEDoubleClick = False Then
            If CHKSERVTAX.Checked = True Then
                GRIDPURCHASE.Rows.Add(0, Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Format(PURDATE.Value.Date, "dd/MM/yyyy"), CMBPURHSNITEMDESC.Text.Trim, TXTPURHSNCODE.Text.Trim, Format(Val(TXTPUREXTRAADULTRATE.Text.Trim), "0.00"), Format(Val(TXTPUREXTRACHILDRATE.Text.Trim), "0.00"), Format(Val(TXTPURAMT.Text.Trim), "0.00"), Format(Val(TXTDISCRECDPER.Text.Trim), "0.00"), Format(Val(TXTDISCRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURSUBTOTAL.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURTDSPER.Text.Trim), "0.00"), Format(Val(TXTPURTDSRS.Text.Trim), "0.00"), 1, Format(Val(TXTSERVCHGS.Text.Trim), "0.00"), Format(Val(TXTPURNETTAMT.Text.Trim), "0.00"), CMBPURTAX.Text.Trim, Format(Val(TXTPURTAX.Text.Trim), "0.00"), CMBPURADDTAX.Text.Trim, Format(Val(TXTPURADDTAX.Text.Trim), "0.00"), Format(Val(TXTPURCGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURSGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURIGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURCESSPER.Text.Trim), "0.00"), Format(Val(TXTPURCESSAMT.Text.Trim), "0.00"), CMBPUROTHERCHGS.Text.Trim, Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00"), Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00"), Format(Val(TXTPURGTOTAL.Text.Trim), "0.00"), 0, 0, 0, 0)
            Else
                GRIDPURCHASE.Rows.Add(0, Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Format(PURDATE.Value.Date, "dd/MM/yyyy"), CMBPURHSNITEMDESC.Text.Trim, TXTPURHSNCODE.Text.Trim, Format(Val(TXTPUREXTRAADULTRATE.Text.Trim), "0.00"), Format(Val(TXTPUREXTRACHILDRATE.Text.Trim), "0.00"), Format(Val(TXTPURAMT.Text.Trim), "0.00"), Format(Val(TXTDISCRECDPER.Text.Trim), "0.00"), Format(Val(TXTDISCRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURSUBTOTAL.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00"), Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00"), Format(Val(TXTPURTDSPER.Text.Trim), "0.00"), Format(Val(TXTPURTDSRS.Text.Trim), "0.00"), 0, Format(Val(TXTSERVCHGS.Text.Trim), "0.00"), Format(Val(TXTPURNETTAMT.Text.Trim), "0.00"), CMBPURTAX.Text.Trim, Format(Val(TXTPURTAX.Text.Trim), "0.00"), CMBPURADDTAX.Text.Trim, Format(Val(TXTPURADDTAX.Text.Trim), "0.00"), Format(Val(TXTPURCGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURSGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURIGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURCESSPER.Text.Trim), "0.00"), Format(Val(TXTPURCESSAMT.Text.Trim), "0.00"), CMBPUROTHERCHGS.Text.Trim, Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00"), Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00"), Format(Val(TXTPURGTOTAL.Text.Trim), "0.00"), 0, 0, 0, 0)
            End If
            getsrno(GRIDPURCHASE)
        ElseIf gridPURCHASEDoubleClick = True Then
            GRIDPURCHASE.Item(GPURSRNO.Index, tempPURCHASErow).Value = Val(TXTPURSRNO.Text.Trim)
            GRIDPURCHASE.Item(GPURNAME.Index, tempPURCHASErow).Value = CMBPURNAME.Text.Trim
            GRIDPURCHASE.Item(GPURDATE.Index, tempPURCHASErow).Value = Format(PURDATE.Value.Date, "dd/MM/yyyy")
            GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, tempPURCHASErow).Value = CMBPURHSNITEMDESC.Text.Trim
            GRIDPURCHASE.Item(GHSNCODE.Index, tempPURCHASErow).Value = TXTPURHSNCODE.Text.Trim
            GRIDPURCHASE.Item(GEXTRAADULTRATE.Index, tempPURCHASErow).Value = Format(Val(TXTPUREXTRAADULTRATE.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GEXTRACHILDRATE.Index, tempPURCHASErow).Value = Format(Val(TXTPUREXTRACHILDRATE.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GDISCPER.Index, tempPURCHASErow).Value = Format(Val(TXTDISCRECDPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GDISC.Index, tempPURCHASErow).Value = Format(Val(TXTDISCRECDRS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSUBTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTSUBTOTAL.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCOMMPER.Index, tempPURCHASErow).Value = Format(Val(TXTCOMMRECDPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCOMM.Index, tempPURCHASErow).Value = Format(Val(TXTCOMMRECDRS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTDSPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURTDSPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTDS.Index, tempPURCHASErow).Value = Format(Val(TXTPURTDSRS.Text.Trim), "0.00")
            If CHKSERVTAX.Checked = True Then
                GRIDPURCHASE.Item(GSERVTAX.Index, temprow).Value = 1
            Else
                GRIDPURCHASE.Item(GSERVTAX.Index, temprow).Value = 0
            End If
            GRIDPURCHASE.Item(GSERVCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTSERVCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GNETTTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURNETTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTAX.Index, tempPURCHASErow).Value = CMBPURTAX.Text.Trim
            GRIDPURCHASE.Item(GTAXAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURTAX.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GADDTAX.Index, tempPURCHASErow).Value = CMBPURADDTAX.Text.Trim
            GRIDPURCHASE.Item(GADDTAXAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURADDTAX.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GCGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GIGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GIGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURCESSPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURCESSPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURCESSAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURCESSAMT.Text.Trim), "0.00")

            GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, tempPURCHASErow).Value = CMBPUROTHERCHGS.Text.Trim
            GRIDPURCHASE.Item(GOTHERCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GROUNDOFF.Index, tempPURCHASErow).Value = Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GGRANDTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURGTOTAL.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURAMTPAID.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMTPAID.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPUREXTRAAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPUREXTRAAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURRETURN.Index, tempPURCHASErow).Value = Format(Val(TXTPURRETURN.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURBAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURBAL.Text.Trim), "0.00")
            gridPURCHASEDoubleClick = False
        End If

        GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

        TXTPURSRNO.Clear()
        CMBPURNAME.Text = ""
        PURDATE.Value = Mydate
        TXTPUREXTRAADULTRATE.Clear()
        TXTPUREXTRACHILDRATE.Focus()
        TXTPURAMT.Clear()
        TXTDISCRECDPER.Clear()
        TXTDISCRECDRS.Clear()
        TXTPURSUBTOTAL.Clear()
        TXTCOMMRECDPER.Clear()
        TXTCOMMRECDRS.Clear()
        TXTPURTDSPER.Clear()
        TXTPURTDSRS.Clear()
        TXTPURNETTAMT.Clear()
        CMBPURTAX.Text = ""
        TXTPURTAX.Clear()
        CMBPURADDTAX.Text = ""
        TXTPURADDTAX.Clear()
        CMBPUROTHERCHGS.Text = ""
        TXTPUROTHERCHGS.Clear()
        TXTPURROUNDOFF.Clear()
        TXTPURGTOTAL.Clear()
        CHKSERVTAX.CheckState = CheckState.Unchecked
        TXTSERVCHGS.Clear()
        TXTPURCGSTPER.Clear()
        TXTPURCGSTAMT.Clear()
        TXTPURSGSTPER.Clear()
        TXTPURSGSTAMT.Clear()
        TXTPURIGSTPER.Clear()
        TXTPURIGSTAMT.Clear()
        TXTPURCESSPER.Clear()
        TXTPURCESSAMT.Clear()
        TXTPURSTATECODE.Clear()

        TXTPURHSNCODE.Clear()
        CMBPURHSNITEMDESC.SelectedIndex = 0

        TXTPURSRNO.Focus()
    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                txtsrno.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBHOTELNAME.Text = GRIDBOOKINGS.Item(GHOTELNAME.Index, e.RowIndex).Value.ToString
                FILLROOMTYPE()
                TXTCONFIRMATIONNO.Text = GRIDBOOKINGS.Item(GCONFIRMATIONNO.Index, e.RowIndex).Value.ToString
                TXTCONFIRMEDBY.Text = GRIDBOOKINGS.Item(GCONFIRMEDBY.Index, e.RowIndex).Value.ToString
                TXTINCLUSIONS.Text = GRIDBOOKINGS.Item(GINCLUSIONS.Index, e.RowIndex).Value.ToString
                CHECKINDATE.Value = GRIDBOOKINGS.Item(GCHECKIN.Index, e.RowIndex).Value
                CHECKOUTDATE.Value = GRIDBOOKINGS.Item(GCHECKOUT.Index, e.RowIndex).Value
                CMBROOMTYPE.Text = GRIDBOOKINGS.Item(groomtype.Index, e.RowIndex).Value
                CMBPLAN.Text = GRIDBOOKINGS.Item(gplan.Index, e.RowIndex).Value.ToString
                TXTBADULTS.Text = GRIDBOOKINGS.Item(GADULTS.Index, e.RowIndex).Value.ToString
                TXTBCHILDS.Text = GRIDBOOKINGS.Item(GCHILD.Index, e.RowIndex).Value.ToString
                TXTBINFANTS.Text = GRIDBOOKINGS.Item(GINFANT.Index, e.RowIndex).Value.ToString
                TXTBEXTRAADULT.Text = GRIDBOOKINGS.Item(GEXTADU.Index, e.RowIndex).Value.ToString
                TXTBEXTRAADULTRATE.Text = GRIDBOOKINGS.Item(GEXADURATE.Index, e.RowIndex).Value.ToString
                TXTBEXTRACHILD.Text = GRIDBOOKINGS.Item(GEXCHILD.Index, e.RowIndex).Value.ToString
                TXTBEXTRACHILDRATE.Text = GRIDBOOKINGS.Item(GEXCHDRATE.Index, e.RowIndex).Value.ToString
                TXTBTOTPAX.Text = GRIDBOOKINGS.Item(GTOTALPAX.Index, e.RowIndex).Value.ToString
                TXTNOOFROOMS.Text = GRIDBOOKINGS.Item(gnoofRooms.Index, e.RowIndex).Value.ToString
                CMBPACKAGE.Text = GRIDBOOKINGS.Item(gpack.Index, e.RowIndex).Value.ToString
                TXTRATE.Text = GRIDBOOKINGS.Item(grate.Index, e.RowIndex).Value.ToString
                TXTCHILDRATE.Text = GRIDBOOKINGS.Item(GCHILDRATE.Index, e.RowIndex).Value.ToString
                TXTINFANTRATE.Text = GRIDBOOKINGS.Item(GINFANTRATE.Index, e.RowIndex).Value.ToString
                CMBCURCODE.Text = GRIDBOOKINGS.Item(GCURCODE.Index, e.RowIndex).Value.ToString
                TXTROE.Text = GRIDBOOKINGS.Item(GROE.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(gamt.Index, e.RowIndex).Value.ToString
                TXTBTOTALNIGHTS.Text = GRIDBOOKINGS.Item(GNIGHTS.Index, e.RowIndex).Value.ToString
                temprow = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGUESTDETAILS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGUESTDETAILS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDGUESTDETAILS.Item(GGUESTSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridGUESTDoubleClick = True
                TXTGUESTSRNO.Text = GRIDGUESTDETAILS.Item(GGUESTSRNO.Index, e.RowIndex).Value.ToString
                CMBGUESTNAME.Text = GRIDGUESTDETAILS.Item(GGUESTNAME.Index, e.RowIndex).Value.ToString
                TXTAGE.Text = GRIDGUESTDETAILS.Item(GAGE.Index, e.RowIndex).Value.ToString
                CMBSEX.Text = GRIDGUESTDETAILS.Item(GSEX.Index, e.RowIndex).Value.ToString

                tempGUESTrow = e.RowIndex
                TXTGUESTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridTOURDoubleClick = True
                TXTTOURSRNO.Text = GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value
                TXTHEADER.Text = GRIDTOUR.Item(GHEADER.Index, e.RowIndex).Value
                TXTDETAILS.Text = GRIDTOUR.Item(GDETAILS.Index, e.RowIndex).Value.ToString


                tempTOURrow = e.RowIndex
                TXTHEADER.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellClick
        Try
            If e.ColumnIndex = GCHK.Index Then
                With GRIDPURCHASE.Rows(e.RowIndex).Cells(GCHK.Index)
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

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridPURCHASEDoubleClick = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value.ToString
                CMBPURNAME.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                PURDATE.Value = Convert.ToDateTime(GRIDPURCHASE.Item(GPURDATE.Index, e.RowIndex).Value).Date
                CMBPURHSNITEMDESC.Text = GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPURHSNCODE.Text = GRIDPURCHASE.Item(GHSNCODE.Index, e.RowIndex).Value.ToString
                TXTPUREXTRAADULTRATE.Text = GRIDPURCHASE.Item(GEXTRAADULTRATE.Index, e.RowIndex).Value.ToString
                TXTPUREXTRACHILDRATE.Text = GRIDPURCHASE.Item(GEXTRACHILDRATE.Index, e.RowIndex).Value.ToString
                TXTPURAMT.Text = GRIDPURCHASE.Item(GPURAMT.Index, e.RowIndex).Value.ToString
                TXTDISCRECDPER.Text = GRIDPURCHASE.Item(GDISCPER.Index, e.RowIndex).Value.ToString
                TXTDISCRECDRS.Text = GRIDPURCHASE.Item(GDISC.Index, e.RowIndex).Value.ToString
                TXTPURSUBTOTAL.Text = GRIDPURCHASE.Item(GSUBTOTAL.Index, e.RowIndex).Value.ToString
                TXTCOMMRECDPER.Text = GRIDPURCHASE.Item(GCOMMPER.Index, e.RowIndex).Value.ToString
                TXTCOMMRECDRS.Text = GRIDPURCHASE.Item(GCOMM.Index, e.RowIndex).Value.ToString
                TXTPURTDSPER.Text = GRIDPURCHASE.Item(GTDSPER.Index, e.RowIndex).Value.ToString
                TXTPURTDSRS.Text = GRIDPURCHASE.Item(GTDS.Index, e.RowIndex).Value.ToString
                CHKSERVTAX.Checked = Convert.ToBoolean(GRIDPURCHASE.Item(GSERVTAX.Index, e.RowIndex).Value)
                TXTSERVCHGS.Text = GRIDPURCHASE.Item(GSERVCHGS.Index, tempPURCHASErow).Value
                TXTPURNETTAMT.Text = GRIDPURCHASE.Item(GNETTTOTAL.Index, e.RowIndex).Value.ToString
                CMBPURTAX.Text = GRIDPURCHASE.Item(GTAX.Index, e.RowIndex).Value.ToString
                TXTPURTAX.Text = GRIDPURCHASE.Item(GTAXAMT.Index, e.RowIndex).Value.ToString
                CMBPURADDTAX.Text = GRIDPURCHASE.Item(GADDTAX.Index, e.RowIndex).Value.ToString
                TXTPURADDTAX.Text = GRIDPURCHASE.Item(GADDTAXAMT.Index, e.RowIndex).Value.ToString
                TXTPURCGSTPER.Text = GRIDPURCHASE.Item(GCGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURCGSTAMT.Text = GRIDPURCHASE.Item(GCGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURSGSTPER.Text = GRIDPURCHASE.Item(GSGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURSGSTAMT.Text = GRIDPURCHASE.Item(GSGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURIGSTPER.Text = GRIDPURCHASE.Item(GIGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURIGSTAMT.Text = GRIDPURCHASE.Item(GIGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURCESSPER.Text = GRIDPURCHASE.Item(GPURCESSPER.Index, e.RowIndex).Value.ToString
                TXTPURCESSAMT.Text = GRIDPURCHASE.Item(GPURCESSAMT.Index, e.RowIndex).Value.ToString

                CMBPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, e.RowIndex).Value.ToString
                TXTPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGS.Index, e.RowIndex).Value.ToString
                TXTPURROUNDOFF.Text = GRIDPURCHASE.Item(GROUNDOFF.Index, e.RowIndex).Value.ToString
                TXTPURGTOTAL.Text = GRIDPURCHASE.Item(GGRANDTOTAL.Index, e.RowIndex).Value.ToString

                tempPURCHASErow = e.RowIndex
                CMBPURNAME.Focus()
                'TXTPURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBOOKINGS.Rows.RemoveAt(GRIDBOOKINGS.CurrentRow.Index)
                total()
                getsrno(GRIDBOOKINGS)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDGUESTDETAILS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGUESTDETAILS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDGUESTDETAILS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridGUESTDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDGUESTDETAILS.Rows.RemoveAt(GRIDGUESTDETAILS.CurrentRow.Index)
                total()
                getsrno(GRIDGUESTDETAILS)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Sub GRIDTOUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTOUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTOUR.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridTOURDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTOUR.Rows.RemoveAt(GRIDTOUR.CurrentRow.Index)
                total()
                getsrno(GRIDTOUR)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellValueChanged
        Try
            If e.RowIndex < 0 Then Exit Sub
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then
                If GRIDPURCHASE.Rows(e.RowIndex).Cells(GCHK.Index).Value = True Then
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURCHASE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURCHASE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridPURCHASEDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDPURCHASE.Rows.RemoveAt(GRIDPURCHASE.CurrentRow.Index)
                total()
                getsrno(GRIDPURCHASE)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRIDMISC()
        Try
            If GRIDMISCDOUBLECLICK = False Then

                GRIDMISC.Rows.Add(Val(TXTMISCSRNO.Text.Trim), TXTMISCSERVICETYPE.Text.Trim, TXTMISCREMARKS.Text.Trim, Val(TXTMISCAMT.Text.Trim))
                getsrno(GRIDMISC)

            ElseIf GRIDMISCDOUBLECLICK = True Then

                GRIDMISC.Item(GMISCSRNO.Index, tempMISCrow).Value = TXTMISCSRNO.Text.Trim
                GRIDMISC.Item(GMISCSERVICETYPE.Index, tempMISCrow).Value = TXTMISCSERVICETYPE.Text.Trim
                GRIDMISC.Item(GMISCREMARKS.Index, tempMISCrow).Value = TXTMISCREMARKS.Text.Trim
                GRIDMISC.Item(GMISCAMOUNT.Index, tempMISCrow).Value = TXTMISCAMT.Text.Trim

                GRIDMISCDOUBLECLICK = False

            End If
            GRIDMISC.FirstDisplayedScrollingRowIndex = GRIDMISC.RowCount - 1

            TXTMISCSRNO.Text = GRIDMISC.RowCount + 1
            TXTMISCSERVICETYPE.Clear()
            TXTMISCREMARKS.Clear()
            TXTMISCAMT.Clear()
            TXTMISCSERVICETYPE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDMISCDOUBLECLICK = True
                TXTMISCSRNO.Text = GRIDMISC.Item(GMISCSRNO.Index, e.RowIndex).Value.ToString
                TXTMISCSERVICETYPE.Text = GRIDMISC.Item(GMISCSERVICETYPE.Index, e.RowIndex).Value.ToString
                TXTMISCREMARKS.Text = GRIDMISC.Item(GMISCREMARKS.Index, e.RowIndex).Value.ToString
                TXTMISCAMT.Text = GRIDMISC.Item(GMISCAMOUNT.Index, e.RowIndex).Value.ToString

                tempMISCrow = e.RowIndex
                TXTMISCSERVICETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMISC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMISC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDMISCDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDMISC.Rows.RemoveAt(GRIDMISC.CurrentRow.Index)
                getsrno(GRIDMISC)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMISCAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMISCAMT.Validated
        Try
            If TXTMISCSERVICETYPE.Text.Trim <> "" Then
                FILLGRIDMISC()
                total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPBOOKINGNO = Val(tstxtbillno.Text)
            If TEMPBOOKINGNO > 0 Then
                edit = True
                HolidayPackage_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtax.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True


    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJBOOKING As New HolidayPackageDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) - 1
Line2:
            If TEMPBOOKINGNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  HOLIDAYPACKAGEMASTER ", " AND HOLIDAYPACKAGEMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = " & CmpId & " AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = " & Locationid & " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    HolidayPackage_Load(sender, e)
                Else
                    TEMPBOOKINGNO = Val(TEMPBOOKINGNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                HolidayPackage_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELCODE.Enter
        Try
            If CMBHOTELCODE.Text.Trim = "" Then fillHOTELCODE(CMBHOTELCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Enter
        Try
            If CMBHOTELNAME.Text.Trim = "" Then fillHOTEL(CMBHOTELNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTELCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then CMBHOTELCODE.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTELNAME.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELCODE.Validating
        Try
            If CMBHOTELCODE.Text.Trim <> "" Then HOTELCODEVALIDATE(CMBHOTELCODE, CMBHOTELNAME, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHOTELNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then CMBHOTELCODE.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then CMBHOTELNAME.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOTELNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOTELNAME.Validated
        Try
            If CMBHOTELNAME.Text.Trim <> "" And gridDoubleClick = False Then FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOTELNAME.Validating
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then HOTELvalidate(CMBHOTELNAME, CMBHOTELCODE, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBACCCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try


            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub
            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "01/07/2017" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()
                End If
                DT = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If
                End If
            End If


            If CMBPURHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(PURDATE.Value.Date).Date >= "01/07/2017" Then

                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                    TXTPURCGSTPER.Clear()
                    TXTPURCGSTAMT.Clear()
                    TXTPURSGSTPER.Clear()
                    TXTPURSGSTAMT.Clear()
                    TXTPURIGSTPER.Clear()
                    TXTPURIGSTAMT.Clear()
                End If

                DT = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTPURHSNCODE.Text = DT.Rows(0).Item("PURHSNCODE")
                    If CMBPURNAME.Text.Trim <> "" Then
                        If TXTPURSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTPURIGSTPER.Text = 0
                            TXTPURCGSTPER.Text = Val(DT.Rows(0).Item("PURCGSTPER"))
                            TXTPURSGSTPER.Text = Val(DT.Rows(0).Item("PURSGSTPER"))
                        Else
                            TXTPURCGSTPER.Text = 0
                            TXTPURSGSTPER.Text = 0
                            TXTPURIGSTPER.Text = Val(DT.Rows(0).Item("PURIGSTPER"))
                        End If
                    End If
                End If
            End If

            PURCHASECALC()
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETBALANCE()
        Try

            Dim USERACCOUNTSADD, USERACCOUNTSEDIT, USERACCOUNTSVIEW, USERACCOUNTSDELETE As Boolean
            Dim DTACCOUNTSROW() As DataRow
            DTACCOUNTSROW = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERACCOUNTSADD = DTACCOUNTSROW(0).Item(1)
            USERACCOUNTSEDIT = DTACCOUNTSROW(0).Item(2)
            USERACCOUNTSVIEW = DTACCOUNTSROW(0).Item(3)
            USERACCOUNTSDELETE = DTACCOUNTSROW(0).Item(4)
            'If USERACCOUNTSVIEW = True Then
            LBLPURBAL.ForeColor = Color.Green
            LBLACCBAL.ForeColor = Color.Green

            LBLPURBAL.Text = "0.00"
            LBLACCBAL.Text = "0.00"
            If USERACCOUNTSVIEW = False Then
                LBLPURBAL.Visible = False
                LBLACCBAL.Visible = False
            End If

            'SALE BALANCE
            'START THIS CODE ONLY
            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS SALEBAL, ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname AND TRIALBALANCE.acc_cmpid = LEDGERS.Acc_cmpid AND TRIALBALANCE.acc_locationid = LEDGERS.Acc_locationid AND TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    LBLACCBAL.Text = DT.Rows(0).Item("SALEBAL")
            '    If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
            '        LBLACCBAL.ForeColor = Color.Red
            '    Else
            '        LBLACCBAL.ForeColor = Color.Green
            '    End If
            'End If
            'END OF CODE




            'PUR BALANCE

            'For Each drow As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
            '    DT = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS PURBAL , ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname AND TRIALBALANCE.acc_cmpid = LEDGERS.Acc_cmpid AND TRIALBALANCE.acc_locationid = LEDGERS.Acc_locationid AND TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & drow.Cells(GPURNAME.Index).Value.ToString & "' AND LEDGERS.ACC_CMPID = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then
            '        'LBLPURBAL.Text = DT.Rows(0).Item("PURBAL")
            '        If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
            '            LBLPURBAL.ForeColor = Color.Red
            '        Else
            '            LBLPURBAL.ForeColor = Color.Green
            '        End If
            '    End If
            '    'End If
            'Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKPURCHASEBALANCES() As Boolean
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable
        Dim TEMPMSG As Integer
        Dim BLN As Boolean = False
        For Each drow As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
            DT = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS PURBAL , ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID  ", " AND NAME = '" & drow.Cells(GPURNAME.Index).Value.ToString & "'  AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                'LBLPURBAL.Text = DT.Rows(0).Item("PURBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    TEMPMSG = MsgBox("Credit Limit Exceeded for " & drow.Cells(GPURNAME.Index).Value.ToString & ", Wish to Proceed?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then
                        BLN = True
                        Exit For
                    End If
                End If
            End If
            'End If
        Next
        Return BLN
    End Function

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            'If CMBACCCODE.Text.Trim <> "" Then GETBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                End If
                GETBALANCE()
                GETHSNCODE()
            End If

            If TXTSALEMOBILE.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_MOBILE,'') ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSALEMOBILE.Text = DT.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or lblcancelled.Visible = True Or PBPAID.Visible = True Or PBRECD.Visible = True Then
                    MsgBox("Voucher Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Booking Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsHolidayPackages
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJBOOKING.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()
                    edit = False

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNOOFROOMS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOOFROOMS.KeyPress
        numkeypress(e, TXTNOOFROOMS, Me)
    End Sub

    Private Sub TXTNOOFROOMS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNOOFROOMS.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
        'Try
        '    If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
        '        TXTTOTAL.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim), "0.00")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TXTEXTRAADULT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULT.KeyPress
        numkeypress(e, TXTEXTRAADULT, Me)
    End Sub

    Private Sub TXTEXTRAADULT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULT.Validated
        Try
            TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRACHILD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILD.KeyPress
        numkeypress(e, TXTEXTRACHILD, Me)
    End Sub

    Private Sub TXTEXTRACHILD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILD.Validated
        Try
            TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSOURCE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True


    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBOOKEDBY.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPLAN.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Validated
        If Val(TXTENQNO.Text.Trim) = 0 Then GETRATE()
    End Sub

    Sub GETRATE()
        Try
            If edit = True Then Exit Sub
            'GET RATE FROM TARIFFMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKDAYS,0) AS WEEKDAYS, ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKENDS,0) AS WEEKENDS ", "", " TARIFFMASTER INNER JOIN TARIFFMASTER_DESC ON TARIFFMASTER.TARIFF_ID = TARIFFMASTER_DESC.TARIFF_ID AND TARIFFMASTER.TARIFF_CMPID = TARIFFMASTER_DESC.TARIFF_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = TARIFFMASTER_DESC.TARIFF_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = TARIFFMASTER_DESC.TARIFF_YEARID INNER JOIN HOTELMASTER ON TARIFFMASTER.TARIFF_HOTELID = HOTELMASTER.HOTEL_ID AND TARIFFMASTER.TARIFF_CMPID = HOTELMASTER.HOTEL_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON TARIFFMASTER_DESC.TARIFF_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID INNER JOIN PLANMASTER ON TARIFFMASTER_DESC.TARIFF_PLANID = PLANMASTER.PLAN_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = PLANMASTER.PLAN_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = PLANMASTER.PLAN_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = PLANMASTER.PLAN_YEARID ", " AND HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND PLAN_NAME = '" & CMBPLAN.Text.Trim & "' AND CAST(TARIFF_FROMDATE AS DATE) <= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "' AND CAST(TARIFF_TODATE AS DATE) >= '" & Format(CHECKINDATE.Value.Date, "MM/dd/yyyy") & "'")
            If DT.Rows.Count > 0 Then
                If CHECKINDATE.Value.DayOfWeek = DayOfWeek.Saturday Or CHECKINDATE.Value.DayOfWeek = DayOfWeek.Sunday Then
                    TXTRATE.Text = DT.Rows(0).Item("WEEKENDS")
                Else
                    TXTRATE.Text = DT.Rows(0).Item("WEEKDAYS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then
                Dim INCLUSIONS As String = ""
                PLANvalidate(CMBPLAN, e, Me, INCLUSIONS)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENTNAME_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENTNAME.GotFocus
        Try
            If CMBAGENTNAME.Text.Trim = "" Then fillAGENT(CMBAGENTNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENTNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBAGENTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENTNAME.Validating
        Try
            If CMBAGENTNAME.Text.Trim <> "" Then AGENTVALIDATE(CMBAGENTNAME, e, Me, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLROOMTYPE()
        Try
            If CMBHOTELNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DISTINCT ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    DT.DefaultView.Sort = "ROOMTYPE"
                    CMBROOMTYPE.DataSource = DT
                    CMBROOMTYPE.DisplayMember = "ROOMTYPE"
                    If edit = False Then CMBROOMTYPE.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROOMTYPE.Enter
        Try
            If CMBHOTELNAME.Text.Trim <> "" And gridDoubleClick = False Then FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTCHILDRATE.KeyPress, TXTINFANTRATE.KeyPress, TXTMISCAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating, TXTCHILDRATE.Validating, TXTINFANTRATE.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBROOMTYPE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBROOMTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBROOMTYPE.Validating
        Try
            If CMBROOMTYPE.Text.Trim <> "" And CMBHOTELNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER_ROOMDESC.HOTEL_RATE as ROOMRATE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & CMBHOTELNAME.Text.Trim & "' AND ROOMTYPEMASTER.ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 And gridDoubleClick = False Then
                    TXTPURAMT.Text = DT.Rows(0).Item("ROOMRATE")
                    PURCHASECALC()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSECTOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSECTOR.Validated
        If TXTSECTOR.Text <> "" And TXTSECTOR.Text <> "   /   /   /   /   /" Then
            'GET LATEST SRNO
            If GRIDAIRDOUBLECLICK = False Then
                If GRIDAIRLINE.RowCount > 0 Then TXTAIRSRNO.Text = Val(GRIDAIRLINE.Rows(GRIDAIRLINE.RowCount - 1).Cells(GSRNO.Index).Value) + 1 Else TXTAIRSRNO.Text = 1
            End If

            TXTSECTOR.Text = UCase(TXTSECTOR.Text)
            SECTORGROUP.Visible = True
            SECTORGROUP.BringToFront()
            FILLGRIDSECTOR()
            GRIDSECTOR.Focus()
        End If
    End Sub

    Private Sub TXTEXTRAADULTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTEXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTEXTRAADULTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULTRATE.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
        total()
    End Sub

    Private Sub TXTEXTRACHILDRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTEXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTEXTRACHILDRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILDRATE.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
        total()
    End Sub

    Private Sub TXTAGENTCOMMPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTCOMMPER.KeyPress
        numdotkeypress(e, TXTAGENTCOMMPER, Me)
    End Sub

    Private Sub TXTAGENTCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTCOMMPER.Validated
        Try
            If CMBAGENTNAME.Text.Trim <> "" Then total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAGENTCOMMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTCOMMRS.KeyPress
        numdotkeypress(e, TXTAGENTCOMMRS, Me)
    End Sub

    Private Sub TXTAGENTCOMMRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTCOMMRS.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTAGENTTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTTDSPER.KeyPress
        numdotkeypress(e, TXTAGENTTDSPER, Me)
    End Sub

    Private Sub TXTAGENTTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTTDSPER.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTAGENTTDSRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTTDSRS.KeyPress
        numdotkeypress(e, TXTAGENTTDSRS, Me)
    End Sub

    Private Sub TXTAGENTTDSRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTTDSRS.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTOURCOMMPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMPER.KeyPress
        numdotkeypress(e, TXTOURCOMMPER, Me)
    End Sub

    Private Sub TXTOURCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMPER.Validated
        total()
    End Sub

    Private Sub TXTOURCOMMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMRS.KeyPress
        numdotkeypress(e, TXTOURCOMMRS, Me)
    End Sub

    Private Sub TXTOURCOMMRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMRS.Validated
        total()
    End Sub

    Private Sub TXTDISCPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCPER.KeyPress
        numdotkeypress(e, TXTDISCPER, Me)
    End Sub

    Private Sub TXTDISCPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCPER.Validated
        total()
    End Sub

    Private Sub TXTDISCRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRS.KeyPress
        numdotkeypress(e, TXTDISCRS, Me)
    End Sub

    Private Sub TXTDISCRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRS.Validated
        total()
    End Sub

    Private Sub cmbaddsub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaddsub.Validated
        total()
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        numdotkeypress(e, txtotherchg, Me)
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        total()
    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress
        numdotkeypress(e, TXTADULTS, Me)
    End Sub

    Private Sub TXTCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILDS.KeyPress
        numdotkeypress(e, TXTCHILDS, Me)
    End Sub

    Private Sub TXTCOMMRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDRS.KeyPress
        numdotkeypress(e, TXTCOMMRECDRS, Me)
    End Sub

    Private Sub TXTCOMMRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDRS.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTDISCRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDRS.KeyPress
        numdotkeypress(e, TXTDISCRECDRS, Me)
    End Sub

    Private Sub TXTDISCRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDRS.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTNCCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNCCHILDS.KeyPress
        numkeypress(e, TXTNCCHILDS, Me)
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMT.KeyPress
        numdotkeypress(e, TXTPURAMT, Me)
    End Sub

    Private Sub TXTPURAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURAMT.Validated, TXTSERVCHGS.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        If e.KeyChar <> "-" Then
            numdotkeypress(e, TXTPUROTHERCHGS, Me)
        End If
    End Sub

    Private Sub TXTPUROTHERCHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUROTHERCHGS.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTPURTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTAX.Validated
        PURCHASECALC()
    End Sub

    Private Sub CMBPURTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Enter
        Try
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

    End Sub

    Private Sub CMBPURTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURTAX.Validating
        Try
            If CMBPURTAX.Text.Trim <> "" Then TAXvalidate(CMBPURTAX, e, Me)
            PURCHASECALC()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPURTDSRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSRS.KeyPress
        numdotkeypress(e, TXTPURTDSRS, Me)
    End Sub

    Private Sub TXTPURTDSRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSRS.Validated
        PURCHASECALC()
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbADDtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBADDTAX.Text.Trim <> "" Then TAXvalidate(CMBADDTAX, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURADDTAX.Enter
        Try
            If CMBPURADDTAX.Text.Trim = "" Then filltax(CMBPURADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURADDTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True


    End Sub

    Private Sub CMBPURADDTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURADDTAX.Validating
        Try
            If CMBPURADDTAX.Text.Trim <> "" Then TAXvalidate(CMBPURADDTAX, e, Me)
            PURCHASECALC()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Enter
        Try
            If CMBPURCODE.Text.Trim = "" Then fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBAGENTCOMMDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAGENTCOMMDEL.Click
        Try
            TXTAGENTCOMMPER.Text = 0.0
            TXTAGENTCOMMRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBAGENTTDSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAGENTTDSDEL.Click
        Try
            TXTAGENTTDSPER.Text = 0.0
            TXTAGENTTDSRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBDISCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDISCDEL.Click
        Try
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREXTRAADULTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUREXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTPUREXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTPUREXTRAADULTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPUREXTRAADULTRATE.Validating
        PURCHASECALC()
    End Sub

    Private Sub TXTPUREXTRACHILDRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUREXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTPUREXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTPUREXTRACHILDRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPUREXTRACHILDRATE.Validating
        PURCHASECALC()
    End Sub

    Private Sub txtmobileno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobileno.KeyPress
        numkeypress(e, txtmobileno, Me)
    End Sub

    Private Sub CMBPURNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBPURCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBPURNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
        'Try
        '    'If CMBPURNAME.Text.Trim <> "" Then GETBALANCE()
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If CMBPURNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPURSTATECODE.Text = Val(DT.Rows(0).Item("PURSTATECODE"))
                    If ALLOWSAMESTATE = True And Val(TXTPURSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
                        EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
                        CMBPURNAME.Text = ""
                        TXTPURSTATECODE.Clear()
                    End If
                End If
                GETHSNCODE()
                'GETBALANCE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTPURADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCancel.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Wish to Cancel Booking Voucher?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If TEMPMSG = vbYes Then
                    Dim OBJBOOKING As New ClsHolidayPackages
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJBOOKING.CANCEL
                    If chkmobile.CheckState = CheckState.Checked Then SENDMSG("Hi, Your booking in " & CMBHOTELNAME.Text.Trim & " is Cancelled", txtmobileno.Text.Trim)
                    MsgBox("Booking Cancelled")
                    clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        If CMBPRINT.Text = "" Or CMBPRINT.Text = "All" Then
            TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJVOUCHER As New HolidayPackageVoucherDesign
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.GUESTNAME = CMBGUESTNAME.Text.Trim
                OBJVOUCHER.BOOKINGNO = BOOKNO
                OBJVOUCHER.FRMSTRING = "VOUCHER"
                OBJVOUCHER.Show()

                If GRIDTRANS.RowCount > 0 Then
                    Dim OBJCAR As New CarBookingVoucherDesign
                    OBJCAR.MdiParent = MDIMain
                    OBJCAR.BOOKINGNO = BOOKNO
                    OBJCAR.FRMSTRING = "VOUCHER"
                    OBJCAR.CARVOUCHERSTR = "NEW VOUCHER"
                    OBJCAR.Show()
                End If
            End If



            If ClientName = "RAMKRISHNA" Then
                If MsgBox("Wish to Print Welcome Letter?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJCOVER As New HolidayPackageVoucherDesign
                    OBJCOVER.MdiParent = MDIMain
                    OBJCOVER.BOOKINGNO = BOOKNO
                    OBJCOVER.FRMSTRING = "COVER"
                    OBJCOVER.Show()
                End If

                If MsgBox("Wish to Print Feedback Form?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJFEEDBACK As New HolidayPackageVoucherDesign
                    OBJFEEDBACK.MdiParent = MDIMain
                    OBJFEEDBACK.BOOKINGNO = BOOKNO
                    OBJFEEDBACK.FRMSTRING = "FEEDBACK"
                    OBJFEEDBACK.Show()
                End If
            End If


            TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJINV As New HolidayPackageVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.BOOKINGDATE = Convert.ToDateTime(BOOKINGDATE.Text).Date
                OBJINV.HIDEAMT = chkhideamt.Checked
                OBJINV.HIDEtransamt = chktrans.Checked
                OBJINV.PRINTGUESTNAME = chkguestname.Checked
                OBJINV.FRMSTRING = "INVOICE"
                OBJINV.Show()
            End If

            If ClientName = "URMI" Then
                TEMPMSG = MsgBox("Wish to Print Vehicle Reservation Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJINV As New HolidayPackageVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.FRMSTRING = "VEHICLEINVOICE"
                    OBJINV.Show()
                End If
            End If

            'SPECIALLY FOR PRATAMESH TOURS
            'DONE BY GULKIT
            'THERE ARE 2 INVOICES FOR PRATAMESH AS PER THEIR REQUIREMENT
            If ClientName = "PRATAMESH" Then
                TEMPMSG = MsgBox("Wish to Print Group Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJINV As New HolidayPackageVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.HIDEAMT = chkhideamt.Checked
                    OBJINV.HIDEtransamt = chktrans.Checked
                    OBJINV.PRINTGUESTNAME = chkguestname.Checked
                    OBJINV.FRMSTRING = "PRATAMESHNEWINVOICE"
                    OBJINV.Show()
                End If
            End If

        ElseIf CMBPRINT.Text = "Voucher" Then

            Dim OBJVOUCHER As New HolidayPackageVoucherDesign
            OBJVOUCHER.MdiParent = MDIMain
            OBJVOUCHER.BOOKINGNO = BOOKNO
            OBJVOUCHER.FRMSTRING = "VOUCHER"
            OBJVOUCHER.Show()

            If GRIDTRANS.RowCount > 0 Then
                Dim OBJCAR As New CarBookingVoucherDesign
                OBJCAR.MdiParent = MDIMain
                OBJCAR.BOOKINGNO = BOOKNO
                OBJCAR.FRMSTRING = "VOUCHER"
                OBJCAR.CARVOUCHERSTR = "NEW VOUCHER"
                OBJCAR.Show()
            End If


        ElseIf CMBPRINT.Text = "Invoice" Then
            Dim OBJINV As New HolidayPackageVoucherDesign
            OBJINV.MdiParent = MDIMain
            OBJINV.BOOKINGNO = BOOKNO
            OBJINV.HIDEAMT = chkhideamt.Checked
            OBJINV.HIDEtransamt = chktrans.Checked
            OBJINV.PRINTGUESTNAME = chkguestname.Checked
            OBJINV.FRMSTRING = "INVOICE"
            OBJINV.Show()
        End If
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPBOOKINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGE.KeyPress
        numkeypress(e, TXTAGE, Me)
    End Sub

    Private Sub TXTPURGTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPURGTOTAL.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" And Val(TXTPURAMT.Text.Trim) > 0 And Val(TXTPURGTOTAL.Text.Trim) > 0 Then
                fillgridPURCHASE()
                total()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADULTS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADULTS.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
    End Sub

    Private Sub TXTCHILDS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCHILDS.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
    End Sub

    Private Sub TXTNCCHILDS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNCCHILDS.Validated
        TXTTOTALPAX.Text = Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) + Val(TXTNCCHILDS.Text.Trim) + Val(TXTEXTRAADULT.Text.Trim) + Val(TXTEXTRACHILD.Text.Trim)
    End Sub

    Private Sub PBDICSRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDICSRECDDEL.Click
        Try
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0

            PURCHASECALC()
            TXTDISCRECDPER.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSPER.KeyPress
        numdotkeypress(e, TXTPURTDSPER, Me)
    End Sub

    Private Sub TXTPURTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSPER.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTCOMMRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDPER.KeyPress
        numdotkeypress(e, TXTCOMMRECDPER, Me)
    End Sub

    Private Sub TXTCOMMRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDPER.Validated
        PURCHASECALC()
    End Sub

    Private Sub TXTDISCRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDPER.KeyPress
        numdotkeypress(e, TXTDISCRECDPER, Me)
    End Sub

    Private Sub TXTDISCRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDPER.Validated
        PURCHASECALC()
    End Sub

    Private Sub cmbguestname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGUESTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGUEST As New SelectGuest
                OBJGUEST.ShowDialog()
                If OBJGUEST.TEMPGUESTNAME <> "" Then CMBGUESTNAME.Text = OBJGUEST.TEMPGUESTNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GUEST_MOBILENO, ISNULL(GUEST_EMAIL,'') ", "", " GUESTMASTER", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_CMPID = " & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    txtmobileno.Text = DT.Rows(0).Item(0)
                    txtemailadd.Text = DT.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        Try
            numkeypress(e, TXTCOPY, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If Val(TXTCOPY.Text.Trim) > 0 Then
                If edit = True Then
                    MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTCOPY.Text.Trim <> "" Then
                    TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        TEMPBOOKINGNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPBOOKINGNO
                        TEMPBOOKINGNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJBOOKING As New ClsHolidayPackages()

                        ALPARAVAL.Add(TXTCOPY.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                'txtbookingno.Text = TEMPBOOKINGNO
                                TXTSTATECODE.Text = dr("STATECODE")
                                CMBHSNITEMDESC.Text = dr("ITEMDESC")
                                BOOKINGDATE.Text = Convert.ToDateTime(dr("BOOKINGDATE")).Date

                                txtemailadd.Text = dr("EMAILADD")
                                txtmobileno.Text = dr("MOBILENO")
                                TXTGUESTADD.Text = dr("GUESTADD")
                                TXTADD.Text = dr("SALEADD")
                                txtrefno.Text = dr("REFNO")

                                CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                                CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                                TXTTOURNAME.Text = dr("TOURNAME")
                                CMBPACKAGETYPE.Text = dr("PACKAGETYPE")
                                CMBQUOTECALC.Text = dr("QUOTETYPE")
                                PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                                PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                                TXTARRIVALFROM.Text = Convert.ToString(dr("ARRIVALFROM"))
                                TXTDEPARTURETO.Text = Convert.ToString(dr("DEPARTTO"))
                                TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                                TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))

                                CMBGUESTNAME.Text = dr("GUEST")
                                CMBGROUPDEPARTURE.Text = Convert.ToString(dr("GROUPDEPART"))


                                TXTADULTS.Text = dr("ADULTS")
                                TXTCHILDS.Text = dr("CHILDS")
                                TXTNCCHILDS.Text = dr("NCCHILDS")
                                TXTTOTALPAX.Text = dr("TOTALPAX")

                                TXTEXTRAADULT.Text = dr("EXTRAADULT")
                                TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                                TXTEXTRACHILD.Text = dr("EXTRACHILD")
                                TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                                CMBBOOKEDBY.Text = dr("BOOKEDBY")
                                CMBSOURCE.Text = dr("SOURCE")
                                CMBAGENTNAME.Text = dr("AGENTNAME")

                                TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                                TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                                TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                                TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                                TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                                TXTOURCOMMPER.Text = dr("OURCOMMPER")
                                TXTOURCOMMRS.Text = dr("OURCOMMRS")

                                TXTDISCPER.Text = dr("DISCPER")
                                TXTDISCRS.Text = dr("DISCRS")

                                cmbtax.Text = dr("TAXNAME")
                                txttax.Text = dr("TAXAMT")
                                CMBADDTAX.Text = dr("ADDTAXNAME")
                                TXTADDTAX.Text = dr("ADDTAXAMT")

                                CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                                If dr("OTHERCHGS") > 0 Then
                                    txtotherchg.Text = dr("OTHERCHGS")
                                    cmbaddsub.Text = "Add"
                                Else
                                    txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                    cmbaddsub.Text = "Sub."
                                End If

                                txtroundoff.Text = dr("ROUNDOFF")

                                txtremarks.Text = Convert.ToString(dr("REMARKS"))
                                TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                                TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))
                                TXTPICKUP.Text = Convert.ToString(dr("PICKUP"))
                                CMBNOTES.Text = Convert.ToString(dr("NOTESNAME"))
                                TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                                CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                                TXTPOLICY.Text = Convert.ToString(dr("POLICY"))

                                TXTHSNCODE.Text = dr("HSNCODE")


                                If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                                If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                                If CHKMANUAL.Checked = True Then
                                    TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                    TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                    TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                                End If

                                If CHKMANUAL.Checked = True Then
                                    TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                    TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                    TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                                End If

                                TXTCGSTPER.Text = dr("CGSTPER")
                                TXTCGSTAMT.Text = dr("CGSTAMT")
                                TXTSGSTPER.Text = dr("SGSTPER")
                                TXTSGSTAMT.Text = dr("SGSTAMT")
                                TXTIGSTPER.Text = dr("IGSTPER")
                                TXTIGSTAMT.Text = dr("IGSTAMT")

                                If CHKMANUAL.Checked = True Then
                                    TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                    TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                    TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                                End If


                                chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                                CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                                CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                                CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))


                                'BOOKING DETAILS
                                GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE"), Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))
                                CMBINCLUSION.Text = Convert.ToString(dr("CINCLUSION"))
                                TXTINCLUSION.Text = Convert.ToString(dr("TINCLUSION"))
                                CMBEXCLUSION.Text = Convert.ToString(dr("CEXCLUSION"))
                                TXTEXCLUSION.Text = Convert.ToString(dr("TEXCLUSION"))
                            Next
                            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                        End If


                        'GUEST DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGGUESTDETAILS()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                CMBGUESTNAME.Text = (DR("GUESTNAME"))
                                GRIDGUESTDETAILS.Rows.Add(DR("GUESTSRNO"), DR("GUESTNAME"), DR("AGE"), DR("SEX"))
                            Next
                        End If



                        'TOUR DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGTOURDETAILS()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDTOUR.Rows.Add(DR("TOURSRNO"), DR("TOURHEADER"), DR("TOURDETAILS"))
                            Next
                        End If



                        'TRANS DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGTRANSDETAILS()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDTRANS.Rows.Add(DR("CARSRNO"), DR("CONTACTPERSON"), DR("CONTACTNO"), DR("CARTYPE"), DR("CARNAME"), Val(DR("CARADULTS")), Val(DR("CARCHILDS")), Val(DR("CARTOTALPAX")), Format(DR("PICKUPON"), "dd/MM/yyyy"), DR("PICKUPFROM"), DR("PICKUPTIME"), DR("PICKUPDTLS"), Format(DR("DROPON"), "dd/MM/yyyy"), DR("DROPAT"), DR("DROPTIME"), DR("DROPDTLS"), Val(DR("CARDAYS")), DR("ROUTE"), DR("CARITINERARY"), DR("CARNOTE"), Format(Val(DR("CARAMT")), "0.00"))
                            Next
                        End If



                        'PURCHASE DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(DR("PURDATE"), "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PUREXTRAADULTRATE"), DR("PUREXTRACHILDRATE"), DR("PURAMT"), DR("PURDISCPER"), DR("PURDISC"), DR("PURSUBTOTAL"), DR("PURCOMMPER"), DR("PURCOMM"), DR("PURTDSPER"), DR("PURTDS"), DR("PURSERVTAX"), DR("PURSERVCHGS"), DR("PURNETT"), DR("TAXNAME"), DR("TAXAMT"), DR("ADDTAXNAME"), DR("ADDTAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PURCESSPER"), DR("PURCESSAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), 0, 0, 0, DR("PURGTOTAL"))
                            Next
                            GRIDPURCHASE.ClearSelection()
                        End If

                        'GET AIRLINE DATA
                        Dim OBJAIR1 As New ClsCommon
                        Dim DTA1 As DataTable = OBJAIR1.search(" ISNULL(BOOKING_NO, 0) AS GROUPDEPNO, ISNULL(BOOKING_GRIDSRNO, 0) AS AIRSRNO, ISNULL(BOOKING_SECTOR, '') AS SECTOR, ISNULL(BOOKING_FLTNO, '') AS FLTNO, ISNULL(BOOKING_TYPE, '') AS AIRLINETYPE, ISNULL(BOOKING_BASIC, 0) AS BASIC, ISNULL(BOOKING_PSF, 0) AS PSF, ISNULL(BOOKING_TAXES, 0) AS TAXES, ISNULL(BOOKING_AMT, 0) AS AIRAMT ", "", " HOLIDAYPACKAGEMASTER_AIRLINE ", " AND HOLIDAYPACKAGEMASTER_AIRLINE.BOOKING_NO = " & TEMPBOOKINGNO & " AND BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_AIRLINE.BOOKING_GRIDSRNO")
                        If DTA1.Rows.Count > 0 Then
                            For Each DR1 As DataRow In DTA1.Rows
                                GRIDAIRLINE.Rows.Add(DR1("AIRSRNO"), DR1("SECTOR"), DR1("FLTNO"), DR1("AIRLINETYPE"), Format(Val(DR1("BASIC")), "0.00"), Format(Val(DR1("PSF")), "0.00"), Format(Val(DR1("TAXES")), "0.00"), Format(Val(DR1("AIRAMT")), "0.00"))
                            Next
                            TOTAL()
                        End If

                        'GET GRIDFLIGHT DATA
                        Dim OBJAIR2 As New ClsCommon
                        Dim DTA2 As DataTable = OBJAIR2.search(" HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_GRIDSRNO AS GRIDSRNO, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_BOOKSRNO AS BOOKSRNO, ISNULL(FROMSECTORMASTER.SECTOR_NAME, '') AS FROMSEC, ISNULL(TOSECTORMASTER.SECTOR_NAME, '') AS TOSEC, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FLIGHTNO AS FLIGHTNO, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FLIGHTDATE AS FLIGHTDATE, ISNULL(HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_ARRIVES, '') AS ARRIVES, CLASSMASTER.CLASS_NAME AS CLASS", "", " SECTORMASTER AS TOSECTORMASTER RIGHT OUTER JOIN HOLIDAYPACKAGEMASTER_FLIGHTDESC LEFT OUTER JOIN CLASSMASTER ON HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = CLASSMASTER.CLASS_YEARID AND  HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = CLASSMASTER.CLASS_CMPID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CLASSID = CLASSMASTER.CLASS_ID ON  TOSECTORMASTER.SECTOR_ID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_TOID AND TOSECTORMASTER.SECTOR_CMPID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID AND TOSECTORMASTER.SECTOR_YEARID = HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID LEFT OUTER JOIN SECTORMASTER AS FROMSECTORMASTER ON HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_FROMID = FROMSECTORMASTER.SECTOR_ID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = FROMSECTORMASTER.SECTOR_CMPID AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = FROMSECTORMASTER.SECTOR_YEARID", " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_CMPID = " & CmpId & " AND HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_BOOKSRNO ASC, HOLIDAYPACKAGEMASTER_FLIGHTDESC.BOOKING_GRIDSRNO ASC")
                        If DTA2.Rows.Count > 0 Then
                            For Each DR2 As DataRow In DTA2.Rows
                                GRIDFLIGHT.Rows.Add(DR2("GRIDSRNO").ToString, DR2("BOOKSRNO"), DR2("FROMSEC").ToString, DR2("TOSEC").ToString, DR2("FLIGHTNO").ToString, DR2("FLIGHTDATE").ToString, DR2("ARRIVES").ToString, DR2("CLASS").ToString)
                            Next
                            TOTAL()
                        End If


                        'MISC GRID
                        Dim OBJMISC As New ClsCommon
                        Dim DTM As DataTable = OBJMISC.search("  ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_SRNO, 0) AS SRNO, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_TYPE, '') AS TYPE, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_REMARKS, '') AS REMARKS, ISNULL(HOLIDAYPACKAGEMASTER_MISC.ENQ_AMOUNT, 0) AS MISCAMOUNT ", "", "  HOLIDAYPACKAGEMASTER INNER JOIN HOLIDAYPACKAGEMASTER_MISC ON HOLIDAYPACKAGEMASTER.BOOKING_NO = HOLIDAYPACKAGEMASTER_MISC.ENQ_NO AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = HOLIDAYPACKAGEMASTER_MISC.ENQ_YEARID ", " AND HOLIDAYPACKAGEMASTER_MISC.ENQ_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_MISC.ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_MISC.ENQ_SRNO ")
                        If DTM.Rows.Count > 0 Then
                            For Each DR As DataRow In DTM.Rows
                                GRIDMISC.Rows.Add(Val(DR("SRNO")), DR("TYPE"), DR("REMARKS"), Val(DR("MISCAMOUNT")))
                            Next
                        End If

                        'GET SCAN DOCS DATA
                        Dim OBJCMN As New ClsCommon
                        dt = OBJCMN.search(" HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NAME AS NAME, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " HOLIDAYPACKAGEMASTER_UPLOAD ", " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY HOLIDAYPACKAGEMASTER_UPLOAD.BOOKING_GRIDSRNO")
                        If dt.Rows.Count > 0 Then
                            For Each DTR As DataRow In dt.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                            Next
                        End If

                        total()
                        chkchange.CheckState = CheckState.Checked

                    Else
                        MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBPURCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBPURNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = "HP-" & TEMPBOOKINGNO
            OBJRECPAY.SALEBILLINITIALS = "HS-" & TEMPBOOKINGNO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HolidayPackage_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ARHAM" Then
            Me.Close()
            Exit Sub
        End If

        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True

        If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
            CHKREFUNDED.Visible = True
            CHKFAILED.Visible = True
        End If
        If ClientName = "RAMKRISHNA" Or ClientName = "KHANNA" Then
            LBLGROUP.Visible = True
            CMBGROUPDEPARTURE.Visible = True
        End If

        If ClientName <> "AIRTRINITY" Then
            CMBCURCODE.Visible = False
            GCURCODE.Visible = False
            TXTROE.Visible = False
            GROE.Visible = False
            TXTTOTAL.Left = Val(TXTTOTAL.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            GRIDBOOKINGS.Width = Val(GRIDBOOKINGS.Width) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            LBLTOTALAMT.Left = Val(LBLTOTALAMT.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            TXTTOTALAMT.Left = TXTTOTAL.Left
        End If

        'If (ClientName = "SSR" Or ClientName = "KHANNA" Or ClientName = "CLASSIC" Or ClientName = "HBAZAAR" Or ClientName = "MAHARAJA" Or ClientName = "AERO" Or ClientName = "URMI") Then
        CHKTAXSERVCHGS.Visible = True
        LBLCOMM.Text = "Service Chgs"
        TXTOURCOMMRS.BackColor = Color.White
        TXTOURCOMMRS.ReadOnly = False
        TXTOURCOMMRS.TabStop = True
        'End If

        If ClientName = "CLASSIC" Then
            CHKDONTPOSTSERVCHGS.Visible = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(USERPOINTS,0) AS USERPOINTS, ISNULL(REFPOINTS,0) AS REFPOINTS", "", "POINTS", "")
            If DT.Rows.Count > 0 Then
                TXTUSERPOINTS.Text = Val(DT.Rows(0).Item("USERPOINTS"))
                TXTREFPOINTS.Text = Val(DT.Rows(0).Item("REFPOINTS"))
            End If
        End If

        'If (ClientName = "CLASSIC" Or ClientName = "KHANNA" Or ClientName = "MAHARAJA" Or ClientName = "AERO" Or ClientName = "URMI") Then
        LBLOURCOMM.Visible = True
        TXTOURCOMM.Visible = True
        'End If
        If ClientName = "GLOBAL" Then
            LBLCGST.Visible = False
            TXTCGSTPER.Visible = False
            TXTCGSTAMT.Visible = False
            LBLSGST.Visible = False
            TXTSGSTPER.Visible = False
            TXTSGSTAMT.Visible = False
            LBLIGST.Visible = False
            TXTIGSTPER.Visible = False
            TXTIGSTAMT.Visible = False
            LBLHSNDESC.Visible = False
            CMBHSNITEMDESC.Visible = False
            LBLHSNCODE.Visible = False
            TXTHSNCODE.Visible = False
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False
            TXTPURSTATECODE.Visible = False
            CHKMANUAL.Visible = False
            CHKPURMANUAL.Visible = False
            TXTPURCGSTPER.Visible = False
            TXTPURCGSTAMT.Visible = False
            GCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            TXTPURSGSTPER.Visible = False
            TXTPURSGSTAMT.Visible = False
            GSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            TXTPURIGSTPER.Visible = False
            TXTPURIGSTAMT.Visible = False
            GIGSTPER.Visible = False
            GIGSTAMT.Visible = False


            ' IN DATA GRIDVIEW PURCHASE COLUMN 

            CMBPURHSNITEMDESC.Visible = False
            GPURHSNITEMDESC.Visible = False
            TXTPURHSNCODE.Visible = False
            GHSNCODE.Visible = False

            TXTPUREXTRAADULTRATE.Left = CMBPURHSNITEMDESC.Left
            TXTPUREXTRACHILDRATE.Left = TXTPUREXTRAADULTRATE.Left + TXTPUREXTRAADULTRATE.Width
            TXTPURAMT.Left = TXTPUREXTRACHILDRATE.Left + TXTPUREXTRACHILDRATE.Width
            TXTDISCRECDPER.Left = TXTPURAMT.Left + TXTPURAMT.Width
            TXTDISCRECDRS.Left = TXTDISCRECDPER.Left + TXTDISCRECDPER.Width
            TXTCOMMRECDPER.Left = TXTDISCRECDRS.Left + TXTDISCRECDRS.Width
            TXTCOMMRECDRS.Left = TXTCOMMRECDPER.Left + TXTCOMMRECDPER.Width
            TXTPURTDSPER.Left = TXTCOMMRECDRS.Left + TXTCOMMRECDRS.Width
            TXTPURTDSRS.Left = TXTPURTDSPER.Left + TXTPURTDSPER.Width
            CHKSERVTAX.Left = TXTPURTDSRS.Left + TXTPURTDSRS.Width
            TXTSERVCHGS.Left = CHKSERVTAX.Left + CHKSERVTAX.Width
            CMBPURTAX.Left = TXTSERVCHGS.Left + TXTSERVCHGS.Width
            TXTPURTAX.Left = CMBPURTAX.Left + CMBPURTAX.Width
            CMBPURADDTAX.Left = TXTPURTAX.Left + TXTPURTAX.Width
            TXTPURADDTAX.Left = CMBPURADDTAX.Left + CMBPURADDTAX.Width
            CMBPUROTHERCHGS.Left = TXTPURADDTAX.Left + TXTPURADDTAX.Width
            TXTPUROTHERCHGS.Left = CMBPUROTHERCHGS.Left + CMBPUROTHERCHGS.Width
            TXTPURGTOTAL.Left = TXTPUROTHERCHGS.Left + TXTPUROTHERCHGS.Width

        End If


        If edit = False Then clear()
    End Sub

    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try

            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec / Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If (PBCN.Visible = True) Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Credit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.BILLNO = "HS-" & txtbookingno.Text.Trim
                    OBJCN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOURNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTTOURNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub PACKAGEFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PACKAGEFROM.Validated
        CALDAYS()
    End Sub

    Private Sub PACKAGEFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKAGEFROM.Validating
        'as PER ASHOK BHAI REQ
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(PACKAGEFROM.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
        If edit = False And CMBGROUPDEPARTURE.Text.Trim = "" And Val(TXTENQNO.Text.Trim) = 0 Then PACKAGETO.Value = DateAdd(DateInterval.Day, 1, PACKAGEFROM.Value)
        CHECKINDATE.Value = PACKAGEFROM.Value.Date
        PICKUPDATE.Value = PACKAGEFROM.Value.Date
    End Sub

    Private Sub PACKAGETO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PACKAGETO.Validating
        'DONE TEMPORARILY
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(PACKAGETO.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
        CHECKOUTDATE.Value = PACKAGETO.Value.Date
        DROPDDATE.Value = PACKAGETO.Value.Date
    End Sub

    Private Sub CHECKINDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKINDATE.Validating
        'AS PER ASHOK BHAI REQ
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(CHECKINDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
        If edit = False Then CHECKOUTDATE.Value = DateAdd(DateInterval.Day, 1, CHECKINDATE.Value)
    End Sub

    Private Sub CHECKOUTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CHECKOUTDATE.Validating
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(CHECKOUTDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Private Sub PURDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PURDATE.Validating
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTENQ.Click
        Try

            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBHSNITEMDESC.Text.Trim = "" Or TXTHSNCODE.Text.Trim = "" Then
                MsgBox("Please Enter HSN Code First", MsgBoxStyle.Critical)
                CMBHSNITEMDESC.Focus()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            SELECTENQ.Clear()
            Dim OBJPACKAENQ As New SelectPackageEnq
            OBJPACKAENQ.ShowDialog()
            SELECTENQ = OBJPACKAENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then

                'GET ALL DATA FROM HOTELENQ
                Dim OBJENQ As New ClsHolidayEnquiry
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(SELECTENQ.Rows(0).Item("ENQNO"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJENQ.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJENQ.SELECTBOOKINGDESC
                If DT.Rows.Count > 0 Then
                    chkchange.CheckState = CheckState.Checked

                    'FILL GUEST
                    GRIDGUESTDETAILS.Rows.Add(1, DT.Rows(0).Item("GUESTNAME"), 0, "Male")
                    getsrno(GRIDGUESTDETAILS)

                    For Each dr As DataRow In DT.Rows

                        TXTENQNO.Text = SELECTENQ.Rows(0).Item("ENQNO")
                        txtrefno.Text = dr("REFNO")
                        CMBGUESTNAME.Text = dr("GUESTNAME")
                        CMBNAME.Text = dr("NAME")
                        TXTGUESTADD.Text = dr("GUESTADD")

                        TXTTOURNAME.Text = dr("TOURNAME")
                        CMBQUOTECALC.Text = dr("QUOTETYPE")
                        CMBPACKAGETYPE.Text = dr("PACKAGETYPE")

                        PACKAGEFROM.Value = Convert.ToDateTime(dr("PACKAGEFROM")).Date
                        PACKAGETO.Value = Convert.ToDateTime(dr("PACKAGETO")).Date

                        TXTADULTS.Text = dr("ADULTS")
                        TXTCHILDS.Text = dr("CHILDS")
                        TXTNCCHILDS.Text = dr("NCCHILDS")
                        TXTTOTALPAX.Text = dr("TOTALPAX")

                        TXTEXTRAADULT.Text = dr("EXTRAADULT")
                        TXTEXTRAADULTRATE.Text = dr("EXTRAADULTRATE")
                        TXTEXTRACHILD.Text = dr("EXTRACHILD")
                        TXTEXTRACHILDRATE.Text = dr("EXTRACHILDRATE")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")

                        CMBNOTES.Text = dr("NOTESNAME")
                        TXTNOTES.Text = dr("NOTES")
                        CMBCANCEL.Text = dr("POLICYNAME")
                        TXTPOLICY.Text = dr("POLICY")


                        'BOOKING DETAILS
                        GRIDBOOKINGS.Rows.Add(dr("BOOKINGSRNO").ToString, dr("HOTELNAME"), dr("CONFNO"), dr("CONFBY"), dr("INCLUSIONS"), Format(Convert.ToDateTime(dr("ARRIVAL")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("DEPARTURE")).Date, "dd/MM/yyyy"), dr("ROOMTYPE").ToString, dr("PLAN").ToString, dr("BADULTS"), dr("BCHILDS"), dr("BINFANTS"), dr("BEXTRAADULTS"), dr("BEXTRAADULTSRATE"), dr("BEXTRACHILDS"), dr("BEXTRACHILDSRATE"), dr("BTOTALPAX"), dr("NOOFROOMS").ToString, dr("BPACKAGE"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("CHILDRATE")), "0.00"), Format(Val(dr("INFANTRATE")), "0.00"), dr("CURCODE").ToString, Format(Val(dr("ROE")), "0.00"), Format(Val(dr("amt")), "0.00"), Val(dr("NIGHTS")))

                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                End If

                'TOUR DETAILS
                DT = OBJENQ.SELECTBOOKINGTOURDETAILS()
                If DT.Rows.Count > 0 Then
                    'For Each DR As DataRow In DT.Rows
                    '    GRIDTOUR.Rows.Add(DR("TOURSRNO"), Format(DR("TOURDATE"), "dd/MM/yyyy"), DR("TOURDETAILS"))
                    'Next
                    For Each DR As DataRow In DT.Rows
                        GRIDTOUR.Rows.Add(DR("SRNO").ToString, DR("HEADER"), DR("DETAILS"))
                    Next
                    GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1
                End If


                'TRANS DETAILS
                Dim DT3 As DataTable = OBJENQ.SELECTBOOKINGTRANSDETAILS()
                If DT3.Rows.Count > 0 Then
                    For Each DR2 As DataRow In DT3.Rows
                        GRIDTRANS.Rows.Add(DR2("CARSRNO"), DR2("CONTACTPERSON"), DR2("CONTACTNO"), DR2("CARTYPE"), DR2("CARNAME"), Val(DR2("CARADULTS")), Val(DR2("CARCHILDS")), Val(DR2("CARTOTALPAX")), Format(DR2("PICKUPON"), "dd/MM/yyyy"), DR2("PICKUPFROM"), DR2("PICKUPTIME"), DR2("PICKUPDTLS"), Format(DR2("DROPON"), "dd/MM/yyyy"), DR2("DROPAT"), DR2("DROPTIME"), DR2("DROPDTLS"), Val(DR2("CARDAYS")), DR2("ROUTE"), DR2("CARITINERARY"), DR2("CARNOTE"), Format(Val(DR2("CARAMT")), "0.00"))
                    Next
                End If

                total()


            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBNOTES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Enter
        Try
            If CMBNOTES.Text.Trim = "" Then FILLNOTE(CMBNOTES, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTNOTES.Clear()
            Dim DT As DataTable = OBJCMN.search(" NOTE_REMARKS AS NOTE", "", " NOTEMASTER", " AND NOTE_NAME ='" & CMBNOTES.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTNOTES.Text = DT.Rows(0).Item("NOTE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNOTES.Validating
        Try
            If CMBNOTES.Text.Trim <> "" Then NOTEVALIDATE(CMBNOTES, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Enter
        Try
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTPOLICY.Clear()
            Dim DT As DataTable = OBJCMN.search(" POLICY_REMARKS AS POLICY", "", " POLICYMASTER", " AND POLICY_NAME ='" & CMBCANCEL.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTPOLICY.Text = DT.Rows(0).Item("POLICY")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCANCEL.Validating
        Try
            If CMBCANCEL.Text.Trim <> "" Then POLICYvalidate(CMBCANCEL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\HOLIDAY\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
                txtimgpath.Text = PBSoftCopy.ImageLocation
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCARNAME.Enter
        Try
            If CMBCARNAME.Text.Trim = "" Then FILLVEHICLE(CMBCARNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCARTYPE.Enter
        Try
            If CMBCARTYPE.Text.Trim = "" Then FILLVEHICLETYPE(CMBCARTYPE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCARTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCARTYPE.Validating
        Try
            If CMBCARTYPE.Text.Trim <> "" Then VEHICLETYPEvalidate(CMBCARTYPE, e, Me)
            'CMBCARNAME.Text = ""
            'FILLVEHICLE(CMBCARNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCARSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCARSRNO.GotFocus
        Try
            If GRIDCARDOUBLECLICK = False Then
                If GRIDTRANS.RowCount > 0 Then
                    TXTCARSRNO.Text = Val(GRIDTRANS.Rows(GRIDTRANS.RowCount - 1).Cells(GCARSRNO.Index).Value) + 1
                Else
                    TXTCARSRNO.Text = 1
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDCAR()
        Try
            EP.Clear()
            If Not CALDAYS() Then
                Exit Sub
            End If

            If GRIDCARDOUBLECLICK = False Then

                GRIDTRANS.Rows.Add(Val(TXTCARSRNO.Text.Trim), TXTCONTACTPERSON.Text.Trim, TXTCONTACTNO.Text.Trim, CMBCARTYPE.Text.Trim, CMBCARNAME.Text.Trim, Val(TXTCARADULTS.Text.Trim), Val(TXTCARCHILDS.Text.Trim), (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim)), Format(PICKUPDATE.Value.Date, "dd/MM/yyyy"), TXTPICKFROM.Text.Trim, TXTPICKTIME.Text.Trim, TXTPICKDTLS.Text.Trim, Format(DROPDDATE.Value.Date, "dd/MM/yyyy"), TXTDROPAT.Text.Trim, TXTDROPTIME.Text.Trim, TXTDROPDTLS.Text.Trim, Val(TXTCARDAYS.Text.Trim), TXTROUTE.Text.Trim, TXTCARITINERARY.Text.Trim, TXTCARNOTE.Text.Trim, Val(TXTCARAMT.Text.Trim))
                getsrno(GRIDTRANS)

            ElseIf GRIDCARDOUBLECLICK = True Then

                GRIDTRANS.Item(GCARSRNO.Index, TEMPCARROW).Value = TXTCARSRNO.Text.Trim
                GRIDTRANS.Item(GCARCONTACTNAME.Index, TEMPCARROW).Value = TXTCONTACTPERSON.Text.Trim
                GRIDTRANS.Item(GCARCONTACTNO.Index, TEMPCARROW).Value = TXTCONTACTNO.Text.Trim
                GRIDTRANS.Item(GCARTYPE.Index, TEMPCARROW).Value = CMBCARTYPE.Text.Trim
                GRIDTRANS.Item(GCARNAME.Index, TEMPCARROW).Value = CMBCARNAME.Text.Trim
                GRIDTRANS.Item(GCARADULTS.Index, TEMPCARROW).Value = Val(TXTCARADULTS.Text.Trim)
                GRIDTRANS.Item(GCARCHILDS.Index, TEMPCARROW).Value = Val(TXTCARCHILDS.Text.Trim)
                GRIDTRANS.Item(GCARPAX.Index, TEMPCARROW).Value = (Val(TXTCARADULTS.Text.Trim) + Val(TXTCARCHILDS.Text.Trim))
                GRIDTRANS.Item(GCARPICKUP.Index, TEMPCARROW).Value = Format(PICKUPDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARPICKUPFROM.Index, TEMPCARROW).Value = TXTPICKFROM.Text.Trim
                GRIDTRANS.Item(GCARPICKUPTIME.Index, TEMPCARROW).Value = TXTPICKTIME.Text.Trim
                GRIDTRANS.Item(GCARPICKUPDTLS.Index, TEMPCARROW).Value = TXTPICKDTLS.Text.Trim
                GRIDTRANS.Item(GCARDROP.Index, TEMPCARROW).Value = Format(DROPDDATE.Value.Date, "dd/MM/yyyy")
                GRIDTRANS.Item(GCARDROPTO.Index, TEMPCARROW).Value = TXTDROPAT.Text.Trim
                GRIDTRANS.Item(GCARDROPTIME.Index, TEMPCARROW).Value = TXTDROPTIME.Text.Trim
                GRIDTRANS.Item(GCARDROPDTLS.Index, TEMPCARROW).Value = TXTDROPDTLS.Text.Trim
                GRIDTRANS.Item(GCARDAYS.Index, TEMPCARROW).Value = Val(TXTCARDAYS.Text.Trim)
                GRIDTRANS.Item(GCARROUTE.Index, TEMPCARROW).Value = TXTROUTE.Text.Trim
                GRIDTRANS.Item(GCARITINERARY.Index, TEMPCARROW).Value = TXTCARITINERARY.Text.Trim
                GRIDTRANS.Item(GCARNOTE.Index, TEMPCARROW).Value = TXTCARNOTE.Text.Trim
                GRIDTRANS.Item(GCARAMT.Index, TEMPCARROW).Value = Val(TXTCARAMT.Text.Trim)


                GRIDCARDOUBLECLICK = False

            End If
            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

            TXTCARSRNO.Clear()
            TXTCONTACTPERSON.Clear()
            TXTCONTACTNO.Clear()
            CMBCARTYPE.Text = ""
            CMBCARNAME.Text = ""
            TXTCARADULTS.Text = 0.0
            TXTCARCHILDS.Text = 0.0
            PICKUPDATE.Value = Mydate
            TXTPICKFROM.Clear()
            TXTPICKTIME.Clear()
            TXTPICKDTLS.Clear()
            DROPDDATE.Value = Mydate
            TXTDROPAT.Clear()
            TXTDROPTIME.Clear()
            TXTDROPDTLS.Clear()
            TXTCARDAYS.Text = 1
            TXTROUTE.Clear()
            TXTCARITINERARY.Clear()
            TXTCARNOTE.Clear()
            TXTCARAMT.Clear()
            CALDAYS()
            TXTCARSRNO.Focus()


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCARAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCARAMT.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 And TXTPICKFROM.Text.Trim <> "" And TXTDROPAT.Text.Trim <> "" Then
                FILLGRIDCAR()
                total()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTRANS.CellDoubleClick
        Try
            If GRIDTRANS.Rows(e.RowIndex).Cells(GCARSRNO.Index).Value <> Nothing Then
                GRIDCARDOUBLECLICK = True
                TEMPCARROW = e.RowIndex
                TXTCARSRNO.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARSRNO.Index).Value
                TXTCONTACTPERSON.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCONTACTNAME.Index).Value
                TXTCONTACTNO.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCONTACTNO.Index).Value
                CMBCARTYPE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARTYPE.Index).Value
                CMBCARNAME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNAME.Index).Value
                TXTCARADULTS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARADULTS.Index).Value
                TXTCARCHILDS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARCHILDS.Index).Value
                PICKUPDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUP.Index).Value
                TXTPICKFROM.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPFROM.Index).Value
                TXTPICKTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPTIME.Index).Value
                TXTPICKDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARPICKUPDTLS.Index).Value
                DROPDDATE.Value = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROP.Index).Value
                TXTDROPAT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTO.Index).Value
                TXTDROPTIME.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPTIME.Index).Value
                TXTDROPDTLS.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARDROPDTLS.Index).Value
                TXTROUTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARROUTE.Index).Value
                TXTCARITINERARY.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARITINERARY.Index).Value
                TXTCARNOTE.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARNOTE.Index).Value
                TXTCARAMT.Text = GRIDTRANS.Rows(e.RowIndex).Cells(GCARAMT.Index).Value
                TXTCARSRNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTRANS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCARDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTRANS.Rows.RemoveAt(GRIDTRANS.CurrentRow.Index)
                total()
                getsrno(GRIDTRANS)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCARNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCARNAME.Validating
        Try
            If CMBCARNAME.Text.Trim <> "" Then VEHICLEVALIDATE(CMBCARNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPDDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DROPDDATE.Validated
        Try
            'CALDAYS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DROPDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DROPDDATE.Validating
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(DROPDDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Function CALDAYS() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBHOTELNAME.Text.Trim <> "" And CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 And Val(TXTBADULTS.Text) > 0 And CMBPACKAGE.Text.Trim <> "" Then
                If CHECKINDATE.Value.Date < PACKAGEFROM.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Check In Date")
                End If
                If CHECKOUTDATE.Value.Date > PACKAGETO.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Check Out Date")
                End If

                If CHECKOUTDATE.Value.Date > CHECKINDATE.Value.Date Then
                    TXTBTOTALNIGHTS.Text = CHECKOUTDATE.Value.Date.Subtract(CHECKINDATE.Value.Date).Days
                ElseIf CHECKOUTDATE.Value.Date = CHECKINDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                    TXTBTOTALNIGHTS.Text = 1
                Else
                    Exit Function
                    EP.SetError(PACKAGETO, "Invalid Check In/Check Out Date")
                End If
            End If


            If TXTCONTACTPERSON.Text.Trim <> "" And CMBCARNAME.Text.Trim <> "" And Val(TXTCARADULTS.Text.Trim) > 0 And TXTPICKFROM.Text.Trim <> "" And TXTDROPAT.Text.Trim <> "" And Val(TXTCARAMT.Text.Trim) > 0 Then
                If PICKUPDATE.Value.Date < PACKAGEFROM.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Pickup Date")
                End If
                If DROPDDATE.Value.Date > PACKAGETO.Value.Date Then
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If

                If DROPDDATE.Value.Date >= PICKUPDATE.Value.Date Then
                    TXTCARDAYS.Text = DROPDDATE.Value.Date.Subtract(PICKUPDATE.Value.Date).Days
                ElseIf DROPDDATE.Value.Date = PICKUPDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                    TXTCARDAYS.Text = 1
                Else
                    'Exit Function
                    BLN = False
                    EP.SetError(PACKAGETO, "Invalid Drop Date")
                End If
            End If



            If PACKAGETO.Value.Date > PACKAGEFROM.Value.Date Then
                TXTPACKAGEDAYS.Text = PACKAGETO.Value.Date.Subtract(PACKAGEFROM.Value.Date).Days
            ElseIf PACKAGETO.Value.Date = PACKAGEFROM.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                TXTPACKAGEDAYS.Text = 1
            Else
                BLN = False
                EP.SetError(PACKAGETO, "Invalid Package Date")
            End If


            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PICKUPDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PICKUPDATE.Validated
        Try
            'CALDAYS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PICKUPDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PICKUPDATE.Validating
        'AS PER ASHOK BHAI REQ
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(PICKUPDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
        If edit = False Then DROPDDATE.Value = DateAdd(DateInterval.Day, 1, PICKUPDATE.Value)
    End Sub

    Private Sub TXTBADULTS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBADULTS.KeyPress
        numkeypress(e, TXTBADULTS, Me)
    End Sub

    Private Sub TXTBCHILDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBCHILDS.KeyPress
        numkeypress(e, TXTBCHILDS, Me)
    End Sub

    Private Sub TXTBINFANTS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBINFANTS.KeyPress
        numkeypress(e, TXTBINFANTS, Me)
    End Sub

    Private Sub TXTBEXTRAADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRAADULT.KeyPress
        numkeypress(e, TXTBEXTRAADULT, Me)
    End Sub

    Private Sub TXTBEXTRACHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRACHILD.KeyPress
        numkeypress(e, TXTBEXTRACHILD, Me)
    End Sub

    Private Sub TXTBEXTRAADULTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTBEXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTBEXTRACHILDRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTBEXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTBEXTRAADULT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRAADULT.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTBTOTALNIGHTS.Text = DateDiff(DateInterval.Day, CHECKINDATE.Value.Date, CHECKOUTDATE.Value.Date)

            'AIRLINE GRID
            TXTAIRAMT.Text = Format((Val(TXTBASIC.Text.Trim) + Val(TXTPSF.Text.Trim) + Val(TXTGRIDTAX.Text.Trim)), "0.00")

            'THIS IS DONE BY GULKIT
            'WHEN WE SELECT PERPAX QUOTE IN ITINERARY THEN CALC IS DIFFERENT, IT IS NOT MULTIPLIED BY ROOMS
            'WHEN WE SELECT LUMPSUM QUOTE IN ITINERARY THEN CALC IS DIFFERENT, IT IS NOT MULTIPLIED BY ROOMS NOR BY PAX
            If CMBQUOTECALC.Text = "Normal" Then
                If CMBPACKAGE.Text.Trim = "No" Then
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)) + (Val(TXTBEXTRAADULT.Text.Trim) * Val(TXTBEXTRAADULTRATE.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)) + (Val(TXTBEXTRACHILD.Text.Trim) * Val(TXTBEXTRACHILDRATE.Text.Trim) * Val(TXTBTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim)) + Val(TXTBEXTRAADULTRATE.Text.Trim) + Val(TXTBEXTRACHILDRATE.Text.Trim), "0.00")
                End If
            ElseIf CMBQUOTECALC.Text = "Per Person" Then
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTBADULTS.Text.Trim)) + (Val(TXTBEXTRAADULT.Text.Trim) * Val(TXTBEXTRAADULTRATE.Text.Trim)) + (Val(TXTBEXTRACHILD.Text.Trim) * Val(TXTBEXTRACHILDRATE.Text.Trim)) + (Val(TXTBCHILDS.Text.Trim) * Val(TXTCHILDRATE.Text.Trim)) + (Val(TXTBINFANTS.Text.Trim) * Val(TXTINFANTRATE.Text.Trim)), "0.00")
            ElseIf CMBQUOTECALC.Text = "Lump Sum" Then
                TXTTOTAL.Text = Format(Val(TXTRATE.Text.Trim), "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRAADULTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRAADULTRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRACHILD_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRACHILD.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEXTRACHILDRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBEXTRACHILDRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPACKAGE.Validated
        CALC()
    End Sub

    Private Sub TXTGRIDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPSF.Validated, TXTGRIDTAX.Validated, TXTBASIC.Validated
        CALC()
    End Sub

    Private Sub CHECKOUTDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECKOUTDATE.Validated
        Try
            If CHECKOUTDATE.Value.Date > CHECKINDATE.Value.Date Then
                TXTBTOTALNIGHTS.Text = CHECKOUTDATE.Value.Date.Subtract(CHECKINDATE.Value.Date).Days
                ' total()
                'PURCHASETOTAL()
            ElseIf CHECKOUTDATE.Value.Date = CHECKINDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                TXTBTOTALNIGHTS.Text = 1
                'total()
                'PURCHASETOTAL()
            Else
                MsgBox("Select Proper Dates", MsgBoxStyle.Critical)
                CHECKINDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                If GRIDPURCHASE.SelectedRows.Count <= 0 Then
                    MsgBox("Select Party To Create Debit Note", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'CHECK IN DN WHETHER DN IS RAISED OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DN_INITIALS AS BILLINITIALS", "", " DEBITNOTEMASTER ", " AND DN_BILLNO = 'HP-" & TEMPBOOKINGNO & "' AND DN_PACKAGESRNO = " & GRIDPURCHASE.CurrentRow.Index + 1 & " AND DN_CMPID = " & CmpId & " AND DN_LOCATIONID = " & Locationid & " AND DN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Debit Note Already Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note for " & GRIDPURCHASE.Rows(GRIDPURCHASE.CurrentRow.Index).Cells(GPURNAME.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    OBJdN.BILLNO = "HP-" & txtbookingno.Text.Trim
                    OBJdN.PACKAGESRNO = GRIDPURCHASE.CurrentRow.Index + 1
                    OBJdN.TEMPPURNAME = GRIDPURCHASE.Rows(GRIDPURCHASE.CurrentRow.Index).Cells(GPURNAME.Index).Value
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Validated
        Try
            If Val(TXTADULTS.Text.Trim) = 0 Then
                MsgBox("Enter No. of Adults")
                CMBGROUPDEPARTURE.Text = ""
                TXTADULTS.Focus()
            Else
                If CMBGROUPDEPARTURE.Text.Trim <> "" And edit = False Then
                    Dim TEMPGROUPNO As Integer

                    'GET DATA FROM GROUP DEPARTURE
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" GROUPDEPARTURE.GROUPDEP_NO AS GROUPNO,  GROUPDEPARTURE.GROUPDEP_FROM AS FROMDATE, GROUPDEPARTURE.GROUPDEP_TO AS TODATE, GROUPDEPARTURE.GROUPDEP_TOTALPACKAGEAMT AS TOTALPACKAGEAMT,  ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_INCLUSIONS, '') AS INCLUSIONS, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKIN, '') AS CHECKIN, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_CHECKOUT, '') AS CHECKOUT, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(PLANMASTER.PLAN_NAME, '') AS PLANNAME, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NOOFROOMS, 0) AS NOOFROOMS, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_PACKAGE, '') AS PACKAGE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_RATE, 0) AS RATE, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_AMOUNT, 0) AS AMOUNT, ISNULL(GROUPDEPARTURE_DESC.GROUPDEP_NIGHTS, 0) AS NIGHTS  ", "", " PLANMASTER INNER JOIN GROUPDEPARTURE INNER JOIN GROUPDEPARTURE_DESC ON GROUPDEPARTURE.GROUPDEP_NO = GROUPDEPARTURE_DESC.GROUPDEP_NO AND GROUPDEPARTURE.GROUPDEP_YEARID = GROUPDEPARTURE_DESC.GROUPDEP_YEARID INNER JOIN HOTELMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_HOTELID = HOTELMASTER.HOTEL_ID INNER JOIN ROOMTYPEMASTER ON GROUPDEPARTURE_DESC.GROUPDEP_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID ON PLANMASTER.PLAN_ID = GROUPDEPARTURE_DESC.GROUPDEP_PLANID  ", "  AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        TXTTOURNAME.Text = CMBGROUPDEPARTURE.Text.Trim
                        GRIDBOOKINGS.RowCount = 0
                        TEMPGROUPNO = DT.Rows(0).Item("GROUPNO")
                        PACKAGEFROM.Value = DT.Rows(0).Item("FROMDATE")
                        PACKAGETO.Value = DT.Rows(0).Item("TODATE")
                        For Each ROW As DataRow In DT.Rows
                            If ClientName = "RAMKRISHNA" Then
                                GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(TXTADULTS.Text.Trim) * Val(ROW("RATE")), "0.00"), 0, 0, "", 0, Format(Val(ROW("NOOFROOMS")) * Val(ROW("RATE")) * Val(TXTADULTS.Text.Trim), "0.00"), Val(ROW("NIGHTS")))
                                'GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Format(Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
                                'GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gnoofRooms.Index).Value) * Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
                            Else
                                GRIDBOOKINGS.Rows.Add(Val(ROW("SRNO")), ROW("HOTELNAME"), "", "", ROW("INCLUSIONS"), Format(Convert.ToDateTime(ROW("CHECKIN").DATE), "dd/MM/yyyy"), Format(Convert.ToDateTime(ROW("CHECKOUT").DATE), "dd/MM/yyyy"), ROW("ROOMTYPE"), ROW("PLANNAME"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), 0, 0, 0, 0, Val(TXTTOTALPAX.Text.Trim), Val(ROW("NOOFROOMS")), ROW("PACKAGE"), Format(Val(ROW("RATE")), "0.00"), 0, 0, "", 0, Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("NIGHTS")))
                            End If
                        Next

                        If ClientName = "RAMKRISHNA" Then
                            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(grate.Index).Value = Format(Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
                            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gamt.Index).Value = Format(Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(gnoofRooms.Index).Value) * Val(DT.Rows(0).Item("TOTALPACKAGEAMT")) * Val(TXTADULTS.Text.Trim), "0.00")
                        End If

                    End If


                    DT = OBJCMN.search(" ISNULL(GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEP_SRNO, 0) AS TOURSRNO, GROUPDEP_TOURDATE AS TOURDATE, ISNULL(GROUPDEP_TOURDETAILS, '') AS TOURDETAILS", "", " GROUPDEPARTURE_TOURDETAILS ", " AND GROUPDEPARTURE_TOURDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TOURDETAILS.GROUPDEP_SRNO")
                    If DT.Rows.Count > 0 Then
                        GRIDTOUR.RowCount = 0
                        For Each DTR As DataRow In DT.Rows
                            GRIDTOUR.Rows.Add(DTR("TOURSRNO"), Format(Convert.ToDateTime(DTR("TOURDATE").DATE), "dd/MM/yyyy"), DTR("TOURDETAILS"))
                        Next

                        '    For Each DTR As DataRow In DT.Rows
                        '        GRIDTOUR.Rows.Add(DTR("TOURSRNO"), DTR("TOURHEADER"), DTR("TOURDETAILS"))
                        '    Next
                    End If


                    'TRANSPORT GRID
                    DT = OBJCMN.search(" ISNULL(VEHICLETYPE_NAME,'') AS VEHICLETYPE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO, 0) AS SRNO, ISNULL(VEHICLEMASTER.VEHICLE_NAME, '') AS VEHICLE, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPON AS PICKUPON,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPFROM, '') AS PICKUPFROM ,ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPTIME, '') AS PICKUPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_PICKUPDTLS, '') AS PICKUPDTLS, GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPON AS DROPON, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPAT, '') AS DROPAT, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPTIME, '') AS DROPTIME, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_DROPDTLS, '') AS DROPDTLS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_CARDAYS, 0) AS CARDAYS, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NOTE, '') AS NOTE, ISNULL(GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_AMT, 0) AS AMOUNT ", "", " GROUPDEPARTURE_TRANSDETAILS INNER JOIN VEHICLEMASTER ON GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_VEHICLEID = VEHICLEMASTER.VEHICLE_ID LEFT OUTER JOIN VEHICLETYPEMASTER ON VEHICLE_TYPEID = VEHICLETYPE_ID ", " AND GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_NO = " & TEMPGROUPNO & " AND GROUPDEP_YEARID = " & YearId & " ORDER BY GROUPDEPARTURE_TRANSDETAILS.GROUPDEP_SRNO")
                    If DT.Rows.Count > 0 Then
                        GRIDTRANS.RowCount = 0
                        For Each DTR As DataRow In DT.Rows
                            GRIDTRANS.Rows.Add(DTR("SRNO"), "", "", DTR("VEHICLETYPE"), DTR("VEHICLE"), Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTTOTALPAX.Text.Trim), Format(Convert.ToDateTime(DTR("PICKUPON").DATE), "dd/MM/yyyy"), DTR("PICKUPFROM"), DTR("PICKUPTIME"), DTR("PICKUPDTLS"), Format(Convert.ToDateTime(DTR("DROPON").DATE), "dd/MM/yyyy"), DTR("DROPAT"), DTR("DROPTIME"), DTR("DROPDTLS"), Val(DTR("CARDAYS")), "", "", DTR("NOTE"), Format(Val(DTR("AMOUNT")), "0.00"))
                        Next
                    End If
                End If

                TBDETAILS.SelectedIndex = 1
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSEAIRLINE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSEAIRLINE.Click
        Try
            If GRIDSECTOR.Rows.Count > 0 Then
                TXTFLTNO.Text = GRIDSECTOR.Rows(0).Cells(GSECFLTNO.Index).Value
            End If
            SECTORGROUP.Visible = False
            TXTFLTNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbookingno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookingno.Validating
        Try
            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If

                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If

            ElseIf (ClientName = "CLASSIC" And UserName = "Admin" And edit = False) Or ((ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE") And edit = False) Then

                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_no AS BOOKINGNO ", "", " HOLIDAYPACKAGEMASTER", " AND HOLIDAYPACKAGEMASTER.BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = " & CmpId & " AND  HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If
                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If

            Else

                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim dt As DataTable
                    Dim OBJSEARCH As New ClsCommon
                    dt = OBJSEARCH.search(" BOOKING_NO", "", " HOLIDAYPACKAGEMASTER", " AND HOLIDAYPACKAGEMASTER.BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = " & CmpId & " AND  HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If

                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            'If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT EXPENSES'", "INDIRECT EXPENSES")
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT EXPENSES'", "INDIRECT EXPENSES")
            Else
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPUROTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPUROTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPUROTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPUROTHERCHGS.Validating
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT INCOME'", "INDIRECT INCOME")
            Else
                If CMBPUROTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then If Val(DT.Rows(0).Item("TAX")) = 0 Then txttax.ReadOnly = False
            Else
                txttax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.Validated
        total()
    End Sub

    Private Sub TXTSALEMOBILE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSALEMOBILE.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ACC_cmpname ", "", " LEDGERS", " AND ACC_mobile LIKE '%" & TXTSALEMOBILE.Text.Trim & "%' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                CMBNAME.Text = DT.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        total()
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If edit = False Then Exit Sub
        SMSCODE()
    End Sub

    Private Sub TXTROE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBCURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURCODE.Enter
        Try
            If CMBCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBCURCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURCODE.Validating
        Try
            If CMBCURCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBCURCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDETAILS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTDETAILS.Validated
        Try
            If TXTHEADER.Text.Trim <> "" And TXTDETAILS.Text.Trim <> "" Then fillgridTOUR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        total()
    End Sub

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNITEMDESC As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_ITEMDESC, '') AS HSNITEMDESC ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNITEMDESC"
                CMBHSNITEMDESC.DataSource = dt
                CMBHSNITEMDESC.DisplayMember = "HSNITEMDESC"
            End If
            CMBHSNITEMDESC.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Enter
        Try
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSERVTAX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSERVTAX.CheckedChanged
        Try
            PURCHASECALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKPURMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURMANUAL.CheckedChanged
        Try
            If CHKPURMANUAL.Checked = True Then
                TXTPURCGSTAMT.ReadOnly = False
                TXTPURCGSTAMT.TabStop = True
                TXTPURCGSTAMT.BackColor = Color.LemonChiffon
                TXTPURSGSTAMT.ReadOnly = False
                TXTPURSGSTAMT.TabStop = True
                TXTPURSGSTAMT.BackColor = Color.LemonChiffon
                TXTPURIGSTAMT.ReadOnly = False
                TXTPURIGSTAMT.TabStop = True
                TXTPURIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTPURCGSTAMT.ReadOnly = True
                TXTPURCGSTAMT.TabStop = False
                TXTPURCGSTAMT.BackColor = Color.Linen
                TXTPURSGSTAMT.ReadOnly = True
                TXTPURSGSTAMT.TabStop = False
                TXTPURSGSTAMT.BackColor = Color.Linen
                TXTPURIGSTAMT.ReadOnly = True
                TXTPURIGSTAMT.TabStop = False
                TXTPURIGSTAMT.BackColor = Color.Linen
                PURCHASECALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTPURCGSTAMT.KeyPress, TXTPURSGSTAMT.KeyPress, TXTPURIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        CALC()
        total()
    End Sub

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASECALC()
    End Sub

    Private Sub BOOKINGDATE_Validating(sender As Object, e As CancelEventArgs) Handles BOOKINGDATE.Validating
        Try
            If BOOKINGDATE.Text <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BOOKINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKINGDATE_Validated(sender As Object, e As EventArgs) Handles BOOKINGDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBINCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTINCLUSION.Clear()
            Dim DT As DataTable = OBJCMN.search(" INCLUSION_REMARKS AS INCLUSION", "", " INCLUSIONMASTER", " AND INCLUSION_NAME ='" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTINCLUSION.Text = DT.Rows(0).Item("INCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBINCLUSION.Validating
        Try
            If CMBINCLUSION.Text.Trim <> "" Then INCLUSIONVALIDATE(CMBINCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBINCLUSION.Enter
        Try
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Enter
        Try
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTEXCLUSION.Clear()
            Dim DT As DataTable = OBJCMN.search(" EXCLUSION_REMARKS AS EXCLUSION", "", " EXCLUSIONMASTER", " AND EXCLUSION_NAME ='" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTEXCLUSION.Text = DT.Rows(0).Item("EXCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBEXCLUSION.Validating
        Try
            If CMBEXCLUSION.Text.Trim <> "" Then EXCLUSIONVALIDATE(CMBEXCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class