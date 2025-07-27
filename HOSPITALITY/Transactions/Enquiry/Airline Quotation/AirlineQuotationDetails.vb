
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class AirlineQuotationDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Public SALEREGID As Integer

    Private Sub InvoiceMasterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            'dt = objclsCMST.search("  AIRLINEQUOTATION.BOOKING_SALEBILLINITIALS AS BILLINITIALS, AIRLINEQUOTATION.BOOKING_NO AS BOOKINGNO, AIRLINEQUOTATION.BOOKING_DATE AS BOOKINGDATE, ISNULL(CRSMASTER.CRS_NAME, '') AS CRS, AIRLINEQUOTATION.BOOKING_BSPSALE AS BSP, AIRLINEQUOTATION.BOOKING_COUPONSALE AS COUPON, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, LEDGERS.Acc_cmpname AS ACCNAME, AIRLINEQUOTATION.BOOKING_TICKETDATE AS TICKETDATE, AIRLINEQUOTATION.BOOKING_PNRNO AS PNR, AIRLINEQUOTATION.BOOKING_AIRLINEPNR AS AIRPNR, AIRLINEQUOTATION.BOOKING_CRSPNR AS CRSPNR, AIRLINEQUOTATION.BOOKING_REFNO AS REFNO, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEQUOTATION.BOOKING_PURGRANDTOTAL AS PURTOTAL, AIRLINEQUOTATION.BOOKING_TOTALBASIC AS BASIC, AIRLINEQUOTATION.BOOKING_TOTALPSF AS YQ, AIRLINEQUOTATION.BOOKING_TOTALTAX AS TAXES, ISNULL(TAXMASTER.TAX_NAME,'') AS TAXNAME, AIRLINEQUOTATION.BOOKING_TAX AS TAXAMT, AIRLINEQUOTATION.BOOKING_GRANDTOTAL AS GRANDTOTAL, AIRLINEQUOTATION.BOOKING_CANCELLED AS CANCELLED, AIRLINEQUOTATION.BOOKING_DISPUTE AS DISPUTED, AIRLINEQUOTATION.BOOKING_BILLCHECKED AS BILLCHECKED, ISNULL(AIRLINEQUOTATION.BOOKING_REMARKS, '') AS REMARKS, USERMASTER.User_Name AS USERNAME, AIRLINEQUOTATION.BOOKING_SALERETURN AS SALERETURN, AIRLINEQUOTATION.BOOKING_REFUNDED AS REFUNDED, AIRLINEQUOTATION.BOOKING_FAILED AS FAILED, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, AIRLINEQUOTATION.BOOKING_PURTAX AS PURTAXAMT, (BOOKING_TOTALAMT- BOOKING_PURAMT) AS MARKUP ", "", " AIRLINEQUOTATION INNER JOIN FLIGHTMASTER ON AIRLINEQUOTATION.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID INNER JOIN USERMASTER ON AIRLINEQUOTATION.BOOKING_USERID = USERMASTER.User_id INNER JOIN BOOKEDBYMASTER ON AIRLINEQUOTATION.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN LEDGERS ON AIRLINEQUOTATION.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON AIRLINEQUOTATION.BOOKING_PURTAXID = PURTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON AIRLINEQUOTATION.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN LEDGERS AS PURLEDGER ON AIRLINEQUOTATION.BOOKING_PURLEDGERID = PURLEDGER.Acc_id LEFT OUTER JOIN CRSMASTER ON AIRLINEQUOTATION.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID ", " AND BOOKING_SALEREGISTERID = " & SALEREGID & " AND BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEQUOTATION.BOOKING_NO")
            ''dt = objclsCMST.search("   AIRLINEQUOTATION.BOOKING_SALEBILLINITIALS AS BILLINITIALS, AIRLINEQUOTATION.BOOKING_NO AS BOOKINGNO, AIRLINEQUOTATION.BOOKING_DATE AS BOOKINGDATE, ISNULL(CRSMASTER.CRS_NAME, '') AS CRS, AIRLINEQUOTATION.BOOKING_BSPSALE AS BSP, AIRLINEQUOTATION.BOOKING_COUPONSALE AS COUPON, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, LEDGERS.Acc_cmpname AS ACCNAME, AIRLINEQUOTATION.BOOKING_TICKETDATE AS TICKETDATE, AIRLINEQUOTATION.BOOKING_PNRNO AS PNR, AIRLINEQUOTATION.BOOKING_AIRLINEPNR AS AIRPNR, AIRLINEQUOTATION.BOOKING_CRSPNR AS CRSPNR, AIRLINEQUOTATION.BOOKING_REFNO AS REFNO, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEQUOTATION.BOOKING_PURGRANDTOTAL AS PURTOTAL, AIRLINEQUOTATION.BOOKING_TOTALBASIC AS BASIC, AIRLINEQUOTATION.BOOKING_TOTALPSF AS YQ, AIRLINEQUOTATION.BOOKING_TOTALTAX AS TAXES, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRLINEQUOTATION.BOOKING_TAX AS TAXAMT, AIRLINEQUOTATION.BOOKING_GRANDTOTAL AS GRANDTOTAL, AIRLINEQUOTATION.BOOKING_CANCELLED AS CANCELLED, AIRLINEQUOTATION.BOOKING_DISPUTE AS DISPUTED, AIRLINEQUOTATION.BOOKING_BILLCHECKED AS BILLCHECKED, ISNULL(AIRLINEQUOTATION.BOOKING_REMARKS, '') AS REMARKS, USERMASTER.User_Name AS USERNAME, AIRLINEQUOTATION.BOOKING_SALERETURN AS SALERETURN, AIRLINEQUOTATION.BOOKING_REFUNDED AS REFUNDED, AIRLINEQUOTATION.BOOKING_FAILED AS FAILED, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, AIRLINEQUOTATION.BOOKING_PURTAX AS PURTAXAMT, (AIRLINEQUOTATION.BOOKING_TOTALAMT - AIRLINEQUOTATION.BOOKING_PURAMT) AS MARKUP, ISNULL(AIRLINEQUOTATION.BOOKING_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(AIRLINEQUOTATION.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEQUOTATION.BOOKING_PURDISCAMT,0) AS PURDISCAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT,ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN,ISNULL(PURLEDGER.ACC_GSTIN, '') AS PURGSTIN ", "", " AIRLINEQUOTATION INNER JOIN FLIGHTMASTER ON AIRLINEQUOTATION.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID INNER JOIN USERMASTER ON AIRLINEQUOTATION.BOOKING_USERID = USERMASTER.User_id INNER JOIN BOOKEDBYMASTER ON AIRLINEQUOTATION.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN LEDGERS ON AIRLINEQUOTATION.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON AIRLINEQUOTATION.BOOKING_PURTAXID = PURTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON AIRLINEQUOTATION.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN LEDGERS AS PURLEDGER ON AIRLINEQUOTATION.BOOKING_PURLEDGERID = PURLEDGER.Acc_id LEFT OUTER JOIN CRSMASTER ON AIRLINEQUOTATION.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID ", " AND BOOKING_SALEREGISTERID = " & SALEREGID & " AND BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEQUOTATION.BOOKING_NO")
            dt = objclsCMST.search("   AIRLINEQUOTATION.BOOKING_BOOKTYPE AS BOOKTYPE, AIRLINEQUOTATION.BOOKING_NO AS BOOKINGNO, AIRLINEQUOTATION.BOOKING_DATE AS BOOKINGDATE, ISNULL(CRSMASTER.CRS_NAME, '') AS CRS, AIRLINEQUOTATION.BOOKING_BSPSALE AS BSP, AIRLINEQUOTATION.BOOKING_COUPONSALE AS COUPON, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, LEDGERS.Acc_cmpname AS ACCNAME, AIRLINEQUOTATION.BOOKING_TICKETDATE AS TICKETDATE, AIRLINEQUOTATION.BOOKING_PNRNO AS PNR, AIRLINEQUOTATION.BOOKING_AIRLINEPNR AS AIRPNR, AIRLINEQUOTATION.BOOKING_CRSPNR AS CRSPNR, AIRLINEQUOTATION.BOOKING_REFNO AS REFNO, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEQUOTATION.BOOKING_PURGRANDTOTAL AS PURTOTAL, AIRLINEQUOTATION.BOOKING_TOTALBASIC AS BASIC, AIRLINEQUOTATION.BOOKING_TOTALPSF AS YQ, AIRLINEQUOTATION.BOOKING_TOTALTAX AS TAXES, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRLINEQUOTATION.BOOKING_TAX AS TAXAMT, AIRLINEQUOTATION.BOOKING_GRANDTOTAL AS GRANDTOTAL, AIRLINEQUOTATION.BOOKING_CANCELLED AS CANCELLED, AIRLINEQUOTATION.BOOKING_DISPUTE AS DISPUTED, AIRLINEQUOTATION.BOOKING_BILLCHECKED AS BILLCHECKED, ISNULL(AIRLINEQUOTATION.BOOKING_REMARKS, '') AS REMARKS, USERMASTER.User_Name AS USERNAME, AIRLINEQUOTATION.BOOKING_REFUNDED AS REFUNDED, AIRLINEQUOTATION.BOOKING_FAILED AS FAILED, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, AIRLINEQUOTATION.BOOKING_PURTAX AS PURTAXAMT, (AIRLINEQUOTATION.BOOKING_TOTALAMT - AIRLINEQUOTATION.BOOKING_PURAMT) AS MARKUP, ISNULL(AIRLINEQUOTATION.BOOKING_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(AIRLINEQUOTATION.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEQUOTATION.BOOKING_PURDISCAMT,0) AS PURDISCAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(AIRLINEQUOTATION.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT,ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN,ISNULL(PURLEDGER.ACC_GSTIN, '') AS PURGSTIN,ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(PURSTATEMASTER.state_name, '') AS PURSTATENAME, ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(AIRLINEQUOTATION.BOOKING_PUROTHERCHGS, 0) AS PUROTHERCHGS, ISNULL(AIRLINEQUOTATION.BOOKING_SALEDISCAMT, 0) AS DISCAMT,ISNULL(AIRLINEQUOTATION.BOOKING_PURTDSRS, 0) AS PURTDSRS, ISNULL(AIRLINEQUOTATION.BOOKING_PURADDDISCAMT, 0) AS PURADDDISCAMT, ISNULL(purotherchgsLEDGERS.Acc_cmpname, '') AS PUROTHERCHGSNAME, ISNULL(AIRLINEQUOTATION.BOOKING_PURROUNDOFF, 0) AS PURROUNDOFF, ISNULL(AIRLINEQUOTATION.BOOKING_TOTALPURAMT, 0) AS TOTALPURAMT, ISNULL(AIRLINEQUOTATION.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(AIRLINEQUOTATION.BOOKING_SALEDISCAMT, 0) AS SALEDISCAMT, ISNULL(AIRLINEQUOTATION.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(otherchgsLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(AIRLINEQUOTATION.BOOKING_TOTALSALEAMT, 0) AS TOTALSALEAMT ", "", "  TAXMASTER AS PURTAXMASTER RIGHT OUTER JOIN AIRLINEQUOTATION INNER JOIN FLIGHTMASTER ON AIRLINEQUOTATION.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID INNER JOIN USERMASTER ON AIRLINEQUOTATION.BOOKING_USERID = USERMASTER.User_id INNER JOIN BOOKEDBYMASTER ON AIRLINEQUOTATION.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN LEDGERS ON AIRLINEQUOTATION.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS otherchgsLEDGERS ON AIRLINEQUOTATION.BOOKING_OTHERCHGSID = otherchgsLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS purotherchgsLEDGERS ON AIRLINEQUOTATION.BOOKING_PUROTHERCHGSID = purotherchgsLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON AIRLINEQUOTATION.BOOKING_HSNCODEID = HSNMASTER.HSN_ID ON PURTAXMASTER.tax_id = AIRLINEQUOTATION.BOOKING_PURTAXID LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON AIRLINEQUOTATION.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGER ON PURSTATEMASTER.state_id = PURLEDGER.Acc_stateid ON AIRLINEQUOTATION.BOOKING_PURLEDGERID = PURLEDGER.Acc_id LEFT OUTER JOIN CRSMASTER ON AIRLINEQUOTATION.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID ", " AND BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEQUOTATION.BOOKING_NO")

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineBookingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AIRLINE RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            If FRMSTRING = "DOMESTIC" Then
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='AIRLINE SALE REGISTER' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            Else
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='INTAIRLINE SALE REGISTER' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            End If
            If dt.Rows.Count > 0 Then
                SALEREGID = dt.Rows(0).Item(2)
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub AirlineBookingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    If ClientName = "ELYSIUM" Then
    '        Me.Close()
    '        Exit Sub
    '    End If
    '    If ClientName = "SEASONED" Then
    '        PRINTTOOL.Visible = True
    '        LBLFROM.Visible = True
    '        LBLTO.Visible = True
    '        TXTFROM.Visible = True
    '        TXTTO.Visible = True
    '    End If
    'End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New AirlineQuotation
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
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

    'Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
    '    Try
    '        If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '            MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If
    '        Dim tempMsg As Integer
    '        tempMsg = MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo)
    '        If tempMsg = vbYes Then
    '            serverprop()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub serverprop()
    '    For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
    '        Dim OBJINVOICE As New AirlineBookingVoucherDesign
    '        OBJINVOICE.MdiParent = MDIMain
    '        OBJINVOICE.DIRECTPRINT = True
    '        OBJINVOICE.FRMSTRING = "INVOICE"
    '        OBJINVOICE.BOOKINGNO = Val(I)
    '        OBJINVOICE.SALEREGISTERID = SALEREGID
    '        OBJINVOICE.Show()
    '        OBJINVOICE.Close()
    '    Next
    'End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Airline Quotation Details.XLS"

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

            opti.SheetName = "Airline Quotation Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Airline Quotation Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineQuotationDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ClientName = "GLOBAL" Then
            GPURGSTIN.Visible = False
            GPURSTATENAME.Visible = False
            GPURSTATECODE.Visible = False
            GGSTIN.Visible = False
            GSTATECODE.Visible = False
            GSTATENAME.Visible = False
            GPURCGSTAMT.Visible = False
            GPURSGSTAMT.Visible = False
            GPURIGSTAMT.Visible = False
            GCGSTAMT.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GST.Visible = False
            GHSNCODE.Visible = False

        End If
    End Sub
End Class