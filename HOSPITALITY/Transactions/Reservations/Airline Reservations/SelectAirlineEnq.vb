
Imports BL
Imports System.Windows.Forms

Public Class SelectAirlineEnq

    Public edit As Boolean
    Public OFFNAME As String
    Public FRMSTRING As String
    Dim ROW As Integer = 0
    Public REQNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub SelectAirlineEnq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectAirlineEnq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" AND ISNULL(MISC_DONE, 0) = 'FALSE' AND MISC_STATUS = 'Pending' AND (MISC_TYPE = 'DOMESTIC AIRLINE' OR MISC_TYPE = 'INTERNATIONAL AIRLINE') and MISC_CMPID = " & CmpId & " and MISC_yearid = " & YearId & " order by MISC_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            'Dim dt As DataTable = objclsCMST.search(" CAST(0 AS BIT) AS CHK,  ISNULL(MISCENQUIRY.MISC_NO, 0) AS SRNO, MISCENQUIRY.MISC_DATE AS DATE, ISNULL(MISCENQUIRY.MISC_GUESTNAME, '') AS NAME, ISNULL(MISCENQUIRY.MISC_DESC, '') AS [DESC], ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, MISCENQUIRY.MISC_CHECKIN AS TRAVELDATE, ISNULL(MISCENQUIRY.MISC_ADULTS, 0) AS ADULTS, ISNULL(MISCENQUIRY.MISC_CHILD, 0) AS CHILD, ISNULL(MISCENQUIRY.MISC_TOTALPAX, 0) AS TOTALPAX ", "", "  MISCENQUIRY LEFT OUTER JOIN SOURCEMASTER ON MISCENQUIRY.MISC_SOURCEID = SOURCEMASTER.SOURCE_ID AND MISCENQUIRY.MISC_YEARID = SOURCEMASTER.SOURCE_YEARID ", tepmcondition)
            Dim dt As DataTable = objclsCMST.search(" CAST(0 AS BIT) AS CHK, ISNULL(MISCENQUIRY.MISC_NO, 0) AS SRNO, MISCENQUIRY.MISC_DATE AS DATE, ISNULL(MISCENQUIRY.MISC_GUESTNAME, '') AS GUESTNAME, ISNULL(MISCENQUIRY.MISC_DESC, '') AS [DESC], ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, MISCENQUIRY.MISC_CHECKIN AS TRAVELDATE, ISNULL(MISCENQUIRY.MISC_ADULTS, 0) AS ADULTS, ISNULL(MISCENQUIRY.MISC_CHILD, 0) AS CHILD, ISNULL(MISCENQUIRY.MISC_TOTALPAX, 0) AS TOTALPAX, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(MISCENQUIRY.MISC_EMAILID, '') AS EMAILID, ISNULL(MISCENQUIRY.MISC_MOBILENO,'') AS MOBILENO ", "", "    MISCENQUIRY INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN SOURCEMASTER ON MISCENQUIRY.MISC_SOURCEID = SOURCEMASTER.SOURCE_ID AND MISCENQUIRY.MISC_YEARID = SOURCEMASTER.SOURCE_YEARID", tepmcondition)

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("ENQNO")
            'DT.Columns.Add("ENQDATE")
            'DT.Columns.Add("GUESTNAME")
            'DT.Columns.Add("DESC")
            'DT.Columns.Add("SOURCE")
            'DT.Columns.Add("TRAVELDATE")
            'DT.Columns.Add("ADULTS")
            'DT.Columns.Add("CHILD")
            'DT.Columns.Add("TOTALPAX")

            DT.Columns.Add("GUESTNAME")
            DT.Columns.Add("SOURCE")
            'DT.Columns.Add("ADULTS")
            DT.Columns.Add("BOOKEDBY")
            DT.Columns.Add("EMAILID")
            DT.Columns.Add("MOBILENO")
            DT.Columns.Add("TOTALPAX")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    'DT.Rows.Add(dtrow("SRNO"), dtrow("ENQDATE"), dtrow("GUESTNAME"), dtrow("DESC"), dtrow("SOURCE"), dtrow("TRAVELDATE"), dtrow("ADULTS"), dtrow("CHILD"), dtrow("TOTALPAX"))
                    DT.Rows.Add(dtrow("SRNO"), dtrow("GUESTNAME"), dtrow("SOURCE"), dtrow("BOOKEDBY"), dtrow("EMAILID"), dtrow("MOBILENO"), dtrow("TOTALPAX"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        Try
            e.ErrorText = "Only 1 row can be selected at a time"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
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