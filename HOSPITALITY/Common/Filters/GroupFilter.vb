
Imports BL

Public Class GroupFilter

    Public frmstring As String
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value.Date)
        a2 = DatePart(DateInterval.Month, dtfrom.Value.Date)
        a3 = DatePart(DateInterval.Year, dtfrom.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value.Date)
        a12 = DatePart(DateInterval.Month, dtto.Value.Date)
        a13 = DatePart(DateInterval.Year, dtto.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub groupfilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillgrid()
    End Sub

    Sub fillgrid()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable

            dt = objclspo.search("  DISTINCT  group_primary as [Group Name],0  ", "", " GROUPMASTER ", " and GROUP_cmpid = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)

            If dt.Rows.Count > 0 Then
                gridbusrefno.DataSource = dt
                gridbusrefno.Columns.Insert(0, col)
                gridbusrefno.Columns(0).Width = 50
                gridbusrefno.Columns(1).Width = 240

                gridbusrefno.Columns(2).Visible = False
                gridbusrefno.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridacc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbusrefno.CellClick
        If e.RowIndex >= 0 Then
            With gridbusrefno.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i As Integer = 0 To gridbusrefno.RowCount - 1
                If gridbusrefno.CurrentRow.Index >= 0 Then
                    With gridbusrefno.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To gridbusrefno.RowCount - 1
                If gridbusrefno.CurrentRow.Index >= 0 Then
                    With gridbusrefno.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub Filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Filter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        chkdate.Checked = False
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub


    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        If txtName.Text.Trim <> "" Then
            Dim rowno, b As Integer
            fillgrid_search()
            rowno = 0
            For b = 1 To gridbusrefno.RowCount
                txtTempName.Text = gridbusrefno.Item(1, rowno).Value.ToString()
                txtTempName.SelectionStart = 0
                txtTempName.SelectionLength = txtName.TextLength
                If LCase(txtName.Text.Trim) <> LCase(txtTempName.SelectedText.Trim) Then
                    gridbusrefno.Rows.RemoveAt(rowno)
                Else
                    rowno = rowno + 1
                End If
            Next
        End If
    End Sub

    Private Sub dtfrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtfrom.Validating
        If Not datecheck(dtfrom.Value.Date) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub dtto_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtto.Validating
        If Not datecheck(dtto.Value.Date) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub


    Sub fillgrid_search()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable
            dt = objclspo.search("  DISTINCT  GROUP_primary as [Group Name],0  ", "", " GROUPMASTER ", " and GROUP_cmpid = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                gridbusrefno.DataSource = dt

                gridbusrefno.Columns(0).Width = 50
                gridbusrefno.Columns(1).Width = 240
                gridbusrefno.Columns(2).Visible = False

                gridbusrefno.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim i As Integer


            Dim objgroup As New GRoupWiseTransdesign

            Dim CONDITION As String = ""
            If chkdetails.CheckState = CheckState.Checked Then
                For i = 0 To gridbusrefno.RowCount - 1
                    If gridbusrefno.Item(0, i).Value = True Then
                        If CONDITION = "" Then
                            CONDITION = CONDITION & " AND ((PRIMARYGROUP= '" & gridbusrefno.Item(1, i).Value.ToString & "')"
                        Else
                            CONDITION = CONDITION & " OR (PRIMARYGROUP= '" & gridbusrefno.Item(1, i).Value.ToString & "')"
                        End If
                    End If
                Next
                CONDITION = CONDITION & ")"
                Dim OBJRPT As New clsReportDesigner("GROUP WISE TRANSACTION", System.AppDomain.CurrentDomain.BaseDirectory & "GROUP WISE TRANSACTION.xlsx", 2)
                OBJRPT.GROUP_TRANS_DETAILS_EXCEL(CONDITION, CmpId, Locationid, YearId)
                Exit Sub
            End If

            If chkdetails.CheckState = CheckState.Checked Then
                objgroup.frmstring = "GroupWiseTransactionDetails"
                ' getFromToDate()
                objgroup.strsearch = ""
                For i = 0 To gridbusrefno.RowCount - 1
                    If gridbusrefno.Item(0, i).Value = True Then
                        If objgroup.strsearch = "" Then
                            objgroup.strsearch = objgroup.strsearch & "  {REGISTER.PRIMARYGROUP}= '" & gridbusrefno.Item(1, i).Value.ToString & "'"
                        Else
                            objgroup.strsearch = objgroup.strsearch & " or {REGISTER.PRIMARYGROUP}= '" & gridbusrefno.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next


            Else
                objgroup.frmstring = "GroupWiseTransaction"
                ' getFromToDate()
                objgroup.strsearch = ""
                For i = 0 To gridbusrefno.RowCount - 1
                    If gridbusrefno.Item(0, i).Value = True Then
                        If objgroup.strsearch = "" Then
                            objgroup.strsearch = objgroup.strsearch & "  {REGISTER.PRIMARYGROUP}= '" & gridbusrefno.Item(1, i).Value.ToString & "'"
                        Else
                            objgroup.strsearch = objgroup.strsearch & " or {REGISTER.PRIMARYGROUP}= '" & gridbusrefno.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
            End If

            If objgroup.strsearch = "" Then
                MsgBox("NO NAME BEEN SELECTED")
                Exit Sub
            Else
                objgroup.strsearch = "(" & objgroup.strsearch & ")"
            End If

            If objgroup.strsearch <> "" Then
                objgroup.strsearch = objgroup.strsearch & " AND {REGISTER.ACC_CMPID}= " & CmpId & " AND  {REGISTER.YEARID}= " & YearId
            End If

            If chkdate.Checked = True Then
                objgroup.FROMDATE = dtfrom.Value.Date
                objgroup.TODATE = dtto.Value.Date
            Else
                objgroup.FROMDATE = AccFrom.Date
                objgroup.TODATE = AccTo.Date
            End If

            objgroup.MdiParent = MDIMain
            objgroup.Show()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        If chkdate.Checked = True Then
            GroupBox2.Enabled = True
            dtfrom.Enabled = True
            dtto.Enabled = True
        Else
            GroupBox2.Enabled = False
            dtfrom.Enabled = False
            dtto.Enabled = False
        End If
    End Sub

End Class