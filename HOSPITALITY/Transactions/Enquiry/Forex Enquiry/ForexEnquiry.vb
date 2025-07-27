Imports BL

Public Class ForexEnquiry

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPFOREXENQNO As Integer
    Dim TEMPMSG As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_FOREXENQ_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(FOREX_NO),0) + 1 ", "FOREXENQUIRY", " and FOREX_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTFOREXENQNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()

        Try
            tstxtbillno.Clear()
            TXTFOREXENQNO.Clear()
            DTFOREXENQDATE.Value = Mydate
            CMBGUESTNAME.Text = ""
            CMBBUYSELL.SelectedIndex = 0
            CMBSOURCE.Text = ""
            CMBBOOKEDBY.Text = ""
            TXTAGENT.Clear()

            CMBSTATUS.SelectedIndex = 0
            CMBCURRENCY.Text = ""
            CMBPRODUCT.SelectedIndex = 0
            TXTROE.Clear()
            TXTCURRENCYAMT.Clear()
            TXTAMTINR.Clear()
            TXTST.Clear()
            TXTOTHERCHGS.Clear()
            CMBOTHERCHGS.Text = ""
            txtroundoff.Clear()
            TXTGTOTAL.Clear()
            MTBRETURNDATE.Clear()
            TXTCOMM.Clear()
            TXTREMARKS.Clear()
            TXTCLOSEREMARKS.Clear()

            If UserName = "Admin" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()
            GETMAX_FOREXENQ_NO()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        CMBGUESTNAME.Focus()
    End Sub

    Private Sub ForexEnquiry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for DIRECT LINK TO INV NO
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
            fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'Indirect Income' or GROUP_SECONDARY = 'Indirect Expenses')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ForexEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            MTBRETURNDATE.Visible = False
            LBLRETURNDATE.Visible = False


            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'FOREX'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim OBJFOREXENQ As New ClsForexEnquiry

                OBJFOREXENQ.alParaval.Add(TEMPFOREXENQNO)
                OBJFOREXENQ.alParaval.Add(YearId)
                dttable = OBJFOREXENQ.SELECTFOREXENQ()

                If dttable.Rows.Count > 0 Then
                    CMBGUESTNAME.Focus()

                    TXTFOREXENQNO.Text = TEMPFOREXENQNO
                    DTFOREXENQDATE.Value = dttable.Rows(0).Item("DATE")
                    CMBGUESTNAME.Text = dttable.Rows(0).Item("GUESTNAME").ToString
                    CMBBUYSELL.Text = dttable.Rows(0).Item("BUYSELL").ToString
                    CMBSOURCE.Text = dttable.Rows(0).Item("SOURCE").ToString
                    CMBBOOKEDBY.Text = dttable.Rows(0).Item("ENQHANDELEDBY").ToString
                    TXTAGENT.Text = dttable.Rows(0).Item("AGENT").ToString
                    CMBSTATUS.Text = dttable.Rows(0).Item("STATUS").ToString
                    CMBCURRENCY.Text = dttable.Rows(0).Item("CURRENCY").ToString
                    TXTROE.Text = dttable.Rows(0).Item("ROE")
                    TXTCURRENCYAMT.Text = dttable.Rows(0).Item("CURRENCYAMT")
                    TXTAMTINR.Text = dttable.Rows(0).Item("AMTINR")
                    TXTST.Text = dttable.Rows(0).Item("STAX")

                    If Val(dttable.Rows(0).Item("OTHERCHGS")) > 0 Then
                        TXTOTHERCHGS.Text = Val(dttable.Rows(0).Item("OTHERCHGS"))
                        cmbaddsub.Text = "Add"
                    Else
                        TXTOTHERCHGS.Text = Val(dttable.Rows(0).Item("OTHERCHGS") * (-1))
                        cmbaddsub.Text = "Sub."
                    End If

                    CMBOTHERCHGS.Text = dttable.Rows(0).Item("OTHERCHGSNAME")
                    TXTGTOTAL.Text = dttable.Rows(0).Item("GTOTAL")
                    If CMBBUYSELL.Text = "Sell" Then
                        MTBRETURNDATE.Visible = True
                        LBLRETURNDATE.Visible = True
                    End If
                    MTBRETURNDATE.Text = dttable.Rows(0).Item("RETURNDATE")
                    CMBPRODUCT.Text = dttable.Rows(0).Item("PRODUCT").ToString
                    TXTCOMM.Text = Val(dttable.Rows(0).Item("COMM"))
                    TXTREMARKS.Text = dttable.Rows(0).Item("REMARKS").ToString
                    TXTCLOSEREMARKS.Text = dttable.Rows(0).Item("CLOSEREMARKS").ToString

                    CALC()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(DTFOREXENQDATE.Value.Date)
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(CMBBUYSELL.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(TXTAGENT.Text.Trim)
            alParaval.Add(CMBSTATUS.Text.Trim)
            alParaval.Add(CMBCURRENCY.Text.Trim)
            alParaval.Add(Val(TXTROE.Text))
            alParaval.Add(Val(TXTCURRENCYAMT.Text))
            alParaval.Add(Val(TXTAMTINR.Text.Trim))
            alParaval.Add(Val(TXTST.Text.Trim))
            alParaval.Add(CMBOTHERCHGS.Text.Trim)

            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(TXTOTHERCHGS.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((TXTOTHERCHGS.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(TXTGTOTAL.Text.Trim))
            alParaval.Add(MTBRETURNDATE.Text.Trim)
            alParaval.Add(CMBPRODUCT.Text.Trim)
            alParaval.Add(Val(TXTCOMM.Text.Trim))
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTCLOSEREMARKS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim OBJFOREX As New ClsForexEnquiry
            OBJFOREX.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = OBJFOREX.SAVE()
                TEMPFOREXENQNO = DT.Rows(0).Item(0)
                MsgBox("Details Added")
                clear()


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPFOREXENQNO)
                IntResult = OBJFOREX.UPDATE()
                edit = False
                MsgBox("Details Updated")
                clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If CMBGUESTNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBGUESTNAME, "Select Guest Name")
            bln = False
        End If

        If CMBBUYSELL.Text.Trim.Length = 0 Then
            EP.SetError(CMBBUYSELL, "Select Buy/Sell")
            bln = False
        End If

        If CMBBUYSELL.Text = "Sell" And CMBPRODUCT.Text = "REMITTANCE" Then
            EP.SetError(CMBPRODUCT, "Only Buy Allowed")
            bln = False
        End If

        If CMBSOURCE.Text.Trim.Length = 0 And ClientName = "WORLDSPIN" Then
            EP.SetError(CMBSOURCE, "Select Source")
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, "Select Enquiry Handeled By")
            bln = False
        End If


        If CMBSTATUS.Text.Trim.Length = 0 Then
            EP.SetError(CMBSTATUS, "Select Enquiry Status")
            bln = False
        End If


        If CMBCURRENCY.Text.Trim.Length = 0 Then
            EP.SetError(CMBCURRENCY, "Select Currency")
            bln = False
        End If


        If TXTROE.Text.Trim.Length = 0 Then
            EP.SetError(TXTROE, "Select Rate of Exchange")
            bln = False
        End If


        If TXTCURRENCYAMT.Text.Trim.Length = 0 Then
            EP.SetError(TXTCURRENCYAMT, "Enter Currency Amount")
            bln = False
        End If

        If Not datecheck(DTFOREXENQDATE.Value.Date) Then
            EP.SetError(DTFOREXENQDATE, "Date Not in Accounting Year")
            bln = False
        End If

        If CMBBUYSELL.Text = "Sell" And MTBRETURNDATE.Text.Trim.Length = 0 Then
            EP.SetError(MTBRETURNDATE, "Select Return Date")
            bln = False
        End If

        If CMBSTATUS.Text = "Cancel" And TXTCLOSEREMARKS.Text.Trim.Length = 0 Then
            EP.SetError(TXTCLOSEREMARKS, "Enter Closing Remarks")
            bln = False
        End If

        If Val(TXTOTHERCHGS.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If


        Return bln

    End Function

    Private Sub CMBBUYSELL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBUYSELL.Validating
        If CMBBUYSELL.Text = "Sell" Then
            LBLRETURNDATE.Visible = True
            MTBRETURNDATE.Visible = True
        Else
            LBLRETURNDATE.Visible = False
            MTBRETURNDATE.Visible = False
        End If
        CALC()
    End Sub

    Private Sub CMBGUESTNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBGUESTNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTADDGUESTNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()

        txtroundoff.Clear()
        TXTAMTINR.Text = Format(Val(TXTROE.Text) * Val(TXTCURRENCYAMT.Text), "0.00")

        If Val(TXTAMTINR.Text) <= 25000 Then
            TXTST.Text = 0
        ElseIf Val(TXTAMTINR.Text) > 25000 And Val(TXTAMTINR.Text) <= 100000 Then
            TXTST.Text = Format(Val(0.001236 * Val(TXTAMTINR.Text)), "0.00")
        ElseIf Val(TXTAMTINR.Text) > 100000 Then
            TXTST.Text = Format(Val(123.6 + ((Val(TXTAMTINR.Text) - 100000) * 0.000618)), "0.00")
        End If

        If cmbaddsub.Text = "Add" Then
            If CMBBUYSELL.Text = "Buy" Then
                TXTGTOTAL.Text = Format((Val(TXTAMTINR.Text) - Val(TXTST.Text)) + Val(TXTOTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(TXTGTOTAL.Text) - ((Val(TXTAMTINR.Text) - Val(TXTST.Text)) + Val(TXTOTHERCHGS.Text)), "0.00")
            Else
                TXTGTOTAL.Text = Format(Val(TXTAMTINR.Text) + Val(TXTST.Text) + Val(TXTOTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(TXTGTOTAL.Text) - (Val(TXTAMTINR.Text) + Val(TXTST.Text) + Val(TXTOTHERCHGS.Text)), "0.00")
            End If

        Else
            If CMBBUYSELL.Text = "Buy" Then
                TXTGTOTAL.Text = Format((Val(TXTAMTINR.Text) - Val(TXTST.Text)) - Val(TXTOTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(TXTGTOTAL.Text) - ((Val(TXTAMTINR.Text) - Val(TXTST.Text)) - Val(TXTOTHERCHGS.Text)), "0.00")
            Else
                TXTGTOTAL.Text = Format((Val(TXTAMTINR.Text) + Val(TXTST.Text)) - Val(TXTOTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(TXTGTOTAL.Text) - ((Val(TXTAMTINR.Text) + Val(TXTST.Text)) - Val(TXTOTHERCHGS.Text)), "0.00")
            End If
        End If

        TXTGTOTAL.Text = Format(Val(TXTGTOTAL.Text), "0.00")

    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' or  GROUP_SECONDARY = 'INDIRECT INCOME')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' or  GROUP_SECONDARY = 'INDIRECT INCOME')", "INDIRECT EXPENSES")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTROE.Validating
        CALC()
    End Sub

    Private Sub TXTCURRENCYAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCURRENCYAMT.Validating
        CALC()
    End Sub

    Private Sub TXTGTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGTOTAL.Validating
        CALC()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPFOREXENQNO = Val(TXTFOREXENQNO.Text) - 1
Line2:
            If TEMPFOREXENQNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" FOREX_NO ", "", "  FOREXENQUIRY", " AND FOREX_NO = '" & TEMPFOREXENQNO & "' AND FOREX_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    ForexEnquiry_Load(sender, e)
                Else
                    TEMPFOREXENQNO = Val(TEMPFOREXENQNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If CMBGUESTNAME.Text.Trim = "" And TEMPFOREXENQNO > 1 Then
                TXTFOREXENQNO.Text = TEMPFOREXENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            'GridItem.RowCount = 0
LINE1:
            TEMPFOREXENQNO = Val(TXTFOREXENQNO.Text) + 1
            GETMAX_FOREXENQ_NO()
            Dim MAXNO As Integer = TXTFOREXENQNO.Text.Trim
            clear()
            If Val(TXTFOREXENQNO.Text) - 1 >= TEMPFOREXENQNO Then
                edit = True
                ForexEnquiry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If CMBGUESTNAME.Text.Trim = "" And TEMPFOREXENQNO < MAXNO Then
                TXTFOREXENQNO.Text = TEMPFOREXENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            'GridItem.RowCount = 0
            TEMPFOREXENQNO = Val(tstxtbillno.Text)
            If TEMPFOREXENQNO > 0 Then
                edit = True
                ForexEnquiry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTROE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROE.KeyPress
        numdotkeypress(e, TXTROE, Me)
    End Sub

    Private Sub TXTCURRENCYAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCURRENCYAMT.KeyPress
        numdotkeypress(e, TXTCURRENCYAMT, Me)
    End Sub

    Private Sub TXTAMTINR_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMTINR.KeyPress
        numdotkeypress(e, TXTAMTINR, Me)
    End Sub

    Private Sub TXTST_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTST.KeyPress
        numdotkeypress(e, TXTST, Me)
    End Sub

    Private Sub TXTOTHERCHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERCHGS.KeyPress
        numdotkeypress(e, TXTOTHERCHGS, Me)
    End Sub

    Private Sub TXTGTOTAL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGTOTAL.KeyPress
        numdotkeypress(e, TXTGTOTAL, Me)
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            'If lbllocked.Visible = True Then
            '    MsgBox("Invoice Locked", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim OBJFOREX As New ClsForexEnquiry()
            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim alParaval As New ArrayList
                alParaval.Add(TEMPFOREXENQNO)
                alParaval.Add(YearId)
                alParaval.Add(Userid)
                OBJFOREX.alParaval = alParaval
                Dim DT As DataTable = OBJFOREX.DELETE()
                MsgBox("Forex Enquiry Deleted Successfully")
                clear()
                edit = False

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaddsub_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbaddsub.Validated
        CALC()
    End Sub

    Private Sub MTBRETURNDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MTBRETURNDATE.Validating
        Try
            If MTBRETURNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(MTBRETURNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Validated
        If CMBOTHERCHGS.Text.Trim <> "" Then CALC()
    End Sub

    Private Sub TXTOTHERCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERCHGS.Validated
        CALC()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJFOREX As New ForexEnquiryDetails
            OBJFOREX.MdiParent = MDIMain
            OBJFOREX.Show()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCOMM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMM.KeyPress
        numdotkeypress(e, TXTCOMM, Me)
    End Sub

    Private Sub ForexEnquiry_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MATRIX" Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class