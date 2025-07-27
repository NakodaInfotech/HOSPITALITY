
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class payment_advice

    Public payno As Integer
    Public payname As String
    Public REGNAME As String
    Public FRMSTRING As String
    Dim RPTPAYMENTADV As New Paymentreport
    Dim OBJCHQPAY As New ChqPayment
    Dim OBJCHQPAY_SCC As New ChqPayment_SCC
    Dim OBJCHQPAY_ARCH As New ChqPayment_BHARAT
    Dim OBJCHQPAY_WORLDSPIN As New ChqPayment_WS_2
    Dim OBJCHQPAY_GLOBE As New ChqPayment_GLOBE

    Private Sub payment_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub payment_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

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

            If FRMSTRING = "CHQPRINT" Then
                If ClientName = "CLASSIC" Then
                    crTables = OBJCHQPAY.Database.Tables
                ElseIf ClientName = "SCC" Then
                    crTables = OBJCHQPAY_SCC.Database.Tables
                ElseIf ClientName = "WORLDSPIN" Then
                    crTables = OBJCHQPAY_WORLDSPIN.Database.Tables
                ElseIf ClientName = "ARCH" Then
                    crTables = OBJCHQPAY_ARCH.Database.Tables
                ElseIf ClientName = "GLOBE" Then
                    crTables = OBJCHQPAY_GLOBE.Database.Tables
                Else
                    crTables = OBJCHQPAY.Database.Tables
                End If
            Else
                crTables = RPTPAYMENTADV.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CHQPRINT" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' And {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If ClientName = "CLASSIC" Then
                    CRPO.ReportSource = OBJCHQPAY
                ElseIf ClientName = "SCC" Then
                    CRPO.ReportSource = OBJCHQPAY_SCC
                ElseIf ClientName = "WORLDSPIN" Then
                    CRPO.ReportSource = OBJCHQPAY_WORLDSPIN
                ElseIf ClientName = "ARCH" Then
                    CRPO.ReportSource = OBJCHQPAY_ARCH
                ElseIf ClientName = "GLOBE" Then
                    CRPO.ReportSource = OBJCHQPAY_GLOBE
                Else
                    CRPO.ReportSource = OBJCHQPAY
                End If
            Else
                strsearch = strsearch & "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.YEARID} = " & YearId
                If ClientName = "ROYALHOLIDAYS" Then
                    RPTPAYMENTADV.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = RPTPAYMENTADV

                'TRY INCH TO TWIP CONVERTOR FOR INCHES TO TWIPS
                Dim LOGO As BlobFieldObject = DirectCast(RPTPAYMENTADV.Section2.ReportObjects("LOGO"), BlobFieldObject)
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

        tempattachment = "PAYMENT"
        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.subject = "PAYMENT ADVICE"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\PAYMENT.PDF"

            If FRMSTRING = "" Then
                RPTPAYMENTADV.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo = RPTPAYMENTADV.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAYMENTADV.Export()
                RPTPAYMENTADV.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


End Class