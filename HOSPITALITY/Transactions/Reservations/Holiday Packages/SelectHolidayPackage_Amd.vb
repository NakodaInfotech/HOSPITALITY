
Imports BL
Imports System.Windows.Forms

Public Class SelectHolidayPackage_Amd

    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectHolidayPackage_Amd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HolidayPackage.dt_amd.Clear()
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim objclspreq As New ClsCommon()
            Dim dt As DataTable
            dt = objclspreq.search(" HOLIDAYPACKAGEMASTER.BOOKING_NO AS [Booking No], (CASE WHEN dbo.HOLIDAYPACKAGEMASTER.BOOKING_amendno <> '' THEN dbo.HOLIDAYPACKAGEMASTER.BOOKING_amendno ELSE CAST(dbo.HOLIDAYPACKAGEMASTER.BOOKING_no AS VARCHAR(100)) END) AS [Booking/Amd No.], HOLIDAYPACKAGEMASTER.BOOKING_DATE AS Date, LEDGERS.Acc_cmpname AS [Sale Account Name], HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS [Total] ", "", "  HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid ", WHERECLAUSE & " and dbo.HOLIDAYPACKAGEMASTER.BOOKING_cmpid=" & CmpId & " and  dbo.HOLIDAYPACKAGEMASTER.BOOKING_locationid=" & Locationid & "  and  dbo.HOLIDAYPACKAGEMASTER.BOOKING_yearid=" & YearId & "  order by HOLIDAYPACKAGEMASTER.BOOKING_no") 'and BOOKING_done = 'False'
            If dt.Rows.Count > 0 Then
                gridpoamd.DataSource = dt
                gridpoamd.Columns.Insert(0, col)
                gridpoamd.Columns(0).Width = 30
                gridpoamd.Columns(1).Width = 80
                gridpoamd.Columns(2).Width = 100
                gridpoamd.Columns(3).Width = 80
                gridpoamd.Columns(4).Width = 200
                gridpoamd.Columns(5).Width = 80

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
                        Dim dt As New DataTable
                        dt.Columns.Add("BOOKINGNO")
                        dt.Rows.Add(row.Cells(1).Value)
                        HolidayPackage.dt_amd = dt
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