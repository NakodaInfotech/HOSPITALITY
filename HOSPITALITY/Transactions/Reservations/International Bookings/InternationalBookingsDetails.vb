
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class InternationalBookingsDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean

    Private Sub InternationalBookingsDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BOOKINGNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS BOOKINGDATE, ACCOUNTSMASTER.Acc_cmpname AS ACCNAME, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED AS CANCELLED, INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE AS AMENDED, INTERNATIONALBOOKINGMASTER.BOOKING_DISPUTE AS DISPUTED ", "", " INTERNATIONALBOOKINGMASTER INNER JOIN ACCOUNTSMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = ACCOUNTSMASTER.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = ACCOUNTSMASTER.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = ACCOUNTSMASTER.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = ACCOUNTSMASTER.Acc_yearid INNER JOIN USERMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_USERID = USERMASTER.User_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = USERMASTER.User_cmpid", " AND BOOKING_CMPID =" & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId & " ORDER BY INTERNATIONALBOOKINGMASTER.BOOKING_NO")
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt

                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15

            Else
                gridbilldetails.DataSource = dt
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
                Dim OBJBOOKING As New InternationalBookings
                OBJBOOKING.MdiParent = MDIMain
                OBJBOOKING.edit = editval
                OBJBOOKING.TEMPBOOKINGNO = BOOKINGNO
                OBJBOOKING.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("BOOKINGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InternationalBookingsDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'INTERNATIONAL RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                If ROW("CANCELLED") = "TRUE" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow

                ElseIf ROW("AMENDED") = "TRUE" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightGreen

                ElseIf ROW("DISPUTED") = "TRUE" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightBlue

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InternationalBookingsDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "TOPCOMM" Then Me.Close()
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Then Me.Close()
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\International Booking Details.XLS"

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

            opti.SheetName = "International Booking Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "International Booking Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
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
        For I As Integer = 0 To (TXTTO.Text - TXTFROM.Text)

            Dim OBJINV As New InternationalVoucherdESIGN
            Dim RPTINV As New InternationalInvoice
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table

            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            crTables = RPTINV.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            OBJINV.MdiParent = MDIMain
            RPTINV.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            RPTINV.RecordSelectionFormula = "{INVOICEMASTER.INVOICE_no}=" & Val(I) & "  and {INVOICEMASTER.INVOICE_cmpid}=" & CmpId & " and {INVOICEMASTER.INVOICE_locationid}=" & Locationid & " and {INVOICEMASTER.INVOICE_yearid}=" & YearId
            RPTINV.PrintToPrinter(1, True, 0, 0)
        Next
    End Sub
End Class