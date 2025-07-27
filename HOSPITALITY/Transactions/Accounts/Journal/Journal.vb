
Imports BL

Public Class journal

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Public edit As Boolean
    Dim temprefno As String
    Dim jvregabbr, jvreginitial As String
    Dim jvregid As Integer
    Dim temprow As Integer
    Dim tempamt, temptds As Double
    Dim temprecodate As Date    'for recodate
    Public tempjvno As Integer
    Public TEMPREGNAME As String
    Public Shared SELECTEDBILLNO As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()
        cmbname.Text = ""
        txtremarks.Clear()
        jvregabbr = ""
        jvreginitial = ""
        gridDoubleClick = False
        journaldate.Value = Mydate
        cmbtype.Text = ""
        cmbpaytype.Text = ""
        txtrefno.Clear()
        txtrefno.ReadOnly = False
        txtdebit.Clear()
        txtcredit.Clear()
        gridjournal.RowCount = 0
        txtremarks.Clear()

        TXTTOTALDR.Text = 0.0
        TXTTOTALCR.Text = 0.0

        lbllocked.Visible = False
        PBlock.Visible = False

        edit = False
        getmaxno_journalmaster()

    End Sub

    Sub getmaxno_journalmaster()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JOURNAL_NO),0) + 1 ", "JOURNALMASTER", " AND JOURNAL_cmpid=" & CmpId & " AND JOURNAL_LOCATIONID = " & Locationid & " AND JOURNAL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtjournalno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub journaldate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles journaldate.Validating
        'If Not datecheck(journaldate.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'JOURNAL'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_journalmaster()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated

        If cmbtype.SelectedIndex = 0 Then
            txtcredit.ReadOnly = False
            txtdebit.ReadOnly = True
        Else
            txtcredit.ReadOnly = True
            txtdebit.ReadOnly = False
        End If
    End Sub

    Private Sub cmbpaytype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpaytype.Validated
        If cmbpaytype.Text = "On Account" Then
            txtrefno.ReadOnly = True
        Else
            txtrefno.ReadOnly = False
        End If
    End Sub

    Private Sub txtrefno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrefno.GotFocus
        'If txtrefno.Text.Trim = "" And cmbpaytype.Text <> "On Account" Then
        '    txtrefno.Text = Val(txtjournalno.Text)
        'ElseIf txtrefno.Text.Trim <> "" And cmbpaytype.Text = "On Account" Then
        '    txtrefno.Clear()
        'End If
    End Sub

    Private Sub txtrefno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrefno.Validating
        Try

            EP.Clear()
            If cmbtype.Text.Trim <> "" And txtrefno.Text.Trim <> "" And gridDoubleClick = False And edit = False Then
                ' GETTING BILL DETAILS DIRECTLY FROM REFNO
                If Not GETBILL(txtrefno.Text.Trim) Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If


            'If txtrefno.Text.Trim.Length > 0 And cmbname.Text.Trim.Length > 0 Then
            '    If (edit = False) Or (edit = True And LCase(temprefno) <> txtrefno.Text.Trim) Then
            '        Dim a As String
            '        a = txtrefno.Text.Trim
            '        'for search
            '        Dim objclscommon As New ClsCommon()
            '        Dim dt As New DataTable
            '        dt = objclscommon.search(" JournalMaster.Journal_refno, LEDGERS.ACC_cmpname", "", " JournalMaster inner join LEDGERS on LEDGERS.ACC_id = JournalMaster.Journal_ledgerid and JournalMaster.Journal_cmpid = LEDGERS.ACC_cmpid and JournalMaster.Journal_LOCATIONid = LEDGERS.ACC_LOCATIONid and JournalMaster.Journal_YEARid = LEDGERS.ACC_YEARid ", " and JournalMaster.Journal_refno = '" & txtrefno.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' and JournalMaster.Journal_cmpid = " & CmpId & " and JournalMaster.Journal_LOCATIONid = " & Locationid & " and JournalMaster.Journal_YEARid = " & YearId)
            '        If dt.Rows.Count > 0 Then
            '            MsgBox("Party Ref. Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
            '            e.Cancel = True
            '            Exit Sub
            '        End If
            '    End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In gridjournal.Rows
                If row.Cells(0).Value <> "" Then row.Cells(8).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'used to assign gridsrno in receiptgrid
            getsrno()


            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(journaldate.Value)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim type As String = ""
            Dim name As String = ""
            Dim paytype As String = ""
            Dim refno As String = ""
            Dim debit As String = ""
            Dim credit As String = ""
            Dim gridsrno As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridjournal.Rows
                If row.Cells(1).Value <> Nothing Then
                    If type = "" Then
                        type = row.Cells(0).Value.ToString
                        name = row.Cells(1).Value
                        paytype = row.Cells(2).Value.ToString
                        refno = row.Cells(3).Value
                        debit = row.Cells(4).Value
                        credit = row.Cells(5).Value
                        gridsrno = row.Cells(8).Value
                    Else
                        type = type & "|" & row.Cells(0).Value.ToString
                        name = name & "|" & row.Cells(1).Value
                        paytype = paytype & "|" & row.Cells(2).Value.ToString
                        refno = refno & "|" & row.Cells(3).Value
                        debit = debit & "|" & row.Cells(4).Value
                        credit = credit & "|" & row.Cells(5).Value
                        gridsrno = gridsrno & "|" & row.Cells(8).Value
                    End If
                End If
            Next

            alParaval.Add(type)
            alParaval.Add(name)
            alParaval.Add(paytype)
            alParaval.Add(refno)
            alParaval.Add(debit)
            alParaval.Add(credit)
            alParaval.Add(gridsrno)

            Dim objclsjvmaster As New ClsJournalMaster()
            objclsjvmaster.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = objclsjvmaster.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempjvno)
                alParaval.Add(tempamt)
                alParaval.Add(temptds)
                'alParaval.Add(temprecodate)
                DT = objclsjvmaster.update()
                MsgBox("Details Updated")
            End If

            'ACCOUNTS ENTRY TO BE DONE HERE COZ LOOP IS NOT POSSIBLE IN SP
            txtjournalno.Text = DT.Rows(0).Item(0)
            ACCOUNTSENTRY(DT.Rows(0).Item(0))
            clear()
            edit = False
            cmbtype.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ACCOUNTSENTRY(ByVal JVNO As Integer)
        Try
            Dim OBJJV As New ClsJournalMaster
            Dim INTRESULT As Integer

            If edit = True Then
                Dim ALP As New ArrayList
                ALP.Add(TEMPREGNAME)
                ALP.Add(JVNO)
                ALP.Add(CmpId)
                ALP.Add(Locationid)
                ALP.Add(YearId)
                OBJJV.alP = ALP
                INTRESULT = OBJJV.ACCDELETE()
            End If

            Dim tempcredit, creditbal, tempdebit, debitbal As Double
            Dim tempr As Integer    'for row no of grid
            Dim I, J As Integer     'FOR LOOP

            tempcredit = 0
            creditbal = 0
            tempdebit = 0
            debitbal = 0
            tempr = 0

            For I = 0 To gridjournal.RowCount - 1
                If gridjournal.Item(0, I).Value.ToString = "Cr" Then
                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempcredit = Val(gridjournal.Item(5, I).Value.ToString)
                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (creditbal > 0)
                            If J < gridjournal.RowCount Then

                                Dim ALPARAVAL As New ArrayList

                                ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME FROMID

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Dr" Then

                                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If

                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(journaldate.Value)                        'JOURNAL DATE
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(txtremarks.Text.Trim)
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()

                                    End If
                                End If

                                J = J + 1
                            Else
                                creditbal = 0
                            End If
                        End While


                    End If

                ElseIf gridjournal.Item(0, I).Value.ToString = "Dr" Then

                    If Val(gridjournal.Item(6, I).Value.ToString) = 0 Then

                        tempdebit = Val(gridjournal.Item(4, I).Value.ToString)
                        If debitbal = 0 Then debitbal = Val(gridjournal.Item(4, I).Value.ToString)

                        J = I + 1

                        'getting amt
                        While (debitbal > 0)
                            If J < gridjournal.RowCount Then
                                Dim ALPARAVAL As New ArrayList

                                If Val(gridjournal.Item(6, J).Value.ToString) = 0 Then

                                    If gridjournal.Item(0, J).Value.ToString = "Cr" Then

                                        'getting ledgerid
                                        ALPARAVAL.Add(gridjournal.Item(1, J).Value.ToString) 'ADDING NAME FROMID

                                        If creditbal = 0 Then creditbal = Val(gridjournal.Item(5, J).Value.ToString)

                                        If Val(creditbal) > Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            creditbal = Val(creditbal) - Val(debitbal)
                                            debitbal = 0
                                            gridjournal.Item(6, I).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, J).Value = 1

                                        ElseIf Val(creditbal) < Val(debitbal) Then

                                            ALPARAVAL.Add(Val(creditbal))        'AMOUNT
                                            debitbal = Val(debitbal) - Val(creditbal)
                                            creditbal = 0
                                            gridjournal.Item(6, J).Value = 1    'DONE BY GULKIT IF ERROR THEN COMMENT THIS SND OPEN NEXT LINE
                                            'gridjournal.Item(6, I).Value = 1

                                        ElseIf Val(creditbal) = Val(debitbal) Then

                                            ALPARAVAL.Add(Val(debitbal))        'AMOUNT
                                            debitbal = 0
                                            creditbal = 0
                                            gridjournal.Item(6, I).Value = 1
                                            gridjournal.Item(6, J).Value = 1

                                        End If


                                        ALPARAVAL.Add(gridjournal.Item(1, I).Value.ToString)    'ADDING NAME TOID
                                        ALPARAVAL.Add(Val(txtjournalno.Text))                   'JOURNAL NO
                                        ALPARAVAL.Add(journaldate.Value)                        'JOURNAL DATE
                                        ALPARAVAL.Add(cmbregister.Text.Trim)                    'REGISTER
                                        ALPARAVAL.Add(txtremarks.Text.Trim)
                                        ALPARAVAL.Add(CmpId)
                                        ALPARAVAL.Add(Locationid)
                                        ALPARAVAL.Add(Userid)
                                        ALPARAVAL.Add(YearId)

                                        OBJJV.alParaval = ALPARAVAL
                                        INTRESULT = OBJJV.ACCOUNTS()


                                    End If
                                End If

                                J = J + 1
                            Else
                                debitbal = 0
                            End If
                        End While


                    End If

                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Not datecheck(journaldate.Value) Then
            EP.SetError(journaldate, "Date Not in Current Accounting Year")
            bln = False
        End If

        If UserName <> "Admin" Then
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Journal Locked")
                bln = False
            End If
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        If gridjournal.RowCount = 0 Then
            EP.SetError(txtcredit, "Enter Transactions")
            bln = False
        End If

        'cheking whether cr and dr is equal or not
        Dim tempdebit, tempcredit As Double
        For Each row As DataGridViewRow In gridjournal.Rows
            If row.Cells(2).Value = "" Then
                EP.SetError(txtcredit, "Fill PayType")
                bln = False
            End If
            tempdebit = Format(Val(tempdebit) + Val(row.Cells(4).Value), "0.00")
            tempcredit = Format(Val(tempcredit) + Val(row.Cells(5).Value), "0.00")
        Next
        If Val(tempdebit) <> Val(tempcredit) Then
            EP.SetError(txtcredit, "Total Does Not Match")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = False Then
                If journaldate.Value.Date < Now.Date Then
                    EP.SetError(journaldate, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If

        If Not datecheck(journaldate.Value) Then
            EP.SetError(journaldate, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub Journal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New JournalDetails
                OBJINVDTLS.Show()
                'ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                '    Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Journal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'esc
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'JOURNAL' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    jvregabbr = dt.Rows(0).Item(0).ToString
                    jvreginitial = dt.Rows(0).Item(1).ToString
                    jvregid = dt.Rows(0).Item(2)
                    getmaxno_journalmaster()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtjournalno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjournalno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True

            If edit = False Then
                If gridDoubleClick = False Then
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If (cmbtype.Text = "Dr" And Val(txtdebit.Text) > Val(TXTBILLAMT.Text)) Or (cmbtype.Text = "Cr" And Val(txtcredit.Text) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN BALANCE AMT OR NOT
                    If ((cmbtype.Text = "Dr" And (Val(txtdebit.Text) - Val(gridjournal.Item(GDEBIT.Index, temprow).Value))) > Val(TXTBILLAMT.Text)) Or ((cmbtype.Text = "Cr" And (Val(txtcredit.Text) - Val(gridjournal.Item(GCREDIT.Index, temprow).Value))) > Val(TXTBILLAMT.Text)) Then
                        EP.SetError(txtcredit, "Amount Exceeds Balance Amt.")
                        BLN = False
                    End If
                End If

                'ElseIf edit = True Then
                '    If gridDoubleClick = False Then
                '        'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                '        If (Val(txttotal.Text.Trim) + Val(txtamt.Text)) > Val(txtchqamt.Text) Then
                '            EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                '            BLN = False
                '        End If

                '        If cmbpaytype.Text.Trim = "Against Bill" Then
                '            Dim MAXALLOWEDVALUE As Double = 0
                '            Dim OBJCMN As New ClsCommon
                '            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                '            If DT.Rows.Count > 0 Then
                '                MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                '            End If

                '            Dim BALAMT As Double = 0
                '            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                '                If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                '                    BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                '                End If
                '            Next

                '            If Val(txtamt.Text) > Val(MAXALLOWEDVALUE) Then
                '                EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                '                BLN = False
                '            End If

                '        End If

                '    Else
                '        'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                '        If ((Val(txttotal.Text.Trim) + Val(txtamt.Text)) - Val(gridpayment.Item(gamt.Index, temprow).Value)) > Val(txtchqamt.Text) Then
                '            EP.SetError(txtamt, "Amount Exceeds Specified Amt.")
                '            BLN = False
                '        End If

                '        If cmbpaytype.Text.Trim = "Against Bill" Then
                '            Dim MAXALLOWEDVALUE As Double = 0
                '            Dim OBJCMN As New ClsCommon
                '            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.PAYAMT),0) AS PAYAMT, ISNULL(SUM(T.DESCAMT),0)  AS DESCAMT ", "", " (SELECT SUM(PAYMENTMASTER_DESC.PAYMENT_amt)  AS PAYAMT, 0 AS DESCAMT, PAYMENT_BILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, register_name AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_DESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  WHERE PAYMENT_paytype = 'Against Bill' GROUP BY PAYMENT_BILLINITIALS, PAYMENT_no, register_name , PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  UNION ALL SELECT 0 AS PAYAMT, SUM(PAYMENTMASTER_GRIDDESC.PAYMENT_DESCAMT ) AS DESCAMT, PAYMENT_PAYBILLINITIALS AS BILLINITIALS, PAYMENT_NO as PAYNO, REGISTER_NAME AS REGNAME, PAYMENT_cmpid AS CMPID, PAYMENT_locationid AS LOCATIONID, PAYMENT_yearid AS YEARID FROM PAYMENTMASTER_GRIDDESC INNER JOIN REGISTERMASTER ON register_id = PAYMENT_registerid AND register_cmpid = PAYMENT_cmpid AND register_locationid = PAYMENT_locationid AND REGISTER_yearid = PAYMENT_yearid  GROUP BY PAYMENT_PAYBILLINITIALS , PAYMENT_NO, register_name ,PAYMENT_CMPID , PAYMENT_LOCATIONID,PAYMENT_YEARID  ) AS T ", " AND T.REGNAME = '" & cmbregister.Text.Trim & "' AND T.PAYNO =  " & txtaccno.Text.Trim & " AND T.BILLINITIALS ='" & cmbbillno.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                '            If DT.Rows.Count > 0 Then
                '                MAXALLOWEDVALUE = Val(lblbilltotal.Text.Trim) + Val(DT.Rows(0).Item("PAYAMT")) + Val(DT.Rows(0).Item("DESCAMT"))
                '            End If

                '            Dim BALAMT As Double = 0
                '            For Each ROW As DataGridViewRow In GRIDDESC.Rows
                '                If cmbbillno.Text.Trim = ROW.Cells(DPAYBILLINITIALS.Index).Value Then
                '                    BALAMT = BALAMT + ROW.Cells(DAMT.Index).Value
                '                End If
                '            Next

                '            If Val(txtamt.Text) + Val(BALAMT) > Val(MAXALLOWEDVALUE) Then
                '                EP.SetError(txtamt, "Amount Exceeds Balance Amt.")
                '                BLN = False
                '            End If

                '        End If
                '    End If
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtcredit_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcredit.Validating
        Try
            If (Val(txtcredit.Text) <> 0 Or Val(txtdebit.Text) <> 0) And cmbname.Text.Trim <> "" And cmbtype.Text.Trim <> "" Then

                If cmbtype.Text.Trim = "Against Bill" Then
                    EP.Clear()
                    If Not AMOUNTVALIDATE() Then
                        Exit Sub
                    End If
                End If

                'If cmbpaytype.Text <> "On Account" And txtrefno.Text.Trim <> "" Then
                If cmbtype.Text = "Dr" Then
                    txtcredit.Clear()
                Else
                    txtdebit.Clear()
                End If

                'If Not checkledger() Then
                '    MsgBox("Ledger already Present in Grid below")
                '    Exit Sub
                'End If

                fillgrid()
                txtdebit.Clear()
                txtcredit.Clear()
                txtrefno.Clear()
                cmbpaytype.SelectedIndex = 0
                cmbname.Text = ""
                cmbtype.Focus()
                'Else
                '    MsgBox("Enter Ref No.")
                '    txtrefno.Focus()
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkledger() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In gridjournal.Rows
                If (gridDoubleClick = True And temprow <> row.Index) Or gridDoubleClick = False Then
                    If cmbname.Text.Trim = row.Cells(1).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        'GETTING CURRENT BALANCE FROM TRIAL BALANCE
        Dim OBJCOMMON As New ClsCommon
        Dim DT As New DataTable
        Dim BAL As String = String.Empty
        Dim DRCR As String = String.Empty
        DT = OBJCOMMON.search(" (CASE WHEN DR-CR>0 THEN DR-CR ELSE CR-DR END), (CASE WHEN DR-CR>0 THEN 'Dr' ELSE 'Cr' END)", "", " TRIALBALANCE", " AND NAME = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            BAL = DT.Rows(0).Item(0)
            DRCR = DT.Rows(0).Item(1)
        End If

        If gridDoubleClick = False Then

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) & "Cr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) & "Dr"
                End If
                gridjournal.Rows.Add(cmbtype.Text, cmbname.Text.Trim, cmbpaytype.Text, txtrefno.Text.Trim, Format(Val(txtdebit.Text), "0.00"), Format(Val(txtcredit.Text), "0.00"), "", BAL)
            End If

        ElseIf gridDoubleClick = True Then

            gridjournal.Item(0, temprow).Value = cmbtype.Text
            gridjournal.Item(1, temprow).Value = cmbname.Text.Trim
            gridjournal.Item(2, temprow).Value = cmbpaytype.Text
            gridjournal.Item(3, temprow).Value = txtrefno.Text.Trim
            gridjournal.Item(4, temprow).Value = Format(Val(txtdebit.Text), "0.00")
            gridjournal.Item(5, temprow).Value = Format(Val(txtcredit.Text), "0.00")
            gridjournal.Item(6, temprow).Value = ""
            gridDoubleClick = False

            If DRCR = "Dr" Then
                BAL = Val(BAL) + Val(txtdebit.Text) - Val(txtcredit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Dr"
                Else
                    BAL = Val(BAL) * (-1) & "Cr"
                End If
                gridjournal.Item(7, temprow).Value = BAL
            Else
                BAL = Val(BAL) + Val(txtcredit.Text) - Val(txtdebit.Text)
                If Val(BAL) > 0 Then
                    BAL = Val(BAL) & "Cr"
                Else
                    BAL = Val(BAL) * (-1) & "Dr"
                End If
                gridjournal.Item(7, temprow).Value = BAL
            End If
        End If

        TOTAL()
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALCR.Text = 0.0
            TXTTOTALDR.Text = 0.0

            For Each ROW As DataGridViewRow In gridjournal.Rows
                If Val(ROW.Cells(GDEBIT.Index).Value) > 0 Or Val(ROW.Cells(GCREDIT.Index).Value) > 0 Then
                    TXTTOTALDR.Text = Format(Val(TXTTOTALDR.Text.Trim) + Val(ROW.Cells(GDEBIT.Index).Value), "0.00")
                    TXTTOTALCR.Text = Format(Val(TXTTOTALCR.Text.Trim) + Val(ROW.Cells(GCREDIT.Index).Value), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridjournal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjournal.KeyDown
        If e.KeyCode = Keys.Delete Then
            gridjournal.Rows.RemoveAt(gridjournal.CurrentRow.Index)
            TOTAL()
        End If
    End Sub

    Private Sub gridjournal_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridjournal.CellDoubleClick
        If e.RowIndex >= 0 And gridjournal.Item(0, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            temprow = e.RowIndex
            cmbtype.Text = gridjournal.Item(0, e.RowIndex).Value
            cmbname.Text = gridjournal.Item(1, e.RowIndex).Value
            cmbpaytype.Text = gridjournal.Item(2, e.RowIndex).Value
            txtrefno.Text = gridjournal.Item(3, e.RowIndex).Value
            txtdebit.Text = gridjournal.Item(4, e.RowIndex).Value
            txtcredit.Text = gridjournal.Item(5, e.RowIndex).Value
            cmbtype.Focus()
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objjvdtls As New JournalDetails
            objjvdtls.MdiParent = MDIMain
            objjvdtls.Show()
            objjvdtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Journal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'JOURNAL VOUCHER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            getmaxno_journalmaster()
            fillregister(cmbregister, " and register_type = 'JOURNAL'")
            fillledger(cmbname, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsJV As New ClsJournalMaster()
                dt = objclsJV.selectjournal_edit(tempjvno, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtjournalno.Text = tempjvno
                        cmbregister.Text = TEMPREGNAME
                        journaldate.Value = Convert.ToDateTime(dr("JOURNAL_date"))
                        tempamt = Convert.ToString(dr("JOURNAL_AMT"))
                        temptds = Convert.ToString(dr("JOURNAL_TDS"))
                        txtremarks.Text = Convert.ToString(dr("JOURNAL_remarks"))
                        gridjournal.Rows.Add(dr("JOURNAL_TYPE").ToString, dr("ACC_CMPNAME").ToString, dr("JOURNAL_PAYTYPE").ToString, dr("JOURNAL_REFNO").ToString, dr("JOURNAL_DEBIT").ToString, dr("JOURNAL_CREDIT").ToString, 0)
                        If IsDBNull(dr("JOURNAL_recodate")) = False Then temprecodate = Convert.ToDateTime(dr("JOURNAL_recodate"))

                        If dr("JOURNAL_PAYTYPE") = "Against Bill" Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    TOTAL()
                    cmbregister.Enabled = False
                    cmbtype.Focus()
                    chkchange.CheckState = CheckState.Checked
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_SECONDARY NOT IN ('CASH IN HAND','BANK A/C','BANK OD A/C') and acc_cmpid = " & CmpId)
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
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
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
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
            'If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, TXTADD, " AND  GROUPMASTER.GROUP_SECONDARY NOT IN ('CASH IN HAND','BANK A/C','BANK OD A/C')")
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY <> 'Bank A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Bank OD A/C' AND GROUPMASTER.GROUP_SECONDARY <> 'Cash In Hand'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_journalmaster()
            Dim MAXNO As Integer = txtjournalno.Text.Trim
            clear()
            If Val(txtjournalno.Text) - 1 >= tempjvno Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno < MAXNO Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridjournal.RowCount = 0
LINE1:
            tempjvno = Val(txtjournalno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If gridjournal.RowCount = 0 And tempjvno > 1 Then
                txtjournalno.Text = tempjvno
                GoTo LINE1
            End If
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

                Dim tempmsg As Integer = MsgBox("Delete Journal Entry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJJV As New ClsJournalMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(tempjvno)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJJV.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJJV.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridjournal.RowCount = 0
            tempjvno = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If tempjvno > 0 Then
                edit = True
                Journal_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If cmbname.Text.Trim <> "" Then

                SELECTEDBILLNO = ""
                txtrefno.Clear()
                TXTBILLAMT.Clear()

                Dim OBJSELECTBILL As New SelectBills
                OBJSELECTBILL.CMPNAME = cmbname.Text.Trim
                OBJSELECTBILL.ShowDialog()
                If OBJSELECTBILL.BILLNO <> "" Then SELECTEDBILLNO = OBJSELECTBILL.BILLNO

                If SELECTEDBILLNO.Trim <> "" Then
                    If Not GETBILL(SELECTEDBILLNO) Then
                        Exit Sub
                    End If
                    txtrefno.Focus()
                End If
            Else
                MsgBox("Select Name")
                cmbname.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function GETBILL(ByVal BILLNO As String) As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search(" * ", "", " (SELECT OPENINGBILL.BILL_INITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, OPENINGBILL.BILL_AMT AS BILLAMT, OPENINGBILL.BILL_BALANCE AS BALAMT, 'OPENING' AS TYPE, OPENINGBILL.BILL_NO AS BILLNO, OPENINGBILL.BILL_CMPID AS CMPID, OPENINGBILL.BILL_LOCATIONID AS LOCATIONID, OPENINGBILL.BILL_YEARID AS YEARID FROM OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id WHERE (OPENINGBILL.BILL_BALANCE > 0) UNION ALL SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS SRNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS BILLAMT, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALAMT, 'HOTELBOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE ='FALSE' AND BOOKING_SALEBALANCE > 0 UNION ALL SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS SRNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS BILLAMT, HOTELBOOKINGMASTER.BOOKING_PURBALANCE AS BALAMT, 'HOTELBOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE ='FALSE' AND BOOKING_PURBALANCE > 0 UNION ALL SELECT RAILBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, RAILBOOKINGMASTER.BOOKING_GRANDTOTAL AS BILLAMT, RAILBOOKINGMASTER.BOOKING_SALEBALANCE AS BALAMT, 'RAILBOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND RAILBOOKINGMASTER.BOOKING_SALEBALANCE > 0 UNION ALL SELECT RAILBOOKINGMASTER.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS BILLAMT, RAILBOOKINGMASTER.BOOKING_PURBALANCE AS BALAMT, 'RAILBOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM RAILBOOKINGMASTER INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND RAILBOOKINGMASTER.BOOKING_PURBALANCE > 0 UNION ALL SELECT AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME,  AIRLINEBOOKINGMASTER.BOOKING_GRANDTOTAL AS BILLAMT, AIRLINEBOOKINGMASTER.BOOKING_SALEBALANCE AS BALAMT, 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_NO AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM AIRLINEBOOKINGMASTER INNER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE (AIRLINEBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE')  AND  (AIRLINEBOOKINGMASTER.BOOKING_SALEBALANCE > 0)  UNION ALL SELECT AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME,  AIRLINEBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS BILLAMT, AIRLINEBOOKINGMASTER.BOOKING_PURBALANCE AS BALAMT, 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_NO AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM AIRLINEBOOKINGMASTER INNER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE (AIRLINEBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE')  AND  (AIRLINEBOOKINGMASTER.BOOKING_PURBALANCE > 0)  UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS BILLAMT, HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE AS BALAMT, 'HOLIDAYPACKAGE' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE ='FALSE' AND HOLIDAYPACKAGEMASTER.BOOKING_SALEBALANCE > 0  UNION ALL SELECT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS BILLAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_BALANCE AS BALAMT, 'HOLIDAYPACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM LEDGERS INNER JOIN HOLIDAYPACKAGEMASTER_PURCHASEDETAILS ON LEDGERS.Acc_id = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') AND (HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_BALANCE > 0) UNION ALL SELECT CARBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, CARBOOKINGMASTER.BOOKING_GRANDTOTAL AS BILLAMT, CARBOOKINGMASTER.BOOKING_SALEBALANCE AS BALAMT, 'VEHICLEBOOKING' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM CARBOOKINGMASTER INNER JOIN LEDGERS ON CARBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND CARBOOKINGMASTER.BOOKING_SALEBALANCE > 0  UNION ALL SELECT CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS BILLAMT, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_BALANCE AS BALAMT, 'VEHICLEBOOKING' AS TYPE, CARBOOKINGMASTER.BOOKING_NO AS BILLNO, CARBOOKINGMASTER.BOOKING_CMPID AS CMPID, CARBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, CARBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM LEDGERS INNER JOIN CARBOOKINGMASTER_PURCHASEDETAILS ON LEDGERS.Acc_id = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID INNER JOIN CARBOOKINGMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = CARBOOKINGMASTER.BOOKING_NO AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = CARBOOKINGMASTER.BOOKING_YEARID WHERE (CARBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_BALANCE >  0)  UNION ALL SELECT VISABOOKING.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, VISABOOKING.BOOKING_GRANDTOTAL AS BILLAMT, VISABOOKING.BOOKING_SALEBALANCE AS BALAMT, 'VISASALE' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, 0 AS LOCATIONID, BOOKING_YEARID AS YEARID FROM VISABOOKING INNER JOIN LEDGERS ON VISABOOKING.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE  VISABOOKING.BOOKING_SALEBALANCE > 0  UNION ALL SELECT VISABOOKING_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, VISABOOKING_PURCHASEDETAILS.BOOKING_GTOTAL AS BILLAMT, VISABOOKING_PURCHASEDETAILS.BOOKING_BALANCE AS BALAMT, 'VISAPUR' AS TYPE, VISABOOKING.BOOKING_NO AS BILLNO, VISABOOKING.BOOKING_CMPID AS CMPID, 0 AS LOCATIONID, VISABOOKING.BOOKING_YEARID AS YEARID FROM LEDGERS INNER JOIN VISABOOKING_PURCHASEDETAILS ON LEDGERS.Acc_id = VISABOOKING_PURCHASEDETAILS.BOOKING_PURLEDGERID INNER JOIN VISABOOKING ON VISABOOKING_PURCHASEDETAILS.BOOKING_NO = VISABOOKING.BOOKING_NO AND  VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = VISABOOKING.BOOKING_YEARID WHERE  (VISABOOKING_PURCHASEDETAILS.BOOKING_BALANCE > 0) UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS BILLAMT, INTERNATIONALBOOKINGMASTER.BOOKING_SALEBALANCE AS BALAMT, 'INTERNATIONAL' AS TYPE, BOOKING_NO AS BILLNO, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE ='FALSE' AND INTERNATIONALBOOKINGMASTER.BOOKING_SALEBALANCE >  0  UNION ALL SELECT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS BILLAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_BALANCE AS BALAMT, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILLNO , INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM LEDGERS INNER JOIN INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS ON LEDGERS.Acc_id = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE ='FALSE' AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_BALANCE > 0 UNION ALL SELECT ISNULL(MISCPURMASTER.BOOKING_PURBILLINITIALS, '') AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, MISCPURMASTER.BOOKING_PURGRANDTOTAL AS BILLAMT, MISCPURMASTER.BOOKING_PURBALANCE AS BALAMT, 'MISCPUR' AS TYPE, MISCPURMASTER.BOOKING_NO AS BILLNO, MISCPURMASTER.BOOKING_CMPID AS CMPID, MISCPURMASTER.BOOKING_LOCATIONID AS LOCATIONID, MISCPURMASTER.BOOKING_YEARID AS YEARID FROM MISCPURMASTER INNER JOIN LEDGERS ON MISCPURMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE  MISCPURMASTER.BOOKING_CANCELLED='FALSE' AND MISCPURMASTER.BOOKING_PURBALANCE > 0 UNION ALL SELECT     ISNULL(MISCSALMASTER.BOOKING_PURBILLINITIALS, '') AS SRNO, '' AS GUESTNAME, LEDGERS.Acc_cmpname AS NAME, MISCSALMASTER.BOOKING_PURGRANDTOTAL AS BILLAMT, MISCSALMASTER.BOOKING_PURBALANCE AS BALAMT, 'MISCSALE' AS TYPE, MISCSALMASTER.BOOKING_NO AS BILLNO, MISCSALMASTER.BOOKING_CMPID AS CMPID, MISCSALMASTER.BOOKING_LOCATIONID AS LOCATIONID, MISCSALMASTER.BOOKING_YEARID AS YEARID FROM MISCSALMASTER INNER JOIN LEDGERS ON MISCSALMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE  MISCSALMASTER.BOOKING_CANCELLED ='FALSE' AND MISCSALMASTER.BOOKING_PURBALANCE > 0) AS T ", " AND T.SRNO = '" & BILLNO & "' AND T.BALAMT > 0 AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID =" & YearId & " ORDER BY T.TYPE, T.BILLNO ")
            If dt.Rows.Count > 0 Then
                cmbname.Text = dt.Rows(0).Item("NAME")
                txtrefno.Text = BILLNO
                cmbpaytype.Text = "Against Bill"
                TXTBILLAMT.Text = Val(dt.Rows(0).Item("BALAMT"))
                If cmbtype.Text = "Dr" Then
                    txtdebit.Text = Val(dt.Rows(0).Item("BALAMT"))
                Else
                    txtcredit.Text = Val(dt.Rows(0).Item("BALAMT"))
                End If
            Else
                EP.SetError(txtcredit, "Invalid Bill No")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub journal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Then Me.Close()
    End Sub
End Class