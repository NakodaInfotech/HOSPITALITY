
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class receivabledesign

    Dim rptpsum As New receivableoutstanding
    Dim RPTPACKOUT As New PackReceivableOutstanding
    Dim RPTAIROUT As New AirReceivableOutstanding
    Dim RPTRAILOUT As New RailReceivableOutstanding
    Dim RPTINTOUT As New IntReceivableOutstanding
    Public strsumm As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public FRMSTRING As String

    Private Sub receivabledesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "receivableoutstanding" Or FRMSTRING = "receivableoutstandingsummary" Then
                crTables = rptpsum.Database.Tables
                strsearch = strsearch & " and  {HOTELBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and  {HOTELBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and  {HOTELBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDING" Or FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTPACKOUT.Database.Tables
                strsearch = strsearch & " and  {HOLIDAYPACKAGEMASTER.BOOKING_cmpid}=" & CmpId & " and  {HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONid}=" & Locationid & " and  {HOLIDAYPACKAGEMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDING" Or FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTAIROUT.Database.Tables
                strsearch = strsearch & " and  {AIRLINEBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and  {AIRLINEBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and  {AIRLINEBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "RAIL RECEIVABLEOUTSTANDING" Or FRMSTRING = "RAIL RECEIVABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTRAILOUT.Database.Tables
                strsearch = strsearch & " and  {RAILBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and  {RAILBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and  {RAILBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            ElseIf FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDINGSUMMARY" Then
                crTables = RPTINTOUT.Database.Tables
                strsearch = strsearch & " and  {INTERNATIONALBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and  {INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONid}=" & Locationid & " and  {INTERNATIONALBOOKINGMASTER.BOOKING_YEARid}=" & YearId
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************

            CRPO.SelectionFormula = strsearch
            If strsumm = "" Then
                rptpsum.DataDefinition.FormulaFields("txt").Text = 1
                rptpsum.DataDefinition.FormulaFields("TITLE").Text = "'RECEIVABLE OUTSTANDING DETAILS'"
            Else
                rptpsum.DataDefinition.FormulaFields("txt").Text = 0
                rptpsum.DataDefinition.FormulaFields("TITLE").Text = "'RECEIVABLE SUMMARY'"
            End If

            If FRMSTRING = "receivableoutstanding" Or FRMSTRING = "receivableoutstandingsummary" Then
                CRPO.ReportSource = rptpsum
            ElseIf FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDING" Or FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTPACKOUT
            ElseIf FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDING" Or FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTAIROUT
            ElseIf FRMSTRING = "RAIL RECEIVABLEOUTSTANDING" Or FRMSTRING = "RAIL RECEIVABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTRAILOUT
            ElseIf FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDINGSUMMARY" Then
                CRPO.ReportSource = RPTINTOUT
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        tempattachment = "OUTSTANDINGREPORT"

        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
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

            oDfDopt.DiskFileName = Application.StartupPath & "\OUTSTANDINGREPORT.PDF"

            If FRMSTRING = "receivableoutstanding" Or FRMSTRING = "receivableoutstandingsummary" Then
                expo = rptpsum.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptpsum.Export()
            ElseIf FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDING" Or FRMSTRING = "PACKAGE RECEIVABLEOUTSTANDINGSUMMARY" Then
                expo = RPTPACKOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKOUT.Export()
            ElseIf FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDING" Or FRMSTRING = "AIRLINE RECEIVABLEOUTSTANDINGSUMMARY" Then
                expo = RPTAIROUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAIROUT.Export()
            ElseIf FRMSTRING = "RAIL RECEIVABLEOUTSTANDING" Or FRMSTRING = "RAIL RECEIVABLEOUTSTANDINGSUMMARY" Then
                expo = RPTRAILOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTRAILOUT.Export()
            ElseIf FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDING" Or FRMSTRING = "INTERNATIONAL RECEIVABLEOUTSTANDINGSUMMARY" Then
                expo = RPTINTOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINTOUT.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class