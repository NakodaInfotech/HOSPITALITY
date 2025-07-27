
Imports BL

Public Class OpeningBills

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Public edit As Boolean
    Public TEMPREGNAME As String
    Public TEMPNAME As String

    Dim regabbr, reginitial As String
    Dim regid As Integer
    Dim temprow As Integer
    
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        'clearing textboxes
        EP.Clear()
        txtopening.Clear()
        lbldrcropening.Text = ""
        LBLTOTAL.Text = 0.0
        cmbname.Text = ""
        CMBACCCODE.Text = ""
        
        TXTSRNO.Clear()
        CMBTYPE.SelectedIndex = 0
        TXTBILLNO.Clear()
        TXTYEAR.Clear()
        BILLDATE.Value = Mydate
        TXTAMT.Clear()

        
        regabbr = ""
        reginitial = ""

        GRIDOPENING.RowCount = 0

        CMBNAME.Enabled = True
        CMBACCCODE.Enabled = True

        edit = False
        GRIDDOUBLECLICK = False
        
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'OPEN ALL LEDGERS
            'If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " and groupmaster.group_SECONDARY = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBNAME.Text.Trim = "" Then fillledger(CMBNAME, edit, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
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
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId
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

    Private Sub txtamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAMT.GotFocus
        txtamt.SelectAll()
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        numdotkeypress(e, txtamt, Me)
    End Sub

    Private Sub txtBILLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBILLNO.KeyPress
        numkeypress(e, TXTBILLNO, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Name")
                BLN = False
            End If

            If GRIDOPENING.RowCount = 0 Then
                EP.SetError(TXTAMT, "Enter Bill Details")
                BLN = False
            End If


            'CHECK WHETHER OPENINGTOTAL MATCHES WITH THE OPENING BAL IN LEDGERS
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ACC_OPBAL, ACC_DRCR", "", " LEDGERS", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'")
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows(0).Item(0)) <> Val(LBLTOTAL.Text.Trim) Then
                    MsgBox("Total Does not match in Ledgers", MsgBoxStyle.Critical)
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub OpeningBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        End If
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningBills_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillledger(CMBNAME, edit, " and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY, LEDGERS.ACC_OPBAL AS OPBAL, LEDGERS.ACC_DRCR AS DRCR", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    txtopening.Text = Format(Val(DT.Rows(0).Item("OPBAL")), "0.00")
                    lbldrcropening.Text = DT.Rows(0).Item("DRCR")

                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        CMBTYPE.Text = "PURCHASE"
                    Else
                        CMBTYPE.Text = "SALE"
                    End If
                    edit = True
                End If

                CMBNAME.Enabled = False
                CMBACCCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBACCCODE, e, Me, txtadd, " and (groupmaster.group_SECONDARY = 'Sundry Debtors' or groupmaster.group_SECONDARY = 'Indirect Income' or groupmaster.group_SECONDARY = 'Direct Income') and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If CMBNAME.Text.Trim <> "" Then ledgervalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId)
            If txtbillno.Text.Trim = "" And cmbname.Text.Trim <> "" Then
                FILLGRIDOPENING()
                'Else
                '    Call txtbillno_Validating(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDOPENING()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" OPENINGBILL.BILL_GRIDSRNO AS GRIDSRNO, OPENINGBILL.BILL_TYPE AS BILLTYPE, OPENINGBILL.BILL_NO AS BILLNO, BOOKEDBY_NAME AS BOOKEDBY, OPENINGBILL.BILL_YEAR AS YEAR, OPENINGBILL.BILL_DATE AS BILLDATE, OPENINGBILL.BILL_AMT AS AMT, OPENINGBILL.BILL_AMTPAIDREC AS AMTPAIDREC, OPENINGBILL.BILL_EXTRAAMT AS EXTRAAMT, OPENINGBILL.BILL_RETURN AS [RETURN], OPENINGBILL.BILL_BALANCE AS BALANCE", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL.BILL_LOCATIONID = LEDGERS.Acc_locationid AND OPENINGBILL.BILL_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN BOOKEDBYMASTER ON OPENINGBILL.BILL_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID AND OPENINGBILL.BILL_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND OPENINGBILL.BILL_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND OPENINGBILL.BILL_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each ROW As DataRow In DT.Rows
                    GRIDOPENING.Rows.Add(ROW("GRIDSRNO"), ROW("BILLTYPE"), ROW("BILLNO"), ROW("BOOKEDBY"), ROW("YEAR"), Format(Convert.ToDateTime(ROW("BILLDATE")).Date, "dd/MM/yyyy"), Format(Val(ROW("AMT")), "0.00"), Format(Val(ROW("AMTPAIDREC")), "0.00"), Format(Val(ROW("EXTRAAMT")), "0.00"), Format(Val(ROW("RETURN")), "0.00"), Format(Val(ROW("BALANCE")), "0.00"))
                    If Val(ROW("AMTPAIDREC")) > 0 Then GRIDOPENING.Rows(GRIDOPENING.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                total()
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

    Private Sub cmdsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim INTRESULT As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alparaval As New ArrayList

            alparaval.Add(CMBNAME.Text.Trim)
            alparaval.Add(CmpId)
            alparaval.Add(Locationid)
            alparaval.Add(Userid)
            alparaval.Add(YearId)
            alparaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim TYPE As String = ""
            Dim BILLNO As String = ""
            Dim BOOKEDBY As String = ""
            Dim YEAR As String = ""
            Dim BILLDATE As String = ""
            Dim AMT As String = ""
            Dim AMTPAIDREC As String = ""
            Dim EXTRAAMT As String = ""
            Dim [RETURN] As String = ""
            Dim BALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDOPENING.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then

                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        TYPE = row.Cells(GBILLTYPE.Index).Value
                        BILLNO = row.Cells(GBILLNO.Index).Value.ToString
                        BOOKEDBY = row.Cells(GBOOKEDBY.Index).Value.ToString
                        YEAR = row.Cells(GYEAR.Index).Value
                        BILLDATE = Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        AMT = row.Cells(GAMT.Index).Value
                        AMTPAIDREC = row.Cells(GAMTPAIDREC.Index).Value
                        EXTRAAMT = row.Cells(GEXTRAAMT.Index).Value
                        [RETURN] = row.Cells(GRETURN.Index).Value
                        BALANCE = row.Cells(GBALANCE.Index).Value
                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        TYPE = TYPE & "," & row.Cells(GBILLTYPE.Index).Value
                        BILLNO = BILLNO & "," & row.Cells(GBILLNO.Index).Value.ToString
                        BOOKEDBY = BOOKEDBY & "," & row.Cells(GBOOKEDBY.Index).Value.ToString
                        YEAR = YEAR & "," & row.Cells(GYEAR.Index).Value
                        BILLDATE = BILLDATE & "," & Format(Convert.ToDateTime(row.Cells(GBILLDATE.Index).Value).Date, "MM/dd/yyyy")
                        AMT = AMT & "," & row.Cells(GAMT.Index).Value
                        AMTPAIDREC = AMTPAIDREC & "," & row.Cells(GAMTPAIDREC.Index).Value
                        EXTRAAMT = EXTRAAMT & "," & row.Cells(GEXTRAAMT.Index).Value
                        [RETURN] = [RETURN] & "," & row.Cells(GRETURN.Index).Value
                        BALANCE = BALANCE & "," & row.Cells(GBALANCE.Index).Value

                    End If
                End If
            Next


            alparaval.Add(GRIDSRNO)
            alparaval.Add(TYPE)
            alparaval.Add(BILLNO)
            alparaval.Add(BOOKEDBY)
            alparaval.Add(YEAR)
            alparaval.Add(BILLDATE)
            alparaval.Add(AMT)
            alparaval.Add(AMTPAIDREC)
            alparaval.Add(EXTRAAMT)
            alparaval.Add([RETURN])
            alparaval.Add(BALANCE)


            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CODE = '" & CMBACCCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                    alparaval.Add("PURCHASE REGISTER")
                    alparaval.Add("PURCHASE")
                Else
                    alparaval.Add("SALE REGISTER")
                    alparaval.Add("SALE")
                End If
            End If


            Dim OBJOPENING As New ClsOpening
            OBJOPENING.alParaval = alparaval

            'If edit = False Then
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            INTRESULT = OBJOPENING.save()
            MessageBox.Show("Details Added")

            'End If
            clear()
            edit = False
            CMBNAME.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()

        LBLTOTAL.Text = 0.0
        
        For Each row As DataGridViewRow In GRIDOPENING.Rows
            LBLTOTAL.Text = Format(Val(LBLTOTAL.Text) + row.Cells(GAMT.Index).Value, "0.00")
        Next

    End Sub

    Sub FILLGRID()
        Try


            For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                If (GRIDDOUBLECLICK = False) Or (GRIDDOUBLECLICK = True And temprow <> ROW.Index) Then
                    If Val(ROW.Cells(GBILLNO.Index).Value) = Val(TXTBILLNO.Text.Trim) And ROW.Cells(GYEAR.Index).Value = TXTYEAR.Text.Trim Then
                        MsgBox("Bill No Already Present in Grid below", MsgBoxStyle.Critical)
                        TXTSRNO.Focus()
                        Exit Sub
                    End If
                End If
            Next

            If GRIDDOUBLECLICK = False Then
                GRIDOPENING.Rows.Add(TXTSRNO.Text.Trim, CMBTYPE.Text.Trim, TXTBILLNO.Text.Trim, CMBBOOKEDBY.Text.Trim, TXTYEAR.Text.Trim, Format(BILLDATE.Value.Date, "dd/MM/yyyy"), Val(TXTAMT.Text.Trim), 0, 0, 0, 0)
                getsrno(GRIDOPENING)
            Else
                GRIDOPENING.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
                GRIDOPENING.Item(GBILLTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
                GRIDOPENING.Item(GBILLNO.Index, temprow).Value = TXTBILLNO.Text.Trim
                GRIDOPENING.Item(GBOOKEDBY.Index, temprow).Value = CMBBOOKEDBY.Text.Trim
                GRIDOPENING.Item(GYEAR.Index, temprow).Value = TXTYEAR.Text.Trim
                GRIDOPENING.Item(GBILLDATE.Index, temprow).Value = Format(BILLDATE.Value.Date, "dd/MM/yyyy")
                GRIDOPENING.Item(GAMT.Index, temprow).Value = Format(Val(TXTAMT.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If
            total()

            GRIDOPENING.FirstDisplayedScrollingRowIndex = GRIDOPENING.RowCount - 1

            TXTSRNO.Clear()
            TXTBILLNO.Text = ""
            TXTYEAR.Text = ""
            BILLDATE.Value = Mydate
            TXTAMT.Clear()
            TXTSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDOPENING.CellDoubleClick
        Try

            If Val(GRIDOPENING.Rows(e.RowIndex).Cells(GAMTPAIDREC.Index).Value) > 0 Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If e.RowIndex >= 0 And GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDOPENING.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBTYPE.Text = GRIDOPENING.Item(GBILLTYPE.Index, e.RowIndex).Value.ToString
                TXTBILLNO.Text = GRIDOPENING.Item(GBILLNO.Index, e.RowIndex).Value.ToString
                CMBBOOKEDBY.Text = GRIDOPENING.Item(GBOOKEDBY.Index, e.RowIndex).Value.ToString
                TXTYEAR.Text = GRIDOPENING.Item(GYEAR.Index, e.RowIndex).Value.ToString
                BILLDATE.Value = Convert.ToDateTime(GRIDOPENING.Item(GBILLDATE.Index, e.RowIndex).Value).Date
                TXTAMT.Text = GRIDOPENING.Item(GAMT.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOPENING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDOPENING.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            'if REC/PAYMERNT IS MADE THEN DONT ALLOW TO DELETE
            If Val(GRIDOPENING.Rows(GRIDOPENING.CurrentRow.Index).Cells(GAMTPAIDREC.Index).Value) > 0 Then
                MsgBox("Rec/Pay Made Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete Bill No " & GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(CMBNAME.Text.Trim)
                    ALPARAVAL.Add(GRIDOPENING.Item(GBILLNO.Index, GRIDOPENING.CurrentRow.Index).Value)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJOP.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJOP.DELETE

                    GRIDOPENING.Rows.RemoveAt(GRIDOPENING.CurrentRow.Index)
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If

        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Enabled = True
        CMBNAME.Focus()
    End Sub

    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBACCCODE.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            If CMBACCCODE.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY AS SECONDARY", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID  ", " AND LEDGERS.ACC_CODE = '" & CMBACCCODE.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        CMBTYPE.Text = "PURCHASE"
                    Else
                        CMBTYPE.Text = "SALE"
                    End If
                End If
                CMBNAME.Enabled = False
                CMBACCCODE.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS')", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtamt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        Try
            If TXTSRNO.Text.Trim.Length = 0 Then txtsrno_GotFocus(sender, e)

            If TXTSRNO.Text.Trim.Length > 0 And Val(TXTAMT.Text) > 0 And TXTBILLNO.Text.Trim <> "" And TXTYEAR.Text.Trim <> "" And CMBTYPE.Text <> "" Then
                FILLGRID()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDOPENING.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDOPENING.Rows(GRIDOPENING.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Delete All Bills of " & CMBNAME.Text.Trim, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJOP As New ClsOpening

                    For Each ROW As DataGridViewRow In GRIDOPENING.Rows
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(CMBNAME.Text.Trim)
                        ALPARAVAL.Add(ROW.Cells(GBILLNO.Index).Value)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)


                        OBJOP.alParaval = ALPARAVAL
                        Dim INTRES As Integer = OBJOP.DELETE

                        'GRIDOPENING.Rows.RemoveAt(GRIDOPENING.CurrentRow.Index)
                    Next
                    clear()
                    total()
                    getsrno(GRIDOPENING)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJOP As New OpeningBillDetails
            OBJOP.MdiParent = MDIMain
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdsave_Click(sender, e)
    End Sub

    Private Sub OpeningBills_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If TEMPNAME <> "" Then
                CMBNAME.Text = TEMPNAME
                cmbname_Validated(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class