
Imports BL
Imports System.Windows.Forms

Public Class RateOfExchangeMaster

    Public edit As Boolean              'Used for edit
    Public tempCODE As String           'Used for edit name
    Public TEMPID, TEMPROW As Integer            'Used for edit id
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean

    Sub clear()
        Try
            CMBCODE.Text = ""
            TXTRATE.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RateOfExchangeMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub RateOfExchangeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CURRENCY MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCURRENCY(CMBCODE)
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub FILLGRID()
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            dttable = objCommon.search(" ISNULL(CURRENCYMASTER.cur_id, 0) AS ID, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CODE, ISNULL(RATEOFEXCHANGEMASTER.ROE_RATE, 0) AS RATE ", "", " CURRENCYMASTER INNER JOIN RATEOFEXCHANGEMASTER ON CURRENCYMASTER.cur_id = RATEOFEXCHANGEMASTER.ROE_CURRENCYID ", " AND RATEOFEXCHANGEMASTER.ROE_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                For Each ROW As DataRow In dttable.Rows
                    GRIDRATE.Rows.Add(Val(ROW("ID")), ROW("CODE"), Val(ROW("RATE")))
                Next
            End If

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

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If CMBCODE.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then

                If Not CHECKGRID() Then
                    Exit Sub
                End If

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Ep.Clear()

                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(CMBCODE.Text.Trim)
                ALPARAVAL.Add(Val(TXTRATE.Text.Trim))

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)


                Dim OBJOPENSTOCK As New ClsRateOfExchangeMaster
                OBJOPENSTOCK.alParaval = ALPARAVAL

                If edit = False Then
                    Dim DT As DataTable = OBJOPENSTOCK.SAVE()
                Else
                    ALPARAVAL.Add(Val(TXTROENO.Text))
                    Dim INTRES As Integer = OBJOPENSTOCK.UPDATE()
                    GRIDDOUBLECLICK = False
                    edit = False
                End If

                GRIDRATE.RowCount = 0
                FILLGRID()
                clear()
                CMBCODE.Focus()

            Else
                MsgBox("Enter Proper Details")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CHECKGRID() As Boolean
        Try
            Dim bln As Boolean = True
            For Each ROW As DataGridViewRow In GRIDRATE.Rows
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Then
                    If ROW.Cells(GCODE.Index).Value = CMBCODE.Text.Trim Then
                        Ep.SetError(CMBCODE, "Currency Code Already Present in Grid Below")
                        bln = False
                    End If
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            TXTROENO.Text = GRIDRATE.Item(GCURRENCYID.Index, e.RowIndex).Value
            CMBCODE.Text = GRIDRATE.Item(GCODE.Index, e.RowIndex).Value
            TXTRATE.Text = GRIDRATE.Item(GRATE.Index, e.RowIndex).Value

            GRIDDOUBLECLICK = True
            edit = True
            TEMPROW = e.RowIndex
            CMBCODE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDRATE.SelectedRows.Count > 0 Then

                    If USERDELETE = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If

                    If GRIDDOUBLECLICK = True Then
                        MsgBox("Unable to Modify, Entry is in Edit Mode", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    Dim TEMPMSG As Integer = MsgBox("Delete Rate of Exchange?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim ALPARAVAL As New ArrayList
                        Dim OBJNO As New ClsRateOfExchangeMaster

                        OBJNO.alParaval = ALPARAVAL
                        ALPARAVAL.Add(GRIDRATE.Rows(GRIDRATE.CurrentRow.Index).Cells(GCURRENCYID.Index).Value)
                        ALPARAVAL.Add(YearId)

                        Dim INTRES As Integer = OBJNO.DELETE()
                        GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class