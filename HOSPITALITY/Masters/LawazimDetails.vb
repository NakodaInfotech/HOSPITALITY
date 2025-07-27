Imports BL


Public Class LawazimDetails
    Public frmstring As String      'Used for form Category or GRade
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub LawazimDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If
            If frmstring = "LAWAZIMMASTER" Then
                Me.Text = "Lawazim Master"
            ElseIf frmstring = "VISA" Then
                Me.Text = "Visa Master"
            ElseIf frmstring = "TAX" Then
                Me.Text = "Taxes Of Country Master"
            ElseIf frmstring = "ADDSERVICE" Then
                Me.Text = "Service Master"
            ElseIf frmstring = "MISCEXP" Then
                Me.Text = "Misc Exp Master"
            ElseIf frmstring = "MEALMASTER" Then
                Me.Text = "Meal Plan Master"
            ElseIf frmstring = "TRANSPORT" Then
                Me.Text = "Transport Master"
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

    Private Sub LawazimDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
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

        If frmstring = "LAWAZIMMASTER" Then
            dttable = objClsCommon.search(" LWZM_name, LWZM_id,isnull(LWZM_adult,0),isnull(LWZM_child,0),isnull(LWZM_infant,0) ", "", " LAWAZIMMASTER", " and LWZM_cmpid = " & CmpId & " and LWZM_locationid = " & Locationid & " and LWZM_yearid = " & YearId)
        ElseIf frmstring = "VISA" Then
            dttable = objClsCommon.search(" VISA_name, VISA_id,isnull(VISA_adult,0),isnull(VISA_child,0),isnull(VISA_infant,0) ", "", " VISAMASTER", " and VISA_yearid = " & YearId)
        ElseIf frmstring = "TAX" Then
            dttable = objClsCommon.search(" TAX_name, TAX_id,ISNULL(TAX_ADULT,0),ISNULL(TAX_CHILD,0),ISNULL(TAX_INFANT,0) ", "", " COUNTRYTAXMASTER", " and TAX_yearid = " & YearId)
        ElseIf frmstring = "ADDSERVICE" Then
            dttable = objClsCommon.search(" SERVICE_name, SERVICE_id,ISNULL(SERVICE_ADULT,0),ISNULL(SERVICE_CHILD,0),ISNULL(SERVICE_INFANT,0) ", "", " SERVICEMASTER", " and SERVICE_yearid = " & YearId)
        ElseIf frmstring = "MISCEXP" Then
            dttable = objClsCommon.search(" MISC_name, MISC_id,ISNULL(MISC_ADULT,0),ISNULL(MISC_CHILD,0),ISNULL(MISC_INFANT,0) ", "", " MISCEXPMASTER", " and MISC_yearid = " & YearId)
        ElseIf frmstring = "MEALMASTER" Then
            dttable = objClsCommon.search(" PLANMASTER.PLAN_NAME AS NAME,MEALCONGIGMASTER.MEAL_ID, ISNULL(MEALCONGIGMASTER.MEAL_adult, 0) AS ADULT, ISNULL(MEALCONGIGMASTER.MEAL_child, 0) AS CHILD, ISNULL(MEALCONGIGMASTER.MEAL_infant, 0) AS INFANT ", "", " MEALCONGIGMASTER LEFT OUTER JOIN PLANMASTER ON MEALCONGIGMASTER.MEAL_yearid = PLANMASTER.PLAN_YEARID AND MEALCONGIGMASTER.MEAL_mealid = PLANMASTER.PLAN_ID", " and MEAL_yearid = " & YearId)
        ElseIf frmstring = "TRANSPORT" Then
            dttable = objClsCommon.search(" TRANSPORTMASTER.TRANS_NAME AS NAME, TRANSPORTMASTER.TRANS_id AS ID,ISNULL(TRANSPORTMASTER.TRANS_adult, 0) AS ADULT, ISNULL(TRANSPORTMASTER.TRANS_child, 0) AS CHILD, ISNULL(TRANSPORTMASTER.TRANS_infant, 0) AS INFANT", "", " TRANSPORTMASTER LEFT OUTER JOIN CURRENCYMASTER ON TRANSPORTMASTER.TRANS_yearid = CURRENCYMASTER.cur_yearid AND TRANSPORTMASTER.TRANS_currencyid = CURRENCYMASTER.cur_id", " and TRANS_yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"
        gridgroup.Columns(0).Width = 230
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(2).HeaderText = "Adult"
        gridgroup.Columns(2).Width = 60
        gridgroup.Columns(3).HeaderText = "Child"
        gridgroup.Columns(3).Width = 60
        gridgroup.Columns(4).HeaderText = "Infant"
        gridgroup.Columns(4).Width = 60
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
            If frmstring = "LAWAZIMMASTER" Or frmstring = "VISA" Or frmstring = "TAX" Or frmstring = "ADDSERVICE" Or frmstring = "MISCEXP" Or frmstring = "TRANSPORT" Then
                Dim objcitymaster As New LawazimMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.frmstring = frmstring
                objcitymaster.tempname = name
                objcitymaster.tempid = id
                objcitymaster.Show()
            ElseIf frmstring = "MEALMASTER" Then
                Dim objcitymaster As New MealConfigurator
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