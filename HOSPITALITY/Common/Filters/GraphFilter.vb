
Imports BL

Public Class GraphFilter

    Public frmstring As String
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim colHOTEL As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim colBOOKEDBY As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value.Date)
        a2 = DatePart(DateInterval.Month, dtfrom.Value.Date)
        a3 = DatePart(DateInterval.Year, dtfrom.Value.Date)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value.Date)
        a12 = DatePart(DateInterval.Month, dtto.Value.Date)
        a13 = DatePart(DateInterval.Year, dtto.Value.Date)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub GraphFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GraphFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid()

        Try
            Dim objclspo As New ClsCommon
            Dim DTLEDGERS As DataTable
            Dim DTBOOKEDBY As DataTable
            Dim DTHOTEL As DataTable
            If frmstring = "BOOKEDBYBOOKINGS" Then
                DTLEDGERS = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
                DTHOTEL = objclspo.search("    HOTEL_NAME as [NAME], HOTEL_id ", "", "     HOTELMASTER  ", " AND HOTEL_cmpid = " & CmpId & " and HOTEL_LOCATIONid = " & Locationid & " and HOTEL_YEARid = " & YearId & " order by HOTEL_name")
                DTBOOKEDBY = objclspo.search("    BOOKEDBY_NAME as [NAME], BOOKEDBY_id ", "", "     BOOKEDBYMASTER ", " and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_LOCATIONid = " & Locationid & " and BOOKEDBY_YEARid = " & YearId & " order by BOOKEDBY_name")
            End If
            If DTLEDGERS.Rows.Count > 0 Then
                GRIDNAME.DataSource = DTLEDGERS
                GRIDNAME.Columns.Insert(0, col)
                GRIDNAME.Columns(0).Width = 30
                GRIDNAME.Columns(1).Width = 180

                GRIDNAME.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDNAME.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If

            If DTHOTEL.Rows.Count > 0 Then
                GRIDHOTEL.DataSource = DTHOTEL
                GRIDHOTEL.Columns.Insert(0, colHOTEL)
                GRIDHOTEL.Columns(0).Width = 30
                GRIDHOTEL.Columns(1).Width = 180

                GRIDHOTEL.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDHOTEL.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If

            If DTBOOKEDBY.Rows.Count > 0 Then
                GRIDBOOKEDBY.DataSource = DTBOOKEDBY
                GRIDBOOKEDBY.Columns.Insert(0, colBOOKEDBY)
                GRIDBOOKEDBY.Columns(0).Width = 30
                GRIDBOOKEDBY.Columns(1).Width = 180

                GRIDBOOKEDBY.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDBOOKEDBY.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKEDBY_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKEDBY.CellClick
        If e.RowIndex >= 0 Then
            With GRIDBOOKEDBY.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub GRIDHOTEL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOTEL.CellClick
        If e.RowIndex >= 0 Then
            With GRIDHOTEL.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub GRIDNAME_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDNAME.CellClick
        If e.RowIndex >= 0 Then
            With GRIDNAME.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
            End With
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkdate.Checked = True Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub CHKBOOKEDALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKBOOKEDALL.CheckedChanged
        If CHKBOOKEDALL.Checked = True Then
            For i As Integer = 0 To GRIDBOOKEDBY.RowCount - 1
                If GRIDBOOKEDBY.CurrentRow.Index >= 0 Then
                    With GRIDBOOKEDBY.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To GRIDBOOKEDBY.RowCount - 1
                If GRIDBOOKEDBY.CurrentRow.Index >= 0 Then
                    With GRIDBOOKEDBY.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub CHKHOTELALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKHOTELALL.CheckedChanged
        If CHKHOTELALL.Checked = True Then
            For i As Integer = 0 To GRIDHOTEL.RowCount - 1
                If GRIDHOTEL.CurrentRow.Index >= 0 Then
                    With GRIDHOTEL.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To GRIDHOTEL.RowCount - 1
                If GRIDHOTEL.CurrentRow.Index >= 0 Then
                    With GRIDHOTEL.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub CHKNAMEALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKNAMEALL.CheckedChanged
        If CHKNAMEALL.Checked = True Then
            For i As Integer = 0 To GRIDNAME.RowCount - 1
                If GRIDNAME.CurrentRow.Index >= 0 Then
                    With GRIDNAME.Rows(i).Cells(0)
                        .Value = True
                    End With
                End If
            Next
        Else
            For i As Integer = 0 To GRIDNAME.RowCount - 1
                If GRIDNAME.CurrentRow.Index >= 0 Then
                    With GRIDNAME.Rows(i).Cells(0)
                        .Value = False
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub chkdate_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        dtfrom.Enabled = chkdate.CheckState
        dtto.Enabled = chkdate.CheckState
    End Sub

    Private Sub txtName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTNAME.Validated
        Dim rowno, b As Integer
        fillgrid_search()
        rowno = 0
        For b = 1 To GRIDNAME.RowCount
            TXTTEMPNAME.Text = GRIDNAME.Item(1, rowno).Value.ToString()
            TXTTEMPNAME.SelectionStart = 0
            TXTTEMPNAME.SelectionLength = TXTNAME.TextLength
            If LCase(TXTNAME.Text.Trim) <> LCase(TXTTEMPNAME.SelectedText.Trim) Then
                GRIDNAME.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Sub fillgrid_search()

        Try
            Dim objclspo As New ClsCommon
            Dim DTLEDGERS As DataTable
            Dim DTBOOKEDBY As DataTable
            Dim DTHOTEL As DataTable
            If frmstring = "BOOKEDBYBOOKINGS" Then
                DTLEDGERS = objclspo.search("    dbo.LEDGERS.Acc_cmpname as [NAME], dbo.LEDGERS.Acc_id ", "", "     dbo.LEDGERS INNER JOIN dbo.GROUPMASTER ON dbo.LEDGERS.Acc_groupid = dbo.GROUPMASTER.group_id AND dbo.LEDGERS.Acc_locationid = dbo.GROUPMASTER.group_locationid And dbo.LEDGERS.Acc_cmpid = dbo.GROUPMASTER.group_cmpid And dbo.LEDGERS.Acc_YEARid = dbo.GROUPMASTER.group_YEARid ", " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & " order by dbo.LEDGERS.Acc_cmpname")
                DTHOTEL = objclspo.search("    HOTEL_NAME as [NAME], HOTEL_id ", "", "     HOTELMASTER  ", " AND HOTEL_cmpid = " & CmpId & " and HOTEL_LOCATIONid = " & Locationid & " and HOTEL_YEARid = " & YearId & " order by HOTEL_name")
                DTBOOKEDBY = objclspo.search("    BOOKEDBY_NAME as [NAME], BOOKEDBY_id ", "", "     BOOKEDBYMASTER ", " and BOOKEDBY_cmpid = " & CmpId & " and BOOKEDBY_LOCATIONid = " & Locationid & " and BOOKEDBY_YEARid = " & YearId & " order by BOOKEDBY_name")
            End If
            If DTLEDGERS.Rows.Count > 0 Then
                GRIDNAME.DataSource = DTLEDGERS
                'GRIDNAME.Columns.Insert(0, col)
                GRIDNAME.Columns(1).Width = 180

                GRIDNAME.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDNAME.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If

            If DTHOTEL.Rows.Count > 0 Then
                GRIDHOTEL.DataSource = DTHOTEL
                'GRIDHOTEL.Columns.Insert(0, col)
                GRIDHOTEL.Columns(1).Width = 180

                GRIDHOTEL.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDHOTEL.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If

            If DTBOOKEDBY.Rows.Count > 0 Then
                GRIDBOOKEDBY.DataSource = DTBOOKEDBY
                'GRIDBOOKEDBY.Columns.Insert(0, col)
                GRIDBOOKEDBY.Columns(1).Width = 180

                GRIDBOOKEDBY.Columns(2).Visible = False
                'gridledger.FirstDisplayedScrollingRowIndex = gridledger.RowCount - 1
                GRIDBOOKEDBY.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub TXTHOTELNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHOTELNAME.Validated
        Dim rowno, b As Integer
        fillgrid_search()
        rowno = 0
        For b = 1 To GRIDHOTEL.RowCount
            TXTTEMPHOTEL.Text = GRIDHOTEL.Item(1, rowno).Value.ToString()
            TXTTEMPHOTEL.SelectionStart = 0
            TXTTEMPHOTEL.SelectionLength = TXTHOTELNAME.TextLength
            If LCase(TXTHOTELNAME.Text.Trim) <> LCase(TXTTEMPHOTEL.SelectedText.Trim) Then
                GRIDHOTEL.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub TXTBOOKEDBY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKEDBY.Validated
        Dim rowno, b As Integer
        fillgrid_search()
        rowno = 0
        For b = 1 To GRIDBOOKEDBY.RowCount
            TXTTEMPBOOKEDBY.Text = GRIDBOOKEDBY.Item(1, rowno).Value.ToString()
            TXTTEMPBOOKEDBY.SelectionStart = 0
            TXTTEMPBOOKEDBY.SelectionLength = TXTBOOKEDBY.TextLength
            If LCase(TXTBOOKEDBY.Text.Trim) <> LCase(TXTTEMPBOOKEDBY.SelectedText.Trim) Then
                GRIDBOOKEDBY.Rows.RemoveAt(rowno)
            Else
                rowno = rowno + 1
            End If
        Next
    End Sub

    Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
        Try
            Dim i As Integer


            If frmstring = "BOOKEDBYBOOKINGS" Then
                Dim OBJHOTEL As New HotelBookingGraphDesign
                OBJHOTEL.strsearch = ""


                'SALE NAME
                For i = 0 To GRIDNAME.RowCount - 1
                    If GRIDNAME.Item(0, i).Value = True Then
                        If OBJHOTEL.strsearch = "" Then
                            OBJHOTEL.strsearch = OBJHOTEL.strsearch & "  ({LEDGERS.Acc_cmpname}= '" & GRIDNAME.Item(1, i).Value.ToString & "'"
                        Else
                            OBJHOTEL.strsearch = OBJHOTEL.strsearch & " or {LEDGERS.Acc_cmpname}= '" & GRIDNAME.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If OBJHOTEL.strsearch <> "" Then OBJHOTEL.strsearch = OBJHOTEL.strsearch & ")"


                'HOTELNAME
                Dim HOTELSEARCH As String = ""
                For i = 0 To GRIDHOTEL.RowCount - 1
                    If GRIDHOTEL.Item(0, i).Value = True Then
                        If HOTELSEARCH = "" Then
                            HOTELSEARCH = "  ({HOTELMASTER.HOTEL_NAME}= '" & GRIDHOTEL.Item(1, i).Value.ToString & "'"
                        Else
                            HOTELSEARCH = HOTELSEARCH & " or {HOTELMASTER.HOTEL_NAME}= '" & GRIDHOTEL.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If HOTELSEARCH <> "" Then HOTELSEARCH = HOTELSEARCH & ")"
                
                If OBJHOTEL.strsearch <> "" Then
                    OBJHOTEL.strsearch = OBJHOTEL.strsearch & " AND " & HOTELSEARCH
                Else
                    OBJHOTEL.strsearch = HOTELSEARCH
                End If



                'BOOKEDBYNAME
                Dim BOOKEDBYNAME As String = ""
                For i = 0 To GRIDBOOKEDBY.RowCount - 1
                    If GRIDBOOKEDBY.Item(0, i).Value = True Then
                        If BOOKEDBYNAME = "" Then
                            BOOKEDBYNAME = "  ({BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & GRIDBOOKEDBY.Item(1, i).Value.ToString & "'"
                        Else
                            BOOKEDBYNAME = BOOKEDBYNAME & " or {BOOKEDBYMASTER.BOOKEDBY_NAME}= '" & GRIDBOOKEDBY.Item(1, i).Value.ToString & "'"
                        End If
                    End If
                Next
                If BOOKEDBYNAME <> "" Then BOOKEDBYNAME = BOOKEDBYNAME & ")"

                If OBJHOTEL.strsearch <> "" Then
                    OBJHOTEL.strsearch = OBJHOTEL.strsearch & " AND " & BOOKEDBYNAME
                Else
                    OBJHOTEL.strsearch = BOOKEDBYNAME
                End If



                If OBJHOTEL.strsearch = "" Then
                    OBJHOTEL.strsearch = " {HOTELBOOKINGMASTER.BOOKING_CMPID} = " & CmpId & " AND {HOTELBOOKINGMASTER.BOOKING_LOCATIONID} = " & Locationid & " AND {HOTELBOOKINGMASTER.BOOKING_YEARID} = " & YearId
                Else
                    OBJHOTEL.strsearch = OBJHOTEL.strsearch & " AND {HOTELBOOKINGMASTER.BOOKING_CMPID} = " & CmpId & " AND {HOTELBOOKINGMASTER.BOOKING_LOCATIONID} = " & Locationid & " AND {HOTELBOOKINGMASTER.BOOKING_YEARID} = " & YearId
                End If

                If chkdate.Checked = True Then
                    getFromToDate()
                    OBJHOTEL.strsearch = OBJHOTEL.strsearch & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                End If
                OBJHOTEL.MdiParent = MDIMain
                OBJHOTEL.FRMSTRING = frmstring
                OBJHOTEL.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class