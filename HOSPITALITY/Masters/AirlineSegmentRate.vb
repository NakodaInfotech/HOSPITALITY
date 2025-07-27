
Imports BL
Imports System.Windows.Forms

Public Class AirlineSegmentRate

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim gridDoubleClick As Boolean
    Dim SEGMENTNO As Integer
    Dim temprow As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AirlineSegmentRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub AirlineSegmentRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'FLIGHT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If CMBAIRLINENAME.Text.Trim = "" Then FILLAIRLINE(CMBAIRLINENAME, edit, "")

            GETDATA()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" AIRLINESEGMENTRATE.AIRLINE_SEGMENTID AS SEGMENTID, FLIGHTMASTER.FLIGHT_NAME AS AIRLINENAME, AIRLINESEGMENTRATE.AIRLINE_SEGRATE AS RATE", "", " FLIGHTMASTER INNER JOIN AIRLINESEGMENTRATE ON FLIGHTMASTER.FLIGHT_ID = AIRLINESEGMENTRATE.AIRLINE_ID AND FLIGHTMASTER.FLIGHT_CMPID = AIRLINESEGMENTRATE.AIRLINE_CMPID AND FLIGHTMASTER.FLIGHT_LOCATIONID = AIRLINESEGMENTRATE.AIRLINE_LOCATIONID AND FLIGHTMASTER.FLIGHT_YEARID = AIRLINESEGMENTRATE.AIRLINE_YEARID", " AND AIRLINESEGMENTRATE.AIRLINE_CMPID = " & CmpId & " AND AIRLINESEGMENTRATE.AIRLINE_LOCATIONID = " & Locationid & " AND AIRLINESEGMENTRATE.AIRLINE_YEARID = " & YearId)
            GRIDAIRLINE.RowCount = 0
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDAIRLINE.Rows.Add(DTROW("SEGMENTID"), DTROW("AIRLINENAME"), Format(Val(DTROW("RATE")), "0.00"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()

        CMBAIRLINENAME.Text = ""
        TXTRATE.Clear()
        edit = False

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBAIRLINENAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBAIRLINENAME, "Fill Airline Name")
            bln = False
        End If

        If TXTRATE.Text.Trim.Length = 0 Then
            EP.SetError(TXTRATE, "Fill Code")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMBAIRLINENAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAIRLINENAME.Enter
        Try
            If CMBAIRLINENAME.Text.Trim = "" Then FILLAIRLINE(CMBAIRLINENAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRLINENAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAIRLINENAME.Validating
        Try
            If CMBAIRLINENAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRLINENAME, CMBCODE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Function CHECKAIRLINE() As Boolean
        Try
            Dim BLN As Boolean = True

            For Each ROW As DataGridViewRow In GRIDAIRLINE.Rows
                If (ROW.Cells(GAIRLINENAME.Index).Value = CMBAIRLINENAME.Text.Trim And gridDoubleClick = False) Or (gridDoubleClick = True And GRIDAIRLINE.Rows(ROW.Index).Cells(GSRNO.Index).Value <> Val(SEGMENTNO) And ROW.Cells(GAIRLINENAME.Index).Value = CMBAIRLINENAME.Text.Trim) Then
                    EP.SetError(TXTRATE, "Airline Name Already Present in Grid Below")
                    BLN = False
                End If
            Next

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        

        If gridDoubleClick = False Then
            GRIDAIRLINE.Rows.Add(Val(TXTSEGNO.Text.Trim), CMBAIRLINENAME.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"))
        ElseIf gridDoubleClick = True Then
            GRIDAIRLINE.Item(GSRNO.Index, temprow).Value = TXTSEGNO.Text.Trim
            GRIDAIRLINE.Item(GAIRLINENAME.Index, temprow).Value = CMBAIRLINENAME.Text.Trim
            GRIDAIRLINE.Item(GRATE.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            gridDoubleClick = False
        End If
        GRIDAIRLINE.FirstDisplayedScrollingRowIndex = GRIDAIRLINE.RowCount - 1
        clear()
        CMBAIRLINENAME.Focus()

    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex = -1 Then
                Exit Sub
            ElseIf e.RowIndex >= 0 Then
                gridDoubleClick = True
                edit = True
                temprow = e.RowIndex
                SEGMENTNO = GRIDAIRLINE.Item(GSRNO.Index, temprow).Value
                CMBAIRLINENAME.Text = GRIDAIRLINE.Item(GAIRLINENAME.Index, temprow).Value
                TXTRATE.Text = GRIDAIRLINE.Item(GRATE.Index, temprow).Value
                CMBAIRLINENAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        Try

            If CMBAIRLINENAME.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then


                EP.Clear()
                If Not CHECKAIRLINE() Then
                    Exit Sub
                End If

                'FIRST SAVE AND GET MAX SEGMENTNO THEN FILLGRID
                Dim ALPARAVAL As New ArrayList
                Dim OBJSEG As New ClsAirlineSegmentRate

                ALPARAVAL.Add(CMBAIRLINENAME.Text.Trim)
                ALPARAVAL.Add(Val(TXTRATE.Text.Trim))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                OBJSEG.alParaval = ALPARAVAL

                If edit = False Then
                    Dim DT As DataTable = OBJSEG.SAVE()
                    TXTSEGNO.Text = DT.Rows(0).Item(0)
                ElseIf edit = True Then
                    ALPARAVAL.Add(SEGMENTNO)
                    Dim INTRESULT As Integer = OBJSEG.update
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

    Private Sub GRIDAIRLINE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDAIRLINE.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                DELETEDATA(GRIDAIRLINE.CurrentRow.Index)
            End If
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

            Dim TEMPMSG As Integer = MsgBox("Delete Segment Rate for " & GRIDAIRLINE.Rows(ROWINDEX).Cells(GAIRLINENAME.Index).Value, MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'delete from DATABASE
                Dim ALPARAVAL As New ArrayList
                Dim OBJDOC As New ClsAirlineSegmentRate

                ALPARAVAL.Add(GRIDAIRLINE.Rows(ROWINDEX).Cells(GSRNO.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)


                OBJDOC.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJDOC.DELETE()
                MsgBox(DT.Rows(0).Item(0), MsgBoxStyle.OkOnly, "TRAVELMATE")
                GRIDAIRLINE.Rows.RemoveAt(ROWINDEX)

                CMBAIRLINENAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class