
Imports System.IO
Imports System.Net
Imports BL
Imports System.Text
Imports iTextSharp.text.pdf
Imports Microsoft.Office.Interop
Imports iTextSharp.text.pdf.parser
Imports TaxProEInvoice.API
Imports RestSharp
Imports System.ComponentModel
Imports Newtonsoft.Json

Public Class RailwayBooking

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Dim TEMPMSG As Integer
    Dim TEMPPNRNO As String
    Public Shared dt_amd As New DataTable
    Dim DDATE As DateTime
    Dim GROUPDEPRAILTYPE As String = ""

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_no),0) + 1 ", " RAILBOOKINGMASTER", " and BOOKING_yearid=" & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then txtbookingno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()
        Try

            LBLPURBAL.ForeColor = Color.Green
            LBLACCBAL.ForeColor = Color.Green

            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "UTTARAKHAND" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                txtbookingno.ReadOnly = False
                txtbookingno.Enabled = True
            End If

            TXTCOPY.Clear()
            tstxtbillno.Clear()
            txtmobileno.Clear()
            txtemailadd.Clear()
            txtrefno.Clear()

            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True

            CMBNAME.Text = ""
            CMBACCCODE.Text = ""
            CMBPURCODE.Text = ""
            CMBPURNAME.Text = ""
            LBLACCBAL.Text = 0.0
            LBLPURBAL.Text = 0.0
            TXTADD.Clear()
            TXTADULTS.Text = 0
            TXTCHILDS.Text = 0

            CMBLOGINID.Text = ""
            TXTPAYMODE.Clear()
            CMBTRAINNAME.Text = ""
            CMBTRAINNO.Text = ""
            CMBCLASS.SelectedIndex = 0
            TXTARRTIME.Clear()
            TXTDEPTIME.Clear()

            CMBFROM.Text = ""
            CMBFROMCODE.Text = ""
            TXTFROM.Clear()
            CMBTO.Text = ""
            CMBTOCODE.Text = ""
            TXTTO.Clear()
            CMBBOARDING.Text = ""
            CMBBOARDINGCODE.Text = ""
            TXTBOARDING.Clear()
            CMBRESTO.Text = ""
            CMBRESTOCODE.Text = ""
            TXTRESTO.Clear()

            CMBTICKETTYPE.SelectedIndex = 0
            CMBQUOTA.SelectedIndex = 0

            bookingdate.Value = Mydate
            JOURNEYDATE.Value = Mydate
            BOARDINGDATE.Value = Mydate

            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBDN.Visible = False
            PBCN.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False

            txttax.ReadOnly = True
            txttax.Enabled = False
            TXTPURTAX.ReadOnly = True
            TXTPURTAX.Enabled = False
            LBLEINVGENERATED.Visible = False

            TXTSRNO.Clear()
            TXTPASSNAME.Clear()
            TXTAGE.Clear()
            CMBSEX.SelectedIndex = 0
            TXTSEATNO.Clear()

            TXTDNRATE.Clear()
            TXTMIDDN.Clear()
            TXTMIDDNRATE.Clear()
            TXTUP.Clear()
            TXTUPRATE.Clear()
            TXTMIDUP.Clear()
            TXTMIDUPRATE.Clear()


            CMBSTATUS.SelectedIndex = 0
            CMBIDTYPE.Text = ""
            TXTIDNO.Clear()
            TXTCONCESSION.Clear()


            GRIDBOOKINGS.RowCount = 0

            GRIDBOOKINGS.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            'TXTFARE.Clear()
            TXTFARE.Text = 0.0
            'TXTIRCTC.Clear()
            TXTIRCTC.Text = 0.0
            'TXTGATEWAY.Clear()
            TXTGATEWAY.Text = 0.0


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
            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0
            CMBPURADDSUB.SelectedIndex = 0
            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0

            TXTTOTALSALEAMT.Text = 0.0
            TXTOURCOMMPER.Text = 0.0
            TXTOURCOMMRS.Text = 0.0
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

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""

            TXTREMARKS.Clear()
            TXTSPECIALREMARKS.Clear()

            txtinwords.Clear()
            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked
            CHKREFUNDED.CheckState = CheckState.Unchecked
            CHKFAILED.CheckState = CheckState.Unchecked
            CHKREVERSE.CheckState = CheckState.Unchecked
            TXTCONFIRMEDBY.Clear()
            TXTCONFIRMATIONNO.Clear()
            TXTTRANSID.Clear()
            TXTTOTALPAX.Clear()

            PBSoftCopy.ImageLocation = ""
            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTFILENAME.Clear()
            txtimgpath.Clear()
            TXTNEWIMGPATH.Clear()
            gridupload.RowCount = 0

            TXTHSNCODE.Clear()
            TXTPURHSNCODE.Clear()
            TXTSTATECODE.Clear()
            TXTPURSTATECODE.Clear()
            'CMBHSNITEMDESC.SelectedIndex = 0
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURSGSTPER.Text = 0.0
            TXTPURSGSTAMT.Text = 0.0
            TXTPURIGSTPER.Text = 0.0
            TXTPURIGSTAMT.Text = 0.0
            TXTPURSERVCHGS.Text = 0.0
            CHKPURTAXSERVCHGS.CheckState = CheckState.Unchecked

            CHKMANUAL.CheckState = CheckState.Unchecked
            CHKPURMANUAL.CheckState = CheckState.Unchecked

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()
            gridDoubleClick = False
            gridUPLOADdoubleclick = False
            getmax_BOOKING_no()

            If GRIDBOOKINGS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If

            'EINVOICE
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        JOURNEYDATE.Focus()
    End Sub

    Private Sub RailwayBooking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then cmdok_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                Call CMDDELETE_Click(sender, e)
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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New RailwayBookingDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBPURCODE.Text.Trim = "" Then fillname(CMBPURCODE, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)


            If CMBLOGINID.Text = "" Then filllogin(CMBLOGINID)
            If CMBIDTYPE.Text = "" Then fillIdType(CMBIDTYPE)

            If CMBGROUPDEPARTURE.Text = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(bookingdate.Value.Date, "MM/dd/yyyy") & "'")

            If ClientName = "CLASSIC" Then
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND GROUP_SECONDARY = 'INDIRECT EXPENSES' AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (ACC_CMPNAME = 'Discount' OR ACC_CMPNAME = 'Round Off')")
            Else
                If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
                If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            End If

            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" And CMBBOARDING.Text.Trim = "" Then
                CMBBOARDING.Text = CMBFROM.Text.Trim
                CMBBOARDINGCODE.Text = CMBFROMCODE.Text.Trim
                TXTBOARDING.Text = CMBFROMCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROM.Validating
        Try
            If CMBFROM.Text.Trim <> "" Then STATIONVALIDATE(CMBFROM, CMBFROMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTO.Validated
        Try
            If CMBTO.Text.Trim <> "" And CMBRESTO.Text.Trim = "" Then
                CMBRESTO.Text = CMBTO.Text.Trim
                CMBRESTOCODE.Text = CMBTOCODE.Text.Trim
                TXTRESTO.Text = CMBTOCODE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTO.Validating
        Try
            If CMBTO.Text.Trim <> "" Then STATIONVALIDATE(CMBTO, CMBTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOARDING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOARDING.Validating
        Try
            If CMBBOARDING.Text.Trim <> "" Then STATIONVALIDATE(CMBBOARDING, CMBBOARDINGCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRESTO.Validating
        Try
            If CMBRESTO.Text.Trim <> "" Then STATIONVALIDATE(CMBRESTO, CMBRESTOCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RailwayBooking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'RAIL RESERVATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            'RECOMMENDED BY ASHOK BHAI
            If UserName <> "Admin" And ClientName = "CLASSIC" Then LBLPURBAL.Visible = False


            Cursor.Current = Cursors.WaitCursor
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            clear()

            If ClientName = "SHREEJI" Or ClientName = "BARODA" Then TXTPURROUNDOFF.ReadOnly = False

            If edit = True Then

                chkmobile.CheckState = CheckState.Unchecked
                CHKEMAIL.CheckState = CheckState.Unchecked

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsRailBookingMaster()

                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtbookingno.ReadOnly = True
                        txtbookingno.Enabled = False
                        txtbookingno.Text = TEMPBOOKINGNO
                        TXTENQNO.Text = dr("ENQNO")
                        CMBHSNITEMDESC.Text = dr("HSNITEMDESC")
                        CMBPURHSNITEMDESC.Text = dr("PURHSNITEMDESC")

                        bookingdate.Value = Convert.ToDateTime(dr("BOOKINGDATE"))
                        DDATE = bookingdate.Value
                        JOURNEYDATE.Value = Convert.ToDateTime(dr("JOURNEYDATE"))
                        BOARDINGDATE.Value = Convert.ToDateTime(dr("BOARDINGDATE"))


                        CMBLOGINID.Text = dr("LOGINID")
                        TXTPAYMODE.Text = dr("PAYMODE")
                        CMBTRAINNAME.Text = dr("TRAINNAME")
                        CMBTRAINNO.Text = dr("TRAINNO")
                        CMBCLASS.Text = dr("CLASS")
                        TXTARRTIME.Text = dr("ARRTIME")
                        TXTDEPTIME.Text = dr("DEPTIME")


                        CMBFROM.Text = dr("STATIONFROM")
                        TXTFROM.Text = dr("FROM")
                        CMBFROMCODE.Text = dr("FROM")
                        CMBTO.Text = dr("STATIONTO")
                        TXTTO.Text = dr("TO")
                        CMBTOCODE.Text = dr("TO")
                        CMBBOARDING.Text = dr("BOARDINGFROM")
                        TXTBOARDING.Text = dr("BFROM")
                        CMBBOARDINGCODE.Text = dr("BFROM")
                        CMBRESTO.Text = dr("RESTO")
                        TXTRESTO.Text = dr("RTO")
                        CMBRESTOCODE.Text = dr("RTO")
                        CMBTICKETTYPE.Text = dr("TICKETTYPE")
                        CMBQUOTA.Text = dr("QUOTA")


                        CMBPURCODE.Text = dr("PURCODE")
                        CMBPURNAME.Text = dr("PURNAME")
                        CMBACCCODE.Text = dr("ACCCODE")
                        CMBNAME.Text = dr("ACCNAME")

                        CMBGROUPDEPARTURE.Text = dr("TOURNAME")
                        'If dr("TOURNAME") <> "" Then CMBGROUPDEPARTURE.Enabled = False
                        GROUPDEPRAILTYPE = dr("GROUPDEPRAILTYPE")
                        CMBGROUPDEPARTURE.Enabled = True

                        TXTADULTS.Text = dr("ADULTS")
                        TXTCHILDS.Text = dr("CHILD")


                        TXTFARE.Text = Format(Val(dr("FARE")), "0.00")
                        TXTIRCTC.Text = Format(Val(dr("IRCTC")), "0.00")
                        TXTGATEWAY.Text = Format(Val(dr("GATEWAY")), "0.00")


                        'PURCHASE VALUES
                        TXTDISCRECDPER.Text = dr("DISCRECDPER")
                        TXTDISCRECDRS.Text = dr("DISCRECDRS")
                        TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                        TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                        TXTPURTDSPER.Text = dr("PURTDSPER")
                        TXTPURTDSRS.Text = dr("PURTDSRS")
                        TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                        CMBPURTAX.Text = dr("PURTAXNAME")
                        TXTPURTAX.Text = dr("PURTAX")


                        CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                        If dr("PUROTHERCHGS") > 0 Then
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                            CMBPURADDSUB.Text = "Add"
                        Else
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                            CMBPURADDSUB.Text = "Sub."
                        End If

                        TXTPURROUNDOFF.Text = dr("PURROUNDOFF")



                        TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")
                        TXTOURCOMMPER.Text = dr("OURCOMMPER")
                        TXTOURCOMMRS.Text = dr("OURCOMMRS")

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


                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))

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



                        If dr("DONE").ToString = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If



                        If Convert.ToBoolean(dr("CANCELLED")) = True Then
                            lblcancelled.Visible = True
                            PBCancelled.Visible = True
                        End If

                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        txtmobileno.Text = dr("MOBILENO")
                        txtemailadd.Text = dr("EMAILADD")
                        txtrefno.Text = dr("REFNO")
                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                        CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                        CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))

                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTPURSTATECODE.Text = dr("PURSTATECODE")

                        TXTHSNCODE.Text = dr("HSNCODE")
                        TXTPURHSNCODE.Text = dr("PURHSNCODE")
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True

                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                        End If

                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True
                        If CHKPURMANUAL.Checked = True Then
                            TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                            TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                            TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                        End If


                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")
                        TXTPURSERVCHGS.Text = dr("PURTAXSERVCHGSAMT")
                        CHKPURTAXSERVCHGS.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                        TXTPURCGSTPER.Text = dr("PURCGSTPER")
                        TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                        TXTPURSGSTPER.Text = dr("PURSGSTPER")
                        TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                        TXTPURIGSTPER.Text = dr("PURIGSTPER")
                        TXTPURIGSTAMT.Text = dr("PURIGSTAMT")

                        TXTCONFIRMEDBY.Text = dr("CONFIRMEDBY")
                        TXTCONFIRMATIONNO.Text = dr("CONFIRMATIONNO")
                        TXTTRANSID.Text = dr("TRANSID")
                        TEMPPNRNO = dr("CONFIRMATIONNO")


                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("AGE").ToString, dr("SEX").ToString, dr("SEATNO").ToString, Val(dr("DNRATE")), dr("MIDDN"), Val(dr("MIDDNRATE")), dr("UP"), Val(dr("UPRATE")), dr("MIDDN"), Val(dr("MIDUPRATE")), dr("STATUS").ToString, dr("IDTYPE").ToString, dr("IDNO").ToString, dr("CONCESSION").ToString)

                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If
                    Next
                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                    'GET SCAN DOCS DATA
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" RAILBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, RAILBOOKINGMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, RAILBOOKINGMASTER_UPLOAD.BOOKING_NAME AS NAME, RAILBOOKINGMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, RAILBOOKINGMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " RAILBOOKINGMASTER_UPLOAD ", " AND RAILBOOKINGMASTER_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND RAILBOOKINGMASTER_UPLOAD.BOOKING_CMPID = " & CmpId & " AND  RAILBOOKINGMASTER_UPLOAD.BOOKING_LOCATIONID  = " & Locationid & " AND RAILBOOKINGMASTER_UPLOAD.BOOKING_YEARID = " & YearId & " ORDER BY RAILBOOKINGMASTER_UPLOAD.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                        Next
                    End If

                    PURCHASETOTAL()

                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    JOURNEYDATE.Focus()
                End If
                chkchange.CheckState = CheckState.Checked
                GETBALANCE()
            End If
            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
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


            alParaval.Add("RAILWAY PURCHASE REGISTER")
            alParaval.Add("RAILWAY SALE REGISTER")

            If ClientName = "PLANET" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "UTTARAKHAND" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(bookingdate.Value.Date)

            alParaval.Add(JOURNEYDATE.Value.Date)
            alParaval.Add(BOARDINGDATE.Value.Date)

            alParaval.Add(CMBPURNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Val(TXTADULTS.Text.Trim))
            alParaval.Add(Val(TXTCHILDS.Text.Trim))

            alParaval.Add(CMBLOGINID.Text.Trim)
            alParaval.Add(TXTPAYMODE.Text.Trim)
            alParaval.Add(CMBTRAINNAME.Text.Trim)
            alParaval.Add(CMBTRAINNO.Text.Trim)
            alParaval.Add(CMBCLASS.Text.Trim)
            alParaval.Add(TXTARRTIME.Text.Trim)
            alParaval.Add(TXTDEPTIME.Text.Trim)


            alParaval.Add(UCase(CMBFROM.Text.Trim))
            alParaval.Add(UCase(CMBFROMCODE.Text.Trim))
            alParaval.Add(UCase(CMBTO.Text.Trim))
            alParaval.Add(UCase(CMBTOCODE.Text.Trim))
            alParaval.Add(UCase(CMBBOARDING.Text.Trim))
            alParaval.Add(UCase(CMBBOARDINGCODE.Text.Trim))
            alParaval.Add(UCase(CMBRESTO.Text.Trim))
            alParaval.Add(UCase(CMBRESTOCODE.Text.Trim))
            alParaval.Add(CMBTICKETTYPE.Text.Trim)
            alParaval.Add(CMBQUOTA.Text.Trim)



            'PURCHASE VALUES
            'ADD PURCHASE AMT + EXTRAADULT AMT + EXTRACHILD AMT + PUREXTRACHGS
            alParaval.Add(Val(TXTFARE.Text.Trim))
            alParaval.Add(Val(TXTIRCTC.Text.Trim))
            alParaval.Add(Val(TXTGATEWAY.Text.Trim))

            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
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
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)


            'SALE VALUES
            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMPER.Text.Trim))
            alParaval.Add(Val(TXTOURCOMMRS.Text.Trim))
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


            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(TXTFAREINWORDS.Text.Trim)
            alParaval.Add(TXTIRCTCINWORDS.Text.Trim)
            alParaval.Add(TXTGATEWAYINWORDS.Text.Trim)
            alParaval.Add(TXTTOTALINWORDS.Text.Trim)


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
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(TXTPURHSNCODE.Text.Trim)

            alParaval.Add(CHKMANUAL.CheckState)
            alParaval.Add(CHKPURMANUAL.CheckState)

            alParaval.Add(TXTCGSTPER.Text.Trim)
            alParaval.Add(TXTCGSTAMT.Text.Trim)
            alParaval.Add(TXTSGSTPER.Text.Trim)
            alParaval.Add(TXTSGSTAMT.Text.Trim)
            alParaval.Add(TXTIGSTPER.Text.Trim)
            alParaval.Add(TXTIGSTAMT.Text.Trim)
            alParaval.Add(CHKPURTAXSERVCHGS.CheckState)
            alParaval.Add(TXTPURSERVCHGS.Text.Trim)
            alParaval.Add(TXTPURCGSTPER.Text.Trim)
            alParaval.Add(TXTPURCGSTAMT.Text.Trim)
            alParaval.Add(TXTPURSGSTPER.Text.Trim)
            alParaval.Add(TXTPURSGSTAMT.Text.Trim)
            alParaval.Add(TXTPURIGSTPER.Text.Trim)
            alParaval.Add(TXTPURIGSTAMT.Text.Trim)

            alParaval.Add(GROUPDEPRAILTYPE)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            'THIS VARIABLE IS JUST USED TO PASS THE GUESTNAME WITH NO OF PAX IN TOURNAME FIELD IN ACCMASTER TABLE
            'THIS WILL BE THEN FETCHED IN LEDGERBOOK, HENCE REDUCING THE DELAY TIME 
            alParaval.Add(GRIDBOOKINGS.Rows(0).Cells(GPASSNAME.Index).Value & " * " & Val(GRIDBOOKINGS.RowCount))


            Dim GRIDSRNO As String = ""
            Dim PASSNAME As String = ""
            Dim AGE As String = ""
            Dim SEX As String = ""
            Dim SEATNO As String = ""
            Dim DNRATE As String = ""
            Dim MIDDN As String = ""
            Dim MIDDNRATE As String = ""
            Dim UP As String = ""
            Dim UPRATE As String = ""
            Dim MIDUP As String = ""
            Dim MIDUPRATE As String = ""
            Dim STATUS As String = ""
            Dim IDTYPE As String = ""
            Dim IDNO As String = ""
            Dim CONCESSION As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        PASSNAME = row.Cells(GPASSNAME.Index).Value.ToString
                        AGE = row.Cells(GAGE.Index).Value.ToString
                        SEX = row.Cells(GSEX.Index).Value.ToString
                        SEATNO = row.Cells(GSEATNO.Index).Value.ToString
                        DNRATE = Val(row.Cells(GDNRATE.Index).Value)
                        MIDDN = row.Cells(GMIDDN.Index).Value.ToString
                        MIDDNRATE = Val(row.Cells(GMIDDNRATE.Index).Value)
                        UP = row.Cells(GRAILUP.Index).Value.ToString
                        UPRATE = Val(row.Cells(GRAILUPRATE.Index).Value)
                        MIDUP = row.Cells(GMIDUP.Index).Value.ToString
                        MIDUPRATE = Val(row.Cells(GMIDUPRATE.Index).Value)
                        STATUS = row.Cells(GSTATUS.Index).Value.ToString
                        IDTYPE = row.Cells(GIDTYPE.Index).Value.ToString
                        IDNO = row.Cells(GIDNO.Index).Value.ToString
                        CONCESSION = row.Cells(GCCode.Index).Value.ToString

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GSRNO.Index).Value
                        PASSNAME = PASSNAME & "|" & row.Cells(GPASSNAME.Index).Value
                        AGE = AGE & "|" & row.Cells(GAGE.Index).Value
                        SEX = SEX & "|" & row.Cells(GSEX.Index).Value.ToString
                        SEATNO = SEATNO & "|" & row.Cells(GSEATNO.Index).Value.ToString
                        DNRATE = DNRATE & "|" & Val(row.Cells(GDNRATE.Index).Value)
                        MIDDN = MIDDN & "|" & row.Cells(GMIDDN.Index).Value.ToString
                        MIDDNRATE = MIDDNRATE & "|" & Val(row.Cells(GMIDDNRATE.Index).Value)
                        UP = UP & "|" & row.Cells(GRAILUP.Index).Value.ToString
                        UPRATE = UPRATE & "|" & Val(row.Cells(GRAILUPRATE.Index).Value)
                        MIDUP = MIDUP & "|" & row.Cells(GMIDUP.Index).Value.ToString
                        MIDUPRATE = MIDUPRATE & "|" & Val(row.Cells(GMIDUPRATE.Index).Value)
                        STATUS = STATUS & "|" & row.Cells(GSTATUS.Index).Value.ToString
                        IDTYPE = IDTYPE & "|" & row.Cells(GIDTYPE.Index).Value.ToString
                        IDNO = IDNO & "|" & row.Cells(GIDNO.Index).Value.ToString
                        CONCESSION = CONCESSION & "|" & row.Cells(GCCode.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PASSNAME)
            alParaval.Add(AGE)
            alParaval.Add(SEX)
            alParaval.Add(SEATNO)
            alParaval.Add(DNRATE)
            alParaval.Add(MIDDN)
            alParaval.Add(MIDDNRATE)
            alParaval.Add(UP)
            alParaval.Add(UPRATE)
            alParaval.Add(MIDUP)
            alParaval.Add(MIDUPRATE)
            alParaval.Add(STATUS)
            alParaval.Add(IDTYPE)
            alParaval.Add(IDNO)
            alParaval.Add(CONCESSION)


            alParaval.Add(txtmobileno.Text.Trim)
            alParaval.Add(txtemailadd.Text.Trim)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(CHKREFUNDED.CheckState)
            alParaval.Add(CHKFAILED.CheckState)


            alParaval.Add(TXTCONFIRMEDBY.Text.Trim)
            alParaval.Add(TXTCONFIRMATIONNO.Text.Trim)
            alParaval.Add(TXTTRANSID.Text.Trim)
            alParaval.Add(ClientName)
            alParaval.Add(Val(TXTENQNO.Text.Trim))

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
            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            Dim OBJBOOKING As New ClsRailBookingMaster()
            OBJBOOKING.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.save()
                'If chkmobile.CheckState = CheckState.Checked Then SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is confirmed between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date, txtmobileno.Text.Trim)
                MessageBox.Show("Details Added")
                PRINTREPORT(DTNO.Rows(0).Item(0))

            Else

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.update()
                'If chkmobile.CheckState = CheckState.Checked Then SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is Updated between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date, txtmobileno.Text.Trim)
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(TEMPBOOKINGNO)
            End If

            edit = False


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\RAIL") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\RAIL")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\RAIL") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next

            clear()
            bookingdate.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Not datecheck(bookingdate.Value) Then
            EP.SetError(bookingdate, "Date Not in Current Accounting Year")
            bln = False
        End If

        GETBALANCE()
        If LBLPURBAL.ForeColor = Color.Red Then
            Dim temppurchasebal As Integer = MsgBox("Amt Exceeds Cr Limit, wish to continue?", MsgBoxStyle.YesNo)
            If temppurchasebal = 7 Then
                EP.SetError(LBLPURBAL, "Amt Exceeds Cr Limit")
                bln = False
            End If
        End If


        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        If LBLACCBAL.ForeColor = Color.Red Then
            If ClientName = "AMIGO" Then
                EP.SetError(CMBNAME, "Amt Exceeds Cr Limit")
            Else
                EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            End If
            bln = False
        End If

        If ClientName = "SHREEJI" And TXTTRANSID.Text.Trim = "" Then
            EP.SetError(TXTTRANSID, "Enter Transaction ID")
            bln = False
        End If

        If Val(TXTADULTS.Text.Trim) = 0 Then
            EP.SetError(TXTADULTS, " Please Enter No Of Adults")
            bln = False
        End If

        If CMBCLASS.Text.Trim = "" Then
            EP.SetError(CMBCLASS, " Please Enter Class")
            bln = False
        End If

        If CMBQUOTA.Text.Trim = "" Then
            EP.SetError(CMBQUOTA, " Please select Quota")
            bln = False
        End If

        'NOW ID IS NOT MANDATE
        '        If CMBQUOTA.Text = "Tatkal" Then
        '            For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
        '                If ROW.Cells(GIDTYPE.Index).EditedFormattedValue <> "" And ROW.Cells(GIDNO.Index).EditedFormattedValue <> "" Then GoTo LINE1
        '            Next
        '            EP.SetError(CMBQUOTA, "Enter Id No")
        '            bln = False
        'LINE1:
        '        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = True Then
                If bookingdate.Value.Date < DDATE.Date Then
                    EP.SetError(bookingdate, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If

        'CHECKING WHETHER NAME IS PRESENT IN DATABASE OR NOT
        'DONT DELETE THIS CODE IT IS NECESSARY COZ SOMETIMES FORM IS OPEN AND USER CHANGES THE NAME FROM BEHIND
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        If ClientName <> "TOPCOMM" Then
            DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count = 0 Then
                EP.SetError(CMBNAME, "Change Name")
                bln = False
            End If

            If ClientName <> "ELYSIUM" And ClientName <> "RAMKRISHNA" Then
                DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
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
            DT = OBJCMN.search(" ACC_MOBILE", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                txtmobileno.Text = DT.Rows(0).Item(0)
            End If
        End If

        'If CMBTRAINNO.Text.Trim.Length = 0 Then
        '    EP.SetError(CMBTRAINNO, " Please Enter Train No ")
        '    bln = False
        'End If

        'If TXTCONFIRMATIONNO.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTCONFIRMATIONNO, " Please Enter PNR No ")
        '    bln = False
        'End If

        If CMBFROM.Text.Trim.Length = 0 Then
            EP.SetError(TXTFROM, " Please Enter Station From")
            bln = False
        End If

        If CMBTO.Text.Trim.Length = 0 Then
            EP.SetError(TXTTO, " Please Enter Station To")
            bln = False
        End If

        If CMBBOARDING.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOARDING, " Please Enter Boarding From")
            bln = False
        End If

        If CMBRESTO.Text.Trim.Length = 0 Then
            EP.SetError(CMBRESTO, " Please Enter Reservation Upto")
            bln = False
        End If

        If Val(TXTFARE.Text.Trim) = 0 Then
            EP.SetError(TXTFARE, " Please Enter Station From")
            bln = False
        End If

        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(TXTFROM, " Sale cannot be 0")
            bln = False
        End If


        If Val(TXTFINALPURAMT.Text.Trim) = 0 And ClientName <> "RAMKRISHNA" Then
            EP.SetError(TXTFINALPURAMT, " Purchase cannot be 0")
            bln = False
        End If


        If ClientName = "CLASSIC" Then
            If Val(txtgrandtotal.Text.Trim) >= 50001 Then
                DT = OBJCMN.search(" ACC_ADD, ACC_PANNO AS PANNO", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("PANNO") = "" Then
                        EP.SetError(CMBNAME, "Insert PAN No")
                        bln = False
                    End If
                End If
            End If
        End If

        If (ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If

        If (ClientName = "CLASSIC" Or ClientName = "UTTARAKAND" Or ClientName = "MILONI" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "NAMASTE") And edit = False Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " RAILBOOKINGMASTER", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' AND BOOKING_CMPID=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    txtbookingno.Clear()
                    txtbookingno.Focus()
                    bln = False
                End If
            End If
        End If


        If JOURNEYDATE.Value.Date < bookingdate.Value.Date And ClientName <> "UNIGO" Then
            EP.SetError(JOURNEYDATE, " Fill Proper Dates ")
            bln = False
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(CMBNAME, "Enter Passenger Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If ClientName <> "LUXCREST" Then
            If UserName <> "Admin" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, " Booking Locked, Payment/Receipt Made")
                    bln = False
                End If
            End If

            If PBCN.Visible = True Then
                EP.SetError(PBCN, " Booking Locked, Credit Note Raised")
                bln = False
            End If

            If PBDN.Visible = True Then
                EP.SetError(PBDN, " Booking Locked, Debit Note Raised")
                bln = False
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

        If Not datecheck(bookingdate.Value) Then
            EP.SetError(bookingdate, "Date Not in Current Accounting Year")
            bln = False
        End If

        If ClientName = "RAMKRISHNA" And CMBGROUPDEPARTURE.Text.Trim = "" Then
            EP.SetError(CMBGROUPDEPARTURE, "Select Group Name")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If Not datecheck(JOURNEYDATE.Value) Then
                EP.SetError(JOURNEYDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
            If Not datecheck(JOURNEYDATE.Value) Then
                EP.SetError(JOURNEYDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()

        TXTTOTALSALEAMT.Text = "0.00"
        TXTTOTALPAX.Text = 0

        CMBADDTAX.Text = ""
        TXTADDTAX.Clear()

        TXTSUBTOTAL.Text = 0.0
        txttax.Text = 0.0
        TXTADDTAX.Text = 0.0
        If Val(TXTOURCOMMPER.Text.Trim) > 0 Then TXTOURCOMMRS.Text = 0.0
        txtroundoff.Text = 0.0
        TXTOURCOMMPER.Text = 0.0
        TXTOURCOMMRS.Text = 0.0
        txtgrandtotal.Text = 0.0
        TXTBAL.Clear()
        txtinwords.Clear()

        If CMBCLASS.Text <> "" And CMBQUOTA.Text <> "" Then
            Dim OBJSEARCH As New ClsCommon
            Dim DT As DataTable = OBJSEARCH.search(" ISNULL(RAILWAY_CONFIG.RAILWAY_RATE, 0) AS RATE ", "", "  RAILWAY_CONFIG INNER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid And RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CLASS='" & CMBCLASS.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_TYPE='" & CMBQUOTA.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID=" & CmpId & " and RAILWAY_CONFIG.RAILWAY_locationid=" & Locationid & " and RAILWAY_CONFIG.RAILWAY_yearid=" & YearId)
            If DT.Rows.Count > 0 Then
                cmbaddsub.Text = "Add"
                CMBOTHERCHGS.Text = "Service Chgs"
                txtotherchg.Text = Format(Val(DT.Rows(0).Item("RATE")) * Val(GRIDBOOKINGS.RowCount), "0.00")
            End If
        End If


        'GET TOTALFARE AUTO FOR RAMKRISHNA
        If ClientName = "RAMKRISHNA" Then
            TXTFARE.Text = 0
            For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                TXTFARE.Text += Val(ROW.Cells(GDNRATE.Index).Value) + Val(ROW.Cells(GMIDDNRATE.Index).Value) + Val(ROW.Cells(GRAILUPRATE.Index).Value) + Val(ROW.Cells(GMIDUPRATE.Index).Value)
            Next
        End If


        If GRIDBOOKINGS.RowCount > 0 Then

            TXTTOTALPAX.Text = GRIDBOOKINGS.RowCount
            TXTTOTALSALEAMT.Text = Format(Val(TXTFARE.Text.Trim) + Val(TXTIRCTC.Text.Trim) + Val(TXTGATEWAY.Text.Trim), "0.00")

            'AS COMM IS CALCULATED AUTO
            'If Val(TXTOURCOMMPER.Text) > 0 Then
            '    TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMPER.Text) * Val(TXTFINALPURAMT.Text)) / 100, "0.00")
            'Else
            '    TXTOURCOMMPER.Text = Format((Val(TXTOURCOMMRS.Text) * 100) / Val(TXTFINALPURAMT.Text), "0.00")
            'End If


            If CHKREVERSE.Checked = True Then
                Dim objclscmn As New ClsCommonMaster
                Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt1.Rows.Count > 0 Then
                    TXTTOTALSALEAMT.Text = Format((Val(TXTTOTALSALEAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                End If
            End If

            'COZ OUR COMM SHOULD NOT BE ADDED
            'TXTSUBTOTAL.Text = Format((Val(TXTTOTALSALEAMT.Text) + Val(TXTOURCOMMRS.Text)) - Val(TXTDISCRS.Text), "0.00")
            TXTSUBTOTAL.Text = Format(Val(TXTTOTALSALEAMT.Text) + Val(TXTEXTRACHGS.Text.Trim) + Val(TXTOURCOMMRS.Text), "0.00")

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If bookingdate.Value.Date < "01/07/2017" Then


                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                'If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTTOTALSALEAMT.Text)) / 100, "0.00")
            Else
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    'If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                    TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                    TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                    TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                    'Else
                    'TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    'TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    'TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    'End If
                End If
            End If

            If cmbaddsub.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


            'as per ASHOK BHAI'S RECOMMENDATION
            'TXTOURCOMMRS.Text = Format(Val(txtgrandtotal.Text) - Val(TXTFINALPURAMT.Text), "0.00")

            'If ClientName <> "ELYSIUM" Then TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTFINALPURAMT.Text), "0.00")
            If ClientName <> "ELYSIUM" Then
                If ClientName <> "BALAJI" Then
                    TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTFINALPURAMT.Text), "0.00")
                ElseIf ClientName = "BALAJI" Then
                    TXTOURCOMMRS.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTPURNETTAMT.Text), "0.00")
                End If
            End If


            If Val(TXTFARE.Text) > 0 Then TXTFAREINWORDS.Text = CurrencyToWord(TXTFARE.Text)
            If Val(txtgrandtotal.Text) > 0 Then TXTIRCTCINWORDS.Text = CurrencyToWord(TXTIRCTC.Text)
            If Val(TXTGATEWAY.Text) > 0 Then
                TXTGATEWAYINWORDS.Text = CurrencyToWord(TXTGATEWAY.Text)
                TXTTOTALINWORDS.Text = CurrencyToWord(Val(TXTFARE.Text) + Val(TXTIRCTC.Text) + Val(TXTGATEWAY.Text))
            Else
                TXTGATEWAYINWORDS.Text = CurrencyToWord(Val(txtotherchg.Text))
                TXTTOTALINWORDS.Text = CurrencyToWord(Val(TXTFARE.Text) + Val(TXTIRCTC.Text) + Val(txtotherchg.Text))
            End If

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

        End If
    End Sub

    Sub PURCHASETOTAL()

        TXTTOTALPURAMT.Text = 0.0
        TXTPURSUBTOTAL.Text = 0.0
        TXTPURTAX.Text = 0.0
        If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0
        TXTPURNETTAMT.Text = 0.0
        If ClientName <> "SHREEJI" And ClientName <> "BARODA" Then TXTPURROUNDOFF.Text = 0.0
        TXTPURGTOTAL.Text = 0.0
        TXTFINALPURAMT.Text = 0.0
        'TXTPURCGSTAMT.Clear()
        'TXTPURSGSTAMT.Clear()
        'TXTPURIGSTAMT.Clear()

        TXTTOTALPURAMT.Text = Format(Val(TXTFARE.Text.Trim) + Val(TXTIRCTC.Text.Trim) + Val(TXTGATEWAY.Text.Trim), "0.00")

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

        'TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) + Val(TXTPUREXTRACHGS.Text.Trim), "0.00")
        TXTPURNETTAMT.Text = Format(Val(TXTPURSUBTOTAL.Text) + Val(TXTPUREXTRACHGS.Text.Trim) + Val(TXTPURSERVCHGS.Text.Trim), "0.00")

        If bookingdate.Value.Date < "01/07/2017" Then

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTPURNETTAMT.Text))) / 100, "0.00")
        Else
            If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                If CHKPURTAXSERVCHGS.CheckState = CheckState.Checked Then
                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                Else
                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                End If
            End If
        End If

        If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
            If CMBPURADDSUB.Text = "Add" Then
                TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPURTAX.Text) + Val(TXTPURROUNDOFF.Text) + Val(TXTPUROTHERCHGS.Text), "0.00")
                'TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0")
            Else
                TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPURTAX.Text) + Val(TXTPURROUNDOFF.Text)) - Val(TXTPUROTHERCHGS.Text), "0.00")
                'TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - ((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text)) - Val(TXTPUROTHERCHGS.Text)), "0")
            End If
        Else
            If CMBPURADDSUB.Text = "Add" Then
                TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPUROTHERCHGS.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0")
                TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPURTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")
            Else
                TXTPURGTOTAL.Text = Format((Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text)) - Val(TXTPUROTHERCHGS.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPURROUNDOFF.Text.Trim), "0")
                TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - ((Val(TXTPURNETTAMT.Text) + Val(TXTPURCGSTAMT.Text.Trim) + Val(TXTPURSGSTAMT.Text.Trim) + Val(TXTPURIGSTAMT.Text.Trim) + Val(TXTPURTAX.Text)) - Val(TXTPUROTHERCHGS.Text)), "0.00")
            End If
        End If

        TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
        TXTFINALPURAMT.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")

        total()
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDBOOKINGS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
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
            GRIDBOOKINGS.Rows.Add(Val(TXTSRNO.Text.Trim), TXTPASSNAME.Text.Trim, Val(TXTAGE.Text.Trim), CMBSEX.Text.Trim, TXTSEATNO.Text.Trim, Val(TXTDNRATE.Text.Trim), TXTMIDDN.Text.Trim, Val(TXTMIDDNRATE.Text.Trim), TXTUP.Text.Trim, Val(TXTUPRATE.Text.Trim), TXTMIDUP.Text.Trim, Val(TXTMIDUPRATE.Text.Trim), CMBSTATUS.Text.Trim, CMBIDTYPE.Text.Trim, TXTIDNO.Text.Trim, TXTCONCESSION.Text.Trim)
            getsrno(GRIDBOOKINGS)

        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDBOOKINGS.Item(GPASSNAME.Index, temprow).Value = TXTPASSNAME.Text.Trim
            GRIDBOOKINGS.Item(GAGE.Index, temprow).Value = Val(TXTAGE.Text.Trim)
            GRIDBOOKINGS.Item(GSEX.Index, temprow).Value = CMBSEX.Text.Trim
            GRIDBOOKINGS.Item(GSEATNO.Index, temprow).Value = TXTSEATNO.Text.Trim
            GRIDBOOKINGS.Item(GDNRATE.Index, temprow).Value = Val(TXTDNRATE.Text.Trim)
            GRIDBOOKINGS.Item(GMIDDN.Index, temprow).Value = TXTMIDDN.Text.Trim
            GRIDBOOKINGS.Item(GMIDDNRATE.Index, temprow).Value = Val(TXTMIDDNRATE.Text.Trim)
            GRIDBOOKINGS.Item(GRAILUP.Index, temprow).Value = TXTUP.Text.Trim
            GRIDBOOKINGS.Item(GRAILUPRATE.Index, temprow).Value = Val(TXTUPRATE.Text.Trim)
            GRIDBOOKINGS.Item(GMIDUP.Index, temprow).Value = TXTMIDUP.Text.Trim
            GRIDBOOKINGS.Item(GMIDUPRATE.Index, temprow).Value = Val(TXTMIDUPRATE.Text.Trim)
            GRIDBOOKINGS.Item(GSTATUS.Index, temprow).Value = CMBSTATUS.Text.Trim
            GRIDBOOKINGS.Item(GIDTYPE.Index, temprow).Value = CMBIDTYPE.Text.Trim
            GRIDBOOKINGS.Item(GIDNO.Index, temprow).Value = TXTIDNO.Text.Trim
            GRIDBOOKINGS.Item(GCCode.Index, temprow).Value = TXTCONCESSION.Text.Trim

            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        TXTSRNO.Clear()
        TXTPASSNAME.Clear()
        TXTAGE.Clear()
        CMBSEX.SelectedIndex = 0
        TXTSEATNO.Clear()
        TXTDNRATE.Clear()
        TXTMIDDN.Clear()
        TXTMIDDNRATE.Clear()
        TXTUP.Clear()
        TXTUPRATE.Clear()
        TXTMIDUP.Clear()
        TXTMIDUPRATE.Clear()
        CMBSTATUS.SelectedIndex = 0
        CMBIDTYPE.Text = ""
        TXTIDNO.Clear()
        TXTCONCESSION.Clear()
        TXTSRNO.Focus()

    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDBOOKINGS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                TXTPASSNAME.Text = GRIDBOOKINGS.Item(GPASSNAME.Index, e.RowIndex).Value.ToString
                TXTAGE.Text = GRIDBOOKINGS.Item(GAGE.Index, e.RowIndex).Value.ToString
                CMBSEX.Text = GRIDBOOKINGS.Item(GSEX.Index, e.RowIndex).Value.ToString
                TXTSEATNO.Text = GRIDBOOKINGS.Item(GSEATNO.Index, e.RowIndex).Value.ToString
                TXTDNRATE.Text = Val(GRIDBOOKINGS.Item(GDNRATE.Index, e.RowIndex).Value)
                TXTMIDDN.Text = GRIDBOOKINGS.Item(GMIDDN.Index, e.RowIndex).Value.ToString
                TXTMIDDNRATE.Text = Val(GRIDBOOKINGS.Item(GMIDDNRATE.Index, e.RowIndex).Value)
                TXTUP.Text = GRIDBOOKINGS.Item(GRAILUP.Index, e.RowIndex).Value.ToString
                TXTUPRATE.Text = Val(GRIDBOOKINGS.Item(GRAILUPRATE.Index, e.RowIndex).Value)
                TXTMIDUP.Text = GRIDBOOKINGS.Item(GMIDUP.Index, e.RowIndex).Value.ToString
                TXTMIDUPRATE.Text = Val(GRIDBOOKINGS.Item(GMIDUPRATE.Index, e.RowIndex).Value)
                CMBSTATUS.Text = GRIDBOOKINGS.Item(GSTATUS.Index, e.RowIndex).Value.ToString
                CMBIDTYPE.Text = GRIDBOOKINGS.Item(GIDTYPE.Index, e.RowIndex).Value.ToString
                TXTIDNO.Text = GRIDBOOKINGS.Item(GIDNO.Index, e.RowIndex).Value.ToString
                TXTCONCESSION.Text = GRIDBOOKINGS.Item(GCCode.Index, e.RowIndex).Value.ToString
                temprow = e.RowIndex
                TXTSRNO.Focus()
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

                getsrno(GRIDBOOKINGS)
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
                RailwayBooking_Load(sender, e)
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

            Dim OBJBOOKING As New RailwayBookingDetails
            OBJBOOKING.MdiParent = MDIMain
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
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  RAILBOOKINGMASTER ", " AND RAILBOOKINGMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND RAILBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND RAILBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    RailwayBooking_Load(sender, e)
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
            'CODE MODIFIED BY GULKIT COZ WHEN WE PRESS NEXT IT GOES PREVIOUS TEMPBOOKING NO
            '            GRIDBOOKINGS.RowCount = 0
            'LINE1:
            '            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            '            getmax_BOOKING_no()
            '            Dim MAXNO As Integer = txtbookingno.Text.Trim
            'Line2:
            '            If TEMPBOOKINGNO > 0 Then

            '                Dim OBJCMN As New ClsCommon
            '                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO ", "", "  RAILBOOKINGMASTER ", " AND RAILBOOKINGMASTER.BOOKING_NO = '" & TEMPBOOKINGNO & "' AND RAILBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND RAILBOOKINGMASTER.BOOKING_YEARID = " & YearId)
            '                If DT.Rows.Count > 0 Then
            '                    edit = True
            '                    RailwayBooking_Load(sender, e)
            '                Else
            '                    TEMPBOOKINGNO = Val(TEMPBOOKINGNO - 1)
            '                    GoTo Line2
            '                End If
            '            Else
            '                clear()
            '                edit = False
            '            End If
            '            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
            '                txtbookingno.Text = TEMPBOOKINGNO
            '                GoTo LINE1
            '            End If

            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                RailwayBooking_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
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
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
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
            Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS SALEBAL, ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLACCBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("SALEBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLACCBAL.ForeColor = Color.Red
                Else
                    LBLACCBAL.ForeColor = Color.Green
                End If
            End If


            'CR LIMIT OF SALE PARTY
            DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ISNULL(ACC_CRDAYS,0) AS CRDAYS", "", "HOTELBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_LEDGERID AND ACC_CMPID = BOOKING_CMPID AND ACC_LOCATIONID = BOOKING_LOCATIONID AND ACC_YEARID = BOOKING_YEARID", " AND BOOKING_SALEBALANCE > 0 AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
                        MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
                        GoTo LINE1
                    End If
                Next
            End If


LINE1:

            'PUR BALANCE
            DT = OBJCMN.search("(CASE WHEN DR > 0 THEN 'Dr'  ELSE 'Cr' END) AS PURBAL , ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & CMBPURNAME.Text.Trim & "'  AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLPURBAL.Text = Convert.ToString(Val(DT.Rows(0).Item("BALANCE"))) & "  " & DT.Rows(0).Item("PURBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLPURBAL.ForeColor = Color.Red
                Else
                    LBLPURBAL.ForeColor = Color.Green
                End If
            End If


            'CR LIMIT OF PUR PARTY
            DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ISNULL(ACC_CRDAYS,0) AS CRDAYS", "", "HOTELBOOKINGMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_PURLEDGERID AND ACC_CMPID = BOOKING_CMPID AND ACC_LOCATIONID = BOOKING_LOCATIONID AND ACC_YEARID = BOOKING_YEARID", " AND BOOKING_PURBALANCE > 0 AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
                        MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
                        GoTo LINE2
                    End If
                Next
            End If
LINE2:


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
        Try
            If CMBACCCODE.Text.Trim <> "" Then GETBALANCE()
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



                Dim OBJCMN1 As New ClsCommon

                Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then

                    TXTSTATECODE.Text = DT1.Rows(0).Item("STATECODE")

                End If
                GETBALANCE()
                GETCHARGES()
                GETHSNCODE()
            End If

            If txtmobileno.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ACC_MOBILE, ISNULL(ACC_EMAIL,'') ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    txtmobileno.Text = DT.Rows(0).Item(0)
                    txtemailadd.Text = DT.Rows(0).Item(1)
                End If
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

                    Dim OBJBOOKING As New ClsRailBookingMaster
                    Dim ALPARAVAL As New ArrayList

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

    Private Sub TXTFARE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFARE.KeyPress, TXTDNRATE.KeyPress, TXTMIDDNRATE.KeyPress, TXTUPRATE.KeyPress, TXTMIDUPRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTFARE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFARE.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTIRCTC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTIRCTC.KeyPress
        numdotkeypress(e, TXTIRCTC, Me)
    End Sub

    Private Sub TXTIRCTC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTIRCTC.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTGATEWAY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGATEWAY.KeyPress
        numdotkeypress(e, TXTGATEWAY, Me)
    End Sub

    Private Sub TXTGATEWAY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGATEWAY.Validated
        PURCHASETOTAL()
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

    Private Sub TXTEXTRACHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdotkeypress(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub TXTEXTRACHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        total()
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
            If CMBPURCODE.Text.Trim <> "" Then GETBALANCE()
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

    Private Sub CMBPURNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" Then
                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT1.Rows.Count > 0 Then TXTPURSTATECODE.Text = DT1.Rows(0).Item("PURSTATECODE")
                GETBALANCE()
                GETHSNCODE()
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

    Private Sub ToolStripCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCANCEL.Click
        Try
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Cancel Booking Voucher?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If TEMPMSG = vbYes Then
                    Dim OBJHOTEL As New ClsRailBookingMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJHOTEL.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJHOTEL.CANCEL
                    TEMPMSG = MsgBox("Wish to Intimate Guest?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    'If TEMPMSG = vbYes Then SENDMSG("Hi, Your booking in " & cmbhotelname.Text.Trim & " is between " & ARRIVALDATE.Value.Date & " and " & DEPARTDATE.Value.Date & " is Cancelled", txtmobileno.Text.Trim)

                    MsgBox("Booking Cancelled")
                    clear()
                End If
            End If
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
                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV As New RailBookingVoucherDesign
                        OBJINV.MdiParent = MDIMain
                        OBJINV.BOOKINGNO = BOOKNO
                        OBJINV.FRMSTRING = "VOUCHER"
                        OBJINV.Show()
                    End If
                End If

                TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJINV As New RailBookingVoucherDesign
                    OBJINV.MdiParent = MDIMain
                    OBJINV.BOOKINGNO = BOOKNO
                    If ClientName = "SHREEJI" Or ClientName = "BARODA" Then OBJINV.SUBJECT = CMBNAME.Text.Trim
                    OBJINV.FRMSTRING = "INVOICE"
                    If ClientName = "UTTARAKHAND" Then OBJINV.SUBJECT = "Invoice No. " & BOOKNO & " Ref No. " & txtrefno.Text.Trim
                    OBJINV.Show()
                End If


                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Office Copy Of Invoice?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV As New RailBookingVoucherDesign
                        OBJINV.MdiParent = MDIMain
                        OBJINV.BOOKINGNO = BOOKNO
                        OBJINV.FRMSTRING = "INVOICEOFFICE"
                        OBJINV.Show()
                    End If
                End If

            ElseIf CMBPRINT.Text = "Voucher" Then

                Dim OBJINV As New RailBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.FRMSTRING = "VOUCHER"
                OBJINV.Show()

            ElseIf CMBPRINT.Text = "Invoice" Then

                Dim OBJINV As New RailBookingVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.FRMSTRING = "INVOICE"
                If ClientName = "UTTARAKHAND" Then OBJINV.SUBJECT = "Invoice No. " & BOOKNO & " Ref No. " & txtrefno.Text.Trim
                OBJINV.Show()

                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    TEMPMSG = MsgBox("Wish to Print Office Copy Of Invoice?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim OBJINV1 As New RailBookingVoucherDesign
                        OBJINV1.MdiParent = MDIMain
                        OBJINV1.BOOKINGNO = BOOKNO
                        OBJINV1.FRMSTRING = "INVOICEOFFICE"
                        OBJINV1.Show()
                    End If
                End If


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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = "RP-" & TEMPBOOKINGNO
            OBJRECPAY.SALEBILLINITIALS = "RS-" & TEMPBOOKINGNO
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
                    Dim OBJBOOKING As New ClsRailBookingMaster()

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
                            CMBHSNITEMDESC.Text = dr("HSNITEMDESC")

                            bookingdate.Value = Convert.ToDateTime(dr("BOOKINGDATE"))
                            JOURNEYDATE.Value = Convert.ToDateTime(dr("JOURNEYDATE"))


                            CMBLOGINID.Text = dr("LOGINID")
                            TXTPAYMODE.Text = dr("PAYMODE")
                            CMBTRAINNAME.Text = dr("TRAINNAME")
                            CMBTRAINNO.Text = dr("TRAINNO")
                            CMBCLASS.Text = dr("CLASS")
                            TXTARRTIME.Text = dr("ARRTIME")
                            TXTDEPTIME.Text = dr("DEPTIME")


                            CMBFROM.Text = dr("STATIONFROM")
                            TXTFROM.Text = dr("FROM")
                            CMBFROMCODE.Text = dr("FROM")
                            CMBTO.Text = dr("STATIONTO")
                            TXTTO.Text = dr("TO")
                            CMBTOCODE.Text = dr("TO")
                            CMBBOARDING.Text = dr("BOARDINGFROM")
                            TXTBOARDING.Text = dr("BFROM")
                            CMBBOARDINGCODE.Text = dr("BFROM")
                            CMBRESTO.Text = dr("RESTO")
                            TXTRESTO.Text = dr("RTO")
                            CMBRESTOCODE.Text = dr("RTO")
                            CMBTICKETTYPE.Text = dr("TICKETTYPE")
                            CMBQUOTA.Text = dr("QUOTA")


                            CMBPURCODE.Text = dr("PURCODE")
                            CMBPURNAME.Text = dr("PURNAME")
                            CMBACCCODE.Text = dr("ACCCODE")
                            CMBNAME.Text = dr("ACCNAME")

                            TXTADULTS.Text = dr("ADULTS")
                            TXTCHILDS.Text = dr("CHILD")

                            TXTFARE.Text = Format(Val(dr("FARE")), "0.00")
                            TXTIRCTC.Text = Format(Val(dr("IRCTC")), "0.00")
                            TXTGATEWAY.Text = Format(Val(dr("GATEWAY")), "0.00")


                            'PURCHASE VALUES
                            TXTDISCRECDPER.Text = dr("DISCRECDPER")
                            TXTDISCRECDRS.Text = dr("DISCRECDRS")
                            TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                            TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                            TXTPURTDSPER.Text = dr("PURTDSPER")
                            TXTPURTDSRS.Text = dr("PURTDSRS")
                            TXTPUREXTRACHGS.Text = dr("PUREXTRACHGS")
                            CMBPURTAX.Text = dr("PURTAXNAME")
                            TXTPURTAX.Text = dr("PURTAX")


                            CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                            If dr("PUROTHERCHGS") > 0 Then
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                                CMBPURADDSUB.Text = "Add"
                            Else
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                                CMBPURADDSUB.Text = "Sub."
                            End If

                            TXTPURROUNDOFF.Text = dr("PURROUNDOFF")



                            TXTTOTALSALEAMT.Text = dr("TOTALSALEAMT")
                            TXTOURCOMMPER.Text = dr("OURCOMMPER")
                            TXTOURCOMMRS.Text = dr("OURCOMMRS")

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

                            TXTHSNCODE.Text = dr("HSNCODE")
                            TXTPURHSNCODE.Text = dr("PURHSNCODE")
                            If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True

                            If CHKMANUAL.Checked = True Then
                                TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                                TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                                TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                            End If

                            If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True
                            If CHKPURMANUAL.Checked = True Then
                                TXTPURCGSTAMT.Text = Format(Val(dr("PURCGSTAMT")), 0.0)
                                TXTPURSGSTAMT.Text = Format(Val(dr("PURSGSTAMT")), 0.0)
                                TXTPURIGSTAMT.Text = Format(Val(dr("PURIGSTAMT")), 0.0)
                            End If

                            TXTCGSTPER.Text = dr("CGSTPER")
                            TXTCGSTAMT.Text = dr("CGSTAMT")
                            TXTSGSTPER.Text = dr("SGSTPER")
                            TXTSGSTAMT.Text = dr("SGSTAMT")
                            TXTIGSTPER.Text = dr("IGSTPER")
                            TXTIGSTAMT.Text = dr("IGSTAMT")
                            TXTPURSERVCHGS.Text = dr("PURTAXSERVCHGSAMT")
                            CHKPURTAXSERVCHGS.Checked = Convert.ToBoolean(dr("PURTAXSERVCHGS"))
                            TXTPURCGSTPER.Text = dr("PURCGSTPER")
                            TXTPURCGSTAMT.Text = dr("PURCGSTAMT")
                            TXTPURSGSTPER.Text = dr("PURSGSTPER")
                            TXTPURSGSTAMT.Text = dr("PURSGSTAMT")
                            TXTPURIGSTPER.Text = dr("PURIGSTPER")
                            TXTPURIGSTAMT.Text = dr("PURIGSTAMT")


                            TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                            TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))

                            TXTBAL.Text = Format(Val(TXTSALEBAL.Text), "0.00")

                            CMBBOOKEDBY.Text = dr("BOOKEDBY")
                            CMBSOURCE.Text = dr("SOURCE")
                            txtmobileno.Text = dr("MOBILENO")
                            txtemailadd.Text = dr("EMAILADD")
                            txtrefno.Text = dr("REFNO")
                            chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                            CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                            CHKREFUNDED.Checked = Convert.ToBoolean(dr("REFUNDED"))
                            CHKFAILED.Checked = Convert.ToBoolean(dr("FAILED"))

                            TXTCONFIRMEDBY.Text = dr("CONFIRMEDBY")
                            TXTCONFIRMATIONNO.Text = dr("CONFIRMATIONNO")
                            TEMPPNRNO = dr("CONFIRMATIONNO")


                            GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("AGE").ToString, dr("SEX").ToString, dr("SEATNO").ToString, Val(dr("DNRATE")), dr("MIDDN"), Val(dr("MIDDNRATE")), dr("UP"), Val(dr("UPRATE")), dr("MIDUP"), Val(dr("MIDUPRATE")), dr("STATUS").ToString, dr("IDTYPE").ToString, dr("IDNO").ToString, dr("CONCESSION").ToString)
                        Next
                        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                        GETCHARGES()
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

    Private Sub DNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    OBJdN.BILLNO = "RP-" & txtbookingno.Text.Trim
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try

            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec / Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
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
                    OBJCN.BILLNO = "RS-" & txtbookingno.Text.Trim
                    OBJCN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub bookingdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles bookingdate.Validating
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOURNEYDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles JOURNEYDATE.Validating
        If ClientName = "CLASSIC" Then
            If Not datecheck(JOURNEYDATE.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
        End If
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

        'OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\RAIL\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If gridupload.RowCount > 0 Then
            TXTSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If

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

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        Try
            If TXTFROM.Text.Trim <> "" And TXTBOARDING.Text.Trim = "" Then
                CMBBOARDING.Text = CMBFROM.Text.Trim
                TXTBOARDING.Text = TXTFROM.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTO.Validated
        Try
            If TXTTO.Text.Trim <> "" And TXTRESTO.Text.Trim = "" Then
                CMBRESTO.Text = CMBTO.Text.Trim
                TXTRESTO.Text = TXTTO.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONFIRMATIONNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCONFIRMATIONNO.Validating
        Try
            If TXTCONFIRMATIONNO.Text.Trim <> "" And (edit = False Or edit = True And TXTCONFIRMATIONNO.Text.Trim <> TEMPPNRNO) Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" BOOKING_NO AS BOOKINGNO", "", " RAILBOOKINGMASTER", " AND BOOKING_CONFIRMATIONNO = '" & TXTCONFIRMATIONNO.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("PNR No already present in Booking No " & DT.Rows(0).Item("BOOKINGNO"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RailwayBooking_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If ClientName = "CLASSIC" And ClientName = "TOPCOMM" And ClientName = "AMIGO" And ClientName = "PARAMOUNT" Or ClientName = "ARHAM" Then
        If ClientName = "CLASSIC" And ClientName = "AMIGO" And ClientName = "PARAMOUNT" Or ClientName = "ARHAM" Then
            Me.Close()
            Exit Sub
        End If
        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True

        If ClientName = "SHREEJI" Then
            CHKREFUNDED.Visible = True
            CHKFAILED.Visible = True
        End If

        If ClientName = "RAMKRISHNA" Or ClientName = "KHANNA" Then
            LBLTOUR.Visible = True
            CMBGROUPDEPARTURE.Visible = True
            GSEATNO.HeaderText = "Rail DN"
        Else
            LBLTOUR.Visible = False
            CMBGROUPDEPARTURE.Visible = False

            TXTDNRATE.Visible = False
            GDNRATE.Visible = False

            TXTMIDDN.Visible = False
            GMIDDN.Visible = False

            TXTMIDDNRATE.Visible = False
            GMIDDNRATE.Visible = False

            TXTUP.Visible = False
            GRAILUP.Visible = False

            TXTUPRATE.Visible = False
            GRAILUPRATE.Visible = False

            TXTMIDUP.Visible = False
            GMIDUP.Visible = False

            TXTMIDUPRATE.Visible = False
            GMIDUPRATE.Visible = False

            CMBSTATUS.Left -= 700
            CMBIDTYPE.Left -= 700
            TXTIDNO.Left -= 700
            TXTCONCESSION.Left -= 700

            GRIDBOOKINGS.Width -= 700

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
            LBLHSNDESC.Visible = False
            CMBHSNITEMDESC.Visible = False
            LBLHSNCODE.Visible = False
            TXTHSNCODE.Visible = False
            LBLPURHSNDESC.Visible = False
            CMBPURHSNITEMDESC.Visible = False
            LBLPURHSNCODE.Visible = False
            TXTPURHSNCODE.Visible = False
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False
            LBLPURSTATECODE.Visible = False
            TXTPURSTATECODE.Visible = False
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

        End If

        fillcmb()
        If CMBTRAINNAME.Text = "" Then FILLTRAINNAME(CMBTRAINNAME)
        If CMBTRAINNO.Text = "" Then FILLTRAINNO(CMBTRAINNO)
        If CMBFROM.Text = "" Then FILLSTATION(CMBFROM)
        If CMBTO.Text = "" Then FILLSTATION(CMBTO)
        If CMBBOARDING.Text = "" Then FILLSTATION(CMBBOARDING)
        If CMBRESTO.Text = "" Then FILLSTATION(CMBRESTO)

        If edit = False Then clear()

    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress
        numkeypress(e, TXTADULTS, Me)
    End Sub

    Private Sub TXTCHILDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILDS.KeyPress
        numkeypress(e, TXTCHILDS, Me)
    End Sub

    Private Sub TXTCONCESSION_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCONCESSION.Validating
        If TXTPASSNAME.Text.Trim <> "" And Val(TXTAGE.Text.Trim) > 0 And CMBSEX.Text.Trim <> "" And TXTSEATNO.Text.Trim <> "" And CMBSTATUS.Text.Trim <> "" Then
            fillgrid()
            PURCHASETOTAL()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Private Sub CMBTRAINNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRAINNO.Enter
        Try
            If CMBTRAINNO.Text.Trim = "" Then FILLTRAINNO(CMBTRAINNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNO.Validating
        Try
            If CMBTRAINNO.Text.Trim <> "" Then TRAINNOVALIDATE(CMBTRAINNO, CMBTRAINNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRAINNAME.Enter
        Try
            If CMBTRAINNAME.Text.Trim = "" Then FILLTRAINNAME(CMBTRAINNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRAINNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRAINNAME.Validating
        Try
            If CMBTRAINNAME.Text.Trim <> "" Then TRAINNAMEVALIDATE(CMBTRAINNAME, CMBTRAINNO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPASSNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPASSNAME.Validated
        Try
            If TXTPASSNAME.Text.Trim = "" Then TXTFARE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOGINID_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOGINID.Validating
        Try
            If CMBLOGINID.Text.Trim <> "" Then LOGINVALIDATE(CMBLOGINID, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROM.Enter
        Try
            If CMBFROM.Text.Trim = "" Then FILLSTATION(CMBFROM)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOGINID_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLOGINID.Enter
        Try
            If CMBLOGINID.Text.Trim = "" Then filllogin(CMBLOGINID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTO.Enter
        Try
            If CMBTO.Text.Trim = "" Then FILLSTATION(CMBTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOARDING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOARDING.Enter
        Try
            If CMBBOARDING.Text.Trim = "" Then FILLSTATION(CMBBOARDING)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRESTO.Enter
        Try
            If CMBRESTO.Text.Trim = "" Then FILLSTATION(CMBRESTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMCODE.Enter
        Try
            If CMBFROMCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBFROMCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMCODE.Validated
        Try
            If CMBFROMCODE.Text.Trim <> "" And CMBBOARDING.Text.Trim = "" Then
                CMBBOARDING.Text = CMBFROM.Text.Trim
                CMBBOARDINGCODE.Text = CMBFROMCODE.Text.Trim
                TXTBOARDING.Text = CMBFROMCODE.Text.Trim
            End If
            TXTFROM.Text = CMBFROMCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCODE.Validating
        Try
            If CMBFROMCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBFROMCODE, CMBFROM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOCODE.Enter
        Try
            If CMBTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBTOCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTOCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRESTOCODE.Enter
        Try
            If CMBRESTOCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBRESTOCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTOCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRESTOCODE.Validated
        Try
            TXTRESTO.Text = CMBRESTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRESTOCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRESTOCODE.Validating
        Try
            If CMBRESTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBRESTOCODE, CMBRESTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOCODE.Validated
        Try
            If CMBTOCODE.Text.Trim <> "" And CMBRESTO.Text.Trim = "" Then
                CMBRESTO.Text = CMBTO.Text.Trim
                CMBRESTOCODE.Text = CMBTOCODE.Text.Trim
                TXTRESTO.Text = CMBTOCODE.Text.Trim
            End If
            TXTTO.Text = CMBTOCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCODE.Validating
        Try
            If CMBTOCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBTOCODE, CMBTO, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOARDINGCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOARDINGCODE.Enter
        Try
            If CMBBOARDINGCODE.Text.Trim = "" Then FILLSTATIONCODE(CMBBOARDINGCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOARDINGCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBOARDINGCODE.Validated
        Try
            TXTBOARDING.Text = CMBBOARDINGCODE.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOARDINGCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOARDINGCODE.Validating
        Try
            If CMBBOARDINGCODE.Text.Trim <> "" Then STATIONCODEVALIDATE(CMBBOARDINGCODE, CMBBOARDING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBIDTYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBIDTYPE.Enter
        Try
            If CMBIDTYPE.Text.Trim = "" Then fillIdType(CMBIDTYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBIDTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBIDTYPE.Validating
        Try
            If CMBIDTYPE.Text.Trim <> "" Then IDTYPEVALIDATE(CMBIDTYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txttax.ReadOnly = False
                        txttax.Enabled = True
                    End If
                End If
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

    Private Sub CMBPUROTHERCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPUROTHERCHGS.Validated
        Try
            If CMBPUROTHERCHGS.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPUROTHERCHGS.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        TXTPUROTHERCHGS.ReadOnly = False
                        TXTPUROTHERCHGS.Enabled = True
                    End If
                End If
            Else
                TXTPUROTHERCHGS.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbookingno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbookingno.Validating
        Try
            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(txtbookingno.Text.Trim))
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

            ElseIf (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "UTTARAKHAND" Or ClientName = "MILONI" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "NAMASTE" Then
                If Val(txtbookingno.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_NO AS BOOKINGNO ", "", " RAILBOOKINGMASTER", " AND BOOKING_NO = '" & txtbookingno.Text.Trim & "' AND BOOKING_CMPID=" & CmpId & " and BOOKING_locationid=" & Locationid & " and BOOKING_yearid=" & YearId)
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

    Private Sub CMBQUOTA_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUOTA.Validating
        Try
            GETCHARGES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETCHARGES()
        Try
            If CMBCLASS.Text <> "" And CMBQUOTA.Text <> "" And CMBNAME.Text.Trim <> "" Then
                Dim OBJSEARCH As New ClsCommon
                Dim DT As DataTable = OBJSEARCH.search(" ISNULL(RAILWAY_CONFIG.RAILWAY_RATE, 0) AS RATE ", "", "  RAILWAY_CONFIG INNER JOIN LEDGERS ON RAILWAY_CONFIG.RAILWAY_ledgerid = LEDGERS.Acc_id AND RAILWAY_CONFIG.RAILWAY_cmpid = LEDGERS.Acc_cmpid AND RAILWAY_CONFIG.RAILWAY_locationid = LEDGERS.Acc_locationid And RAILWAY_CONFIG.RAILWAY_yearid = LEDGERS.Acc_yearid", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CLASS='" & CMBCLASS.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_TYPE='" & CMBQUOTA.Text.Trim & "' AND RAILWAY_CONFIG.RAILWAY_CMPID=" & CmpId & " and RAILWAY_CONFIG.RAILWAY_locationid=" & Locationid & " and RAILWAY_CONFIG.RAILWAY_yearid=" & YearId)
                If DT.Rows.Count > 0 Then
                    cmbaddsub.Text = "Add"
                    CMBOTHERCHGS.Text = "Service Chgs"
                    txtotherchg.Text = Val(DT.Rows(0).Item("RATE")) * Val(TXTTOTALPAX.Text.Trim)
                    total()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function GetTextFromPDF(ByVal PdfFileName As String) As String
        'Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

        Dim sOut = ""
        'For i = 1 To oReader.NumberOfPages
        '    Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy
        '    sOut &= iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
        'Next

        'Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        'Dim doc As iTextSharp.text.Document = Nothing
        ''Dim doc As PdfManipulation.DocumentEx = Nothing
        'Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        'Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Try
            '    reader = New iTextSharp.text.pdf.PdfReader(PdfFileName)
            '    doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
            '    'doc = New PdfManipulation.DocumentEx(reader.GetPageSizeWithRotation(pageNumberToExtract))
            '    'Debug.WriteLine("Add producer: " & doc.AddProducer().ToString)
            '    pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream("c:\PDFTEST.pdf", IO.FileMode.Create))

            '    Dim acfields As AcroFields
            '    acfields = reader.AcroFields
            '    MsgBox(acfields.Fields.Keys.Count)


            '    doc.Open()
            '    page = pdfCpy.GetImportedPage(reader, 1)
            '    pdfCpy.AddPage(page)
            '    doc.Close()
            '    reader.Close()

            Dim its As ITextExtractionStrategy = New iTextSharp.text.pdf.parser.LocationTextExtractionStrategy()
            Using reader As New PdfReader(PdfFileName)
                Dim text As New StringBuilder()

                For i As Integer = 1 To 1
                    Dim thePage As String = PdfTextExtractor.GetTextFromPage(reader, i, its)
                    Dim theLines As String() = thePage.Split(ControlChars.Lf)
                    For Each theLine As String In theLines
                        text.AppendLine(theLine)
                    Next
                Next
                Return text.ToString()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
        Return sOut

    End Function

    Private Sub TOOLUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLUPLOAD.Click

        On Error Resume Next
        OPENDIALOGUPLOAD.FileName = ""
        OPENDIALOGUPLOAD.Filter = "HTML (*.htm;*.mht;*.html;*.pfd)|*.htm;*.mht;*.html;*.pdf"
        OPENDIALOGUPLOAD.ShowDialog()
        Dim CONTENT As String = ""
        Dim STARTPOS As Integer = 0
        Dim ENDPOS As Integer = 0
        Dim D As Integer
        Dim MON As Integer
        Dim Y As Integer

        If OPENDIALOGUPLOAD.FileName <> "" And OPENDIALOGUPLOAD.FileName <> "OPENDIALOGUPLOAD" Then CONTENT = LoadSiteContent(OPENDIALOGUPLOAD.FileName) Else Exit Sub

        'get FILE EXTENSION
        If Path.GetExtension(OPENDIALOGUPLOAD.FileName) = ".pdf" Then




            Dim PDFTEXT As String = GetTextFromPDF(OPENDIALOGUPLOAD.FileName)
            ''RND BY GULKIT **************
            'PDFTEXT = PDFTEXT.Replace(vbNewLine, "")
            'PDFTEXT = PDFTEXT.Replace(vbCr, "")
            'PDFTEXT = PDFTEXT.Replace(vbCrLf, "")
            'PDFTEXT = PDFTEXT.Replace(" ", "")
            ''REMOVE ALL BLANKSPACES AND ENTER FROM PDFTEXT
            '********RND****************


            'COPY DATA IN NOTEPAD FILE
            Dim FILENAME = "C:\PDFTEXT.txt"
            If File.Exists(FILENAME) = True Then
                Dim objWriter As New System.IO.StreamWriter(FILENAME)
                objWriter.Write(PDFTEXT)
                objWriter.Close()
            End If



            'FETCH DATA FROM NOTEPAD FILE
            'PNR NO
            STARTPOS = PDFTEXT.IndexOf("PNR No: ")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" PNR No:")
            TXTCONFIRMATIONNO.Text = PDFTEXT.Substring(STARTPOS + 8, 10)

            'TRANSACTION ID
            STARTPOS = PDFTEXT.IndexOf("Transaction ID: ")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Transaction ID:")
            TXTTRANSID.Text = PDFTEXT.Substring(STARTPOS + 16, 15)

            'TRAIN NAME
            STARTPOS = PDFTEXT.IndexOf("Train No. & Name:")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf("Train No. & Name:")
            ENDPOS = PDFTEXT.IndexOf("/", STARTPOS)
            CMBTRAINNO.Text = PDFTEXT.Substring(STARTPOS + 17, ENDPOS - STARTPOS - 17).Trim

            'QUOTA
            STARTPOS = PDFTEXT.IndexOf("Quota: ")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Quota:")
            ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
            CMBQUOTA.Text = PDFTEXT.Substring(STARTPOS + 7, ENDPOS - STARTPOS - 7).Trim


            'CLASS
            STARTPOS = PDFTEXT.IndexOf("Class: ")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Class:")
            STARTPOS = PDFTEXT.IndexOf("(", STARTPOS)
            ENDPOS = PDFTEXT.IndexOf(")", STARTPOS)
            CMBCLASS.Text = PDFTEXT.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            'FROM
            STARTPOS = PDFTEXT.IndexOf("From:")
            ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
            CMBFROM.Text = PDFTEXT.Substring(STARTPOS + 5, ENDPOS - STARTPOS - 5).Trim

            'FROMCODE
            STARTPOS = PDFTEXT.IndexOf("(", STARTPOS)
            ENDPOS = PDFTEXT.IndexOf(")", STARTPOS)
            CMBFROMCODE.Text = PDFTEXT.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            'TO
            STARTPOS = PDFTEXT.IndexOf("To:")
            ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
            CMBTO.Text = PDFTEXT.Substring(STARTPOS + 3, ENDPOS - STARTPOS - 3).Trim

            'TOCODE
            STARTPOS = PDFTEXT.IndexOf("(", STARTPOS)
            ENDPOS = PDFTEXT.IndexOf(")", STARTPOS)
            CMBTOCODE.Text = PDFTEXT.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            'DATE OF JOURNEY
            STARTPOS = PDFTEXT.IndexOf("Date Of Journey :")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Date Of Journey:")
            If STARTPOS = -1 Then
                STARTPOS = PDFTEXT.IndexOf("Date Of Journey:", System.StringComparison.CurrentCultureIgnoreCase)
                If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf("Date of Journey:")
                ENDPOS = STARTPOS + 18
                D = PDFTEXT.Substring(STARTPOS + 16, ENDPOS - STARTPOS - 16).Trim
            Else
                ENDPOS = STARTPOS + 19
                D = PDFTEXT.Substring(STARTPOS + 17, 2).Trim
            End If
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 3
            MON = Convert.ToDateTime("01-" + PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim + "-2014").Month
            STARTPOS = ENDPOS + 1
            If PDFTEXT.Substring(STARTPOS, 1).Trim = "-" Then STARTPOS += 1

            ENDPOS = STARTPOS + 4
            Y = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            JOURNEYDATE.Value = Convert.ToDateTime(D & "-" & MON & "-" & Y).Date


            'DATE OF BOARDING 
            STARTPOS = PDFTEXT.IndexOf("Date Of Boarding:")
            ENDPOS = STARTPOS + 19
            If STARTPOS < 0 Then
                STARTPOS = PDFTEXT.IndexOf(" Date Of Boarding:")
                ENDPOS = STARTPOS + 20
                D = PDFTEXT.Substring(STARTPOS + 18, ENDPOS - STARTPOS - 18).Trim
            Else
                D = PDFTEXT.Substring(STARTPOS + 17, ENDPOS - STARTPOS - 17).Trim
            End If
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 3
            MON = Convert.ToDateTime("01-" + PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim + "-2014").Month
            STARTPOS = ENDPOS + 1
            If PDFTEXT.Substring(STARTPOS, 1).Trim = "-" Then STARTPOS += 1

            ENDPOS = STARTPOS + 4
            Y = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            BOARDINGDATE.Value = Convert.ToDateTime(D & "-" & MON & "-" & Y).Date

            'BOARDING
            STARTPOS = PDFTEXT.IndexOf("Boarding At:")
            If STARTPOS < 0 Then
                STARTPOS = PDFTEXT.IndexOf(" Boarding At:")
                ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
                CMBBOARDING.Text = PDFTEXT.Substring(STARTPOS + 13, ENDPOS - STARTPOS - 13).Trim
            Else
                ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
                CMBBOARDING.Text = PDFTEXT.Substring(STARTPOS + 12, ENDPOS - STARTPOS - 12).Trim
            End If

            'BOARDINGCODE
            STARTPOS = PDFTEXT.IndexOf("(", STARTPOS)
            ENDPOS = PDFTEXT.IndexOf(")", STARTPOS)
            CMBBOARDINGCODE.Text = PDFTEXT.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            'RES UPTO
            STARTPOS = PDFTEXT.IndexOf("Resv . Upto:")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Resv. Upto:")
            If STARTPOS = -1 Then
                STARTPOS = PDFTEXT.IndexOf("Resv. Upto:")
                ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
                CMBRESTO.Text = PDFTEXT.Substring(STARTPOS + 11, ENDPOS - STARTPOS - 11).Trim
            Else
                ENDPOS = PDFTEXT.IndexOf("(", STARTPOS)
                CMBRESTO.Text = PDFTEXT.Substring(STARTPOS + 12, ENDPOS - STARTPOS - 12).Trim
            End If


            'RES UPTOCODE
            STARTPOS = PDFTEXT.IndexOf("(", STARTPOS)
            ENDPOS = PDFTEXT.IndexOf(")", STARTPOS)
            CMBRESTOCODE.Text = PDFTEXT.Substring(STARTPOS + 1, ENDPOS - STARTPOS - 1).Trim

            'SCHEDULED DEPARTURE
            STARTPOS = PDFTEXT.IndexOf("Scheduled Departure:")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Scheduled Departure:")
            ENDPOS = PDFTEXT.IndexOf("*", STARTPOS) - 1
            If ENDPOS > STARTPOS + 20 Then TXTDEPTIME.Text = PDFTEXT.Substring(STARTPOS + 20, ENDPOS - STARTPOS - 20).Trim Else TXTDEPTIME.Text = ""

            'SCHEDULED ARRIVAL
            STARTPOS = PDFTEXT.IndexOf("Scheduled Arrival:")
            If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf(" Scheduled Arrival:")
            If STARTPOS > 0 Then
                ENDPOS = PDFTEXT.IndexOf("*", STARTPOS)
                If ENDPOS > STARTPOS + 19 Then TXTARRTIME.Text = PDFTEXT.Substring(STARTPOS + 19, ENDPOS - STARTPOS - 19).Trim Else TXTARRTIME.Text = ""
            End If

            'ADULTS
            STARTPOS = PDFTEXT.IndexOf("Adult:")
            ENDPOS = STARTPOS + 7
            TXTADULTS.Text = PDFTEXT.Substring(STARTPOS + 6, ENDPOS - STARTPOS - 6).Trim

            'CHILDS
            STARTPOS = PDFTEXT.IndexOf("Child:")
            ENDPOS = STARTPOS + 7
            TXTCHILDS.Text = PDFTEXT.Substring(STARTPOS + 6, ENDPOS - STARTPOS - 6).Trim

            'TICEKT FARE
            STARTPOS = PDFTEXT.IndexOf("Ticket Fare **")
            If STARTPOS < 0 Then
                STARTPOS = PDFTEXT.IndexOf(" Ticket Fare **")
                ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                TXTFARE.Text = Format(Val(PDFTEXT.Substring(STARTPOS + 15, ENDPOS - STARTPOS - 15).Trim), "0.00")
            Else
                STARTPOS = PDFTEXT.IndexOf("Only", STARTPOS) + 4
                ENDPOS = PDFTEXT.IndexOf("IRCTC Service", STARTPOS)

                If ENDPOS - STARTPOS <= 2 Or ENDPOS - STARTPOS >= 11 Then
                    STARTPOS = PDFTEXT.IndexOf("Ticket Fare **") + 14
                    ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                End If

                TXTFARE.Text = Format(Val(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 2).Trim), "0.00")

                If Val(TXTFARE.Text.Trim) = 0 Then
                    STARTPOS = PDFTEXT.IndexOf("Ticket Fare **") + 14
                    STARTPOS = PDFTEXT.IndexOf("Only", STARTPOS) + 4
                    ENDPOS = PDFTEXT.IndexOf("Catering", STARTPOS)
                    TXTFARE.Text = Format(Val(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 2).Trim), "0.00")
                End If
            End If


            'CATERING FARE
            STARTPOS = PDFTEXT.IndexOf("Catering Charges")
            If STARTPOS > 0 Then
                ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                TXTFARE.Text = Format(Val(PDFTEXT.Substring(STARTPOS + 16, ENDPOS - STARTPOS - 16).Trim) + Val(TXTFARE.Text.Trim), "0.00")
            Else
                STARTPOS = PDFTEXT.IndexOf(" Catering Charges")
                If STARTPOS > 0 Then
                    ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                    TXTFARE.Text = Format(Val(PDFTEXT.Substring(STARTPOS + 17, ENDPOS - STARTPOS - 17).Trim) + Val(TXTFARE.Text.Trim), "0.00")
                End If
            End If

            'IRCTC CHARGES
            STARTPOS = PDFTEXT.IndexOf("Tax) # ")
            If STARTPOS = -1 Then
                STARTPOS = PDFTEXT.IndexOf("(Incl. of Service")
                If STARTPOS < 0 Then
                    STARTPOS = PDFTEXT.IndexOf(" IRCTC Service Charge (Incl. of Service Tax) #")
                    ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                    TXTIRCTC.Text = Format(Val(PDFTEXT.Substring(STARTPOS + 46, 5).Trim), "0.00")
                Else
                    ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                    TXTIRCTC.Text = Format(Val(PDFTEXT.Substring(STARTPOS + 19, 5).Trim), "0.00")
                End If
            Else
                STARTPOS = PDFTEXT.IndexOf("Only", STARTPOS) + 4
                ENDPOS = PDFTEXT.IndexOf("Total Fare", STARTPOS)

                If ENDPOS - STARTPOS <= 2 Then
                    STARTPOS = PDFTEXT.IndexOf("Tax) # ") + 7
                    ENDPOS = PDFTEXT.IndexOf("Rupees", STARTPOS)
                End If

                'MsgBox("")
                TXTIRCTC.Text = Format(Val(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim), "0.00")
            End If


            '******************* FOR GRID *****************

            Dim N As String = ""    'FOR NAME
            Dim A As Integer = 0    'FOR AGE
            Dim S As String = "M"   'FOR SEX
            Dim C As String = ""    'FOR CONCESSION CODE
            Dim ST As String = ""    'FOR STATUS"
            Dim SEAT As String = ""   'FOR SEATNO
            Dim IDTYPE As String = ""    'FOR IDTYPE
            Dim IDNO As String = ""   'FOR IDNO

            Dim INITIALSTART As Integer = ENDPOS



            Dim Number As String = "0123456789"
            Dim anyof As Char() = Number.ToCharArray()



            'FOR FIRST LINE
            '*****************************************************
            If CMBQUOTA.Text = "General" Then

                STARTPOS = PDFTEXT.IndexOf("Current Status ID Card Type ID Card Number")
                If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf("Current Status") + 18 Else STARTPOS = STARTPOS + 47

                If STARTPOS = 17 Then STARTPOS = PDFTEXT.IndexOf("Current Status") + 18

                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CMBQUOTA.Text = "Premium Tatkal" Or CMBQUOTA.Text = "Tatkal" Then
                STARTPOS = PDFTEXT.IndexOf("Current Status")
                If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf("Current Status") + 18 Else STARTPOS = PDFTEXT.IndexOf("Current Status") + 19
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                STARTPOS = PDFTEXT.IndexOf("ID Card Number")
                If STARTPOS < 0 Then STARTPOS = PDFTEXT.IndexOf("ID Card Number") + 18 Else STARTPOS = PDFTEXT.IndexOf("ID Card Number") + 18
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim


            'CONCESSION CODE
            If PDFTEXT.IndexOf("Concession") > 0 Then
                STARTPOS = ENDPOS
                ENDPOS = STARTPOS + 6
                C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If



            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4



            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If


            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)

            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '            'ENDPOS = ENDPOS - 4
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If
            'End If
            '********************** *************************

NEXTLINE:

            GRIDBOOKINGS.Rows.Add(1, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF FIRST LINE **************************






            'FOR SECOND LINE
            '*****************************************************
            If Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) = 1 Then GoTo CODEFINISH
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 2 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then
                    ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
                End If
            End If
            'MsgBox(PDFTEXT.Substring(ENDPOS + 30, 10).Trim)
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "is booked" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS + 30, 10).Trim = "ticket is" Then GoTo CODEFINISH

            If CMBQUOTA.Text = "General" Then
                'MsgBox(PDFTEXT.Substring(ENDPOS, 10).Trim)
                If PDFTEXT.IndexOf("Current Status ID Card Type ID Card Number") Then ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS + 35)

                STARTPOS = ENDPOS + 2
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                Dim TEMPSTART As Integer = STARTPOS
                STARTPOS = ENDPOS + 1
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS + 1 = ENDPOS Then STARTPOS = TEMPSTART
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If



            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim


            'CONCESSION CODE
            If PDFTEXT.IndexOf("Concession") > 0 Then
                STARTPOS = ENDPOS
                ENDPOS = STARTPOS + 6
                C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4


            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If



            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)


            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE1
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If

            'End If
            '********************** *************************
NEXTLINE1:

            GRIDBOOKINGS.Rows.Add(2, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF SECOND LINE **************************




            'FOR THIRD LINE
            '*****************************************************
            If Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) = 2 Then GoTo CODEFINISH
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 2 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then
                    ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
                End If
            End If
            'MsgBox(PDFTEXT.Substring(ENDPOS, 10).Trim)
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "is booked" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS + 30, 10).Trim = "ticket is" Then GoTo CODEFINISH

            If CMBQUOTA.Text = "General" Then
                STARTPOS = ENDPOS + 2
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                Dim TEMPSTART As Integer = STARTPOS
                STARTPOS = ENDPOS + 1
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS + 1 = ENDPOS Then STARTPOS = TEMPSTART
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim



            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4


            'CONCESSION CODE
            STARTPOS = PDFTEXT.IndexOf("Concession")
            If STARTPOS <> -1 Then
                STARTPOS = ENDPOS
                If PDFTEXT.Substring(STARTPOS, 2) <> "  " Then
                    STARTPOS = STARTPOS + 1
                    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
                    C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                Else
                    ENDPOS = ENDPOS + 1
                End If
            End If



            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If



            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)

            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE2
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If

            'End If
            '********************** *************************

NEXTLINE2:
            GRIDBOOKINGS.Rows.Add(3, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF THIRD LINE **************************




            'FOR FOURTH LINE
            '*****************************************************
            If Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) = 3 Then GoTo CODEFINISH
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 2 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then
                    ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
                End If
            End If
            'MsgBox(PDFTEXT.Substring(ENDPOS, 10).Trim)
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "is booked" Then GoTo CODEFINISH

            If CMBQUOTA.Text = "General" Then
                STARTPOS = ENDPOS + 2
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                Dim TEMPSTART As Integer = STARTPOS
                STARTPOS = ENDPOS + 1
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS + 1 = ENDPOS Then STARTPOS = TEMPSTART
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim



            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4


            'CONCESSION CODE
            STARTPOS = PDFTEXT.IndexOf("Concession")
            If STARTPOS <> -1 Then
                STARTPOS = ENDPOS
                If PDFTEXT.Substring(STARTPOS, 2) <> "  " Then
                    STARTPOS = STARTPOS + 1
                    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
                    C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                Else
                    ENDPOS = ENDPOS + 1
                End If
            End If



            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If



            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)

            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE3
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If

            'End If
            '********************** *************************

NEXTLINE3:
            GRIDBOOKINGS.Rows.Add(4, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF FOURTH LINE **************************





            'FOR FIFTH LINE
            '*****************************************************
            If Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) = 4 Then GoTo CODEFINISH
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 2 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then
                    ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
                End If
            End If
            'MsgBox(PDFTEXT.Substring(ENDPOS, 10).Trim)
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "is booked" Then GoTo CODEFINISH

            If CMBQUOTA.Text = "General" Then
                STARTPOS = ENDPOS + 2
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                Dim TEMPSTART As Integer = STARTPOS
                STARTPOS = ENDPOS + 1
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS + 1 = ENDPOS Then STARTPOS = TEMPSTART
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim



            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4


            'CONCESSION CODE
            STARTPOS = PDFTEXT.IndexOf("Concession")
            If STARTPOS <> -1 Then
                STARTPOS = ENDPOS
                If PDFTEXT.Substring(STARTPOS, 2) <> "  " Then
                    STARTPOS = STARTPOS + 1
                    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
                    C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                Else
                    ENDPOS = ENDPOS + 1
                End If
            End If



            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If



            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)

            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE4
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If

            'End If
            '********************** *************************

NEXTLINE4:
            GRIDBOOKINGS.Rows.Add(5, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF FIFTH LINE **************************



            'FOR SIXTH LINE
            '*****************************************************
            If Val(TXTADULTS.Text.Trim) + Val(TXTCHILDS.Text.Trim) = 5 Then GoTo CODEFINISH
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 2 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then
                    ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
                End If
            End If
            'MsgBox(PDFTEXT.Substring(ENDPOS, 10).Trim)
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then GoTo CODEFINISH
            If PDFTEXT.Substring(ENDPOS, 10).Trim = "is booked" Then GoTo CODEFINISH

            If CMBQUOTA.Text = "General" Then
                STARTPOS = ENDPOS + 2
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                Dim TEMPSTART As Integer = STARTPOS
                STARTPOS = ENDPOS + 1
                ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                If STARTPOS + 1 = ENDPOS Then STARTPOS = TEMPSTART
                If STARTPOS = ENDPOS Then
                    STARTPOS += 1
                    ENDPOS = PDFTEXT.IndexOfAny(anyof, STARTPOS)
                End If
                N = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'AGE
            STARTPOS = ENDPOS
            ENDPOS = STARTPOS + 3
            A = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'SEX
            STARTPOS = ENDPOS
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            S = PDFTEXT.Substring(STARTPOS, 1).Trim
            If S = "" Then S = PDFTEXT.Substring(STARTPOS + 1, 1).Trim



            If PDFTEXT.IndexOf("VEG") > 0 Then ENDPOS = ENDPOS + 4


            'CONCESSION CODE
            STARTPOS = PDFTEXT.IndexOf("Concession")
            If STARTPOS <> -1 Then
                STARTPOS = ENDPOS
                If PDFTEXT.Substring(STARTPOS, 2) <> "  " Then
                    STARTPOS = STARTPOS + 1
                    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
                    C = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                Else
                    ENDPOS = ENDPOS + 1
                End If
            End If



            'STATUS AND SEAT
            STARTPOS = ENDPOS + 1
            ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            If ENDPOS - STARTPOS > 5 Then
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            Else
                If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            End If
            If PDFTEXT.Substring(STARTPOS, 2) = " C" Or PDFTEXT.Substring(STARTPOS, 2) = " R" Then STARTPOS += 1
            If PDFTEXT.Substring(STARTPOS, 2).Trim = "CN" Then
                ST = "CONFIRMED"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                ST = "RAC"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            Else
                ST = "WAITING"
                SEAT = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            End If


            'FROM 30-09-15 ID TYPE AND ID NO IS NOT PRESENT IN THE TICKETS, SO SKIP THIS SECTION
            '********************** *************************
            'If CMBQUOTA.Text = "Tatkal" Or CMBQUOTA.Text = "Premium Tatkal" Then
            '    'THIS CODE IS WRITTEN TO SKIP CURRENT STATUS COLUMN
            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '    If ENDPOS - STARTPOS > 5 Then
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 6) = "WINDOW" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    Else
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "SIDE" Or PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 2) = "NO" Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    End If



            '    STARTPOS = ENDPOS + 1
            '    ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)

            '    If ENDPOS = STARTPOS Then
            '        IDTYPE = ""
            '        IDNO = ""
            '        GoTo NEXTLINE5
            '    End If

            '    If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    If LCase(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim) <> "pan card" Then If (ENDPOS - STARTPOS) <= 8 Then ENDPOS = PDFTEXT.IndexOf(" ", ENDPOS + 1)
            '    IDTYPE = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            '    'ID NO
            '    STARTPOS = ENDPOS + 1
            '    If PDFTEXT.Substring(ENDPOS, 10).Trim = "ticket is" Then
            '        ENDPOS = PDFTEXT.IndexOf("This", STARTPOS)
            '        IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '    Else
            '        ENDPOS = PDFTEXT.IndexOf(" ", STARTPOS)
            '        If PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Substring(PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Length - 4) = "This" Then
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS - 4).Trim
            '        Else
            '            IDNO = PDFTEXT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            '        End If
            '    End If

            'End If
            '********************** *************************

NEXTLINE5:
            GRIDBOOKINGS.Rows.Add(6, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
            '********************** END OF SIXTH LINE **************************




            '******************* FOR GRID *****************
CODEFINISH:
            total()
        Else

            'HTML FORMAT

            'PNR NO
            STARTPOS = CONTENT.IndexOf("PNR No:")
            If STARTPOS > 0 Then TXTCONFIRMATIONNO.Text = CONTENT.Substring(STARTPOS + 13, 10)

            'TRANSACTION NO
            STARTPOS = CONTENT.IndexOf("Transaction ID:")
            If STARTPOS > 0 Then TXTTRANSID.Text = CONTENT.Substring(STARTPOS + 21, 10)


            'TRAIN NO AND NAME
            STARTPOS = CONTENT.IndexOf("Train No. &amp; Name:")
            If STARTPOS > 0 Then CMBTRAINNO.Text = CONTENT.Substring(STARTPOS + 27, 5)
            STARTPOS = STARTPOS + 33
            ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
            CMBTRAINNAME.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'QUOTA
            STARTPOS = CONTENT.IndexOf("Quota:") + 12
            ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
            CMBQUOTA.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'CLASS
            STARTPOS = CONTENT.IndexOf("Class:") + 12
            ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
            CMBCLASS.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'FROM
            STARTPOS = CONTENT.IndexOf("From:") + 11
            ENDPOS = CONTENT.IndexOf("(", STARTPOS)
            CMBFROM.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'FROMCODE
            STARTPOS = ENDPOS + 1
            ENDPOS = CONTENT.IndexOf(")", STARTPOS)
            CMBFROMCODE.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'DATE OF JOURNEY
            STARTPOS = CONTENT.IndexOf("Date of Journey:") + 22
            ENDPOS = STARTPOS + 2
            D = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 3
            MON = Convert.ToDateTime("01-" + CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim + "-2014").Month
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 4
            Y = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            JOURNEYDATE.Value = Convert.ToDateTime(D & "-" & MON & "-" & Y).Date

            'TO
            STARTPOS = CONTENT.IndexOf("&nbsp;To:") + 15
            ENDPOS = CONTENT.IndexOf("(", STARTPOS)
            CMBTO.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'TOCODE
            STARTPOS = ENDPOS + 1
            ENDPOS = CONTENT.IndexOf(")", STARTPOS)
            CMBTOCODE.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'BOARDING
            STARTPOS = CONTENT.IndexOf("Boarding:") + 15
            ENDPOS = CONTENT.IndexOf("(", STARTPOS)
            CMBBOARDING.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'BOARDINGCODE
            STARTPOS = ENDPOS + 1
            ENDPOS = CONTENT.IndexOf(")", STARTPOS)
            CMBBOARDINGCODE.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim


            'DATE OF BOARDING 
            STARTPOS = CONTENT.IndexOf("Date&nbsp;of&nbsp;Boarding:", STARTPOS) + 33
            ENDPOS = STARTPOS + 2
            D = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 3
            MON = Convert.ToDateTime("01-" + CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim + "-2014").Month
            STARTPOS = ENDPOS + 1
            ENDPOS = STARTPOS + 4
            Y = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
            BOARDINGDATE.Value = Convert.ToDateTime(D & "-" & MON & "-" & Y).Date

            'SCHEDULED DEPARTURE
            STARTPOS = CONTENT.IndexOf("Scheduled Departure:") + 26
            ENDPOS = STARTPOS + 5
            TXTDEPTIME.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'RES UPTO
            STARTPOS = CONTENT.IndexOf("Resv Upto:") + 16
            ENDPOS = CONTENT.IndexOf("(", STARTPOS)
            CMBRESTO.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'RES UPTOCODE
            STARTPOS = ENDPOS + 1
            ENDPOS = CONTENT.IndexOf(")", STARTPOS)
            CMBRESTOCODE.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'SCHEDULED ARRIVAL
            STARTPOS = CONTENT.IndexOf("Scheduled Arrival:") + 24
            ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
            TXTARRTIME.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'ADULTS
            STARTPOS = CONTENT.IndexOf("Adult:") + 13
            ENDPOS = STARTPOS + 2
            TXTADULTS.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'CHILDS
            STARTPOS = CONTENT.IndexOf("Child:") + 12
            ENDPOS = STARTPOS + 2
            TXTCHILDS.Text = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

            'TICEKT FARE
            STARTPOS = CONTENT.IndexOf("Ticket&nbsp;Fare") + 12
            STARTPOS = CONTENT.IndexOf("Rs.", STARTPOS) + 9
            ENDPOS = CONTENT.IndexOf("&", STARTPOS)
            TXTFARE.Text = Format(Val(CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim), "0.00")

            'SERVICE CHARGES
            STARTPOS = CONTENT.IndexOf("IRCTC Service Charges") + 12
            STARTPOS = CONTENT.IndexOf("Rs.", STARTPOS) + 9
            ENDPOS = CONTENT.IndexOf("&", STARTPOS)
            TXTIRCTC.Text = Format(Val(CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim), "0.00")


            '******************* FOR GRID *****************

            Dim N As String = ""    'FOR NAME
            Dim A As Integer = 0    'FOR AGE
            Dim S As String = "M"   'FOR SEX
            Dim C As String = ""    'FOR CONCESSION CODE
            Dim ST As String = ""    'FOR STATUS"
            Dim SEAT As String = ""   'FOR SEATNO
            Dim IDTYPE As String = ""    'FOR IDTYPE
            Dim IDNO As String = ""   'FOR IDNO
            Dim INITIALSTART As Integer = STARTPOS


            For I As Integer = 0 To 5

                'FOR FIRST LINE
                '*****************************************************
                'NAME
                'LEAVE FIRST POSITION
                If I = 0 Then
                    STARTPOS = CONTENT.IndexOf("width=""22%""", STARTPOS) + 12
                    INITIALSTART = STARTPOS
                End If
                STARTPOS = CONTENT.IndexOf("width=""22%""", STARTPOS) + 18
                If STARTPOS < INITIALSTART Then Exit For
                ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                N = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

                'AGE
                STARTPOS = CONTENT.IndexOf("width=""5%""", ENDPOS) + 17
                ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                A = Val(CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim)

                'SEX
                STARTPOS = CONTENT.IndexOf("width=""6%""", ENDPOS) + 17
                ENDPOS = STARTPOS + 1
                S = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

                'CONCESSION CODE
                STARTPOS = CONTENT.IndexOf("width=""12%""", STARTPOS) + 18
                STARTPOS = CONTENT.IndexOf("&", STARTPOS) + 6
                ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                C = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim

                'STATUS AND SEAT
                STARTPOS = CONTENT.IndexOf("&nbsp;", ENDPOS) + 6
                ENDPOS = STARTPOS + 2
                If CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "CO" Then
                    ST = "CONFIRMED"
                    ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                    SEAT = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                    SEAT = SEAT.Replace(" ", "")
                    SEAT = SEAT.Replace(vbCr, "")
                    SEAT = SEAT.Replace(vbLf, "")

                ElseIf CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim = "RA" Then
                    ST = "RAC"
                    ENDPOS = CONTENT.IndexOf("&", STARTPOS)
                    SEAT = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Replace(" ", "")
                    STARTPOS = ENDPOS + 6
                    ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                    SEAT = SEAT & CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                    SEAT = SEAT.Replace(" ", "")
                    SEAT = SEAT.Replace(vbCr, "")
                    SEAT = SEAT.Replace(vbLf, "")
                Else
                    ST = "WAITING"
                    ENDPOS = CONTENT.IndexOf("&", STARTPOS)
                    SEAT = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Replace(" ", "")
                    STARTPOS = ENDPOS + 6
                    ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                    SEAT = SEAT & CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                    SEAT = SEAT.Replace(" ", "")
                    SEAT = SEAT.Replace(vbCr, "")
                    SEAT = SEAT.Replace(vbLf, "")
                End If

                If CMBQUOTA.Text = "Tatkal" Then
                    'ID TYPE
                    STARTPOS = CONTENT.IndexOf("width=""25%""", STARTPOS) + 12
                    ENDPOS = CONTENT.IndexOf("/", STARTPOS) - 1
                    IDTYPE = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                    If IDTYPE = "&nbsp;" Then IDTYPE = ""


                    'ID NO
                    STARTPOS = ENDPOS + 2
                    ENDPOS = CONTENT.IndexOf("</td>", STARTPOS)
                    IDNO = CONTENT.Substring(STARTPOS, ENDPOS - STARTPOS).Trim
                    If IDNO.Substring(0, 3).Trim = "td>" Then IDNO = ""

                End If

                GRIDBOOKINGS.Rows.Add(I + 1, N, A, S, SEAT, 0, "", 0, "", 0, "", 0, ST, IDTYPE, IDNO, C)
                '************************************************

            Next

            '******************* FOR GRID *****************
        End If
        PURCHASETOTAL()
        total()


    End Sub

    Public Function LoadSiteContent(ByVal url As String) As String

        'create a new WebClient object
        Dim client As New WebClient()
        'create a byte array for holding the returned data
        Dim html As Byte() = client.DownloadData(url)
        'use the UTF8Encoding object to convert the byte
        'array into a string
        Dim utf As New UTF8Encoding()
        'return the converted string
        Return utf.GetString(html)
    End Function

    Private Sub CMBCLASS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCLASS.Validated
        Try
            GETCHARGES()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Validated
        Try

            'NO NEED OF THIS CODE
            'COZ WE HAVE GIVEN MANUAL ENTRY OPTION AS PER CLIENTS REQUIREMENT
            ' If CMBGROUPDEPARTURE.Text.Trim <> "" Then




            ''FETCH DATA FROM TOURNAME
            'Dim OBJRAIL As New ClsCommon
            'Dim DT2 As New DataTable
            'If MsgBox("Fetch Data for Up Train?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    DT2 = OBJRAIL.search(" ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_NO, 0) AS GROUPDEPNO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNAME, '') AS TRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TRAINNO, '') AS TRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_JOURNEYDATE AS JOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROM, '') AS FRM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FROMCODE, '') AS FCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TO, '') AS [TO], ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TOCODE, '') AS TOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDING, '') AS BOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_BOARDINGCODE, '') AS BCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTO, '') AS RESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_RESTOCODE, '') AS RCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_CLASS, '') AS CLASS, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_FARE, 0) AS FARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_EXTRACHGS, 0) AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXAMT, 0) AS TAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_GRANDTOTAL, 0) AS GTOTAL", "", " TAXMASTER RIGHT OUTER JOIN GROUPDEPARTURE_RAILWAY ON TAXMASTER.tax_id = GROUPDEPARTURE_RAILWAY.GROUPDEP_TAXID INNER JOIN GROUPDEPARTURE ON GROUPDEPARTURE.GROUPDEP_NO = GROUPDEPARTURE_RAILWAY.GROUPDEP_NO AND GROUPDEPARTURE.GROUPDEP_YEARID = GROUPDEPARTURE_RAILWAY.GROUPDEP_YEARID", " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
            '    If DT2.Rows.Count > 0 Then
            '        GROUPDEPRAILTYPE = "RAILUP"
            '        Dim DTR As DataRow = DT2.Rows(0)
            '        CMBTRAINNAME.Text = DTR("TRAINNAME")
            '        CMBTRAINNO.Text = DTR("TRAINNO")
            '        CMBCLASS.Text = DTR("CLASS")
            '        JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("JOURNEYDATE").DATE), "dd/MM/yyyy")
            '        CMBFROM.Text = DTR("FRM")
            '        CMBFROMCODE.Text = DTR("FCODE")
            '        CMBTO.Text = DTR("TO")
            '        CMBTOCODE.Text = DTR("TOCODE")
            '        CMBBOARDING.Text = DTR("BOARDING")
            '        CMBBOARDINGCODE.Text = DTR("BCODE")
            '        CMBRESTO.Text = DTR("RESTO")
            '        CMBRESTOCODE.Text = DTR("RCODE")
            '        TXTFARE.Text = Format(Val(DTR("FARE")), "0.00")
            '        TXTEXTRACHGS.Text = Format(Val(DTR("EXTRACHGS")), "0.00")
            '        cmbtax.Text = DTR("TAXNAME")
            '        txttax.Text = Format(Val(DTR("TAXAMT")), "0.00")
            '        txtgrandtotal.Text = Format(Val(DTR("GTOTAL")), "0.00")
            '    End If
            '    PURCHASETOTAL()
            '    Exit Sub
            'End If

            'If MsgBox("Fetch Data for Down Train?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    DT2 = OBJRAIL.search(" ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNAME, '') AS DNTRAINNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTRAINNO, '') AS DNTRAINNO, GROUPDEPARTURE_RAILWAY.GROUPDEP_DNJOURNEYDATE AS DNJOURNEYDATE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROM, '') AS DNFROM, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFROMCODE, '') AS DNFCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTO, '') AS DNTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTOCODE, '') AS DNTOCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDING, '') AS DNBOARDING, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNBOARDINGCODE, '') AS DNBCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTO, '') AS DNRESTO, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNRESTOCODE, '') AS DNRCODE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNCLASS, '') AS DNCLASS, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNFARE, 0) AS DNFARE, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNEXTRACHGS, 0) AS DNEXTRACHGS, ISNULL(DNTAXMASTER.tax_name, '') AS DNTAXNAME, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXAMT, 0) AS DNTAXAMT, ISNULL(GROUPDEPARTURE_RAILWAY.GROUPDEP_DNGRANDTOTAL, 0) AS DNGTOTAL", "", " TAXMASTER AS DNTAXMASTER LEFT OUTER JOIN GROUPDEPARTURE_RAILWAY ON GROUPDEPARTURE_RAILWAY.GROUPDEP_DNTAXID = DNTAXMASTER.tax_id INNER JOIN GROUPDEPARTURE ON GROUPDEPARTURE.GROUPDEP_NO = GROUPDEPARTURE_RAILWAY.GROUPDEP_NO AND GROUPDEPARTURE.GROUPDEP_YEARID = GROUPDEPARTURE_RAILWAY.GROUPDEP_YEARID", " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
            '    If DT2.Rows.Count > 0 Then
            '        Dim DTR As DataRow = DT2.Rows(0)
            '        GROUPDEPRAILTYPE = "RAILDOWN"
            '        CMBTRAINNAME.Text = DTR("DNTRAINNAME")
            '        CMBTRAINNO.Text = DTR("DNTRAINNO")
            '        CMBCLASS.Text = DTR("DNCLASS")
            '        JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("DNJOURNEYDATE").DATE), "dd/MM/yyyy")
            '        CMBFROM.Text = DTR("DNFROM")
            '        CMBFROMCODE.Text = DTR("DNFCODE")
            '        CMBTO.Text = DTR("DNTO")
            '        CMBTOCODE.Text = DTR("DNTOCODE")
            '        CMBBOARDING.Text = DTR("DNBOARDING")
            '        CMBBOARDINGCODE.Text = DTR("DNBCODE")
            '        CMBRESTO.Text = DTR("DNRESTO")
            '        CMBRESTOCODE.Text = DTR("DNRCODE")
            '        TXTFARE.Text = Format(Val(DTR("DNFARE")), "0.00")
            '        TXTEXTRACHGS.Text = Format(Val(DTR("DNEXTRACHGS")), "0.00")
            '        cmbtax.Text = DTR("DNTAXNAME")
            '        txttax.Text = Format(Val(DTR("DNTAXAMT")), "0.00")
            '        txtgrandtotal.Text = Format(Val(DTR("DNGTOTAL")), "0.00")
            '    End If
            '    PURCHASETOTAL()
            '    Exit Sub
            'End If

            'If MsgBox("Fetch Data for Mid Up Train?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    DT2 = OBJRAIL.search(" ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTRAINNAME, '') AS MIDUPTRAINNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTRAINNO, '') AS MIDUPTRAINNO, GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPJOURNEYDATE AS MIDUPJOURNEYDATE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPCLASS, '') AS MIDUPCLASS, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFROM, '') AS MIDUPFRM, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFROMCODE, '') AS MIDUPFCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTO, '') AS MIDUPTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTOCODE, '') AS MIDUPTOCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPBOARDING, '') AS MIDUPBOARDING, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPBOARDINGCODE, '') AS MIDUPBCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPRESTO, '') AS MIDUPRESTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPRESTOCODE, '') AS MIDUPRCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPFARE, 0) AS MIDUPFARE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPEXTRACHGS, 0) AS MIDUPEXTRACHGS, ISNULL(MIDUPTAXMASTER.tax_name, '') AS MIDUPTAXNAME,ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTAXAMT, 0) AS MIDUPTAXAMT, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPGRANDTOTAL, 0) AS MIDUPGTOTAL", "", " GROUPDEPARTURE_MIDRAILWAY LEFT OUTER JOIN TAXMASTER AS MIDUPTAXMASTER ON GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDUPTAXID = MIDUPTAXMASTER.tax_id ", " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
            '    If DT2.Rows.Count > 0 Then
            '        GROUPDEPRAILTYPE = "MIDUP"
            '        Dim DTR As DataRow = DT2.Rows(0)
            '        CMBTRAINNAME.Text = DTR("MIDUPTRAINNAME")
            '        CMBTRAINNO.Text = DTR("MIDUPTRAINNO")
            '        CMBCLASS.Text = DTR("MIDUPCLASS")
            '        JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("MIDUPJOURNEYDATE").DATE), "dd/MM/yyyy")
            '        CMBFROM.Text = DTR("MIDUPFRM")
            '        CMBFROMCODE.Text = DTR("MIDUPFCODE")
            '        CMBTO.Text = DTR("MIDUPTO")
            '        CMBTOCODE.Text = DTR("MIDUPTOCODE")
            '        CMBBOARDING.Text = DTR("MIDUPBOARDING")
            '        CMBBOARDINGCODE.Text = DTR("MIDUPBCODE")
            '        CMBRESTO.Text = DTR("MIDUPRESTO")
            '        CMBRESTOCODE.Text = DTR("MIDUPRCODE")
            '        TXTFARE.Text = Format(Val(DTR("MIDUPFARE")), "0.00")
            '        TXTEXTRACHGS.Text = Format(Val(DTR("MIDUPEXTRACHGS")), "0.00")
            '        cmbtax.Text = DTR("MIDUPTAXNAME")
            '        txttax.Text = Format(Val(DTR("MIDUPTAXAMT")), "0.00")
            '        txtgrandtotal.Text = Format(Val(DTR("MIDUPGTOTAL")), "0.00")
            '    End If
            '    PURCHASETOTAL()
            '    Exit Sub
            'End If

            'If MsgBox("Fetch Data for Mid Down Train?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            '    DT2 = OBJRAIL.search("ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTRAINNAME, '') AS MIDDNTRAINNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTRAINNO, '') AS MIDDNTRAINNO, GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNJOURNEYDATE AS MIDDNJOURNEYDATE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNCLASS, '') AS MIDDNCLASS, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFROM, '') AS MIDDNFROM, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFROMCODE, '') AS MIDDNFCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTO, '') AS MIDDNTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTOCODE, '') AS MIDDNTOCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNBOARDING, '') AS MIDDNBOARDING, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNBOARDINGCODE, '') AS MIDDNBCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNRESTO, '') AS MIDDNRESTO, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNRESTOCODE, '') AS MIDDNRCODE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNFARE, 0) AS MIDDNFARE, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNEXTRACHGS, 0) AS MIDDNEXTRACHGS, ISNULL(MIDDNTAXMASTER.tax_name, '') AS MIDDNTAXNAME, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTAXAMT, 0) AS MIDDNTAXAMT, ISNULL(GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNGRANDTOTAL, 0) AS MIDDNGTOTAL", "", " GROUPDEPARTURE_MIDRAILWAY LEFT OUTER JOIN TAXMASTER AS MIDDNTAXMASTER ON GROUPDEPARTURE_MIDRAILWAY.GROUPDEP_MIDDNTAXID = MIDDNTAXMASTER.tax_id  ", " AND GROUPDEPARTURE.GROUPDEP_NAME = '" & CMBGROUPDEPARTURE.Text.Trim & "' AND GROUPDEPARTURE.GROUPDEP_YEARID = " & YearId)
            '    If DT2.Rows.Count > 0 Then
            '        GROUPDEPRAILTYPE = "MIDDOWN"
            '        Dim DTR As DataRow = DT2.Rows(0)
            '        CMBTRAINNAME.Text = DTR("MIDDNTRAINNAME")
            '        CMBTRAINNO.Text = DTR("MIDDNTRAINNO")
            '        CMBCLASS.Text = DTR("MIDDNCLASS")
            '        JOURNEYDATE.Value = Format(Convert.ToDateTime(DTR("MIDDNJOURNEYDATE").DATE), "dd/MM/yyyy")
            '        CMBFROM.Text = DTR("MIDDNFROM")
            '        CMBFROMCODE.Text = DTR("MIDDNFCODE")
            '        CMBTO.Text = DTR("MIDDNTO")
            '        CMBTOCODE.Text = DTR("MIDDNTOCODE")
            '        CMBBOARDING.Text = DTR("MIDDNBOARDING")
            '        CMBBOARDINGCODE.Text = DTR("MIDDNBCODE")
            '        CMBRESTO.Text = DTR("MIDDNRESTO")
            '        CMBRESTOCODE.Text = DTR("MIDDNRCODE")
            '        TXTFARE.Text = Format(Val(DTR("MIDDNFARE")), "0.00")
            '        TXTEXTRACHGS.Text = Format(Val(DTR("MIDDNEXTRACHGS")), "0.00")
            '        cmbtax.Text = DTR("MIDDNTAXNAME")
            '        txttax.Text = Format(Val(DTR("MIDDNTAXAMT")), "0.00")
            '        txtgrandtotal.Text = Format(Val(DTR("MIDDNGTOTAL")), "0.00")
            '    End If
            '    PURCHASETOTAL()
            '    Exit Sub
            'End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        'Try
        '    If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM > '" & Format(bookingdate.Value.Date, "MM/dd/yyyy") & "'")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(bookingdate.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGROUPDEPARTURE.Enter
        'Try
        '    If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(bookingdate.Value.Date, "MM/dd/yyyy") & "'")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(bookingdate.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Enter
        Try
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
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
                'CMBHSNITEMDESC.SelectedIndex = Nothing
            End If
            CMBHSNITEMDESC.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        GETHSNCODE()
    End Sub

    Private Sub CMBPURHSNITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Validated
        GETHSNCODE()
    End Sub

    Private Sub CHKPURTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKPURTAXSERVCHGS.CheckedChanged
        Try
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(bookingdate.Text).Date >= "01/07/2017" Then
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
                Dim DT As DataTable
                DT = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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
                End If
            End If

            If CMBPURHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(bookingdate.Text).Date >= "01/07/2017" Then
                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then
                    TXTPURHSNCODE.Clear()
                    TXTPURCGSTPER.Clear()
                    TXTPURCGSTAMT.Clear()
                    TXTPURSGSTPER.Clear()
                    TXTPURSGSTAMT.Clear()
                    TXTPURIGSTPER.Clear()
                    TXTPURIGSTAMT.Clear()
                End If
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS PURHSNCODE, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBPURHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURSERVCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURSERVCHGS.Validated
        PURCHASETOTAL()
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

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)



                'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                'PBQRCODE.ImageLocation = Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                'PBQRCODE.Refresh()


                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\RS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\RS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()



                'If PBQRCODE.Image IsNot Nothing Then
                '    Dim OBJINVOICE As New ClsInvoiceMaster
                '    Dim MS As New IO.MemoryStream
                '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                '    OBJINVOICE.alParaval.Add(MS.ToArray)
                '    OBJINVOICE.alParaval.Add(YearId)
                '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                'End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""
            'Dim KOTHARIPLACE As String = ""  'THIS VARIABLE IS USED TO FETCH RANGE COLUMN ONLY FOR KOTHARI, THEY WILL ENTER FULL SHIPTO ADDRESS THERE
            Dim DISPATCHFROM As String = ""
            Dim DISPATCHFROMGSTIN As String = ""
            Dim DISPATCHFROMPINCODE As String = ""
            Dim DISPATCHFROMSTATECODE As String = ""
            Dim DISPATCHFROMSTATENAME As String = ""
            Dim DISPATCHFROMKMS As Double = 0
            Dim DISPATCHFROMADD1 As String = ""
            Dim DISPATCHFROMADD2 As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")
            DISPATCHFROM = CmpName
            DISPATCHFROMGSTIN = CMPGSTIN
            DISPATCHFROMPINCODE = CMPPINCODE
            DISPATCHFROMSTATECODE = CMPSTATECODE
            DISPATCHFROMSTATENAME = CMPSTATENAME


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2  ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","
                j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " RAILBOOKINGMASTER ", " AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & bookingdate.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & "," 'CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & DISPATCHFROM & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & DISPATCHFROMPINCODE & "" & ","
                j = j & """Stcd"":""" & DISPATCHFROMSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"


                Dim TEMPOTHERAMT As Double = Val(TXTTOTALSALEAMT.Text.Trim) + Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                Dim TEMPTOTALITEMAMT As Double = Val(TXTEXTRACHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)


                j = j & """ItemList"":[{"
                j = j & """SlNo"": """ & "1" & """" & ","
                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
                j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
                'j = j & """Barcde"":""REC9999"","
                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                'j = j & """FreeQty"":" & "0" & "" & ","
                'j = j & """Unit"":""" & "MTR" & """" & ","
                j = j & """UnitPrice"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & ","
                j = j & """TotAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                j = j & """AssAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """CesRt"":" & "0" & "" & ","
                j = j & """CesAmt"":" & "0" & "" & ","
                j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """StateCesRt"":" & "0" & "" & ","
                j = j & """StateCesAmt"":" & "0" & "" & ","
                j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                j = j & """OthChrg"":" & "0" & "" & ","

                j = j & """TotItemVal"":" & Val(TEMPTOTALITEMAMT) & "" & ","
                j = j & """OrdLineRef"":"" "","
                j = j & """OrgCntry"":""IN"","
                j = j & """PrdSlNo"":""123"","

                j = j & """BchDtls"": {"
                j = j & """Nm"":""123"","
                j = j & """Expdt"":""" & bookingdate.Text & """" & ","
                j = j & """wrDt"":""" & bookingdate.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                j = j & """AssVal"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","

                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TEMPOTHERAMT) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & "0" & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & bookingdate.Text & """" & ","
                j = j & """InvEndDt"":""" & bookingdate.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & bookingdate.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & bookingdate.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & bookingdate.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & bookingdate.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"



                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10

                'WE HAVE REMOVED CREATING EWAY DIRECTLY FORM EINVOICE
                'USER HAVE TO MANUALLY CREATE EWAY SEPERATELY
                'If TXTVEHICLENO.Text.Trim <> "" Then
                '    j = j & ","
                '    j = j & """EwbDtls"": {"
                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                '    j = j & """Distance"":""" & PARTYKMS & """" & ","
                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                '    j = j & """VehType"":""" & "R" & """" & ","
                '    j = j & """TransMode"":""1""" & "}"
                'End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()



            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                'Dim ERRORMSG As String = ""
                'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                'ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO


            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE RAILBOOKINGMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM RAILBOOKINGMASTER WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

                'GET REGINITIALS AS SAVE WITH IT
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\RS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\RS" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsRailBookingMaster
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'RAILBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTPURCGSTAMT.KeyPress, TXTPURSGSTAMT.KeyPress, TXTPURIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        total()
    End Sub

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASETOTAL()
    End Sub

End Class