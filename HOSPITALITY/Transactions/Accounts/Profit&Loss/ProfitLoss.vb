
Imports BL
Imports System.Drawing

Public Class ProfitLoss

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProfitLoss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJPL As New ClsProfitLoss
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

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

            OBJPL.alParaval = ALPARAVAL

            If chkcondensed.CheckState = CheckState.Checked Then

                DT = OBJPL.GETSUMMARY()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '*****************************************************************
                    '*****************************************************************
                    Dim i As Integer

                    If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

                        gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
                        gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                    End If



                    If DTROW(0) = "Gross Profit C/O" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "Indirect Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Indirect Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                Next

            ElseIf chkdetails.CheckState = CheckState.Checked Then

                DT = OBJPL.GETDETAILS()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) = 1 Or DTROW(2) = 2 Then
                        If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                            gridexpenses.Rows.Add("", "")
                            gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridexpenses.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) = 3 Or DTROW(2) = 4 Then
                        If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                            gridincome.Rows.Add("", "")
                            gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridincome.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    Dim i As Integer

                    If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

                        gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
                        gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                        gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                        gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                    End If



                    If DTROW(0) = "Gross Profit C/O" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************

                    If DTROW(2) = 11 Then
                        If DTROW(0) = "Indirect Expenses" Then
                            gridexpenses.Rows.Add("", "")
                            gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridexpenses.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If


                    If DTROW(2) = 12 Then
                        If DTROW(0) = "Indirect Income" Then
                            gridincome.Rows.Add("", "")
                            gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridincome.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                Next

            ElseIf CHKLEDGER.CheckState = CheckState.Checked Then

                DT = OBJPL.GETLEDGER()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) = 1 Or DTROW(2) = 2 Then
                        If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                            gridexpenses.Rows.Add("", "")
                            gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridexpenses.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) = 3 Or DTROW(2) = 4 Then
                        If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                            gridincome.Rows.Add("", "")
                            gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridincome.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    Dim i As Integer

                    If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

                        gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
                        gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                        gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                        gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                    End If



                    If DTROW(0) = "Gross Profit C/O" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************

                    If DTROW(2) = 11 Then
                        If DTROW(0) = "Indirect Expenses" Then
                            gridexpenses.Rows.Add("", "")
                            gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridexpenses.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If


                    If DTROW(2) = 12 Then
                        If DTROW(0) = "Indirect Income" Then
                            gridincome.Rows.Add("", "")
                            gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        Else
                            gridincome.Rows.Add(DTROW(0), "", Val(DTROW(1)))
                        End If
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function SPACER(ByVal LEVEL As Integer) As String
        Dim SPACE As String = ""
        Dim I As Integer = 0
        For I = 0 To LEVEL
            SPACE = SPACE & "   "
        Next
        Return SPACE
    End Function

    Private Sub gridexpenses_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.CellDoubleClick
        Try
            showform(gridexpenses.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridexpenses_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridincome.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridexpenses_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridexpenses.Scroll
        gridincome.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub gridincome_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.CellDoubleClick
        Try
            showform(gridincome.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridincome_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridexpenses.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridincome_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridincome.Scroll
        gridexpenses.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        If chkcondensed.CheckState = CheckState.Checked Or chkdetails.CheckState = CheckState.Checked Or CHKLEDGER.CheckState = CheckState.Checked Then fillgrid()
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

    Private Sub chkcondensed_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcondensed.CheckStateChanged
        Try
            'If chkcondensed.CheckState = CheckState.Checked Then
            '    chkdetails.CheckState = CheckState.Unchecked
            'Else
            '    chkdetails.CheckState = CheckState.Checked
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkdetails_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkdetails.CheckStateChanged
        Try
            'If chkdetails.CheckState = CheckState.Checked Then
            '    chkcondensed.CheckState = CheckState.Unchecked
            'Else
            '    chkcondensed.CheckState = CheckState.Checked
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim CONDITION As String = ""
            If chkcondensed.CheckState = CheckState.Checked Then
                CONDITION = "CONDENSED"
            ElseIf chkdetails.CheckState = CheckState.Checked Then
                CONDITION = "DETAILS"
            ElseIf CHKLEDGER.CheckState = CheckState.Checked Then
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

                Dim OBJRPT As New clsReportDesigner("PROFIT AND LOSS", System.AppDomain.CurrentDomain.BaseDirectory & "PROFIT AND LOSS.xlsx", 2)

                OBJRPT.ALPARAVAL = ALPARAVAL
                OBJRPT.PROFIT_AND_LOSS_EXCEL(CONDITION, CmpId, Locationid, YearId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProfitLoss_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "TOPCOMM" Then Me.Close()
    End Sub

    
End Class