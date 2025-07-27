
Imports BL

Public Class GuestLedgerConfig

    Public FRMSTRING As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'CHECK DUPLICATION
        'WHETHER GUEST FOR THIS LEDGER OR NOT
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" GUESTLEDGERCONFIG.CONFIG_ID AS ID", "", " GUESTLEDGERCONFIG INNER JOIN GUESTMASTER ON GUESTLEDGERCONFIG.CONFIG_GUESTID = GUEST_ID INNER JOIN LEDGERS ON GUESTLEDGERCONFIG.CONFIG_LEDGERID = LEDGERS.ACC_ID ", " AND GUEST_NAME = '" & CMBGUESTNAME.Text.Trim & "' AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & CMBNAME.Text.Trim & "' AND CONFIG_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(TXTMOBILENO, "Guest Details for Selected Ledger Already Added Below")
                bln = False
            End If
        End If

        If CMBGUESTNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBGUESTNAME, "Select Guest Name")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Customer Name")
            bln = False
        End If

        Return bln
    End Function

    Sub EDITROW()
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If gridbill.GetFocusedRowCellValue("ID") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = gridbill.GetFocusedRowCellValue("ID")
                CMBGUESTNAME.Text = gridbill.GetFocusedRowCellValue("GUESTNAME")
                CMBNAME.Text = gridbill.GetFocusedRowCellValue("NAME")
                TXTADDRESS.Text = gridbill.GetFocusedRowCellValue("ADDRESS")
                TXTMOBILENO.Text = gridbill.GetFocusedRowCellValue("MOBILENO")
                CMBGUESTNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        EDITROW()
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTLEDGERCONFIG.CONFIG_ID AS ID, GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, GUESTLEDGERCONFIG.CONFIG_ADDRESS AS [ADDRESS], ISNULL(GUESTLEDGERCONFIG.CONFIG_MOBILENO,'') AS MOBILENO ", "", " GUESTLEDGERCONFIG INNER JOIN GUESTMASTER ON GUESTLEDGERCONFIG.CONFIG_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN LEDGERS ON GUESTLEDGERCONFIG.CONFIG_LEDGERID = LEDGERS.Acc_id  ", " AND CONFIG_YEARID = " & YearId & " ORDER BY CONFIG_ID")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONFIG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            gridbilldetails.Focus()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()
        Try
            FILLGUESTNAME(CMBGUESTNAME, False)
            fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            CMBGUESTNAME.Text = ""
            CMBNAME.Text = ""
            TXTADDRESS.Clear()
            TXTMOBILENO.Clear()
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONFIG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub SAVE()
        Try

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Val(TXTNO.Text.Trim))
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(CMBGUESTNAME.Text.Trim)
            ALPARAVAL.Add(TXTADDRESS.Text.Trim)
            ALPARAVAL.Add(TXTMOBILENO.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            Dim OBJCONFIG As New CLsGuestLedgerConfig
            OBJCONFIG.alParaval = ALPARAVAL
            Dim INT As Integer = OBJCONFIG.SAVE()

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Call CMDDELETE_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMOBILENO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMOBILENO.Validated
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            SAVE()
            CLEAR()
            CMBGUESTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTADDRESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, False, " AND GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'Sundry Debtors'", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        EDITROW()
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub


            'DELETE FROM TABLE
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("ID"))
            Dim OBJCONFIG As New CLsGuestLedgerConfig
            OBJCONFIG.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJCONFIG.DELETE()

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class