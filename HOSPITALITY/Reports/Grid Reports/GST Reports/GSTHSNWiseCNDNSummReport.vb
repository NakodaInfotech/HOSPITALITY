
Imports BL
Imports System.Windows.Forms

Public Class GSTHSNWiseCNDNSummReport

    Public WHERECLAUSE As String = ""
    Public FROMDATE, TODATE As Date
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub SaleGSTReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("isnull(HSNCODE,'') AS HSNCODE ,SUM(TAXABLEAMT) AS TAXABLEAMT , SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(GTOTAL) AS GTOTAL  ", "", "  GSTCREDITDEBITNOTE ", WHERECLAUSE & " GROUP BY HSNCODE")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\HSN Credit-Debit Note Wise Summary Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = FROMDATE & " - " & TODATE

            opti.SheetName = "HSN Credit-Debit Note Wise Summary Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "HSN Credit-Debit Note Wise Summary Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleGSTreport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class