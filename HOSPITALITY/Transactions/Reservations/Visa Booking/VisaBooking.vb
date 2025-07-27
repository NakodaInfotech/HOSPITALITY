
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL
Imports Newtonsoft.Json
Imports RestSharp
Imports TaxProEInvoice.API

Public Class VisaBooking

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick, GRIDCHGSDOUBLECLICK, gridPURCHASEDoubleClick As Boolean
    Dim temprow, TEMPCHGSROW, tempPURCHASErow As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Dim TEMPMSG As Integer
    Dim TEMPDOC As String
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPUPLOADROW As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_ENQ_NO()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_no),0) + 1 ", "VISABOOKING", " and BOOKING_yearid=" & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then TXTBOOKINGNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()

        Try
            tstxtbillno.Clear()
            If ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "KHANNA" Then
                TXTBOOKINGNO.ReadOnly = False
                TXTBOOKINGNO.Enabled = True
            Else
                TXTBOOKINGNO.Enabled = True
                TXTBOOKINGNO.ReadOnly = True
            End If
            tstxtbillno.Clear()
            CMBACCCODE.Text = ""
            CMBNAME.Text = ""
            CMBBOOKEDBY.Text = ""
            TXTENQUIREBY.Clear()
            txtrefno.Clear()
            TXTENQNO.Clear()
            CMBSOURCE.Text = ""

            BOOKINGDATE.Text = Mydate

            cmdshowdetails.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBCN.Visible = False
            PBDN.Visible = False

            TXTSRNO.Clear()
            CMBGUEST.Text = ""
            TXTPASSPORT.Clear()
            CMBCOUNTRY.Text = ""
            SUBDT.Clear()
            COLDT.Clear()
            CMBCITY.Text = ""
            TXTVISAFEES.Text = "0.00"
            TXTVISAINCOME.Clear()
            TXTVISACENTRE.Text = "0.00"
            TXTMISC.Text = "0.00"
            TXTTOTAL.Text = "0.00"
            TXTGRIDSERCHGS.Text = "0.00"

            GRIDBOOKINGS.RowCount = 0
            'GRIDCHGS.RowCount = 0
            'GRIDPURCHASE.RowCount = 0
            GRIDBOOKINGS.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            TXTREMARKS.Clear()
            TXTINWORDS.Clear()

            TXTPURSRNO.Clear()
            CMBPURNAME.Text = ""
            PURDATE.Value = Mydate
            TXTPURAMT.Text = 0.0
            TXTPURSERVCHGS.Text = 0.0
            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0
            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0
            TXTPURGTOTAL.Text = 0.0
            TXTFINALPURAMT.Text = 0.0
            GRIDPURCHASE.RowCount = 0

            TXTTOTALSALEAMT.Text = 0.0
            TXTSERVICECHGS.Text = 0.0
            TXTSERVICECHGS.ReadOnly = True
            cmbtax.Text = ""
            txttax.Text = 0.0
            txtnett.Text = 0.0
            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0
            TXTCHARGES.Text = 0.0

            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0


            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            PBSOFTCOPY.Image = Nothing
            TXTUPLOADSRNO.Text = 1
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTIMGPATH.Clear()
            gridupload.RowCount = 0
            GRIDUPLOADDOUBLECLICK = False


            EP.Clear()
            gridDoubleClick = False
            GRIDCHGSDOUBLECLICK = False
            gridPURCHASEDoubleClick = False
            GETMAX_ENQ_NO()

            TXTSRNO.Text = 1
            TXTPURSRNO.Text = 1
            cmdSELECTENQ.Enabled = True

            TXTSTATECODE.Clear()
            TXTHSNCODE.Clear()
            'CMBHSNITEMDESC.SelectedIndex = 0
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            TXTPURCGSTPER.Text = 0.0
            TXTPURCGSTAMT.Text = 0.0
            'TXTSERVCHGS.Text = 0.0
            'CHKSERVTAX.CheckState = CheckState.Unchecked
            TXTPURSTATECODE.Clear()

            TXTPURHSNCODE.Clear()
            CHKMANUALGST.CheckState = CheckState.Unchecked
            CHKPURMANUAL.CheckState = CheckState.Unchecked
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing
            LBLEINVGENERATED.Visible = False
            CMBGROUPDEPARTURE.Text = ""
            CMBGROUPDEPARTURE.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUPLOAD()

        If GRIDUPLOADDOUBLECLICK = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf GRIDUPLOADDOUBLECLICK = True Then

            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = TXTUPLOADSRNO.Text.Trim
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSOFTCOPY.Image

            GRIDUPLOADDOUBLECLICK = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()

    End Sub

    Sub SAVEUPLOAD()

        Try
            Dim OBJVISABOOKING As New ClsVisaBookingMaster

            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJVISABOOKING.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJVISABOOKING.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Private Sub VisaBooking_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TBDETAILS.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TBDETAILS.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
                TBDETAILS.SelectedIndex = 2
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for DIRECT LINK TO INV NO
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call ToolStripprint_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New VisaBookingDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM > '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
            'If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            If CMBGUEST.Text.Trim = "" Then FILLGUEST(CMBGUEST, edit)
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            If CMBCOUNTRY.Text.Trim = "" Then fillCountry(CMBCOUNTRY)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
            If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
            If CMBPURHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub VisaBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'VISA'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            clear()
            fillcmb()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsVisaBookingMaster

                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows


                        TXTBOOKINGNO.Text = TEMPBOOKINGNO
                        TXTSTATECODE.Text = dr("STATECODE")
                        CMBHSNITEMDESC.Text = dr("ITEMDESC")
                        'CMBPURHSNITEMDESC.Text = dr("PURHSNITEMDESC")

                        BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKINGDATE")), "dd/MM/yyyy")
                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))
                        CMBBOOKEDBY.Text = dr("BOOKEDBY")

                        TXTENQUIREBY.Text = dr("ENQUIRYBY")
                        txtrefno.Text = dr("REFNO")
                        TXTENQNO.Text = dr("ENQNO")
                        CMBSOURCE.Text = dr("SOURCE")
                        TXTREMARKS.Text = dr("REMARKS")

                        TXTTOTALSALEAMT.Text = dr("SUBTOTAL")
                        chkmanual.Checked = dr("MANUAL")
                        TXTSERVICECHGS.Text = dr("SERVCHGS")

                        cmbtax.Text = dr("TAXNAME")
                        txttax.Text = dr("TAXAMT")
                        txtnett.Text = dr("NETT")
                        CMBGROUPDEPARTURE.Text = Convert.ToString(dr("GROUPDEPART"))
                        'If dr("GROUPDEPART") <> "" Then CMBGROUPDEPARTURE.Enabled = False

                        CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                        If dr("OTHERCHGS") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGS")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGS") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        'TXTCHARGES.Text = dr("CHARGES")
                        txtroundoff.Text = dr("ROUNDOFF")
                        txtgrandtotal.Text = dr("GRANDTOTAL")

                        TXTSALEAMTREC.Text = dr("SALEAMTREC")
                        TXTSALEEXTRAAMT.Text = dr("SALEEXTRAAMT")
                        TXTSALERETURN.Text = dr("SALERETURN")
                        TXTSALEBAL.Text = dr("SALEBALANCE")

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


                        chkdispute.Checked = Convert.ToBoolean(dr("BILLDISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))

                        TXTHSNCODE.Text = dr("HSNCODE")
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUALGST.Checked = False Else CHKMANUALGST.Checked = True
                        If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")

                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("PASSPORT").ToString, dr("COUNTRY").ToString, dr("SUBDATE").ToString, dr("COLDATE").ToString, dr("CITY").ToString, Format(dr("VISAFEES"), "0.00"), Format(dr("VFS"), "0.00"), Format(dr("MISC"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(dr("SERVGRIDCHGS"), "0.00"), dr("ENQNO"), dr("ENQSRNO"))

                        'If dr("GRIDDONE").ToString = True Then
                        '    GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If


                    Next

                    'UPLOAD(GRID)
                    Dim OBJCMN As New ClsCommon
                    Dim DTGRID As DataTable = OBJCMN.search(" VISABOOKING_UPLOAD.BOOKING_SRNO AS GRIDSRNO, VISABOOKING_UPLOAD.BOOKING_REMARKS AS REMARKS, VISABOOKING_UPLOAD.BOOKING_NAME AS NAME, VISABOOKING_UPLOAD.BOOKING_PHOTO AS IMGPATH ", "", " VISABOOKING_UPLOAD ", " AND VISABOOKING_UPLOAD.BOOKING_NO = " & TEMPBOOKINGNO & " AND BOOKING_YEARID = " & YearId & " ORDER BY VISABOOKING_UPLOAD.BOOKING_SRNO")
                    If DTGRID.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTGRID.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    'total()

                    'PURCHASE DETAILS
                    dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()
                    If dt.Rows.Count > 0 Then
                        For Each DR As DataRow In dt.Rows
                            GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(DR("PURDATE"), "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PURAMT"), DR("PURSERVCHGS"), DR("PURNETT"), DR("PURTAX"), DR("PURTAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), DR("PURAMTPAID"), DR("PUREXTRAAMT"), DR("PURRETURN"), DR("PURBALANCE"))

                            If Convert.ToBoolean(DR("PURBILLCHECKED")) = True Then GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen

                            If Val(DR("PURAMTPAID")) > 0 Or Val(DR("PUREXTRAAMT")) > 0 Then
                                cmdshowdetails.Visible = True
                                PBPAID.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If

                            If Val(DR("PURRETURN")) > 0 Then
                                cmdshowdetails.Visible = True
                                PBDN.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                                GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            End If

                        Next
                        GRIDPURCHASE.ClearSelection()
                    End If

                    cmdSELECTENQ.Enabled = False
                    total()
                Else
                    clear()
                    edit = False
                    CMBNAME.Focus()
                End If



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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "KHANNA" Then
                alParaval.Add(TXTBOOKINGNO.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add("VISA PURCHASE REGISTER")
            alParaval.Add("VISA SALE REGISTER")

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(TXTENQUIREBY.Text.Trim)
            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(TXTENQNO.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)

            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTINWORDS.Text.Trim)


            alParaval.Add(Val(TXTTOTALSALEAMT.Text.Trim))
            alParaval.Add(Val(TXTSERVICECHGS.Text.Trim))

            If chkmanual.Checked = False Then
                alParaval.Add(0)
            Else
                alParaval.Add(1)
            End If

            alParaval.Add(CHKBILLCHECK.CheckState)
            alParaval.Add(chkdispute.CheckState)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(CHKMANUALGST.CheckState)
            alParaval.Add(CHKPURMANUAL.CheckState)

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(Val(txtnett.Text.Trim))

            alParaval.Add(CMBOTHERCHGS.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If


            ''alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(Val(TXTSALEAMTREC.Text.Trim))
            alParaval.Add(Val(TXTSALEEXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTSALERETURN.Text.Trim))
            alParaval.Add(Val(TXTSALEBAL.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            'THIS VARIABLE IS JUST USED TO PASS THE GUESTNAME WITH NO OF PAX IN TOURNAME FIELD IN ACCMASTER TABLE
            'THIS WILL BE THEN FETCHED IN LEDGERBOOK, HENCE REDUCING THE DELAY TIME 
            alParaval.Add(GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value & " * " & Val(GRIDBOOKINGS.RowCount))

            Dim gridsrno As String = ""
            Dim PASSNAME As String = ""
            Dim PASSPORTNO As String = ""
            Dim COUNTRY As String = ""
            Dim SUBDATE As String = ""
            Dim COLLDATE As String = ""
            Dim CITY As String = ""
            Dim VISAFEES As String = ""
            Dim VFS As String = ""
            Dim MISC As String = ""
            Dim AMT As String = ""
            Dim SERVICE As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        PASSNAME = row.Cells(GPassName.Index).Value.ToString
                        PASSPORTNO = row.Cells(gPassport.Index).Value.ToString
                        COUNTRY = (row.Cells(GCountry.Index).Value).ToString
                        SUBDATE = (row.Cells(GSubDT.Index).Value).ToString
                        COLLDATE = (row.Cells(GCollectionDT.Index).Value).ToString
                        CITY = (row.Cells(GSubCity.Index).Value).ToString
                        VISAFEES = Val(row.Cells(GVisaFees.Index).Value)
                        VFS = Val(row.Cells(GVFS.Index).Value)
                        MISC = Val(row.Cells(GMiscChgs.Index).Value)
                        AMT = Val(row.Cells(GTotal.Index).Value)
                        SERVICE = Val(row.Cells(GSerChgs.Index).Value)
                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value
                        PASSNAME = PASSNAME & "|" & row.Cells(GPassName.Index).Value.ToString
                        PASSPORTNO = PASSPORTNO & "|" & row.Cells(gPassport.Index).Value.ToString
                        COUNTRY = COUNTRY & "|" & (row.Cells(GCountry.Index).Value).ToString
                        SUBDATE = SUBDATE & "|" & (row.Cells(GSubDT.Index).Value).ToString
                        COLLDATE = COLLDATE & "|" & (row.Cells(GCollectionDT.Index).Value).ToString
                        CITY = CITY & "|" & (row.Cells(GSubCity.Index).Value).ToString
                        VISAFEES = VISAFEES & "|" & Val(row.Cells(GVisaFees.Index).Value)
                        VFS = VFS & "|" & Val(row.Cells(GVFS.Index).Value)
                        MISC = MISC & "|" & Val(row.Cells(GMiscChgs.Index).Value)
                        AMT = AMT & "|" & Val(row.Cells(GTotal.Index).Value)
                        SERVICE = SERVICE & "|" & Val(row.Cells(GSerChgs.Index).Value)
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PASSNAME)
            alParaval.Add(PASSPORTNO)
            alParaval.Add(COUNTRY)
            alParaval.Add(SUBDATE)
            alParaval.Add(COLLDATE)
            alParaval.Add(CITY)
            alParaval.Add(VISAFEES)
            alParaval.Add(VFS)
            alParaval.Add(MISC)
            alParaval.Add(AMT)
            alParaval.Add(SERVICE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)


            'PURCHASE DETAILS
            Dim PURBILLCHECKED As String = ""
            Dim PURSRNO As String = ""
            Dim PURNAME As String = ""
            Dim PURDATE As String = ""
            Dim PURHSNCODE As String = ""
            Dim PURAMT As String = ""
            Dim PURSERVCHGS As String = ""
            Dim PURNETTTOTAL As String = ""
            Dim PURTAXNAME As String = ""
            Dim PURTAX As String = ""
            Dim PURCGSTPER As String = ""
            Dim PURCGSTAMT As String = ""
            Dim PURSGSTPER As String = ""
            Dim PURSGSTAMT As String = ""
            Dim PURIGSTPER As String = ""
            Dim PURIGSTAMT As String = ""

            Dim PUROTHERCHGSNAME As String = ""
            Dim PUROTHERCHGS As String = ""
            Dim PURROUNDOFF As String = ""
            Dim PURGTOTAL As String = ""
            Dim PURAMTPAID As String = ""
            Dim PUREXTRAAMT As String = ""
            Dim PURRETURN As String = ""
            Dim PURBALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GPURSRNO.Index).Value <> Nothing Then
                    If PURSRNO = "" Then

                        PURBILLCHECKED = row.Cells(GCHK.Index).Value
                        PURSRNO = row.Cells(GPURSRNO.Index).Value.ToString
                        PURNAME = row.Cells(GPURNAME.Index).Value.ToString
                        PURDATE = Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        PURHSNCODE = row.Cells(GPURHSNCODE.Index).Value.ToString
                        PURAMT = Val(row.Cells(GPURAMT.Index).Value)
                        PURSERVCHGS = Val(row.Cells(GSERVCHGS.Index).Value)
                        PURNETTTOTAL = row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = row.Cells(GTAX.Index).Value.ToString
                        PURTAX = Val(row.Cells(GTAXAMT.Index).Value)
                        PURCGSTPER = row.Cells(GPURCGSTPER.Index).Value.ToString
                        PURCGSTAMT = row.Cells(GPURCGSTAMT.Index).Value.ToString
                        PURSGSTPER = row.Cells(GPURSGSTPER.Index).Value.ToString
                        PURSGSTAMT = row.Cells(GPURSGSTAMT.Index).Value.ToString
                        PURIGSTPER = row.Cells(GPURIGSTPER.Index).Value.ToString
                        PURIGSTAMT = row.Cells(GPURIGSTAMT.Index).Value.ToString

                        PUROTHERCHGSNAME = row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = Val(row.Cells(GOTHERCHGS.Index).Value)
                        PURROUNDOFF = Val(row.Cells(GROUNDOFF.Index).Value)
                        PURGTOTAL = Val(row.Cells(GGRANDTOTAL.Index).Value)
                        PURAMTPAID = Val(row.Cells(GPURAMTPAID.Index).Value)
                        PUREXTRAAMT = Val(row.Cells(GPUREXTRAAMT.Index).Value)
                        PURRETURN = Val(row.Cells(GPURRETURN.Index).Value)
                        PURBALANCE = Val(row.Cells(GPURBAL.Index).Value)

                    Else

                        PURBILLCHECKED = PURBILLCHECKED & "|" & row.Cells(GCHK.Index).Value
                        PURSRNO = PURSRNO & "|" & row.Cells(GPURSRNO.Index).Value
                        PURNAME = PURNAME & "|" & row.Cells(GPURNAME.Index).Value
                        PURDATE = PURDATE & "|" & Format(Convert.ToDateTime(row.Cells(GPURDATE.Index).Value).Date, "MM/dd/yyyy")
                        PURHSNCODE = PURHSNCODE & " |" & row.Cells(GPURHSNCODE.Index).Value.ToString
                        PURAMT = PURAMT & "|" & Val(row.Cells(GPURAMT.Index).Value)
                        PURSERVCHGS = PURSERVCHGS & "|" & Val(row.Cells(GSERVCHGS.Index).Value)
                        PURNETTTOTAL = PURNETTTOTAL & "|" & row.Cells(GNETTTOTAL.Index).Value.ToString
                        PURTAXNAME = PURTAXNAME & "|" & row.Cells(GTAX.Index).Value.ToString
                        PURTAX = PURTAX & "|" & Val(row.Cells(GTAXAMT.Index).Value)
                        PURCGSTPER = PURCGSTPER & "|" & row.Cells(GPURCGSTPER.Index).Value.ToString
                        PURCGSTAMT = PURCGSTAMT & "|" & row.Cells(GPURCGSTAMT.Index).Value.ToString
                        PURSGSTPER = PURSGSTPER & "|" & row.Cells(GPURSGSTPER.Index).Value.ToString
                        PURSGSTAMT = PURSGSTAMT & "|" & row.Cells(GPURSGSTAMT.Index).Value.ToString
                        PURIGSTPER = PURIGSTPER & "|" & row.Cells(GPURIGSTPER.Index).Value.ToString
                        PURIGSTAMT = PURIGSTAMT & "|" & row.Cells(GPURIGSTAMT.Index).Value.ToString

                        PUROTHERCHGSNAME = PUROTHERCHGSNAME & "|" & row.Cells(GOTHERCHGSNAME.Index).Value.ToString
                        PUROTHERCHGS = PUROTHERCHGS & "|" & Val(row.Cells(GOTHERCHGS.Index).Value)
                        PURROUNDOFF = PURROUNDOFF & "|" & Val(row.Cells(GROUNDOFF.Index).Value)
                        PURGTOTAL = PURGTOTAL & "|" & Val(row.Cells(GGRANDTOTAL.Index).Value)
                        PURAMTPAID = PURAMTPAID & "|" & Val(row.Cells(GPURAMTPAID.Index).Value)
                        PUREXTRAAMT = PUREXTRAAMT & "|" & Val(row.Cells(GPUREXTRAAMT.Index).Value)
                        PURRETURN = PURRETURN & "|" & Val(row.Cells(GPURRETURN.Index).Value)
                        PURBALANCE = PURBALANCE & "|" & Val(row.Cells(GPURBAL.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(PURBILLCHECKED)
            alParaval.Add(PURSRNO)
            alParaval.Add(PURNAME)
            alParaval.Add(PURDATE)
            alParaval.Add(PURHSNCODE)
            alParaval.Add(PURAMT)
            alParaval.Add(PURSERVCHGS)
            alParaval.Add(PURNETTTOTAL)
            alParaval.Add(PURTAXNAME)
            alParaval.Add(PURTAX)
            alParaval.Add(PURCGSTPER)
            alParaval.Add(PURCGSTAMT)
            alParaval.Add(PURSGSTPER)
            alParaval.Add(PURSGSTAMT)
            alParaval.Add(PURIGSTPER)
            alParaval.Add(PURIGSTAMT)
            alParaval.Add(PUROTHERCHGSNAME)
            alParaval.Add(PUROTHERCHGS)
            alParaval.Add(PURROUNDOFF)
            alParaval.Add(PURGTOTAL)
            alParaval.Add(PURAMTPAID)
            alParaval.Add(PUREXTRAAMT)
            alParaval.Add(PURRETURN)
            alParaval.Add(PURBALANCE)
            alParaval.Add(Val(TXTFINALPURAMT.Text.Trim))

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
            alParaval.Add(CMBGROUPDEPARTURE.Text.Trim)



            Dim OBJBOOKING As New ClsVisaBookingMaster
            OBJBOOKING.alParaval = alParaval

            If edit = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.SAVE()
                MessageBox.Show("Details Added")
                TEMPBOOKINGNO = DTNO.Rows(0).Item(0)
                PRINTREPORT(DTNO.Rows(0).Item(0))
            Else

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.UPDATE()
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(Val(TXTBOOKINGNO.Text.Trim))
            End If
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Select Name ")
            bln = False
        End If

        If ClientName = "URMI" And txtrefno.Text.Trim.Length = 0 Then
            EP.SetError(txtrefno, "Enter Ref No")
            bln = False
        End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Visa Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amount cannot be 0")
            bln = False
        End If
        If Val(TXTFINALPURAMT.Text.Trim) = 0 And ClientName <> "KHANNA" Then
            EP.SetError(TXTFINALPURAMT, "Purchase Amount Cannot be 0")
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If

        If GRIDPURCHASE.RowCount = 0 And ClientName <> "KHANNA" Then
            EP.SetError(TXTENQUIREBY, " Please Fill Purchase Details ")
            TBDETAILS.SelectedIndex = 1
            bln = False
        End If

        If ClientName <> "LUXCREST" Then
            If UserName <> "Admin" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, "Booking Locked")
                    bln = False
                End If
            End If
        End If


        If (ClientName = "CLASSIC" And UserName = "Admin" And edit = False) Or ((ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "NAMASTE") And edit = False) Then
            If Val(TXTBOOKINGNO.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " VISABOOKING", " AND BOOKING_NO = " & Val(TXTBOOKINGNO.Text.Trim) & " and BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(TXTBOOKINGNO, "Booking No Already Exists !")
                    bln = False
                    TXTBOOKINGNO.Clear()
                    TXTBOOKINGNO.Focus()
                End If
            End If
        End If

        If (ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE") And edit = False Then
            If Val(TXTBOOKINGNO.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(TXTBOOKINGNO.Text.Trim))
                If DT1.Rows.Count > 0 Then
                    EP.SetError(TXTBOOKINGNO, "Booking No Already Exists !")
                    TXTBOOKINGNO.Clear()
                    TXTBOOKINGNO.Focus()
                    bln = False
                End If
            End If
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
        Return bln
    End Function

    Sub TOTAL()


        TXTTOTALSALEAMT.Text = 0.0
        If chkmanual.Checked = False Then TXTSERVICECHGS.Text = 0.0
        txttax.Text = 0.0
        txtnett.Text = 0.0
        TXTCHARGES.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0
        TXTFINALPURAMT.Text = 0.0

        For Each row As DataGridViewRow In GRIDPURCHASE.Rows
            If Val(row.Cells(GGRANDTOTAL.Index).Value) > 0 Then TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text) + Val(row.Cells(GGRANDTOTAL.Index).Value), "0.00")
        Next

        For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
            row.Cells(GTotal.Index).Value = Format(((row.Cells(GVisaFees.Index).EditedFormattedValue + Val(row.Cells(GVFS.Index).EditedFormattedValue)) + row.Cells(GMiscChgs.Index).EditedFormattedValue), "0")
            If Val(row.Cells(GTotal.Index).Value) > 0 Then TXTTOTALSALEAMT.Text = Format(Val(TXTTOTALSALEAMT.Text) + Val(row.Cells(GTotal.Index).Value), "0.00")
            If chkmanual.Checked = False And Val(row.Cells(GSerChgs.Index).Value) > 0 Then TXTSERVICECHGS.Text = Format(Val(TXTSERVICECHGS.Text) + Val(row.Cells(GSerChgs.Index).Value), "0.00")
        Next

        If CHKREVERSE.Checked = True Then
            Dim objclscmn As New ClsCommonMaster
            Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt1.Rows.Count > 0 Then TXTSERVICECHGS.Text = Format((Val(TXTSERVICECHGS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
        End If


        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        If Convert.ToDateTime(BOOKINGDATE.Text).Date < "01/07/2017" Then
            dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSERVICECHGS.Text))) / 100, "0.00")
        Else
            'If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
            If CHKMANUALGST.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSERVICECHGS.Text)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSERVICECHGS.Text)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSERVICECHGS.Text)) / 100, "0.00")
                'Else
                'TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                'TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                'TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            End If
        End If


        txtnett.Text = Format(Val(TXTTOTALSALEAMT.Text) + Val(TXTSERVICECHGS.Text.Trim) + Val(txttax.Text.Trim) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

        'If GRIDCHGS.RowCount > 0 Then
        '    For Each row As DataGridViewRow In GRIDCHGS.Rows
        '        TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
        '    Next
        'End If

        If cmbaddsub.Text = "Add" Then
            txtgrandtotal.Text = Format(Val(txtnett.Text) + Val(txtotherchg.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtnett.Text) + Val(txtotherchg.Text)), "0.00")
        Else
            txtgrandtotal.Text = Format(Val(txtnett.Text) - Val(txtotherchg.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtnett.Text) - Val(txtotherchg.Text)), "0.00")
        End If

        'txtgrandtotal.Text = Format(Val(txtnett.Text) + Val(TXTCHARGES.Text.Trim), "0")
        'txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtnett.Text) + Val(TXTCHARGES.Text.Trim)), "0.00")
        txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

        If Val(txtgrandtotal.Text) > 0 Then TXTINWORDS.Text = CurrencyToWord(txtgrandtotal.Text)

    End Sub

    Sub PRINTREPORT(ByVal ENQNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJINVOICE As New VisaBookingDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.BOOKINGNO = ENQNO
                OBJINVOICE.PRINTTAX = CHKTAXPRINT.Checked
                OBJINVOICE.GUESTNAME = CMBNAME.Text.Trim
                OBJINVOICE.Show()
            End If
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

                If lbllocked.Visible = True Or PBPAID.Visible = True Or PBRECD.Visible = True Then
                    MsgBox("Voucher Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Booking Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsVisaBookingMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJBOOKING.DELETE()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()
                    edit = False

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
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
            GRIDBOOKINGS.Rows.Add(Val(TXTSRNO.Text.Trim), CMBGUEST.Text.Trim, TXTPASSPORT.Text.Trim, CMBCOUNTRY.Text.Trim, SUBDT.Text.Trim, COLDT.Text.Trim, CMBCITY.Text.Trim, Format(Val(TXTVISAFEES.Text.Trim), "0.00"), Format(Val(TXTVISACENTRE.Text.Trim), "0.00"), Format(Val(TXTMISC.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), Format(Val(TXTGRIDSERCHGS.Text.Trim), "0.00"), 0, 0)
            getsrno(GRIDBOOKINGS)
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDBOOKINGS.Item(GPassName.Index, temprow).Value = CMBGUEST.Text.Trim
            GRIDBOOKINGS.Item(gPassport.Index, temprow).Value = TXTPASSPORT.Text.Trim
            GRIDBOOKINGS.Item(GCountry.Index, temprow).Value = CMBCOUNTRY.Text.Trim
            GRIDBOOKINGS.Item(GSubDT.Index, temprow).Value = (SUBDT.Text.Trim)
            GRIDBOOKINGS.Item(GCollectionDT.Index, temprow).Value = (COLDT.Text.Trim)
            GRIDBOOKINGS.Item(GSubCity.Index, temprow).Value = (CMBCITY.Text.Trim)
            GRIDBOOKINGS.Item(GVisaFees.Index, temprow).Value = Format(Val(TXTVISAFEES.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GVFS.Index, temprow).Value = Format(Val(TXTVISACENTRE.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GMiscChgs.Index, temprow).Value = Format(Val(TXTMISC.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GTotal.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            GRIDBOOKINGS.Item(GSerChgs.Index, temprow).Value = Format(Val(TXTGRIDSERCHGS.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        TXTSRNO.Text = GRIDBOOKINGS.RowCount + 1
        CMBGUEST.Text = ""
        TXTPASSPORT.Clear()


        'CMBCOUNTRY.Text = ""
        'SUBDT.Clear()
        'COLDT.Clear()
        'CMBCITY.Text = ""
        'TXTVISAFEES.Clear()
        'TXTVISACENTRE.Clear()
        'TXTMISC.Clear()
        'TXTTOTAL.Clear()
        'TXTGRIDSERCHGS.Clear()

        CMBGUEST.Focus()

    End Sub

    Private Sub CMBACCCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKEDBY.Enter
        Try
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUEST.Enter
        Try
            If CMBGUEST.Text.Trim = "" Then FILLGUEST(CMBGUEST, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOUNTRY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCOUNTRY.Enter
        Try
            If CMBCOUNTRY.Text.Trim = "" Then fillCountry(CMBCOUNTRY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Enter
        Try
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSOURCE.Enter
        Try
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACCCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACCCODE.Validating
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
                End If
                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBSOURCE.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBOOKEDBY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBBOOKEDBY.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBBOOKEDBY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBOOKEDBY.Validating
        Try
            If CMBBOOKEDBY.Text.Trim <> "" Then BOOKEDBYvalidate(CMBBOOKEDBY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGUEST.Validating
        Try
            If CMBGUEST.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUEST, e, Me, TXTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOUNTRY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOUNTRY.Validating
        Try
            If CMBCOUNTRY.Text.Trim <> "" Then CountryValidate(CMBCOUNTRY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtax.Validating
        Try
            If cmbtax.Text.Trim <> "" Then TAXvalidate(cmbtax, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVISAFEES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTVISAFEES.KeyPress, TXTVISAINCOME.KeyPress, TXTVISACENTRE.KeyPress, TXTMISC.KeyPress, TXTGRIDSERCHGS.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVISAFEES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTVISAFEES.Validating
        Try
            calc()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calc()
        Try
            TXTTOTAL.Text = Val(TXTVISAFEES.Text.Trim) + Val(TXTMISC.Text.Trim) + Val(TXTVISACENTRE.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVISACENTRE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTVISACENTRE.Validating
        calc()
        If ClientName = "PRIYA" Then CALCPURAMT()
    End Sub

    Private Sub TXTMISC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMISC.Validating
        calc()
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSERVICECHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSERVICECHGS.KeyPress
        Try
            numdotkeypress(e, TXTSERVICECHGS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then If Val(DT.Rows(0).Item("TAX")) = 0 Then txttax.ReadOnly = False
            Else
                txttax.Clear()
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUEST_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGUEST.Validated
        Try
            If CMBGUEST.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" isnull(GUEST_PASSPORTNO,'') AS PASSPORTNO", "", " GUESTMASTER", " AND GUEST_NAME = '" & CMBGUEST.Text.Trim & "' AND GUEST_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then TXTPASSPORT.Text = (DT.Rows(0).Item("PASSPORTNO"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLDT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLDT.Validated
        Try
            If SUBDT.Text = "  /  /" And (COLDT.Text = "  /  /") Then GoTo line1
            If SUBDT.Text = "  /  /" Then
                MsgBox("Pls fill sub. Date first")
                COLDT.Text = "  /  /"
                SUBDT.Focus()
            End If
line1:

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(TXTBOOKINGNO.Text) - 1
            If TEMPBOOKINGNO > 0 Then
                edit = True
                VisaBooking_Load(sender, e)
            Else
                clear()
                edit = False
            End If

            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                TXTBOOKINGNO.Text = TEMPBOOKINGNO
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
            TEMPBOOKINGNO = Val(TXTBOOKINGNO.Text) + 1
            GETMAX_ENQ_NO()
            Dim MAXNO As Integer = TXTBOOKINGNO.Text.Trim
            clear()
            If Val(TXTBOOKINGNO.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                VisaBooking_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                TXTBOOKINGNO.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkmanual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmanual.CheckedChanged
        If chkmanual.Checked = True Then
            TXTSERVICECHGS.Text = "0.0"
            TXTSERVICECHGS.ReadOnly = False
        End If
        total()
    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        Try
            If GRIDBOOKINGS.CurrentRow.Index >= 0 And GRIDBOOKINGS.Item(GSRNO.Index, GRIDBOOKINGS.CurrentRow.Index).Value <> Nothing Then
                gridDoubleClick = True
                TXTSRNO.Text = GRIDBOOKINGS.Item(GSRNO.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                CMBGUEST.Text = GRIDBOOKINGS.Item(GPassName.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTPASSPORT.Text = GRIDBOOKINGS.Item(gPassport.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                CMBCOUNTRY.Text = GRIDBOOKINGS.Item(GCountry.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                SUBDT.Text = GRIDBOOKINGS.Item(GSubDT.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                COLDT.Text = GRIDBOOKINGS.Item(GCollectionDT.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                CMBCITY.Text = GRIDBOOKINGS.Item(GSubCity.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTVISAFEES.Text = GRIDBOOKINGS.Item(GVisaFees.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTVISACENTRE.Text = GRIDBOOKINGS.Item(GVFS.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTMISC.Text = GRIDBOOKINGS.Item(GMiscChgs.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTTOTAL.Text = GRIDBOOKINGS.Item(GTotal.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString
                TXTGRIDSERCHGS.Text = GRIDBOOKINGS.Item(GSerChgs.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString

                temprow = GRIDBOOKINGS.CurrentRow.Index
                CMBGUEST.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOOKINGS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                Dim TINDEX As Integer = GRIDBOOKINGS.CurrentRow.Index
                GRIDBOOKINGS.Rows.RemoveAt(TINDEX)
                getsrno(GRIDBOOKINGS)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SUBDT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SUBDT.Validating
        Try
            If SUBDT.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SUBDT.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLDT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles COLDT.Validating
        Try
            If COLDT.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(COLDT.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
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

            Dim OBJDTLS As New VisaBookingDetails
            OBJDTLS.MdiParent = MDIMain
            OBJDTLS.Show()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSERVICECHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSERVICECHGS.Validating
        total()
    End Sub

    Private Sub cmdSELECTENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSELECTENQ.Click
        Try
            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Name First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJVISA As New SelectVisaEnq
            OBJVISA.NAME = CMBNAME.Text.Trim
            OBJVISA.ShowDialog()
            DTTABLE = OBJVISA.DT
            If DTTABLE.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTTABLE.Rows

                    TXTENQUIREBY.Text = DTROWPS("ENQUIRYBY")
                    CMBBOOKEDBY.Text = DTROWPS("BOOKEDBY")
                    CMBSOURCE.Text = DTROWPS("SOURCE")
                    TXTREMARKS.Text = DTROWPS("REMARKS")
                    TXTENQNO.Text = DTROWPS("ENQNO")

                    GRIDBOOKINGS.Rows.Add(0, DTROWPS("GUEST"), DTROWPS("PASSPORT"), DTROWPS("COUNTRY"), DTROWPS("SUBDATE"), DTROWPS("COLDATE"), DTROWPS("CITY"), Format(Val(DTROWPS("VISAFEES")), "0.00"), Format(Val(DTROWPS("VFS")), "0.00"), Format(Val(DTROWPS("MISC")), "0.00"), Format(Val(DTROWPS("AMT")), "0.00"), Format(Val(DTROWPS("SERCHGS")), "0.00"), DTROWPS("ENQNO"), DTROWPS("SRNO"))
                Next
                getsrno(GRIDBOOKINGS)
                total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDSERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDSERCHGS.Validating
        Try
            If CMBGUEST.Text.Trim <> "" And CMBCOUNTRY.Text.Trim <> "" And CMBCITY.Text.Trim <> "" And (TXTTOTAL.Text.Trim > 0 Or TXTGRIDSERCHGS.Text.Trim > 0) Then
                If ClientName <> "PRIYA" Then TXTPURAMT.Text = Val(TXTTOTAL.Text.Trim)
                fillgrid()
                TOTAL()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURSRNO.GotFocus
        If gridPURCHASEDoubleClick = False Then
            If GRIDPURCHASE.RowCount > 0 Then
                TXTPURSRNO.Text = Val(GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).Cells(GPURSRNO.Index).Value) + 1
            Else
                TXTPURSRNO.Text = 1
            End If
        End If
    End Sub

    Sub fillgridPURCHASE()

        GRIDPURCHASE.Enabled = True

        If gridPURCHASEDoubleClick = False Then
            GRIDPURCHASE.Rows.Add(0, Val(TXTPURSRNO.Text.Trim), CMBPURNAME.Text.Trim, Format(PURDATE.Value.Date, "dd/MM/yyyy"), CMBPURHSNITEMDESC.Text.Trim, TXTPURHSNCODE.Text.Trim, Format(Val(TXTPURAMT.Text.Trim), "0.00"), Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00"), Format(Val(TXTPURNETTAMT.Text.Trim), "0.00"), CMBPURTAX.Text.Trim, Format(Val(TXTPURTAX.Text.Trim), "0.00"), Format(Val(TXTPURCGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURSGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTPURIGSTPER.Text.Trim), "0.00"), Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00"), CMBPUROTHERCHGS.Text.Trim, Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00"), Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00"), Format(Val(TXTPURGTOTAL.Text.Trim), "0.00"), 0, 0, 0, 0)
            getsrno(GRIDPURCHASE)
        ElseIf gridPURCHASEDoubleClick = True Then
            GRIDPURCHASE.Item(GPURSRNO.Index, tempPURCHASErow).Value = Val(TXTPURSRNO.Text.Trim)
            GRIDPURCHASE.Item(GPURNAME.Index, tempPURCHASErow).Value = CMBPURNAME.Text.Trim
            GRIDPURCHASE.Item(GPURDATE.Index, tempPURCHASErow).Value = Format(PURDATE.Value.Date, "dd/MM/yyyy")
            GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, tempPURCHASErow).Value = CMBPURHSNITEMDESC.Text.Trim
            GRIDPURCHASE.Item(GPURHSNCODE.Index, tempPURCHASErow).Value = TXTPURHSNCODE.Text.Trim

            GRIDPURCHASE.Item(GPURAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GSERVCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GNETTTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURNETTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GTAX.Index, tempPURCHASErow).Value = CMBPURTAX.Text.Trim
            GRIDPURCHASE.Item(GTAXAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURTAX.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURCGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURCGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURCGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURSGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURSGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURSGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURIGSTPER.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTPER.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURIGSTAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPURIGSTAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, tempPURCHASErow).Value = CMBPUROTHERCHGS.Text.Trim
            GRIDPURCHASE.Item(GOTHERCHGS.Index, tempPURCHASErow).Value = Format(Val(TXTPUROTHERCHGS.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GROUNDOFF.Index, tempPURCHASErow).Value = Format(Val(TXTPURROUNDOFF.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GGRANDTOTAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURGTOTAL.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURAMTPAID.Index, tempPURCHASErow).Value = Format(Val(TXTPURAMTPAID.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPUREXTRAAMT.Index, tempPURCHASErow).Value = Format(Val(TXTPUREXTRAAMT.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURRETURN.Index, tempPURCHASErow).Value = Format(Val(TXTPURRETURN.Text.Trim), "0.00")
            GRIDPURCHASE.Item(GPURBAL.Index, tempPURCHASErow).Value = Format(Val(TXTPURBAL.Text.Trim), "0.00")
            gridPURCHASEDoubleClick = False
        End If

        GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

        TXTPURSRNO.Clear()
        CMBPURNAME.Text = ""
        PURDATE.Value = Mydate
        TXTPURAMT.Clear()
        TXTPURSERVCHGS.Clear()
        TXTPURNETTAMT.Clear()
        CMBPURTAX.Text = ""
        TXTPURTAX.Clear()
        CMBPUROTHERCHGS.Text = ""
        TXTPUROTHERCHGS.Clear()
        TXTPURROUNDOFF.Clear()
        TXTPURGTOTAL.Clear()

        TXTPURCGSTPER.Clear()
        TXTPURCGSTAMT.Clear()
        TXTPURSGSTPER.Clear()
        TXTPURSGSTAMT.Clear()
        TXTPURIGSTPER.Clear()
        TXTPURIGSTAMT.Clear()
        TXTPURSTATECODE.Clear()
        TXTPURHSNCODE.Clear()
        CMBPURHSNITEMDESC.SelectedIndex = 0

        CMBPURNAME.Focus()
    End Sub

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridPURCHASEDoubleClick = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value.ToString
                CMBPURNAME.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                PURDATE.Value = Convert.ToDateTime(GRIDPURCHASE.Item(GPURDATE.Index, e.RowIndex).Value).Date
                CMBPURHSNITEMDESC.Text = GRIDPURCHASE.Item(GPURHSNITEMDESC.Index, e.RowIndex).Value.ToString
                TXTPURHSNCODE.Text = GRIDPURCHASE.Item(GPURHSNCODE.Index, e.RowIndex).Value.ToString
                TXTPURAMT.Text = GRIDPURCHASE.Item(GPURAMT.Index, e.RowIndex).Value.ToString
                TXTPURSERVCHGS.Text = GRIDPURCHASE.Item(GSERVCHGS.Index, e.RowIndex).Value.ToString
                TXTPURNETTAMT.Text = GRIDPURCHASE.Item(GNETTTOTAL.Index, e.RowIndex).Value.ToString
                CMBPURTAX.Text = GRIDPURCHASE.Item(GTAX.Index, e.RowIndex).Value.ToString
                TXTPURTAX.Text = GRIDPURCHASE.Item(GTAXAMT.Index, e.RowIndex).Value.ToString
                TXTPURCGSTPER.Text = GRIDPURCHASE.Item(GPURCGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURCGSTAMT.Text = GRIDPURCHASE.Item(GPURCGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURSGSTPER.Text = GRIDPURCHASE.Item(GPURSGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURSGSTAMT.Text = GRIDPURCHASE.Item(GPURSGSTAMT.Index, e.RowIndex).Value.ToString
                TXTPURIGSTPER.Text = GRIDPURCHASE.Item(GPURIGSTPER.Index, e.RowIndex).Value.ToString
                TXTPURIGSTAMT.Text = GRIDPURCHASE.Item(GPURIGSTAMT.Index, e.RowIndex).Value.ToString

                CMBPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGSNAME.Index, e.RowIndex).Value.ToString
                TXTPUROTHERCHGS.Text = GRIDPURCHASE.Item(GOTHERCHGS.Index, e.RowIndex).Value.ToString
                TXTPURROUNDOFF.Text = GRIDPURCHASE.Item(GROUNDOFF.Index, e.RowIndex).Value.ToString
                TXTPURGTOTAL.Text = GRIDPURCHASE.Item(GGRANDTOTAL.Index, e.RowIndex).Value.ToString

                tempPURCHASErow = e.RowIndex
                CMBPURNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellValueChanged
        Try
            If e.RowIndex < 0 Then Exit Sub
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSRNO.Index, e.RowIndex).Value <> Nothing Then
                If GRIDPURCHASE.Rows(e.RowIndex).Cells(GCHK.Index).Value = True Then
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    GRIDPURCHASE.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
                End If
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
                If gridPURCHASEDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDPURCHASE.Rows.RemoveAt(GRIDPURCHASE.CurrentRow.Index)
                total()
                getsrno(GRIDPURCHASE)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Enter
        Try
            If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
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

    Private Sub CMBPURTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Enter
        Try
            If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPURTAX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPURTAX.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPURTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURTAX.Validating
        Try
            If CMBPURTAX.Text.Trim <> "" Then TAXvalidate(CMBPURTAX, e, Me)
            PURCHASECALC()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPUROTHERCHGS.Enter
        Try
            If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPUROTHERCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPUROTHERCHGS.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub CMBPUROTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPUROTHERCHGS.Validating
        Try
            If CMBPUROTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURAMT.KeyPress
        numdotkeypress(e, TXTPURAMT, Me)
    End Sub

    Private Sub TXTPURSERVCHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURSERVCHGS.KeyPress
        numdotkeypress(e, TXTPURSERVCHGS, Me)
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        numdotkeypress(e, TXTPUROTHERCHGS, Me)
    End Sub

    Private Sub CMBPURHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBPURHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURHSNITEMDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PURCHASECALC()

        Try
            'TXTPURSUBTOTAL.Text = 0.0
            TXTPURTAX.Text = 0.0
            'TXTPURAMT.Text = 0.0
            TXTPURNETTAMT.Text = 0.0
            TXTPURROUNDOFF.Text = 0.0
            TXTPURGTOTAL.Text = 0.0


            'TXTPURSUBTOTAL.Text = Format(Val(TXTPURAMT.Text) - Val(TXTDISCRECDRS.Text), "0.00")

            TXTPURNETTAMT.Text = Format(Val(TXTPURAMT.Text.Trim) + Val(TXTPURSERVCHGS.Text.Trim), "0.00")

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If Convert.ToDateTime(PURDATE.Value.Date).Date < "01/07/2017" Then
                dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
            Else '''SHOW TO GULKIT SIR... ''NEHA
                'If CHKSERVTAX.CheckState = CheckState.Checked Then
                If CHKPURMANUAL.CheckState = CheckState.Unchecked Then

                    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")

                    'Else
                    '    TXTPURCGSTAMT.Text = Format((Val(TXTPURCGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    '    TXTPURSGSTAMT.Text = Format((Val(TXTPURSGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")
                    '    TXTPURIGSTAMT.Text = Format((Val(TXTPURIGSTPER.Text) * Val(TXTPURNETTAMT.Text)) / 100, "0.00")

                End If

            End If
            TXTPURGTOTAL.Text = Format(Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPUROTHERCHGS.Text), "0")
            TXTPURROUNDOFF.Text = Format(Val(TXTPURGTOTAL.Text) - (Val(TXTPURNETTAMT.Text) + Val(TXTPURTAX.Text) + Val(TXTPURCGSTAMT.Text) + Val(TXTPURSGSTAMT.Text) + Val(TXTPURIGSTAMT.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")

            TXTPURGTOTAL.Text = Format(Val(TXTPURGTOTAL.Text), "0.00")
            total()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTPURGTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPURGTOTAL.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" And Val(TXTPURAMT.Text.Trim) > 0 And Val(TXTPURGTOTAL.Text.Trim) > 0 Then
                fillgridPURCHASE()
                PURCHASECALC()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURAMT.Validated, TXTPURSERVCHGS.Validated, TXTPUROTHERCHGS.Validated
        PURCHASECALC()
    End Sub

    Private Sub CMBGUEST_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGUEST.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGUEST As New SelectGuest
                OBJGUEST.ShowDialog()
                If OBJGUEST.TEMPGUESTNAME <> "" Then CMBGUEST.Text = OBJGUEST.TEMPGUESTNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPBOOKINGNO = Val(tstxtbillno.Text)
            If TEMPBOOKINGNO > 0 Then
                edit = True
                VisaBooking_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                If GRIDPURCHASE.SelectedRows.Count <= 0 Then
                    MsgBox("Select Party To Create Debit Note", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'CHECK IN DN WHETHER DN IS RAISED OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" DN_INITIALS AS BILLINITIALS", "", " DEBITNOTEMASTER ", " AND DN_BILLNO = 'VPR-" & TEMPBOOKINGNO & "' AND DN_PACKAGESRNO = " & GRIDPURCHASE.CurrentRow.Index + 1 & " AND DN_CMPID = " & CmpId & " AND DN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Debit Note Already Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note for " & GRIDPURCHASE.Rows(GRIDPURCHASE.CurrentRow.Index).Cells(GPURNAME.Index).Value, MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    OBJdN.BILLNO = "VISAP-" & TXTBOOKINGNO.Text.Trim
                    OBJdN.PACKAGESRNO = GRIDPURCHASE.CurrentRow.Index + 1
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

            If (PBCN.Visible = True) Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Credit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.BILLNO = "VISAS-" & TXTBOOKINGNO.Text.Trim
                    OBJCN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
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
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBACCCODE, e, Me, TXTADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        numdotkeypress(e, txtotherchg, Me)
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        total()
    End Sub

    Private Sub CMBOTHERCHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Validated
        total()
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = "VISAP-" & TEMPBOOKINGNO
            OBJRECPAY.SALEBILLINITIALS = "VISAS-" & TEMPBOOKINGNO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPY.KeyPress
        numkeypress(e, TXTCOPY, Me)
    End Sub

    Private Sub TXTCOPY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCOPY.Validated
        Try
            If Val(TXTCOPY.Text.Trim) > 0 Then
                If edit = True Then
                    MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTCOPY.Text.Trim <> "" Then
                    TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        TEMPBOOKINGNO = TXTCOPY.Text.Trim
                        clear()

                        TXTCOPY.Text = TEMPBOOKINGNO
                        TEMPBOOKINGNO = 0

                        Dim ALPARAVAL As New ArrayList
                        Dim OBJBOOKING As New ClsVisaBookingMaster()

                        ALPARAVAL.Add(TXTCOPY.Text.Trim)
                        ALPARAVAL.Add(YearId)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim dt As DataTable = OBJBOOKING.SELECTBOOKINGDESC()
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                'TXTBOOKINGNO.Text = TEMPBOOKINGNO
                                TXTSTATECODE.Text = dr("STATECODE")
                                CMBHSNITEMDESC.Text = dr("ITEMDESC")
                                BOOKINGDATE.Text = Convert.ToDateTime(dr("BOOKINGDATE"))
                                CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                                CMBNAME.Text = Convert.ToString(dr("ACCNAME"))
                                CMBBOOKEDBY.Text = dr("BOOKEDBY")

                                TXTENQUIREBY.Text = dr("ENQUIRYBY")
                                CMBSOURCE.Text = dr("SOURCE")
                                TXTREMARKS.Text = dr("REMARKS")

                                TXTTOTALSALEAMT.Text = dr("SUBTOTAL")
                                TXTSERVICECHGS.Text = dr("SERVCHGS")
                                chkmanual.Checked = dr("MANUAL")

                                cmbtax.Text = dr("TAXNAME")
                                txttax.Text = dr("TAXAMT")
                                txtnett.Text = dr("NETT")

                                CMBOTHERCHGS.Text = dr("OTHERCHGSNAME")
                                If dr("OTHERCHGS") > 0 Then
                                    txtotherchg.Text = dr("OTHERCHGS")
                                    cmbaddsub.Text = "Add"
                                Else
                                    txtotherchg.Text = dr("OTHERCHGS") * (-1)
                                    cmbaddsub.Text = "Sub."
                                End If

                                'TXTCHARGES.Text = dr("CHARGES")
                                txtroundoff.Text = dr("ROUNDOFF")
                                txtgrandtotal.Text = dr("GRANDTOTAL")

                                TXTSALEAMTREC.Text = 0
                                TXTSALEEXTRAAMT.Text = 0
                                TXTSALERETURN.Text = 0
                                TXTSALEBAL.Text = 0


                                chkdispute.Checked = Convert.ToBoolean(dr("BILLDISPUTE"))
                                CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                                TXTHSNCODE.Text = dr("HSNCODE")
                                If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUALGST.Checked = False Else CHKMANUALGST.Checked = True
                                If Convert.ToBoolean(dr("PURMANUALGST")) = False Then CHKPURMANUAL.Checked = False Else CHKPURMANUAL.Checked = True

                                TXTCGSTPER.Text = dr("CGSTPER")
                                TXTCGSTAMT.Text = dr("CGSTAMT")
                                TXTSGSTPER.Text = dr("SGSTPER")
                                TXTSGSTAMT.Text = dr("SGSTAMT")
                                TXTIGSTPER.Text = dr("IGSTPER")
                                TXTIGSTAMT.Text = dr("IGSTAMT")

                                GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("PASSPORT").ToString, dr("COUNTRY").ToString, dr("SUBDATE").ToString, dr("COLDATE").ToString, dr("CITY").ToString, Format(dr("VISAFEES"), "0.00"), Format(dr("VFS"), "0.00"), Format(dr("MISC"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(dr("SERVGRIDCHGS"), "0.00"), dr("ENQNO"), dr("ENQSRNO"))

                            Next
                            GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

                        End If


                        'PURCHASE DETAILS
                        dt = OBJBOOKING.SELECTBOOKINGPURDETAILS()
                        If dt.Rows.Count > 0 Then
                            For Each DR As DataRow In dt.Rows
                                GRIDPURCHASE.Rows.Add(DR("PURBILLCHECKED"), DR("PURSRNO"), DR("PURNAME"), Format(DR("PURDATE"), "dd/MM/yyyy"), DR("PURHSNITEMDESC"), DR("PURHSNCODE"), DR("PURAMT"), DR("PURSERVCHGS"), DR("PURNETT"), DR("PURTAX"), DR("PURTAXAMT"), DR("PURCGSTPER"), DR("PURCGSTAMT"), DR("PURSGSTPER"), DR("PURSGSTAMT"), DR("PURIGSTPER"), DR("PURIGSTAMT"), DR("PUROTHERCHGSNAME"), DR("PUROTHERCHGS"), DR("PURROUNDOFF"), DR("PURGTOTAL"), 0, 0, 0, DR("PURGTOTAL"))
                            Next
                            GRIDPURCHASE.ClearSelection()
                        End If

                        total()

                    Else
                        MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                FILLUPLOAD()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDUPLOADDOUBLECLICK = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
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

    Private Sub VisaBooking_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "ARHAM" Then
                Me.Close()
                Exit Sub
            End If
            If ClientName = "KHANNA" Then
                LBLGROUP.Visible = True
                CMBGROUPDEPARTURE.Visible = True
            End If

            If ALLOWEINVOICE = True Then TOOLEINV.Visible = True

            If ClientName = "STARVISA" Then
                LBLSOURCE.Text = "Country"
                LBLREMARKS.Text = "Passport"
                GMiscChgs.HeaderText = "Photo Chg"
            End If
            If ClientName = "GLOBAL" Then
                CHKMANUALGST.Visible = False
                chkmanual.Visible = False
                LBLCGST.Visible = False
                TXTCGSTPER.Visible = False
                TXTCGSTAMT.Visible = False
                LBLSGST.Visible = False
                TXTSGSTPER.Visible = False
                TXTSGSTAMT.Visible = False
                LBLIGST.Visible = False
                TXTIGSTPER.Visible = False
                TXTIGSTAMT.Visible = False
                CHKPURMANUAL.Visible = False
                LBLHSNDESC.Visible = False
                CMBHSNITEMDESC.Visible = False
                LBLHSNCODE.Visible = False
                TXTHSNCODE.Visible = False
                LBLSTATECODE.Visible = False
                TXTSTATECODE.Visible = False
                TXTPURSTATECODE.Visible = False

                'GRIDVALUEPARAMETER
                CMBPURHSNITEMDESC.Visible = False
                GPURHSNITEMDESC.Visible = False
                TXTPURHSNCODE.Visible = False
                GPURHSNCODE.Visible = False
                GPURCGSTPER.Visible = False
                TXTPURCGSTPER.Visible = False
                GPURCGSTAMT.Visible = False
                TXTPURCGSTAMT.Visible = False
                GPURSGSTPER.Visible = False
                GPURSGSTAMT.Visible = False
                TXTPURSGSTPER.Visible = False
                TXTPURSGSTAMT.Visible = False
                GPURIGSTPER.Visible = False
                GPURIGSTAMT.Visible = False
                TXTPURIGSTPER.Visible = False
                TXTPURIGSTAMT.Visible = False



                TXTPURAMT.Left = CMBPURHSNITEMDESC.Left
                TXTPURSERVCHGS.Left = TXTPURAMT.Left + TXTPURAMT.Width
                CMBPURTAX.Left = TXTPURSERVCHGS.Left + TXTPURSERVCHGS.Width
                TXTPURTAX.Left = CMBPURTAX.Left + CMBPURTAX.Width
                CMBPUROTHERCHGS.Left = TXTPURTAX.Left + TXTPURTAX.Width
                TXTPUROTHERCHGS.Left = CMBPUROTHERCHGS.Left + CMBPUROTHERCHGS.Width
                TXTPURGTOTAL.Left = TXTPUROTHERCHGS.Left + TXTPUROTHERCHGS.Width

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        total()
    End Sub

    Private Sub TXTBOOKINGNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBOOKINGNO.Validating
        Try
            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Then
                If Val(TXTBOOKINGNO.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" T.BOOKINGNO AS BOOKINGNO ", "", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " ) AS T ", " AND T.BOOKINGNO = " & Val(TXTBOOKINGNO.Text.Trim))
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        TXTBOOKINGNO.Focus()
                    End If

                    If Val(TXTBOOKINGNO.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If

            ElseIf ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Then
                If Val(TXTBOOKINGNO.Text.Trim) >= 0 And edit = False Then
                    Dim OBJSEARCH As New ClsCommon
                    Dim DT As DataTable = OBJSEARCH.search(" BOOKING_NO AS BOOKINGNO ", "", " VISABOOKING ", " AND VISABOOKING.BOOKING_NO = '" & TXTBOOKINGNO.Text.Trim & "' and VISABOOKING.BOOKING_yearid = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Booking No Allready Used")
                        e.Cancel = True
                        TXTBOOKINGNO.Focus()
                    End If

                    If Val(TXTBOOKINGNO.Text.Trim) = 0 Then
                        MsgBox("Booking No Cannot Be 0!")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTVISAFEES_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTVISAFEES.Validated
        If Val(TXTVISAFEES.Text.Trim) > 0 And ClientName = "PRIYA" Then
            INCOMEVISAGROUP.Visible = True
            TXTVISAINCOME.Focus()
            CALCPURAMT()
        End If
    End Sub

    Private Sub TXTVISAINCOME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTVISAINCOME.Validating
        If Val(TXTVISAINCOME.Text.Trim) <= Val(TXTVISAFEES.Text.Trim) Then
            INCOMEVISAGROUP.Visible = False
            TXTVISACENTRE.Focus()
        Else
            MsgBox("Income is greater than Actual Amount")
            e.Cancel = True
        End If
    End Sub

    Sub CALCPURAMT()
        Try
            TXTPURAMT.Text = Val(TXTVISAFEES.Text.Trim) - Val(TXTVISAINCOME.Text.Trim) + Val(TXTVISACENTRE.Text.Trim)
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

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        Try

            TXTHSNCODE.Clear()
            'TXTCGSTPER.Clear()
            'TXTCGSTAMT.Clear()
            'TXTSGSTPER.Clear()
            'TXTSGSTAMT.Clear()
            'TXTIGSTPER.Clear()
            'TXTIGSTAMT.Clear()

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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
                total()
            End If

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

    Sub GETHSNCODE()
        Try

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "07/01/2017" Then
                If CHKMANUALGST.CheckState = CheckState.Unchecked Then
                    TXTHSNCODE.Clear()
                    TXTCGSTPER.Clear()
                    TXTCGSTAMT.Clear()
                    TXTSGSTPER.Clear()
                    TXTSGSTAMT.Clear()
                    TXTIGSTPER.Clear()
                    TXTIGSTAMT.Clear()
                End If
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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

            If CMBPURHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(PURDATE.Value.Date).Date >= "01/07/2017" Then
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
            End If

            PURCHASECALC()
            total()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
        Try
            If CMBPURNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    'CMBTRANSPORT.Text = DT.Rows(0).Item("TRANSNAME")
                    'CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                    TXTPURSTATECODE.Text = DT.Rows(0).Item("PURSTATECODE")
                    'TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                End If
                GETHSNCODE()
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
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTVISACENTRE.Text.Trim & TXTUPLOADSRNO.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If TXTIMGPATH.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = TXTIMGPATH.Text.Trim
            PBQRCODE.Load(TXTIMGPATH.Text.Trim)
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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\VISA" & Val(TXTBOOKINGNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\VISA" & Val(TXTBOOKINGNO.Text.Trim) & AccFrom.Year & ".png"
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

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                CMDOK_Click(sender, e)

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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " VISABOOKING ", " AND BOOKING_NO = " & Val(TXTBOOKINGNO.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & BOOKINGDATE.Text & """" & "},"


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

                Dim TEMPOTHERAMT As Double = Val(TXTTOTALSALEAMT.Text.Trim) - Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim)
                Dim TEMPTOTALITEMAMT As Double = Val(TXTSERVICECHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)


                j = j & """ItemList"":[{"
                j = j & """SlNo"": """ & "1" & """" & ","
                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
                j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
                'j = j & """Barcde"":""REC9999"","
                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                'j = j & """FreeQty"":" & "0" & "" & ","
                'j = j & """Unit"":""" & "MTR" & """" & ","
                j = j & """UnitPrice"":" & Val(TXTSERVICECHGS.Text.Trim) & "" & ","
                j = j & """TotAmt"":" & Format(Val(TXTSERVICECHGS.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                j = j & """AssAmt"":" & Format(Val(TXTSERVICECHGS.Text.Trim), "0.00") & "" & ","
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
                j = j & """Expdt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """wrDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                j = j & """AssVal"":" & Val(TXTSERVICECHGS.Text.Trim) & "" & ","
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
                j = j & """InvStDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & BOOKINGDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & BOOKINGDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & BOOKINGDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & BOOKINGDATE.Text & """" & ","
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE VISABOOKING SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM VISABOOKING WHERE BOOKING_NO = " & Val(TXTBOOKINGNO.Text.Trim) & " AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\VISA" & Val(TXTBOOKINGNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\VISA" & Val(TXTBOOKINGNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsVisaBookingMaster
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTBOOKINGNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTBOOKINGNO.Text.Trim) & ",'VISABOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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

    Private Sub PURDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PURDATE.Validating
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUALGST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUALGST.CheckedChanged
        Try
            If CHKMANUALGST.Checked = True Then
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
                PURCHASECALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress, TXTPURCGSTAMT.KeyPress, TXTPURSGSTAMT.KeyPress, TXTPURIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        calc()
        total()
    End Sub

    Private Sub TXTPURCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURCGSTAMT.Validated, TXTPURSGSTAMT.Validated, TXTPURIGSTAMT.Validated
        PURCHASECALC()
    End Sub

    Private Sub BOOKINGDATE_Validating(sender As Object, e As CancelEventArgs) Handles BOOKINGDATE.Validating
        Try
            If BOOKINGDATE.Text.Trim <> "__/__/____" Then
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

    Private Sub CMBGROUPDEPARTURE_Enter(sender As Object, e As EventArgs) Handles CMBGROUPDEPARTURE.Enter
        Try
            If CMBGROUPDEPARTURE.Text.Trim = "" Then FILLGROUPNAME(CMBGROUPDEPARTURE, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPDEPARTURE_Validating(sender As Object, e As CancelEventArgs) Handles CMBGROUPDEPARTURE.Validating
        Try
            If CMBGROUPDEPARTURE.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBGROUPDEPARTURE, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class