
Imports BL

Public Class LedgerBook

    Public TEMPNAME As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Sub fillgrid()

        txttotal.Text = "0.00"

        Dim dt As New DataTable()
        Dim ALPARAVAL As New ArrayList

        Dim objregister As New ClsLedgerBook

        ALPARAVAL.Add(cmbname.Text.Trim)
        If chkdate.Checked = True Then
            ALPARAVAL.Add(dtfrom.Value.Date)
            ALPARAVAL.Add(dtto.Value.Date)
        Else
            ALPARAVAL.Add(AccFrom)
            'COZ DATE WONT BE IN ACCOUNTING YEAR
            If CmpName = "TRANSFER DATA" Then
                ALPARAVAL.Add(Now.Date)
            Else
                ALPARAVAL.Add(AccTo)
            End If
        End If

        ALPARAVAL.Add(CHKARR.Checked)
        ALPARAVAL.Add(ARRFROM.Value.Date)
        ALPARAVAL.Add(ARRTO.Value.Date)

        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        objregister.alParaval = ALPARAVAL
        If chksubdetails.CheckState = CheckState.Checked Then
            dt = objregister.GETSUBDETAILS
        ElseIf chkdetails.Checked = True Then
            dt = objregister.getDETAILS
        ElseIf chkdetails.Checked = False Then
            dt = objregister.getSUMMARY
        End If
        griddetails.DataSource = dt


        'getting opening balances
        Dim OBJCOMMON As New ClsCommonMaster
        If chkdate.CheckState = CheckState.Unchecked And CHKARR.CheckState = CheckState.Unchecked Then
            dt = OBJCOMMON.search(" ISNULL(SUM(DR)-SUM(CR), 0)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(AccFrom, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        ElseIf chkdate.CheckState = CheckState.Checked Then
            dt = OBJCOMMON.search(" ISNULL(SUM(DR)-SUM(CR), 0)", "", " Register_Grouped", " and name = '" & cmbname.Text.Trim & "' and acc_billdate <'" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and YEARID = " & YearId)
        ElseIf CHKARR.CheckState = CheckState.Checked Then
            GETARROPBAL()
            GoTo LINE1
        End If

        '' ADDED BY SHOHIN, FOR ADJUSTING OPENING BALANCE
        'Dim dtOPEN As DataTable = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
        'Dim OPEN_BAL As Double
        'If dtOPEN.Rows.Count > 0 Then
        '    'txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
        '    If dtOPEN.Rows(0).Item(1).ToString = "Dr." Then
        '        OPEN_BAL = Val(dtOPEN.Rows(0).Item(0).ToString)
        '        'lbldrcropening.Text = "Dr"
        '    Else
        '        OPEN_BAL = Val(dtOPEN.Rows(0).Item(0).ToString) * (-1)
        '        'lbldrcropening.Text = "Cr"
        '    End If
        'End If


        If dt.Rows.Count > 0 Then
            dt.Rows(0).Item(0) = Val(dt.Rows(0).Item(0))
            If Val(dt.Rows(0).Item(0).ToString) < 0 Then
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
                lbldrcropening.Text = "Cr"
            Else
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                lbldrcropening.Text = "Dr"
            End If
        End If

LINE1:
        'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
        'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
        If (Val(txtopening.Text.Trim) = 0 And chkdate.CheckState = CheckState.Unchecked) Or (Val(txtopening.Text.Trim) = 0 And chkdate.CheckState = CheckState.Checked And dtfrom.Value.Date = Convert.ToDateTime("01/04/" & Year(AccFrom)).Date) Then
            dt = OBJCOMMON.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
                If dt.Rows(0).Item(1).ToString = "Dr." Then
                    lbldrcropening.Text = "Dr"
                Else
                    lbldrcropening.Text = "Cr"
                End If
            End If
        End If

        total()
        txtopening.Text = Format(Val(txtopening.Text), "0.00")
    End Sub

    Sub GETARROPBAL()
        Try

            Dim DRBAL, CRBAL As Double

            Dim dt As New DataTable()
            Dim ALPARAVAL As New ArrayList

            Dim objregister As New ClsLedgerBook

            ALPARAVAL.Add(cmbname.Text.Trim)
            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                'COZ DATE WONT BE IN ACCOUNTING YEAR
                If CmpName = "TRANSFER DATA" Then
                    ALPARAVAL.Add(Now.Date)
                Else
                    ALPARAVAL.Add(AccTo)
                End If
            End If

            ALPARAVAL.Add(CHKARR.Checked)
            ALPARAVAL.Add(AccFrom)
            ALPARAVAL.Add(ARRFROM.Value.Date.AddDays(-1))

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            objregister.alParaval = ALPARAVAL
            If chksubdetails.CheckState = CheckState.Checked Then
                dt = objregister.GETSUBDETAILS
            ElseIf chkdetails.Checked = True Then
                dt = objregister.getDETAILS
            ElseIf chkdetails.Checked = False Then
                dt = objregister.getSUMMARY
            End If
            DRBAL = 0
            CRBAL = 0

            If dt.Rows.Count > 0 Then
                DRBAL = dt.Compute("SUM(DEBIT)", "DEBIT>0")
                CRBAL = dt.Compute("SUM(CREDIT)", "CREDIT>0")
            End If

            If (Val(DRBAL) - Val(CRBAL)) < 0 Then
                txtopening.Text = (Val(DRBAL) - Val(CRBAL)) * (-1)
                lbldrcropening.Text = "Cr"
            Else
                txtopening.Text = (Val(DRBAL) - Val(CRBAL))
                lbldrcropening.Text = "Dr"
            End If

            'GETTING OPNEING
            Dim OBJCMN As New ClsCommon
            dt = OBJCMN.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(1).ToString = "Dr." Then
                    If lbldrcropening.Text = "Dr" Then
                        txtopening.Text = Val(txtopening.Text.Trim) + Val(dt.Rows(0).Item(0))
                    Else
                        txtopening.Text = Val(txtopening.Text.Trim) - Val(dt.Rows(0).Item(0))
                        If Val(txtopening.Text.Trim) < 0 Then
                            txtopening.Text = Val(txtopening.Text.Trim) * (-1)
                            lbldrcropening.Text = "Dr"
                        End If
                    End If
                Else
                    If lbldrcropening.Text = "Cr" Then
                        txtopening.Text = Val(txtopening.Text.Trim) + Val(dt.Rows(0).Item(0))
                    Else
                        txtopening.Text = Val(txtopening.Text.Trim) - Val(dt.Rows(0).Item(0))
                        If Val(txtopening.Text.Trim) < 0 Then
                            txtopening.Text = Val(txtopening.Text.Trim) * (-1)
                            lbldrcropening.Text = "Cr"
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            txttotal.Text = 0.0
            txtdrtotal.Text = 0.0
            txtcrtotal.Text = 0.0

            txtcrtotal.Text = Format(Val(gcr.SummaryText), "0.00")
            txtdrtotal.Text = Format(Val(gdr.SummaryText), "0.00")


            'FOR RUNNING BALANCE
            Dim dtrow As DataRow
            Dim i As Integer
            Dim RUNNINGBAL As Double
            If lbldrcropening.Text = "Dr" Then
                RUNNINGBAL = Val(txtopening.Text)
            Else
                RUNNINGBAL = Val(txtopening.Text) * (-1)
            End If

            For i = 0 To gridregister.RowCount - 1
                dtrow = gridregister.GetDataRow(i)
                dtrow("RUNNINGBAL") = (Val(dtrow("Debit")) + Val(RUNNINGBAL)) - Val(dtrow("Credit"))
                RUNNINGBAL = dtrow("RUNNINGBAL")
            Next


            'Dim dtrow As DataRow
            'Dim i As Integer

            'For i = 0 To gridregister.RowCount - 1
            '    dtrow = gridregister.GetDataRow(i)
            '    txtdrtotal.Text = Format(Val(txtdrtotal.Text) + Val(dtrow(4).ToString), "0.00")
            '    txtcrtotal.Text = Format(Val(txtcrtotal.Text) + Val(dtrow(5).ToString), "0.00")
            'Next

            'txttotal.Text = Format(Val(txtdrtotal.Text) - Val(txtcrtotal.Text), "0.00")

            'If chkdate.CheckState = CheckState.Checked Then
            If lbldrcropening.Text = "Dr" Then
                txttotal.Text = Format((Val(txtdrtotal.Text) + Val(txtopening.Text)) - Val(txtcrtotal.Text), "0.00")
            Else
                txttotal.Text = Format(Val(txtdrtotal.Text) - (Val(txtcrtotal.Text) + Val(txtopening.Text)), "0.00")
            End If
            'End If

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

    Private Sub RegisterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F3 Then
                Dim objlb As New LedgerBillwise
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F4 Then
                Dim objlb As New LedgerDaily
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                Dim objlb As New LedgerMonthly
                objlb.cmbname.Text = cmbname.Text.Trim
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegisterDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillname(cmbname, False, " and LEDGERS.ACC_YEARID = " & YearId)
            cmbname.Text = TEMPNAME
            fillgrid()
            If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                gridregister.Columns("ARRIVAL").Caption = "Travel Dt"
                gridregister.Columns("Name").Caption = "Sale Type"
                gridregister.Columns("REMARKS").Caption = "Details"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
            If chkdate.Checked = True Then CHKARR.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
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
                If dtrow("TYPE").ToString = "PURCHASE" Then

                    Dim OBJPURCHASE As New HotelBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.FRMSTRING = "BOOKING"
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "TRANSFER PURCHASE" Then

                    Dim OBJPURCHASE As New HotelBookings
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.FRMSTRING = "TRANSFER"
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "PACKAGE PURCHASE" Then

                    Dim OBJPURCHASE As New HolidayPackage
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "VISA PURCHASE" Then

                    Dim OBJPURCHASE As New VisaBooking
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow("TYPE").ToString = "INTERNATIONAL PURCHASE" Then

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

                ElseIf dtrow(2).ToString = "MISC PURCHASE" Then

                    Dim OBJPURCHASE As New MiscPur
                    OBJPURCHASE.MdiParent = MDIMain
                    OBJPURCHASE.edit = True
                    OBJPURCHASE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJPURCHASE.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJPURCHASE.Show()

                ElseIf dtrow(2).ToString = "MISC SALE" Then

                    Dim OBJSALE As New MiscSale
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJSALE.TEMPREGNAME = dtrow("REGTYPE").ToString
                    OBJSALE.Show()

                ElseIf dtrow("TYPE").ToString = "SALE" Then

                    Dim OBJSALE As New HotelBookings
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.FRMSTRING = "BOOKING"
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow("TYPE").ToString = "TRANSFER SALE" Then

                    Dim OBJSALE As New HotelBookings
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.FRMSTRING = "TRANSFER"
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJPURCHASE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow("TYPE").ToString = "PACKAGE SALE" Then

                    Dim OBJSALE As New HolidayPackage
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow("TYPE").ToString = "VISA SALE" Then

                    Dim OBJSALE As New VisaBooking
                    OBJSALE.MdiParent = MDIMain
                    OBJSALE.edit = True
                    OBJSALE.TEMPBOOKINGNO = dtrow("BILL").ToString
                    'OBJSALE.TEMPREGNAME = dtrow(7).ToString
                    OBJSALE.Show()

                ElseIf dtrow("TYPE").ToString = "INTERNATIONAL SALE" Then

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

                ElseIf dtrow("REGTYPE").ToString = "AIRLINE PURCHASE REGISTER" Then
                    Dim OBJAIR As New AirlineBookings
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.FRMSTRING = "DOMESTIC"
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("REGTYPE").ToString = "INTAIRLINE PURCHASE REGISTER" Then
                    Dim OBJAIR As New AirlineBookings
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.FRMSTRING = "INTERNATIONAL"
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("REGTYPE").ToString = "OTHER PURCHASE REGISTER" Then
                    Dim OBJAIR As New OtherSalePurchase
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("REGTYPE").ToString = "OTHER SALE REGISTER" Then
                    Dim OBJAIR As New OtherSalePurchase
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("TYPE").ToString = "AIRDEBITNOTE" Then
                    Dim objDN As New AirlineDebitNote
                    objDN.MdiParent = MDIMain
                    objDN.edit = True
                    objDN.TEMPDNNO = dtrow("BILL").ToString
                    objDN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    objDN.Show()

                ElseIf dtrow("NAME").ToString = "AIRLINE SALE" Then
                    Dim OBJAIR As New AirlineBookings
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.FRMSTRING = "DOMESTIC"
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("NAME").ToString = "INTAIRLINE SALE" Then
                    Dim OBJAIR As New AirlineBookings
                    OBJAIR.MdiParent = MDIMain
                    OBJAIR.FRMSTRING = "INTERNATIONAL"
                    OBJAIR.edit = True
                    OBJAIR.TEMPBOOKINGNO = dtrow("BILL").ToString
                    OBJAIR.Show()

                ElseIf dtrow("TYPE").ToString = "AIRCREDITNOTE" Then
                    Dim objCN As New AirlineCreditNote
                    objCN.MdiParent = MDIMain
                    objCN.edit = True
                    objCN.TEMPCNNO = dtrow("BILL").ToString
                    objCN.TEMPREGNAME = dtrow("REGTYPE").ToString
                    objCN.Show()
                ElseIf dtrow("TYPE").ToString = "MISC. SALE" Then
                    Dim objMS As New MiscSale
                    objMS.MdiParent = MDIMain
                    objMS.edit = True
                    objMS.TEMPBOOKINGNO = dtrow("BILL").ToString
                    objMS.PURregid = dtrow("REGTYPE").ToString
                    objMS.Show()
                ElseIf dtrow("TYPE").ToString = "MISC. PURCHASE" Then
                    Dim objMP As New MiscPur
                    objMP.MdiParent = MDIMain
                    objMP.edit = True
                    objMP.TEMPBOOKINGNO = dtrow("BILL").ToString
                    objMP.PURregid = dtrow("REGTYPE").ToString
                    objMP.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        Try

            'Dim tempmsg As Integer = MsgBox("Wish to Print All Ledgers?", MsgBoxStyle.YesNo)
            'If tempmsg = vbYes Then
            '    Dim OBJLEDGER As New LedgerFilter
            '    OBJLEDGER.MdiParent = MDIMain
            '    OBJLEDGER.Show()
            '    Exit Sub
            'End If



            Dim objreg As New registerdesign
            'strsearch = "{SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@PBILL_NO}=" & tempbillno & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@registername}=" & cmbregister.Text & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@cmpid}=" & CmpId & ""
            Dim tempmsg As Integer = MsgBox("Wish to Print Ledger Confirmation?", MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                objreg.frmstring = "LedgerBookConfirm"
                'Else
                '    If chkdetails.Checked = False Then
                '        objreg.frmstring = "LedgerBook"
                '    Else
                '        objreg.frmstring = "LedgerBookDetails"
                '    End If
            End If

            objreg.OPENING = Format(Val(txtopening.Text), "0.00")
            objreg.CLOSINGAMT = Format(Val(txttotal.Text), "0.00")
            objreg.crdr = lbldrcropening.Text
            objreg.CLOSINGDRCR = lbldrcrclosing.Text
            objreg.name = cmbname.Text.Trim


            If chkdate.Checked = True Then
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
                objreg.PERIOD = "LEDGER BOOK (" & Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy") & ")"
            Else
                objreg.FROMDATE = AccFrom
                objreg.TODATE = AccTo
                objreg.PERIOD = "LEDGER BOOK (" & Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy") & ")"
            End If

            objreg.NEWPAGE = True
            objreg.INDEX = False
            objreg.ADDRESS = 0

            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chksubdetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksubdetails.CheckedChanged
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKARR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKARR.CheckedChanged
        Try
            ARRFROM.Enabled = CHKARR.CheckState
            ARRTO.Enabled = CHKARR.CheckState
            If CHKARR.Checked = True Then chkdate.Checked = False
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            If chkdetails.Checked = True Then
                PATH = Application.StartupPath & "\Ledger Book Details.XLS"
            ElseIf chksubdetails.Checked = True Then
                PATH = Application.StartupPath & "\Ledger Book sub-Details.XLS"
            Else
                PATH = Application.StartupPath & "\Ledger Book Summary.XLS"
            End If
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

            If chkdetails.Checked = True Then
                opti.SheetName = "Ledger Book Details"
                griddetails.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Ledger Book Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)

            ElseIf chksubdetails.Checked = True Then
                opti.SheetName = "Ledger Book sub-Details"
                griddetails.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Ledger Book sub-Details", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)
            Else
                opti.SheetName = "Ledger Book Summary"
                griddetails.ExportToXls(PATH, opti)
                EXCELCMPHEADER(PATH, "Ledger Book Summary", gridregister.VisibleColumns.Count + gridregister.GroupCount, cmbname.Text.Trim, PERIOD, Val(txtopening.Text.Trim) & " " & lbldrcropening.Text.Trim, Val(txttotal.Text.Trim) & " " & lbldrcrclosing.Text)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLBILL.Click
        Try
            Dim objlb As New LedgerBillwise
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDAILY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDAILY.Click
        Try
            Dim objlb As New LedgerDaily
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMONTHLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMONTHLY.Click
        Try
            Dim objlb As New LedgerMonthly
            objlb.cmbname.Text = cmbname.Text.Trim
            objlb.fillgrid()
            objlb.MdiParent = MDIMain
            objlb.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub griddetails_Click(sender As Object, e As EventArgs) Handles griddetails.Click

    End Sub
End Class