
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class HolidayEnqDesign

    'Dim RPTENQ_TOPCOMM As New HolidayEnqReport_TOPCOMM
    'Dim RPTENQ_HEERA As New HolidayEnqReport_HEERA
    'Dim RPTENQ_WAHWAH As New HolidayEnqReport_HEERA
    'Dim RPTENQ_RAMKRISHNA As New HolidayEnqReport_RAMKRISHNA
    'Dim RPTHOLIDAYRATE_TOPCOMM As New HolidayRateConfirmation_TOPCOMM
    Dim RPTHOLIDAYENQ_SSR As New PackageEnquiryInvoice_SSR
    Dim RPTHOLIDAYRATE_REPORT As New HolidayRateConfirmation_REPORT

    '************************
    'NEW REPORTS
    'Dim RPTITINERARYQUOTE_AIRTRINITY As New ItineraryQuote_AIRTRINITY
    'Dim RPTITINERARYQUOTE_TNL As New ItineraryQuote_TNL

    Dim RPTITINERARYQUOTE_BELLA As New ItineraryQuote_BELLA
    Dim RPTITINERARYQUOTE_VIHAR As New ItineraryQuoteREPORT_VIHAR
    Dim RPTITINERARYQUOTE_REPORT As New ItineraryQuote_REPORT
    Dim RPTHOLIDAYQUOTE_TRAVELBRIDGE As New HolidayQuote_TRAVELBRIDGE



    Public strsearch As String
    Public FRMSTRING As String
    Public ENQNO As Integer
    Public HIDEAMT As Boolean
    Public QUOTEPERPAX As Boolean
    Public SUBJECT As String = ""
    Public GUESTNAME As String = ""
    Public ADULTRATE, EXTRAADULTRATE, CHILDRATE, CHILDWITHOUTBEDRATE, INFANTRATE, EXTRAADULTS, EXTRACHILDS As Double
    Public NOOFROOMS As Integer

    Private Sub HolidayEnqDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "HOTELRATE" Then
                'If ClientName = "TOPCOMM" Then
                '    crTables = RPTHOLIDAYRATE_TOPCOMM.Database.Tables
                'Else
                crTables = RPTHOLIDAYRATE_REPORT.Database.Tables
                'End If

            ElseIf FRMSTRING = "PACKAGEINV" Then
                If ClientName = "SSR" Then crTables = RPTHOLIDAYENQ_SSR.Database.Tables

            Else
                If ClientName = "BELLA" Then
                    crTables = RPTITINERARYQUOTE_BELLA.Database.Tables
                ElseIf ClientName = "VIHAR" Then
                    crTables = RPTITINERARYQUOTE_VIHAR.Database.Tables
                ElseIf ClientName = "TRAVELBRIDGE" Then
                    crTables = RPTHOLIDAYQUOTE_TRAVELBRIDGE.Database.Tables
                Else
                    crTables = RPTITINERARYQUOTE_REPORT.Database.Tables
                End If

            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            strsearch = strsearch & " {HOLIDAYENQMASTER.ENQ_NO}= " & ENQNO & " and {HOLIDAYENQMASTER.ENQ_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch


            If FRMSTRING = "HOTELRATE" Then
                If ClientName = "TOPCOMM" Then
                    'CRPO.ReportSource = RPTHOLIDAYRATE_TOPCOMM
                Else
                    Dim LOGO As BlobFieldObject = DirectCast(RPTHOLIDAYRATE_REPORT.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    'If ClientName = "AIRTRINTY" Then
                    '    RPTHOLIDAYRATE_REPORT.Section2.ReportObjects("AIRTRINITYTEXT").ObjectFormat.EnableSuppress = True
                    '    LOGO.Height = 1353.6
                    '    LOGO.Width = 3182.4
                    '    'ElseIf ClientName = "TNL" Then
                    '    '    RPTHOLIDAYRATE_REPORT.Section2.ReportObjects("AIRTRINITYTEXT").ObjectFormat.EnableSuppress = True
                    '    '    LOGO.Height = 1353.6
                    '    '    LOGO.Width = 3182.4
                    'Else
                    LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    'End If
                    CRPO.ReportSource = RPTHOLIDAYRATE_REPORT
                End If

            ElseIf FRMSTRING = "PACKAGEINV" Then
                If ClientName = "SSR" Then CRPO.ReportSource = RPTHOLIDAYENQ_SSR

            Else

                If ClientName = "VIHAR" Then
                    CRPO.ReportSource = RPTITINERARYQUOTE_VIHAR

                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("ADULTRATE").Text = ADULTRATE
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("EXTRAADULTRATE").Text = EXTRAADULTRATE
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("CHILDRATE").Text = CHILDRATE
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("CHILDWITHOUTBEDRATE").Text = CHILDWITHOUTBEDRATE
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("INFANTRATE").Text = INFANTRATE
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("EXTRAADULTS").Text = EXTRAADULTS
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("CHILDWITHOUTBED").Text = EXTRACHILDS
                    RPTITINERARYQUOTE_VIHAR.DataDefinition.FormulaFields("NOOFROOMS").Text = NOOFROOMS

                ElseIf ClientName = "TRAVELBRIDGE" Then
                    CRPO.ReportSource = RPTHOLIDAYQUOTE_TRAVELBRIDGE

                Else
                    CRPO.ReportSource = RPTITINERARYQUOTE_REPORT

                    If QUOTEPERPAX = False Then RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("PERPAX").Text = 0
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("ADULTRATE").Text = ADULTRATE
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("EXTRAADULTRATE").Text = EXTRAADULTRATE
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("CHILDRATE").Text = CHILDRATE
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("CHILDWITHOUTBEDRATE").Text = CHILDWITHOUTBEDRATE
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("INFANTRATE").Text = INFANTRATE
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("EXTRAADULTS").Text = EXTRAADULTS
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("CHILDWITHOUTBED").Text = EXTRACHILDS
                    RPTITINERARYQUOTE_REPORT.DataDefinition.FormulaFields("NOOFROOMS").Text = NOOFROOMS

                    'TRY INCH TO TWIP CONVERTOR FOR INCHES TO TWIPS
                    Dim LOGO As BlobFieldObject = DirectCast(RPTITINERARYQUOTE_REPORT.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    If ClientName = "AERO" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "APPLE" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "KHANNA" Then
                        RPTITINERARYQUOTE_REPORT.Section2.ReportObjects("LOGO").ObjectFormat.EnableSuppress = True
                        RPTITINERARYQUOTE_REPORT.Section2.ReportObjects("LOGOKHANNA").ObjectFormat.EnableSuppress = False
                        RPTITINERARYQUOTE_REPORT.PageFooterSection1.ReportObjects("FOOTERTEXT").ObjectFormat.EnableSuppress = True
                        RPTITINERARYQUOTE_REPORT.PageFooterSection1.ReportObjects("FOOTERKHANNA").ObjectFormat.EnableSuppress = False
                    Else
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    End If
                End If
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        If FRMSTRING = "HOTELRATE" Then
            tempattachment = "Rate Confirmation"
        Else
            tempattachment = "Package Quotation"
            'If SUBJECT = "" Then
            '    tempattachment = "Enquiry No. " & ENQNO
            'Else
            '    tempattachment = SUBJECT
            'End If
        End If


        If FRMSTRING = "HOTELRATE" Then
            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" HOTELMASTER.HOTEL_EMAILID AS EMAILID", "", "  HOLIDAYENQMASTER INNER JOIN HOTELMASTER ON HOLIDAYENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID AND HOLIDAYENQMASTER.ENQ_CMPID = HOTELMASTER.HOTEL_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = HOTELMASTER.HOTEL_YEARID ", " AND ENQ_NO = " & ENQNO & " AND ENQ_CMPID = " & CmpId & " AND ENQ_LOCATIONID = " & Locationid & " AND ENQ_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then emailid = DT.Rows(0).Item("EMAILID")
        Else
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_EMAIL AS EMAILID", "", "  HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID ", " AND ENQ_NO = " & ENQNO & " AND ENQ_CMPID = " & CmpId & " AND ENQ_LOCATIONID = " & Locationid & " AND ENQ_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then emailid = DT.Rows(0).Item("EMAILID")
        End If


        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If SUBJECT = "" Then
                objmail.subject = tempattachment
            Else
                objmail.subject = SUBJECT
            End If
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.GUESTNAME = GUESTNAME
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\Package Quotation.pdf"

            If FRMSTRING = "HOTELRATE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Rate Confirmation.PDF"
                'If ClientName = "TOPCOMM" Then
                '    expo = RPTHOLIDAYRATE_TOPCOMM.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTHOLIDAYRATE_TOPCOMM.Export()
                'Else

                'End If
            ElseIf FRMSTRING = "PACKAGEINV" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Enquiry Invoice.PDF"
                expo = RPTHOLIDAYENQ_SSR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOLIDAYENQ_SSR.Export()
            Else
                If ClientName = "VIHAR" Then
                    expo = RPTITINERARYQUOTE_VIHAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTITINERARYQUOTE_VIHAR.Export()
                ElseIf ClientName = "TRAVELBRIDGE" Then
                    expo = RPTHOLIDAYQUOTE_TRAVELBRIDGE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTHOLIDAYQUOTE_TRAVELBRIDGE.Export()
                Else
                    expo = RPTITINERARYQUOTE_REPORT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTITINERARYQUOTE_REPORT.Export()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class