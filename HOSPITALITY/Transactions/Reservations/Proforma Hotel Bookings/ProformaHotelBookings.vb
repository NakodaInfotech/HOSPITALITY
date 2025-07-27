
Imports System.ComponentModel
Imports System.IO
Imports BL

Public Class ProformaHotelBookings
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean, DIRECTUPLOAD As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Dim TEMPMSG As Integer
    Public Shared dt_amd As New DataTable
    Public FRMSTRING As String = "BOOKING"
    Public Shared SELECTENQ As New DataTable
    Dim DDATE As DateTime

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As DataTable = getmax(" isnull(max(BOOKING_no),0) + 1 ", "PROFORMAHOTELBOOKINGMASTER", " and BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND BOOKING_cmpid=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then txtbookingno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try
            DIRECTUPLOAD = False
            If ClientName = "TOPCOMM" Then
                LBLOTHERCHGS.Text = "Our Service Chg"
                TabControl1.TabPages(0).Text = "Payment"
            End If

            If ClientName = "SKYMAPS" Or ClientName = "BARODA" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                txtbookingno.ReadOnly = False
                txtbookingno.Enabled = True
            Else
                txtbookingno.Enabled = True
                txtbookingno.ReadOnly = True
            End If
            CMBROOMTYPE.Text = ""
            TXTENQNO.Clear()
            LBLPURBAL.ForeColor = Color.Green
            LBLACCBAL.ForeColor = Color.Green
            CMBPREFIX.Text = ""
            TXTCOPY.Clear()
            TXTTEMPNIGHTS.Clear()
            tstxtbillno.Clear()
            CMBGUESTNAME.Text = ""
            txtmobileno.Clear()
            txtemailadd.Clear()
            txtrefno.Clear()
            CMBBOOKINGTYPE.SelectedIndex = 0
            cmbhotelcode.Text = ""
            cmbhotelname.Text = ""
            CMBNAME.Text = ""
            CMBACCCODE.Text = ""
            CMBPURCODE.Text = ""
            CMBPURNAME.Text = ""
            LBLACCBAL.Text = 0.0
            LBLPURBAL.Text = 0.0


            txthoteladd.Clear()
            TXTADD.Clear()
            TXTGUESTADD.Clear()

            BOOKINGDATE.Text = Mydate
            ARRIVALDATE.Value = Mydate
            DEPARTDATE.Value = Mydate.Date.AddDays(1)

            CMBARRFROM.Text = ""
            CMBDEPARTTO.Text = ""
            txtcheckin.Text = "12:00"
            txtcheckout.Text = "12:00"

            TXTARRFLIGHTNO.Clear()
            TXTDEPARTFLIGHTNO.Clear()
            TXTSALEMOBILE.Clear()
            CMBCANCEL.Text = ""

            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBDN.Visible = False
            PBCN.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblamd.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False
            btnselectpo.Enabled = True

            txttax.ReadOnly = True

            TXTPURTAX.ReadOnly = True
            TXTPURTAX.Enabled = False
            TXTPURADDTAX.ReadOnly = True
            TXTPURADDTAX.Enabled = False

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
            GRIDPUR.RowCount = 0
            GRIDBOOKINGS.ClearSelection()

            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            gridupload.RowCount = 0
            txtimgpath.Clear()
            TXTNEWIMGPATH.Clear()
            TXTFILENAME.Clear()
            PBSoftCopy.ImageLocation = ""
            gridupload.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            TXTTOTALCHILDS.Clear()
            TXTTOTALADULTS.Clear()
            TXTTOTALNCCHILDS.Clear()
            TXTTOTALEXTRAADULTS.Clear()
            TXTTOTALEXTRACHILDS.Clear()
            TXTTOTALROOMS.Clear()
            TXTTOTALAMT.Text = 0.0

            TXTPURAMT.Text = 0.0
            TXTTOTALPURAMT.Text = 0.0
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTPURSUBTOTAL.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTPUREXTRACHGS.Text = 0.0
            TXTPURNETTAMT.Text = 0.0

            TXTPURTAX.Text = 0.0
            CMBPURADDTAX.Text = ""
            TXTPURADDTAX.Text = 0.0
            CMBPURADDSUB.SelectedIndex = 0
            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0

            TXTTOTALSALEAMT.Text = 0.0

            'THIS FIELD IS SPECIALLY FOR CLASSIC
            TXTOURCOMM.Text = 0.0

            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TXTEXTRACHGS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            cmbtax.Text = ""
            txttax.Text = 0.0
            CMBADDTAX.Text = ""
            TXTADDTAX.Text = 0.0
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0
            TXTBAL.Text = 0.0


            TXTTOTALPAX.Clear()
            TXTTOTALNIGHTS.Text = 1

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            CMBAGENTNAME.Text = ""
            TXTAGENTCOMMPER.Text = 0.0
            TXTAGENTCOMMRS.Text = 0.0
            TXTAGENTTDSPER.Text = 0.0
            TXTAGENTTDSRS.Text = 0.0

            If ClientName = "CLASSIC" Then
                txtremarks.Text = "Room bill to " & CmpName & " & Extra or Direct Payment if any, payment to be collected directly from Guest."
            ElseIf ClientName = "TOPCOMM" Then
                txtremarks.Clear()
            ElseIf ClientName = "TRISHA" Then
                txtremarks.Text = "Bill to " & CmpName & " & all Extras direct."
            Else
                txtremarks.Text = "As per Standard Rates billed to " & CmpName & " & Extra if any, payment to be collected direct from Guest."
            End If

            If ClientName = "BELLA" Then TXTBOOKINGDESC.Text = "? This booking is under cancellation." & vbNewLine & "? No Show will be charged at 100 % of the total booking." & vbNewLine & "? Early checkout will be charged at 100 % of the total booked period." & vbNewLine & "? Name change /Date change will be treated as a cancellation if falling within the cancellation period." Else TXTBOOKINGDESC.Clear()
            TXTSPECIALREMARKS.Clear()
            TXTPICKUP.Clear()

            txtinwords.Clear()
            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked
            CHKREFUNDED.CheckState = CheckState.Unchecked
            CHKFAILED.CheckState = CheckState.Unchecked
            CHKREVERSE.CheckState = CheckState.Unchecked
            CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
            TXTCONFIRMEDBY.Clear()
            TXTCONFIRMATIONNO.Clear()

            CMBCANCEL.Text = ""
            CMBNOTES.Text = ""
            TXTNOTES.Clear()
            TXTPOLICY.Clear()

            TXTDP.Clear()

            TXTBOOKING_AMD.Clear()
            TXTAMDNO.Clear()
            txtpapa.Clear()
            TXTAMDREMARKS.Clear()

            CMBPURTAX.Text = ""
            CMBPUROTHERCHGS.Text = ""


            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()
            gridDoubleClick = False
            getmax_BOOKING_no()
            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            TXTSTATECODE.Clear()
            TXTHSNCODE.Clear()
            TXTPURHSNCODE.Clear()
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTCESSPER.Text = 1
            TXTCESSAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURSGSTPER.Text = 0.0
            TXTPURSGSTAMT.Text = 0.0
            TXTPURIGSTPER.Text = 0.0
            TXTPURIGSTAMT.Text = 0.0
            TXTPURCESSPER.Text = 1
            TXTPURCESSAMT.Text = 0.0
            TXTPURCOMMPER.Text = 0.0
            CHKPURSERVTAX.CheckState = CheckState.Unchecked
            TXTPURSTATECODE.Clear()
            CHKPURMANUAL.CheckState = CheckState.Unchecked
            CHKMANUAL.CheckState = CheckState.Unchecked

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        CMBGUESTNAME.Focus()
    End Sub

    Private Sub HotelBookings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripprint_Click(sender, e)
            ElseIf e.KeyCode = Keys.D And e.Alt = True Then
                Call CMDDELETE_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New HotelBookingsDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub HotelBookings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname, "")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBARRFROM.Text.Trim = "" Then fillcity(CMBARRFROM)
            If CMBDEPARTTO.Text.Trim = "" Then fillcity(CMBDEPARTTO)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, edit)


            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If

            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURITEMDESC)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub HotelBookings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DOMESTIC RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            'RECOMMENDED BY ASHOK BHAI
            If UserName <> "Admin" And ClientName = "CLASSIC" Then LBLPURBAL.Visible = False


            Cursor.Current = Cursors.WaitCursor
            clear()

            fillcmb()
            If edit = True Then


                chkmobile.CheckState = CheckState.Unchecked
                CHKEMAIL.CheckState = CheckState.Unchecked

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsProformaHotelBookingMaster()

                ALPARAVAL.Add(FRMSTRING)
                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTUSERPOINTS.Text = Val(dr("USERPOINTS"))
                        TXTREFPOINTS.Text = Val(dr("REFPOINTS"))

                        txtbookingno.ReadOnly = True
                        txtbookingno.Enabled = False
                        txtbookingno.Text = TEMPBOOKINGNO
                        TXTENQNO.Text = dr("ENQNO")
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTPURSTATECODE.Text = dr("PURSTATECODE")
                        CMBHSNITEMDESC.Text = dr("ITEMDESC")
                        CMBPURITEMDESC.Text = dr("PURITEMDESC")

                        BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                        DDATE = BOOKINGDATE.Text
                        CHKBOOKINGDATE.Checked = Convert.ToBoolean(dr("ENTRYDATEASBOOKINGDATE"))
                        CMBBOOKINGTYPE.Text = dr("BOOKINGTYPE")
                        CMBGUESTNAME.Text = dr("GUESTNAME")
                        CMBPREFIX.Text = dr("PREFIX")
                        txtmobileno.Text = dr("MOBILENO")
                        txtemailadd.Text = dr("EMAILADD")
                        TXTGUESTADD.Text = dr("GUESTADD")
                        txthoteladd.Text = dr("HOTELADD")
                        TXTPURADD.Text = dr("PURADD")
                        TXTADD.Text = dr("SALEADD")
                        txtrefno.Text = dr("REFNO")
                        cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                        cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                        FILLROOMTYPE()


                        CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                        CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))

                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                        ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                        DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                        CMBARRFROM.Text = Convert.ToString(dr("ARRFROM"))
                        CMBDEPARTTO.Text = Convert.ToString(dr("DEPARTTO"))

                        txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                        txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))

                        TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                        TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))


                        'PURCHASE VALUES
                        TXTPURAMT.Text = dr("PURAMT")
                        TXTDISCRECDPER.Text = dr("DISCRECDPER")
                        TXTDISCRECDRS.Text = dr("DISCRECDRS")
                        TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                        TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                        TXTPURTDSPER.Text = dr("PURTDSPER")
                        TXTPURTDSRS.Text = dr("PURTDSRS")
                        TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                        CMBPURTAX.Text = dr("PURTAXNAME")
                        TXTPURTAX.Text = dr("PURTAX")

                        CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                        TXTPURADDTAX.Text = dr("PURADDTAX")

                        CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                        If dr("PUROTHERCHGS") > 0 Then
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                            CMBPURADDSUB.Text = "Add"
                        Else
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                            CMBPURADDSUB.Text = "Sub."
                        End If

                        TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                        TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        CMBAGENTNAME.Text = dr("AGENTNAME")

                        TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                        TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                        TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                        TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")

                        TXTDISCPER.Text = dr("DISCPER")
                        TXTDISCRS.Text = dr("DISCRS")
                        TXTEXTRACHGS.Text = dr("EXTRACHGS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")

                        CMBADDTAX.Text = dr("ADDTAXNAME")
                        TXTADDTAX.Text = dr("ADDTAXAMT")


                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))


                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtroundoff.Text = dr("ROUNDOFF")
                        TXTDP.Text = dr("DP")

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))

                        TXTPURAMTPAID.Text = dr("PURAMTPAID")
                        TXTPUREXTRAAMT.Text = dr("PUREXTRAAMT")
                        TXTPURRETURN.Text = dr("PURRETURN")
                        TXTPURBAL.Text = dr("PURBAL")


                        TXTSALEAMTREC.Text = dr("SALEAMTREC")
                        TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                        TXTSALERETURN.Text = dr("SALERETURN")
                        TXTSALEBAL.Text = dr("SALEBAL")

                        TXTBAL.Text = Format(Val(TXTSALEBAL.Text), "0.00")


                        If Val(dr("PURAMTPAID")) > 0 Or Val(dr("PUREXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("PURRETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        If Val(dr("SALEAMTREC")) > 0 Or Val(dr("SALEEXTRAAMT")) > 0 Then
                            PBRECD.Visible = True
                            cmdshowdetails.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("SALERETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If



                        txtremarks.Text = dr("REMARKS")
                        TXTBOOKINGDESC.Text = dr("BOOKINGDESC")
                        TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                        TXTPICKUP.Text = dr("PICKUPDETAILS")


                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If dr("COMMINVRAISED").ToString = True Then
                            LBLCOMMISSION.Visible = True
                            'PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("CANCELLED")) = True Then
                            lblcancelled.Visible = True
                            PBCancelled.Visible = True
                        End If

                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                        CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                        CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))
                        TXTCONFIRMEDBY.Text = dr("CONFIRMEDBY")
                        TXTCONFIRMATIONNO.Text = dr("CONFIRMATIONNO")

                        CMBCANCEL.Text = dr("POLICYNAME")
                        TXTPOLICY.Text = dr("POLICY")
                        CMBNOTES.Text = dr("NOTESNAME")
                        TXTNOTES.Text = dr("NOTES")

                        TXTHSNCODE.Text = dr("HSNCODE")
                        TXTPURHSNCODE.Text = dr("PURHSNCODE")
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")
                        TXTCESSPER.Text = dr("CESSPER")
                        TXTCESSAMT.Text = dr("CESSAMT")

                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")

                        End If

                        CHKPURSERVTAX.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                        TXTPURCOMMPER.Text = dr("PUROURCOMMPER")
                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True


                        TXTPURCGSTPER.Text = dr("PURCGSTPER")
                        TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                        TXTPURSGSTPER.Text = dr("PURSGSTPER")
                        TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                        TXTPURIGSTPER.Text = dr("PURIGSTPER")
                        TXTPURIGSTAMT.Text = dr("PURIGSTAMT")
                        TXTPURCESSPER.Text = dr("PURCESSPER")
                        TXTPURCESSAMT.Text = dr("PURCESSAMT")

                        If CHKPURMANUAL.Checked = True Then
                            TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                            TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                            TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                        End If


                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), dr("CURCODE"), Format(dr("ROE"), "0.00"), Format(dr("amt"), "0.00"))

                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                    'GET GRIDPUR DATA
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search("  PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ADULTS AS ADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CHILDS AS CHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NCCHILDS AS NCCHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTS AS EXTRAADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTRATE AS EXTRAADULTRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILD AS EXTRACHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILDRATE AS EXTRACHILDRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NOOFROOMS AS NOOFROOMS, CASE WHEN BOOKING_PACKAGE = 'TRUE' THEN 'Yes' ELSE 'No' END AS PACKAGE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_RATE AS RATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT", "", " PROFORMAHOTELBOOKINGMASTER INNER JOIN PROFORMAHOTELBOOKINGMASTER_PURDESC ON PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NO AND PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_BOOKTYPE AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID INNER JOIN ROOMTYPEMASTER ON PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DR As DataRow In dttable.Rows
                            GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("ROOMTYPE").ToString, DR("ADULTS").ToString, DR("CHILDS").ToString, DR("NCCHILDS").ToString, DR("EXTRAADULTS"), Format(DR("EXTRAADULTRATE"), "0.00"), DR("EXTRACHILDS"), Format(DR("EXTRACHILDRATE"), "0.00"), DR("NOOFROOMS").ToString, DR("PACKAGE"), Format(DR("RATE"), "0.00"), Format(DR("amt"), "0.00"))
                        Next
                    End If


                    ' Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH", "", " PROFORMAHOTELBOOKINGMASTER_UPLOAD", " AND PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY PROFORMAHOTELBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR2 As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR2("GRIDSRNO"), DTR2("REMARKS"), DTR2("NAME"), DTR2("IMGPATH"), DTR2("NEWIMGPATH"))
                        Next
                    End If
                    PURCHASETOTAL()

                End If
                chkchange.CheckState = CheckState.Checked

            Else
                clear()
                edit = False
                CMBGUESTNAME.Focus()
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

            alParaval.Add("BOOKING")

            If FRMSTRING = "BOOKING" Then
                alParaval.Add("PURCHASE REGISTER")
                alParaval.Add("SALE REGISTER")
            End If

            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CHKBOOKINGDATE.CheckState)
            alParaval.Add(CMBBOOKINGTYPE.Text.Trim)
            alParaval.Add(CMBGUESTNAME.Text.Trim)
            alParaval.Add(TXTGUESTADD.Text.Trim)
            alParaval.Add(cmbhotelname.Text.Trim)
            alParaval.Add(CMBPURNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)

            alParaval.Add(ARRIVALDATE.Value.Date)
            alParaval.Add(DEPARTDATE.Value.Date)
            alParaval.Add(CMBARRFROM.Text.Trim)
            alParaval.Add(CMBDEPARTTO.Text.Trim)
            alParaval.Add(txtcheckin.Text.Trim)
            alParaval.Add(txtcheckout.Text.Trim)
            alParaval.Add(TXTARRFLIGHTNO.Text.Trim)
            alParaval.Add(TXTDEPARTFLIGHTNO.Text.Trim)

            alParaval.Add(Val(TXTTOTALADULTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALCHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALNCCHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALEXTRAADULTS.Text.Trim))
            alParaval.Add(Val(TXTTOTALEXTRACHILDS.Text.Trim))
            alParaval.Add(Val(TXTTOTALROOMS.Text.Trim))
            alParaval.Add(Val(TXTTOTALAMT.Text.Trim))

            'PURCHASE VALUES
            alParaval.Add(Val(TXTPURAMT.Text.Trim))

            'ADD PURCHASE AMT + EXTRAADULT AMT + EXTRACHILD AMT + PUREXTRACHGS
            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim) + Val(TXTPURTOTALADULT.Text.Trim) + Val(TXTPURTOTALCHILD.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURSUBTOTAL.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDPER.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURTDSPER.Text.Trim))
            alParaval.Add(Val(TXTPURTDSRS.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTPURNETTAMT.Text.Trim))
            alParaval.Add(CMBPURTAX.Text.Trim)
            alParaval.Add(Val(TXTPURTAX.Text.Trim))
            alParaval.Add(CMBPURADDTAX.Text.Trim)
            alParaval.Add(Val(TXTPURADDTAX.Text.Trim))

            alParaval.Add(CMBPUROTHERCHGS.Text.Trim)
            If CMBPURADDSUB.Text.Trim = "Add" Then
                alParaval.Add(Val(TXTPUROTHERCHGS.Text.Trim))
            ElseIf CMBPURADDSUB.Text.Trim = "Sub." Then
                alParaval.Add(Val((TXTPUROTHERCHGS.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTPURROUNDOFF.Text.Trim))
            alParaval.Add(Val(TXTPURGTOTAL.Text.Trim))

            alParaval.Add(Val(TXTTOTALPAX.Text.Trim))
            alParaval.Add(Val(TXTTOTALNIGHTS.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)

            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(CMBAGENTNAME.Text.Trim)
            alParaval.Add(Val(TXTAGENTCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTAGENTCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTAGENTTDSPER.Text.Trim))
            alParaval.Add(Val(TXTAGENTTDSRS.Text.Trim))


            'SALE VALUES
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMRS.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))




            alParaval.Add(CMBADDTAX.Text.Trim)
            alParaval.Add(Val(TXTADDTAX.Text.Trim))

            alParaval.Add(CHKTAXSERVCHGS.CheckState)

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

            alParaval.Add(txtremarks.Text.Trim)


            alParaval.Add(TXTBOOKINGDESC.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            alParaval.Add(TXTPICKUP.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(Val(TXTDP.Text.Trim))

            alParaval.Add(Val(TXTPURAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTPURRETURN.Text.Trim))
            alParaval.Add(Val(TXTPURBAL.Text.Trim))
            alParaval.Add(Val(TXTSALEAMTREC.Text.Trim))
            alParaval.Add(Val(TXTSALEEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTSALERETURN.Text.Trim))
            alParaval.Add(Val(TXTSALEBAL.Text.Trim))

            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTUSERPOINTS.Text.Trim))
            alParaval.Add(Val(TXTREFPOINTS.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            'BOOKING_GRID
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

                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value
                        ROOMTYPE = ROOMTYPE & "|" & row.Cells(groomtype.Index).Value

                        If row.Cells(gac.Index).Value.ToString = "Yes" Then
                            AC = AC & "|" & 1
                        Else
                            AC = AC & "|" & 0
                        End If

                        PLAN = PLAN & "|" & row.Cells(gplan.Index).Value.ToString
                        ADULT = ADULT & "|" & row.Cells(gadults.Index).Value.ToString
                        CHILD = CHILD & "|" & row.Cells(gchilds.Index).Value.ToString
                        NCCHILD = NCCHILD & "|" & row.Cells(gncchilds.Index).Value.ToString
                        EXTRAADULT = EXTRAADULT & "|" & row.Cells(GEXTRAADULT.Index).Value.ToString
                        ADULTRATE = ADULTRATE & "|" & row.Cells(GEXTRAADULTRATE.Index).Value.ToString
                        EXTRACHILD = EXTRACHILD & "|" & row.Cells(GEXTRACHILD.Index).Value.ToString
                        CHILDRATE = CHILDRATE & "|" & row.Cells(GEXTRACHILDRATE.Index).Value.ToString
                        NOOFROOMS = NOOFROOMS & "|" & row.Cells(gnoofRooms.Index).Value.ToString
                        GRIDREMARKS = GRIDREMARKS & "|" & row.Cells(GDESC.Index).Value.ToString

                        If row.Cells(GPACKAGE.Index).Value.ToString = "Yes" Then
                            PACKAGE = PACKAGE & "|" & 1
                        Else
                            PACKAGE = PACKAGE & "|" & 0
                        End If

                        RATE = RATE & "|" & row.Cells(grate.Index).Value
                        CURCODE = CURCODE & "|" & row.Cells(GCURCODE.Index).Value
                        ROE = ROE & "|" & row.Cells(GROE.Index).Value
                        AMT = AMT & "|" & row.Cells(gamt.Index).Value

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



            Dim PURGRIDSRNO As String = ""
            Dim PURADULTRATE As String = ""
            Dim PURCHILDRATE As String = ""
            Dim PURRATE As String = ""
            Dim PURAMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPUR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If PURGRIDSRNO = "" Then
                        PURGRIDSRNO = Val(row.Cells(GPURSRNO.Index).Value)
                        PURADULTRATE = Val(row.Cells(GPUREXTRAADULTRATE.Index).Value)
                        PURCHILDRATE = Val(row.Cells(GPUREXTRACHILDRATE.Index).Value)
                        PURRATE = Val(row.Cells(GPURRATE.Index).Value)
                        PURAMT = Val(row.Cells(GPURAMT.Index).Value)

                    Else

                        PURGRIDSRNO = PURGRIDSRNO & "|" & Val(row.Cells(GPURSRNO.Index).Value)
                        PURADULTRATE = PURADULTRATE & "|" & Val(row.Cells(GPUREXTRAADULTRATE.Index).Value)
                        PURCHILDRATE = PURCHILDRATE & "|" & Val(row.Cells(GPUREXTRACHILDRATE.Index).Value)
                        PURRATE = PURRATE & "|" & Val(row.Cells(GPURRATE.Index).Value)
                        PURAMT = PURAMT & "|" & Val(row.Cells(GPURAMT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(PURGRIDSRNO)
            alParaval.Add(PURADULTRATE)
            alParaval.Add(PURCHILDRATE)
            alParaval.Add(PURRATE)
            alParaval.Add(PURAMT)


            alParaval.Add(txtmobileno.Text.Trim)
            alParaval.Add(txtemailadd.Text.Trim)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(CHKREFUNDED.CheckState)
            alParaval.Add(CHKFAILED.CheckState)

            alParaval.Add(TXTCONFIRMEDBY.Text.Trim)
            alParaval.Add(TXTCONFIRMATIONNO.Text.Trim)
            alParaval.Add(ClientName)
            alParaval.Add(CMBPREFIX.Text.Trim)
            alParaval.Add(Val(TXTENQNO.Text.Trim))
            alParaval.Add(CMBNOTES.Text.Trim)
            alParaval.Add(CMBCANCEL.Text.Trim)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(TXTPURHSNCODE.Text.Trim)

            alParaval.Add(CHKMANUAL.CheckState)

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTCESSPER.Text.Trim))
            alParaval.Add(Val(TXTCESSAMT.Text.Trim))

            alParaval.Add(CHKPURSERVTAX.CheckState)
            alParaval.Add(Val(TXTPURCOMMPER.Text.Trim))

            alParaval.Add(CHKPURMANUAL.CheckState)

            alParaval.Add(Val(TXTPURCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTPURCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTPURSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTPURSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTPURIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTPURIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTPURCESSPER.Text.Trim))
            alParaval.Add(Val(TXTPURCESSAMT.Text.Trim))

            'FOR COMM
            If LBLCOMMISSION.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)


            Dim OBJBOOKING As New ClsProformaHotelBookingMaster()
            OBJBOOKING.alParaval = alParaval


            'code for to save amended purchase order 
            If Val(TXTBOOKING_AMD.Text.Trim) > 0 Then 'And txtamdno.Text.Trim <> ""
                alParaval.Add(0) 'this is for done track ..in fresh entry mode done is always false
                alParaval.Add(TXTBOOKING_AMD.Text.Trim)
                alParaval.Add(TXTAMDNO.Text.Trim)

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.SAVEAMENDEDBOOKING()
                MessageBox.Show("Booking Amended ")
                TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    PRINTREPORT(DTNO.Rows(0).Item(0))
                End If

                clear()
                Exit Sub
            End If
            'End of current block of code



            If edit = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.save()

                ''ONCE DATA IS ADDED CALL CLP
                'If ClientName = "CLASSIC" Then
                '    Dim ARRLIST As String() = {"HOTELBOOKING", Val(TXTTOTALROOMS.Text.Trim), Val(TXTTOTALROOMS.Text.Trim)}
                '    Dim OBJ As New CustomerPointsMgmtClient
                '    Dim AR As Object = OBJ.getBillDetails("CLP", "S-" & DTNO.Rows(0).Item(0), Format(bookingdate.Value.Date, "yyyy-MM-dd"), "000000000002", "CLASSIC HOLIDAYS", "COH", Val(TXTSUBTOTAL.Text.Trim), Val(txtgrandtotal.Text.Trim), ARRLIST, 0, "", "", "GULKIT TEST", True)
                'End If

                If DIRECTUPLOAD = False Then
                    MessageBox.Show("Details Added")
                    TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then PRINTREPORT(DTNO.Rows(0).Item(0))
                End If
                TEMPBOOKINGNO = DTNO.Rows(0).Item(0)

            Else

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.update()

                ''ONCE DATA IS MODIFIED CALL CLP
                'If ClientName = "CLASSIC" Then
                '    'FIRST CANCEL THE  TRANSACTION  AND THEN RETURN
                '    Dim OBJ As New CustomerPointsMgmtClient
                '    Dim OO As New Object
                '    OO = OBJ.cancelTransaction("CLP", "S-" & Val(TEMPBOOKINGNO), Format(bookingdate.Value.Date, "yyyy-MM-dd"), "000000000002", "COH")

                '    Dim ARRLIST As String() = {"HOTELBOOKING", Val(TXTTOTALROOMS.Text.Trim), Val(TXTTOTALROOMS.Text.Trim)}
                '    OO = OBJ.getBillDetails("CLP", "S-" & Val(TEMPBOOKINGNO), Format(bookingdate.Value.Date, "yyyy-MM-dd"), "000000000002", "CLASSIC HOLIDAYS", "COH", Val(TXTSUBTOTAL.Text.Trim), Val(txtgrandtotal.Text.Trim), ARRLIST, 0, "", "", "GULKIT TEST", True)
                'End If


                MessageBox.Show("Details Updated")
                edit = False
                TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then PRINTREPORT(TEMPBOOKINGNO)
            End If


            'SEND SMS
            If chkmobile.CheckState = CheckState.Checked Then SMSCODE()

            'COPY SCANNED DOCS FILES 
            'For Each ROW As DataGridViewRow In gridupload.Rows
            '    If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\HOTEL") = False Then
            '        FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\HOTEL")
            '    End If
            '    If FileIO.FileSystem.FileExists(Application.StartupPath & "\HOTEL") = False Then
            '        System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
            '    End If
            'Next

            clear()
            BOOKINGDATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Not ClientName <> "CLASSIC" Then
            If Not datecheck(BOOKINGDATE.Text) Then
                EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If CMBBOOKINGTYPE.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKINGTYPE, " Select Booking Type")
            bln = False
        End If

        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        If ClientName = "URMI" And txtrefno.Text.Trim.Length = 0 Then
            EP.SetError(txtrefno, "Enter Ref No")
            bln = False
        End If

        If CMBGUESTNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBGUESTNAME, " Please Fill Guest Name ")
            bln = False
        End If

        ' GETBALANCE()
        If LBLPURBAL.ForeColor = Color.Red Then
            Dim temppurchasebal As Integer = MsgBox("Amt Exceeds Cr Limit, wish to continue?", MsgBoxStyle.YesNo)
            If temppurchasebal = 7 Then
                EP.SetError(LBLPURBAL, "Amt Exceeds Cr Limit")
                bln = False
            End If
        End If

        If LBLACCBAL.ForeColor = Color.Red Then
            EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            bln = False
        End If


        If (ClientName = "CLASSIC" And UserName = "Admin" And edit = False) Or ((ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "NAMASTE") And edit = False) Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " PROFORMAHOTELBOOKINGMASTER", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' AND BOOKING_BOOKTYPE='" & FRMSTRING & "' and BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    bln = False
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                End If
            End If
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = True Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < DDATE.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If

        'CHECKING WHETHER NAME IS PRESENT IN DATABASE OR NOT
        'DONT DELETE THIS CODE IT IS NECESSARY COZ SOMETIMES FORM IS OPEN AND USER CHANGES THE NAME FROM BEHIND
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        If ClientName <> "TOPCOMM" Then
            DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                EP.SetError(CMBNAME, "Change Name")
                bln = False
            End If

            If ClientName <> "ARHAM" Then
                DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    EP.SetError(CMBPURNAME, "Change Name")
                    bln = False
                End If
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Account Name ")
                bln = False
            End If
        End If
        '***************************************************

        If txtmobileno.Text.Trim.Length = 0 Then
            DT = OBJCMN.search(" ISNULL(ACC_MOBILE,0) AS ACC_MOBILE ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                txtmobileno.Text = DT.Rows(0).Item(0)
            End If
        End If

        If DIRECTUPLOAD = False Then
            If txtmobileno.Text.Trim.Length = 0 And ClientName <> "HEENKAR" Then
                EP.SetError(txtmobileno, " Please Fill Guest's Mobile No ")
                bln = False
            End If
        End If


        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = False Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < Now.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If


            If Val(txtgrandtotal.Text.Trim) >= 50001 Then
                DT = OBJCMN.search(" ACC_ADD, ACC_PANNO AS PANNO", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("PANNO") = "" Then
                        EP.SetError(CMBNAME, "Insert PAN No")
                        bln = False
                    End If
                End If
            End If

            If Val(txtgrandtotal.Text.Trim) = 0 Then
                EP.SetError(txtgrandtotal, "Amount cannot be 0")
                bln = False
            End If

            If Val(TXTFINALPURAMT.Text.Trim) = 0 Then
                EP.SetError(TXTFINALPURAMT, "Amount cannot be 0")
                bln = False
            End If

        End If


        If TXTGUESTADD.Text.Trim.Length = 0 Then
            DT = OBJCMN.search(" ISNULL(ACC_ADD,'') AS ACC_ADD ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                TXTGUESTADD.Text = DT.Rows(0).Item(0)
            End If
        End If

        If DIRECTUPLOAD = False Then
            If TXTGUESTADD.Text.Trim.Length = 0 Then
                EP.SetError(TBadd, " Please Fill Guest Add")
                bln = False
            End If

            If cmbhotelname.Text.Trim.Length = 0 Then
                EP.SetError(cmbhotelname, " Please Fill Hotel Name ")
                bln = False
            End If
        End If


        'If txthoteladd.Text.Trim.Length = 0 Then
        '    EP.SetError(TBadd, " Please Fill Hotel Add")
        '    bln = False
        'End If


        If ClientName = "CLASSIC" Then
            If ARRIVALDATE.Value.Date > DEPARTDATE.Value.Date Then
                EP.SetError(ARRIVALDATE, " Fill Proper Dates ")
                bln = False
            End If
        Else
            If ARRIVALDATE.Value.Date >= DEPARTDATE.Value.Date Then
                EP.SetError(ARRIVALDATE, " Fill Proper Dates ")
                bln = False
            End If
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

        'If chkchange.CheckState = CheckState.Unchecked Then
        '    EP.SetError(CMBGUESTNAME, "Enter Details")
        '    bln = False
        'End If


        If ClientName <> "LUXCREST" Then
            If UserName <> "Admin" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, " Booking Locked, Payment/Receipt Made")
                    bln = False
                End If
            End If

            If LBLCOMMISSION.Visible = True Then
                EP.SetError(lblamd, " Booking Locked, Commission Raised...")
                bln = False
            End If

            If lblamd.Visible = True Then
                EP.SetError(lblamd, " Booking Locked, Booking Amended")
                bln = False
            End If

            If UserName <> "Admin" Then
                If PBCN.Visible = True Then
                    EP.SetError(PBCN, " Booking Locked, Credit Note Raised")
                    bln = False
                End If
            End If

            If UserName <> "Admin" Then
                If PBDN.Visible = True Then
                    EP.SetError(PBDN, " Booking Locked, Debit Note Raised")
                    bln = False
                End If
            End If

            If lblcancelled.Visible = True Then
                EP.SetError(PBCancelled, " Booking Locked, Booking Cancelled")
                bln = False
            End If
        End If

        If Val(txtotherchg.Text.Trim) = 0 Then
            CMBOTHERCHGS.Text = ""
            cmbaddsub.SelectedIndex = 0
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) = 0 Then
            CMBPUROTHERCHGS.Text = ""
            CMBPURADDSUB.SelectedIndex = 0
        End If


        If Val(txtotherchg.Text.Trim) > 0 And CMBOTHERCHGS.Text.Trim = "" Then
            EP.SetError(txtotherchg, " Select Expense Type")
            bln = False
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If

        If BOOKINGDATE.Text = "__/__/____" Then
            EP.SetError(BOOKINGDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(BOOKINGDATE.Text) Then
                EP.SetError(BOOKINGDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If ClientName = "CLASSIC" Then
            'AS PER ASHOK BHAI REQ
            'If Not datecheck(ARRIVALDATE.Value) Then
            '    EP.SetError(ARRIVALDATE, "Date Not in Current Accounting Year")
            '    bln = False
            'End If

            'done temporarily
            'If Not datecheck(DEPARTDATE.Value) Then
            '    EP.SetError(DEPARTDATE, "Date Not in Current Accounting Year")
            '    bln = False
            'End If
        End If

        If ClientName = "TOPCOMM" Then
            If txtremarks.Text.Trim = "" Then
                EP.SetError(TabControl1, "Enter Payment Notes")
                bln = False
            End If
        End If

        'If Convert.ToDateTime(BILLDATE.Text).Date >= "01/07/2017" Then
        '    If TXTSTATECODE.Text.Trim.Length = 0 Then
        '        EP.SetError(TXTSTATECODE, "Please enter the state code")
        '        bln = False
        '    End If

        '    If TXTGSTIN.Text.Trim.Length = 0 Then
        '        If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '            EP.SetError(TXTSTATECODE, "Enter GSTIN in Party Master")
        '            bln = False
        '        End If
        '    End If

        '    If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(LBLTOTALCGSTAMT.Text) > 0 Or Val(LBLTOTALSGSTAMT.Text.Trim) > 0) Then
        '        EP.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
        '        bln = False
        '    End If

        '    If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(LBLTOTALIGSTAMT.Text) > 0 Then
        '        EP.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
        '        bln = False
        '    End If
        'End If

        Return bln
    End Function

    Sub total()

        TXTTOTALADULTS.Text = 0
        TXTTOTALCHILDS.Text = 0
        TXTTOTALNCCHILDS.Text = 0
        TXTTOTALEXTRAADULTS.Text = 0
        TXTTOTALEXTRACHILDS.Text = 0
        TXTTOTALROOMS.Text = 0
        TXTTOTALAMT.Text = "0.00"
        TXTTOTALSALEAMT.Text = "0.00"
        TXTTOTALPAX.Text = 0
        TXTCESSAMT.Clear()

        CMBADDTAX.Text = ""
        TXTADDTAX.Clear()


        TXTSUBTOTAL.Text = 0.0
        ' txttax.Text = 0.0
        TXTADDTAX.Text = 0.0
        If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
        txtroundoff.Text = 0.0


        'FOR SSR/CLASSIC/HBAZAAR/KHANNA/URMI OURCOMM IS SERVICE CHARGES, HERE THEY ENTER SERVICE CHGS MANUALLY
        'If (ClientName <> "SSR" And ClientName <> "CLASSIC" And ClientName <> "HBAZAAR" And ClientName <> "KHANNA" And ClientName <> "MAHARAJA" And ClientName <> "AERO" And ClientName <> "URMI") Then TXTOURCOMMRS.Text = 0.0

        txtgrandtotal.Text = 0.0
        TXTBAL.Clear()
        txtinwords.Clear()



        If GRIDBOOKINGS.RowCount > 0 Then

            For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
                If Val(row.Cells(gadults.Index).Value) > 0 Then TXTTOTALADULTS.Text = Val(TXTTOTALADULTS.Text) + Val(row.Cells(gadults.Index).Value)
                If Val(row.Cells(gchilds.Index).Value) > 0 Then TXTTOTALCHILDS.Text = Val(TXTTOTALCHILDS.Text) + Val(row.Cells(gchilds.Index).Value)
                If Val(row.Cells(gncchilds.Index).Value) > 0 Then TXTTOTALNCCHILDS.Text = Val(TXTTOTALNCCHILDS.Text) + Val(row.Cells(gncchilds.Index).Value)
                If Val(row.Cells(GEXTRAADULT.Index).Value) > 0 Then TXTTOTALEXTRAADULTS.Text = Val(TXTTOTALEXTRAADULTS.Text) + Val(row.Cells(GEXTRAADULT.Index).Value)
                If Val(row.Cells(GEXTRACHILD.Index).Value) > 0 Then TXTTOTALEXTRACHILDS.Text = Val(TXTTOTALEXTRACHILDS.Text) + Val(row.Cells(GEXTRACHILD.Index).Value)
                If Val(row.Cells(gnoofRooms.Index).Value) > 0 Then TXTTOTALROOMS.Text = Val(TXTTOTALROOMS.Text) + Val(row.Cells(gnoofRooms.Index).Value)
                If row.Cells(GPACKAGE.Index).Value = "No" Then
                    row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRAADULT.Index).Value) * Val(row.Cells(GEXTRAADULTRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GEXTRACHILD.Index).Value) * Val(row.Cells(GEXTRACHILDRATE.Index).Value) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    row.Cells(gamt.Index).Value = Format((Val(row.Cells(grate.Index).Value) * Val(row.Cells(gnoofRooms.Index).Value)) + (Val(row.Cells(GEXTRAADULTRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRAADULT.Index).EditedFormattedValue)) + (Val(row.Cells(GEXTRACHILDRATE.Index).EditedFormattedValue) * Val(row.Cells(GEXTRACHILD.Index).EditedFormattedValue)), "0.00")
                End If
                If Val(row.Cells(gamt.Index).Value) > 0 Then TXTTOTALAMT.Text = Format(Val(TXTTOTALAMT.Text) + Val(row.Cells(gamt.Index).Value), "0.00")
            Next

            TXTTOTALPAX.Text = Val(TXTTOTALADULTS.Text.Trim) + Val(TXTTOTALCHILDS.Text.Trim) + Val(TXTTOTALNCCHILDS.Text.Trim) + Val(TXTTOTALEXTRAADULTS.Text.Trim) + Val(TXTTOTALEXTRACHILDS.Text.Trim)

            'Dim objclscmn As New ClsCommonMaster
            'Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            'If dt1.Rows.Count > 0 Then If Val(dt1.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt1.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            'If dt1.Rows.Count > 0 Then

            'If CHKREVERSE.Checked = True Then
            'Dim objclscmn As New ClsCommonMaster
            'Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            'If dt1.Rows.Count > 0 Then
            '    If CHKREVERSE.Checked = True Then
            '        TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1) + 100) * 100), "0.00")
            '    Else
            '        TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
            '    End If
            'End If

            'COREECT CODE ON 24-05-2017 
            'If CHKREVERSE.Checked = True Then
            '    Dim objclscmn As New ClsCommonMaster
            '    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            '    If dt1.Rows.Count > 0 Then
            '        TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
            '    End If
            'Else
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
            'End If


            'TESTING FOR AERO 24-05-2017
            '24-05-2017
            If CHKREVERSE.Checked = True Then
                If CHKTAXSERVCHGS.Checked = False Then
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    Else
                        TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                    End If
                Else
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMRS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    End If
                    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
                End If
            Else
                TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")
            End If

            'TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALAMT.Text.Trim), "0.00")

            'COZ EXTRA ADULT AND CHILD ARE NOW IN GRID LINE ITEM
            'If Val(TXTEXTRAADULT.Text.Trim) > 0 And Val(TXTEXTRAADULTRATE.Text.Trim) > 0 Then
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            'End If

            'If Val(TXTEXTRACHILD.Text.Trim) > 0 And Val(TXTEXTRACHILDRATE.Text.Trim) > 0 Then
            '    TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text.Trim) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            'End If


            If Val(TXTAGENTCOMMPER.Text) > 0 Then
                TXTAGENTCOMMRS.Text = Format((Val(TXTAGENTCOMMPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
            Else
                'TXTAGENTCOMMPER.Text = Format((Val(TXTAGENTCOMMRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
            End If


            If Val(TXTAGENTTDSPER.Text) > 0 Then
                TXTAGENTTDSRS.Text = Format((Val(TXTAGENTTDSPER.Text) * Val(TXTAGENTCOMMRS.Text)) / 100, "0.00")
            Else
                'TXTAGENTTDSPER.Text = Format((Val(TXTAGENTTDSRS.Text) * 100) / Val(TXTAGENTCOMMRS.Text), "0.00")
            End If



            If Val(TXTDISCPER.Text) > 0 Then
                TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
            Else
                'TXTDISCPER.Text = Format((Val(TXTDISCRS.Text) * 100) / Val(TXTTOTALSALEAMT.Text), "0.00")
            End If


            'FOR SSR OURCOMM IS SERVICE CHARGES, HERE THEY ENTER SERVICE CHGS MANUALLY
            'If (ClientName = "SSR" Or ClientName = "CLASSIC" Or ClientName = "HBAZAAR" Or ClientName = "KHANNA" Or ClientName = "MAHARAJA" Or ClientName = "AERO") Then
            TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text)) - Val(TXTDISCRS.Text) + Val(TXTEXTRACHGS.Text.Trim) + Val(TXTOURCOMMRS.Text.Trim), "0.00")
            'Else
            'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text)) - Val(TXTDISCRS.Text) + Val(TXTEXTRACHGS.Text.Trim), "0.00")
            'End If




            Dim objclscommon As New ClsCommonMaster
            Dim dt As New DataTable
            If Convert.ToDateTime(BOOKINGDATE.Text).Date < "07/01/2017" Then
                dt = objclscommon.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                    If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTOURCOMMRS.Text))) / 100, "0.00")
                Else
                    If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                End If
            Else
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
                        End If
                    Else
                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                        End If
                    End If
                End If
            End If

            'If CHKMANUAL.CheckState = CheckState.Unchecked Then
            '    TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '    TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '    TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '    'row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
            '    'row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
            '    'row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")
            'End If

            dt = objclscommon.search("TAX_NAME, tax_tax AS TAX", "", "TAXMaster", " And TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            'If dt.Rows.Count > 0 Then TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")


            If cmbaddsub.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


            'FOR SSR OURCOMM IS SERVICE CHARGES, HERE THEY ENTER SERVICE CHGS MANUALLY
            'If (ClientName <> "SSR" And ClientName <> "CLASSIC" And ClientName <> "HBAZAAR" And ClientName <> "KHANNA" And ClientName <> "MAHARAJA" And ClientName <> "AERO" And ClientName <> "URMI") Then TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTPURNETTAMT.Text), "0.00")


            'JUST SHOW THIS FOR CLASSIC/KHANNA/URMI IN ANOTHER FIELD
            'If (ClientName = "CLASSIC" Or ClientName = "KHANNA" Or ClientName = "MAHARAJA" Or ClientName = "AERO" Or ClientName = "URMI") Then TXTOURCOMM.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTPURNETTAMT.Text), "0.00")
            TXTOURCOMM.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTPURNETTAMT.Text), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)
        End If
    End Sub

    Sub PURCHASETOTAL()

        TXTPURAMT.Text = 0.0
        TXTPURTOTALADULT.Text = 0
        TXTPURTOTALCHILD.Text = 0
        TXTTOTALPURAMT.Text = 0.0
        TXTPURSUBTOTAL.Text = 0.0
        '  TXTPURTAX.Text = 0.0
        TXTPURADDTAX.Text = 0.0
        If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0
        TXTPURNETTAMT.Text = 0.0
        If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = 0.0
        TXTPURGTOTAL.Text = 0.0
        TXTFINALPURAMT.Text = 0.0
        TXTPURCESSAMT.Clear()

        If GRIDPUR.RowCount > 0 Then

            For Each row As DataGridViewRow In GRIDPUR.Rows

                'NO CALCULATIONS OF EXTRA ADULTS
                If row.Cells(GPURPACKAGE.Index).Value = "No" Then
                    'row.Cells(GPURAMT.Index).Value = Format((Val(row.Cells(GPURRATE.Index).EditedFormattedValue) * Val(row.Cells(GPURNOOFROOMS.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GPUREXTRAADULT.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(row.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    row.Cells(GPURAMT.Index).Value = Format((Val(row.Cells(GPURRATE.Index).EditedFormattedValue) * Val(row.Cells(GPURNOOFROOMS.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    If Val(row.Cells(GPUREXTRAADULT.Index).Value) > 0 Then TXTPURTOTALADULT.Text = Format(Val(TXTPURTOTALADULT.Text) + (Val(row.Cells(GPUREXTRAADULT.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    If Val(row.Cells(GPUREXTRACHILDS.Index).Value) > 0 Then TXTPURTOTALCHILD.Text = Format(Val(TXTPURTOTALCHILD.Text) + (Val(row.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
                Else
                    'row.Cells(GPURAMT.Index).Value = Format((Val(row.Cells(GPURRATE.Index).EditedFormattedValue) * Val(row.Cells(GPURNOOFROOMS.Index).EditedFormattedValue)) + (Val(row.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRAADULT.Index).EditedFormattedValue)) + (Val(row.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue)), "0.00")
                    row.Cells(GPURAMT.Index).Value = Format((Val(row.Cells(GPURRATE.Index).EditedFormattedValue) * Val(row.Cells(GPURNOOFROOMS.Index).EditedFormattedValue)), "0.00")
                    If Val(row.Cells(GPUREXTRAADULT.Index).Value) > 0 Then TXTPURTOTALADULT.Text = Format(Val(TXTPURTOTALADULT.Text) + (Val(row.Cells(GPUREXTRAADULT.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue)), "0.00")
                    If Val(row.Cells(GPUREXTRACHILDS.Index).Value) > 0 Then TXTPURTOTALCHILD.Text = Format(Val(TXTPURTOTALCHILD.Text) + (Val(row.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue) * Val(row.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue)), "0.00")
                End If

                If Val(row.Cells(GPURAMT.Index).Value) > 0 Then TXTPURAMT.Text = Format(Val(TXTPURAMT.Text) + Val(row.Cells(GPURAMT.Index).EditedFormattedValue), "0.00")

            Next

            TXTTOTALPURAMT.Text = Format(Val(TXTPURAMT.Text.Trim), "0.00")


            If Val(TXTDISCRECDPER.Text) > 0 Then
                TXTDISCRECDRS.Text = Format((Val(TXTDISCRECDPER.Text) * Val(TXTTOTALPURAMT.Text)) / 100, "0.00")
            Else
                'TXTDISCRECDPER.Text = Format((Val(TXTDISCRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
            End If

            TXTPURSUBTOTAL.Text = Format(Val(TXTTOTALPURAMT.Text) - Val(TXTDISCRECDRS.Text), "0.00")

            If Val(TXTCOMMRECDPER.Text) > 0 Then
                TXTCOMMRECDRS.Text = Format((Val(TXTCOMMRECDPER.Text) * Val(TXTTOTALPURAMT.Text)) / 100, "0.00")
            Else
                'TXTCOMMRECDPER.Text = Format((Val(TXTCOMMRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
            End If

            If Val(TXTPURTDSPER.Text) > 0 Then
                TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(TXTCOMMRECDRS.Text)) / 100, "0.00")
            Else
                ' TXTPURTDSPER.Text = Format((Val(TXTPURTDSRS.Text) * 100) / Val(TXTCOMMRECDRS.Text), "0.00")
            End If

            TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) - Val(TXTCOMMRECDRS.Text) + Val(TXTPUREXTRACHGS.Text.Trim) + Val(TXTPURTOTALADULT.Text.Trim) + Val(TXTPURTOTALCHILD.Text.Trim) + Val(TXTPURCOMMPER.Text.Trim), "0.00")



            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If Convert.ToDateTime(BOOKINGDATE.Text).Date < "07/01/2017" Then
                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If CHKPURSERVTAX.CheckState = CheckState.Checked Then
                    If dt.Rows.Count > 0 Then
                        If (Val(dt.Rows(0).Item(1))) > 0 Then
                            TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTTOTALPURAMT.Text) + Val(TXTPURTOTALADULT.Text.Trim) + Val(TXTPURTOTALCHILD.Text.Trim) + Val(TXTPUREXTRACHGS.Text.Trim))) / 100, "0.00")
                        End If
                    End If
                End If
            Else '''SHOW TO GULKIT SIR... ''NEHA
                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKPURSERVTAX.CheckState = CheckState.Checked Then
                        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURCOMMPER.Text)) / 100, "0.00")
                        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURCOMMPER.Text)) / 100, "0.00")
                        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURCOMMPER.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTPURCOMMPER.Text)) / 100, "0.00")
                        End If
                    Else

                        TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBPURNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTPURCESSAMT.Text = Format((Val(TXTPURCESSPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                        End If

                    End If
                End If
            End If
            'If CHKPURMANUAL.CheckState = CheckState.Checked Then
            '    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
            '    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
            '    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
            'End If

            'Dim objclscommon As New ClsCommonMaster

            'Dim dt As New DataTable
            'If Format(bookingdate.Value.Date, "dd/MM/yyyy") < "01/07/2017" Then
            '    dt = objclscommon.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            '    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
            '        If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTOURCOMMRS.Text))) / 100, "0.00")
            '    Else
            '        If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '    End If
            'Else
            '    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
            '        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
            '        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")
            '        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTOURCOMMRS.Text)) / 100, "0.00")

            '    Else

            '        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            '        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")

            '    End If
            'End If


            ''for add tax

            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then TXTPURADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTTOTALPURAMT.Text) + Val(TXTPURTOTALADULT.Text.Trim) + Val(TXTPURTOTALCHILD.Text.Trim) + Val(TXTPUREXTRACHGS.Text.Trim))) / 100, "0.00")




            If CMBPURADDSUB.Text = "Add" Then
                TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text), "0")
                If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")
            Else
                TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text), "0")
                If ClientName <> "PRIYA" Then TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - ((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURCESSAMT.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text)), "0.00")
            End If


            ''ADD EXTRAADULTS AND EXTRACHILDS IN GTOTTAL 
            'For Each ROW As DataGridViewRow In GRIDPUR.Rows
            '    If ROW.Cells(GPURSRNO.Index).Value <> Nothing Then
            '        If ROW.Cells(GPURPACKAGE.Index).Value = "No" Then
            '            TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text.Trim) + (Val(ROW.Cells(GPUREXTRAADULT.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(ROW.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            '        Else
            '            TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text.Trim) + (Val(ROW.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRAADULT.Index).EditedFormattedValue)) + (Val(ROW.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue)), "0.00")
            '        End If
            '    End If
            'Next

            If ClientName <> "PRIYA" Then
                TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
            Else
                If CMBPURADDSUB.Text = "Add" Then
                    TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0.00")
                Else
                    TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0.00")
                End If
            End If

            TXTFINALPURAMT.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")

        End If
        total()

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If GRIDBOOKINGS.RowCount > 0 Then
                txtsrno.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If CMBROOMTYPE.Text.Trim <> "" And Val(TXTADULTS.Text) > 0 And CMBACNONAC.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTNOOFROOMS.Text.Trim) > 0 And CMBPACKAGE.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 Then

            'NO NEED OF THIS CALCULATION AS EXTRA ADULT AND CHILD ARE NOW IN GRID ITEM
            'If (Val(TXTADULTS.Text.Trim) - (Val(TXTNOOFROOMS.Text.Trim) * 2)) > 0 Then
            '    TXTEXTRAADULT.Text = Format((Val(TXTADULTS.Text.Trim) - (Val(TXTNOOFROOMS.Text.Trim) * 2)), "0")
            '    TXTADULTS.Text = Val(TXTADULTS.Text.Trim) - Format((Val(TXTADULTS.Text.Trim) - (Val(TXTNOOFROOMS.Text.Trim) * 2)), "0")
            'End If

            fillgrid()
            PURCHASETOTAL()
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
        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Val(txtsrno.Text.Trim), CMBROOMTYPE.Text.Trim, "Yes", CMBPLAN.Text.Trim, Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), Val(TXTEXTRAADULT.Text.Trim), Val(TXTEXTRAADULTRATE.Text.Trim), Val(TXTEXTRACHILD.Text.Trim), Val(TXTEXTRACHILDRATE.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), "", CMBPACKAGE.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), CMBCURCODE.Text.Trim, Format(Val(TXTROE.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"))

            'ADD IN GRIDPUR ALSO
            'GET DEFAULT PUR RATE FROM HOTELMASTER WITH RESPECT TO ROOMTYPE
            Dim TPURRATE As Double = 0.0
            If CMBROOMTYPE.Text.Trim <> "" And cmbhotelname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER_ROOMDESC.HOTEL_RATE as ROOMRATE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND ROOMTYPEMASTER.ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    'TPURRATE = Format((DT.Rows(0).Item("ROOMRATE") * (TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    TPURRATE = Format((DT.Rows(0).Item("ROOMRATE")), "0.00")
                End If
            End If
            GRIDPUR.Rows.Add(Val(txtsrno.Text.Trim), CMBROOMTYPE.Text.Trim, Val(TXTADULTS.Text.Trim), Val(TXTCHILDS.Text.Trim), Val(TXTNCCHILDS.Text.Trim), Val(TXTEXTRAADULT.Text.Trim), Val(TXTEXTRAADULTRATE.Text.Trim), Val(TXTEXTRACHILD.Text.Trim), Val(TXTEXTRACHILDRATE.Text.Trim), Val(TXTNOOFROOMS.Text.Trim), CMBPACKAGE.Text.Trim, Format(Val(TPURRATE), "0.00"), 0)

            getsrno(GRIDBOOKINGS)
            getsrno(GRIDPUR)

        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDBOOKINGS.Item(groomtype.Index, temprow).Value = CMBROOMTYPE.Text.Trim
            GRIDBOOKINGS.Item(gac.Index, temprow).Value = "Yes"
            GRIDBOOKINGS.Item(gplan.Index, temprow).Value = CMBPLAN.Text.Trim
            GRIDBOOKINGS.Item(gadults.Index, temprow).Value = Val(TXTADULTS.Text.Trim)
            GRIDBOOKINGS.Item(gchilds.Index, temprow).Value = Val(TXTCHILDS.Text.Trim)
            GRIDBOOKINGS.Item(gncchilds.Index, temprow).Value = Val(TXTNCCHILDS.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRAADULT.Index, temprow).Value = Val(TXTEXTRAADULT.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRAADULTRATE.Index, temprow).Value = Val(TXTEXTRAADULTRATE.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRACHILD.Index, temprow).Value = Val(TXTEXTRACHILD.Text.Trim)
            GRIDBOOKINGS.Item(GEXTRACHILDRATE.Index, temprow).Value = Val(TXTEXTRACHILDRATE.Text.Trim)
            GRIDBOOKINGS.Item(gnoofRooms.Index, temprow).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDBOOKINGS.Item(GPACKAGE.Index, temprow).Value = CMBPACKAGE.Text.Trim
            GRIDBOOKINGS.Item(grate.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GCURCODE.Index, temprow).Value = CMBCURCODE.Text.Trim
            GRIDBOOKINGS.Item(GROE.Index, temprow).Value = Format(Val(TXTROE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(gamt.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")


            'EDIT IN GRIDPUR
            GRIDPUR.Item(GPURSRNO.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDPUR.Item(GPURROOMTYPE.Index, temprow).Value = CMBROOMTYPE.Text.Trim
            GRIDPUR.Item(GPURADULTS.Index, temprow).Value = Val(TXTADULTS.Text.Trim)
            GRIDPUR.Item(GPURCHILDS.Index, temprow).Value = Val(TXTCHILDS.Text.Trim)
            GRIDPUR.Item(GPURNCCHILD.Index, temprow).Value = Val(TXTNCCHILDS.Text.Trim)
            GRIDPUR.Item(GPUREXTRAADULT.Index, temprow).Value = Val(TXTEXTRAADULT.Text.Trim)
            GRIDPUR.Item(GPUREXTRAADULTRATE.Index, temprow).Value = Val(TXTEXTRAADULTRATE.Text.Trim)
            GRIDPUR.Item(GPUREXTRACHILDS.Index, temprow).Value = Val(TXTEXTRACHILD.Text.Trim)
            GRIDPUR.Item(GPUREXTRACHILDRATE.Index, temprow).Value = Val(TXTEXTRACHILDRATE.Text.Trim)
            GRIDPUR.Item(GPURNOOFROOMS.Index, temprow).Value = Val(TXTNOOFROOMS.Text.Trim)
            GRIDPUR.Item(GPURPACKAGE.Index, temprow).Value = CMBPACKAGE.Text.Trim

            gridDoubleClick = False
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

                gridDoubleClick = True
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

                temprow = e.RowIndex
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                Dim TINDEX As Integer = GRIDBOOKINGS.CurrentRow.Index

                GRIDBOOKINGS.Rows.RemoveAt(TINDEX)
                GRIDPUR.Rows.RemoveAt(TINDEX)

                getsrno(GRIDBOOKINGS)
                getsrno(GRIDPUR)
                PURCHASETOTAL()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPBOOKINGNO = Val(tstxtbillno.Text)
            If TEMPBOOKINGNO > 0 Then
                edit = True
                HotelBookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.GotFocus
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
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

            Dim OBJBOOKING As New ProformaHotelBookingsDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.FRMSTRING = FRMSTRING
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
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
            TEMPBOOKINGNO = Val(txtbookingno.Text) - 1
Line2:
            If TEMPBOOKINGNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  PROFORMAHOTELBOOKINGMASTER ", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    HotelBookings_Load(sender, e)
                Else
                    TEMPBOOKINGNO = Val(TEMPBOOKINGNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                txtbookingno.Text = TEMPBOOKINGNO
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
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                HotelBookings_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
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
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
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
                If OBJHOTEL.TEMPHOTELCODE <> "" Then cmbhotelcode.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then cmbhotelname.Text = OBJHOTEL.TEMPHOTELNAME
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
                If txtmobileno.Text.Trim = "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" GUEST_MOBILENO AS MOBILENO, ISNULL(GUEST_EMAIL,'') AS EMAILID, ISNULL(PREFIX_NAME, '') AS PREFIX ", "", " GUESTMASTER LEFT OUTER JOIN PREFIXMASTER ON GUEST_PREFIXID = PREFIX_ID ", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        txtmobileno.Text = DT.Rows(0).Item("MOBILENO")
                        txtemailadd.Text = DT.Rows(0).Item("EMAILID")
                        CMBPREFIX.Text = DT.Rows(0).Item("PREFIX")
                    End If
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

    Sub GETBALANCE()
        Try

            Dim USERACCOUNTSADD, USERACCOUNTSEDIT, USERACCOUNTSVIEW, USERACCOUNTSDELETE As Boolean
            Dim DTACCOUNTSROW() As DataRow
            DTACCOUNTSROW = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERACCOUNTSADD = DTACCOUNTSROW(0).Item(1)
            USERACCOUNTSEDIT = DTACCOUNTSROW(0).Item(2)
            USERACCOUNTSVIEW = DTACCOUNTSROW(0).Item(3)
            USERACCOUNTSDELETE = DTACCOUNTSROW(0).Item(4)


            LBLPURBAL.Text = "0.00"
            LBLACCBAL.Text = "0.00"
            If USERACCOUNTSVIEW = False Then
                LBLPURBAL.Visible = False
                LBLACCBAL.Visible = False
            End If

            'SALE BALANCE
            Dim OBJCMN As New ClsCommon
            'DONE TO REMOVE CRLIMIT
            'Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS SALEBAL, ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname and TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)


            'START THIS CODE ONLY
            'DONE TEMP AS IT WAS WORKING SLOW FOR NEW YEAR
            'Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS SALEBAL, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE ", " AND NAME = '" & CMBNAME.Text.Trim & "' AND YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    LBLACCBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("SALEBAL")
            '    'If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
            '    '    LBLACCBAL.ForeColor = Color.Red
            '    'Else
            '    '    LBLACCBAL.ForeColor = Color.Green
            '    'End If
            'End If
            'END OF CODE





            ''CR LIMIT OF SALE PARTY
            'DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ACC_CRDAYS AS CRDAYS", "", "PROFORMAHOTELBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_LEDGERID AND ACC_YEARID = BOOKING_YEARID", " AND BOOKING_SALEBALANCE > 0 AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    For Each DTROW As DataRow In DT.Rows
            '        If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
            '            MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
            '            GoTo LINE1
            '        End If
            '    Next
            'End If


LINE1:

            'PUR BALANCE
            'DT = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS PURBAL , ACC_CRLIMIT AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.Name = LEDGERS.Acc_cmpname AND TRIALBALANCE.YEARID = LEDGERS.Acc_yearid ", " AND NAME = '" & CMBPURNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)


            'START THIS CODE ONLY
            'DONE TEMP AS IT WAS WORKING SLOW FOR NEW YEAR
            'DT = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS PURBAL , (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE ", " AND NAME = '" & CMBPURNAME.Text.Trim & "' AND YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    LBLPURBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("PURBAL")
            '    'If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
            '    '    LBLPURBAL.ForeColor = Color.Red
            '    'Else
            '    '    LBLPURBAL.ForeColor = Color.Green
            '    'End If
            'End If
            'END CODE


            ''CR LIMIT OF PUR PARTY
            'DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ACC_CRDAYS AS CRDAYS", "", "PROFORMAHOTELBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_PURLEDGERID AND ACC_YEARID = BOOKING_YEARID", " AND BOOKING_PURBALANCE > 0 AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND BOOKING_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    For Each DTROW As DataRow In DT.Rows
            '        If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
            '            MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
            '            GoTo LINE2
            '        End If
            '    Next
            'End If
LINE2:


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            'If CMBACCCODE.Text.Trim <> "" Then GETBALANCE()
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

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    'CMBTRANSPORT.Text = DT.Rows(0).Item("TRANSNAME")
                    'CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    'TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")

                    If txtmobileno.Text.Trim = "" Then
                        DT = OBJCMN.search(" ISNULL(ACC_MOBILE,'') AS MOBILENO, ISNULL(ACC_EMAIL,'') ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            TXTSALEMOBILE.Text = DT.Rows(0).Item(0)
                            txtemailadd.Text = DT.Rows(0).Item(1)
                        End If
                    End If
                End If
                GETBALANCE()
                GETHSNCODE()
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

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Or lblcancelled.Visible = True Then
                    MsgBox("Voucher Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Booking Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsProformaHotelBookingMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(FRMSTRING)
                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJBOOKING.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()
                    edit = False
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
            'If CHKMANUAL.CheckState = CheckState.Unchecked Then
            '    TXTCGSTAMT.Text = 0.0
            '    TXTSGSTAMT.Text = 0.0
            '    TXTIGSTAMT.Text = 0.0
            'End If

            If CMBPACKAGE.Text.Trim = "No" Then
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRAADULT.Text.Trim) * Val(TXTEXTRAADULTRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(TXTEXTRACHILD.Text.Trim) * Val(TXTEXTRACHILDRATE.Text.Trim) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
            Else
                TXTTOTAL.Text = Format((Val(TXTRATE.Text.Trim) * Val(TXTNOOFROOMS.Text.Trim)) + Val(TXTEXTRAADULTRATE.Text.Trim) + Val(TXTEXTRACHILDRATE.Text.Trim), "0.00")
            End If

            'If CHKMANUAL.CheckState = CheckState.Unchecked Then
            '    TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
            '    TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
            '    TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTSUBTOTAL.Text), "0.00")
            'End If

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
                PURCHASETOTAL()
            ElseIf DEPARTDATE.Value.Date = ARRIVALDATE.Value.Date Then
                TXTTOTALNIGHTS.Text = 1
                PURCHASETOTAL()
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
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
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
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
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

    Private Sub CMBARRFROM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBARRFROM.GotFocus
        Try
            If CMBARRFROM.Text.Trim = "" Then fillcity(CMBARRFROM)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEPARTTO.GotFocus
        Try
            If CMBDEPARTTO.Text.Trim = "" Then fillcity(CMBDEPARTTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBARRFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBARRFROM.Validating
        Try
            If CMBARRFROM.Text.Trim <> "" Then CITYVALIDATE(CMBARRFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTTO.Validating
        Try
            If CMBDEPARTTO.Text.Trim <> "" Then CITYVALIDATE(CMBDEPARTTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPLAN.Validated
        If Val(TXTENQNO.Text.Trim) = 0 Then GETRATE()
    End Sub

    Sub GETRATE()
        Try
            If edit = True Then Exit Sub
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

    Private Sub CMBAGENTNAME_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENTNAME.GotFocus
        Try
            If CMBAGENTNAME.Text.Trim = "" Then fillAGENT(CMBAGENTNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENTNAME.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True


    End Sub

    Private Sub CMBAGENTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENTNAME.Validating
        Try
            If CMBAGENTNAME.Text.Trim <> "" Then AGENTVALIDATE(CMBAGENTNAME, e, Me, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors")
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
                If edit = False Then CMBROOMTYPE.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBROOMTYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBROOMTYPE.Enter
        Try
            If cmbhotelname.Text.Trim <> "" And gridDoubleClick = False Then FILLROOMTYPE()
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

    Private Sub CMBROOMTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBROOMTYPE.Validating
        Try
            If CMBROOMTYPE.Text.Trim <> "" And cmbhotelname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" HOTELMASTER_ROOMDESC.HOTEL_RATE as ROOMRATE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND ROOMTYPEMASTER.ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                If DT.Rows.Count > 0 And gridDoubleClick = False Then
                    If ClientName = "TOPCOMM" Then
                        TXTRATE.Text = DT.Rows(0).Item("ROOMRATE")
                    Else
                        TXTPURAMT.Text = Format((DT.Rows(0).Item("ROOMRATE") * (TXTTOTALNIGHTS.Text.Trim)), "0.00")
                    End If
                    PURCHASETOTAL()
                End If
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

    Private Sub TXTAGENTCOMMPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTCOMMPER.KeyPress
        numdotkeypress(e, TXTAGENTCOMMPER, Me)
    End Sub

    Private Sub TXTAGENTCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTCOMMPER.Validated
        Try
            If CMBAGENTNAME.Text.Trim <> "" Then total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAGENTCOMMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTCOMMRS.KeyPress
        numdotkeypress(e, TXTAGENTCOMMRS, Me)
    End Sub

    Private Sub TXTAGENTCOMMRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTCOMMRS.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTAGENTTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTTDSPER.KeyPress
        numdotkeypress(e, TXTAGENTTDSPER, Me)
    End Sub

    Private Sub TXTAGENTTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTTDSPER.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTAGENTTDSRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAGENTTDSRS.KeyPress
        numdotkeypress(e, TXTAGENTTDSRS, Me)
    End Sub

    Private Sub TXTAGENTTDSRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTAGENTTDSRS.Validated
        If CMBAGENTNAME.Text.Trim <> "" Then total()
    End Sub

    Private Sub TXTOURCOMMPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMPER.KeyPress
        numdotkeypress(e, TXTOURCOMMPER, Me)
    End Sub

    Private Sub TXTOURCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMPER.Validated
        total()
    End Sub

    Private Sub TXTOURCOMMRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOURCOMMRS.KeyPress
        numdotkeypress(e, TXTOURCOMMRS, Me)
    End Sub

    Private Sub TXTOURCOMMRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTOURCOMMRS.Validated
        total()
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

    Private Sub TXTCOMMRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDPER.KeyPress
        numdotkeypress(e, TXTCOMMRECDPER, Me)
    End Sub

    Private Sub TXTCOMMRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTCOMMRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMMRECDRS.KeyPress
        numdotkeypress(e, TXTCOMMRECDRS, Me)
    End Sub

    Private Sub TXTCOMMRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOMMRECDRS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTDISCRECDPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDPER.KeyPress
        numdotkeypress(e, TXTDISCRECDPER, Me)
    End Sub

    Private Sub TXTDISCRECDPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTDISCRECDRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISCRECDRS.KeyPress
        numdotkeypress(e, TXTDISCRECDRS, Me)
    End Sub

    Private Sub TXTDISCRECDRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDISCRECDRS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTNCCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNCCHILDS.KeyPress
        numkeypress(e, TXTNCCHILDS, Me)
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMT.KeyPress
        numdotkeypress(e, TXTPURAMT, Me)
    End Sub

    Private Sub TXTPURAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURAMT.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        numdotkeypress(e, TXTPUROTHERCHGS, Me)
    End Sub

    Private Sub TXTPUROTHERCHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUROTHERCHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURROUNDOFF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURROUNDOFF.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTAX.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub CMBPURTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Enter
        Try
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURTAX.Validating
        Try
            If CMBPURTAX.Text.Trim <> "" Then TAXvalidate(CMBPURTAX, e, Me)
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTPURTDSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSPER.KeyPress
        numdotkeypress(e, TXTPURTDSPER, Me)
    End Sub

    Private Sub TXTPURTDSPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURTDSRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTDSRS.KeyPress
        numdotkeypress(e, TXTPURTDSRS, Me)
    End Sub

    Private Sub TXTPURTDSRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURTDSRS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub btnselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectpo.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            clear()
            Dim objselectpoamend As New SelectHotelBooking_Amd
            objselectpoamend.FRMSTRING = FRMSTRING
            objselectpoamend.ShowDialog()

            If dt_amd.Rows.Count > 0 Then
                chkchange.Checked = True
                For Each dr As DataRow In dt_amd.Rows  'this for loop is basically for to fill detail grid
                    BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                    CMBBOOKINGTYPE.Text = dr("BOOKINGTYPE")
                    CMBGUESTNAME.Text = dr("GUESTNAME")
                    txtmobileno.Text = dr("MOBILENO")
                    txtemailadd.Text = dr("EMAILADD")
                    TXTGUESTADD.Text = dr("GUESTADD")
                    txthoteladd.Text = dr("HOTELADD")
                    TXTPURADD.Text = dr("PURADD")
                    TXTADD.Text = dr("SALEADD")
                    txtrefno.Text = dr("REFNO")

                    cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                    cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                    CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                    CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))

                    CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                    CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                    ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                    DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                    CMBARRFROM.Text = Convert.ToString(dr("ARRFROM"))
                    CMBDEPARTTO.Text = Convert.ToString(dr("DEPARTTO"))

                    txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                    txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))

                    TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                    TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))


                    'PURCHASE VALUES
                    TXTPURAMT.Text = dr("PURAMT")
                    TXTDISCRECDPER.Text = dr("DISCRECDPER")
                    TXTDISCRECDRS.Text = dr("DISCRECDRS")
                    TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                    TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                    TXTPURTDSPER.Text = dr("PURTDSPER")
                    TXTPURTDSRS.Text = dr("PURTDSRS")
                    CMBPURTAX.Text = dr("PURTAXNAME")
                    TXTPURTAX.Text = dr("PURTAX")

                    CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                    TXTPURADDTAX.Text = dr("PURADDTAX")

                    CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                    If dr("PUROTHERCHGS") > 0 Then
                        TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                        CMBPURADDSUB.Text = "Add"
                    Else
                        TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                        CMBPURADDSUB.Text = "Sub."
                    End If

                    TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                    TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                    CMBBOOKEDBY.Text = dr("BOOKEDBY")
                    CMBSOURCE.Text = dr("SOURCE")
                    CMBAGENTNAME.Text = dr("AGENTNAME")

                    TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                    TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                    TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                    TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                    TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                    TXTOURCOMMPER.Text = dr("OURCOMMPER")
                    TXTOURCOMMRS.Text = dr("OURCOMMRS")

                    TXTDISCPER.Text = dr("DISCPER")
                    TXTDISCRS.Text = dr("DISCRS")

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
                    TXTDP.Text = dr("DP")

                    txtremarks.Text = Convert.ToString(dr("REMARKS"))
                    TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))

                    TXTPURAMTPAID.Text = dr("PURAMTPAID")
                    TXTPUREXTRAAMT.Text = dr("PUREXTRAAMT")
                    TXTPURRETURN.Text = dr("PURRETURN")
                    TXTPURBAL.Text = dr("PURBAL")

                    TXTSALEAMTREC.Text = dr("SALEAMTREC")
                    TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                    TXTSALERETURN.Text = dr("SALERETURN")
                    TXTSALEBAL.Text = dr("SALEBAL")


                    If dr("DONE").ToString = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If

                    If dr("CANCELLED").ToString = True Then
                        lblcancelled.Visible = True
                        PBCancelled.Visible = True
                    End If

                    If dr("AMDDONE").ToString = True Then
                        TXTAMDNO.Text = dr("AMDNO").ToString()
                        TXTAMDREMARKS.Text = dr("AMDREMARKS").ToString()
                        btnselectpo.Enabled = False
                        lblamd.Visible = True
                    End If

                    TXTBOOKING_AMD.Text = Convert.ToString(dr("BOOKINGNO"))
                    TXTAMDNO.Text = Convert.ToString(dr("AMDNO"))


                    GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), dr("EXTRAADULTRATE"), dr("EXTRACHILDS"), dr("EXTRACHILDRATE"), dr("NOOFROOMS").ToString, "", dr("PACKAGE"), Format(dr("RATE"), "0.00"), Format(dr("amt"), "0.00"))


                Next
                GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1


                'GET GRIDPUR DATA
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search("  PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ADULTS AS ADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CHILDS AS CHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NCCHILDS AS NCCHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTS AS EXTRAADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTRATE AS EXTRAADULTRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILD AS EXTRACHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILDRATE AS EXTRACHILDRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NOOFROOMS AS NOOFROOMS, CASE WHEN BOOKING_PACKAGE = 'TRUE' THEN 'Yes' ELSE 'No' END AS PACKAGE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_RATE AS RATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT", "", " PROFORMAHOTELBOOKINGMASTER INNER JOIN PROFORMAHOTELBOOKINGMASTER_PURDESC ON PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NO AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID INNER JOIN ROOMTYPEMASTER ON PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = " & Val(TXTBOOKING_AMD.Text.Trim) & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("ROOMTYPE").ToString, DR("ADULTS").ToString, DR("CHILDS").ToString, DR("NCCHILDS").ToString, DR("EXTRAADULTS"), Format(DR("EXTRAADULTRATE"), "0.00"), DR("EXTRACHILDS"), Format(DR("EXTRACHILDRATE"), "0.00"), DR("NOOFROOMS").ToString, DR("PACKAGE"), Format(DR("RATE"), "0.00"), Format(DR("amt"), "0.00"))
                    Next
                End If

                PURCHASETOTAL()

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbaddtax_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
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

    Private Sub CMBPURADDTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURADDTAX.Enter
        Try
            If CMBPURADDTAX.Text.Trim = "" Then filltax(CMBPURADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURADDTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPURADDTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURADDTAX.Validating
        Try
            If CMBPURADDTAX.Text.Trim <> "" Then TAXvalidate(CMBPURADDTAX, e, Me)
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Enter
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

    Private Sub PBDICSRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDICSRECDDEL.Click
        Try
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBCOMMRECDDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCOMMRECDDEL.Click
        Try
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBPURTDSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBPURTDSDEL.Click
        Try
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBAGENTCOMMDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAGENTCOMMDEL.Click
        Try
            TXTAGENTCOMMPER.Text = 0.0
            TXTAGENTCOMMRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBAGENTTDSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAGENTTDSDEL.Click
        Try
            TXTAGENTTDSPER.Text = 0.0
            TXTAGENTTDSRS.Text = 0.0
            total()
        Catch ex As Exception
            Throw ex
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

    Private Sub TXTDP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDP.KeyPress
        numdotkeypress(e, TXTDP, Me)
    End Sub

    Private Sub txtmobileno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobileno.KeyPress
        numkeypress(e, txtmobileno, Me)
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

    Private Sub CMBPURCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURCODE.Validated
        Try
            'If CMBPURCODE.Text.Trim <> "" Then GETBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURCODE.Validating
        Try
            If CMBPURCODE.Text.Trim <> "" Then ACCCODEVALIDATE(CMBPURCODE, CMBPURNAME, e, Me, TXTPURADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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

    Private Sub CMBPURNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTPURSTATECODE.Text = DT.Rows(0).Item("PURSTATECODE")
                End If
                GETBALANCE()
                GETHSNCODE()
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

    Private Sub ToolStripprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPBOOKINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try

            If CMBPRINT.Text = "" Or CMBPRINT.Text = "All" Then
                Dim TEMPMSG As Integer
                Dim OBJVOUCHER As New ProformaHotelDesign
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.BOOKINGNO = BOOKNO
                OBJVOUCHER.BOOKTYPE = FRMSTRING
                If ClientName = "TOPCOMM" Then
                    OBJVOUCHER.SUBJECT = "Travelite Voucher BS-" & BOOKNO & " - " & cmbhotelname.Text.Trim
                    TEMPMSG = MsgBox("Print On Letter Head?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        OBJVOUCHER.LETTERHEAD = 1
                    Else
                        TEMPMSG = MsgBox("Print MTDC Voucher?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then OBJVOUCHER.MTDC = True
                    End If
                End If
                OBJVOUCHER.HIDEHEADER = False
                OBJVOUCHER.FRMSTRING = "VOUCHER"
                OBJVOUCHER.Show()


                TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJINV As New ProformaHotelDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    OBJINV.GUESTNAME = CMBGUESTNAME.Text.Trim
                    OBJINV.BOOKTYPE = FRMSTRING
                    OBJINV.PRINTGUESTNAME = chkguestname.CheckState
                    OBJINV.HIDEAMT = chkhideamt.CheckState
                    OBJINV.PRINTST = CHKSTPRINT.CheckState
                    OBJINV.FRMSTRING = "INVOICE"
                    OBJINV.Show()
                End If

            ElseIf CMBPRINT.Text = "Voucher" Then
                Dim TEMPMSG As Integer
                Dim OBJVOUCHER As New ProformaHotelDesign
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.BOOKINGNO = BOOKNO
                OBJVOUCHER.BOOKTYPE = FRMSTRING
                If ClientName = "TOPCOMM" Then
                    OBJVOUCHER.SUBJECT = "Travelite Voucher BS-" & BOOKNO & " - " & cmbhotelname.Text.Trim
                    TEMPMSG = MsgBox("Print On Letter Head?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        OBJVOUCHER.LETTERHEAD = 1
                    Else
                        TEMPMSG = MsgBox("Print MTDC Voucher?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then OBJVOUCHER.MTDC = True
                    End If
                End If
                OBJVOUCHER.HIDEHEADER = False
                OBJVOUCHER.FRMSTRING = "VOUCHER"
                OBJVOUCHER.Show()


            ElseIf CMBPRINT.Text = "Invoice" Then

                Dim OBJINV As New ProformaHotelDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.BOOKTYPE = FRMSTRING
                OBJINV.PRINTGUESTNAME = chkguestname.CheckState
                OBJINV.HIDEAMT = chkhideamt.CheckState
                OBJINV.PRINTST = CHKSTPRINT.CheckState
                OBJINV.FRMSTRING = "INVOICE"
                OBJINV.Show()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
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
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "INDIRECT EXPENSES")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPUROTHERCHGS.Enter
        Try
            If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPUROTHERCHGS.Validating
        Try
            If CMBPUROTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "INDIRECT EXPENSES")
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

    Private Sub GRIDPUR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPUR.CellValidating
        Try
            Dim colNum As Integer = GRIDPUR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPUREXTRAADULTRATE.Index, GPUREXTRACHILDRATE.Index, GPURRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPUR.CurrentCell.Value = Nothing Then GRIDPUR.CurrentCell.Value = "0.00"
                        GRIDPUR.CurrentCell.Value = Convert.ToDecimal(GRIDPUR.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        PURCHASETOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then

                'dont allow user TO DFELETE IN GRIDPUR
                MessageBox.Show("You Cannot Delete This Row, Delete from Booking Tab")
                Exit Sub

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUREXTRACHGS.KeyPress
        Try
            numdotkeypress(e, TXTPUREXTRACHGS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUREXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUREXTRACHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTEXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdotkeypress(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub TXTEXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        total()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            If FRMSTRING = "TRANSFER" Then
                OBJRECPAY.PURBILLINITIALS = "TP-" & TEMPBOOKINGNO
                OBJRECPAY.SALEBILLINITIALS = "TS-" & TEMPBOOKINGNO
            Else
                OBJRECPAY.PURBILLINITIALS = "P-" & TEMPBOOKINGNO
                OBJRECPAY.SALEBILLINITIALS = "S-" & TEMPBOOKINGNO
            End If
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        Try
            numkeypress(e, TXTCOPY, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If edit = True Then
                MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TXTCOPY.Text.Trim <> "" Then
                TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    chkmobile.CheckState = CheckState.Unchecked
                    CHKEMAIL.CheckState = CheckState.Unchecked

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJBOOKING As New ClsProformaHotelBookingMaster()

                    ALPARAVAL.Add(FRMSTRING)
                    ALPARAVAL.Add(TXTCOPY.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows

                            TXTSTATECODE.Text = dr("STATECODE")
                            TXTPURSTATECODE.Text = dr("PURSTATECODE")
                            CMBHSNITEMDESC.Text = dr("ITEMDESC")
                            BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                            CHKBOOKINGDATE.Checked = Convert.ToBoolean(dr("ENTRYDATEASBOOKINGDATE"))
                            CMBBOOKINGTYPE.Text = dr("BOOKINGTYPE")
                            CMBGUESTNAME.Text = dr("GUESTNAME")
                            txtmobileno.Text = dr("MOBILENO")
                            txtemailadd.Text = dr("EMAILADD")
                            TXTGUESTADD.Text = dr("GUESTADD")
                            txthoteladd.Text = dr("HOTELADD")
                            TXTPURADD.Text = dr("PURADD")
                            TXTADD.Text = dr("SALEADD")
                            txtrefno.Text = dr("REFNO")

                            cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                            cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                            FILLROOMTYPE()


                            CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                            CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))

                            CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                            CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                            ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                            DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                            CMBARRFROM.Text = Convert.ToString(dr("ARRFROM"))
                            CMBDEPARTTO.Text = Convert.ToString(dr("DEPARTTO"))

                            txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                            txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))

                            TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                            TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))


                            'PURCHASE VALUES
                            TXTPURAMT.Text = dr("PURAMT")
                            TXTDISCRECDPER.Text = dr("DISCRECDPER")
                            TXTDISCRECDRS.Text = dr("DISCRECDRS")
                            TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                            TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                            TXTPURTDSPER.Text = dr("PURTDSPER")
                            TXTPURTDSRS.Text = dr("PURTDSRS")
                            TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                            CMBPURTAX.Text = dr("PURTAXNAME")
                            TXTPURTAX.Text = dr("PURTAX")

                            CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                            TXTPURADDTAX.Text = dr("PURADDTAX")

                            CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                            If dr("PUROTHERCHGS") > 0 Then
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                                CMBPURADDSUB.Text = "Add"
                            Else
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                                CMBPURADDSUB.Text = "Sub."
                            End If

                            TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                            TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                            CMBBOOKEDBY.Text = dr("BOOKEDBY")
                            CMBSOURCE.Text = dr("SOURCE")
                            CMBAGENTNAME.Text = dr("AGENTNAME")

                            TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                            TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                            TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                            TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                            TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                            TXTOURCOMMPER.Text = dr("OURCOMMPER")
                            TXTOURCOMMRS.Text = dr("OURCOMMRS")

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
                            TXTDP.Text = dr("DP")

                            txtremarks.Text = Convert.ToString(dr("REMARKS"))
                            TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))

                            TXTPURAMTPAID.Text = 0
                            TXTPUREXTRAAMT.Text = 0
                            TXTPURRETURN.Text = 0
                            TXTPURBAL.Text = 0

                            TXTSALEAMTREC.Text = 0
                            TXTSALEEXTRAAMT.Text = 0
                            TXTSALERETURN.Text = 0
                            TXTSALEBAL.Text = 0

                            TXTBAL.Text = 0

                            txtremarks.Text = dr("REMARKS")
                            TXTBOOKINGDESC.Text = dr("BOOKINGDESC")
                            TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                            TXTPICKUP.Text = dr("PICKUPDETAILS")


                            If dr("DONE").ToString = True Then
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If

                            If dr("AMDDONE").ToString = True Then
                                TXTAMDNO.Text = dr("AMDNO").ToString()
                                TXTAMDREMARKS.Text = dr("AMDREMARKS").ToString()
                                btnselectpo.Enabled = False
                                lblamd.Visible = True
                            End If
                            TXTAMDNO.Text = dr("AMDNO").ToString()


                            If Convert.ToBoolean(dr("CANCELLED")) = True Then
                                lblcancelled.Visible = True
                                PBCancelled.Visible = True
                            End If

                            chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                            CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                            CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                            CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))

                            TXTHSNCODE.Text = dr("HSNCODE")
                            If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                            TXTCGSTPER.Text = dr("CGSTPER")
                            TXTCGSTAMT.Text = dr("CGSTAMT")
                            TXTSGSTPER.Text = dr("SGSTPER")
                            TXTSGSTAMT.Text = dr("SGSTAMT")
                            TXTIGSTPER.Text = dr("IGSTPER")
                            TXTIGSTAMT.Text = dr("IGSTAMT")

                            If CHKMANUAL.Checked = True Then
                                TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")

                            End If

                            CHKPURSERVTAX.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                            TXTPURCOMMPER.Text = dr("PUROURCOMMPER")
                            If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                            TXTPURHSNCODE.Text = dr("PURHSNCODE")
                            TXTPURCGSTPER.Text = dr("PURCGSTPER")
                            TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                            TXTPURSGSTPER.Text = dr("PURSGSTPER")
                            TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                            TXTPURIGSTPER.Text = dr("PURIGSTPER")
                            TXTPURIGSTAMT.Text = dr("PURIGSTAMT")

                            If CHKPURMANUAL.Checked = True Then
                                TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                                TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                                TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                            End If


                            TXTCONFIRMEDBY.Text = dr("CONFIRMEDBY")
                            TXTCONFIRMATIONNO.Text = dr("CONFIRMATIONNO")



                            GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), dr("CURCODE"), Format(dr("ROE"), "0.00"), Format(dr("amt"), "0.00"))

                        Next
                        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                        'GET GRIDPUR DATA
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search("  PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ADULTS AS ADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CHILDS AS CHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NCCHILDS AS NCCHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTS AS EXTRAADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTRATE AS EXTRAADULTRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILD AS EXTRACHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILDRATE AS EXTRACHILDRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NOOFROOMS AS NOOFROOMS, CASE WHEN BOOKING_PACKAGE = 'TRUE' THEN 'Yes' ELSE 'No' END AS PACKAGE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_RATE AS RATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT", "", " PROFORMAHOTELBOOKINGMASTER INNER JOIN PROFORMAHOTELBOOKINGMASTER_PURDESC ON PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NO AND PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_BOOKTYPE AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID INNER JOIN ROOMTYPEMASTER ON PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = " & Val(TXTCOPY.Text.Trim) & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DR As DataRow In dttable.Rows
                                GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("ROOMTYPE").ToString, DR("ADULTS").ToString, DR("CHILDS").ToString, DR("NCCHILDS").ToString, DR("EXTRAADULTS"), Format(DR("EXTRAADULTRATE"), "0.00"), DR("EXTRACHILDS"), Format(DR("EXTRACHILDRATE"), "0.00"), DR("NOOFROOMS").ToString, DR("PACKAGE"), Format(DR("RATE"), "0.00"), Format(DR("amt"), "0.00"))
                            Next
                        End If


                        PURCHASETOTAL()
                    End If
                Else
                    MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub ARRIVALDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ARRIVALDATE.Validated
        Try
            If DEPARTDATE.Value.Date > ARRIVALDATE.Value.Date Then
                TXTTOTALNIGHTS.Text = DEPARTDATE.Value.Date.Subtract(ARRIVALDATE.Value.Date).Days
                PURCHASETOTAL()
                'ElseIf DEPARTDATE.Value.Date = ARRIVALDATE.Value.Date And (ClientName = "ELYSIUM" Or ClientName = "ESSGEE") Then
                '    TXTTOTALNIGHTS.Text = 1
                '    PURCHASETOTAL()
            ElseIf DEPARTDATE.Value.Date = ARRIVALDATE.Value.Date Then
                TXTTOTALNIGHTS.Text = 1
                PURCHASETOTAL()
            Else
                'MsgBox("Select Proper Dates", MsgBoxStyle.Critical)
                'ARRIVALDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ARRIVALDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ARRIVALDATE.Validating
        'AS PER ASHOK BHAI REQ
        'If ClientName <> "CLASSIC" Then
        '    If Not datecheck(ARRIVALDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        '    If edit = False Then DEPARTDATE.Value = DateAdd(DateInterval.Day, 1, ARRIVALDATE.Value)
        'End If
    End Sub

    Private Sub DEPARTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEPARTDATE.Validating
        'DONE TEMPORARILY
        'If ClientName = "CLASSIC" Then
        '    If Not datecheck(DEPARTDATE.Value) Then
        '        MsgBox("Date Not in Current Accounting Year")
        '        e.Cancel = True
        '    End If
        'End If
    End Sub


    Private Sub HotelBookings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                CHKREFUNDED.Visible = True
                CHKFAILED.Visible = True
            End If

            If ClientName <> "AIRTRINITY" Then
                CMBCURCODE.Visible = False
                GCURCODE.Visible = False
                TXTROE.Visible = False
                GROE.Visible = False
                TXTTOTAL.Left = Val(TXTTOTAL.Left) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
                GRIDBOOKINGS.Width = Val(GRIDBOOKINGS.Width) - Val(CMBCURCODE.Width) - Val(TXTROE.Width)
            End If

            'NOW ENABLE FOR ALL AS PER GST
            'If (ClientName = "SSR" Or ClientName = "CLASSIC" Or ClientName = "HBAZAAR" Or ClientName = "KHANNA" Or ClientName = "MAHARAJA" Or ClientName = "AERO" Or ClientName = "URMI") Then
            CHKTAXSERVCHGS.Visible = True
            LBLCOMM.Text = "Service Chgs"
            TXTOURCOMMRS.BackColor = Color.White
            TXTOURCOMMRS.ReadOnly = False
            TXTOURCOMMRS.TabStop = True
            'End If

            'If ClientName = "CLASSIC" Or ClientName = "KHANNA" Or ClientName = "MAHARAJA" Or ClientName = "AERO" Or ClientName = "URMI" Then
            LBLOURCOMM.Visible = True
            TXTOURCOMM.Visible = True
            'End If

            If ClientName = "CLASSIC" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(USERPOINTS,0) AS USERPOINTS, ISNULL(REFPOINTS,0) AS REFPOINTS", "", "POINTS", "")
                If DT.Rows.Count > 0 Then
                    TXTUSERPOINTS.Text = Val(DT.Rows(0).Item("USERPOINTS"))
                    TXTREFPOINTS.Text = Val(DT.Rows(0).Item("REFPOINTS"))
                End If
            End If

            If ClientName = "PRIYA" Then
                TXTPURROUNDOFF.ReadOnly = False
                TXTPURROUNDOFF.TabStop = True
            End If

            If ClientName = "GLOBAL" Then
                CHKMANUAL.Visible = False
                LBLCGST.Visible = False
                TXTCGSTPER.Visible = False
                TXTCGSTAMT.Visible = False
                LBLSGST.Visible = False
                TXTSGSTPER.Visible = False
                TXTSGSTAMT.Visible = False
                LBLIGST.Visible = False
                TXTIGSTPER.Visible = False
                TXTIGSTAMT.Visible = False
                TXTPURSTATECODE.Visible = False
                LBLPURHSNDESC.Visible = False
                CMBPURITEMDESC.Visible = False
                LBLPURHSNCODE.Visible = False
                TXTPURHSNCODE.Visible = False
                LBLHSNITEMDESC.Visible = False
                CMBHSNITEMDESC.Visible = False
                LBLHSNCODE.Visible = False
                TXTHSNCODE.Visible = False
                LBLSTATECODE.Visible = False
                TXTSTATECODE.Visible = False
                CHKPURMANUAL.Visible = False
                LBLPURCGST.Visible = False
                TXTPURCGSTPER.Visible = False
                TXTPURCGSTAMT.Visible = False
                LBLPURSGST.Visible = False
                TXTPURSGSTPER.Visible = False
                TXTPURSGSTAMT.Visible = False
                LBLPURIGST.Visible = False
                TXTPURIGSTPER.Visible = False
                TXTPURIGSTAMT.Visible = False
                CHKPURMANUAL.Visible = False
                LBLPURCGST.Visible = False
                TXTPURCGSTPER.Visible = False
                TXTPURCGSTAMT.Visible = False
                LBLPURSGST.Visible = False
                TXTPURSGSTAMT.Visible = False
                TXTPURSGSTPER.Visible = False
                LBLPURIGST.Visible = False
                TXTPURIGSTPER.Visible = False
                TXTPURIGSTAMT.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNOTES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNOTES.Enter
        Try
            If CMBNOTES.Text.Trim = "" Then FILLNOTE(CMBNOTES, edit)
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
            If CMBCANCEL.Text.Trim = "" Then FILLPOLICY(CMBCANCEL, edit)
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

    Private Sub TXTARRFLIGHTNO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTARRFLIGHTNO.Validated
        Try
            If TXTARRFLIGHTNO.Text.Trim <> "" Then TXTPICKUP.Text = TXTPICKUP.Text & " ARRIVAL FROM " & TXTARRFLIGHTNO.Text.Trim & " FOR " & Val(TXTTOTALPAX.Text.Trim) & " PAX."
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\HOTEL\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
                txtimgpath.Text = PBSoftCopy.ImageLocation
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDEPARTFLIGHTNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDEPARTFLIGHTNO.Validated
        Try
            If TXTDEPARTFLIGHTNO.Text.Trim <> "" Then TXTPICKUP.Text = TXTPICKUP.Text & " DEPARTURE FROM " & TXTARRFLIGHTNO.Text.Trim & " FOR " & Val(TXTTOTALPAX.Text.Trim) & " PAX."
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADULTS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTADULTS.Validated
        Try
            If CMBPLAN.Text.Trim = "" And Val(TXTADULTS.Text.Trim) = 0 Then CMBBOOKEDBY.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then If Val(DT.Rows(0).Item("TAX")) = 0 Then txttax.ReadOnly = False
            Else
                txttax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Validated
        Try
            If CMBPURTAX.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        TXTPURTAX.ReadOnly = False
                        TXTPURTAX.Enabled = True
                    End If
                End If
            Else
                TXTPURTAX.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURADDTAX.Validated
        Try
            If CMBPURADDTAX.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        TXTPURADDTAX.ReadOnly = False
                        TXTPURADDTAX.Enabled = True
                    End If
                End If
            Else
                TXTPURADDTAX.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbookingno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookingno.Validating
        Try
            If (ClientName = "CLASSIC" And UserName = "ADMIN") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_NO AS BOOKINGNO ", "", " PROFORMAHOTELBOOKINGMASTER", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = '" & txtbookingno.Text.Trim & "' and PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE='" & FRMSTRING & "' AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID=" & CmpId & " and PROFORMAHOTELBOOKINGMASTER.BOOKING_locationid=" & Locationid & " and PROFORMAHOTELBOOKINGMASTER.BOOKING_yearid=" & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        txtbookingno.Focus()
                    End If

                    If Val(txtbookingno.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.Validated
        total()
    End Sub

    Private Sub TXTPURADDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURADDTAX.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURTAX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURTAX.KeyPress
        numdotkeypress(e, TXTPURTAX, Me)
    End Sub

    Private Sub TXTSALEMOBILE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSALEMOBILE.Validating
        Try
            If TXTSALEMOBILE.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ACC_cmpname ", "", " LEDGERS", " AND ACC_mobile LIKE '%" & TXTSALEMOBILE.Text.Trim & "%' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBNAME.Text = DT.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        total()
    End Sub

    Private Sub TOOLSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLSMS.Click
        If edit = False Then Exit Sub
        SMSCODE()
    End Sub

    Sub SMSCODE()
        If ALLOWSMS = True And txtmobileno.Text.Trim <> "" Then
            If SENDMSG("Dear " & CMBPREFIX.Text.Trim & " " & CMBGUESTNAME.Text.Trim & ", Your booking for " & cmbhotelname.Text.Trim & " is Confirmed. Booking No S-" & Val(TEMPBOOKINGNO) & ", Check In " & Format(ARRIVALDATE.Value.Date, "dd/MM/yyyy") & ", Check Out " & Format(DEPARTDATE.Value.Date, "dd/MM/yyyy") & ", Room Type " & GRIDBOOKINGS.Item(groomtype.Index, 0).Value & ", No Of Rooms " & Val(GRIDBOOKINGS.Item(gnoofRooms.Index, 0).Value) & ", Total Pax " & Val(TXTTOTALPAX.Text.Trim), txtmobileno.Text.Trim) = "1701" Then MsgBox("Message Sent") Else MsgBox("Error Sending Message")
        End If
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

    Private Sub TXTROE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTROE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        total()
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNITEMDESC As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_ITEMDESC, '') AS HSNITEMDESC ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNITEMDESC"
                CMBHSNITEMDESC.DataSource = dt
                CMBHSNITEMDESC.DisplayMember = "HSNITEMDESC"
            End If
            CMBHSNITEMDESC.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub
            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "01/07/2017" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()
                End If


                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If


                    If CMBPURITEMDESC.Text.Trim <> "" Then
                        If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                            TXTPURHSNCODE.Clear()
                            TXTPURCGSTPER.Clear()
                            TXTPURCGSTAMT.Clear()
                            TXTPURSGSTPER.Clear()
                            TXTPURSGSTAMT.Clear()
                            TXTPURIGSTPER.Clear()
                            TXTPURIGSTAMT.Clear()
                        End If
                        'Dim OBJCMN As New ClsCommon
                        Dim DT1 As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                        If DT.Rows.Count > 0 Then
                            TXTPURHSNCODE.Text = DT1.Rows(0).Item("PURHSNCODE")

                            If CMBPURNAME.Text.Trim <> "" Then
                                If TXTPURSTATECODE.Text.Trim = CMPSTATECODE Then
                                    TXTPURIGSTPER.Text = 0
                                    TXTPURCGSTPER.Text = Val(DT1.Rows(0).Item("PURCGSTPER"))
                                    TXTPURSGSTPER.Text = Val(DT1.Rows(0).Item("PURSGSTPER"))
                                Else
                                    TXTPURCGSTPER.Text = 0
                                    TXTPURSGSTPER.Text = 0
                                    TXTPURIGSTPER.Text = Val(DT1.Rows(0).Item("PURIGSTPER"))
                                End If
                            End If
                        End If
                    End If
                End If
                total()
                PURCHASETOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        Try

            TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub
            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "07/01/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If CMBNAME.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If

                    '    If CMBPURNAME.Text.Trim <> "" Then
                    '        If TXTPURSTATECODE.Text.Trim = CMPSTATECODE Then
                    '            TXTPURIGSTPER.Text = 0
                    '            TXTPURCGSTPER.Text = Val(DT.Rows(0).Item("PURCGSTPER"))
                    '            TXTPURSGSTPER.Text = Val(DT.Rows(0).Item("PURSGSTPER"))
                    '        Else
                    '            TXTPURCGSTPER.Text = 0
                    '            TXTPURSGSTPER.Text = 0
                    '            TXTPURIGSTPER.Text = Val(DT.Rows(0).Item("PURIGSTPER"))
                    '        End If
                    '    End If
                End If
                total()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBHSNITEMDESC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNITEMDESC.Validating
    '    Try
    '        If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CHKPURSERVTAX_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKPURSERVTAX.CheckedChanged
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPURCOMMPER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCOMMPER.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub CMBPURITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURITEMDESC.Validated
        Try

            TXTPURHSNCODE.Clear()
            TXTPURCGSTPER.Clear()
            TXTPURCGSTAMT.Clear()
            TXTPURSGSTPER.Clear()
            TXTPURSGSTAMT.Clear()
            TXTPURIGSTPER.Clear()
            TXTPURIGSTAMT.Clear()

            'If CMBPURITEMDESC.Text.Trim <> "" And Convert.ToDateTime(bookingdate.Text).Date >= "01/07/2017" Then
            If CMBPURITEMDESC.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTPURHSNCODE.Text = DT.Rows(0).Item("PURHSNCODE")
                    If CMBPURNAME.Text.Trim <> "" Then
                        If TXTPURSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTPURIGSTPER.Text = 0
                            TXTPURCGSTPER.Text = Val(DT.Rows(0).Item("PURCGSTPER"))
                            TXTPURSGSTPER.Text = Val(DT.Rows(0).Item("PURSGSTPER"))
                        Else
                            TXTPURCGSTPER.Text = 0
                            TXTPURSGSTPER.Text = 0
                            TXTPURIGSTPER.Text = Val(DT.Rows(0).Item("PURIGSTPER"))
                        End If
                    End If
                End If
                PURCHASETOTAL()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKPURMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURMANUAL.CheckedChanged
        Try
            If CHKPURMANUAL.Checked = True Then
                TXTPURCGSTAMT.ReadOnly = False
                TXTPURCGSTAMT.TabStop = True
                TXTPURCGSTAMT.BackColor = Color.LemonChiffon
                TXTPURSGSTAMT.ReadOnly = False
                TXTPURSGSTAMT.TabStop = True
                TXTPURSGSTAMT.BackColor = Color.LemonChiffon
                TXTPURIGSTAMT.ReadOnly = False
                TXTPURIGSTAMT.TabStop = True
                TXTPURIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTPURCGSTAMT.ReadOnly = True
                TXTPURCGSTAMT.TabStop = False
                TXTPURCGSTAMT.BackColor = Color.Linen
                TXTPURSGSTAMT.ReadOnly = True
                TXTPURSGSTAMT.TabStop = False
                TXTPURSGSTAMT.BackColor = Color.Linen
                TXTPURIGSTAMT.ReadOnly = True
                TXTPURIGSTAMT.TabStop = False
                TXTPURIGSTAMT.BackColor = Color.Linen
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTPURCGSTAMT.KeyPress, TXTPURSGSTAMT.KeyPress, TXTPURIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        CALC()
        total()
    End Sub

    Private Sub CMDSELECTENQ_Click(sender As Object, e As EventArgs) Handles CMDSELECTENQ.Click
        Try

            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBHSNITEMDESC.Text.Trim = "" Or TXTHSNCODE.Text.Trim = "" Then
                MsgBox("Please Enter HSN Code First", MsgBoxStyle.Critical)
                CMBHSNITEMDESC.Focus()
                Exit Sub
            End If


            'WE WILL FETCH QUOTATION HERE
            SELECTENQ.Clear()
            Dim OBJHOTELENQ As New SelectHotelEnq
            OBJHOTELENQ.ShowDialog()
            SELECTENQ = OBJHOTELENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then

                'GET ALL DATA FROM HOTELENQ
                Dim OBJENQ As New ClsHotelEnqMaster
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(SELECTENQ.Rows(0).Item("ENQNO"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJENQ.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJENQ.SELECTENQ
                If DT.Rows.Count > 0 Then
                    chkchange.CheckState = CheckState.Checked
                    For Each dr As DataRow In DT.Rows

                        TXTENQNO.Text = SELECTENQ.Rows(0).Item("ENQNO")
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

                        TXTCONFIRMATIONNO.Text = dr("CONFNO")
                        TXTCONFIRMEDBY.Text = dr("CONFBY")
                        CMBBOOKEDBY.Text = dr("BOOKEDBY")

                        CMBNOTES.Text = dr("NOTENAME")
                        TXTNOTES.Text = dr("NOTE")
                        CMBCANCEL.Text = dr("POLICYNAME")
                        TXTPOLICY.Text = dr("POLICY")

                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), dr("CURCODE"), Format(dr("ROE"), "0.00"), Format(dr("amt"), "0.00"))


                        'ADD IN GRIDPUR ALSO
                        'GET DEFAULT PUR RATE FROM HOTELMASTER WITH RESPECT TO ROOMTYPE
                        Dim TPURRATE As Double = 0.0
                        If ClientName <> "TOPCOMM" Then
                            If CMBROOMTYPE.Text.Trim <> "" And cmbhotelname.Text.Trim <> "" Then
                                Dim OBJCMN As New ClsCommon
                                DT = OBJCMN.search(" HOTELMASTER_ROOMDESC.HOTEL_RATE as ROOMRATE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND ROOMTYPEMASTER.ROOMTYPE_NAME = '" & CMBROOMTYPE.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
                                If DT.Rows.Count > 0 Then
                                    TPURRATE = Format((DT.Rows(0).Item("ROOMRATE") * (TXTTOTALNIGHTS.Text.Trim)), "0.00")
                                End If
                            End If
                        End If
                        GRIDPUR.Rows.Add(dr("GRIDSRNO"), dr("ROOMTYPE").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("PACKAGE"), Format(Val(TPURRATE), "0.00"), 0)



                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    total()
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub BOOKINGDATE_Validating(sender As Object, e As CancelEventArgs) Handles BOOKINGDATE.Validating
        Try
            If BOOKINGDATE.Text <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(BOOKINGDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BOOKINGDATE_Validated(sender As Object, e As EventArgs) Handles BOOKINGDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub COPYDATA(ByVal DT As DataTable)
        Try
            For Each dr As DataRow In DT.Rows

                TXTSTATECODE.Text = dr("STATECODE")
                TXTPURSTATECODE.Text = dr("PURSTATECODE")
                CMBHSNITEMDESC.Text = dr("ITEMDESC")
                BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                CHKBOOKINGDATE.Checked = Convert.ToBoolean(dr("ENTRYDATEASBOOKINGDATE"))
                CMBBOOKINGTYPE.Text = dr("BOOKINGTYPE")
                CMBGUESTNAME.Text = dr("GUESTNAME")
                txtmobileno.Text = dr("MOBILENO")
                txtemailadd.Text = dr("EMAILADD")
                TXTGUESTADD.Text = dr("GUESTADD")
                txthoteladd.Text = dr("HOTELADD")
                TXTPURADD.Text = dr("PURADD")
                TXTADD.Text = dr("SALEADD")
                txtrefno.Text = dr("REFNO")

                cmbhotelcode.Text = Convert.ToString(dr("HOTELCODE"))
                cmbhotelname.Text = Convert.ToString(dr("HOTELNAME"))

                FILLROOMTYPE()


                CMBPURCODE.Text = Convert.ToString(dr("PURCODE"))
                CMBPURNAME.Text = Convert.ToString(dr("PURNAME"))

                CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                CMBNAME.Text = Convert.ToString(dr("ACCNAME"))

                ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVAL"))
                DEPARTDATE.Value = Convert.ToDateTime(dr("DEPARTURE"))

                CMBARRFROM.Text = Convert.ToString(dr("ARRFROM"))
                CMBDEPARTTO.Text = Convert.ToString(dr("DEPARTTO"))

                txtcheckin.Text = Convert.ToString(dr("CHECKIN"))
                txtcheckout.Text = Convert.ToString(dr("CHECKOUT"))

                TXTARRFLIGHTNO.Text = Convert.ToString(dr("ARRFLIGHTNO"))
                TXTDEPARTFLIGHTNO.Text = Convert.ToString(dr("DEPARTFLIGHTNO"))


                'PURCHASE VALUES
                TXTPURAMT.Text = dr("PURAMT")
                TXTDISCRECDPER.Text = dr("DISCRECDPER")
                TXTDISCRECDRS.Text = dr("DISCRECDRS")
                TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                TXTPURTDSPER.Text = dr("PURTDSPER")
                TXTPURTDSRS.Text = dr("PURTDSRS")
                TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                CMBPURTAX.Text = dr("PURTAXNAME")
                TXTPURTAX.Text = dr("PURTAX")

                CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                TXTPURADDTAX.Text = dr("PURADDTAX")

                CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                If dr("PUROTHERCHGS") > 0 Then
                    TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                    CMBPURADDSUB.Text = "Add"
                Else
                    TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                    CMBPURADDSUB.Text = "Sub."
                End If

                TXTPURROUNDOFF.Text = dr("PURROUNDOFF")


                TXTTOTALNIGHTS.Text = dr("TOTALNIGHTS")

                CMBBOOKEDBY.Text = dr("BOOKEDBY")
                CMBSOURCE.Text = dr("SOURCE")
                CMBAGENTNAME.Text = dr("AGENTNAME")

                TXTAGENTCOMMPER.Text = dr("AGENTCOMMPER")
                TXTAGENTCOMMRS.Text = dr("AGENTCOMMRS")
                TXTAGENTTDSPER.Text = dr("AGENTTDSPER")
                TXTAGENTTDSRS.Text = dr("AGENTTDSRS")

                TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")

                TXTOURCOMMPER.Text = dr("OURCOMMPER")
                TXTOURCOMMRS.Text = dr("OURCOMMRS")

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
                TXTDP.Text = dr("DP")

                txtremarks.Text = Convert.ToString(dr("REMARKS"))
                TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))

                TXTPURAMTPAID.Text = 0
                TXTPUREXTRAAMT.Text = 0
                TXTPURRETURN.Text = 0
                TXTPURBAL.Text = 0

                TXTSALEAMTREC.Text = 0
                TXTSALEEXTRAAMT.Text = 0
                TXTSALERETURN.Text = 0
                TXTSALEBAL.Text = 0

                TXTBAL.Text = 0

                txtremarks.Text = dr("REMARKS")
                TXTBOOKINGDESC.Text = dr("BOOKINGDESC")
                TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                TXTPICKUP.Text = dr("PICKUPDETAILS")



                TXTHSNCODE.Text = dr("HSNCODE")
                If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                TXTCGSTPER.Text = dr("CGSTPER")
                TXTCGSTAMT.Text = dr("CGSTAMT")
                TXTSGSTPER.Text = dr("SGSTPER")
                TXTSGSTAMT.Text = dr("SGSTAMT")
                TXTIGSTPER.Text = dr("IGSTPER")
                TXTIGSTAMT.Text = dr("IGSTAMT")
                TXTCESSPER.Text = dr("CESSPER")
                TXTCESSAMT.Text = dr("CESSAMT")

                If CHKMANUAL.Checked = True Then
                    TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                    TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                    TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")

                End If

                CHKPURSERVTAX.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))

                TXTPURCOMMPER.Text = dr("PUROURCOMMPER")
                If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                TXTPURHSNCODE.Text = dr("PURHSNCODE")
                TXTPURCGSTPER.Text = dr("PURCGSTPER")
                TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                TXTPURSGSTPER.Text = dr("PURSGSTPER")
                TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                TXTPURIGSTPER.Text = dr("PURIGSTPER")
                TXTPURIGSTAMT.Text = dr("PURIGSTAMT")
                TXTPURCESSPER.Text = dr("PURCESSPER")
                TXTPURCESSAMT.Text = dr("PURCESSAMT")

                If CHKPURMANUAL.Checked = True Then
                    TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                    TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                    TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                End If


                TXTCONFIRMEDBY.Text = dr("CONFIRMEDBY")
                TXTCONFIRMATIONNO.Text = dr("CONFIRMATIONNO")



                GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("ROOMTYPE").ToString, dr("AC").ToString, dr("PLAN").ToString, dr("ADULTS").ToString, dr("CHILDS").ToString, dr("NCCHILDS").ToString, dr("EXTRAADULTS"), Format(dr("EXTRAADULTRATE"), "0.00"), dr("EXTRACHILDS"), Format(dr("EXTRACHILDRATE"), "0.00"), dr("NOOFROOMS").ToString, dr("gridremarks"), dr("PACKAGE"), Format(dr("RATE"), "0.00"), dr("CURCODE"), Format(dr("ROE"), "0.00"), Format(dr("amt"), "0.00"))

            Next
            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1



            'GET GRIDPUR DATA
            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable
            'IF WE HAVE FETCHED DATA FROM PROFORMA THEN GET DATA FROM PROFORMA
            If Val(TXTENQNO.Text.Trim) > 0 Then
                dttable = OBJCMN.search("  PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ADULTS AS ADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CHILDS AS CHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NCCHILDS AS NCCHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTS AS EXTRAADULTS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTRATE AS EXTRAADULTRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILD AS EXTRACHILDS, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILDRATE AS EXTRACHILDRATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NOOFROOMS AS NOOFROOMS, CASE WHEN BOOKING_PACKAGE = 'TRUE' THEN 'Yes' ELSE 'No' END AS PACKAGE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_RATE AS RATE, PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT", "", " PROFORMAHOTELBOOKINGMASTER INNER JOIN PROFORMAHOTELBOOKINGMASTER_PURDESC ON PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_NO AND PROFORMAHOTELBOOKINGMASTER.BOOKING_BOOKTYPE = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_BOOKTYPE AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID INNER JOIN ROOMTYPEMASTER ON PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID  ", " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_NO = " & Val(TXTENQNO.Text.Trim) & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND PROFORMAHOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY PROFORMAHOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
            Else
                dttable = OBJCMN.search("  HOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO AS GRIDSRNO, ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE, HOTELBOOKINGMASTER_PURDESC.BOOKING_ADULTS AS ADULTS, HOTELBOOKINGMASTER_PURDESC.BOOKING_CHILDS AS CHILDS, HOTELBOOKINGMASTER_PURDESC.BOOKING_NCCHILDS AS NCCHILDS, HOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTS AS EXTRAADULTS, HOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRAADULTRATE AS EXTRAADULTRATE, HOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILD AS EXTRACHILDS, HOTELBOOKINGMASTER_PURDESC.BOOKING_EXTRACHILDRATE AS EXTRACHILDRATE, HOTELBOOKINGMASTER_PURDESC.BOOKING_NOOFROOMS AS NOOFROOMS, CASE WHEN BOOKING_PACKAGE = 'TRUE' THEN 'Yes' ELSE 'No' END AS PACKAGE, HOTELBOOKINGMASTER_PURDESC.BOOKING_RATE AS RATE, HOTELBOOKINGMASTER_PURDESC.BOOKING_AMT AS AMT", "", " HOTELBOOKINGMASTER INNER JOIN HOTELBOOKINGMASTER_PURDESC ON HOTELBOOKINGMASTER.BOOKING_NO = HOTELBOOKINGMASTER_PURDESC.BOOKING_NO AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = HOTELBOOKINGMASTER_PURDESC.BOOKING_BOOKTYPE AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELBOOKINGMASTER_PURDESC.BOOKING_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELBOOKINGMASTER_PURDESC.BOOKING_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELBOOKINGMASTER_PURDESC.BOOKING_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID ", " AND HOTELBOOKINGMASTER.BOOKING_NO = " & Val(TXTCOPY.Text.Trim) & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = '" & FRMSTRING & "' AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YearId & " ORDER BY HOTELBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO")
            End If
            If dttable.Rows.Count > 0 Then
                For Each DR As DataRow In dttable.Rows
                    GRIDPUR.Rows.Add(DR("GRIDSRNO").ToString, DR("ROOMTYPE").ToString, DR("ADULTS").ToString, DR("CHILDS").ToString, DR("NCCHILDS").ToString, DR("EXTRAADULTS"), Format(DR("EXTRAADULTRATE"), "0.00"), DR("EXTRACHILDS"), Format(DR("EXTRACHILDRATE"), "0.00"), DR("NOOFROOMS").ToString, DR("PACKAGE"), Format(DR("RATE"), "0.00"), Format(DR("amt"), "0.00"))
                Next
            End If


            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
