
Imports BL
Imports DevExpress.XtraGrid.Views.Base

Public Class SelectMiscProforma
    Public DT As New DataTable
    Dim ROW As Integer = 0

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SelectMiscProforma_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectMiscProforma_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCLSCOMMOM As New ClsCommonMaster
            Dim DT As DataTable = OBJCLSCOMMOM.search("  CAST(0 AS BIT) AS CHK, PROFORMAMISCSALMASTER.BOOKING_NO AS MISCENQNO, PROFORMAMISCSALMASTER.BOOKING_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname,'') AS NAME,  ISNULL(PROFORMAMISCSALMASTER.BOOKING_REFNO,'') AS REFNO, ISNULL(REGISTERMASTER.REGISTER_NAME,'') AS REGNAME ,ISNULL(PROFORMAMISCSALMASTER.BOOKING_PURGRANDTOTAL,0) AS GRANDTOTAL", "", "  PROFORMAMISCSALMASTER INNER JOIN LEDGERS ON PROFORMAMISCSALMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PROFORMAMISCSALMASTER.BOOKING_PURCHASEREGISTERID = REGISTERMASTER.REGISTER_ID", "  and BOOKING_DONE= 'FALSE' AND BOOKING_yearid=" & YearId & " order by BOOKING_no ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("MISCENQNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("REFNO")
            DT.Columns.Add("REGNAME")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                DT.Rows.Add(Val(dtrow("MISCENQNO")), dtrow("NAME"), dtrow("REFNO"), dtrow("REGNAME"))
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        Try
            e.ErrorText = "Only 1 row can be selected at a time"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try

LINE1:
            If ROW = 0 Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(I)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        ROW = I
                        Exit For
                    End If
                Next
            Else
                Dim dtrow As DataRow = gridbill.GetDataRow(ROW)
                If Convert.ToBoolean(dtrow("CHK")) = False Then
                    ROW = 0
                    GoTo LINE1
                End If
            End If

            If Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = True And e.RowHandle <> ROW Then
                e.Valid = False
                gridbill.SetColumnError(gridbill.Columns("CHK"), "Only 1 row can be selected at a time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            ElseIf Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = False And e.RowHandle = ROW Then
                ROW = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class