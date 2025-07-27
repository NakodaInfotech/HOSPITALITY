
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SaleTDSReport

    Private Sub SaleTDSReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RDDETAILS.Checked = True Then
                gridbill.Columns("BILLINITIALS").Visible = True
                gridbill.Columns("GUESTNAME").Visible = True
                gridbill.Columns("FLIGHTNAME").Visible = True
                gridbill.Columns("DATE").Visible = True
                dt = objclsCMST.search(" * ", "", " SALETDS ", WHERECLAUSE & " AND YEARID = " & YearId & " ORDER BY DATE,BOOKINGNO")
            Else
                gridbill.Columns("BILLINITIALS").Visible = False
                gridbill.Columns("GUESTNAME").Visible = False
                gridbill.Columns("FLIGHTNAME").Visible = False
                gridbill.Columns("DATE").Visible = False
                dt = objclsCMST.search(" NAME, SUM(TOTALSALE) AS TOTALSALE, SUM(COMMPER) AS COMMPER, SUM(COMMRS) AS COMMRS, SUM(TDSPER) AS TDSPER, SUM(TDSRS) AS TDSRS, SUM(GRANDTOTAL) AS GRANDTOTAL ", "", " SALETDS ", WHERECLAUSE & " AND YEARID = " & YearId & " GROUP BY NAME ")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SaleTDSReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim WHERECLAUSE As String = ""
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' "
            fillgrid(WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Sale TDS.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Sale TDS"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale TDS", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class