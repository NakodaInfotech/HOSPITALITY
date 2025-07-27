Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class GiftPurchase
   
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK, GRIDEXTRADBLCLICK, gridUPLOADdoubleclick As Boolean
    Dim TEMPROW, TEMPCHGSROW, TEMPEXTRAROW, tempUPLOADrow, PURREGID As Integer
    Dim TEMPPARTYBILLNO As String
    Public EDIT As Boolean
    Public TEMPBILLNO, TEMPREGNAME As String
    Dim PURREGABBR, PURREGINITIAL As String
    Public Shared selectGRNtable As New DataTable
    Dim TDSPER As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Sub clear()

        BILLDATE.Value = Mydate
        tstxtbillno.Clear()

        cmbname.Text = ""
        cmbname.Enabled = True
        CMBCODE.Text = ""
        TXTPARTYBILLNO.Clear()
        PARTYBILLDATE.Value = Mydate
        txtadd.Clear()
        CHKBILLCHECKED.Checked = False
        CHKBILLDISPUTE.Checked = False
        chkchange.Checked = False
        CHKTDS.Checked = False

        EP.Clear()
        PBDN.Visible = False
        PBPAID.Visible = False
        PBTDS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSHOWDETAILS.Visible = False

        txtremarks.Clear()
        txtinwords.Clear()
        TXTSRNO.Clear()
        CMBGIFT.Text = ""
        TXTQTY.Clear()
        CMBQTYUNIT.Text = ""
        TXTQTY.Clear()
        TXTRATE.Clear()
        TXTAMT.Clear()

        GRIDBILL.RowCount = 0

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTCHGSNARRATION.Clear()
        GRIDCHGS.RowCount = 0

        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        txtimgpath.Clear()
        TXTFILENAME.Clear()
        TXTNEWIMGPATH.Clear()
        PBSoftCopy.ImageLocation = ""
        gridupload.RowCount = 0

        getmax_BILL_no()

        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        gridUPLOADdoubleclick = False

        txtbillamt.Text = 0.0
        TXTCHARGES.Text = 0.0
        TXTSUBTOTAL.Text = 0.0
        txtgrandtotal.Text = 0.0
        txtroundoff.Text = 0.0
        txtremarks.Clear()

        lbltotalqty.Text = 0.0
        lbltotalqty.Text = 0.0

        TabControl1.SelectedIndex = 0

        If GRIDBILL.RowCount > 0 Then
            TXTSRNO.Text = Val(GRIDBILL.Rows(GRIDBILL.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If

        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If


    End Sub

    Sub getmax_BILL_no()
        Dim DTTABLE As New DataTable
        cmbregister.Text = "GIFT PURCHASE REGISTER"
        DTTABLE = getmax(" isnull(max(BILL_NO),0) + 1 ", "  GIFTPURCHASEMaster left outer JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID AND REGISTER_CMPID = BILL_CMPID AND REGISTER_LOCATIONID = BILL_LOCATIONID AND REGISTER_YEARID = BILL_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND BILL_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTBILLNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub PurchaseMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3) Then       'for CLEAR
                TabControl1.SelectedIndex = (2)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4) Then       'for CLEAR
                TabControl1.SelectedIndex = (3)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        fillregister(cmbregister, " and register_type = 'PURCHASE'")
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        If CMBGIFT.Text.Trim = "" Then fillGIFT(CMBGIFT)

    End Sub


    Private Sub GiftPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'REGISTRATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            cmbregister.Text = "GIFT PURCHASE REGISTER"
            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dt As New DataTable
                Dim ALPARAVAL As New ArrayList
                Dim objclsINV As New ClsGiftPurchaseMaster

                ALPARAVAL.Add(TEMPBILLNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsINV.alParaval = ALPARAVAL
                dt = objclsINV.selectbill_edit()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTBILLNO.Text = TEMPBILLNO

                        cmbregister.Text = Convert.ToString(dr("REGNAME"))
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        BILLDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        TXTPARTYBILLNO.Text = Convert.ToString(dr("PARTYBILLNO"))
                        TEMPPARTYBILLNO = Convert.ToString(dr("PARTYBILLNO"))

                        PARTYBILLDATE.Value = Format(Convert.ToDateTime(dr("PARTYBILLDATE")).Date, "dd/MM/yyyy")



                        If dr("BILLCHECKED") = 0 Then
                            CHKBILLCHECKED.Checked = False
                        Else
                            CHKBILLCHECKED.Checked = True
                        End If
                        If dr("BILLDISPUTE") = 0 Then
                            CHKBILLDISPUTE.Checked = False
                        Else
                            CHKBILLDISPUTE.Checked = True
                        End If
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        lbltotalqty.Text = dr("TOTALQTY")
                        'lbltotalqty.Text = dr("TOTALMTRS")
                        txtinwords.Text = Convert.ToString(dr("INWORDS"))

                        txtbillamt.Text = dr("BILLAMT")
                        TXTCHARGES.Text = dr("CHARGES")
                        'TXTBROKERAGE.Text = dr("BROKERAGE")
                        txtroundoff.Text = dr("ROUNDOFF")
                        txtgrandtotal.Text = dr("GRANDTOTAL")

                        TXTAMTPAID.Text = dr("AMTPAID")
                        TXTEXTRAAMT.Text = dr("EXTRAAMT")
                        TXTRETURN.Text = dr("RETURN")
                        TXTBAL.Text = dr("BALANCE")

                        'Item Grid
                        GRIDBILL.Rows.Add(dr("GRIDSRNO").ToString, dr("GIFTNAME").ToString, Val(dr("QTY")), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMT")), "0.00"), dr("OUTPCS"))

                        '    If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                        '        lbllocked.Visible = True
                        '        PBlock.Visible = True
                        '        GRIDBILL.Rows(GRIDBILL.RowCount - 1).DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        '        cmbname.Enabled = False
                        '    End If

                        '    TabControl1.SelectedIndex = (0)

                        '    'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        '    Dim OBJCMNTDS As New ClsCommon
                        '    Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(JOURNALMASTER.journal_credit,0) AS TDS", "", " JOURNALMASTER INNER JOIN PURCHASEMASTER ON JOURNALMASTER.journal_refno = PURCHASEMASTER.BILL_INITIALS AND  JOURNALMASTER.journal_yearid = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id AND JOURNALMASTER.journal_yearid = LEDGERS.Acc_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid", "AND (LEDGERS.ACC_TDSAC = 'True') AND BILL_NO = " & TEMPBILLNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND BILL_YEARID = " & YearId)
                        '    If DTTDS.Rows.Count > 0 Then
                        '        If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                        '            CMDSHOWDETAILS.Visible = True
                        '            PBTDS.Visible = True
                        '            lbllocked.Visible = True
                        '            PBlock.Visible = True
                        '        End If
                        '    End If

                        '    If PBTDS.Visible = False Then
                        '        If Val(dr("AMTPAID")) > 0 Or Val(dr("EXTRAAMT")) > 0 Then
                        '            CMDSHOWDETAILS.Visible = True
                        '            PBPAID.Visible = True
                        '            lbllocked.Visible = True
                        '            PBlock.Visible = True
                        '        End If
                        '    End If

                        '    If Val(dr("BILLRETURN")) > 0 Then
                        '        CMDSHOWDETAILS.Visible = True
                        '        PBDN.Visible = True
                        '        lbllocked.Visible = True
                        '        PBlock.Visible = True
                        '    End If

                    Next

                    'CHARGES GRID
                    Dim OBJCM2 As New ClsCommon
                    Dim dt2 As DataTable = OBJCM2.search("  GIFTPURCHASEMASTER_CHGS.BILL_gridsrno AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CHARGES, ISNULL(GIFTPURCHASEMASTER_CHGS.BILL_CHGSREMARKS, '') AS REMARKS, ISNULL(GIFTPURCHASEMASTER_CHGS.BILL_PER, 0) AS PER, ISNULL(GIFTPURCHASEMASTER_CHGS.BILL_AMT, 0) AS AMT, ISNULL(TAXMASTER.tax_id, 0) AS TAXID", "", " GIFTPURCHASEMASTER INNER JOIN GIFTPURCHASEMASTER_CHGS ON GIFTPURCHASEMASTER.BILL_NO = GIFTPURCHASEMASTER_CHGS.BILL_no AND GIFTPURCHASEMASTER.BILL_REGISTERID = GIFTPURCHASEMASTER_CHGS.BILL_REGISTERID AND GIFTPURCHASEMASTER.BILL_YEARID = GIFTPURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON GIFTPURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id AND GIFTPURCHASEMASTER.BILL_YEARID = REGISTERMASTER.register_yearid LEFT OUTER JOIN LEDGERS ON GIFTPURCHASEMASTER_CHGS.BILL_CHARGESID = LEDGERS.Acc_id AND GIFTPURCHASEMASTER_CHGS.BILL_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN TAXMASTER ON GIFTPURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id AND GIFTPURCHASEMASTER_CHGS.BILL_yearid = TAXMASTER.tax_yearid", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND GIFTPURCHASEMASTER_CHGS.BILL_NO = " & TEMPBILLNO & " AND GIFTPURCHASEMASTER_CHGS.BILL_YEARID = " & YearId)
                    If dt2.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt2.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("REMARKS"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    'UPLOAD GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" GIFTPURCHASEMASTER_UPLOAD.BILL_GRIDSRNO AS GRIDSRNO, GIFTPURCHASEMASTER_UPLOAD.BILL_REMARKS AS REMARKS, GIFTPURCHASEMASTER_UPLOAD.BILL_NAME AS NAME, GIFTPURCHASEMASTER_UPLOAD.BILL_IMGPATH AS IMGPATH, GIFTPURCHASEMASTER_UPLOAD.BILL_NEWIMGPATH AS NEWIMGPATH", "", " REGISTERMASTER INNER JOIN GIFTPURCHASEMASTER ON REGISTERMASTER.register_id = GIFTPURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_yearid = GIFTPURCHASEMASTER.BILL_YEARID LEFT OUTER JOIN GIFTPURCHASEMASTER_UPLOAD ON GIFTPURCHASEMASTER.BILL_NO = GIFTPURCHASEMASTER_UPLOAD.BILL_NO AND GIFTPURCHASEMASTER.BILL_YEARID = GIFTPURCHASEMASTER_UPLOAD.BILL_YEARID AND GIFTPURCHASEMASTER.BILL_REGISTERID = GIFTPURCHASEMASTER_UPLOAD.BILL_REGISTERID", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'PURCHASE' AND GIFTPURCHASEMASTER_UPLOAD.BILL_NO = " & TEMPBILLNO & " AND GIFTPURCHASEMASTER_UPLOAD.BILL_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR2 As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR2("GRIDSRNO"), DTR2("REMARKS"), DTR2("NAME"), DTR2("IMGPATH"), DTR2("NEWIMGPATH"))
                        Next
                    End If

                    Dim clscommon As New ClsCommon
                    Dim dtID As DataTable
                    dtID = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                    If dtID.Rows.Count > 0 Then
                        PURREGABBR = dtID.Rows(0).Item(0).ToString
                        PURREGINITIAL = dtID.Rows(0).Item(1).ToString
                        PURREGID = dtID.Rows(0).Item(2)
                    End If
                    GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

                End If

                cmbregister.Enabled = False
                cmbname.Focus()
                chkchange.CheckState = CheckState.Checked
                total()
            Else
                EDIT = False
                clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub


    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(BILLDATE.Value)

            alParaval.Add(TXTPARTYBILLNO.Text.Trim)
            alParaval.Add(PARTYBILLDATE.Value)


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
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(txtinwords.Text)

            alParaval.Add(txtbillamt.Text.Trim)
            alParaval.Add(TXTCHARGES.Text.Trim)
            alParaval.Add(txtroundoff.Text.Trim)
            alParaval.Add(txtgrandtotal.Text.Trim)

            alParaval.Add(TXTAMTPAID.Text.Trim)
            alParaval.Add(TXTEXTRAAMT.Text.Trim)
            alParaval.Add(TXTRETURN.Text.Trim)
            alParaval.Add(TXTBAL.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim GIFTNAME As String = ""
            Dim qty As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim AMT As String = ""          'value of AMT
            Dim OUTPCS As String = ""          'value of OUTPCS
          
            For Each row As Windows.Forms.DataGridViewRow In GRIDBILL.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        GIFTNAME = row.Cells(gGiftname.Index).Value.ToString
                        qty = row.Cells(GQty.Index).Value.ToString
                        RATE = row.Cells(GRATE.Index).Value
                        If row.Cells(GAMT.Index).Value <> Nothing Then
                            AMT = row.Cells(GAMT.Index).Value
                        Else
                            AMT = "0"
                        End If
                        OUTPCS = row.Cells(GOutPcs.Index).Value
                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        GIFTNAME = GIFTNAME & "|" & row.Cells(gGiftname.Index).Value.ToString
                        qty = qty & "|" & row.Cells(GQty.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        If row.Cells(GAMT.Index).Value <> Nothing Then
                            AMT = AMT & "|" & row.Cells(GAMT.Index).Value
                        Else
                            AMT = AMT & "|" & "0"
                        End If
                        OUTPCS = OUTPCS & "|" & row.Cells(GOutPcs.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(GIFTNAME)
            alParaval.Add(qty)
            alParaval.Add(RATE)
            alParaval.Add(AMT)
            alParaval.Add(OUTPCS)


            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CREMARKS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CREMARKS = row.Cells(EREMARKS.Index).Value.ToString
                        CPER = row.Cells(EPER.Index).Value.ToString
                        CAMT = row.Cells(EAMT.Index).Value.ToString
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)

                    Else
                        CSRNO = CSRNO & "," & row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = CCHGS & "," & row.Cells(ECHARGES.Index).Value.ToString
                        CREMARKS = CREMARKS & "," & row.Cells(EREMARKS.Index).Value.ToString
                        CPER = CPER & "," & row.Cells(EPER.Index).Value.ToString
                        CAMT = CAMT & "," & row.Cells(EAMT.Index).Value.ToString
                        CTAXID = CTAXID & "," & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CREMARKS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)

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
                        griduploadsrno = griduploadsrno & "," & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "," & row.Cells(1).Value.ToString
                        name = name & "," & row.Cells(2).Value.ToString
                        imgpath = imgpath & "," & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "," & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)


            Dim OBJINV As New ClsGiftPurchaseMaster
            OBJINV.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJINV.save()
                MessageBox.Show("Details Added")

                'If CHKTDS.CheckState = CheckState.Checked Then
                '    Dim OBJTDS As New DeductTDS
                '    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                '    OBJTDS.TXTTDSPER.Text = TDSPER
                '    OBJTDS.REGISTER = cmbregister.Text.Trim
                '    OBJTDS.ShowDialog()
                'End If


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBILLNO)
                IntResult = OBJINV.Update()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            clear()
            BILLDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = Val(TXTQTY.Text) * Val(TXTRATE.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, " Please Fill Company Name ")
            bln = False
        End If

        If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTPARTYBILLNO, "Enter Party Bill No")
            bln = False
        End If

        If GRIDBILL.RowCount = 0 Then
            EP.SetError(cmbname, "Select grn")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDBILL.Rows
            If Val(row.Cells(GAMT.Index).Value) = 0 Then
                EP.SetError(cmbname, "Amt Cannot be 0")
                bln = False
            End If
        Next

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Rec/Pay/TDS Made, Delete Rec/Pay/TDS First")
            bln = False
        End If
        

        If Not datecheck(BILLDATE.Value) Then
            EP.SetError(BILLDATE, "Date Not in Current Accounting Year")
            bln = False
        End If

        If Not datecheck(PARTYBILLDATE.Value) Then bln = False
        'If Not datecheck(lrdate.Value) Then bln = False
        'If Not datecheck(DUEDATE.Value) Then bln = False

        Return bln
    End Function

    Private Sub cmbname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.GotFocus
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub total()
        Try
            lbltotalqty.Text = "0.0"
            lbltotalqty.Text = "0.0"

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0


            If GRIDBILL.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDBILL.Rows
                    row.Cells(GAMT.Index).Value = Format((row.Cells(GQty.Index).EditedFormattedValue * row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                    If Val(row.Cells(gQty.Index).Value) > 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0")
                    If Val(row.Cells(GAMT.Index).Value) > 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                Next
            End If

            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If


            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")
            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - Val(TXTSUBTOTAL.Text), "0.00")
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then
                If lbllocked.Visible = True Then
                    MsgBox("Invoice Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim intresult As Integer
                Dim objcls As New ClsGiftPurchaseMaster()
                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPBILLNO)
                    alParaval.Add(TEMPREGNAME)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)
                    alParaval.Add(Userid)
                    objcls.alParaval = alParaval
                    intresult = objcls.DELETE()
                    MsgBox("Purchase Invoice Delete Successfully")
                    clear()
                    EDIT = False

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                GiftPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO > 1 Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDBILL.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmax_BILL_no()
            Dim MAXNO As Integer = TXTBILLNO.Text.Trim
            clear()
            If Val(TXTBILLNO.Text) - 1 >= TEMPBILLNO Then
                EDIT = True
                GiftPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDBILL.RowCount = 0 And TEMPBILLNO < MAXNO Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
            End If
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

            Dim objINVDTLS As New GiftPurchaseDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            '  Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            'If cmbname.Text.Trim <> "" Then
            '    'GET REGISTER , AGENCT AND TRANS
            '    Dim OBJCMN As New ClsCommon
            '    Dim DT As DataTable = OBJCMN.search(" ISNULL(REGISTERMASTER.register_name, '') AS REGISTERNAME", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON LEDGERS.Acc_yearid = ACCOUNTSMASTER_TDS.ACC_YEARID AND LEDGERS.Acc_id = ACCOUNTSMASTER_TDS.ACC_ID LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId)
            '    If DT.Rows.Count > 0 Then

            '        If DT.Rows(0).Item("REGISTERNAME") <> cmbregister.Text.Trim And DT.Rows(0).Item("REGISTERNAME") <> "" Then
            '            Dim TEMPMSG As Integer = MsgBox("Register is Different Change to Default?", MsgBoxStyle.YesNo)
            '            If TEMPMSG = vbYes Then
            '                cmbregister.Text = DT.Rows(0).Item("REGISTERNAME")
            '                getmax_BILL_no()
            '            End If
            '        End If

            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub dtinvdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BILLDATE.Validating
        'If Not datecheck(BILLDATE.Value) Then
        '    MsgBox("Date Not in Current Accounting Year")
        '    e.Cancel = True
        'End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        'Try
        '    If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

        '    Dim clscommon As New ClsCommon
        '    Dim dt As DataTable
        '    dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
        '    If dt.Rows.Count > 0 Then
        '        cmbregister.Text = dt.Rows(0).Item(0).ToString
        '    End If
        '    getmax_BILL_no()

        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        'Try
        '    If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
        '        'clear()
        '        cmbregister.Text = UCase(cmbregister.Text)
        '        Dim clscommon As New ClsCommon
        '        Dim dt As DataTable
        '        dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
        '        If dt.Rows.Count > 0 Then
        '            PURREGABBR = dt.Rows(0).Item(0).ToString
        '            PURREGINITIAL = dt.Rows(0).Item(1).ToString
        '            PURREGID = dt.Rows(0).Item(2)
        '            getmax_BILL_no()
        '            cmbregister.Enabled = False
        '        Else
        '            MsgBox("Register Not Present, Add New from Master Module")
        '            e.Cancel = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub gridinv_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDBILL.CellValidating
        Dim colNum As Integer = GRIDBILL.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GRATE.Index, GQty.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDBILL.CurrentCell.Value = Nothing Then GRIDBILL.CurrentCell.Value = "0.00"
                    GRIDBILL.CurrentCell.Value = Convert.ToDecimal(GRIDBILL.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If
                'Case GPER.Index
                total()
        End Select
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating

        Try
            GRIDBILL.RowCount = 0

            TEMPBILLNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                GiftPurchase_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Sub fillgrid()

        GRIDBILL.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDBILL.Rows.Add(Val(TXTSRNO.Text.Trim), CMBGIFT.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMT.Text.Trim), "0.00"), 0)
            getsrno(GRIDBILL)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDBILL.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDBILL.Item(gGiftname.Index, TEMPROW).Value = CMBGIFT.Text.Trim
            GRIDBILL.Item(GQty.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDBILL.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDBILL.Item(GAMT.Index, TEMPROW).Value = Format(Val(TXTAMT.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False

        End If
        TXTAMT.ReadOnly = True
        total()
        GRIDBILL.FirstDisplayedScrollingRowIndex = GRIDBILL.RowCount - 1

        TXTSRNO.Clear()
        CMBGIFT.Text = ""
        TXTQTY.Clear()
        TXTRATE.Clear()
        TXTAMT.Clear()


        If GRIDBILL.RowCount > 0 Then
            TXTSRNO.Text = Val(GRIDBILL.Rows(GRIDBILL.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If
        TXTSRNO.Focus()

    End Sub

    Sub fillchgsgrid()

        If GRIDCHGSDOUBLECLICK = False Then
            GRIDCHGS.Rows.Add(Val(TXTCHGSSRNO.Text.Trim), CMBCHARGES.Text.Trim, TXTCHGSNARRATION.Text.Trim, Val(TXTCHGSPER.Text.Trim), Val(TXTCHGSAMT.Text.Trim), Val(TXTTAXID.Text.Trim))
            getsrno(GRIDCHGS)
        ElseIf GRIDCHGSDOUBLECLICK = True Then
            GRIDCHGS.Item(ESRNO.Index, TEMPCHGSROW).Value = Val(TXTCHGSSRNO.Text.Trim)
            GRIDCHGS.Item(ECHARGES.Index, TEMPCHGSROW).Value = CMBCHARGES.Text.Trim
            GRIDCHGS.Item(EREMARKS.Index, TEMPCHGSROW).Value = TXTCHGSNARRATION.Text.Trim
            GRIDCHGS.Item(EPER.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSPER.Text.Trim), "0.00")
            GRIDCHGS.Item(EAMT.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSAMT.Text.Trim), "0.00")
            GRIDCHGS.Item(ETAXID.Index, TEMPCHGSROW).Value = Format(Val(TXTTAXID.Text.Trim))

            GRIDCHGSDOUBLECLICK = False

        End If
        total()
        TXTCHGSPER.ReadOnly = False
        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTCHGSNARRATION.Clear()
        TXTTAXID.Clear()

        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If
        TXTCHGSSRNO.Focus()
    End Sub

    Private Sub TXTAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTAMT.Validated
        If (TXTRATE.Text.Length) = 0 Then
            TXTRATE.Text = Format(Val(TXTAMT.Text) / Val(TXTQTY.Text), "0.00")
        End If
        If CMBGIFT.Text.Trim <> "" And CMBGIFT.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 And Val(TXTAMT.Text.Trim) > 0 Then
            fillgrid()
            total()

        Else
            If CMBGIFT.Text.Trim = "" Then
                MsgBox("Please Fill Gift Item Name ")
                CMBGIFT.Focus()
                Exit Sub
            End If
            
            If TXTQTY.Text.Trim = "" Then
                MsgBox("Please Fill Qty. ")
                TXTQTY.Focus()
                Exit Sub
            End If

            If Val(TXTRATE.Text.Trim) <= 0 Then
                MsgBox("Please Fill Rate")
                TXTRATE.Focus()
                Exit Sub
            End If

            If Val(TXTAMT.Text.Trim) <= 0 Then
                MsgBox("Please Fill Amt.")
                TXTAMT.Focus()
                Exit Sub
            End If


        End If
        'MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
        'Exit Sub
    End Sub

    Sub EDITROW()
        Try
            If GRIDBILL.CurrentRow.Index >= 0 And GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDBILL.Item(gsrno.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                CMBGIFT.Text = GRIDBILL.Item(gGiftname.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDBILL.Item(GQty.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDBILL.Item(GRATE.Index, GRIDBILL.CurrentRow.Index).Value.ToString
                TXTAMT.Text = GRIDBILL.Item(GAMT.Index, GRIDBILL.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDBILL.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub CMBPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
            CALC()
        Catch ex As Exception
            Throw ex
        End Try

        'Try
        '    If CMBPER.Text = "Mtrs" Then
        '        TXTAMT.Text = Val(TXTMTRS.Text) * Val(TXTRATE.Text)
        '    Else
        '        TXTAMT.Text = Val(TXTQTY.Text) * Val(TXTRATE.Text)
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub GRIDBILL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDBILL.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDBILL.Rows.RemoveAt(GRIDBILL.CurrentRow.Index)
                getsrno(GRIDBILL)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDBILL.RowCount > 0 Then
                If GRIDBILL.CurrentRow.Cells(gGiftname.Index).Value <> "" Then GRIDBILL.Rows.Add(CloneWithValues(GRIDBILL.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        CALC()
        total()
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTQTY.Validated
        CALC()
        total()
    End Sub

    Private Sub TXTQTY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CALC()
        total()
    End Sub

    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGIFT.Enter
        Try
            If CMBGIFT.Text.Trim = "" Then fillGIFT(CMBGIFT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGIFT.Validating
        Try
            If CMBGIFT.Text.Trim <> "" Then GIFTVALIDATE(CMBGIFT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdot(e, TXTRATE, Me)
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.SALEBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDN.Click
        Try
            If PBPAID.Visible = True Then
                MsgBox("Pay made, Delete Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME  = '" & cmbregister.Text.Trim & "' AND REGISTER_CMPID = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    OBJdN.BILLNO = DT.Rows(0).Item("INITIALS") & "-" & Val(TXTBILLNO.Text.Trim)
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses'  OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        Try
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSNARRATION.Text = GRIDCHGS.Item(EREMARKS.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                TXTCHGSSRNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                getsrno(GRIDCHGS)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    fillchgsgrid()
                    total()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")

                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        'Try
        '    If CMBCHARGES.Text.Trim <> "" And TXTCHGSAMT.Text.Trim <> "" Then
        '        fillchgsgrid()
        '    Else
        '        'If CMBCHARGES.Text.Trim = "" Then
        '        '    MsgBox("Please Fill Charges Name ")
        '        '    CMBCHARGES.Focus()
        '        '    Exit Sub
        '        'End If
        '        If TXTCHGSAMT.Text.Trim = "" Then
        '            MsgBox("Please Fill Charges Amount ")
        '            TXTCHGSAMT.Focus()
        '            Exit Sub
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
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

        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTBILLNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
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
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
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

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSPER.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSPER, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSPER.Validating
        Try
            Dim dDebit As Decimal
            Dim bValid As Boolean = Decimal.TryParse(TXTCHGSPER.Text.Trim, dDebit)
            If bValid Then
                If Val(TXTCHGSPER.Text) = 0 Then TXTCHGSPER.Text = ""
                TXTCHGSPER.Text = Convert.ToDecimal(Val(TXTCHGSPER.Text))
                '' everything is good
                calchgs()
            ElseIf TXTCHGSPER.Text = "" Then

            Else
                MessageBox.Show("Invalid Number Entered")
                'e.Cancel = True
                TXTCHGSPER.Clear()
                TXTCHGSPER.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            TXTTAXID.Text = 0
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" ISNULL(tax_tax, 0) as TAX, TAX_ID AS TAXID ", "", " TAXMASTER", " AND tax_name = '" & CMBCHARGES.Text & "'  AND tax_cmpid=" & CmpId & " AND tax_LOCATIONID = " & Locationid & " AND tax_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                TXTCHGSPER.Text = dt.Rows(0).Item("TAX")
                TXTTAXID.Text = Val(dt.Rows(0).Item("TAXID"))
                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" Then filltax()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If (EDIT = False) Or (EDIT = True And TEMPPARTYBILLNO <> TXTPARTYBILLNO.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" BILL_INITIALS AS BILLNO", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id AND PURCHASEMASTER.BILL_CMPID = LEDGERS.Acc_cmpid AND PURCHASEMASTER.BILL_LOCATIONID = LEDGERS.Acc_locationid AND PURCHASEMASTER.BILL_YEARID = LEDGERS.Acc_yearid ", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill No Already Exists in Entry No " & DT.Rows(0).Item("BILLNO"))
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        Try
            numdot(e, TXTAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GiftPurchase_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName <> "FINASTA" Then Me.Close()
    End Sub
End Class