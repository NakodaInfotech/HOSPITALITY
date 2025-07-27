
Imports BL

Public Class TargetReport

    Private Sub TargetReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" BOOKEDBYMASTER.BOOKEDBY_NAME AS NAME, TARGETMASTER.TARGET_AMOUNT AS TARGET, SUM(RESERVATION_SALEREPORT.GROSSAMT) AS ACHIEVED, ROUND(((SUM(RESERVATION_SALEREPORT.GROSSAMT) / TARGETMASTER.TARGET_AMOUNT )*100),2) AS PERACHIEVED , TARGETMASTER.TARGET_ALIGIBILITY  AS PERELIGIBILITY ,  CAST((CASE WHEN (ROUND(((SUM(RESERVATION_SALEREPORT.GROSSAMT) / TARGETMASTER.TARGET_AMOUNT )*100),2)) >= TARGETMASTER.TARGET_ALIGIBILITY  THEN 1 ELSE 0 END) AS BIT) AS ELIGIBLE,   TARGETMASTER.TARGET_INCENTIVES AS PERINCENTIVES , (CASE WHEN (ROUND(((SUM(RESERVATION_SALEREPORT.GROSSAMT) / TARGETMASTER.TARGET_AMOUNT )*100),2)) >= TARGETMASTER.TARGET_ALIGIBILITY  THEN ROUND((TARGETMASTER.TARGET_INCENTIVES * SUM(RESERVATION_SALEREPORT.GROSSAMT) )/100,2) ELSE 0 END) AS INCENTIVES", "", "   RESERVATION_SALEREPORT INNER JOIN BOOKEDBYMASTER ON RESERVATION_SALEREPORT.BOOKEDBY = BOOKEDBYMASTER.BOOKEDBY_NAME AND RESERVATION_SALEREPORT.CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND RESERVATION_SALEREPORT.LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND RESERVATION_SALEREPORT.YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID INNER JOIN TARGETMASTER ON BOOKEDBYMASTER.BOOKEDBY_ID = TARGETMASTER.TARGET_BOOKEDBYID AND BOOKEDBYMASTER.BOOKEDBY_CMPID = TARGETMASTER.TARGET_CMPID AND BOOKEDBYMASTER.BOOKEDBY_LOCATIONID = TARGETMASTER.TARGET_LOCATIONID AND BOOKEDBYMASTER.BOOKEDBY_YEARID = TARGETMASTER.TARGET_YEARID ", " AND MONTH(RESERVATION_SALEREPORT.DATE )  = " & dtfrom.Value.Date.Month & " AND RESERVATION_SALEREPORT.CANCELLED = 0 AND RESERVATION_SALEREPORT.AMENDED = 0 AND RESERVATION_SALEREPORT.CMPID =" & CmpId & " AND RESERVATION_SALEREPORT.LOCATIONID = " & Locationid & " AND RESERVATION_SALEREPORT.YEARID = " & YearId & " GROUP BY BOOKEDBYMASTER.BOOKEDBY_NAME, TARGETMASTER.TARGET_AMOUNT, TARGETMASTER.TARGET_ALIGIBILITY, TARGETMASTER.TARGET_INCENTIVES ORDER BY BOOKEDBY_NAME ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TargetReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Target Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = AccFrom.Date & " - " & AccTo.Date
            
            opti.SheetName = "Target Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Target Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMONTH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMONTH.Validated
        If CMBMONTH.Text.Trim = "" Then CMBMONTH.SelectedIndex = 0
        GETDATE()
    End Sub

    Sub GETDATE()
        Try
            If CMBMONTH.Text.Trim = "January" Then
                dtfrom.Value = "01/01/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "February" Then
                dtfrom.Value = "01/02/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "March" Then
                dtfrom.Value = "01/03/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "April" Then
                dtfrom.Value = "01/04/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "May" Then
                dtfrom.Value = "01/05/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "June" Then
                dtfrom.Value = "01/06/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "July" Then
                dtfrom.Value = "01/07/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "August" Then
                dtfrom.Value = "01/08/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "September" Then
                dtfrom.Value = "01/09/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "October" Then
                dtfrom.Value = "01/10/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "November" Then
                dtfrom.Value = "01/11/" & Year(AccFrom)
            ElseIf CMBMONTH.Text.Trim = "December" Then
                dtfrom.Value = "01/12/" & Year(AccFrom)
            End If
            dtto.Value = dtfrom.Value.AddMonths(1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(gridbill.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(gridbill.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal BOOKEDBY As String)
        Try
            If BOOKEDBY <> "" Then
                Dim OBJRES As New ReservationDetails
                OBJRES.MdiParent = MDIMain
                OBJRES.STRSEARCH = " AND BOOKEDBY = '" & BOOKEDBY & "' AND MONTH(DATE) = " & dtfrom.Value.Date.Month
                OBJRES.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class