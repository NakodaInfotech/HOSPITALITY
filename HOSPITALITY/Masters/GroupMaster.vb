Imports BL

Public Class GroupMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public tempGroupname, TEMPGROUPOLDNAME As String
    Dim tempGroupId, TEMPGROUPOLDID As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempGroupname
                Case "Bank A/C"
                    bln_4_case = False
                Case "Bank OD A/C"
                    bln_4_case = False
                Case "Bank OD A/C"
                    bln_4_case = False
                Case "Capital A/C"
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Current Assets"
                    bln_4_case = False
                Case "Current Liabilities"
                    bln_4_case = False
                Case "Deposit (Assets)"
                    bln_4_case = False
                Case "Direct Expenses"
                    bln_4_case = False
                Case "Direct Income"
                    bln_4_case = False
                Case "Duties & Taxes"
                    bln_4_case = False
                Case "Fixed Assets"
                    bln_4_case = False
                Case "Indirect Expenses"
                    bln_4_case = False
                Case "Indirect Income"
                    bln_4_case = False
                Case "Investments"
                    bln_4_case = False
                Case "Loans & Advances"
                    bln_4_case = False
                Case "Loans"
                    bln_4_case = False
                Case "Misc. Expenses"
                    bln_4_case = False
                Case "Provisions"
                    bln_4_case = False
                Case "Purchase A/C"
                    bln_4_case = False
                Case "Reserves & Surplus"
                    bln_4_case = False
                Case "Sales A/C"
                    bln_4_case = False
                Case "Secured Loans"
                    bln_4_case = False
                Case "Stock In Hand"
                    bln_4_case = False
                Case "Sundry Creditors"
                    bln_4_case = False
                Case "Sundry Debtors"
                    bln_4_case = False
                Case "Suspense A/C"
                    bln_4_case = False
                Case "Unsecured Loans"
                    bln_4_case = False
                Case "Profit & Loss"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
            End Select

            If bln_4_case = False Then
                Ep.SetError(txtname, "Build In Group Cannot be Modified")
                BLN = False
            End If
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


            Ep.Clear()
            If Not DELETEERRORVALID() Then
                Exit Sub
            End If


            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbunder.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objclsGroupMaster As New ClsGroupMaster
            objclsGroupMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsGroupMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempGroupId)
                IntResult = objclsGroupMaster.update()
                MsgBox("Details Updated")
            End If


            clear()
            txtname.Clear()
            txtname.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            EP.SetError(txtname, "Fill Group Name")
            bln = False
        End If

        If cmbunder.Text.Trim.Length = 0 Then
            EP.SetError(cmbunder, "Select Under Group")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
        edit = False
    End Sub

    Private Sub cmbunder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunder.GotFocus
        Try
            If cmbunder.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "group_name"
                    cmbunder.DataSource = dt
                    cmbunder.DisplayMember = "group_name"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            pcase(txtname)
            If (edit = False) Or (edit = True And LCase(tempGroupname) <> LCase(txtname.Text.Trim)) Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_name = '" & txtname.Text.Trim & "' and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Group Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'fOR sAVE
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Oemcomma Then
            'e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtremarks_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtremarks.Validated
        pcase(txtremarks)
    End Sub

    Private Sub GroupMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GROUP MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                dttable = objCommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    dttable.DefaultView.Sort = "group_name"
                    cmbunder.DataSource = dttable
                    cmbunder.DisplayMember = "group_name"
                End If


                dttable = objCommon.search(" group_id , group_name, group_under", "", "GroupMaster", " and group_name = '" & tempGroupname & "' and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    tempGroupId = dttable.Rows(0).Item(0)
                    txtname.Text = dttable.Rows(0).Item(1)
                    cmbunder.Text = dttable.Rows(0).Item(2)

                End If
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Ep.Clear()
                If Not DELETEERRORVALID() Then
                    Exit Sub
                End If


                Dim tempmsg As Integer = MsgBox("Delete Group Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJGROUP As New ClsGroupMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(txtname.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJGROUP.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJGROUP.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class