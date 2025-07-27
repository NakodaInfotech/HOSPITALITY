Imports System.Windows.Forms
Imports BL


Public Class DeleteDetails

    Public TEMPID As Integer

    Sub FILLGRID()
        Try
            Dim Objcls As New ClsCommonMaster
            Dim dt As DataTable
            dt = Objcls.search(" CAST(0 AS BIT) AS CHK, DELETE_LOGS.DELETE_ID AS ID,DELETE_LOGS.DELETE_TABLE AS [TABLE], DELETE_LOGS.DELETE_REMARKS + ' ' + cast(DELETE_LOGS.DELETE_DATE as varchar(100)) AS REMARKS, USERMASTER.User_Name AS [USER], CMPMASTER.cmp_name AS CMPNAME,DELETE_LOGS.DELETE_DATE as DATE ", " ", "  DELETE_LOGS INNER JOIN CMPMASTER ON DELETE_LOGS.DELETE_CMPID = CMPMASTER.cmp_id INNER JOIN USERMASTER ON DELETE_LOGS.DELETE_USERID = USERMASTER.User_id ", " and DELETE_LOGS.DELETE_CMPID = " & CmpId & " AND DELETE_LOGS.DELETE_LOCATIONID = " & Locationid & " AND DELETE_LOGS.DELETE_YEARID = " & YearId & "ORDER BY DELETE_LOGS.DELETE_DATE")
            griddetails.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeleteDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fromdate.Value = Mydate
            Todate.Value = Mydate
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "Delete logs.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each Proc As Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                Proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Delete Details"
            griddetails.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Delete Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fromdate.Value = Mydate
            Todate.Value = Mydate
            FILLGRID()
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub DeleteDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub griddetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles griddetails.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Delete And UserName = "Admin" Then
                If MsgBox("Delete Log? " & GRIDBILL.GetFocusedRowCellValue("TABLE"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJOP As New ClsDelete
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(GRIDBILL.GetFocusedRowCellValue("ID").ToString)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJOP.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJOP.Delete
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DateTimePicker1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fromdate.Validated
        Try
            If Todate.Value.Date < fromdate.Value.Date Then

                MsgBox("Invalid Check In Date")
                Exit Sub

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Todate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Todate.Validated
        Try
            If fromdate.Value.Date > Todate.Value.Date Then

                MsgBox("Invalid date")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Try
            If chkdate.Checked = True AndAlso fromdate.Value.Date <= Todate.Value.Date Then
                If MsgBox("Delete Logs? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJOP As New ClsDelete
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(fromdate.Value.Date)
                ALPARAVAL.Add(Todate.Value.Date)
                OBJOP.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJOP.Delete_DATE
                FILLGRID()
                Exit Sub
            End If

            'Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            Dim OBJCMN As New ClsCommon
            If MsgBox("Delete Logs ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For I As Integer = 0 To GRIDBILL.RowCount - 1
                Dim ROW As DataRow = GRIDBILL.GetDataRow(I)
                If ROW("CHK") = True Then OBJCMN.Execute_Any_String("DELETE FROM DELETE_LOGS WHERE DELETE_ID = " & Val(ROW("ID")), "", "")
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        fromdate.Enabled = chkdate.CheckState
        Todate.Enabled = chkdate.CheckState
    End Sub

    Private Sub DeleteDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If UserName <> "Admin" Then cmddel.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class