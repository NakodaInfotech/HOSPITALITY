
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class AirlineBookingDetails

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
            dt = objclsCMST.search("AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, AIRLINEBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, AIRLINEBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, ISNULL(CRSMASTER.CRS_NAME, '') AS CRS, AIRLINEBOOKINGMASTER.BOOKING_BSPSALE AS BSP, AIRLINEBOOKINGMASTER.BOOKING_COUPONSALE AS COUPON, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, LEDGERS.Acc_cmpname AS ACCNAME, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS TICKETDATE, ISNULL(dbo.AIRLINEBOOKINGMASTER.BOOKING_RETURNDATE,GETDATE()) AS RETURNDATE, AIRLINEBOOKINGMASTER.BOOKING_PNRNO AS PNR, AIRLINEBOOKINGMASTER.BOOKING_AIRLINEPNR AS AIRPNR, AIRLINEBOOKINGMASTER.BOOKING_CRSPNR AS CRSPNR, AIRLINEBOOKINGMASTER.BOOKING_REFNO AS REFNO, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, AIRLINEBOOKINGMASTER.BOOKING_TOTALBASIC AS BASIC, AIRLINEBOOKINGMASTER.BOOKING_TOTALPSF AS YQ, AIRLINEBOOKINGMASTER.BOOKING_TOTALTAX AS TAXES, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME,AIRLINEBOOKINGMASTER.BOOKING_TAX AS TAXAMT, AIRLINEBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, AIRLINEBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, AIRLINEBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED, AIRLINEBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_REMARKS, '') AS REMARKS, USERMASTER.User_Name AS USERNAME, AIRLINEBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, AIRLINEBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, AIRLINEBOOKINGMASTER.BOOKING_FAILED AS FAILED, ISNULL(PURTAXMASTER.tax_name, '') AS PURTAXNAME, AIRLINEBOOKINGMASTER.BOOKING_PURTAX AS PURTAXAMT,  AIRLINEBOOKINGMASTER.BOOKING_TOTALAMT - AIRLINEBOOKINGMASTER.BOOKING_PURAMT AS MARKUP, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURDISCAMT, 0) AS PURDISCAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS PURCGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS PURSGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS PURIGSTAMT, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(PURLEDGER.ACC_GSTIN, '') AS PURGSTIN, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(PURSTATEMASTER.state_name, '') AS PURSTATENAME, ISNULL(CAST(PURSTATEMASTER.state_remark AS VARCHAR), '') AS PURSTATECODE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS, 0) AS PUROTHERCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_SALEDISCAMT, 0) AS DISCAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTDSRS, 0) AS PURTDSRS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURADDDISCAMT, 0) AS PURADDDISCAMT, ISNULL(purotherchgsLEDGERS.Acc_cmpname, '') AS PUROTHERCHGSNAME, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURROUNDOFF, 0) AS PURROUNDOFF, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALPURAMT, 0) AS TOTALPURAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_SALEDISCAMT, 0) AS SALEDISCAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(otherchgsLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALSALEAMT, 0) AS TOTALSALEAMT, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_IRNNO, '') AS IRNNO, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_ACKNO, '') AS ACKNO, AIRLINEBOOKINGMASTER.BOOKING_ACKDATE AS ACKDATE, AIRLINEBOOKINGMASTER.BOOKING_QRCODE AS QRCODE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALAMT, 0) AS TOTAL, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALPURPSF, 0) AS PSF, ISNULL(GROUPDEPARTURE.GROUPDEP_NAME, '') AS GROUPDEPARTURE ", "", " HSNMASTER RIGHT OUTER JOIN AIRLINEBOOKINGMASTER INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID INNER JOIN USERMASTER ON AIRLINEBOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id INNER JOIN BOOKEDBYMASTER ON AIRLINEBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN GROUPDEPARTURE ON AIRLINEBOOKINGMASTER.BOOKING_TOURID = GROUPDEPARTURE.GROUPDEP_NO LEFT OUTER JOIN LEDGERS AS otherchgsLEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_OTHERCHGSID = otherchgsLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS purotherchgsLEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGSID = purotherchgsLEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ON HSNMASTER.HSN_ID = AIRLINEBOOKINGMASTER.BOOKING_HSNCODEID LEFT OUTER JOIN TAXMASTER AS PURTAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURTAXID = PURTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN STATEMASTER AS PURSTATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGER ON PURSTATEMASTER.state_id = PURLEDGER.Acc_stateid ON AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGER.Acc_id LEFT OUTER JOIN CRSMASTER ON AIRLINEBOOKINGMASTER.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID LEFT OUTER JOIN SOURCEMASTER ON AIRLINEBOOKINGMASTER.BOOKING_SOURCEID = SOURCEMASTER.SOURCE_ID ", " AND BOOKING_SALEREGISTERID = " & SALEREGID & " AND BOOKING_YEARID = " & YearId & " ORDER BY AIRLINEBOOKINGMASTER.BOOKING_NO")
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

    Private Sub AirlineBookingDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Then
            Me.Close()
            Exit Sub
        End If
        If ClientName = "SEASONED" Then
            PRINTTOOL.Visible = True
            LBLFROM.Visible = True
            LBLTO.Visible = True
            TXTFROM.Visible = True
            TXTTO.Visible = True
        End If
        If ClientName = "GLOBAL" Then
            GPURGSTIN.Visible = False
            GPURSTATENAME.Visible = False
            GPURSTATECODE.Visible = False
            GGSTIN.Visible = False
            GSTATECODE.Visible = False
            GSTATENAME.Visible = False
            GHSNCODE.Visible = False
            GCGSTAMT.Visible = False
            GSGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GPURCGSTAMT.Visible = False
            GPURSGSTAMT.Visible = False
            GPURIGSTAMT.Visible = False



        End If
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New AirlineBookings
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

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
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

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGRID As New AirlineBookingGridDetails
            OBJGRID.MdiParent = MDIMain
            OBJGRID.FRMSTRING = FRMSTRING
            OBJGRID.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            'For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
            '    Dim OBJINVOICE As New AirlineBookingVoucherDesign
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
                Dim OBJINVOICE As New AirlineBookingVoucherDesign
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

            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJINVOICE As New AirlineBookingVoucherDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                OBJINVOICE.BOOKINGNO = Val(ROW("BOOKINGNO"))
                OBJINVOICE.BOOKINGDATE = ROW("BOOKINGDATE")
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

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Airline Booking Details.XLS"

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

            opti.SheetName = "Airline Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Airline Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class