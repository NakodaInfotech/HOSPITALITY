
Imports BL

Public Class datefilter

    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public frmstring As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub filter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillgrid()
        dtfrom.Value = AccFrom.Date
        dtto.Value = AccTo.Date
    End Sub

    Sub fillgrid()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable
            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Or frmstring = "PayamentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "payableoutstanding" Or frmstring = "payableoutstandingsummary" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and dbo.GROUPMASTER.group_secondary = 'Sundry Creditors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & "  order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "saledetails" Or frmstring = "salesummary" Or frmstring = "ReceiptDetails" Or frmstring = "receivableoutstanding" Or frmstring = "receivableoutstandingsummary" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and dbo.GROUPMASTER.group_secondary = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & "  order by dbo.LEDGERS.Acc_cmpname")
            End If
            If dt.Rows.Count > 0 Then
                gridledger.DataSource = dt
                gridledger.Columns.Insert(0, col)
                gridledger.Columns(0).Width = 50
                gridledger.Columns(1).Width = 250
                gridledger.Columns(2).Visible = False
                gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridacc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridledger.CellClick
        If e.RowIndex >= 0 Then
            With gridledger.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkdate.Checked = True Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        If chkall.Checked = True Then
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To gridledger.RowCount - 1
                If gridledger.CurrentRow.Index >= 0 Then
                    With gridledger.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub Filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdShowReport_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
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

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Validated
        Dim rowno, b As Integer
        fillgrid_search()
        rowno = 0
        For b = 1 To gridledger.RowCount
            txtTempName.Text = gridledger.Item(1, rowno).Value.ToString()
            txtTempName.SelectionStart = 0
            txtTempName.SelectionLength = txtName.TextLength
            If LCase(txtName.Text.Trim) <> LCase(txtTempName.SelectedText.Trim) Then
                gridledger.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Sub fillgrid_search()

        Try
            Dim objclspo As New ClsCommon
            Dim dt As DataTable
            If frmstring = "purchasedetails" Or frmstring = "purchasesummary" Or frmstring = "PayamentDetails" Or frmstring = "AdvancesPaidReport" Or frmstring = "payableoutstanding" Or frmstring = "payableoutstandingsummary" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and dbo.GROUPMASTER.group_secondary = 'Sundry Creditors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & "  order by dbo.LEDGERS.Acc_cmpname")
            ElseIf frmstring = "saledetails" Or frmstring = "salesummary" Or frmstring = "ReceiptDetails" Or frmstring = "receivableoutstanding" Or frmstring = "receivableoutstandingsummary" Then
                dt = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " and dbo.GROUPMASTER.group_secondary = 'Sundry Debtors' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & "  order by dbo.LEDGERS.Acc_cmpname")
            End If
            If dt.Rows.Count > 0 Then
                gridledger.DataSource = dt
                'gridledger.Columns.Insert(0, col)
                gridledger.Columns(0).Width = 50
                gridledger.Columns(1).Width = 250
                gridledger.Columns(2).Width = 50
                gridledger.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                gridledger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim i As Integer
            getFromToDate()

            If frmstring = "payableoutstanding" Or frmstring = "payableoutstandingsummary" Then
                Dim objpur As New payabledesign
                objpur.strsearch = ""
                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objpur.strsearch = "" Then
                            objpur.strsearch = objpur.strsearch & "  {ledgers.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        Else
                            objpur.strsearch = objpur.strsearch & " or {ledgers.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If objpur.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                Else
                    objpur.strsearch = "(" & objpur.strsearch & ")"
                End If

                objpur.strsearch = objpur.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"


                If frmstring = "payableoutstandingsummary" Then
                    objpur.strsumm = "Summary"
                Else
                    objpur.strsearch = objpur.strsearch & " and {@bal}<>0"
                    objpur.strsumm = ""
                End If
                objpur.MdiParent = MDIMain
                objpur.Show()
            ElseIf frmstring = "receivableoutstanding" Or frmstring = "receivableoutstandingsummary" Then

                Dim objpur As New receivabledesign
                objpur.strsearch = ""
                For i = 0 To gridledger.RowCount - 1
                    If gridledger.Item(0, i).Value = True Then
                        If objpur.strsearch = "" Then
                            objpur.strsearch = objpur.strsearch & "  {report_sp_receivableoutstanding.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        Else
                            objpur.strsearch = objpur.strsearch & " or {report_sp_receivableoutstanding.Acc_cmpname}= '" & gridledger.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next

                If chkdate.Checked = True Then
                    objpur.FROMDATE = dtfrom.Value.Date
                    objpur.TODATE = dtto.Value.Date
                Else
                    objpur.FROMDATE = AccFrom.Date
                    objpur.TODATE = AccTo.Date
                End If
                'objpur.strsearch = objpur.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                If objpur.strsearch = "" Then
                    MsgBox("NO NAME BEEN SELECTED")
                    Exit Sub
                Else
                    objpur.strsearch = "(" & objpur.strsearch & ")"
                End If
                objpur.strsearch = objpur.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"

                If frmstring = "receivableoutstandingsummary" Then
                    objpur.strsumm = "Summary"
                Else
                    objpur.strsearch = objpur.strsearch & " and {@JAMA}<>0"

                    objpur.strsumm = ""
                End If
                objpur.MdiParent = MDIMain
                objpur.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class