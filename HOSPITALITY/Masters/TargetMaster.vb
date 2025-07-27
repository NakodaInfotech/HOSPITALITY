
Imports BL

Public Class TargetMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPTARGETNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLCMB()
        Try
            FILLBOOKEDBY(CMBNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Sub clear()
        EP.Clear()
        CMBNAME.Text = ""
        CMBMONTH.SelectedIndex = 0
        CMBTARGETON.SelectedIndex = 0
        TXTTARGETS.Clear()
        TXTINCENTIVES.Clear()
        TXTALIGIBILITY.Clear()

        GETMAXNO_TARGETNO()
    End Sub

    Sub GETMAXNO_TARGETNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(TARGET_NO),0) + 1 ", "TARGETMASTER", " AND TARGET_cmpid=" & CmpId & " AND TARGET_LOCATIONid=" & Locationid & " AND TARGET_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSRNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub MonthlyTargetMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Or chkchange.CheckState = CheckState.Checked Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Delete
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MonthlyTargetMaster_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub MonthlyTargetMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EMPLOYEE MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            FILLCMB()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim OBJSAL As New ClsTargetMaster()
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPTARGETNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSAL.alParaval = ALPARAVAL
                dt = OBJSAL.GETTARGET()

                If dt.Rows.Count > 0 Then

                    TXTSRNO.Text = TEMPTARGETNO
                    SALDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("DATE")).Date

                    CMBNAME.Text = dt.Rows(0).Item("BOOKEDBY")
                    CMBMONTH.Text = dt.Rows(0).Item("MONTH")
                    CMBTARGETON.Text = dt.Rows(0).Item("TARGETON")
                    TXTTARGETS.Text = Format(Val(dt.Rows(0).Item("TARGET")), "0.00")
                    TXTINCENTIVES.Text = Format(Val(dt.Rows(0).Item("INCENTIVES")), "0.00")
                    TXTALIGIBILITY.Text = Format(Val(dt.Rows(0).Item("ALIGIBILITY")), "0.00")
                    chkchange.CheckState = CheckState.Checked
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Target Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJAGENT As New ClsTargetMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPTARGETNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJAGENT.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJAGENT.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
       
    Private Sub SALdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SALDATE.Validating
        If Not datecheck(SALDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(SALDATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBMONTH.Text.Trim)
            alParaval.Add(CMBTARGETON.Text.Trim)
            alParaval.Add(Val(TXTTARGETS.Text.Trim))
            alParaval.Add(Val(TXTINCENTIVES.Text.Trim))
            alParaval.Add(Val(TXTALIGIBILITY.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim OBJSAL As New ClsTargetMaster
            OBJSAL.alParaval = alParaval
            Dim INTRES As Integer

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                INTRES = OBJSAL.save()
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPTARGETNO)
                Dim INT As Integer = OBJSAL.update()
                MsgBox("Details Updated")
            End If

            clear()
            edit = False
            CMBNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If edit = False Then
            'CHECKING WHETHER TARGET OF THE EMPLOYUEE FOR THE MONTH IS PRESENT OR NOT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TARGET_NO", "", " TARGETMASTER INNER JOIN BOOKEDBYMASTER ON TARGETMASTER.TARGET_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_id AND TARGETMASTER.TARGET_CMPID = BOOKEDBYMASTER.BOOKEDBY_cmpid AND TARGETMASTER.TARGET_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_locationid AND TARGETMASTER.TARGET_YEARID = BOOKEDBYMASTER.BOOKEDBY_yearid ", " AND BOOKEDBY_NAME ='" & CMBNAME.Text.Trim & "' AND TARGET_MONTH = '" & CMBMONTH.Text.Trim & "' AND TARGET_CMPID = " & CmpId & " AND TARGET_LOCATIONID = " & Locationid & " AND TARGET_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                EP.SetError(CMBMONTH, "Target for selected Month Already Present")
                bln = False
            End If
        End If
        If CMBTARGETON.Text.Trim.Length = 0 Then
            EP.SetError(CMBTARGETON, "Enter Proper Target")
            bln = False
        End If

        If TXTTARGETS.Text.Trim.Length = 0 Then
            EP.SetError(TXTTARGETS, "Enter Target")
            bln = False
        End If

        If TXTINCENTIVES.Text.Trim.Length = 0 Then
            EP.SetError(TXTINCENTIVES, "Enter Incentives")
            bln = False
        End If

        If TXTALIGIBILITY.Text.Trim.Length = 0 Then
            EP.SetError(TXTALIGIBILITY, "Enter Aligibility")
            bln = False
        End If

        If CMBMONTH.Text.Trim.Length = 0 Then
            EP.SetError(CMBMONTH, "Select Month")
            bln = False
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Employee's Name")
            bln = False
        End If


        If Not datecheck(SALDATE.Value) Then
            EP.SetError(SALDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln

    End Function

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLBOOKEDBY(CMBNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub DELETE()
    '    Try
    '        If USERDELETE = False Then
    '            MsgBox("Insufficient Rights")
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then BOOKEDBYvalidate(CMBNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTALIGIBILITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTALIGIBILITY.KeyPress
        numdotkeypress(e, TXTALIGIBILITY, Me)
    End Sub

    Private Sub TXTINCENTIVES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINCENTIVES.KeyPress
        numdotkeypress(e, TXTINCENTIVES, Me)
    End Sub

    Private Sub TXTTARGETS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTARGETS.KeyPress
        numdotkeypress(e, TXTTARGETS, Me)
    End Sub
End Class