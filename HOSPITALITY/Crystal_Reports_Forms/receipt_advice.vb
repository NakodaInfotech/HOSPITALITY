
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class receipt_advice

    Public recno As Integer
    Public recname As String
    Public REGNAME As String
    Dim RPTRECADVICE As New recreport

    Private Sub receipt_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub receipt_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try


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
            crTables = RPTRECADVICE.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            'TRY INCH TO TWIP CONVERTOR FOR INCHES TO TWIPS
            Dim LOGO As BlobFieldObject = DirectCast(RPTRECADVICE.Section2.ReportObjects("LOGO"), BlobFieldObject)
            If ClientName = "AERO" Then
                LOGO.Height = 1036.8
                LOGO.Width = 3182.4
            ElseIf ClientName = "APPLE" Then
                LOGO.Height = 1036.8
                LOGO.Width = 3182.4
            ElseIf ClientName = "WAHWAH" Then
                LOGO.Height = 719.2
                LOGO.Width = 3339.2
            ElseIf ClientName = "STARVISA" Then
                LOGO.Height = 1627.2
                LOGO.Width = 1929.6
            Else
                LOGO.Height = 1036.8
                LOGO.Width = 3182.4
            End If

            strsearch = strsearch & "  {receiptmaster.receipt_no}= " & recno & " and {RECEIPT_REPORT.REGNAME}= '" & REGNAME & "' and {ledgermaster.Acc_cmpname} = '" & recname & "' and {receiptmaster.receipt_cmpid} = " & CmpId & " and {receiptmaster.receipt_LOCATIONid} = " & Locationid & " and {receiptmaster.receipt_YEARid} = " & YearId
            If ClientName = "ROYALHOLIDAYS" Then
                RPTRECADVICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            End If
            CRPO.SelectionFormula = strsearch
            CRPO.ReportSource = RPTRECADVICE
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
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\Rec Advice.PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            objmail.subject = "RECEIPT ADVICE"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\Rec Advice.PDF"
            RPTRECADVICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            expo = RPTRECADVICE.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            RPTRECADVICE.Export()
            RPTRECADVICE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class