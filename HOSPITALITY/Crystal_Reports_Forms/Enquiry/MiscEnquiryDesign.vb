
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class MiscEnquiryDesign
    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Dim RPTALLDTLS As New MiscEnquiryAllDetails
    Dim RPTHANDLEDBYDTLS As New MiscEnquiryHandledByDetails
    Dim RPTSOURCEDTLS As New MiscEnquirySourceWiseDetails
    Dim RPTSTATUSDTLS As New MiscEnquiryStatusWiseDetails
    Dim RPTMONTHLY As New MiscEnquiryMonthWise

    Dim RPTPENDING As New MiscEnquiryPendingEnquiries
    Dim RPTCLOSED As New MiscEnquiryClosedEnquiries
    Dim RPTCOMPLETED As New MiscEnquiryConfirmedEnquiries

    Private Sub MiscEnquiryDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub MiscEnquiryDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "HANDLEDWISEDTLS" Then crTables = RPTHANDLEDBYDTLS.Database.Tables
            If FRMSTRING = "SOURCEWISEDTLS" Then crTables = RPTSOURCEDTLS.Database.Tables
            If FRMSTRING = "STATUSWISEDTLS" Then crTables = RPTSTATUSDTLS.Database.Tables
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
            ElseIf FRMSTRING = "HANDLEDWISEDTLS" Then
                CRPO.ReportSource = RPTHANDLEDBYDTLS
                RPTHANDLEDBYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
         
            ElseIf FRMSTRING = "SOURCEWISEDTLS" Then
                crpo.ReportSource = RPTSOURCEDTLS
                RPTSOURCEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            
            ElseIf FRMSTRING = "STATUSWISEDTLS" Then
                crpo.ReportSource = RPTSTATUSDTLS
                RPTSTATUSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PENDINGENQ" Then
                CRPO.ReportSource = RPTPENDING
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
            ElseIf FRMSTRING = "HANDLEDWISEDTLS" Then
                expo = RPTHANDLEDBYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHANDLEDBYDTLS.Export()
            ElseIf FRMSTRING = "SOURCEWISEDTLS" Then
                expo = RPTSOURCEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOURCEDTLS.Export()
           
            ElseIf FRMSTRING = "STATUSWISEDTLS" Then
                expo = RPTSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTATUSDTLS.Export()
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

    Private Sub SENDMAILTOOL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SENDMAILTOOL.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = " Misc Enquiry Details"
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