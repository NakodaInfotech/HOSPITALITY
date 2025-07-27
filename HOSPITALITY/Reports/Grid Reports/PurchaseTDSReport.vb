
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseTDSReport

    Private Sub PurchaseTDSReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
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
            If RDDETAILS.Checked = True Then
                gridbill.Columns("BILLINITIALS").Visible = True
                gridbill.Columns("GUESTNAME").Visible = True
                gridbill.Columns("HOTELNAME").Visible = True
                gridbill.Columns("DATE").Visible = True
                dt = objclsCMST.search(" * ", "", " PURCHASETDS ", WHERECLAUSE & " AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " ORDER BY DATE,BOOKINGNO")
            Else
                gridbill.Columns("BILLINITIALS").Visible = False
                gridbill.Columns("GUESTNAME").Visible = False
                gridbill.Columns("HOTELNAME").Visible = False
                gridbill.Columns("DATE").Visible = False
                dt = objclsCMST.search(" NAME, SUM(TOTALPUR) AS TOTALPUR, SUM(COMMPER) AS COMMPER, SUM(COMMRS) AS COMMRS, SUM(TDSPER) AS TDSPER, SUM(TDSRS) AS TDSRS, SUM(GRANDTOTAL) AS GRANDTOTAL ", "", " PURCHASETDS ", WHERECLAUSE & " AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY NAME ")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal TYPE As String, ByVal BOOKTYPE As String)
        Try
            If RDDETAILS.Checked = False Then Exit Sub
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                If TYPE = "BOOKING" Or TYPE = "TRANSFER" Then
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
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), gridbill.GetFocusedRowCellValue("TYPE"), gridbill.GetFocusedRowCellValue("TYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), gridbill.GetFocusedRowCellValue("TYPE"), gridbill.GetFocusedRowCellValue("TYPE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTDSReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Purchase TDS.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Purchase TDS"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase TDS", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class