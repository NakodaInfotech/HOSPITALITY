
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL
Imports Newtonsoft.Json
Imports RestSharp
Imports TaxProEInvoice.API

Public Class DebitNote

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim temprefno As String
    Dim DNREGABBR, DNREGINITIAL As String
    Dim DNREGID As Integer


    Dim TYPE As String  'USED FOR FORMTYPE WHILE RETRIVING DATA FROM GETDATE FUNCTION AND PASSING IN TO SP
    Public FRMSTRING As String  ' USED FOR BOOKTYPE 
    Public TEMPDNNO As Integer
    Public BILLNO As String
    Public PACKAGESRNO As Integer
    Public TEMPREGNAME As String
    Public TEMPPURNAME As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        tstxtbillno.Clear()
        EP.Clear()

        TXTBILLNO.Enabled = True
        TXTBILLNO.Clear()
        TXTSTATECODE.Clear()
        TXTGUESTNAME.Clear()
        TXTHOTELNAME.Clear()
        CMBNAME.Text = ""
        CMBNAME.Enabled = True
        txtremarks.Clear()
        DNREGABBR = ""
        DNREGINITIAL = ""

        DNDATE.Text = Now.Date
        ARRIVALDATE.Value = Mydate

        TXTTOTALPURAMT.Text = 0.0
        TXTDISCPER.Text = 0.0
        TXTDISCRS.Text = 0.0
        TXTCOMMRECDPER.Text = 0.0
        TXTCOMMRECDRS.Text = 0.0
        TXTPURTDSPER.Text = 0.0
        TXTPURTDSRS.Text = 0.0
        TXTPUREXTRACHGS.Text = 0.0
        TXTPURSERVCHGS.Clear()
        CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked
        CHKGSTR1.CheckState = CheckState.Unchecked
        TXTSUBTOTAL.Text = 0.0
        cmbtax.Text = ""
        txttax.Text = 0.0
        txttax.ReadOnly = True
        txttax.Enabled = False
        CMBADDTAX.Text = ""
        TXTADDTAX.Text = 0.0
        cmbaddsub.SelectedIndex = 0
        CMBOTHERCHGS.Text = ""
        txtotherchg.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0
        TXTDP.Text = 0.0
        'CMBHSNITEMDESC.SelectedIndex = 0
        TXTHSNCODE.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        getmaxno_DN()


        TXTIRNNO.Clear()
        TXTACKNO.Clear()
        ACKDATE.Value = Now.Date
        PBQRCODE.Image = Nothing
        LBLEINVGENERATED.Visible = False
    End Sub

    Sub PURCHASETOTAL()


        TXTSUBTOTAL.Text = 0.0
        '   txttax.Text = 0.0
        TXTADDTAX.Text = 0.0
        If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0



        If Val(TXTDISCPER.Text) > 0 Then
            TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * Val(TXTTOTALPURAMT.Text)) / 100, "0.00")
        Else
            'TXTDISCRECDPER.Text = Format((Val(TXTDISCRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
        End If

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


        TXTSUBTOTAL.Text = Format(Val(Val(TXTTOTALPURAMT.Text) - Val(TXTDISCRS.Text)) - Val(TXTCOMMRECDRS.Text) + Val(TXTPUREXTRACHGS.Text.Trim) + Val(TXTPURSERVCHGS.Text.Trim), "0.00")


        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        If Convert.ToDateTime(DNDATE.Text).Date < "01/07/2017" Then
            dt = objclscommon.search("TAX_NAME,tax_tax as TAX", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If CHKTAXSERVCHGS.CheckState = CheckState.Unchecked Then
                If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text))) / 100, "0.00")
            Else
                If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then txttax.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTPURSERVCHGS.Text))) / 100, "0.00")
            End If
        Else
            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then

                    TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                    TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                Else
                    TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                    TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
                End If
            End If
        End If



        'End If

        'for add tax
        dt = objclscommon.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & CMBADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            If TYPE <> "MISCELLANEOUSPURCHASE" Then
                TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTTOTALPURAMT.Text) + Val(TXTPUREXTRACHGS.Text.Trim))) / 100, "0.00")
            Else
                TXTADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text) + Val(TXTPUREXTRACHGS.Text.Trim))) / 100, "0.00")
            End If
        End If



        If cmbaddsub.Text = "Add" Then
            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTADDTAX.Text) + Val(txtotherchg.Text)), "0.00")
        Else
            txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTADDTAX.Text)) - Val(txtotherchg.Text)), "0.00")
        End If


        ''ADD EXTRAADULTS AND EXTRACHILDS IN GTOTTAL 
        'For Each ROW As DataGridViewRow In GRIDPUR.Rows
        '    If ROW.Cells(GPURSRNO.Index).Value <> Nothing Then
        '        If ROW.Cells(GPURPACKAGE.Index).Value = "No" Then
        '            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text.Trim) + (Val(ROW.Cells(GPUREXTRAADULT.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)) + (Val(ROW.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(TXTTOTALNIGHTS.Text.Trim)), "0.00")
        '        Else
        '            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text.Trim) + (Val(ROW.Cells(GPUREXTRAADULTRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRAADULT.Index).EditedFormattedValue)) + (Val(ROW.Cells(GPUREXTRACHILDRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GPUREXTRACHILDS.Index).EditedFormattedValue)), "0.00")
        '        End If
        '    End If
        'Next

        txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


    End Sub

    Sub getmaxno_DN()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DN_NO),0) + 1 ", "DEBITNOTEMASTER", " AND DN_cmpid=" & CmpId & " AND DN_LOCATIONID = " & Locationid & " AND DN_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTDNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub DNDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DNDATE.Validating
        Try
            If DNDATE.Text <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'  and REGISTER_NAME <> 'AIRLINE DEBITNOTE' ")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            getmaxno_DN()
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
            End If
            CMBHSNITEMDESC.SelectAll()
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If TXTBILLNO.Text.Trim <> "" And TYPE = Nothing Then TYPE = "HOTELBOOKING"

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            If TYPE = Nothing Then TYPE = ""
            alParaval.Add(TYPE)
            alParaval.Add(Format(Convert.ToDateTime(DNDATE.Text).Date, "MM/dd/yyyy"))

            'IF BILLNO IS NOT THERE THEN ARRIVAL DATE SAME AS DNDATE
            If TXTBILLNO.Text.Trim = "" Then
                alParaval.Add(Format(Convert.ToDateTime(DNDATE.Text).Date, "MM/dd/yyyy"))
            Else
                alParaval.Add(ARRIVALDATE.Value)
            End If

            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(Val(PACKAGESRNO))
            alParaval.Add(TXTGUESTNAME.Text.Trim)
            alParaval.Add(TXTHOTELNAME.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDPER.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURTDSPER.Text.Trim))
            alParaval.Add(Val(TXTPURTDSRS.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTPURSERVCHGS.Text.Trim))
            alParaval.Add(CHKTAXSERVCHGS.CheckState)
            alParaval.Add(CHKMANUAL.CheckState)
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
            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))
            alParaval.Add(Val(TXTDP.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(ClientName)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

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

            If CHKGSTR1.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            Dim objclsDNmaster As New ClsDebitNote()
            objclsDNmaster.alParaval = alParaval
            Dim DT As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DT = objclsDNmaster.save()
                MessageBox.Show("Details Added")
                PRINTREPORT(DT.Rows(0).Item(0))

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDNNO)
                DT = objclsDNmaster.update()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPDNNO)
            End If

            clear()
            edit = False
            TXTBILLNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If DNDATE.Text = "__/__/____" Then
            EP.SetError(DNDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DNDATE.Text) Then
                EP.SetError(DNDATE, "Date Not in Current Accounting Year")
                bln = False
            End If
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If


        'CHEKCING IN HOTELBOOKINGS WHETHER DN IS MADE OR NOT
        If TXTBILLNO.Text.Trim <> "" And edit = False Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" * ", "", " (SELECT BOOKING_PURRETURN AS PURRETURN, BOOKING_PURBILLINITIALS AS INITIALS, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_RETURN AS PURRETURN, BOOKING_PURBILLINITIALS AS INITIALS,BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS WHERE BOOKING_SRNO = " & PACKAGESRNO & " UNION ALL SELECT BOOKING_PURRETURN AS PURRETURN, BOOKING_PURBILLINITIALS AS INITIALS, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM RAILBOOKINGMASTER UNION ALL SELECT BOOKING_RETURN AS PURRETURN, BOOKING_PURBILLINITIALS AS INITIALS, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM CARBOOKINGMASTER_PURCHASEDETAILS )AS T ", " AND T.INITIALS = '" & TXTBILLNO.Text.Trim & "'  AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows(0).Item("PURRETURN")) > 0 Then
                    EP.SetError(TXTBILLNO, "Debit Note Already Raised")
                    bln = False
                End If
            End If
        End If


        'If TXTBILLNO.Text.Trim = "" Then
        '    EP.SetError(TXTBILLNO, "Select Booking Voucher")
        '    bln = False
        'End If

        If TYPE = "CARBOOKING" Then
            If TXTBILLNO.Text.Trim <> "" And PACKAGESRNO = 0 Then
                EP.SetError(TXTBILLNO, "Create Debit Note from Holiday Package Voucher")
                bln = False
            End If
        End If

        If TYPE = "HOTELBOOKING" Then
            If TXTBILLNO.Text.Trim <> "" And TXTGUESTNAME.Text.Trim = "" Then
                EP.SetError(TXTGUESTNAME, "Select Booking Voucher")
                bln = False
            End If

            If TXTBILLNO.Text.Trim <> "" And TXTHOTELNAME.Text.Trim = "" Then
                EP.SetError(TXTHOTELNAME, "Select Booking Voucher")
                bln = False
            End If
        End If

        If CMBNAME.Text.Trim = "" Then
            EP.SetError(CMBNAME, "Select Booking Voucher")
            bln = False
        End If


        If txtgrandtotal.Text.Trim = "" Then
            EP.SetError(txtgrandtotal, "Enter Amount")
            bln = False
        End If



        Return bln

    End Function

    Private Sub DN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
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
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New DebitNoteDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    DNREGABBR = dt.Rows(0).Item(0).ToString
                    DNREGINITIAL = dt.Rows(0).Item(1).ToString
                    DNREGID = dt.Rows(0).Item(2)
                    getmaxno_DN()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objDNdtls As New DebitNoteDetails
            objDNdtls.MdiParent = MDIMain
            objDNdtls.Show()
            objDNdtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGS.Enter
        Try
            If CMBOTHERCHGS.Text.Trim = "" Then fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGS.Validating
        Try
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "INDIRECT EXPENSES")
        Catch ex As Exception
            Throw ex
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
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.GotFocus
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBADDTAX.Text.Trim <> "" Then TAXvalidate(CMBADDTAX, e, Me)
            PURCHASETOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            filltax(cmbtax, edit)
            filltax(CMBADDTAX, edit)
            'fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            fillname(CMBNAME, edit, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')")
            fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            fillregister(cmbregister, " and register_type = 'DEBITNOTE'  and REGISTER_NAME <> 'AIRLINE DEBITNOTE' ")
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')")
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
                'OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'"
                OBJLEDGER.STRSEARCH = " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')"
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
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(GROUPMASTER.GROUP_SECONDARY,'') AS SECONDARY ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id INNER JOIN GROUPMASTER ON LEDGERS.ACC_GROUPID = GROUPMASTER.GROUP_ID", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    If DT.Rows(0).Item("SECONDARY") = "Sundry Debtors" Then CHKGSTR1.CheckState = CheckState.Checked
                End If
                GETHSNCODE()
            End If
            CMBNAME.Enabled = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            'If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTOTHERCHGSADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITNOTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            clear()

            If BILLNO <> "" Then
                TXTBILLNO.Text = BILLNO
                TXTBILLNO.Enabled = False
                GETDATA()
            End If


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsDN As New ClsDebitNote()
                dt = objclsDN.selectDEBITNOTE_edit(TEMPDNNO, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTDNNO.Text = TEMPDNNO
                        cmbregister.Text = TEMPREGNAME
                        PACKAGESRNO = dt.Rows(0).Item("PACKAGESRNO")
                        TYPE = dt.Rows(0).Item("TYPE")
                        CMBHSNITEMDESC.Text = dr("ITEMDESC")
                        TXTSTATECODE.Text = dr("STATECODE")
                        DNDATE.Text = Convert.ToDateTime(dr("DNDATE")).Date
                        ARRIVALDATE.Value = Convert.ToDateTime(dr("ARRIVALDATE")).Date
                        TXTBILLNO.Text = dt.Rows(0).Item("BILLNO")
                        TXTBILLNO.Enabled = False
                        If TXTBILLNO.Text.Trim = "" Then CMBNAME.Enabled = True Else CMBNAME.Enabled = False

                        TXTGUESTNAME.Text = dt.Rows(0).Item("GUESTNAME")
                        TXTHOTELNAME.Text = dt.Rows(0).Item("HOTELNAME")
                        CMBNAME.Text = dt.Rows(0).Item("NAME")
                        TXTHSNCODE.Text = dt.Rows(0).Item("HSNCODE")
                        TXTTOTALPURAMT.Text = dt.Rows(0).Item("PURAMT")
                        TXTDISCPER.Text = dt.Rows(0).Item("DISCPER")
                        TXTDISCRS.Text = dt.Rows(0).Item("DISCRS")
                        TXTCOMMRECDPER.Text = dt.Rows(0).Item("COMMPER")
                        TXTCOMMRECDRS.Text = dt.Rows(0).Item("COMMRS")
                        TXTPURTDSPER.Text = dt.Rows(0).Item("TDSPER")
                        TXTPURTDSRS.Text = dt.Rows(0).Item("TDSRS")
                        TXTPUREXTRACHGS.Text = dt.Rows(0).Item("EXTRACHGS")
                        TXTPURSERVCHGS.Text = Val(dt.Rows(0).Item("PURSERVCHGS"))
                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dt.Rows(0).Item("TAXSERVCHGS"))
                        cmbtax.Text = dt.Rows(0).Item("TAXNAME")
                        txttax.Text = dt.Rows(0).Item("TAXAMT")
                        CMBADDTAX.Text = dt.Rows(0).Item("ADDTAXNAME")
                        TXTADDTAX.Text = dt.Rows(0).Item("ADDTAXAMT")
                        CMBOTHERCHGS.Text = dt.Rows(0).Item("OTHERCHGSNAME")

                        If dr("OTHERCHGSAMT") > 0 Then
                            txtotherchg.Text = dr("OTHERCHGSAMT")
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = dr("OTHERCHGSAMT") * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        If Convert.ToBoolean(dr("GSTR1")) = False Then CHKGSTR1.Checked = False Else CHKGSTR1.Checked = True
                        If Convert.ToBoolean(dr("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        If CHKMANUAL.Checked = True Then
                            TXTCGSTAMT.Text = Format(Val(dr("CGSTAMT")), "0.00")
                            TXTSGSTAMT.Text = Format(Val(dr("SGSTAMT")), "0.00")
                            TXTIGSTAMT.Text = Format(Val(dr("IGSTAMT")), "0.00")
                        End If

                        TXTCGSTPER.Text = dr("CGSTPER")
                        TXTCGSTAMT.Text = dr("CGSTAMT")
                        TXTSGSTPER.Text = dr("SGSTPER")
                        TXTSGSTAMT.Text = dr("SGSTAMT")
                        TXTIGSTPER.Text = dr("IGSTPER")
                        TXTIGSTAMT.Text = dr("IGSTAMT")

                        txtroundoff.Text = dt.Rows(0).Item("ROUNDOFF")
                        txtgrandtotal.Text = dt.Rows(0).Item("GTOTAL")
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTDP.Text = dt.Rows(0).Item("DP")


                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                        If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then LBLEINVGENERATED.Visible = True

                        PURCHASETOTAL()

                    Next
                    cmbregister.Enabled = False
                    TXTGUESTNAME.Focus()

                End If
            End If

            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_DN()
            Dim MAXNO As Integer = TXTDNNO.Text.Trim
            clear()
            If Val(TXTDNNO.Text) - 1 >= TEMPDNNO Then
                edit = True
                DEBITNOTE_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If CMBNAME.Text.Trim = "" And TEMPDNNO < MAXNO Then
                TXTDNNO.Text = TEMPDNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPDNNO > 0 Then
                edit = True
                DEBITNOTE_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If CMBNAME.Text.Trim = "" And TEMPDNNO > 1 Then
                TXTDNNO.Text = TEMPDNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Debit Note Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJDN As New ClsDebitNote
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TYPE)
                    ALPARAVAL.Add(TEMPDNNO)
                    ALPARAVAL.Add(TEMPREGNAME)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)
                    OBJDN.alParaval = ALPARAVAL
                    Dim DT As DataTable = OBJDN.Delete()
                    MsgBox(DT.Rows(0).Item(0).ToString)

                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            TEMPDNNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPDNNO > 0 Then
                edit = True
                DEBITNOTE_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            If TXTBILLNO.Text.Trim <> "" And edit = False Then
                GETDATA()
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTBILLNO.Enabled = False
            Else
                TXTBILLNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA()
        Try
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" * ", "", " (SELECT 'HOTELBOOKING' AS TYPE, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_CMPID AS CMPID, HOTELBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOTELBOOKINGMASTER.BOOKING_YEARID AS YEARID, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, HOTELBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, HOTELBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, HOTELBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, HOTELBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, HOTELBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, HOTELBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, HOTELBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, HOTELBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, ISNULL(HOTELBOOKINGMASTER.BOOKING_DP, 0) AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HOTELBOOKINGMASTER.BOOKING_PUROURCOMMPER, 0) AS PURSERVCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN GUESTMASTER INNER JOIN HOTELBOOKINGMASTER ON GUESTMASTER.GUEST_ID = HOTELBOOKINGMASTER.BOOKING_GUESTID AND GUESTMASTER.GUEST_CMPID = HOTELBOOKINGMASTER.BOOKING_CMPID AND GUESTMASTER.GUEST_LOCATIONID = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND GUESTMASTER.GUEST_YEARID = HOTELBOOKINGMASTER.BOOKING_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID ON HSNMASTER.HSN_ID = HOTELBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON HOTELBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON HOTELBOOKINGMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND HOTELBOOKINGMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND HOTELBOOKINGMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = HOTELBOOKINGMASTER.BOOKING_PURTAXID ON HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id UNION ALL SELECT     'RAILBOOKING' AS TYPE, RAILBOOKINGMASTER.BOOKING_JOURNEYDATE AS ARRIVAL, RAILBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, RAILBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, RAILBOOKINGMASTER.BOOKING_CMPID AS CMPID, RAILBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, RAILBOOKINGMASTER.BOOKING_YEARID AS YEARID, ISNULL(LEDGERS.Acc_cmpname, '') AS GUESTNAME, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNAME, '') AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, RAILBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, RAILBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, RAILBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, RAILBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, RAILBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, RAILBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, RAILBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, RAILBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, RAILBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, RAILBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, RAILBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS FROM         STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN RAILBOOKINGMASTER ON HSNMASTER.HSN_ID = RAILBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON RAILBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND RAILBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND RAILBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id ON TAXMASTER.tax_yearid = RAILBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = RAILBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = RAILBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = RAILBOOKINGMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = RAILBOOKINGMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = RAILBOOKINGMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = RAILBOOKINGMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = RAILBOOKINGMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS ARRIVAL, AIRLINEBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID, '' AS GUESTNAME, ISNULL(FLIGHTMASTER.FLIGHT_NAME, '') AS AIRLINENAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, AIRLINEBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, AIRLINEBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, AIRLINEBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, AIRLINEBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, AIRLINEBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, AIRLINEBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, AIRLINEBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, AIRLINEBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRLINEBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, AIRLINEBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, AIRLINEBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, AIRLINEBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER INNER JOIN AIRLINEBOOKINGMASTER INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ON HSNMASTER.HSN_ID = AIRLINEBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = AIRLINEBOOKINGMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'MISCELLANEOUSPURCHASE' AS TYPE, '' AS ARRIVAL, MISCPURMASTER.BOOKING_PURAMTPAID AS PAIDAMT, MISCPURMASTER.BOOKING_PURBILLINITIALS AS BILLNO, MISCPURMASTER.BOOKING_CMPID AS CMPID, MISCPURMASTER.BOOKING_LOCATIONID AS LOCATIONID, MISCPURMASTER.BOOKING_YEARID AS YEARID, '' AS GUESTNAME, '' AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, MISCPURMASTER.BOOKING_FINALPURAMT AS PURAMT, MISCPURMASTER.BOOKING_DISCRECDPER AS DISCPER, MISCPURMASTER.BOOKING_DISCRECDRS AS DISCRS, MISCPURMASTER.BOOKING_COMMRECDPER AS COMMPER, MISCPURMASTER.BOOKING_COMMRECDRS AS COMMRS, MISCPURMASTER.BOOKING_PURTDSPER AS TDSPER, MISCPURMASTER.BOOKING_PURTDSRS AS TDSRS, MISCPURMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, MISCPURMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, MISCPURMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, MISCPURMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCPURMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, MISCPURMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(MISCPURMASTER.BOOKING_CGSTPER, 0) AS CGSTPER, ISNULL(MISCPURMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(MISCPURMASTER.BOOKING_SGSTPER, 0) AS SGSTPER, ISNULL(MISCPURMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(MISCPURMASTER.BOOKING_IGSTPER, 0) AS IGSTPER, ISNULL(MISCPURMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN MISCPURMASTER ON HSNMASTER.HSN_ID = MISCPURMASTER.BOOKING_HSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON MISCPURMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND MISCPURMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND MISCPURMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND MISCPURMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON MISCPURMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND MISCPURMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND MISCPURMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND MISCPURMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = MISCPURMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = MISCPURMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = MISCPURMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = MISCPURMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = MISCPURMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = MISCPURMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = MISCPURMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = MISCPURMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'HOLIDAYPACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGEFROM AS ARRIVAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_AMTPAID AS PAIDAMT, HOLIDAYPACKAGEMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID, LEDGERS.Acc_cmpname AS GUESTNAME, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME, '') AS HOTELNAME, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DISCPER AS DISCPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DISC AS DISCRS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_COMMPER AS COMMPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_COMM AS COMMRS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TDSPER AS TDSPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TDS AS TDSRS, 0 AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSERVICECHGS, 0) AS PURSERVCHGS, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS FROM HOLIDAYPACKAGEMASTER INNER JOIN HOLIDAYPACKAGEMASTER_PURCHASEDETAILS ON HOLIDAYPACKAGEMASTER.BOOKING_NO = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN HSNMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHGSLEDGERS.Acc_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = OTHERCHGSLEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = OTHERCHGSLEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = ADDTAXMASTER.tax_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID = ADDTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = TAXMASTER.tax_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = TAXMASTER.tax_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SRNO = " & PACKAGESRNO & " UNION ALL SELECT 'CARBOOKING' AS TYPE, CARBOOKINGMASTER.BOOKING_PACKAGEFROM AS ARRIVAL, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMTPAID AS PAIDAMT, CARBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, CARBOOKINGMASTER.BOOKING_CMPID AS CMPID, CARBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, CARBOOKINGMASTER.BOOKING_YEARID AS YEARID, LEDGERS.Acc_cmpname AS GUESTNAME, '' AS HOTELNAME, LEDGERS.Acc_cmpname AS NAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DISCPER AS DISCPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DISC AS DISCRS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_COMMPER AS COMMPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_COMM AS COMMRS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TDSPER AS TDSPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TDS AS TDSRS, 0 AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSERVCHGS, 0) AS PURSERVCHGS, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSERVTAX, 0) AS TAXSERVCHGS FROM CARBOOKINGMASTER INNER JOIN CARBOOKINGMASTER_PURCHASEDETAILS ON CARBOOKINGMASTER.BOOKING_NO = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AND CARBOOKINGMASTER.BOOKING_CMPID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID AND CARBOOKINGMASTER.BOOKING_LOCATIONID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND CARBOOKINGMASTER.BOOKING_YEARID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHGSLEDGERS.Acc_yearid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = OTHERCHGSLEDGERS.Acc_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = OTHERCHGSLEDGERS.Acc_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = TAXMASTER.tax_yearid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = TAXMASTER.tax_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id WHERE CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SRNO = " & PACKAGESRNO & " UNION ALL SELECT 'VISABOOKING' AS TYPE, GETDATE() AS ARRIVAL, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_AMTPAID, 0) AS PAIDAMT, VISABOOKING.BOOKING_PURBILLINITIALS AS BILLNO, VISABOOKING.BOOKING_CMPID AS CMPID, 0 AS LOCATIONID, VISABOOKING.BOOKING_YEARID AS YEARID, ISNULL(LEDGERS.Acc_cmpname, '') AS GUESTNAME, '' AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_AMOUNT, 0) AS PURAMT, 0 AS DISCPER, 0 AS DISCRS, 0 AS COMMPER, 0 AS COMMRS, 0 AS TDSPER, 0 AS TDSRS, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_SERVCHGS, 0) AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_TAXAMT, 0) AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHARGES.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_OTHERCHGS, 0) AS OTHERCHARGES, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, VISABOOKING_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_SERVCHGS, 0) AS PURSERVCHGS, 1 AS TAXSERVCHGS FROM VISABOOKING INNER JOIN VISABOOKING_PURCHASEDETAILS ON VISABOOKING.BOOKING_NO = VISABOOKING_PURCHASEDETAILS.BOOKING_NO AND VISABOOKING.BOOKING_CMPID = VISABOOKING_PURCHASEDETAILS.BOOKING_CMPID AND VISABOOKING.BOOKING_YEARID = VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON VISABOOKING_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON VISABOOKING_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHARGES ON VISABOOKING_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHARGES.Acc_id AND VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHARGES.Acc_yearid LEFT OUTER JOIN TAXMASTER ON VISABOOKING_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id WHERE VISABOOKING_PURCHASEDETAILS.BOOKING_SRNO=" & PACKAGESRNO & ") AS T ", " AND T.BILLNO = '" & TXTBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
            'Dim DT As DataTable = OBJCMN.search(" * ", "", " (SELECT  'HOTELBOOKING' AS TYPE, HOTELBOOKINGMASTER.BOOKING_ARRIVAL AS ARRIVAL, HOTELBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_CMPID AS CMPID, HOTELBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOTELBOOKINGMASTER.BOOKING_YEARID AS YEARID, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUESTNAME, ISNULL(HOTELMASTER.HOTEL_NAME, '') AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, HOTELBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, HOTELBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, HOTELBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, HOTELBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, HOTELBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, HOTELBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, HOTELBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, HOTELBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, ISNULL(HOTELBOOKINGMASTER.BOOKING_DP, 0) AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HOTELBOOKINGMASTER.BOOKING_PUROURCOMMPER, 0) AS PURSERVCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(HOTELBOOKINGMASTER.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN GUESTMASTER INNER JOIN HOTELBOOKINGMASTER ON GUESTMASTER.GUEST_ID = HOTELBOOKINGMASTER.BOOKING_GUESTID AND GUESTMASTER.GUEST_CMPID = HOTELBOOKINGMASTER.BOOKING_CMPID AND GUESTMASTER.GUEST_LOCATIONID = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND GUESTMASTER.GUEST_YEARID = HOTELBOOKINGMASTER.BOOKING_YEARID INNER JOIN HOTELMASTER ON HOTELBOOKINGMASTER.BOOKING_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELBOOKINGMASTER.BOOKING_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELBOOKINGMASTER.BOOKING_YEARID = HOTELMASTER.HOTEL_YEARID ON HSNMASTER.HSN_ID = HOTELBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON HOTELBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON HOTELBOOKINGMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND HOTELBOOKINGMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND HOTELBOOKINGMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = HOTELBOOKINGMASTER.BOOKING_PURTAXID ON HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id  UNION ALL  SELECT 'RAILBOOKING' AS TYPE, RAILBOOKINGMASTER.BOOKING_JOURNEYDATE AS ARRIVAL, RAILBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, RAILBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, RAILBOOKINGMASTER.BOOKING_CMPID AS CMPID, RAILBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, RAILBOOKINGMASTER.BOOKING_YEARID AS YEARID, ISNULL(LEDGERS.Acc_cmpname, '') AS GUESTNAME, ISNULL(RAILBOOKINGMASTER.BOOKING_TRAINNAME, '') AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, RAILBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, RAILBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, RAILBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, RAILBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, RAILBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, RAILBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, RAILBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, RAILBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, RAILBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, RAILBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, RAILBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(RAILBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS,ISNULL(RAILBOOKINGMASTER.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM         STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN RAILBOOKINGMASTER ON HSNMASTER.HSN_ID = RAILBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON RAILBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND RAILBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND RAILBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id ON TAXMASTER.tax_yearid = RAILBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = RAILBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = RAILBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = RAILBOOKINGMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = RAILBOOKINGMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = RAILBOOKINGMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = RAILBOOKINGMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = RAILBOOKINGMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS ARRIVAL, AIRLINEBOOKINGMASTER.BOOKING_PURAMTPAID AS PAIDAMT, AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID, '' AS GUESTNAME, ISNULL(FLIGHTMASTER.FLIGHT_NAME, '') AS AIRLINENAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, AIRLINEBOOKINGMASTER.BOOKING_TOTALPURAMT AS PURAMT, AIRLINEBOOKINGMASTER.BOOKING_DISCRECDPER AS DISCPER, AIRLINEBOOKINGMASTER.BOOKING_DISCRECDRS AS DISCRS, AIRLINEBOOKINGMASTER.BOOKING_COMMRECDPER AS COMMPER, AIRLINEBOOKINGMASTER.BOOKING_COMMRECDRS AS COMMRS, AIRLINEBOOKINGMASTER.BOOKING_PURTDSPER AS TDSPER, AIRLINEBOOKINGMASTER.BOOKING_PURTDSRS AS TDSRS, AIRLINEBOOKINGMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, AIRLINEBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, AIRLINEBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, AIRLINEBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, AIRLINEBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS,ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER INNER JOIN AIRLINEBOOKINGMASTER INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID ON HSNMASTER.HSN_ID = AIRLINEBOOKINGMASTER.BOOKING_PURHSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = AIRLINEBOOKINGMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'MISCELLANEOUSPURCHASE' AS TYPE, '' AS ARRIVAL, MISCPURMASTER.BOOKING_PURAMTPAID AS PAIDAMT, MISCPURMASTER.BOOKING_PURBILLINITIALS AS BILLNO, MISCPURMASTER.BOOKING_CMPID AS CMPID, MISCPURMASTER.BOOKING_LOCATIONID AS LOCATIONID, MISCPURMASTER.BOOKING_YEARID AS YEARID, '' AS GUESTNAME, '' AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, MISCPURMASTER.BOOKING_FINALPURAMT AS PURAMT, MISCPURMASTER.BOOKING_DISCRECDPER AS DISCPER, MISCPURMASTER.BOOKING_DISCRECDRS AS DISCRS, MISCPURMASTER.BOOKING_COMMRECDPER AS COMMPER, MISCPURMASTER.BOOKING_COMMRECDRS AS COMMRS, MISCPURMASTER.BOOKING_PURTDSPER AS TDSPER, MISCPURMASTER.BOOKING_PURTDSRS AS TDSRS, MISCPURMASTER.BOOKING_PUREXTRACHGS AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, MISCPURMASTER.BOOKING_PURTAX AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, MISCPURMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, ISNULL(OTHERCHGS.Acc_cmpname, '') AS OTHERCHGSNAME, MISCPURMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCPURMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, MISCPURMASTER.BOOKING_PURGRANDTOTAL AS GTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(MISCPURMASTER.BOOKING_CGSTPER, 0) AS CGSTPER, ISNULL(MISCPURMASTER.BOOKING_CGSTAMT, 0) AS CGSTAMT, ISNULL(MISCPURMASTER.BOOKING_SGSTPER, 0) AS SGSTPER, ISNULL(MISCPURMASTER.BOOKING_SGSTAMT, 0) AS SGSTAMT, ISNULL(MISCPURMASTER.BOOKING_IGSTPER, 0) AS IGSTPER, ISNULL(MISCPURMASTER.BOOKING_IGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(MISCPURMASTER.BOOKING_TAXSERVCHGS, 0) AS TAXSERVCHGS,ISNULL(MISCPURMASTER.BOOKING_MANUALGST, 0) AS MANUALGST FROM STATEMASTER RIGHT OUTER JOIN LEDGERS ON STATEMASTER.state_id = LEDGERS.Acc_stateid RIGHT OUTER JOIN TAXMASTER RIGHT OUTER JOIN HSNMASTER RIGHT OUTER JOIN MISCPURMASTER ON HSNMASTER.HSN_ID = MISCPURMASTER.BOOKING_HSNCODEID LEFT OUTER JOIN LEDGERS AS OTHERCHGS ON MISCPURMASTER.BOOKING_YEARID = OTHERCHGS.Acc_yearid AND MISCPURMASTER.BOOKING_LOCATIONID = OTHERCHGS.Acc_locationid AND MISCPURMASTER.BOOKING_CMPID = OTHERCHGS.Acc_cmpid AND MISCPURMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON MISCPURMASTER.BOOKING_PURADDTAXID = ADDTAXMASTER.tax_id AND MISCPURMASTER.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND MISCPURMASTER.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND MISCPURMASTER.BOOKING_YEARID = ADDTAXMASTER.tax_yearid ON TAXMASTER.tax_yearid = MISCPURMASTER.BOOKING_YEARID AND TAXMASTER.tax_locationid = MISCPURMASTER.BOOKING_LOCATIONID AND TAXMASTER.tax_cmpid = MISCPURMASTER.BOOKING_CMPID AND TAXMASTER.tax_id = MISCPURMASTER.BOOKING_PURTAXID ON LEDGERS.Acc_cmpid = MISCPURMASTER.BOOKING_CMPID AND LEDGERS.Acc_locationid = MISCPURMASTER.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = MISCPURMASTER.BOOKING_YEARID AND LEDGERS.Acc_id = MISCPURMASTER.BOOKING_PURLEDGERID UNION ALL SELECT 'HOLIDAYPACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_PACKAGEFROM AS ARRIVAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_AMTPAID AS PAIDAMT, HOLIDAYPACKAGEMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID, LEDGERS.Acc_cmpname AS GUESTNAME, ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_TOURNAME, '') AS HOTELNAME, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DISCPER AS DISCPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DISC AS DISCRS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_COMMPER AS COMMPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_COMM AS COMMRS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TDSPER AS TDSPER, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TDS AS TDSRS, 0 AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, ISNULL(ADDTAXMASTER.tax_name, '') AS ADDTAXNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURSERVICECHGS, 0) AS PURSERVCHGS, ISNULL(HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS,ISNULL(HOLIDAYPACKAGEMASTER.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM HOLIDAYPACKAGEMASTER INNER JOIN HOLIDAYPACKAGEMASTER_PURCHASEDETAILS ON HOLIDAYPACKAGEMASTER.BOOKING_NO = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN HSNMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHGSLEDGERS.Acc_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = OTHERCHGSLEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = OTHERCHGSLEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS ADDTAXMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = ADDTAXMASTER.tax_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = ADDTAXMASTER.tax_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = ADDTAXMASTER.tax_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID = ADDTAXMASTER.tax_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = TAXMASTER.tax_yearid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = TAXMASTER.tax_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id WHERE HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SRNO = " & PACKAGESRNO & " UNION ALL SELECT 'CARBOOKING' AS TYPE, CARBOOKINGMASTER.BOOKING_PACKAGEFROM AS ARRIVAL, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMTPAID AS PAIDAMT, CARBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, CARBOOKINGMASTER.BOOKING_CMPID AS CMPID, CARBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, CARBOOKINGMASTER.BOOKING_YEARID AS YEARID, LEDGERS.Acc_cmpname AS GUESTNAME, '' AS HOTELNAME, LEDGERS.Acc_cmpname AS NAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DISCPER AS DISCPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DISC AS DISCRS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_COMMPER AS COMMPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_COMM AS COMMRS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TDSPER AS TDSPER, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TDS AS TDSRS, 0 AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHGSLEDGERS.Acc_cmpname, '') AS OTHERCHGSNAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSERVCHGS, 0) AS PURSERVCHGS, ISNULL(CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURSERVTAX, 0) AS TAXSERVCHGS ,ISNULL(CARBOOKINGMASTER.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM CARBOOKINGMASTER INNER JOIN CARBOOKINGMASTER_PURCHASEDETAILS ON CARBOOKINGMASTER.BOOKING_NO = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AND CARBOOKINGMASTER.BOOKING_CMPID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID AND CARBOOKINGMASTER.BOOKING_LOCATIONID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND CARBOOKINGMASTER.BOOKING_YEARID = CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGERS ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHGSLEDGERS.Acc_yearid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = OTHERCHGSLEDGERS.Acc_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = OTHERCHGSLEDGERS.Acc_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHGSLEDGERS.Acc_id LEFT OUTER JOIN TAXMASTER AS TAXMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = TAXMASTER.tax_yearid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = TAXMASTER.tax_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id WHERE CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SRNO  = " & PACKAGESRNO & " UNION ALL SELECT 'VISABOOKING' AS TYPE, GETDATE() AS ARRIVAL, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_AMTPAID, 0) AS PAIDAMT, VISABOOKING.BOOKING_PURBILLINITIALS AS BILLNO, VISABOOKING.BOOKING_CMPID AS CMPID, 0 AS LOCATIONID, VISABOOKING.BOOKING_YEARID AS YEARID, ISNULL(LEDGERS.Acc_cmpname, '') AS GUESTNAME, '' AS HOTELNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_AMOUNT, 0) AS PURAMT, 0 AS DISCPER, 0 AS DISCRS, 0 AS COMMPER, 0 AS COMMRS, 0 AS TDSPER, 0 AS TDSRS, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_SERVCHGS, 0) AS EXTRACHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_TAXAMT, 0) AS TAXAMT, '' AS ADDTAXNAME, 0 AS ADDTAXAMT, ISNULL(OTHERCHARGES.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_OTHERCHGS, 0) AS OTHERCHARGES, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, VISABOOKING_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, 0 AS DP, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(CAST(STATEMASTER.state_remark AS VARCHAR), '') AS STATECODE, ISNULL(VISABOOKING_PURCHASEDETAILS.BOOKING_SERVCHGS, 0) AS PURSERVCHGS, 1 AS TAXSERVCHGS,ISNULL(VISABOOKING.BOOKING_PURMANUALGST, 0) AS MANUALGST FROM VISABOOKING INNER JOIN VISABOOKING_PURCHASEDETAILS ON VISABOOKING.BOOKING_NO = VISABOOKING_PURCHASEDETAILS.BOOKING_NO AND VISABOOKING.BOOKING_CMPID = VISABOOKING_PURCHASEDETAILS.BOOKING_CMPID AND VISABOOKING.BOOKING_YEARID = VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID INNER JOIN LEDGERS ON VISABOOKING_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN HSNMASTER ON VISABOOKING_PURCHASEDETAILS.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS OTHERCHARGES ON VISABOOKING_PURCHASEDETAILS.BOOKING_OTHERCHGSID = OTHERCHARGES.Acc_id AND VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = OTHERCHARGES.Acc_yearid LEFT OUTER JOIN TAXMASTER ON VISABOOKING_PURCHASEDETAILS.BOOKING_TAXID = TAXMASTER.tax_id WHERE VISABOOKING_PURCHASEDETAILS.BOOKING_SRNO = " & PACKAGESRNO & ") AS T ", " AND T.BILLNO = '" & TXTBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)

            'WE HAVE COMMENTED THIS QUERY BECAUSE WE HAVE NOT PASSED PURCHASE GRID SR NO HENCE IT IS SELECTING ALL ENTRIES

            Dim WHERECLAUSE As String = ""
            If TEMPPURNAME <> "" Then WHERECLAUSE = " AND LEDGERNAME = '" & TEMPPURNAME & "' "
            Dim DT As DataTable = OBJCMN.search(" RESERVATIONDETAILS.RECPAYAMT AS PAIDAMT, BOOKINGNO AS BILL, BILLINITIALS AS BILLNO, CMPID, LOCATIONID, YEARID ,GUESTNAME , HOTELNAME ,LEDGERNAME AS NAME, TOTALAMT AS PURAMT, 0 AS DISCPER, DISCRS, COMMRS, TDSRS , EXTRACHGS, TAXNAME, TAX AS TAXAMT, ADDTAXNAME , ADDTAX AS ADDTAXAMT, OTHERCHGSNAME , OTHERCHGS , ROUNDOFF, GTOTAL, ARRIVAL, TYPE, DP, ISNULL(SERVCHGS,0) AS PURSERVCHGS, ISNULL(TAXSERVCHGS,0) AS TAXSERVCHGS,ISNULL(HSNCODE, '') AS HSNCODE, ISNULL(HSNDESC, '') AS ITEMDESC, ISNULL(IGSTAMT, 0) AS IGSTAMT, ISNULL(IGSTPER, 0) AS IGSTPER, ISNULL(SGSTAMT, 0) AS SGSTAMT,  ISNULL(SGSTPER, 0) AS SGSTPER, ISNULL(CGSTAMT, 0) AS CGSTAMT, ISNULL(CGSTPER, 0) AS CGSTPER ,MANUALGST ", "", " RESERVATIONDETAILS ", " AND BILLINITIALS = '" & TXTBILLNO.Text.Trim & "' AND YEARID = " & YearId & WHERECLAUSE)

            ' Dim DT As DataTable = OBJCMN.search(" RESERVATIONDETAILS.RECPAYAMT AS PAIDAMT, BOOKINGNO AS BILL, BILLINITIALS AS BILLNO, CMPID, LOCATIONID, YEARID ,GUESTNAME , HOTELNAME ,LEDGERNAME AS NAME, TOTALAMT AS PURAMT, 0 AS DISCPER, DISCRS, COMMRS, TDSRS , EXTRACHGS, TAXNAME, TAX AS TAXAMT, ADDTAXNAME , ADDTAX AS ADDTAXAMT, OTHERCHGSNAME , OTHERCHGS , ROUNDOFF, GTOTAL, ARRIVAL, TYPE, DP, ISNULL(SERVCHGS,0) AS PURSERVCHGS, ISNULL(TAXSERVCHGS,0) AS TAXSERVCHGS,ISNULL(HSNCODE, '') AS HSNCODE, ISNULL(HSNDESC, '') AS ITEMDESC, ISNULL(IGSTAMT, 0) AS IGSTAMT, ISNULL(IGSTPER, 0) AS IGSTPER, ISNULL(SGSTAMT, 0) AS SGSTAMT,  ISNULL(SGSTPER, 0) AS SGSTPER, ISNULL(CGSTAMT, 0) AS CGSTAMT, ISNULL(CGSTPER, 0) AS CGSTPER ,MANUALGST ,HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SRNO ", "", " RESERVATIONDETAILS INNER JOIN HOLIDAYPACKAGEMASTER_PURCHASEDETAILS ON RESERVATIONDETAILS.BOOKINGNO = HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO ", " AND BILLINITIALS = '" & TXTBILLNO.Text.Trim & "'AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SRNO =" & PACKAGESRNO & " AND YEARID = " & YearId)

            If DT.Rows.Count > 0 Then

                If DT.Rows(0).Item("TYPE") <> "RAILBOOKING" And DT.Rows(0).Item("TYPE") <> "VISABOOKING" Then
                    LBLEXTRACHGS.Text = "Other Chgs (Add)"
                    LBLHOTELNAME.Text = "Hotel Name"
                Else
                    LBLEXTRACHGS.Text = "Service Chgs (Add)"
                    LBLHOTELNAME.Text = "Train Name"
                End If

                If DT.Rows(0).Item("PAIDAMT") > 0 Then
                    MsgBox("Payment Made, Delete Payment First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TYPE = DT.Rows(0).Item("TYPE")
                CMBHSNITEMDESC.Text = DT.Rows(0).Item("ITEMDESC")
                GETSTATECODE()
                ARRIVALDATE.Value = Format(Convert.ToDateTime(DT.Rows(0).Item("ARRIVAL")).Date, "dd/MM/yyyy")

                TXTGUESTNAME.Text = DT.Rows(0).Item("GUESTNAME")
                TXTHOTELNAME.Text = DT.Rows(0).Item("HOTELNAME")
                CMBNAME.Text = DT.Rows(0).Item("NAME")
                TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                TXTTOTALPURAMT.Text = DT.Rows(0).Item("PURAMT")
                'TXTDISCPER.Text = DT.Rows(0).Item("DISCPER")
                TXTDISCPER.Text = 0
                TXTDISCRS.Text = DT.Rows(0).Item("DISCRS")
                'TXTCOMMRECDPER.Text = DT.Rows(0).Item("COMMPER")
                TXTCOMMRECDPER.Text = 0
                TXTCOMMRECDRS.Text = DT.Rows(0).Item("COMMRS")
                'TXTPURTDSPER.Text = DT.Rows(0).Item("TDSPER")
                TXTPURTDSPER.Text = 0
                TXTPURTDSRS.Text = DT.Rows(0).Item("TDSRS")
                TXTPUREXTRACHGS.Text = DT.Rows(0).Item("EXTRACHGS")
                cmbtax.Text = DT.Rows(0).Item("TAXNAME")
                txttax.Text = DT.Rows(0).Item("TAXAMT")
                CMBADDTAX.Text = DT.Rows(0).Item("ADDTAXNAME")
                TXTADDTAX.Text = DT.Rows(0).Item("ADDTAXAMT")
                CMBOTHERCHGS.Text = DT.Rows(0).Item("OTHERCHGSNAME")
                If Val(DT.Rows(0).Item("OTHERCHGS")) > 0 Then
                    txtotherchg.Text = DT.Rows(0).Item("OTHERCHGS")
                    cmbaddsub.Text = "Add"
                Else
                    txtotherchg.Text = DT.Rows(0).Item("OTHERCHGS") * (-1)
                    cmbaddsub.Text = "Sub."
                End If
                TXTCGSTPER.Text = DT.Rows(0).Item("CGSTPER")
                TXTCGSTAMT.Text = DT.Rows(0).Item("CGSTAMT")
                TXTSGSTPER.Text = DT.Rows(0).Item("SGSTPER")
                TXTSGSTAMT.Text = DT.Rows(0).Item("SGSTAMT")
                TXTIGSTPER.Text = DT.Rows(0).Item("IGSTPER")
                TXTIGSTAMT.Text = DT.Rows(0).Item("IGSTAMT")
                TXTPURSERVCHGS.Text = Val(DT.Rows(0).Item("PURSERVCHGS"))
                CHKTAXSERVCHGS.Checked = Convert.ToBoolean(DT.Rows(0).Item("TAXSERVCHGS"))
                CHKMANUAL.Checked = Convert.ToBoolean(DT.Rows(0).Item("MANUALGST"))
                txtroundoff.Text = DT.Rows(0).Item("ROUNDOFF")
                txtgrandtotal.Text = DT.Rows(0).Item("GTOTAL")
                TXTDP.Text = DT.Rows(0).Item("DP")
                txtremarks.Text = DT.Rows(0).Item("BILLNO")

                PURCHASETOTAL()

                CMBNAME.Enabled = False

            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub GETSTATECODE()
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "'  and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")

                GETHSNCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOTALPURAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTALPURAMT.Validated, TXTDISCPER.Validated, TXTDISCRS.Validated, TXTCOMMRECDRS.Validated, TXTCOMMRECDPER.Validated, TXTPURTDSPER.Validated, TXTPUREXTRACHGS.Validated, TXTPURTDSRS.Validated, TXTPURSERVCHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub cmbtax_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtax.Validated
        Try
            If cmbtax.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & cmbtax.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                If DT.Rows.Count > 0 Then
                    If Val(DT.Rows(0).Item("TAX")) = 0 Then
                        txttax.ReadOnly = False
                        txttax.Enabled = True
                    Else
                        txttax.ReadOnly = True
                        txttax.Enabled = False
                    End If
                End If
            Else
                txttax.Clear()
            End If
            PURCHASETOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub PBDISCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDISCDEL.Click
        Try
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
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

    Private Sub DebitNote_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPDNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BILLNO As Integer)
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Print Debit Note?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJCN As New CrDrNoteDesign
                OBJCN.BILLNO = BILLNO
                OBJCN.REGNAME = cmbregister.Text.Trim
                OBJCN.MdiParent = MDIMain
                OBJCN.FRMSTRING = "DEBIT"
                OBJCN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        PURCHASETOTAL()
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

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(DNDATE.Text).Date >= "01/07/2017" Then
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
                PURCHASETOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(DNDATE.Text).Date >= "01/07/2017" Then
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
                End If
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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTBILLNO.Text.Trim & TXTDNNO.Text.Trim & TXTBILLNO.Text.Trim
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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim TEMPREG As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE'  and REGISTER_NAME <> 'AIRLINE DEBITNOTE' AND REGISTER_YEARID = " & YearId)
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTDNNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTDNNO.Text.Trim) & AccFrom.Year & ".png"
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

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, GROUPMASTER.GROUP_SECONDARY AS SECONDARY  ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID INNER JOIN GROUPMASTER ON LEDGERS.ACC_GROUPID = GROUPMASTER.GROUP_ID", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") Or DT.Rows(0).Item("SECONDARY") <> "Sundry Debtors" Then
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim DTINI As DataTable = OBJCMN.search("DN_INITIALS AS PRINTINITIALS", "", " DEBITNOTEMASTER ", " AND DN_NO = " & Val(TXTDNNO.Text.Trim) & " AND DN_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""DBN"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & DNDATE.Text & """" & "},"


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

                Dim TEMPOTHERAMT As Double = 0.0
                Dim TEMPTOTALITEMAMT As Double = 0.0
                If CHKTAXSERVCHGS.Checked = True Then
                    TEMPOTHERAMT = Val(TXTTOTALPURAMT.Text.Trim) - Val(TXTDISCRS.Text.Trim) + Val(TXTCOMMRECDRS.Text.Trim) + Val(TXTPUREXTRACHGS.Text.Trim) + Val(txttax.Text.Trim) + Val(TXTADDTAX.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTPURSERVCHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                Else
                    TEMPOTHERAMT = Val(txttax.Text.Trim) + Val(TXTADDTAX.Text.Trim) + Val(txtotherchg.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTSUBTOTAL.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                End If


                j = j & """ItemList"":[{"
                j = j & """SlNo"": """ & "1" & """" & ","
                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
                j = j & """IsServc"":""" & "Y" & """" & ","
                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
                'j = j & """Barcde"":""REC9999"","
                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                'j = j & """FreeQty"":" & "0" & "" & ","
                'j = j & """Unit"":""" & "MTR" & """" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTPURSERVCHGS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTPURSERVCHGS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","
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
                j = j & """Expdt"":""" & DNDATE.Text & """" & ","
                j = j & """wrDt"":""" & DNDATE.Text & """" & "},"

                j = j & """AttribDtls"": [{"
                j = j & """Nm"":""123"","
                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

                j = j & " }"

                j = j & " ],"



                j = j & """ValDtls"": {"
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTPURSERVCHGS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
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
                j = j & """InvStDt"":""" & DNDATE.Text & """" & ","
                j = j & """InvEndDt"":""" & DNDATE.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & DNDATE.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & DNDATE.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & DNDATE.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"

                j = j & """TransDocNo"":"" "","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & DNDATE.Text & """" & ","
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER SET DN_IRNNO = '" & TXTIRNNO.Text.Trim & "', DN_ACKNO = '" & TXTACKNO.Text.Trim & "', DN_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM DEBITNOTEMASTER WHERE DN_NO = " & Val(TXTDNNO.Text.Trim) & " AND DN_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                Dim TEMPREG As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and register_type = 'DEBITNOTE'  and REGISTER_NAME <> 'AIRLINE DEBITNOTE' AND REGISTER_YEARID = " & YearId)
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTDNNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTDNNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsDebitNote
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTDNNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'DEBITNOTE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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

    Private Sub TXTTOTALPURAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTALPURAMT.KeyPress, TXTDISCPER.KeyPress, TXTDISCRS.KeyPress, TXTCOMMRECDPER.KeyPress, TXTCOMMRECDRS.KeyPress, TXTPURTDSPER.KeyPress, TXTPURTDSRS.KeyPress, TXTPUREXTRACHGS.KeyPress, TXTPURSERVCHGS.KeyPress, txtotherchg.KeyPress
        numdotkeypress(e, sender, Me)
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
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGSTAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGSTAMT.KeyPress, TXTSGSTAMT.KeyPress, TXTIGSTAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        PURCHASETOTAL()
    End Sub

End Class