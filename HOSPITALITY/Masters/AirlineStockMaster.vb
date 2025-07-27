
Imports BL

Public Class AirlineStockMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPAIRLINEID As Integer
    Public FRMSTRING As String
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Dim BILLNO As Integer
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AirlineStockMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            'Write Code here
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()
        Try
            FILLAIRCODE(CMBCODE, "")
            FILLAIRLINE(CMBNAME, edit, "")

            If FRMSTRING = "BSP" Then
                CMBPURCODE.Enabled = False
                CMBPURNAME.Enabled = False
            Else
                fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
                fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineStockMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'FLIGHT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "BSP" Then
                lbl.Text = "Ticket Stock Master"
                Me.Text = "Ticket Stock Master"
            ElseIf FRMSTRING = "COUPON" Then
                lbl.Text = "Coupon Stock Master"
                Me.Text = "Coupon Stock Master"
            End If

            fillcmb()
            

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJAIR As New ClsCommon
                Dim dttable As DataTable = OBJAIR.search(" FLIGHTMASTER.FLIGHT_CODE AS CODE, FLIGHTMASTER.FLIGHT_NAME AS NAME, AIRLINESTOCKMASTER.STOCK_TICKETFROM AS [FROM], AIRLINESTOCKMASTER.STOCK_TICKETTO AS [TO], AIRLINESTOCKMASTER.STOCK_TOTAL AS TOTAL, AIRLINESTOCKMASTER.STOCK_ISSUED AS ISSUED, AIRLINESTOCKMASTER.STOCK_PTA AS PTA, AIRLINESTOCKMASTER.STOCK_SPECIAL AS SPECIAL, ISNULL(LEDGERS.Acc_code,'') AS CMPCODE, ISNULL(LEDGERS.Acc_cmpname,'') AS CMPNAME, ISNULL(AIRLINESTOCKMASTER.STOCK_BOOKING_NO, 0) AS BILLNO ", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN LEDGERS ON AIRLINESTOCKMASTER.STOCK_YEARID = LEDGERS.Acc_yearid AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINESTOCKMASTER.STOCK_CMPID = LEDGERS.Acc_cmpid AND AIRLINESTOCKMASTER.STOCK_PURLEDGERID = LEDGERS.Acc_id ", " AND STOCK_ID = " & TEMPAIRLINEID & " AND STOCK_CMPID = " & CmpId & " AND STOCK_LOCATIONID = " & Locationid & " AND STOCK_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        CMBPURCODE.Text = ROW("CMPCODE")
                        CMBPURNAME.Text = ROW("CMPNAME")

                        CMBCODE.Text = ROW("CODE")
                        CMBNAME.Text = ROW("NAME")

                        TXTFROM.Text = ROW("FROM")
                        TXTTO.Text = ROW("TO")
                        TXTTOTAL.Text = ROW("TOTAL")

                        BILLNO = ROW("BILLNO")


                        DTISSUED.Value = Format(Convert.ToDateTime(ROW("ISSUED")).Date, "dd/MM/yyyy")

                        If Convert.ToBoolean(ROW("PTA")) = True Then
                            CMBPTA.Text = "YES"
                        Else
                            CMBPTA.Text = "NO"
                        End If

                        If Convert.ToBoolean(ROW("SPECIAL")) = True Then
                            CMBSPECIAL.Text = "YES"
                        Else
                            CMBSPECIAL.Text = "NO"
                        End If

                    Next

                    Dim OBJAIR_DESC As New ClsCommon
                    Dim DT As DataTable = OBJAIR_DESC.search(" AIRLINE_STOCK_TICKETNO AS TICKETNO, AIRLINE_STOCK_RATE AS RATE ", "", " AIRLINESTOCKMASTER_DESC ", " AND AIRLINE_STOCK_ID = " & TEMPAIRLINEID & " AND AIRLINE_STOCK_CMPID = " & CmpId & " AND AIRLINE_STOCK_LOCATIONID = " & Locationid & " AND AIRLINE_STOCK_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then

                        For Each ROW As DataRow In DT.Rows
                            GRIDAIRLINE.Rows.Add(0, ROW("TICKETNO"), Val(ROW("RATE")))
                        Next
                        getsrno(GRIDAIRLINE)

                    End If
                End If
            Else
                GRIDAIRLINE.Rows.Add("1", "", 0)
                TXTSRNO.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(FRMSTRING)

            alParaval.Add(CMBPURCODE.Text.Trim)
            alParaval.Add(CMBPURNAME.Text.Trim)

            alParaval.Add(CMBCODE.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            
            alParaval.Add(Val(TXTFROM.Text.Trim))
            alParaval.Add(Val(TXTTO.Text.Trim))
            alParaval.Add(TXTTOTAL.Text.Trim)
            alParaval.Add(DTISSUED.Value.Date)

            If CMBPTA.Text = "Yes" Then
                alParaval.Add("1")
            Else
                alParaval.Add("0")
            End If

            If CMBSPECIAL.Text = "Yes" Then
                alParaval.Add("1")
            Else
                alParaval.Add("0")
            End If

            Dim TICKETNO As String = ""
            Dim RATE As String = ""
            For Each row As Windows.Forms.DataGridViewRow In GRIDAIRLINE.Rows
                If row.Cells(GTICKETNO.Index).Value <> Nothing Then
                    If TICKETNO = "" Then
                        TICKETNO = row.Cells(GTICKETNO.Index).Value
                    Else
                        TICKETNO = TICKETNO & "," & row.Cells(GTICKETNO.Index).Value
                    End If
                End If

                If row.Cells(GRATE.Index).Value <> Nothing Then
                    If RATE = "" Then
                        RATE = row.Cells(GRATE.Index).Value
                    Else
                        RATE = RATE & "," & row.Cells(GRATE.Index).Value
                    End If
                End If

            Next

            alParaval.Add(TICKETNO)
            alParaval.Add(RATE)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJAIR As New ClsAirlineStockMaster
            Dim dtno As DataTable
            OBJAIR.alParaval = alParaval
            Dim tempairid As Integer
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                dtno = OBJAIR.SAVE()
                tempairid = dtno.Rows(0).Item(0)
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPAIRLINEID)
                dtno = OBJAIR.update()
                tempairid = TEMPAIRLINEID
                MsgBox("Details Updated")
            End If

            If DTISSUED.Value.Date >= AccFrom And DTISSUED.Value.Date <= AccTo And FRMSTRING <> "BSP" Then
                TEMPMSG = MsgBox("Wish to Raise the purchase?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim objmic As New MiscPur
                    objmic.MdiParent = MDIMain
                    objmic.STOCKNO = tempairid
                    objmic.TEMPBOOKINGNO = BILLNO
                    If BILLNO <> 0 Then
                        objmic.edit = True
                    End If
                    objmic.Show()
                End If
            End If

            clear()
            GRIDAIRLINE.RowCount = 0
            GRIDAIRLINE.Rows.Add("1", "")
            TXTSRNO.Text = 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        CMBCODE.Text = ""
        CMBNAME.Text = ""
        CMBPURCODE.Text = ""
        CMBPURNAME.Text = ""
        TXTPRE.Clear()
        TXTSUFF.Clear()
        TXTCOMRATE.Clear()
        TXTFROM.Clear()
        TXTTO.Clear()
        TXTTOTAL.Clear()
        DTISSUED.Value = Mydate
        CMBPTA.SelectedIndex = 0
        CMBSPECIAL.SelectedIndex = 0
        TXTTICKETNO.Text = ""
        getsrno(GRIDAIRLINE)
        edit = False
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Fill Name")
            bln = False
        End If

        If CMBCODE.Text.Trim.Length = 0 Then
            EP.SetError(CMBCODE, "Fill Code")
            bln = False
        End If

        If FRMSTRING = "COUPON" Then
            If CMBPURNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBPURNAME, "Fill Name")
                bln = False
            End If

            If CMBPURCODE.Text.Trim.Length = 0 Then
                EP.SetError(CMBPURCODE, "Fill Code")
                bln = False
            End If
        End If
        'If Val(TXTFROM.Text.Trim) = 0 Then
        '    EP.SetError(TXTFROM, "Fill Ticket No")
        '    bln = False
        'End If

        'If Val(TXTTO.Text.Trim) = 0 Then
        '    EP.SetError(TXTTO, "Fill Ticket No")
        '    bln = False
        'End If

        'If Val(TXTTOTAL.Text.Trim) = 0 Then
        '    EP.SetError(TXTTOTAL, "Enter Proper Ticket No")
        '    bln = False
        'End If

        If CMBPTA.Text.Trim.Length = 0 Then
            EP.SetError(CMBPTA, "Select PTA")
            bln = False
        End If

        If CMBSPECIAL.Text.Trim.Length = 0 Then
            EP.SetError(CMBSPECIAL, "Select Stock Type")
            bln = False
        End If

        If GRIDAIRLINE.RowCount = 1 And GRIDAIRLINE.Item(GTICKETNO.Index, 0).Value.ToString() = "" Then
            EP.SetError(TXTTICKETNO, "Please add minimum one ticket to the stock to continue")
            bln = False
        End If

        For Each ROW As DataGridViewRow In GRIDAIRLINE.Rows

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            If edit = True Then
                DT = OBJCMN.search(" AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO AS TICKETNO", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AirlineStockMaster.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID ", " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID = " & CmpId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID = " & Locationid & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID = " & YearId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO = '" & ROW.Cells(GTICKETNO.Index).Value & "' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBNAME.Text & "' AND AIRLINE_STOCK_ID <> " & TEMPAIRLINEID & " AND STOCK_TYPE = '" & FRMSTRING & "'")
            Else
                DT = OBJCMN.search(" AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO AS TICKETNO", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AirlineStockMaster.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID ", " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID = " & CmpId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID = " & Locationid & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID = " & YearId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO = '" & ROW.Cells(GTICKETNO.Index).Value & "' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBNAME.Text & "' AND STOCK_TYPE = '" & FRMSTRING & "'")
            End If
            If DT.Rows.Count > 0 Then
                EP.SetError(TXTTICKETNO, "Ticket Number Already Present for this airline.")
                bln = False
            End If

        Next

        Return bln
    End Function

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then FILLAIRCODE(CMBCODE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJFLIGHT As New SelectFlight
                'OBJFLIGH.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJFLIGHT.ShowDialog()
                If OBJFLIGHT.TEMPCODE <> "" Then CMBCODE.Text = OBJFLIGHT.TEMPCODE
                If OBJFLIGHT.TEMPNAME <> "" Then CMBNAME.Text = OBJFLIGHT.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then AIRCODEVALIDATE(CMBCODE, CMBNAME, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLAIRLINE(CMBNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try

            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJFLIGHT As New SelectFlight
                'OBJFLIGH.STRSEARCH = " and ledgers.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.ACC_YEARID = " & YearId
                OBJFLIGHT.ShowDialog()
                If OBJFLIGHT.TEMPCODE <> "" Then CMBCODE.Text = OBJFLIGHT.TEMPCODE
                If OBJFLIGHT.TEMPNAME <> "" Then CMBNAME.Text = OBJFLIGHT.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then AIRLINEVALIDATE(CMBNAME, CMBCODE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress
        numkeypress(e, TXTFROM, Me)
    End Sub

    Private Sub TXTTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTO.KeyPress
        numkeypress(e, TXTTO, Me)
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
                TXTSRNO.Text = row.Cells(GSRNO.Index).Value
            Next
            TXTSRNO.Text = Val(TXTSRNO.Text) + 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        Try
            TXTTOTAL.Text = 0
            If Val(TXTFROM.Text.Trim) < Val(TXTTO.Text.Trim) Then TXTTOTAL.Text = (Val(TXTTO.Text.Trim) - Val(TXTFROM.Text.Trim)) + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineStockMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "TOPCOMM" Then Me.Close()
    End Sub

    Private Sub TXTTICKETNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTICKETNO.KeyPress
        numdotkeypress(e, TXTTICKETNO, Me)
    End Sub

    Function CHECKTICKETNO()
        Try
            Dim BLN As Boolean = True

            For Each ROW As DataGridViewRow In GRIDAIRLINE.Rows
                ' check if the ticket number is already used or not
                If (ROW.Cells(GTICKETNO.Index).Value = TXTTICKETNO.Text.Trim() And gridDoubleClick = False) Or (gridDoubleClick = True And ROW.Cells(GTICKETNO.Index).Value = TXTTICKETNO.Text.Trim And ROW.Cells(GSRNO.Index).Value <> Val(TXTSRNO.Text)) Then
                    EP.SetError(TXTTICKETNO, "Ticket Number Already Present in Grid Below")
                    BLN = False
                End If

                If BLN = True Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable
                    If edit = True Then
                        DT = OBJCMN.search(" AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO AS TICKETNO", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AirlineStockMaster.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID ", " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID = " & CmpId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID = " & Locationid & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID = " & YearId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO = '" & TXTTICKETNO.Text.Trim & "' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBNAME.Text & "' AND AIRLINE_STOCK_ID <> " & TEMPAIRLINEID & " AND STOCK_TYPE = '" & FRMSTRING & "'")
                    Else
                        DT = OBJCMN.search(" AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO AS TICKETNO", "", " AIRLINESTOCKMASTER INNER JOIN FLIGHTMASTER ON AIRLINESTOCKMASTER.STOCK_FLIGHTID = FLIGHTMASTER.FLIGHT_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINESTOCKMASTER.STOCK_YEARID = FLIGHTMASTER.FLIGHT_YEARID LEFT OUTER JOIN AIRLINESTOCKMASTER_DESC ON AIRLINESTOCKMASTER.STOCK_ID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_ID AND AIRLINESTOCKMASTER.STOCK_CMPID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID AND AIRLINESTOCKMASTER.STOCK_LOCATIONID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID AND AirlineStockMaster.STOCK_YEARID = AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID ", " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_CMPID = " & CmpId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_LOCATIONID = " & Locationid & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_YEARID = " & YearId & " AND AIRLINESTOCKMASTER_DESC.AIRLINE_STOCK_TICKETNO = '" & TXTTICKETNO.Text.Trim & "' AND FLIGHTMASTER.FLIGHT_NAME = '" & CMBNAME.Text & "' AND STOCK_TYPE = '" & FRMSTRING & "'")
                    End If
                    If DT.Rows.Count > 0 Then
                        EP.SetError(TXTTICKETNO, "Ticket Number Already used before")
                        BLN = False
                    End If
                End If
            Next

            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()
        If gridDoubleClick = False Then
            If GRIDAIRLINE.RowCount = 1 And GRIDAIRLINE.Item(GTICKETNO.Index, 0).Value.ToString() = "" Then
                GRIDAIRLINE.RowCount = 0
            End If
            GRIDAIRLINE.Rows.Add(Val(TXTSRNO.Text.Trim), TXTTICKETNO.Text, Val(TXTRATE.Text))
        ElseIf gridDoubleClick = True Then
            GRIDAIRLINE.Item(GSRNO.Index, temprow).Value = TXTSRNO.Text.Trim
            GRIDAIRLINE.Item(GTICKETNO.Index, temprow).Value = TXTTICKETNO.Text.Trim
            GRIDAIRLINE.Item(GRATE.Index, temprow).Value = Val(TXTRATE.Text)
            gridDoubleClick = False
        End If
        GRIDAIRLINE.FirstDisplayedScrollingRowIndex = GRIDAIRLINE.RowCount - 1
        getsrno(GRIDAIRLINE)
        TXTTICKETNO.Clear()
        TXTRATE.Text = "0.00"
        TXTTICKETNO.Focus()
    End Sub

    Private Sub GRIDAIRLINE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDAIRLINE.CellDoubleClick
        Try
            If e.RowIndex = -1 Then
                Exit Sub
            ElseIf e.RowIndex >= 0 Then
                gridDoubleClick = True
                ' edit = True
                temprow = e.RowIndex
                TXTSRNO.Text = GRIDAIRLINE.Item(GSRNO.Index, temprow).Value
                TXTTICKETNO.Text = GRIDAIRLINE.Item(GTICKETNO.Index, temprow).Value
                TXTRATE.Text = Val(GRIDAIRLINE.Item(GRATE.Index, temprow).Value)
                TXTTICKETNO.Focus()
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

            Dim TEMPMSG As Integer = MsgBox("Delete Ticket Number for " & GRIDAIRLINE.Rows(ROWINDEX).Cells(GTICKETNO.Index).Value, MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                GRIDAIRLINE.Rows.RemoveAt(ROWINDEX)
                TXTTICKETNO.Focus()
                If GRIDAIRLINE.RowCount = 0 Then
                    GRIDAIRLINE.Rows.Add(0, "")
                End If
                getsrno(GRIDAIRLINE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOMRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCOMRATE.Validated
        Try
            TXTTOTAL.Text = 0
            If Val(TXTFROM.Text.Trim) < Val(TXTTO.Text.Trim) Then
                TXTTOTAL.Text = (Val(TXTTO.Text.Trim) - Val(TXTFROM.Text.Trim)) + 1

                'Dim srno As Integer
                If GRIDAIRLINE.RowCount = 1 And GRIDAIRLINE.Item(GTICKETNO.Index, 0).Value.ToString() = "" Then
                    GRIDAIRLINE.RowCount = 0
                    'srno = 1
                    'Else
                    '    srno = Val(GRIDAIRLINE.Item(GSRNO.Index, GRIDAIRLINE.RowCount - 1).Value) + 1
                End If
                Dim j As Integer
                j = Val(TXTFROM.Text)

                For i = 1 To Val(TXTTOTAL.Text)

                    Dim proceed As Integer
                    proceed = 1
                    For Each row As DataGridViewRow In GRIDAIRLINE.Rows
                        If (row.Cells(GTICKETNO.Index).Value = TXTPRE.Text.Trim & j.ToString & TXTSUFF.Text.Trim) Then
                            proceed = 0
                            Exit For
                        End If
                    Next
                    If proceed = 1 Then
                        GRIDAIRLINE.Rows.Add(0, TXTPRE.Text.Trim & j.ToString & TXTSUFF.Text.Trim, Val(TXTCOMRATE.Text))
                    End If
                    j = j + 1
                Next

                getsrno(GRIDAIRLINE)
                TXTFROM.Clear()
                TXTTO.Clear()
                TXTSUFF.Clear()
                TXTPRE.Clear()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        Try

            If TXTTICKETNO.Text.Trim <> "" Then

                EP.Clear()
                If Not CHECKTICKETNO() Then
                    Exit Sub
                End If
                fillgrid()
                'If edit = False Then

                'ElseIf edit = True Then

                'End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBPURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Enter
        Try
            If CMBPURCODE.Text.Trim = "" Then fillACCCODE(CMBPURCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    
    Private Sub CMBPURNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBPURCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBPURNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCODE.Validating
        Try
            If CMBPURCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBPURCODE, CMBPURNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBPURCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBPURNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class