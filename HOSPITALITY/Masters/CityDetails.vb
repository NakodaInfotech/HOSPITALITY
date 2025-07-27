
Imports BL

Public Class CityDetails

    Public frmstring As String      'Used for form Category or GRade
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CityDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub CityDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If

            If frmstring = "CITYMASTER" Then
                Me.Text = "CITY MASTER"
            ElseIf frmstring = "GIFTMASTER" Then
                Me.Text = "HADIYAH / GIFT MASTER"
            ElseIf frmstring = "LOGINMASTER" Then
                Me.Text = "LOGIN MASTER"
            ElseIf frmstring = "IDMASTER" Then
                Me.Text = "ID MASTER"
            ElseIf frmstring = "AREAMASTER" Then
                Me.Text = "AREA MASTER"
            ElseIf frmstring = "FORMTYPE" Then
                Me.Text = "FORm MASTER"
            ElseIf frmstring = "STATEMASTER" Then
                Me.Text = "STATE MASTER"
            ElseIf frmstring = "COUNTRYMASTER" Then
                Me.Text = "COUNTRYMASTER"
            ElseIf frmstring = "DOCUMENT" Then
                Me.Text = "DOCUMENT"
            ElseIf frmstring = "NATIONALITY" Then
                Me.Text = "NATIONALITY MASTER"
            ElseIf frmstring = "CURRENCYMASTER" Then
                Me.Text = "CURRENCY MASTER"
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

    Sub fillgrid()

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CITYMASTER" Then
            dttable = objClsCommon.search(" city_name, city_id,''", "", "citymaster", " and city_cmpid = " & CmpId & " and city_locationid = " & Locationid & " and city_yearid = " & YearId)
        ElseIf frmstring = "LOGINMASTER" Then
            dttable = objClsCommon.search(" login_name, login_id,''", "", " loginmaster", " and login_cmpid = " & CmpId & " and login_locationid = " & Locationid & " and login_yearid = " & YearId)
        ElseIf frmstring = "IDMASTER" Then
            dttable = objClsCommon.search(" ID_name, ID_id,''", "", " IDmaster", " and ID_cmpid = " & CmpId & " and ID_locationid = " & Locationid & " and ID_yearid = " & YearId)
        ElseIf frmstring = "AREAMASTER" Then
            dttable = objClsCommon.search(" area_name, area_id,''", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_locationid = " & Locationid & " and area_yearid = " & YearId)
        ElseIf frmstring = "FORMTYPE" Then
            dttable = objClsCommon.search(" FORm_name, FORm_id,''", "", "formtype", " and FORm_cmpid = " & CmpId & " and FORm_locationid = " & Locationid & " and FORm_yearid = " & YearId)
        ElseIf frmstring = "STATEMASTER" Then
            dttable = objClsCommon.search(" state_name, state_id,''", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_locationid = " & Locationid & " and state_yearid = " & YearId)
        ElseIf frmstring = "COUNTRYMASTER" Then
            dttable = objClsCommon.search(" country_name, country_id,''", "", "Countrymaster", " and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
        ElseIf frmstring = "CURRENCYMASTER" Then
            dttable = objClsCommon.search(" cur_name, cur_id,CUR_CODE ", "", "currencymaster", " and cur_cmpid = " & CmpId & " and cur_locationid = " & Locationid & " and cur_yearid = " & YearId)
        ElseIf frmstring = "NATIONALITY" Then
            dttable = objClsCommon.search(" NAT_name, NAT_id,NAT_CODE ", "", " NATIONALITYMASTER", " and NAT_yearid = " & YearId)
        ElseIf frmstring = "LAWAZIMMASTER" Then
            dttable = objClsCommon.search(" LWZM_name, LWZM_id,'' ", "", " LAWAZIMMASTER", " and LWZM_cmpid = " & CmpId & " and LWZM_locationid = " & Locationid & " and LWZM_yearid = " & YearId)
        ElseIf frmstring = "GIFTMASTER" Then
            dttable = objClsCommon.search(" GIFT_name, GIFT_id,'' ", "", " GIFTMASTER", " and GIFT_yearid = " & YearId)
        ElseIf frmstring = "VISA" Then
            dttable = objClsCommon.search(" VISA_name, VISA_id,'' ", "", " VISAMASTER", " and VISA_yearid = " & YearId)
        ElseIf frmstring = "TAX" Then
            dttable = objClsCommon.search(" TAX_name, TAX_id,'' ", "", " COUNTRYTAXMASTER", " and TAX_yearid = " & YearId)
        ElseIf frmstring = "ADDSERVICE" Then
            dttable = objClsCommon.search(" SERVICE_name, SERVICE_id,'' ", "", " SERVICEMASTER", " and SERVICE_yearid = " & YearId)
        ElseIf frmstring = "MISCEXP" Then
            dttable = objClsCommon.search(" MISC_name, MISC_id,'' ", "", " MISCEXPMASTER", " and MISC_yearid = " & YearId)
        ElseIf frmstring = "DOCUMENT" Then
            dttable = objClsCommon.search(" DOC_name, DOC_id,'' ", "", " DOCMASTER", " and DOC_yearid = " & YearId)
        End If

        gridgroup.DataSource = dttable
        gridgroup.Columns(0).HeaderText = "Name"
        gridgroup.Columns(0).Width = 250
        gridgroup.Columns(1).Visible = False
        gridgroup.Columns(2).Visible = False
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
            If frmstring = "CURRENCYMASTER" Then
                Dim objcitymaster As New CurrencyMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.tempname = name
                objcitymaster.tempCODE = abbr
                objcitymaster.tempid = id
                objcitymaster.Show()
            ElseIf frmstring = "LAWAZIMMASTER" Or frmstring = "VISA" Or frmstring = "TAX" Or frmstring = "ADDSERVICE" Or frmstring = "MISCEXP" Then
                Dim objcitymaster As New LawazimMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.frmstring = frmstring
                objcitymaster.tempname = name
                objcitymaster.tempid = id
                objcitymaster.Show()
            ElseIf frmstring = "NATIONALITY" Then
                Dim objcitymaster As New NationalityMaster
                objcitymaster.edit = editval
                objcitymaster.MdiParent = MDIMain
                objcitymaster.frmstring = frmstring
                objcitymaster.tempname = name
                objcitymaster.tempCODE = abbr
                objcitymaster.tempid = id
                objcitymaster.Show()
            Else
                Dim objcitymaster As New citymaster
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