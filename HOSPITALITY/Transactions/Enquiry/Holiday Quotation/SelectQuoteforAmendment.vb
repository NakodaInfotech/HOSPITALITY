
Imports BL
Imports System.Windows.Forms

Public Class SelectQuoteforAmendment

    Dim ROW As Integer = 0
    Public DT As New DataTable

    Private Sub PackageEnquiryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, HOLIDAYENQMASTER.ENQ_NO AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(HOLIDAYENQMASTER.ENQ_REFNO,'') AS REFNO ,GUESTMASTER.GUEST_NAME AS GUESTNAME, HOLIDAYENQMASTER.ENQ_TOURNAME AS TOURNAME, HOLIDAYENQMASTER.ENQ_PACKAGEFROM AS PACKAGEFROM, HOLIDAYENQMASTER.ENQ_PACKAGETO AS PACKAGETO,  HOLIDAYENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOLIDAYENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, HOLIDAYENQMASTER.ENQ_DONE AS DONE, HOLIDAYENQMASTER.ENQ_REMARKS AS REMARKS ", "", " HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID= GUESTMASTER.GUEST_id AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_cmpid AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_locationid AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_yearid INNER JOIN USERMASTER ON HOLIDAYENQMASTER.ENQ_USERID = USERMASTER.User_id AND HOLIDAYENQMASTER.ENQ_CMPID = USERMASTER.User_cmpid ", " AND ENQ_AMENDED = 0 AND ENQ_DONE = 0 AND ENQ_CLOSE = 0 AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER.ENQ_NO")

            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub PackageEnquiryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Dim n As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If n <> "" Then
                        If n = (dtrow("ENQNO")) Then
                            GoTo Line1
                        Else
                            MsgBox("Pls Select One Enquiry Only!")
                            Exit Sub
                        End If
                    End If
Line1:
                    n = (dtrow("ENQNO"))
                End If
            Next

            DT.Columns.Add("ENQNO")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("ENQNO"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class