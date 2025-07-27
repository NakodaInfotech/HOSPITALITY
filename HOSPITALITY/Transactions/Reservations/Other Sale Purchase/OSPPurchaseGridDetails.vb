

Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class OSPPurchaseGridDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim REGID As Integer

    Private Sub OSPPurchaseGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OSPPurchaseGridDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OTHER SALE PURCHASE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_NO, '') AS BOOKINGNO, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_SRNO, 0) AS PURSRNO, ISNULL(ACCOUNTSMASTER.Acc_cmpname, '') AS PURNAME, OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_DATE AS PURDATE, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_AMOUNT, 0) AS PURAMT, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_DISCPER, 0) AS PURDISCPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_DISC, 0) AS PURDISC, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL, 0) AS PURSUBTOTAL, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_COMMPER, 0) AS PURCOMMPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_COMM, 0) AS PURCOMM, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_TDSPER, 0) AS PURTDSPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_TDS, 0) AS PURTDS, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_NETT, 0) AS PURNETT, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT, 0) AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT, 0) AS ADDTAXAMT, ISNULL(PUROTHERCHGSNAME.Acc_cmpname, '') AS PUROTHERCHGSNAME, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS, '') AS PUROTHERCHGS, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF, 0) AS PURROUNDOFF, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL, 0) AS PURGTOTAL, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_AMTPAID, 0) AS PURAMTPAID, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_EXTRAAMT, 0) AS PUREXTRAAMT, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_RETURN, 0) AS PURRETURN, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_BALANCE, 0) AS PURBALANCE, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_BILLCHECKED, 0) AS PURBILLCHECKED, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURTAXSERVCHGS, 0) AS PURSERVTAX, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURSERVICECHGS, 0) AS PURSERVCHGS, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS PURCGSTPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS PURSGSTPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS PURIGSTPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURCESSPER, 0) AS PURCESSPER, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURCESSAMT, 0) AS PURCESSAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(HSNMASTER.HSN_CODE, '') AS PURHSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS PURHSNITEMDESC, ISNULL(OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_COMMINVRAISED, 0) AS COMMINVRAISED, ISNULL(OTHERSALEPURCHASEMASTER.BOOKING_FINALPURAMT, 0) AS FINALPURAMT ", "", " OTHERSALEPURCHASEMASTER INNER JOIN OTHERSALEPURCHASEMASTER_PURCHASEDETAILS INNER JOIN ACCOUNTSMASTER ON OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = ACCOUNTSMASTER.Acc_id AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_CMPID = ACCOUNTSMASTER.Acc_cmpid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = ACCOUNTSMASTER.Acc_locationid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_YEARID = ACCOUNTSMASTER.Acc_yearid ON OTHERSALEPURCHASEMASTER.BOOKING_NO = OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_NO AND OTHERSALEPURCHASEMASTER.BOOKING_YEARID = OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_YEARID LEFT OUTER JOIN HSNMASTER ON OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER ON ACCOUNTSMASTER.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS PUROTHERCHGSNAME ON OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_YEARID = PUROTHERCHGSNAME.Acc_yearid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = PUROTHERCHGSNAME.Acc_locationid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_CMPID = PUROTHERCHGSNAME.Acc_cmpid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGSID = PUROTHERCHGSNAME.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_YEARID = ADDTAXMASTER.tax_yearid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID = ADDTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER ON OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id ", " AND OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_YEARID = " & YearId & " ORDER BY OTHERSALEPURCHASEMASTER_PURCHASEDETAILS.BOOKING_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPUR As New OtherSalePurchase
                objPUR.MdiParent = MDIMain
                objPUR.edit = editval
                objPUR.TEMPBOOKINGNO = BOOKINGNO

                objPUR.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
    '    Try
    '        Dim DT As DataTable = gridbilldetails.DataSource
    '        If gridbill.RowFilter = "" Then
    '            If e.RowHandle >= 0 Then
    '                Dim ROW As DataRow = DT.Rows(e.RowHandle)
    '                Dim View As GridView = sender
    '                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CANCELLED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.Yellow

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.LightGreen

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.LightBlue
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\OSP Purchase.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "OSP Purchase"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "OSP Purchase ", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class