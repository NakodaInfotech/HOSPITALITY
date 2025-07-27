
Imports BL

Public Class Matching

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPMATCHNO As Integer
    Public Shared SELECTEDBILLNO As String

    'FOR ADDING NEW CHKCOL IN GRIDBILL
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

    Sub clear()

        'clearing textboxes
        EP.Clear()
        tstxtbillno.Clear()

        CMBNAME.Text = ""
        CMBNAME.Enabled = True

        tstxtbillno.Clear()
        TXTMATCHNO.Clear()

        TXTOPENING.Clear()
        TXTDP.Clear()
        TXTTOTAL.Clear()
        TXTPREADJUSTED.Clear()
        TXTTOTALPAY.Clear()
        TXTTOTALBAL.Clear()
        

        txtremarks.Clear()
        MATCHDATE.Value = Mydate

        GRIDMATCH.RowCount = 0
        GETMAXNO_MATCH()
        TXTADJTOTAL.Clear()
        TXTBALANCE.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False

    End Sub

    Sub GETMAXNO_MATCH()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MATCH_NO),0) + 1 ", " MANUALMATCHING ", " AND MATCH_cmpid=" & CmpId & " AND MATCH_LOCATIONid=" & Locationid & " AND MATCH_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTMATCHNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and groupmaster.group_SECONDARY = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, edit, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBNAME.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If Not datecheck(MATCHDATE.Value) Then
                EP.SetError(MATCHDATE, "Date Not in Current Accounting Year")
                BLN = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Reco Done, Receipt Locked")
                BLN = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Name")
                BLN = False
            End If

            If GRIDMATCH.RowCount = 0 Then
                EP.SetError(GRIDMATCH, "Enter Match Details")
                BLN = False
            End If

            If Val(TXTBALANCE.Text.Trim) < 0 And edit = False Then
                EP.SetError(TXTBALANCE, "Negative Balance")
                BLN = False
            End If

            If Val(TXTTOTALBAL.Text.Trim) = 0 Then
                EP.SetError(TXTTOTALBAL, "Enter Match Details")
                BLN = False
            End If

            If Val(TXTTOTALPAY.Text.Trim) = 0 Then
                EP.SetError(TXTTOTALPAY, "Enter Match Details")
                BLN = False
            End If

            If ClientName = "CLASSIC" Then
                If UserName <> "Admin" And edit = False Then
                    If MATCHDATE.Value.Date < Now.Date Then
                        EP.SetError(MATCHDATE, "Back Date Entry Not Allowed")
                        BLN = False
                    End If
                End If
            End If

            If Not datecheck(MATCHDATE.Value) Then
                EP.SetError(MATCHDATE, "Date Not in Current Accounting Year")
                BLN = False
            End If

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Matching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdsave_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdsave_Click(sender, e)
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
        End If
    End Sub

    Private Sub Matching_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If AscW(e.KeyChar) <> 33 Then CHKCHANGE.CheckState = CheckState.Checked
    End Sub

    Private Sub Matching_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            fillledger(CMBNAME, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJMATCH As New ClsManualMatching()
                dt = OBJMATCH.selectbill_edit(TEMPMATCHNO, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then

                    GRIDMATCH.RowCount = 0

                    For Each dr As DataRow In dt.Rows

                        TXTMATCHNO.Text = TEMPMATCHNO
                        MATCHDATE.Value = Convert.ToDateTime(dr("MATCHDATE"))
                        CMBNAME.Text = Convert.ToString(dr("NAME"))

                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        GRIDMATCH.Rows.Add(1, dr("GRIDSRNO"), dr("BILLNO"), dr("BILLINITIALS"), Format(Convert.ToDateTime(dr("BILLDATE")).Date, "dd/MM/yyyy"), dr("REFNO"), dr("HOTELNAME"), dr("GUESTNAME"), Format(dr("BILLAMT"), "0.00"), Format(dr("BALAMT"), "0.00"), Format(dr("PAIDAMT"), "0.00"))
                    Next
                    MATCHDATE.Focus()
                    CHKCHANGE.CheckState = CheckState.Checked
                End If
                total()
            End If
            GRIDMATCH.ClearSelection()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETBALANCE()
        Try
            TXTDP.Clear()
            TXTOPENING.Clear()
            TXTTOTAL.Clear()
            TXTBALANCE.Clear()

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" LEDGERS.Acc_opbal - ISNULL(SUM(OPENINGBILL.BILL_AMT),0) AS BALANCE ", "", " LEDGERS LEFT OUTER JOIN OPENINGBILL ON LEDGERS.Acc_id = OPENINGBILL.BILL_LEDGERID AND LEDGERS.Acc_cmpid = OPENINGBILL.BILL_CMPID AND LEDGERS.Acc_locationid = OPENINGBILL.BILL_LOCATIONID AND LEDGERS.Acc_yearid = OPENINGBILL.BILL_YEARID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID  =" & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " GROUP BY LEDGERS.Acc_opbal ")
            If DT.Rows.Count > 0 Then TXTOPENING.Text = Format(Val(DT.Rows(0).Item("BALANCE")), "0.00")
            DT = OBJCMN.search("SUM(T.BALANCE) AS DP", "", " (SELECT LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_DP - HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS BALANCE FROM HOTELBOOKINGMASTER INNER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid And HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid WHERE LEDGERS.Acc_CMPNAME  = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " AND (HOTELBOOKINGMASTER.BOOKING_DP - HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL > 0) UNION ALL SELECT LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_DP - HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS BALANCE FROM HOTELBOOKINGMASTER INNER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid And HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid WHERE LEDGERS.Acc_CMPNAME  = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId & " AND (HOTELBOOKINGMASTER.BOOKING_DP - HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL > 0)) AS T  ", " GROUP BY T.NAME  ")
            If DT.Rows.Count > 0 Then TXTDP.Text = Format(Val(DT.Rows(0).Item("DP")), "0.00")
            TXTTOTAL.Text = Format(Val(TXTOPENING.Text.Trim) + Val(TXTDP.Text.Trim), "0.00")
            DT = OBJCMN.search(" ISNULL( SUM(MANUALMATCHING.MATCH_TOTALPAID),0) AS ADJUSTED ", "", "  MANUALMATCHING INNER JOIN LEDGERS ON MANUALMATCHING.MATCH_LEDGERID = LEDGERS.Acc_id AND MANUALMATCHING.MATCH_CMPID = LEDGERS.Acc_cmpid AND MANUALMATCHING.MATCH_LOCATIONID = LEDGERS.Acc_locationid AND MANUALMATCHING.MATCH_YEARID = LEDGERS.Acc_yearid ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND MATCH_CMPID = " & CmpId & " AND MATCH_LOCATIONID = " & Locationid & " AND MATCH_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTPREADJUSTED.Text = Format(Val(DT.Rows(0).Item("ADJUSTED")), "0.00")
            TXTBALANCE.Text = Format(Val(TXTTOTAL.Text.Trim) - Val(TXTPREADJUSTED.Text.Trim), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                CMBNAME.Enabled = False
                GETBALANCE()
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then ledgervalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' OR groupmaster.group_SECONDARY = 'Sundry Creditors' ) and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try


            Dim DTTABLE As DataTable

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(MATCHDATE.Value)
            alparaval.Add(CMBNAME.Text.Trim)
            alparaval.Add(Val(TXTTOTALBAL.Text.Trim))
            alparaval.Add(Val(TXTTOTALPAY.Text.Trim))
            alparaval.Add(txtremarks.Text.Trim)

            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim BILLINITIALS As String = ""
            Dim BILLNO As String = ""
            Dim BILLDATE As String = ""
            Dim REFNO As String = ""
            Dim HOTELNAME As String = ""
            Dim GUESTNAME As String = ""
            Dim BILLAMT As String = ""
            Dim BALAMT As String = ""
            Dim PAYAMT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDMATCH.Rows
                Dim I As Integer = 1
                If Convert.ToBoolean(row.Cells(GCHK.Index).Value) = True Then
                    If BILLINITIALS = "" Then
                        GRIDSRNO = I
                        BILLINITIALS = row.Cells(GBILLINITIALS.Index).Value.ToString
                        BILLNO = row.Cells(GBILLNO.Index).Value
                        BILLDATE = Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        REFNO = row.Cells(GREFNO.Index).Value
                        HOTELNAME = row.Cells(GHOTELNAME.Index).Value.ToString
                        GUESTNAME = row.Cells(GGUESTNAME.Index).Value
                        BILLAMT = row.Cells(GBILLAMT.Index).Value
                        BALAMT = row.Cells(GBALAMT.Index).Value.ToString
                        PAYAMT = row.Cells(GPAIDAMT.Index).Value.ToString
                    Else
                        GRIDSRNO = GRIDSRNO & "," & I
                        BILLINITIALS = BILLINITIALS & "," & row.Cells(GBILLINITIALS.Index).Value.ToString
                        BILLNO = BILLNO & "," & row.Cells(GBILLNO.Index).Value
                        BILLDATE = BILLDATE & "," & Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        REFNO = REFNO & "," & row.Cells(GREFNO.Index).Value
                        HOTELNAME = HOTELNAME & "," & row.Cells(GHOTELNAME.Index).Value.ToString
                        GUESTNAME = GUESTNAME & "," & row.Cells(GGUESTNAME.Index).Value.ToString
                        BILLAMT = BILLAMT & "," & row.Cells(GBILLAMT.Index).Value
                        BALAMT = BALAMT & "," & row.Cells(GBALAMT.Index).Value.ToString
                        PAYAMT = PAYAMT & "," & row.Cells(GPAIDAMT.Index).Value.ToString
                    End If
                    I += 1
                End If
            Next

            alparaval.Add(GRIDSRNO)
            alparaval.Add(BILLINITIALS)
            alparaval.Add(BILLNO)
            alparaval.Add(BILLDATE)
            alparaval.Add(REFNO)
            alparaval.Add(HOTELNAME)
            alparaval.Add(GUESTNAME)
            alparaval.Add(BILLAMT)
            alparaval.Add(BALAMT)
            alparaval.Add(PAYAMT)


            Dim OBJMATCH As New ClsManualMatching
            OBJMATCH.alParaval = alparaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJMATCH.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alparaval.Add(TEMPMATCHNO)
                Dim IntResult As Integer = OBJMATCH.update()
                MsgBox("Details Updated")
            End If
            clear()
            edit = False
            MATCHDATE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        TXTTOTALBAL.Text = 0.0
        TXTTOTALPAY.Text = 0.0
        TXTBALANCE.Text = 0.0
        TXTADJTOTAL.Text = 0.0

        For Each row As DataGridViewRow In GRIDMATCH.Rows
            If Convert.ToBoolean(row.Cells(GCHK.Index).EditedFormattedValue) = True Then
                TXTTOTALBAL.Text = Format(Val(TXTTOTALBAL.Text) + row.Cells(GBALAMT.Index).EditedFormattedValue, "0.00")
                TXTTOTALPAY.Text = Format(Val(TXTTOTALPAY.Text) + row.Cells(GPAIDAMT.Index).EditedFormattedValue, "0.00")
                TXTADJTOTAL.Text = Format(Val(TXTADJTOTAL.Text) + row.Cells(GPAIDAMT.Index).EditedFormattedValue, "0.00")
            End If
        Next
        TXTBALANCE.Text = Format(Val(TXTTOTAL.Text.Trim) - Val(TXTPREADJUSTED.Text.Trim) - Val(TXTADJTOTAL.Text.Trim), "0.00")

    End Sub

    Sub fillgrid()
        Try
            Dim OBJPAY As New ClsManualMatching
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable = OBJPAY.GETBILLS(CmpId, CMBNAME.Text.Trim, Locationid, YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDMATCH.Rows.Add(0, 0, DTROW("BILLNO"), DTROW("BILLINITIALS"), Format(Convert.ToDateTime(DTROW("BILLDATE")).Date, "dd/MM/yyyy"), DTROW("PARTYBILLNO"), DTROW("HOTELNAME"), DTROW("GUESTNAME"), DTROW("BILLAMT"), DTROW("BALAMT"), 0)
                Next
                total()
                getsrno(GRIDMATCH)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDMATCH.RowCount = 0
LINE1:
            TEMPMATCHNO = Val(TXTMATCHNO.Text) + 1
            GETMAXNO_MATCH()
            Dim MAXNO As Integer = TXTMATCHNO.Text.Trim
            clear()
            If Val(TXTMATCHNO.Text) - 1 >= TEMPMATCHNO Then
                edit = True
                Matching_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDMATCH.RowCount = 0 And TEMPMATCHNO < MAXNO Then
                TXTMATCHNO.Text = TEMPMATCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDMATCH.RowCount = 0
LINE1:
            TEMPMATCHNO = Val(TXTMATCHNO.Text) - 1
            If TEMPMATCHNO > 0 Then
                edit = True
                Matching_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDMATCH.RowCount = 0 And TEMPMATCHNO > 1 Then
                TXTMATCHNO.Text = TEMPMATCHNO
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
            Dim OBJMATCHDTLS As New MatchingDetails
            OBJMATCHDTLS.MdiParent = MDIMain
            OBJMATCHDTLS.Show()
            OBJMATCHDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        MATCHDATE.Focus()
    End Sub

    Private Sub MATCHDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MATCHDATE.Validating
        'If Not datecheck(MATCHDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Matching Entry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJREC As New ClsManualMatching
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPMATCHNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJREC.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJREC.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            'If edit = True Then
            '    Dim objrec As New MATCH_advice
            '    objrec.recno = Val(TXTMATCHNO.Text)
            '    objrec.recname = CMBNAME.Text.Trim
            '    objrec.REGNAME = cmbregister.Text.Trim
            '    objrec.MdiParent = MDIMain
            '    objrec.Show()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            Cursor.Current = Cursors.WaitCursor
            GRIDMATCH.RowCount = 0
            TEMPMATCHNO = Val(tstxtbillno.Text)
            clear()
            If TEMPMATCHNO > 0 Then
                edit = True
                Matching_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRIDMATCH_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDMATCH.CellValidating
        Try
            Dim colNum As Integer = GRIDMATCH.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPAIDAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDMATCH.CurrentCell.Value = Nothing Then GRIDMATCH.CurrentCell.Value = "0.00"
                        GRIDMATCH.CurrentCell.Value = Convert.ToDecimal(GRIDMATCH.Item(colNum, e.RowIndex).Value)
                        '' everything is good

                        'CHECK WHETHER IT IS GREATER THAN BAL AMT OR NOT.
                        If Val(GRIDMATCH.CurrentCell.EditedFormattedValue) > Val(GRIDMATCH.CurrentRow.Cells(GBALAMT.Index).Value) Then
                            MessageBox.Show("Amount greater than Balance Amt")
                            e.Cancel = True
                            Exit Sub
                        End If

                        total()

                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case GCHK.Index
                    total()

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class