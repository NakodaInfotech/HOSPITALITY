
Imports BL

Public Class CNRegisterDetails

    Public CNREGNAME As String
    Public FromDate As Date
    Public ToDate As Date

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CNRegisterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            ElseIf e.KeyCode = Keys.F4 Then
                Call TOOLDAILY_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CNRegisterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtfrom.Enabled = False
            dtto.Enabled = False
            chkdate.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsCNRegister

        ALPARAVAL.Add(CNREGNAME)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(FromDate)
            ALPARAVAL.Add(ToDate)
        End If
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        If chkdetails.CheckState = CheckState.Unchecked Then
            dt = objregister.getSUMMARY
        Else
            dt = objregister.getDETAILS
        End If
        griddetails.DataSource = dt


        total()
        txtopening.Text = Format(Val(txtopening.Text), "0.00")
    End Sub

    Sub total()
        Try
            txttotal.Text = 0.0
            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")


            'Dim dtrow As DataRow
            'Dim i As Integer

            'For i = 0 To gridregister.RowCount - 1
            '    dtrow = gridregister.GetDataRow(i)
            '    txtdrtotal.Text = Format(Val(txtdrtotal.Text) + Val(dtrow(4).ToString), "0.00")
            '    txtcrtotal.Text = Format(Val(txtcrtotal.Text) + Val(dtrow(5).ToString), "0.00")
            'Next

            'txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If

            'calculating total
            If Val(txttotal.Text) < 0 Then
                txttotal.Text = Format(Val(txttotal.Text) * (-1), "0.00")
                lbldrcrclosing.Text = "Cr"
            Else
                lbldrcrclosing.Text = "Dr"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Private Sub chkdetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdetails.CheckedChanged
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.DoubleClick
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        showform()
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                If dtrow(2).ToString = "PURCHASE" Then

                    Dim OBJPURCHASE As New HotelBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.FRMSTRING = "BOOKING"
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "TRANSFER PURCHASE" Then

                    Dim OBJPURCHASE As New HotelBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.FRMSTRING = "TRANSFER"
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "PACKAGE PURCHASE" Then

                    Dim OBJPURCHASE As New HolidayPackage
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "VISA PURCHASE" Then

                    Dim OBJPURCHASE As New VisaBooking
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "INTERNATIONAL PURCHASE" Then

                    Dim OBJPURCHASE As New InternationalBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "RAIL PURCHASE" Then

                    Dim OBJSALE As New RailwayBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "VEHICLE PURCHASE" Then

                    Dim OBJSALE As New CarBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "SALE" Then

                    Dim OBJSALE As New HotelBookings
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.FRMSTRING = "BOOKING"
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "TRANSFER SALE" Then

                    Dim OBJSALE As New HotelBookings
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.FRMSTRING = "TRANSFER"
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "PACKAGE SALE" Then

                    Dim OBJSALE As New HolidayPackage
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "VISA SALE" Then

                    Dim OBJSALE As New VisaBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "INTERNATIONAL SALE" Then

                    Dim OBJSALE As New InternationalBookings
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "RAIL SALE" Then

                    Dim OBJSALE As New RailwayBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "VEHICLE SALE" Then

                    Dim OBJSALE As New CarBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow(2).ToString = "PAYMENT" Then

                    Dim OBJPAYMENT As New PaymentMaster
                    OBJPAYMENT.MdiParent = MDIMain
                    OBJPAYMENT.edit = True
                    OBJPAYMENT.TEMPPAYMENTNO = dtrow("BILL").ToString
                    OBJPAYMENT.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJPAYMENT.Show()

                ElseIf dtrow(2).ToString = "RECEIPT" Then

                    Dim OBJREC As New Receipt
                    OBJREC.MdiParent = MDIMain
                    OBJREC.edit = True
                    OBJREC.TEMPRECEIPTNO = dtrow("BILL").ToString
                    OBJREC.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJREC.Show()

                ElseIf dtrow(2).ToString = "JOURNAL" Then

                    Dim OBJCN As New journal
                    OBJCN.MdiParent = MDIMain
                    OBJCN.edit = True
                    OBJCN.tempjvno = dtrow("BILL").ToString
                    OBJCN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJCN.Show()

                ElseIf dtrow(2).ToString = "DEBITNOTE" Then

                    Dim OBJDN As New DebitNote
                    OBJDN.MdiParent = MDIMain
                    OBJDN.edit = True
                    OBJDN.TEMPDNNO = dtrow("BILL").ToString
                    OBJDN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJDN.Show()

                ElseIf dtrow(2).ToString = "CREDITNOTE" Then

                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.edit = True
                    OBJCN.TEMPCNNO = dtrow("BILL").ToString
                    OBJCN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJCN.Show()

                ElseIf dtrow(2).ToString = "CONTRA" Then

                    Dim OBJCON As New ContraEntry
                    OBJCON.MdiParent = MDIMain
                    OBJCON.edit = True
                    OBJCON.tempcontrano = dtrow("BILL").ToString
                    OBJCON.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJCON.Show()

                ElseIf dtrow(2).ToString = "EXPENSE" Then

                    Dim OBJEXP As New ExpenseVoucher
                    OBJEXP.MdiParent = MDIMain
                    OBJEXP.edit = True
                    OBJEXP.TEMPEXPNO = dtrow("BILL").ToString
                    OBJEXP.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJEXP.FRMSTRING = "NONPURCHASE"
                    OBJEXP.Show()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NAR(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch ex As Exception
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = "" = Application.StartupPath & "\Credit Note Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next
            opti.SheetName = "Credit Note Details"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Credit Note Details", gridregister.VisibleColumns.Count + gridregister.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Credit Note Register.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            If chkdate.Checked = False Then
                PERIOD = AccFrom & " - " & AccTo
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If


            opti.SheetName = "Credit Note Register"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Credit Note Register", gridregister.VisibleColumns.Count + gridregister.GroupCount, "", PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDAILY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDAILY.Click
        Try
            Dim OBJCN As New CNRegisterDaily
            OBJCN.CNREGNAME = CNREGNAME
            OBJCN.FromDate = FromDate
            OBJCN.ToDate = ToDate
            OBJCN.MdiParent = MDIMain
            OBJCN.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class