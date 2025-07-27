
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class RailBookingVoucherDesign

    Dim RPTINVOICE_KHANNA As New RailBookingInvoice_KHANNA
    'Dim RPTINVOICE_SAFAR As New RailBookingInvoice_SAFAR
    Dim RPTINVOICE_TRISHA As New RailBookingInvoice_TRISHA
    Dim RPTINVOICE_BARODA As New RailBookingInvoice_BARODA
    Dim RPTINVOICE_BELLA As New RailBookingInvoice_BELLA
    Dim RPTINVOICE_COMMON As New RailBookingInvoice_COMMON
    Dim RPTINVOICE_PRATAMESH As New RailBookingInvoice_PRATAMESH
    Dim RPTINVOICE_SSR As New RailBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New RailBookingInvoice_AERO
    'Dim RPTINVOICE_TOP As New RailBookingInvoice_TOPCOMM
    'Dim RPTINVOICE_AIRTRINITY As New RailBookingInvoice_AIRTRINITY
    Dim RPTINVOICE_STARVISA As New RailBookingInvoice_STARVISA
    'Dim RPTINVOICE_GLOBE As New RailBookingInvoice_GLOBE
    'Dim RPTINVOICE_TNL As New RailBookingInvoice_TNL
    Dim RPTINVOICE_KPNT As New RailBookingInvoice_KPNT
    Dim RPTINVOICE_MILONI As New RailBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New RailBookingInvoice_MATRIX
    Dim RPTINVOICE_SKYMAPS As New RailBookingInvoice_SKYMAPS
    'Dim RPTINVOICE_LUXCREST As New RailBookingInvoice_LUXCREST
    Dim RPTINVOICE_HEENKAR As New RailBookingInvoice_HEENKAR
    Dim RPTINVOICE_RAMKRISHNA As New RailBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_URMI As New RailBookingInvoice_URMI
    'Dim RPTINVOICE_SCC As New RailBookingInvoice_SCC
    'Dim RPTINVOICE_MAHARAJA As New RailBookingInvoice_MAHARAJA

    Dim RPTVOUCHER_BARODA As New RailBookingVoucher_BARODA
    Dim RPTINVOICEOFFICE_BARODA As New RailBookingInvoice_BARODA_OfficeCopy

    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public MTDC As Boolean = False
    Public BOOKINGNO As Integer
    Public LETTERHEAD As Integer = 0
    Public BOOKTYPE As String
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public PRINTST As Boolean
    Public HIDEHEADER As Boolean
    Public DIRECTPRINT As Boolean = False
    Public SALEREGISTERID As Integer
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub RAILBOOKINGMASTERVoucherDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If


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

            If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                TOOLMAILTICKETANDINVOICE.Visible = True
                TOOLSTRIP.Visible = True
            End If


            If FRMSTRING = "INVOICE" Then
                If ClientName = "KHANNA" Then
                    crTables = RPTINVOICE_KHANNA.Database.Tables
                    'ElseIf ClientName = "SEASONED" Then
                    '    crTables = RPTINVOICE_SEASONED.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = RPTINVOICE_SAFAR.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = RPTINVOICE_TRISHA.Database.Tables
                    'ElseIf ClientName = "SHREEJI" Then
                    '    crTables = RPTINVOICE_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = RPTINVOICE_BARODA.Database.Tables
                ElseIf ClientName = "BELLA" Then
                    crTables = RPTINVOICE_BELLA.Database.Tables

                ElseIf ClientName = "PRATAMESH" Then
                    crTables = RPTINVOICE_PRATAMESH.Database.Tables
                ElseIf ClientName = "SSR" Then
                    crTables = RPTINVOICE_SSR.Database.Tables
                ElseIf ClientName = "AERO" Then
                    crTables = RPTINVOICE_AERO.Database.Tables

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = RPTINVOICE_TOP.Database.Tables
                    'ElseIf ClientName = "APPLE" Then
                    '    crTables = RPTINVOICE_APPLE.Database.Tables
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    crTables = RPTINVOICE_AIRTRINITY.Database.Tables
                ElseIf ClientName = "STARVISA" Then
                    crTables = RPTINVOICE_STARVISA.Database.Tables
                    'ElseIf ClientName = "GLOBE" Then
                    '    crTables = RPTINVOICE_GLOBE.Database.Tables
                    'ElseIf ClientName = "TNL" Then
                    '    crTables = RPTINVOICE_TNL.Database.Tables
                    'ElseIf ClientName = "PRIYA" Then
                    '    crTables = RPTINVOICE_PRIYA.Database.Tables
                ElseIf ClientName = "KPNT" Then
                    crTables = RPTINVOICE_KPNT.Database.Tables
                    'ElseIf ClientName = "NAMASTE" Then
                    '    crTables = RPTINVOICE_NAMASTE.Database.Tables
                ElseIf ClientName = "MILONI" Then
                    crTables = RPTINVOICE_MILONI.Database.Tables
                ElseIf ClientName = "MATRIX" Then
                    crTables = RPTINVOICE_MATRIX.Database.Tables

                ElseIf ClientName = "SKYMAPS" Then
                    crTables = RPTINVOICE_SKYMAPS.Database.Tables
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    crTables = RPTINVOICE_OFFBEAT.Database.Tables
                    'ElseIf ClientName = "LUXCREST" Then
                    '    crTables = RPTINVOICE_LUXCREST.Database.Tables
                ElseIf ClientName = "HEENKAR" Then
                    crTables = RPTINVOICE_HEENKAR.Database.Tables
                    'ElseIf ClientName = "ARUN" Then
                    '    crTables = RPTINVOICE_ARUN.Database.Tables
                    'ElseIf ClientName = "HEERA" Then
                    '    crTables = RPTINVOICE_HEERA.Database.Tables
                ElseIf ClientName = "RAMKRISHNA" Then
                    crTables = RPTINVOICE_RAMKRISHNA.Database.Tables
                ElseIf ClientName = "URMI" Then
                    crTables = RPTINVOICE_URMI.Database.Tables
                    'ElseIf ClientName = "SCC" Then
                    '    crTables = RPTINVOICE_SCC.Database.Tables
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    crTables = RPTINVOICE_WORLDSPIN.Database.Tables
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    crTables = RPTINVOICE_MAHARAJA.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = RPTINVOICE_COMMON.Database.Tables
                End If
            ElseIf FRMSTRING = "VOUCHER" Then
                'If ClientName = "SHREEJI" Then
                '    crTables = RPTVOUCHER_SHREEJI.Database.Tables
                If ClientName = "BARODA" Then
                    crTables = RPTVOUCHER_BARODA.Database.Tables

                End If

            ElseIf FRMSTRING = "INVOICEOFFICE" Then
                'If ClientName = "SHREEJI" Then
                '    crTables = RPTINVOICEOFFICE_SHREEJI.Database.Tables
                If ClientName = "BARODA" Then
                    crTables = RPTINVOICEOFFICE_BARODA.Database.Tables

                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            strsearch = strsearch & " {RAILBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {RAILBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {RAILBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {RAILBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "INVOICE" Then
                If ClientName = "KHANNA" Then
                    CRPO.ReportSource = RPTINVOICE_KHANNA
                    'ElseIf ClientName = "SEASONED" Then
                    '    CRPO.ReportSource = RPTINVOICE_SEASONED
                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = RPTINVOICE_SAFAR
                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = RPTINVOICE_TRISHA
                    'ElseIf ClientName = "SHREEJI" Then
                    '    CRPO.ReportSource = RPTINVOICE_SHREEJI
                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICE_BARODA
                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = RPTINVOICE_BELLA

                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = RPTINVOICE_PRATAMESH
                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = RPTINVOICE_SSR
                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = RPTINVOICE_AERO
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = RPTINVOICE_TOP
                    'ElseIf ClientName = "APPLE" Then
                    '    CRPO.ReportSource = RPTINVOICE_APPLE
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = RPTINVOICE_AIRTRINITY
                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = RPTINVOICE_STARVISA
                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = RPTINVOICE_GLOBE
                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = RPTINVOICE_TNL
                    'ElseIf ClientName = "PRIYA" Then
                    '    CRPO.ReportSource = RPTINVOICE_PRIYA
                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = RPTINVOICE_KPNT
                    'ElseIf ClientName = "NAMASTE" Then
                    '    CRPO.ReportSource = RPTINVOICE_NAMASTE
                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = RPTINVOICE_MILONI
                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = RPTINVOICE_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = RPTINVOICE_SKYMAPS
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    CRPO.ReportSource = RPTINVOICE_OFFBEAT
                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = RPTINVOICE_LUXCREST
                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTINVOICE_HEENKAR
                    'ElseIf ClientName = "ARUN" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARUN
                    'ElseIf ClientName = "HEERA" Then
                    '    CRPO.ReportSource = RPTINVOICE_HEERA
                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTINVOICE_RAMKRISHNA
                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = RPTINVOICE_URMI
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = RPTINVOICE_SCC
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    CRPO.ReportSource = RPTINVOICE_WORLDSPIN
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = RPTINVOICE_MAHARAJA
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    CRPO.ReportSource = RPTINVOICE_COMMON
                End If
            ElseIf FRMSTRING = "VOUCHER" Then
                'If ClientName = "SHREEJI" Then
                '    CRPO.ReportSource = RPTVOUCHER_SHREEJI
                If ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTVOUCHER_BARODA

                End If
            ElseIf FRMSTRING = "INVOICEOFFICE" Then
                'If ClientName = "SHREEJI" Then
                '    CRPO.ReportSource = RPTINVOICEOFFICE_SHREEJI
                If ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICEOFFICE_BARODA

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

    Sub PRINTDIRECTLYTOPRINTER()
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

            strsearch = strsearch & " {RAILBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {RAILBOOKINGMASTER.BOOKING_SALEREGISTERID} = " & SALEREGISTERID & " AND {RAILBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Rail Booking Invoice"

                If ClientName = "KHANNA" Then
                    OBJ = New RailBookingInvoice_KHANNA
                    OBJOLD = New RailBookingInvoice_KHANNAOLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New RailBookingInvoice_TRISHA
                    OBJOLD = New RailBookingInvoice_TRISHAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New RailBookingInvoice_BARODA
                    OBJOLD = New RailBookingInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New RailBookingInvoice_BELLA
                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New RailBookingInvoice_PRATAMESH
                    OBJOLD = New RailBookingInvoice_PRATAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New RailBookingInvoice_SSR
                    OBJOLD = New RailBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New RailBookingInvoice_AERO
                    OBJOLD = New RailBookingInvoice_AEROOLD
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    OBJ = New RailBookingInvoice_TOPCOMM
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New RailBookingInvoice_AIRTRINITY
                    '    OBJOLD = New RailBookingInvoice_AIRTRINITYOLD
                ElseIf ClientName = "STARVISA" Then
                    OBJ = New RailBookingInvoice_STARVISA
                    OBJOLD = New RailBookingInvoice_STARVISAOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New RailBookingInvoice_GLOBE
                    '    OBJOLD = New RailBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New RailBookingInvoice_TNL
                ElseIf ClientName = "KPNT" Then
                    OBJ = New RailBookingInvoice_KPNT
                    OBJOLD = New RailBookingInvoice_KPNTOLD
                ElseIf ClientName = "MILONI" Then
                    OBJ = New RailBookingInvoice_MILONI
                    OBJOLD = New RailBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New RailBookingInvoice_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New RailBookingInvoice_SKYMAPS
                    OBJOLD = New RailBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New RailBookingInvoice_LUXCREST
                    '    OBJOLD = New RailBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New RailBookingInvoice_HEENKAR
                    OBJOLD = New RailBookingInvoice_HEENKAROLD
                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New RailBookingInvoice_RAMKRISHNA
                    OBJOLD = New RailBookingInvoice_RAMKRISHNAOLD
                ElseIf ClientName = "URMI" Then
                    OBJ = New RailBookingInvoice_URMI
                    OBJOLD = New RailBookingInvoice_URMIOLD
                    'ElseIf ClientName = "SCC" Then
                    '    OBJ = New RailBookingInvoice_SCC
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New RailBookingInvoice_MAHARAJA
                    '    OBJOLD = New RailBookingInvoice_MAHARAJAOLD
                Else
                    OBJ = New RailBookingInvoice_COMMON
                End If

            End If


            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "RAILBOOKINGMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Convert.ToDateTime(DT.Rows(0).Item("DATE")).Date <= "2017-06-30" Then
                    crTables = OBJOLD.Database.Tables
                    For Each crTable In crTables
                        crtableLogonInfo = crTable.LogOnInfo
                        crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                        crTable.ApplyLogOnInfo(crtableLogonInfo)
                    Next

                    OBJOLD.RecordSelectionFormula = strsearch
                    'OBJOLD.PrintToPrinter(1, True, 0, 0)
                    If DIRECTMAIL = False Then
                        OBJOLD.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                        OBJOLD.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
                    Else
                        Dim expo As New ExportOptions
                        Dim oDfDopt As New DiskFileDestinationOptions
                        oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE_" & BOOKINGNO & ".pdf"
                        expo = OBJOLD.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        OBJOLD.Export()
                    End If
                Else
                    crTables = OBJ.Database.Tables
                    For Each crTable In crTables
                        crtableLogonInfo = crTable.LogOnInfo
                        crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                        crTable.ApplyLogOnInfo(crtableLogonInfo)
                    Next

                    OBJ.RecordSelectionFormula = strsearch
                    'OBJ.PrintToPrinter(1, True, 0, 0)
                    If DIRECTMAIL = False Then
                        OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                        OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
                    Else
                        Dim expo As New ExportOptions
                        Dim oDfDopt As New DiskFileDestinationOptions
                        oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE_" & BOOKINGNO & ".pdf"
                        expo = OBJ.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        OBJ.Export()
                    End If
                End If
            Else
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        If FRMSTRING = "INVOICE" Then
            tempattachment = "Invoice No. " & BOOKINGNO
        ElseIf FRMSTRING = "VOUCHER" Then
            tempattachment = "Voucher No. " & BOOKINGNO
        End If

        If ClientName = "TOPCOMM" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_EMAIL AS EMAILID", "", "  RAILBOOKINGMASTER INNER JOIN GUESTMASTER ON RAILBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND RAILBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND RAILBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID ", " AND BOOKING_NO = " & BOOKINGNO & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
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
            If FRMSTRING = "INVOICE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                If ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_KHANNA.Export()
                    'ElseIf ClientName = "SEASONED" Then
                    '    expo = RPTINVOICE_SEASONED.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SEASONED.Export()
                    'ElseIf ClientName = "SAFAR" Then
                    '    expo = RPTINVOICE_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SAFAR.Export()
                ElseIf ClientName = "TRISHA" Then
                    RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_TRISHA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_TRISHA.Export()
                    RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "SHREEJI" Then
                    '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_SHREEJI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SHREEJI.Export()
                    '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BARODA" Then
                    RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_BARODA.Export()
                    RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BELLA" Then
                    RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_BELLA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_BELLA.Export()
                    RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 0



                ElseIf ClientName = "PRATAMESH" Then
                    expo = RPTINVOICE_PRATAMESH.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_PRATAMESH.Export()
                ElseIf ClientName = "SSR" Then
                    RPTINVOICE_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_SSR.Export()
                    RPTINVOICE_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                ElseIf ClientName = "AERO" Then
                    RPTINVOICE_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_AERO.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_AERO.Export()
                    RPTINVOICE_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    RPTINVOICE_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_TOP.Export()
                    '    RPTINVOICE_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_AIRTRINITY.Export()
                    '    RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                ElseIf ClientName = "STARVISA" Then
                    RPTINVOICE_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_STARVISA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_STARVISA.Export()
                    RPTINVOICE_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "GLOBE" Then
                    '    RPTINVOICE_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_GLOBE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_GLOBE.Export()
                    '    RPTINVOICE_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "TNL" Then
                    '    RPTINVOICE_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_TNL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_TNL.Export()
                    '    RPTINVOICE_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "PRIYA" Then
                    '    RPTINVOICE_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_PRIYA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_PRIYA.Export()
                    '    RPTINVOICE_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "KPNT" Then
                    RPTINVOICE_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_KPNT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_KPNT.Export()
                    RPTINVOICE_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "NAMASTE" Then
                    '    RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_NAMASTE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_NAMASTE.Export()
                    '    RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "MILONI" Then
                    RPTINVOICE_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_MILONI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_MILONI.Export()
                    RPTINVOICE_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "MATRIX" Then
                    RPTINVOICE_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_MATRIX.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_MATRIX.Export()
                    RPTINVOICE_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                ElseIf ClientName = "SKYMAPS" Then
                    RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_SKYMAPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_SKYMAPS.Export()
                    RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "LUXCREST" Then
                    '    RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_LUXCREST.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_LUXCREST.Export()
                    '    RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "HEENKAR" Then
                    RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_HEENKAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_HEENKAR.Export()
                    RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "ARUN" Then
                    '    RPTINVOICE_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_ARUN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_ARUN.Export()
                    '    RPTINVOICE_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "HEERA" Then
                    '    RPTINVOICE_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_HEERA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_HEERA.Export()
                    '    RPTINVOICE_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                ElseIf ClientName = "RAMKRISHNA" Then
                    RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_RAMKRISHNA.Export()
                    RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                ElseIf ClientName = "URMI" Then
                    RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = False
                    expo = RPTINVOICE_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_URMI.Export()
                    RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    RPTINVOICE_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_SCC.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SCC.Export()
                    '    RPTINVOICE_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_WORLDSPIN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_WORLDSPIN.Export()
                    '    RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    expo = RPTINVOICE_MAHARAJA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_MAHARAJA.Export()
                Else
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_COMMON.Export()
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                End If
            ElseIf FRMSTRING = "VOUCHER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Voucher No. " & BOOKINGNO & ".PDF"
                'If ClientName = "SHREEJI" Then
                '    RPTVOUCHER_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                '    expo = RPTVOUCHER_SHREEJI.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTVOUCHER_SHREEJI.Export()
                '    RPTVOUCHER_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                If ClientName = "BARODA" Then
                    RPTVOUCHER_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_BARODA.Export()
                    RPTVOUCHER_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLMAILTICKETANDINVOICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAILTICKETANDINVOICE.Click
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            'SEATCH FOR ETICKET
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "PDF (*.pfd)|*.pdf"
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then
                MsgBox("Ticket Not Selected", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'CONVERT TO PFD
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
            'If ClientName = "SHREEJI" Then
            '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            '    expo = RPTINVOICE_SHREEJI.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    RPTINVOICE_SHREEJI.Export()
            '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            If ClientName = "BARODA" Then
                RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_BARODA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_BARODA.Export()
                RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            ElseIf ClientName = "BELLA" Then
                RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_BELLA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_BELLA.Export()
                RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            Else
                RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_COMMON.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_COMMON.Export()
                RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            End If

            'CONVERTTING DONE
            '*********************************


            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
            objmail.attachment1 = OpenFileDialog1.FileName
            objmail.subject = SUBJECT
            objmail.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class