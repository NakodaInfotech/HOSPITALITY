
Imports BL
Imports System.Windows.Forms

Public Class SelectHotelBooking_Amd

    Dim tempindex, i As Integer
    Public FRMSTRING As String
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPO_Amendment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HotelBookings.dt_amd.Clear()
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable
            dt = objclspreq.search(" dbo.HOTELBOOKINGMASTER.BOOKING_no AS [Booking No], (CASE WHEN dbo.HOTELBOOKINGMASTER.BOOKING_amendno <> '' THEN dbo.HOTELBOOKINGMASTER.BOOKING_amendno ELSE CAST(dbo.HOTELBOOKINGMASTER.BOOKING_no AS VARCHAR(100)) END ) AS [Booking/Amd No.], dbo.HOTELBOOKINGMASTER.BOOKING_date AS Date, GUEST_NAME AS [Guest Name], hotelmaster.hotel_name AS [Hotel Name], HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS [Arrival], HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS [Departure] ", "", "  dbo.HOTELBOOKINGMASTER LEFT OUTER JOIN dbo.hotelmaster ON dbo.HOTELBOOKINGMASTER.BOOKING_yearid = dbo.hotelmaster.hotel_yearid AND dbo.HOTELBOOKINGMASTER.BOOKING_locationid = dbo.hotelmaster.hotel_locationid AND dbo.hotelmaster.hotel_id = dbo.HOTELBOOKINGMASTER.BOOKING_hotelid AND dbo.hotelmaster.hotel_cmpid = dbo.HOTELBOOKINGMASTER.BOOKING_cmpid INNER JOIN GUESTMASTER ON GUEST_ID = BOOKING_GUESTID AND GUEST_CMPID = BOOKING_CMPID AND GUEST_LOCATIONID = BOOKING_LOCATIONID AND GUEST_YEARID = BOOKING_YEARID ", WHERECLAUSE & " and dbo.HOTELBOOKINGMASTER.BOOKING_cmpid=" & CmpId & " and  dbo.HOTELBOOKINGMASTER.BOOKING_locationid=" & Locationid & "  and  dbo.HOTELBOOKINGMASTER.BOOKING_yearid=" & YearId & "  order by BOOKING_no") 'and BOOKING_done = 'False'
            If dt.Rows.Count > 0 Then
                gridpoamd.DataSource = dt
                gridpoamd.Columns.Insert(0, col)
                gridpoamd.Columns(0).Width = 30
                gridpoamd.Columns(1).Width = 100
                gridpoamd.Columns(2).Width = 80
                gridpoamd.Columns(3).Width = 80
                gridpoamd.Columns(4).Width = 200
                gridpoamd.Columns(5).Width = 200
                gridpoamd.Columns(6).Width = 80
                gridpoamd.Columns(7).Width = 80

                gridpoamd.Columns(1).Visible = False
                gridpoamd.FirstDisplayedScrollingRowIndex = gridpoamd.RowCount - 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub gridpoamd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpoamd.CellClick
        'for selecting single PO for amendement at a time
        If e.RowIndex >= 0 Then
            With gridpoamd.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                    tempindex = e.RowIndex
                End If
            End With

            For i = 0 To gridpoamd.RowCount - 1
                If i <> tempindex Then
                    With gridpoamd.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub gridpoamd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridpoamd.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridpoamd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpoamd.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            For Each row As DataGridViewRow In gridpoamd.Rows
                With row.Cells(0)
                    If .Value = True Then
                        Dim OBJBOOKING As New ClsHotelBookingMaster()
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(FRMSTRING)
                        ALPARAVAL.Add(gridpoamd.Rows(gridpoamd.CurrentRow.Index).Cells(1).Value)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        HotelBookings.dt_amd = OBJBOOKING.SELECTBOOKING()
                        Me.Close()
                    End If
                End With
            Next

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated

        If cmbselect.Text.Trim <> "" Then
            If cmbselect.Text = "Booking/ Amendment No." Then
                fillgrid(" AND HOTELBOOKINGMASTER.BOOKING_no = " & txtsearch.Text.Trim)
            ElseIf cmbselect.Text = "Guest Name" Then
                fillgrid(" AND HOTELBOOKINGMASTER.BOOKING_GUESTNAME = '" & txtsearch.Text.Trim & "'")
            ElseIf cmbselect.Text = "Hotel Name" Then
                fillgrid(" AND hotelmaster.hotel_name = '" & txtsearch.Text.Trim & "'")
            End If
        Else
            fillgrid("")
        End If

    End Sub

End Class