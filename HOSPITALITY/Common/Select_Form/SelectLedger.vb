
Imports BL

Public Class SelectLedger

    Public STRSEARCH As String
    Public TEMPNAME, TEMPCODE As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click_1(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectLedger_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectLedger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("   LEDGERS.Acc_cmpname AS LEDGERNAME, LEDGERS.Acc_code AS CODE, GROUPMASTER.group_secondary AS [GROUP], CITYMASTER.city_name AS CITY, LEDGERS.Acc_mobile AS MOBILENO, LEDGERS.ACC_MEMBERID AS MEMBERSHIPID, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY, ISNULL(LEDGERS.Acc_email, '') AS EMAIL", "", "  LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN CATEGORYMASTER ON LEDGERS.ACC_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", STRSEARCH & " AND ISNULL(LEDGERS.ACC_BLOCKED,0) = 'FALSE' AND LEDGERS.Acc_yearid = " & YearId & " ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            TEMPNAME = gridbill.GetFocusedRowCellValue("LEDGERNAME")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Try
            TEMPNAME = gridbill.GetFocusedRowCellValue("LEDGERNAME")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class