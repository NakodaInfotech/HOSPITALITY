Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class RegistrationDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub RegistrationDeatils_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            dt = objclsCMST.search(" REGISTRATIONMASTER.REG_NO AS NO,REGISTRATIONMASTER.REG_PERSONTYPE AS PERSONTYPE, REGISTRATIONMASTER.REG_INVNO AS REGNO, REGISTRATIONMASTER.REG_DATE AS DATE,ISNULL(TOURMASTER.TOUR_NAME, '') AS TOURNAME, ISNULL(REGISTRATIONMASTER.REG_GRPSTRENGTH, 0) AS STRNGTH,REGISTRATIONMASTER.REG_STARTDATE AS STARTDATE, REGISTRATIONMASTER.REG_ENDDATE AS ENDDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS SALENAME,ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUEST, ISNULL(HOF.GUEST_NAME, '') AS HOF, ISNULL(REGISTRATIONMASTER.REG_PURTOTALADULT, 0)AS PURADULT, ISNULL(REGISTRATIONMASTER.REG_PURTOTALCHILD, 0) AS PURCHILD, ISNULL(REGISTRATIONMASTER.REG_PURTOTALINFANT, 0) AS PURINFANT,ISNULL(REGISTRATIONMASTER.REG_CUSTADULT, 0) AS CUSTADULT, ISNULL(REGISTRATIONMASTER.REG_CUSTCHILD, 0) AS CUSTCHILD, ISNULL(REGISTRATIONMASTER.REG_CUSTINFANT, 0) AS CUSTINFANT, ISNULL(REGISTRATIONMASTER.REG_SALEADDADULT, 0) AS ADDADULT, ISNULL(REGISTRATIONMASTER.REG_SALEADDCHILD, 0) AS ADDCHILD, ISNULL(REGISTRATIONMASTER.REG_SALEADDINFANT, 0) AS ADDINFANT, ISNULL(REGISTRATIONMASTER.REG_SALETOTALADULT, 0) AS SALETOTALADULT, ISNULL(REGISTRATIONMASTER.REG_SALETOTALCHILD, 0) AS SALETOTALCHILD, ISNULL(REGISTRATIONMASTER.REG_SALETOTALINFANT, 0) AS SALETOTALINFANT, ISNULL(REGISTRATIONMASTER.REG_PROFFIT, 0) AS PROFIT, ISNULL(REGISTRATIONMASTER.REG_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " GUESTMASTER RIGHT OUTER JOIN LEDGERS INNER JOIN REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ON LEDGERS.Acc_id = REGISTRATIONMASTER.REG_SALEID AND LEDGERS.Acc_yearid = REGISTRATIONMASTER.REG_YEARID LEFT OUTER JOIN GUESTMASTER AS HOF ON REGISTRATIONMASTER.REG_YEARID = HOF.GUEST_YEARID AND REGISTRATIONMASTER.REG_HOFID = HOF.GUEST_ID ON GUESTMASTER.GUEST_YEARID = REGISTRATIONMASTER.REG_YEARID AND GUESTMASTER.GUEST_ID = REGISTRATIONMASTER.REG_GUESTID", " AND REG_CMPID =" & CmpId & " AND REG_LOCATIONID = " & Locationid & " AND REG_YEARID = " & YearId & " ORDER BY REGISTRATIONMASTER.REG_NO")
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
                Dim OBJBOOKING As New RegistrationMaster
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPREGNO = BOOKINGNO
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
            showform(True, gridbill.GetFocusedRowCellValue("REGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("NO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegistrationDeatils_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Registration Booking Details.XLS"

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

            opti.SheetName = "Registration Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Registration Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegistrationDeatils_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "FINASTA" Then Me.Close()
    End Sub
End Class