
Imports BL

Public Class AirlineStockDetails
    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub AirlineStockDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
                showform(False, 0)
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            If FRMSTRING = "BSP" Then
                dt = objclsCMST.search(" STOCK_ID AS SRNO, STOCK_TYPE AS TYPE, '' AS PURNAME,  FLIGHTMASTER.FLIGHT_CODE AS CODE, FLIGHTMASTER.FLIGHT_NAME AS NAME, COUNT(AIRLINESTOCKMASTER_DESC.ID) AS TOTAL, AIRLINESTOCKMASTER.STOCK_ISSUED AS ISSUED, AIRLINESTOCKMASTER.STOCK_PTA AS PTA, AIRLINESTOCKMASTER.STOCK_SPECIAL AS SPECIAL ", "", "  AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID ", tempcondition & " AND STOCK_CMPID = " & CmpId & " AND STOCK_LOCATIONID = " & Locationid & " AND STOCK_YEARID = " & YearId & " AND STOCK_TYPE='" & FRMSTRING & "' GROUP BY STOCK_ID, STOCK_TYPE, FLIGHTMASTER.FLIGHT_CODE , FLIGHTMASTER.FLIGHT_NAME , AIRLINESTOCKMASTER.STOCK_ISSUED , AIRLINESTOCKMASTER.STOCK_PTA , AIRLINESTOCKMASTER.STOCK_SPECIAL ")
            ElseIf FRMSTRING = "COUPON" Then
                dt = objclsCMST.search(" AIRLINESTOCKMASTER.STOCK_ID AS SRNO, AIRLINESTOCKMASTER.STOCK_TYPE AS TYPE, LEDGERS.Acc_cmpname AS PURNAME, FLIGHTMASTER.FLIGHT_CODE AS CODE, FLIGHTMASTER.FLIGHT_NAME AS NAME, COUNT(AIRLINESTOCKMASTER_DESC.ID) AS TOTAL, AIRLINESTOCKMASTER.STOCK_ISSUED AS ISSUED, AIRLINESTOCKMASTER.STOCK_PTA AS PTA, AIRLINESTOCKMASTER.STOCK_SPECIAL AS SPECIAL ", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN LEDGERS ON AIRLINESTOCKMASTER.STOCK_YEARID = LEDGERS.Acc_yearid AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINESTOCKMASTER.STOCK_CMPID = LEDGERS.Acc_cmpid AND AIRLINESTOCKMASTER.STOCK_PURLEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID  ", tempcondition & " AND STOCK_CMPID = " & CmpId & " AND STOCK_LOCATIONID = " & Locationid & " AND STOCK_YEARID = " & YearId & " AND STOCK_TYPE='" & FRMSTRING & "' GROUP BY AIRLINESTOCKMASTER.STOCK_ID, AIRLINESTOCKMASTER.STOCK_TYPE, LEDGERS.Acc_cmpname, FLIGHTMASTER.FLIGHT_CODE, FLIGHTMASTER.FLIGHT_NAME, AIRLINESTOCKMASTER.STOCK_ISSUED, AIRLINESTOCKMASTER.STOCK_PTA, AIRLINESTOCKMASTER.STOCK_SPECIAL ")
            End If
            griddetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridcontra.FocusedRowHandle = gridcontra.RowCount - 1
                gridcontra.TopRowIndex = gridcontra.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal billno As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridcontra.RowCount > 0) Then
                Dim OBJAIRLINE As New AirlineStockMaster
                OBJAIRLINE.MdiParent = MDIMain
                OBJAIRLINE.edit = editval
                OBJAIRLINE.TEMPAIRLINEID = billno
                OBJAIRLINE.FRMSTRING = FRMSTRING
                OBJAIRLINE.Show()
                'Me.Close()
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

    Private Sub gridcontra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridcontra.DoubleClick
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridcontra.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineStockDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'FLIGHT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\BSP Stock Details.XLS"

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

            opti.SheetName = "BSP Stock Details"
            gridcontra.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "BSP Stock Details", gridcontra.VisibleColumns.Count + gridcontra.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineStockDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "TOPCOMM" Then Me.Close()
    End Sub
End Class