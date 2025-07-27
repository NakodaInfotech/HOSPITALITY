
Imports BL
Imports System.Windows.Forms

Public Class RegisterMaster

    Public edit As Boolean
    Dim TempRegisterName, TEMPABBR, TEMPINITIALS As String
    Public TEMPREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String        'Used from Displaying Purchase, Sale, Receipt, Payment, Journal, CONTRA VOUCHER

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Register Name")
            bln = False
        End If

        If txtabbr.Text.Trim.Length = 0 Then
            EP.SetError(txtabbr, "Fill Abbr.")
            bln = False
        End If

        If txtinitials.Text.Trim.Length = 0 Then
            EP.SetError(txtinitials, "Fill Initials")
            bln = False
        End If
        Return bln
    End Function

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If (edit = False) Or (edit = True And TempRegisterName <> txtname.Text.Trim) Then
                'for search
                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search("register_name", "", "RegisterMaster", " and register_name = '" & txtname.Text.Trim & "' AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Register Name. Already Exists", MsgBoxStyle.Critical, CmpName)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegisterMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MsgBox("Save Changes?", MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegisterMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If AscW(e.KeyChar) <> 33 Then
                chkchange.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            txtname.ReadOnly = False
            txtinitials.ReadOnly = False
            txtname.Clear()
            txtabbr.Clear()
            txtinitials.Clear()
            cmbname.Text = ""
            cmdok.Enabled = True
            cmddelete.Enabled = True


            If FRMSTRING = "PURCHASE" Then
                Me.Text = "Purchase Register"
                lbl.Text = "Purchase Register"
            ElseIf FRMSTRING = "SALE" Then
                Me.Text = "Sale Register"
                lbl.Text = "Sale Register"
            ElseIf FRMSTRING = "JOURNAL" Then
                Me.Text = "Journal Register"
                lbl.Text = "Journal Register"
            ElseIf FRMSTRING = "EXPENSE" Then
                Me.Text = "Expense Register"
                lbl.Text = "Expense Register"
            ElseIf FRMSTRING = "CONTRA" Then
                Me.Text = "Contra"
                lbl.Text = "Contra"
                lbldefault.Visible = True
                cmbname.Visible = True
            ElseIf FRMSTRING = "PAYMENT" Then
                Me.Text = "Payment"
                lbl.Text = "Payment"
                lbldefault.Visible = True
                cmbname.Visible = True
            ElseIf FRMSTRING = "RECEIPT" Then
                Me.Text = "Receipt"
                lbl.Text = "Receipt"
                lbldefault.Visible = True
                cmbname.Visible = True
            ElseIf FRMSTRING = "DEBITNOTE" Then
                Me.Text = "Debit Note Register"
                lbl.Text = "Debit Note Register"
            ElseIf FRMSTRING = "CREDITNOTE" Then
                Me.Text = "Credit Note Register"
                lbl.Text = "Credit Note Register"
            ElseIf FRMSTRING = "MISC. PURCHASE" Then
                Me.Text = "Misc. Purchase Register"
                lbl.Text = "Misc. Purchase Register"
            ElseIf FRMSTRING = "MISC. SALE" Then
                Me.Text = "Misc. Sale Register"
                lbl.Text = "Misc. Sale Register"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegisterMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'REGISTER MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            CLEAR()

            If edit = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" register_name AS REGNAME, register_abbr AS REGABBR, register_initials AS REGINITIALS, ISNULL(LEDGERS.Acc_cmpname,'') AS LEDGERNAME, ISNULL(REGISTER_ISLOCKED,1) AS LOCKED ", "", " REGISTERMASTER LEFT OUTER JOIN LEDGERS ON Acc_id = register_ledgerid ", " AND REGISTER_ID = " & TEMPREGID)
                If DT.Rows.Count > 0 Then
                    txtname.Text = DT.Rows(0).Item("REGNAME")
                    TempRegisterName = txtname.Text.Trim
                    txtabbr.Text = DT.Rows(0).Item("REGABBR")
                    TEMPABBR = txtabbr.Text.Trim
                    txtinitials.Text = DT.Rows(0).Item("REGINITIALS")
                    TEMPINITIALS = txtinitials.Text.Trim
                    cmbname.Text = DT.Rows(0).Item("LEDGERNAME")
                    txtname.ReadOnly = True
                    txtinitials.ReadOnly = True
                    cmdok.Enabled = False

                    If Convert.ToBoolean(DT.Rows(0).Item("LOCKED")) = True Then cmddelete.Enabled = False

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtabbr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtabbr.Validating
        Try
            If (edit = False) Or (edit = True And TEMPABBR <> txtabbr.Text.Trim) Then
                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search("register_abbr", "", "RegisterMaster", " and register_abbr = '" & txtabbr.Text.Trim & "' AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Register Abbr. Already Exists", MsgBoxStyle.Critical, CmpName)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtinitials_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtinitials.Validating
        Try
            If (edit = False) Or (edit = True And TEMPINITIALS <> txtinitials.Text.Trim) Then
                'for search
                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search("register_initials", "", "RegisterMaster", " and register_initials = '" & txtinitials.Text.Trim & "' AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Register Initials Already Exists", MsgBoxStyle.Critical, CmpName)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillledger(cmbname, edit, " AND (GROUP_SECONDARY = 'Bank A/C' OR GROUP_SECONDARY = 'Casn In Hand')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then ledgervalidate(cmbname, CMBCODE, e, Me, TXTADD, " AND (GROUP_SECONDARY = 'Bank A/C' OR GROUP_SECONDARY = 'Casn In Hand') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtabbr.Text.Trim)
            alParaval.Add(txtinitials.Text.Trim)
            If frmstring = "MISC. PURCHASE" Then
                alParaval.Add("PURCHASE")
            ElseIf frmstring = "MISC. SALE" Then
                alParaval.Add("SALE")
            Else
                alParaval.Add(frmstring)
            End If

            alParaval.Add(0)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objclsRegisterMaster As New ClsRegisterMaster
            objclsRegisterMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsRegisterMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPREGID)
                IntResult = objclsRegisterMaster.update()
                MsgBox("Details Updated")
            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If edit = True Then

                Dim tempmsg As Integer = MsgBox("Delete Register Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJREGISTER As New ClsRegisterMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPREGID)

                    OBJREGISTER.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJREGISTER.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)
                    edit = False
                    CLEAR()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class