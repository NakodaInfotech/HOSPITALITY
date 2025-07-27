
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class OtherSaleVoucherDesign

    Dim RPTINVOICE_KHANNA As New OtherSaleBookingInvoice_KHANNA
    Dim RPTINVOICE_COMMON As New OtherSaleBookingInvoice_COMMON


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

    Private Sub OtherSaleVoucherDesign_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                If ClientName = "KHANNA" Then
                    crTables = RPTINVOICE_KHANNA.Database.Tables
                Else
                    crTables = RPTINVOICE_COMMON.Database.Tables
                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            If FRMSTRING = "INVOICE" Then
                strsearch = strsearch & " {OTHERSALEPURCHASEMASTER.BOOKING_NO}= " & BOOKINGNO & " and {OTHERSALEPURCHASEMASTER.BOOKING_yearid}=" & YearId
            End If

            CRPO.SelectionFormula = strsearch
            If FRMSTRING = "INVOICE" Then
                If ClientName = "KHANNA" Then
                    RPTINVOICE_KHANNA.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    CRPO.ReportSource = RPTINVOICE_KHANNA
                    If PRINTTAX = True Then RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTST").Text = 0
                    If PRINTOTHERCHGS = True Then RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTINVOICE_KHANNA.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                Else
                    CRPO.ReportSource = RPTINVOICE_COMMON
                    If PRINTTAX = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTST").Text = 0
                    If PRINTOTHERCHGS = True Then RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1 Else RPTINVOICE_COMMON.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
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

            strsearch = strsearch & " {OTHERSALEPURCHASEMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {OTHERSALEPURCHASEMASTER.BOOKING_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                If ClientName = "KHANNA" Then
                    OBJ = New OtherSaleBookingInvoice_KHANNA
                Else
                    OBJ = New OtherSaleBookingInvoice_COMMON
                End If
            End If


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

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String = ""

        If FRMSTRING = "INVOICE" Then
            tempattachment = "Invoice No. " & BOOKINGNO
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
                oDfDopt.DiskFileName = Application.StartupPath & "\Invoice No. " & BOOKINGNO & ".PDF"
                If ClientName = "KHANNA" Then
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

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub



End Class