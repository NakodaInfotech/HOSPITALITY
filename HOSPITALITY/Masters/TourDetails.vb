Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class TourDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TourDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" TOUR_NO AS TOURNO, TOUR_DATE AS DATE, ISNULL(TOUR_NAME, '') AS TOURNAME, ISNULL(TOUR_GRPSTRENGTH, 0) AS GRPSTRENGTH, ISNULL(TOUR_DAYS, 0) AS DAYS, TOUR_STARTDATE AS STARTDATE, TOUR_ENDDATE AS ENDDATE, ISNULL(TOUR_VISA, '') AS VISA, ISNULL(TOUR_PORT, '') AS PORT, ISNULL(TOUR_FAIZE, '') AS FAIZE, ISNULL(TOUR_SELF, '') AS TOURTYPE, ISNULL(TOUR_PKGADULT, 0) AS PKGADULT, ISNULL(TOUR_PKGCHILD, 0) AS PKGCHILD, ISNULL(TOUR_PKGINFANT, 0) AS PKGINFANT, ISNULL(TOUR_PROFITADULT, 0) AS PROFITADULT, ISNULL(TOUR_PROFITCHILD, 0) AS PROFITCHILD, ISNULL(TOUR_PROFITINFANT, 0) AS PROFITINFANT, ISNULL(TOUR_DECPKGADULT, 0) AS DECPKGADULT, ISNULL(TOUR_DECPKGCHILD, 0) AS DECPKGCHILD, ISNULL(TOUR_DECPKGINFANT, 0) AS DECPKGINFANT, ISNULL(TOUR_DECADULT, 0) AS DECADULT, ISNULL(TOUR_DECCHILD, 0) AS DECCHILD, ISNULL(TOUR_DECINFANT, 0) AS DECINFANT", "", " TOURMASTER", " AND TOUR_CMPID =" & CmpId & " AND TOUR_LOCATIONID = " & Locationid & " AND TOUR_YEARID = " & YearId & " ORDER BY TOURMASTER.TOUR_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New TourMaster
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPTOURNO = BOOKINGNO
                OBJBOOKING.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TOURNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TOURNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TourDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Tour Booking Details.XLS"

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

            opti.SheetName = "Tour Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Tour Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class