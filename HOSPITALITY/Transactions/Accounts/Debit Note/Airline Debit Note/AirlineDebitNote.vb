
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports BL
Imports Newtonsoft.Json
Imports RestSharp
Imports TaxProEInvoice.API

Public Class AirlineDebitNote

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public edit As Boolean
    Dim temprefno As String
    Dim DNREGABBR, DNREGINITIAL As String
    Dim DNREGID As Integer

    Dim TYPE As String  'USED FOR FORMTYPE WHILE RETRIVING DATA FROM GETDATA FUNCTION AND PASSING IN TO SP
    Public FRMSTRING As String  ' USER FOR BOOKTYPE 
    Public TEMPDNNO As Integer
    Public BILLNO As String
    Public TEMPREGNAME As String
    Public AUTOCREATE As Boolean = False
    Public TEMPCNNO As String   'USED TO FETCH DATA FROM CREDIT NOTE WHILE AUTOCREATING DABITENOTE
    Dim COMMTAX As Boolean

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

        GRIDBOOKINGS.RowCount = 0

        TXTACTUALPAX.Clear()

        TXTBILLNO.Enabled = True
        TXTTICKETNO.Enabled = True
        TXTPNRNO.Enabled = True
        TXTAIRPNR.Enabled = True
        TXTCRSPNR.Enabled = True

        TXTBILLNO.Clear()

        TXTCUSNAME.Clear()
        TXTAIRLINE.Clear()
        TXTNAME.Clear()
        TXTPURNAME.Clear()
        TXTBOOKEDBY.Clear()
        txtremarks.Clear()


        DNDATE.Value = Mydate
        TICKETDATE.Value = Mydate
        TXTTICKETNO.Clear()
        TXTPNRNO.Clear()
        TXTAIRPNR.Clear()
        TXTCRSPNR.Clear()
        TXTPARTYREFNO.Clear()
        TXTREFNO.Clear()
        TXTCRSTYPE.Clear()

        DNREGABBR = ""
        DNREGINITIAL = ""


        TXTTOTALPURAMT.Text = 0.0
        TXTDISCPER.Text = 0.0
        TXTDISCRS.Text = 0.0
        TXTPURTDSPER.Text = 0.0
        TXTPURTDSRS.Text = 0.0
        TXTADDDISC.Text = 0.0
        TXTSUBTOTAL.Text = 0.0
        cmbtax.Text = ""
        txttax.Text = 0.0
        txttax.ReadOnly = True
        txttax.Enabled = False
        cmbaddsub.SelectedIndex = 0
        CMBOTHERCHGS.Text = ""
        txtotherchg.Text = 0.0
        TXTCANCEL.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0

        TXTCGSTPER.Text = 0.0
        TXTCGSTAMT.Text = 0.0
        TXTSGSTPER.Text = 0.0
        TXTSGSTAMT.Text = 0.0
        TXTIGSTPER.Text = 0.0
        TXTIGSTAMT.Text = 0.0
        TXTSTATECODE.Clear()
        TXTHSNCODE.Clear()
        TXTPURSERVCHGS.Clear()
        CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
        getmaxno_DN()

        TXTIRNNO.Clear()
        TXTACKNO.Clear()
        ACKDATE.Value = Now.Date
        PBQRCODE.Image = Nothing
        LBLEINVGENERATED.Visible = False

    End Sub

    Sub TOTAL()

        Dim ACTUALDISC As Double = 0
        Dim ACTUALADDDISC As Double = 0

        TXTSUBTOTAL.Text = 0.0
        ' txttax.Text = 0.0
        If Val(TXTDISCPER.Text.Trim) > 0 Then TXTDISCRS.Text = 0.0
        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0

        TXTTOTALBASIC.Text = 0.0
        TXTTOTALPSF.Text = 0.0
        TXTTOTALTAXES.Text = 0.0
        TXTTOTALPURAMT.Text = 0.0

        Dim rowcount As Integer = 0

        For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
            If Convert.ToBoolean(ROW.Cells(GPASSCHK.Index).Value) = True Then
                TXTTOTALBASIC.Text = Format(Val(TXTTOTALBASIC.Text.Trim) + Val(ROW.Cells(GBASIC.Index).Value), "0.00")
                TXTTOTALPSF.Text = Format(Val(TXTTOTALPSF.Text.Trim) + Val(ROW.Cells(GPSF.Index).Value), "0.00")
                TXTTOTALTAXES.Text = Format(Val(TXTTOTALTAXES.Text.Trim) + Val(ROW.Cells(GTAXES.Index).Value), "0.00")
                TXTTOTALPURAMT.Text = Format(Val(TXTTOTALPURAMT.Text.Trim) + Val(ROW.Cells(GTOTAL.Index).Value), "0.00")
                rowcount = rowcount + 1
            End If
        Next

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" BOOKING_TOTALPASS AS ACTUALPAX, BOOKING_PURDISCAMT AS DISCAMT, BOOKING_PURADDDISCAMT AS ADDDISC", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_PURBILLINITIALS = '" & TXTBILLNO.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            ACTUALDISC = Format(Val(DT.Rows(0).Item("DISCAMT")), "0.00")
            ACTUALADDDISC = Format(Val(DT.Rows(0).Item("ADDDISC")), "0.00")
            If edit = True Then TXTACTUALPAX.Text = Val(DT.Rows(0).Item("ACTUALPAX"))
        End If

        If ClientName <> "URMI" Then
            If Val(TXTACTUALPAX.Text.Trim) <> rowcount Then
                If Val(TXTDISCPER.Text.Trim) = 0 And Val(TXTDISCRS.Text.Trim) > 0 Then TXTDISCRS.Text = (ACTUALDISC / Val(TXTACTUALPAX.Text.Trim)) * rowcount
                TXTADDDISC.Text = (ACTUALADDDISC / Val(TXTACTUALPAX.Text.Trim)) * rowcount
            Else
                If ACTUALDISC > 0 Then TXTDISCRS.Text = ACTUALDISC
                If ACTUALADDDISC > 0 Then TXTADDDISC.Text = ACTUALADDDISC
            End If
        End If



        If Val(TXTDISCPER.Text) > 0 Then
            TXTDISCRS.Text = Format((Val(TXTDISCPER.Text) * (Val(TXTTOTALBASIC.Text) + Val(TXTTOTALTAXES.Text))) / 100, "0.00")
        End If

        If Val(TXTPURTDSPER.Text) > 0 Then
            TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(TXTDISCRS.Text)) / 100, "0.00")
        End If



        TXTSUBTOTAL.Text = Format(Val(Val(TXTTOTALPURAMT.Text) + Val(TXTPURSERVCHGS.Text.Trim) - Val(TXTDISCRS.Text) - Val(TXTADDDISC.Text)), "0.00")




        If DNDATE.Value.Date < "01/07/2017" Then

            'DT = OBJCMN.search("TAX_NAME,tax_tax", "", "TAXMaster", " and TAX_NAME = '" & cmbtax.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    If COMMTAX = False Then
            '        txttax.Text = Format((Val(DT.Rows(0).Item(1)) * (Val(TXTTOTALBASIC.Text))) / 100, "0.00")
            '    Else
            '        txttax.Text = Format((Val(DT.Rows(0).Item(1)) * (Val(TXTDISCRS.Text))) / 100, "0.00")
            '    End If
            'End If
        Else
            If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTPURSERVCHGS.Text)) / 100, "0.00")

            Else

                TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTTOTALBASIC.Text)) / 100, "0.00")

            End If
        End If


        If cmbaddsub.Text = "Add" Then
            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(txtotherchg.Text) - Val(TXTCANCEL.Text.Trim), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) + Val(txtotherchg.Text) - Val(TXTCANCEL.Text.Trim)), "0.00")
        Else
            txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(txttax.Text)) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtotherchg.Text) - Val(TXTCANCEL.Text.Trim), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text)) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text) - Val(txtotherchg.Text) - Val(TXTCANCEL.Text.Trim)), "0.00")
        End If

        txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")


    End Sub

    Sub getmaxno_DN()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(AIRDN_NO),0) + 1 ", "AIRDEBITNOTEMASTER", " AND AIRDN_cmpid=" & CmpId & " AND AIRDN_LOCATIONID = " & Locationid & " AND AIRDN_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTDNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub DEBITNOTEdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DNDATE.Validating
        'If Not datecheck(DNDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'DEBITNOTE'")
            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'DEBITNOTE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = "AIRLINE DEBITNOTE"
            End If
            getmaxno_DN()
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

            If TXTBILLNO.Text.Trim <> "" And TYPE = Nothing Then TYPE = "AIRLINEBOOKING"

            Dim alParaval As New ArrayList

            alParaval.Add("AIRLINE DEBITNOTE")
            alParaval.Add(TYPE)
            alParaval.Add(DNDATE.Value.Date)


            alParaval.Add(TXTBILLNO.Text.Trim)
            alParaval.Add(TXTCUSNAME.Text.Trim)
            alParaval.Add(TXTAIRLINE.Text.Trim)
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTPURNAME.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(TXTBOOKEDBY.Text.Trim)


            'IF BILLNO IS NOT THERE THEN ARRIVAL DATE SAME AS CNDATE
            If TXTBILLNO.Text.Trim = "" Then
                alParaval.Add(DNDATE.Value.Date)
            Else
                alParaval.Add(TICKETDATE.Value.Date)
            End If
            alParaval.Add(TXTTICKETNO.Text.Trim)
            alParaval.Add(TXTPNRNO.Text.Trim)
            alParaval.Add(TXTAIRPNR.Text.Trim)
            alParaval.Add(TXTCRSPNR.Text.Trim)
            alParaval.Add(TXTPARTYREFNO.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(TXTCRSTYPE.Text.Trim)



            alParaval.Add(Val(TXTTOTALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRS.Text.Trim))
            alParaval.Add(Val(TXTPURTDSPER.Text.Trim))
            alParaval.Add(Val(TXTPURTDSRS.Text.Trim))
            alParaval.Add(Val(TXTADDDISC.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(cmbtax.Text.Trim)
            alParaval.Add(Val(txttax.Text.Trim))
            alParaval.Add(CMBOTHERCHGS.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                alParaval.Add(Val(txtotherchg.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                alParaval.Add(Val((txtotherchg.Text.Trim) * (-1)))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(TXTPURSERVCHGS.Text.Trim)
            alParaval.Add(CHKTAXSERVCHGS.CheckState)

            alParaval.Add(Val(TXTCANCEL.Text.Trim))

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)



            Dim gridsrno As String = ""
            Dim BOOKSRNO As String = ""
            Dim PASSNAME As String = ""
            Dim SECTOR As String = ""
            Dim FLTNO As String = ""
            Dim BTYPE As String = ""
            Dim TICKETNO As String = ""
            Dim CLASSNAME As String = ""
            Dim BASIC As String = ""
            Dim PSF As String = ""
            Dim TAXES As String = ""
            Dim AMT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If row.Cells(1).Value <> Nothing And row.Cells(0).Value = True Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        BOOKSRNO = row.Cells(GBOOKSRNO.Index).Value.ToString
                        PASSNAME = row.Cells(GNAME.Index).Value.ToString
                        SECTOR = row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = row.Cells(GFLTNO.Index).Value.ToString
                        BTYPE = row.Cells(GTYPE.Index).Value.ToString
                        TICKETNO = row.Cells(GTICKETNO.Index).Value.ToString
                        CLASSNAME = row.Cells(GCLASS.Index).Value.ToString
                        BASIC = row.Cells(GBASIC.Index).Value.ToString
                        PSF = row.Cells(GPSF.Index).Value.ToString
                        TAXES = row.Cells(GTAXES.Index).Value.ToString
                        AMT = row.Cells(GTOTAL.Index).Value
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        BOOKSRNO = BOOKSRNO & "|" & row.Cells(GBOOKSRNO.Index).Value.ToString
                        PASSNAME = PASSNAME & "|" & row.Cells(GNAME.Index).Value.ToString
                        SECTOR = SECTOR & "|" & row.Cells(GSECTOR.Index).Value.ToString
                        FLTNO = FLTNO & "|" & row.Cells(GFLTNO.Index).Value.ToString
                        BTYPE = BTYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        TICKETNO = TICKETNO & "|" & row.Cells(GTICKETNO.Index).Value.ToString
                        CLASSNAME = CLASSNAME & "|" & row.Cells(GCLASS.Index).Value.ToString
                        BASIC = BASIC & "|" & row.Cells(GBASIC.Index).Value.ToString
                        PSF = PSF & "|" & row.Cells(GPSF.Index).Value.ToString
                        TAXES = TAXES & "|" & row.Cells(GTAXES.Index).Value.ToString
                        AMT = AMT & "|" & row.Cells(GTOTAL.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(BOOKSRNO)
            alParaval.Add(PASSNAME)
            alParaval.Add(SECTOR)
            alParaval.Add(FLTNO)
            alParaval.Add(BTYPE)
            alParaval.Add(TICKETNO)
            alParaval.Add(CLASSNAME)
            alParaval.Add(BASIC)
            alParaval.Add(PSF)
            alParaval.Add(TAXES)
            alParaval.Add(AMT)

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

            Dim OBJAIRDN As New ClsAirDebitNote()
            OBJAIRDN.alParaval = alParaval
            Dim DTTABLE As DataTable

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                DTTABLE = OBJAIRDN.save()
                MessageBox.Show("Details Added")
                PRINTREPORT(DTTABLE.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDNNO)
                DTTABLE = OBJAIRDN.update()
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

        If Not datecheck(DNDATE.Value) Then
            EP.SetError(DNDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Select Register Name")
            bln = False
        End If

        ''CHEKCING IN AIRLINEBOOKING WHETHER CN IS MADE OR NOT
        'If TXTBILLNO.Text.Trim <> "" And edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As DataTable = OBJCMN.search(" BOOKING_PURRETURN AS PURRETURN", "", " AIRLINEBOOKINGMASTER", " AND BOOKING_PURBILLINITIALS = '" & TXTBILLNO.Text.Trim & "'  AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
        '    If DT.Rows.Count > 0 Then
        '        If Val(DT.Rows(0).Item("PURRETURN")) > 0 Then
        '            EP.SetError(TXTBILLNO, "Debit Note Already Raised")
        '            bln = False
        '        End If
        '    End If
        'End If

        If TXTBILLNO.Text.Trim = "" Then
            EP.SetError(TXTBILLNO, "Select Booking Voucher")
            bln = False
        End If


        If TXTNAME.Text.Trim = "" Then
            EP.SetError(TXTNAME, "Select Booking Voucher")
            bln = False
        End If

        If txtgrandtotal.Text.Trim = "" Then
            EP.SetError(txtgrandtotal, "Enter Amount")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = False Then
                If DNDATE.Value.Date < Now.Date Then
                    EP.SetError(DNDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If

        If Not datecheck(DNDATE.Value) Then
            EP.SetError(DNDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        Dim proceed As Boolean = False
        For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
            If row.Cells(1).Value <> Nothing And Convert.ToBoolean(row.Cells(GPASSCHK.Index).Value) = True Then
                proceed = True

                'CHEKCING IN AIRLINEBOOKING WHETHER CN IS MADE OR NOT FOR CHECKED TICKETBNO
                If TXTBILLNO.Text.Trim <> "" And edit = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CANCELLED AS CANCELLED", "", " AIRLINEBOOKINGMASTER INNER JOIN AIRLINEBOOKINGMASTER_PURDESC ON AIRLINEBOOKINGMASTER.BOOKING_NO = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_NO AND AIRLINEBOOKINGMASTER.BOOKING_PURCHASEREGISTERID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PURREGID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID =AIRLINEBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_YEARID ", " AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = '" & TXTBILLNO.Text.Trim & "'  AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO = " & Val(row.Cells(GBOOKSRNO.Index).Value) & " AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If Convert.ToBoolean(DT.Rows(0).Item("CANCELLED")) = True Then
                            EP.SetError(TXTBILLNO, "Debit Note Already Raised for Ticket No " & row.Cells(GTICKETNO.Index).Value)
                            bln = False
                        End If
                    End If
                End If
            End If
        Next

        If proceed = False Then
            EP.SetError(txtgrandtotal, "Please Select At Least One Passenger to Continue.")
            bln = False
        End If

        Return bln

    End Function

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
            Dim OBJAIRDN As New AirlineDebitNoteDetails
            OBJAIRDN.MdiParent = MDIMain
            OBJAIRDN.Show()
            OBJAIRDN.BringToFront()
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
            If CMBOTHERCHGS.Text.Trim <> "" Then namevalidate(CMBOTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "INDIRECT INCOME")
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
            TOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Sub FILLCMB()
        Try
            filltax(cmbtax, edit)
            fillname(CMBOTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
            fillregister(cmbregister, " and register_type = 'DEBITNOTE'")
            cmbregister.Text = "AIRLINE DEBITNOTE"
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineDebitNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New AirlineDebitNoteDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            ElseIf e.KeyCode = Keys.P And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AirlineDebitNote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEBIT NOTE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            FILLCMB()

            If AUTOCREATE = True And TEMPCNNO <> "" And edit = False Then
                Dim WHERE As String = ""
                Dim OBJCMN As New ClsCommon
                Dim DTC As DataTable = OBJCMN.search(" AIRCREDITNOTEMASTER.AIRCN_BILLNO AS BILLNO, AIRCREDITNOTEMASTER_DESC.AIRCN_BOOKSRNO AS BOOKSRNO, (AIRCREDITNOTEMASTER.AIRCN_CANCEL - AIRCREDITNOTEMASTER.AIRCN_CANCELINC) AS CANCELCHGS ", "", " AIRCREDITNOTEMASTER INNER JOIN AIRCREDITNOTEMASTER_DESC ON AIRCREDITNOTEMASTER.AIRCN_no = AIRCREDITNOTEMASTER_DESC.AIRCN_no AND AIRCREDITNOTEMASTER.AIRCN_registerid = AIRCREDITNOTEMASTER_DESC.AIRCN_registerid AND AIRCREDITNOTEMASTER.AIRCN_cmpid = AIRCREDITNOTEMASTER_DESC.AIRCN_CMPID AND AIRCREDITNOTEMASTER.AIRCN_locationid = AIRCREDITNOTEMASTER_DESC.AIRCN_LOCATIONID AND AIRCREDITNOTEMASTER.AIRCN_yearid = AIRCREDITNOTEMASTER_DESC.AIRCN_YEARID", " AND AIRCREDITNOTEMASTER.AIRCN_INITIALS = '" & TEMPCNNO & "' AND AIRCREDITNOTEMASTER.AIRCN_CMPID = " & CmpId & " AND AIRCREDITNOTEMASTER.AIRCN_LOCATIONID = " & Locationid & " AND AIRCREDITNOTEMASTER.AIRCN_YEARID = " & YearId)
                If DTC.Rows.Count > 0 Then

                    Dim str As String() = DTC.Rows(0).Item("BILLNO").ToString.Split("-")
                    If str(0) = "IAS" Then
                        WHERE = " AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = 'IAP-" & str(1) & "' "
                    Else
                        WHERE = " AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = 'AP-" & str(1) & "' "
                    End If
                    'WHERE = " AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = 'AP-" & DTC.Rows(0).Item("BILLNO").ToString.Substring(3, Len(DTC.Rows(0).Item("BILLNO")) - 3) & "' "

                    If DTC.Rows.Count > 0 Then
                        Dim subwhere As String = ""
                        WHERE = WHERE & " AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_GRIDSRNO in ("
                        For Each DTR As DataRow In DTC.Rows
                            subwhere = subwhere & DTR("BOOKSRNO") & ","
                        Next
                        subwhere = subwhere.Substring(0, subwhere.Trim.Length - 1)
                        WHERE = WHERE & subwhere & ")"
                    End If
                    GETDATA(WHERE)
                    TXTCANCEL.Text = Format(Val(DTC.Rows(0).Item("CANCELCHGS")), "0.00")
                    TOTAL()
                    TXTBILLNO.Enabled = False
                End If
            ElseIf BILLNO <> "" And edit = False Then
                TXTBILLNO.Text = BILLNO
                TXTBILLNO.Enabled = False
                GETDATA(" AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = '" & TXTBILLNO.Text.Trim & "' ")
            End If




            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim objclsCN As New ClsAirDebitNote()
                dt = objclsCN.SELECTDEBITNOTE_EDIT(TEMPDNNO, TEMPREGNAME, CmpId, Locationid, YearId)

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTDNNO.Text = TEMPDNNO
                        cmbregister.Text = TEMPREGNAME
                        TYPE = dt.Rows(0).Item("TYPE")
                        TXTSTATECODE.Text = dt.Rows(0).Item("STATECODE")
                        CMBHSNITEMDESC.Text = dt.Rows(0).Item("ITEMDESC")
                        DNDATE.Value = Convert.ToDateTime(dr("DNDATE")).Date

                        TXTBILLNO.Text = dt.Rows(0).Item("BILLNO")
                        TXTCUSNAME.Text = dt.Rows(0).Item("CUSTNAME")
                        TXTAIRLINE.Text = dt.Rows(0).Item("AIRLINE")
                        TXTNAME.Text = dt.Rows(0).Item("NAME")
                        TXTPURNAME.Text = dt.Rows(0).Item("PURNAME")
                        TXTHSNCODE.Text = dt.Rows(0).Item("HSNCODE")
                        TXTBOOKEDBY.Text = dt.Rows(0).Item("BOOKEDBY")


                        TXTBILLNO.Enabled = False
                        TXTTICKETNO.Enabled = False
                        TXTPNRNO.Enabled = False
                        TXTAIRPNR.Enabled = False
                        TXTCRSPNR.Enabled = False

                        TICKETDATE.Value = Convert.ToDateTime(dr("TICKETDATE")).Date
                        TXTTICKETNO.Text = dt.Rows(0).Item("TICKETNO")
                        TXTPNRNO.Text = dt.Rows(0).Item("PNRNO")
                        TXTAIRPNR.Text = dt.Rows(0).Item("AIRPNR")
                        TXTCRSPNR.Text = dt.Rows(0).Item("CRSPNR")
                        TXTPARTYREFNO.Text = dt.Rows(0).Item("PARTYREFNO")
                        TXTREFNO.Text = dt.Rows(0).Item("REFNO")
                        TXTCRSTYPE.Text = dt.Rows(0).Item("CRSTYPE")


                        TXTTOTALPURAMT.Text = Format(Val(dt.Rows(0).Item("SALEAMT")), "0.00")
                        TXTDISCPER.Text = Format(Val(dt.Rows(0).Item("DISCPER")), "0.00")
                        TXTDISCRS.Text = Format(Val(dt.Rows(0).Item("DISCRS")), "0.00")
                        TXTPURTDSPER.Text = Format(Val(dt.Rows(0).Item("TDSPER")), "0.00")
                        TXTPURTDSRS.Text = Format(Val(dt.Rows(0).Item("TDSRS")), "0.00")
                        TXTADDDISC.Text = Format(Val(dt.Rows(0).Item("ADDDISC")), "0.00")
                        cmbtax.Text = dt.Rows(0).Item("TAXNAME")
                        txttax.Text = Format(Val(dt.Rows(0).Item("TAXAMT")), "0.00")
                        CMBOTHERCHGS.Text = dt.Rows(0).Item("OTHERCHGSNAME")
                        txtotherchg.Text = Format(Val(dt.Rows(0).Item("OTHERCHGSAMT")), "0.00")

                        If Val(dr("OTHERCHGSAMT")) > 0 Then
                            txtotherchg.Text = Val(dr("OTHERCHGSAMT"))
                            cmbaddsub.Text = "Add"
                        Else
                            txtotherchg.Text = Val(dr("OTHERCHGSAMT")) * (-1)
                            cmbaddsub.Text = "Sub."
                        End If
                        TXTPURSERVCHGS.Text = Val(dt.Rows(0).Item("PURSERVCHGS"))
                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))
                        TXTCANCEL.Text = Format(Val(dt.Rows(0).Item("CANCEL")), "0.00")


                        TXTCGSTPER.Text = Val(dt.Rows(0).Item("CGSTPER"))
                        TXTCGSTAMT.Text = Val(dt.Rows(0).Item("CGSTAMT"))
                        TXTSGSTPER.Text = Val(dt.Rows(0).Item("SGSTPER"))
                        TXTSGSTAMT.Text = Val(dt.Rows(0).Item("SGSTAMT"))
                        TXTIGSTPER.Text = Val(dt.Rows(0).Item("IGSTPER"))
                        TXTIGSTAMT.Text = Val(dt.Rows(0).Item("IGSTAMT"))


                        txtroundoff.Text = Format(Val(dt.Rows(0).Item("ROUNDOFF")), "0.00")
                        txtgrandtotal.Text = Format(Val(dt.Rows(0).Item("GTOTAL")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTACTUALPAX.Text = Val(dt.Rows(0).Item("ACTUALPAX"))

                        GRIDBOOKINGS.Rows.Add(1, dr("GRIDSRNO"), dr("BOOKSRNO"), dr("PASSNAME"), dr("SECTOR"), dr("FLTNO"), dr("BTYPE"), dr("BTICKETNO"), dr("CLASSNAME"), Format(Val(dr("BASIC")), "0.00"), Format(Val(dr("PSF")), "0.00"), Format(Val(dr("TAXES")), "0.00"), Format(Val(dr("AMT")), "0.00"))

                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If

                        If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then LBLEINVGENERATED.Visible = True
                        TOTAL()

                    Next
                    cmbregister.Enabled = False
                    TXTCUSNAME.Focus()

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_DN()
            Dim MAXNO As Integer = TXTDNNO.Text.Trim
            clear()
            If Val(TXTDNNO.Text) - 1 >= TEMPDNNO Then
                edit = True
                AirlineDebitNote_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPDNNO < MAXNO Then
                TXTDNNO.Text = TEMPDNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBOOKINGS.RowCount = 0
LINE1:
            TEMPDNNO = Val(TXTDNNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPDNNO > 0 Then
                edit = True
                AirlineDebitNote_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDBOOKINGS.RowCount = 0 And TEMPDNNO > 1 Then
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

                    Dim OBJDN As New ClsAirDebitNote
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
                AirlineDebitNote_Load(sender, e)
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
                GRIDBOOKINGS.RowCount = 0
                GETDATA(" AND AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS = '" & TXTBILLNO.Text.Trim & "' ")
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTPNRNO.Enabled = False
                TXTAIRPNR.Enabled = False
                TXTCRSPNR.Enabled = False
                TXTBILLNO.Enabled = False
                ' TXTTICKETNO.Enabled = False
            Else
                TXTPNRNO.Enabled = True
                TXTAIRPNR.Enabled = True
                TXTCRSPNR.Enabled = True
                TXTBILLNO.Enabled = True
                TXTTICKETNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDATA(Optional ByVal WHERECLAUSE As String = "")
        Try
            If edit = True Then Exit Sub

            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILL, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PRINTNAME, '') AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS TICKETDATE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PNRNO, '') AS PNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_AIRLINEPNR, '') AS AIRPNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_CRSPNR, '') AS CRSPNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PARTYREFNO, '') AS PARTYREFNO, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_REFNO, '') AS REFNO, ISNULL(CRSMASTER.CRS_NAME, '') AS CRSTYPE, AIRLINEBOOKINGMASTER_DESC.BOOKING_GRIDSRNO AS GRIDSRNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_PASSNAME, '') AS PASSNAME, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_SECTOR, '') AS SECTOR, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_FLTNO, '') AS FLTNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TYPE, '') AS BTYPE, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_CLASS, '') AS CLASS, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_BASIC, 0) AS BASIC, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PSF, 0) AS PSF, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TAXES, 0) AS TAXES, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_AMT, 0) AS AMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURDISCPERC, 0) AS DISCPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURDISCAMT, 0) AS DISCAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTDSPER, 0) AS TDSPER,ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTDSRS, 0) AS TDSRS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURADDDISCAMT, 0) AS ADDDISCAMT, ISNULL(OTHERCHGSLEDGER.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS, 0) AS OTHERCHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(TAXMASTER.tax_tax, 0) AS TAX, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURAMTPAID + AIRLINEBOOKINGMASTER.BOOKING_PUREXTRAAMT, 0) AS PAIDAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALPASS, 0) AS PAX, BOOKING_PURCOMMTAX AS  COMMTAX ", "", " AIRLINEBOOKINGMASTER INNER JOIN AIRLINEBOOKINGMASTER_DESC ON AIRLINEBOOKINGMASTER.BOOKING_NO = AIRLINEBOOKINGMASTER_DESC.BOOKING_NO AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_PURCHASEREGISTERID = AIRLINEBOOKINGMASTER_DESC.BOOKING_PURREGID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID INNER JOIN AIRLINEBOOKINGMASTER_PURDESC ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_PURREGID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PURREGID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_GRIDSRNO = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSGRIDSRNO LEFT OUTER JOIN TAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURTAXID = TAXMASTER.tax_id AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = TAXMASTER.tax_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = TAXMASTER.tax_cmpid LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER ON AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGSLEDGER.Acc_id AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = OTHERCHGSLEDGER.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGSLEDGER.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = OTHERCHGSLEDGER.Acc_cmpid LEFT OUTER JOIN BOOKEDBYMASTER ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS PURLEDGER ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = PURLEDGER.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = PURLEDGER.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = PURLEDGER.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID = PURLEDGER.Acc_id LEFT OUTER JOIN CRSMASTER ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = CRSMASTER.CRS_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = CRSMASTER.CRS_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = CRSMASTER.CRS_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID ", WHERECLAUSE & " AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CANCELLED = 'FALSE' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
            Dim DT As DataTable = OBJCMN.search(" 'AIRLINEBOOKING' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILL, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PRINTNAME, '') AS CUSTOMER, FLIGHTMASTER.FLIGHT_NAME AS AIRLINE, LEDGERS.Acc_cmpname AS NAME, ISNULL(PURLEDGER.Acc_cmpname, '') AS PURNAME, BOOKEDBYMASTER.BOOKEDBY_NAME AS BOOKEDBY, AIRLINEBOOKINGMASTER.BOOKING_TICKETDATE AS TICKETDATE, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PNRNO, '') AS PNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_AIRLINEPNR, '') AS AIRPNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_CRSPNR, '') AS CRSPNR, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PARTYREFNO, '') AS PARTYREFNO, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_REFNO, '') AS REFNO, ISNULL(CRSMASTER.CRS_NAME, '') AS CRSTYPE, AIRLINEBOOKINGMASTER_DESC.BOOKING_GRIDSRNO AS GRIDSRNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_PASSNAME, '') AS PASSNAME, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_SECTOR, '') AS SECTOR, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_FLTNO, '') AS FLTNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TYPE, '') AS BTYPE, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO, '') AS TICKETNO, ISNULL(AIRLINEBOOKINGMASTER_DESC.BOOKING_CLASS, '') AS CLASS, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_BASIC, 0) AS BASIC, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PSF, 0) AS PSF, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_TAXES, 0) AS TAXES, ISNULL(AIRLINEBOOKINGMASTER_PURDESC.BOOKING_AMT, 0) AS AMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURDISCPERC, 0) AS DISCPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURDISCAMT, 0) AS DISCAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTDSPER, 0) AS TDSPER,ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTDSRS, 0) AS TDSRS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURADDDISCAMT, 0) AS ADDDISCAMT, ISNULL(OTHERCHGSLEDGER.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS, 0) AS OTHERCHGS, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(TAXMASTER.tax_tax, 0) AS TAX, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURAMTPAID + AIRLINEBOOKINGMASTER.BOOKING_PUREXTRAAMT, 0) AS PAIDAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TOTALPASS, 0) AS PAX, BOOKING_PURCOMMTAX AS  COMMTAX , ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGS, 0) AS TAXSERVCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURTAXSERVCHGSAMT, 0) AS PURSERVCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTPER, 0) AS CGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURCGSTAMT, 0) AS CGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTPER, 0) AS SGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURSGSTAMT, 0) AS SGSTAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTPER, 0) AS IGSTPER, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_PURIGSTAMT, 0) AS IGSTAMT, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS ITEMDESC,ISNULL(CAST(STATEMASTER.state_remark AS varchar), '') AS STATECODE ", "", " STATEMASTER RIGHT OUTER JOIN LEDGERS AS PURLEDGER ON STATEMASTER.state_id = PURLEDGER.Acc_stateid RIGHT OUTER JOIN AIRLINEBOOKINGMASTER INNER JOIN AIRLINEBOOKINGMASTER_DESC ON AIRLINEBOOKINGMASTER.BOOKING_NO = AIRLINEBOOKINGMASTER_DESC.BOOKING_NO AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_PURCHASEREGISTERID = AIRLINEBOOKINGMASTER_DESC.BOOKING_PURREGID INNER JOIN FLIGHTMASTER ON AIRLINEBOOKINGMASTER.BOOKING_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = FLIGHTMASTER.FLIGHT_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = FLIGHTMASTER.FLIGHT_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = FLIGHTMASTER.FLIGHT_YEARID INNER JOIN AIRLINEBOOKINGMASTER_PURDESC ON AIRLINEBOOKINGMASTER_DESC.BOOKING_NO = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_NO AND AIRLINEBOOKINGMASTER_DESC.BOOKING_PURREGID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PURREGID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_CMPID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CMPID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_LOCATIONID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_LOCATIONID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_YEARID = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_YEARID AND AIRLINEBOOKINGMASTER_DESC.BOOKING_GRIDSRNO = AIRLINEBOOKINGMASTER_PURDESC.BOOKING_PASSGRIDSRNO LEFT OUTER JOIN HSNMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURHSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN TAXMASTER ON AIRLINEBOOKINGMASTER.BOOKING_PURTAXID = TAXMASTER.tax_id AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = TAXMASTER.tax_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = TAXMASTER.tax_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = TAXMASTER.tax_cmpid LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER ON AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGSID = OTHERCHGSLEDGER.Acc_id AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = OTHERCHGSLEDGER.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = OTHERCHGSLEDGER.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = OTHERCHGSLEDGER.Acc_cmpid LEFT OUTER JOIN BOOKEDBYMASTER ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = BOOKEDBYMASTER.BOOKEDBY_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = BOOKEDBYMASTER.BOOKEDBY_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id ON PURLEDGER.Acc_yearid = AIRLINEBOOKINGMASTER.BOOKING_YEARID AND PURLEDGER.Acc_locationid = AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AND PURLEDGER.Acc_cmpid = AIRLINEBOOKINGMASTER.BOOKING_CMPID AND PURLEDGER.Acc_id = AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID LEFT OUTER JOIN CRSMASTER ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = CRSMASTER.CRS_YEARID AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = CRSMASTER.CRS_LOCATIONID AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = CRSMASTER.CRS_CMPID AND AIRLINEBOOKINGMASTER.BOOKING_CRSTYPEID = CRSMASTER.CRS_ID ", WHERECLAUSE & " AND AIRLINEBOOKINGMASTER_PURDESC.BOOKING_CANCELLED = 'FALSE' AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = " & CmpId & " AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = " & Locationid & " AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows

                    If DTROW("PAIDAMT") > 0 Then
                        MsgBox("Payment Made, Delete Payment First", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    BILLNO = DTROW("BILL")
                    TXTBILLNO.Text = DTROW("BILL")
                    TYPE = DTROW("TYPE")
                    TXTSTATECODE.Text = DTROW("STATECODE")
                    CMBHSNITEMDESC.Text = DTROW("ITEMDESC")
                    TICKETDATE.Value = Format(Convert.ToDateTime(DTROW("TICKETDATE")).Date, "dd/MM/yyyy")

                    TXTACTUALPAX.Text = DTROW("PAX")

                    TXTCUSNAME.Text = DTROW("CUSTOMER")
                    TXTAIRLINE.Text = DTROW("AIRLINE")
                    TXTNAME.Text = DTROW("NAME")
                    TXTPURNAME.Text = DTROW("PURNAME")
                    TXTHSNCODE.Text = DTROW("HSNCODE")
                    TXTBOOKEDBY.Text = DTROW("BOOKEDBY")

                    TXTPNRNO.Text = DTROW("PNR")
                    TXTAIRPNR.Text = DTROW("AIRPNR")
                    TXTCRSPNR.Text = DTROW("CRSPNR")
                    TXTPARTYREFNO.Text = DTROW("PARTYREFNO")
                    TXTREFNO.Text = DTROW("REFNO")
                    TXTCRSTYPE.Text = DTROW("CRSTYPE")

                    GRIDBOOKINGS.Rows.Add(True, 0, DTROW("GRIDSRNO"), DTROW("PASSNAME"), DTROW("SECTOR"), DTROW("FLTNO"), DTROW("BTYPE"), DTROW("TICKETNO"), DTROW("CLASS"), Format(Val(DTROW("BASIC")), "0.00"), Format(Val(DTROW("PSF")), "0.00"), Format(Val(DTROW("TAXES")), "0.00"), Format(Val(DTROW("AMT")), "0.00"))

                    TXTDISCPER.Text = DTROW("DISCPER")
                    TXTDISCRS.Text = DTROW("DISCAMT")
                    TXTPURTDSPER.Text = DTROW("TDSPER")
                    TXTPURTDSRS.Text = DTROW("TDSRS")
                    TXTADDDISC.Text = DTROW("ADDDISCAMT")

                    cmbtax.Text = DTROW("TAXNAME")

                    CMBOTHERCHGS.Text = DTROW("OTHERCHGSNAME")
                    txtotherchg.Text = DTROW("OTHERCHGS")

                    If (Val(DTROW("OTHERCHGS")) > 0) Then
                        cmbaddsub.Text = "Add"
                    Else
                        cmbaddsub.Text = "Sub."
                        txtotherchg.Text = Val(DTROW("OTHERCHGS")) * (-1)
                    End If

                    TXTPURSERVCHGS.Text = Val(DTROW("PURSERVCHGS"))
                    CHKTAXSERVCHGS.Checked = Convert.ToBoolean(DTROW("TAXSERVCHGS"))
                    '  CHKTAXSERVCHGS.Text = DTROW("TAXSERVCHGS")

                    TXTCGSTPER.Text = DTROW("CGSTPER")
                    TXTCGSTAMT.Text = DTROW("CGSTAMT")
                    TXTSGSTPER.Text = DTROW("SGSTPER")
                    TXTSGSTAMT.Text = DTROW("SGSTAMT")
                    TXTIGSTPER.Text = DTROW("IGSTPER")
                    TXTIGSTAMT.Text = DTROW("IGSTAMT")

                    txtremarks.Text = DTROW("BILL")

                    If Convert.ToBoolean(DTROW("COMMTAX")) = True Then
                        COMMTAX = True
                    Else
                        COMMTAX = False
                    End If


                Next

                If Val(TXTACTUALPAX.Text.Trim) <> GRIDBOOKINGS.RowCount Then
                    If Val(TXTDISCPER.Text.Trim) = 0 And Val(TXTDISCRS.Text.Trim) > 0 Then TXTDISCRS.Text = (Val(TXTDISCRS.Text.Trim) / Val(TXTACTUALPAX.Text.Trim)) * GRIDBOOKINGS.RowCount
                    TXTADDDISC.Text = (Val(TXTADDDISC.Text.Trim) / Val(TXTACTUALPAX.Text.Trim)) * GRIDBOOKINGS.RowCount
                End If

                TOTAL()
                getsrno(GRIDBOOKINGS)
            Else
                MsgBox("Invalid Details", MsgBoxStyle.Critical)
                Exit Sub
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(1).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTTOTALSALEAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTALPURAMT.Validated, TXTDISCPER.Validated, TXTDISCRS.Validated, TXTADDDISC.Validated
        TOTAL()
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
                    End If
                End If
            Else
                txttax.Clear()
            End If
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtotherchg.Validated, TXTPURSERVCHGS.Validated
        TOTAL()
    End Sub

    Private Sub PBDISCDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBDISCDEL.Click
        Try
            TXTDISCPER.Text = 0.0
            TXTDISCRS.Text = 0.0
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
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
                OBJCN.FRMSTRING = "AIRDEBIT"
                OBJCN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAIRPNR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAIRPNR.Validating
        Try
            If TXTAIRPNR.Text.Trim <> "" And edit = False Then
                GRIDBOOKINGS.RowCount = 0
                GETDATA(" AND AIRLINEBOOKINGMASTER.BOOKING_AIRLINEPNR = '" & TXTAIRPNR.Text.Trim & "' ")
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTPNRNO.Enabled = False
                TXTAIRPNR.Enabled = False
                TXTCRSPNR.Enabled = False
                TXTBILLNO.Enabled = False
                'TXTTICKETNO.Enabled = False
            Else
                TXTPNRNO.Enabled = True
                TXTAIRPNR.Enabled = True
                TXTCRSPNR.Enabled = True
                TXTBILLNO.Enabled = True
                TXTTICKETNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRSPNR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCRSPNR.Validating
        Try
            If TXTCRSPNR.Text.Trim <> "" And edit = False Then
                GRIDBOOKINGS.RowCount = 0
                GETDATA(" AND AIRLINEBOOKINGMASTER.BOOKING_CRSPNR = '" & TXTCRSPNR.Text.Trim & "' ")
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTPNRNO.Enabled = False
                TXTAIRPNR.Enabled = False
                TXTCRSPNR.Enabled = False
                TXTBILLNO.Enabled = False
                'TXTTICKETNO.Enabled = False
            Else
                TXTPNRNO.Enabled = True
                TXTAIRPNR.Enabled = True
                TXTCRSPNR.Enabled = True
                TXTBILLNO.Enabled = True
                TXTTICKETNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPNRNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPNRNO.Validating
        Try
            If TXTPNRNO.Text.Trim <> "" And edit = False Then
                GRIDBOOKINGS.RowCount = 0
                GETDATA(" AND AIRLINEBOOKINGMASTER.BOOKING_PNRNO = '" & TXTPNRNO.Text.Trim & "' ")
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTPNRNO.Enabled = False
                TXTAIRPNR.Enabled = False
                TXTCRSPNR.Enabled = False
                TXTBILLNO.Enabled = False
                'TXTTICKETNO.Enabled = False
            Else
                TXTPNRNO.Enabled = True
                TXTAIRPNR.Enabled = True
                TXTCRSPNR.Enabled = True
                TXTBILLNO.Enabled = True
                TXTTICKETNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKTICKET() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDBOOKINGS.Rows
                If ROW.Cells(GTICKETNO.Index).Value = TXTTICKETNO.Text.Trim Then
                    BLN = False
                    Exit For
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTTICKETNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTICKETNO.Validating
        Try
            If TXTTICKETNO.Text.Trim <> "" And edit = False Then
                If Not CHECKTICKET Then
                    Exit Sub
                End If
                GETDATA(" AND AIRLINEBOOKINGMASTER_DESC.BOOKING_TICKETNO = '" & TXTTICKETNO.Text.Trim & "' ")
                TXTDISCPER.Focus()
                If Val(txtgrandtotal.Text.Trim) = 0 Then
                    MsgBox("Invalid Voucher No")
                    e.Cancel = True
                    Exit Sub
                End If
                TXTPNRNO.Enabled = False
                TXTAIRPNR.Enabled = False
                TXTCRSPNR.Enabled = False
                TXTBILLNO.Enabled = False
                'TXTTICKETNO.Enabled = False
                'Else
                '    TXTPNRNO.Enabled = True
                '    TXTAIRPNR.Enabled = True
                '    TXTCRSPNR.Enabled = True
                '    TXTBILLNO.Enabled = True
                '    TXTTICKETNO.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCANCEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANCEL.KeyPress
        numdotkeypress(e, TXTCANCEL, Me)
    End Sub

    Private Sub TXTCANCEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCANCEL.Validated
        If Val(TXTCANCEL.Text.Trim) > 0 Then TOTAL()
    End Sub

    'Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
    '    Try
    '        If edit = False Then Exit Sub
    '        GENERATEINV()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '    Async Sub GENERATEINV()
    '        Try
    '            If ALLOWEINVOICE = False Then Exit Sub
    '            If CMBNAME.Text.Trim = "" Then Exit Sub

    '            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

    '            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '            If TXTIRNNO.Text.Trim <> "" Then
    '                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
    '            'IF DATA IS NOT PRESENT THEN VALIDATE
    '            'DATA TO BE CHECKED 
    '            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
    '            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
    '            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
    '            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
    '                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            Dim TEMPCMPADD1 As String = ""
    '            Dim TEMPCMPADD2 As String = ""
    '            Dim TEMPCMPDISPATCHADD1 As String = ""
    '            Dim PARTYGSTIN As String = ""
    '            Dim PARTYPINCODE As String = ""
    '            Dim PARTYSTATECODE As String = ""
    '            Dim PARTYSTATENAME As String = ""
    '            Dim SHIPTOGSTIN As String = ""
    '            Dim SHIPTOSTATECODE As String = ""
    '            Dim SHIPTOSTATENAME As String = ""
    '            Dim SHIPTOPINCODE As String = ""
    '            Dim PARTYKMS As Double = 0
    '            Dim PARTYADD1 As String = ""
    '            Dim PARTYADD2 As String = ""
    '            Dim SHIPTOADD1 As String = ""
    '            Dim SHIPTOADD2 As String = ""
    '            Dim TRANSGSTIN As String = ""
    '            'Dim KOTHARIPLACE As String = ""  'THIS VARIABLE IS USED TO FETCH RANGE COLUMN ONLY FOR KOTHARI, THEY WILL ENTER FULL SHIPTO ADDRESS THERE
    '            Dim DISPATCHFROM As String = ""
    '            Dim DISPATCHFROMGSTIN As String = ""
    '            Dim DISPATCHFROMPINCODE As String = ""
    '            Dim DISPATCHFROMSTATECODE As String = ""
    '            Dim DISPATCHFROMSTATENAME As String = ""
    '            Dim DISPATCHFROMKMS As Double = 0
    '            Dim DISPATCHFROMADD1 As String = ""
    '            Dim DISPATCHFROMADD2 As String = ""


    '            Dim OBJCMN As New ClsCommon
    '            'CMP ADDRESS DETAILS
    '            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
    '            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
    '            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
    '            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")
    '            DISPATCHFROM = CmpName
    '            DISPATCHFROMGSTIN = CMPGSTIN
    '            DISPATCHFROMPINCODE = CMPPINCODE
    '            DISPATCHFROMSTATECODE = CMPSTATECODE
    '            DISPATCHFROMSTATENAME = CMPSTATENAME


    '            'PARTY GST DETAILS 
    '            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2  ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
    '            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") Then
    '                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
    '                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
    '                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
    '                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
    '                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
    '                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
    '                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
    '                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
    '                PARTYADD1 = DT.Rows(0).Item("ADD1")
    '                PARTYADD2 = DT.Rows(0).Item("ADD2")
    '            End If


    '            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
    '            If CMPEINVOICECOUNTER = 0 Then
    '                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            'GET USED EINVOICECOUNTER
    '            Dim USEDEINVOICECOUNTER As Integer = 0
    '            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
    '            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

    '            'IF COUNTERS ARE FINISJED
    '            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
    '                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            'IF DATE HAS EXPIRED
    '            If Now.Date > EINVOICEEXPDATE Then
    '                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
    '            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
    '                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
    '            End If


    '            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
    '            'THIS IS FOR SANDBOX TEST
    '            Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
    '            'Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

    '            ServicePointManager.Expect100Continue = True
    '            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

    '            Dim REQUEST As WebRequest
    '            Dim RESPONSE As WebResponse
    '            REQUEST = WebRequest.CreateDefault(URL)

    '            REQUEST.Method = "GET"
    '            Try
    '                RESPONSE = REQUEST.GetResponse()
    '            Catch ex As WebException
    '                RESPONSE = ex.Response
    '            End Try
    '            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
    '            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

    '            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
    '            Dim STARTPOS As Integer = 0
    '            Dim TEMPSTATUS As String = ""
    '            Dim TOKEN As String = ""
    '            Dim ENDPOS As Integer = 0

    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
    '            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
    '            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
    '            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
    '            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

    '            'ADD DATA IN EINVOICEENTRY
    '            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
    '            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


    '            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
    '            'IF STATUS IS FAILED THEN ERROR MESSAGE
    '            If TEMPSTATUS = "FAILED" Then
    '                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
    '                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
    '                Exit Sub
    '            End If

    '            Dim j As String = ""
    '            Dim PRINTINITIALS As String = ""

    '            'GENERATING EINVOICE
    '            'FOR SANBOX TEST
    '            Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
    '            'Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
    '            REQUEST = WebRequest.CreateDefault(FURL)
    '            REQUEST.Method = "POST"
    '            Try
    '                REQUEST.ContentType = "application/json"



    '                j = "{"
    '                j = j & """Version"": ""1.1"","
    '                j = j & """TranDtls"": {"
    '                j = j & """TaxSch"":""GST"","
    '                j = j & """SupTyp"":""B2B"","
    '                j = j & """RegRev"":""N"","
    '                j = j & """IgstOnIntra"":""N""},"



    '                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
    '                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " HOTELBOOKINGMASTER ", " AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
    '                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

    '                j = j & """DocDtls"": {"
    '                j = j & """Typ"":""INV"","
    '                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
    '                j = j & """Dt"":""" & BOOKINGDATE.Text & """" & "},"


    '                'For WORKING ON SANDBOX
    '                CMPGSTIN = "34AACCC1596Q002"
    '                CMPPINCODE = "605001"
    '                CMPSTATECODE = "34"


    '                j = j & """SellerDtls"": {"
    '                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
    '                j = j & """LglNm"":""" & CmpName & """" & ","
    '                j = j & """TrdNm"":""" & CmpName & """" & ","
    '                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Loc"":""" & CMPCITYNAME & """" & "," 'CMBFROMCITY.Text.Trim & """" & ","
    '                j = j & """Pin"":" & CMPPINCODE & "" & ","
    '                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

    '                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
    '                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

    '                j = j & """BuyerDtls"": {"
    '                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
    '                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
    '                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
    '                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
    '                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
    '                j = j & """Pin"":" & PARTYPINCODE & "" & ","
    '                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


    '                j = j & """DispDtls"": {"
    '                j = j & """Nm"":""" & DISPATCHFROM & """" & ","
    '                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
    '                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
    '                j = j & """Pin"":" & DISPATCHFROMPINCODE & "" & ","
    '                j = j & """Stcd"":""" & DISPATCHFROMSTATECODE & """" & "},"

    '                j = j & """ShipDtls"": {"
    '                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
    '                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
    '                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
    '                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
    '                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
    '                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
    '                j = j & """Loc"":""" & PARTYSTATENAME & """" & ","
    '                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
    '                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"

    '                Dim TEMPOTHERAMT As Double = 0.0
    '                Dim TEMPTOTALITEMAMT As Double = 0.0
    '                If CHKTAXSERVCHGS.Checked = True Then
    '                    TEMPOTHERAMT = Val(TXTTOTALSALEAMT.Text.Trim) - Val(TXTDISCRS.Text.Trim) + Val(TXTEXTRACHGS.Text.Trim) + Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim) + Val(txtroundoff.Text.Trim)
    '                    TEMPTOTALITEMAMT = Val(TXTOURCOMMRS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
    '                Else
    '                    TEMPOTHERAMT = Val(txttax.Text.Trim) + Val(txtotherchg.Text.Trim) + Val(txtroundoff.Text.Trim)
    '                    TEMPTOTALITEMAMT = Val(TXTSUBTOTAL.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
    '                End If


    '                j = j & """ItemList"":[{"
    '                j = j & """SlNo"": """ & "1" & """" & ","
    '                'j = j & """PrdDesc"":""" & "Travel Booking" & """" & ","
    '                j = j & """IsServc"":""" & "Y" & """" & ","
    '                j = j & """HsnCd"":""" & TXTHSNCODE.Text.Trim & """" & ","
    '                'j = j & """Barcde"":""REC9999"","
    '                'j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
    '                'j = j & """FreeQty"":" & "0" & "" & ","
    '                'j = j & """Unit"":""" & "MTR" & """" & ","
    '                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTOURCOMMRS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
    '                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTOURCOMMRS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","

    '                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
    '                'j = j & """PreTaxVal"":" & "1" & "" & ","
    '                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTOURCOMMRS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","
    '                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
    '                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


    '                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
    '                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
    '                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
    '                If APPLYCESS = True Then
    '                    j = j & """CesRt"":" & Val(TXTCESSPER.Text.Trim) & "" & ","
    '                    j = j & """CesAmt"":" & Val(TXTCESSAMT.Text.Trim) & "" & ","
    '                Else
    '                    j = j & """CesRt"":" & "0" & "" & ","
    '                    j = j & """CesAmt"":" & "0" & "" & ","
    '                End If
    '                j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
    '                j = j & """StateCesRt"":" & "0" & "" & ","
    '                j = j & """StateCesAmt"":" & "0" & "" & ","
    '                j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
    '                j = j & """OthChrg"":" & "0" & "" & ","

    '                j = j & """TotItemVal"":" & Val(TEMPTOTALITEMAMT) & "" & ","
    '                j = j & """OrdLineRef"":"" "","
    '                j = j & """OrgCntry"":""IN"","
    '                j = j & """PrdSlNo"":""123"","

    '                j = j & """BchDtls"": {"
    '                j = j & """Nm"":""123"","
    '                j = j & """Expdt"":""" & BOOKINGDATE.Text & """" & ","
    '                j = j & """wrDt"":""" & BOOKINGDATE.Text & """" & "},"

    '                j = j & """AttribDtls"": [{"
    '                j = j & """Nm"":""123"","
    '                j = j & """Val"":""" & Val(TEMPTOTALITEMAMT) & """" & "}]"

    '                j = j & " }"

    '                j = j & " ],"



    '                j = j & """ValDtls"": {"
    '                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTOURCOMMRS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
    '                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
    '                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
    '                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","

    '                j = j & """CesVal"":" & "0" & "" & ","
    '                j = j & """StCesVal"":" & "0" & "" & ","
    '                j = j & """Discount"":" & "0" & "" & ","
    '                j = j & """OthChrg"":" & Val(TEMPOTHERAMT) & "" & ","
    '                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
    '                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
    '                j = j & """TotInvValFc"":" & "0" & "" & "},"


    '                j = j & """PayDtls"": {"
    '                j = j & """Nm"":"" "","
    '                j = j & """Accdet"":"" "","
    '                j = j & """Mode"":""Credit"","
    '                j = j & """Fininsbr"":"" "","
    '                j = j & """Payterm"":"" "","
    '                j = j & """Payinstr"":"" "","
    '                j = j & """Crtrn"":"" "","
    '                j = j & """Dirdr"":"" "","
    '                j = j & """Crday"":" & "0" & "" & ","
    '                j = j & """Paidamt"":" & "0" & "" & ","
    '                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


    '                j = j & """RefDtls"": {"
    '                j = j & """InvRm"":""TEST"","
    '                j = j & """DocPerdDtls"": {"
    '                j = j & """InvStDt"":""" & BOOKINGDATE.Text & """" & ","
    '                j = j & """InvEndDt"":""" & BOOKINGDATE.Text & """" & "},"

    '                j = j & """PrecDocDtls"": [{"
    '                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
    '                j = j & """InvDt"":""" & BOOKINGDATE.Text & """" & ","
    '                j = j & """OthRefNo"":"" ""}],"

    '                j = j & """ContrDtls"": [{"
    '                j = j & """RecAdvRefr"":"" "","
    '                j = j & """RecAdvDt"":""" & BOOKINGDATE.Text & """" & ","
    '                j = j & """Tendrefr"":"" "","
    '                j = j & """Contrrefr"":"" "","
    '                j = j & """Extrefr"":"" "","
    '                j = j & """Projrefr"":"" "","
    '                j = j & """Porefr"":"" "","
    '                j = j & """PoRefDt"":""" & BOOKINGDATE.Text & """" & "}]"
    '                j = j & "},"




    '                j = j & """AddlDocDtls"": [{"
    '                j = j & """Url"":""https://einv-apisandbox.nic.in"","
    '                j = j & """Docs"":""INVOICE"","
    '                j = j & """Info"":""INVOICE""}],"

    '                j = j & """TransDocNo"":"" "","



    '                j = j & """ExpDtls"": {"
    '                j = j & """ShipBNo"":"" "","
    '                j = j & """ShipBDt"":""" & BOOKINGDATE.Text & """" & ","
    '                j = j & """Port"":""INBOM1"","
    '                j = j & """RefClm"":""N"","
    '                j = j & """ForCur"":""AED"","
    '                j = j & """CntCode"":""AE""}"



    '                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
    '                'OR ELSE IT WILL GIVE ERROR
    '                If DISPATCHFROMPINCODE = PARTYPINCODE Then PARTYKMS = 10

    '                'WE HAVE REMOVED CREATING EWAY DIRECTLY FORM EINVOICE
    '                'USER HAVE TO MANUALLY CREATE EWAY SEPERATELY
    '                'If TXTVEHICLENO.Text.Trim <> "" Then
    '                '    j = j & ","
    '                '    j = j & """EwbDtls"": {"
    '                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
    '                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
    '                '    j = j & """Distance"":""" & PARTYKMS & """" & ","
    '                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
    '                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
    '                '    j = j & """VehType"":""" & "R" & """" & ","
    '                '    j = j & """TransMode"":""1""" & "}"
    '                'End If

    '                j = j & "}"


    '                Dim stream As Stream = REQUEST.GetRequestStream()
    '                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
    '                stream.Write(buffer, 0, buffer.Length)

    '                'POST request absenden
    '                RESPONSE = REQUEST.GetResponse()



    '            Catch ex As WebException
    '                'RESPONSE = ex.Response
    '                'MsgBox("Error While Generating EWB, Please check the Data Properly")
    '                ''ADD DATA IN EINVOICEENTRY
    '                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

    '                RESPONSE = ex.Response
    '                READER = New StreamReader(RESPONSE.GetResponseStream())
    '                REQUESTEDTEXT = READER.ReadToEnd()
    '                GoTo ERRORMESSAGE
    '            End Try

    '            READER = New StreamReader(RESPONSE.GetResponseStream())
    '            REQUESTEDTEXT = READER.ReadToEnd()


    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
    '            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
    '            If TEMPSTATUS = "1" Then
    '                TEMPSTATUS = "SUCCESS"
    '                MsgBox("E-Invoice Generated Successfully ")

    '            Else

    'ERRORMESSAGE:
    '                TEMPSTATUS = "FAILED"

    '                Dim ERRORMSG As String = ""
    '                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
    '                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
    '                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

    '                'ADD DATA IN EINVOICEENTRY
    '                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

    '                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

    '                Exit Sub
    '            End If


    '            Dim IRNNO As String = ""
    '            Dim ACKNO As String = ""
    '            Dim ADATE As String = ""


    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
    '            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
    '            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
    '            TXTACKNO.Text = ACKNO


    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
    '            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
    '            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
    '            ACKDATE.Value = ADATE

    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
    '            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
    '            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
    '            TXTIRNNO.Text = IRNNO


    '            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
    '            DT = OBJCMN.Execute_Any_String("UPDATE HOTELBOOKINGMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM HOTELBOOKINGMASTER WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId, "", "")

    '            'ADD DATA IN EINVOICEENTRY
    '            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


    '            'ADD DATA IN EINVOICEENTRY FOR QRCODE
    '            If TEMPSTATUS = "SUCCESS" Then

    '                ''GET SIGNED QRCODE
    '                Dim req As New RestRequest
    '                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
    '                Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
    '                'Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
    '                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
    '                Dim respPl = New RespPl()
    '                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
    '                Dim respPlGenIRNDec As New RespPlGenIRNDec()
    '                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
    '                'MsgBox(respPlGenIRNDec.Irn)
    '                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
    '                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
    '                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

    '                'GET REGINITIALS AS SAVE WITH IT
    '                'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = 'VEHICLE SALE REGISTER' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
    '                bitmap1.Save(Application.StartupPath & "\S" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
    '                PBQRCODE.ImageLocation = Application.StartupPath & "\S" & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
    '                PBQRCODE.Refresh()

    '                If PBQRCODE.Image IsNot Nothing Then
    '                    Dim OBJINVOICE As New ClsHotelBookingMaster
    '                    Dim MS As New IO.MemoryStream
    '                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
    '                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
    '                    OBJINVOICE.alParaval.Add(MS.ToArray)
    '                    OBJINVOICE.alParaval.Add(YearId)
    '                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
    '                End If

    '                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


    '                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
    '                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

    '            End If




    '            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
    '            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
    '            ''Dim QRSTREAM As New MemoryStream
    '            ''Dim bmp As New Bitmap(QRSTREAM)
    '            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
    '            ''QRSTREAM.Position = STARTPOS
    '            ''Dim data As Byte()
    '            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

    '            'Dim bytes() As Byte
    '            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
    '            'Dim MS As System.IO.MemoryStream
    '            'Dim NewImage As Bitmap

    '            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
    '            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

    '            'bytes = Convert.FromBase64String(BASE64STRING)
    '            'NewImage = BytesToBitmap(bytes)
    '            'MS = New System.IO.MemoryStream(bytes)
    '            'MS.Write(bytes, 0, bytes.Length)
    '            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
    '            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

    '            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

    '            ''ADD data IN EINVOICEENTRY
    '            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub


    'Private Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
    '    Try
    '        If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

    '            'FIRST GETTOKEN AND THEN GET QRCODE
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As New DataTable

    '            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

    '            ServicePointManager.Expect100Continue = True
    '            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

    '            Dim REQUEST As WebRequest
    '            Dim RESPONSE As WebResponse
    '            REQUEST = WebRequest.CreateDefault(URL)

    '            REQUEST.Method = "GET"
    '            Try
    '                RESPONSE = REQUEST.GetResponse()
    '            Catch ex As WebException
    '                RESPONSE = ex.Response
    '            End Try
    '            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
    '            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

    '            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
    '            Dim STARTPOS As Integer = 0
    '            Dim TEMPSTATUS As String = ""
    '            Dim TOKEN As String = ""
    '            Dim ENDPOS As Integer = 0

    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
    '            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
    '            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




    '            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
    '            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
    '            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

    '            'ADD DATA IN EINVOICEENTRY
    '            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
    '            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


    '            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
    '            'IF STATUS IS FAILED THEN ERROR MESSAGE
    '            If TEMPSTATUS = "FAILED" Then
    '                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
    '                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
    '                Exit Sub
    '            End If


    '            ''GET SIGNED QRCODE
    '            Dim req As New RestRequest
    '            req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
    '            'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
    '            Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
    '            Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
    '            Dim respPl = New RespPl()
    '            respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
    '            Dim respPlGenIRNDec As New RespPlGenIRNDec()
    '            respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
    '            'MsgBox(respPlGenIRNDec.Irn)
    '            Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
    '            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
    '            Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)



    '            'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
    '            'PBQRCODE.ImageLocation = Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
    '            'PBQRCODE.Refresh()


    '            'GET REGINITIALS AS SAVE WITH IT
    '            'Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
    '            bitmap1.Save(Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
    '            PBQRCODE.ImageLocation = Application.StartupPath & "\" & SALEreginitial & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
    '            PBQRCODE.Refresh()



    '            'If PBQRCODE.Image IsNot Nothing Then
    '            '    Dim OBJINVOICE As New ClsInvoiceMaster
    '            '    Dim MS As New IO.MemoryStream
    '            '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
    '            '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
    '            '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
    '            '    OBJINVOICE.alParaval.Add(MS.ToArray)
    '            '    OBJINVOICE.alParaval.Add(YearId)
    '            '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
    '            'End If

    '            'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

    '            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
    '            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'AIRINVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
    '            cmdok_Click(sender, e)

    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'AIRDEBITNOTE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim TEMPREG As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and register_type = 'AIRLINE DEBITNOTE' AND REGISTER_YEARID = " & YearId)
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

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'AIRDEBITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTDNNO.Text.Trim) & ",'AIRDEBITNOTE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            'GENERATEINV()
            'NO NEED OF EINV HERE, THIS FORM IS ONLY FOR PURCHASE DEBIT NOTE, IF USER WANTS TO CREATE THEN THEY WILL DO IT IN DEBITNOTE FORM, NOT HERE
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOOKINGS_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
                With GRIDBOOKINGS.Rows(e.RowIndex).Cells(GRIDBOOKINGS.Columns("GPASSCHK").Index)
                    If .Value = True Then
                        ' IF A PASSENGER IS UNCHECKED
                        .Value = False
                    Else
                        ' IF A PASSENGER IS CHECKED
                        .Value = True
                    End If
                End With
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.Validated, TXTPURSERVCHGS.Validated
        TOTAL()
    End Sub

    Private Sub TXTPURTDSRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURTDSRS.Validated
        TOTAL()
    End Sub

    Private Sub CHKTAXSERVCHGS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.TextChanged
        TOTAL()
    End Sub


End Class