
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class HotelBookingsDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

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
            Dim dt As DataTable = objclsCMST.search(" HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO,  HOTELBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(GUESTMASTER.GUEST_EMAIL, '') AS EMAIL, HOTELMASTER.HOTEL_NAME AS HOTELNAME,  LEDGERS.Acc_cmpname AS ACCNAME, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE,  HOTELBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOTELBOOKINGMASTER.BOOKING_TOTALROOMS AS TOTALROOMS, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL,  HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, HOTELBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED,  HOTELBOOKINGMASTER.BOOKING_AMD_DONE AS AMENDED, HOTELBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE,  HOTELBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, HOTELBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, HOTELBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED,  HOTELBOOKINGMASTER.BOOKING_FAILED AS FAILED, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS PURSUBTOTAL, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME,  HOTELBOOKINGMASTER.BOOKING_PURTAX AS PURTAXAMT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(TAXMASTER_1.tax_name, '') AS TAXNAME,  HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ARRIVALFROMID AS ARRFROM, HOTELBOOKINGMASTER.BOOKING_ARRFLIGHTNO AS ARRFLIGHTNO,  HOTELBOOKINGMASTER.BOOKING_DEPARTTOID AS DEPARTTO, HOTELBOOKINGMASTER.BOOKING_DEPARTFLIGHTNO AS DEPARTFLIGHTNO, HOTELBOOKINGMASTER.BOOKING_PURBALANCE AS PURBAL,  HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS SALEBAL, HOTELBOOKINGMASTER.BOOKING_CGSTAMT AS CGSTAMT, HOTELBOOKINGMASTER.BOOKING_SGSTAMT AS SGSTAMT,  HOTELBOOKINGMASTER.BOOKING_IGSTAMT AS IGSTAMT, HOTELBOOKINGMASTER.BOOKING_PURCGSTAMT AS PURCGSTAMT, HOTELBOOKINGMASTER.BOOKING_PURSGSTAMT AS PURSGSTAMT,  HOTELBOOKINGMASTER.BOOKING_PURIGSTAMT AS PURIGSTAMT, HOTELBOOKINGMASTER.BOOKING_PUROURCOMMPER AS PUROURCOMMPER, HOTELBOOKINGMASTER.BOOKING_OURCOMMRS AS OURCOMMRS,  ISNULL(LEDGERS.Acc_GSTIN, '') AS GSTIN, ISNULL(PURLEDGERS.Acc_GSTIN, '') AS PURGSTIN, ISNULL(PURLEDGERS.Acc_cmpname, '') AS PURNAME, ISNULL(PURHSNMASTER.HSN_CODE, '') AS PURHSNCODE,  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(PURSTATEMASTER.state_name,  '') AS PURSTATENAME, ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(HOTELBOOKINGMASTER.BOOKING_TOTALPURAMT, 0) AS TOTALPURAMT,  ISNULL(HOTELBOOKINGMASTER.BOOKING_DISCRECDRS, 0) AS DISCRECDRS, ISNULL(HOTELBOOKINGMASTER.BOOKING_COMMRECDRS, 0) AS COMMRECDRS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURTDSRS, 0)  AS PURTDSRS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PUREXTRACHGS, 0) AS PUREXTRACHGS, ISNULL(PURADDTAXMASTER.tax_name, '') AS PURADDTAXNAME,  ISNULL(HOTELBOOKINGMASTER.BOOKING_PURADDTAX, 0) AS PURADDTAX, ISNULL(PUROTHERCHGS.Acc_cmpname, '') AS PUROTHERCHGSNAME, ISNULL(HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS, 0)  AS PUROTHERCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF, 0) AS PURROUNDOFF, ISNULL(HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT, 0) AS TOTALSALEAMT,  ISNULL(HOTELBOOKINGMASTER.BOOKING_DISCRS, 0) AS DISCRS, ISNULL(HOTELBOOKINGMASTER.BOOKING_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME,  ISNULL(HOTELBOOKINGMASTER.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0)  AS PURTAXSERVCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(HOTELBOOKINGMASTER.BOOKING_IRNNO, '')  AS IRNNO, ISNULL(HOTELBOOKINGMASTER.BOOKING_ACKNO, '') AS ACKNO, HOTELBOOKINGMASTER.BOOKING_ACKDATE AS ACKDATE, ISNULL(GUESTMASTER1.GUEST_NAME, '') AS GUEST1,  ISNULL(HOTELBOOKINGMASTER.BOOKING_SPECIALREMARKS, '') AS SPECIALREMARKS, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPDEPART ", "", " TAXMASTER AS PURADDTAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN BOOKEDBYMASTER ON HOTELBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN GROUPDEPARTURE ON HOTELBOOKINGMASTER.BOOKING_GROUPDEPARTID = GROUPDEPARTURE.GROUPDEP_NO AND  HOTELBOOKINGMASTER.BOOKING_YEARID = GROUPDEPARTURE.GROUPDEP_YEARID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON HOTELBOOKINGMASTER.BOOKING_OTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN LEDGERS AS PUROTHERCHGS ON HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGSID = PUROTHERCHGS.Acc_id ON PURADDTAXMASTER.tax_id = HOTELBOOKINGMASTER.BOOKING_PURADDTAXID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON HOTELBOOKINGMASTER.BOOKING_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN HSNMASTER AS PURHSNMASTER ON HOTELBOOKINGMASTER.BOOKING_PURHSNCODEID = PURHSNMASTER.HSN_ID LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGERS ON PURSTATEMASTER.state_id = PURLEDGERS.Acc_stateid ON HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER_1 ON HOTELBOOKINGMASTER.BOOKING_TAXID = TAXMASTER_1.tax_id LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON HOTELBOOKINGMASTER.BOOKING_PURTAXID = PURTAXMASTER.tax_id LEFT OUTER JOIN CITYMASTER AS ARRIVALCITYMASTER ON HOTELBOOKINGMASTER.BOOKING_ARRIVALFROMID = ARRIVALCITYMASTER.city_id LEFT OUTER JOIN CITYMASTER AS DEPARTCITYMASTER ON HOTELBOOKINGMASTER.BOOKING_DEPARTTOID = DEPARTCITYMASTER.city_id LEFT OUTER JOIN SOURCEMASTER ON HOTELBOOKINGMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN GUESTMASTER AS GUESTMASTER1 ON HOTELBOOKINGMASTER.BOOKING_GUEST1ID = GUESTMASTER1.GUEST_ID ", " AND BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND BOOKING_YEARID = " & YearId & " ORDER BY HOTELBOOKINGMASTER.BOOKING_NO")
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

    Private Sub InvoiceMasterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DOMESTIC RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

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

            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New HotelBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(I)
                OBJINVOICE.BOOKTYPE = FRMSTRING
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

            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJINVOICE As New HotelBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
                OBJINVOICE.BOOKTYPE = FRMSTRING
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

    Private Sub HotelBookingsDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName <> "TRAVELBRIDGE" Then
                GGUEST1.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class