
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GRoupWiseTransdesign

    Dim retgroupdtls As New groupwisetransdetails
    Dim retgroupdtlsNEW As New GroupWiseTransdtls
    Dim retgroup As New groupwisetrans
    Public frmstring As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String


    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, FROMDATE)
        a2 = DatePart(DateInterval.Month, FROMDATE)
        a3 = DatePart(DateInterval.Year, FROMDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TODATE)
        a12 = DatePart(DateInterval.Month, TODATE)
        a13 = DatePart(DateInterval.Year, TODATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub purchasedesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If frmstring = "GroupWiseTransactionDetails" Then
                crTables = retgroupdtls.Database.Tables
                crTables = retgroupdtlsNEW.Database.Tables
            Else
                crTables = retgroup.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            getFromToDate()

            strsearch = "(" & strsearch & ")"
            If frmstring = "GroupWiseTransactionDetails" Then
                'retgroupdtls.Subreports.Item("GRoupWiseSubreport").RecordSelectionFormula = strsearch
                strsearch = strsearch & " and {REGISTER.acc_cmpid}=" & CmpId & " and {REGISTER.acc_locationid}=" & Locationid & " and {REGISTER.YEARID}=" & YearId
                strsearch = strsearch & " and {@Date} in date " & fromD & " to date " & toD
                CRPO.ReportSource = retgroupdtlsNEW
                CRPO.SelectionFormula = strsearch
            Else
                strsearch = strsearch & " and {REGISTER.acc_cmpid}=" & CmpId & " and {REGISTER.acc_locationid}=" & Locationid & " and {REGISTER.YEARID}=" & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = retgroup
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

        tempattachment = "GroupWiseTransactions"

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


            oDfDopt.DiskFileName = Application.StartupPath & "\GroupWiseTransactions.PDF"
            expo = retgroup.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            retgroup.Export()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class