
Imports BL

Public Class AgentMaster

    Public edit As Boolean
    Public tempAgentName As String
    Dim tempAgentId, TEMPAGENTOLDID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AgentMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Write Code here
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.Oemcomma Then
            'e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtagentname.Text.Trim)
            alParaval.Add(txtperson.Text.Trim)
            alParaval.Add(cmbgroup.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtcomm.Text.Trim)

            If cmbcommdrcr.Text = "%" Then
                alParaval.Add("P")
            Else
                alParaval.Add("F")
            End If

            alParaval.Add(txtopbal.Text.Trim)
            alParaval.Add(cmbdrcrrs.Text.Trim)
            alParaval.Add(txtcrlimit.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(txtaddress.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objAgentMaster As New ClsAgentMaster
            objAgentMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAgentMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempAgentId)
                IntResult = objAgentMaster.update()
                MsgBox("Details Updated")
            End If

            clear()
            txtagentname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        txtagentname.Clear()
        txtperson.Clear()
        cmbgroup.Text = ""
        cmbcity.Text = ""
        txtcomm.Clear()
        cmbcommdrcr.SelectedIndex = 0
        txtopbal.Clear()
        cmbdrcrrs.SelectedIndex = 0
        txtcrlimit.Clear()
        txtremarks.Clear()
        
        edit = False

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtagentname.Text.Trim.Length = 0 Then
            EP.SetError(txtagentname, "Fill Agent Name")
            bln = False
        End If

        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group")
            bln = False
        End If
        Return bln
    End Function

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("city_NAME", "", "CityMaster", " AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_NAME"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_NAME"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If

    End Sub

    Private Sub AgentMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AGENT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            fillcmb()
            txtagentname.Text = tempAgentName

            If edit = True Then

                Dim dttable As New DataTable
                Dim objagent As New ClsAgentMaster

                objagent.alParaval.Add(tempAgentName)
                objagent.alParaval.Add(CmpId)
                objagent.alParaval.Add(Locationid)
                objagent.alParaval.Add(YearId)

                dttable = objagent.getAGENT()

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    txtagentname.Text = dttable.Rows(0).Item(0).ToString
                    txtperson.Text = dttable.Rows(0).Item(1).ToString
                    cmbgroup.Text = dttable.Rows(0).Item(2).ToString
                    cmbcity.Text = dttable.Rows(0).Item(3).ToString
                    txtcomm.Text = Val(dttable.Rows(0).Item(5).ToString)

                    If dttable.Rows(0).Item(4).ToString = "F" Then
                        cmbcommdrcr.Text = "Rs."
                    Else
                        cmbcommdrcr.Text = "%"
                    End If

                    txtopbal.Text = Val(dttable.Rows(0).Item(6).ToString)
                    cmbdrcrrs.Text = dttable.Rows(0).Item(7).ToString
                    txtcrlimit.Text = dttable.Rows(0).Item(8).ToString
                    txtremarks.Text = dttable.Rows(0).Item(9).ToString
                    txtaddress.Text = dttable.Rows(0).Item("agent_address").ToString
                    tempAgentId = Val(dttable.Rows(0).Item(10).ToString)
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_NAME", "", "CityMaster", " AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_NAME"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_NAME"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_NAME", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecity(cmbcity.Text.Trim, Userid, CmpId, Locationid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                        Dim dt1 As New DataTable
                        Dim a As String = cmbcity.Text.Trim
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.Enter
        Try
            If cmbgroup.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    cmbgroup.DataSource = dt
                    cmbgroup.DisplayMember = "group_name"
                    cmbgroup.Text = ""
                End If
                cmbgroup.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then
                pcase(cmbgroup)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = cmbgroup.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_LOCATIONid = " & Locationid & " and group_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = cmbgroup.Text.Trim
                            dt1 = cmbgroup.DataSource
                            If cmbgroup.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(cmbgroup.Text)
                                cmbgroup.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Agent Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJAGENT As New ClsAgentMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(txtagentname.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJAGENT.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJAGENT.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class