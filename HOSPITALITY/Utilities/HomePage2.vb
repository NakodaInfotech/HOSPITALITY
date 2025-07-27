Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class HomePage2

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String
    Dim TOURDATE As String
    Dim a1, a2, a3, a4 As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub HomePage2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'REGISTRATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HomePage2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            getFromToDate()
            dt = objclsCMST.search("  TOURMASTER.TOUR_GRPSTRENGTH - COUNT(REGISTRATIONMASTER.REG_PERSONTYPE) AS BALANCE, TOURMASTER.TOUR_NAME AS TOURNAME, TOURMASTER.TOUR_NO AS TOURNO, TOURMASTER.TOUR_DATE AS TOURDATE, TOURMASTER.TOUR_GRPSTRENGTH AS GROUPSTRENGTH, TOURMASTER.TOUR_STARTDATE AS STARTDATE, TOURMASTER.TOUR_ENDDATE AS ENDDATE, TOURMASTER.TOUR_DAYS AS DAYS, ISNULL(TOURMASTER.TOUR_DECPKGADULT, 0) AS ADULT, ISNULL(TOURMASTER.TOUR_DECPKGCHILD, 0) AS CHILD, ISNULL(TOURMASTER.TOUR_DECPKGINFANT, 0) AS INFANT, TOURMASTER.TOUR_CUTOFDATE AS CUTOFDATE, DATEDIFF(day,'" & TOURDATE & "' ,TOUR_CUTOFDATE) AS CUTOFDAYS ", "", " TOURMASTER LEFT OUTER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID AND TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID ", " and (REGISTRATIONMASTER.REG_PERSONTYPE = 'ADULT' OR REGISTRATIONMASTER.REG_PERSONTYPE = 'CHILD') AND TOUR_STARTDATE>'" & TOURDATE & "' AND TOUR_YEARID = " & YearId & " GROUP BY TOURMASTER.TOUR_NAME, TOURMASTER.TOUR_NO, TOURMASTER.TOUR_DATE, TOURMASTER.TOUR_GRPSTRENGTH, TOURMASTER.TOUR_STARTDATE, TOURMASTER.TOUR_ENDDATE, TOURMASTER.TOUR_DAYS, ISNULL(TOURMASTER.TOUR_DECPKGADULT, 0), ISNULL(TOURMASTER.TOUR_DECPKGCHILD, 0), ISNULL(TOURMASTER.TOUR_DECPKGINFANT, 0), TOURMASTER.TOUR_CUTOFDATE, ISNULL(TOURMASTER.TOUR_CUTOFDAYS, 0) ORDER BY TOURMASTER.TOUR_NO")
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

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TOURNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, Mydate.Date)
        a2 = DatePart(DateInterval.Month, Mydate.Date)
        a3 = DatePart(DateInterval.Year, Mydate.Date)
        TOURDATE = "" & a3 & "-" & a2 & "-" & a1 & ""
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

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class