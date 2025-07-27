
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PendingBookings

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub PendingBookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0, "HOTELBOOKING", "BOOKING")
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If (FRMSTRING = "SALEBALANCE" Or FRMSTRING = "ALLBALANCE") And ClientName = "PARAMOUNT" Then
                gridbill.Columns("NAME").Visible = True
                gridbill.Columns("SUBTOTAL").Visible = True
                gridbill.Columns("TAX").Visible = True
            Else
                gridbill.Columns("NAME").Visible = False
                gridbill.Columns("SUBTOTAL").Visible = False
                gridbill.Columns("TAX").Visible = False
            End If

            If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then WHERECLAUSE = WHERECLAUSE & " AND BOOKEDBY = '" & UserName & "' "

            If FRMSTRING = "SALEBALANCE" Then
                If ClientName = "PARAMOUNT" Then
                    dt = objclsCMST.search(" BILL, BOOKINGNO, DATE, REFNO, GUEST_NAME AS GUESTNAME, SALELEDGER AS NAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAX, SALEAMT AS BILLAMT, SALEBAL AS DEBITBAL , 0 AS CREDITBAL, BOOKTYPE, TYPE ", "", " GUESTMASTER INNER JOIN HOLIDAYPACKAGEMASTER_GUESTDETAILS ON GUESTMASTER.GUEST_ID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_GUESTID INNER JOIN RESERVATION_SALEREPORT ON HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_NO = RESERVATION_SALEREPORT.BILL AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID = RESERVATION_SALEREPORT.YEARID INNER JOIN HOLIDAYPACKAGEMASTER ON RESERVATION_SALEREPORT.BILL = HOLIDAYPACKAGEMASTER.BOOKING_NO AND RESERVATION_SALEREPORT.YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID  ", WHERECLAUSE & " AND CANCELLED = 0 AND SALEAMT > 0 AND SALEBAL > 0 AND YEARID = " & YearId & " ORDER BY RESERVATION_SALEREPORT.DATE,BILL")
                Else
                    dt = objclsCMST.search(" BILL, BOOKINGNO, DATE, REFNO, GUESTNAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, SALEAMT AS BILLAMT, SALEBAL AS DEBITBAL , 0 AS CREDITBAL, BOOKTYPE, TYPE ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & " AND CANCELLED = 0 AND SALEAMT > 0 AND SALEBAL > 0 AND YEARID = " & YearId & " ORDER BY RESERVATION_SALEREPORT.DATE,BILL")
                End If
            ElseIf FRMSTRING = "PURBALANCE" Then
                If ClientName = "PARAMOUNT" Then
                    dt = objclsCMST.search(" BOOKINGNO AS BILL,BILLINITIALS AS BOOKINGNO, BOOKINGDATE AS DATE, REFNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, GUESTNAME AS NAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, GTOTAL AS BILLAMT, 0 AS DEBITBAL, CREDITBALANCE AS CREDITBAL, BOOKTYPE, TYPE ", "", " RESERVATIONDETAILS INNER JOIN HOLIDAYPACKAGEMASTER_GUESTDETAILS ON RESERVATIONDETAILS.BOOKINGNO = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_NO AND RESERVATIONDETAILS.CMPID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID AND RESERVATIONDETAILS.LOCATIONID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID AND RESERVATIONDETAILS.YEARID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID  ", WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY BOOKINGDATE,BOOKINGNO")
                    gridbill.Columns("NAME").Visible = True
                Else
                    dt = objclsCMST.search(" BOOKINGNO AS BILL,BILLINITIALS AS BOOKINGNO, BOOKINGDATE AS DATE, REFNO, GUESTNAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, GTOTAL AS BILLAMT, 0 AS DEBITBAL, CREDITBALANCE AS CREDITBAL, BOOKTYPE, TYPE ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY BOOKINGDATE,BOOKINGNO")
                End If
            ElseIf FRMSTRING = "ALLBALANCE" Then
                If ClientName = "PARAMOUNT" Then
                    dt = objclsCMST.search(" * ", "", "( SELECT BOOKINGNO AS BILL,BILLINITIALS AS BOOKINGNO, BOOKINGDATE AS DATE, REFNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, GUESTNAME AS NAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, NETTAMT AS SUBTOTAL , TAX, GTOTAL AS BILLAMT, 0 AS DEBITBAL, CREDITBALANCE AS CREDITBAL, BOOKTYPE, TYPE  FROM RESERVATIONDETAILS INNER JOIN HOLIDAYPACKAGEMASTER_GUESTDETAILS ON RESERVATIONDETAILS.BOOKINGNO = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_NO AND RESERVATIONDETAILS.CMPID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID AND RESERVATIONDETAILS.LOCATIONID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID AND RESERVATIONDETAILS.YEARID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID INNER JOIN GUESTMASTER ON HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID  WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " UNION ALL SELECT BILL, BOOKINGNO, DATE, REFNO, GUEST_NAME AS GUESTNAME, SALELEDGER AS NAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAX, SALEAMT AS BILLAMT, SALEBAL AS DEBITBAL , 0 AS CREDITBAL, BOOKTYPE, TYPE  FROM GUESTMASTER INNER JOIN HOLIDAYPACKAGEMASTER_GUESTDETAILS ON GUESTMASTER.GUEST_ID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_GUESTID AND GUESTMASTER.GUEST_CMPID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID AND GUESTMASTER.GUEST_LOCATIONID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID AND GUESTMASTER.GUEST_YEARID = HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID INNER JOIN RESERVATION_SALEREPORT ON HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_NO = RESERVATION_SALEREPORT.BILL AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_CMPID = RESERVATION_SALEREPORT.CMPID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_LOCATIONID = RESERVATION_SALEREPORT.LOCATIONID AND HOLIDAYPACKAGEMASTER_GUESTDETAILS.BOOKING_YEARID = RESERVATION_SALEREPORT.YEARID INNER JOIN HOLIDAYPACKAGEMASTER ON RESERVATION_SALEREPORT.BILL = HOLIDAYPACKAGEMASTER.BOOKING_NO AND RESERVATION_SALEREPORT.CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND RESERVATION_SALEREPORT.LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND RESERVATION_SALEREPORT.YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID  WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 0 AND SALEAMT > 0 AND SALEBAL > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & ") AS T", " ORDER BY T.DATE,T.BOOKINGNO ")
                Else
                    dt = objclsCMST.search(" * ", "", "( SELECT BOOKINGNO AS BILL,BILLINITIALS AS BOOKINGNO, BOOKINGDATE AS DATE, REFNO, GUESTNAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, GTOTAL AS BILLAMT, 0 AS DEBITBAL, CREDITBALANCE AS CREDITBAL, BOOKTYPE, TYPE FROM RESERVATIONDETAILS WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " UNION ALL SELECT BILL, BOOKINGNO, DATE, REFNO, GUESTNAME, HOTELNAME, ARRIVAL, DEPARTURE, BOOKEDBY, SALEAMT AS BILLAMT, SALEBAL AS DEBITBAL , 0 AS CREDITBAL,  BOOKTYPE, TYPE FROM RESERVATION_SALEREPORT WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 0 AND SALEAMT > 0 AND SALEBAL > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & ") AS T", " ORDER BY T.DATE,T.BOOKINGNO ")
                End If
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal TYPE As String, ByVal BOOKTYPE As String)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                If TYPE = "HOTELBOOKING" Then
                    Dim OBJBOOKING As New HotelBookings
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.FRMSTRING = BOOKTYPE
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                ElseIf TYPE = "HOLIDAYPACKAGE" Then
                    Dim OBJBOOKING As New HolidayPackage
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                ElseIf TYPE = "INTERNATIONALBOOKING" Then
                    Dim OBJBOOKING As New InternationalBookings
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                ElseIf TYPE = "RAILBOOKING" Then
                    Dim OBJBOOKING As New RailwayBooking
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                ElseIf TYPE = "CARBOOKING" Then
                    Dim OBJBOOKING As New CarBooking
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BILL"), gridbill.GetFocusedRowCellValue("TYPE"), gridbill.GetFocusedRowCellValue("BOOKTYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BILL"), gridbill.GetFocusedRowCellValue("TYPE"), gridbill.GetFocusedRowCellValue("BOOKTYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingBookings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "SALEBALANCE" Then
                Me.Text = "Sale Balance Report"
            ElseIf FRMSTRING = "PURBALANCE" Then
                Me.Text = "Purchase Balance Report"
            ElseIf FRMSTRING = "ALLBALANCE" Then
                Me.Text = "Pur - Sale Balance Report"
            End If
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim WHERECLAUSE As String = ""
            If chkdate.CheckState = CheckState.Checked Then WHERECLAUSE = " AND DATE >= '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' "
            fillgrid(WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Pending Booking.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Pending Booking"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pending Booking", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try

            If e.RowHandle >= 0 Then
                Dim View As GridView = sender

                '5 DAYS LEFT FOR CHECKIN
                If DateDiff(DateInterval.Day, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date, Now.Date) <= 5 And DateDiff(DateInterval.Day, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date, Now.Date) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow

                    'CHECKED IN
                ElseIf Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date <= Now.Date And Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date > Now.Date Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow

                    'CHECKED OUT
                ElseIf Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date <= Now.Date And DateAdd(DateInterval.Day, 7, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date) > Now.Date Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Orange

                    'AFTER 1 WEEK OF CHECK OUT
                ElseIf DateAdd(DateInterval.Day, 7, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date) <= Now.Date And DateAdd(DateInterval.Day, 30, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date) > Now.Date Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Red

                    'AFTER 1 MONTH OF CHECKOUT
                ElseIf DateAdd(DateInterval.Day, 30, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date) < Now.Date Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Plum
                End If
            End If

            'gridbill.OptionsSelection.EnableAppearanceFocusedRow = False
            'Dim DT As DataTable = gridbilldetails.DataSource
            'If gridbill.RowFilter = "" Then
            '    If e.RowHandle >= 0 Then
            '        Dim ROW As DataRow = DT.Rows(e.RowHandle)

            '        'MsgBox(ROW("BOOKINGNO"))
            '        e.Appearance.BackColor = Color.Empty

            '        '5 DAYS LEFT FOR CHECKIN
            '        Dim A As Date = DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date)
            '        If DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("ARRIVAL")).Date, Now.Date) <= 5 And DateDiff(DateInterval.Day, Convert.ToDateTime(ROW("ARRIVAL")).Date, Now.Date) > 0 Then
            '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
            '            e.Appearance.BackColor = Color.Green

            '            'CHECKED IN
            '        ElseIf Convert.ToDateTime(ROW("ARRIVAL")).Date <= Now.Date And Convert.ToDateTime(ROW("DEPARTURE")).Date > Now.Date Then
            '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
            '            e.Appearance.BackColor = Color.Yellow

            '            'CHECKED OUT
            '        ElseIf Convert.ToDateTime(ROW("DEPARTURE")).Date <= Now.Date And DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date) > Now.Date Then
            '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
            '            e.Appearance.BackColor = Color.Orange

            '            'AFTER 1 WEEK OF CHECK OUT
            '        ElseIf DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date) <= Now.Date And DateAdd(DateInterval.Day, 30, Convert.ToDateTime(ROW("DEPARTURE")).Date) > Now.Date Then
            '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
            '            e.Appearance.BackColor = Color.Red

            '            'AFTER 1 MONTH OF CHECKOUT
            '        ElseIf DateAdd(DateInterval.Day, 30, Convert.ToDateTime(ROW("DEPARTURE")).Date) < Now.Date Then
            '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
            '            e.Appearance.BackColor = Color.Plum
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class