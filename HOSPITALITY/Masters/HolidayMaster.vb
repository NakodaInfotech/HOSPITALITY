
Imports BL

Public Class HolidayMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public TEMPHOLIDAYNO As Integer
    Public edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub FILLEDITGRID()
        Try
            GRIDHOLIDAY.RowCount = 0
            Dim ALPARAVAL As New ArrayList
            Dim OBJHOLIDAY As New ClsHolidayMaster

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJHOLIDAY.alParaval = ALPARAVAL

            Dim DT As DataTable = OBJHOLIDAY.GETHOL()
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDHOLIDAY.Rows.Add(DTROW("HOLIDAYNO"), Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), DTROW("HOLIDAY"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If gridDoubleClick = False Then
                GRIDHOLIDAY.Rows.Add(TXTHOLIDAYNO.Text.Trim, Format(HOLIDAYDATE.Value.Date, "dd/MM/yyyy"), TXTHOLIDAY.Text.Trim)
            ElseIf gridDoubleClick = True Then
                GRIDHOLIDAY.Item(GDATE.Index, temprow).Value = Format(HOLIDAYDATE.Value.Date, "dd/MM/yyyy")
                GRIDHOLIDAY.Item(GREMARKS.Index, temprow).Value = TXTHOLIDAY.Text.Trim
                gridDoubleClick = False
            End If

            'GRIDHOLIDAY.FirstDisplayedScrollingRowIndex = GRIDHOLIDAY.RowCount - 10

            edit = False
            TXTHOLIDAYNO.Clear()
            HOLIDAYDATE.Value = Mydate
            TXTHOLIDAY.Text = ""
            
            TXTHOLIDAYNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HolidayMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                DELETEDATA(GRIDHOLIDAY.CurrentRow.Index)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HolidayMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PAYROLL'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLEDITGRID()

            If edit = True Then
                'GET ROWINDEX FIRST
                For Each ROW As DataGridViewRow In GRIDHOLIDAY.Rows
                    If ROW.Cells(gsrno.Index).Value = TEMPHOLIDAYNO Then
                        GETDATA(ROW.Index)
                    End If
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHOLIDAY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDHOLIDAY.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            GETDATA(e.RowIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA(ByVal ROWINDEX As Integer)
        Try
            gridDoubleClick = True
            edit = True
            TEMPHOLIDAYNO = GRIDHOLIDAY.Item(GSRNO.Index, ROWINDEX).Value
            TXTHOLIDAYNO.Text = GRIDHOLIDAY.Item(gsrno.Index, ROWINDEX).Value
            HOLIDAYDATE.Value = GRIDHOLIDAY.Item(GDATE.Index, ROWINDEX).Value
            TXTHOLIDAY.Text = GRIDHOLIDAY.Item(GREMARKS.Index, ROWINDEX).Value
            temprow = ROWINDEX
            HOLIDAYDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHOLIDAY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHOLIDAY.Validated
        Try

            If TXTHOLIDAY.Text.Trim <> "" Then

                'FIRST SAVE AND GET MAX INWARD NO THEN FILLGRID
                Dim ALPARAVAL As New ArrayList
                Dim OBJHOLIDAY As New ClsHolidayMaster

                ALPARAVAL.Add(HOLIDAYDATE.Value.Date)
                ALPARAVAL.Add(TXTHOLIDAY.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                OBJHOLIDAY.alParaval = ALPARAVAL
                If edit = False Then
                    Dim DT As DataTable = OBJHOLIDAY.SAVE()
                    TXTHOLIDAYNO.Text = DT.Rows(0).Item(0)
                ElseIf edit = True Then
                    ALPARAVAL.Add(TEMPHOLIDAYNO)
                    Dim INTRESULT As Integer = OBJHOLIDAY.update
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_HOLIDAYNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(HOLIDAY_NO),0) + 1 ", "HOLIDAYMASTER", " AND HOLIDAY_cmpid=" & CmpId & " AND HOLIDAY_LOCATIONid=" & Locationid & " AND HOLIDAY_YEARid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTHOLIDAYNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub GRIDHOLIDAY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDHOLIDAY.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                DELETEDATA(GRIDHOLIDAY.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTHOLIDAYNO.Clear()
            HOLIDAYDATE.Value = Mydate
            TXTHOLIDAY.Text = ""
            
            GETMAX_HOLIDAYNO()

            gridDoubleClick = False
            TXTHOLIDAYNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DELETEDATA(ByVal ROWINDEX As Integer)
        Try
            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If gridDoubleClick = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Delete Holiday?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'delete from DATABASE
                Dim ALPARAVAL As New ArrayList
                Dim OBJHOLIDAY As New ClsHolidayMaster

                ALPARAVAL.Add(GRIDHOLIDAY.Rows(ROWINDEX).Cells(gsrno.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                OBJHOLIDAY.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJHOLIDAY.DELETE()
                MsgBox(DT.Rows(0).Item(0), MsgBoxStyle.OkOnly, "MNOWF")
                GRIDHOLIDAY.Rows.RemoveAt(ROWINDEX)

                TXTHOLIDAYNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            DELETEDATA(GRIDHOLIDAY.CurrentRow.Index)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class