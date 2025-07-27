
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class OutstandingDesign

    Dim RPTOUTSTANDINGALLSUMMREC As New OutstandingReport_All_Summary_Rec
    Dim RPTOUTSTANDINGALLSUMMPAY As New OutstandingReport_All_Summary_Pay
    Dim RPTOUTSTANDINGALLDTLS As New OutstandingReport_All_Details

    Dim RPTOUTSTANDINGPAYSUMM As New OutstandingReport_Summary_Pay
    Dim RPTOUTSTANDINGRECSUMM As New OutstandingReport_Summary_Rec
    Dim RPTOUTSTANDINGPAYDTLS As New OutstandingReport_Details_Pay
    Dim RPTOUTSTANDINGRECDTLS As New OutstandingReport_Details_Rec

    Dim RPTALLOUTSTANDINGREC As New OutstandingReport_AllBills_Summary_Rec
    Dim RPTALLOUTSTANDINGPAY As New OutstandingReport_AllBills_Summary_Pay

    Dim RPTONLYOUTSTANDINGREC As New OutstandingReport_AllBills_Summary_Rec
    Dim RPTONLYOUTSTANDINGPAY As New OutstandingReport_AllBills_Summary_Pay

    Dim RPTREMINDERLETTER As New OutstandingReport_Letter


    'NEWLY ADDED
    Public REPORTNAME As String
    Public DAYS As String
    Public ADDRESS As Integer
    Public NEWPAGE As Boolean
    Public FRMSTRING As String
    Public selfor_ss As String
    Public PERIOD As String
    Public INTEREST As Double
    Public INTDAYS As Integer
    Public SHOWPRINTDATE As Integer

    Private Sub OutstandingDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then crTables = RPTOUTSTANDINGALLSUMMREC.Database.Tables
            If FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then crTables = RPTOUTSTANDINGALLSUMMPAY.Database.Tables
            If FRMSTRING = "OUTSTANDINGALLDTLS" Then crTables = RPTOUTSTANDINGALLDTLS.Database.Tables

            If FRMSTRING = "OUTSTANDINGPAYSUMM" Then crTables = RPTOUTSTANDINGPAYSUMM.Database.Tables
            If FRMSTRING = "OUTSTANDINGRECSUMM" Then crTables = RPTOUTSTANDINGRECSUMM.Database.Tables
            If FRMSTRING = "OUTSTANDINGPAYDTLS" Then crTables = RPTOUTSTANDINGPAYDTLS.Database.Tables
            If FRMSTRING = "OUTSTANDINGRECDTLS" Then crTables = RPTOUTSTANDINGRECDTLS.Database.Tables

            
            If FRMSTRING = "ALLBILLOUTSTANDINGREC" Then crTables = RPTALLOUTSTANDINGREC.Database.Tables
            If FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then crTables = RPTALLOUTSTANDINGPAY.Database.Tables

            If FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then crTables = RPTONLYOUTSTANDINGREC.Database.Tables
            If FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then crTables = RPTONLYOUTSTANDINGPAY.Database.Tables

            If FRMSTRING = "REMINDERLETTER" Then crTables = RPTREMINDERLETTER.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMREC
                RPTOUTSTANDINGALLSUMMREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLSUMMREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLSUMMREC.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLSUMMREC.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMPAY
                RPTOUTSTANDINGALLSUMMPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLSUMMPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLSUMMPAY.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLSUMMPAY.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGALLDTLS
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGALLDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGALLDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crTables = RPTOUTSTANDINGALLDTLS.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then

                CRPO.ReportSource = RPTOUTSTANDINGPAYSUMM
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGPAYSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGPAYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOUTSTANDINGPAYSUMM.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then

                CRPO.ReportSource = RPTOUTSTANDINGRECSUMM
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGRECSUMM.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGRECSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOUTSTANDINGRECSUMM.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGPAYDTLS
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGPAYDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGPAYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOUTSTANDINGPAYDTLS.Database.Tables

            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then

                CRPO.ReportSource = RPTOUTSTANDINGRECDTLS
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTOUTSTANDINGRECDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                RPTOUTSTANDINGRECDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTOUTSTANDINGRECDTLS.Database.Tables

            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then

                CRPO.ReportSource = RPTALLOUTSTANDINGREC
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTALLOUTSTANDINGREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                crTables = RPTALLOUTSTANDINGREC.Database.Tables

            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then

                CRPO.ReportSource = RPTALLOUTSTANDINGPAY
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTALLOUTSTANDINGPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                crTables = RPTALLOUTSTANDINGPAY.Database.Tables


            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then

                CRPO.ReportSource = RPTONLYOUTSTANDINGREC
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTONLYOUTSTANDINGREC.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTONLYOUTSTANDINGREC.Database.Tables

            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then

                CRPO.ReportSource = RPTONLYOUTSTANDINGPAY
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("REPORTNAME").Text = "'" & REPORTNAME & "'"
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("CALDAYS").Text = "'" & DAYS & "'"
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("ADDRESS").Text = ADDRESS
                RPTONLYOUTSTANDINGPAY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = SHOWPRINTDATE
                crTables = RPTONLYOUTSTANDINGPAY.Database.Tables

            ElseIf FRMSTRING = "REMINDERLETTER" Then

                CRPO.ReportSource = RPTREMINDERLETTER
                crTables = RPTREMINDERLETTER.Database.Tables
            End If

            CRPO.SelectionFormula = selfor_ss

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMREC
            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLSUMMPAY
            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGALLDTLS
            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then
                CRPO.ReportSource = RPTOUTSTANDINGPAYSUMM
            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then
                CRPO.ReportSource = RPTOUTSTANDINGRECSUMM
            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGPAYDTLS
            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then
                CRPO.ReportSource = RPTOUTSTANDINGRECDTLS
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then
                CRPO.ReportSource = RPTALLOUTSTANDINGREC
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then
                CRPO.ReportSource = RPTALLOUTSTANDINGPAY
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then
                CRPO.ReportSource = RPTONLYOUTSTANDINGREC
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then
                CRPO.ReportSource = RPTONLYOUTSTANDINGPAY
            ElseIf FRMSTRING = "REMINDERLETTER" Then
                CRPO.ReportSource = RPTREMINDERLETTER
            End If
            '************************ END *******************

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\Outstanding Report.PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\Outstanding Report.pdf"

            If FRMSTRING = "OUTSTANDINGALLSUMMREC" Then
                expo = RPTOUTSTANDINGALLSUMMREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLSUMMREC.Export()
            ElseIf FRMSTRING = "OUTSTANDINGALLSUMMPAY" Then
                expo = RPTOUTSTANDINGALLSUMMPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLSUMMPAY.Export()
            ElseIf FRMSTRING = "OUTSTANDINGALLDTLS" Then
                expo = RPTOUTSTANDINGALLDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGALLDTLS.Export()
            ElseIf FRMSTRING = "OUTSTANDINGPAYSUMM" Then
                expo = RPTOUTSTANDINGPAYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGPAYSUMM.Export()
            ElseIf FRMSTRING = "OUTSTANDINGRECSUMM" Then
                expo = RPTOUTSTANDINGRECSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGRECSUMM.Export()
            ElseIf FRMSTRING = "OUTSTANDINGPAYDTLS" Then
                expo = RPTOUTSTANDINGPAYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGPAYDTLS.Export()
            ElseIf FRMSTRING = "OUTSTANDINGRECDTLS" Then
                expo = RPTOUTSTANDINGRECDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTOUTSTANDINGRECDTLS.Export()
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGREC" Then
                expo = RPTALLOUTSTANDINGREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALLOUTSTANDINGREC.Export()
            ElseIf FRMSTRING = "ALLBILLOUTSTANDINGPAY" Then
                expo = RPTALLOUTSTANDINGPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALLOUTSTANDINGPAY.Export()
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGREC" Then
                expo = RPTONLYOUTSTANDINGREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTONLYOUTSTANDINGREC.Export()
            ElseIf FRMSTRING = "ONLYBILLOUTSTANDINGPAY" Then
                expo = RPTONLYOUTSTANDINGPAY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTONLYOUTSTANDINGPAY.Export()
            ElseIf FRMSTRING = "REMINDERLETTER" Then
                expo = RPTREMINDERLETTER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREMINDERLETTER.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub OutstandingDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class