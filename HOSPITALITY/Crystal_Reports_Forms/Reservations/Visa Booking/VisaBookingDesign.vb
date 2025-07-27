
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class VisaBookingDesign

    Dim RPTINVOICE_URMI As New VisaBookingInvoice_URMI
    'Dim RPTINVOICE_WORLDSPIN As New VisaBookingInvoice_WORLDSPIN
    Dim RPTINVOICE_SSR As New VisaBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New VisaBookingInvoice_AERO
    'Dim RPTINVOICE_APPLE As New VisaBookingInvoice_APPLE
    'Dim RPTINVOICE_AIRTRINITY As New VisaBookingInvoice_AIRTRINITY
    Dim RPTINVOICE_STARVISA As New VisaBookingInvoice_STARVISA
    'Dim RPTINVOICE_GLOBE As New VisaBookingInvoice_GLOBE
    'Dim RPTINVOICE_TNL As New VisaBookingInvoice_TNL
    Dim RPTINVOICE_BELLA As New VisaBookingInvoice_BELLA
    Dim RPTINVOICE_COMMON As New VisaBookingInvoice_COMMON
    'Dim RPTINVOICE_PRIYA As New VisaBookingInvoice_PRIYA
    Dim RPTINVOICE_KPNT As New VisaBookingInvoice_KPNT
    'Dim RPTINVOICE_NAMASTE As New VisaBookingInvoice_NAMASTE
    Dim RPTINVOICE_MILONI As New VisaBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New VisaBookingInvoice_MATRIX
    'Dim RPTINVOICE_BHAGYASHRI As New VisaBookingInvoice_BHAGYASHRI
    'Dim RPTINVOICE_WAHWAH As New VisaBookingInvoice_WAHWAH
    'Dim RPTINVOICE_MANYA As New VisaBookingInvoice_MANYA
    'Dim RPTINVOICE_WHITEPEARL As New VisaBookingInvoice_WHITEPEARL
    Dim RPTINVOICE_SKYMAPS As New VisaBookingInvoice_SKYMAPS
    'Dim RPTINVOICE_OFFBEAT As New VisaBookingInvoice_OFFBEAT
    'Dim RPTINVOICE_LUXCREST As New VisaBookingInvoice_LUXCREST
    'Dim RPTINVOICE_SCC As New VisaBookingInvoice_SCC
    Dim RPTINVOICE_HEENKAR As New VisaBookingInvoice_HEENKAR
    'Dim RPTINVOICE_ARUN As New VisaBookingInvoice_ARUN
    'Dim RPTINVOICE_HEERA As New VisaBookingInvoice_HEERA
    Dim RPTINVOICE_RAMKRISHNA As New VisaBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_KHANNA As New VisaBookingInvoice_KHANNA
    Dim RPTINVOICE_TRISHA As New VisaBookingInvoice_TRISHA

    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public MTDC As Boolean = False
    Public BOOKINGNO As Integer
    Public LETTERHEAD As Integer = 0
    Public BOOKTYPE As String
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public PRINTTAX As Boolean
    Public HIDEHEADER As Boolean
    Public GUESTNAME As String = ""
    Public DIRECTPRINT As Boolean = False
    Public SALEREGISTERID As Integer
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub VisaBookingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If ClientName = "URMI" Then
                crTables = RPTINVOICE_URMI.Database.Tables
                'ElseIf ClientName = "WORLDSPIN" Then
                '    crTables = RPTINVOICE_WORLDSPIN.Database.Tables
            ElseIf ClientName = "SSR" Then
                crTables = RPTINVOICE_SSR.Database.Tables
            ElseIf ClientName = "AERO" Then
                crTables = RPTINVOICE_AERO.Database.Tables
                'ElseIf ClientName = "AIRTRINITY" Then
                '    crTables = RPTINVOICE_AIRTRINITY.Database.Tables
            ElseIf ClientName = "STARVISA" Then
                crTables = RPTINVOICE_STARVISA.Database.Tables
                'ElseIf ClientName = "GLOBE" Then
                '    crTables = RPTINVOICE_GLOBE.Database.Tables
                'ElseIf ClientName = "TNL" Then
                '    crTables = RPTINVOICE_TNL.Database.Tables
            ElseIf ClientName = "BELLA" Then
                crTables = RPTINVOICE_BELLA.Database.Tables


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
            ElseIf ClientName = "TRISHA" Then
                crTables = RPTINVOICE_TRISHA.Database.Tables
                RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            ElseIf ClientName = "KHANNA" Then
                RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                crTables = RPTINVOICE_KHANNA.Database.Tables
            Else
                If ClientName = "ROYALHOLIDAYS" Then
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                crTables = RPTINVOICE_COMMON.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            strsearch = strsearch & " {VISABOOKING.BOOKING_NO}= " & BOOKINGNO & " AND {VISABOOKING.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch
            If ClientName = "URMI" Then
                CRPO.ReportSource = RPTINVOICE_URMI
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box6").ObjectFormat.EnableSuppress = True
                'ElseIf ClientName = "WORLDSPIN" Then
                '    CRPO.ReportSource = RPTINVOICE_WORLDSPIN
            ElseIf ClientName = "SSR" Then
                CRPO.ReportSource = RPTINVOICE_SSR
            ElseIf ClientName = "AERO" Then
                CRPO.ReportSource = RPTINVOICE_AERO
                'ElseIf ClientName = "AIRTRINITY" Then
                '    CRPO.ReportSource = RPTINVOICE_AIRTRINITY
            ElseIf ClientName = "STARVISA" Then
                CRPO.ReportSource = RPTINVOICE_STARVISA
                'ElseIf ClientName = "GLOBE" Then
                '    CRPO.ReportSource = RPTINVOICE_GLOBE
                'ElseIf ClientName = "TNL" Then
                '    CRPO.ReportSource = RPTINVOICE_TNL
            ElseIf ClientName = "BELLA" Then
                CRPO.ReportSource = RPTINVOICE_BELLA

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
            ElseIf ClientName = "TRISHA" Then
                CRPO.ReportSource = RPTINVOICE_TRISHA
            ElseIf ClientName = "KHANNA" Then
                CRPO.ReportSource = RPTINVOICE_KHANNA
            Else
                If ClientName = "ROYALHOLIDAYS" Then
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                CRPO.ReportSource = RPTINVOICE_COMMON
                If PRINTTAX = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 0
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            Throw ex
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

            strsearch = strsearch & " {VISABOOKING.BOOKING_NO}= " & BOOKINGNO & " AND {VISABOOKING.BOOKING_SALEREGISTERID} = " & SALEREGISTERID & " AND {VISABOOKING.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Visa Booking Invoice"

                If ClientName = "URMI" Then
                    OBJ = New VisaBookingInvoice_URMI
                    OBJOLD = New VisaBookingInvoice_URMIOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New VisaBookingInvoice_SSR
                    OBJOLD = New VisaBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New VisaBookingInvoice_AERO
                    OBJOLD = New VisaBookingInvoice_AEROOLD
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New VisaBookingInvoice_AIRTRINITY
                    '    OBJOLD = New VisaBookingInvoice_AIRTRINITYOLD
                ElseIf ClientName = "STARVISA" Then
                    OBJ = New VisaBookingInvoice_STARVISA
                    OBJOLD = New VisaBookingInvoice_STARVISAOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New VisaBookingInvoice_GLOBE
                    '    OBJOLD = New VisaBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New VisaBookingInvoice_TNL
                ElseIf ClientName = "BELLA" Then
                    OBJ = New VisaBookingInvoice_BELLA

                ElseIf ClientName = "KPNT" Then
                    OBJ = New VisaBookingInvoice_KPNT
                    OBJOLD = New VisaBookingInvoice_KPNTOLD
                ElseIf ClientName = "MILONI" Then
                    OBJ = New VisaBookingInvoice_MILONI
                    OBJOLD = New VisaBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New VisaBookingInvoice_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New VisaBookingInvoice_SKYMAPS
                    OBJOLD = New VisaBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New VisaBookingInvoice_LUXCREST
                    '    OBJOLD = New VisaBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New VisaBookingInvoice_HEENKAR
                    OBJOLD = New VisaBookingInvoice_HEENKAROLD
                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New VisaBookingInvoice_RAMKRISHNA
                    OBJOLD = New VisaBookingInvoice_RAMKRISHNAOLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New VisaBookingInvoice_TRISHA
                ElseIf ClientName = "KHANNA" Then
                    OBJ = New VisaBookingInvoice_KHANNA
                    OBJOLD = New VisaBookingInvoice_KHANNAOLD
                Else
                    OBJ = New VisaBookingInvoice_COMMON
                End If

            End If


            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "VISABOOKING ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
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
        Try
            Dim emailid As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_EMAIL,'') AS EMAILID", "", " LEDGERS ", " AND ACC_CMPNAME = '" & GUESTNAME & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then emailid = DT.Rows(0).Item("EMAILID")
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim tempattachment As String = "Invoice No. " & BOOKINGNO

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If SUBJECT = "" Then objmail.subject = tempattachment Else objmail.subject = SUBJECT
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
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
            oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
            If ClientName = "URMI" Then
                RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = False
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box6").ObjectFormat.EnableSuppress = False
                expo = RPTINVOICE_URMI.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_URMI.Export()
                RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box6").ObjectFormat.EnableSuppress = True
                'ElseIf ClientName = "WORLDSPIN" Then
                '    expo = RPTINVOICE_WORLDSPIN.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTINVOICE_WORLDSPIN.Export()
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
            ElseIf ClientName = "BELLA" Then
                RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_BELLA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_BELLA.Export()
                RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 0


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
                'ElseIf ClientName = "OFFBEAT" Then
                '    RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                '    expo = RPTINVOICE_OFFBEAT.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTINVOICE_OFFBEAT.Export()
                '    RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 0

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
            ElseIf ClientName = "TRISHA" Then
                RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_TRISHA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_TRISHA.Export()
                RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            ElseIf ClientName = "KHANNA" Then
                RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_KHANNA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_KHANNA.Export()
                RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            Else
                RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTINVOICE_COMMON.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE_COMMON.Export()
                RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class