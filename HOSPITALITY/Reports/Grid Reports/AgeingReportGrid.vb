
Imports BL

Public Class AgeingReportGrid

    Private Sub AgeingReportGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
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
            Dim dt As DataTable
            dt = objclsCMST.search(" SALELEDGER, BOOKINGNO, BOOKTYPE, TYPE, DATE, HOTELNAME, (CASE WHEN CRDAYS >0 AND CRDAYS<31 THEN SALEBAL ELSE 0 END) AS [30],(CASE WHEN CRDAYS >30 AND CRDAYS<46 THEN SALEBAL ELSE 0 END) AS [45], (CASE WHEN CRDAYS >45 AND CRDAYS<61 THEN SALEBAL ELSE 0 END) AS [60], (CASE WHEN CRDAYS >60 AND CRDAYS<91 THEN SALEBAL ELSE 0 END) AS [90], (CASE WHEN CRDAYS >90 THEN SALEBAL ELSE 0 END) AS [GREATER], BILL, BOOKEDBY", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & " AND SALEBAL > 0 AND CRDAYS > 0 AND CANCELLED = 'FALSE' AND AMENDED = 'FALSE'  AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY TYPE, BILL")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal TYPE As String, Optional ByVal BOOKTYPE As String = "")
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                If TYPE = "HOLIDAYPACKAGE" Then
                    Dim OBJBOOKING As New HolidayPackage
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.edit = editval
                    OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                    OBJBOOKING.Show()
                Else
                    Dim OBJBOOKING As New HotelBookings
                    OBJBOOKING.MdiParent = MDIMain
                    OBJBOOKING.FRMSTRING = BOOKTYPE
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

    Private Sub AgeingReportGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Ageing Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = ""
            If chkdate.CheckState = CheckState.Unchecked Then
                PERIOD = DateAdd(DateInterval.Day, 1, Now.Date) & " - " & DateAdd(DateInterval.Day, 1, Now.Date)
            Else
                PERIOD = dtfrom.Value.Date & " - " & dtto.Value.Date
            End If

            opti.SheetName = "Ageing Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ageing Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class