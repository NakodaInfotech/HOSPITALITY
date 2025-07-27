
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BL

Public Class HotelBookingVoucherDesign

    Dim RPTVOUCHER As New HotelBookingVoucher
    'Dim RPTVOUCHER_TOP As New HotelBookingVoucher_Top
    'Dim RPTVOUCHER_MTDCTOP As New MTDCVoucher_Top
    Dim RPTVOUCHER_KHANNA As New HotelBookingVoucher_KHANNA
    ' Dim RPTVOUCHER_SEASONED As New HotelBookingVoucher_SEASONED
    'Dim RPTVOUCHER_SAFAR As New HotelBookingVoucher_SAFAR
    Dim RPTVOUCHER_TRISHA As New HotelBookingVoucher_TRISHA
    ' Dim RPTVOUCHER_SHREEJI As New HotelBookingVoucher_SHREEJI
    Dim RPTVOUCHER_BARODA As New HotelBookingVoucher_BARODA
    Dim RPTVOUCHER_BELLA As New HotelBookingVoucher_BELLA
    Dim RPTVOUCHER_COMMON As New HotelBookingVoucher_COMMON
    Dim RPTVOUCHER_PRATAMESH As New HotelBookingVoucher_PRATAMESH
    Dim RPTVOUCHER_SSR As New HotelBookingVoucher_SSR
    Dim RPTVOUCHER_AERO As New HotelBookingVoucher_AERO
    'Dim RPTVOUCHER_APPLE As New HotelBookingVoucher_APPLE
    'Dim RPTVOUCHER_AIRTRINITY As New HotelBookingVoucher_AIRTRINITY
    Dim RPTVOUCHER_STARVISA As New HotelBookingVoucher_STARVISA
    'Dim RPTVOUCHER_GLOBE As New HotelBookingVoucher_GLOBE
    'Dim RPTVOUCHER_TNL As New HotelBookingVoucher_TNL
    'Dim RPTVOUCHER_PRIYA As New HotelBookingVoucher_PRIYA
    Dim RPTVOUCHER_KPNT As New HotelBookingVoucher_KPNT
    'Dim RPTVOUCHER_NAMASTE As New HotelBookingVoucher_NAMASTE
    Dim RPTVOUCHER_MILONI As New HotelBookingVoucher_MILONI
    Dim RPTVOUCHER_MATRIX As New HotelBookingVoucher_MATRIX
    'Dim RPTVOUCHER_BHAGYASHRI As New HotelBookingVoucher_BHAGYASHRI
    '' Dim RPTVOUCHER_WAHWAH As New HotelBookingVoucher_WAHWAH
    'Dim RPTVOUCHER_MANYA As New HotelBookingVoucher_MANYA
    'Dim RPTVOUCHER_WHITEPEARL As New HotelBookingVoucher_WHITEPEARL
    Dim RPTVOUCHER_SKYMAPS As New HotelBookingVoucher_SKYMAPS
    'Dim RPTVOUCHER_OFFBEAT As New HotelBookingVoucher_OFFBEAT
    'Dim RPTVOUCHER_LUXCREST As New HotelBookingVoucher_LUXCREST
    Dim RPTVOUCHER_HEENKAR As New HotelBookingVoucher_HEENKAR
    ' Dim RPTVOUCHER_ARUN As New HotelBookingVoucher_ARUN
    'Dim RPTVOUCHER_ARHAM As New HotelBookingVoucher_ARHAM
    ' Dim RPTVOUCHER_HEERA As New HotelBookingVoucher_HEERA
    Dim RPTVOUCHER_RAMKRISHNA As New HotelBookingVoucher_RAMKRISHNA
    Dim RPTVOUCHER_URMI As New HotelBookingVoucher_URMI
    Dim RPTVOUCHER_TRAVELBRIDGE As New HotelBookingVoucher_TRAVELBRIDGE
    'Dim RPTVOUCHER_SCC As New HotelBookingVoucher_SCC
    ' Dim RPTVOUCHER_WORLDSPIN As New HotelBookingVoucher_WORLDSPIN
    'Dim RPTVOUCHER_MAHARAJA As New HotelBookingVoucher_MAHARAJA


    Dim RPTINVOICE As New HotelBookingInvoice
    'Dim RPTINVOICE_TOP As New HotelBookingInvoice_Top
    Dim RPTINVOICE_KHANNA As New HotelBookingInvoice_KHANNA
    'Dim RPTINVOICE_SEASONED As New HotelBookingInvoice_SEASONED
    'Dim RPTINVOICE_SAFAR As New HotelBookingInvoice_SAFAR
    Dim RPTINVOICE_TRISHA As New HotelBookingInvoice_TRISHA
    ' Dim RPTINVOICE_SHREEJI As New HotelBookingInvoice_SHREEJI
    Dim RPTINVOICE_BARODA As New HotelBookingInvoice_BARODA
    Dim RPTINVOICE_BELLA As New HotelBookingInvoice_BELLA
    Dim RPTINVOICE_COMMON As New HotelBookingInvoice_COMMON
    Dim RPTINVOICE_PRATAMESH As New HotelBookingInvoice_PRATHAMESH
    Dim RPTINVOICE_SSR As New HotelBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New HotelBookingInvoice_AERO
    'Dim RPTINVOICE_APPLE As New HotelBookingInvoice_APPLE
    'Dim RPTINVOICE_AIRTRINITY As New HotelBookingInvoice_AIRTRINITY
    Dim RPTINVOICE_STARVISA As New HotelBookingInvoice_STARVISA
    'Dim RPTINVOICE_GLOBE As New HotelBookingInvoice_GLOBE
    'Dim RPTINVOICE_TNL As New HotelBookingInvoice_TNL
    '  Dim RPTINVOICE_PRIYA As New HotelBookingInvoice_PRIYA
    Dim RPTINVOICE_KPNT As New HotelBookingInvoice_KPNT
    'Dim RPTINVOICE_NAMASTE As New HotelBookingInvoice_NAMASTE
    Dim RPTINVOICE_MILONI As New HotelBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New HotelBookingInvoice_MATRIX
    'Dim RPTINVOICE_BHAGYASHRI As New HotelBookingInvoice_BHAGYASHRI
    'Dim RPTINVOICE_WAHWAH As New HotelBookingInvoice_WAHWAH
    'Dim RPTINVOICE_MANYA As New HotelBookingInvoice_MANYA
    'Dim RPTINVOICE_WHITEPEARL As New HotelBookingInvoice_WHITEPEARL
    Dim RPTINVOICE_SKYMAPS As New HotelBookingInvoice_SKYMAPS
    '  Dim RPTINVOICE_OFFBEAT As New HotelBookingInvoice_OFFBEAT
    'Dim RPTINVOICE_LUXCREST As New HotelBookingInvoice_LUXCREST
    Dim RPTINVOICE_HEENKAR As New HotelBookingInvoice_HEENKAR
    'Dim RPTINVOICE_ARUN As New HotelBookingInvoice_ARUN
    'Dim RPTINVOICE_ARHAM As New HotelBookingInvoice_ARHAM
    'Dim RPTINVOICE_HEERA As New HotelBookingInvoice_HEERA
    Dim RPTINVOICE_RAMKRISHNA As New HotelBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_URMI As New HotelBookingInvoice_URMI
    'Dim RPTINVOICE_SCC As New HotelBookingInvoice_SCC
    ' Dim RPTINVOICE_WORLDSPIN As New HotelBookingInvoice_WORLDSPIN
    'Dim RPTINVOICE_MAHARAJA As New HotelBookingInvoice_MAHARAJA


    '  Dim RPTINVOICEOFFICE_SHREEJI As New HotelBookingInvoice_SHREEJI_OfficeCopy
    Dim RPTINVOICEOFFICE_BARODA As New HotelBookingInvoice_BARODA_OfficeCopy

    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public MTDC As Boolean = False
    Public BOOKINGNO As Integer
    Public BOOKINGDATE As Date
    Public LETTERHEAD As Integer = 0
    Public BOOKTYPE As String
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public PRINTST As Boolean
    Public HIDEHEADER As Boolean
    Public GUESTNAME As String = ""
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub HotelBookingVoucherDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


            If FRMSTRING = "VOUCHER" Then
                Me.Text = "Hotel Booking Voucher"

                'FOR COMMON REPORTS
                If ClientName = "CLASSIC" Then
                    crTables = RPTVOUCHER.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    If MTDC = False Then
                    '        crTables = RPTVOUCHER_TOP.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_MTDCTOP.Database.Tables
                    '    End If
                ElseIf ClientName = "KHANNA" Then
                    crTables = RPTVOUCHER_KHANNA.Database.Tables
                ElseIf ClientName = "TRAVELBRIDGE" Then
                    crTables = RPTVOUCHER_TRAVELBRIDGE.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = RPTVOUCHER_SAFAR.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = RPTVOUCHER_TRISHA.Database.Tables
                    'ElseIf ClientName = "SHREEJI" Then
                    '    crTables = RPTVOUCHER_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = RPTVOUCHER_BARODA.Database.Tables
                ElseIf ClientName = "BELLA" Then
                    crTables = RPTVOUCHER_BELLA.Database.Tables

                ElseIf ClientName = "PRATAMESH" Then
                    crTables = RPTVOUCHER_PRATAMESH.Database.Tables
                ElseIf ClientName = "SSR" Then
                    crTables = RPTVOUCHER_SSR.Database.Tables
                ElseIf ClientName = "AERO" Then
                    crTables = RPTVOUCHER_AERO.Database.Tables
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    crTables = RPTVOUCHER_AIRTRINITY.Database.Tables
                ElseIf ClientName = "STARVISA" Then
                    crTables = RPTVOUCHER_STARVISA.Database.Tables
                    'ElseIf ClientName = "GLOBE" Then
                    '    crTables = RPTVOUCHER_GLOBE.Database.Tables
                    'ElseIf ClientName = "TNL" Then
                    '    crTables = RPTVOUCHER_TNL.Database.Tables
                    'ElseIf ClientName = "PRIYA" Then
                    '    crTables = RPTVOUCHER_PRIYA.Database.Tables
                ElseIf ClientName = "KPNT" Then
                    crTables = RPTVOUCHER_KPNT.Database.Tables
                    'ElseIf ClientName = "NAMASTE" Then
                    '    crTables = RPTVOUCHER_NAMASTE.Database.Tables
                ElseIf ClientName = "MILONI" Then
                    crTables = RPTVOUCHER_MILONI.Database.Tables
                ElseIf ClientName = "MATRIX" Then
                    crTables = RPTVOUCHER_MATRIX.Database.Tables
                ElseIf ClientName = "SKYMAPS" Then
                    crTables = RPTVOUCHER_SKYMAPS.Database.Tables
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    crTables = RPTVOUCHER_OFFBEAT.Database.Tables
                    'ElseIf ClientName = "LUXCREST" Then
                    '    crTables = RPTVOUCHER_LUXCREST.Database.Tables
                ElseIf ClientName = "HEENKAR" Then
                    crTables = RPTVOUCHER_HEENKAR.Database.Tables
                    'ElseIf ClientName = "ARHAM" Then
                    '    crTables = RPTVOUCHER_ARHAM.Database.Tables
                    'ElseIf ClientName = "ARUN" Then
                    '    crTables = RPTVOUCHER_ARUN.Database.Tables
                    'ElseIf ClientName = "HEERA" Then
                    '    crTables = RPTVOUCHER_HEERA.Database.Tables
                ElseIf ClientName = "RAMKRISHNA" Then
                    crTables = RPTVOUCHER_RAMKRISHNA.Database.Tables
                ElseIf ClientName = "URMI" Then
                    crTables = RPTVOUCHER_URMI.Database.Tables
                    'ElseIf ClientName = "SCC" Then
                    '    crTables = RPTVOUCHER_SCC.Database.Tables
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    crTables = RPTVOUCHER_WORLDSPIN.Database.Tables
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    crTables = RPTVOUCHER_MAHARAJA.Database.Tables
                Else
                    crTables = RPTVOUCHER_COMMON.Database.Tables
                End If
            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Invoice"

                'FOR COMMON REPORTS
                If ClientName = "CLASSIC" Then
                    crTables = RPTINVOICE.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = RPTINVOICE_TOP.Database.Tables
                ElseIf ClientName = "KHANNA" Then
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
                    'ElseIf ClientName = "ARHAM" Then
                    '    crTables = RPTINVOICE_ARHAM.Database.Tables
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
                    crTables = RPTINVOICE_COMMON.Database.Tables
                End If
            ElseIf FRMSTRING = "INVOICEOFFICE" Then
                Me.Text = "Hotel Booking Invoice"
                If ClientName = "SHREEJI" Then
                    'crTables = RPTINVOICEOFFICE_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = RPTINVOICEOFFICE_BARODA.Database.Tables
              
                End If

            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            strsearch = strsearch & " {HOTELBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {HOTELBOOKINGMASTER.BOOKING_BOOKTYPE}= '" & BOOKTYPE & "' and {HOTELBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch


            If FRMSTRING = "VOUCHER" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = RPTVOUCHER
                ElseIf ClientName = "TOPCOMM" Then

                    'If MTDC = False Then
                    '    RPTVOUCHER_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = LETTERHEAD
                    '    CRPO.ReportSource = RPTVOUCHER_TOP
                    'Else
                    '    CRPO.ReportSource = RPTVOUCHER_MTDCTOP
                    'End If

                ElseIf ClientName = "KHANNA" Then
                    CRPO.ReportSource = RPTVOUCHER_KHANNA
                ElseIf ClientName = "TRAVELBRIDGE" Then
                    CRPO.ReportSource = RPTVOUCHER_TRAVELBRIDGE
                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = RPTVOUCHER_SAFAR
                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = RPTVOUCHER_TRISHA
                    'ElseIf ClientName = "SHREEJI" Then
                    '    CRPO.ReportSource = RPTVOUCHER_SHREEJI
                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTVOUCHER_BARODA
                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = RPTVOUCHER_BELLA

                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = RPTVOUCHER_PRATAMESH
                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = RPTVOUCHER_SSR
                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = RPTVOUCHER_AERO
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = RPTVOUCHER_AIRTRINITY
                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = RPTVOUCHER_STARVISA
                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = RPTVOUCHER_GLOBE
                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = RPTVOUCHER_TNL
                    'ElseIf ClientName = "PRIYA" Then
                    '    CRPO.ReportSource = RPTVOUCHER_PRIYA
                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = RPTVOUCHER_KPNT
                    'ElseIf ClientName = "NAMASTE" Then
                    '    CRPO.ReportSource = RPTVOUCHER_NAMASTE
                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = RPTVOUCHER_MILONI
                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = RPTVOUCHER_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = RPTVOUCHER_SKYMAPS
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    CRPO.ReportSource = RPTVOUCHER_OFFBEAT
                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = RPTVOUCHER_LUXCREST
                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTVOUCHER_HEENKAR
                    'ElseIf ClientName = "ARHAM" Then
                    '    CRPO.ReportSource = RPTVOUCHER_ARHAM
                    'ElseIf ClientName = "ARUN" Then
                    '    CRPO.ReportSource = RPTVOUCHER_ARUN
                    'ElseIf ClientName = "HEERA" Then
                    '    CRPO.ReportSource = RPTVOUCHER_HEERA
                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTVOUCHER_RAMKRISHNA
                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = RPTVOUCHER_URMI
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = RPTVOUCHER_SCC
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    CRPO.ReportSource = RPTVOUCHER_WORLDSPIN
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = RPTVOUCHER_MAHARAJA
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTVOUCHER_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    CRPO.ReportSource = RPTVOUCHER_COMMON
                End If

            ElseIf FRMSTRING = "INVOICE" Then

                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = RPTINVOICE

                    If PRINTGUESTNAME = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = RPTINVOICE_TOP
                ElseIf ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    CRPO.ReportSource = RPTINVOICE_KHANNA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "SEASONED" Then
                    '    CRPO.ReportSource = RPTINVOICE_SEASONED
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = RPTINVOICE_SAFAR
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "SHREEJI" Then
                    '    CRPO.ReportSource = RPTINVOICE_SHREEJI
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICE_BARODA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = RPTINVOICE_BELLA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If



                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = RPTINVOICE_PRATAMESH
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = RPTINVOICE_SSR
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = RPTINVOICE_AERO
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = RPTINVOICE_AIRTRINITY
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = RPTINVOICE_STARVISA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = RPTINVOICE_GLOBE
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = RPTINVOICE_TNL
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "PRIYA" Then
                    '    CRPO.ReportSource = RPTINVOICE_PRIYA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = RPTINVOICE_KPNT
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "NAMASTE" Then
                    '    CRPO.ReportSource = RPTINVOICE_NAMASTE
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = RPTINVOICE_MILONI
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = RPTINVOICE_MATRIX
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = RPTINVOICE_SKYMAPS
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = RPTINVOICE_LUXCREST
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTINVOICE_HEENKAR
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "ARHAM" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARHAM
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTINVOICE_RAMKRISHNA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = RPTINVOICE_URMI
                    If PRINTGUESTNAME = True Then RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1 Else RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    If HIDEAMT = True Then RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTAMT").Text = 0 Else RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTAMT").Text = 1


                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = RPTINVOICE_SCC
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = RPTINVOICE_MAHARAJA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If


                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = RPTINVOICE_TRISHA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    CRPO.ReportSource = RPTINVOICE_COMMON
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If
                End If
            End If




            If FRMSTRING = "INVOICEOFFICE" Then
                If ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICEOFFICE_BARODA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
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

            strsearch = strsearch & " {HOTELBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {HOTELBOOKINGMASTER.BOOKING_BOOKTYPE}= '" & BOOKTYPE & "' and {HOTELBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Invoice"

                'FOR COMMON REPORTS
                If ClientName = "CLASSIC" Then
                    OBJ = New HotelBookingInvoice
                    OBJOLD = New HotelBookingInvoiceOLD
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    OBJ = New HotelBookingInvoice_Top
                    '    OBJOLD = New HotelBookingInvoice_TopOLD
                ElseIf ClientName = "KHANNA" Then
                    OBJ = New HotelBookingInvoice_KHANNA
                    OBJOLD = New HotelBookingInvoice_KHANNAOLD
                    'ElseIf ClientName = "SAFAR" Then
                    '    OBJ = New HotelBookingInvoice_SAFAR
                    '    OBJOLD = New HotelBookingInvoice_SAFAROLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New HotelBookingInvoice_TRISHA
                    OBJOLD = New HotelBookingInvoice_TRISHAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New HotelBookingInvoice_BARODA
                    OBJOLD = New HotelBookingInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New HotelBookingInvoice_BELLA
               
                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New HotelBookingInvoice_PRATHAMESH
                    OBJOLD = New HotelBookingInvoice_PRATHAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New HotelBookingInvoice_SSR
                    OBJOLD = New HotelBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New HotelBookingInvoice_AERO
                    OBJOLD = New HotelBookingInvoice_AEROOLD
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New HotelBookingInvoice_AIRTRINITY
                    '    OBJOLD = New HotelBookingInvoice_AIRTRINITYOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New HotelBookingInvoice_GLOBE
                    '    OBJOLD = New HotelBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New HotelBookingInvoice_TNL
                ElseIf ClientName = "MILONI" Then
                    OBJ = New HotelBookingInvoice_MILONI
                    OBJOLD = New HotelBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New HotelBookingInvoice_MATRIX
                    'ElseIf ClientName = "MANYA" Then
                    '    OBJ = New HotelBookingInvoice_MANYA
                    '    OBJOLD = New HotelBookingInvoice_MANYAOLD
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New HotelBookingInvoice_SKYMAPS
                    OBJOLD = New HotelBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New HotelBookingInvoice_LUXCREST
                    '    OBJOLD = New HotelBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New HotelBookingInvoice_HEENKAR
                    OBJOLD = New HotelBookingInvoice_HEENKAROLD
                    'ElseIf ClientName = "ARHAM" Then
                    '    OBJ = New HotelBookingInvoice_ARHAM
                    '    OBJOLD = New HotelBookingInvoice_ARHAMOLD
                ElseIf ClientName = "URMI" Then
                    OBJ = New HotelBookingInvoice_URMI
                    OBJOLD = New HotelBookingInvoice_URMIOLD
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New HotelBookingInvoice_MAHARAJA
                    '    OBJOLD = New HotelBookingInvoice_MAHARAJAOLD
                Else
                    OBJ = New HotelBookingInvoice_COMMON
                End If
            End If

            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "HOTELBOOKINGMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_BOOKTYPE = '" & BOOKTYPE & "' AND BOOKING_YEARID = " & YearId)
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
        Dim tempattachment As String = ""

        If FRMSTRING = "VOUCHER" Then
            If ClientName = "7HOSPITALITY" Then
                tempattachment = "Reservation Voucher No. 7HM-" & BOOKINGNO
            ElseIf ClientName = "TOPCOMM" Then
                tempattachment = SUBJECT
            Else
                tempattachment = "Reservation Voucher No. " & BOOKINGNO
            End If
        ElseIf FRMSTRING = "INVOICE" Then
            If ClientName = "7HOSPITALITY" Then
                tempattachment = "Invoice No. 7HM-" & BOOKINGNO
            Else
                tempattachment = "Invoice No. " & BOOKINGNO
            End If
        ElseIf FRMSTRING = "INVOICEOFFICE" Then
            If ClientName = "7HOSPITALITY" Then
                tempattachment = "Invoice No. 7HM-" & BOOKINGNO
            End If
        End If

        If ClientName = "TOPCOMM" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_EMAIL AS EMAILID", "", "  HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID ", " AND BOOKING_NO = " & BOOKINGNO & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
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


            'FOR SENCOND EMAIL ID
            If ClientName = "TOPCOMM" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER.HOTEL_EMAILID AS EMAILID", "", "  HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID ", " AND BOOKING_NO = " & BOOKINGNO & " AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then objmail.cmbsecondadd.Text = DT.Rows(0).Item("EMAILID")
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

            If FRMSTRING = "VOUCHER" Then

                If ClientName = "7HOSPITALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. 7HM-" & BOOKINGNO & ".PDF"
                ElseIf ClientName = "TOPCOMM" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\" & SUBJECT & ".PDF"
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. " & BOOKINGNO & ".PDF"
                End If
                If ClientName = "CLASSIC" Then
                    RPTVOUCHER.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER.Export()
                    RPTVOUCHER.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    If MTDC = False Then
                    '        RPTVOUCHER_TOP.DataDefinition.FormulaFields("SIGN").Text = 1
                    '        expo = RPTVOUCHER_TOP.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_TOP.Export()
                    '    Else
                    '        RPTVOUCHER_MTDCTOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_MTDCTOP.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_MTDCTOP.Export()
                    '    End If

                ElseIf ClientName = "KHANNA" Then
                    expo = RPTVOUCHER_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_KHANNA.Export()

                ElseIf ClientName = "TRAVELBRIDGE" Then
                    expo = RPTVOUCHER_TRAVELBRIDGE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_TRAVELBRIDGE.Export()

                    'ElseIf ClientName = "SAFAR" Then
                    '    expo = RPTVOUCHER_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_SAFAR.Export()

                    'ElseIf ClientName = "SHREEJI" Then
                    '    expo = RPTVOUCHER_SHREEJI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_SHREEJI.Export()

                ElseIf ClientName = "BARODA" Then
                    expo = RPTVOUCHER_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_BARODA.Export()

                ElseIf ClientName = "BELLA" Then
                    expo = RPTVOUCHER_BELLA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_BELLA.Export()




                ElseIf ClientName = "PRATAMESH" Then
                    expo = RPTVOUCHER_PRATAMESH.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_PRATAMESH.Export()

                ElseIf ClientName = "SSR" Then
                    RPTVOUCHER_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_SSR.Export()
                    RPTVOUCHER_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "AERO" Then
                    RPTVOUCHER_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_AERO.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_AERO.Export()
                    RPTVOUCHER_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    RPTVOUCHER_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_AIRTRINITY.Export()
                    '    RPTVOUCHER_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "STARVISA" Then
                    RPTVOUCHER_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_STARVISA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_STARVISA.Export()
                    RPTVOUCHER_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "GLOBE" Then
                    '    RPTVOUCHER_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_GLOBE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_GLOBE.Export()
                    '    RPTVOUCHER_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "TNL" Then
                    '    RPTVOUCHER_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_TNL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_TNL.Export()
                    '    RPTVOUCHER_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "PRIYA" Then
                    '    RPTVOUCHER_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_PRIYA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_PRIYA.Export()
                    '    RPTVOUCHER_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "KPNT" Then
                    RPTVOUCHER_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_KPNT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_KPNT.Export()
                    RPTVOUCHER_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "NAMASTE" Then
                    '    RPTVOUCHER_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_NAMASTE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_NAMASTE.Export()
                    '    RPTVOUCHER_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "MILONI" Then
                    RPTVOUCHER_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_MILONI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_MILONI.Export()
                    RPTVOUCHER_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                ElseIf ClientName = "MATRIX" Then
                    RPTVOUCHER_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_MATRIX.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_MATRIX.Export()
                    RPTVOUCHER_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "SKYMAPS" Then
                    RPTVOUCHER_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_SKYMAPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_SKYMAPS.Export()
                    RPTVOUCHER_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    RPTVOUCHER_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_OFFBEAT.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_OFFBEAT.Export()
                    '    RPTVOUCHER_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "LUXCREST" Then
                    '    RPTVOUCHER_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_LUXCREST.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_LUXCREST.Export()
                    '    RPTVOUCHER_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "HEENKAR" Then
                    RPTVOUCHER_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_HEENKAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_HEENKAR.Export()
                    RPTVOUCHER_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "ARHAM" Then
                    '    expo = RPTVOUCHER_ARHAM.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_ARHAM.Export()

                    'ElseIf ClientName = "ARUN" Then
                    '    expo = RPTVOUCHER_ARUN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_ARUN.Export()

                    'ElseIf ClientName = "HEERA" Then
                    '    RPTVOUCHER_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_HEERA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_HEERA.Export()
                    '    RPTVOUCHER_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "RAMKRISHNA" Then
                    RPTVOUCHER_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_RAMKRISHNA.Export()
                    RPTVOUCHER_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "URMI" Then
                    RPTVOUCHER_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                    expo = RPTVOUCHER_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_URMI.Export()
                    RPTVOUCHER_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True

                    'ElseIf ClientName = "SCC" Then
                    '    RPTVOUCHER_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_SCC.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_SCC.Export()
                    '    RPTVOUCHER_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    RPTVOUCHER_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_WORLDSPIN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_WORLDSPIN.Export()
                    '    RPTVOUCHER_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "MAHARAJA" Then
                    '    expo = RPTVOUCHER_MAHARAJA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_MAHARAJA.Export()

                ElseIf ClientName = "TRISHA" Then
                    RPTVOUCHER_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER_TRISHA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_TRISHA.Export()
                    RPTVOUCHER_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                Else
                    expo = RPTVOUCHER_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_COMMON.Export()

                End If
            ElseIf FRMSTRING = "INVOICE" Then

                If ClientName = "7HOSPITALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. 7HM-" & BOOKINGNO & ".PDF"
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                End If
                If ClientName = "CLASSIC" Then
                    RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE.Export()
                    RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    'RPTINVOICE_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_TOP.Export()

                ElseIf ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_KHANNA.Export()
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0


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

                    'ElseIf ClientName = "ARHAM" Then
                    '    expo = RPTINVOICE_ARHAM.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_ARHAM.Export()

                    'ElseIf ClientName = "ARUN" Then
                    '    expo = RPTINVOICE_ARUN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_ARUN.Export()

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
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box4").ObjectFormat.EnableSuppress = False
                    expo = RPTINVOICE_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_URMI.Export()
                    RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box4").ObjectFormat.EnableSuppress = True

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

                Else
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_COMMON.Export()
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                End If
            ElseIf FRMSTRING = "INVOICEOFFICE" Then
                'If ClientName = "SHREEJI" Then
                '    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No.-" & BOOKINGNO & ".PDF"
                '    RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                '    expo = RPTINVOICEOFFICE_SHREEJI.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTINVOICEOFFICE_SHREEJI.Export()
                If ClientName = "BARODA" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No.-" & BOOKINGNO & ".PDF"
                    RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICEOFFICE_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICEOFFICE_BARODA.Export()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class