
Imports System.Windows.Forms
Imports BL

Public Class EntryDetails

    Sub FILLGRID()
        Try
            Dim TEMPCONDITION As String = ""
            If chkdate.CheckState = CheckState.Checked Then TEMPCONDITION = TEMPCONDITION & " AND ENTRYDATE > = '" & Format(Convert.ToDateTime(fromdate.Value).Date, "MM/dd/yyyy") & "' AND ENTRYDATE < = '" & Format(Convert.ToDateTime(Todate.Value).Date, "MM/dd/yyyy") & "'" Else TEMPCONDITION = TEMPCONDITION & " and ENTRYDATE = '" & Format(Convert.ToDateTime(Mydate).Date, "MM/dd/yyyy") & "'"
            Dim Objcls As New ClsCommonMaster
            Dim dt As DataTable = Objcls.search(" ENTRYNO,ENTRYDATE,FORMNAME,USERNAME, CMPNAME ", " ", "  ENTRYVIEW ", " and CMPID = " & CmpId & " AND YEARID = " & YearId & TEMPCONDITION & " ORDER BY ENTRYDATE ")
            griddetails.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EntryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub EntryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fromdate.Value = Mydate
            Todate.Value = Mydate
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fromdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fromdate.Validating
        Try
            If Todate.Value.Date < fromdate.Value.Date Then
                MsgBox("Invalid Check In Date")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Todate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Todate.Validating
        Try
            If fromdate.Value.Date > Todate.Value.Date Then
                MsgBox("Invalid date")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "Entry logs.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each Proc As Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                Proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Entry Details"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Entry Details", gridpayment.VisibleColumns.Count + gridpayment.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            If chkdate.CheckState = CheckState.Checked Then FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class