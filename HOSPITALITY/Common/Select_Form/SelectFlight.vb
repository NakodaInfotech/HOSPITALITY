Imports BL

Public Class SelectFlight

    Public STRSEARCH As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPNAME, TEMPCODE As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectFlight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectFlight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID("")
            cmbname.Text = "Flight"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" FLIGHTMASTER.FLIGHT_NAME AS FLIGHT_NAME, FLIGHTMASTER.FLIGHT_CODE AS CODE, FLIGHTMASTER.FLIGHT_LCC AS LCC ", "", " FLIGHTMASTER ", STRSEARCH & WHERECLAUSE & " AND FLIGHT_CMPID = " & CmpId & " AND FLIGHT_LOCATIONID = " & Locationid & " AND FLIGHT_YEARID = " & YearId & " order by FLIGHT_NAME")
            GRIDFLIGHT.DataSource = DT

            GRIDFLIGHT.Columns(0).HeaderText = "Name"
            GRIDFLIGHT.Columns(0).Width = 260

            GRIDFLIGHT.Columns(1).HeaderText = "Code"
            GRIDFLIGHT.Columns(1).Width = 100

            GRIDFLIGHT.Columns(2).HeaderText = "LCC"
            GRIDFLIGHT.Columns(2).Width = 150

            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Try
            If TXTNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If rbstart.Checked = True Then
                    If cmbname.Text = "Flight" Then
                        FILLGRID(" AND FLIGHTMASTER.FLIGHT_NAME = '" & TXTNAME.Text.Trim & "'")
                    End If
                ElseIf rbpart.Checked = True Then
                    If cmbname.Text = "Flight" Then
                        FILLGRID(" AND FLIGHTMASTER.FLIGHT_NAME LIKE '%" & TXTNAME.Text.Trim & "%'")
                    End If

                End If
            Else
                FILLGRID("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If GRIDFLIGHT.SelectedRows.Count > 0 Then
                TEMPNAME = GRIDFLIGHT.Rows(GRIDFLIGHT.SelectedRows(0).Index).Cells(0).Value
                TEMPCODE = GRIDFLIGHT.Rows(GRIDFLIGHT.SelectedRows(0).Index).Cells(1).Value
            Else
                TEMPNAME = ""
                TEMPCODE = ""
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, GRIDFLIGHT.Item(0, GRIDFLIGHT.CurrentRow.Index).Value)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDFLIGHT.RowCount > 0) Then
                Dim OBJFLIGHTMASTER As New FlightMaster
                OBJFLIGHTMASTER.MdiParent = MDIMain
                OBJFLIGHTMASTER.edit = editval
                OBJFLIGHTMASTER.TEMPFLIGHTNAME = name
                OBJFLIGHTMASTER.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class