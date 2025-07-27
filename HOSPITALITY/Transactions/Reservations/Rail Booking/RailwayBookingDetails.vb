
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class RailwayBookingDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Dim SALEREGID As Integer

    Private Sub RailwayBookingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            'dt = objclsCMST.search(" RAILBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, RAILBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, RAILBOOKINGMASTER.BOOKING_DATE AS DATE, ISNULL(PURLEDGERS.Acc_cmpname, '') AS PURNAME, RAILBOOKINGMASTER.BOOKING_JOURNEYDATE AS JOURNEYDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(RAILBOOKINGMASTER.BOOKING_LOGINID, '') AS LOGINID, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNAME, '') AS TRAINNAME, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNO, '') AS TRAINNO, RAILBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX,  ISNULL(RAILBOOKINGMASTER.BOOKING_CLASS, '') AS CLASS, ISNULL(RAILBOOKINGMASTER.BOOKING_FROM, '') AS [FROM], ISNULL(RAILBOOKINGMASTER.BOOKING_TO, '') AS [TO], ISNULL(RAILBOOKINGMASTER.BOOKING_BOARDING, '') AS BOARDING, ISNULL(RAILBOOKINGMASTER.BOOKING_RESTO, '') AS RESTO, ISNULL(RAILBOOKINGMASTER.BOOKING_TICKETTYPE, '') AS TICKETTYPE, ISNULL(RAILBOOKINGMASTER.BOOKING_QUOTA, '') AS QUOTA, RAILBOOKINGMASTER.BOOKING_FARE AS FARE, RAILBOOKINGMASTER.BOOKING_IRCTC AS IRCTC, RAILBOOKINGMASTER.BOOKING_GATEWAY AS GATEWAY, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, RAILBOOKINGMASTER.BOOKING_GRANDTOTAL AS GTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_CONFIRMATIONNO, '') AS PNRNO,  RAILBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTE, RAILBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, RAILBOOKINGMASTER.BOOKING_DONE AS DONE, RAILBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, BOOKING_SALEBALANCE AS BALANCE, BOOKING_SALERETURN AS SALERETURN, BOOKING_REFUNDED AS REFUNDED, BOOKING_FAILED AS FAILED,  RAILBOOKINGMASTER.BOOKING_EXTRACHGS AS SUBTOTAL, ISNULL(TAXMASTER.tax_name,'') AS TAXNAME, RAILBOOKINGMASTER.BOOKING_TAX AS TAXAMT ", "", " RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN BOOKEDBYMASTER ON RAILBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN TAXMASTER ON RAILBOOKINGMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN LEDGERS AS PURLEDGERS ON RAILBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGERS.Acc_id", " AND BOOKING_YEARID = " & YearId & " ORDER BY RAILBOOKINGMASTER.BOOKING_NO")
            'dt = objclsCMST.search(" RAILBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, RAILBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, RAILBOOKINGMASTER.BOOKING_DATE AS DATE, ISNULL(PURLEDGERS.Acc_cmpname, '') AS PURNAME, RAILBOOKINGMASTER.BOOKING_JOURNEYDATE AS JOURNEYDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(RAILBOOKINGMASTER.BOOKING_LOGINID, '') AS LOGINID, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNAME, '') AS TRAINNAME, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNO, '') AS TRAINNO, RAILBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, ISNULL(RAILBOOKINGMASTER.BOOKING_CLASS, '') AS CLASS, ISNULL(RAILBOOKINGMASTER.BOOKING_FROM, '') AS [FROM], ISNULL(RAILBOOKINGMASTER.BOOKING_TO, '') AS [TO], ISNULL(RAILBOOKINGMASTER.BOOKING_BOARDING, '') AS BOARDING, ISNULL(RAILBOOKINGMASTER.BOOKING_RESTO, '') AS RESTO, ISNULL(RAILBOOKINGMASTER.BOOKING_TICKETTYPE, '') AS TICKETTYPE, ISNULL(RAILBOOKINGMASTER.BOOKING_QUOTA, '') AS QUOTA, RAILBOOKINGMASTER.BOOKING_FARE AS FARE, RAILBOOKINGMASTER.BOOKING_IRCTC AS IRCTC, RAILBOOKINGMASTER.BOOKING_GATEWAY AS GATEWAY, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, RAILBOOKINGMASTER.BOOKING_GRANDTOTAL AS GTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_CONFIRMATIONNO, '') AS PNRNO, RAILBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTE, RAILBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, RAILBOOKINGMASTER.BOOKING_DONE AS DONE, RAILBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, RAILBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, RAILBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, RAILBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, RAILBOOKINGMASTER.BOOKING_FAILED AS FAILED, ISNULL(RAILBOOKINGMASTER.BOOKING_EXTRACHGS, 0) AS SERVICECHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, RAILBOOKINGMASTER.BOOKING_TAX AS TAXAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT,ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(PURLEDGERS.ACC_GSTIN, '') AS PURGSTIN,ISNULL(HSNMASTER.HSN_CODE, '')  AS HSNCODE, ISNULL(PURSTATEMASTER.state_name, '') AS PURSTATENAME, ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE ", "", " TAXMASTER RIGHT OUTER JOIN RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN BOOKEDBYMASTER ON RAILBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON RAILBOOKINGMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID ON TAXMASTER.tax_id = RAILBOOKINGMASTER.BOOKING_TAXID LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGERS ON PURSTATEMASTER.state_id = PURLEDGERS.Acc_stateid ON RAILBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGERS.Acc_id", " AND BOOKING_YEARID = " & YearId & " ORDER BY RAILBOOKINGMASTER.BOOKING_NO")
            dt = objclsCMST.search(" RAILBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, RAILBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, RAILBOOKINGMASTER.BOOKING_DATE AS DATE, ISNULL(PURLEDGERS.Acc_cmpname, '')  AS PURNAME, RAILBOOKINGMASTER.BOOKING_JOURNEYDATE AS JOURNEYDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(RAILBOOKINGMASTER.BOOKING_LOGINID, '') AS LOGINID,  ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNAME, '') AS TRAINNAME, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNO, '') AS TRAINNO, RAILBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX,  ISNULL(RAILBOOKINGMASTER.BOOKING_CLASS, '') AS CLASS, ISNULL(RAILBOOKINGMASTER.BOOKING_FROM, '') AS [FROM], ISNULL(RAILBOOKINGMASTER.BOOKING_TO, '') AS [TO],  ISNULL(RAILBOOKINGMASTER.BOOKING_BOARDING, '') AS BOARDING, ISNULL(RAILBOOKINGMASTER.BOOKING_RESTO, '') AS RESTO, ISNULL(RAILBOOKINGMASTER.BOOKING_TICKETTYPE, '') AS TICKETTYPE,  ISNULL(RAILBOOKINGMASTER.BOOKING_QUOTA, '') AS QUOTA, RAILBOOKINGMASTER.BOOKING_FARE AS FARE, RAILBOOKINGMASTER.BOOKING_IRCTC AS IRCTC, RAILBOOKINGMASTER.BOOKING_GATEWAY AS GATEWAY, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, RAILBOOKINGMASTER.BOOKING_GRANDTOTAL AS GTOTAL,  ISNULL(RAILBOOKINGMASTER.BOOKING_CONFIRMATIONNO, '') AS PNRNO, RAILBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTE, RAILBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED,  RAILBOOKINGMASTER.BOOKING_DONE AS DONE, RAILBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, RAILBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE,  RAILBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, RAILBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, RAILBOOKINGMASTER.BOOKING_FAILED AS FAILED,  ISNULL(RAILBOOKINGMASTER.BOOKING_EXTRACHGS, 0) AS SERVICECHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, RAILBOOKINGMASTER.BOOKING_TAX AS TAXAMT,  ISNULL(RAILBOOKINGMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT,  ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT,  ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT, ISNULL(LEDGERS.Acc_GSTIN, '') AS GSTIN,  ISNULL(PURLEDGERS.Acc_GSTIN, '') AS PURGSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(PURSTATEMASTER.state_name, '') AS PURSTATENAME,  ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE,  ISNULL(RAILBOOKINGMASTER.BOOKING_TOTALPURAMT, 0) AS TOTALPURAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_DISCRECDRS, 0) AS DISCRECDRS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSUBTOTAL, 0)  AS PURSUBTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_COMMRECDRS, 0) AS COMMRECDRS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTDSRS, 0) AS PURTDSRS,  ISNULL(RAILBOOKINGMASTER.BOOKING_PUREXTRACHGS, 0) AS PUREXTRACHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURROUNDOFF, 0) AS PURROUNDOFF,  ISNULL(RAILBOOKINGMASTER.BOOKING_TOTALSALEAMT, 0) AS TOTALSALEAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_OURCOMMRS, 0) AS OURCOMMRS, ISNULL(RAILBOOKINGMASTER.BOOKING_EXTRACHGS, 0)  AS EXTRACHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(RAILBOOKINGMASTER.BOOKING_IRNNO, '')  AS IRNNO, ISNULL(RAILBOOKINGMASTER.BOOKING_ACKNO, '') AS ACKNO, RAILBOOKINGMASTER.BOOKING_ACKDATE AS ACKDATE, RAILBOOKINGMASTER.BOOKING_QRCODE AS QRCODE,  ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS TOURNAME ", "", "  HSNMASTER RIGHT OUTER JOIN RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN BOOKEDBYMASTER ON RAILBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN GROUPDEPARTURE ON RAILBOOKINGMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO AND RAILBOOKINGMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ON HSNMASTER.HSN_ID = RAILBOOKINGMASTER.BOOKING_HSNCODEID LEFT OUTER JOIN TAXMASTER ON RAILBOOKINGMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGERS ON PURSTATEMASTER.state_id = PURLEDGERS.Acc_stateid ON RAILBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGERS.Acc_id", " AND BOOKING_YEARID = " & YearId & " ORDER BY RAILBOOKINGMASTER.BOOKING_NO")
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
                Dim OBJBOOKING As New RailwayBooking
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
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

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
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

    Private Sub RailwayBookingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'RAIL RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Dim clscommon As New ClsCommon
            Dim dt As DataTable = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='RAILWAY SALE REGISTER' and register_type = 'SALE' and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then SALEREGID = dt.Rows(0).Item(2)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALERETURN")) > 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightBlue

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FAILED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Plum

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("REFUNDED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.PeachPuff
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Hotel Booking Details.XLS"

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

            opti.SheetName = "Hotel Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Hotel Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    serverprop(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then SERVERPROPSELECTED(True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RailwayBookingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "CLASSIC" And ClientName = "TOPCOMM" And ClientName = "AMIGO" And ClientName = "PARAMOUNT" Then Me.Close()
        If ClientName = "CLASSIC" And ClientName = "AMIGO" And ClientName = "PARAMOUNT" Then Me.Close()
        If ClientName = "SEASONED" Then
            PRINTTOOL.Visible = True
            LBLFROM.Visible = True
            LBLTO.Visible = True
            TXTFROM.Visible = True
            TXTTO.Visible = True
        End If
        If ClientName = "GLOBAL" Then
            GGSTIN.Visible = False
            GSTATENAME.Visible = False
            GSTATECODE.Visible = False
            GPURGSTIN.Visible = False
            GPURSTATENAME.Visible = False
            GPURSTATECODE.Visible = False
            GHSNCODE.Visible = False
            GPURCGSTAMT.Visible = False
            GPURSGSTAMT.Visible = False
            GPURIGSTAMT.Visible = False
            GCGSTAMT.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False

        End If
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Print Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    serverprop(False)
                End If
            Else
                If MsgBox("Wish to Print Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then SERVERPROPSELECTED(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            '    For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
            '    Dim OBJINVOICE As New RailBookingVoucherDesign
            '    OBJINVOICE.MdiParent = MDIMain
            '    OBJINVOICE.DIRECTPRINT = True
            '    OBJINVOICE.FRMSTRING = "INVOICE"
            '    OBJINVOICE.BOOKINGNO = Val(I)
            '    OBJINVOICE.SALEREGISTERID = SALEREGID
            '    OBJINVOICE.Show()
            '    OBJINVOICE.Close()
            'Next
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New RailBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(I)
                OBJINVOICE.SALEREGISTERID = SALEREGID
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJINVOICE As New RailBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
                OBJINVOICE.SALEREGISTERID = SALEREGID
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(ROW("BOOKINGNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Invoice"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class