
Imports System.ComponentModel
Imports BL

Public Class GroupDepartureProfitLoss

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GroupDepartureProfitLoss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJPL As New ClsGroupDepProfitLoss
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable

            ALPARAVAL.Add(CMBGROUPDEPARTURE.Text.Trim)
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
            DT = OBJPL.GETLEDGER()


            gridexpenses.RowCount = 1
            gridincome.RowCount = 1
            Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS As Double


            gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
            gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
            gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            gridexpenses.Rows.Insert(1, "", "")


            Dim i As Integer = 1
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

            'FORMATTING GRID
            For Each DTROW As DataRow In DT.Rows
                Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                        TOTALDREXP += Val(DTROW("DR"))
                        TOTALCREXP += Val(DTROW("CR"))

                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
                        gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                    Else
                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                        gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                    End If
                End If
                '*****************************************************************
                '*****************************************************************

                If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                        TOTALDRINC += Val(DTROW("DR"))
                        TOTALCRINC += Val(DTROW("CR"))

                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
                        gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                    Else
                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                        gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                    End If
                End If
            Next

            '*****************************************************************
            '*****************************************************************



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


            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            gridincome.Rows.Insert(gridincome.RowCount - 1, "Closing Stock", "0.00")
            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


            If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
                TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
            Else
                gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
                TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
            End If
            ''**************************************************************************************



            '***************************************************************************************
            '***** FILLING TOTAL ***********
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

            gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

            gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

            gridexpenses.Rows.Add("===========================", "===============", "===============")
            gridincome.Rows.Add("===========================", "===============", "===============")
            '***************************************************************************************



            '***** FILLING TOTAL ***********
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


            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")




            'WE NEED ONLY GROSS PROFIT, NO NEED OF NETT PROFIT
            'If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
            '    gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
            '    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            '    'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
            'Else
            '    gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
            '    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            '    'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
            'End If
            '''*************************************************************************


            'gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            'gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            'gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
            'gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


            ''***** FILLING TOTAL ***********
            ''KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
            'If gridexpenses.RowCount > gridincome.RowCount Then
            '    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
            '        gridincome.Rows.Add("", "", "")
            '    Next
            'ElseIf gridexpenses.RowCount < gridincome.RowCount Then
            '    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
            '        gridexpenses.Rows.Add("", "", "")
            '    Next
            'End If


            'TOTALDREXP = 0
            'TOTALCREXP = 0
            'TOTALDRINC = 0
            'TOTALCRINC = 0


            ''FORMATTING GRID
            'For Each DTROW As DataRow In DT.Rows
            '    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

            '    If DTROW("PRIMARYGP") = "Indirect Expenses" Then
            '        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
            '            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
            '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

            '            TOTALDREXP += Val(DTROW("DR"))
            '            TOTALCREXP += Val(DTROW("CR"))

            '        ElseIf DTROW("NAME").ToString.Trim <> "" Then
            '            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
            '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
            '        Else
            '            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
            '            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
            '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
            '        End If
            '    End If
            '    '*****************************************************************
            '    '*****************************************************************

            '    If DTROW("PRIMARYGP") = "Indirect Income" Then
            '        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
            '            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
            '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

            '            TOTALDRINC += Val(DTROW("DR"))
            '            TOTALCRINC += Val(DTROW("CR"))

            '        ElseIf DTROW("NAME").ToString.Trim <> "" Then
            '            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
            '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
            '        Else
            '            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
            '            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
            '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
            '        End If
            '    End If
            'Next

            ''***** FILLING TOTAL ***********
            ''KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
            'If gridexpenses.RowCount > gridincome.RowCount Then
            '    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
            '        gridincome.Rows.Add("", "", "")
            '    Next
            'ElseIf gridexpenses.RowCount < gridincome.RowCount Then
            '    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
            '        gridexpenses.Rows.Add("", "", "")
            '    Next
            'End If

            'gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            'gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
            'gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
            'gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


            'If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
            '    gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
            '    TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
            '    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            'Else
            '    gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
            '    TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
            '    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
            '    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            'End If
            '''***************************************************************************************
            ''***** FILLING TOTAL ***********
            ''KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
            'If gridexpenses.RowCount > gridincome.RowCount Then
            '    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
            '        gridincome.Rows.Add("", "", "")
            '    Next
            'ElseIf gridexpenses.RowCount < gridincome.RowCount Then
            '    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
            '        gridexpenses.Rows.Add("", "", "")
            '    Next
            'End If

            'gridexpenses.Rows.Add("===========================", "===============", "===============")
            'gridincome.Rows.Add("===========================", "===============", "===============")

            'gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
            'gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            'gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

            'gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
            'gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
            'gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

            'gridexpenses.Rows.Add("===========================", "===============", "===============")
            'gridincome.Rows.Add("===========================", "===============", "===============")
            ''***************************************************************************************


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
        FILLGRID()
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

            Dim TEMPMSG As Integer = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim OBJPL As New ClsGroupDepProfitLoss
            OBJPL.DELETE(CmpId)

            For I As Integer = 0 To gridexpenses.RowCount - 2

                Dim ALPARAVAL As New ArrayList
                If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "===========================" And gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> "" Then
                    If gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridexpenses.Rows(I).Cells(GEXPNAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridexpenses.Rows(I).Cells(GEXPDR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridexpenses.Rows(I).Cells(GEXPDR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridexpenses.Rows(I).Cells(GEXPCR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridexpenses.Rows(I).Cells(GEXPCR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                '----------------------------------------------------------------------------------
                If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "===========================" And gridincome.Rows(I).Cells(GINCNAME.Index).Value <> "" Then
                    If gridincome.Rows(I).Cells(GINCNAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridincome.Rows(I).Cells(GINCNAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridincome.Rows(I).Cells(GINCDR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridincome.Rows(I).Cells(GINCDR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridincome.Rows(I).Cells(GINCCR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridincome.Rows(I).Cells(GINCCR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(I)


                OBJPL.alParaval = ALPARAVAL
                OBJPL.SAVE()

            Next

            Dim OBJPLPRINT As New PLDesign
            OBJPLPRINT.MdiParent = MDIMain
            OBJPLPRINT.frmstring = "GROUPDEPPROFITLOSS"
            OBJPLPRINT.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupDepartureProfitLoss_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(sender As Object, e As EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(sender As Object, e As CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class