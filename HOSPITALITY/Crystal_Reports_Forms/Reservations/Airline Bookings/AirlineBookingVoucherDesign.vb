
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class AirlineBookingVoucherDesign

    'CLIENTS TO EXCLUDE ARE ELYSIUM, 7HOSPITALITY, PLANET HOSPITALITY
    'Dim RPTINVOICE_TOPCOMM As New AirlineBookingInvoice_Top
    Dim RPTINVOICE As New AirlineBookingInvoice
    Dim RPTINVOICE_KHANNA As New AirlineBookingInvoice_KHANNA
    'Dim RPTINVOICE_SEASONED As New AirlineBookingInvoice_SEASONED
    Dim RPTINVOICE_TRISHA As New AirlineBookingInvoice_TRISHA
    'Dim RPTINVOICE_SHREEJI As New AirlineBookingInvoice_SHREEJI
    Dim RPTINVOICE_BARODA As New AirlineBookingInvoice_BARODA
    Dim RPTINVOICE_BELLA As New AirlineBookingInvoice_BELLACORSA
    Dim RPTINVOICE_COMMON As New AirlineBookingInvoice_COMMON

    Dim RPTINVOICE_PRATAMESH As New AirlineBookingInvoice_PRATAMESH
    Dim RPTINVOICE_SSR As New AirlineBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New AirlineBookingInvoice_AERO
    'Dim RPTINVOICE_APPLE As New AirlineBookingInvoice_APPLE
    'Dim RPTINVOICE_AIRTRINITY As New AirlineBookingInvoice_AIRTRINITY
    Dim RPTINVOICE_STARVISA As New AirlineBookingInvoice_STARVISA
    'Dim RPTINVOICE_GLOBE As New AirlineBookingInvoice_GLOBE
    'Dim RPTINVOICE_TNL As New AirlineBookingInvoice_TNL
    'Dim RPTINVOICE_PRIYA As New AirlineBookingInvoice_PRIYA
    Dim RPTINVOICE_KPNT As New AirlineBookingInvoice_KPNT
    'Dim RPTINVOICE_NAMASTE As New AirlineBookingInvoice_NAMASTE
    Dim RPTINVOICE_MILONI As New AirlineBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New AirlineBookingInvoice_MATRIX
    'Dim RPTINVOICE_BHAGYASHRI As New AirlineBookingInvoice_BHAGYASHRI
    'Dim RPTINVOICE_WAHWAH As New AirlineBookingInvoice_WAHWAH
    Dim RPTINVOICE_HEENKAR As New AirlineBookingInvoice_HEENKAR
    ' Dim RPTINVOICE_ARHAM As New AirlineBookingInvoice_ARHAM
    'Dim RPTINVOICE_ARUN As New AirlineBookingInvoice_ARUN
    'Dim RPTINVOICE_HEERA As New AirlineBookingInvoice_HEERA
    Dim RPTINVOICE_RAMKRISHNA As New AirlineBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_URMI As New AirlineBookingInvoice_URMI
    'Dim RPTINVOICE_SCC As New AirlineBookingInvoice_SCC
    'Dim RPTINVOICE_MANYA As New AirlineBookingInvoice_MANYA
    'Dim RPTINVOICE_WHITEPEARL As New AirlineBookingInvoice_WHITEPEARL
    Dim RPTINVOICE_SKYMAPS As New AirlineBookingInvoice_SKYMAPS
    'Dim RPTINVOICE_OFFBEAT As New AirlineBookingInvoice_OFFBEAT
    'Dim RPTINVOICE_LUXCREST As New AirlineBookingInvoice_LUXCREST
    'Dim RPTINVOICE_WORLDSPIN As New AirlineBookingInvoice_WORLDSPIN
    'Dim RPTINVOICE_MAHARAJA As New AirlineBookingInvoice_MAHARAJA
    'Dim RPTINVOICE_SAFAR As New AirlineBookingInvoice_SAFAR
    'Dim RPTVOUCHER_SHREEJI As New AirlineBookingVoucher_SHREEJI
    Dim RPTVOUCHER_BARODA As New AirlineBookingVoucher_BARODA

    'Dim RPTVOUCHER_SAFAR As New AirlineBookingVoucher_SAFAR
    'Dim RPTINVOICEOFFICE_SHREEJI As New AirlineBookingInvoice_SHREEJI_OfficeCopy
    Dim RPTINVOICEOFFICE_BARODA As New AirlineBookingInvoice_BARODA_OfficeCopy


    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public BOOKINGDATE As Date
    Public SALEREGISTERID As Integer
    Public LETTERHEAD As Integer = 0
    Public BOOKTYPE As String
    Public PRINTGUESTNAME As Boolean
    Public HIDEAMT As Boolean
    Public PRINTTAX As Boolean
    Public PRINTOTHERCHGS As Boolean
    Public PRINTADDDISC As Boolean
    Public COLVISIBLE As Boolean
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub AirlineBookingVoucherDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                'USE SAME VOUCHER OF BARODA FOR AERO
                If ClientName = "AERO" Then
                    crTables = RPTVOUCHER_BARODA.Database.Tables
                ElseIf ClientName = "BARODA" Then
                    crTables = RPTVOUCHER_BARODA.Database.Tables
                    'ElseIf ClientName = "SAFAR" Then
                    '    crTables = RPTVOUCHER_SAFAR.Database.Tables
                End If

            ElseIf FRMSTRING = "INVOICE" Then
                Me.Text = "Airline Booking Invoice"
                If ClientName = "CLASSIC" Then
                    crTables = RPTINVOICE.Database.Tables
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
                    '    crTables = RPTINVOICE_TNL.Database.Tables()
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
                    'ElseIf ClientName = "MANYA" Then
                    '    crTables = RPTINVOICE_MANYA.Database.Tables
                    'ElseIf ClientName = "WHITEPEARL" Then
                    '    crTables = RPTINVOICE_WHITEPEARL.Database.Tables
                ElseIf ClientName = "SKYMAPS" Then
                    crTables = RPTINVOICE_SKYMAPS.Database.Tables
                    'ElseIf ClientName = "OFFBEAT" Then
                    '    crTables = RPTINVOICE_OFFBEAT.Database.Tables
                    'ElseIf ClientName = "LUXCREST" Then
                    '    crTables = RPTINVOICE_LUXCREST.Database.Tables
                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    crTables = RPTINVOICE_WORLDSPIN.Database.Tables
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    crTables = RPTINVOICE_MAHARAJA.Database.Tables
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    crTables = RPTINVOICE_TOPCOMM.Database.Tables

                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = RPTINVOICE_COMMON.Database.Tables
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
                strsearch = strsearch & " {AIRLINEBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID} = " & SALEREGISTERID & " AND {AIRLINEBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {AIRLINEBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {AIRLINEBOOKINGMASTER.BOOKING_yearid}=" & YearId
                CRPO.SelectionFormula = strsearch

                If FRMSTRING = "VOUCHER" Then
                If ClientName = "AERO" Then
                    CRPO.ReportSource = RPTVOUCHER_BARODA
                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTVOUCHER_BARODA
                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = RPTVOUCHER_SAFAR
                End If
            ElseIf FRMSTRING = "INVOICE" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = RPTINVOICE
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If
                    'If PRINTADDDISC = True Then
                    '    RPTINVOICE.DataDefinition.FormulaFields("PRINTADDDISC").Text = 1
                    'Else
                    '    RPTINVOICE.DataDefinition.FormulaFields("PRINTADDDISC").Text = 0
                    'End If

                    'ElseIf ClientName = "SEASONED" Then
                    '    CRPO.ReportSource = RPTINVOICE_SEASONED
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_SEASONED.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "SAFAR" Then
                    '    CRPO.ReportSource = RPTINVOICE_SAFAR
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_SAFAR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = RPTINVOICE_TRISHA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_TRISHA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If


                    'ElseIf ClientName = "SHREEJI" Then
                    '    CRPO.ReportSource = RPTINVOICE_SHREEJI
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICE_BARODA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_BARODA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "BELLA" Then
                    CRPO.ReportSource = RPTINVOICE_BELLA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_BELLA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If



                ElseIf ClientName = "PRATAMESH" Then
                    CRPO.ReportSource = RPTINVOICE_PRATAMESH
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If


                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = RPTINVOICE_SSR
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_SSR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "AERO" Then
                    CRPO.ReportSource = RPTINVOICE_AERO
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_AERO.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If


                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = RPTINVOICE_AIRTRINITY
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_AIRTRINITY.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = RPTINVOICE_STARVISA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_STARVISA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                    'ElseIf ClientName = "GLOBE" Then
                    '    CRPO.ReportSource = RPTINVOICE_GLOBE
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_GLOBE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = RPTINVOICE_TNL
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_TNL.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If


                    'ElseIf ClientName = "PRIYA" Then
                    '    CRPO.ReportSource = RPTINVOICE_PRIYA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_PRIYA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If


                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = RPTINVOICE_KPNT
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_KPNT.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                    'ElseIf ClientName = "NAMASTE" Then
                    '    CRPO.ReportSource = RPTINVOICE_NAMASTE
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_NAMASTE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = RPTINVOICE_MILONI
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_MILONI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "MATRIX" Then
                    CRPO.ReportSource = RPTINVOICE_MATRIX
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_MATRIX.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If


                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTINVOICE_HEENKAR
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                    'ElseIf ClientName = "ARHAM" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARHAM
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_ARHAM.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "ARUN" Then
                    '    CRPO.ReportSource = RPTINVOICE_ARUN
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_ARUN.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "HEERA" Then
                    '    CRPO.ReportSource = RPTINVOICE_HEERA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_HEERA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTINVOICE_RAMKRISHNA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_RAMKRISHNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "URMI" Then
                    CRPO.ReportSource = RPTINVOICE_URMI
                    If PRINTGUESTNAME = True Then RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1 Else RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    If PRINTTAX = True Then RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTST").Text = 0
                    If PRINTOTHERCHGS = True Then RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0



                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box1").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = True
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box4").ObjectFormat.EnableSuppress = True

                    'ElseIf ClientName = "SCC" Then
                    '    CRPO.ReportSource = RPTINVOICE_SCC
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_SCC.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "MANYA" Then
                    '    CRPO.ReportSource = RPTINVOICE_MANYA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_MANYA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "WHITEPEARL" Then
                    '    CRPO.ReportSource = RPTINVOICE_WHITEPEARL
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = RPTINVOICE_SKYMAPS
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_SKYMAPS.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                    'ElseIf ClientName = "OFFBEAT" Then
                    '    CRPO.ReportSource = RPTINVOICE_OFFBEAT
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_OFFBEAT.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "LUXCREST" Then
                    '    CRPO.ReportSource = RPTINVOICE_LUXCREST
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_LUXCREST.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If

                    'ElseIf ClientName = "WORLDSPIN" Then
                    '    CRPO.ReportSource = RPTINVOICE_WORLDSPIN
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_WORLDSPIN.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If


                    'ElseIf ClientName = "MAHARAJA" Then
                    '    CRPO.ReportSource = RPTINVOICE_MAHARAJA
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If


                ElseIf ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    CRPO.ReportSource = RPTINVOICE_KHANNA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If
                    'If PRINTADDDISC = True Then
                    '    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTADDDISC").Text = 1
                    'Else
                    '    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTADDDISC").Text = 0
                    'End If

                    'ElseIf ClientName = "TOPCOMM" Then
                    '    CRPO.ReportSource = RPTINVOICE_TOPCOMM
                    '    If PRINTGUESTNAME = True Then
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    '    Else
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    '    End If
                    '    If PRINTTAX = True Then
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTST").Text = 1
                    '    Else
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTST").Text = 0
                    '    End If
                    '    If PRINTOTHERCHGS = True Then
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    '    Else
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    '    End If
                    '    If PRINTADDDISC = True Then
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTADDDISC").Text = 1
                    '    Else
                    '        RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("PRINTADDDISC").Text = 0
                    '    End If

                Else
                    CRPO.ReportSource = RPTINVOICE_COMMON
                    If PRINTGUESTNAME = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    If PRINTTAX = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 0
                    If PRINTOTHERCHGS = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0

                End If

            ElseIf FRMSTRING = "INVOICEOFFICE" Then
                'If ClientName = "SHREEJI" Then
                '    CRPO.ReportSource = RPTINVOICEOFFICE_SHREEJI
                '    If PRINTGUESTNAME = True Then
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                '    Else
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                '    End If
                '    If PRINTTAX = True Then
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTST").Text = 1
                '    Else
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTST").Text = 0
                '    End If
                '    If PRINTOTHERCHGS = True Then
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                '    Else
                '        RPTINVOICEOFFICE_SHREEJI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                '    End If
                If ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICEOFFICE_BARODA
                    If PRINTGUESTNAME = True Then
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    If PRINTTAX = True Then
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICEOFFICE_BARODA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If
                End If
            End If
            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
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

            strsearch = strsearch & " {AIRLINEBOOKINGMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {AIRLINEBOOKINGMASTER.BOOKING_SALEREGISTERID} = " & SALEREGISTERID & " AND {AIRLINEBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {AIRLINEBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {AIRLINEBOOKINGMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Invoice"

                'FOR COMMON REPORTS
                If ClientName = "CLASSIC" Then
                    OBJ = New AirlineBookingInvoice
                    'OBJOLD = New AirlineBookingInvoiceOLD
                ElseIf ClientName = "KHANNA" Then
                    OBJ = New AirlineBookingInvoice_KHANNA
                    OBJOLD = New AirlineBookingInvoice_KHANNAOLD
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    OBJ = New AirlineBookingInvoice_TOP
                    '    OBJOLD = New AirlineBookingInvoice_TopOLD
                    'ElseIf ClientName = "SAFAR" Then
                    '    OBJ = New AirlineBookingInvoice_SAFAR
                    '    OBJOLD = New AirlineBookingInvoice_SAFAROLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New AirlineBookingInvoice_TRISHA
                    OBJOLD = New AirlineBookingInvoice_TRISHAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New AirlineBookingInvoice_BARODA
                    OBJOLD = New AirlineBookingInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New AirlineBookingInvoice_BELLACORSA
                ElseIf ClientName = "COMMON" Then
                    OBJ = New AirlineBookingInvoice_COMMON
                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New AirlineBookingInvoice_PRATAMESH
                    OBJOLD = New AirlineBookingInvoice_PRATAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New AirlineBookingInvoice_SSR
                    OBJOLD = New AirlineBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New AirlineBookingInvoice_AERO
                    OBJOLD = New AirlineBookingInvoice_AEROOLD
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New AirlineBookingInvoice_AIRTRINITY
                    '    OBJOLD = New AirlineBookingInvoice_AIRTRINITYOLD
                ElseIf ClientName = "STARVISA" Then
                    OBJ = New AirlineBookingInvoice_STARVISA
                    OBJOLD = New AirlineBookingInvoice_STARVISAOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New AirlineBookingInvoice_GLOBE
                    '    OBJOLD = New AirlineBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New AirlineBookingInvoice_TNL
                ElseIf ClientName = "KPNT" Then
                    OBJ = New AirlineBookingInvoice_KPNT
                    OBJOLD = New AirlineBookingInvoice_KPNTOLD
                ElseIf ClientName = "MILONI" Then
                    OBJ = New AirlineBookingInvoice_MILONI
                    OBJOLD = New AirlineBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New AirlineBookingInvoice_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New AirlineBookingInvoice_SKYMAPS
                    OBJOLD = New AirlineBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New AirlineBookingInvoice_LUXCREST
                    '    OBJOLD = New AirlineBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New AirlineBookingInvoice_HEENKAR
                    OBJOLD = New AirlineBookingInvoice_HEENKAROLD
                    'ElseIf ClientName = "ARHAM" Then
                    '    OBJ = New AirlineBookingInvoice_ARHAM
                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New AirlineBookingInvoice_RAMKRISHNA
                ElseIf ClientName = "URMI" Then
                    OBJ = New AirlineBookingInvoice_URMI
                    OBJOLD = New AirlineBookingInvoice_URMIOLD
                    'ElseIf ClientName = "SCC" Then
                    '    OBJ = New AirlineBookingInvoice_SCC
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New AirlineBookingInvoice_MAHARAJA
                    '    OBJOLD = New AirlineBookingInvoice_MAHARAJAOLD
                End If
            End If


            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", "AIRLINEBOOKINGMASTER ", " AND BOOKING_NO = " & Val(BOOKINGNO) & " AND BOOKING_YEARID = " & YearId)
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
        Dim tempattachment As String

        If FRMSTRING = "INVOICE" Then
            If ClientName = "7HOSPITALITY" Then
                tempattachment = "Invoice No. 7HM-" & BOOKINGNO
            Else
                tempattachment = "Invoice No. " & BOOKINGNO
            End If
        ElseIf FRMSTRING = "VOUCHER" Then
            tempattachment = "Voucher No. " & BOOKINGNO
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
                oDfDopt.DiskFileName = Application.StartupPath & "\Voucher No. " & BOOKINGNO & ".PDF"
                'If ClientName = "SHREEJI" Then
                '    expo = RPTVOUCHER_SHREEJI.ExportOptions
                '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                '    expo.DestinationOptions = oDfDopt
                '    RPTVOUCHER_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                '    RPTVOUCHER_SHREEJI.Export()
                '    RPTVOUCHER_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                If ClientName = "BARODA" Then
                    expo = RPTVOUCHER_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTVOUCHER_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTVOUCHER_BARODA.Export()
                    RPTVOUCHER_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "SAFAR" Then
                    '    expo = RPTVOUCHER_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTVOUCHER_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTVOUCHER_SAFAR.Export()
                End If
            ElseIf FRMSTRING = "INVOICE" Then
                If ClientName = "7HOSPITALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. 7HM-" & BOOKINGNO & ".PDF"
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                End If
                If ClientName = "CLASSIC" Then
                    expo = RPTINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    If PRINTGUESTNAME = True Then
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 1
                    Else
                        RPTINVOICE.DataDefinition.FormulaFields("PRINTGUEST").Text = 0
                    End If
                    RPTINVOICE.Export()

                    'ElseIf ClientName = "SEASONED" Then
                    '    expo = RPTINVOICE_SEASONED.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SEASONED.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTINVOICE_SEASONED.Export()

                    'ElseIf ClientName = "SAFAR" Then
                    '    expo = RPTINVOICE_SAFAR.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SAFAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
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
                    '    expo = RPTINVOICE_SHREEJI.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTINVOICE_SHREEJI.Export()
                    '    RPTINVOICE_SHREEJI.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BARODA" Then
                    expo = RPTINVOICE_BARODA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTINVOICE_BARODA.Export()
                    RPTINVOICE_BARODA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "BELLA" Then
                    expo = RPTINVOICE_BELLA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTINVOICE_BELLA.Export()
                    RPTINVOICE_BELLA.DataDefinition.FormulaFields("SENDMAIL").Text = 0


                ElseIf ClientName = "PRATAMESH" Then
                    expo = RPTINVOICE_PRATAMESH.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_PRATAMESH.DataDefinition.FormulaFields("SENDMAIL").Text = 1
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

                ElseIf ClientName = "HEENKAR" Then
                    RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_HEENKAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_HEENKAR.Export()
                    RPTINVOICE_HEENKAR.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "ARHAM" Then
                    '    RPTINVOICE_ARHAM.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_ARHAM.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_ARHAM.Export()
                    '    RPTINVOICE_ARHAM.DataDefinition.FormulaFields("SENDMAIL").Text = 0

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

                    'ElseIf ClientName = "MANYA" Then
                    '    RPTINVOICE_MANYA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_MANYA.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_MANYA.Export()
                    '    RPTINVOICE_MANYA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                    'ElseIf ClientName = "WHITEPEARL" Then
                    '    RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    expo = RPTINVOICE_WHITEPEARL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_WHITEPEARL.Export()
                    '    RPTINVOICE_WHITEPEARL.DataDefinition.FormulaFields("SENDMAIL").Text = 0

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
                    '    RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTINVOICE_MAHARAJA.Export()

                ElseIf ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_KHANNA.Export()
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'ElseIf ClientName = "TOPCOMM" Then
                    '    expo = RPTINVOICE_TOPCOMM.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTINVOICE_TOPCOMM.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTINVOICE_TOPCOMM.Export()

                Else
                    expo = RPTINVOICE_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTINVOICE_COMMON.Export()
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class