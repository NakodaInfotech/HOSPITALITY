
Imports BL

Public Class HotelQuotationDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub HotelEnquiryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            dt = objclsCMST.search("  HOTELENQMASTER.ENQ_NO AS ENQNO, HOTELENQMASTER.ENQ_REFNO AS REFNO, HOTELENQMASTER.ENQ_DATE AS ENQDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, HOTELMASTER.HOTEL_NAME AS HOTELNAME, HOTELENQMASTER.ENQ_ARRIVAL AS ARRIVAL, HOTELENQMASTER.ENQ_DEPARTURE AS DEPARTURE, HOTELENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOTELENQMASTER.ENQ_TOTALROOMS AS TOTALROOMS, HOTELENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL,  USERMASTER.User_Name AS USERNAME, HOTELENQMASTER.ENQ_DONE AS DONE, (HOTELENQMASTER.ENQ_SUBTOTAL - HOTELENQMASTER.ENQ_COSTPRICE) AS OURCOMM ", "", "   HOTELENQMASTER INNER JOIN HOTELMASTER ON HOTELENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELENQMASTER.ENQ_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN USERMASTER ON HOTELENQMASTER.ENQ_USERID = USERMASTER.User_id INNER JOIN GUESTMASTER ON HOTELENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOTELENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID ", " AND ENQ_CMPID =" & CmpId & " AND ENQ_LOCATIONID = " & Locationid & " AND ENQ_YEARID = " & YearId & " ORDER BY HOTELENQMASTER.ENQ_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDBOOKEDBYWISE()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" HOTELENQMASTER.ENQ_NO AS ENQNO, HOTELENQMASTER.ENQ_REFNO AS REFNO, HOTELENQMASTER.ENQ_DATE AS ENQDATE, GUESTMASTER.GUEST_NAME AS GUESTNAME, HOTELMASTER.HOTEL_NAME AS HOTELNAME, HOTELENQMASTER.ENQ_ARRIVAL AS ARRIVAL, HOTELENQMASTER.ENQ_DEPARTURE AS DEPARTURE, HOTELENQMASTER.ENQ_TOTALPAX AS TOTALPAX, HOTELENQMASTER.ENQ_TOTALROOMS AS TOTALROOMS, HOTELENQMASTER.ENQ_GRANDTOTAL AS GRANDTOTAL, USERMASTER.User_Name AS USERNAME, HOTELENQMASTER.ENQ_DONE AS DONE, (HOTELENQMASTER.ENQ_SUBTOTAL - HOTELENQMASTER.ENQ_COSTPRICE) AS OURCOMM, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY ", "", " HOTELENQMASTER INNER JOIN HOTELMASTER ON HOTELENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELENQMASTER.ENQ_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN USERMASTER ON HOTELENQMASTER.ENQ_USERID = USERMASTER.User_id INNER JOIN GUESTMASTER ON HOTELENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOTELENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN BOOKEDBYMASTER ON HOTELENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' AND ENQ_YEARID = " & YearId & " ORDER BY HOTELENQMASTER.ENQ_NO")
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
                Dim OBJENQ As New HotelQuotation
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

    Private Sub HotelEnquiryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DOMESTIC ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If ClientName = "VIDHI" Then
                If UserName <> "Admin" Then
                    FILLGRIDBOOKEDBYWISE()
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

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Hotel Enquiry Details.XLS"

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

            opti.SheetName = "Hotel Enquiry Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Hotel Enquiry Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelQuotationDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "MATRIX" Then Me.Close()

    End Sub
End Class