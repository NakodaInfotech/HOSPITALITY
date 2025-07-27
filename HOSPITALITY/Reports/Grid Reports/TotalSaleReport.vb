
Imports BL

Public Class TotalSaleReport

    Private Sub TotalSaleReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.KeyCode = Keys.O And e.Alt = True) Then
                Call CMDOK_Click(sender, e)
            ElseIf (e.KeyCode = Keys.S And e.Alt = True) Then
                Call cmdshowdetails_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
           
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            Dim dt As DataTable

            dt = objclsCMST.search(" TYPE, SUM(PURAMT) AS PURAMT, SUM(SALEAMT) AS SALEAMT, SUM(GROSSAMT) AS GROSSAMT, (CASE WHEN SUM(GROSSAMT) > 0 THEN ROUND((SUM(GROSSAMT) / SUM(SALEAMT))*100,2) ELSE 0 END) AS GROSSPER ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & " AND TYPE <> 'OPENING' AND SALEAMT >0  AND YEARID = " & YearId & " GROUP BY TYPE")

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Total Sale Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True


            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Total Sale Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Total Sale Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            If RBCITYWISE.Checked = True Then
                Dim OBJ As New CityWiseSaleReport
                OBJ.SALETYPE = gridbill.GetFocusedRowCellValue("TYPE")
                OBJ.chkdate.CheckState = CheckState.Checked
                OBJ.dtfrom.Value = dtfrom.Value.Date
                OBJ.dtto.Value = dtto.Value.Date
                OBJ.MdiParent = MDIMain
                OBJ.Show()
            ElseIf RBHOTELWISE.Checked = True Then
                Dim OBJ As New HotelWiseSaleReport
                OBJ.SALETYPE = gridbill.GetFocusedRowCellValue("TYPE")
                OBJ.chkdate.CheckState = CheckState.Checked
                OBJ.dtfrom.Value = dtfrom.Value.Date
                OBJ.dtto.Value = dtto.Value.Date
                OBJ.MdiParent = MDIMain
                OBJ.Show()
            ElseIf RBEXECUTIVE.Checked = True Then
                Dim OBJ As New ExecutiveWiseSaleReport
                OBJ.SALETYPE = gridbill.GetFocusedRowCellValue("TYPE")
                OBJ.chkdate.CheckState = CheckState.Checked
                OBJ.dtfrom.Value = dtfrom.Value.Date
                OBJ.dtto.Value = dtto.Value.Date
                OBJ.MdiParent = MDIMain
                OBJ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TotalSaleReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            chkdate.CheckState = CheckState.Checked
            dtfrom.Value = Now.Date
            dtto.Value = Now.Date
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class