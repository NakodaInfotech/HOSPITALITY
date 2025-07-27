
Imports BL

Public Class UnitDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub UnitDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then               'FOR new
            showform(False, "", "")
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            If frmstring = "UNIT" Then
                DTROW = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
            ElseIf frmstring = "TAXMASTER" Then
                DTROW = USERRIGHTS.Select("FormName = 'TAX MASTER'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Dim dttable As DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "UNIT" Then

            dttable = objClsCommon.search(" Unit_name, Unit_abbr, Unit_id", "", "Unitmaster", " and unit_cmpid = " & CmpId & " and unit_LOCATIONid = " & Locationid & " and unit_YEARid = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "Unit Name"
            gridgroup.Columns(1).HeaderText = "Abbr"

            gridgroup.Columns(0).Width = 180
            gridgroup.Columns(1).Width = 180
            gridgroup.Columns(2).Visible = False

        ElseIf frmstring = "PACKINGUNIT" Then

            dttable = objClsCommon.search(" PackingUnit_name, PackingUnit_abbr, PackingUnit_id", "", "PackingUnitmaster", " and Packingunit_cmpid = " & CmpId & " and Packingunit_LOCATIONid = " & Locationid & " and Packingunit_YEARid = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "Unit Name"
            gridgroup.Columns(1).HeaderText = "Abbr"

            gridgroup.Columns(0).Width = 180
            gridgroup.Columns(1).Width = 180
            gridgroup.Columns(2).Visible = False

        ElseIf frmstring = "TAXMASTER" Then

            dttable = objClsCommon.search(" tax_name, tax_abbr, tax_id", "", "Taxmaster", " and tax_cmpid = " & CmpId & " and tax_LOCATIONid = " & Locationid & " and tax_YEARid = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "Tax Name"
            gridgroup.Columns(1).HeaderText = "Abbr"

            gridgroup.Columns(0).Width = 180
            gridgroup.Columns(1).Width = 180
            gridgroup.Columns(2).Visible = False

        ElseIf frmstring = "SUBPACKINGUNIT" Then

            dttable = objClsCommon.search(" SubPackingUnit_name, SubPackingUnit_abbr, SubPackingUnit_id", "", "SubPackingUnitmaster", " and SubPackingunit_cmpid = " & CmpId & " and SubPackingunit_LOCATIONid = " & Locationid & " and SubPackingunit_YEARid = " & YearId)

            gridgroup.DataSource = dttable
            gridgroup.Columns(0).HeaderText = "Unit Name"
            gridgroup.Columns(1).HeaderText = "Abbr"

            gridgroup.Columns(0).Width = 180
            gridgroup.Columns(1).Width = 180
            gridgroup.Columns(2).Visible = False

        End If
        gridgroup.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.Automatic
        If gridgroup.RowCount > 0 Then gridgroup.FirstDisplayedScrollingRowIndex = gridgroup.RowCount - 1

    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objunitmaster As New UnitMaster
            objunitmaster.edit = editval
            objunitmaster.frmString = frmstring
            objunitmaster.MdiParent = MDIMain
            objunitmaster.Tempname = name
            objunitmaster.tempid = id
            objunitmaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgroup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgroup.CellDoubleClick
        Try
            showform(True, gridgroup.Item(0, gridgroup.CurrentRow.Index).Value.ToString, gridgroup.Item(2, gridgroup.CurrentRow.Index).Value.ToString)
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

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "", 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class