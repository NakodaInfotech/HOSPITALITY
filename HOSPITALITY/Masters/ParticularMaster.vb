Imports BL

Public Class ParticularMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    ''  Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public EDIT As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                    '  If frmString = "CATEGORY" Then
                    dt = objclscommon.search("particular_name", "", " PARTICULARMASTER ", " and particular_name = '" & txtname.Text.Trim & "' and particular_cmpid =" & CmpId & " and particular_locationid =" & Locationid & " and particular_yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Particular Name Already Exists", MsgBoxStyle.Critical, "HOSPITALITY")
                        e.Cancel = True
                    End If

                End If
            End If
            uppercase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Saving
            Call CMDDELETE_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub ParticularMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster
            If EDIT = True Then dttable = objCommon.search(" particular_name, particular_remarks", "", "PARTICULARMASTER", " and particular_id = " & TempID & " and particular_cmpid = " & CmpId & " and particular_locationid = " & Locationid & " and particular_yearid = " & YearId)
            txtname.Text = TempName

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtremarks.Text = dttable.Rows(0).Item(1).ToString
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex

        End Try
    End Sub


    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = False Then Exit Sub
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If MsgBox("Wish to Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJCMN As New ClsCommon
                Dim DT = OBJCMN.Execute_Any_String("DELETE FROM PARTICULARMASTER WHERE particular_name = '" & TempName & "' AND particular_yearid= " & YearId, "", "")
                MsgBox("Entry Deleted Successfully")
                EDIT = False
                clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(UCase(txtname.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJPARTICULA As New ClsParticularMaster
            OBJPARTICULA.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJPARTICULA.save()
                MsgBox("Detail Added")
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficent Rights")
                    Exit Sub
                End If
                alParaval.Add(TempID)
                IntResult = OBJPARTICULA.Update()
                EDIT = False
                MsgBox("Detail Updated")
            End If
            clear()
            txtname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class