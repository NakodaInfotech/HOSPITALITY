
Imports BL

Public Class AgentDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AgentDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridagent.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridagent.RowCount > 0) Then
                Dim objagent As New AgentMaster
                objagent.MdiParent = MDIMain
                objagent.edit = editval
                objagent.tempAgentName = name
                objagent.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AgentDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'AGENT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridname()
        Dim dttable As New DataTable
        Dim objClsAgent As New ClsAgentMaster
        objClsAgent.alParaval.Add("")
        objClsAgent.alParaval.Add(CmpId)
        objClsAgent.alParaval.Add(Locationid)
        objClsAgent.alParaval.Add(YearId)
        dttable = objClsAgent.getAGENT()
        If dttable.Rows.Count > 0 Then
            griddetails.DataSource = dttable
            gridagent.Columns(0).Width = 200
            gridagent.Columns(1).Width = 125
        End If
    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim objClsAgent As New ClsAgentMaster
        objClsAgent.alParaval.Add(name)
        objClsAgent.alParaval.Add(CmpId)
        objClsAgent.alParaval.Add(Locationid)
        objClsAgent.alParaval.Add(YearId)
        dttable = objClsAgent.getAGENT()

        cleartextbox()

        If dttable.Rows.Count > 0 Then

            txtagentname.Text = dttable.Rows(0).Item(0).ToString
            txtperson.Text = dttable.Rows(0).Item(1).ToString
            txtgroup.Text = dttable.Rows(0).Item(2).ToString
            txtcity.Text = dttable.Rows(0).Item(3).ToString
            txtcomm.Text = Val(dttable.Rows(0).Item(5).ToString)
            txtcommdrcr.Text = dttable.Rows(0).Item(4).ToString
            txtopbal.Text = Val(dttable.Rows(0).Item(6).ToString)
            txtdrcr.Text = dttable.Rows(0).Item(7).ToString
            txtcrlimit.Text = dttable.Rows(0).Item(8).ToString
            txtremarks.Text = dttable.Rows(0).Item(9).ToString

        End If

    End Sub

    Sub cleartextbox()
        txtagentname.Clear()
        txtperson.Clear()
        txtgroup.Clear()
        txtcity.Clear()
        txtcomm.Clear()
        txtcommdrcr.Clear()
        txtopbal.Clear()
        txtdrcr.Clear()
        txtcrlimit.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub gridagent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridagent.Click
        Try
            getdetails(gridagent.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridagent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridagent.DoubleClick
        Try
            showform(True, gridagent.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridagent_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridagent.FocusedRowChanged
        Try
            getdetails(gridagent.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class