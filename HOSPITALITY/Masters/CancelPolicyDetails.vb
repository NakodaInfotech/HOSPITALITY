
Imports BL

Public Class CancelPolicyDetails

    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CancelPolicyDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for edit
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.KeyCode = Windows.Forms.Keys.A) Then   'for Exit
            showform(False, "", 0)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CancelPolicyDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "POLICY" Then
                Me.Text = "Cancellation Policy Details"
            ElseIf FRMSTRING = "NOTES" Then
                Me.Text = "Notes Details"
            ElseIf FRMSTRING = "INCLUSIONS" Then
                Me.Text = "Inclusions Details"
            ElseIf FRMSTRING = "EXCLUSIONS" Then
                Me.Text = "Exclusions Details"
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If FRMSTRING = "POLICY" Then
            dttable = objClsCommon.search(" POLICY_name, POLICY_id", "", "POLICYmaster", " and POLICY_cmpid = " & CmpId & " and POLICY_Locationid = " & Locationid & " and POLICY_Yearid = " & YearId)
        ElseIf FRMSTRING = "NOTES" Then
            dttable = objClsCommon.search(" NOTE_name, NOTE_id", "", "NOTEmaster", " and NOTE_cmpid = " & CmpId & " and NOTE_Locationid = " & Locationid & " and NOTE_Yearid = " & YearId)
        ElseIf FRMSTRING = "INCLUSIONS" Then
            dttable = objClsCommon.search(" INCLUSION_name, INCLUSION_id", "", "INCLUSIONmaster", " and INCLUSION_cmpid = " & CmpId & " and INCLUSION_Locationid = " & Locationid & " and INCLUSION_Yearid = " & YearId)
        ElseIf FRMSTRING = "EXCLUSIONS" Then
            dttable = objClsCommon.search(" EXCLUSION_name, EXCLUSION_id", "", "EXCLUSIONmaster", " and EXCLUSION_cmpid = " & CmpId & " and EXCLUSION_Locationid = " & Locationid & " and EXCLUSION_Yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"

        gridgroup.Columns(0).Width = 250
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try
            Dim OBJPOLICY As New CancelPolicyMaster
            OBJPOLICY.edit = editval
            OBJPOLICY.MdiParent = MDIMain
            OBJPOLICY.FRMSTRING = FRMSTRING
            OBJPOLICY.TempName = name
            OBJPOLICY.TempID = id
            OBJPOLICY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtcmp_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcmp.Validated
        Dim rowno, b As Integer

        fillgrid()
        rowno = 0
        For b = 1 To gridgroup.RowCount
            txttempname.Text = gridgroup.Item(0, rowno).Value.ToString()
            txttempname.SelectionStart = 0
            txttempname.SelectionLength = txtcmp.TextLength
            If LCase(txtcmp.Text.Trim) <> LCase(txttempname.SelectedText.Trim) Then
                gridgroup.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub
End Class