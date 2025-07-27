
Imports BL

Public Class Attendence

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Attendence_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then
                Call cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If GRIDATT.RowCount > 0 Then
                If GRIDATT.SelectedRows.Count >= 0 Then
                    Dim OBJATT As New AttendenceDetails
                    OBJATT.MdiParent = MDIMain
                    OBJATT.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            GETATT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETATT()
        Try
            If dtfrom.Value.Date < dtto.Value.Date Then
                GRIDATT.RowCount = 0
                GRIDATT.ColumnCount = 0

                'ADDING COLUMS
                For I As Integer = 1 To DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
                    Dim OBJ As New DataGridViewCheckBoxColumn
                    OBJ.Name = "G" & I
                    OBJ.HeaderText = I
                    OBJ.Width = 30
                    OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                    OBJ.Resizable = DataGridViewTriState.False
                    OBJ.DefaultCellStyle.BackColor = Color.LightGreen
                    OBJ.ReadOnly = True
                    GRIDATT.Columns.Add(OBJ)
                Next

                'ADD 3MORE COLUMNS
                For I = 0 To 2
                    If I = 0 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GTOTAL"
                        OBJ.HeaderText = "Total Days"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GRIDATT.Columns.Add(OBJ)
                    ElseIf I = 1 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GPRESENT"
                        OBJ.HeaderText = "Present"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GRIDATT.Columns.Add(OBJ)
                    ElseIf I = 2 Then
                        Dim OBJ As New DataGridViewTextBoxColumn
                        OBJ.Name = "GABSENT"
                        OBJ.HeaderText = "Absent"
                        OBJ.Width = 80
                        OBJ.SortMode = DataGridViewColumnSortMode.NotSortable
                        OBJ.Resizable = DataGridViewTriState.False
                        OBJ.ReadOnly = True
                        OBJ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        GRIDATT.Columns.Add(OBJ)
                    End If
                Next
                


                'ADDING ROWS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" EMP_NAME AS EMPNAME", "", " EMPLOYEEMASTER ", " AND EMP_CMPID = " & CmpId & " AND EMP_LOCATIONID = " & Locationid & " AND EMP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataRow In DT.Rows
                        GRIDATT.Rows.Add()
                        GRIDATT.Rows(GRIDATT.RowCount - 1).HeaderCell.Value = ROW("EMPNAME")
                    Next
                    GRIDATT.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    GRIDATT.RowHeadersWidth = 130
                End If


                'SET ATTENDENCE
                Dim TPRESENT As Integer = 0
                DT = OBJCMN.search(" DISTINCT  EMPLOYEEMASTER.EMP_NAME AS EMPNAME, DAY(ATTENDENCE.ATT_DATE) AS ATTDATE ", "", " ATTENDENCE INNER JOIN EMPLOYEEMASTER ON ATTENDENCE.ATT_EMPID = EMPLOYEEMASTER.EMP_id AND ATTENDENCE.ATT_CMPID = EMPLOYEEMASTER.EMP_cmpid AND ATTENDENCE.ATT_LOCATIONID = EMPLOYEEMASTER.EMP_locationid AND ATTENDENCE.ATT_YEARID = EMPLOYEEMASTER.EMP_yearid", " AND ATT_DATE BETWEEN '" & Format(dtfrom.Value.Date, "MM/dd/yyyy") & "' AND '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "' AND ATT_CMPID = " & CmpId & " AND ATT_LOCATIONID = " & Locationid & " AND ATT_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each ROW As DataGridViewRow In GRIDATT.Rows
                        TPRESENT = 0
                        For Each COL As DataGridViewColumn In GRIDATT.Columns
                            Dim DTROW() As DataRow = DT.Select("EMPNAME = '" & (ROW.HeaderCell.Value) & "'")
                            If DTROW.Length > 0 Then
                                For I As Integer = 0 To DTROW.Count - 1
                                    If Convert.ToString(DTROW(I).Item("ATTDATE")) = COL.HeaderText.ToString Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        ROW.Cells(COL.Index).Value = True
                                        TPRESENT += 1
                                    ElseIf COL.HeaderText = "Total Days" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.LightBlue
                                        ROW.Cells(COL.Index).Value = DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
                                    ElseIf COL.HeaderText = "Present" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.Yellow
                                        ROW.Cells(COL.Index).Value = TPRESENT
                                    ElseIf COL.HeaderText = "Absent" Then
                                        ROW.Cells(COL.Index).Style.BackColor = Color.LightGreen
                                        ROW.Cells(COL.Index).Value = (DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date) - TPRESENT)
                                    End If
                                Next
                            End If
                        Next
                    Next
                    GRIDATT.ClearSelection()
                End If
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDATT_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDATT.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDATT.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If .Value = True Then
                        .Value = False
                        GRIDATT.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightGreen
                    Else
                        .Value = True
                        GRIDATT.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Yellow
                    End If
                End With
            End If
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            Dim TOTALDAYS As Integer = DateDiff(DateInterval.Day, dtfrom.Value.Date, dtto.Value.Date)
            Dim TOTALPRESENT As Integer = 0
            Dim TOTALABSENT As Integer = 0
            For Each ROW As DataGridViewRow In GRIDATT.Rows
                TOTALPRESENT = 0
                TOTALABSENT = 0
                For Each COL As DataGridViewColumn In GRIDATT.Columns
                    If Convert.ToBoolean(ROW.Cells(COL.Index).Value) = True And COL.Index < (GRIDATT.ColumnCount - 3) Then
                        TOTALPRESENT = TOTALPRESENT + 1
                    End If
                Next
                TOTALABSENT = TOTALDAYS - TOTALPRESENT
                ROW.Cells(GRIDATT.ColumnCount - 3).Value = TOTALDAYS
                ROW.Cells(GRIDATT.ColumnCount - 2).Value = TOTALPRESENT
                ROW.Cells(GRIDATT.ColumnCount - 1).Value = TOTALABSENT
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDATT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDATT.DoubleClick
        Try

            Dim OBJATT As New AttendenceDetails
            OBJATT.EMPNAME = GRIDATT.Rows(GRIDATT.CurrentRow.Index).HeaderCell.Value
            OBJATT.ATTDATE = Convert.ToDateTime(GRIDATT.Columns(GRIDATT.CurrentCell.ColumnIndex).HeaderCell.Value & "/" & Month(dtfrom.Value.Date) & "/" & Year(dtfrom.Value.Date)).Date
            OBJATT.MdiParent = MDIMain
            OBJATT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJATT As New ClsAttendence
            Dim INTRES As Integer

            For Each ROW As DataGridViewRow In GRIDATT.Rows
                'FIRST DELETE ALL DATA FROM ATTENDANCE FOR EMPLOYEE WITHIN SELECTED DATE
                ALPARAVAL.Add(ROW.HeaderCell.Value)   'EMPNAME
                ALPARAVAL.Add(dtfrom.Value.Date)    'FROMDATE
                ALPARAVAL.Add(dtto.Value.Date)      'TODATE
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJATT.alParaval = ALPARAVAL
                INTRES = OBJATT.DELETE()

                For Each COL As DataGridViewColumn In GRIDATT.Columns
                    ALPARAVAL.Clear()
                    If Convert.ToBoolean(ROW.Cells(COL.Index).Value) = True And COL.Index < (GRIDATT.ColumnCount - 3) Then
                        ALPARAVAL.Add(ROW.HeaderCell.Value)   'EMPNAME
                        ALPARAVAL.Add(Month(dtfrom.Value.Date) & "/" & GRIDATT.Columns(COL.Index).HeaderText & "/" & Year(dtfrom.Value.Date))    'ATT DATE
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJATT.alParaval = ALPARAVAL
                        INTRES = OBJATT.SAVEUPDATE()
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class