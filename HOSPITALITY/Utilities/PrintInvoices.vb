
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class PrintInvoices

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Public edit As Boolean

    Private Sub PrintInvoices_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search(" HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(GUESTMASTER.GUEST_EMAIL,'') AS EMAIL, HOTELMASTER.HOTEL_NAME AS HOTELNAME, LEDGERS.Acc_cmpname AS ACCNAME, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOTELBOOKINGMASTER.BOOKING_TOTALROOMS AS TOTALROOMS, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL,  USERMASTER.User_Name AS USERNAME, HOTELBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, HOTELBOOKINGMASTER.BOOKING_AMD_DONE AS AMENDED, HOTELBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, HOTELBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, HOTELBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, HOTELBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, HOTELBOOKINGMASTER.BOOKING_FAILED  AS FAILED, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS PURSUBTOTAL, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, HOTELBOOKINGMASTER.BOOKING_PURTAX AS PURTAXAMT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT ", "", " HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN                      USERMASTER ON HOTELBOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TAXMASTER ON HOTELBOOKINGMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON HOTELBOOKINGMASTER.BOOKING_PURTAXID = PURTAXMASTER.tax_id  ", " AND BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND BOOKING_YEARID = " & YearId & " ORDER BY HOTELBOOKINGMASTER.BOOKING_NO")
            'dt = objclsCMST.search(" HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(GUESTMASTER.GUEST_EMAIL,'') AS EMAIL, HOTELMASTER.HOTEL_NAME AS HOTELNAME, LEDGERS.Acc_cmpname AS ACCNAME, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOTELBOOKINGMASTER.BOOKING_TOTALROOMS AS TOTALROOMS, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL,  USERMASTER.User_Name AS USERNAME, HOTELBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, HOTELBOOKINGMASTER.BOOKING_AMD_DONE AS AMENDED, HOTELBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, HOTELBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, HOTELBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, HOTELBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, HOTELBOOKINGMASTER.BOOKING_FAILED  AS FAILED, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS PURSUBTOTAL, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, HOTELBOOKINGMASTER.BOOKING_PURTAX AS PURTAXAMT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ARRIVALFROMID AS ARRFROM,  HOTELBOOKINGMASTER.BOOKING_ARRFLIGHTNO AS ARRFLIGHTNO, HOTELBOOKINGMASTER.BOOKING_DEPARTTOID AS DEPARTTO , HOTELBOOKINGMASTER.BOOKING_DEPARTFLIGHTNO AS DEPARTFLIGHTNO, HOTELBOOKINGMASTER.BOOKING_PURBALANCE AS PURBAL,HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS SALEBAL ", "", " HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN                      USERMASTER ON HOTELBOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN TAXMASTER ON HOTELBOOKINGMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON HOTELBOOKINGMASTER.BOOKING_PURTAXID = PURTAXMASTER.tax_id LEFT OUTER JOIN CITYMASTER AS ARRIVALCITYMASTER ON HOTELBOOKINGMASTER.BOOKING_ARRIVALFROMID = ARRIVALCITYMASTER.CITY_ID LEFT OUTER JOIN CITYMASTER AS DEPARTCITYMASTER ON HOTELBOOKINGMASTER.BOOKING_DEPARTTOID = DEPARTCITYMASTER.CITY_ID ", " AND BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND BOOKING_YEARID = " & YearId & " ORDER BY HOTELBOOKINGMASTER.BOOKING_NO")

            dt = objclsCMST.search(" HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, LEDGERS.Acc_cmpname AS ACCNAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, HOTELBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, HOTELBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, HOTELBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, HOTELBOOKINGMASTER.BOOKING_FAILED  AS FAILED, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS SALEBAL ", "", " HOTELBOOKINGMASTER INNER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID ", " AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            
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
                Dim OBJBOOKING As New HotelBookings
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.FRMSTRING = FRMSTRING
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim tempMsg = MsgBox("Wish to Print Invoices ?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then
                serverprop()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
    '    Try
    '        showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub PrintInvoices_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
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
    '                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALERETURN")) > 0 Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.Yellow

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.LightGreen

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.LightBlue

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FAILED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.Plum

    '                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("REFUNDED")) = "Checked" Then
    '                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
    '                    e.Appearance.BackColor = Color.PeachPuff
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Invoice Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Invoice Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Invoice Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            Dim tempMsg = MsgBox("Wish to Print Invoices?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then
                serverprop()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        For i As Integer = 0 To gridbill.RowCount - 1
            Dim dtrow As DataRow = gridbill.GetDataRow(i)
            If Convert.ToBoolean(dtrow("CHK")) = True Then
                Dim OBJINVOICE As New HotelBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.BOOKINGNO = Val(i)
                OBJINVOICE.BOOKTYPE = FRMSTRING
                OBJINVOICE.Show()
            End If
        Next
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            gridbilldetails.DataSource = Nothing
            CMBNAME.Text = ""
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class