
Imports BL

Public Class CancelPolicyMaster

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                If FRMSTRING = "POLICY" Then
                    dt = objclscommon.search("POLICY_name", "", "POLICYMaster", " and POLICY_name = '" & txtname.Text.Trim & "' and POLICY_cmpid =" & CmpId & " and POLICY_Locationid =" & Locationid & " and POLICY_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Policy Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "NOTES" Then
                    dt = objclscommon.search("NOTE_name", "", "NOTEMaster", " and NOTE_name = '" & txtname.Text.Trim & "' and NOTE_cmpid = " & CmpId & " and NOTE_Locationid = " & Locationid & " and NOTE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Note Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "EXCLUSIONS" Then
                    dt = objclscommon.search("EXCLUSION_name", "", "EXCLUSIONMaster", " and EXCLUSION_name = '" & txtname.Text.Trim & "' and EXCLUSION_cmpid = " & CmpId & " and EXCLUSION_Locationid = " & Locationid & " and EXCLUSION_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("EXCLUSION Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                ElseIf FRMSTRING = "INCLUSIONS" Then
                    dt = objclscommon.search("INCLUSION_name", "", "INCLUSIONMaster", " and INCLUSION_name = '" & txtname.Text.Trim & "' and INCLUSION_cmpid = " & CmpId & " and INCLUSION_Locationid = " & Locationid & " and INCLUSION_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("INCLUSION Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                End If
            End If
            pcase(txtname)
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If FRMSTRING = "POLICY" Then
                Dim OBJPOLICY As New ClsCancelPolicyMaster
                OBJPOLICY.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJPOLICY.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJPOLICY.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "NOTES" Then
                Dim OBJNOTES As New ClsNoteMaster
                OBJNOTES.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJNOTES.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJNOTES.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "EXCLUSIONS" Then
                Dim OBJEXCLUSIONS As New ClsEXCLUSIONMaster
                OBJEXCLUSIONS.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJEXCLUSIONS.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJEXCLUSIONS.update()
                    MsgBox("Details Updated")
                End If

            ElseIf FRMSTRING = "INCLUSIONS" Then
                Dim OBJINCLUSIONS As New ClsINCLUSIONMaster
                OBJINCLUSIONS.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJINCLUSIONS.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJINCLUSIONS.update()
                    MsgBox("Details Updated")
                End If
            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Name")
            bln = False
        End If

        If txtremarks.Text.Trim.Length = 0 Then
            EP.SetError(txtremarks, "Fill Remarks")
            bln = False
        End If

        If Not VALIDATENAME() Then
            EP.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub CancelPolicyMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub CancelPolicyMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DT As New DataTable
            Dim OBJCOMMON As New ClsCommon
            txtname.Text = TempName

            If FRMSTRING = "POLICY" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'POLICY MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Policy Master"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" POLICY_name, POLICY_REMARKS", "", "POLICYMaster", " and POLICY_id = " & TempID & " and POLICY_cmpid = " & CmpId & " and POLICY_locationid = " & Locationid & " and POLICY_yearid = " & YearId)


            ElseIf FRMSTRING = "NOTES" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'NOTE MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Note Master"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" NOTE_name, NOTE_REMARKS", "", "NOTEMaster", " and NOTE_id = " & TempID & " and NOTE_cmpid = " & CmpId & " and NOTE_locationid = " & Locationid & " and NOTE_yearid = " & YearId)

            ElseIf FRMSTRING = "EXCLUSIONS" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EXCLUSION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "EXCLUSION Master"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" EXCLUSION_name, EXCLUSION_REMARKS", "", "EXCLUSIONMaster", " and EXCLUSION_id = " & TempID & " and EXCLUSION_cmpid = " & CmpId & " and EXCLUSION_locationid = " & Locationid & " and EXCLUSION_yearid = " & YearId)

            ElseIf FRMSTRING = "INCLUSIONS" Then

                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'INCLUSION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "INCLUSION Master"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then DT = OBJCOMMON.search(" INCLUSION_name, INCLUSION_REMARKS", "", "INCLUSIONMaster", " and INCLUSION_id = " & TempID & " and INCLUSION_cmpid = " & CmpId & " and INCLUSION_locationid = " & Locationid & " and INCLUSION_yearid = " & YearId)


            End If
            If edit = True Then
                txtname.Text = DT.Rows(0).Item(0)
                txtremarks.Text = DT.Rows(0).Item(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TempID)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim DT As DataTable
                If FRMSTRING = "POLICY" Then
                    Dim OBJCANCEL As New ClsCancelPolicyMaster
                    OBJCANCEL.alParaval = ALPARAVAL
                    DT = OBJCANCEL.DELETE
                ElseIf FRMSTRING = "NOTES" Then
                    Dim OBJNOTES As New ClsNoteMaster
                    OBJNOTES.alParaval = ALPARAVAL
                    DT = OBJNOTES.DELETE
                ElseIf FRMSTRING = "EXCLUSIONS" Then
                    Dim OBJEXCLUSIONS As New ClsEXCLUSIONMaster
                    OBJEXCLUSIONS.alParaval = ALPARAVAL
                    DT = OBJEXCLUSIONS.DELETE
                ElseIf FRMSTRING = "INCLUSIONS" Then
                    Dim OBJINCLUSIONS As New ClsINCLUSIONMaster
                    OBJINCLUSIONS.alParaval = ALPARAVAL
                    DT = OBJINCLUSIONS.DELETE
                End If
            If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class