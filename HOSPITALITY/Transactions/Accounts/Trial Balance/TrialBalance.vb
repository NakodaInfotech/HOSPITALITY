
Imports BL

Public Class TrialBalance


    Private Sub TrialBalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.S And e.Alt = True Then
                cmdshowdetails_Click(sender, e)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            tabop.Visible = False
            Tabtb.Visible = True
            Me.Width = 756
            cmdok.Location = New System.Drawing.Point(295, 542)
            cmdexit.Location = New System.Drawing.Point(373, 543)
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try

            Dim totaldr, totalcr, TOTALOPBALDR, TOTALOPBALCR As Double
            gridtrialbalance.RowCount = 1

            Dim OBJTB As New ClsTrialBalance
            Dim ALPARAVAL As New ArrayList

            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJTB.alParaval = ALPARAVAL
            If chkdetails.CheckState = CheckState.Checked Then

                Dim DT As DataTable = OBJTB.GETDETAILS()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            'If DTROW("NAME") = "Aamby Valley Ltd3" Then
                            '    Me.Close()
                            'End If
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("              " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Black
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 3 Then
                                    gridtrialbalance.Rows.Add("                   " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 4 Then
                                    gridtrialbalance.Rows.Add("                        " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 5 Then
                                    gridtrialbalance.Rows.Add("                             " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 6 Then
                                    gridtrialbalance.Rows.Add("                                  " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 7 Then
                                    gridtrialbalance.Rows.Add("                                       " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 8 Then
                                    gridtrialbalance.Rows.Add("                                            " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 9 Then
                                    gridtrialbalance.Rows.Add("                                                 " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 10 Then
                                    gridtrialbalance.Rows.Add("                                                      " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 3 Then
                                    gridtrialbalance.Rows.Add("                   " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 4 Then
                                    gridtrialbalance.Rows.Add("                        " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 5 Then
                                    gridtrialbalance.Rows.Add("                             " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 6 Then
                                    gridtrialbalance.Rows.Add("                                  " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 7 Then
                                    gridtrialbalance.Rows.Add("                                       " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 8 Then
                                    gridtrialbalance.Rows.Add("                                            " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 9 Then
                                    gridtrialbalance.Rows.Add("                                                 " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                ElseIf DTROW("LEVELNO") = 10 Then
                                    gridtrialbalance.Rows.Add("                                                      " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            End If
                        Else
                            TOTALOPBALDR = DTROW("OPBALDR")
                            TOTALOPBALDR = DTROW("OPBALCR")
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
                    gridtrialbalance.Rows.Add("TOTAL", TOTALOPBALDR, TOTALOPBALCR, "", totaldr, totalcr, "")
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")

                    TOTAL()

                End If

            Else

                Dim DT As DataTable = OBJTB.GETSUMMARY()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("         " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridtrialbalance.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridtrialbalance.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridtrialbalance.Rows(gridtrialbalance.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridtrialbalance.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            End If
                        Else
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")
                    gridtrialbalance.Rows.Add("TOTAL", "", "", "", totaldr, totalcr, "")
                    gridtrialbalance.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "")

                    TOTAL()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDOPCLOSING()
        Try

            Dim totaldr, totalcr, TOTALOPBALDR, TOTALOPBALCR, totalclosing As Double
            gridopclo.RowCount = 1

            Dim OBJTB As New ClsTrialBalance
            Dim ALPARAVAL As New ArrayList

            If chkdate.Checked = True Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJTB.alParaval = ALPARAVAL
            If chkdetails.CheckState = CheckState.Checked Then

                Dim DT As DataTable = OBJTB.GETDETAILSOPCLOSING()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"), DTROW("CLOBAL"), DTROW("CLODRCR"))
                                End If
                            End If
                        Else
                            TOTALOPBALDR = DTROW("OPBALDR")
                            TOTALOPBALCR = DTROW("OPBALCR")
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                            totalclosing = DTROW("CLOBAL")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "=======")
                    gridopclo.Rows.Add("TOTAL", TOTALOPBALDR, TOTALOPBALCR, "", totaldr, totalcr, "", totalclosing)
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "=======")

                    TOTAL()

                End If

            Else

                Dim DT As DataTable = OBJTB.GETSUMMARYOPCLOSING()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If DTROW("NAME") <> "TOTAL" Then
                            If chkopbal.CheckState = CheckState.Unchecked Then
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), "", "", "", DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            Else
                                If DTROW("LEVELNO") = 0 Then
                                    gridopclo.Rows.Add(DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                ElseIf DTROW("LEVELNO") = 1 Then
                                    gridopclo.Rows.Add("     " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                    gridopclo.Rows(gridopclo.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                                ElseIf DTROW("LEVELNO") = 2 Then
                                    gridopclo.Rows.Add("         " & DTROW("NAME"), DTROW("OPBALDR"), DTROW("OPBALCR"), DTROW("DRCR"), DTROW("DR"), DTROW("CR"), DTROW("GROUPNAME"))
                                End If
                            End If
                        Else
                            totaldr = DTROW("DR")
                            totalcr = DTROW("CR")
                        End If
                    Next

                    'DISPLAYING TOTALS
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "=======")
                    gridopclo.Rows.Add("TOTAL", "", "", "", totaldr, totalcr, "")
                    gridopclo.Rows.Add("==================================", "===============", "===============", "=======", "===============", "===============", "", "===============", "=======")

                    TOTAL()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            Dim TOTALOPDR, TOTALCLOSING, TOTALOPCR As Double

            If chkopclosing.CheckState = CheckState.Checked Then
                For Each ROW As DataGridViewRow In gridopclo.Rows
                    If ROW.DefaultCellStyle.ForeColor <> Color.Maroon And ROW.DefaultCellStyle.ForeColor <> Color.Green Then
                        TOTALOPDR = TOTALOPDR + Val(ROW.Cells(GOPCLOPDR.Index).Value)
                        TOTALOPDR = TOTALOPDR + Val(ROW.Cells(GOPCLOPCR.Index).Value)
                        TOTALCLOSING = TOTALCLOSING + Val(ROW.Cells(GCLODR.Index).Value)
                    End If
                Next
                gridopclo.Rows(gridopclo.RowCount - 3).Cells(GOPCLOPDR.Index).Value = Format(TOTALOPDR, "00,000.00")
                gridopclo.Rows(gridopclo.RowCount - 3).Cells(GOPCLOPCR.Index).Value = Format(TOTALOPCR, "00,000.00")
                gridopclo.Rows(gridopclo.RowCount - 3).Cells(GCLODR.Index).Value = Format(TOTALCLOSING, "00,000.00")
            Else
                For Each ROW As DataGridViewRow In gridtrialbalance.Rows
                    If ROW.DefaultCellStyle.ForeColor <> Color.Maroon And ROW.DefaultCellStyle.ForeColor <> Color.Green Then
                        TOTALOPDR = TOTALOPDR + Val(ROW.Cells(GOPDR.Index).Value)
                        TOTALOPCR = TOTALOPCR + Val(ROW.Cells(GOPCR.Index).Value)
                    End If
                Next
                gridtrialbalance.Rows(gridtrialbalance.RowCount - 3).Cells(GOPDR.Index).Value = Format(TOTALOPDR, "00,000.00")
                gridtrialbalance.Rows(gridtrialbalance.RowCount - 3).Cells(GOPCR.Index).Value = Format(TOTALOPCR, "00,000.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            If chkopclosing.CheckState = CheckState.Checked Then
                Tabtb.Visible = False
                tabop.Visible = True
                cmdok.Location = New System.Drawing.Point(370, 542)
                cmdexit.Location = New System.Drawing.Point(448, 543)
                Me.Width = 898
                FILLGRIDOPCLOSING()
            Else
                Tabtb.Visible = True
                tabop.Visible = False
                Me.Width = 756
                cmdok.Location = New System.Drawing.Point(295, 542)
                cmdexit.Location = New System.Drawing.Point(373, 543)
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkcondensed_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcondensed.CheckStateChanged
        Try
            If chkcondensed.CheckState = CheckState.Checked Then
                chkdetails.CheckState = CheckState.Unchecked
                chkledger.CheckState = CheckState.Unchecked
            Else
                chkdetails.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdetails_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdetails.CheckStateChanged
        Try
            If chkdetails.CheckState = CheckState.Checked Then
                chkcondensed.CheckState = CheckState.Unchecked
            Else
                chkcondensed.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkledger_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkledger.CheckStateChanged
        Try
            If chkdetails.CheckState = CheckState.Unchecked Then chkledger.CheckState = CheckState.Unchecked
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If tabop.Visible = False Then
                showform(gridtrialbalance.CurrentRow.Cells(GNAME.Index).Value.ToString.Trim)
            Else
                showform(gridopclo.CurrentRow.Cells(0).Value.ToString.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal name As String)
        Try
            If gridtrialbalance.CurrentRow.Cells(5).Value.ToString.Trim <> "" Then
                Dim objlb As New LedgerBook
                objlb.TEMPNAME = name
                'objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridtrialbalance_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridtrialbalance.CellDoubleClick
        Try
            showform(gridtrialbalance.CurrentRow.Cells(GNAME.Index).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub gridopclo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridopclo.CellDoubleClick
        Try
            showform(gridopclo.CurrentRow.Cells(0).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim OBJTB As New ClsTrialBalance
            OBJTB.DELETE(CmpId)
            If gridtrialbalance.Visible = True Then
                For Each ROW As DataGridViewRow In gridtrialbalance.Rows

                    If ROW.Cells(GNAME.Index).Value <> "==================================" Then
                        Dim ALPARAVAL As New ArrayList

                        If ROW.Cells(GNAME.Index).Value <> Nothing Then
                            ALPARAVAL.Add(ROW.Cells(GNAME.Index).Value)
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(opdrcr.Index).Value = "Dr." Then
                            If ROW.Cells(GOPDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                        Else
                            If ROW.Cells(GOPCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                        End If

                        If ROW.Cells(opdrcr.Index).Value <> Nothing Then
                            ALPARAVAL.Add(ROW.Cells(opdrcr.Index).Value)
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GDR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GDR.Index).Value))
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GCR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GCR.Index).Value))
                        Else
                            ALPARAVAL.Add("")
                        End If


                        ALPARAVAL.Add(0)
                        ALPARAVAL.Add("")
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(ROW.Index)

                        OBJTB.alParaval = ALPARAVAL
                        OBJTB.SAVE()
                    End If

                Next
            Else
                For Each ROW As DataGridViewRow In gridopclo.Rows

                    If ROW.Cells(GOPCLNAME.Index).Value <> "==================================" Then
                        Dim ALPARAVAL As New ArrayList

                        If ROW.Cells(GOPCLNAME.Index).Value <> Nothing Then
                            ALPARAVAL.Add(ROW.Cells(GOPCLNAME.Index).Value)
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GOPCLDRCR.Index).Value = "Dr." Then
                            If ROW.Cells(GOPCLDR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPCLDR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                        Else
                            If ROW.Cells(GOPCLCR.Index).Value <> Nothing Then
                                ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPCLCR.Index).Value))
                            Else
                                ALPARAVAL.Add("")
                            End If
                        End If


                        If ROW.Cells(GOPCLDRCR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(ROW.Cells(GOPCLDRCR.Index).Value)
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GOPCLDR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPCLDR.Index).Value))
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GOPCLCR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GOPCLCR.Index).Value))
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GCLODR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(Convert.ToDouble(ROW.Cells(GCLODR.Index).Value))
                        Else
                            ALPARAVAL.Add("")
                        End If

                        If ROW.Cells(GCLODRCR.Index).Value <> Nothing Then
                            ALPARAVAL.Add(ROW.Cells(GCLODRCR.Index).Value)
                        Else
                            ALPARAVAL.Add("")
                        End If

                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(ROW.Index)

                        OBJTB.alParaval = ALPARAVAL
                        OBJTB.SAVE()
                    End If
                Next
            End If


            Dim TEMPMSG As Integer = MsgBox("Wish to Print in Excel?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                Dim OBJTBPRINT As New TrialBalanceDesign
                OBJTBPRINT.frmstring = "TrialBalanceDetails"
                OBJTBPRINT.MdiParent = MDIMain
                OBJTBPRINT.Show()
            Else
                TEMPMSG = MsgBox("Excel Printing will take some time to Open, Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJRPT As New clsReportDesigner("TRIAL-BALANCE", System.AppDomain.CurrentDomain.BaseDirectory & "TRIAL-BALANCE.xlsx", 2)
                    OBJRPT.TRIALBALANCE_EXCEL("", CmpId, Locationid, YearId)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalance_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Then Me.Close()
    End Sub
End Class