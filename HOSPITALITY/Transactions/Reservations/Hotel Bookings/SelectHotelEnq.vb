
Imports BL
Imports System.Windows.Forms

Public Class SelectHotelEnq

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

    Private Sub SelectHotelEnq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SelectHotelEnq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "PROFORMA" Then
                Me.Text = "Select Proforma"
                GMISCENQNO.Visible = False
                GSRNO.Caption = "Proforma No"
                fillgrid(" and BOOKING_DONE= 'FALSE' AND BOOKING_yearid=" & YearId & " order by BOOKING_no ")
            Else
                fillgrid(" and ENQ_DONE= 'FALSE' AND ENQ_CLOSE = 'FALSE' and ENQ_yearid=" & YearId & " order by ENQ_no ")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If FRMSTRING = "PROFORMA" Then
                dt = objclsCMST.search(" CAST(0 AS BIT) AS CHK,  PROFORMAHOTELBOOKINGMASTER.BOOKING_NO AS SRNO, PROFORMAHOTELBOOKINGMASTER.BOOKING_DATE AS DATE, GUESTMASTER.GUEST_NAME AS NAME, PROFORMAHOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELMASTER.HOTEL_NAME AS HOTELNAME, PROFORMAHOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, PROFORMAHOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, PROFORMAHOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GTOTAL ", "", "  PROFORMAHOTELBOOKINGMASTER INNER JOIN GUESTMASTER ON PROFORMAHOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON PROFORMAHOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID   ", tepmcondition)
            Else
                dt = objclsCMST.search(" CAST(0 AS BIT) AS CHK,  HOTELENQMASTER.ENQ_NO AS SRNO, ISNULL(HOTELENQMASTER.ENQ_MISCENQNO,0) AS MISCENQNO, HOTELENQMASTER.ENQ_DATE AS DATE, GUESTMASTER.GUEST_NAME AS NAME, HOTELENQMASTER.ENQ_REFNO AS REFNO, HOTELMASTER.HOTEL_NAME AS HOTELNAME, HOTELENQMASTER.ENQ_ARRIVAL AS ARRIVAL, HOTELENQMASTER.ENQ_DEPARTURE AS DEPARTURE, HOTELENQMASTER.ENQ_GRANDTOTAL AS GTOTAL ", "", "  HOTELENQMASTER INNER JOIN GUESTMASTER ON HOTELENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOTELENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELMASTER ON HOTELENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELENQMASTER.ENQ_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = HOTELMASTER.HOTEL_YEARID  ", tepmcondition)
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
            DT.Columns.Add("HOTELNAME")
            DT.Columns.Add("ARRIVAL")
            DT.Columns.Add("DEPARTURE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("SRNO"), dtrow("NAME"), dtrow("REFNO"), dtrow("HOTELNAME"), dtrow("ARRIVAL"), dtrow("DEPARTURE"))
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