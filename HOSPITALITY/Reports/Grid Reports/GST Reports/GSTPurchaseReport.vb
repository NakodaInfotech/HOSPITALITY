
Imports BL
Imports System.Windows.Forms

Public Class GSTPurchaseReport

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
            Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT TYPE AS BOOKTYPE, BILLINITIALS, BOOKINGDATE, LEDGERNAME, GSTIN, STATENAME, STATECODE, HSNCODE,  TAXABLEAMT, CGSTPER, CGSTAMT, SGSTPER, SGSTAMT, IGSTPER, IGSTAMT, GTOTAL, BOOKINGNO FROM RESERVATIONDETAILS WHERE 1=1 " & WHERECLAUSE & " UNION ALL SELECT 'NONPURCHASE' AS BOOKTYPE, NONPURCHASE.NP_INITIALS AS BILLINITIALS, NONPURCHASE.NP_DATE AS BOOKINGDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS LEDGERNAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR(100)), '') AS STATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, SUM(NONPURCHASE_DESC.NP_TAXABLEAMT) AS TAXABLEAMT, NONPURCHASE_DESC.NP_CGSTPER AS CGSTPER, SUM(NONPURCHASE_DESC.NP_CGSTAMT) AS CGSTAMT, NONPURCHASE_DESC.NP_SGSTPER AS SGSTPER, SUM(NONPURCHASE_DESC.NP_SGSTAMT) AS SGSTAMT, NONPURCHASE_DESC.NP_IGSTPER AS IGSTPER, SUM(NONPURCHASE_DESC.NP_IGSTAMT) AS IGSTAMT, SUM(NONPURCHASE_DESC.NP_GRIDTOTAL) AS GTOTAL, NONPURCHASE.NP_NO AS BOOKINGNO FROM  NONPURCHASE INNER JOIN NONPURCHASE_DESC ON NONPURCHASE.NP_NO = NONPURCHASE_DESC.NP_NO AND NONPURCHASE.NP_REGISTERID = NONPURCHASE_DESC.NP_REGISTERID AND NONPURCHASE.NP_YEARID = NONPURCHASE_DESC.NP_YEARID INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON NONPURCHASE_DESC.NP_HSNCODEID = HSNMASTER.HSN_ID WHERE NONPURCHASE.NP_YEARID = " & YearId & " AND NP_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' GROUP BY NONPURCHASE.NP_INITIALS, NONPURCHASE.NP_DATE, ISNULL(Ledgers.Acc_cmpname, ''), ISNULL(LEDGERS.ACC_GSTIN, ''), ISNULL(STATEMASTER.state_name, ''), ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR(100)), ''), ISNULL(HSNMASTER.HSN_CODE, ''), NONPURCHASE_DESC.NP_CGSTPER, NONPURCHASE_DESC.NP_SGSTPER , NONPURCHASE_DESC.NP_IGSTPER, NONPURCHASE.NP_NO ) AS T", " ORDER BY BOOKINGDATE, BOOKINGNO")
            'Dim dt As DataTable = objclsCMST.search("  TYPE AS BOOKTYPE, BILLINITIALS, BOOKINGDATE, LEDGERNAME, GSTIN, STATENAME, STATECODE, HSNCODE, (CASE WHEN TAXSERVCHGS=1 THEN SERVCHGS ELSE SUBTOTAL END) AS TAXABLEAMT, CGSTPER, CGSTAMT, SGSTPER, SGSTAMT, IGSTPER, IGSTAMT, GTOTAL  ", "", "  RESERVATIONDETAILS", WHERECLAUSE & " ORDER BY BOOKINGDATE, BOOKINGNO")
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
            PATH = Application.StartupPath & "\Purchase GST Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = FROMDATE & " - " & TODATE

            opti.SheetName = "Purchase GST Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase GST Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

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