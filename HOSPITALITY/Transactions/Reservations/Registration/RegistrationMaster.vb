
Imports System.IO
Imports System.Net
Imports BL

Public Class RegistrationMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Public TEMPREGNO As Integer
    Dim TEMPMSG As Integer
    Public TEMPTOURNAME As String
    Dim Age As Double
    Dim hof As String = ""
    Dim Salename As String
    Dim Expiry As DateTime
    Dim TEMPINITIALS As String
    Dim TEMPFLIGHT As Double
    Dim TEMPFOREIGNEXCHNG As Double
    Dim TEMPSERVICECHGS As Double

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(REG_no),0) + 1 ", "REGISTRATIONMASTER", " AND REG_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTREGNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub clear()
        Try
            EP.Clear()
            CMBTOURNAME.Text = ""
            CMBTOURNAME.Enabled = True
            TXTGRPSTRENGTH.Clear()
            TXTBALSEATS.Clear()

            TXTMEAL.Clear()
            TXTREMARKS.Clear()

            STARTDATE.Value = Mydate
            ENDDATE.Value = Mydate
            TXTDOB.Clear()
            CMBGUEST.Text = ""
            CMBHOF.Text = ""
            CHKHOF.Checked = True
            DTEXPIRY.Value = Mydate

            CHKBILLCHECKED.Checked = False
            CHKBILLDISPUTE.Checked = False

            TXTVISA.Clear()

            TXTREGISTRATION.Clear()
            TXTREGNO.Clear()
            REGDATE.Value = Mydate
            CMDSELECTSTOCK.Enabled = True
            CMBCORDINATORVIA.Text = ""

            ''purchase 
            TXTPURPKGADULT.Clear()
            TXTPURPKGCHILD.Clear()
            TXTPURPKGINFANT.Clear()

            TXTPURADDADULT.Clear()
            TXTPURADDCHILD.Clear()
            TXTPURADDINFANT.Clear()

            TXTPURTOTALADULT.Clear()
            TXTPURTOTALCHILD.Clear()
            TXTPURTOTALINFANT.Clear()

            ''sale
            TXTSALEPKGADULT.Clear()
            TXTSALEPKGCHILD.Clear()
            TXTSALEPKGINFANT.Clear()

            TXTSALEADDADULT.Clear()
            TXTSALEADDCHILD.Clear()
            TXTSALEADDINFANT.Clear()

            TXTCUSTADULT.Clear()
            TXTCUSTCHILD.Clear()
            TXTCUSTINFANT.Clear()

            TXTSALEADDADULT.Clear()
            TXTSALEADDCHILD.Clear()
            TXTSALEADDINFANT.Clear()

            GRIDREG.RowCount = 0
            GRIDBILL.RowCount = 0

            TXTADDSERADULT.Clear()
            TXTADDSERCHILD.Clear()
            TXTADDSERINFANT.Clear()

            TXTSALEADDADULT.Clear()
            TXTSALEADDCHILD.Clear()
            TXTSALEADDINFANT.Clear()

            TXTSALETOTALADULT.Clear()
            TXTSALETOTALCHILD.Clear()
            TXTSALETOTALINFANT.Clear()

            TXTPROFFIT.Clear()
            TXTGRANDTOTAL.Clear()
            TXTBILLREMARKS.Clear()
            TXTDECREMARKS.Clear()
            TXTSUBTOTAL.Clear()
            TXTPURCHASETOTAL.Clear()
            TXTSERVICECHGS.Clear()
            CMBTAX.Text = ""
            TXTTAX.Clear()

            lbllocked.Visible = False
            PBlock.Visible = False
            PBCN.Visible = False
            PBRECD.Visible = False


            CMBSALENAME.Text = ""
            getmax_BOOKING_no()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False
            REGDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RegistrationMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemPipe Or e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                txtbillno.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 Then       'for tabselection
                TabControl1.SelectedIndex = 0
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for tabselection
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then       'for tabselection
                TabControl1.SelectedIndex = 2
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBSALENAME.Text.Trim = "" Then fillname(CMBSALENAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBGUEST.Text.Trim = "" Then FILLGUEST(CMBGUEST, edit, "")
            If CMBTOURNAME.Text.Trim = "" Then FILLTOURNAME(CMBTOURNAME, edit, "")
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If CMBHOF.Text.Trim = "" Then
                dt = objclscommon.search(" GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND RegistrationMaster.REG_HOFID = GuestMaster.GUEST_ID ", " and (REGISTRATIONMASTER.REG_HOFCHK = 1) AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GUEST_name"
                    CMBHOF.DataSource = dt
                    CMBHOF.DisplayMember = "GUEST_name"
                End If
                CMBHOF.SelectAll()
            End If

            dt = objclscommon.search("GUEST_NAME", "", "GUESTMASTER", " and GUEST_cmpid = " & CmpId & " and GUEST_CORDINATOR = 1 and GUEST_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "GUEST_name"
                CMBCORDINATORVIA.DataSource = dt
                CMBCORDINATORVIA.DisplayMember = "GUEST_name"
                CMBCORDINATORVIA.Text = ""
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(REGDATE.Value.Date)
            alParaval.Add(TXTREGISTRATION.Text.Trim)
            alParaval.Add(CMBTOURNAME.Text.Trim)
            alParaval.Add(TXTGRPSTRENGTH.Text.Trim)
            alParaval.Add(TXTBALSEATS.Text.Trim)

            alParaval.Add(STARTDATE.Value.Date)
            alParaval.Add(ENDDATE.Value.Date)
            alParaval.Add(CMBSALENAME.Text.Trim)
            alParaval.Add(CMBGUEST.Text.Trim)
            alParaval.Add(CMBHOF.Text.Trim)
            alParaval.Add(CHKHOF.CheckState)
            alParaval.Add(TXTVISA.Text.Trim)

            alParaval.Add(Val(TXTPURPKGADULT.Text.Trim))
            alParaval.Add(Val(TXTPURPKGCHILD.Text.Trim))
            alParaval.Add(Val(TXTPURPKGINFANT.Text.Trim))

            alParaval.Add(Val(TXTPURADDADULT.Text.Trim))
            alParaval.Add(Val(TXTPURADDCHILD.Text.Trim))
            alParaval.Add(Val(TXTPURADDINFANT.Text.Trim))

            alParaval.Add(Val(TXTPURTOTALADULT.Text.Trim))
            alParaval.Add(Val(TXTPURTOTALCHILD.Text.Trim))
            alParaval.Add(Val(TXTPURTOTALINFANT.Text.Trim))

            alParaval.Add(Val(TXTSALEPKGADULT.Text.Trim))
            alParaval.Add(Val(TXTSALEPKGCHILD.Text.Trim))
            alParaval.Add(Val(TXTSALEPKGINFANT.Text.Trim))

            alParaval.Add(Val(TXTCUSTADULT.Text.Trim))
            alParaval.Add(Val(TXTCUSTCHILD.Text.Trim))
            alParaval.Add(Val(TXTCUSTINFANT.Text.Trim))

            alParaval.Add(Val(TXTSALEADDADULT.Text.Trim))
            alParaval.Add(Val(TXTSALEADDCHILD.Text.Trim))
            alParaval.Add(Val(TXTSALEADDINFANT.Text.Trim))

            alParaval.Add(Val(TXTSALETOTALADULT.Text.Trim))
            alParaval.Add(Val(TXTSALETOTALCHILD.Text.Trim))
            alParaval.Add(Val(TXTSALETOTALINFANT.Text.Trim))

            alParaval.Add(Val(TXTADDSERADULT.Text.Trim))
            alParaval.Add(Val(TXTADDSERCHILD.Text.Trim))
            alParaval.Add(Val(TXTADDSERINFANT.Text.Trim))
            alParaval.Add(Val(TXTPROFFIT.Text.Trim))
            alParaval.Add(Val(TXTGRANDTOTAL.Text.Trim))
            alParaval.Add(TXTPERSONTYPE.Text.Trim)

            alParaval.Add(CMBCORDINATORVIA.Text.Trim)
            alParaval.Add(TXTMEAL.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(Val(TXTAMTREC.Text.Trim))
            alParaval.Add(Val(TXTEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTRETURN.Text.Trim))
            alParaval.Add(Val(TXTBAL.Text.Trim))

            If CHKBILLCHECKED.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If CHKBILLDISPUTE.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(TXTBILLREMARKS.Text.Trim)
            alParaval.Add(TXTDECREMARKS.Text.Trim)
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(Val(TXTPURCHASETOTAL.Text.Trim))
            alParaval.Add(Val(TXTSERVICECHGS.Text.Trim))
            alParaval.Add((CMBTAX.Text.Trim))
            alParaval.Add(Val(TXTTAX.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            'ADDITIONAL DETAILS
            Dim SRNO As String = ""
            Dim NAME As String = ""
            Dim CURRENCY As String = ""
            Dim ADULT As String = ""
            Dim ADULTINR As String = ""
            Dim CHILD As String = ""
            Dim CHILDINR As String = ""
            Dim INFANT As String = ""
            Dim INFANTINR As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDREG.Rows
                If row.Cells(0).Value = True Then
                    If row.Cells(1).Value <> Nothing Then
                        If SRNO = "" Then
                            SRNO = row.Cells(GSRNO.Index).Value.ToString
                            NAME = row.Cells(GNAME.Index).Value.ToString
                            CURRENCY = row.Cells(GCURRENCY.Index).Value.ToString
                            ADULT = row.Cells(GADULT.Index).Value.ToString
                            ADULTINR = row.Cells(GADULTINR.Index).Value.ToString
                            CHILD = row.Cells(GCHILD.Index).Value.ToString
                            CHILDINR = row.Cells(GCHILDINR.Index).Value.ToString
                            INFANT = row.Cells(GINFANT.Index).Value.ToString
                            INFANTINR = row.Cells(GINFANTINR.Index).Value.ToString
                        Else
                            SRNO = SRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                            NAME = NAME & "|" & row.Cells(GNAME.Index).Value.ToString
                            CURRENCY = CURRENCY & "|" & row.Cells(GCURRENCY.Index).Value.ToString
                            ADULT = ADULT & "|" & row.Cells(GADULT.Index).Value.ToString
                            ADULTINR = ADULTINR & "|" & row.Cells(GADULTINR.Index).Value.ToString
                            CHILD = CHILD & "|" & row.Cells(GCHILD.Index).Value.ToString
                            CHILDINR = CHILDINR & "|" & row.Cells(GCHILDINR.Index).Value.ToString
                            INFANT = INFANT & "|" & row.Cells(GINFANT.Index).Value.ToString
                            INFANTINR = INFANTINR & "|" & row.Cells(GINFANTINR.Index).Value.ToString
                        End If
                    End If
                End If
            Next

            alParaval.Add(SRNO)
            alParaval.Add(NAME)
            alParaval.Add(CURRENCY)
            alParaval.Add(ADULT)
            alParaval.Add(ADULTINR)
            alParaval.Add(CHILD)
            alParaval.Add(CHILDINR)
            alParaval.Add(INFANT)
            alParaval.Add(INFANTINR)

            'ADDITIONAL DETAILS
            Dim GIFTSRNO As String = ""
            Dim GIFTNAME As String = ""
            Dim GIFTQTY As String = ""
            Dim GIFTRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBILL.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GIFTSRNO = "" Then
                        GIFTSRNO = row.Cells(GGiftsrno.Index).Value.ToString
                        GIFTNAME = row.Cells(gGiftname.Index).Value.ToString
                        GIFTQTY = row.Cells(GGiftQty.Index).Value.ToString
                        GIFTRATE = row.Cells(GGiftRate.Index).Value.ToString
                    Else
                        GIFTSRNO = GIFTSRNO & "|" & row.Cells(GGiftsrno.Index).Value.ToString
                        GIFTNAME = GIFTNAME & "|" & row.Cells(gGiftname.Index).Value.ToString
                        GIFTQTY = GIFTQTY & "|" & row.Cells(GGiftQty.Index).Value.ToString
                        GIFTRATE = GIFTRATE & "|" & row.Cells(GGiftRate.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GIFTSRNO)
            alParaval.Add(GIFTNAME)
            alParaval.Add(GIFTQTY)
            alParaval.Add(GIFTRATE)

            Dim OBJBOOKING As New ClsRegistrationMaster()
            OBJBOOKING.alParaval = alParaval


            If edit = False Then
                Dim DTNO As DataTable = OBJBOOKING.save()
                MessageBox.Show("Details Added")
                TEMPMSG = MsgBox("Wish to Register Another Family Member ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    getmax_BOOKING_no()
                    hof = CMBHOF.Text.Trim
                    Salename = CMBSALENAME.Text.Trim
                    CHKHOF.Checked = False
                    CMBSALENAME.Text = Salename
                    CMBHOF.Text = hof
                    GETBALANCESEATS()
                    CMBGUEST.Text = ""
                    CMBGUEST.Focus()
                Else
                    clear()
                    CMBTOURNAME.Focus()
                End If
            Else
                alParaval.Add(TEMPREGNO)

                IntResult = OBJBOOKING.update()
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(TEMPREGNO)
                clear()
                CMBTOURNAME.Focus()
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Registration Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsRegistrationMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPREGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJBOOKING.Delete()
                    MsgBox(DT.Rows(0).Item(0))

                    clear()
                    edit = False

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETBALANCESEATS()
        Dim OBJCMN As New ClsCommon
        Dim dt1 As DataTable = OBJCMN.search(" ISNULL(TOURMASTER.TOUR_NAME,'')", "", "TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID", " AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' and REGISTRATIONMASTER.REG_PERSONTYPE<>'INFANT' AND TOURMASTER.TOUR_YEARID=" & YearId & "")
        If dt1.Rows.Count > 0 Then
            TXTBALSEATS.Text = Val(TXTGRPSTRENGTH.Text.Trim) - Val(dt1.Rows.Count)
            'Else
            '    MsgBox(" Group Strength Completed !", MsgBoxStyle.Critical)
            '    Exit Sub
        End If
    End Sub

    Private Sub RegistrationMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'REGISTRATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsRegistrationMaster()

                ALPARAVAL.Add(TEMPREGNO)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTREG()
                If dt.Rows.Count > 0 Then

                    TXTREGNO.ReadOnly = True
                    TXTREGNO.Text = TEMPREGNO
                    TXTREGISTRATION.Text = dt.Rows(0).Item("INVNO")
                    REGDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("REGDATE")).Date
                    CMBTOURNAME.Text = dt.Rows(0).Item("TOURNAME")
                    CMBTOURNAME.Enabled = False
                    GETDATA()
                    TXTGRPSTRENGTH.Text = dt.Rows(0).Item("GRPSTRENGTH")

                    GETBALANCESEATS()

                    STARTDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("STARTDATE")).Date
                    ENDDATE.Value = Convert.ToDateTime(dt.Rows(0).Item("ENDDATE")).Date

                    If dt.Rows(0).Item("HOFCHK") = 0 Then
                        CHKHOF.CheckState = CheckState.Unchecked
                    Else
                        CHKHOF.CheckState = CheckState.Checked
                    End If
                    CMBSALENAME.Text = dt.Rows(0).Item("ACCNAME")
                    CMBGUEST.Text = dt.Rows(0).Item("GUESTNAME")
                    GUESTDETAIL()
                    ' DOB()
                    GENRATEDOB()
                    TXTMEAL.Text = dt.Rows(0).Item("MEALPLAN")
                    TXTREMARKS.Text = dt.Rows(0).Item("REMARKS")

                    If dt.Rows(0).Item("BILLCHECKED") = 0 Then
                        CHKBILLCHECKED.Checked = False
                    Else
                        CHKBILLCHECKED.Checked = True
                    End If
                    If dt.Rows(0).Item("BILLDISPUTE") = 0 Then
                        CHKBILLDISPUTE.Checked = False
                    Else
                        CHKBILLDISPUTE.Checked = True
                    End If

                    TXTAMTREC.Text = dt.Rows(0).Item("AMTREC")
                    TXTEXTRAAMT.Text = dt.Rows(0).Item("EXTRAAMT")
                    TXTRETURN.Text = dt.Rows(0).Item("RETURN")
                    TXTBAL.Text = dt.Rows(0).Item("BALANCE")

                    If Val(dt.Rows(0).Item("AMTREC")) > 0 Or Val(dt.Rows(0).Item("EXTRAAMT")) > 0 Then
                        PBRECD.Visible = True
                        cmdshowdetails.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                    If Val(dt.Rows(0).Item("RETURN")) > 0 Then
                        cmdshowdetails.Visible = True
                        PBCN.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    CMBHOF.Text = dt.Rows(0).Item("HOF")
                    TXTVISA.Text = dt.Rows(0).Item("VISA")
                    TXTPURPKGADULT.Text = dt.Rows(0).Item("PURPKGADULT")
                    TXTPURPKGCHILD.Text = dt.Rows(0).Item("PURPKGCHILD")
                    TXTPURPKGINFANT.Text = dt.Rows(0).Item("PURPKGINFANT")

                    TXTPURADDADULT.Text = dt.Rows(0).Item("PURADDADULT")
                    TXTPURADDCHILD.Text = dt.Rows(0).Item("PURADDCHILD")
                    TXTPURADDINFANT.Text = dt.Rows(0).Item("PURADDINFANT")

                    TXTPURTOTALADULT.Text = dt.Rows(0).Item("PURTOTALADULT")
                    TXTPURTOTALCHILD.Text = dt.Rows(0).Item("PURTOTALCHILD")
                    TXTPURTOTALINFANT.Text = dt.Rows(0).Item("PURTOTALINFANT")

                    TXTSALEPKGADULT.Text = dt.Rows(0).Item("SALEPKGADULT")
                    TXTSALEPKGCHILD.Text = dt.Rows(0).Item("SALEPKGCHILD")
                    TXTSALEPKGINFANT.Text = dt.Rows(0).Item("SALEPKGINFANT")

                    TXTCUSTADULT.Text = dt.Rows(0).Item("CUSTADULT")
                    TXTCUSTCHILD.Text = dt.Rows(0).Item("CUSTCHILD")
                    TXTCUSTINFANT.Text = dt.Rows(0).Item("CUSTINFANT")

                    TXTSALEADDADULT.Text = dt.Rows(0).Item("SALEADDADULT")
                    TXTSALEADDCHILD.Text = dt.Rows(0).Item("SALEADDCHILD")
                    TXTSALEADDINFANT.Text = dt.Rows(0).Item("SALEADDINFANT")

                    TXTSALETOTALADULT.Text = dt.Rows(0).Item("SALETOTALADULT")
                    TXTSALETOTALCHILD.Text = dt.Rows(0).Item("SALETOTALCHILD")
                    TXTSALETOTALINFANT.Text = dt.Rows(0).Item("SALETOTALINFANT")

                    TXTADDSERADULT.Text = dt.Rows(0).Item("ADDSERVADULT")
                    TXTADDSERCHILD.Text = dt.Rows(0).Item("ADDSERVCHILD")
                    TXTADDSERINFANT.Text = dt.Rows(0).Item("ADDSERVINFANT")

                    TXTPROFFIT.Text = dt.Rows(0).Item("PROFFIT")
                    TXTGRANDTOTAL.Text = dt.Rows(0).Item("GRANDTOTAL")
                    TXTPERSONTYPE.Text = dt.Rows(0).Item("PERSONTYPE")
                    CMBCORDINATORVIA.Text = dt.Rows(0).Item("CORDINATOR")

                    TXTBILLREMARKS.Text = dt.Rows(0).Item("BILLREMARKS")
                    TXTDECREMARKS.Text = dt.Rows(0).Item("DECREMARKS")
                    TXTSUBTOTAL.Text = dt.Rows(0).Item("SUBTOTAL")
                    TXTPURCHASETOTAL.Text = dt.Rows(0).Item("TOTALPURCHASEAMT")
                    TXTSERVICECHGS.Text = dt.Rows(0).Item("SERVICECHGS")
                    CMBTAX.Text = dt.Rows(0).Item("TAXNAME")
                    TXTTAX.Text = dt.Rows(0).Item("TAXAMT")
                    TabControl1.SelectedIndex = 2

                    For Each dr As DataRow In dt.Rows
                        If dr("SERVICE") <> "" Then
                            For Each row As Windows.Forms.DataGridViewRow In GRIDREG.Rows
                                If dr("SERVICE") = row.Cells(2).Value Then
                                    row.Cells(0).Value = True
                                End If
                            Next
                        End If
                    Next

                    If GRIDREG.RowCount > 0 Then
                        GRIDREG.FirstDisplayedScrollingRowIndex = GRIDREG.RowCount - 1
                    End If

                    Dim OBJCMN As New ClsCommon
                    Dim DT1 As DataTable = OBJCMN.search(" ISNULL(REGISTRATION_GIFT.REG_GRIDSRNO, 0) AS GIFTSRNO, ISNULL(GIFTMASTER.GIFT_name, '') AS GIFTNAME, ISNULL(REGISTRATION_GIFT.REG_QTY, 0) AS GIFTQTY, ISNULL(REGISTRATION_GIFT.REG_RATE, 0) AS GIFTRATE ", "", " REGISTRATIONMASTER LEFT OUTER JOIN REGISTRATION_GIFT ON REGISTRATIONMASTER.REG_NO = REGISTRATION_GIFT.REG_NO AND REGISTRATIONMASTER.REG_YEARID = REGISTRATION_GIFT.REG_YEARID AND REGISTRATIONMASTER.REG_REGISTERID = REGISTRATION_GIFT.REG_REGISTERID LEFT OUTER JOIN GIFTMASTER ON REGISTRATION_GIFT.REG_YEARID = GIFTMASTER.GIFT_yearid AND REGISTRATION_GIFT.REG_GIFTID = GIFTMASTER.GIFT_id", " AND REGISTRATIONMASTER.REG_NO=" & TEMPREGNO & " AND REGISTRATIONMASTER.REG_YEARID = " & YearId & " order by REGISTRATION_GIFT.REG_GRIDSRNO")
                    If DT1.Rows.Count > 0 Then
                        For Each dr As DataRow In DT1.Rows
                            GRIDBILL.Rows.Add(dr("GIFTSRNO").ToString, dr("GIFTNAME"), dr("GIFTQTY"), Format(Val(dr("GIFTRATE")), "0.00"))
                        Next
                        GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1
                    End If
                    total()
                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    REGDATE.Focus()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TOURMASTER.TOUR_GRPSTRENGTH AS STRENGTH, TOURMASTER.TOUR_DAYS AS DAYS, TOURMASTER.TOUR_STARTDATE AS STARTDATE, TOURMASTER.TOUR_ENDDATE AS ENDDATE, ISNULL(TOURMASTER.TOUR_PKGADULT, 0) AS PURPKGADULT, ISNULL(TOURMASTER.TOUR_PKGCHILD, 0) AS PURPKGCHILD, ISNULL(TOURMASTER.TOUR_PKGINFANT, 0) AS PURPKGINFANT, ISNULL(TOURMASTER.TOUR_FADULTTOTAL, 0) AS ADDADULT, ISNULL(TOURMASTER.TOUR_FCHILDTOTAL, 0) AS ADDCHILD, ISNULL(TOURMASTER.TOUR_FINFANTTOTAL, 0) AS ADDINFANT, ISNULL(TOURMASTER.TOUR_DECPKGADULT, 0) AS SALEPKGADULT, ISNULL(TOURMASTER.TOUR_DECPKGCHILD, 0) AS SALEPKGCHILD, ISNULL(TOURMASTER.TOUR_DECPKGINFANT, 0) AS SALEPKGINFANT, ISNULL(TOUR_ADDSERVICES.TOUR_GRIDSRNO, 0) AS SRNO, ISNULL(SERVICEMASTER.SERVICE_name, '') AS SERVICE, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_ADDSERVICES.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_ADDSERVICES.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_ADDSERVICES.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_ADDSERVICES.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_ADDSERVICES.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_ADDSERVICES.TOUR_INFANTINR, 0) AS INFANTINR  ", "", " CURRENCYMASTER RIGHT OUTER JOIN TOUR_ADDSERVICES ON CURRENCYMASTER.cur_yearid = TOUR_ADDSERVICES.TOUR_yearid AND CURRENCYMASTER.cur_id = TOUR_ADDSERVICES.TOUR_CURRENCYID LEFT OUTER JOIN SERVICEMASTER ON TOUR_ADDSERVICES.TOUR_ADDSERVICEID = SERVICEMASTER.SERVICE_id AND TOUR_ADDSERVICES.TOUR_yearid = SERVICEMASTER.SERVICE_yearid RIGHT OUTER JOIN TOURMASTER ON TOUR_ADDSERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID AND TOUR_ADDSERVICES.TOUR_NO = TOURMASTER.TOUR_NO ", " AND TOURMASTER.TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each dr As DataRow In DT.Rows
                    GRIDREG.Rows.Add(0, dr("SRNO").ToString, dr("SERVICE"), dr("CURRENCY"), Format(Val(dr("ADULT")), "0.00"), Format(Val(dr("ADULTINR")), "0.00"), Format(Val(dr("CHILD")), "0.00"), Format(Val(dr("CHILDINR")), "0.00"), Format(Val(dr("INFANT")), "0.00"), Format(Val(dr("INFANTINR")), "0.00"))
                Next
                GRIDREG.FirstDisplayedScrollingRowIndex = GRIDREG.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETREGISTRATION()
        Try
            If CMBTOURNAME.Text.Trim <> "" And CMBHOF.Text.Trim <> "" And edit = False Then
                TXTREGISTRATION.Text = CMBTOURNAME.Text.Trim & "/"
                Dim OBJCMN As New ClsCommon

                'GETTING BOOKING NO FOR THAT PERTICULAR TOUR
                Dim DT As DataTable = OBJCMN.search(" COUNT(REG_NO) AS TOTALREG", "", " REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REG_YEARID = TOUR_YEARID ", " AND TOURMASTER.TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND REG_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTREGISTRATION.Text = TXTREGISTRATION.Text.Trim & DT.Rows(0).Item(0) + 1

                'GETTING HOF NO FOR THAT TOUR
                Dim DT1 As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_NAME AS HOFNAME, REG_INVNO AS REGNO", "", " REGISTRATIONMASTER INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_HOFID = GUESTMASTER.GUEST_ID INNER JOIN TOURMASTER ON REG_TOURID = TOURMASTER.TOUR_NO AND REG_YEARID = TOUR_YEARID ", " AND TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND REG_YEARID = " & YearId)
                If DT1.Rows.Count <= 0 Then
                    TXTREGISTRATION.Text = TXTREGISTRATION.Text.Trim & "/1"
                Else
                    Dim BLNMATCH As Boolean = False
                    For Each ROW As DataRow In DT1.Rows
                        If ROW("HOFNAME") = CMBHOF.Text.Trim Then
                            Dim NO As Integer = Val(StrReverse(ROW("REGNO").ToString).Substring(0, StrReverse(ROW("REGNO").ToString).IndexOf("/")))
                            TXTREGISTRATION.Text = TXTREGISTRATION.Text & "/" & Val(NO)
                            BLNMATCH = True
                            Exit For
                        End If
                    Next
                    If BLNMATCH = False Then
                        DT1 = OBJCMN.search(" DISTINCT COUNT(REG_HOFID) AS HOFNO ", "", " REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REG_YEARID = TOUR_YEARID ", " AND TOURMASTER.TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND REG_YEARID = " & YearId)
                        TXTREGISTRATION.Text = TXTREGISTRATION.Text & "/" & DT1.Rows.Count + 1
                    End If
                End If


                DT = OBJCMN.search(" COUNT(REG_NO) AS REGNO", "", " REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_HOFID = GUESTMASTER.GUEST_ID", " AND TOURMASTER.TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND GUESTMASTER.GUEST_NAME = '" & CMBHOF.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTREGISTRATION.Text = TXTREGISTRATION.Text & "-" & Val(DT.Rows(0).Item(0)) + 1
                Else
                    TXTREGISTRATION.Text = TXTREGISTRATION.Text & "-1"
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon


        If CMBTOURNAME.Text.Trim = "" Then
            EP.SetError(CMBTOURNAME, " Please Fill Tour name")
            bln = False
        End If


        If Val(TXTBALSEATS.Text.Trim) = 0 And edit = False And TXTPERSONTYPE.Text.Trim <> "Infant" Then
            EP.SetError(TXTBALSEATS, " Seats Not Available For This Tour !")
            bln = False
        End If


        GETREGISTRATION()
        If TXTREGISTRATION.Text.Trim = "" Then
            EP.SetError(TXTREGISTRATION, " Registration no is Mandate")
            bln = False
        End If

        If CMBGUEST.Text.Trim = "" Then
            EP.SetError(CMBGUEST, " Please Fill Guest name")
            bln = False
        End If

        If CMBHOF.Text.Trim = "" Then
            EP.SetError(CMBHOF, " Please Fill Head Of Family")
            bln = False
        End If

        If CMBSALENAME.Text.Trim = "" Then
            EP.SetError(CMBSALENAME, " Please Fill Customer Name !")
            bln = False
        End If

        Dim DTNEW As DataTable = OBJCMN.search(" ISNULL(GUEST_LEADER,0) ", "", " GUESTMASTER", " and GUEST_NAME= '" & CMBGUEST.Text.Trim & "' and GUEST_Yearid = " & YearId)
        If DTNEW.Rows.Count > 0 Then

            If Convert.ToBoolean(DTNEW.Rows(0).Item(0)) = False Then
                If Val(TXTSALETOTALADULT.Text.Trim) <= 0 Or Val(TXTSALETOTALCHILD.Text.Trim) <= 0 Or Val(TXTSALETOTALINFANT.Text.Trim) <= 0 Then
                    EP.SetError(TXTSALETOTALADULT, " Sale Amt Cannot be 0 !")
                    bln = False
                End If

                If Val(TXTGRANDTOTAL.Text.Trim) <= 0 Then
                    EP.SetError(TXTGRANDTOTAL, " Sale Amt Cannot be 0 !")
                    bln = False
                End If
            End If
        End If

        If GRIDBILL.RowCount > 0 And edit = False Then
            For Each row As DataGridViewRow In GRIDBILL.Rows

                If (row.Cells(gGiftname.Index).Value) <> "" And Val(row.Cells(GGiftRate.Index).Value) > 0 And Val(row.Cells(GGiftQty.Index).Value) > 0 Then
                    Dim STRGIFTNAME As String
                    Dim STRGIFTRATE As Double
                    Dim STRGIFTQTY As Integer


                    STRGIFTNAME = (row.Cells(gGiftname.Index).Value)
                    STRGIFTRATE = Val(row.Cells(GGiftRate.Index).Value)
                    STRGIFTQTY = Val(row.Cells(GGiftQty.Index).Value)

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable = objclscommon.search(" SUM(QTY) AS QTY ", "", " GIFT_VIEW", " and GIFTNAME= '" & STRGIFTNAME & "' and RATE= '" & STRGIFTRATE & "' AND cmpid = " & CmpId & " and Yearid = " & YearId & " GROUP BY GIFTNAME,RATE")
                    If STRGIFTQTY > Val(dt.Rows(0).Item(0)) Then
                        GRIDBILL.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        EP.SetError(GRIDBILL, "Gift are not available !")
                        bln = False
                    End If
                End If
            Next
        End If
        If GRIDBILL.RowCount > 0 And edit = True Then
            For Each row As DataGridViewRow In GRIDBILL.Rows
                If (row.Cells(gGiftname.Index).Value) <> "" And Val(row.Cells(GGiftRate.Index).Value) > 0 And Val(row.Cells(GGiftQty.Index).Value) > 0 Then
                    Dim STRGIFTNAME As String
                    Dim STRGIFTRATE As Double
                    Dim STRGIFTQTY As Integer
                    Dim BALQTY As Double
                    STRGIFTNAME = (row.Cells(gGiftname.Index).Value)
                    STRGIFTRATE = Val(row.Cells(GGiftRate.Index).Value)
                    STRGIFTQTY = Val(row.Cells(GGiftQty.Index).Value)
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable = objclscommon.search(" SUM(QTY) AS QTY ", "", " GIFT_VIEW", " and GIFTNAME= '" & STRGIFTNAME & "' and RATE= '" & STRGIFTRATE & "' AND cmpid = " & CmpId & " and Yearid = " & YearId & " GROUP BY GIFTNAME,RATE")
                    If dt.Rows.Count > 0 Then
                        BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.00")
                    End If
                    Dim dt1 As DataTable = objclscommon.search(" REGISTRATION_GIFT.REG_QTY AS GIFTQTY ", "", " REGISTRATION_GIFT INNER JOIN REGISTRATIONMASTER ON REGISTRATION_GIFT.REG_NO = REGISTRATIONMASTER.REG_NO AND REGISTRATION_GIFT.REG_YEARID = REGISTRATIONMASTER.REG_YEARID INNER JOIN GIFTMASTER ON REGISTRATION_GIFT.REG_GIFTID = GIFTMASTER.GIFT_id AND REGISTRATION_GIFT.REG_YEARID = GIFTMASTER.GIFT_yearid", " AND GIFTMASTER.GIFT_NAME='" & STRGIFTNAME & "' AND REGISTRATION_GIFT.REG_RATE= " & STRGIFTRATE & " AND REGISTRATION_GIFT.REG_NO= " & TEMPREGNO & " AND REGISTRATION_GIFT.REG_YEARID = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        BALQTY = BALQTY + Val(dt1.Rows(0).Item(0))
                    End If

                    If STRGIFTQTY > BALQTY Then
                        EP.SetError(GRIDBILL, "Stock Not Present,You Can Select Only " & BALQTY & " ! ")
                        GRIDBILL.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        bln = False
                    End If
                End If
            Next
        End If

        Return bln
    End Function

    Sub PASSPORTEXPIRY()

        Dim Tempexpiry As Date = DateAdd(DateInterval.Month, 6, STARTDATE.Value.Date)
        If Tempexpiry.Date >= DTEXPIRY.Value.Date Then
            TEMPMSG = MsgBox("Customer Passport has been expired ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                If PASS <> "finasta" Then
                    MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                    CMBGUEST.Focus()
                    Exit Sub
                End If
            Else
                CMBGUEST.Focus()
            End If
        End If
    End Sub

    Sub total()

        Try
            ''add service grid total
            TXTADDSERADULT.Text = "0.00"
            TXTADDSERCHILD.Text = "0.00"
            TXTADDSERINFANT.Text = "0.00"

            ''sale add service total
            TXTSALEADDADULT.Text = "0.00"
            TXTSALEADDCHILD.Text = "0.00"
            TXTSALEADDINFANT.Text = "0.00"

            ''Purchase total
            TXTPURTOTALADULT.Text = "0.00"
            TXTPURTOTALCHILD.Text = "0.00"
            TXTPURTOTALINFANT.Text = "0.00"

            '' sale grand total
            TXTSALETOTALADULT.Text = "0.00"
            TXTSALETOTALCHILD.Text = "0.00"
            TXTSALETOTALINFANT.Text = "0.00"

            TXTSUBTOTAL.Text = 0.0
            TXTPURCHASETOTAL.Text = 0.0
            TXTSERVICECHGS.Text = 0.0
            TXTTAX.Text = 0.0
            TXTGRANDTOTAL.Text = 0.0

            If GRIDREG.RowCount > 0 Then
                For Each ROW As DataGridViewRow In GRIDREG.Rows
                    If Val(ROW.Cells(GADULTINR.Index).Value) > 0 And (Val(ROW.Cells(gCHK.Index).Value) = 1 Or Val(ROW.Cells(gCHK.Index).Value) = True) Then TXTADDSERADULT.Text = Format(Val(TXTADDSERADULT.Text) + Val(ROW.Cells(GADULTINR.Index).Value), "0")
                    If Val(ROW.Cells(GCHILDINR.Index).Value) > 0 And (Val(ROW.Cells(gCHK.Index).Value) = 1 Or Val(ROW.Cells(gCHK.Index).Value) = True) Then TXTADDSERCHILD.Text = Format(Val(TXTADDSERCHILD.Text) + Val(ROW.Cells(GCHILDINR.Index).Value), "0")
                    If Val(ROW.Cells(GINFANTINR.Index).Value) > 0 And (Val(ROW.Cells(gCHK.Index).Value) = 1 Or Val(ROW.Cells(gCHK.Index).Value) = True) Then TXTADDSERINFANT.Text = Format(Val(TXTADDSERINFANT.Text) + Val(ROW.Cells(GINFANTINR.Index).Value), "0")

                    TXTSALEADDADULT.Text = Val(TXTADDSERADULT.Text.Trim)
                    TXTSALEADDCHILD.Text = Val(TXTADDSERCHILD.Text.Trim)
                    TXTSALEADDINFANT.Text = Val(TXTADDSERINFANT.Text.Trim)

                Next
            End If

            TXTPURTOTALADULT.Text = Val(TXTPURPKGADULT.Text.Trim) + Val(TXTPURADDADULT.Text.Trim)
            TXTPURTOTALCHILD.Text = Val(TXTPURPKGCHILD.Text.Trim) + Val(TXTPURADDCHILD.Text.Trim)
            TXTPURTOTALINFANT.Text = Val(TXTPURPKGINFANT.Text.Trim) + Val(TXTPURADDINFANT.Text.Trim)

            TXTSALETOTALADULT.Text = Val(TXTCUSTADULT.Text.Trim) + Val(TXTSALEADDADULT.Text.Trim)
            TXTSALETOTALCHILD.Text = Val(TXTCUSTCHILD.Text.Trim) + Val(TXTSALEADDCHILD.Text.Trim)
            TXTSALETOTALINFANT.Text = Val(TXTCUSTINFANT.Text.Trim) + Val(TXTSALEADDINFANT.Text.Trim)

            If Val(Age) <= 2 Then
                TXTSUBTOTAL.Text = Val(TXTSALETOTALINFANT.Text.Trim)
                LBLTOTAL.Text = "INFANT GRAND TOTAL"
                TXTPROFFIT.Text = Val(TXTCUSTINFANT.Text.Trim) - Val(TXTPURPKGINFANT.Text.Trim)
                LBLPROFFIT.Text = "PROFFIT ON THIS INFANT"
                TXTPERSONTYPE.Text = "INFANT"
            ElseIf Val(Age) <= 12 And Val(Age) > 2 Then
                TXTSUBTOTAL.Text = Val(TXTSALETOTALCHILD.Text.Trim)
                LBLTOTAL.Text = "CHILD GRAND TOTAL"
                TXTPROFFIT.Text = Val(TXTCUSTCHILD.Text.Trim) - Val(TXTPURPKGCHILD.Text.Trim)
                LBLPROFFIT.Text = "PROFFIT ON THIS CHILD"
                TXTPERSONTYPE.Text = "CHILD"
            ElseIf Val(Age) > 12 Then
                TXTSUBTOTAL.Text = Val(TXTSALETOTALADULT.Text.Trim)
                LBLTOTAL.Text = "ADULT GRAND TOTAL"
                TXTPROFFIT.Text = Val(TXTCUSTADULT.Text.Trim) - Val(TXTPURPKGADULT.Text.Trim)
                LBLPROFFIT.Text = "PROFFIT ON THIS ADULT"
                TXTPERSONTYPE.Text = "ADULT"
            End If

            ''FOR GETTING PURCHASE FROM PURCHASE INVOICE

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" isnull(REG_INITIALS,'')", "", " REGISTRATIONMASTER", " and REG_NO = " & TEMPREGNO & " and REG_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                TEMPINITIALS = (dt.Rows(0).Item(0))

                Dim dt2 As DataTable = objclscommon.search(" ISNULL(SUM(BILL_AMT),0)", "", " PURCHASEINVOICE_DESC", " and BILL_REGNO = '" & TEMPINITIALS & "' and BILL_Yearid = " & YearId)
                If dt2.Rows.Count > 0 Then
                    For Each DTR As DataRow In dt2.Rows
                        TXTPURCHASETOTAL.Text = Val(TXTPURCHASETOTAL.Text.Trim) + DTR(0)
                    Next
                End If
            End If

            TXTSERVICECHGS.Text = Val(TXTSUBTOTAL.Text.Trim) - Val(TXTPURCHASETOTAL.Text.Trim)

            If CMBTAX.Text.Trim <> "" Then
                Dim dt1 As DataTable = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then TXTTAX.Text = Format((Val(dt1.Rows(0).Item("TAX")) * (Val(TXTSERVICECHGS.Text)) / 100), "0.00")
            End If

            TXTGRANDTOTAL.Text = Val(TXTSUBTOTAL.Text.Trim) + Val(TXTTAX.Text.Trim)



            'If Val(Age) <= 2 Then
            '    TXTGRANDTOTAL.Text = Val(TXTSALETOTALINFANT.Text.Trim)
            '    LBLTOTAL.Text = "INFANT GRAND TOTAL"
            '    TXTPROFFIT.Text = Val(TXTCUSTINFANT.Text.Trim) - Val(TXTPURPKGINFANT.Text.Trim)
            '    LBLPROFFIT.Text = "PROFFIT ON THIS INFANT"
            '    TXTPERSONTYPE.Text = "INFANT"
            'ElseIf Val(Age) <= 12 And Val(Age) > 2 Then
            '    TXTGRANDTOTAL.Text = Val(TXTSALETOTALCHILD.Text.Trim)
            '    LBLTOTAL.Text = "CHILD GRAND TOTAL"
            '    TXTPROFFIT.Text = Val(TXTCUSTCHILD.Text.Trim) - Val(TXTPURPKGCHILD.Text.Trim)
            '    LBLPROFFIT.Text = "PROFFIT ON THIS CHILD"
            '    TXTPERSONTYPE.Text = "CHILD"
            'ElseIf Val(Age) > 12 Then
            '    TXTGRANDTOTAL.Text = Val(TXTSALETOTALADULT.Text.Trim)
            '    LBLTOTAL.Text = "ADULT GRAND TOTAL"
            '    TXTPROFFIT.Text = Val(TXTCUSTADULT.Text.Trim) - Val(TXTPURPKGADULT.Text.Trim)
            '    LBLPROFFIT.Text = "PROFFIT ON THIS ADULT"
            '    TXTPERSONTYPE.Text = "ADULT"
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDREG.CellClick
        Try
            If e.ColumnIndex = gCHK.Index Then
                With GRIDREG.Rows(e.RowIndex).Cells(gCHK.Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True
                    End If
                End With
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbillno.Validating
        Try
            If txtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDREG.RowCount = 0
            TEMPREGNO = Val(txtbillno.Text)
            If TEMPREGNO > 0 Then
                edit = True
                RegistrationMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDREG.RowCount = 0
LINE1:
            TEMPREGNO = Val(TXTREGNO.Text) - 1
Line2:
            If TEMPREGNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" REG_NO ", "", "  REGISTRATIONMASTER ", " AND REGISTRATIONMASTER.REG_NO = '" & TEMPREGNO & "' AND REGISTRATIONMASTER.REG_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    RegistrationMaster_Load(sender, e)
                Else
                    TEMPREGNO = Val(TEMPREGNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDREG.RowCount = 0 And TEMPREGNO > 1 Then
                TXTREGNO.Text = TEMPREGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDREG.RowCount = 0
LINE1:
            TEMPREGNO = Val(TXTREGNO.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = TXTREGNO.Text.Trim
            clear()
            If Val(TXTREGNO.Text) - 1 >= TEMPREGNO Then
                edit = True
                RegistrationMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDREG.RowCount = 0 And TEMPREGNO < MAXNO Then
                TXTREGNO.Text = TEMPREGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSALENAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSALENAME.Enter
        Try
            If CMBSALENAME.Text.Trim = "" Then fillname(CMBSALENAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
    Private Sub CMBSALENAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSALENAME.Validating
        Try
            If CMBSALENAME.Text.Trim <> "" Then namevalidate(CMBSALENAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
            GETREGISTRATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOURNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOURNAME.Enter
        Try
            If CMBTOURNAME.Text.Trim = "" Then FILLTOURNAME(CMBTOURNAME, edit, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUEST.Enter
        Try
            If CMBGUEST.Text.Trim = "" Then FILLGUESTNAME(CMBGUEST, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHOF.Enter
        Try
            If CMBHOF.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND RegistrationMaster.REG_HOFID = GuestMaster.GUEST_ID ", " and (REGISTRATIONMASTER.REG_HOFCHK = 1) AND GUESTMASTER.GUEST_NAME='" & CMBGUEST.Text.Trim & "' AND GUEST_cmpid=" & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GUEST_name"
                    CMBHOF.DataSource = dt
                    CMBHOF.DisplayMember = "GUEST_name"
                End If
                CMBHOF.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUEST.Validating
        Try
            If CMBGUEST.Text.Trim <> "" And CMBTOURNAME.Text.Trim <> "" And edit = False Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GUEST_NAME ", "", " REGISTRATIONMASTER INNER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_GUESTID = GUESTMASTER.GUEST_ID AND REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID ", " and GUESTMASTER.GUEST_NAME='" & CMBGUEST.Text.Trim & "' AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPMSG = MsgBox("This Guest already registered ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbNo Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If

            If CMBGUEST.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUEST, e, Me, TXTADD)
            GUESTDETAIL()
            GETREGISTRATION()
            'DOB()
            GENRATEDOB()
            Dim Tempexpiry As Date = DateAdd(DateInterval.Month, 6, STARTDATE.Value.Date)
            If Tempexpiry.Date >= DTEXPIRY.Value.Date And CMBGUEST.Text <> "" Then
                TEMPMSG = MsgBox("Customer Passport has been expired ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                    If PASS <> "finasta" Then
                        MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                        CMBGUEST.Focus()
                        e.Cancel = True
                    End If
                Else
                    CMBGUEST.Focus()
                    e.Cancel = True
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GUESTDETAIL()
        Try
            If CMBGUEST.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GUEST_DOB,GUEST_EXPIRYDATE ", "", "  GUESTMASTER ", " and GUESTMASTER.GUEST_NAME='" & CMBGUEST.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    GUESTDOB.Value = dt.Rows(0).Item(0)
                    DTEXPIRY.Value = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHOF.Validated
        Try
            GETREGISTRATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHOF_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHOF.Validating
        Try
            If CMBGUEST.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUEST, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try
            If edit = True Then

                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" isnull(REG_INITIALS,'')", "", " REGISTRATIONMASTER", " and REG_NO = " & TEMPREGNO & " and REG_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPINITIALS = (dt.Rows(0).Item(0))

                    Dim dt2 As DataTable = objclscommon.search(" ISNULL(SUM(BILL_AMT),0)", "", " PURCHASEINVOICE_DESC LEFT OUTER JOIN CURRENCYMASTER ON PURCHASEINVOICE_DESC.BILL_YEARID = CURRENCYMASTER.cur_yearid AND PURCHASEINVOICE_DESC.BILL_CURRENCYID = CURRENCYMASTER.cur_id", " and BILL_REGNO = '" & TEMPINITIALS & "' and CURRENCYMASTER.CUR_CODE='INR' and (PURCHASEINVOICE_DESC.BILL_SERVICETYPE = 'Flight') and BILL_Yearid = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            TEMPFLIGHT = DTR(0)
                        Next
                    End If

                    Dim dt3 As DataTable = objclscommon.search(" ISNULL(SUM(BILL_AMT),0)", "", " PURCHASEINVOICE_DESC LEFT OUTER JOIN CURRENCYMASTER ON PURCHASEINVOICE_DESC.BILL_YEARID = CURRENCYMASTER.cur_yearid AND PURCHASEINVOICE_DESC.BILL_CURRENCYID = CURRENCYMASTER.cur_id", " and BILL_REGNO = '" & TEMPINITIALS & "' and CURRENCYMASTER.CUR_CODE<>'INR' and BILL_Yearid = " & YearId)
                    If dt3.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt3.Rows
                            TEMPFOREIGNEXCHNG = DTR(0)
                        Next
                    End If

                    Dim dt4 As DataTable = objclscommon.search(" ISNULL(SUM(BILL_AMT),0)", "", " PURCHASEINVOICE_DESC LEFT OUTER JOIN CURRENCYMASTER ON PURCHASEINVOICE_DESC.BILL_YEARID = CURRENCYMASTER.cur_yearid AND PURCHASEINVOICE_DESC.BILL_CURRENCYID = CURRENCYMASTER.cur_id", " and BILL_REGNO = '" & TEMPINITIALS & "' and CURRENCYMASTER.CUR_CODE='INR' and (PURCHASEINVOICE_DESC.BILL_SERVICETYPE <> 'Flight') and BILL_Yearid = " & YearId)
                    If dt4.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt4.Rows
                            TEMPSERVICECHGS = DTR(0)
                        Next
                    End If

                    Dim OBJINV As New TourDesign
                    OBJINV.strsearch = " {REGISTRATIONMASTER.REG_NO}=" & TEMPREGNO & " AND {REGISTRATIONMASTER.REG_YEARID}=" & YearId & ""
                    OBJINV.MdiParent = MDIMain
                    OBJINV.INWORDS = CurrencyToWord(TXTGRANDTOTAL.Text)
                    OBJINV.REGNO = TEMPREGNO
                    OBJINV.AIRTICKET = TEMPFLIGHT
                    OBJINV.FOREIGN = TEMPFOREIGNEXCHNG
                    OBJINV.SERVICECHGS = TEMPSERVICECHGS
                    OBJINV.FRMSTRING = "INVOICE"
                    OBJINV.Show()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUEST.Validated
        Try
            If CMBGUEST.Text.Trim <> "" And CHKHOF.Checked = True Then
                CMBHOF.Text = CMBGUEST.Text.Trim
                CMBSALENAME.Text = CMBGUEST.Text.Trim
                CMBSALENAME.Focus()
            ElseIf CMBGUEST.Text.Trim <> "" And CHKHOF.Checked = False Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT ISNULL(GUEST_name,'') AS GUEST_name ", "", "  REGISTRATIONMASTER LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND RegistrationMaster.REG_HOFID = GuestMaster.GUEST_ID ", " and (REGISTRATIONMASTER.REG_HOFCHK = 1) AND GUEST_cmpid=" & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GUEST_name"
                    CMBHOF.DataSource = dt
                    CMBHOF.DisplayMember = "GUEST_name"
                End If
                CMBHOF.SelectAll()
                CMBSALENAME.Text = CMBGUEST.Text.Trim
                If hof <> "" Then
                    CMBHOF.Text = hof
                End If
                If Salename <> "" Then
                    CMBSALENAME.Text = Salename
                End If
                CMBSALENAME.Focus()
            End If
            If CMBGUEST.Text.Trim <> "" Then total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKHOF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKHOF.CheckedChanged
        Try
            If CHKHOF.Checked = False Then
                CMBHOF.Text = ""
                CMBHOF.Enabled = True

                If CMBGUEST.Text.Trim <> "" Then

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search(" GUEST_name ", "", "  REGISTRATIONMASTER INNER JOIN TOURMASTER ON REGISTRATIONMASTER.REG_TOURID = TOURMASTER.TOUR_NO AND REGISTRATIONMASTER.REG_YEARID = TOURMASTER.TOUR_YEARID LEFT OUTER JOIN GUESTMASTER ON REGISTRATIONMASTER.REG_YEARID = GUESTMASTER.GUEST_YEARID AND REGISTRATIONMASTER.REG_HOFID = GUESTMASTER.GUEST_ID", " AND (REGISTRATIONMASTER.REG_HOFCHK = 1) AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' AND GUEST_cmpid=" & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        dt.DefaultView.Sort = "GUEST_name"
                        CMBHOF.DataSource = dt
                        CMBHOF.DisplayMember = "GUEST_name"
                    End If
                    CMBHOF.SelectAll()
                End If
                CMBSALENAME.Text = CMBGUEST.Text.Trim
                CMBSALENAME.Focus()
            Else
                CMBHOF.Text = CMBGUEST.Text.Trim
                CMBSALENAME.Text = CMBHOF.Text.Trim
                CMBSALENAME.Focus()
                CMBHOF.Enabled = False
                GETREGISTRATION()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREG_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDREG.CellValidating
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUSTADULT.Validating
        Try
            If Val(TXTCUSTADULT.Text.Trim) < Val(TXTPURPKGADULT.Text.Trim) Then
                TEMPMSG = MsgBox("You Have Enter Less Than Package Amt ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                    If PASS <> "finasta" Then
                        MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                        TXTCUSTADULT.Focus()
                        e.Cancel = True
                    End If
                Else
                    TXTCUSTADULT.Focus()
                    e.Cancel = True
                End If
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTCHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUSTCHILD.Validating
        Try
            If Val(TXTCUSTCHILD.Text.Trim) < Val(TXTPURPKGCHILD.Text.Trim) Then
                If Val(TXTCUSTADULT.Text.Trim) < Val(TXTPURPKGADULT.Text.Trim) Then
                    TEMPMSG = MsgBox("You Have Enter Less Than Package Amt ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                        If PASS <> "finasta" Then
                            MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                            TXTCUSTCHILD.Focus()
                            e.Cancel = True
                        End If
                    Else
                        TXTCUSTCHILD.Focus()
                        e.Cancel = True
                    End If
                End If
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUSTINFANT.Validating
        Try
            If Val(TXTCUSTINFANT.Text.Trim) < Val(TXTPURPKGINFANT.Text.Trim) Then
                If Val(TXTCUSTADULT.Text.Trim) < Val(TXTPURPKGADULT.Text.Trim) Then
                    TEMPMSG = MsgBox("You Have Enter Less Than Package Amt ! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                        If PASS <> "finasta" Then
                            MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                            TXTCUSTINFANT.Focus()
                            e.Cancel = True
                        End If
                    Else
                        TXTCUSTINFANT.Focus()
                        e.Cancel = True
                    End If
                End If
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUSTADULT.KeyPress
        Try
            numdotkeypress(e, TXTCUSTADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTCHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUSTCHILD.KeyPress
        Try
            numdotkeypress(e, TXTCUSTCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUSTINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUSTINFANT.KeyPress
        Try
            numdotkeypress(e, TXTCUSTINFANT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENRATEDOB()
        Try
            Dim dateDifference As New DateDifference(STARTDATE.Value, GUESTDOB.Value)
            TXTDOB.Text = dateDifference.ToString()
            Age = dateDifference.Years
            Dim MONTHS As Integer = dateDifference.Months
            Dim DAYS As Integer = dateDifference.Days
            If Age = 2 And (MONTHS > 0 Or DAYS > 0) Then Age = 3
            If Age = 12 And (MONTHS > 0 Or DAYS > 0) Then Age = 13
            'total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub DOB()
    '    Try
    '        Age = STARTDATE.Value.Date.Year - GUESTDOB.Value.Date.Year
    '        Dim YEARS As Integer = STARTDATE.Value.Date.Year - GUESTDOB.Value.Date.Year
    '        Dim MONTHS As Integer = STARTDATE.Value.Date.Month - GUESTDOB.Value.Date.Month
    '        Dim DAYS As Integer = STARTDATE.Value.Date.Day - GUESTDOB.Value.Date.Day

    '        If Val(MONTHS) < 0 Then
    '            YEARS = Val(YEARS) + Val(MONTHS)
    '            MONTHS = 12 + Val(MONTHS)
    '        End If

    '        If Val(MONTHS) = 0 And DAYS < 0 Then
    '            YEARS = Val(YEARS) - 1
    '            MONTHS = 12 - 1
    '        End If

    '        If Val(DAYS) < 0 Then
    '            MONTHS = MONTHS - 1
    '        End If

    '        'If Val(DAYS) > 0 And Val(MONTHS) = 0 Then
    '        '    YEARS = YEARS - 1
    '        'End If

    '        Dim CurrentMonthDays As Integer = DateTime.DaysInMonth(STARTDATE.Value.Year, STARTDATE.Value.Month)

    '        If Val(DAYS) < 0 Then
    '            DAYS = Val(CurrentMonthDays) + Val(DAYS)
    '        End If


    '        'TXTDOB.Text = (STARTDATE.Value.Year - GUESTDOB.Value.Year).ToString & "Years-" & (STARTDATE.Value.Month - GUESTDOB.Value.Month).ToString() & "Month-" & (STARTDATE.Value.Day - GUESTDOB.Value.Day).ToString() & "Days"
    '        TXTDOB.Text = YEARS & "Years-" & MONTHS & "Month-" & DAYS & "Days"
    '        Age = YEARS
    '        If Age = 2 And (MONTHS > 0 Or DAYS > 0) Then Age = 3
    '        If Age = 12 And (MONTHS > 0 Or DAYS > 0) Then Age = 13
    '        total()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub GUESTDOB_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GUESTDOB.Validating
        Try
            Dim myCoolBirthday As Date = GUESTDOB.Value.Date
            Dim currentDate As Date = STARTDATE.Value.Date
            Age = currentDate.Year - myCoolBirthday.Year
            TXTDOB.Clear()

            Dim Ageyear, AgeMonth As Integer
            Dim Agedate As Integer
            Ageyear = STARTDATE.Value.Year - GUESTDOB.Value.Year
            TXTDOB.Text = Ageyear.ToString() & "Years-"

            AgeMonth = STARTDATE.Value.Month - GUESTDOB.Value.Month
            TXTDOB.Text = TXTDOB.Text.Trim & AgeMonth.ToString() & "Month-"

            Agedate = (STARTDATE.Value.Day - GUESTDOB.Value.Day)
            TXTDOB.Text = TXTDOB.Text.Trim & Agedate.ToString() & "Days"

            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objreg As New RegistrationDetails
            objreg.MdiParent = MDIMain
            objreg.Show()
            objreg.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBTOURNAME.Text.Trim = "" Then
                MsgBox("Please Select Tour First", MsgBoxStyle.Critical)
                CMBTOURNAME.Focus()
                Exit Sub
            End If

            Dim DTGDN As New DataTable
            Dim OBJSELECTGDN As New SelectGift
            OBJSELECTGDN.TOURNAME = CMBTOURNAME.Text.Trim

            OBJSELECTGDN.ShowDialog()
            DTGDN = OBJSELECTGDN.DT
            If DTGDN.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTGDN.Rows
                    GRIDBILL.Rows.Add(0, DTROWPS("GIFTNAME"), 1, DTROWPS("RATE"))
                Next
                getsrno(GRIDBILL)
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBILL.RowCount > 0 Then
                GRIDBILL.Rows.RemoveAt(GRIDBILL.CurrentRow.Index)
                total()
                getsrno(GRIDBILL)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RegistrationMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "FINASTA" Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub CMBTOURNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOURNAME.Validating
        Try
            If CMBTOURNAME.Text <> "" And edit = False Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOURMASTER.TOUR_GRPSTRENGTH AS STRENGTH, TOURMASTER.TOUR_DAYS AS DAYS, TOURMASTER.TOUR_CUTOFDATE AS CUTOFDATE,TOURMASTER.TOUR_STARTDATE AS STARTDATE, TOURMASTER.TOUR_ENDDATE AS ENDDATE, ISNULL(TOURMASTER.TOUR_PKGADULT, 0) AS PURPKGADULT, ISNULL(TOURMASTER.TOUR_PKGCHILD, 0) AS PURPKGCHILD, ISNULL(TOURMASTER.TOUR_PKGINFANT, 0) AS PURPKGINFANT, ISNULL(TOURMASTER.TOUR_FADULTTOTAL, 0) AS ADDADULT, ISNULL(TOURMASTER.TOUR_FCHILDTOTAL, 0) AS ADDCHILD, ISNULL(TOURMASTER.TOUR_FINFANTTOTAL, 0) AS ADDINFANT, ISNULL(TOURMASTER.TOUR_DECPKGADULT, 0) AS SALEPKGADULT, ISNULL(TOURMASTER.TOUR_DECPKGCHILD, 0) AS SALEPKGCHILD, ISNULL(TOURMASTER.TOUR_DECPKGINFANT, 0) AS SALEPKGINFANT, ISNULL(TOUR_ADDSERVICES.TOUR_GRIDSRNO, 0) AS SRNO, ISNULL(SERVICEMASTER.SERVICE_name, '') AS SERVICE, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_ADDSERVICES.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_ADDSERVICES.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_ADDSERVICES.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_ADDSERVICES.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_ADDSERVICES.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_ADDSERVICES.TOUR_INFANTINR, 0) AS INFANTINR  ", "", " CURRENCYMASTER RIGHT OUTER JOIN TOUR_ADDSERVICES ON CURRENCYMASTER.cur_yearid = TOUR_ADDSERVICES.TOUR_yearid AND CURRENCYMASTER.cur_id = TOUR_ADDSERVICES.TOUR_CURRENCYID LEFT OUTER JOIN SERVICEMASTER ON TOUR_ADDSERVICES.TOUR_ADDSERVICEID = SERVICEMASTER.SERVICE_id AND TOUR_ADDSERVICES.TOUR_yearid = SERVICEMASTER.SERVICE_yearid RIGHT OUTER JOIN TOURMASTER ON TOUR_ADDSERVICES.TOUR_yearid = TOURMASTER.TOUR_YEARID AND TOUR_ADDSERVICES.TOUR_NO = TOURMASTER.TOUR_NO ", " AND TOURMASTER.TOUR_NAME ='" & CMBTOURNAME.Text.Trim & "' AND TOURMASTER.TOUR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    For Each dr As DataRow In DT.Rows

                        If Mydate > Convert.ToDateTime(dr("CUTOFDATE")).Date Then
                            TEMPMSG = MsgBox("Cut Of Date is " & Convert.ToDateTime(dr("CUTOFDATE")).Date & " ! Do You Want to Proceed for Registration ?", MsgBoxStyle.YesNo)
                            If TEMPMSG = vbYes Then
                                Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                                If PASS <> "finasta" Then
                                    MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                                    CMBTOURNAME.Focus()
                                    CMBTOURNAME.Enabled = True
                                    Exit Sub
                                    e.Cancel = True

                                End If
                            Else
                                CMBTOURNAME.Focus()
                                CMBTOURNAME.Enabled = True
                                Exit Sub
                                e.Cancel = True
                            End If
                        End If

                        TXTGRPSTRENGTH.Text = dr("STRENGTH")
                        CMBTOURNAME.Enabled = False
                        Dim dt1 As DataTable = OBJCMN.search(" ISNULL(TOURMASTER.TOUR_NAME,'')", "", "  TOURMASTER INNER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID AND TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID", " AND TOURMASTER.TOUR_NAME='" & CMBTOURNAME.Text.Trim & "' AND REGISTRATIONMASTER.REG_PERSONTYPE<>'INFANT' AND TOURMASTER.TOUR_YEARID=" & YearId & "")
                        If dt1.Rows.Count <= Val(TXTGRPSTRENGTH.Text.Trim) Then
                            TXTBALSEATS.Text = Val(TXTGRPSTRENGTH.Text.Trim) - dt1.Rows.Count
                        Else
                            MsgBox(" Group Strength Completed !", MsgBoxStyle.Critical)
                            'e.Cancel = True
                            'CMBTOURNAME.Enabled = True
                            'CMBTOURNAME.Focus()
                            'Exit Sub
                        End If



                        STARTDATE.Value = Convert.ToDateTime(dr("STARTDATE")).Date
                        ENDDATE.Value = Convert.ToDateTime(dr("ENDDATE")).Date

                        TXTPURPKGADULT.Text = dr("PURPKGADULT")
                        TXTPURPKGCHILD.Text = dr("PURPKGCHILD")
                        TXTPURPKGINFANT.Text = dr("PURPKGINFANT")

                        TXTPURADDADULT.Text = dr("ADDADULT")
                        TXTPURADDCHILD.Text = dr("ADDCHILD")
                        TXTPURADDINFANT.Text = dr("ADDINFANT")

                        TXTSALEPKGADULT.Text = dr("SALEPKGADULT")
                        TXTSALEPKGCHILD.Text = dr("SALEPKGCHILD")
                        TXTSALEPKGINFANT.Text = dr("SALEPKGINFANT")

                        TXTCUSTADULT.Text = dr("SALEPKGADULT")
                        TXTCUSTCHILD.Text = dr("SALEPKGCHILD")
                        TXTCUSTINFANT.Text = dr("SALEPKGINFANT")

                        GRIDREG.Rows.Add(0, dr("SRNO").ToString, dr("SERVICE"), dr("CURRENCY"), Format(Val(dr("ADULT")), "0.00"), Format(Val(dr("ADULTINR")), "0.00"), Format(Val(dr("CHILD")), "0.00"), Format(Val(dr("CHILDINR")), "0.00"), Format(Val(dr("INFANT")), "0.00"), Format(Val(dr("INFANTINR")), "0.00"))
                    Next
                    GRIDREG.FirstDisplayedScrollingRowIndex = GRIDREG.RowCount - 1
                    total()
                    GETREGISTRATION()
                Else

                    clear()
                    edit = False
                    CMBTOURNAME.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBTAX_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTAX.Enter
        Try
            If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTAX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTAX.Validating
        Try
            If CMBTAX.Text.Trim <> "" Then TAXvalidate(CMBTAX, e, Me)
            total()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTTAX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTAX.Validating
        total()

    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            PRINTREPORT(TEMPREGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = "TRS-" & TEMPREGNO
            OBJRECPAY.SALEBILLINITIALS = "TRS-" & TEMPREGNO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try

            If PBRECD.Visible = True Then
                MsgBox("Rec made, Delete Rec First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Credit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.BILLNO = "TRS-" & TXTREGNO.Text.Trim
                    OBJCN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class