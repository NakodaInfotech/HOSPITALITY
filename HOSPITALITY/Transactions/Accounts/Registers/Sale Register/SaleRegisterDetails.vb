﻿
Imports BL

Public Class SaleRegisterDetails

    Public SALEREGNAME As String
    Public FromDate As Date
    Public ToDate As Date

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        Try
            dtfrom.Enabled = chkdate.CheckState
            dtto.Enabled = chkdate.CheckState
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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        fillgrid()
    End Sub

    Private Sub SaleRegisterDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SaleRegisterDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Dim objregister As New ClsSaleRegister

        ALPARAVAL.Add(SALEREGNAME)
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


        ''getting opening balances
        'Dim OBJCOMMON As New ClsCommonMaster
        'If chkdate.CheckState = CheckState.Unchecked Then
        '    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CashName & "' and acc_billdate <='" & Format(FromDate, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId)
        'Else
        '    dt = OBJCOMMON.search(" SUM(DR)-SUM(CR)", "", " Register_Grouped", " and name = '" & CashName & "' and acc_billdate <='" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' and acc_cmpid = " & CmpId)
        'End If
        'If dt.Rows.Count > 0 Then
        '    If Val(dt.Rows(0).Item(0).ToString) < 0 Then
        '        txtopening.Text = Val(dt.Rows(0).Item(0).ToString) * (-1)
        '        lbldrcropening.Text = "Cr"
        '    Else
        '        txtopening.Text = Val(dt.Rows(0).Item(0).ToString)
        '        lbldrcropening.Text = "Dr"
        '    End If
        'End If

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

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

            Dim objreg As New registerdesign
            'strsearch = "{SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@PBILL_NO}=" & tempbillno & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@registername}=" & cmbregister.Text & " and {SP_TRANS_SELECT_PURCHASEBILL_FOR_EDIT;1.@cmpid}=" & CmpId & ""
            If chkdetails.Checked = False Then
                objreg.frmstring = "SaleRegister"
            Else
                objreg.frmstring = "SaleRegisterDetails"
            End If
            If chkdate.Checked = True Then
                objreg.FROMDATE = dtfrom.Value.Date
                objreg.TODATE = dtto.Value.Date
            Else
                objreg.FROMDATE = FromDate
                objreg.TODATE = ToDate
            End If
            objreg.reg = SALEREGNAME
            objreg.MdiParent = MDIMain
            objreg.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class