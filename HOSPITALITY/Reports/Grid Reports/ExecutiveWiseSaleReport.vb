
Imports BL

Public Class ExecutiveWiseSaleReport

    Public SALETYPE As String
    Public TEMPCITYNAME As String

    Private Sub ExecutiveWiseSaleReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim dt As DataTable
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = WHERECLAUSE & " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
            If SALETYPE <> "" Then WHERECLAUSE = WHERECLAUSE & " AND TYPE = '" & SALETYPE & "'"
            If TEMPCITYNAME <> "" Then WHERECLAUSE = WHERECLAUSE & " AND CITYNAME = '" & TEMPCITYNAME & "'"
            dt = objclsCMST.search(" TYPE, CITYNAME, BOOKEDBY, SUM(SALEAMT) AS SALEAMT, SUM(GROSSAMT) AS GROSSAMT, (CASE WHEN SUM(GROSSAMT) > 0 THEN ROUND((SUM(GROSSAMT)/SUM(SALEAMT))* 100,2) ELSE 0 END) AS GROSSPER, SUM(ROOMS) AS ROOMS, SUM(NIGHTS) AS NIGHTS, SUM(TOTALNIGHTS) AS TOTALNIGHTS ", "", " CITYWISESALE ", WHERECLAUSE & " AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY TYPE, CITYNAME, BOOKEDBY ORDER BY TYPE, CITYNAME, BOOKEDBY ")
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
            'Dim OBJ As New HotelWiseSaleReport
            'OBJ.SALETYPE = gridbill.GetFocusedRowCellValue("TYPE")
            'OBJ.TEMPCITYNAME = gridbill.GetFocusedRowCellValue("CITYNAME")
            'OBJ.MdiParent = MDIMain
            'OBJ.Show()
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

    Private Sub ExecutiveWiseSaleReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class