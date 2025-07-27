
Imports BL

Public Class StageMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        'CHECK DUPLICATION
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" STAGEMASTER.STAGE_ID AS ID", "", " STAGEMASTER ", " AND STAGE_NAME = '" & TXTNAME.Text.Trim & "' AND STAGE_YEARID =  " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(TXTNAME, "Stage Name Already Added below")
                bln = False
            End If
        End If

        DT = OBJCMN.search(" STAGEMASTER.STAGE_ID AS ID", "", " STAGEMASTER ", " AND STAGE_NO = " & Val(TXTSTAGENO.Text.Trim) & " AND STAGE_YEARID =  " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(TXTSTAGENO, "Stage No Already Added below")
                bln = False
            End If
        End If
        '*******************************


        If TXTSTAGENO.Text.Trim.Length = 0 Then
            EP.SetError(TXTSTAGENO, "Enter Stage No")
            bln = False
        End If

        If TXTNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTNAME, "Enter Stage Name")
            bln = False
        End If

        If TXTCLOSING.Text.Trim.Length = 0 Then
            EP.SetError(TXTCLOSING, "Enter Closing %")
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
                TXTSTAGENO.Text = Val(gridbill.GetFocusedRowCellValue("STAGENO"))
                TXTNAME.Text = gridbill.GetFocusedRowCellValue("NAME")
                TXTCLOSING.Text = Val(gridbill.GetFocusedRowCellValue("CLOSING"))
                TXTSTAGENO.Focus()
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
            Dim DT As DataTable = OBJCMN.search(" STAGEMASTER.STAGE_ID AS ID, STAGEMASTER.STAGE_NO AS STAGENO, STAGEMASTER.STAGE_NAME AS NAME, STAGEMASTER.STAGE_CLOSING AS CLOSING", "", " STAGEMASTER ", " AND STAGE_YEARID =  " & YearId)
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STAGEMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            gridbilldetails.Focus()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            TXTSTAGENO.Clear()
            TXTNAME.Clear()
            TXTCLOSING.Clear()
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STAGEMASTER_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PACKAGE ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

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
            Dim OBJCONFIG As New ClsStageMaster

            ALPARAVAL.Add(Val(TXTNO.Text.Trim))
            ALPARAVAL.Add(Val(TXTSTAGENO.Text.Trim))
            ALPARAVAL.Add(TXTNAME.Text.Trim)
            ALPARAVAL.Add(Val(TXTCLOSING.Text.Trim))
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

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

    Private Sub TXTSTAGENO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSTAGENO.KeyPress
        numkeypress(e, TXTSTAGENO, Me)
    End Sub

    Private Sub TXTCLOSING_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLOSING.KeyPress
        numdotkeypress(e, TXTCLOSING, Me)
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
            Dim OBJSTAGE As New ClsStageMaster
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("ID"))
            ALPARAVAL.Add(YearId)


            OBJSTAGE.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJSTAGE.DELETE()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCLOSING_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCLOSING.Validated
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            SAVE()
            CLEAR()
            TXTSTAGENO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCLOSING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCLOSING.Validating
        Try
            If Val(TXTCLOSING.Text.Trim) > 100 Then
                e.Cancel = True
                MsgBox("% Cannot be Greater then 100", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class