Imports System.IO
Imports BL

Public Class RailwayConfig

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean = False
    Public tempprocessName As String
    Public tempprocessId As Integer

    Sub FillCombo()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBNAME.Text.Trim)

            Dim CLASSNAME As String = ""
            Dim TYPE As String = ""
            Dim RATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If CLASSNAME = "" Then
                    CLASSNAME = row.Cells(GCLASS.Index).Value
                    TYPE = row.Cells(GTYPE.Index).Value
                    RATE = row.Cells(GRATE.Index).Value
                Else
                    CLASSNAME = CLASSNAME & "|" & row.Cells(GCLASS.Index).Value
                    TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value
                    RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                End If
            Next

            alParaval.Add(CLASSNAME)
            alParaval.Add(TYPE)
            alParaval.Add(RATE)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim obclsexpns As New ClsRailway
            obclsexpns.alParaval = alParaval
            'If USERADD = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
            IntResult = obclsexpns.save()
            MsgBox("Details Added")

            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Party Name")
            bln = False
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(GRIDBOOKINGS, "Fill The Grid")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()

        GRIDBOOKINGS.RowCount = 0
        CMBNAME.Text = ""
        CMBCLASS.Text = ""
        CMBTYPE.Text = ""
        txtrate.Clear()
        edit = False
    End Sub

    Private Sub RailwayConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EXPENSE MASTER'")
            'USERADD = DTROW(0).Item(1)
            'USEREDIT = DTROW(0).Item(2)
            'USERVIEW = DTROW(0).Item(3)
            'USERDELETE = DTROW(0).Item(4)

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                CMBNAME.Text = ""
            End If
            FillCombo()
            CMBNAME.Text = tempprocessName

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(CMBCLASS.Text.Trim, CMBTYPE.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Rows(tempRow).Cells(GCLASS.Index).Value = CMBCLASS.Text.Trim
            GRIDBOOKINGS.Rows(tempRow).Cells(GTYPE.Index).Value = CMBTYPE.Text.Trim
            GRIDBOOKINGS.Rows(tempRow).Cells(GRATE.Index).Value = Format(Val(txtrate.Text.Trim), "0.00")

            gridDoubleClick = False
        End If
        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
        CMBCLASS.Text = ""
        CMBTYPE.Text = ""
        txtrate.Clear()
        CMBCLASS.Focus()
    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GCLASS.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            CMBCLASS.Text = GRIDBOOKINGS.Item(GCLASS.Index, e.RowIndex).Value
            CMBTYPE.Text = GRIDBOOKINGS.Item(GTYPE.Index, e.RowIndex).Value
            txtrate.Text = GRIDBOOKINGS.Item(GRATE.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            CMBCLASS.Focus()
        End If
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDBOOKINGS.Rows.RemoveAt(GRIDBOOKINGS.CurrentRow.Index)
        End If
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Select Name First", MsgBoxStyle.Critical, CmpName)
                CMBNAME.Focus()
            End If
            If CMBCLASS.Text.Trim <> "" And CMBTYPE.Text.Trim <> "" And txtrate.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
                CMBCLASS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbProcess_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
            'GETTING DATA FOR EDIT MODE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" RAILWAY_CONFIG.RAILWAY_CLASS AS CLASS, RAILWAY_CONFIG.RAILWAY_TYPE AS TYPE, RAILWAY_CONFIG.RAILWAY_RATE AS RATE", "", " RAILWAY_CONFIG LEFT OUTER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid AND RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID = " & CmpId & " AND RAILWAY_CONFIG.RAILWAY_LOCATIONID = " & Locationid & " AND RAILWAY_CONFIG.RAILWAY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                GRIDBOOKINGS.RowCount = 0
                For Each DTROW As DataRow In DT.Rows
                    GRIDBOOKINGS.Rows.Add(DTROW("CLASS"), DTROW("TYPE"), Format(DTROW("RATE"), "0.00"))
                Next
            Else
                GRIDBOOKINGS.RowCount = 0
            End If
           
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbProcess_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            Try
                If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            Catch ex As Exception
                Throw ex
            End Try

            If CMBNAME.Text.Trim <> "" Then
                pcase(CMBNAME)

                'GETTING DATA FOR EDIT MODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" RAILWAY_CONFIG.RAILWAY_CLASS AS CLASS, RAILWAY_CONFIG.RAILWAY_TYPE AS TYPE, RAILWAY_CONFIG.RAILWAY_RATE AS RATE", "", " RAILWAY_CONFIG LEFT OUTER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid AND RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID = " & CmpId & " AND RAILWAY_CONFIG.RAILWAY_LOCATIONID = " & Locationid & " AND RAILWAY_CONFIG.RAILWAY_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    GRIDBOOKINGS.RowCount = 0
                    For Each DTROW As DataRow In DT.Rows
                        GRIDBOOKINGS.Rows.Add(DTROW("CLASS"), DTROW("TYPE"), Format(DTROW("RATE"), "0.00"))

                    Next
                    edit = True
                End If

            End If
        Catch ex As Exception
            'GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        Try
            numdotkeypress(e, txtrate, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Expense_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTYPE.Validating
        If CMBCLASS.Text.Trim <> "" And CMBTYPE.Text.Trim <> "" And GRIDBOOKINGS.RowCount > 0 Then

            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If gridDoubleClick = False Then
                    If CMBCLASS.Text = row.Cells(GCLASS.Index).Value.ToString And CMBTYPE.Text = row.Cells(GTYPE.Index).Value.ToString Then
                        MsgBox("This class and type already exists")
                        e.Cancel = True
                        CMBTYPE.Focus()
                    End If
                Else
                    If CMBCLASS.Text = row.Cells(GCLASS.Index).Value.ToString And CMBTYPE.Text = row.Cells(GTYPE.Index).Value.ToString And row.Index <> tempRow Then
                        MsgBox("This class and type already exists")
                        e.Cancel = True
                        CMBTYPE.Focus()
                    End If
                End If

            Next
        End If

    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class