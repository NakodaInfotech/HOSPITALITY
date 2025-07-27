
Imports BL

Public Class SelectGuest

    Public TEMPGUESTNAME As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectGuest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SelectGuest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(CITYMASTER.city_name, '') AS CITY, GUESTMASTER.GUEST_MOBILENO AS MOBILENO, GUESTMASTER.GUEST_ADD AS ADDRESS, ISNULL(GUESTCATEGORYMASTER.CATEGORY_NAME, '') AS GUESTCATEGORY, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(GUESTMASTER.GUEST_EMAIL, '') AS EMAIL ", "", "  GUESTMASTER LEFT OUTER JOIN STATEMASTER ON GUESTMASTER.GUEST_STATEID = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON GUESTMASTER.GUEST_CITYID = CITYMASTER.city_id LEFT OUTER JOIN GUESTCATEGORYMASTER ON GUESTMASTER.GUEST_GUESTCATEGORYID = GUESTCATEGORYMASTER.CATEGORY_ID", " and ISNULL(GUESTMASTER.GUEST_BLOCKED,0) = 'FALSE' AND GUESTMASTER.GUEST_YEARID = " & YearId & " ORDER BY GUESTMASTER.GUEST_NAME")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            TEMPGUESTNAME = gridbill.GetFocusedRowCellValue("GUESTNAME")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(sender As Object, e As EventArgs) Handles gridbill.DoubleClick
        Try
            TEMPGUESTNAME = gridbill.GetFocusedRowCellValue("GUESTNAME")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class