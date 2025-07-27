
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class HolidayPackageVoucherDesign
    ''  ** VOUCHER **
    Dim rptvoucher As New HolidayPackageVoucher
    'Dim rptvoucher_TOP As New HolidayPackageVoucher_Top
    Dim rptvoucher_KHANNA As New HolidayPackageVoucher_KHANNA
    'Dim rptvoucher_SAFAR As New HolidayPackageVoucher_SAFAR
    Dim rptvoucher_TRISHA As New HolidayPackageVoucher_TRISHA
    Dim rptvoucher_BARODA As New HolidayPackageVoucher_BARODA
    Dim rptvoucher_BELLA As New HolidayPackageVoucher_BELLA
    Dim rptvoucher_COMMON As New HolidayPackageVoucher_COMMON
    Dim rptvoucher_PRATAMESH As New HolidayPackageVoucher_PRATAMESH
    Dim rptvoucher_SSR As New HolidayPackageVoucher_SSR
    Dim rptvoucher_AERO As New HolidayPackageVoucher_AERO
    'Dim rptvoucher_AIRTRINITY As New HolidayPackageVoucher_AIRTRINITY
    Dim rptvoucher_STARVISA As New HolidayPackageVoucher_STARVISA
    'Dim rptvoucher_GLOBE As New HolidayPackageVoucher_GLOBE
    'Dim rptvoucher_TNL As New HolidayPackageVoucher_TNL
    Dim rptvoucher_KPNT As New HolidayPackageVoucher_KPNT
    Dim rptvoucher_MILONI As New HolidayPackageVoucher_MILONI
    Dim rptvoucher_MATRIX As New HolidayPackageVoucher_MATRIX
    Dim rptvoucher_SKYMAPS As New HolidayPackageVoucher_SKYMAPS
    'Dim rptvoucher_LUXCREST As New HolidayPackageVoucher_LUXCREST
    Dim rptvoucher_HEENKAR As New HolidayPackageVoucher_COMMON
    Dim rptvoucher_RAMKRISHNA As New HolidayPackageVoucher_RAMKRISHNA
    Dim rptvoucher_URMI As New HolidayPackageVoucher_URMI
    Dim rptvehicle_URMI As New PackageBookingInvoice_URMI
    'Dim rptvoucher_SCC As New HolidayPackageVoucher_SCC
    'Dim rptvoucher_MAHARAJA As New HolidayPackageVoucher_MAHARAJA

    '' **INVOICE**

    Dim rptINVOICE As New HolidayPackageInvoice
    'Dim rptINVOICE_TOP As New HolidayPackageInvoice_Top
    Dim rptINVOICE_KHANNA As New HolidayPackageInvoice_KHANNA
    'Dim rptINVOICE_SAFAR As New HolidayPackageInvoice_SAFAR
    Dim rptINVOICE_TRISHA As New HolidayPackageInvoice_TRISHA
    Dim rptINVOICE_BARODA As New HolidayPackageInvoice_BARODA
    Dim rptINVOICE_BELLA As New HolidayPackageInvoice_BELLA
    Dim rptINVOICE_COMMON As New HolidayPackageInvoice_COMMON
    Dim rptINVOICE_PRATAMESH As New HolidayPackageInvoice_PRATHAMESH
    Dim rptINVOICE_NEW_PRATAMESH As New HolidayPackageInvoice_New_PRATAMESH
    Dim rptINVOICE_SSR As New HolidayPackageInvoice_SSR
    Dim rptINVOICE_AERO As New HolidayPackageInvoice_AERO
    'Dim rptINVOICE_AIRTRINITY As New HolidayPackageInvoice_AIRTRINITY
    Dim rptINVOICE_STARVISA As New HolidayPackageInvoice_STARVISA
    'Dim rptINVOICE_GLOBE As New HolidayPackageInvoice_GLOBE
    'Dim rptINVOICE_TNL As New HolidayPackageInvoice_TNL
    Dim rptINVOICE_KPNT As New HolidayPackageInvoice_KPNT
    Dim rptINVOICE_MILONI As New HolidayPackageInvoice_MILONI
    Dim rptINVOICE_MATRIX As New HolidayPackageInvoice_MATRIX
    Dim rptINVOICE_SKYMAPS As New HolidayPackageInvoice_SKYMAPS
    'Dim rptINVOICE_LUXCREST As New HolidayPackageInvoice_LUXCREST
    Dim RPTINVOICE_HEENKAR As New HolidayPackageInvoice_HEENKAR
    Dim rptINVOICE_RAMKRISHNA As New HolidayPackageInvoice_RAMKRISHNA
    Dim rptINVOICE_URMI As New HolidayPackageInvoice_URMI
    'Dim rptINVOICE_SCC As New HolidayPackageInvoice_SCC
    'Dim rptINVOICE_MAHARAJA As New HolidayPackageInvoice_MAHARAJA

    Dim RPTWELCOME_RAMKRISHNA As New CoveringLetter_RAMKRISHNA
    Dim RPTFEEDBACK_RAMKRISHNA As New Feedback_RAMKRISHNA

    Public strsearch As String
    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public BOOKINGDATE As Date
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public HIDEtransamt As Boolean
    Public hideheader As Boolean
    Public SUBJECT As String
    Public GUESTNAME As String = ""
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub HolidayPackageVoucherDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Me.Text = "Holiday Package Voucher"
                If ClientName = "CLASSIC" Then
                    crTables = rptvoucher.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = rptvoucher_TOP.Database.Tables
                ElseIf ClientName = "KHANNA" Then
                    crTables = rptvoucher_KHANNA.Database.Tables
                    'ElseIf ClientName = "SEASONED" Then
                    '    crTables = rptvoucher_SEASONED.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = rptvoucher_SAFAR.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = rptvoucher_TRISHA.Database.Tables
                ElseIf ClientName = "SHREEJI" Then
                    'crTables = rptvoucher_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = rptvoucher_BARODA.Database.Tables
                ElseIf ClientName = "BELLA" Then
                    crTables = rptvoucher_BELLA.Database.Tables

                ElseIf ClientName = "PRATAMESH" Then
                    crTables = rptvoucher_PRATAMESH.Database.Tables
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    crTables = rptvoucher_MAHARAJA.Database.Tables
                ElseIf ClientName = "SSR" Then
                    crTables = rptvoucher_SSR.Database.Tables
                ElseIf ClientName = "AERO" Then
                    crTables = rptvoucher_AERO.Database.Tables
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    crTables = rptvoucher_AIRTRINITY.Database.Tables
                ElseIf ClientName = "STARVISA" Then
                    crTables = rptvoucher_STARVISA.Database.Tables
                    'ElseIf ClientName = "GLOBE" Then
                    '    crTables = rptvoucher_GLOBE.Database.Tables
                    'ElseIf ClientName = "TNL" Then
                    '    crTables = rptvoucher_TNL.Database.Tables
                    'ElseIf ClientName = "PRIYA" Then
                    ' crTables = rptvoucher_PRIYA.Database.Tables
                ElseIf ClientName = "KPNT" Then
                    crTables = rptvoucher_KPNT.Database.Tables
                ElseIf ClientName = "NAMASTE" Then
                    ' crTables = rptvoucher_NAMASTE.Database.Tables
                ElseIf ClientName = "MILONI" Then
                    crTables = rptvoucher_MILONI.Database.Tables
                ElseIf ClientName = "MATRIX" Then
                    crTables = rptvoucher_MATRIX.Database.Tables
                ElseIf ClientName = "BHAGYASHRI" Then
                    '  crTables = rptvoucher_BHAGYASHRI.Database.Tables
                ElseIf ClientName = "WAHWAH" Then
                    ' crTables = rptvoucher_WAHWAH.Database.Tables
                ElseIf ClientName = "MANYA" Then
                    ' crTables = rptvoucher_MANYA.Database.Tables
                ElseIf ClientName = "WHITEPEARL" Then
                    '  crTables = rptvoucher_WHITEPEARL.Database.Tables
                ElseIf ClientName = "SKYMAPS" Then
                    crTables = rptvoucher_SKYMAPS.Database.Tables
                ElseIf ClientName = "OFFBEAT" Then
                    '  crTables = rptvoucher_OFFBEAT.Database.Tables
                    'ElseIf ClientName = "LUXCREST" Then
                    '    crTables = rptvoucher_LUXCREST.Database.Tables
                ElseIf ClientName = "HEENKAR" Then
                    crTables = rptvoucher_HEENKAR.Database.Tables
                ElseIf ClientName = "ARUN" Then
                    '  crTables = rptvoucher_ARUN.Database.Tables
                ElseIf ClientName = "HEERA" Then
                    ' crTables = rptvoucher_HEERA.Database.Tables
                ElseIf ClientName = "RAMKRISHNA" Then
                    crTables = rptvoucher_RAMKRISHNA.Database.Tables
                ElseIf ClientName = "URMI" Then
                    crTables = rptvoucher_URMI.Database.Tables
                    'ElseIf ClientName = "SCC" Then
                    '    crTables = rptvoucher_SCC.Database.Tables
                ElseIf ClientName = "WORLDSPIN" Then
                    ' crTables = rptvoucher_WORLDSPIN.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        rptvoucher_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = rptvoucher_COMMON.Database.Tables
                End If

            ElseIf FRMSTRING = "COVER" Then
                Me.Text = "Holiday Package Cover Letter"
                If ClientName = "RAMKRISHNA" Then
                    crTables = RPTWELCOME_RAMKRISHNA.Database.Tables
                End If

            ElseIf FRMSTRING = "FEEDBACK" Then
                Me.Text = "Tour Evaluation Form"
                If ClientName = "RAMKRISHNA" Then
                    crTables = RPTFEEDBACK_RAMKRISHNA.Database.Tables
                End If

            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "Holiday Package Invoice"
                If ClientName = "CLASSIC" Then
                    crTables = rptINVOICE.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = rptINVOICE_TOP.Database.Tables
                ElseIf ClientName = "KHANNA" Then
                    crTables = rptINVOICE_KHANNA.Database.Tables
                ElseIf ClientName = "SEASONED" Then
                    ' crTables = rptINVOICE_SEASONED.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = rptINVOICE_SAFAR.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = rptINVOICE_TRISHA.Database.Tables
                ElseIf ClientName = "SHREEJI" Then
                    ' crTables = rptINVOICE_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = rptINVOICE_BARODA.Database.Tables
                ElseIf ClientName = "BELLA" Then
                    crTables = rptINVOICE_BELLA.Database.Tables

                ElseIf ClientName = "PRATAMESH" Then
                    crTables = rptINVOICE_PRATAMESH.Database.Tables
                ElseIf ClientName = "SSR" Then
                    crTables = rptINVOICE_SSR.Database.Tables
                ElseIf ClientName = "AERO" Then
                    crTables = rptINVOICE_AERO.Database.Tables
                ElseIf ClientName = "APPLE" Then
                    '  crTables = rptINVOICE_APPLE.Database.Tables
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    crTables = rptINVOICE_AIRTRINITY.Database.Tables
                ElseIf ClientName = "STARVISA" Then
                    crTables = rptINVOICE_STARVISA.Database.Tables
                    'ElseIf ClientName = "GLOBE" Then
                    '    crTables = rptINVOICE_GLOBE.Database.Tables
                    'ElseIf ClientName = "TNL" Then
                    '    crTables = rptINVOICE_TNL.Database.Tables
                ElseIf ClientName = "PRIYA" Then
                    '  crTables = rptINVOICE_PRIYA.Database.Tables
                ElseIf ClientName = "KPNT" Then
                    crTables = rptINVOICE_KPNT.Database.Tables
                ElseIf ClientName = "NAMASTE" Then
                    'crTables = rptINVOICE_NAMASTE.Database.Tables
                ElseIf ClientName = "MILONI" Then
                    crTables = rptINVOICE_MILONI.Database.Tables
                ElseIf ClientName = "MATRIX" Then
                    crTables = rptINVOICE_MATRIX.Database.Tables
                ElseIf ClientName = "BHAGYASHRI" Then
                    '  crTables = rptINVOICE_BHAGYASHRI.Database.Tables
                ElseIf ClientName = "WAHWAH" Then
                    '   crTables = rptINVOICE_WAHWAH.Database.Tables
                ElseIf ClientName = "MANYA" Then
                    '  crTables = rptINVOICE_MANYA.Database.Tables
                ElseIf ClientName = "WHITEPEARL" Then
                    'crTables = rptINVOICE_WHITEPEARL.Database.Tables
                ElseIf ClientName = "SKYMAPS" Then
                    crTables = rptINVOICE_SKYMAPS.Database.Tables
                ElseIf ClientName = "OFFBEAT" Then
                    'crTables = rptINVOICE_OFFBEAT.Database.Tables
                    'ElseIf ClientName = "LUXCREST" Then
                    '    crTables = rptINVOICE_LUXCREST.Database.Tables
                ElseIf ClientName = "HEENKAR" Then
                    crTables = RPTINVOICE_HEENKAR.Database.Tables
                ElseIf ClientName = "ARUN" Then
                    '  crTables = RPTINVOICE_ARUN.Database.Tables
                ElseIf ClientName = "HEERA" Then
                    ' crTables = rptINVOICE_HEERA.Database.Tables
                ElseIf ClientName = "RAMKRISHNA" Then
                    crTables = rptINVOICE_RAMKRISHNA.Database.Tables
                ElseIf ClientName = "URMI" Then
                    crTables = rptINVOICE_URMI.Database.Tables

                    'ElseIf ClientName = "SCC" Then
                    '    crTables = rptINVOICE_SCC.Database.Tables
                ElseIf ClientName = "WORLDSPIN" Then
                    ' crTables = rptINVOICE_WORLDSPIN.Database.Tables
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    crTables = rptINVOICE_MAHARAJA.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        rptINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = rptINVOICE_COMMON.Database.Tables
                End If

            ElseIf FRMSTRING = "PRATAMESHNEWINVOICE" Then
                If ClientName = "PRATAMESH" Then
                    crTables = rptINVOICE_NEW_PRATAMESH.Database.Tables
                End If

            ElseIf FRMSTRING = "VEHICLEINVOICE" Then
                If ClientName = "URMI" Then
                    crTables = rptvehicle_URMI.Database.Tables
                End If
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            'strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {HOLIDAYPACKAGEMASTER.BOOKING_cmpid}=" & CmpId & " and {HOLIDAYPACKAGEMASTER.BOOKING_locationid}=" & Locationid & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId
            strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId

            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "VOUCHER" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = rptvoucher
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = rptvoucher_TOP
                ElseIf ClientName = "KHANNA" Then
                    CRPO.ReportSource = rptvoucher_KHANNA
                ElseIf ClientName = "SEASONED" Then
                    'CRPO.ReportSource = rptvoucher_SEASONED
                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = rptvoucher_SAFAR
                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = rptvoucher_TRISHA
                ElseIf ClientName = "SHREEJI" Then
                    ' CRPO.ReportSource = rptvoucher_SHREEJI
                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = rptvoucher_BARODA
                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = rptvoucher_BELLA

                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = rptvoucher_PRATAMESH
                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = rptvoucher_SSR
                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = rptvoucher_AERO
                ElseIf ClientName = "APPLE" Then
                    '  CRPO.ReportSource = rptvoucher_APPLE
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = rptvoucher_AIRTRINITY
                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = rptvoucher_STARVISA
                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = rptvoucher_GLOBE
                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = rptvoucher_TNL
                ElseIf ClientName = "PRIYA" Then
                    ' CRPO.ReportSource = rptvoucher_PRIYA
                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = rptvoucher_KPNT
                ElseIf ClientName = "NAMASTE" Then
                    '  CRPO.ReportSource = rptvoucher_NAMASTE
                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = rptvoucher_MILONI
                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = rptvoucher_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = rptvoucher_SKYMAPS
                ElseIf ClientName = "OFFBEAT" Then
                    'CRPO.ReportSource = rptvoucher_OFFBEAT
                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = rptvoucher_LUXCREST
                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = rptvoucher_HEENKAR
                ElseIf ClientName = "ARUN" Then
                    '  CRPO.ReportSource = rptvoucher_ARUN
                ElseIf ClientName = "HEERA" Then
                    'CRPO.ReportSource = rptvoucher_HEERA
                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = rptvoucher_RAMKRISHNA
                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = rptvoucher_URMI
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = rptvoucher_SCC
                ElseIf ClientName = "WORLDSPIN" Then
                    ' CRPO.ReportSource = rptvoucher_WORLDSPIN
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = rptvoucher_MAHARAJA
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        rptvoucher_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    CRPO.ReportSource = rptvoucher_COMMON
                End If

            ElseIf FRMSTRING = "COVER" Then
                If ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTWELCOME_RAMKRISHNA
                End If

            ElseIf FRMSTRING = "FEEDBACK" Then
                If ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTFEEDBACK_RAMKRISHNA
                End If

            ElseIf FRMSTRING = "PRATAMESHNEWINVOICE" Then

                If ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = rptINVOICE_NEW_PRATAMESH

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_NEW_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_NEW_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_NEW_PRATAMESH.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_NEW_PRATAMESH").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_NEW_PRATAMESH.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_NEW_PRATAMESH").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_NEW_PRATAMESH.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_NEW_PRATAMESH.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If
                End If

            ElseIf FRMSTRING = "VEHICLEINVOICE" Then
                If ClientName = "URMI" Then
                    CRPO.ReportSource = rptvehicle_URMI
                    rptvehicle_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                End If

            ElseIf FRMSTRING = "INVOICE" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = rptINVOICE

                    If PRINTGUESTNAME = True Then
                        rptINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If HIDEAMT = True Then
                        rptINVOICE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = rptINVOICE_TOP

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_TOP.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_TOP.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If


                ElseIf ClientName = "KHANNA" Then
                    rptINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    CRPO.ReportSource = rptINVOICE_KHANNA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_KHANNA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_KHANNA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_KHANNA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_KHANNA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "SEASONED" Then
                    '    CRPO.ReportSource = rptINVOICE_SEASONED

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_SEASONED.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SEASONED").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SEASONED.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SEASONED").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = rptINVOICE_SAFAR

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_SAFAR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SAFAR").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SAFAR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SAFAR").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = rptINVOICE_TRISHA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_TRISHA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TRISHA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_TRISHA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TRISHA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "SHREEJI" Then
                    '    CRPO.ReportSource = rptINVOICE_SHREEJI

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_SHREEJI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SHREEJI").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SHREEJI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SHREEJI").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = rptINVOICE_BARODA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_BARODA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_BARODA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_BARODA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_BARODA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_BARODA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_BARODA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = rptINVOICE_BELLA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_BELLA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_BELLA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_BELLA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_BELLA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_BELLA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_BELLA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If



                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = rptINVOICE_PRATAMESH

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_PRATAMESH.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_PRATAMESH").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_PRATAMESH.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_PRATAMESH").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = rptINVOICE_SSR

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_SSR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SSR").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_SSR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SSR").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_SSR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_SSR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = rptINVOICE_AERO

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_AERO.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_AERO").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_AERO.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_AERO").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_AERO.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_AERO.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If


                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = rptINVOICE_AIRTRINITY

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_AIRTRINITY.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_AIRTRINITY").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_AIRTRINITY.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_AIRTRINITY").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = rptINVOICE_STARVISA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_STARVISA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_STARVISA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_STARVISA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_STARVISA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = rptINVOICE_GLOBE

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_GLOBE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_GLOBE").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_GLOBE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_GLOBE").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = rptINVOICE_TNL

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_TNL.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TNL").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_TNL.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TNL").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_TNL.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_TNL.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "PRIYA" Then
                    '    CRPO.ReportSource = rptINVOICE_PRIYA

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_PRIYA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_PRIYA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_PRIYA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_PRIYA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = rptINVOICE_KPNT

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_KPNT.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_KPNT").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_KPNT.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_KPNT").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_KPNT.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_KPNT.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                    'ElseIf ClientName = "NAMASTE" Then
                    '    CRPO.ReportSource = rptINVOICE_NAMASTE

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_NAMASTE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_NAMASTE").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_NAMASTE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_NAMASTE").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = rptINVOICE_MILONI

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_MILONI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MILONI").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_MILONI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MILONI").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_MILONI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_MILONI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = rptINVOICE_MATRIX

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_MATRIX.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MATRIX").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_MATRIX.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MATRIX").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If


                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = rptINVOICE_SKYMAPS

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        rptINVOICE_SKYMAPS.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SKYMAPS").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        rptINVOICE_SKYMAPS.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SKYMAPS").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    CRPO.ReportSource = rptINVOICE_OFFBEAT

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_OFFBEAT.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_OFFBEAT").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_OFFBEAT.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_OFFBEAT").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = rptINVOICE_LUXCREST

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_LUXCREST.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_LUXCREST").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_LUXCREST.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_LUXCREST").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTINVOICE_HEENKAR

                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEAMT = True Then
                        RPTINVOICE_HEENKAR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_HEENKAR").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE_HEENKAR.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_HEENKAR").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    If HIDEtransamt = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                    'ElseIf ClientName = "ARUN" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARUN

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_ARUN.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_ARUN").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_ARUN.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_ARUN").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "HEERA" Then
                    '    CRPO.ReportSource = rptINVOICE_HEERA

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_HEERA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_HEERA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_HEERA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_HEERA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_HEERA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_HEERA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = rptINVOICE_RAMKRISHNA

                    If PRINTGUESTNAME = True Then
                        rptINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        rptINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If

                    If HIDEtransamt = True Then
                        rptINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    Else
                        rptINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    End If

                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = rptINVOICE_URMI
                    If PRINTGUESTNAME = True Then rptINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1 Else rptINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    If HIDEAMT = True Then rptINVOICE_URMI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_URMI").DataDefinition.FormulaFields("PRINTAMT").Text = 0 Else rptINVOICE_URMI.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_URMI").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    If HIDEtransamt = True Then rptINVOICE_URMI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0 Else rptINVOICE_URMI.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1


                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = rptINVOICE_SCC

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_SCC.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SCC").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SCC.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_SCC").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_SCC.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_SCC.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If


                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    CRPO.ReportSource = rptINVOICE_WORLDSPIN

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_WORLDSPIN.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_WORLDSPIN").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_WORLDSPIN.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_WORLDSPIN").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = rptINVOICE_MAHARAJA

                    '    If PRINTGUESTNAME = True Then
                    '        rptINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        rptINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If

                    '    If HIDEAMT = True Then
                    '        rptINVOICE_MAHARAJA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MAHARAJA").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        rptINVOICE_MAHARAJA.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_MAHARAJA").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    '    If HIDEtransamt = True Then
                    '        rptINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                    '    Else
                    '        rptINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
                    '    End If

                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        rptINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    CRPO.ReportSource = rptINVOICE_COMMON

                    If PRINTGUESTNAME = True Then
                            rptINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                        Else
                            rptINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                        End If

                        If HIDEAMT = True Then
                            rptINVOICE_COMMON.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_COMMON").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                        Else
                            rptINVOICE_COMMON.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_COMMON").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                        End If

                        If HIDEtransamt = True Then
                            rptINVOICE_COMMON.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 0
                        Else
                            rptINVOICE_COMMON.DataDefinition.FormulaFields("PRINTTRANSAMT").Text = 1
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

            'strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {HOLIDAYPACKAGEMASTER.BOOKING_cmpid}=" & CmpId & " and {HOLIDAYPACKAGEMASTER.BOOKING_locationid}=" & Locationid & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId
            strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId

            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Invoice"

                'FOR COMMON REPORTS
                If ClientName = "CLASSIC" Then
                    OBJ = New HolidayPackageInvoice
                    OBJOLD = New HolidayPackageInvoice_OLD

                ElseIf ClientName = "KHANNA" Then
                    OBJ = New HolidayPackageInvoice_KHANNA
                    OBJOLD = New HolidayPackageInvoice_KHANNAOLD
                    'ElseIf ClientName = "SAFAR" Then
                    '    OBJ = New HolidayPackageInvoice_SAFAR
                    '    OBJOLD = New HolidayPackageInvoice_SAFAROLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New HolidayPackageInvoice_TRISHA
                    OBJOLD = New HolidayPackageInvoice_TRISHAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New HolidayPackageInvoice_BARODA
                    OBJOLD = New HolidayPackageInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New HolidayPackageInvoice_BELLA

                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New HolidayPackageInvoice_PRATHAMESH
                    OBJOLD = New HolidayPackageInvoice_PRATAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New HolidayPackageInvoice_SSR
                    OBJOLD = New HolidayPackageInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New HolidayPackageInvoice_AERO
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New HolidayPackageInvoice_AIRTRINITY
                    '    OBJOLD = New HolidayPackageInvoice_AIRTRINITYOLD

                ElseIf ClientName = "STARVISA" Then
                    OBJ = New HolidayPackageInvoice_STARVISA
                    OBJOLD = New HolidayPackageInvoice_STARVISAOLD

                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New HolidayPackageInvoice_GLOBE
                    '    OBJOLD = New HolidayPackageInvoice_GLOBEOLD

                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New HolidayPackageInvoice_TNL

                ElseIf ClientName = "KPNT" Then
                    OBJ = New HolidayPackageInvoice_KPNT
                    OBJOLD = New HolidayPackageInvoice_KPNTOLD


                ElseIf ClientName = "MILONI" Then
                    OBJ = New HolidayPackageInvoice_MILONI
                    OBJOLD = New HolidayPackageInvoice_MILONIOLD

                ElseIf ClientName = "MATRIX" Then
                    OBJ = New HolidayPackageInvoice_MATRIX

                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New HolidayPackageInvoice_SKYMAPS
                    OBJOLD = New HolidayPackageInvoice_SKYMAPSOLD

                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New HolidayPackageInvoice_LUXCREST
                    '    OBJOLD = New HolidayPackageInvoice_LUXCRESTOLD

                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New HolidayPackageInvoice_HEENKAR
                    OBJOLD = New HolidayPackageInvoice_HEENKAROLD

                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New HolidayPackageInvoice_RAMKRISHNA
                    OBJOLD = New HolidayPackageInvoice_RAMKRISHNAOLD

                ElseIf ClientName = "URMI" Then
                    OBJ = New HolidayPackageInvoice_URMI
                    OBJOLD = New HolidayPackageInvoice_URMIOLD
                    'ElseIf ClientName = "SCC" Then
                    '    OBJ = New HolidayPackageInvoice_SCC

                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New HolidayPackageInvoice_MAHARAJA
                    '    OBJOLD = New HolidayPackageInvoice_MAHARAJAOLD

                Else
                    OBJ = New HolidayPackageInvoice_COMMON
                End If

            End If

            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "HOLIDAYPACKAGEMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
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
            'crTables = OBJ.Database.Tables

            'For Each crTable In crTables
            '    crtableLogonInfo = crTable.LogOnInfo
            '    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            '    crTable.ApplyLogOnInfo(crtableLogonInfo)
            'Next

            'OBJ.RecordSelectionFormula = strsearch
            'OBJ.PrintToPrinter(1, True, 0, 0)
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
            tempattachment = "Reservation Voucher No. " & BOOKINGNO
        ElseIf FRMSTRING = "INVOICE" Then
            tempattachment = "Invoice No. " & BOOKINGNO
        ElseIf FRMSTRING = "VEHICLEINVOICE" Then
            tempattachment = "Reservation Voucher No. " & BOOKINGNO
        ElseIf FRMSTRING = "COVER" Then
            tempattachment = "Welcome Letter"
        ElseIf FRMSTRING = "FEEDBACK" Then
            tempattachment = "Feedback Form"
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

            If FRMSTRING = "VOUCHER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    rptvoucher.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher.Export()
                    rptvoucher.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    rptvoucher_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_TOP.Export()
                ElseIf ClientName = "KHANNA" Then
                    rptvoucher_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_KHANNA.Export()
                    'ElseIf ClientName = "SEASONED" Then
                    '    rptvoucher_SEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_SEASONED.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_SEASONED.Export()
                    'ElseIf ClientName = "SAFAR" Then
                    '    rptvoucher_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_SAFAR.Export()
                ElseIf ClientName = "TRISHA" Then
                    rptvoucher_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_TRISHA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_TRISHA.Export()

                    'ElseIf ClientName = "SHREEJI" Then
                    '    rptvoucher_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_SHREEJI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_SHREEJI.Export()
                ElseIf ClientName = "BARODA" Then
                    rptvoucher_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_BARODA.Export()
                ElseIf ClientName = "BELLA" Then
                    rptvoucher_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_BELLA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_BELLA.Export()

                ElseIf ClientName = "PRATAMESH" Then
                    rptvoucher_PRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_PRATAMESH.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_PRATAMESH.Export()
                ElseIf ClientName = "SSR" Then
                    rptvoucher_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_SSR.Export()
                ElseIf ClientName = "AERO" Then
                    rptvoucher_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_AERO.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_AERO.Export()
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    rptvoucher_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_AIRTRINITY.Export()

                ElseIf ClientName = "STARVISA" Then
                    rptvoucher_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_STARVISA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_STARVISA.Export()

                    'ElseIf ClientName = "GLOBE" Then
                    '    rptvoucher_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_GLOBE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_GLOBE.Export()


                    'ElseIf ClientName = "TNL" Then
                    '    rptvoucher_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_TNL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_TNL.Export()

                    'ElseIf ClientName = "PRIYA" Then
                    '    rptvoucher_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_PRIYA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_PRIYA.Export()

                ElseIf ClientName = "KPNT" Then
                    rptvoucher_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_KPNT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_KPNT.Export()


                    'ElseIf ClientName = "NAMASTE" Then
                    '    rptvoucher_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_NAMASTE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_NAMASTE.Export()

                ElseIf ClientName = "MILONI" Then
                    rptvoucher_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_MILONI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_MILONI.Export()

                ElseIf ClientName = "MATRIX" Then
                    rptvoucher_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_MATRIX.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_MATRIX.Export()

                ElseIf ClientName = "SKYMAPS" Then
                    rptvoucher_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_SKYMAPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_SKYMAPS.Export()

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    rptvoucher_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_OFFBEAT.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_OFFBEAT.Export()

                    'ElseIf ClientName = "LUXCREST" Then
                    '    rptvoucher_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_LUXCREST.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_LUXCREST.Export()

                ElseIf ClientName = "HEENKAR" Then
                    rptvoucher_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_HEENKAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_HEENKAR.Export()
                    'ElseIf ClientName = "ARUN" Then
                    '    rptvoucher_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_ARUN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_ARUN.Export()
                    'ElseIf ClientName = "HEERA" Then
                    '    rptvoucher_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_HEERA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_HEERA.Export()
                ElseIf ClientName = "RAMKRISHNA" Then
                    rptvoucher_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_RAMKRISHNA.Export()
                ElseIf ClientName = "URMI" Then
                    rptvoucher_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                    expo = rptvoucher_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_URMI.Export()
                    rptvoucher_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    rptvoucher_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    rptvoucher_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_SCC.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_SCC.Export()
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    rptvoucher_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_WORLDSPIN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_WORLDSPIN.Export()
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    rptvoucher_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptvoucher_MAHARAJA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptvoucher_MAHARAJA.Export()
                Else
                    rptvoucher_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptvoucher_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvoucher_COMMON.Export()
                End If


            ElseIf FRMSTRING = "INVOICE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    rptINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE.Export()
                    rptINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    rptINVOICE_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_TOP.Export()
                ElseIf ClientName = "KHANNA" Then
                    rptINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_KHANNA.Export()
                    'ElseIf ClientName = "SEASONED" Then
                    '    rptINVOICE_SEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_SEASONED.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_SEASONED.Export()
                    'ElseIf ClientName = "SAFAR" Then
                    '    rptINVOICE_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_SAFAR.Export()

                ElseIf ClientName = "TRISHA" Then
                    rptINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_TRISHA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_TRISHA.Export()
                    rptINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "SHREEJI" Then
                    '    rptINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_SHREEJI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_SHREEJI.Export()
                    '    rptINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BARODA" Then
                    rptINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_BARODA.Export()
                    rptINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BELLA" Then
                    rptINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_BELLA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_BELLA.Export()
                    rptINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                ElseIf ClientName = "PRATAMESH" Then
                    rptINVOICE_PRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_PRATAMESH.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_PRATAMESH.Export()
                ElseIf ClientName = "SSR" Then
                    rptINVOICE_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_SSR.Export()
                ElseIf ClientName = "AERO" Then
                    rptINVOICE_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_AERO.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_AERO.Export()


                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    rptINVOICE_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_AIRTRINITY.Export()

                ElseIf ClientName = "STARVISA" Then
                    rptINVOICE_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_STARVISA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_STARVISA.Export()

                    'ElseIf ClientName = "GLOBE" Then
                    '    rptINVOICE_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_GLOBE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_GLOBE.Export()

                    'ElseIf ClientName = "TNL" Then
                    '    rptINVOICE_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_TNL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_TNL.Export()

                    'ElseIf ClientName = "PRIYA" Then
                    '    rptINVOICE_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_PRIYA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_PRIYA.Export()

                ElseIf ClientName = "KPNT" Then
                    rptINVOICE_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_KPNT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_KPNT.Export()


                    'ElseIf ClientName = "NAMASTE" Then
                    '    rptINVOICE_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_NAMASTE.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_NAMASTE.Export()

                ElseIf ClientName = "MILONI" Then
                    rptINVOICE_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_MILONI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_MILONI.Export()

                ElseIf ClientName = "MATRIX" Then
                    rptINVOICE_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_MATRIX.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_MATRIX.Export()


                ElseIf ClientName = "SKYMAPS" Then
                    rptINVOICE_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_SKYMAPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_SKYMAPS.Export()
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    rptINVOICE_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_OFFBEAT.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_OFFBEAT.Export()
                    'ElseIf ClientName = "LUXCREST" Then
                    '    rptINVOICE_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_LUXCREST.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_LUXCREST.Export()
                ElseIf ClientName = "HEENKAR" Then
                    RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_HEENKAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_HEENKAR.Export()
                    'ElseIf ClientName = "ARUN" Then
                    '    RPTINVOICE_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_ARUN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_ARUN.Export()
                    'ElseIf ClientName = "HEERA" Then
                    '    rptINVOICE_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_HEERA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_HEERA.Export()
                ElseIf ClientName = "RAMKRISHNA" Then
                    rptINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_RAMKRISHNA.Export()
                ElseIf ClientName = "URMI" Then
                    rptINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box7").ObjectFormat.EnableSuppress = False
                    expo = rptINVOICE_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_URMI.Export()
                    rptINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'rptINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box7").ObjectFormat.EnableSuppress = True
                    'ElseIf ClientName = "SCC" Then
                    '    rptINVOICE_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_SCC.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_SCC.Export()
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    rptINVOICE_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_WORLDSPIN.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_WORLDSPIN.Export()
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    rptINVOICE_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = rptINVOICE_MAHARAJA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    rptINVOICE_MAHARAJA.Export()
                Else
                    rptINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = rptINVOICE_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptINVOICE_COMMON.Export()
                    rptINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                End If
            ElseIf FRMSTRING = "VEHICLEINVOICE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Reservation Voucher No. " & BOOKINGNO & ".PDF"
                If ClientName = "URMI" Then
                    rptvehicle_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    rptvehicle_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    expo = rptvehicle_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptvehicle_URMI.Export()
                    rptvehicle_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    rptvehicle_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                End If

            ElseIf FRMSTRING = "COVER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Welcome Letter.PDF"
                If ClientName = "RAMKRISHNA" Then
                    expo = RPTWELCOME_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTWELCOME_RAMKRISHNA.Export()
                End If

            ElseIf FRMSTRING = "FEEDBACK" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Feedback Form.PDF"
                If ClientName = "RAMKRISHNA" Then
                    expo = RPTFEEDBACK_RAMKRISHNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFEEDBACK_RAMKRISHNA.Export()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


End Class