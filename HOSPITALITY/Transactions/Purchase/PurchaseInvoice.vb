Imports BL

Public Class PurchaseInvoice

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick, gridCurDoubleClick As Boolean
    Dim temprow As Integer
    Public edit As Boolean
    Public tempbillno As Integer
    Public TEMPREGNAME As String
    Dim tempbillamtpaid, temptdspaid As Double
    Dim temprefno, purregabbr, purreginitial As String
    Dim purregid As Integer
    Public Shared strsearch As String
    Dim tempCURrow As Integer
    Dim PRESENT As Boolean

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        EP.Clear()
        txtpartybillno.Clear()
        txtadd.Clear()
        cmbname.Text = ""
        CMBTOURNAME.Text = ""
        purchasedate.Value = Mydate
        duedate.Value = Mydate
        txtremarks.Clear()
        txtinwords.Clear()
        txttax.Clear()
        txtotherchg.Clear()
        CMBTOURNAME.DataSource = Nothing
        CMBSERVICETYPE.Text = ""
        CMBPASSNAME.DataSource = Nothing

        lblamt.Text = "0.00"

        txtsubtotal.Text = 0.0
        cmbtax.Text = ""
        lbltax.Text = ""
        cmbaddsub.SelectedIndex = (0)
        txtgtotal.Text = 0.0
     
        gridbill.RowCount = 0
        GRIDCURRENCY.RowCount = 0
        'purregabbr = ""
        'purreginitial = ""
        CMBSERVICENAME.Text = ""
        CMBPASSNAME.Text = ""
        CMBPASSNAME.Items.Clear()
        CMBREGNO.Text = ""
        CMBREGNO.Items.Clear()
        txtrate.Clear()
        CMBCURRENCY.Text = ""
        TXTDESC.Text = ""
        TXTCURAMT.Clear()
        txtamount.Clear()

        GRIDCURRENCY.RowCount = 0
        CMBCURCURRENCY.Text = ""
        TXTCURRATE.Clear()

        gridDoubleClick = False
        gridCurDoubleClick = False

        getmax_BILLNO()

        If gridbill.RowCount > 0 Then
            txtsrno.Text = Val(gridbill.Rows(gridbill.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        If GRIDCURRENCY.RowCount > 0 Then
            TXTCURSRNO.Text = Val(GRIDCURRENCY.Rows(GRIDCURRENCY.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCURSRNO.Text = 1
        End If

    End Sub

    Sub getmax_BILLNO()
        Dim DTTABLE As New DataTable
        cmbregister.Text = "TOUR PURCHASE REGISTER"
        DTTABLE = getmax(" isnull(max(BILL_NO),0) + 1 ", "PURCHASEINVOICE INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID AND REGISTER_CMPID = BILL_CMPID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND BILL_cmpid=" & CmpId & " AND BILL_LOCATIONid=" & Locationid & " AND BILL_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtbillno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub PurchaseInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdsave_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillcombo()
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " AND REGISTER_TYPE='PURCHASE'")
            If CMBCURCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURCURRENCY)
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
            If CMBTOURNAME.Text.Trim = "" Then FILLTOURNAME(CMBTOURNAME, edit, "")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'REGISTRATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            getmax_BILLNO()
            fillname(cmbname, edit, " and groupmaster.group_secondary = 'Sundry Creditors' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID  = " & Locationid & " AND ACC_YEARID = " & YearId)
            fillcombo()
            cmbregister.Text = "TOUR PURCHASE REGISTER"

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt_po As New DataTable
                Dim objclspurchase As New ClsPurchaseInvoice()
                dt_po = objclspurchase.selectpurchase(tempbillno, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt_po.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_po.Rows


                        cmbname.Text = Convert.ToString(dr("NAME"))
                        txtbillno.Text = Convert.ToString(dr("BILLNO"))
                        cmbregister.Text = Convert.ToString(dr("REGNAME"))
                        CMBTOURNAME.Text = Convert.ToString(dr("TOURNAME"))
                        FILLPASSANGER()
                        txtpartybillno.Text = Convert.ToString(dr("PARTYBILLNO"))
                        purchasedate.Value = Convert.ToDateTime(dr("BILLDATE"))
                        duedate.Value = Convert.ToDateTime(dr("DUEDATE"))
                       
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        gridbill.Rows.Add(dr("SRNO").ToString, dr("SERVICETYPE").ToString, dr("SERVICENAME").ToString, dr("PASSNAME").ToString, dr("REGNO").ToString, dr("DESC").ToString, dr("SALERATE").ToString, dr("CURRENCY").ToString, dr("CURAMT").ToString, dr("BILLAMT").ToString)
                        lbltotalamt.Text = Convert.ToString(dr("TOTALAMT"))
                        txtsubtotal.Text = Convert.ToString(dr("SUBTOTAL"))

                        cmbtax.Text = Convert.ToString(dr("TAXNAME"))
                        'lbltax.Text = Convert.ToString(dr("tax_tax"))
                        txttax.Text = Convert.ToString(dr("TAXAMT"))
                        TXTAMTPAID.Text = dr("AMTPAID")
                        TXTEXTRAAMT.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("RETURN")
                        TXTBAL.Text = dr("BALANCE")

                        If (Convert.ToString(dr("ADDTAXAMT")) < 0) Then
                            cmbaddsub.Text = "Sub."
                            txtotherchg.Text = Convert.ToString(dr("ADDTAXAMT") * -1)
                        Else
                            cmbaddsub.Text = "Add"
                            txtotherchg.Text = Convert.ToString(dr("ADDTAXAMT"))
                        End If

                        txtgtotal.Text = Convert.ToString(dr("GRANDTOTAL"))

                    Next

                    'CURRENCY GRID
                    Dim OBJCM2 As New ClsCommon
                    Dim dt2 As DataTable = OBJCM2.search("  PURCHASEINVOCIE_CURRENCY.BILL_CURSRNO AS SRNO, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CODE, ISNULL(PURCHASEINVOCIE_CURRENCY.BILL_CURAMT, 0) AS AMT", "", "  PURCHASEINVOCIE_CURRENCY INNER JOIN PURCHASEINVOICE ON PURCHASEINVOCIE_CURRENCY.BILL_no = PURCHASEINVOICE.BILL_NO AND PURCHASEINVOCIE_CURRENCY.BILL_REGISTERID = PURCHASEINVOICE.BILL_REGISTERID AND PURCHASEINVOCIE_CURRENCY.BILL_yearid = PURCHASEINVOICE.BILL_YEARID INNER JOIN REGISTERMASTER ON PURCHASEINVOICE.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEINVOICE.BILL_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN CURRENCYMASTER ON PURCHASEINVOCIE_CURRENCY.BILL_yearid = CURRENCYMASTER.cur_yearid AND PURCHASEINVOCIE_CURRENCY.BILL_CURCURRENCYID = CURRENCYMASTER.cur_id ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND PURCHASEINVOCIE_CURRENCY.BILL_NO = " & tempbillno & " AND PURCHASEINVOCIE_CURRENCY.BILL_YEARID = " & YearId & " ORDER BY PURCHASEINVOCIE_CURRENCY.BILL_CURSRNO")
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            GRIDCURRENCY.Rows.Add(DTR("SRNO"), DTR("CODE"), DTR("AMT"))
                        Next
                    End If

                    cmbregister.Enabled = False
                    cmbname.Focus()
                    chkchange.CheckState = CheckState.Checked
                    total()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(purchasedate.Value)

            alParaval.Add(txtpartybillno.Text.Trim)
            alParaval.Add(duedate.Value)
            alParaval.Add(CMBTOURNAME.Text.Trim)

            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(Val(lblamt.Text.Trim))
            alParaval.Add(txtsubtotal.Text.Trim)
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(txttax.Text.Trim)

            alParaval.Add(cmbaddsub.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(txtgtotal.Text.Trim))

            alParaval.Add(TXTAMTPAID.Text.Trim)
            alParaval.Add(TXTEXTRAAMT.Text.Trim)
            alParaval.Add(TXTRETURN.Text.Trim)
            alParaval.Add(TXTBAL.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim SERVICETYPE As String = ""
            Dim SERVICENAME As String = ""
            Dim PASSNAME As String = ""
            Dim REGNO As String = ""
            Dim DESC As String = ""
            Dim SALERATE As String = ""         'value of RATE
            Dim CURRNAME As String = ""
            Dim CURAMT As String = ""          'value of AMT
            Dim AMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridbill.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSrno.Index).Value.ToString
                        SERVICETYPE = row.Cells(GType.Index).Value.ToString
                        SERVICENAME = row.Cells(GName.Index).Value.ToString
                        PASSNAME = row.Cells(GPASSNAME.Index).Value.ToString
                        REGNO = row.Cells(GRegNo.Index).Value.ToString
                        DESC = row.Cells(GDesc.Index).Value.ToString
                        SALERATE = row.Cells(GRate.Index).Value
                        CURRNAME = row.Cells(GCurName.Index).Value.ToString
                        CURAMT = Val(row.Cells(GCurAmt.Index).Value)
                        AMT = Val(row.Cells(Gamount.Index).Value)
                      
                    Else

                        gridsrno = gridsrno & "|" & row.Cells(GSrno.Index).Value
                        SERVICETYPE = SERVICETYPE & "|" & row.Cells(GType.Index).Value
                        SERVICENAME = SERVICENAME & "|" & row.Cells(GName.Index).Value.ToString
                        PASSNAME = PASSNAME & "|" & row.Cells(GPASSNAME.Index).Value.ToString
                        REGNO = REGNO & "|" & row.Cells(GRegNo.Index).Value.ToString
                        DESC = DESC & "|" & row.Cells(GDesc.Index).Value.ToString
                        SALERATE = SALERATE & "|" & row.Cells(GRate.Index).Value
                        CURRNAME = CURRNAME & "|" & row.Cells(GCurName.Index).Value.ToString
                        CURAMT = CURAMT & "|" & Val(row.Cells(GCurAmt.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(Gamount.Index).Value)
                       

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(SERVICETYPE)
            alParaval.Add(SERVICENAME)
            alParaval.Add(PASSNAME)
            alParaval.Add(REGNO)
            alParaval.Add(DESC)
            alParaval.Add(SALERATE)
            alParaval.Add(CURRNAME)
            alParaval.Add(CURAMT)
            alParaval.Add(AMT)


            Dim CSRNO As String = ""
            Dim CCURRENCY As String = ""
            Dim CAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCURRENCY.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(GCURSRNO.Index).Value.ToString
                        CCURRENCY = row.Cells(GCURCURRENCY.Index).Value.ToString
                        CAMT = row.Cells(GCURRATE.Index).Value.ToString

                    Else
                        CSRNO = CSRNO & "|" & row.Cells(GCURSRNO.Index).Value.ToString
                        CCURRENCY = CCURRENCY & "|" & row.Cells(GCURCURRENCY.Index).Value.ToString
                        CAMT = CAMT & "|" & row.Cells(GCURRATE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCURRENCY)
            alParaval.Add(CAMT)

            Dim OBJINV As New ClsPurchaseInvoice
            OBJINV.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJINV.save()
                MessageBox.Show("Details Added")

                'If CHKTDS.CheckState = CheckState.Checked Then
                '    Dim OBJTDS As New DeductTDS
                '    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                '    OBJTDS.TXTTDSPER.Text = TDSPER
                '    OBJTDS.REGISTER = cmbregister.Text.Trim
                '    OBJTDS.ShowDialog()
                'End If


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempbillno)
                IntResult = OBJINV.update()
                MessageBox.Show("Details Updated")
                edit = False
            End If

            clear()
            purchasedate.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, "Select Vendor Name")
            bln = False
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If


        If gridbill.RowCount = 0 Then
            EP.SetError(txtamount, "Enter Item Details")
            bln = False
        End If

        If GRIDCURRENCY.RowCount = 0 Then
            EP.SetError(TXTCURRATE, "Enter Item Details")
            bln = False
        End If

        'If chkchange.CheckState = CheckState.Unchecked Then
        '    EP.SetError(txtamount, "Enter Item Details")
        '    bln = False
        'End If

        If txtpartybillno.Text.Trim.Length = 0 Then
            EP.SetError(txtpartybillno, "Enter Party Bill No.")
            bln = False
        End If


        If Not datecheck(purchasedate.Value) Then
            EP.SetError(purchasedate, "Date not in Current Year")
            bln = False
        End If

        If Not datecheck(duedate.Value) Then
            EP.SetError(duedate, "Date not in Current Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and groupmaster.group_SECONDARY = 'Sundry Creditors' and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID  = " & Locationid & " AND ACC_YEARID = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND (LEDGERS.ACC_TYPE = 'ACCOUNTs' OR LEDGERS.ACC_TYPE = 'TRANSPORT')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBACCCODE, e, Me, txtadd, " AND GROUPMASTER.group_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.Enter
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        'Try
        '    If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

        '    Dim clscommon As New ClsCommon
        '    Dim dt As DataTable
        '    dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
        '    If dt.Rows.Count > 0 Then
        '        cmbregister.Text = dt.Rows(0).Item(0).ToString
        '    End If
        '    getmax_BILLNO()

        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        'Try
        '    If cmbregister.Text.Trim.Length > 0 And edit = False Then
        '        'clear()
        '        cmbregister.Text = UCase(cmbregister.Text)
        '        Dim clscommon As New ClsCommon
        '        Dim dt As DataTable
        '        dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
        '        If dt.Rows.Count > 0 Then
        '            purregabbr = dt.Rows(0).Item(0).ToString
        '            purreginitial = dt.Rows(0).Item(1).ToString
        '            purregid = dt.Rows(0).Item(2)
        '            getmax_BILLNO()
        '            cmbregister.Enabled = False
        '        Else
        '            MsgBox("Register Not Present, Add New from Master Module")
        '            e.Cancel = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub total()

        LBLTOTALCURRENCY.Text = "0.00"
        lblamt.Text = "0.00"
        txtsubtotal.Clear()
        ' txttax.Clear()
        txtgtotal.Clear()

        For Each row As DataGridViewRow In gridbill.Rows
            lblamt.Text = Format(Val(lblamt.Text) + Val(row.Cells(Gamount.Index).Value), "0.00")
            LBLTOTALCURRENCY.Text = Format(Val(LBLTOTALCURRENCY.Text) + Val(row.Cells(GCurAmt.Index).Value), "0.00")
        Next


        txtsubtotal.Text = Format(Val(lblamt.Text), "0.00")

        If cmbtax.Text.Trim <> "" Then
            Dim objclscommon As New ClsCommonMaster
            Dim dt1 As DataTable = objclscommon.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt1.Rows.Count > 0 Then If Val(dt1.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt1.Rows(0).Item(1)) * Val(txtsubtotal.Text)) / 100, "0.00")
        End If

        If Val(lbltax.Text) <> 0 Then txttax.Text = Format((Val(txtsubtotal.Text) * Val(lbltax.Text)) / 100, "0.00")

        If cmbaddsub.Text = "Add" Then
            txtgtotal.Text = Format(Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtotherchg.Text), "0")
            'txtroundoff.Text = Format(Val(txtgtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(txtotherchg.Text)), "0.00")
        Else
            txtgtotal.Text = Format(Val(txtsubtotal.Text) + Val(txttax.Text) - Val(txtotherchg.Text), "0")
            'txtroundoff.Text = Format(Val(txtgtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) - Val(txtotherchg.Text)), "0.00")
        End If

        txtgtotal.Text = Format(Val(txtgtotal.Text), "0.00")

        If Val(txtgtotal.Text) <> 0 Then txtinwords.Text = CurrencyToWord(txtgtotal.Text)

    End Sub

    Sub fillgrid()
        If gridDoubleClick = False Then
            gridbill.Rows.Add(Val(txtsrno.Text.Trim), CMBSERVICETYPE.Text.Trim, CMBSERVICENAME.Text.Trim, CMBPASSNAME.Text.Trim, CMBREGNO.Text.Trim, TXTDESC.Text.Trim, Val(txtrate.Text.Trim), CMBCURRENCY.Text.Trim, Val(TXTCURAMT.Text.Trim), Val(txtamount.Text.Trim))
            getsrno(gridbill)
        ElseIf gridDoubleClick = True Then
            gridbill.Item(GSrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            gridbill.Item(GType.Index, temprow).Value = CMBSERVICETYPE.Text.Trim
            gridbill.Item(GName.Index, temprow).Value = CMBSERVICENAME.Text.Trim
            gridbill.Item(GPASSNAME.Index, temprow).Value = CMBPASSNAME.Text.Trim
            gridbill.Item(GRegNo.Index, temprow).Value = CMBREGNO.Text.Trim
            gridbill.Item(GDesc.Index, temprow).Value = TXTDESC.Text.Trim
            gridbill.Item(GRate.Index, temprow).Value = Format(Val(txtrate.Text.Trim), "0.00")
            gridbill.Item(GCurName.Index, temprow).Value = CMBCURRENCY.Text.Trim
            gridbill.Item(GCurAmt.Index, temprow).Value = Val(TXTCURAMT.Text.Trim)
            gridbill.Item(Gamount.Index, temprow).Value = Format(Val(txtamount.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        total()
        gridbill.FirstDisplayedScrollingRowIndex = gridbill.RowCount - 1

        CMBSERVICETYPE.Text = ""
        CMBSERVICENAME.Text = ""
        CMBPASSNAME.Text = ""
        CMBREGNO.Text = ""
        TXTDESC.Text = ""
        CMBCURRENCY.Text = ""
        TXTCURAMT.Clear()
        txtrate.Clear()
        txtamount.Clear()
        LBLTYPE.Text = ""

        If gridbill.RowCount > 0 Then
            txtsrno.Text = Val(gridbill.Rows(gridbill.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        CMBSERVICETYPE.Focus()

    End Sub

    Sub EDITROW()
        Try
            If GRIDBILL.CurrentRow.Index >= 0 And GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                txtsrno.Text = gridbill.Item(GSrno.Index, gridbill.CurrentRow.Index).Value.ToString
                CMBSERVICETYPE.Text = gridbill.Item(GType.Index, gridbill.CurrentRow.Index).Value.ToString
                CMBSERVICENAME.Text = gridbill.Item(GName.Index, gridbill.CurrentRow.Index).Value.ToString
                CMBPASSNAME.Text = gridbill.Item(GPASSNAME.Index, gridbill.CurrentRow.Index).Value.ToString
                CMBREGNO.Text = gridbill.Item(GRegNo.Index, gridbill.CurrentRow.Index).Value.ToString
                TXTDESC.Text = gridbill.Item(GDesc.Index, gridbill.CurrentRow.Index).Value.ToString
                txtrate.Text = gridbill.Item(GRate.Index, gridbill.CurrentRow.Index).Value.ToString
                CMBCURRENCY.Text = gridbill.Item(GCurName.Index, gridbill.CurrentRow.Index).Value.ToString
                TXTCURAMT.Text = gridbill.Item(GCurAmt.Index, gridbill.CurrentRow.Index).Value.ToString
                txtamount.Text = gridbill.Item(Gamount.Index, gridbill.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDBILL.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub gridbill_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridbill.CellValidating
        Dim colNum As Integer = gridbill.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GRate.Index, GCurAmt.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridbill.CurrentCell.Value = Nothing Then gridbill.CurrentCell.Value = "0.00"
                    gridbill.CurrentCell.Value = Convert.ToDecimal(gridbill.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
                'Case GPER.Index
                total()
        End Select
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridbill.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                gridbill.Rows.RemoveAt(gridbill.CurrentRow.Index)
                getsrno(gridbill)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcurgrid()
        If gridCurDoubleClick = False Then
            GRIDCURRENCY.Rows.Add(Val(TXTCURSRNO.Text.Trim), CMBCURCURRENCY.Text.Trim, Val(TXTCURRATE.Text.Trim))
            getsrno(GRIDCURRENCY)
        ElseIf gridCurDoubleClick = True Then
            GRIDCURRENCY.Item(GCURSRNO.Index, temprow).Value = Val(TXTCURSRNO.Text.Trim)
            GRIDCURRENCY.Item(GCURCURRENCY.Index, temprow).Value = CMBCURCURRENCY.Text.Trim
            GRIDCURRENCY.Item(GCURRATE.Index, temprow).Value = Val(TXTCURRATE.Text.Trim)
            gridCurDoubleClick = False
        End If

        GRIDCURRENCY.FirstDisplayedScrollingRowIndex = GRIDCURRENCY.RowCount - 1

        CMBCURCURRENCY.Text = ""
        TXTCURRATE.Clear()
        
        If GRIDCURRENCY.RowCount > 0 Then
            TXTCURSRNO.Text = Val(GRIDCURRENCY.Rows(GRIDCURRENCY.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCURSRNO.Text = 1
        End If
        TXTCURSRNO.Focus()

    End Sub

    Sub CUREDITROW()
        Try
            If GRIDCURRENCY.CurrentRow.Index >= 0 And GRIDCURRENCY.Item(GCURSRNO.Index, GRIDCURRENCY.CurrentRow.Index).Value <> Nothing Then
                gridCurDoubleClick = True
                TXTCURSRNO.Text = GRIDCURRENCY.Item(GCURSRNO.Index, GRIDCURRENCY.CurrentRow.Index).Value.ToString
                CMBCURCURRENCY.Text = GRIDCURRENCY.Item(GCURCURRENCY.Index, GRIDCURRENCY.CurrentRow.Index).Value.ToString
                TXTCURRATE.Text = GRIDCURRENCY.Item(GCURRATE.Index, GRIDCURRENCY.CurrentRow.Index).Value.ToString

                temprow = GRIDCURRENCY.CurrentRow.Index
                TXTCURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCURRENCY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCURRENCY.CellDoubleClick
        CUREDITROW()
    End Sub

    Private Sub GRIDCURRENCY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCURRENCY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCURRENCY.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridCurDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDCURRENCY.Rows.RemoveAt(GRIDCURRENCY.CurrentRow.Index)
                getsrno(GRIDCURRENCY)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCURRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCURRATE.KeyPress
        Try
            numdot(e, TXTCURRATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCURAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCURAMT.KeyPress
        Try
            numdot(e, TXTCURAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        Try
            numdot(e, txtotherchg, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridbill.RowCount = 0
LINE1:
            tempbillno = Val(txtbillno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If tempbillno > 0 Then
                edit = True
                PurchaseInvoice_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridbill.RowCount = 0 And tempbillno > 1 Then
                txtbillno.Text = tempbillno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridbill.RowCount = 0
LINE1:
            tempbillno = Val(txtbillno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmax_BILLNO()
            Dim MAXNO As Integer = txtbillno.Text.Trim
            clear()
            If Val(txtbillno.Text) - 1 >= tempbillno Then
                edit = True
                PurchaseInvoice_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridbill.RowCount = 0 And tempbillno < MAXNO Then
                txtbillno.Text = tempbillno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New PurchaseInvoiceDetail
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdsave_Click(sender, e)
    End Sub

    Private Sub CMBTOURNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOURNAME.Enter
        Try
            If CMBTOURNAME.Text.Trim = "" Then FILLTOURNAME(CMBTOURNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCURRENCY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCURCURRENCY.Enter
        Try
            If CMBCURCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCURRENCY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURCURRENCY.Validating
        Try
            If CMBCURCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURCURRENCY, e, Me)
            If CMBCURCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As Windows.Forms.DataGridViewRow In GRIDCURRENCY.Rows
                    If gridCurDoubleClick = False Then
                        If CMBCURCURRENCY.Text = row.Cells(GCURCURRENCY.Index).Value.ToString Then
                            MsgBox("This Currency already exists")
                            e.Cancel = True
                            CMBCURCURRENCY.Focus()
                        End If
                    Else
                        If CMBCURCURRENCY.Text = row.Cells(GCURCURRENCY.Index).Value.ToString And row.Index <> temprow Then
                            MsgBox("This Currency already exists")
                            e.Cancel = True
                            CMBCURCURRENCY.Focus()
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try

            If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" And CMBSERVICENAME.Text <> "" And CMBPASSNAME.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt1 As DataTable = objclscommon.search(" CURRENCYMASTER.CUR_CODE AS CURRENCY,ISNULL(REGISTRATIONMASTER.REG_PERSONTYPE,'') AS PERSONTYPE, (CASE WHEN REGISTRATIONMASTER.REG_PERSONTYPE='Adult' then (TOUR_SERVICES.TOUR_ADULT) else (case when REGISTRATIONMASTER.REG_PERSONTYPE='child' then (TOUR_SERVICES.TOUR_child) else (TOUR_SERVICES.TOUR_infant)end)end) AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID AND REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID LEFT OUTER JOIN CURRENCYMASTER ON TOUR_SERVICES.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_SERVICES.TOUR_CURRENCYID = CURRENCYMASTER.cur_id ", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and SERVICE_VIEW.NAME='" & CMBSERVICENAME.Text.Trim & "' AND GUESTMASTER.GUEST_NAME='" & CMBPASSNAME.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    CMBCURRENCY.Text = (dt1.Rows(0).Item("CURRENCY"))
                    TXTCURAMT.Text = Val(dt1.Rows(0).Item("AMT"))
                    LBLTYPE.Text = (dt1.Rows(0).Item("PERSONTYPE"))
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPASSNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPASSNAME.Enter
        REMOVENAME()
    End Sub

    Private Sub CMBPASSNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPASSNAME.Validating
        FILLREGNO()
        GETDATA()
    End Sub

    Private Sub TXTCURRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCURRATE.Validating
        If CMBCURCURRENCY.Text.Trim <> "" And Val(TXTCURRATE.Text.Trim) > 0 Then
            fillcurgrid()
            'total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Private Sub txtamount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamount.Validating
        If CMBPASSNAME.Text.Trim <> "" And CMBCURRENCY.Text.Trim <> "" And Val(TXTCURAMT.Text.Trim) > 0 And Val(txtamount.Text.Trim) > 0 And CMBREGNO.Text.Trim <> "" Then
            If CMBSERVICETYPE.Text = "" Then CMBSERVICENAME.Text = ""
            If CMBSERVICENAME.Text = "" Then CMBSERVICETYPE.Text = ""
            fillgrid()
            total()
            FILLPASSANGER()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Private Sub CMBCURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURRENCY.Validated
        Try
            If CMBCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBCURRENCY.Text = STRCODE Then
                        PRESENT = True
                        txtamount.Text = Val(TXTCURAMT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")
                    CMBCURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSERVICETYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSERVICETYPE.Validating
        Try
            CMBSERVICENAME.Text = ""
            If CMBSERVICETYPE.Text = "Lawazim" Then
                'If CMBSERVICENAME.Text.Trim = "" Then fillLAWAZIM(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    ' CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Visa" Then
                'If CMBSERVICENAME.Text.Trim = "" Then fillVISA(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '  CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Gift" Then
                '  If CMBSERVICENAME.Text.Trim = "" Then fillGIFT(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '  CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Transport" Then
                '   If CMBSERVICENAME.Text.Trim = "" Then fillTRANSPORT(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    ' CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Meals" Then
                '  If CMBSERVICENAME.Text.Trim = "" Then FILLPLAN(CMBSERVICENAME, edit)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '   CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "CountryTax" Then
                ' If CMBSERVICENAME.Text.Trim = "" Then FILLCOUNTRYTAX(CMBSERVICENAME, edit)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" SERVICE_VIEW.NAME as NAME, TOUR_SERVICES.TOUR_ADULTINR AS AMT ", "", " TOUR_SERVICES INNER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID INNER JOIN TOURMASTER ON TOUR_SERVICES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_SERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and SERVICE_VIEW.TYPE='" & CMBSERVICETYPE.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '  CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Flight" Then
                '     If CMBSERVICENAME.Text.Trim = "" Then FILLAIRLINE(CMBSERVICENAME, edit, "")
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" ISNULL(FLIGHTMASTER.FLIGHT_NAME, '') AS NAME, ISNULL(TOUR_FLIGHT.TOUR_ADULT, 0) AS AMT ", "", " TOURMASTER LEFT OUTER JOIN TOUR_FLIGHT ON TOURMASTER.TOUR_NO = TOUR_FLIGHT.TOUR_NO AND TOURMASTER.TOUR_YEARID = TOUR_FLIGHT.TOUR_yearid LEFT OUTER JOIN FLIGHTMASTER ON TOUR_FLIGHT.TOUR_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND TOUR_FLIGHT.TOUR_yearid = FLIGHTMASTER.FLIGHT_YEARID ", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '  CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Add. Service" Then
                '  If CMBSERVICENAME.Text.Trim = "" Then fillSERVICE(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" ISNULL(SERVICEMASTER.SERVICE_name, '') AS NAME, ISNULL(TOUR_ADDSERVICES.TOUR_ADULT, 0) AS AMT", "", " TOURMASTER LEFT OUTER JOIN TOUR_ADDSERVICES ON TOURMASTER.TOUR_NO = TOUR_ADDSERVICES.TOUR_NO AND TOURMASTER.TOUR_YEARID = TOUR_ADDSERVICES.TOUR_yearid LEFT OUTER JOIN SERVICEMASTER ON TOUR_ADDSERVICES.TOUR_ADDSERVICEID = SERVICEMASTER.SERVICE_id AND TOUR_ADDSERVICES.TOUR_yearid = SERVICEMASTER.SERVICE_yearid ", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '   CMBSERVICENAME.SelectAll()
                End If
            ElseIf CMBSERVICETYPE.Text = "Misc Exp" Then
                '   If CMBSERVICENAME.Text.Trim = "" Then fillMISCEXP(CMBSERVICENAME)
                If CMBTOURNAME.Text <> "" And CMBSERVICETYPE.Text <> "" Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscommon.search(" ISNULL(MISCEXPMASTER.MISC_name, '') AS NAME, ISNULL(TOUR_EXPENSES.TOUR_ADULT, 0) AS AMT ", "", " MISCEXPMASTER RIGHT OUTER JOIN TOUR_EXPENSES ON MISCEXPMASTER.MISC_yearid = TOUR_EXPENSES.TOUR_yearid AND MISCEXPMASTER.MISC_id = TOUR_EXPENSES.TOUR_MISCEXPID RIGHT OUTER JOIN TOURMASTER ON TOUR_EXPENSES.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_EXPENSES.TOUR_yearid = TOURMASTER.TOUR_YEARID ", " and TOURMASTER.TOUR_NAME = '" & CMBTOURNAME.Text.Trim & "' and TOURMASTER.TOUR_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        dt1.DefaultView.Sort = "NAME"
                        CMBSERVICENAME.DataSource = dt1
                        CMBSERVICENAME.DisplayMember = "NAME"
                        CMBSERVICENAME.Text = ""
                    End If
                    '    CMBSERVICENAME.SelectAll()
                End If
            Else
                CMBSERVICENAME.DataSource = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSERVICENAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSERVICENAME.Validating
        Try

            If CMBSERVICETYPE.Text = "Lawazim" Then
                If CMBSERVICENAME.Text.Trim <> "" Then LAWAZIMVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Visa" Then
                If CMBSERVICENAME.Text.Trim <> "" Then VISAVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Gift" Then
                If CMBSERVICENAME.Text.Trim <> "" Then GIFTVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Transport" Then
                If CMBSERVICENAME.Text.Trim <> "" Then TRANSPORTVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Meals" Then
                If CMBSERVICENAME.Text.Trim <> "" Then MEALPLANVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "CountryTax" Then
                If CMBSERVICENAME.Text.Trim <> "" Then COUNTRYTAXVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Flight" Then
                If CMBSERVICENAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBSERVICENAME, CMBCODE, e, Me, "", 0, 0)
            ElseIf CMBSERVICETYPE.Text = "Add. Service" Then
                If CMBSERVICENAME.Text.Trim <> "" Then ADDSERVICEVALIDATE(CMBSERVICENAME, e, Me)
            ElseIf CMBSERVICETYPE.Text = "Misc Exp" Then
                If CMBSERVICENAME.Text.Trim <> "" Then MISCVALIDATE(CMBSERVICENAME, e, Me)
            End If

            'If CMBSERVICETYPE.Text.Trim <> "" And CMBSERVICENAME.Text.Trim <> "" And gridbill.RowCount > 0 Then
            '    For Each row As Windows.Forms.DataGridViewRow In gridbill.Rows
            '        If gridDoubleClick = False Then
            '            If CMBSERVICETYPE.Text = row.Cells(GType.Index).Value.ToString And CMBSERVICENAME.Text = row.Cells(GName.Index).Value.ToString Then
            '                MsgBox("This Service Type and Service Name already exists")
            '                e.Cancel = True
            '                CMBSERVICETYPE.Focus()
            '            End If
            '        Else
            '            If CMBSERVICETYPE.Text = row.Cells(GType.Index).Value.ToString And CMBSERVICENAME.Text = row.Cells(GName.Index).Value.ToString And row.Index <> temprow Then
            '                MsgBox("This class and type already exists")
            '                e.Cancel = True
            '                CMBSERVICENAME.Focus()
            '            End If
            '        End If
            '    Next
            'End If
            GETDATA()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPASSANGER()
        Try
            If CMBTOURNAME.Text <> "" Then
                CMBPASSNAME.Items.Clear()
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("  GUEST_NAME AS GUESTNAME", "", " TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID ", " AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' and GUEST_YEARID = " & YearId)
                For Each DTROW As DataRow In dt.Rows
                    CMBPASSNAME.Items.Add(DTROW("GUESTNAME"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLREGNO()
        Try
            If CMBPASSNAME.Text <> "" Then
                CMBREGNO.Items.Clear()
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT REG_INITIALS AS REGNO", "", " REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID  ", " AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' AND GUESTMASTER.GUEST_NAME='" & CMBPASSNAME.Text.Trim & "' and REGISTRATIONMASTER.REG_YEARID  = " & YearId)
                For Each DTROW As DataRow In dt.Rows
                    CMBREGNO.Items.Add(DTROW("REGNO"))
                    CMBREGNO.SelectedIndex = 0
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCURAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCURAMT.Validating
        Try
            CMBCURRENCY_Validated(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaddsub_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbaddsub.Validating
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtotherchg.Validating
        total()
    End Sub

    Private Sub PurchaseInvoice_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "FINASTA" Then Me.Close()
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txttax.ReadOnly = False
                    Else
                        txttax.ReadOnly = True
                    End If
                End If
            Else
                txttax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttax.Validating
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttax.KeyPress
        Try
            numdot(e, txttax, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOURNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOURNAME.Validating
        FILLPASSANGER()
    End Sub

    Sub REMOVENAME()
        Try
            FILLPASSANGER()
            'If CMBSERVICETYPE.Text.Trim <> "" And CMBSERVICENAME.Text.Trim <> "" Then
            'REMOVE PASSENDER FROM CMB WITH THIS SERV NAME AND TYPE
            For Each ROW As DataGridViewRow In gridbill.Rows
                If ROW.Cells(GType.Index).Value = CMBSERVICETYPE.Text.Trim And ROW.Cells(GName.Index).Value = CMBSERVICENAME.Text.Trim Then
                    CMBPASSNAME.Items.RemoveAt(CMBPASSNAME.Items.IndexOf(ROW.Cells(GPASSNAME.Index).Value))
                End If
            Next
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSERVICENAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSERVICENAME.Validated
        REMOVENAME()
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Purchase Invoice Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJPUR As New ClsPurchaseInvoice
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(tempbillno)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJPUR.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJPUR.DELETE()
                    MsgBox("Purchase Invoice Deleted!")

                    clear()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class