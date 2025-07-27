Imports BL

Public Class AirReservationDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public STRSEARCH As String


    Private Sub AirReservationDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0, "DOMESTIC", "")
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
            Dim dt As DataTable
            'dt = objclsCMST.search(" CASE WHEN D.PAX > 1 THEN m.BOOKING_PASSNAME + ' * ' + CAST(d.PAX AS VARCHAR) ELSE M.BOOKING_PASSNAME END AS PASSNAME ,m.BILL ,m.BOOKINGNO ,m.BOOKTYPE ,m.DATE,m.GUESTNAME,m.AIRLINENAME,m.ARRIVAL,m.DEPARTURE,m.BOOKEDBY,m.CONFIRMEDBY,m.PURAMT,m.PURBAL,m.SALEAMT,m.SALEBAL,m.TYPE,m.CANCELLED,m.AMENDED,m.CMPID,m.LOCATIONID,m.YEARID,m.SALELEDGER,m.PURLEDGER,m.REFNO,m.GROUPNAME,m.GROSSAMT,m.ROOMS,m.NIGHTS,m.TOTALNIGHTS,m.GROSSPERCENT,m.CRDAYS,m.BOOKING_PNRNO,m.BOOKING_AIRLINEPNR,m.BOOKING_CRSPNR ", "", " AIRRESERVATION_SALEREPORT as m inner join ( SELECT count([BOOKING_GRIDSRNO])  as PAX ,[BILL],[BOOKINGNO],[BOOKTYPE],[DATE],[GUESTNAME],[AIRLINENAME],[ARRIVAL],[DEPARTURE],[BOOKEDBY],[CONFIRMEDBY],[PURAMT],[PURBAL],[SALEAMT],[SALEBAL],[TYPE],[CANCELLED],[AMENDED],[CMPID],[LOCATIONID],[YEARID],[SALELEDGER],[PURLEDGER],[REFNO],[GROUPNAME],[GROSSAMT],[ROOMS],[NIGHTS],[TOTALNIGHTS],[GROSSPERCENT],[CRDAYS],[BOOKING_PNRNO],[BOOKING_AIRLINEPNR],[BOOKING_CRSPNR] FROM [HOSPITALITY].[dbo].[AIRRESERVATION_SALEREPORT] GROUP BY [BILL],[BOOKINGNO],[BOOKTYPE],[DATE],[GUESTNAME],[AIRLINENAME],[ARRIVAL],[DEPARTURE],[BOOKEDBY],[CONFIRMEDBY],[PURAMT],[PURBAL],[SALEAMT],[SALEBAL],[TYPE],[CANCELLED],[AMENDED],[CMPID],[LOCATIONID],[YEARID],[SALELEDGER],[PURLEDGER],[REFNO],[GROUPNAME],[GROSSAMT],[ROOMS],[NIGHTS],[TOTALNIGHTS],[GROSSPERCENT],[CRDAYS],[BOOKING_PNRNO],[BOOKING_AIRLINEPNR],[BOOKING_CRSPNR]) as d on m.BILL = d.BILL and m.BOOKINGNO = d.BOOKINGNO and m.CMPID = d.CMPID and m.LOCATIONID = d.LOCATIONID and m.YEARID = d.YEARID ", " AND m.BOOKING_GRIDSRNO = 1 " & WHERECLAUSE & " AND m.CMPID =" & CmpId & " AND m.LOCATIONID = " & Locationid & " AND m.YEARID = " & YearId & " ORDER BY m.BILL")
            dt = objclsCMST.search(" CASE WHEN D .PAX > 1 THEN m.BOOKING_PASSNAME + ' * ' + CAST(d .PAX AS VARCHAR) ELSE M.BOOKING_PASSNAME END AS PASSNAME, m.BILL, m.BOOKINGNO, m.BOOKTYPE, m.DATE, m.GUESTNAME, m.AIRLINENAME, m.ARRIVAL, m.DEPARTURE, m.BOOKEDBY, m.CONFIRMEDBY, m.PURAMT, m.PURBAL, m.SALEAMT, m.SALEBAL, m.TYPE, m.CANCELLED, m.AMENDED, m.CMPID, m.LOCATIONID, m.YEARID, m.SALELEDGER, m.PURLEDGER, m.REFNO, m.GROUPNAME, m.GROSSAMT, m.ROOMS, m.NIGHTS, m.TOTALNIGHTS, m.GROSSPERCENT, m.CRDAYS, m.BOOKING_PNRNO, m.BOOKING_AIRLINEPNR, m.BOOKING_CRSPNR, m.REGISTERNAME, m.DOMINT ", "", " AIRRESERVATION_SALEREPORT AS m INNER JOIN (SELECT        COUNT(BOOKING_GRIDSRNO) AS PAX, BILL, BOOKINGNO, BOOKTYPE, DATE, GUESTNAME, AIRLINENAME, ARRIVAL, DEPARTURE, BOOKEDBY, CONFIRMEDBY, PURAMT, PURBAL, SALEAMT, SALEBAL, TYPE, CANCELLED, AMENDED, CMPID, LOCATIONID, YEARID, SALELEDGER, PURLEDGER, REFNO, GROUPNAME, GROSSAMT, ROOMS, NIGHTS, TOTALNIGHTS, GROSSPERCENT, CRDAYS, BOOKING_PNRNO, BOOKING_AIRLINEPNR, BOOKING_CRSPNR FROM            AIRRESERVATION_SALEREPORT GROUP BY BILL, BOOKINGNO, BOOKTYPE, DATE, GUESTNAME, AIRLINENAME, ARRIVAL, DEPARTURE, BOOKEDBY, CONFIRMEDBY, PURAMT, PURBAL, SALEAMT, SALEBAL, TYPE, CANCELLED, AMENDED, CMPID, LOCATIONID, YEARID, SALELEDGER, PURLEDGER, REFNO, GROUPNAME, GROSSAMT, ROOMS, NIGHTS, TOTALNIGHTS, GROSSPERCENT, CRDAYS, BOOKING_PNRNO, BOOKING_AIRLINEPNR, BOOKING_CRSPNR) AS d ON m.BILL = d.BILL AND m.BOOKINGNO = d.BOOKINGNO AND m.CMPID = d.CMPID AND m.LOCATIONID = d.LOCATIONID AND m.YEARID = d.YEARID ", " AND m.BOOKING_GRIDSRNO = 1 " & WHERECLAUSE & " AND m.CMPID =" & CmpId & " AND m.LOCATIONID = " & Locationid & " AND m.YEARID = " & YearId & " ORDER BY m.BILL")
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
            Else
                gridbilldetails.DataSource = dt
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal TYPE As String, ByVal BOOKTYPE As String)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New AirlineBookings
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.FRMSTRING = TYPE
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
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
            Dim TYPE As String() = gridbill.GetFocusedRowCellValue("BOOKINGNO").ToString.Split("-")
            Dim STR As String = ""
            If TYPE(0) = "AS" Then
                STR = "DOMESTIC"
            Else
                STR = "INTERNATIONAL"
            End If
            showform(True, gridbill.GetFocusedRowCellValue("BILL"), STR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            Dim TYPE As String() = gridbill.GetFocusedRowCellValue("BOOKINGNO").ToString.Split("-")
            Dim STR As String = ""
            If TYPE(0) = "AS" Then
                STR = "DOMESTIC"
            Else
                STR = "INTERNATIONAL"
            End If
            showform(True, gridbill.GetFocusedRowCellValue("BILL"), STR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirReservationDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(STRSEARCH)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            gridbill.OptionsSelection.EnableAppearanceFocusedRow = False
            Dim DT As DataTable = gridbilldetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)

                    'MsgBox(ROW("BOOKINGNO"))
                    e.Appearance.BackColor = Color.Empty

                    '5 DAYS LEFT FOR CHECKIN
                    Dim A As Date = DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date)
                    Dim I As Integer = DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(ROW("ARRIVAL")).Date)
                    If Val(ROW("SALEBAL")) = 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.White

                    ElseIf DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(ROW("ARRIVAL")).Date) <= 5 And DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(ROW("ARRIVAL")).Date) > 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen

                        'CHECKED IN
                    ElseIf Convert.ToDateTime(ROW("ARRIVAL")).Date <= Now.Date And Convert.ToDateTime(ROW("DEPARTURE")).Date > Now.Date Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow

                        'CHECKED OUT
                        'ElseIf Convert.ToDateTime(ROW("DEPARTURE")).Date <= Now.Date And DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date) > Now.Date Then
                        '    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        '    e.Appearance.BackColor = Color.Orange

                        'AFTER 1 WEEK OF CHECK OUT
                    ElseIf DateAdd(DateInterval.Day, 7, Convert.ToDateTime(ROW("DEPARTURE")).Date) <= Now.Date And DateAdd(DateInterval.Day, 30, Convert.ToDateTime(ROW("DEPARTURE")).Date) > Now.Date Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Red

                        'AFTER 1 MONTH OF CHECKOUT
                    ElseIf DateAdd(DateInterval.Day, 30, Convert.ToDateTime(ROW("DEPARTURE")).Date) < Now.Date Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Plum
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Airline Reservation Details.XLS"

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

            opti.SheetName = "Reservation Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Airline Reservation Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class