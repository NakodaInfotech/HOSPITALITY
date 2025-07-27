
Imports BL

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO

Public Class TourFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Dim TEMPLEADER As String
    Dim TEMPGIFT As String
    Dim TEMPCOUNTRY As String
    Dim TEMPCITY As String
    Dim TEMPMALE, TEMPFEMALE, TEMPADULT, TEMPCHILD, TEMPINFANT, TEMPTOTAL As Integer

    Private Sub CMBJOBBER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOUR.Enter
        Try
            If CMBTOUR.Text.Trim = "" Then FILLTOURNAME(CMBTOUR, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListFieldNames()
        'Dim pdfTemplate As String = "D:\HOSPITALITY\Documentation\IRAQ FORM.pdf"
        Dim pdfTemplate As String = "C:\IRAQ FORM.pdf"

        ' create a new PDF reader based on the PDF template document
        Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)

        ' create and populate a string builder with each of the 
        ' field names available in the subject PDF
        Dim sb As New StringBuilder()

        Dim de As New DictionaryEntry

        'Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(NEWFILE, FileMode.Create))
        Dim pdfFormFields As AcroFields = pdfReader.AcroFields



        Dim fields As IDictionary(Of String, iTextSharp.text.pdf.AcroFields.Item) = pdfReader.AcroFields.Fields
        For Each key As String In fields.Keys
            sb.Append(key.ToString() + Environment.NewLine)
            sb.Append(pdfFormFields.GetField(Replace(key.ToString(), "#", "")))
        Next

        ' Write the string builder's content to the form's textbox
        'TXTTEST.Text = sb.ToString()
        'TXTTEST.SelectionStart = 0
    End Sub

    Private Sub FillForm()
        Try
            Dim pdfTemplate As String = "c:/IRAQ FORM.pdf"
            Dim newFile As String = "c:/FINAL IRAQ FORM.pdf"

            Dim pdfReader As New PdfReader(pdfTemplate)
            'MsgBox(pdfReader.AcroFields.Fields("form1[0].#subform[1].field[49]"))
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream( _
                newFile, FileMode.Create))

            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields

            ' set form pdfFormFields

            ' The first worksheet and W-4 form
            pdfFormFields.SetField("form1[0].subform[0].field[11]", "TESTING")
            pdfFormFields.SetField("form1[0].subform[0].field[12]", "TESTING12")
            pdfFormFields.SetField("form1[0].subform[0].field[13]", "TESTING13")
            pdfFormFields.SetField("form1[0].subform[0].field[14]", "TESTING14")


            'pdfFormFields.SetField("PassportApplicationForm[0].MainForm[0].dd_ApplyingFor[0]", "TESTING")
            'pdfFormFields.SetField("PassportApplicationForm[0].MainForm[0].tf_place[0]", "MUMBAI")

            ' report by reading values from completed PDF
            ' Dim sTmp As String = "Completed for " + _
            'For I As Integer = 0 To 47
            '    MsgBox(pdfFormFields.GetField("form1[0].subform[0].field[" & I & "]"))
            'Next
            ' flatten the form to remove editting options, set it to false
            ' to leave the form open to subsequent manual edits
            pdfStamper.FormFlattening = False

            ' close the pdf
            pdfStamper.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LotFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATAINEXCEL()
        Try
            Dim pdfTemplate As String = "C:\IRAQ FORM.Pdf"
            Dim readerPDF As New PdfReader(pdfTemplate)
            Dim pdfFormFields As AcroFields = readerPDF.AcroFields

            '~~> Define your Excel Objects
            Dim xlApp As New Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim LastRow As Integer, i As Integer

            '~~> Show/Hide Excel
            xlApp.Visible = True

            '~~> Opens an exisiting Workbook
            xlWorkBook = xlApp.Workbooks.Open("C:\TEST.xlsx")

            '~~> Set the relevant sheet that we want to work with
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            '~~> Get the last row in Col A which has Form Fields
            LastRow = xlWorkSheet.Range("B" & xlApp.Rows.Count).End(Excel.XlDirection.xlUp).Row

            '~~> Loop through Col A and use the Form Fields to extract text
            For i = 1 To LastRow
                xlWorkSheet.Range("C" & i).Value = "Value Of " & pdfFormFields.GetField(xlWorkSheet.Range("B" & i).Value)
                xlWorkSheet.Range("D" & i).Value = "Value Of " & pdfFormFields.GetField(xlWorkSheet.Range("A" & i).Value)
            Next

            '~~> Close the Excel file without saving
            xlWorkBook.Close(True)
            '~~> Quit the Excel Application
            xlApp.Quit()

            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub LotFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()

            ''TESTING FOR FILING DATA INTO PDF FORM
            ''GETDATAINEXCEL()
            'ListFieldNames()
            'FillForm()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            If RDBIRAQAIR.Checked = True Then
                '    Dim OBJIRAQ As New IraqiAirways2
                '    OBJIRAQ.MdiParent = MDIMain
                '    If CMBGUEST.Text.Trim <> "" Then
                '        OBJIRAQ.GUESTNAME = CMBGUEST.Text.Trim
                '    End If
                '    If CMBTOUR.Text.Trim <> "" Then
                '        OBJIRAQ.TOURNAME = CMBTOUR.Text.Trim
                '    End If
                '    OBJIRAQ.Show()
                'ElseIf RDBIRAQMU.Checked = True Then
                '    Dim OBJIRAQ As New IraqMuwafekaList7
                '    OBJIRAQ.MdiParent = MDIMain
                '    If CMBGUEST.Text.Trim <> "" Then
                '        OBJIRAQ.GUESTNAME = CMBGUEST.Text.Trim
                '    End If
                '    If CMBTOUR.Text.Trim <> "" Then
                '        OBJIRAQ.TOURNAME = CMBTOUR.Text.Trim
                '    End If
                '    OBJIRAQ.Show()

                'ElseIf RDBGIFTSTOCK.Checked = True Then
                '    Dim OBJGIFT As New GiftStock
                '    OBJGIFT.MdiParent = MDIMain
                '    OBJGIFT.Show()


                'ElseIf RDBKUWAIT.Checked = True Then
                '    Dim OBJIRAQ As New KuwaitAirways14
                '    OBJIRAQ.MdiParent = MDIMain
                '    If CMBGUEST.Text.Trim <> "" Then
                '        OBJIRAQ.GUESTNAME = CMBGUEST.Text.Trim
                '    End If
                '    If CMBTOUR.Text.Trim <> "" Then
                '        OBJIRAQ.TOURNAME = CMBTOUR.Text.Trim
                '    End If
                '    OBJIRAQ.Show()
            ElseIf RDFOREX.Checked = True Then
                If CMBTOUR.Text.Trim = "" Then
                    MsgBox("Select Tour", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If CMBCURRENCY.Text.Trim = "" Then
                    MsgBox("Select Currency", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOURNAME,PASSNAME, HOF,DOB, SUM(LAWAZIM) AS LAWAZIM, SUM(VISA) AS VISA, SUM(GIFT ) AS GIFT, SUM(TRANSPORT) AS TRANSPORT, SUM(MEALS )AS MEALS, SUM(COUNTRYTAX) AS COUNTRYTAX, SUM(MISCEXP) AS MISCEXP, SUM(AIRLINE) AS AIRLINE, SUM(CORDINATOR) AS CORDINATOR, SUM(ADDSERVICE) AS ADDSERVICE ", "", " FOREXVIEW ", " AND TOURNAME = '" & CMBTOUR.Text.Trim & "' AND CURCODE = '" & CMBCURRENCY.Text.Trim & "' AND YEARID = " & YearId & " GROUP BY TOURNAME,PASSNAME,DOB, HOF ORDER BY HOF ")
                Dim objrep As New clsReportDesigner("FOREX REQUIREMENT", System.AppDomain.CurrentDomain.BaseDirectory & "FOREX REQUIREMENT.xlsx", 2)
                objrep.FOREX_REQUIREMENT_EXCEL(DT, CmpId, YearId, CMBCURRENCY.Text.Trim)

            ElseIf RBCSV.Checked = True Then
                If CMBTOUR.Text.Trim = "" Then
                    MsgBox("Select Tour", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" CASE WHEN REG_PERSONTYPE = 'ADULT' THEN 'AD' ELSE (CASE WHEN REG_PERSONTYPE = 'CHILD' THEN 'CH' ELSE 'IN' END) END AS PERSONTYPE, ISNULL(PREFIXMASTER.PREFIX_NAME, '') AS PREFIX, GUESTMASTER.GUEST_GIVENNAME AS FIRSTNAME, GUESTMASTER.GUEST_SURNAME AS LASTNAME,ISNULL(NATIONALITYMASTER.NAT_name, '') AS NATIONALITY, GUESTMASTER.GUEST_DOB AS DOB, GUESTMASTER.GUEST_PASSPORTNO AS PASSPORTNO, GUESTMASTER.GUEST_EXPIRYDATE AS EXPIRYDATE  ", "", " REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN NATIONALITYMASTER ON GUESTMASTER.GUEST_NATIONALITYID = NATIONALITYMASTER.NAT_id LEFT OUTER JOIN PREFIXMASTER ON GUESTMASTER.GUEST_PREFIXID = PREFIXMASTER.PREFIX_ID  ", " AND TOUR_NAME = '" & CMBTOUR.Text.Trim & "' AND REG_YEARID = " & YearId & " ORDER BY REG_NO ")
                Dim objrep As New clsReportDesigner("NAME LIST", System.AppDomain.CurrentDomain.BaseDirectory & "NAME LIST.xlsx", 2)
                objrep.CSVREPORT_EXCEL(DT, CmpId, YearId)
            Else
                Dim OBJTOUR As New TourDesign
                OBJTOUR.MdiParent = MDIMain
                If RDBGIFTPURCHASE.Checked = True Then
                    OBJTOUR.strsearch = "{GIFTPURCHASEMASTER.BILL_YEARID}=" & YearId & ""

                ElseIf RDBCASH.Checked = True Then
                    OBJTOUR.strsearch = "{CASHCHQVIEW.YEARID}=" & YearId & ""

                Else
                    OBJTOUR.strsearch = "{TOURMASTER.TOUR_YEARID}=" & YearId & ""

                End If
                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJTOUR.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                    OBJTOUR.strsearch = OBJTOUR.strsearch & " and {@DATE} in date " & fromD & " to date " & toD & ""
                Else
                    OBJTOUR.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If

                If RDBPASSLIST.Checked = True Then
                    OBJTOUR.FRMSTRING = "PASSLIST"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBITS.Checked = True Then
                    OBJTOUR.FRMSTRING = "ITSLIST"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBUPLOAD.Checked = True Then
                    OBJTOUR.FRMSTRING = "VISAFORM"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                    'GET THE SRNO AND PASS IT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("GUEST_NAME AS GUESTNAME", "", " REGISTRATIONMASTER INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ", " AND REGISTRATIONMASTER.REG_YEARID = " & YearId & " AND TOURMASTER.TOUR_NAME = '" & CMBTOUR.Text.Trim & "' ORDER BY REGISTRATIONMASTER.REG_no")
                    If DT.Rows.Count > 0 Then
                        For Each DTROW As DataRow In DT.Rows
                            If DTROW("GUESTNAME") = CMBGUEST.Text.Trim Then OBJTOUR.SRNOFORVISAFORM = Val(DT.Rows.IndexOf(DTROW) + 1)
                        Next
                    End If

                ElseIf RDBVISA2.Checked = True Then
                    OBJTOUR.FRMSTRING = "VISAFORM2"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBGIFTPENDING.Checked = True Then
                    OBJTOUR.FRMSTRING = "GIFTPENDING"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable = objclscommon.search(" ISNULL(SERVICE_VIEW.NAME, '') AS gift", "", "  TOURMASTER INNER JOIN TOUR_SERVICES ON TOURMASTER.TOUR_NO = TOUR_SERVICES.TOUR_NO AND TOURMASTER.TOUR_YEARID = TOUR_SERVICES.TOUR_yearid LEFT OUTER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID AND TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID", " and SERVICE_VIEW.TYPE='gift' and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each dtrow As DataRow In dt.Rows
                            If TEMPGIFT = Nothing Then
                                TEMPGIFT = dtrow(0)
                            Else
                                TEMPGIFT = TEMPGIFT + "/" + dtrow(0)
                            End If
                        Next
                    End If

                    OBJTOUR.GIFT = TEMPGIFT

                ElseIf RDBCASH.Checked = True Then
                    OBJTOUR.FRMSTRING = "CASH"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {CASHCHQVIEW.TOURNAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {CASHCHQVIEW.PASSNAME}='" & CMBGUEST.Text.Trim & "'"
                    If CMBCURRENCY.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {CASHCHQVIEW.CURCODE}='" & CMBCURRENCY.Text.Trim & "'"



                ElseIf RDBPASSPHOTO.Checked = True Then
                    OBJTOUR.FRMSTRING = "PASSPORTPHOTO"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBPHOTO.Checked = True Then
                    OBJTOUR.FRMSTRING = "PHOTOCOPY"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBSAFAI.Checked = True Then
                    OBJTOUR.FRMSTRING = "SAFAI"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBITSCOPY.Checked = True Then
                    OBJTOUR.FRMSTRING = "ITSCOPY"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBPASSPORTLABLE.Checked = True Then
                    OBJTOUR.FRMSTRING = "PASSLABLE"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RBIDCARD.Checked = True Then
                    OBJTOUR.FRMSTRING = "IDCARD"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RBBAGTAG.Checked = True Then
                    OBJTOUR.FRMSTRING = "BAGTAG"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBEMBARKATION.Checked = True Then
                    OBJTOUR.FRMSTRING = "EMBARK"

                    If CMBTOUR.Text.Trim = "" Then
                        MsgBox("Select Tour", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"


                ElseIf RDBGIFTREG.Checked = True Then
                    OBJTOUR.FRMSTRING = "GIFTSALE"


                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"
                ElseIf RDBGIFTPURCHASE.Checked = True Then
                    OBJTOUR.FRMSTRING = "GIFTPURCHASE"

                ElseIf RDBBMM.Checked = True Then
                    OBJTOUR.FRMSTRING = "BMM"

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If CMBTOUR.Text.Trim <> "" Then
                        dt = objclscommon.search(" ISNULL(GUESTMASTER.GUEST_NAME,'') AS LEADER", "", "  TOUR_LEADER LEFT OUTER JOIN GUESTMASTER ON TOUR_LEADER.TOUR_LEADERID = GUESTMASTER.GUEST_ID AND TOUR_LEADER.TOUR_yearid = GUESTMASTER.GUEST_YEARID RIGHT OUTER JOIN TOURMASTER ON TOUR_LEADER.TOUR_yearid = TOURMASTER.TOUR_YEARID AND TOUR_LEADER.TOUR_NO = TOURMASTER.TOUR_NO", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            For Each dtrow As DataRow In dt.Rows
                                If TEMPLEADER = Nothing Then
                                    TEMPLEADER = dtrow(0)
                                Else
                                    TEMPLEADER = TEMPLEADER + "/" + dtrow(0)
                                End If
                            Next
                        End If

                        dt = objclscommon.search(" ISNULL(COUNTRYMASTER.country_name,'') AS COUNTRY", "", "  COUNTRYMASTER RIGHT OUTER JOIN TOUR_COUNTRY ON COUNTRYMASTER.country_yearid = TOUR_COUNTRY.TOUR_yearid AND COUNTRYMASTER.country_id = TOUR_COUNTRY.TOUR_COUNTRYID RIGHT OUTER JOIN TOURMASTER ON TOUR_COUNTRY.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_COUNTRY.TOUR_yearid = TOURMASTER.TOUR_YEARID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            For Each dtrow As DataRow In dt.Rows
                                If TEMPCOUNTRY = Nothing Then
                                    TEMPCOUNTRY = dtrow(0)
                                Else
                                    TEMPCOUNTRY = TEMPCOUNTRY + "/" + dtrow(0)
                                End If
                            Next
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS CHILD ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'CHILD') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPCHILD = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS INFANT ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'INFANT') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPINFANT = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS ADULT ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'ADULT') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPADULT = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS TOTALPAX ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPTOTAL = Val(dt.Rows(0).Item(0))
                        End If

                    End If

                    OBJTOUR.CHILD = TEMPCHILD
                    OBJTOUR.INFANT = TEMPINFANT
                    OBJTOUR.ADULT = TEMPADULT
                    OBJTOUR.LEADER = TEMPLEADER
                    OBJTOUR.TOTALPAX = TEMPTOTAL
                    OBJTOUR.COUNTRY = TEMPCOUNTRY

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBIRAQ.Checked = True Then
                    OBJTOUR.FRMSTRING = "IRAQ"

                    If CMBTOUR.Text = "" Then
                        MsgBox("Please Select Tour!")
                        Exit Sub
                    End If

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If CMBTOUR.Text.Trim <> "" Then
                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS CHILD ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'CHILD') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPCHILD = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS INFANT ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'INFANT') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPINFANT = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS ADULT ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (REGISTRATIONMASTER.REG_PERSONTYPE = 'ADULT') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPADULT = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS MALE ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (GUESTMASTER.GUEST_GENDER = 'Male') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPMALE = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS FEMALE ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND (GUESTMASTER.GUEST_GENDER = 'Female') and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPFEMALE = Val(dt.Rows(0).Item(0))
                        End If

                        dt = objclscommon.search(" COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS TOTALPAX ", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            TEMPTOTAL = Val(dt.Rows(0).Item(0))
                        End If
                    End If

                    OBJTOUR.CHILD = TEMPCHILD
                    OBJTOUR.INFANT = TEMPINFANT
                    OBJTOUR.ADULT = TEMPADULT
                    OBJTOUR.MALE = TEMPMALE
                    OBJTOUR.FEMALE = TEMPFEMALE
                    OBJTOUR.TOTALPAX = TEMPTOTAL

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"
                ElseIf RDBPENDOCS.Checked = True Then
                    OBJTOUR.FRMSTRING = "PENDING"
                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {GUESTMASTER.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"

                ElseIf RDBDECLARE.Checked = True Then
                    OBJTOUR.FRMSTRING = "DECLARE"
                    If CMBTOUR.Text = "" Or CMBGUEST.Text = "" Then
                        MsgBox("Please Select Tour Or Guest Name !")
                        Exit Sub
                    End If

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable

                    dt = objclscommon.search(" ISNULL(CITYMASTER.CITY_name,'') AS CITY", "", "  CITYMASTER RIGHT OUTER JOIN TOUR_COUNTRY ON CITYMASTER.CITY_yearid = TOUR_COUNTRY.TOUR_yearid AND CITYMASTER.CITY_id = TOUR_COUNTRY.TOUR_CITYID RIGHT OUTER JOIN TOURMASTER ON TOUR_COUNTRY.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_COUNTRY.TOUR_yearid = TOURMASTER.TOUR_YEARID  ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each dtrow As DataRow In dt.Rows
                            If TEMPCITY = Nothing Then
                                TEMPCITY = dtrow(0)
                            Else
                                TEMPCITY = TEMPCITY + "/" + dtrow(0)
                            End If
                        Next
                    End If

                    OBJTOUR.CITY = TEMPCITY

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                    If CMBGUEST.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {HOF.GUEST_NAME}='" & CMBGUEST.Text.Trim & "'"
                ElseIf RDBITENARY.Checked = True Then
                    OBJTOUR.FRMSTRING = "ITENARY"
                    If CMBTOUR.Text = "" Then
                        MsgBox("Please Select Tour!")
                        Exit Sub
                    End If
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If CMBTOUR.Text.Trim <> "" Then
                        dt = objclscommon.search(" ISNULL(GUESTMASTER.GUEST_NAME,'') AS LEADER", "", "  TOUR_LEADER LEFT OUTER JOIN GUESTMASTER ON TOUR_LEADER.TOUR_LEADERID = GUESTMASTER.GUEST_ID AND TOUR_LEADER.TOUR_yearid = GUESTMASTER.GUEST_YEARID RIGHT OUTER JOIN TOURMASTER ON TOUR_LEADER.TOUR_yearid = TOURMASTER.TOUR_YEARID AND TOUR_LEADER.TOUR_NO = TOURMASTER.TOUR_NO", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            For Each dtrow As DataRow In dt.Rows
                                If TEMPLEADER = Nothing Then
                                    TEMPLEADER = dtrow(0)
                                Else
                                    TEMPLEADER = TEMPLEADER + "/" + dtrow(0)
                                End If
                            Next
                        End If
                    End If
                    OBJTOUR.LEADER = TEMPLEADER

                    If CMBTOUR.Text <> "" Then OBJTOUR.strsearch = OBJTOUR.strsearch & " and {TOURMASTER.TOUR_NAME}='" & CMBTOUR.Text.Trim & "'"
                End If

                OBJTOUR.Show()
            End If
            TEMPLEADER = ""
            TEMPCOUNTRY = ""
            TEMPCITY = ""
            TEMPGIFT = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            If CMBTOUR.Text.Trim = "" Then FILLTOURNAME(CMBTOUR, edit, "")

            If CMBTOUR.Text.Trim <> "" Then
                CMBCURRENCY.DataSource = Nothing
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If CMBCURRENCY.Text.Trim = "" Then
                    dt = objclscommon.search(" ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY ", "", "  TOUR_CURRENCY INNER JOIN TOURMASTER ON TOUR_CURRENCY.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_CURRENCY.TOUR_yearid = TOURMASTER.TOUR_YEARID INNER JOIN CURRENCYMASTER ON TOUR_CURRENCY.TOUR_CURRENCYID = CURRENCYMASTER.cur_id  ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "CURRENCY"
                        CMBCURRENCY.DataSource = dt
                        CMBCURRENCY.DisplayMember = "CURRENCY"
                    End If
                    CMBCURRENCY.Text = ""
                End If
            End If

            If RDBDECLARE.Checked = True Then
                CMBGUEST.Text = ""
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If CMBGUEST.Text.Trim = "" Then
                    dt = objclscommon.search(" DISTINCT GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' and reg_HOFCHK=1 AND GUEST_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "GUEST_name"
                        CMBGUEST.DataSource = dt
                        CMBGUEST.DisplayMember = "GUEST_name"
                    End If
                    CMBGUEST.Text = ""
                End If
            Else
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If CMBGUEST.Text.Trim = "" Then
                    dt = objclscommon.search(" GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "GUEST_name"
                        CMBGUEST.DataSource = dt
                        CMBGUEST.DisplayMember = "GUEST_name"
                    End If
                    CMBGUEST.Text = ""
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOUR.Validating
        Try
            If CMBTOUR.Text.Trim <> "" Then
                CMBGUEST.DataSource = Nothing
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If CMBGUEST.Text.Trim = "" Then
                    dt = objclscommon.search(" GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "GUEST_name"
                        CMBGUEST.DataSource = dt
                        CMBGUEST.DisplayMember = "GUEST_name"
                    End If
                    CMBGUEST.Text = ""
                End If
            End If

            If CMBTOUR.Text.Trim <> "" Then
                CMBCURRENCY.DataSource = Nothing
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If CMBCURRENCY.Text.Trim = "" Then
                    dt = objclscommon.search(" ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY ", "", "  TOUR_CURRENCY INNER JOIN TOURMASTER ON TOUR_CURRENCY.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_CURRENCY.TOUR_yearid = TOURMASTER.TOUR_YEARID INNER JOIN CURRENCYMASTER ON TOUR_CURRENCY.TOUR_CURRENCYID = CURRENCYMASTER.cur_id  ", " and TOURMASTER.TOUR_NAME='" & CMBTOUR.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "CURRENCY"
                        CMBCURRENCY.DataSource = dt
                        CMBCURRENCY.DisplayMember = "CURRENCY"
                    End If
                    CMBCURRENCY.Text = ""
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDFOREX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDFOREX.CheckedChanged
        Try
            LBLCURR.Visible = RDFOREX.Checked
            CMBCURRENCY.Visible = RDFOREX.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBDECLARE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBDECLARE.CheckedChanged
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDBCASH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBCASH.CheckedChanged
        Try
            LBLCURR.Visible = RDBCASH.Checked
            CMBCURRENCY.Visible = RDBCASH.Checked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
End Class