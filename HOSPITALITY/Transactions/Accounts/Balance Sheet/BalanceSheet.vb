
Imports BL
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class BalanceSheet

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BalanceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            Dim OBJBS As New ClsBalanceSheet
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable


            'FOR BALANCE SHEET
            Dim OBJPL As New ClsProfitLoss
            Dim DTPL As New DataTable


            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJBS.alParaval = ALPARAVAL
            OBJPL.alParaval = ALPARAVAL

            DTPL = OBJPL.GETSUMMARY()
            Dim DRPL() As DataRow = DTPL.Select("NAME = 'Nett Profit' OR NAME = 'Nett Loss'")

            If rdcondensed.Checked = True Then
                DT = OBJBS.GETSUMMARY()

                gridliabilities.RowCount = 1
                gridassets.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows


                    'LIABILITY GRID
                    If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Then
                        gridliabilities.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        gridliabilities.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(0) = "Profit" Then
                        If DRPL(0)(0) = "Nett Loss" Then GoTo LINE1
                        gridliabilities.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************



                    '***** FILLING TOTAL
                    Dim i As Integer
                    If DTROW(0) = "Total Liability" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridliabilities.RowCount > gridassets.RowCount Then
                            For i = 1 To gridliabilities.RowCount - gridassets.RowCount
                                gridassets.Rows.Add("", "", "")
                            Next
                        ElseIf gridliabilities.RowCount < gridassets.RowCount Then
                            For i = 1 To gridassets.RowCount - gridliabilities.RowCount
                                gridliabilities.Rows.Add("", "", "")
                            Next
                        End If

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")

                        gridliabilities.Rows.Add("Total", Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If




                    'ASSETS GRID
                    If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Then
                        gridassets.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        gridassets.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Loss" Then
                        If DRPL(0)(0) = "Nett Profit" Then GoTo LINE1
                        gridassets.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Total Assets" Then
                        gridassets.Rows.Add("Total", Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")
                        GoTo LINE1
                    End If
                    '***************************************************************************************

LINE1:

                Next

            Else

                If rddetails.Checked = True Then
                    DT = OBJBS.GETDETAILS()
                ElseIf rdledger.Checked = True Then
                    DT = OBJBS.GETLEDGERDETAILS()
                End If
                gridliabilities.RowCount = 1
                gridassets.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) < 8 Then
                        If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Or (DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Profit" Then
                            If DTROW(0) <> "Profit" Then
                                gridliabilities.Rows.Add("", "")
                                gridliabilities.Rows.Add(DTROW(0), Val(DTROW(1)))
                                gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            Else
                                If DTROW(0) = "Profit" Then
                                    If DRPL(0)(0) = "Nett Loss" Then GoTo LINE2
                                    gridliabilities.Rows.Add("", "")
                                    gridliabilities.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                                    GoTo LINE2
                                End If
                                '*****************************************************************
                                '*****************************************************************
                            End If
                        Else
                            gridliabilities.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE2
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) > 7 And DTROW(2) < 14 Then
                        If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Or (DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Loss" Then
                            If DTROW(0) <> "Loss" Then

                                gridassets.Rows.Add("", "")
                                gridassets.Rows.Add(DTROW(0), Val(DTROW(1)))
                                gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon

                            Else

                                If DTROW(0) = "Loss" Then
                                    If DRPL(0)(0) = "Nett Profit" Then GoTo LINE2
                                    gridassets.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                                    gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                                    GoTo LINE2
                                End If
                                '*****************************************************************
                                '*****************************************************************

                            End If

                        Else
                            gridassets.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE2
                    End If


                    '*****************************************************************
                    '*****************************************************************

                    '***** FILLING TOTAL
                    Dim i As Integer
                    If DTROW(0) = "Total Liability" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridliabilities.RowCount > gridassets.RowCount Then
                            For i = 1 To gridliabilities.RowCount - gridassets.RowCount
                                gridassets.Rows.Add("", "", "")
                            Next
                        ElseIf gridliabilities.RowCount < gridassets.RowCount Then
                            For i = 1 To gridassets.RowCount - gridliabilities.RowCount
                                gridliabilities.Rows.Add("", "", "")
                            Next
                        End If

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")

                        gridliabilities.Rows.Add("Total", Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Total Assets" Then
                        gridassets.Rows.Add("Total", Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")
                        GoTo LINE2
                    End If
                    '***************************************************************************************

LINE2:
                Next



            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLIABILITIES_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridliabilities.CellDoubleClick
        Try
            showform(gridliabilities.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLIABILITIES_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridliabilities.RowEnter
        If gridassets.RowCount = gridliabilities.RowCount Then gridassets.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub GRIDLIABILITIES_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridliabilities.Scroll
        gridassets.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub gridassets_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridassets.CellDoubleClick
        Try
            showform(gridassets.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridassets_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridassets.RowEnter
        If gridassets.RowCount = gridliabilities.RowCount Then gridliabilities.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridassets_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridassets.Scroll
        gridliabilities.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        If rdcondensed.Checked = True Or rddetails.Checked = True Or rdledger.Checked = True Then fillgrid()
    End Sub

    Sub showform(ByVal name As String)
        Try
            If name <> "" Then
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim CONDITION As String = ""
            If rdcondensed.Checked = True Then
                CONDITION = "CONDENSED"
            ElseIf rddetails.Checked = True Then
                CONDITION = "DETAILS"
            ElseIf rdledger.Checked = True Then
                CONDITION = "LEDGERDETAILS"
            End If
            If CONDITION <> "" Then

                Dim ALPARAVAL As New ArrayList

                If chkdate.CheckState = CheckState.Checked Then
                    ALPARAVAL.Add(dtfrom.Value.Date)
                    ALPARAVAL.Add(dtto.Value.Date)
                Else
                    ALPARAVAL.Add(AccFrom)
                    ALPARAVAL.Add(AccTo)
                End If
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJRPT As New clsReportDesigner("BALANCE SHEET", System.AppDomain.CurrentDomain.BaseDirectory & "BALANCE SHEET.xlsx", 2)

                OBJRPT.ALPARAVAL = ALPARAVAL
                OBJRPT.BALANCE_SHEET_EXCEL(CONDITION, CmpId, Locationid, YearId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BalanceSheet_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' If ClientName = "TOPCOMM" Then Me.Close()
    End Sub
End Class