
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PackageQuotationDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub PackageEnquiryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" HOLIDAYENQMASTER.ENQ_NO AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(HOLIDAYENQMASTER.ENQ_REFNO, '') AS REFNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, HOLIDAYENQMASTER.ENQ_TOURNAME AS TOURNAME, HOLIDAYENQMASTER.ENQ_PACKAGEFROM AS PACKAGEFROM, HOLIDAYENQMASTER.ENQ_PACKAGETO AS PACKAGETO, HOLIDAYENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOLIDAYENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL, HOLIDAYENQMASTER.ENQ_DONE AS DONE, HOLIDAYENQMASTER.ENQ_REMARKS AS REMARKS, HOLIDAYENQMASTER.ENQ_QUOTEPENDING AS QUOTEPENDING, HOLIDAYENQMASTER.ENQ_AMENDED AS AMENDED, HOLIDAYENQMASTER.ENQ_SUBTOTAL - HOLIDAYENQMASTER.ENQ_COSTPRICE AS COMM ", "", " HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID", " AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER.ENQ_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBOOKEDBYGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" HOLIDAYENQMASTER.ENQ_NO AS ENQNO, HOLIDAYENQMASTER.ENQ_DATE AS ENQDATE, ISNULL(HOLIDAYENQMASTER.ENQ_REFNO, '') AS REFNO, GUESTMASTER.GUEST_NAME AS GUESTNAME, HOLIDAYENQMASTER.ENQ_TOURNAME AS TOURNAME, HOLIDAYENQMASTER.ENQ_PACKAGEFROM AS PACKAGEFROM, HOLIDAYENQMASTER.ENQ_PACKAGETO AS PACKAGETO, HOLIDAYENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOLIDAYENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL, HOLIDAYENQMASTER.ENQ_DONE AS DONE, HOLIDAYENQMASTER.ENQ_REMARKS AS REMARKS, HOLIDAYENQMASTER.ENQ_QUOTEPENDING AS QUOTEPENDING, HOLIDAYENQMASTER.ENQ_AMENDED AS AMENDED, HOLIDAYENQMASTER.ENQ_SUBTOTAL - HOLIDAYENQMASTER.ENQ_COSTPRICE AS COMM ", "", "  HOLIDAYENQMASTER INNER JOIN GUESTMASTER ON HOLIDAYENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOLIDAYENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOLIDAYENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOLIDAYENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN BOOKEDBYMASTER ON HOLIDAYENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOLIDAYENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' AND ENQ_YEARID = " & YearId & " ORDER BY HOLIDAYENQMASTER.ENQ_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ENQNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJENQ As New PackageQuotation
                OBJENQ.MdiParent = MDIMain
                OBJENQ.edit = editval
                OBJENQ.TEMPENQNO = ENQNO
                OBJENQ.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ENQNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ENQNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PackageEnquiryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PACKAGE ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If ClientName = "VIDHI" Then
                If UserName <> "Admin" Then
                    FILLBOOKEDBYGRID()
                Else
                    fillgrid()
                End If
            Else
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJDTLS As New PackageQuotationGridDetails
            OBJDTLS.MdiParent = MDIMain
            OBJDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HolidayPackageDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "MATRIX" Then Me.Close()
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Package Enquiry Details.XLS"

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

            opti.SheetName = "Package Enquiry Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Package Enquiry Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Friend Function DT() As DataTable
        Throw New NotImplementedException()
    End Function

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try

            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("QUOTEPENDING")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightBlue
                ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("AMENDED"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class