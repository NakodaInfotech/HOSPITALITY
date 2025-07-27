Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ForexEnquiryDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Dim RPTALLDTLS As New ForexEnquiryAllDetails
    Dim RPTGUESTDTLS As New ForexEnquiryGuestWiseDetails
    Dim RPTGUESTSUMM As New ForexEnquiryGuestWiseSummary
    Dim RPTCURRDTLS As New ForexEnquiryCurrencyWiseDetails
    Dim RPTCURRSUMM As New ForexEnquiryCurrencyWiseSummary
    Dim RPTHANDLEDBYDTLS As New ForexEnquiryHandledByDetails
    Dim RPTHANDLEDBYSUMM As New ForexEnquiryHandledBySummary
    Dim RPTSOURCEDTLS As New ForexEnquirySourceWiseDetails
    Dim RPTSOURCESUMM As New ForexEnquirySourceWiseSummary
    Dim RPTSTATUSDTLS As New ForexEnquiryStatusWiseDetails
    Dim RPTSTATUSSUMM As New ForexEnquiryStatusWiseSummary
    Dim RPTMONTHLY As New ForexEnquiryMonthWise

    Dim RPTPENDING As New ForexEnquiryPendingEnquiries
    Dim RPTCLOSED As New ForexEnquiryClosedEnquiries
    Dim RPTCOMPLETED As New ForexEnquiryConfirmedEnquiries

    Private Sub ForexEnquiryDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub ForexEnquiryDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

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

            If FRMSTRING = "ALLDTLS" Then crTables = RPTALLDTLS.Database.Tables

            If FRMSTRING = "GUESTWISEDTLS" Then crTables = RPTGUESTDTLS.Database.Tables
            If FRMSTRING = "GUESTWISESUMM" Then crTables = RPTGUESTSUMM.Database.Tables

            If FRMSTRING = "CURRENCYWISEDTLS" Then crTables = RPTCURRDTLS.Database.Tables
            If FRMSTRING = "CURRENCYWISESUMM" Then crTables = RPTCURRSUMM.Database.Tables

            If FRMSTRING = "HANDLEDWISEDTLS" Then crTables = RPTHANDLEDBYDTLS.Database.Tables
            If FRMSTRING = "HANDLEDWISESUMM" Then crTables = RPTHANDLEDBYSUMM.Database.Tables

            If FRMSTRING = "SOURCEWISEDTLS" Then crTables = RPTSOURCEDTLS.Database.Tables
            If FRMSTRING = "SOURCEWISESUMM" Then crTables = RPTSOURCESUMM.Database.Tables

            If FRMSTRING = "STATUSWISEDTLS" Then crTables = RPTSTATUSDTLS.Database.Tables
            If FRMSTRING = "STATUSWISESUMM" Then crTables = RPTSTATUSSUMM.Database.Tables

            If FRMSTRING = "MONTHLYDTLS" Then crTables = RPTMONTHLY.Database.Tables

            If FRMSTRING = "PENDINGENQ" Then crTables = RPTPENDING.Database.Tables
            If FRMSTRING = "CLOSEDENQ" Then crTables = RPTCLOSED.Database.Tables
            If FRMSTRING = "CONFIRMEDENQ" Then crTables = RPTCOMPLETED.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "ALLDTLS" Then
                crpo.ReportSource = RPTALLDTLS
                RPTALLDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GUESTWISEDTLS" Then
                crpo.ReportSource = RPTGUESTDTLS
                RPTGUESTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GUESTWISESUMM" Then
                crpo.ReportSource = RPTGUESTSUMM
                RPTGUESTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CURRENCYWISEDTLS" Then
                crpo.ReportSource = RPTCURRDTLS
                RPTCURRDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CURRENCYWISESUMM" Then
                crpo.ReportSource = RPTCURRSUMM
                RPTCURRSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "HANDLEDWISEDTLS" Then
                crpo.ReportSource = RPTHANDLEDBYDTLS
                RPTHANDLEDBYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "HANDLEDWISESUMM" Then
                crpo.ReportSource = RPTHANDLEDBYSUMM
                RPTHANDLEDBYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SOURCEWISEDTLS" Then
                crpo.ReportSource = RPTSOURCEDTLS
                RPTSOURCEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SOURCEWISESUMM" Then
                crpo.ReportSource = RPTSOURCESUMM
                RPTSOURCESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "STATUSWISEDTLS" Then
                crpo.ReportSource = RPTSTATUSDTLS
                RPTSTATUSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "STATUSWISESUMM" Then
                crpo.ReportSource = RPTSTATUSSUMM
                RPTSTATUSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PENDINGENQ" Then
                crpo.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CLOSEDENQ" Then
                crpo.ReportSource = RPTCLOSED
                RPTCLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CONFIRMEDENQ" Then
                crpo.ReportSource = RPTCOMPLETED
                RPTCOMPLETED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "MONTHLYDTLS" Then
                crpo.ReportSource = RPTMONTHLY
            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\Forex Enquiry Details.pdf"

            If FRMSTRING = "ALLDTLS" Then
                expo = RPTALLDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALLDTLS.Export()
            ElseIf FRMSTRING = "GUESTWISEDTLS" Then
                expo = RPTGUESTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGUESTDTLS.Export()
            ElseIf FRMSTRING = "GUESTWISESUMM" Then
                expo = RPTGUESTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGUESTSUMM.Export()
            ElseIf FRMSTRING = "CURRENCYWISEDTLS" Then
                expo = RPTCURRDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCURRDTLS.Export()
            ElseIf FRMSTRING = "CURRENCYWISESUMM" Then
                expo = RPTCURRSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCURRSUMM.Export()
            ElseIf FRMSTRING = "HANDLEDWISEDTLS" Then
                expo = RPTHANDLEDBYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHANDLEDBYDTLS.Export()
            ElseIf FRMSTRING = "HANDLEDWISESUMM" Then
                expo = RPTHANDLEDBYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHANDLEDBYSUMM.Export()
            ElseIf FRMSTRING = "SOURCEWISEDTLS" Then
                expo = RPTSOURCEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOURCEDTLS.Export()
            ElseIf FRMSTRING = "SOURCEWISESUMM" Then
                expo = RPTSOURCESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOURCESUMM.Export()
            ElseIf FRMSTRING = "STATUSWISEDTLS" Then
                expo = RPTSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTATUSDTLS.Export()
            ElseIf FRMSTRING = "STATUSWISESUMM" Then
                expo = RPTSTATUSSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTATUSSUMM.Export()
            ElseIf FRMSTRING = "PENDINGENQ" Then
                expo = RPTPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDING.Export()
            ElseIf FRMSTRING = "CLOSEDENQ" Then
                expo = RPTCLOSED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCLOSED.Export()
            ElseIf FRMSTRING = "CONFIRMEDENQ" Then
                expo = RPTCOMPLETED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMPLETED.Export()
            ElseIf FRMSTRING = "MONTHLYDTLS" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "Forex Enquiry Details"
            Dim objmail As New SendMail
            objmail.attachment = TEMPATTACHMENT
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class