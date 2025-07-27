Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class DetailForm

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub DetailForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0, "")
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
            dt = objclsCMST.search("  HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, HOTELBOOKINGMASTER.BOOKING_REFNO AS REFNO, HOTELBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, ISNULL(GUESTMASTER.GUEST_EMAIL, '') AS EMAIL, HOTELMASTER.HOTEL_NAME AS HOTELNAME, LEDGERS.Acc_cmpname AS ACCNAME, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_DEPARTURE AS DEPARTURE, HOTELBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, HOTELBOOKINGMASTER.BOOKING_TOTALROOMS AS TOTALROOMS, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS PURTOTAL, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, HOTELBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, HOTELBOOKINGMASTER.BOOKING_AMD_DONE AS AMENDED, HOTELBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED, HOTELBOOKINGMASTER.BOOKING_SALEBALANCE AS BALANCE, HOTELBOOKINGMASTER.BOOKING_BILLCHECKED AS BILLCHECKED, HOTELBOOKINGMASTER.BOOKING_SALERETURN AS SALERETURN, HOTELBOOKINGMASTER.BOOKING_REFUNDED AS REFUNDED, HOTELBOOKINGMASTER.BOOKING_FAILED AS FAILED, ISNULL(ROOMTYPEMASTER.ROOMTYPE_NAME, '') AS ROOMTYPE, ISNULL(PLANMASTER.PLAN_NAME, '') AS [PLAN]", "", "    HOTELBOOKINGMASTER INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN USERMASTER ON HOTELBOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id INNER JOIN GUESTMASTER ON HOTELBOOKINGMASTER.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN HOTELBOOKINGMASTER_DESC ON HOTELBOOKINGMASTER.BOOKING_NO = HOTELBOOKINGMASTER_DESC.BOOKING_NO AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = HOTELBOOKINGMASTER_DESC.BOOKING_BOOKTYPE AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELBOOKINGMASTER_DESC.BOOKING_YEARID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELBOOKINGMASTER_DESC.BOOKING_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_PURCHASEREGISTERID = HOTELBOOKINGMASTER_DESC.BOOKING_PURREGID AND HOTELBOOKINGMASTER.BOOKING_SALEREGISTERID = HOTELBOOKINGMASTER_DESC.BOOKING_SALEREGID LEFT OUTER JOIN PLANMASTER ON HOTELBOOKINGMASTER_DESC.BOOKING_PLANID = PLANMASTER.PLAN_ID AND HOTELBOOKINGMASTER_DESC.BOOKING_CMPID = PLANMASTER.PLAN_CMPID AND HOTELBOOKINGMASTER_DESC.BOOKING_LOCATIONID = PLANMASTER.PLAN_LOCATIONID AND HOTELBOOKINGMASTER_DESC.BOOKING_YEARID = PLANMASTER.PLAN_YEARID LEFT OUTER JOIN ROOMTYPEMASTER ON HOTELBOOKINGMASTER_DESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELBOOKINGMASTER_DESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELBOOKINGMASTER_DESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELBOOKINGMASTER_DESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE ='" & CMBTYPE.Text.Trim & "' AND  HOTELBOOKINGMASTER.BOOKING_CMPID =" & CmpId & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY HOTELBOOKINGMASTER.BOOKING_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal BOOKINGNO As Integer, ByVal BOOKINGTYPE As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBOOKING As New HotelBookings
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                'OBJBOOKING.FRMSTRING = FRMSTRING
                OBJBOOKING.FRMSTRING = CMBTYPE.Text
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
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
            showform(False, 0, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), CMBTYPE.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"), CMBTYPE.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DetailForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DOMESTIC RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "TRANSFER" Then
                CMBTYPE.Text = "TRANSFER"
            Else
                CMBTYPE.Text = "BOOKING"
            End If

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If gridbill.RowFilter = "" Then
                If e.RowHandle >= 0 Then
                    Dim ROW As DataRow = DT.Rows(e.RowHandle)
                    Dim View As GridView = sender
                    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALERETURN")) > 0 Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Yellow

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("BILLCHECKED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightGreen

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DISPUTED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.LightBlue

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("FAILED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.Plum

                    ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("REFUNDED")) = "Checked" Then
                        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                        e.Appearance.BackColor = Color.PeachPuff
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Hotel Booking Details.XLS"

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

            opti.SheetName = "Hotel Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Hotel Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim tempMsg As Integer
            tempMsg = MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then
                serverprop()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub serverprop()
        'For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)

        '    'Dim RPTINV_SEASONED As New HotelBookingInvoice_SEASONED

        '    '**************** SET SERVER ************************
        '    Dim crtableLogonInfo As New TableLogOnInfo
        '    Dim crConnecttionInfo As New ConnectionInfo
        '    Dim crTables As Tables
        '    Dim crTable As Table

        '    With crConnecttionInfo
        '        .ServerName = SERVERNAME
        '        .DatabaseName = DatabaseName
        '        .UserID = DBUSERNAME
        '        .Password = Dbpassword
        '        .IntegratedSecurity = Dbsecurity
        '    End With

        '    crTables = RPTINV_SEASONED.Database.Tables

        '    For Each crTable In crTables
        '        crtableLogonInfo = crTable.LogOnInfo
        '        crtableLogonInfo.ConnectionInfo = crConnecttionInfo
        '        crTable.ApplyLogOnInfo(crtableLogonInfo)
        '    Next

        '    RPTINV_SEASONED.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        '    RPTINV_SEASONED.RecordSelectionFormula = "{HOTELBOOKINGMASTER.BOOKING_NO}=" & Val(I) & "  and {HOTELBOOKINGMASTER.BOOKING_cmpid}=" & CmpId & " and {HOTELBOOKINGMASTER.BOOKING_locationid}=" & Locationid & " and {HOTELBOOKINGMASTER.BOOKING_yearid}=" & YearId
        '    RPTINV_SEASONED.PrintToPrinter(1, True, 0, 0)
        'Next
    End Sub
End Class