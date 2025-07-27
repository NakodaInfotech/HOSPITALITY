Imports BL

Public Class ImpDateDetail
    Public frmstring As String      'Used for form Category or GRade
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ImpDateDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If

            If frmstring = "IMPDATE" Then
                Me.Text = "Imp Date Master"
            End If

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ImpDateDetail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Then   'for New
            showform(False, "", 0, "")
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "IMPDATE" Then
            dttable = objClsCommon.search(" ISNULL(IMPDATEMASTER.IMP_name,'') AS NAME,IMP_ID , IMPDATEMASTER.IMP_FROMDATE AS FROMDATE, IMPDATEMASTER.IMP_TODATE AS TODATE ", "", " IMPDATEMASTER", " and IMP_yearid = " & YearId)
        ElseIf frmstring = "BLOCKDATE" Then
            dttable = objClsCommon.search(" COUNTRYMASTER.country_name AS NAME,COUNTRYMASTER.country_ID AS ID,BLOCKDATEMASTER.BLOCK_FROMDATE AS FROMDATE, BLOCKDATEMASTER.BLOCK_TODATE AS TODATE ", "", " BLOCKDATEMASTER LEFT OUTER JOIN COUNTRYMASTER ON BLOCKDATEMASTER.BLOCK_yearid = COUNTRYMASTER.country_yearid AND BLOCKDATEMASTER.BLOCK_COUNTRYID = COUNTRYMASTER.country_id", " and BLOCK_yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"
        gridgroup.Columns(0).Width = 200
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(2).HeaderText = "FROMDATE"
        gridgroup.Columns(2).Width = 90
        gridgroup.Columns(3).HeaderText = "TODATE"
        gridgroup.Columns(3).Width = 90
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(1, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer, ByVal abbr As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If frmstring = "IMPDATE" Then
                Dim objcitymaster As New ImpDateMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.frmstring = frmstring
                objcitymaster.tempname = name
                objcitymaster.tempid = id
                objcitymaster.Show()
            ElseIf frmstring = "BLOCKDATE" Then
                Dim objcitymaster As New BlockDateMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.frmstring = frmstring
                objcitymaster.tempname = name
                objcitymaster.tempid = id
                objcitymaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "", 0, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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