
Imports BL
Imports System.Windows.Forms

Public Class SelectPackageEnq

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

    Private Sub SelectPackageEnq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectPackageEnq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(" and HOLIDAYENQMASTER.ENQ_DONE= 'FALSE' and HOLIDAYENQMASTER.ENQ_CLOSE = 'FALSE' and HOLIDAYENQMASTER.ENQ_yearid=" & YearId & " order by HOLIDAYENQMASTER.ENQ_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If ClientName = "TRAVELBRIDGE" Then
                dt = objclsCMST.search(" CAST(0 AS BIT) AS CHK, HOLIDAYENQMASTER.ENQ_NO AS SRNO, ISNULL(HOLIDAYENQMASTER.ENQ_MISCENQNO, 0) AS MISCENQNO, HOLIDAYENQMASTER.ENQ_DATE AS DATE, GUESTMASTER.GUEST_NAME AS NAME, HOLIDAYENQMASTER.ENQ_REFNO AS REFNO, HOTELMASTER.HOTEL_NAME AS TOURNAME, HOLIDAYENQMASTER_DESC.ENQ_ARRIVALDATE AS PACKAGEFROM, HOLIDAYENQMASTER_DESC.ENQ_DEPARTUREDATE AS PACKAGETO, HOLIDAYENQMASTER_DESC.ENQ_AMOUNT AS GTOTAL, ISNULL(HOTEL_NAME,'') AS HOTELNAME, HOLIDAYENQMASTER_DESC.ENQ_SRNO AS GRIDSRNO  ", "", "  HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID INNER JOIN HOLIDAYENQMASTER_DESC ON HOLIDAYENQMASTER.ENQ_NO = HOLIDAYENQMASTER_DESC.ENQ_NO AND HOLIDAYENQMASTER.ENQ_YEARID = HOLIDAYENQMASTER_DESC.ENQ_YEARID INNER JOIN HOTELMASTER ON HOLIDAYENQMASTER_DESC.ENQ_HOTELID = HOTELMASTER.HOTEL_ID ", tepmcondition)
            Else
                dt = objclsCMST.search(" CAST(0 AS BIT) AS CHK,  HOLIDAYENQMASTER.ENQ_NO AS SRNO,  ISNULL(HOLIDAYENQMASTER.ENQ_MISCENQNO, 0) AS MISCENQNO, HOLIDAYENQMASTER.ENQ_DATE AS DATE, GUESTMASTER.GUEST_NAME AS NAME, HOLIDAYENQMASTER.ENQ_REFNO AS REFNO, HOLIDAYENQMASTER.ENQ_TOURNAME AS TOURNAME, HOLIDAYENQMASTER.ENQ_PACKAGEFROM AS PACKAGEFROM, HOLIDAYENQMASTER.ENQ_PACKAGETO AS PACKAGETO, HOLIDAYENQMASTER.ENQ_GRANDTOTAL AS GTOTAL, 0 AS GRIDSRNO ", "", "  HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID ", tepmcondition)
            End If
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
            DT.Columns.Add("NAME")
            DT.Columns.Add("REFNO")
            DT.Columns.Add("GRIDSRNO")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("SRNO"), dtrow("NAME"), dtrow("REFNO"), dtrow("GRIDSRNO"))
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