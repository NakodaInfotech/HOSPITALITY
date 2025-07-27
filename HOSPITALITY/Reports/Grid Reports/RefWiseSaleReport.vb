
Imports BL

Public Class RefWiseSaleReport

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String = ""

    Private Sub RefWiseSaleReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            If ClientName = "CLASSIC" And UserName <> "Admin" Then If USERVIEW = False Then WHERECLAUSE = WHERECLAUSE & " AND BOOKEDBY = '" & UserName & "' "
            If FRMSTRING = "SALEBALANCE" Then
                dt = objclsCMST.search(" REFNO, SUM(SALEAMT) AS BILLAMT, SUM(SALEBAL) AS DEBITBAL , 0 AS CREDITBAL ", "", " RESERVATION_SALEREPORT ", WHERECLAUSE & " AND CANCELLED = 0 AND SALEAMT > 0 AND SALEBAL > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY REFNO ")
            ElseIf FRMSTRING = "PURBALANCE" Then
                dt = objclsCMST.search(" REFNO, SUM(GTOTAL) AS BILLAMT, 0 AS DEBITBAL, SUM(CREDITBALANCE) AS CREDITBAL ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY REFNO ")
            ElseIf FRMSTRING = "ALLBALANCE" Then
                dt = objclsCMST.search(" * ", "", "( SELECT REFNO, SUM(GTOTAL) AS BILLAMT, 0 AS DEBITBAL, SUM(CREDITBALANCE) AS CREDITBAL FROM RESERVATIONDETAILS WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 0 AND CREDIT > 0 AND CREDITBALANCE > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY REFNO UNION ALL SELECT REFNO, SUM(SALEAMT) AS BILLAMT, SUM(SALEBAL) AS DEBITBAL , 0 AS CREDITBAL FROM RESERVATION_SALEREPORT WHERE 1 = 1 " & WHERECLAUSE & " AND CANCELLED = 'FALSE' AND SALEAMT > 0 AND SALEBAL > 0 AND CMPID =" & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId & " GROUP BY REFNO) AS T", " ")
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
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
            Dim OBJREF As New RefWiseSaleDetails
            OBJREF.FRMSTRING = FRMSTRING
            OBJREF.WHERESTRING = " AND REFNO = '" & gridbill.GetFocusedRowCellValue("REFNO") & "'"
            OBJREF.MdiParent = MDIMain
            OBJREF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefWiseSaleReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            If FRMSTRING = "SALEBALANCE" Then
                Me.Text = "Ref Wise Sale Report"
            ElseIf FRMSTRING = "PURBALANCE" Then
                Me.Text = "Ref Wise Purchase Report"
            ElseIf FRMSTRING = "ALLBALANCE" Then
                Me.Text = "Ref Wise Pur - Sale Report"
            End If
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
            PATH = Application.StartupPath & "\Ref Wise Booking.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()

            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "Ref Wise Booking"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Ref Wise Booking", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class