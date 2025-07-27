
Imports System.ComponentModel
Imports BL

Public Class HotelQuotation

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDFOLLOWDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPENQNO, TEMPFOLLOWROW As Integer
    Dim TEMPMSG, TEMPPURROW As Integer
    Public Shared SELECTENQ As New DataTable
    Dim GRIDPURCHASEDOUBLECLICK As Boolean

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_ENQ_NO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(ENQ_no),0) + 1 ", "HOTELENQMASTER", " and ENQ_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTENQNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            CHKAVL.CheckState = CheckState.Checked
            TXTCONFIRMATIONNO.Clear()
            TXTCONFIRMEDBY.Clear()

            CMBPREFIX.Text = ""
            TXTTEMPNIGHTS.Clear()
            tstxtbillno.Clear()
            CMBGUESTNAME.Text = ""
            txtrefno.Clear()
            cmbhotelcode.Text = ""
            cmbhotelname.Text = ""
            CMBNAME.Text = ""
            CMBACCCODE.Text = ""

            txthoteladd.Clear()
            TXTGUESTADD.Clear()

            ENQDATE.Value = Mydate
            ARRIVALDATE.Value = Mydate
            DEPARTDATE.Value = Mydate.Date.AddDays(1)

            txtcheckin.Text = "12:00"
            txtcheckout.Text = "12:00"

            PBlock.Visible = False
            lbllocked.Visible = False
            LBLCLOSED.Visible = False

            txtsrno.Clear()
            CMBROOMTYPE.Text = ""
            CMBACNONAC.SelectedIndex = 0
            CMBPLAN.Text = ""
            TXTADULTS.Clear()
            TXTCHILDS.Clear()
            TXTNCCHILDS.Clear()
            TXTEXTRAADULT.Clear()
            TXTEXTRACHILD.Clear()
            TXTEXTRAADULTRATE.Text = 0.0
            TXTEXTRACHILDRATE.Text = 0.0
            TXTNOOFROOMS.Clear()
            CMBPACKAGE.SelectedIndex = 0
            TXTRATE.Clear()
            TXTTOTAL.Clear()

            GRIDBOOKINGS.RowCount = 0
            GRIDBOOKINGS.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            TXTTOTALCHILDS.Clear()
            TXTTOTALADULTS.Clear()
            TXTTOTALNCCHILDS.Clear()
            TXTTOTALEXTRAADULTS.Clear()
            TXTTOTALEXTRACHILDS.Clear()
            TXTTOTALROOMS.Clear()
            TXTTOTALAMT.Text = 0.0


            TXTTOTALSALEAMT.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTEXTRACHGS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            cmbtax.Text = ""
            If ClientName <> "ELYSIUM" Then cmbtax.Text = "S.T. 1.03%"
            If ClientName = "TOPCOMM" Then
                LBLREFNO.Text = "Tracking ID"
                LBLOTHERCHGS.Text = "Our Service Chg"
            End If
            txttax.Text = 0.0
            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0


            TXTTOTALPAX.Clear()
            TXTTOTALNIGHTS.Text = 1
            CMBCANCEL.Text = ""
            CMBNOTES.Text = ""
            CMBEXCLUSION.Text = ""
            CMBINCLUSION.Text = ""
            TXTINCLUSIONS.Clear()
            TXTEXCLUSIONS.Clear()

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            TXTMISCENQNO.Clear()

            TXTTOTALPURAMT.Clear()

            TXTBOOKINGDESC.Clear()
            TXTSPECIALREMARKS.Clear()
            TXTNOTES.Clear()
            TXTPOLICY.Clear()

            txtinwords.Clear()

            TXTFSRNO.Text = 1
            DTFOLLOWDATE.Clear()
            CMBFOLLOWUPBY.Text = ""
            TXTFOLLOWTO.Clear()
            CMBSTAGE.Text = ""
            DTNEXTDATE.Clear()
            TXTFNARR.Clear()
            GRIDFOLLOW.RowCount = 0
            GRIDFOLLOWDOUBLECLICK = False

            If UserName = "Admin" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()
            GRIDDOUBLECLICK = False
            GETMAX_ENQ_NO()

            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If

            TXTOURCOMM.Clear()

            'GRID PURCHASE
            GRIDPURCHASE.RowCount = 0
            TXTPURSRNO.Text = 1
            CMBPURNAME.Text = ""
            CMBPURCURCODE.Text = ""
            TXTPURROE.Clear()
            TXTPURAMOUNT.Clear()
            TXTPURREMARKS.Clear()
            GRIDPURCHASEDOUBLECLICK = False


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        EDIT = False
        CMBGUESTNAME.Focus()
    End Sub

    Private Sub HotelEnquiry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub HotelEnquiry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Sub fillcmb()
        Try
            If cmbhotelcode.Text.Trim = "" Then fillHOTELCODE(cmbhotelcode, "")
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname, "")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, EDIT)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, EDIT)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, EDIT)
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, EDIT)
            If CMBNOTES.Text.Trim = "" Then FILLNOTE(CMBNOTES, EDIT)
            If CMBFOLLOWUPBY.Text.Trim = "" Then FILLBOOKEDBY(CMBFOLLOWUPBY, EDIT)
            If CMBSTAGE.Text.Trim = "" Then FILLSTAGE(CMBSTAGE)
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, EDIT)
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, EDIT)

            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, EDIT, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, EDIT, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES'")
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub HotelEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DOMESTIC ENQUIRY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsHotelEnqMaster()

                ALPARAVAL.Add(TEMPENQNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTENQ()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTENQNO.Text = TEMPENQNO
                        ENQDATE.Value = Convert.ToDateTime(dr("ENQDATE"))
                        CMBGUESTNAME.Text = dr("GUESTNAME")
                        CMBPREFIX.Text = dr("PREFIX")
                        TXTGUESTADD.Text = dr("GUESTADD")
                        txthoteladd.Text = dr("HOTELADD")
                        txtrefno.Text = dr("REFNO")

                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                        cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                        cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                        FILLROOMTYPE()

                        ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                        DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                        txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                        txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))


                        TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        TXTMISCENQNO.Text = dr("MISCENQNO")
                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")
                        TXTEXTRACHGS.Text = dr("EXTRACHGS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")

                        TXTBOOKINGDESC.Text = dr("BOOKINGDESC")
                        TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                        CMBNOTES.Text = Convert.ToString(dr("NOTENAME"))
                        TXTNOTES.Text = Convert.ToString(dr("NOTE"))
                        CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                        TXTPOLICY.Text = Convert.ToString(dr("POLICY"))

                        TXTNOTES.Text = Convert.ToString(dr("NOTES"))
                        TXTPOLICY.Text = Convert.ToString(dr("CANCELPOLICY"))

                        CHKAVL.Checked = Convert.ToBoolean(dr("AVL"))
                        TXTCONFIRMATIONNO.Text = Convert.ToString(dr("CONFNO"))
                        TXTCONFIRMEDBY.Text = Convert.ToString(dr("CONFBY"))


                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If dr("CLOSE").ToString = True Then
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), dr("CURCODE"), Format(Val(dr("ROE")), "0.00"), Format(dr("amt"), "0.00"))

                        CMBINCLUSION.Text = Convert.ToString(dr("CINCLUSION"))
                        TXTINCLUSIONS.Text = Convert.ToString(dr("TINCLUSION"))
                        CMBEXCLUSION.Text = Convert.ToString(dr("CEXCLUSION"))
                        TXTEXCLUSIONS.Text = Convert.ToString(dr("TEXCLUSION"))
                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    EDIT = False
                    CMBGUESTNAME.Focus()
                End If

                'FOLLOWUP GRID
                Dim OBJCMN As New ClsCommon
                dt = OBJCMN.search("ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_NO, '') AS FOLLOWUPNO, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_SRNO, 0) AS SRNO, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_DATE, '') AS FOLLOWUPDATE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS GIVENBY, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_GIVENTO, '') AS GIVENTO, ISNULL(STAGEMASTER.STAGE_NAME, '') AS STAGE, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_NEXTDATE, '') AS NEXTDATE, ISNULL(HOTELENQMASTER_FOLLOWUP.ENQ_NARRATION, '') AS NARR", "", " HOTELENQMASTER_FOLLOWUP INNER JOIN BOOKEDBYMASTER ON HOTELENQMASTER_FOLLOWUP.ENQ_GIVENBYID = BOOKEDBYMASTER.BOOKEDBY_ID INNER JOIN STAGEMASTER ON HOTELENQMASTER_FOLLOWUP.ENQ_STAGEID = STAGEMASTER.STAGE_ID", " AND ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY ENQ_SRNO")
                If dt.Rows.Count > 0 Then
                    For Each DTFOLLOW As DataRow In dt.Rows
                        GRIDFOLLOW.Rows.Add(DTFOLLOW("SRNO"), Format(Convert.ToDateTime(DTFOLLOW("FOLLOWUPDATE")).Date, "dd/MM/yyyy"), DTFOLLOW("GIVENBY"), DTFOLLOW("GIVENTO"), DTFOLLOW("STAGE"), DTFOLLOW("NEXTDATE"), DTFOLLOW("NARR"))
                    Next
                End If


                chkchange.CheckState = CheckState.Checked

                'GRID PURCHASE
                Dim OBJPUR As New ClsCommon
                Dim DTP As DataTable = OBJPUR.search(" ISNULL(HOTELENQMASTER_PURCHASE.ENQ_SRNO, 0) AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(HOTELENQMASTER_PURCHASE.ENQ_AMOUNT, 0) AS AMOUNT, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURCODE, ISNULL(HOTELENQMASTER_PURCHASE.ENQ_ROE, 0) AS ROE, ISNULL(HOTELENQMASTER_PURCHASE.ENQ_REMARKS, '') AS REMARKS ", "", " HOTELENQMASTER INNER JOIN HOTELENQMASTER_PURCHASE ON HOTELENQMASTER.ENQ_NO = HOTELENQMASTER_PURCHASE.ENQ_NO AND HOTELENQMASTER.ENQ_YEARID = HOTELENQMASTER_PURCHASE.ENQ_YEARID INNER JOIN LEDGERS ON HOTELENQMASTER_PURCHASE.ENQ_NAMEID = LEDGERS.Acc_id LEFT OUTER JOIN CURRENCYMASTER ON ENQ_CURID = CUR_ID", " AND HOTELENQMASTER_PURCHASE.ENQ_NO = " & TEMPENQNO & " AND HOTELENQMASTER_PURCHASE.ENQ_YEARID = " & YearId & " ORDER BY HOTELENQMASTER_PURCHASE.ENQ_SRNO ")
                If DTP.Rows.Count > 0 Then
                    For Each DP1 As DataRow In DTP.Rows
                        GRIDPURCHASE.Rows.Add(DP1("SRNO"), DP1("NAME").ToString, Format(Val(DP1("AMOUNT")), "0.00"), DP1("CURCODE"), Format(Val(DP1("ROE")), "0.00"), DP1("REMARKS").ToString)
                    Next
                End If


            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(ENQDATE.Value.Date)
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTGUESTADD.Text.Trim)
            alParaval.Add(cmbhotelname.Text.Trim)

            alParaval.Add(ARRIVALDATE.Value.Date)
            alParaval.Add(DEPARTDATE.Value.Date)
            alParaval.Add(txtcheckin.Text.Trim)
            alParaval.Add(txtcheckout.Text.Trim)

            alParaval.Add(Val(TXTTOTALADULTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALCHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALNCCHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALEXTRAADULTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALEXTRACHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALROOMS.Text.Trim))
            alParaval.Add(Val(TXTTOTALAMT.Text.Trim))



            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(Val(TXTTOTALNIGHTS.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)
            'MISC ENQ NO
            alParaval.Add(Val(TXTMISCENQNO.Text.Trim))
            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))


            'SALE VALUES
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(CMBADDTAX.Text.Trim)
            alParaval.Add(Val(TXTADDTAX.Text.Trim))

            alParaval.Add(CMBOTHERCHGS.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(TXTBOOKINGDESC.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)

            'Newly Added in Master
            alParaval.Add(TXTNOTES.Text.Trim)
            alParaval.Add(TXTPOLICY.Text.Trim)

            alParaval.Add(CMBNOTES.Text.Trim)
            alParaval.Add(CMBCANCEL.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ROOMTYPE As String = ""
            Dim AC As String = ""
            Dim PLAN As String = ""
            Dim ADULT As String = ""
            Dim CHILD As String = ""
            Dim NCCHILD As String = ""
            Dim EXTRAADULT As String = ""
            Dim ADULTRATE As String = ""
            Dim EXTRACHILD As String = ""
            Dim CHILDRATE As String = ""
            Dim NOOFROOMS As String = ""
            Dim GRIDREMARKS As String = ""
            Dim PACKAGE As String = ""
            Dim RATE As String = ""
            Dim CURCODE As String = ""
            Dim ROE As String = ""
            Dim AMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        ROOMTYPE = row.Cells(groomtype.Index).Value.ToString

                        If row.Cells(gac.Index).Value.ToString = "Yes" Then
                            AC = 1
                        Else
                            AC = 0
                        End If

                        PLAN = row.Cells(gplan.Index).Value.ToString
                        ADULT = row.Cells(gadults.Index).Value.ToString
                        CHILD = row.Cells(gchilds.Index).Value.ToString
                        NCCHILD = row.Cells(gncchilds.Index).Value.ToString
                        EXTRAADULT = row.Cells(GEXTRAADULT.Index).Value.ToString
                        ADULTRATE = row.Cells(GEXTRAADULTRATE.Index).Value.ToString
                        EXTRACHILD = row.Cells(GEXTRACHILD.Index).Value.ToString
                        CHILDRATE = row.Cells(GEXTRACHILDRATE.Index).Value.ToString
                        NOOFROOMS = row.Cells(gnoofRooms.Index).Value.ToString
                        GRIDREMARKS = row.Cells(GDESC.Index).Value.ToString

                        If row.Cells(GPACKAGE.Index).Value.ToString = "Yes" Then
                            PACKAGE = 1
                        Else
                            PACKAGE = 0
                        End If

                        RATE = row.Cells(grate.Index).Value.ToString
                        CURCODE = row.Cells(GCURCODE.Index).Value.ToString
                        ROE = row.Cells(GROE.Index).Value.ToString
                        AMT = row.Cells(gamt.Index).Value

                    Else

                        gridsrno = gridsrno & "," & row.Cells(GSRNO.Index).Value
                        ROOMTYPE = ROOMTYPE & "," & row.Cells(groomtype.Index).Value

                        If row.Cells(gac.Index).Value.ToString = "Yes" Then
                            AC = AC & "," & 1
                        Else
                            AC = AC & "," & 0
                        End If

                        PLAN = PLAN & "," & row.Cells(gplan.Index).Value.ToString
                        ADULT = ADULT & "," & row.Cells(gadults.Index).Value.ToString
                        CHILD = CHILD & "," & row.Cells(gchilds.Index).Value.ToString
                        NCCHILD = NCCHILD & "," & row.Cells(gncchilds.Index).Value.ToString
                        EXTRAADULT = EXTRAADULT & "," & row.Cells(GEXTRAADULT.Index).Value.ToString
                        ADULTRATE = ADULTRATE & "," & row.Cells(GEXTRAADULTRATE.Index).Value.ToString
                        EXTRACHILD = EXTRACHILD & "," & row.Cells(GEXTRACHILD.Index).Value.ToString
                        CHILDRATE = CHILDRATE & "," & row.Cells(GEXTRACHILDRATE.Index).Value.ToString
                        NOOFROOMS = NOOFROOMS & "," & row.Cells(gnoofRooms.Index).Value.ToString
                        GRIDREMARKS = GRIDREMARKS & "," & row.Cells(GDESC.Index).Value.ToString

                        If row.Cells(GPACKAGE.Index).Value.ToString = "Yes" Then
                            PACKAGE = PACKAGE & "," & 1
                        Else
                            PACKAGE = PACKAGE & "," & 0
                        End If

                        RATE = RATE & "," & row.Cells(grate.Index).Value
                        CURCODE = CURCODE & "," & row.Cells(GCURCODE.Index).Value
                        ROE = ROE & "," & row.Cells(GROE.Index).Value
                        AMT = AMT & "," & row.Cells(gamt.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(AC)
            alParaval.Add(PLAN)
            alParaval.Add(ADULT)
            alParaval.Add(CHILD)
            alParaval.Add(NCCHILD)
            alParaval.Add(EXTRAADULT)
            alParaval.Add(ADULTRATE)
            alParaval.Add(EXTRACHILD)
            alParaval.Add(CHILDRATE)
            alParaval.Add(NOOFROOMS)
            alParaval.Add(GRIDREMARKS)
            alParaval.Add(PACKAGE)
            alParaval.Add(RATE)
            alParaval.Add(CURCODE)
            alParaval.Add(ROE)
            alParaval.Add(AMT)




            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(ClientName)
            alParaval.Add(CMBPREFIX.Text.Trim)

            alParaval.Add(CHKAVL.Checked)
            alParaval.Add(TXTCONFIRMATIONNO.Text.Trim)
            alParaval.Add(TXTCONFIRMEDBY.Text.Trim)


            'FOR FOLLOWUP

            Dim FSRNO As String = ""
            Dim FDATE As String = ""
            Dim GIVENBY As String = ""
            Dim GIVENTO As String = ""
            Dim STAGE As String = ""
            Dim NDATE As String = ""
            Dim NARR As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFOLLOW.Rows
                If row.Cells(GFSRNO.Index).Value <> Nothing Then
                    If FSRNO = "" Then
                        FSRNO = row.Cells(GFSRNO.Index).Value.ToString
                        FDATE = row.Cells(GFDATE.Index).Value.ToString
                        GIVENBY = row.Cells(GFNAME.Index).Value.ToString
                        GIVENTO = row.Cells(GFOLLOWTO.Index).Value.ToString
                        STAGE = row.Cells(GFSTAGE.Index).Value.ToString
                        NDATE = row.Cells(GFNEXTDATE.Index).Value.ToString
                        NARR = row.Cells(GFNARR.Index).Value.ToString
                    Else
                        FSRNO = FSRNO & "|" & row.Cells(GFSRNO.Index).Value.ToString
                        FDATE = FDATE & "|" & row.Cells(GFDATE.Index).Value.ToString
                        GIVENBY = GIVENBY & "|" & row.Cells(GFNAME.Index).Value.ToString
                        GIVENTO = GIVENTO & "|" & row.Cells(GFOLLOWTO.Index).Value.ToString
                        STAGE = STAGE & "|" & row.Cells(GFSTAGE.Index).Value.ToString
                        NDATE = NDATE & "|" & row.Cells(GFNEXTDATE.Index).Value.ToString
                        NARR = NARR & "|" & row.Cells(GFNARR.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(FSRNO)
            alParaval.Add(FDATE)
            alParaval.Add(GIVENBY)
            alParaval.Add(GIVENTO)
            alParaval.Add(STAGE)
            alParaval.Add(NDATE)
            alParaval.Add(NARR)




            'PURCHASE GRID
            Dim PURSRNO As String = ""
            Dim PURNAME As String = ""
            Dim PURAMOUNT As String = ""
            Dim PURCURCODE As String = ""
            Dim PURROE As String = ""
            Dim PURREMARKS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GPURSRNO.Index).Value <> Nothing Then
                    If PURSRNO = "" Then
                        PURSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = row.Cells(GPURNAME.Index).Value.ToString
                        PURAMOUNT = Val(row.Cells(GPURAMOUNT.Index).Value)
                        PURCURCODE = row.Cells(GPURCURCODE.Index).Value.ToString
                        PURROE = Val(row.Cells(GPURROE.Index).Value)
                        PURREMARKS = row.Cells(GPURREMARKS.Index).Value.ToString
                    Else
                        PURSRNO = PURSRNO & "|" & row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = PURNAME & "|" & row.Cells(GPURNAME.Index).Value.ToString
                        PURAMOUNT = PURAMOUNT & "|" & Val(row.Cells(GPURAMOUNT.Index).Value)
                        PURCURCODE = PURCURCODE & "|" & row.Cells(GPURCURCODE.Index).Value.ToString
                        PURROE = PURROE & "|" & Val(row.Cells(GPURROE.Index).Value)
                        PURREMARKS = PURREMARKS & "|" & row.Cells(GPURREMARKS.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(PURSRNO)
            alParaval.Add(PURNAME)
            alParaval.Add(PURAMOUNT)
            alParaval.Add(PURCURCODE)
            alParaval.Add(PURROE)
            alParaval.Add(PURREMARKS)

            alParaval.Add(CMBINCLUSION.Text.Trim)
            alParaval.Add(CMBEXCLUSION.Text.Trim)
            alParaval.Add(TXTINCLUSIONS.Text.Trim)
            alParaval.Add(TXTEXCLUSIONS.Text.Trim)

            Dim OBJBOOKING As New ClsHotelEnqMaster()
            OBJBOOKING.alParaval = alParaval


            If EDIT = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.save()
                'SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is confirmed between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date)
                MessageBox.Show("Details Added")
                PRINTREPORT(DTNO.Rows(0).Item(0))
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPENQNO)

                IntResult = OBJBOOKING.update()
                'SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is Updated between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date)
                MessageBox.Show("Details Updated")
                EDIT = False
                PRINTREPORT(Val(TXTENQNO.Text.Trim))

            End If

            clear()
            CMBGUESTNAME.Focus()
        Catch ex As Exception
            ' If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal ENQNO As Integer)
        Try

            If ClientName = "SSR" Then
                If MsgBox("Wish To Print Hotel Enquiry Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJENQ As New HotelEnqDesign
                    OBJENQ.MdiParent = MDIMain
                    OBJENQ.ENQNO = ENQNO
                    OBJENQ.HIDEAMT = chkhideamt.CheckState
                    OBJENQ.FRMSTRING = "HOTELENQ"
                    OBJENQ.Show()
                End If
                Exit Sub
            End If


            If ClientName = "TOPCOMM" Or ClientName = "AIRTRINITY" Or ClientName = "KHANNA" Then
                If MsgBox("Avail & Price to Hotel?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJVOUCHER As New HotelEnqDesign
                    OBJVOUCHER.MdiParent = MDIMain
                    OBJVOUCHER.ENQNO = ENQNO
                    OBJVOUCHER.SUBJECT = UCase(CMBGUESTNAME.Text.Trim) & " - " & UCase(cmbhotelname.Text.Trim)
                    OBJVOUCHER.FRMSTRING = "HOTELRATE"
                    If CHKAVL.CheckState = CheckState.Checked Then
                        OBJVOUCHER.SUBJECT = "AVAILABILITY - " & UCase(cmbhotelname.Text.Trim) & " - " & txtrefno.Text.Trim
                    Else
                        OBJVOUCHER.SUBJECT = "CONFIRMATION - " & UCase(cmbhotelname.Text.Trim) & " - " & txtrefno.Text.Trim
                    End If
                    OBJVOUCHER.Show()
                End If
            End If


            If MsgBox("Send Quote to Guest?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJVOUCHER As New HotelEnqDesign
                OBJVOUCHER.MdiParent = MDIMain
                'SUBJECT
                If ClientName = "BELLA" Then
                    'GET DESTINATION FROM ENQNO
                    Dim OBJCMN As New ClsCommon
                    Dim DTDES As DataTable = OBJCMN.search("ISNULL(CITY_NAME,'') AS DESTINATION", "", " MISCENQUIRY LEFT OUTER JOIN CITYMASTER ON MISC_CITYID = CITY_ID ", " AND MISC_NO =" & Val(TEMPENQNO) & " AND MISC_YEARID = " & YearId)
                    OBJVOUCHER.SUBJECT = "BCD-" & Val(TXTMISCENQNO.Text.Trim) & "/" & DTDES.Rows(0).Item("DESTINATION") & "/" & CMBGUESTNAME.Text.Trim & "/" & MonthName(ARRIVALDATE.Value.Month) & "/" & Val(TXTTOTALPAX.Text.Trim)
                Else
                    OBJVOUCHER.SUBJECT = "FILE NO - " & txtrefno.Text.Trim & "-ENQ NO - " & Val(TXTMISCENQNO.Text.Trim) & "-QUOTE NO - " & Val(TEMPENQNO)
                End If

                OBJVOUCHER.GUESTNAME = CMBGUESTNAME.Text.Trim
                OBJVOUCHER.ENQNO = ENQNO
                OBJVOUCHER.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable

        If CMBGUESTNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBGUESTNAME, " Please Fill Guest Name ")
            bln = False
        End If

        If cmbhotelname.Text.Trim.Length = 0 Then
            EP.SetError(cmbhotelname, " Please Fill Hotel Name ")
            bln = False
        End If


        If txthoteladd.Text.Trim.Length = 0 Then
            EP.SetError(TBadd, " Please Fill Hotel Add")
            bln = False
        End If

        If ARRIVALDATE.Value.Date >= DEPARTDATE.Value.Date Then
            EP.SetError(ARRIVALDATE, " Fill Proper Dates ")
            bln = False
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Room Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If chkchange.CheckState = CheckState.Unchecked Then
            EP.SetError(CMBGUESTNAME, "Enter Details")
            bln = False
        End If

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(PBlock, "Enquiry Locked, Booking Made")
            bln = False
        End If

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If

        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If


        If Not datecheck(ENQDATE.Value) Then
            EP.SetError(ENQDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If Not datecheck(ARRIVALDATE.Value) Then
                EP.SetError(ARRIVALDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(DEPARTDATE.Value) Then
                EP.SetError(DEPARTDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If ClientName = "BELLA" Then
            If Val(TXTMISCENQNO.Text.Trim) = 0 Then
                EP.SetError(TXTMISCENQNO, "Please Save/Add Enquiry First.....")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()

        TXTTOTALADULTS.Text = "0.00"
        TXTTOTALCHILDS.Text = "0.00"
        TXTTOTALNCCHILDS.Text = "0.00"
        TXTTOTALEXTRAADULTS.Text = "0.00"
        TXTTOTALEXTRACHILDS.Text = "0.00"
        TXTTOTALROOMS.Text = "0.00"
        TXTTOTALAMT.Text = "0.00"
        TXTTOTALSALEAMT.Text = "0.00"
        TXTTOTALPAX.Text = 0

        'dont SUPRESS
        'CMBADDTAX.Text = ""
        'TXTADDTAX.Clear()

        If GRIDBOOKINGS.RowCount > 0 Then

            TXTSUBTOTAL.Text = 0.0
            txttax.Text = 0.0
            TXTADDTAX.Text = 0.0
            If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0

            For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                If Val(row.Cells(gadults.Index).Value) > 0 Then TXTTOTALADULTS.Text = Val(TXTTOTALADULTS.Text) + Val(row.Cells(gadults.Index).Value)
                If Val(row.Cells(gchilds.Index).Value) > 0 Then TXTTOTALCHILDS.Text = Val(TXTTOTALCHILDS.Text) + Val(row.Cells(gchilds.Index).Value)
                If Val(row.Cells(gncchilds.Index).Value) > 0 Then TXTTOTALNCCHILDS.Text = Val(TXTTOTALNCCHILDS.Text) + Val(row.Cells(gncchilds.Index).Value)
                If Val(row.Cells(GEXTRAADULT.Index).Value) > 0 Then TXTTOTALEXTRAADULTS.Text = Val(TXTTOTALEXTRAADULTS.Text) + Val(row.Cells(GEXTRAADULT.Index).Value)
                If Val(row.Cells(GEXTRACHILD.Index).Value) > 0 Then TXTTOTALEXTRACHILDS.Text = Val(TXTTOTALEXTRACHILDS.Text) + Val(row.Cells(GEXTRACHILD.Index).Value)
                If Val(row.Cells(gnoofRooms.Index).Value) > 0 Then TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text) + Val(row.Cells(gnoofRooms.Index).Value)

                If ClientName = "ELYSIUM" Then
                    If row.Cells(GPACKAGE.Index).Value = "No" Then
                        row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRAADULT.Index).Value) * Val(row.Cells(GEXTRAADULTRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRACHILD.Index).Value) * Val(row.Cells(GEXTRACHILDRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    Else
                        row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gadults.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRAADULTRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRAADULT.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRACHILDRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRACHILD.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    End If
                Else
                    If row.Cells(GPACKAGE.Index).Value = "No" Then
                        row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRAADULT.Index).Value) * Val(row.Cells(GEXTRAADULTRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRACHILD.Index).Value) * Val(row.Cells(GEXTRACHILDRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    Else
                        row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value)) + (Val(row.Cells(GEXTRAADULTRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRAADULT.Index).EditedFormattedValue)) + (Val(row.Cells(GEXTRACHILDRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRACHILD.Index).EditedFormattedValue)), "0.00")
                    End If
                End If

                If Val(row.Cells(gamt.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
            Next

            TXTTOTALPAX.Text = Val(TXTTOTALADULTS.Text.Trim) + Val(TXTTOTALCHILDS.Text.Trim) + Val(TXTTOTALNCCHILDS.Text.Trim) + Val(TXTTOTALEXTRAADULTS.Text.Trim) + Val(TXTTOTALEXTRACHILDS.Text.Trim)

            TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")

            'COZ EXTRA ADULT AND CHILD ARE NOW IN GRID LINE ITEM
            'If Val(TXTEXTRAADULT.Text.Trim) > 0 And Val(TXTEXTRAADULTRATE.Text.Trim) > 0 Then
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            'End If

            'If Val(TXTEXTRACHILD.Text.Trim) > 0 And Val(TXTEXTRACHILDRATE.Text.Trim) > 0 Then
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            'End If


            'AS COMM IS CALCULATED AUTO
            'If Val(TXTOURCOMMPER.Text) > 0 Then
            '    TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMPER.Text) * Val(TXTFINALPURAMT.Text)) / 100, "0.00")
            'Else
            '    TXTOURCOMMPER.Text = Format((Val(TXTOURCOMMRS.Text) * 100) / Val(TXTFINALPURAMT.Text), "0.00")
            'End If


            If Val(TXTDISCPER.Text) > 0 Then
                TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
            Else
                'TXTDISCPER.Text = Format((Val(TXTDISCRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
            End If



            'COZ OUR COMM SHOULD NOT BE ADDED
            'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTOURCOMMRS.Text)) - Val(TXTDISCRS.Text), "0.00")
            TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text)) - Val(TXTDISCRS.Text) + Val(TXTEXTRACHGS.Text.Trim), "0.00")


            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            'If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")

            If ClientName = "TOPCOMM" Then
                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text) + (TXTADDTAX.Text.Trim))) / 100, "0.00")
            Else
                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                'If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
            End If

            'Purchase grid total
            TXTTOTALPURAMT.Text = 0.0
            If GRIDPURCHASE.Rows.Count > 0 Then
                For Each ROW As DataGridViewRow In GRIDPURCHASE.Rows
                    TXTTOTALPURAMT.Text = Val(TXTTOTALPURAMT.Text) + Val(ROW.Cells(GPURAMOUNT.Index).Value)
                Next
            End If

            TXTOURCOMM.Text = Val(TXTSUBTOTAL.Text) - Val(TXTTOTALPURAMT.Text)

            'FOR 7HOSPITALITY TAX SHOULD BE ROUNDED OFF AS PER ACCOUNTANTS REQ
            If ClientName = "7HOSPITALITY" Then
                txttax.Text = Format(Val(txttax.Text.Trim), "0")
                txttax.Text = Format(Val(txttax.Text.Trim), "0.00")
            End If


            If cmbaddsub.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


            'as per ASHOK BHAI'S RECOMMENDATION
            'TXTOURCOMMRS.Text = Format(Val(txtgrandtotal.Text) - Val(TXTFINALPURAMT.Text), "0.00")


            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)


        End If
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDDOUBLECLICK = False Then
            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If CMBROOMTYPE.Text.Trim <> "" And Val(TXTADULTS.Text) > 0 And CMBACNONAC.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And CMBPACKAGE.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 Then
            fillgrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        GRIDBOOKINGS.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBROOMTYPE.Text.Trim, "Yes", CMBPLAN.Text.Trim, Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), Val(TXTEXTRAADULT.Text.Trim), Val(TXTEXTRAADULTRATE.Text.Trim), Val(TXTEXTRACHILD.Text.Trim), Val(TXTEXTRACHILDRATE.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), "", CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), CMBCURCODE.Text.Trim, Format(Val(TXTROE.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"))
            getsrno(GRIDBOOKINGS)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(groomtype.Index, TEMPROW).Value = CMBROOMTYPE.Text.Trim
            GRIDBOOKINGS.Item(gac.Index, TEMPROW).Value = "Yes"
            GRIDBOOKINGS.Item(gplan.Index, TEMPROW).Value = CMBPLAN.Text.Trim
            GRIDBOOKINGS.Item(gadults.Index, TEMPROW).Value = Val(TXTADULTS.Text.Trim)
            GRIDBOOKINGS.Item(gchilds.Index, TEMPROW).Value = Val(TXTCHILDS.Text.Trim)
            GRIDBOOKINGS.Item(gncchilds.Index, TEMPROW).Value = Val(TXTNCCHILDS.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRAADULT.Index, TEMPROW).Value = Val(TXTEXTRAADULT.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRAADULTRATE.Index, TEMPROW).Value = Val(TXTEXTRAADULTRATE.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRACHILD.Index, TEMPROW).Value = Val(TXTEXTRACHILD.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRACHILDRATE.Index, TEMPROW).Value = Val(TXTEXTRACHILDRATE.Text.Trim)
            GRIDBOOKINGS.Item(gnoofRooms.Index, TEMPROW).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDBOOKINGS.Item(GPACKAGE.Index, TEMPROW).Value = CMBPACKAGE.Text.Trim
            GRIDBOOKINGS.Item(grate.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GCURCODE.Index, TEMPROW).Value = CMBCURCODE.Text.Trim
            GRIDBOOKINGS.Item(GROE.Index, TEMPROW).Value = Format(Val(TXTROE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(gamt.Index, TEMPROW).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        txtsrno.Clear()
        CMBROOMTYPE.Text = ""
        CMBACNONAC.SelectedIndex = 0
        CMBPLAN.Text = ""
        TXTADULTS.Clear()
        TXTCHILDS.Clear()
        TXTNCCHILDS.Clear()
        TXTEXTRAADULT.Clear()
        TXTEXTRAADULTRATE.Clear()
        TXTEXTRACHILD.Clear()
        TXTEXTRACHILDRATE.Clear()
        TXTNOOFROOMS.Text = ""
        CMBPACKAGE.SelectedIndex = 0
        TXTRATE.Clear()
        CMBCURCODE.Text = ""
        TXTROE.Clear()
        TXTTOTAL.Clear()
        txtsrno.Focus()

    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBROOMTYPE.Text = GRIDBOOKINGS.Item(groomtype.Index, e.RowIndex).Value.ToString
                CMBACNONAC.Text = GRIDBOOKINGS.Item(gac.Index, e.RowIndex).Value.ToString
                CMBPLAN.Text = GRIDBOOKINGS.Item(gplan.Index, e.RowIndex).Value.ToString
                TXTADULTS.Text = GRIDBOOKINGS.Item(gadults.Index, e.RowIndex).Value.ToString
                TXTCHILDS.Text = GRIDBOOKINGS.Item(gchilds.Index, e.RowIndex).Value.ToString
                TXTNCCHILDS.Text = GRIDBOOKINGS.Item(gncchilds.Index, e.RowIndex).Value.ToString
                TXTEXTRAADULT.Text = GRIDBOOKINGS.Item(GEXTRAADULT.Index, e.RowIndex).Value.ToString
                TXTEXTRAADULTRATE.Text = GRIDBOOKINGS.Item(GEXTRAADULTRATE.Index, e.RowIndex).Value.ToString
                TXTEXTRACHILD.Text = GRIDBOOKINGS.Item(GEXTRACHILD.Index, e.RowIndex).Value.ToString
                TXTEXTRACHILDRATE.Text = GRIDBOOKINGS.Item(GEXTRACHILDRATE.Index, e.RowIndex).Value.ToString
                TXTNOOFROOMS.Text = GRIDBOOKINGS.Item(gnoofRooms.Index, e.RowIndex).Value.ToString
                CMBPACKAGE.Text = GRIDBOOKINGS.Item(GPACKAGE.Index, e.RowIndex).Value.ToString
                TXTRATE.Text = GRIDBOOKINGS.Item(grate.Index, e.RowIndex).Value.ToString
                CMBCURCODE.Text = GRIDBOOKINGS.Item(GCURCODE.Index, e.RowIndex).Value.ToString
                TXTROE.Text = GRIDBOOKINGS.Item(GROE.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(gamt.Index, e.RowIndex).Value.ToString

                TEMPROW = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in EDIT mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim TINDEX As Integer = GRIDBOOKINGS.CurrentRow.Index

                GRIDBOOKINGS.Rows.RemoveAt(TINDEX)

                getsrno(GRIDBOOKINGS)
                total()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPENQNO = Val(tstxtbillno.Text)
            If TEMPENQNO > 0 Then
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" ENQ_no ", "", " HOTELENQMASTER INNER JOIN BOOKEDBYMASTER ON HOTELENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_NO = " & TEMPENQNO & " and ENQ_yearid = " & YearId)
                        If DT.Rows.Count > 0 Then
                            EDIT = True
                            HotelEnquiry_Load(sender, e)
                        End If
                    Else
                        EDIT = True
                        HotelEnquiry_Load(sender, e)
                    End If
                Else
                    EDIT = True
                    HotelEnquiry_Load(sender, e)
                End If
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJENQ As New HotelQuotationDetails
            OBJENQ.MdiParent = MDIMain
            OBJENQ.Show()
            OBJENQ.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) - 1
            If TEMPENQNO > 0 Then
                If ClientName = "VIDHI" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable
                    If UserName <> "Admin" Then
                        DT = OBJCMN.search(" ENQ_NO ", "", " HOTELENQMASTER INNER JOIN BOOKEDBYMASTER ON HOTELENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND ENQ_NO = " & TEMPENQNO & " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_yearid=" & YearId)
                        If DT.Rows.Count > 0 Then
                            EDIT = True
                            HotelEnquiry_Load(sender, e)
                        End If
                    Else
                        EDIT = True
                        HotelEnquiry_Load(sender, e)
                    End If
                Else
                    EDIT = True
                    HotelEnquiry_Load(sender, e)
                End If
            Else
                clear()
                EDIT = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPENQNO > 1 Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPENQNO = Val(TXTENQNO.Text) + 1
            GETMAX_ENQ_NO()
            Dim MAXNO As Integer = TXTENQNO.Text.Trim
            clear()

            If Val(TXTENQNO.Text) - 1 >= TEMPENQNO Then
                If ClientName = "VIDHI" Then
                    If UserName <> "Admin" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.search(" ENQ_no ", "", " HOTELENQMASTER INNER JOIN BOOKEDBYMASTER ON HOTELENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND HOTELENQMASTER.ENQ_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID ", " AND BOOKEDBYMASTER.BOOKEDBY_NAME = '" & UserName & "' and ENQ_NO = " & TEMPENQNO & " and ENQ_yearid = " & YearId)
                        If DT.Rows.Count > 0 Then
                            EDIT = True
                            HotelEnquiry_Load(sender, e)
                        End If
                    Else
                        EDIT = True
                        HotelEnquiry_Load(sender, e)
                    End If
                Else
                    EDIT = True
                    HotelEnquiry_Load(sender, e)
                End If
            Else
                clear()
                EDIT = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPENQNO < MAXNO Then
                TXTENQNO.Text = TEMPENQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbhotelcode.Enter
        Try
            If cmbhotelcode.Text.Trim = "" Then fillHOTELCODE(cmbhotelcode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbhotelname.Enter
        Try
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Enter
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbhotelcode.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If SelectHotel.TEMPHOTELCODE <> "" Then cmbhotelcode.Text = SelectHotel.TEMPHOTELCODE
                If SelectHotel.TEMPHOTELNAME <> "" Then cmbhotelname.Text = SelectHotel.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbhotelcode.Validating
        Try
            If cmbhotelcode.Text.Trim <> "" Then HOTELCODEVALIDATE(cmbhotelcode, cmbhotelname, e, Me, txthoteladd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbhotelname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then cmbhotelcode.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then cmbhotelname.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbhotelname.Validated
        Try
            If cmbhotelname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTEL_CHECKIN AS CHECKIN, HOTEL_CHECKOUT AS CHECKOUT", "", " HOTELMASTER", " AND HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND HOTEL_CMPID = " & CmpId & " AND HOTEL_LOCATIONID = " & Locationid & " AND HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    txtcheckin.Text = DT.Rows(0).Item("CHECKIN")
                    txtcheckout.Text = DT.Rows(0).Item("CHECKOUT")
                End If
                FILLROOMTYPE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbhotelname.Validating
        Try
            If cmbhotelname.Text.Trim <> "" Then HOTELvalidate(cmbhotelname, cmbhotelcode, e, Me, txthoteladd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGUESTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGUEST As New SelectGuest
                OBJGUEST.ShowDialog()
                If OBJGUEST.TEMPGUESTNAME <> "" Then CMBGUESTNAME.Text = OBJGUEST.TEMPGUESTNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GUEST_MOBILENO AS MOBILENO, ISNULL(GUEST_EMAIL,'') AS EMAILID, ISNULL(PREFIX_NAME, '') AS PREFIX ", "", " GUESTMASTER LEFT OUTER JOIN PREFIXMASTER ON GUEST_PREFIXID = PREFIX_ID ", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    CMBPREFIX.Text = DT.Rows(0).Item("PREFIX")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbguestname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUESTNAME.Validating
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("Enquiry Locked/Closed!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Enquiry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsHotelEnqMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPENQNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim intres As Integer = OBJBOOKING.Delete()
                    MsgBox("Entry Deleted")
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNOOFROOMS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOOFROOMS.KeyPress
        numkeypress(e, TXTNOOFROOMS, Me)
    End Sub

    Sub CALC()
        Try
            If ClientName = "ELYSIUM" Then
                If CMBPACKAGE.Text.Trim = "No" Then
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTADULTS.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTEXTRAADULT.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTEXTRACHILD.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                End If
            Else
                If CMBPACKAGE.Text.Trim = "No" Then
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim)) + Val(TXTEXTRAADULTRATE.Text.Trim) + Val(TXTEXTRACHILDRATE.Text.Trim), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNOOFROOMS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNOOFROOMS.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DEPARTDATE.Validated
        Try
            If DEPARTDATE.Value.Date > ARRIVALDATE.Value.Date Then
                TXTTOTALNIGHTS.Text = DEPARTDATE.Value.Date.Subtract(ARRIVALDATE.Value.Date).Days
                total()
            Else
                MsgBox("Select Proper Dates", MsgBoxStyle.Critical)
                ARRIVALDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRAADULT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULT.KeyPress
        numkeypress(e, TXTEXTRAADULT, Me)
    End Sub

    Private Sub TXTEXTRACHILD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILD.KeyPress
        numkeypress(e, TXTEXTRACHILD, Me)
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Validated
        GETRATE()
    End Sub

    Sub GETRATE()
        Try
            If EDIT = True Then Exit Sub
            'GET RATE FROM TARIFFMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKDAYS,0) AS WEEKDAYS, ISNULL(TARIFFMASTER_DESC.TARIFF_WEEKENDS,0) AS WEEKENDS ", "", " TARIFFMASTER INNER JOIN TARIFFMASTER_DESC ON TARIFFMASTER.TARIFF_ID = TARIFFMASTER_DESC.TARIFF_ID AND TARIFFMASTER.TARIFF_CMPID = TARIFFMASTER_DESC.TARIFF_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = TARIFFMASTER_DESC.TARIFF_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = TARIFFMASTER_DESC.TARIFF_YEARID INNER JOIN HOTELMASTER ON TARIFFMASTER.TARIFF_HOTELID = HOTELMASTER.HOTEL_ID AND TARIFFMASTER.TARIFF_CMPID = HOTELMASTER.HOTEL_CMPID AND TARIFFMASTER.TARIFF_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND TARIFFMASTER.TARIFF_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON TARIFFMASTER_DESC.TARIFF_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID INNER JOIN PLANMASTER ON TARIFFMASTER_DESC.TARIFF_PLANID = PLANMASTER.PLAN_ID AND TARIFFMASTER_DESC.TARIFF_CMPID = PLANMASTER.PLAN_CMPID AND TARIFFMASTER_DESC.TARIFF_LOCATIONID = PLANMASTER.PLAN_LOCATIONID AND TARIFFMASTER_DESC.TARIFF_YEARID = PLANMASTER.PLAN_YEARID ", " AND HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND PLAN_NAME = '" & CMBPLAN.Text.Trim & "' AND CAST(TARIFF_FROMDATE AS DATE) <= '" & Format(ARRIVALDATE.Value.Date, "MM/dd/yyyy") & "' AND CAST(TARIFF_TODATE AS DATE) >= '" & Format(ARRIVALDATE.Value.Date, "MM/dd/yyyy") & "'")
            If DT.Rows.Count > 0 Then
                If ARRIVALDATE.Value.DayOfWeek = DayOfWeek.Saturday Or ARRIVALDATE.Value.DayOfWeek = DayOfWeek.Sunday Then
                    TXTRATE.Text = DT.Rows(0).Item("WEEKENDS")
                Else
                    TXTRATE.Text = DT.Rows(0).Item("WEEKDAYS")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then PLANvalidate(CMBPLAN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLROOMTYPE()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "ROOMTYPE"
                CMBROOMTYPE.DataSource = DT
                CMBROOMTYPE.DisplayMember = "ROOMTYPE"
                If EDIT = False Then CMBROOMTYPE.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROOMTYPE.Enter
        Try
            If cmbhotelname.Text.Trim <> "" Then FILLROOMTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRAADULTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRAADULTRATE.KeyPress
        numdotkeypress(e, TXTEXTRAADULTRATE, Me)
    End Sub

    Private Sub TXTEXTRACHILDRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHILDRATE.KeyPress
        numdotkeypress(e, TXTEXTRACHILDRATE, Me)
    End Sub

    Private Sub TXTDISCPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCPER.KeyPress
        numdotkeypress(e, TXTDISCPER, Me)
    End Sub

    Private Sub TXTDISCPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCPER.Validated
        total()
    End Sub

    Private Sub TXTDISCRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRS.KeyPress
        numdotkeypress(e, TXTDISCRS, Me)
    End Sub

    Private Sub TXTDISCRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRS.Validated
        total()
    End Sub

    Private Sub cmbaddsub_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbaddsub.Validated
        total()
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        numdotkeypress(e, txtotherchg, Me)
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        total()
    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress
        numkeypress(e, TXTADULTS, Me)
    End Sub

    Private Sub txtcheckin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheckin.KeyPress
        numkeypress(e, txtcheckin, Me)
    End Sub

    Private Sub txtcheckout_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheckout.KeyPress
        numkeypress(e, txtcheckout, Me)
    End Sub

    Private Sub TXTCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILDS.KeyPress
        numkeypress(e, TXTCHILDS, Me)
    End Sub

    Private Sub TXTNCCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNCCHILDS.KeyPress
        numkeypress(e, TXTNCCHILDS, Me)
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBADDTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbADDtax_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBADDTAX.Text.Trim <> "" Then TAXvalidate(CMBADDTAX, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PBDISCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDISCDEL.Click
        Try
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPENQNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, EDIT, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, EDIT, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBOTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'INDIRECT EXPENSES'", "INDIRECT EXPENSES")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRAADULT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULT.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRAADULTRATE_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRAADULTRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRACHILD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILD.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEXTRACHILDRATE_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHILDRATE.Validated
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTNOOFROOMS.Text.Trim) > 0 Then
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKAGE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKAGE.Validated
        CALC()
    End Sub

    Private Sub TXTEXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdotkeypress(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub TXTEXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        total()
    End Sub

    Private Sub TXTTEMPNIGHTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTEMPNIGHTS.KeyPress
        numkeypress(e, TXTTEMPNIGHTS, Me)
    End Sub

    Private Sub TXTTEMPNIGHTS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTEMPNIGHTS.Validating
        Try
            If Val(TXTTEMPNIGHTS.Text.Trim) > 0 Then DEPARTDATE.Value = DateAdd(DateInterval.Day, Val(TXTTEMPNIGHTS.Text.Trim), ARRIVALDATE.Value)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPREFIX.Enter
        Try
            If CMBPREFIX.Text.Trim = "" Then FILLPREFIX(CMBPREFIX)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPREFIX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPREFIX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPREFIX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPREFIX.Validating
        Try
            If CMBPREFIX.Text.Trim <> "" Then PREFIXvalidate(CMBPREFIX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub bookingdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ENQDATE.Validating
        'If Not datecheck(ENQDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub ARRIVALDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ARRIVALDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(ARRIVALDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
            If EDIT = False Then DEPARTDATE.Value = DateAdd(DateInterval.Day, 1, ARRIVALDATE.Value)
        End If
    End Sub

    Private Sub DEPARTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEPARTDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(DEPARTDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub CMBNOTES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Enter
        Try
            If CMBNOTES.Text.Trim = "" Then FILLNOTE(CMBNOTES, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTNOTES.Clear()
            Dim DT As DataTable = OBJCMN.search(" NOTE_REMARKS AS NOTE", "", " NOTEMASTER", " AND NOTE_NAME ='" & CMBNOTES.Text.Trim & "' AND NOTE_CMPID = " & CmpId & " AND NOTE_LOCATIONID = " & Locationid & " AND NOTE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTNOTES.Text = DT.Rows(0).Item("NOTE")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNOTES.Validating
        Try
            If CMBNOTES.Text.Trim <> "" Then NOTEVALIDATE(CMBNOTES, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Enter
        Try
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCANCEL.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTPOLICY.Clear()
            Dim DT As DataTable = OBJCMN.search(" POLICY_REMARKS AS POLICY", "", " POLICYMASTER", " AND POLICY_NAME ='" & CMBCANCEL.Text.Trim & "' AND POLICY_CMPID = " & CmpId & " AND POLICY_LOCATIONID = " & Locationid & " AND POLICY_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTPOLICY.Text = DT.Rows(0).Item("POLICY")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCANCEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCANCEL.Validating
        Try
            If CMBCANCEL.Text.Trim <> "" Then POLICYvalidate(CMBCANCEL, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROOMTYPE.Validated
        Try
            'GET ROOM RATE FROM HOTELMASTER
            If CMBROOMTYPE.Text.Trim <> "" And ClientName = "TOPCOMM" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER_ROOMDESC.HOTEL_RATE AS RATE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND ROOMTYPE_NAME ='" & CMBROOMTYPE.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTRATE.Text = DT.Rows(0).Item("RATE")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If Val(TXTCOPY.Text.Trim) > 0 Then
                If EDIT = True Then
                    MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTCOPY.Text.Trim <> "" Then
                    TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        TEMPENQNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPENQNO
                        TEMPENQNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJBOOKING As New ClsHotelEnqMaster()

                        ALPARAVAL.Add(TXTCOPY.Text.Trim)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJBOOKING.SELECTENQ()
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                TXTENQNO.Text = TEMPENQNO
                                ENQDATE.Value = Convert.ToDateTime(dr("ENQDATE"))
                                CMBGUESTNAME.Text = dr("GUESTNAME")
                                CMBPREFIX.Text = dr("PREFIX")
                                TXTGUESTADD.Text = dr("GUESTADD")
                                txthoteladd.Text = dr("HOTELADD")
                                txtrefno.Text = dr("REFNO")

                                cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                                cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                                FILLROOMTYPE()

                                ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                                DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                                txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                                txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))


                                TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                                CMBBOOKEDBY.Text = dr("BOOKEDBY")
                                CMBSOURCE.Text = dr("SOURCE")
                                TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                                TXTDISCPER.Text = dr("DISCPER")
                                TXTDISCRS.Text = dr("DISCRS")
                                TXTEXTRACHGS.Text = dr("EXTRACHGS")

                                cmbtax.Text = dr("TAXNAME")
                                txttax.Text = dr("TAXAMT")
                                CMBADDTAX.Text = dr("ADDTAXNAME")
                                TXTADDTAX.Text = dr("ADDTAXAMT")

                                CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                                If dr("OTHERCHGS") > 0 Then
                                    txtotherchg.Text = dr("OTHERCHGS")
                                    cmbaddsub.Text = "Add"
                                Else
                                    txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                    cmbaddsub.Text = "Sub."
                                End If

                                txtroundoff.Text = dr("ROUNDOFF")

                                TXTBOOKINGDESC.Text = dr("BOOKINGDESC")
                                TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                                CMBNOTES.Text = Convert.ToString(dr("NOTENAME"))
                                TXTNOTES.Text = Convert.ToString(dr("NOTE"))
                                CMBCANCEL.Text = Convert.ToString(dr("POLICYNAME"))
                                TXTPOLICY.Text = Convert.ToString(dr("POLICY"))


                                CHKAVL.Checked = Convert.ToBoolean(dr("AVL"))
                                TXTCONFIRMATIONNO.Text = Convert.ToString(dr("CONFNO"))
                                TXTCONFIRMEDBY.Text = Convert.ToString(dr("CONFBY"))


                                GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), Format(dr("amt"), "0.00"))
                                CMBINCLUSION.Text = Convert.ToString(dr("INCLUSION"))
                                CMBEXCLUSION.Text = Convert.ToString(dr("EXCLUSION"))
                            Next
                            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                            total()
                        Else
                            'IF ROWCOUNT = 0
                            clear()
                            EDIT = False
                            CMBGUESTNAME.Focus()
                        End If

                    Else
                        MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBACCCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
        Try
            If CMBACCCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBACCCODE, CMBNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBACCCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If EDIT = True Then
                If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Close Enquiry ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim obj As New ClsCommon
                        Dim dt As DataTable = obj.Execute_Any_String(" UPDATE HOTELENQMASTER SET ENQ_CLOSE=1 WHERE ENQ_NO=" & TEMPENQNO & " AND ENQ_YEARID=" & YearId & "", "", "")
                        MsgBox(" Enquiry No- " & TEMPENQNO & " Closed")
                        clear()
                        EDIT = False

                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFOLLOWUPBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFOLLOWUPBY.Enter
        Try
            If CMBFOLLOWUPBY.Text.Trim = "" Then FILLBOOKEDBY(CMBFOLLOWUPBY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFOLLOWUPBY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFOLLOWUPBY.Validating
        Try
            If CMBFOLLOWUPBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBFOLLOWUPBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSTAGE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSTAGE.Enter
        Try
            If CMBSTAGE.Text.Trim = "" Then FILLSTAGE(CMBSTAGE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTFOLLOWDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTFOLLOWDATE.Validating
        Try
            If DTFOLLOWDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTFOLLOWDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTNEXTDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTNEXTDATE.Validating
        Try
            If DTNEXTDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTNEXTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFNARR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFNARR.Validating
        Try
            If DTFOLLOWDATE.Text.Trim <> "" And CMBFOLLOWUPBY.Text.Trim <> "" And TXTFOLLOWTO.Text.Trim <> "" And CMBSTAGE.Text.Trim <> "" Then
                FILLFOLLOWUP()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFOLLOWUP()

        If GRIDFOLLOWDOUBLECLICK = False Then
            GRIDFOLLOW.Rows.Add(Val(TXTFSRNO.Text.Trim), DTFOLLOWDATE.Text, CMBFOLLOWUPBY.Text.Trim, TXTFOLLOWTO.Text.Trim, CMBSTAGE.Text.Trim, DTNEXTDATE.Text, TXTFNARR.Text.Trim)
            getsrno(GRIDFOLLOW)

        ElseIf GRIDFOLLOWDOUBLECLICK = True Then

            GRIDFOLLOW.Item(GFSRNO.Index, TEMPFOLLOWROW).Value = TXTFSRNO.Text.Trim
            GRIDFOLLOW.Item(GFDATE.Index, TEMPFOLLOWROW).Value = DTFOLLOWDATE.Text
            GRIDFOLLOW.Item(GFNAME.Index, TEMPFOLLOWROW).Value = CMBFOLLOWUPBY.Text.Trim
            GRIDFOLLOW.Item(GFOLLOWTO.Index, TEMPFOLLOWROW).Value = TXTFOLLOWTO.Text.Trim
            GRIDFOLLOW.Item(GFSTAGE.Index, TEMPFOLLOWROW).Value = CMBSTAGE.Text.Trim
            GRIDFOLLOW.Item(GFNEXTDATE.Index, TEMPFOLLOWROW).Value = DTNEXTDATE.Text
            GRIDFOLLOW.Item(GFNARR.Index, TEMPFOLLOWROW).Value = TXTFNARR.Text.Trim

            GRIDFOLLOWDOUBLECLICK = False


        End If
        GRIDFOLLOW.FirstDisplayedScrollingRowIndex = GRIDFOLLOW.RowCount - 1

        'If GRIDFOLLOWDOUBLECLICK = False Or (GRIDFOLLOWDOUBLECLICK = True And TEMPFOLLOWROW = GRIDFOLLOW.RowCount - 1) Then
        '    'GET CLOSING %
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As DataTable = OBJCMN.search(" STAGE_CLOSING AS CLOSING", "", " STAGEMASTER ", " AND STAGE_NAME = '" & CMBSTAGE.Text.Trim & "'")
        '    'If DT.Rows.Count > 0 Then TXTCLOSING.Text = Val(DT.Rows(0).Item(0))
        'End If


        TXTFSRNO.Text = GRIDFOLLOW.RowCount + 1
        DTFOLLOWDATE.Clear()
        CMBFOLLOWUPBY.Text = ""
        TXTFOLLOWTO.Clear()
        CMBSTAGE.Text = ""
        DTNEXTDATE.Clear()
        TXTFNARR.Clear()

        DTFOLLOWDATE.Focus()

    End Sub

    Private Sub GRIDFOLLOW_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFOLLOW.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDFOLLOW.Item(GFSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDFOLLOWDOUBLECLICK = True
                TXTFSRNO.Text = GRIDFOLLOW.Item(GFSRNO.Index, e.RowIndex).Value
                DTFOLLOWDATE.Text = GRIDFOLLOW.Item(GFDATE.Index, e.RowIndex).Value
                CMBFOLLOWUPBY.Text = GRIDFOLLOW.Item(GFNAME.Index, e.RowIndex).Value
                TXTFOLLOWTO.Text = GRIDFOLLOW.Item(GFOLLOWTO.Index, e.RowIndex).Value
                CMBSTAGE.Text = GRIDFOLLOW.Item(GFSTAGE.Index, e.RowIndex).Value
                DTNEXTDATE.Text = GRIDFOLLOW.Item(GFNEXTDATE.Index, e.RowIndex).Value
                TXTFNARR.Text = GRIDFOLLOW.Item(GFNARR.Index, e.RowIndex).Value


                TEMPFOLLOWROW = e.RowIndex
                DTFOLLOWDATE.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFOLLOW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFOLLOW.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFOLLOW.RowCount > 0 Then
                'dont allow user if any of the grid line is in EDIT mode.....
                If GRIDFOLLOWDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDFOLLOW.Rows.RemoveAt(GRIDFOLLOW.CurrentRow.Index)
                getsrno(GRIDFOLLOW)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTMISCENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMISCENQ.Click
        Try
            If EDIT = True Then
                MsgBox("Not Allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            SELECTENQ.Clear()
            Dim OBJHOTELENQ As New SelectMiscEnquiry
            OBJHOTELENQ.FRMSTRING = "HOTEL"
            OBJHOTELENQ.ShowDialog()
            SELECTENQ = OBJHOTELENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then
                TXTMISCENQNO.Text = (SELECTENQ.Rows(0).Item("MISCNO"))

                'GET OTHER DETAILS AS WELL
                Dim dttable As New DataTable
                Dim OBJENQ As New ClsMiscEnquiry

                OBJENQ.alParaval.Add(SELECTENQ.Rows(0).Item("MISCNO"))
                OBJENQ.alParaval.Add(YearId)
                dttable = OBJENQ.SELECTMISCENQ()
                If dttable.Rows.Count > 0 Then
                    CMBGUESTNAME.Text = dttable.Rows(0).Item("GUESTNAME").ToString
                    CMBSOURCE.Text = dttable.Rows(0).Item("SOURCE").ToString
                    CMBBOOKEDBY.Text = dttable.Rows(0).Item("BOOKEDBY").ToString
                    If dttable.Rows(0).Item("CHECKIN") <> "" Then ARRIVALDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKIN")).Date
                    If dttable.Rows(0).Item("CHECKOUT") <> "" Then DEPARTDATE.Value = Convert.ToDateTime(dttable.Rows(0).Item("CHECKOUT")).Date
                    TXTADD.Text = dttable.Rows(0).Item("ADDRESS").ToString
                    TXTADULTS.Text = Val(dttable.Rows(0).Item("ADULTS"))
                    TXTCHILDS.Text = Val(dttable.Rows(0).Item("CHILD"))
                    TXTNCCHILDS.Text = Val(dttable.Rows(0).Item("INFANTS"))
                    TXTEXTRACHILD.Text = Val(dttable.Rows(0).Item("CHILDWITHOUTBED"))
                    TXTEXTRAADULT.Text = Val(dttable.Rows(0).Item("EXTRAADULTS"))
                    TXTNOOFROOMS.Text = Val(dttable.Rows(0).Item("ROOMS"))
                End If
                CMBGUESTNAME.Focus()

            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBCURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURCODE.Enter
        Try
            If CMBCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBCURCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURCODE.Validating
        Try
            If CMBCURCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBCURCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HotelEnquiry_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            If ClientName = "MATRIX" Then Me.Close()

            If ClientName <> "AIRTRINITY" Or ClientName <> "BELLA" Then
                CMBCURCODE.Visible = False
                GCURCODE.Visible = False
                TXTROE.Visible = False
                GROE.Visible = False
                TXTTOTAL.Left = Val(TXTTOTAL.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
                GRIDBOOKINGS.Width = Val(GRIDBOOKINGS.Width) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
                LBLTOTALAMT.Left = Val(LBLTOTALAMT.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
                TXTTOTALAMT.Left = TXTTOTAL.Left
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDPURCHASEDOUBLECLICK = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value.ToString
                CMBPURNAME.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                TXTPURAMOUNT.Text = Val(GRIDPURCHASE.Item(GPURAMOUNT.Index, e.RowIndex).Value)
                CMBPURCURCODE.Text = GRIDPURCHASE.Item(GPURCURCODE.Index, e.RowIndex).Value.ToString
                TXTPURROE.Text = Val(GRIDPURCHASE.Item(GPURROE.Index, e.RowIndex).Value)
                TXTPURREMARKS.Text = GRIDPURCHASE.Item(GPURREMARKS.Index, e.RowIndex).Value.ToString
                TEMPPURROW = e.RowIndex
                CMBPURNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURCHASE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURCHASE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDPURCHASEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDPURCHASE.Rows.RemoveAt(GRIDPURCHASE.CurrentRow.Index)
                total()
                getsrno(GRIDPURCHASE)


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, EDIT, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
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
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, TXTPURADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMOUNT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBPURCURCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURCURCODE.Enter
        Try
            If CMBPURCURCODE.Text.Trim = "" Then FILLCURRENCY(CMBPURCURCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCURCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCURCODE.Validated
        Try
            'GET ROE
            If CMBPURCURCODE.Text.Trim <> "" And Val(TXTPURROE.Text.Trim) = 0 Then TXTPURROE.Text = GETROE(CMBPURCURCODE.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCURCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCURCODE.Validating
        Try
            If CMBPURCURCODE.Text.Trim <> "" Then CURRENCYvalidate(CMBPURCURCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTROE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROE.KeyPress, TXTPURROE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Sub FILLGRIDPURCHASE()
        Try
            If GRIDPURCHASEDOUBLECLICK = False Then

                GRIDPURCHASE.Rows.Add(Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Val(TXTPURAMOUNT.Text.Trim), CMBPURCURCODE.Text.Trim, Val(TXTPURROE.Text.Trim), TXTPURREMARKS.Text.Trim)
                getsrno(GRIDPURCHASE)

            ElseIf GRIDPURCHASEDOUBLECLICK = True Then

                GRIDPURCHASE.Item(GPURSRNO.Index, TEMPPURROW).Value = TXTPURSRNO.Text.Trim
                GRIDPURCHASE.Item(GPURNAME.Index, TEMPPURROW).Value = CMBPURNAME.Text.Trim
                GRIDPURCHASE.Item(GPURAMOUNT.Index, TEMPPURROW).Value = Val(TXTPURAMOUNT.Text.Trim)
                GRIDPURCHASE.Item(GPURCURCODE.Index, TEMPPURROW).Value = CMBPURCURCODE.Text.Trim
                GRIDPURCHASE.Item(GPURROE.Index, TEMPPURROW).Value = Val(TXTPURROE.Text.Trim)
                GRIDPURCHASE.Item(GPURREMARKS.Index, TEMPPURROW).Value = TXTPURREMARKS.Text.Trim

                GRIDPURCHASEDOUBLECLICK = False

            End If
            GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

            TXTPURSRNO.Text = GRIDPURCHASE.RowCount + 1
            CMBPURNAME.Text = ""
            TXTPURAMOUNT.Clear()
            CMBPURCURCODE.Text = ""
            TXTPURROE.Clear()
            TXTPURREMARKS.Clear()

            CMBPURNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPURREMARKS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURREMARKS.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" And Val(TXTPURAMOUNT.Text.Trim) > 0 Then
                FILLGRIDPURCHASE()
                total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURCODE.Validated
        Try
            'GET ROE
            If CMBCURCODE.Text.Trim <> "" And Val(TXTROE.Text.Trim) = 0 Then TXTROE.Text = GETROE(CMBCURCODE.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Enter
        Try
            If CMBEXCLUSION.Text.Trim = "" Then FILLEXCLUSION(CMBEXCLUSION, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBEXCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTEXCLUSIONS.Clear()
            Dim DT As DataTable = OBJCMN.search(" EXCLUSION_REMARKS AS EXCLUSION", "", " EXCLUSIONMASTER", " AND EXCLUSION_NAME ='" & CMBEXCLUSION.Text.Trim & "' AND EXCLUSION_CMPID = " & CmpId & " AND EXCLUSION_LOCATIONID = " & Locationid & " AND EXCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTEXCLUSIONS.Text = DT.Rows(0).Item("EXCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBEXCLUSION.Validating
        Try
            If CMBEXCLUSION.Text.Trim <> "" Then EXCLUSIONVALIDATE(CMBEXCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Validated(sender As Object, e As EventArgs) Handles CMBINCLUSION.Validated
        Try
            Dim OBJCMN As New ClsCommon
            TXTINCLUSIONS.Clear()
            Dim DT As DataTable = OBJCMN.search(" INCLUSION_REMARKS AS INCLUSION", "", " INCLUSIONMASTER", " AND INCLUSION_NAME ='" & CMBINCLUSION.Text.Trim & "' AND INCLUSION_CMPID = " & CmpId & " AND INCLUSION_LOCATIONID = " & Locationid & " AND INCLUSION_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTINCLUSIONS.Text = DT.Rows(0).Item("INCLUSION")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Validating(sender As Object, e As CancelEventArgs) Handles CMBINCLUSION.Validating
        Try
            If CMBINCLUSION.Text.Trim <> "" Then INCLUSIONVALIDATE(CMBINCLUSION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINCLUSION_Enter(sender As Object, e As EventArgs) Handles CMBINCLUSION.Enter
        Try
            If CMBINCLUSION.Text.Trim = "" Then FILLINCLUSION(CMBINCLUSION, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class