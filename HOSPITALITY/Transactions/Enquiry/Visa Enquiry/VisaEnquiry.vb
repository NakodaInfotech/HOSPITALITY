
Imports BL

Public Class VisaEnquiry

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick, GRIDCHGSDOUBLECLICK As Boolean
    Dim temprow, TEMPCHGSROW As Integer
    Public edit As Boolean
    Public TEMPENQNO As Integer
    Dim TEMPMSG As Integer
    Dim TEMPDOC As String
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPUPLOADROW As Integer
    Public Shared SELECTENQ As New DataTable

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub GETMAX_ENQ_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ENQ_no),0) + 1 ", "VISAENQMASTER", " and ENQ_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTENQNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()

        Try
            tstxtbillno.Clear()
            CMBACCCODE.Text = ""
            CMBNAME.Text = ""
            CMBBOOKEDBY.Text = ""
            TXTENQUIREBY.Clear()
            CMBSOURCE.Text = ""

            ENQDATE.Value = Mydate
            DELDATE.Clear()

            For I As Integer = 0 To DocumentList.Items.Count - 1
                Dim DTR As DataRowView = DocumentList.Items(I)
                DocumentList.SetItemCheckState(I, CheckState.Unchecked)
            Next

            PBlock.Visible = False
            lbllocked.Visible = False
            LBLCLOSED.Visible = False

            TXTSRNO.Clear()
            CMBGUEST.Text = ""
            TXTPASSPORT.Clear()
            CMBCOUNTRY.Text = ""
            SUBDT.Clear()
            COLDT.Clear()
            CMBCITY.Text = ""
            TXTVISAFEES.Text = "0.00"
            TXTVISACENTRE.Text = "0.00"
            TXTMISC.Text = "0.00"
            TXTTOTAL.Text = "0.00"
            TXTGRIDSERCHGS.Text = "0.00"
            TXTQUERY.Clear()

            GRIDBOOKINGS.RowCount = 0
            GRIDBOOKINGS.ClearSelection()

            TBDETAILS.SelectedIndex = 0

            TXTREMARKS.Clear()
            TXTCLOSEREMARKS.Clear()

            TXTSUBTOTAL.Text = 0.0
            TXTSERVICECHGS.Text = 0.0
            TXTSERVICECHGS.ReadOnly = True
            cmbtax.Text = ""
            txttax.Text = 0.0
            txtnett.Text = 0.0

            cmbaddsub.SelectedIndex = 0
            CMBOTHERCHGS.Text = ""
            txtotherchg.Text = 0.0


            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0


            If UserName = "Admin" Then
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
            GETMAX_ENQ_NO()

            TXTSRNO.Text = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        CMBNAME.Focus()
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
            Dim OBJVISA As New ClsVisaEnquiry

            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPENQNO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJVISA.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJVISA.SAVEUPLOAD()
                End If
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VisaEnquiry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
            If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
            If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
            fillDoc(DocumentList, edit)
            If CMBGUEST.Text.Trim = "" Then FILLGUEST(CMBGUEST, edit)
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            If CMBCOUNTRY.Text.Trim = "" Then fillCountry(CMBCOUNTRY)
            If cmbtax.Text.Trim = "" Then filltax(cmbtax, edit)
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub VisaEnquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'VISA'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsVisaEnquiry()

                ALPARAVAL.Add(TEMPENQNO)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTENQ()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTENQNO.Text = TEMPENQNO
                        ENQDATE.Value = Convert.ToDateTime(dr("ENQDATE"))
                        CMBACCCODE.Text = Convert.ToString(dr("ACCCODE"))
                        CMBNAME.Text = Convert.ToString(dr("ACCNAME"))
                        CMBBOOKEDBY.Text = dr("BOOKEDBY")

                        TXTENQUIREBY.Text = dr("ENQUIRYBY")
                        CMBSOURCE.Text = dr("SOURCE")
                        DELDATE.Text = dr("DELDATE")
                        TXTMISCENQNO.Text = dr("MISCENQNO")
                        TXTREMARKS.Text = dr("REMARKS")
                        TXTCLOSEREMARKS.Text = dr("CLOSEREMARKS")

                        TXTSUBTOTAL.Text = dr("SUBTOTAL")
                        TXTSERVICECHGS.Text = dr("SERVICECHGS")
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

                        GRIDBOOKINGS.Rows.Add(dr("GRIDSRNO").ToString, dr("PASSNAME").ToString, dr("PASSPORT").ToString, dr("COUNTRY").ToString, dr("SUBDATE").ToString, dr("COLDATE").ToString, dr("CITY").ToString, Format(dr("VISAFEES"), "0.00"), Format(dr("VFS"), "0.00"), Format(dr("MISC"), "0.00"), Format(dr("TOTAL"), "0.00"), Format(dr("SERGRIDCHGS"), "0.00"), dr("QUERY").ToString, dr("GRIDDONE"))

                        If dr("GRIDDONE").ToString = True Then
                            GRIDBOOKINGS.Rows(GRIDBOOKINGS.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If dr("CLOSED").ToString = True Then
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If
                    Next

                    Dim OBJCOMMON As New ClsCommon
                    Dim dttable As New DataTable
                    dttable = OBJCOMMON.search(" ISNULL(doc_name,'') AS DOCNAME", "", " VISAENQMASTER INNER JOIN VISAENQMASTER_DOC ON VISAENQMASTER.ENQ_NO = VISAENQMASTER_DOC.ENQ_NO AND VISAENQMASTER.ENQ_YEARID = VISAENQMASTER_DOC.ENQ_YEARID INNER JOIN DOCMASTER ON VISAENQMASTER_DOC.ENQ_DOCID = DOCMASTER.doc_id ", " AND VISAENQMASTER.ENQ_NO = " & TEMPENQNO & " AND VISAENQMASTER.ENQ_YEARID= " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each ROW As DataRow In dttable.Rows
                            For I As Integer = 0 To DocumentList.Items.Count - 1
                                Dim DTR As DataRowView = DocumentList.Items(I)
                                If ROW("DOCNAME") = DTR.Item(0) Then
                                    DocumentList.SetItemCheckState(I, CheckState.Checked)
                                    'DocumentList = ROW("DOCNAME")
                                End If
                            Next
                        Next
                    End If


                    'UPLOAD(GRID)
                    Dim OBJCMN As New ClsCommon
                    Dim DTGRID As DataTable = OBJCMN.search(" VISAENQMASTER_UPLOAD.ENQ_SRNO AS GRIDSRNO, VISAENQMASTER_UPLOAD.ENQ_REMARKS AS REMARKS, VISAENQMASTER_UPLOAD.ENQ_NAME AS NAME, VISAENQMASTER_UPLOAD.ENQ_PHOTO AS IMGPATH ", "", " VISAENQMASTER_UPLOAD ", " AND VISAENQMASTER_UPLOAD.ENQ_NO = " & TEMPENQNO & " AND ENQ_YEARID = " & YearId & " ORDER BY VISAENQMASTER_UPLOAD.ENQ_SRNO")
                    If DTGRID.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTGRID.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If


                    GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
                    total()
                Else
                    clear()
                    edit = False
                    CMBNAME.Focus()
                End If

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

            alParaval.Add(ENQDATE.Value.Date)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(TXTENQUIREBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(DELDATE.Text)
            alParaval.Add(Val(TXTMISCENQNO.Text.Trim))

            'ADDING DOCUMENTS
            Dim DOCUMENT As String = ""
            For Each DTROW As DataRowView In DocumentList.CheckedItems
                If DOCUMENT = "" Then
                    DOCUMENT = DTROW.Item(0)
                Else
                    DOCUMENT = DOCUMENT & "|" & DTROW.Item(0)
                End If
            Next
            alParaval.Add(DOCUMENT)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTCLOSEREMARKS.Text.Trim)

            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(Val(TXTSERVICECHGS.Text.Trim))

            If chkmanual.Checked = False Then
                alParaval.Add(0)
            Else
                alParaval.Add(1)
            End If

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

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

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
            Dim QUERY As String = ""
            Dim GRIDDONE As String = ""

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
                        QUERY = row.Cells(GQuery.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDone.Index).Value) = True Then
                            GRIDDONE = "1"
                        Else
                            GRIDDONE = "0"
                        End If

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
                        QUERY = QUERY & "|" & row.Cells(GQuery.Index).Value.ToString

                        If Convert.ToBoolean(row.Cells(GDone.Index).Value) = True Then
                            GRIDDONE = GRIDDONE & "|" & "1"
                        Else
                            GRIDDONE = GRIDDONE & "|" & "0"
                        End If
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
            alParaval.Add(QUERY)
            alParaval.Add(GRIDDONE)


            Dim OBJBOOKING As New ClsVisaEnquiry()
            OBJBOOKING.alParaval = alParaval

            If edit = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.SAVE()
                TEMPENQNO = DTNO.Rows(0).Item(0)
                MessageBox.Show("Details Added")
                PRINTREPORT(DTNO.Rows(0).Item(0))
            Else

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPENQNO)

                IntResult = OBJBOOKING.update()
                MessageBox.Show("Details Updated")
                edit = False
                PRINTREPORT(Val(TXTENQNO.Text.Trim))
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

        'Dim FORMTYPE As String = ""
        'For Each DTROW As DataRowView In DocumentList.CheckedItems
        '    FORMTYPE = DTROW.Item(0)
        'Next
        'If FORMTYPE = Nothing Then
        '    EP.SetError(DocumentList, "Please Select Document")
        '    bln = False
        'End If

        If GRIDBOOKINGS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Visa Details")
            TBDETAILS.SelectedIndex = 0
            bln = False
        End If

        If CMBBOOKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(CMBBOOKEDBY, " Please Fill Your Name ")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Enquiry Locked, Booking Made")
            bln = False
        End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "Enquiry Closed")
            bln = False
        End If

        If Not datecheck(ENQDATE.Value) Then
            EP.SetError(ENQDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Return bln
    End Function

    Sub total()


        TXTSUBTOTAL.Text = 0.0
        If chkmanual.Checked = False Then TXTSERVICECHGS.Text = 0.0
        txttax.Text = 0.0
        txtnett.Text = 0.0
        TXTCHARGES.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0

        For Each row As DataGridViewRow In GRIDBOOKINGS.Rows
            row.Cells(GTotal.Index).Value = Format(((row.Cells(GVisaFees.Index).EditedFormattedValue + Val(row.Cells(GVFS.Index).EditedFormattedValue)) + row.Cells(GMiscChgs.Index).EditedFormattedValue), "0")
            If Val(row.Cells(GTotal.Index).Value) > 0 Then TXTSUBTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(row.Cells(GTotal.Index).Value), "0.00")
            If chkmanual.Checked = False And Val(row.Cells(GSerChgs.Index).Value) > 0 Then TXTSERVICECHGS.Text = Format(Val(TXTSERVICECHGS.Text) + Val(row.Cells(GSerChgs.Index).Value), "0.00")
        Next

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSERVICECHGS.Text))) / 100, "0.00")

        txtnett.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTSERVICECHGS.Text.Trim) + Val(txttax.Text.Trim), "0.00")

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
        'txtgrandtotal.Text = Format(Val(txtnett.Text) + Val(txtotherchg.Text.Trim), "0")
        'txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtnett.Text) + Val(TXTCHARGES.Text.Trim)), "0.00")
        'txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(txtnett.Text) + Val(txtotherchg.Text.Trim)), "0.00")
        txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

    End Sub

    Sub PRINTREPORT(ByVal ENQNO As Integer)
        Try
            TEMPMSG = MsgBox("Send Quote to Guest?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJVOUCHER As New HotelEnqDesign
                OBJVOUCHER.MdiParent = MDIMain
                OBJVOUCHER.ENQNO = ENQNO
                'OBJVOUCHER.FRMSTRING = "HOTELRATE"

                OBJVOUCHER.Show()
            End If

            If ClientName = "TOPCOMM" Or ClientName = "SAPPHIRE" Or ClientName = "UTTARAKHAND" Then
                TEMPMSG = MsgBox("Avail & Price to Hotel?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJVOUCHER As New HotelEnqDesign
                    OBJVOUCHER.MdiParent = MDIMain
                    OBJVOUCHER.ENQNO = ENQNO
                    OBJVOUCHER.FRMSTRING = "HOTELRATE"
                    OBJVOUCHER.Show()
                End If
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

                If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
                    MsgBox("Voucher Locked/Closed", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Enquiry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsVisaEnquiry
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPENQNO)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)


                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJBOOKING.DELETE()
                    MessageBox.Show("Enquiry Deleted Successfully")
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

    Private Sub TXTQUERY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQUERY.Validating
        If CMBGUEST.Text.Trim <> "" And CMBCOUNTRY.Text.Trim <> "" And CMBCITY.Text.Trim <> "" And Val(TXTTOTAL.Text.Trim) > 0 Then
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
        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Val(TXTSRNO.Text.Trim), CMBGUEST.Text.Trim, TXTPASSPORT.Text.Trim, CMBCOUNTRY.Text.Trim, SUBDT.Text.Trim, COLDT.Text.Trim, CMBCITY.Text.Trim, Format(Val(TXTVISAFEES.Text.Trim), "0.00"), Format(Val(TXTVISACENTRE.Text.Trim), "0.00"), Format(Val(TXTMISC.Text.Trim), "0.00"), Format(Val(TXTTOTAL.Text.Trim), "0.00"), Format(Val(TXTGRIDSERCHGS.Text.Trim), "0.00"), TXTQUERY.Text.Trim, 0)
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
            GRIDBOOKINGS.Item(GQuery.Index, temprow).Value = TXTQUERY.Text.Trim
            gridDoubleClick = False
        End If

        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1

        TXTSRNO.Clear()
        CMBGUEST.Text = ""
        TXTPASSPORT.Clear()
        CMBCOUNTRY.Text = ""
        SUBDT.Clear()
        COLDT.Clear()
        CMBCITY.Text = ""
        TXTVISAFEES.Clear()
        TXTVISACENTRE.Clear()
        TXTMISC.Clear()
        TXTTOTAL.Clear()
        TXTGRIDSERCHGS.Clear()
        TXTQUERY.Clear()


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

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSOURCE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSOURCE.Validating
        Try
            If CMBSOURCE.Text.Trim <> "" Then SOURCEvalidate(CMBSOURCE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub TXTVISAFEES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTVISAFEES.KeyPress
        Try
            numdotkeypress(e, TXTVISAFEES, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTVISACENTRE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTVISACENTRE.KeyPress
        Try
            numdotkeypress(e, TXTVISACENTRE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMISC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMISC.KeyPress
        Try
            numdotkeypress(e, TXTMISC, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDSERCHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGRIDSERCHGS.KeyPress
        Try
            numdotkeypress(e, TXTGRIDSERCHGS, Me)
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
            Else
                DocumentList.Focus()
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
            TEMPENQNO = Val(TXTENQNO.Text) - 1
            If TEMPENQNO > 0 Then
                edit = True
                VisaEnquiry_Load(sender, e)
            Else
                clear()
                edit = False
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
                edit = True
                VisaEnquiry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPENQNO < MAXNO Then
                TXTENQNO.Text = TEMPENQNO
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
                TXTQUERY.Text = GRIDBOOKINGS.Item(GQuery.Index, GRIDBOOKINGS.CurrentRow.Index).Value.ToString

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

            Dim OBJENQ As New VisaEnquiryDetails
            OBJENQ.MdiParent = MDIMain
            OBJENQ.Show()
            OBJENQ.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSERVICECHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSERVICECHGS.Validating
        total()
    End Sub

    Private Sub cmdclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            TEMPMSG = MsgBox("Wish to Close Enquiry ?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    If TXTCLOSEREMARKS.Text <> "" Then
                        Dim obj As New ClsCommon
                        Dim dt As DataTable = obj.Execute_Any_String(" UPDATE VISAENQMASTER SET ENQ_CLOSE=1 WHERE ENQ_NO=" & TEMPENQNO & " AND ENQ_YEARID=" & YearId & "", "", "")
                        MsgBox(" Enquiry No- " & TEMPENQNO & " Closed")
                        clear()
                        edit = False
                    Else
                        MsgBox("Write Close Remarks !", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBOTHERCHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Validated
        total()
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBACCCODE, e, Me, TXTADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtotherchg.KeyPress
        numdot(e, txtotherchg, Me)
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        total()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDBOOKINGS.RowCount = 0
            TEMPENQNO = Val(tstxtbillno.Text)
            If TEMPENQNO > 0 Then
                edit = True
                VisaEnquiry_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
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

    Private Sub CMDSELECTMISCENQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMISCENQ.Click
        Try
            If edit = True Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            SELECTENQ.Clear()
            Dim OBJHOTELENQ As New SelectMiscEnquiry
            OBJHOTELENQ.FRMSTRING = "VISA"
            OBJHOTELENQ.ShowDialog()
            SELECTENQ = OBJHOTELENQ.DT
            Dim i As Integer = 0
            If SELECTENQ.Rows.Count > 0 Then
                TXTMISCENQNO.Text = (SELECTENQ.Rows(0).Item("MISCNO"))
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub VisaEnquiry_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "MATRIX" Then Me.Close()

            If ClientName = "STARVISA" Then
                LBLSOURCE.Text = "Country"
                LBLREMARKS.Text = "Passport"
                SENDMAILTOOL.Enabled = True
                PASSPORTRECDEMAIL.Enabled = True
                DOCREQEMAIL.Enabled = True
                DELDATEEMAIL.Enabled = True
                SUBCOLLEMAIL.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DELDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DELDATE.Validating
        Try
            If DELDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DELDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PASSPORTRECDEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PASSPORTRECDEMAIL.Click
        Try
            If edit = True Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.GUESTNAME = GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value

                'GET EMAILID OF SALENAME
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_EMAIL,'')  AS EMAILID", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then OBJMAIL.cmbfirstadd.Text = DT.Rows(0).Item("EMAILID")

                OBJMAIL.subject = "Passport Recd Intimation"
                OBJMAIL.BODY = "Dear Sir/Madam," + vbCrLf & vbCrLf & "We have Received your Passport of " & GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value & " X " & TXTREMARKS.Text.Trim & " Pax for " & CMBSOURCE.Text.Trim & " visa. " & vbCrLf & vbCrLf & "Thanks & Regards " & vbCrLf & "Sabir."
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DOCREQEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOCREQEMAIL.Click
        Try
            If edit = True And DocumentList.CheckedItems.Count > 0 Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.GUESTNAME = GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value

                'GET EMAILID OF SALENAME
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_EMAIL,'')  AS EMAILID", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then OBJMAIL.cmbfirstadd.Text = DT.Rows(0).Item("EMAILID")

                OBJMAIL.subject = "Documents Required"

                'ADDING DOCUMENTS
                Dim DOCUMENT As String = ""
                For Each DTROW As DataRowView In DocumentList.CheckedItems
                    DOCUMENT = DOCUMENT & DTROW.Item(0) & vbCrLf
                Next
                If DOCUMENT = "" Then
                    MsgBox("Please Select Document Required", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                OBJMAIL.BODY = "Dear Sir/Madam," + vbCrLf & vbCrLf & "Following Document are Required " & vbCrLf & DOCUMENT & vbCrLf & "of " & GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value & " for " & CMBSOURCE.Text.Trim & " visa. " & vbCrLf & vbCrLf & "Thanks & Regards " & vbCrLf & "Sabir."
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DELDATEEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELDATEEMAIL.Click
        Try
            If edit = True Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.GUESTNAME = GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value

                'GET EMAILID OF SALENAME
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_EMAIL,'')  AS EMAILID", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then OBJMAIL.cmbfirstadd.Text = DT.Rows(0).Item("EMAILID")

                If DELDATE.Text = "  /  /" Then
                    MsgBox("Enter Delivery Date", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                OBJMAIL.subject = "Visa Delivery Status"
                OBJMAIL.BODY = "Dear Sir/Madam," + vbCrLf & vbCrLf & "Today We have send your Passport for " & TXTREMARKS.Text.Trim & " pax of " & CMBSOURCE.Text.Trim & " visa with all necessary document, Please confirm the receipt on priority." & vbCrLf & vbCrLf & "Thanks & Regards " & vbCrLf & "Sabir."
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUBCOLLEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBCOLLEMAIL.Click
        Try
            If edit = True Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.MdiParent = MDIMain
                OBJMAIL.GUESTNAME = GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value

                'GET EMAILID OF SALENAME
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_EMAIL,'')  AS EMAILID", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then OBJMAIL.cmbfirstadd.Text = DT.Rows(0).Item("EMAILID")

                If GRIDBOOKINGS.Rows(0).Cells(GSubDT.Index).Value = "/  /" Or GRIDBOOKINGS.Rows(0).Cells(GSubDT.Index).Value = "/  /" Then
                    MsgBox("Enter Submission / Collection Date", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                OBJMAIL.subject = "Submission/ Collection Status"
                OBJMAIL.BODY = "Dear Sir/Madam," + vbCrLf & vbCrLf & "Sub " & CMBSOURCE.Text.Trim & " visa of " & GRIDBOOKINGS.Rows(0).Cells(GPassName.Index).Value & " X " & TXTREMARKS.Text.Trim & " Pax, Sub on " & Format(Convert.ToDateTime(GRIDBOOKINGS.Rows(0).Cells(GSubDT.Index).Value).Date, "dd-MMM-yyyy - (ddd)") & ",  Coll on " & Format(Convert.ToDateTime(GRIDBOOKINGS.Rows(0).Cells(GCollectionDT.Index).Value).Date, "dd-MMM-yyyy - (ddd)") & vbCrLf & vbCrLf & "Thanks & Regards " & vbCrLf & "Sabir."
                OBJMAIL.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class