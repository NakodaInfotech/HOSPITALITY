Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class MiscVoucherDesign

    Dim RPTINVOICE_TRISHA As New MiscBookingInvoice_TRISHA
    Dim RPTINVOICE_BARODA As New MiscBookingInvoice_BARODA
    Dim RPTINVOICE_BELLA As New MiscBookingInvoice_BELLA
    Dim RPTINVOICE_COMMON As New MiscBookingInvoice_COMMON
    Dim RPTINVOICE_PRATAMESH As New MiscBookingInvoice_PRATAMESH
    Dim RPTINVOICE_SSR As New MiscBookingInvoice_SSR
    Dim RPTINVOICE_AERO As New MiscBookingInvoice_AERO
    Dim RPTINVOICE_STARVISA As New MiscBookingInvoice_STARVISA
    Dim RPTINVOICE_KPNT As New MiscBookingInvoice_KPNT
    Dim RPTINVOICE_MILONI As New MiscBookingInvoice_MILONI
    Dim RPTINVOICE_MATRIX As New MiscBookingInvoice_MATRIX
    Dim RPTINVOICE_SKYMAPS As New MiscBookingInvoice_SKYMAPS
    Dim RPTINVOICE_HEENKAR As New MiscBookingInvoice_HEENKAR
    Dim RPTINVOICE_RAMKRISHNA As New MiscBookingInvoice_RAMKRISHNA
    Dim RPTINVOICE_URMI As New MiscBookingInvoice_URMI
    Dim RPTINVOICE_KHANNA As New MiscBookingInvoice_KHANNA
    Dim RPTINVOICE_CLASSIC As New MiscBookingInvoice_CLASSIC
    Dim RPTINVOICE_APSARA As New MiscBookingInvoice_APSARA

    Dim RPTPROFORMA As New ProformaMiscBookingInvoice_COMMON

    Public strsearch As String
    Public SUBJECT As String
    Public FRMSTRING As String
    Public BOOKINGNO As Integer
    Public SALEREGISTERID As Integer
    Public BOOKTYPE As String
    Public TYPE As String

    Public HIDEAMT As Boolean
    Public PRINTTAX As Boolean
    Public PRINTOTHERCHGS As Boolean
    Public GUESTNAME As String = ""
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub MiscVoucherDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "INVOICE" Then
                Me.Text = "Miscellaneous Sale Invoice"
                If ClientName = "CLASSIC" Then
                    crTables = RPTINVOICE_CLASSIC.Database.Tables
                ElseIf ClientName = "TRISHA" Then
                    crTables = RPTINVOICE_TRISHA.Database.Tables
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
                ElseIf ClientName = "STARVISA" Then
                    crTables = RPTINVOICE_STARVISA.Database.Tables
                ElseIf ClientName = "KPNT" Then
                    crTables = RPTINVOICE_KPNT.Database.Tables
                ElseIf ClientName = "MILONI" Then
                    crTables = RPTINVOICE_MILONI.Database.Tables
                ElseIf ClientName = "MATRIX" Then
                    crTables = RPTINVOICE_MATRIX.Database.Tables
                ElseIf ClientName = "SKYMAPS" Then
                    crTables = RPTINVOICE_SKYMAPS.Database.Tables
                ElseIf ClientName = "HEENKAR" Then
                    crTables = RPTINVOICE_HEENKAR.Database.Tables
                ElseIf ClientName = "RAMKRISHNA" Then
                    crTables = RPTINVOICE_RAMKRISHNA.Database.Tables
                ElseIf ClientName = "URMI" Then
                    crTables = RPTINVOICE_URMI.Database.Tables
                ElseIf ClientName = "KHANNA" Then
                    crTables = RPTINVOICE_KHANNA.Database.Tables
                ElseIf ClientName = "APSARA" Then
                    crTables = RPTINVOICE_APSARA.Database.Tables
                Else

                    crTables = RPTINVOICE_COMMON.Database.Tables
                End If

            ElseIf FRMSTRING = "PROFORMA" Then
                crTables = RPTPROFORMA.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            If FRMSTRING = "INVOICE" Then
                If TYPE = "PURCHASE" Then
                    strsearch = strsearch & " {MISCPURMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {MISCPURMASTER.BOOKING_PURCHASEREGISTERID} = " & SALEREGISTERID & " AND {MISCPURMASTER.BOOKING_cmpid}=" & CmpId & " and {MISCPURMASTER.BOOKING_locationid}=" & Locationid & " and {MISCPURMASTER.BOOKING_yearid}=" & YearId
                Else
                    strsearch = strsearch & " {MISCSALMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {MISCSALMASTER.BOOKING_PURCHASEREGISTERID} = " & SALEREGISTERID & " AND {MISCSALMASTER.BOOKING_cmpid}=" & CmpId & " and {MISCSALMASTER.BOOKING_locationid}=" & Locationid & " and {MISCSALMASTER.BOOKING_yearid}=" & YearId
                End If
            ElseIf FRMSTRING = "PROFORMA" Then
                strsearch = strsearch & " {PROFORMAMISCSALMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {PROFORMAMISCSALMASTER.BOOKING_PURCHASEREGISTERID} = " & SALEREGISTERID & " and {PROFORMAMISCSALMASTER.BOOKING_yearid}=" & YearId
            End If

            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "INVOICE" Then
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = RPTINVOICE_CLASSIC

                ElseIf ClientName = "TRISHA" Then
                    CRPO.ReportSource = RPTINVOICE_TRISHA

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

                ElseIf ClientName = "BARODA" Then
                    CRPO.ReportSource = RPTINVOICE_BARODA

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

                ElseIf ClientName = "APSARA" Then
                    CRPO.ReportSource = RPTINVOICE_APSARA

                    If PRINTTAX = True Then
                        RPTINVOICE_APSARA.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_APSARA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_APSARA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_APSARA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "STARVISA" Then
                    CRPO.ReportSource = RPTINVOICE_STARVISA

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

                ElseIf ClientName = "KPNT" Then
                    CRPO.ReportSource = RPTINVOICE_KPNT

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

                ElseIf ClientName = "MILONI" Then
                    CRPO.ReportSource = RPTINVOICE_MILONI

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


                ElseIf ClientName = "SKYMAPS" Then
                    CRPO.ReportSource = RPTINVOICE_SKYMAPS

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

                ElseIf ClientName = "HEENKAR" Then
                    CRPO.ReportSource = RPTINVOICE_HEENKAR

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

                ElseIf ClientName = "RAMKRISHNA" Then
                    CRPO.ReportSource = RPTINVOICE_RAMKRISHNA

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

                    If PRINTTAX = True Then
                        RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If PRINTOTHERCHGS = True Then
                        RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        RPTINVOICE_URMI.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If

                ElseIf ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    CRPO.ReportSource = RPTINVOICE_KHANNA

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
                Else

                    CRPO.ReportSource = RPTINVOICE_COMMON
                    If PRINTTAX = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 0
                    If PRINTOTHERCHGS = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                End If

            ElseIf FRMSTRING = "PROFORMA" Then
                CRPO.ReportSource = RPTPROFORMA
                If PRINTTAX = True Then RPTPROFORMA.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTPROFORMA.DataDefinition.FormulaFields("PRINTST").Text = 0
                If PRINTOTHERCHGS = True Then RPTPROFORMA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTPROFORMA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
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

            strsearch = strsearch & " {MISCSALMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {MISCSALMASTER.BOOKING_PURCHASEREGISTERID} = " & SALEREGISTERID & " AND {MISCSALMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Hotel Booking Invoice"

                If ClientName = "CLASSIC" Then
                    OBJ = New MiscBookingInvoice_CLASSIC
                    OBJOLD = New MiscBookingInvoice_CLASSICOLD
                ElseIf ClientName = "TRISHA" Then
                    OBJ = New MiscBookingInvoice_TRISHA
                    OBJOLD = New MiscBookingInvoice_TRISHAOLD
                ElseIf ClientName = "BARODA" Then
                    OBJ = New MiscBookingInvoice_BARODA
                    OBJOLD = New MiscBookingInvoice_BARODAOLD
                ElseIf ClientName = "BELLA" Then
                    OBJ = New MiscBookingInvoice_BELLA

                ElseIf ClientName = "PRATAMESH" Then
                    OBJ = New MiscBookingInvoice_PRATAMESH
                    OBJOLD = New MiscBookingInvoice_PRATAMESHOLD
                ElseIf ClientName = "SSR" Then
                    OBJ = New MiscBookingInvoice_SSR
                    OBJOLD = New MiscBookingInvoice_SSROLD
                ElseIf ClientName = "AERO" Then
                    OBJ = New MiscBookingInvoice_AERO
                    OBJOLD = New MiscBookingInvoice_AEROOLD
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    OBJ = New MiscBookingInvoice_AIRTRINITY
                    '    OBJOLD = New MiscBookingInvoice_AIRTRINITYOLD
                ElseIf ClientName = "STARVISA" Then
                    OBJ = New MiscBookingInvoice_STARVISA
                    OBJOLD = New MiscBookingInvoice_STARVISAOLD
                    'ElseIf ClientName = "GLOBE" Then
                    '    OBJ = New MiscBookingInvoice_GLOBE
                    '    OBJOLD = New MiscBookingInvoice_GLOBEOLD
                    'ElseIf ClientName = "TNL" Then
                    '    OBJ = New MiscBookingInvoice_TNL
                ElseIf ClientName = "KPNT" Then
                    OBJ = New MiscBookingInvoice_KPNT
                    OBJOLD = New MiscBookingInvoice_KPNTOLD
                ElseIf ClientName = "MILONI" Then
                    OBJ = New MiscBookingInvoice_MILONI
                    OBJOLD = New MiscBookingInvoice_MILONIOLD
                ElseIf ClientName = "MATRIX" Then
                    OBJ = New MiscBookingInvoice_MATRIX
                ElseIf ClientName = "SKYMAPS" Then
                    OBJ = New MiscBookingInvoice_SKYMAPS
                    OBJOLD = New MiscBookingInvoice_SKYMAPSOLD
                    'ElseIf ClientName = "LUXCREST" Then
                    '    OBJ = New MiscBookingInvoice_LUXCREST
                    '    OBJOLD = New MiscBookingInvoice_LUXCRESTOLD
                ElseIf ClientName = "HEENKAR" Then
                    OBJ = New MiscBookingInvoice_HEENKAR
                    OBJOLD = New MiscBookingInvoice_HEENKAROLD
                ElseIf ClientName = "RAMKRISHNA" Then
                    OBJ = New MiscBookingInvoice_RAMKRISHNA
                    OBJOLD = New MiscBookingInvoice_RAMKRISHNAOLD
                ElseIf ClientName = "URMI" Then
                    OBJ = New MiscBookingInvoice_URMI
                    OBJOLD = New MiscBookingInvoice_URMIOLD
                    'ElseIf ClientName = "SCC" Then
                    '    OBJ = New MiscBookingInvoice_SCC
                    'ElseIf ClientName = "MAHARAJA" Then
                    '    OBJ = New MiscBookingInvoice_MAHARAJA
                    '    OBJOLD = New MiscBookingInvoice_MAHARAJAOLD
                ElseIf ClientName = "KHANNA" Then
                    OBJ = New MiscBookingInvoice_KHANNA
                    OBJOLD = New MiscBookingInvoice_KHANNAOLD
                ElseIf ClientName = "APSARA" Then
                    OBJ = New MiscBookingInvoice_APSARA
                Else
                    OBJ = New MiscBookingInvoice_COMMON
                End If

            ElseIf FRMSTRING = "PROFORMA" Then
                OBJ = New ProformaMiscBookingInvoice_COMMON
            End If


            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("BOOKING_DATE AS DATE", "", " MISCSALMASTER ", " AND MISCSALMASTER.BOOKING_NO= " & BOOKINGNO & " AND MISCSALMASTER.BOOKING_PURCHASEREGISTERID = " & SALEREGISTERID & " AND MISCSALMASTER.BOOKING_yearid=" & YearId)
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
            If ClientName = "7HOSPITALITY" Then
                tempattachment = "Invoice No. 7HM-" & BOOKINGNO
            Else
                tempattachment = "Invoice No. " & BOOKINGNO
            End If

        ElseIf FRMSTRING = "PROFORMA" Then
            tempattachment = "Proforma No. " & BOOKINGNO
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

            If FRMSTRING = "INVOICE" Then
                If ClientName = "7HOSPITALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. 7HM-" & BOOKINGNO & ".PDF"
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                End If
                If ClientName = "CLASSIC" Then
                    RPTINVOICE_CLASSIC.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_CLASSIC.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_CLASSIC.Export()
                    RPTINVOICE_CLASSIC.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                ElseIf ClientName = "TRISHA" Then
                    RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_TRISHA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_TRISHA.Export()
                    RPTINVOICE_TRISHA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

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

                ElseIf ClientName = "APSARA" Then
                    RPTINVOICE_APSARA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    expo = RPTINVOICE_APSARA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_APSARA.Export()
                    RPTINVOICE_APSARA.DataDefinition.FormulaFields("SENDMAIL").Text = 0

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
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box3").ObjectFormat.EnableSuppress = False
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box4").ObjectFormat.EnableSuppress = False
                    expo = RPTINVOICE_URMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_URMI.Export()
                    RPTINVOICE_URMI.DataDefinition.FormulaFields("SENDMAIL").Text = 0
                    'RPTINVOICE_URMI.ReportDefinition.ReportObjects.Item("Box2").ObjectFormat.EnableSuppress = True
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
                    '    RPTINVOICE_MAHARAJA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    '    RPTINVOICE_MAHARAJA.Export()

                ElseIf ClientName = "KHANNA" Then
                    expo = RPTINVOICE_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTINVOICE_KHANNA.Export()
                Else
                    expo = RPTINVOICE_COMMON.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    RPTINVOICE_COMMON.Export()
                    RPTINVOICE_COMMON.DataDefinition.FormulaFields("SENDMAIL").Text = 0

                End If

            ElseIf FRMSTRING = "PROFORMA" Then

                oDfDopt.DiskFileName = Application.StartupPath & "\Proforma No. " & BOOKINGNO & ".PDF"
                expo = RPTPROFORMA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPROFORMA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                RPTPROFORMA.Export()
                RPTPROFORMA.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class