
Imports BL
Imports System.Windows.Forms

Public Class GSTCNDNDetailsReport

    Public WHERECLAUSE As String = ""
    Public FROMDATE, TODATE As Date
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub PurchaseGSTReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            Dim dt As DataTable = objclsCMST.search("  TYPE AS CNTYPE, INITIALS, DATE, NAME, BILLINITIALS, GSTIN, STATENAME, STATECODE, HSNCODE,TAXABLEAMT, CGSTPER, CGSTAMT, SGSTPER, SGSTAMT, IGSTPER, IGSTAMT, GTOTAL  ", "", " GSTCREDITDEBITNOTE ", WHERECLAUSE & " ORDER BY DATE, CNNO")
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
            'Dim PATH As String = ""
            'If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            'PATH = Application.StartupPath & "\Credit/Debit Note Details GST Report.XLS"

            'Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            'opti.ShowGridLines = True

            'Dim workbook As String = PATH
            'If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            'GC.Collect()

            'Dim PERIOD As String = ""
            'PERIOD = FROMDATE & " - " & TODATE

            'opti.SheetName = "Credit/Debit Note Details GST Report"
            'gridbill.ExportToXls(PATH, opti)
            'EXCELCMPHEADER(PATH, "Credit/Debit Note Details GST Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\CN-DN GST Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = FROMDATE & " - " & TODATE

            opti.SheetName = "CN-DN GST Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "CN-DN GST Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

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