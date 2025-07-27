Imports BL
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.GridControl
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class BspStock
    Dim AB As BaseView

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click

        If chkpaid.CheckState = CheckState.Checked Then
            'FILLGRIDPAID()
        Else
            fillgrid()
        End If
    End Sub

    Sub fillgrid()
        gridregister.OptionsDetail.EnableMasterViewMode = True
        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim dt1 As New DataTable
        Dim ALPARAVAL As New ArrayList

        Dim whereclause As String = ""

        If cmbname.Text.Trim.Length > 0 Then
            whereclause = whereclause & " AND AIRLINE_SALEREPORT.NAME = '" & cmbname.Text.Trim & "'"
        End If

        If cmbairline.Text.Trim.Length > 0 Then
            whereclause = whereclause & " AND AIRLINE_SALEREPORT.AIRLINENAME = '" & cmbairline.Text.Trim & "'"
        End If

        If chkdate.Checked = True Then
            whereclause = whereclause & " AND AIRLINE_SALEREPORT.DATE BETWEEN '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
        Else
            whereclause = whereclause & " AND AIRLINE_SALEREPORT.DATE BETWEEN '" & Format(AccFrom, "MM/dd/yyyy") & "' AND '" & Format(AccTo, "MM/dd/yyyy") & "'"
        End If

        If CHKTICKET.Checked = True Then
            whereclause = whereclause & " AND AIRLINE_SALEREPORT.TICKETDATE BETWEEN '" & Format(ARRFROM.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(ARRTO.Value.Date, "MM/dd/yyyy") & "'"
        End If

        Dim OBJCMN As New ClsCommon
        dt = OBJCMN.search(" [TYPE] AS TYPE,[DATE] AS DATE, AIRLINENAME AS AIRLINENAME, CMNNAME AS CMNNAME, REFNO AS REFNO, CRSTYPE AS CRSTYPE, BILLINITIALS AS INITIALS , DEBIT AS DR, CREDIT AS CR, BOOKINGNO AS BILL, REGISTERNAME AS REGTYPE, TICKETDATE AS TICKETDATE, BOOKEDBY AS BOOKEDBY, REMARKS AS REMARKS, USERNAME AS USERNAME ", "", " AIRLINE_SALEREPORT ", " AND AIRLINE_SALEREPORT.BSPSALE = 'True' AND AIRLINE_SALEREPORT.CMPID = " & CmpId & " AND AIRLINE_SALEREPORT.YEARID = " & YearId & " AND AIRLINE_SALEREPORT.LOCATIONID = " & Locationid & " " & whereclause & " GROUP BY [TYPE],[DATE], AIRLINENAME, CMNNAME, REFNO, CRSTYPE, BILLINITIALS, DEBIT, CREDIT, BOOKINGNO, REGISTERNAME, TICKETDATE, BOOKEDBY, REMARKS, USERNAME ORDER BY [DATE], (CASE WHEN [TYPE] = 'AIRLINEPURCHASE'  THEN 0 WHEN [TYPE] = 'AIRLINESALE'  THEN 1 WHEN [TYPE] = 'AIRDEBITNOTE'  THEN 2 WHEN [TYPE] = 'AIRCREDITNOTE'   THEN 3 END ) ")

        dt1 = OBJCMN.search(" TICKETNO AS TICKETNO, GRIDBASIC AS GRIDBASIC, GRIDPSF AS GRIDPSF, GRIDTAXES AS GRIDTAX, GRIDAMT AS GRIDTOTAL, BILLINITIALS AS INITIALS ", "", " AIRLINE_SALEREPORT ", " AND AIRLINE_SALEREPORT.BSPSALE = 'True' AND AIRLINE_SALEREPORT.CMPID = " & CmpId & " AND AIRLINE_SALEREPORT.YEARID = " & YearId & " AND AIRLINE_SALEREPORT.LOCATIONID = " & Locationid & " " & whereclause)


        Dim DTSET As New DataSet
        DTSET.Tables.Add(dt.Copy)
        DTSET.Tables(0).TableName = "AIRLINE_SALE"
        DTSET.Tables.Add(dt1.Copy)
        DTSET.Tables(1).TableName = "AIRLINE_SALE_TRANSACTION"

        DTSET.Relations.Add("BILLDETAILS", DTSET.Tables("AIRLINE_SALE").Columns("INITIALS"), DTSET.Tables("AIRLINE_SALE_TRANSACTION").Columns("INITIALS"), False)

        griddetails.DataSource = DTSET.Tables("AIRLINE_SALE")
        'griddetails.DataSource = dt



        '***********************************************************************
        'NO NEED OF OPENING BALANCE HERE ONLY REQUIRED WHEN ALL BILLS IS CHECKED
        'COZ IT CAUSES DOUBLE ENTRY, AS WE ARE GETTING OPENING BILLS FROM TABLE
        '***********************************************************************
        'getting opening balances

        lblopbal.Visible = chkall.Checked
        txtopening.Visible = chkall.Checked
        lbldrcropening.Visible = chkall.Checked
        ' ASK GULKIT WHAT TO DO
        'If chkall.CheckState = CheckState.Checked Then
        '    Dim OBJCOMMON As New ClsCommonMaster
        '    If chkdate.CheckState = CheckState.Unchecked Then
        '        dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(AccFrom, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        '    Else
        '        dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        '    End If
        '    If dt.Rows.Count > 0 Then
        '        If Val(dt.Rows(0).Item(0).ToString) < 0 Then
        '            txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
        '            lbldrcropening.Text = "Cr"
        '        Else
        '            txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
        '            lbldrcropening.Text = "Dr"
        '        End If
        '    End If


        '    'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
        '    'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
        '    If Val(txtopening.Text.Trim) = 0 Then
        '        dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        '        If dt.Rows.Count > 0 Then
        '            txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
        '            If dt.Rows(0).Item(1).ToString = "Dr." Then
        '                lbldrcropening.Text = "Dr"
        '            Else
        '                lbldrcropening.Text = "Cr"
        '            End If
        '        End If
        '    End If
        'Else
        '    txtopening.Clear()
        'End If
        '***********************************************************************


        'total()

    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and ledgers.acc_cmpname = '" & cmbname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BspStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BspStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'dtfrom.Enabled = False
            'dtto.Enabled = False
            'chkdate.Checked = False
            fillname(cmbname, False, " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId)
            FILLAIRLINE(cmbairline, False, "")
            gridregister.OptionsDetail.EnableMasterViewMode = chkpaid.CheckState
            'If chkpaid.CheckState = CheckState.Checked Then
            '    'FILLGRIDPAID()
            'Else
            fillgrid()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            If chkdate.Checked = True Then CHKTICKET.Checked = False
            gridregister.OptionsDetail.EnableMasterViewMode = chkpaid.CheckState
            'If chkpaid.CheckState = CheckState.Checked Then
            '    FILLGRIDPAID()
            'Else
            fillgrid()
            ' End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            gridregister.OptionsDetail.EnableMasterViewMode = chkpaid.CheckState
            'If chkpaid.CheckState = CheckState.Checked Then
            '    FILLGRIDPAID()
            'Else
            fillgrid()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridregister_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridregister.ColumnFilterChanged
        Try
            ' total()
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
        Try
            showform()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform()
        Try
            If gridregister.RowCount > 0 Then
                Dim dtrow As DataRow = gridregister.GetFocusedDataRow
                If dtrow("TYPE").ToString = "HOTELBOOKING" Then

                    Dim OBJPURCHASE As New HotelBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.FRMSTRING = dtrow("BOOKTYPE").ToString
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "HOLIDAYPACKAGE" Then

                    Dim OBJPURCHASE As New HolidayPackage
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "INTERNATIONALBOOKINGMASTER" Then

                    Dim OBJPURCHASE As New InternationalBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "PAYMENT" Then

                    Dim OBJPAYMENT As New PaymentMaster
                    OBJPAYMENT.MdiParent = MDIMain
                    OBJPAYMENT.edit = True
                    OBJPAYMENT.TEMPPAYMENTNO = dtrow("BILL").ToString
                    OBJPAYMENT.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJPAYMENT.Show()

                ElseIf dtrow("TYPE").ToString = "RECEIPT" Then

                    Dim OBJREC As New Receipt
                    OBJREC.MdiParent = MDIMain
                    OBJREC.edit = True
                    OBJREC.TEMPRECEIPTNO = dtrow("BILL").ToString
                    OBJREC.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJREC.Show()

                ElseIf dtrow("TYPE").ToString = "JOURNAL" Then

                    Dim OBJJV As New journal
                    OBJJV.MdiParent = MDIMain
                    OBJJV.edit = True
                    OBJJV.tempjvno = dtrow("BILL").ToString
                    OBJJV.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJJV.Show()

                ElseIf dtrow("TYPE").ToString = "DEBITNOTE" Then

                    Dim OBJDN As New DebitNote
                    OBJDN.MdiParent = MDIMain
                    OBJDN.edit = True
                    OBJDN.TEMPDNNO = dtrow("BILL").ToString
                    OBJDN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJDN.Show()

                ElseIf dtrow("TYPE").ToString = "CREDITNOTE" Then

                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.edit = True
                    OBJCN.TEMPCNNO = dtrow("BILL").ToString
                    OBJCN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJCN.Show()

                ElseIf dtrow("TYPE").ToString = "CONTRA" Then

                    Dim OBJCON As New ContraEntry
                    OBJCON.MdiParent = MDIMain
                    OBJCON.edit = True
                    OBJCON.tempcontrano = dtrow("BILL").ToString
                    OBJCON.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJCON.Show()

                ElseIf dtrow("TYPE").ToString = "EXPENSE" Then

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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            PATH = Application.StartupPath & "\BSP.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next
            opti.SheetName = "BSP STOCK (Bill Wise)"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "BSP STOCK (Bill Wise)", gridregister.VisibleColumns.Count + gridregister.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkpaid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpaid.CheckedChanged
        Try
            gridregister.OptionsDetail.EnableMasterViewMode = chkpaid.CheckState
            'If chkpaid.CheckState = CheckState.Checked Then
            '    FILLGRIDPAID()
            'Else
            fillgrid()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\BSP.XLS"

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


            opti.SheetName = "BSP STOCK (Bill Wise)"
            gridregister.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "BSP STOCK (Bill Wise)", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTICKET_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTICKET.CheckedChanged
        Try
            ARRFROM.Enabled = CHKTICKET.CheckState
            ARRTO.Enabled = CHKTICKET.CheckState
            If CHKTICKET.Checked = True Then chkdate.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbairline_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbairline.Enter
        Try
            If cmbairline.Text.Trim = "" Then FILLAIRLINE(cmbairline, False, " ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbairline_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbairline.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJFLIGHT As New SelectFlight
                'OBJFLIGH.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJFLIGHT.ShowDialog()
                If OBJFLIGHT.TEMPCODE <> "" Then CMBAIRCODE.Text = OBJFLIGHT.TEMPCODE
                If OBJFLIGHT.TEMPNAME <> "" Then cmbairline.Text = OBJFLIGHT.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbairline_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbairline.Validating
        Try
            If cmbairline.Text.Trim <> "" Then AIRLINEVALIDATE(cmbname, CMBAIRCODE, e, Me, " and FLIGHTMASTER.FLIGHT_NAME = '" & cmbairline.Text.Trim & "' and FLIGHT_CMPID = " & CmpId & " and FLIGHT_LOCATIONID = " & Locationid & " and FLIGHT_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class