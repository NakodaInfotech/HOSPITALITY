
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class CarBookingVoucherDesign

    Dim RPTVOUCHER As New CarBookingVoucher
    'Dim RPTVOUCHER_TOP As New CarBookingVoucher_Top
    'Dim RPTVOUCHER_MTDCTOP As New MTDCVoucher_Top
    'Dim RPTVOUCHER_PACKAGETOP As New PackageBookingVoucher_Top
    Dim RPTVOUCHER_KHANNA As New CarBookingVoucher_KHANNA
    Dim RPTVOUCHER_CARVOUCHERSTR As New CarBookingVoucher_NEWKHANNA
    'Dim RPTVOUCHER_SEASONED As New CarBookingVoucher_Seasoned
    'Dim RPTVOUCHER_PACKAGESEASONED As New PackageBookingVoucher_SEASONED
    'Dim RPTVOUCHER_SAFAR As New CarBookingVoucher_SAFAR
    'Dim RPTVOUCHER_PACKAGESAFAR As New PackageBookingVoucher_SAFAR
    Dim RPTVOUCHER_TRISHA As New CarBookingVoucher_TRISHA
    Dim RPTVOUCHER_PACKAGETRISHA As New PackageBookingVoucher_TRISHA
    'Dim RPTVOUCHER_SHREEJI As New CarBookingVoucher_SHREEJI
    'Dim RPTVOUCHER_PACKAGESHREEJI As New PackageBookingVoucher_SHREEJI
    Dim RPTVOUCHER_BARODA As New CarBookingVoucher_BARODA
    Dim RPTVOUCHER_PACKAGEBARODA As New PackageBookingVoucher_BARODA
    Dim RPTVOUCHER_BELLA As New CarBookingVoucher_BELLA
    Dim RPTVOUCHER_PACKAGEBELLA As New PackageBookingVoucher_BELLA
    Dim RPTVOUCHER_COMMON As New CarBookingVoucher_COMMON
    Dim RPTVOUCHER_PACKAGECOMMON As New PackageBookingVoucher_COMMON
    Dim RPTVOUCHER_PRATAMESH As New CarBookingVoucher_PRATAMESH
    Dim RPTVOUCHER_PACKAGEPRATAMESH As New PackageBookingVoucher_PRATAMESH
    Dim RPTVOUCHER_SSR As New CarBookingVoucher_SSR
    Dim RPTVOUCHER_PACKAGESSR As New PackageBookingVoucher_SSR
    Dim RPTVOUCHER_AERO As New CarBookingVoucher_AERO
    Dim RPTVOUCHER_PACKAGEAERO As New PackageBookingVoucher_AERO
    'Dim RPTVOUCHER_AIRTRINITY As New CarBookingVoucher_AIRTRINITY
    'Dim RPTVOUCHER_PACKAGEAIRTRINITY As New PackageBookingVoucher_AIRTRINITY
    'Dim RPTVOUCHER_APPLE As New CarBookingVoucher_APPLE
    'Dim RPTVOUCHER_PACKAGEAPPLE As New PackageBookingVoucher_APPLE
    Dim RPTVOUCHER_STARVISA As New CarBookingVoucher_STARVISA
    Dim RPTVOUCHER_PACKAGESTARVISA As New PackageBookingVoucher_STARVISA
    'Dim RPTVOUCHER_GLOBE As New CarBookingVoucher_GLOBE
    'Dim RPTVOUCHER_PACKAGEGLOBE As New PackageBookingVoucher_GLOBE
    'Dim RPTVOUCHER_TNL As New CarBookingVoucher_TNL
    'Dim RPTVOUCHER_PACKAGETNL As New PackageBookingVoucher_TNL
    'Dim RPTVOUCHER_PRIYA As New CarBookingVoucher_PRIYA
    'Dim RPTVOUCHER_PACKAGEPRIYA As New PackageBookingVoucher_PRIYA
    Dim RPTVOUCHER_KPNT As New CarBookingVoucher_KPNT
    'Dim RPTVOUCHER_NAMASTE As New CarBookingVoucher_NAMASTE
    Dim RPTVOUCHER_MILONI As New CarBookingVoucher_MILONI
    Dim RPTVOUCHER_MATRIX As New CarBookingVoucher_MATRIX
    'Dim RPTVOUCHER_BHAGYASHRI As New CarBookingVoucher_BHAGYASHRI
    'Dim RPTVOUCHER_WAHWAH As New CarBookingVoucher_WAHWAH
    Dim RPTVOUCHER_PACKAGEKPNT As New PackageBookingVoucher_KPNT
    'Dim RPTVOUCHER_PACKAGENAMASTE As New PackageBookingVoucher_NAMASTE
    Dim RPTVOUCHER_PACKAGEMILONI As New PackageBookingVoucher_MILONI
    Dim RPTVOUCHER_PACKAGEMATRIX As New PackageBookingVoucher_MATRIX
    'Dim RPTVOUCHER_PACKAGEBHAGYASHRI As New PackageBookingVoucher_BHAGYASHRI
    'Dim RPTVOUCHER_PACKAGEWAHWAH As New PackageBookingVoucher_WAHWAH
    'Dim RPTVOUCHER_MANYA As New CarBookingVoucher_MANYA
    'Dim RPTVOUCHER_PACKAGEMANYA As New PackageBookingVoucher_MANYA
    'Dim RPTVOUCHER_WHITEPEARL As New CarBookingVoucher_WHITEPEARL
    'Dim RPTVOUCHER_PACKAGEWHITEPEARL As New PackageBookingVoucher_WHITEPEARL
    Dim RPTVOUCHER_SKYMAPS As New CarBookingVoucher_SKYMAPS
    Dim RPTVOUCHER_PACKAGESKYMAPS As New PackageBookingVoucher_SKYMAPS
    'Dim RPTVOUCHER_OFFBEAT As New CarBookingVoucher_OFFBEAT
    'Dim RPTVOUCHER_PACKAGEOFFBEAT As New PackageBookingVoucher_OFFBEAT
    'Dim RPTVOUCHER_LUXCREST As New CarBookingVoucher_LUXCREST
    'Dim RPTVOUCHER_PACKAGELUXCREST As New PackageBookingVoucher_LUXCREST
    Dim RPTVOUCHER_HEENKAR As New CarBookingVoucher_HEENKAR
    Dim RPTVOUCHER_PACKAGEHEENKAR As New PackageBookingVoucher_HEENKAR
    'Dim RPTVOUCHER_ARHAM As New CarBookingVoucher_ARHAM
    'Dim RPTVOUCHER_ARUN As New CarBookingVoucher_ARUN
    'Dim RPTVOUCHER_PACKAGEARUN As New PackageBookingVoucher_ARUN
    'Dim RPTVOUCHER_HEERA As New CarBookingVoucher_HEERA
    'Dim RPTVOUCHER_PACKAGEHEERA As New PackageBookingVoucher_HEERA
    Dim RPTVOUCHER_RAMKRISHNA As New CarBookingVoucher_RAMKRISHNA
    Dim RPTVOUCHER_PACKAGERAMKRISHNA As New PackageBookingVoucher_RAMKRISHNA
    Dim RPTVOUCHER_URMI As New CarBookingVoucher_URMI
    Dim RPTVOUCHER_PACKAGEURMI As New PackageBookingVoucher_URMI
    'Dim RPTVOUCHER_SCC As New CarBookingVoucher_SCC
    'Dim RPTVOUCHER_PACKAGESCC As New PackageBookingVoucher_SCC
    'Dim RPTVOUCHER_WORLDSPIN As New CarBookingVoucher_WORLDSPIN
    'Dim RPTVOUCHER_PACKAGEWORLDSPIN As New PackageBookingVoucher_WORLDSPIN
    'Dim RPTVOUCHER_MAHARAJA As New CarBookingVoucher_MAHARAJA
    'Dim RPTVOUCHER_PACKAGEMAHARAJA As New PackageBookingVoucher_MAHARAJA


    Dim RPTINVOICE As New HolidayPackageVoucher
    'Dim RPTINVOICE_TOP As New CarBookingInvoice_Top
    Dim RPTINVOICE_KHANNA As New HolidayPackageVoucher_KHANNA
    Dim RPTINVOICE_KHANNACARINVOICE As New CarBookingInvoice_KHANNA
    'Dim RPTINVOICE_SEASONED As New CarBookingInvoice_Seasoned
    'Dim RPTINVOICE_SAFAR As New CarBookingInvoice_SAFAR
    Dim RPTINVOICE_TRISHA As New CarBookingInvoice_TRISHA
    ' Dim RPTINVOICE_SHREEJI As New CarBookingInvoice_SHREEJI
    Dim RPTINVOICE_BARODA As New CarBookingInvoice_BARODA
    Dim RPTINVOICE_BELLA As New CarBookingInvoice_BELLA
    Dim RPTINVOICE_COMMON As New CarBookingInvoice_COMMON
    Dim RPTINVOICE_PRATAMESH As New CarBookingInvoice_PRATAMESH
    Dim RPTINVOICE_SSR As New CarBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New CarBookingInvoice_AERO
    ' Dim RPTINVOICE_APPLE As New CarBookingInvoice_APPLE
    'Dim RPTINVOICE_AIRTRINITY As New CarBookingInvoice_AIRTRINITY
    Dim RPTINVOICE_STARVISA As New CarBookingInvoice_STARVISA
    'Dim RPTINVOICE_GLOBE As New CarBookingInvoice_GLOBE
    'Dim RPTINVOICE_TNL As New CarBookingInvoice_TNL
    'Dim RPTINVOICE_PRIYA As New CarBookingInvoice_PRIYA
    Dim RPTINVOICE_KPNT As New CarBookingInvoice_KPNT
    ' Dim RPTINVOICE_NAMASTE As New CarBookingInvoice_NAMASTE
    Dim RPTINVOICE_MILONI As New CarBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New CarBookingInvoice_MATRIX

    'Dim RPTINVOICE_BHAGYASHRI As New CarBookingInvoice_BHAGYASHRI
    'Dim RPTINVOICE_WAHWAH As New CarBookingInvoice_WAHWAH
    'Dim RPTINVOICE_MANYA As New CarBookingInvoice_MANYA
    'Dim RPTINVOICE_WHITEPEARL As New CarBookingInvoice_WHITEPEARL
    Dim RPTINVOICE_SKYMAPS As New CarBookingInvoice_SKYMAPS
    'Dim RPTINVOICE_OFFBEAT As New CarBookingInvoice_OFFBEAT
    'Dim RPTINVOICE_LUXCREST As New CarBookingInvoice_LUXCREST
    Dim RPTINVOICE_HEENKAR As New CarBookingInvoice_HEENKAR
    'Dim RPTINVOICE_ARHAM As New CarBookingInvoice_ARHAM
    'Dim RPTINVOICE_ARUN As New CarBookingInvoice_ARUN
    'Dim RPTINVOICE_HEERA As New CarBookingInvoice_HEERA
    Dim RPTINVOICE_RAMKRISHNA As New CarBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_URMI As New CarBookingInvoice_URMI
    'Dim RPTINVOICE_SCC As New CarBookingInvoice_SCC
    'Dim RPTINVOICEBLANK_SCC As New CarBookingInvoicePrinted_SCC
    ' Dim RPTINVOICE_WORLDSPIN As New CarBookingInvoice_WORLDSPIN
    'Dim RPTINVOICE_MAHARAJA As New CarBookingInvoice_MAHARAJA

    'Dim RPTDUTYSLIP_SCC As New DutySlipVoucher_SCC
    Dim RPTWELCOMEBOARD As New WelcomeBoardReport


    Public TEMP As String
    Public SUBJECT As String
    Public strsearch As String
    Public CARVOUCHERSTR As String
    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public BOOKINGDATE As Date
    Public MTDC As Boolean = False
    Public LETTERHEAD As Integer = 0
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public hideheader As Boolean
    Public DIRECTPRINT As Boolean = False
    Public SALEREGISTERID As Integer
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub CarBookingVoucherDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                Me.Text = "Car Booking Voucher"
                If ClientName = "CLASSIC" Then
                    crTables = RPTVOUCHER.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    'If MTDC = False Then
                    '    crTables = RPTVOUCHER_TOP.Database.Tables
                    'Else
                    '    crTables = RPTVOUCHER_MTDCTOP.Database.Tables
                    'End If
                    'If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '    crTables = RPTVOUCHER_PACKAGETOP.Database.Tables
                    'Else
                    '    crTables = RPTVOUCHER_TOP.Database.Tables
                    'End If
                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_KHANNA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_CARVOUCHERSTR.Database.Tables
                    End If
                    'ElseIf ClientName = "SEASONED" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGESEASONED.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_SEASONED.Database.Tables
                    '    End If
                    'ElseIf ClientName = "SAFAR" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGESAFAR.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_SAFAR.Database.Tables
                    '    End If
                ElseIf ClientName = "TRISHA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGETRISHA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_TRISHA.Database.Tables
                    End If

                ElseIf ClientName = "PRATAMESH" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEPRATAMESH.Database.Tables
                    Else
                        crTables = RPTVOUCHER_PRATAMESH.Database.Tables
                    End If
                ElseIf ClientName = "SSR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGESSR.Database.Tables
                    Else
                        crTables = RPTVOUCHER_SSR.Database.Tables
                    End If

                ElseIf ClientName = "AERO" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEAERO.Database.Tables
                    Else
                        crTables = RPTVOUCHER_AERO.Database.Tables
                    End If

                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEAIRTRINITY.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_AIRTRINITY.Database.Tables
                    '    End If

                ElseIf ClientName = "STARVISA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGESTARVISA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_STARVISA.Database.Tables
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEGLOBE.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_GLOBE.Database.Tables
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGETNL.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_TNL.Database.Tables
                    '    End If

                    'ElseIf ClientName = "PRIYA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEPRIYA.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_PRIYA.Database.Tables
                    '    End If

                ElseIf ClientName = "KPNT" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEKPNT.Database.Tables
                    Else
                        crTables = RPTVOUCHER_KPNT.Database.Tables
                    End If

                    'ElseIf ClientName = "NAMASTE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGENAMASTE.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_NAMASTE.Database.Tables
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEMILONI.Database.Tables
                    Else
                        crTables = RPTVOUCHER_MILONI.Database.Tables
                    End If

                ElseIf ClientName = "MATRIX" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEMATRIX.Database.Tables
                    Else
                        crTables = RPTVOUCHER_MATRIX.Database.Tables
                    End If


                ElseIf ClientName = "SKYMAPS" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGESKYMAPS.Database.Tables
                    Else
                        crTables = RPTVOUCHER_SKYMAPS.Database.Tables
                    End If

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEOFFBEAT.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_OFFBEAT.Database.Tables
                    '    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGELUXCREST.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_LUXCREST.Database.Tables
                    '    End If

                ElseIf ClientName = "HEENKAR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEHEENKAR.Database.Tables
                    Else
                        crTables = RPTVOUCHER_HEENKAR.Database.Tables
                    End If
                    'ElseIf ClientName = "ARHAM" Then
                    '    crTables = RPTVOUCHER_ARHAM.Database.Tables

                    'ElseIf ClientName = "ARUN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEARUN.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_ARUN.Database.Tables
                    '    End If

                    'ElseIf ClientName = "HEERA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEHEERA.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_HEERA.Database.Tables
                    '    End If

                ElseIf ClientName = "RAMKRISHNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGERAMKRISHNA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_RAMKRISHNA.Database.Tables
                    End If

                ElseIf ClientName = "URMI" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEURMI.Database.Tables
                    Else
                        crTables = RPTVOUCHER_URMI.Database.Tables
                    End If

                    'ElseIf ClientName = "SCC" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGESCC.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_SCC.Database.Tables
                    '    End If
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEWORLDSPIN.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_WORLDSPIN.Database.Tables
                    '    End If
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGEMAHARAJA.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_MAHARAJA.Database.Tables
                    '    End If

                    'ElseIf ClientName = "SHREEJI" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        crTables = RPTVOUCHER_PACKAGESHREEJI.Database.Tables
                    '    Else
                    '        crTables = RPTVOUCHER_SHREEJI.Database.Tables
                    '    End If
                ElseIf ClientName = "BARODA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEBARODA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_BARODA.Database.Tables
                    End If
                ElseIf ClientName = "BELLA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGEBELLA.Database.Tables
                    Else
                        crTables = RPTVOUCHER_BELLA.Database.Tables
                    End If
                Else
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTVOUCHER_PACKAGECOMMON.Database.Tables
                    Else
                        crTables = RPTVOUCHER_COMMON.Database.Tables
                    End If
                End If


            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "Car Booking Invoice"
                If ClientName = "CLASSIC" Then
                    crTables = RPTINVOICE.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = RPTINVOICE_TOP.Database.Tables
                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        crTables = RPTINVOICE_KHANNA.Database.Tables
                    Else
                        crTables = RPTINVOICE_KHANNACARINVOICE.Database.Tables
                    End If
                    'ElseIf ClientName = "SEASONED" Then
                    '    crTables = RPTINVOICE_SEASONED.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = RPTINVOICE_SAFAR.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = RPTINVOICE_TRISHA.Database.Tables
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
                    'ElseIf ClientName = "SHREEJI" Then
                    '    crTables = RPTINVOICE_SHREEJI.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = RPTINVOICE_BARODA.Database.Tables
                ElseIf ClientName = "BELLA" Then
                    crTables = RPTINVOICE_BELLA.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = RPTINVOICE_COMMON.Database.Tables
                End If

            ElseIf FRMSTRING = "DUTYSLIP" Then
                Me.Text = "Duty Slip"
                'If ClientName = "SCC" Then
                '    crTables = RPTDUTYSLIP_SCC.Database.Tables
                'End If
            ElseIf FRMSTRING = "WELCOMEBOARD" Then
                Me.Text = "Welcome Board"
                crTables = RPTWELCOMEBOARD.Database.Tables

                'ElseIf FRMSTRING = "INVOICEBLANK" Then
                '    crTables = RPTINVOICEBLANK_SCC.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If CARVOUCHERSTR <> "NEW VOUCHER" Then
                strsearch = strsearch & " {CARBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {CARBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {CARBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {CARBOOKINGMASTER.BOOKING_yearid}=" & YearId
            Else
                strsearch = strsearch & " {HOLIDAYPACKAGEMASTER_TRANSDETAILS.BOOKING_NO}= " & BOOKINGNO & " AND {HOLIDAYPACKAGEMASTER_TRANSDETAILS.BOOKING_cmpid}=" & CmpId & " and {HOLIDAYPACKAGEMASTER_TRANSDETAILS.BOOKING_locationid}=" & Locationid & " and {HOLIDAYPACKAGEMASTER_TRANSDETAILS.BOOKING_yearid}=" & YearId
            End If

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "VOUCHER" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = RPTVOUCHER
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGETOP
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_TOP
                    '    End If
                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_KHANNA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_CARVOUCHERSTR
                    End If
                    'ElseIf ClientName = "SEASONED" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGESEASONED
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_SEASONED
                    '    End If
                    'ElseIf ClientName = "SAFAR" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGESAFAR
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_SAFAR
                    '    End If
                ElseIf ClientName = "TRISHA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGETRISHA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_TRISHA
                    End If
                ElseIf ClientName = "PRATAMESH" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEPRATAMESH
                    Else
                        CRPO.ReportSource = RPTVOUCHER_PRATAMESH
                    End If
                ElseIf ClientName = "SSR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGESSR
                    Else
                        CRPO.ReportSource = RPTVOUCHER_SSR
                    End If
                ElseIf ClientName = "AERO" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEAERO
                    Else
                        CRPO.ReportSource = RPTVOUCHER_AERO
                    End If

                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEAIRTRINITY
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_AIRTRINITY
                    '    End If

                ElseIf ClientName = "STARVISA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGESTARVISA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_STARVISA
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEGLOBE
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_GLOBE
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGETNL
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_TNL
                    '    End If

                    'ElseIf ClientName = "PRIYA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEPRIYA
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_PRIYA
                    '    End If

                ElseIf ClientName = "KPNT" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEKPNT
                    Else
                        CRPO.ReportSource = RPTVOUCHER_KPNT
                    End If
                    'ElseIf ClientName = "NAMASTE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGENAMASTE
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_NAMASTE
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEMILONI
                    Else
                        CRPO.ReportSource = RPTVOUCHER_MILONI
                    End If

                ElseIf ClientName = "MATRIX" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEMATRIX
                    Else
                        CRPO.ReportSource = RPTVOUCHER_MATRIX
                    End If


                ElseIf ClientName = "SKYMAPS" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGESKYMAPS
                    Else
                        CRPO.ReportSource = RPTVOUCHER_SKYMAPS
                    End If
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEOFFBEAT
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_OFFBEAT
                    '    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGELUXCREST
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_LUXCREST
                    '    End If

                ElseIf ClientName = "HEENKAR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEHEENKAR
                    Else
                        CRPO.ReportSource = RPTVOUCHER_HEENKAR
                    End If
                    'ElseIf ClientName = "ARHAM" Then
                    '    CRPO.ReportSource = RPTVOUCHER_ARHAM
                    'ElseIf ClientName = "ARUN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEARUN
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_ARUN
                    '    End If
                    'ElseIf ClientName = "HEERA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEHEERA
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_HEERA
                    '    End If
                ElseIf ClientName = "RAMKRISHNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGERAMKRISHNA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_RAMKRISHNA
                    End If
                ElseIf ClientName = "URMI" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEURMI
                    Else
                        CRPO.ReportSource = RPTVOUCHER_URMI
                        RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    End If
                    'ElseIf ClientName = "SCC" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGESCC
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_SCC
                    '    End If
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEWORLDSPIN
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_WORLDSPIN
                    '    End If
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGEMAHARAJA
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_MAHARAJA
                    '    End If
                    'ElseIf ClientName = "SHREEJI" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        CRPO.ReportSource = RPTVOUCHER_PACKAGESHREEJI
                    '    Else
                    '        CRPO.ReportSource = RPTVOUCHER_SHREEJI
                    '    End If
                ElseIf ClientName = "BARODA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEBARODA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_BARODA
                    End If
                ElseIf ClientName = "BELLA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGEBELLA
                    Else
                        CRPO.ReportSource = RPTVOUCHER_BELLA
                    End If
                Else
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        CRPO.ReportSource = RPTVOUCHER_PACKAGECOMMON
                    Else
                        CRPO.ReportSource = RPTVOUCHER_COMMON
                    End If
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
                        RPTINVOICE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    Else
                        RPTINVOICE.Subreports("HOLIDAYPACKAGE_INVOICEREPORT").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    End If

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = RPTINVOICE_TOP

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_TOP.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_TOP.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    'If HIDEAMT = True Then
                    '    RPTINVOICE_TOP.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TOPCOMM").DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    'Else
                    '    RPTINVOICE_TOP.Subreports("HOLIDAYPACKAGE_INVOICEREPORT_TOPCOMM").DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    'End If


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

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    CRPO.ReportSource = RPTINVOICE_OFFBEAT

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

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

                    'ElseIf ClientName = "ARUN" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARUN

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                    '    End If

                    'ElseIf ClientName = "HEERA" Then
                    '    CRPO.ReportSource = RPTINVOICE_HEERA

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTAMT").Text = 1
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




                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box8").ObjectFormat.EnableSuppress = True


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

                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    CRPO.ReportSource = RPTINVOICE_WORLDSPIN

                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If HIDEAMT = True Then
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                    '    Else
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTAMT").Text = 1
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

                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
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
                    Else
                        CRPO.ReportSource = RPTINVOICE_KHANNACARINVOICE

                        If PRINTGUESTNAME = True Then
                            RPTINVOICE_KHANNACARINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                        Else
                            RPTINVOICE_KHANNACARINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                        End If
                        If HIDEAMT = True Then
                            RPTINVOICE_KHANNACARINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                        Else
                            RPTINVOICE_KHANNACARINVOICE.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                        End If
                    End If


                Else
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

            ElseIf FRMSTRING = "DUTYSLIP" Then
                'If ClientName = "SCC" Then
                '    CRPO.ReportSource = RPTDUTYSLIP_SCC
                'End If

            ElseIf FRMSTRING = "WELCOMEBOARD" Then
                    CRPO.ReportSource = RPTWELCOMEBOARD

                'ElseIf FRMSTRING = "INVOICEBLANK" Then
                '        CRPO.ReportSource = RPTINVOICEBLANK_SCC

                '        If PRINTGUESTNAME = True Then
                '            RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                '        Else
                '            RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                '        End If
                '        If HAIDEAMT = True Then
                '            RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("PRINTAMT").Text = 0
                '        Else
                '            RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("PRINTAMT").Text = 1
                '        End If

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

            strsearch = strsearch & " {CARBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {CARBOOKINGMASTER.BOOKING_SALEREGISTERID} = " & SALEREGISTERID & " AND {CARBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Car Booking Invoice"

                'If ClientName = "TOPCOMM" Then
                '    OBJ = New CarBookingInvoice_Top
                '    OBJOLD = New CarBookingInvoice_TopOLD
                If ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        OBJ = New HolidayPackageVoucher_KHANNA
                        OBJOLD = New HolidayPackageVoucher_KHANNA
                    Else
                        OBJ = New CarBookingInvoice_KHANNA
                        OBJOLD = New CarBookingInvoice_KHANNAOLD
                    End If
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New CarBookingInvoice_TRISHA
                    OBJOLD = New CarBookingInvoice_TRISHAOLD
                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New CarBookingInvoice_PRATAMESH
                    OBJOLD = New CarBookingInvoice_PRATAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New CarBookingInvoice_SSR
                    OBJOLD = New CarBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New CarBookingInvoice_AERO
                    OBJOLD = New CarBookingInvoice_AEROOLD
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New CarBookingInvoice_AIRTRINITY
                    '    OBJOLD = New CarBookingInvoice_AIRTRINITYOLD
                ElseIf ClientName = "STARVISA" Then
                    OBJ = New CarBookingInvoice_STARVISA
                    OBJOLD = New CarBookingInvoice_STARVISAOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New CarBookingInvoice_GLOBE
                    '    OBJOLD = New CarBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New CarBookingInvoice_TNL
                ElseIf ClientName = "KPNT" Then
                    OBJ = New CarBookingInvoice_KPNT
                    OBJOLD = New CarBookingInvoice_KPNTOLD
                ElseIf ClientName = "MILONI" Then
                    OBJ = New CarBookingInvoice_MILONI
                    OBJOLD = New CarBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New CarBookingInvoice_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New CarBookingInvoice_SKYMAPS
                    OBJOLD = New CarBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New CarBookingInvoice_LUXCREST
                    '    OBJOLD = New CarBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New CarBookingInvoice_HEENKAR
                    OBJOLD = New CarBookingInvoice_HEENKAROLD
                    'ElseIf ClientName = "ARHAM" Then
                    '    OBJ = New CarBookingInvoice_ARHAM
                    '    OBJOLD = New CarBookingInvoice_ARHAMOLD
                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New CarBookingInvoice_RAMKRISHNA
                    OBJOLD = New CarBookingInvoice_RAMKRISHNAOLD
                ElseIf ClientName = "URMI" Then
                    OBJ = New CarBookingInvoice_URMI
                    OBJOLD = New CarBookingInvoice_URMIOLD
                    'ElseIf ClientName = "SCC" Then
                    '    OBJ = New CarBookingInvoice_SCC
                    '    OBJOLD = New CarBookingInvoice_SCC_old
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New CarBookingInvoice_MAHARAJA
                    '    OBJOLD = New CarBookingInvoice_MAHARAJAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New CarBookingInvoice_BARODA
                    OBJOLD = New CarBookingInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New CarBookingInvoice_BELLA
                Else
                    OBJ = New CarBookingInvoice_COMMON
                End If

            End If


            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "CARBOOKINGMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
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

        If FRMSTRING = "VOUCHER" Then
            tempattachment = "Car Voucher No. " & BOOKINGNO
        ElseIf FRMSTRING = "INVOICE" Or FRMSTRING = "INVOICEBLANK" Then
            tempattachment = "Invoice No. " & BOOKINGNO
        ElseIf FRMSTRING = "DUTYSLIP" Then
            tempattachment = "Booking No. " & BOOKINGNO
        ElseIf FRMSTRING = "WELCOMEBOARD" Then
            tempattachment = "Welcome Board " & BOOKINGNO
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

            If FRMSTRING = "VOUCHER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Car Voucher No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    RPTVOUCHER.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTVOUCHER.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER.Export()

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    RPTVOUCHER_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_TOP.Export()

                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_KHANNA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_KHANNA.Export()
                    Else
                        RPTVOUCHER_CARVOUCHERSTR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_CARVOUCHERSTR.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_CARVOUCHERSTR.Export()
                    End If

                    'ElseIf ClientName = "SEASONED" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        RPTVOUCHER_SEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_SEASONED.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_SEASONED.Export()
                    '    Else
                    '        RPTVOUCHER_PACKAGESEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGESEASONED.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGESEASONED.Export()
                    '    End If

                    'ElseIf ClientName = "SAFAR" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        RPTVOUCHER_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_SAFAR.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_SAFAR.Export()
                    '    Else
                    '        RPTVOUCHER_PACKAGESAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGESAFAR.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGESAFAR.Export()
                    '    End If

                ElseIf ClientName = "TRISHA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_TRISHA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_TRISHA.Export()
                        RPTVOUCHER_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGETRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGETRISHA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGETRISHA.Export()
                    End If

                ElseIf ClientName = "PRATAMESH" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_PRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PRATAMESH.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PRATAMESH.Export()
                    Else
                        RPTVOUCHER_PACKAGEPRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEPRATAMESH.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEPRATAMESH.Export()
                    End If

                ElseIf ClientName = "SSR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_SSR.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_SSR.Export()
                        RPTVOUCHER_SSR.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGESSR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGESSR.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGESSR.Export()
                        RPTVOUCHER_PACKAGESSR.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                ElseIf ClientName = "AERO" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_AERO.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_AERO.Export()
                        RPTVOUCHER_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGEAERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEAERO.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEAERO.Export()
                        RPTVOUCHER_PACKAGEAERO.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                    'ElseIf ClientName = "AIRTRINITY" Then
                    'If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '    RPTVOUCHER_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_AIRTRINITY.Export()
                    '    RPTVOUCHER_AIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'Else
                    '    RPTVOUCHER_PACKAGEAIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_PACKAGEAIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_PACKAGEAIRTRINITY.Export()
                    '    RPTVOUCHER_PACKAGEAIRTRINITY.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'End If

                ElseIf ClientName = "STARVISA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_STARVISA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_STARVISA.Export()
                        RPTVOUCHER_STARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGESTARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGESTARVISA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGESTARVISA.Export()
                        RPTVOUCHER_PACKAGESTARVISA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_GLOBE.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_GLOBE.Export()
                    '        RPTVOUCHER_GLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEGLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEGLOBE.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEGLOBE.Export()
                    '        RPTVOUCHER_PACKAGEGLOBE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_TNL.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_TNL.Export()
                    '        RPTVOUCHER_TNL.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGETNL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGETNL.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGETNL.Export()
                    '        RPTVOUCHER_PACKAGETNL.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If


                    'ElseIf ClientName = "PRIYA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PRIYA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PRIYA.Export()
                    '        RPTVOUCHER_PRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEPRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEPRIYA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEPRIYA.Export()
                    '        RPTVOUCHER_PACKAGEPRIYA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If


                ElseIf ClientName = "KPNT" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_KPNT.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_KPNT.Export()
                        RPTVOUCHER_KPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGEKPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEKPNT.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEKPNT.Export()
                        RPTVOUCHER_PACKAGEKPNT.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                    'ElseIf ClientName = "NAMASTE" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_NAMASTE.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_NAMASTE.Export()
                    '        RPTVOUCHER_NAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGENAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGENAMASTE.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGENAMASTE.Export()
                    '        RPTVOUCHER_PACKAGENAMASTE.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_MILONI.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_MILONI.Export()
                        RPTVOUCHER_MILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGEMILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEMILONI.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEMILONI.Export()
                        RPTVOUCHER_PACKAGEMILONI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                ElseIf ClientName = "MATRIX" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_MATRIX.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_MATRIX.Export()
                        RPTVOUCHER_MATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGEMATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEMATRIX.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEMATRIX.Export()
                        RPTVOUCHER_PACKAGEMATRIX.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If


                ElseIf ClientName = "SKYMAPS" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_SKYMAPS.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_SKYMAPS.Export()
                        RPTVOUCHER_SKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGESKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGESKYMAPS.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGESKYMAPS.Export()
                        RPTVOUCHER_PACKAGESKYMAPS.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_OFFBEAT.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_OFFBEAT.Export()
                    '        RPTVOUCHER_OFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEOFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEOFFBEAT.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEOFFBEAT.Export()
                    '        RPTVOUCHER_PACKAGEOFFBEAT.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_LUXCREST.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_LUXCREST.Export()
                    '        RPTVOUCHER_LUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGELUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGELUXCREST.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGELUXCREST.Export()
                    '        RPTVOUCHER_PACKAGELUXCREST.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If


                ElseIf ClientName = "HEENKAR" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_HEENKAR.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_HEENKAR.Export()
                        RPTVOUCHER_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGEHEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEHEENKAR.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEHEENKAR.Export()
                        RPTVOUCHER_PACKAGEHEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    End If

                    'ElseIf ClientName = "ARHAM" Then
                    '    expo = RPTVOUCHER_ARHAM.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_ARHAM.Export()

                    'ElseIf ClientName = "ARUN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_ARUN.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_ARUN.Export()
                    '        RPTVOUCHER_ARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEARUN.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEARUN.Export()
                    '        RPTVOUCHER_PACKAGEARUN.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    End If
                    'ElseIf ClientName = "HEERA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_HEERA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_HEERA.Export()
                    '        RPTVOUCHER_HEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEHEERA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEHEERA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEHEERA.Export()
                    '    End If

                ElseIf ClientName = "RAMKRISHNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                        RPTVOUCHER_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_RAMKRISHNA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_RAMKRISHNA.Export()
                        RPTVOUCHER_RAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    Else
                        RPTVOUCHER_PACKAGERAMKRISHNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGERAMKRISHNA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGERAMKRISHNA.Export()
                    End If

                ElseIf ClientName = "URMI" Then
                    'If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    RPTVOUCHER_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = False
                    expo = RPTVOUCHER_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_URMI.Export()
                    RPTVOUCHER_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    RPTVOUCHER_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'Else
                    '    RPTVOUCHER_PACKAGEURMI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTVOUCHER_PACKAGEURMI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_PACKAGEURMI.Export()
                    'End If

                    'ElseIf ClientName = "SCC" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_SCC.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_SCC.Export()
                    '        RPTVOUCHER_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGESCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGESCC.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGESCC.Export()
                    '    End If

                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" And TEMP = "TEMP" Then
                    '        RPTVOUCHER_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_WORLDSPIN.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_WORLDSPIN.Export()
                    '        RPTVOUCHER_WORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    '    Else
                    '        RPTVOUCHER_PACKAGEWORLDSPIN.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEWORLDSPIN.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEWORLDSPIN.Export()
                    '    End If

                    'ElseIf ClientName = "MAHARAJA" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        RPTVOUCHER_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_MAHARAJA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_MAHARAJA.Export()
                    '    Else
                    '        RPTVOUCHER_PACKAGEMAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGEMAHARAJA.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGEMAHARAJA.Export()
                    '    End If

                    'ElseIf ClientName = "SHREEJI" Then
                    '    If CARVOUCHERSTR = "NEW VOUCHER" Then
                    '        RPTVOUCHER_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_SHREEJI.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_SHREEJI.Export()
                    '    Else
                    '        RPTVOUCHER_PACKAGESHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '        expo = RPTVOUCHER_PACKAGESHREEJI.ExportOptions
                    '        expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '        expo.DestinationOptions = oDfDopt
                    '        RPTVOUCHER_PACKAGESHREEJI.Export()
                    '    End If

                ElseIf ClientName = "BARODA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_BARODA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_BARODA.Export()
                    Else
                        RPTVOUCHER_PACKAGEBARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEBARODA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEBARODA.Export()
                    End If

                ElseIf ClientName = "BELLA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_BELLA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_BELLA.Export()
                    Else
                        RPTVOUCHER_PACKAGEBELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGEBELLA.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGEBELLA.Export()
                    End If

                Else
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTVOUCHER_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_COMMON.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_COMMON.Export()
                    Else
                        RPTVOUCHER_PACKAGECOMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTVOUCHER_PACKAGECOMMON.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTVOUCHER_PACKAGECOMMON.Export()
                    End If

                End If

            ElseIf FRMSTRING = "INVOICE" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                If ClientName = "CLASSIC" Then
                    RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE.Export()

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    RPTINVOICE_TOP.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_TOP.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_TOP.Export()

                ElseIf ClientName = "KHANNA" Then
                    If CARVOUCHERSTR = "NEW VOUCHER" Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTINVOICE_KHANNACARINVOICE.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTINVOICE_KHANNA.Export()
                    Else
                        RPTINVOICE_KHANNACARINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                        expo = RPTINVOICE_KHANNACARINVOICE.ExportOptions
                        expo.ExportDestinationType = ExportDestinationType.DiskFile
                        expo.ExportFormatType = ExportFormatType.PortableDocFormat
                        expo.DestinationOptions = oDfDopt
                        RPTINVOICE_KHANNACARINVOICE.Export()
                    End If

                    'ElseIf ClientName = "SEASONED" Then
                    '    RPTINVOICE_SEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_SEASONED.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SEASONED.Export()

                    'ElseIf ClientName = "SAFAR" Then
                    '    RPTINVOICE_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
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


                ElseIf ClientName = "PRATAMESH" Then
                    RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
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
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box8").ObjectFormat.EnableSuppress = False
                    expo = RPTINVOICE_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_URMI.Export()
                    RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box8").ObjectFormat.EnableSuppress = True

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
                    '    RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
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

            ElseIf FRMSTRING = "DUTYSLIP" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Booking No. " & BOOKINGNO & ".PDF"

                'If ClientName = "SCC" Then
                '    expo = RPTDUTYSLIP_SCC.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTDUTYSLIP_SCC.Export()
                'End If

            ElseIf FRMSTRING = "WELCOMEBOARD" Then

                expo = RPTWELCOMEBOARD.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTWELCOMEBOARD.Export()

                'ElseIf FRMSTRING = "INVOICEBLANK" Then
                '    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                '    RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                '    expo = RPTINVOICEBLANK_SCC.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTINVOICEBLANK_SCC.Export()
                '    RPTINVOICEBLANK_SCC.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class