
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReservationDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public STRSEARCH As String
    Public FRMSTRING As String

    Private Sub ReservationDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0, "HOTELBOOKING", "BOOKING")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" *, ROUND((SALEAMT-TAX),2) AS GROSSSALE, ISNULL(CMPMASTER.cmp_name, '') AS CMPNAME, ISNULL(CMPMASTER.cmp_GSTIN, '') AS CMPGST ", "", " RESERVATION_SALEREPORT INNER JOIN CMPMASTER ON RESERVATION_SALEREPORT.CMPID = CMPMASTER.cmp_id ", WHERECLAUSE & " ORDER BY TYPE, BOOKTYPE, BILL")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
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
                ElseIf TYPE = "VISABOOKING" Then
                    Dim OBJBOOKING As New VisaBooking
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
                ElseIf TYPE = "OTHERSALEPURCHASE" Then
                    Dim OBJBOOKING As New OtherSalePurchase
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

    Private Sub ReservationDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "RAIL DETAILS" Or FRMSTRING = "RAIL SUMMARY" Then
                gridbill.Columns("GUESTNAME").Caption = "Passenger Name"
                gridbill.Columns("HOTELNAME").Caption = "Train Name"
                gridbill.Columns("ARRIVAL").Caption = "Travel Dt"
            End If
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
                    Dim View As GridView = sender

                    'MsgBox(ROW("BOOKINGNO"))
                    e.Appearance.BackColor = Color.Empty

                    '5 DAYS LEFT FOR CHECKIN
                    Dim A As Date = DateAdd(DateInterval.Day, 7, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date)
                    Dim I As Integer = DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date)
                    If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALEBAL"))) = 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.White

                    ElseIf DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date) <= 5 And DateDiff(DateInterval.Day, Now.Date, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ARRIVAL"))).Date) > 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen

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
                        e.Appearance.BackColor = Color.MistyRose

                        'AFTER 1 MONTH OF CHECKOUT
                    ElseIf DateAdd(DateInterval.Day, 30, Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DEPARTURE"))).Date) < Now.Date Then
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
            PATH = Application.StartupPath & "\Reservation Details.XLS"

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
            EXCELCMPHEADER(PATH, "Reservation Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReservationDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TRAVELBRIDGE" Then
                GDISPLAYNAME.VisibleIndex = GGUESTNAME.VisibleIndex
                GGUESTNAME.Visible = False
                GPURDISPLAYNAME.Visible = True
                GPURDISPLAYNAME.VisibleIndex = GPURNAME.VisibleIndex + 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class