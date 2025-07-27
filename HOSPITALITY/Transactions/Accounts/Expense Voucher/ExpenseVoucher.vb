
Imports BL
Imports System.Windows.Forms

Public Class ExpenseVoucher

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPEXPNO As Integer     'used for non purchase no while editing
    Dim temprow As Integer
    Public partyref As String      'used for refno while edit mode
    Dim PURregid As Integer
    Dim PURregabbr, PURreginitial As String
    Public TEMPREGNAME As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        gridGRN.Enabled = True
        EP.Clear()
        npdate.Value = Mydate
        partybilldate.Value = Mydate

        CHKRCM.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked

        TXTTOTALOTHERAMT.Text = 0
        TXTTOTALTAXABLEAMT.Text = 0
        TXTTOTALCGSTAMT.Text = 0
        TXTTOTALSGSTAMT.Text = 0
        TXTTOTALIGSTAMT.Text = 0
        TXTTOTALBILLAMT.Text = 0

        lbltotalamt.Text = 0
        lbltotalqty.Text = 0
        cmbtax.Text = ""
        txttax.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        cmbname.Text = ""
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()

        TXTADD.Clear()
        txtrefno.Clear()
        TXTNP.Clear()
        cmbdrname.Text = ""
        CMBHSNCODE.Text = ""

        txtnote.Clear()
        TXTQTY.Clear()
        TXTRATE.Clear()
        txtamt.Clear()

        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        txtremarks.Clear()
        gridGRN.RowCount = 0
        partyref = ""
        TXTBAL.Clear()
        TXTAMTREC.Clear()
        TXTRETURN.Clear()
        TXTTDS.Clear()


        getmaxno()
        gridDoubleClick = False

        If gridGRN.RowCount > 0 Then
            txtsrno.Text = Val(gridGRN.Rows(gridGRN.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        CMDSHOWDETAILS.Visible = False
        PBTDS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        PBPAID.Visible = False

    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        If cmbregister.Text <> "" Then
            If FRMSTRING = "NONPURCHASE" Then
                DTTABLE = getmax(" isnull(max(NP_NO),0) + 1 ", "  NONPURCHASE left outer JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID AND REGISTER_CMPID = NP_CMPID AND REGISTER_LOCATIONID = NP_LOCATIONID AND REGISTER_YEARID = NP_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'EXPENSE' AND NP_cmpid=" & CmpId & " AND NONPURCHASE.NP_LOCATIONID = " & Locationid & " AND NP_YEARID = " & YearId)
            Else
                DTTABLE = getmax(" isnull(max(NONINV_NO),0) + 1 ", "  NONINVPURCHASE left outer JOIN REGISTERMASTER ON REGISTER_ID = NONINV_REGISTERID AND REGISTER_CMPID = NONINV_CMPID AND REGISTER_LOCATIONID = NONINV_LOCATIONID AND REGISTER_YEARID = NONINV_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND NONINV_cmpid=" & CmpId & " AND NONINV_LOCATIONID = " & Locationid & " AND NONINV_YEARID = " & YearId)
            End If
            If DTTABLE.Rows.Count > 0 Then
                TXTNP.Text = DTTABLE.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub NonPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
            'ElseIf e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.F2 Then
            tstxtbillno.Focus()
        ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
            Call toolprevious_Click(sender, e)
        ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
            Call toolnext_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Dim OBJINVDTLS As New ExpenseVoucherDetails
            OBJINVDTLS.MdiParent = MDIMain
            OBJINVDTLS.Show()
            'ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            '    Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub NonPurchase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub NonPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'VOUCHER ENTRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor
            clear()
            If FRMSTRING = "NONPURCHASE" Then
                fillregister(cmbregister, " and register_type = 'EXPENSE'")
            Else
                fillregister(cmbregister, " and register_type = 'PURCHASE'")
            End If
            'fillregister(cmbregister, " and register_type = 'EXPENSE'")

            If cmbregister.Items.Count > 0 Then cmbregister.SelectedIndex = (0)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, "")
            'If cmbdrname.Text.Trim = "" Then fillledger(cmbdrname, edit, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
            If cmbdrname.Text.Trim = "" Then fillledger(cmbdrname, edit, "")
            filltax(cmbtax, edit)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPEXPNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                If FRMSTRING = "NONPURCHASE" Then

                    Dim objclsNP As New ClsExpenseVoucher
                    objclsNP.alParaval = ALPARAVAL
                    dt = objclsNP.selectNONpurchase()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            TXTNP.Text = TEMPEXPNO
                            cmbregister.Text = Convert.ToString(dr("REGNAME"))
                            cmbname.Text = Convert.ToString(dr("NAME"))
                            TXTSTATECODE.Text = dr("STATECODE")
                            TXTGSTIN.Text = dr("GSTIN")

                            npdate.Value = dr("DATE")
                            txtrefno.Text = dr("REFNO")
                            partyref = txtrefno.Text.Trim
                            partybilldate.Value = dr("PARTYBILLDATE")

                            CHKRCM.Checked = Convert.ToBoolean(dr("RCM"))
                            CHKMANUAL.Checked = Convert.ToBoolean(dr("MANUALGST"))

                            txtremarks.Text = Convert.ToString(dr("Remarks"))
                            TXTAMTREC.Text = Val(dr("AMTPAID"))
                            TXTTDS.Text = Val(dr("EXTRAAMT"))
                            TXTRETURN.Text = Val(dr("BILLRETURN"))
                            TXTBAL.Text = Val(dr("BALANCE"))
                            cmbtax.Text = dr("TAXNAME")
                            txttax.Text = dr("TAXAMT")

                            gridGRN.Rows.Add(dr("gridsrno").ToString, dr("DRNAME").ToString, dr("HSNCODE"), dr("NOTE").ToString, dr("qty").ToString, dr("rate").ToString, dr("amt").ToString, Val(dr("OTHERAMT")), Val(dr("TAXABLEAMT")), Val(dr("CGSTPER")), Val(dr("CGSTAMT")), Val(dr("SGSTPER")), Val(dr("SGSTAMT")), Val(dr("IGSTPER")), Val(dr("IGSTAMT")), Val(dr("GRIDTOTAL")))

                            'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                            Dim OBJCMNTDS As New ClsCommon
                            Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(JOURNALMASTER.journal_credit,0) AS TDS", "", " JOURNALMASTER INNER JOIN NONPURCHASE ON JOURNALMASTER.journal_refno = NONPURCHASE.NP_INITIALS AND  JOURNALMASTER.journal_yearid = NONPURCHASE.NP_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON NONPURCHASE.NP_REGISTERID = REGISTERMASTER.register_id ", "AND (LEDGERS.ACC_TDSAC = 'True') AND NP_NO = " & TEMPEXPNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND NP_YEARID = " & YearId)
                            If DTTDS.Rows.Count > 0 Then
                                If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                                    CMDSHOWDETAILS.Visible = True
                                    PBTDS.Visible = True
                                    lbllocked.Visible = True
                                    PBlock.Visible = True
                                    cmbname.Enabled = False
                                End If
                            End If

                            If PBTDS.Visible = False Then
                                If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                                    CMDSHOWDETAILS.Visible = True
                                    PBPAID.Visible = True
                                    lbllocked.Visible = True
                                    PBlock.Visible = True
                                End If
                            End If

                            If Val(dr("BILLRETURN")) > 0 Then
                                CMDSHOWDETAILS.Visible = True
                                PBDN.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If

                        Next

                    End If

                ElseIf FRMSTRING = "PURCHASE" Then

                    Dim objclsNP As New ClsExpenseVoucher
                    objclsNP.alParaval = ALPARAVAL
                    dt = objclsNP.selectNONpurchase()

                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            TXTNP.Text = TEMPEXPNO
                            cmbregister.Text = Convert.ToString(dr("register_name"))
                            cmbname.Text = Convert.ToString(dr("vendorname"))
                            npdate.Value = dr("NP_DATE")
                            txtrefno.Text = dr("NP_REFNO")
                            partyref = txtrefno.Text.Trim
                            partybilldate.Value = dr("NP_PARTYBILLDATE")
                            txtremarks.Text = Convert.ToString(dr("NP_Remarks"))
                            TXTAMTREC.Text = dr("NP_AMTPAID")
                            TXTTDS.Text = dr("NP_TDS")
                            TXTBAL.Text = dr("NP_BALANCE")
                            cmbtax.Text = dr("TAXNAME")
                            txttax.Text = dr("TAXAMT")
                            If Val(dr("NP_gridsrno").ToString) <> 0 Then
                                gridGRN.Rows.Add(dr("NP_gridsrno").ToString, dr("DRNAME").ToString, dr("NP_NOTE").ToString, dr("NP_qty").ToString, dr("NP_rate").ToString, dr("NP_amt").ToString)
                            End If
                        Next

                    End If

                End If

                cmbregister.Enabled = False
                cmbname.Focus()
                chkchange.CheckState = CheckState.Checked
                total()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim IntResult As Integer

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If Not VALIDATEREFNO() Then
                EP.SetError(txtrefno, "Party Ref. Already Exists")
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(npdate.Value)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(partybilldate.Value)

            If CHKRCM.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            If CHKMANUAL.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(Val(lbltotalamt.Text))

            alParaval.Add(Val(TXTTOTALOTHERAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALTAXABLEAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTTOTALBILLAMT.Text))

            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text))
            alParaval.Add(Val(txtroundoff.Text))
            alParaval.Add(Val(txtgrandtotal.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTTDS.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim drname As String = ""
            Dim HSNCODE As String = ""

            Dim note As String = ""
            Dim qty As String = ""
            Dim rate As String = ""
            Dim amount As String = ""

            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridGRN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(srno.Index).Value)
                        drname = row.Cells(gridname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString

                        note = row.Cells(gremarks.Index).Value.ToString
                        qty = Val(row.Cells(GQTY.Index).Value.ToString)
                        rate = Val(row.Cells(GRATE.Index).Value.ToString)
                        amount = Val(row.Cells(gAMT.Index).Value.ToString)
                        OTHERAMT = Val(row.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = Val(row.Cells(GGRIDTOTAL.Index).Value)
                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(srno.Index).Value)
                        drname = drname & "|" & row.Cells(gridname.Index).Value.ToString
                        note = note & "|" & row.Cells(gremarks.Index).Value.ToString
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(GQTY.Index).Value.ToString)
                        rate = rate & "|" & Val(row.Cells(GRATE.Index).Value.ToString)
                        amount = amount & "|" & Val(row.Cells(gAMT.Index).Value.ToString)
                        OTHERAMT = OTHERAMT & "|" & Val(row.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = TAXABLEAMT & "|" & Val(row.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & Val(row.Cells(GCGSTPER.Index).Value)
                        CGSTAMT = CGSTAMT & "|" & Val(row.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & Val(row.Cells(GSGSTPER.Index).Value)
                        SGSTAMT = SGSTAMT & "|" & Val(row.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & Val(row.Cells(GIGSTPER.Index).Value)
                        IGSTAMT = IGSTAMT & "|" & Val(row.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(row.Cells(GGRIDTOTAL.Index).Value)
                    End If
                End If
            Next



            alParaval.Add(gridsrno)
            alParaval.Add(drname)
            alParaval.Add(HSNCODE)

            alParaval.Add(note)
            alParaval.Add(qty)
            alParaval.Add(rate)
            alParaval.Add(amount)

            alParaval.Add(OTHERAMT)
            alParaval.Add(TAXABLEAMT)
            alParaval.Add(CGSTPER)
            alParaval.Add(CGSTAMT)
            alParaval.Add(SGSTPER)
            alParaval.Add(SGSTAMT)
            alParaval.Add(IGSTPER)
            alParaval.Add(IGSTAMT)
            alParaval.Add(GRIDTOTAL)

            Dim objclsNP As New ClsExpenseVoucher
            objclsNP.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsNP.SAVE()
                MsgBox("Details Added")
            ElseIf edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPEXPNO)
                IntResult = objclsNP.UPDATE()
                MsgBox("Details Updated")
            End If
            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            'TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()


            If CMBHSNCODE.Text.Trim <> "" And Convert.ToDateTime(NPDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    'TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If


                End If
                total()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If Not datecheck(npdate.Value) Then
                EP.SetError(npdate, "Date Not in Current Accounting Year")
                bln = False
            End If

            If cmbregister.Text.Trim.Length = 0 Then
                EP.SetError(cmbregister, "Enter Register Name")
                bln = False
            End If

            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If


            If txtrefno.Text.Trim.Length = 0 Then
                EP.SetError(txtrefno, "Please Fill Party Bill No.")
                bln = False
            End If

            If gridGRN.RowCount = 0 Then
                EP.SetError(txtamt, "Please Fill Proper Entries")
                bln = False
            End If

            If ClientName = "CLASSIC" Then
                If UserName <> "Admin" And edit = False Then
                    If npdate.Value.Date < Now.Date Then
                        EP.SetError(npdate, "Back Date Entry Not Allowed")
                        bln = False
                    End If
                End If
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Rec/Pay/TDS Made, Delete Rec/Pay/TDS First")
                bln = False
            End If

            If Not datecheck(npdate.Value) Then
                EP.SetError(npdate, "Date Not in Current Accounting Year")
                bln = False
            End If


            If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(TXTTOTALCGSTAMT.Text) > 0 Or Val(TXTTOTALSGSTAMT.Text.Trim) > 0) Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                bln = False
            End If

            If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(TXTTOTALIGSTAMT.Text) > 0 Then
                EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            'If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub total()

        lbltotalqty.Text = 0.0
        lbltotalamt.Text = 0.0

        TXTTOTALOTHERAMT.Text = 0.0
        TXTTOTALTAXABLEAMT.Text = 0.0
        TXTTOTALCGSTAMT.Text = "0.0"
        TXTTOTALSGSTAMT.Text = "0.0"
        TXTTOTALIGSTAMT.Text = "0.0"

        TXTTOTALBILLAMT.Text = 0.0

        txttax.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0

        If gridGRN.RowCount > 0 Then
            For Each row As DataGridViewRow In gridGRN.Rows
                'lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(3).Value), "0.00")
                'lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(5).Value), "0.00")

                If Val(row.Cells(GQTY.Index).Value) <> 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(gAMT.Index).Value) <> 0 Then lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(gAMT.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GOTHERAMT.Index).Value) <> 0 Then TXTTOTALOTHERAMT.Text = Format(Val(TXTTOTALOTHERAMT.Text) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GTAXABLEAMT.Index).Value) <> 0 Then TXTTOTALTAXABLEAMT.Text = Format(Val(TXTTOTALTAXABLEAMT.Text) + Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GCGSTAMT.Index).Value) <> 0 Then TXTTOTALCGSTAMT.Text = Format(Val(TXTTOTALCGSTAMT.Text) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GSGSTAMT.Index).Value) <> 0 Then TXTTOTALSGSTAMT.Text = Format(Val(TXTTOTALSGSTAMT.Text) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GIGSTAMT.Index).Value) <> 0 Then TXTTOTALIGSTAMT.Text = Format(Val(TXTTOTALIGSTAMT.Text) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GGRIDTOTAL.Index).Value) <> 0 Then TXTTOTALBILLAMT.Text = Format(Val(TXTTOTALBILLAMT.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

            Next

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                txttax.Text = Format(Val(Val(dt.Rows(0).Item(1)) * Val(lbltotalamt.Text)) / 100, "0.00")
            End If

            'txtgrandtotal.Text = Format(Val(lbltotalamt.Text) + Val(txttax.Text), "0")

            'txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(lbltotalamt.Text) + Val(txttax.Text)), "0.00")
            'txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text) + Val(TXTTOTALBILLAMT.Text) + Val(txttax.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - Val(TXTTOTALBILLAMT.Text) + Val(txttax.Text), "0.00")
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

        End If

    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridGRN.RowCount = 0
LINE1:
            TEMPEXPNO = Val(TXTNP.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPEXPNO > 0 Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridGRN.RowCount = 0 And TEMPEXPNO > 1 Then
                TXTNP.Text = TEMPEXPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridGRN.RowCount = 0
LINE1:
            TEMPEXPNO = Val(TXTNP.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno()
            Dim MAXNO As Integer = TXTNP.Text.Trim
            clear()
            If Val(TXTNP.Text) - 1 >= TEMPEXPNO Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridGRN.RowCount = 0 And TEMPEXPNO < MAXNO Then
                TXTNP.Text = TEMPEXPNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objNPdetails As New ExpenseVoucherDetails
            objNPdetails.MdiParent = MDIMain
            objNPdetails.Show()
            ' Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            'If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub npdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles npdate.Validating
        'If Not datecheck(npdate.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'EXPENSE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'EXPENSE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURregabbr = dt.Rows(0).Item(0).ToString
                    PURreginitial = dt.Rows(0).Item(1).ToString
                    PURregid = dt.Rows(0).Item(2)
                    getmaxno()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdrname.GotFocus
        Try
            If cmbdrname.Text.Trim = "" Then fillledger(cmbdrname, edit, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdrname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbdrname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbdrname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdrname.Validating
        Try
            If cmbdrname.Text.Trim <> "" Then namevalidate(cmbdrname, CMBDRCODE, e, Me, TXTADD, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        If Val(TXTQTY.Text) > 0 And Val(TXTRATE.Text) > 0 Then
            txtamt.Text = Val(TXTQTY.Text) * Val(TXTRATE.Text)
        End If
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try
            If txtrefno.Text.Trim.Length > 0 Then
                If VALIDATEREFNO() = False Then
                    MsgBox("Party Ref. Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function VALIDATEREFNO() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(partyref) <> txtrefno.Text.Trim) Then
                'for search
                Dim objclscommon As New ClsCommon()
                Dim dt As New DataTable
                dt = objclscommon.search(" NONPURCHASE.NP_refno, LEDGERS.ACC_cmpname", "", " dbo.NONPURCHASE INNER JOIN dbo.LEDGERS ON dbo.LEDGERS.ACC_id = dbo.NONPURCHASE.NP_ledgerid AND dbo.NONPURCHASE.NP_cmpid = dbo.LEDGERS.ACC_cmpid AND dbo.NONPURCHASE.NP_locationid = dbo.LEDGERS.ACC_locationid AND dbo.NONPURCHASE.NP_yearid = dbo.LEDGERS.ACC_yearid ", " and NONPURCHASE.NP_refno = '" & txtrefno.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' and dbo.NONPURCHASE.NP_cmpid=" & CmpId & " and dbo.NONPURCHASE.NP_locationid=" & Locationid & " and dbo.NONPURCHASE.NP_yearid=" & YearId)
                If dt.Rows.Count > 0 Then BLN = False
            End If
            Return BLN
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridGRN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridGRN.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If temprow = gridGRN.CurrentRow.Index And gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridGRN.Rows.RemoveAt(gridGRN.CurrentRow.Index)
                total()
                getsrno(gridGRN)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtamount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamt.Validating
        'Try
        '    If cmbdrname.Text.Trim <> "" And Val(txtamt.Text.Trim) <> 0 And txtsrno.Text.Trim > 0 Then
        '        fillgrid()
        '        total()
        '    Else
        '        MsgBox("Fill Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Sub fillgrid()

        gridGRN.Enabled = True
        If gridDoubleClick = False Then
            gridGRN.Rows.Add(Val(txtsrno.Text.Trim), cmbdrname.Text.Trim, CMBHSNCODE.Text.Trim, txtnote.Text.Trim, Val(TXTQTY.Text.Trim), Val(TXTRATE.Text.Trim), Val(txtamt.Text.Trim), Val(TXTOTHERAMT.Text.Trim), Val(TXTTAXABLEAMT.Text.Trim), Val(TXTCGSTPER.Text.Trim), Val(TXTCGSTAMT.Text.Trim), Val(TXTSGSTPER.Text.Trim), Val(TXTSGSTAMT.Text.Trim), Val(TXTIGSTPER.Text.Trim), Val(TXTIGSTAMT.Text.Trim), Val(TXTGRIDTOTAL.Text.Trim))
            getsrno(gridGRN)
        ElseIf gridDoubleClick = True Then

            gridGRN.Item(srno.Index, temprow).Value = txtsrno.Text.Trim
            gridGRN.Item(gridname.Index, temprow).Value = cmbdrname.Text.Trim
            gridGRN.Item(GHSNCODE.Index, temprow).Value = CMBHSNCODE.Text.Trim
            gridGRN.Item(gremarks.Index, temprow).Value = txtnote.Text.Trim
            gridGRN.Item(GQTY.Index, temprow).Value = Val(TXTQTY.Text.Trim)
            gridGRN.Item(GRATE.Index, temprow).Value = Val(TXTRATE.Text.Trim)
            gridGRN.Item(gAMT.Index, temprow).Value = Val(txtamt.Text.Trim)

            gridGRN.Item(GOTHERAMT.Index, temprow).Value = Val(TXTOTHERAMT.Text.Trim)
            gridGRN.Item(GTAXABLEAMT.Index, temprow).Value = Val(TXTTAXABLEAMT.Text.Trim)
            gridGRN.Item(GCGSTPER.Index, temprow).Value = Val(TXTCGSTPER.Text.Trim)
            gridGRN.Item(GCGSTAMT.Index, temprow).Value = Val(TXTCGSTAMT.Text.Trim)
            gridGRN.Item(GSGSTPER.Index, temprow).Value = Val(TXTSGSTPER.Text.Trim)
            gridGRN.Item(GSGSTAMT.Index, temprow).Value = Val(TXTSGSTAMT.Text.Trim)
            gridGRN.Item(GIGSTPER.Index, temprow).Value = Val(TXTIGSTPER.Text.Trim)
            gridGRN.Item(GIGSTAMT.Index, temprow).Value = Val(TXTIGSTAMT.Text.Trim)
            gridGRN.Item(GGRIDTOTAL.Index, temprow).Value = Val(TXTGRIDTOTAL.Text.Trim)

            gridDoubleClick = False

        End If
        gridGRN.FirstDisplayedScrollingRowIndex = gridGRN.RowCount - 1

        txtsrno.Clear()
        cmbdrname.Text = ""
        CMBHSNCODE.Text = ""

        txtnote.Text = ""
        TXTQTY.Clear()
        TXTRATE.Clear()
        txtamt.Clear()
        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridGRN.CellDoubleClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridGRN.Item(0, e.RowIndex).Value <> Nothing Then

            gridDoubleClick = True
            txtsrno.Text = gridGRN.Item(srno.Index, e.RowIndex).Value
            cmbdrname.Text = gridGRN.Item(gridname.Index, e.RowIndex).Value
            CMBHSNCODE.Text = gridGRN.Item(GHSNCODE.Index, e.RowIndex).Value.ToString
            txtnote.Text = gridGRN.Item(gremarks.Index, e.RowIndex).Value.ToString

            TXTQTY.Text = Val(gridGRN.Item(GQTY.Index, e.RowIndex).Value)
            TXTRATE.Text = Val(gridGRN.Item(GRATE.Index, e.RowIndex).Value)
            txtamt.Text = Val(gridGRN.Item(gAMT.Index, e.RowIndex).Value)
            TXTOTHERAMT.Text = Val(gridGRN.Item(GOTHERAMT.Index, e.RowIndex).Value)
            TXTTAXABLEAMT.Text = Val(gridGRN.Item(GTAXABLEAMT.Index, e.RowIndex).Value)
            TXTCGSTPER.Text = Val(gridGRN.Item(GCGSTPER.Index, e.RowIndex).Value)
            TXTCGSTAMT.Text = Val(gridGRN.Item(GCGSTAMT.Index, e.RowIndex).Value)
            TXTSGSTPER.Text = Val(gridGRN.Item(GSGSTPER.Index, e.RowIndex).Value)
            TXTSGSTAMT.Text = Val(gridGRN.Item(GSGSTAMT.Index, e.RowIndex).Value)
            TXTIGSTPER.Text = Val(gridGRN.Item(GIGSTPER.Index, e.RowIndex).Value)
            TXTIGSTAMT.Text = Val(gridGRN.Item(GIGSTAMT.Index, e.RowIndex).Value)
            TXTGRIDTOTAL.Text = Val(gridGRN.Item(GGRIDTOTAL.Index, e.RowIndex).Value)

            temprow = e.RowIndex
            txtsrno.Focus()

        End If
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridGRN.RowCount > 0 Then
                txtsrno.Text = Val(gridGRN.Rows(gridGRN.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridGRN.RowCount = 0
            TEMPEXPNO = Val(tstxtbillno.Text)
            If TEMPEXPNO > 0 Then
                edit = True
                NonPurchase_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub partybilldate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles partybilldate.Validating
        If Not datecheck(partybilldate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Contra Entry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJNONPURCHASE As New ClsExpenseVoucher
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPEXPNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJNONPURCHASE.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJNONPURCHASE.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExpenseVoucher_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Then Me.Close()
        If ClientName = "GLOBAL" Then
            LBLTOTALCGST.Visible = False
            TXTTOTALCGSTAMT.Visible = False
            LBLTOTALSGST.Visible = False
            TXTTOTALSGSTAMT.Visible = False
            LBLTOTALIGST.Visible = False
            TXTTOTALIGSTAMT.Visible = False
            LBLGSTIN.Visible = False
            TXTGSTIN.Visible = False
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False
            CHKMANUAL.Visible = False

            'For grid parameter
            CMBHSNCODE.Visible = False
            GHSNCODE.Visible = False
            GCGSTPER.Visible = False
            TXTCGSTPER.Visible = False
            GCGSTAMT.Visible = False
            TXTCGSTAMT.Visible = False
            GSGSTPER.Visible = False
            TXTSGSTPER.Visible = False
            GSGSTAMT.Visible = False
            TXTSGSTAMT.Visible = False
            GIGSTAMT.Visible = False
            GIGSTPER.Visible = False
            TXTIGSTPER.Visible = False
            TXTIGSTAMT.Visible = False

            TXTQTY.Left = CMBHSNCODE.Left
            TXTRATE.Left = TXTQTY.Left + TXTQTY.Width
            txtamt.Left = TXTRATE.Left + TXTRATE.Width
            TXTOTHERAMT.Left = txtamt.Left + txtamt.Width
            TXTTAXABLEAMT.Left = TXTOTHERAMT.Left + TXTOTHERAMT.Width
            TXTGRIDTOTAL.Left = TXTTAXABLEAMT.Left + TXTTAXABLEAMT.Width



        End If
    End Sub

    Private Sub TXTOTHERAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERAMT.KeyPress
        AMOUNTNUMDOTKYEPRESS(e, sender, Me)
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated, TXTQTY.Validated, TXTRATE.Validated, txtamt.Validated, TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURreginitial & "-" & TEMPEXPNO
            OBJRECPAY.SALEBILLINITIALS = PURreginitial & "-" & TEMPEXPNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTGRIDTOTAL.Text = 0.0
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTQTY.Text.Trim) > 0 Then txtamt.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE.Text), "0.00")

            If CHKRCM.CheckState = CheckState.Checked Then TXTTAXABLEAMT.Text = Format((Val(txtamt.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0") Else TXTTAXABLEAMT.Text = Format((Val(txtamt.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            End If
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            Dim OBJCMN As New ClsCommon
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id  ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")

                    'If DT.Rows(0).Item("REGISTERNAME") <> CMBREGISTER.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
                    '    Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
                    '    If TEMPMSG = vbYes Then
                    '        CMBREGISTER.Text = DT.Rows(0).Item("REGISTERNAME")
                    '        getmaxno()
                    '    End If
                    'End If
                    total()
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDTOTAL.Validating
        Try
            If CMBDRNAME.Text.Trim <> "" And Val(TXTAMT.Text.Trim) <> 0 And TXTSRNO.Text.Trim > 0 Then
                fillgrid()
                total()
            Else
                MsgBox("Fill Proper Details", MsgBoxStyle.Critical, "HOSPITALITY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class