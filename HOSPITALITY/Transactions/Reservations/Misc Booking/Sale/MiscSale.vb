
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Net
Imports RestSharp
Imports TaxProEInvoice.API
Imports Newtonsoft.Json

Public Class MiscSale

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean, DIRECTUPLOAD As Boolean
    Dim gridUPLOADdoubleclick As Boolean

    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public edit As Boolean
    Public TEMPBOOKINGNO As Integer
    Public TEMPREGNAME As String

    Public TEMPBOOKINGINITIALS As String
    Public FRMSTRING As String
    Dim TEMPMSG As Integer
    Dim DDATE As DateTime

    Dim PURregabbr, PURreginitial As String
    Public PURregid As Integer

    Private Sub MiscSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then CMDOK_Click(sender, e)
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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New MiscSaleDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MiscSale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then chkchange.CheckState = CheckState.Checked
    End Sub

    Private Sub MiscSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MISC SALE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            If FRMSTRING = "COMMISSION" Then
                Me.Text = "Commission Invoice"
            Else
                Me.Text = "Misc Sale Invoice"
            End If

            'RECOMMENDED BY ASHOK BHAI
            If UserName <> "Admin" Then LBLBAL.Visible = False
            If ClientName = "KHANNA" Then
                CMBTOUR.Visible = True
                LBLTOUR.Visible = True
            End If


            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If



                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsMiscSale()

                'TEMPBOOKINGNO = dr_auto("BOOKING_NO")
                'SALEregid = dr_auto("BOOKING_SALEREGISTERID")
                ALPARAVAL.Add(TEMPBOOKINGNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtbookingno.Text = TEMPBOOKINGNO
                        TXTSTATECODE.Text = dr("STATECODE")

                        TEMPBOOKINGINITIALS = dr("PURBILLINITIALS")
                        BOOKINGDATE.Text = Format(Convert.ToDateTime(dr("BOOKING_DATE")), "dd/MM/yyyy")
                        DDATE = BOOKINGDATE.Text

                        cmbregister.Text = Convert.ToString(dr("PURREG"))
                        CMBACCCODE.Text = Convert.ToString(dr("PURCODE"))
                        CMBNAME.Text = Convert.ToString(dr("PURNAME"))
                        CMBGUESTNAME.Text = Convert.ToString(dr("GUESTNAME"))
                        CMBPURNAME.Text = Convert.ToString(dr("NAME"))
                        CMBTOUR.Text = Convert.ToString(dr("TOURNAME"))
                        'If dr("TOURNAME") <> "" Then CMBTOUR.Enabled = False
                        txtrefno.Text = dr("REFNO")

                        'PURCHASE VALUES
                        TXTFINALPURAMT.Text = dr("FINALPURAMT")
                        TXTDISCRECDPER.Text = dr("DISCRECDPER")
                        TXTDISCRECDRS.Text = dr("DISCRECDRS")
                        TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                        TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                        TXTPURTDSPER.Text = dr("PURTDSPER")
                        TXTPURTDSRS.Text = dr("PURTDSRS")
                        TXTEXTRACHGS.Text = dr("PUREXTRACHGS")
                        TXTSUBTOTAL.Text = dr("PURSUBTOTAL")
                        'TXTEXTRACHGS.Text = dr("EXTRACHGS")
                        CMBPURTAX.Text = dr("PURTAXNAME")
                        TXTPURTAX.Text = dr("PURTAX")

                        If CMBPURTAX.Text.Trim <> "" Then
                            Dim OBJCMNN As New ClsCommon
                            Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                            If DTN.Rows.Count > 0 Then
                                If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                    TXTPURTAX.ReadOnly = False
                                    TXTPURTAX.Enabled = True
                                End If
                            End If
                        End If

                        CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                        TXTPURADDTAX.Text = dr("PURADDTAX")


                        If CMBPURADDTAX.Text.Trim <> "" Then
                            Dim OBJCMNN As New ClsCommon
                            Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                            If DTN.Rows.Count > 0 Then
                                If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                    TXTPURADDTAX.ReadOnly = False
                                    TXTPURADDTAX.Enabled = True
                                End If
                            End If
                        End If

                        CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                        If dr("PUROTHERCHGS") > 0 Then
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                            CMBPURADDSUB.Text = "Add"
                        Else
                            TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                            CMBPURADDSUB.Text = "Sub."
                        End If
                        txtroundoff.Text = dr("PURROUNDOFF")


                        CMBBOOKEDBY.Text = dr("BOOKEDBY")
                        CMBSOURCE.Text = dr("SOURCE")

                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                        TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))


                        TXTPROFORMANO.Text = Val(dr("PROFORMANO"))
                        TXTPROFORMAREGNAME.Text = dr("PROFORMAREGNAME")


                        TXTPURAMTPAID.Text = dr("PURAMTPAID")
                        TXTPUREXTRAAMT.Text = dr("PUREXTRAAMT")
                        TXTPURRETURN.Text = dr("PURRETURN")
                        TXTPURBAL.Text = dr("PURBAL")
                        TXTBAL.Text = dr("PURBAL")

                        If Val(dr("PURAMTPAID")) > 0 Or Val(dr("PUREXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBRECD.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(dr("PURRETURN")) > 0 Then
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

                        chkdispute.Checked = Convert.ToBoolean(dr("DISPUTE"))
                        CHKBILLCHECK.Checked = Convert.ToBoolean(dr("BILLCHECKED"))
                        CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))
                        CMBHSNITEMDESC.Text = dr("ITEMDESC")
                        TXTHSNCODE.Text = dr("HSNCODE")

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
                        TXTCESSPER.Text = dr("CESSPER")
                        TXTCESSAMT.Text = dr("CESSAMT")
                        TXTBILLNO.Text = dr("BILLNO")

                        'MsgBox(Convert.ToByte(dr("GRIDCANCELLED")))
                        Dim DFROM As String = Format(Convert.ToDateTime(dr("DFROM").ToString).Date, "dd/MM/yyyy")
                        Dim DTO As String = Format(Convert.ToDateTime(dr("DTO").ToString).Date, "dd/MM/yyyy")
                        If Convert.ToDateTime(DFROM).Date = "01/01/1900" Then DFROM = "__/__/____"
                        If Convert.ToDateTime(DTO).Date = "01/01/1900" Then DTO = "__/__/____"

                        GRIDTRANS.Rows.Add(dr("GRIDSRNO").ToString, dr("PARTICULARS").ToString, dr("GRIDDESC").ToString, dr("QTY").ToString, Format(Val(dr("RATE").ToString), "0.00"), DFROM, DTO, Format(Val(dr("TOTAL").ToString), "0.00"), Val(dr("FROMNO")), dr("FROMINITIALS"), dr("FROMTYPE"))

                        'EINVOICE
                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If
                    Next

                    GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" MISCSALMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, MISCSALMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, MISCSALMASTER_UPLOAD.BOOKING_NAME AS NAME, MISCSALMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, MISCSALMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " MISCSALMASTER_UPLOAD INNER JOIN MISCSALMASTER ON MISCSALMASTER_UPLOAD.BOOKING_NO = MISCSALMASTER.BOOKING_NO AND MISCSALMASTER_UPLOAD.BOOKING_CMPID = MISCSALMASTER.BOOKING_CMPID AND MISCSALMASTER_UPLOAD.BOOKING_LOCATIONID = MISCSALMASTER.BOOKING_LOCATIONID AND MISCSALMASTER_UPLOAD.BOOKING_YEARID = MISCSALMASTER.BOOKING_YEARID AND MISCSALMASTER_UPLOAD.BOOKING_PURREGID = MISCSALMASTER.BOOKING_PURCHASEREGISTERID ", " AND MISCSALMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND MISCSALMASTER.BOOKING_CMPID = " & CmpId & " AND MISCSALMASTER.BOOKING_PURCHASEREGISTERID = " & PURregid & " AND MISCSALMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND MISCSALMASTER.BOOKING_YEARID = " & YearId & " ORDER BY MISCSALMASTER_UPLOAD.BOOKING_GRIDSRNO")
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                        Next
                    End If

                    'Dim dttable As DataTable = OBJCMN.search(" MISCSALMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, MISCSALMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, MISCSALMASTER_UPLOAD.BOOKING_NAME AS NAME, MISCSALMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, MISCSALMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH", "", " REGISTERMASTER INNER JOIN PURCHASEMASTER ON REGISTERMASTER.register_id = PURCHASEMASTER.BILL_REGISTERID AND REGISTERMASTER.register_cmpid = PURCHASEMASTER.BILL_CMPID AND REGISTERMASTER.register_locationid = PURCHASEMASTER.BILL_LOCATIONID AND REGISTERMASTER.register_yearid = PURCHASEMASTER.BILL_YEARID LEFT OUTER JOIN PURCHASEMASTER_UPLOAD ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_UPLOAD.BILL_NO AND PURCHASEMASTER.BILL_CMPID = PURCHASEMASTER_UPLOAD.BILL_CMPID AND PURCHASEMASTER.BILL_LOCATIONID = PURCHASEMASTER_UPLOAD.BILL_LOCATIONID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_UPLOAD.BILL_YEARID AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_UPLOAD.BILL_REGISTERID", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_UPLOAD.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_UPLOAD.BILL_CMPID = " & CmpId & " AND PURCHASEMASTER_UPLOAD.BILL_LOCATIONID = " & Locationid & " AND PURCHASEMASTER_UPLOAD.BILL_YEARID = " & YearId)
                    'If dttable.Rows.Count > 0 Then
                    '    For Each DTR2 As DataRow In dttable.Rows
                    '        gridupload.Rows.Add(DTR2("GRIDSRNO"), DTR2("REMARKS"), DTR2("NAME"), DTR2("IMGPATH"), DTR2("NEWIMGPATH"))
                    '    Next
                    'End If

                    PURCHASETOTAL()
                    Dim clscommon As New ClsCommon
                    Dim dtID As DataTable
                    dtID = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                    If dtID.Rows.Count > 0 Then
                        PURregabbr = dtID.Rows(0).Item(0).ToString
                        PURreginitial = dtID.Rows(0).Item(1).ToString
                        PURregid = dtID.Rows(0).Item(2)
                    Else
                        MsgBox("Register Not Present, Add New from Master Module")
                        Exit Sub
                    End If
                    cmbregister.Enabled = False

                Else
                    clear()

                    edit = False
                    CMBNAME.Focus()
                End If
                chkchange.CheckState = CheckState.Checked
                GETBALANCE()
            End If
            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLEINVGENERATED.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        If CMBGUESTNAME.Text.Trim = "" Then fillname(CMBGUESTNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        If cmbregister.Text.Trim = "" Then
            'OPEN VISA SALE REGISTER
            If ClientName = "VINAYAK" Then
                fillregister(cmbregister, " and register_type = 'SALE' and register_name not in ('AIRLINE SALE REGISTER', 'INTAIRLINE SALE REGISTER', 'INTERNATIONAL SALE REGISTER', 'RAILWAY SALE REGISTER', 'PACKAGE SALE REGISTER', 'SALE REGISTER', 'TRANSFER SALE REGISTER','VEHICLE SALE REGISTER', 'OTHER SALE REGISTER')")
            Else
                fillregister(cmbregister, " and register_type = 'SALE' and register_name not in ('AIRLINE SALE REGISTER', 'INTAIRLINE SALE REGISTER', 'INTERNATIONAL SALE REGISTER', 'RAILWAY SALE REGISTER', 'PACKAGE SALE REGISTER', 'SALE REGISTER', 'TRANSFER SALE REGISTER','VEHICLE SALE REGISTER', 'VISA SALE REGISTER', 'OTHER SALE REGISTER')")
            End If
        End If
        If CMBPUROTHERCHGS.Text.Trim = "" Then fillname(CMBPUROTHERCHGS, edit, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')")
        If CMBPURTAX.Text.Trim = "" Then filltax(CMBPURTAX, edit)
        If CMBPURADDTAX.Text.Trim = "" Then filltax(CMBPURADDTAX, edit)
        If CMBSOURCE.Text.Trim = "" Then FILLSOURCE(CMBSOURCE, edit)
        If CMBBOOKEDBY.Text.Trim = "" Then FILLBOOKEDBY(CMBBOOKEDBY, edit)
        If CMBTOUR.Text.Trim = "" Then FILLTOURNAME(CMBTOUR, edit, "")
        If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        If CMBPURNAME.Text.Trim = "" Then fillname(CMBPURNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
        If CMBPARTICULARS.Text.Trim = "" Then FILLPARTICULAR(CMBPARTICULARS, edit)
    End Sub

    Private Sub MiscSale_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TXTPARTICULARS.Visible = False

        If ALLOWEINVOICE = True Then TOOLEINV.Visible = True

        If ClientName = "ELYSIUM" Or ClientName = "7HOSPITALITY" Or ClientName = "ARHAM" Then
            Me.Close()
            Exit Sub
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
            LBLSTATECODE.Visible = False
            TXTSTATECODE.Visible = False


        End If
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub clear()
        Try

            If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "SKYMAPS" Or ClientName = "BARODA" Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "KHANNA" Then
                txtbookingno.ReadOnly = False
                txtbookingno.Enabled = True
            End If
            LBLACCBAL.ForeColor = Color.Green
            TXTPROFORMANO.Clear()

            TXTCOPY.Clear()
            tstxtbillno.Clear()

            CMBNAME.Text = ""
            CMBGUESTNAME.Text = ""
            CMBPURNAME.Text = ""
            TXTBILLNO.Clear()
            CMBACCCODE.Text = ""
            LBLACCBAL.Text = 0.0

            BOOKINGDATE.Text = Mydate

            cmdshowdetails.Visible = False
            PBRECD.Visible = False
            PBPAID.Visible = False
            PBDN.Visible = False
            PBCN.Visible = False
            PBlock.Visible = False
            lbllocked.Visible = False
            lblcancelled.Visible = False
            PBCancelled.Visible = False
            LBLEINVGENERATED.Visible = False
            txtrefno.Clear()
            CMBTOUR.Text = ""
            CMBTOUR.Enabled = True

            'transaction grid
            TXTSRNO.Clear()
            TXTPARTICULARS.Clear()
            CMBPARTICULARS.Text = ""
            TXTGRIDDESC.Clear()
            TXTQTY.Text = "1"
            TXTRATE.Text = "0.00"
            DTPFROM.Text = "__/__/____"
            DTPTO.Text = "__/__/____"
            TXTTOTAL.Text = "0.00"
            TXTMARKUPINCOME.Clear()
            GRIDTRANS.RowCount = 0
            GRIDTRANS.ClearSelection()

            'scan docs grid

            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            gridupload.RowCount = 0
            txtimgpath.Clear()
            TXTNEWIMGPATH.Clear()
            TXTFILENAME.Clear()
            PBSoftCopy.ImageLocation = ""
            gridupload.ClearSelection()

            'tax grid


            TBDETAILS.SelectedIndex = 0
            TXTFINALPURAMT.Text = 0.0
            TXTDISCRECDPER.Text = 0.0
            TXTDISCRECDRS.Text = 0.0
            TXTCOMMRECDPER.Text = 0.0
            TXTCOMMRECDRS.Text = 0.0
            TXTPURTDSPER.Text = 0.0
            TXTPURTDSRS.Text = 0.0
            TXTSUBTOTAL.Text = 0.0
            TXTEXTRACHGS.Text = 0.0

            CMBPURTAX.Text = ""
            TXTPURTAX.Text = 0.0

            CMBPURADDTAX.Text = ""
            TXTPURADDTAX.Text = 0.0

            TXTPURTAX.ReadOnly = True
            TXTPURTAX.Enabled = False
            TXTPURADDTAX.ReadOnly = True
            TXTPURADDTAX.Enabled = False

            CMBPUROTHERCHGS.Text = ""
            TXTPUROTHERCHGS.Text = 0.0

            txtroundoff.Text = 0.0
            txtgrandtotal.Text = 0.0
            TXTBAL.Text = 0.0

            CMBBOOKEDBY.Text = ""
            CMBSOURCE.Text = ""
            TXTSPECIALREMARKS.Clear()
            TXTBOOKINGDESC.Clear()
            If ClientName = "CLASSIC" Then
                txtremarks.Text = "Room bill to CLASSIC TRAVEL SHOPPE PVT. LTD. & Extra or Direct Payment if any, payment to be collected directly from Guest."
            ElseIf ClientName = "ELYSIUM" Then
                txtremarks.Text = "Room bill to ELYSIUM RESORTS & Extra or Direct Payment if any, payment to be collected directly from Guest."
            ElseIf ClientName = "TOPCOMM" Or ClientName = "APSARA" Then
                txtremarks.Clear()
            Else
                txtremarks.Text = "As per Standard Rates billed to " & CmpName & " & Extra if any, payment to be collected direct from Guest."
            End If
            txtinwords.Clear()

            chkdispute.CheckState = CheckState.Unchecked
            CHKBILLCHECK.CheckState = CheckState.Unchecked
            CHKREVERSE.CheckState = CheckState.Unchecked

            If UserName = "Admin" Or ClientName = "KHANNA" Then
                CMBBOOKEDBY.Enabled = True
            Else
                CMBBOOKEDBY.Enabled = False
                CMBBOOKEDBY.Text = UserName
            End If

            EP.Clear()


            gridDoubleClick = False

            If GRIDTRANS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDTRANS.Rows(GRIDTRANS.RowCount - 1).Cells(GTRANSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
            getmaxno_PURCHASEmaster()
            TXTSTATECODE.Clear()
            TXTHSNCODE.Clear()
            'CMBHSNITEMDESC.SelectedIndex = 0
            TXTCGSTPER.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTPER.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTPER.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            TXTCESSPER.Text = 1
            TXTCESSAMT.Text = 0.0

            'EINVOICE 
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Now.Date
            PBQRCODE.Image = Nothing

            CHKMANUAL.CheckState = CheckState.Unchecked
            If ClientName = "TRISHA" Then CHKTAXSERVCHGS.CheckState = CheckState.Checked

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        cmbregister.Enabled = True
        edit = False
        cmbregister.Focus()
    End Sub

    Sub getmaxno_PURCHASEmaster()
        Dim DTTABLE As New DataTable
        If ClientName = "UNIGO" Or ClientName = "TRAVELBRIDGE" Or ClientName = "TRAVIZIA" Then
            DTTABLE = getmax(" isnull(MAX(T.BOOKINGNO),0) + 1 ", " (SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM AIRLINEBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOTELBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM HOLIDAYPACKAGEMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM CARBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM INTERNATIONALBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM MISCSALMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM RAILBOOKINGMASTER WHERE BOOKING_YEARID = " & YearId & " UNION ALL SELECT MAX(BOOKING_NO) AS BOOKINGNO FROM VISABOOKING WHERE BOOKING_YEARID = " & YearId & " ) AS T ", "")
        Else
            DTTABLE = getmax(" isnull(max(BOOKING_NO),0) + 1 ", "MISCSALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BOOKING_PURCHASEREGISTERID AND REGISTER_CMPID = BOOKING_CMPID AND REGISTER_LOCATIONID = BOOKING_LOCATIONID AND REGISTER_YEARID = BOOKING_YEARID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'SALE' AND BOOKING_cmpid=" & CmpId & " AND BOOKING_LOCATIONid=" & Locationid & " AND BOOKING_YEARid=" & YearId)
        End If
        If DTTABLE.Rows.Count > 0 Then txtbookingno.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
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

    Private Sub cmbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBNAME.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
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

    Private Sub CMBACCCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Enter
        Try
            If CMBACCCODE.Text.Trim = "" Then fillACCCODE(CMBACCCODE, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'")
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

    Private Sub CMBACCCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBACCCODE.KeyPress
        enterkeypress(e, Me)
    End Sub

    Private Sub CMBACCCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBACCCODE.Validated
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

    Sub GETBALANCE()
        Try

            Dim USERACCOUNTSADD, USERACCOUNTSEDIT, USERACCOUNTSVIEW, USERACCOUNTSDELETE As Boolean
            Dim DTACCOUNTSROW() As DataRow
            DTACCOUNTSROW = USERRIGHTS.Select("FormName = 'ACCOUNT REPORTS'")
            USERACCOUNTSADD = DTACCOUNTSROW(0).Item(1)
            USERACCOUNTSEDIT = DTACCOUNTSROW(0).Item(2)
            USERACCOUNTSVIEW = DTACCOUNTSROW(0).Item(3)
            USERACCOUNTSDELETE = DTACCOUNTSROW(0).Item(4)

            LBLACCBAL.Text = "0.00"
            If USERACCOUNTSVIEW = False Then
                LBLACCBAL.Visible = False
            End If

            'SALE BALANCE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("(CASE WHEN DR > 0 THEN CAST(DR AS VARCHAR) + ' Dr'  ELSE CAST(CR AS VARCHAR) + ' Cr' END) AS SALEBAL, ISNULL(ACC_CRLIMIT,0) AS CRLIMIT, (CASE WHEN DR > 0 THEN DR ELSE CR END) AS BALANCE ", "", "  TRIALBALANCE INNER JOIN LEDGERS ON TRIALBALANCE.LEDGERID = LEDGERS.ACC_ID ", " AND NAME = '" & CMBNAME.Text.Trim & "'  AND LEDGERS.ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLACCBAL.Text = DT.Rows(0).Item("SALEBAL")
                If Val(DT.Rows(0).Item("CRLIMIT")) < Val(DT.Rows(0).Item("BALANCE")) And Val(DT.Rows(0).Item("CRLIMIT")) > 0 Then
                    LBLACCBAL.ForeColor = Color.Red
                Else
                    LBLACCBAL.ForeColor = Color.Green
                End If
            End If

            'CR LIMIT OF SALE PARTY
            DT = OBJCMN.search("BOOKING_NO, BOOKING_DATE AS DATE, ISNULL(ACC_CRDAYS,0) AS CRDAYS", "", "MISCSALMASTER INNER JOIN LEDGERS ON ACC_ID = BOOKING_PURLEDGERID AND ACC_CMPID = BOOKING_CMPID AND ACC_LOCATIONID = BOOKING_LOCATIONID AND ACC_YEARID = BOOKING_YEARID", " AND BOOKING_PURBALANCE > 0 AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BOOKING_CMPID = " & CmpId & " AND BOOKING_LOCATIONID = " & Locationid & " AND BOOKING_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("CRDAYS") < DateDiff(DateInterval.Day, Convert.ToDateTime(DTROW("DATE")).Date, Now.Date) And DTROW("CRDAYS") > 0 Then
                        MsgBox("Overdue Outstanding", MsgBoxStyle.Critical)
                        GoTo LINE1
                    End If
                Next
            End If

LINE1:


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        'WRITE SAVE CODE HERE
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            'invoicedesc()
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbregister.Text.Trim)

            If (ClientName = "CLASSIC" And UserName = "Admin") Or ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "NAMASTE" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Then
                alParaval.Add(txtbookingno.Text.Trim)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBPURNAME.Text.Trim)
            'PURCHASE VALUES
            alParaval.Add(Val(TXTFINALPURAMT.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDPER.Text.Trim))
            alParaval.Add(Val(TXTDISCRECDRS.Text.Trim))


            alParaval.Add(Val(TXTCOMMRECDPER.Text.Trim))
            alParaval.Add(Val(TXTCOMMRECDRS.Text.Trim))
            alParaval.Add(Val(TXTPURTDSPER.Text.Trim))
            alParaval.Add(Val(TXTPURTDSRS.Text.Trim))
            'alParaval.Add(Val(TXTPUREXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTEXTRACHGS.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
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

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))
            alParaval.Add(CMBBOOKEDBY.Text.Trim)
            alParaval.Add(CMBSOURCE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBOOKINGDESC.Text.Trim)
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)

            alParaval.Add(txtinwords.Text.Trim)

            alParaval.Add(Val(TXTPURAMTPAID.Text.Trim))
            alParaval.Add(Val(TXTPUREXTRAAMT.Text.Trim))
            alParaval.Add(Val(TXTPURRETURN.Text.Trim))
            alParaval.Add(Val(TXTPURBAL.Text.Trim))


            'FOR DONE
            If lbllocked.Visible = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CHKTAXSERVCHGS.CheckState)
            alParaval.Add(CMBTOUR.Text.Trim)

            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(CHKMANUAL.CheckState)
            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTCESSPER.Text.Trim))
            alParaval.Add(Val(TXTCESSAMT.Text.Trim))

            alParaval.Add(Val(TXTBILLNO.Text.Trim))
            alParaval.Add(Val(TXTPROFORMANO.Text.Trim))
            alParaval.Add(TXTPROFORMAREGNAME.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim PARTICULARS As String = ""
            Dim CMBPARTICULARS As String = ""
            Dim GRIDDESC As String = ""
            Dim QTY As String = ""
            Dim RATE As String = ""
            Dim DFROM As String = ""
            Dim DTO As String = ""
            Dim TOTAL As String = ""
            Dim FROMNO As String = ""
            Dim FROMINITIALS As String = ""
            Dim FROMTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GTRANSRNO.Index).Value.ToString
                        PARTICULARS = row.Cells(GTRANPARTICULARS.Index).Value.ToString
                        CMBPARTICULARS = row.Cells(GTRANPARTICULARS.Index).Value.ToString
                        GRIDDESC = row.Cells(GTRANSDESC.Index).Value.ToString
                        QTY = row.Cells(GTRANQTY.Index).Value.ToString
                        RATE = row.Cells(GTRANRATE.Index).Value.ToString
                        If row.Cells(GTRANFROM.Index).Value.ToString <> "__/__/____" Then
                            DFROM = Format(Convert.ToDateTime(row.Cells(GTRANFROM.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            DFROM = ""
                        End If
                        If row.Cells(GTRANTO.Index).Value.ToString <> "__/__/____" Then
                            DTO = Format(Convert.ToDateTime(row.Cells(GTRANTO.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            DTO = ""
                        End If
                        TOTAL = row.Cells(GTRANTOTAL.Index).Value
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMINITIALS = row.Cells(GFROMINITIALS.Index).Value
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GTRANSRNO.Index).Value.ToString
                        PARTICULARS = PARTICULARS & "|" & row.Cells(GTRANPARTICULARS.Index).Value.ToString
                        CMBPARTICULARS = PARTICULARS & "|" & row.Cells(GTRANPARTICULARS.Index).Value.ToString

                        GRIDDESC = GRIDDESC & "|" & row.Cells(GTRANSDESC.Index).Value.ToString
                        QTY = QTY & "|" & row.Cells(GTRANQTY.Index).Value.ToString
                        RATE = RATE & "|" & row.Cells(GTRANRATE.Index).Value.ToString
                        If row.Cells(GTRANFROM.Index).Value.ToString <> "__/__/____" Then
                            DFROM = DFROM & "|" & Format(Convert.ToDateTime(row.Cells(GTRANFROM.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            DFROM = DFROM & "|"
                        End If
                        If row.Cells(GTRANTO.Index).Value.ToString <> "__/__/____" Then
                            DTO = DTO & "|" & Format(Convert.ToDateTime(row.Cells(GTRANTO.Index).Value).Date, "MM/dd/yyyy")
                        Else
                            DTO = DTO & "|"
                        End If
                        TOTAL = TOTAL & "|" & row.Cells(GTRANTOTAL.Index).Value
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMINITIALS = FROMINITIALS & "|" & row.Cells(GFROMINITIALS.Index).Value
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PARTICULARS)
            alParaval.Add(CMBPARTICULARS)
            alParaval.Add(GRIDDESC)
            alParaval.Add(QTY)
            alParaval.Add(RATE)
            alParaval.Add(DFROM)
            alParaval.Add(DTO)
            alParaval.Add(TOTAL)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMINITIALS)
            alParaval.Add(FROMTYPE)


            alParaval.Add(txtrefno.Text.Trim)
            alParaval.Add(chkdispute.CheckState)
            alParaval.Add(CHKBILLCHECK.CheckState)

            alParaval.Add(ClientName)

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
            alParaval.Add(CMBGUESTNAME.Text.Trim)


            Dim OBJBOOKING As New ClsMiscSale()
            OBJBOOKING.alParaval = alParaval

            If edit = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTNO As DataTable = OBJBOOKING.SAVE()
                txtbookingno.Text = DTNO.Rows(0).Item(0)

                If DIRECTUPLOAD = False Then
                    MessageBox.Show("Details Added")
                    PRINTREPORT(DTNO.Rows(0).Item(0))
                End If

            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPBOOKINGNO)

                IntResult = OBJBOOKING.UPDATE()

                MessageBox.Show("Details Updated")
                PRINTREPORT(TEMPBOOKINGNO)
                edit = False
                'TEMPMSG = MsgBox("Wish to Print Voucher?", MsgBoxStyle.YesNo)
                'If TEMPMSG = vbYes Then PRINTREPORT(TEMPBOOKINGNO)
            End If


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\MISC\SALE") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\MISC\SALE")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\MISC\SALE") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next


            '***************** AUTO CREATE PURCHASE ENTRY CODE ****************************
            If edit = False And (ClientName = "CLASSIC" Or ClientName = "HEENKAR") Then
                Dim TEMPMSG As Integer = MsgBox("Wish to Create Misc Purchase?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJMISC As New MiscPur
                    OBJMISC.MdiParent = MDIMain
                    OBJMISC.AUTOCREATE = True
                    OBJMISC.TEMPSALENO = Val(txtbookingno.Text.Trim)
                    OBJMISC.TEMPSALEREGNAME = cmbregister.Text.Trim
                    OBJMISC.TEMPMARKUP = Val(TXTMARKUPINCOME.Text.Trim)
                    OBJMISC.Show()
                End If
            End If
            '***************** AUTO CREATE PURCHASE ENTRY CODE ****************************


            If DIRECTUPLOAD = False Then
                clear()
                cmbregister.Enabled = True
                cmbregister.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BOOKNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJINV As New MiscVoucherDesign
                OBJINV.MdiParent = MDIMain
                OBJINV.BOOKINGNO = BOOKNO
                OBJINV.GUESTNAME = CMBNAME.Text.Trim
                OBJINV.SALEREGISTERID = PURregid
                OBJINV.PRINTTAX = CHKTAXPRINT.Checked
                OBJINV.PRINTOTHERCHGS = 0
                OBJINV.FRMSTRING = "INVOICE"
                If ClientName = "UTTARAKHAND" Then OBJINV.SUBJECT = "Invoice No. " & BOOKNO & " Ref No. " & txtrefno.Text.Trim
                OBJINV.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then
                'OPEN VISA SALE REGISTER
                If ClientName = "VINAYAK" Then
                    fillregister(cmbregister, " and register_type = 'SALE' and register_name not in ('AIRLINE SALE REGISTER', 'INTAIRLINE SALE REGISTER', 'INTERNATIONAL SALE REGISTER', 'RAILWAY SALE REGISTER', 'PACKAGE SALE REGISTER', 'SALE REGISTER', 'TRANSFER SALE REGISTER','VEHICLE SALE REGISTER', 'OTHER SALE REGISTER')")
                Else
                    fillregister(cmbregister, " and register_type = 'SALE' and register_name not in ('AIRLINE SALE REGISTER', 'INTAIRLINE SALE REGISTER', 'INTERNATIONAL SALE REGISTER', 'RAILWAY SALE REGISTER', 'PACKAGE SALE REGISTER', 'SALE REGISTER', 'TRANSFER SALE REGISTER','VEHICLE SALE REGISTER', 'VISA SALE REGISTER', 'OTHER SALE REGISTER')")
                End If
            End If
            getmaxno_PURCHASEmaster()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try

            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                clear()
                cmbregister.Text = UCase(cmbregister.Text)

                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_LOCATIONid = " & Locationid & " and register_YEARid = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURregabbr = dt.Rows(0).Item(0).ToString
                    PURreginitial = dt.Rows(0).Item(1).ToString
                    PURregid = dt.Rows(0).Item(2)
                    getmaxno_PURCHASEmaster()
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

    Private Sub CMBPURTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURTAX.Validated
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
        Catch ex As Exception
            Throw ex
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

    Private Sub CMBPURADDTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURADDTAX.Validated
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPURADDTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURADDTAX.Validating
        Try
            If CMBPURADDTAX.Text.Trim <> "" Then TAXvalidate(CMBPURADDTAX, e, Me)
            PURCHASETOTAL()
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

    Private Sub CMBPUROTHERCHGS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPUROTHERCHGS.Validating
        Try
            If CMBPUROTHERCHGS.Text.Trim <> "" Then namevalidate(CMBPUROTHERCHGS, CMBOTHERCHGSCODE, e, Me, TXTOTHERCHGSADD, " AND (GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT INCOME')", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPUROTHERCHGS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPUROTHERCHGS.KeyPress
        numdotkeypress(e, TXTPUROTHERCHGS, Me)
    End Sub

    Private Sub TXTPUROTHERCHGS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPUROTHERCHGS.Validated
        PURCHASETOTAL()
    End Sub

    Sub PURCHASETOTAL()

        TXTSUBTOTAL.Text = 0.0
        'TXTPURTAX.Text = 0.0
        'TXTPURADDTAX.Text = 0.0
        If Val(TXTDISCRECDPER.Text.Trim) > 0 Then TXTDISCRECDRS.Text = 0.0
        If Val(TXTCOMMRECDPER.Text.Trim) > 0 Then TXTCOMMRECDRS.Text = 0.0
        If Val(TXTPURTDSPER.Text.Trim) > 0 Then TXTPURTDSRS.Text = 0.0

        txtroundoff.Text = 0.0
        txtgrandtotal.Text = 0.0
        TXTFINALPURAMT.Text = 0.0
        txtinwords.Clear()
        TXTCESSAMT.Clear()

        If GRIDTRANS.RowCount > 0 Then

            For Each row As DataGridViewRow In GRIDTRANS.Rows
                'row.Cells(GTRANTOTAL.Index).Value = Format(Val(row.Cells(GTRANQTY.Index).Value) * Val(row.Cells(GTRANRATE.Index).Value), "0.00")
                If Val(row.Cells(GTRANTOTAL.Index).Value) > 0 Then TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text) + Val(row.Cells(GTRANTOTAL.Index).EditedFormattedValue), "0.00")

            Next

            'WORKING CODE TILL 24-05-207, NEW CODE WRITTEN BELOW AS PER AERO N ALL
            'If CHKREVERSE.Checked = True Then
            '    Dim objclscmn As New ClsCommonMaster
            '    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            '    If dt1.Rows.Count > 0 Then
            '        TXTFINALPURAMT.Text = Format((Val(TXTFINALPURAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
            '    End If
            'Else
            '    TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text.Trim), "0.00")
            'End If


            If CHKREVERSE.Checked = True Then
                If CHKTAXSERVCHGS.Checked = False Then
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTFINALPURAMT.Text = Format((Val(TXTFINALPURAMT.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    Else
                        TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text.Trim), "0.00")
                    End If
                Else
                    Dim objclscmn As New ClsCommonMaster
                    Dim dt1 As DataTable = objclscmn.search("TAX_NAME ,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        TXTOURCOMMRS.Text = Format((Val(TXTOURCOMMRS.Text.Trim) / (Val(dt1.Rows(0).Item(1)) + 100) * 100), "0.00")
                    End If
                    TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text.Trim), "0.00")
                End If
            Else
                TXTFINALPURAMT.Text = Format(Val(TXTFINALPURAMT.Text.Trim), "0.00")
            End If


            If Val(TXTDISCRECDPER.Text) > 0 Then
                TXTDISCRECDRS.Text = Format((Val(TXTDISCRECDPER.Text) * Val(TXTFINALPURAMT.Text)) / 100, "0.00")
            Else
                'TXTDISCRECDPER.Text = Format((Val(TXTDISCRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
            End If

            TXTSUBTOTAL.Text = Format(Val(TXTFINALPURAMT.Text) - Val(TXTDISCRECDRS.Text) + Val(TXTEXTRACHGS.Text), "0.00")

            If Val(TXTCOMMRECDPER.Text) > 0 Then
                TXTCOMMRECDRS.Text = Format((Val(TXTCOMMRECDPER.Text) * Val(TXTFINALPURAMT.Text)) / 100, "0.00")
            Else
                'TXTCOMMRECDPER.Text = Format((Val(TXTCOMMRECDRS.Text) * 100) / Val(TXTTOTALPURAMT.Text), "0.00")
            End If

            If Val(TXTPURTDSPER.Text) > 0 Then
                TXTPURTDSRS.Text = Format((Val(TXTPURTDSPER.Text) * Val(TXTCOMMRECDRS.Text)) / 100, "0.00")
            Else
                ' TXTPURTDSPER.Text = Format((Val(TXTPURTDSRS.Text) * 100) / Val(TXTCOMMRECDRS.Text), "0.00")
            End If

            'If ClientName = "AMIGO" Then
            '    TXTSUBTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTEXTRACHGS.Text.Trim), "0.00")
            'Else
            '    TXTSUBTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) - Val(TXTCOMMRECDRS.Text) + Val(TXTEXTRACHGS.Text.Trim), "0.00")
            'End If


            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If Convert.ToDateTime(BOOKINGDATE.Text).Date >= "07/01/2017" Then
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                        TXTCGSTAMT.Text = Format((Val(TXTCGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        TXTSGSTAMT.Text = Format((Val(TXTSGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        TXTIGSTAMT.Text = Format((Val(TXTIGSTPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
                        If APPLYCESS = True And CMBNAME.Text.Trim <> "" Then
                            'IF GSTNO IS BLANK THEN APPLYCESS
                            Dim DTCESS As DataTable = objclscommon.search("ISNULL(ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                            If DTCESS.Rows(0).Item("GSTIN") = "" Then TXTCESSAMT.Text = Format((Val(TXTCESSPER.Text) * Val(TXTEXTRACHGS.Text)) / 100, "0.00")
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


            dt = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                If Val(dt.Rows(0).Item("TAX")) > 0 Then
                    If Convert.ToDateTime(BOOKINGDATE.Text).Date >= "07/01/2017" Then TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim))) / 100, "0.00") Else TXTPURTAX.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTEXTRACHGS.Text.Trim) / 100), "0.00")
                End If
            End If



            'for add tax
            dt = objclscommon.search("TAX_NAME,tax_tax AS TAX", "", "TAXMaster", " and TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
            If CHKTAXSERVCHGS.CheckState = CheckState.Checked Then
                If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then TXTPURADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTEXTRACHGS.Text))) / 100, "0.00")
            Else
                If dt.Rows.Count > 0 Then If Val(dt.Rows(0).Item("TAX")) > 0 Then TXTPURADDTAX.Text = Format((Val(dt.Rows(0).Item(1)) * (Val(TXTSUBTOTAL.Text))) / 100, "0.00")
            End If


            If CMBPURADDSUB.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTPURTAX.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTPURTAX.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text) + Val(TXTPUROTHERCHGS.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format((Val(TXTSUBTOTAL.Text) + Val(TXTPURTAX.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(TXTPURTAX.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + +Val(TXTIGSTAMT.Text) + Val(TXTCESSAMT.Text.Trim) + Val(TXTPURADDTAX.Text)) - Val(TXTPUROTHERCHGS.Text)), "0.00")
            End If

            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

        End If
    End Sub

    Private Sub txtroundoff_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtroundoff.Validated
        PURCHASETOTAL()
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

    Private Sub TXTTOTAL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTAL.Validated
        If (TXTPARTICULARS.Text.Trim <> "" Or CMBPARTICULARS.Text.Trim <> "") And ((Val(TXTQTY.Text) > 0 And Val(TXTRATE.Text) > 0) Or (DTPFROM.Text.Trim <> "__/__/__" Or DTPTO.Text.Trim <> "__/__/__")) Then
            If Val(TXTQTY.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 Then TXTTOTAL.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00") Else TXTTOTAL.Text = Format(Val(TXTTOTAL.Text.Trim), "0.00")
            If TXTPARTICULARS.Text.Trim = "" And CMBPARTICULARS.Text.Trim <> "" Then TXTPARTICULARS.Text = CMBPARTICULARS.Text.Trim
            fillgrid()
            PURCHASETOTAL()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Private Sub TXTVISAINCOME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMARKUPINCOME.Validating
        INCOMEMARKUPGROUP.Visible = False
        TXTDISCRECDPER.Focus()
    End Sub

    Private Sub TXTTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOTAL.Validating
        If Val(TXTTOTAL.Text.Trim) > 0 And (ClientName = "CLASSIC" Or ClientName = "HEENKAR") Then
            INCOMEMARKUPGROUP.Visible = True
            TXTMARKUPINCOME.Focus()
        End If

    End Sub

    Sub fillgrid()

        GRIDTRANS.Enabled = True
        If gridDoubleClick = False Then
            Dim DFROM As String = DTPFROM.Text.Trim
            Dim DTO As String = DTPTO.Text.Trim
            If DFROM <> "__/__/____" Then DFROM = Format(Convert.ToDateTime(DTPFROM.Text.Trim).Date, "dd/MM/yyyy")
            If DTO <> "__/__/____" Then DTO = Format(Convert.ToDateTime(DTPTO.Text.Trim).Date, "dd/MM/yyyy")
            GRIDTRANS.Rows.Add(Val(TXTSRNO.Text.Trim), CMBPARTICULARS.Text.Trim, TXTGRIDDESC.Text.Trim, Val(TXTQTY.Text.Trim), Format(Val(TXTRATE.Text.Trim), "0.00"), DFROM, DTO, Format(Val(TXTTOTAL.Text.Trim), "0.00"), 0, "", "")
            getsrno(GRIDTRANS)
        ElseIf gridDoubleClick = True Then
            GRIDTRANS.Item(GTRANSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDTRANS.Item(GTRANPARTICULARS.Index, temprow).Value = TXTPARTICULARS.Text.Trim
            GRIDTRANS.Item(GTRANPARTICULARS.Index, temprow).Value = CMBPARTICULARS.Text.Trim
            GRIDTRANS.Item(GTRANSDESC.Index, temprow).Value = TXTGRIDDESC.Text.Trim
            GRIDTRANS.Item(GTRANQTY.Index, temprow).Value = Val(TXTQTY.Text.Trim)
            GRIDTRANS.Item(GTRANRATE.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            If DTPFROM.Text.Trim <> "__/__/____" Then
                GRIDTRANS.Item(GTRANFROM.Index, temprow).Value = Format(Convert.ToDateTime(DTPFROM.Text.Trim).Date, "dd/MM/yyyy")
            Else
                GRIDTRANS.Item(GTRANFROM.Index, temprow).Value = Format(DTPFROM.Text.Trim, "__/__/____")
            End If
            If DTPTO.Text.Trim <> "__/__/____" Then
                GRIDTRANS.Item(GTRANTO.Index, temprow).Value = Format(Convert.ToDateTime(DTPTO.Text.Trim).Date, "dd/MM/yyyy")
            Else
                GRIDTRANS.Item(GTRANTO.Index, temprow).Value = Format(DTPFROM.Text.Trim, "__/__/____")
            End If
            GRIDTRANS.Item(GTRANTOTAL.Index, temprow).Value = Format(Val(TXTTOTAL.Text.Trim), "0.00")

            gridDoubleClick = False
        End If

        GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

        TXTSRNO.Text = GRIDTRANS.RowCount + 1
        'TXTPARTICULARS.Clear()
        CMBPARTICULARS.Text = ""
        TXTGRIDDESC.Clear()
        TXTQTY.Text = 0
        TXTRATE.Text = 0.0
        DTPFROM.Text = "__/__/____"
        DTPTO.Text = "__/__/____"
        TXTTOTAL.Clear()
        CMBPARTICULARS.Focus()
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(GTRANSRNO.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numkeypress(e, TXTQTY, Me)
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub TXTTOTAL_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTAL.KeyPress
        numdotkeypress(e, TXTTOTAL, Me)
    End Sub

    Private Sub TXTQTY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTQTY.Validated
        If Val(TXTQTY.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 Then TXTTOTAL.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        If Val(TXTQTY.Text.Trim) > 0 And Val(TXTRATE.Text.Trim) > 0 Then TXTTOTAL.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
    End Sub

    Private Sub GRIDTRANS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTRANS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTRANS.Item(GTRANSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDTRANS.Item(GTRANSRNO.Index, e.RowIndex).Value.ToString
                TXTPARTICULARS.Text = GRIDTRANS.Item(GTRANPARTICULARS.Index, e.RowIndex).Value.ToString
                CMBPARTICULARS.Text = GRIDTRANS.Item(GTRANPARTICULARS.Index, e.RowIndex).Value.ToString
                TXTGRIDDESC.Text = GRIDTRANS.Item(GTRANSDESC.Index, e.RowIndex).Value.ToString
                TXTQTY.Text = GRIDTRANS.Item(GTRANQTY.Index, e.RowIndex).Value.ToString
                DTPFROM.Text = GRIDTRANS.Item(GTRANFROM.Index, e.RowIndex).Value.ToString
                DTPTO.Text = GRIDTRANS.Item(GTRANTO.Index, e.RowIndex).Value.ToString
                TXTRATE.Text = GRIDTRANS.Item(GTRANRATE.Index, e.RowIndex).Value.ToString
                TXTTOTAL.Text = GRIDTRANS.Item(GTRANTOTAL.Index, e.RowIndex).Value.ToString

                temprow = e.RowIndex
                CMBPARTICULARS.Focus()
            End If
        Catch EX As Exception
            Throw EX
        End Try
    End Sub

    Private Sub GRIDTRANS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTRANS.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                Dim TINDEX As Integer = GRIDTRANS.CurrentRow.Index
                GRIDTRANS.Rows.RemoveAt(TINDEX)
                getsrno(GRIDTRANS)
                PURCHASETOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            EP.SetError(cmbregister, " Select Register Type")
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


        If ALLOWSAMESTATE = True And Val(TXTSTATECODE.Text.Trim) <> Val(CMPSTATECODE) Then
            EP.SetError(CMBNAME, " Booking Of Other State Not Allowed")
            bln = False
        End If

        GETBALANCE()


        If ClientName = "URMI" And txtrefno.Text.Trim.Length = 0 Then
            EP.SetError(txtrefno, "Enter Ref No")
            bln = False
        End If

        'If LBLPURBAL.ForeColor = Color.Red Then
        '    Dim temppurchasebal As Integer = MsgBox("Amt Exceeds Cr Limit, wish to continue?", MsgBoxStyle.YesNo)
        '    If temppurchasebal = 7 Then
        '        EP.SetError(LBLPURBAL, "Amt Exceeds Cr Limit")
        '        bln = False
        '    End If
        'End If

        If LBLACCBAL.ForeColor = Color.Red Then
            If ClientName = "AMIGO" Then
                EP.SetError(CMBNAME, "Amt Exceeds Cr Limit")
            Else
                EP.SetError(LBLACCBAL, "Amt Exceeds Cr Limit")
            End If
            bln = False
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

            'If ClientName <> "ELYSIUM" Then
            '    DT = OBJCMN.search(" ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBPURNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count = 0 Then
            '        EP.SetError(CMBPURNAME, "Change Name")
            '        bln = False
            '    End If
            'End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Fill Account Name ")
                bln = False
            End If
        End If
        '***************************************************


        If (ClientName = "CLASSIC" And UserName = "Admin" And edit = False) Or ((ClientName = "GLOBE" Or ClientName = "MILONI" Or ClientName = "BARODA" Or ClientName = "SKYMAPS" Or ClientName = "NAMASTE") And edit = False) Then
            If Val(txtbookingno.Text.Trim) >= 0 Then
                Dim OBJC As New ClsCommon
                Dim DT1 As DataTable = OBJC.search(" BOOKING_NO AS BOOKINGNO ", "", " MISCSALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BOOKING_PURCHASEREGISTERID", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " and BOOKING_yearid=" & YearId)
                If DT1.Rows.Count > 0 Then
                    EP.SetError(txtbookingno, "Booking No Already Exists !")
                    bln = False
                    txtbookingno.Clear()
                    txtbookingno.Focus()
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

        If Val(txtgrandtotal.Text.Trim) = 0 Then
            EP.SetError(txtgrandtotal, "Amount cannot be 0")
            bln = False
        End If

        If Val(TXTFINALPURAMT.Text.Trim) = 0 Then
            EP.SetError(TXTFINALPURAMT, "Amount Cannot be 0")
            bln = False
        End If

        If GRIDTRANS.RowCount = 0 Then
            EP.SetError(TXTTOTAL, "Enter Room Details")
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

            If lblcancelled.Visible = True Then
                EP.SetError(PBCancelled, " Booking Locked, Booking Cancelled")
                bln = False
            End If
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) = 0 Then
            CMBPUROTHERCHGS.Text = ""
            CMBPURADDSUB.SelectedIndex = 0
        End If

        If Val(TXTPUROTHERCHGS.Text.Trim) > 0 And CMBPUROTHERCHGS.Text.Trim = "" Then
            EP.SetError(TXTPUROTHERCHGS, " Select Expense Type")
            bln = False
        End If

        If ClientName = "CLASSIC" Then
            If UserName <> "Admin" And edit = False Then
                If Convert.ToDateTime(BOOKINGDATE.Text).Date < Now.Date Then
                    EP.SetError(BOOKINGDATE, "Back Date Entry Not Allowed")
                    bln = False
                End If
            End If
        End If


        'If Not datecheck(bookingdate.Value) Then
        '    EP.SetError(bookingdate, "Date Not in Current Accounting Year")
        '    bln = False
        'End If

        Return bln
    End Function

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
        TXTNEWIMGPATH.Text = Application.StartupPath & "\MISC\SALE\" & txtbookingno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
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

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
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

    Private Sub TXTSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If GRIDTRANS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDTRANS.Rows(GRIDTRANS.RowCount - 1).Cells(GTRANSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub DTPFROM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTPFROM.Validating
        If DTPFROM.Text.Trim <> "__/__/____" Then
            Dim dDATE As Date
            Dim bValid As Boolean = Date.TryParse(DTPFROM.Text.Trim, dDATE)
            If Not bValid Then
                MessageBox.Show("Invalid Date Entered")
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub DTPTO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTPTO.Validating
        If DTPTO.Text.Trim <> "__/__/____" Then
            Dim dDATE As Date
            Dim bValid As Boolean = Date.TryParse(DTPTO.Text.Trim, dDATE)
            If Not bValid Then
                MessageBox.Show("Invalid Date Entered")
                e.Cancel = True
                Exit Sub
            End If
        End If

        If DTPFROM.Text <> "__/__/____" And DTPTO.Text <> "__/__/____" Then
            If Convert.ToDateTime(DTPFROM.Text.Trim) > Convert.ToDateTime(DTPTO.Text.Trim) Then
                MessageBox.Show("From Date cannot be greater than to date")
                e.Cancel = True
                Exit Sub
            End If
        End If


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

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            If cmbregister.Text.Trim <> "" Then
                GRIDTRANS.RowCount = 0
                TEMPBOOKINGNO = Val(tstxtbillno.Text)
                TEMPREGNAME = cmbregister.Text.Trim
                If TEMPBOOKINGNO > 0 And PURregid > 0 Then
                    edit = True
                    MiscSale_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
            Else
                MsgBox("SELECT A REGISTER TO EDIT", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCOPY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPY.Validating
        Try
            If edit = True Then
                MsgBox("Copy Allowed only in Fresh mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TXTCOPY.Text.Trim <> "" And cmbregister.Text <> "" Then
                TEMPMSG = MsgBox("Wish to Copy Voucher No " & TXTCOPY.Text.Trim & "?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJBOOKING As New ClsMiscSale()
                    'TEMPBOOKINGNO = dr_auto("BOOKING_NO")
                    'SALEregid = dr_auto("BOOKING_SALEREGISTERID")
                    ALPARAVAL.Add(Val(TXTCOPY.Text.Trim))
                    ALPARAVAL.Add(cmbregister.Text.Trim)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)

                    OBJBOOKING.alParaval = ALPARAVAL
                    Dim dt As DataTable = OBJBOOKING.SELECTBOOKING()


                    If dt.Rows.Count > 0 Then
                        For Each dr As DataRow In dt.Rows
                            TXTSTATECODE.Text = dr("STATECODE")
                            TEMPBOOKINGINITIALS = dr("PURBILLINITIALS")

                            CMBACCCODE.Text = Convert.ToString(dr("PURCODE"))
                            CMBNAME.Text = Convert.ToString(dr("PURNAME"))
                            CMBTOUR.Text = Convert.ToString(dr("TOURNAME"))

                            txtrefno.Text = dr("REFNO")


                            'PURCHASE VALUES
                            TXTFINALPURAMT.Text = dr("FINALPURAMT")
                            TXTDISCRECDPER.Text = dr("DISCRECDPER")
                            TXTDISCRECDRS.Text = dr("DISCRECDRS")
                            TXTCOMMRECDPER.Text = dr("COMMRECDPER")
                            TXTCOMMRECDRS.Text = dr("COMMRECDRS")
                            TXTPURTDSPER.Text = dr("PURTDSPER")
                            TXTPURTDSRS.Text = dr("PURTDSRS")
                            TXTEXTRACHGS.Text = dr("PUREXTRACHGS")
                            TXTSUBTOTAL.Text = dr("PURSUBTOTAL")
                            'TXTEXTRACHGS.Text = dr("EXTRACHGS")
                            CMBPURTAX.Text = dr("PURTAXNAME")
                            TXTPURTAX.Text = dr("PURTAX")

                            If CMBPURTAX.Text.Trim <> "" Then
                                Dim OBJCMNN As New ClsCommon
                                Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                                If DTN.Rows.Count > 0 Then
                                    If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                        TXTPURTAX.ReadOnly = False
                                        TXTPURTAX.Enabled = True
                                    End If
                                End If
                            End If

                            CMBPURADDTAX.Text = dr("PURADDTAXNAME")
                            TXTPURADDTAX.Text = dr("PURADDTAX")


                            If CMBPURADDTAX.Text.Trim <> "" Then
                                Dim OBJCMNN As New ClsCommon
                                Dim DTN As DataTable = OBJCMNN.search(" TAX_TAX AS TAX ", "", " TAXMASTER ", " AND TAX_NAME = '" & CMBPURADDTAX.Text.Trim & "' AND TAX_CMPID = " & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID  =  " & YearId)
                                If DTN.Rows.Count > 0 Then
                                    If Val(DTN.Rows(0).Item("TAX")) = 0 Then
                                        TXTPURADDTAX.ReadOnly = False
                                        TXTPURADDTAX.Enabled = True
                                    End If
                                End If
                            End If

                            CMBPUROTHERCHGS.Text = dr("PUROTHERCHGSNAME")
                            If dr("PUROTHERCHGS") > 0 Then
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS")
                                CMBPURADDSUB.Text = "Add"
                            Else
                                TXTPUROTHERCHGS.Text = dr("PUROTHERCHGS") * (-1)
                                CMBPURADDSUB.Text = "Sub."
                            End If
                            txtroundoff.Text = dr("PURROUNDOFF")


                            CMBBOOKEDBY.Text = dr("BOOKEDBY")
                            CMBSOURCE.Text = dr("SOURCE")

                            txtremarks.Text = Convert.ToString(dr("REMARKS"))
                            TXTBOOKINGDESC.Text = Convert.ToString(dr("BOOKINGDESC"))
                            TXTSPECIALREMARKS.Text = Convert.ToString(dr("SPECIALREMARKS"))

                            CHKTAXSERVCHGS.Checked = Convert.ToBoolean(dr("TAXSERVCHGS"))

                            TXTPURAMTPAID.Text = 0
                            TXTPUREXTRAAMT.Text = 0
                            TXTPURRETURN.Text = 0
                            TXTPURBAL.Text = 0

                            TXTHSNCODE.Text = dr("HSNCODE")

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
                            TXTCESSPER.Text = dr("CESSPER")
                            TXTCESSAMT.Text = dr("CESSAMT")

                            Dim DFROM As String = Format(Convert.ToDateTime(dr("DFROM").ToString).Date, "dd/MM/yyyy")
                            Dim DTO As String = Format(Convert.ToDateTime(dr("DTO").ToString).Date, "dd/MM/yyyy")
                            If Convert.ToDateTime(DFROM).Date = "01/01/1900" Then DFROM = "__/__/____"
                            If Convert.ToDateTime(DTO).Date = "01/01/1900" Then DTO = "__/__/____"

                            GRIDTRANS.Rows.Add(dr("GRIDSRNO").ToString, dr("PARTICULARS").ToString, dr("GRIDDESC").ToString, dr("QTY").ToString, Format(Val(dr("RATE").ToString), "0.00"), DFROM, DTO, Format(Val(dr("TOTAL").ToString), "0.00"), 0, 0, "")

                        Next

                        GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search(" MISCPURMASTER_UPLOAD.BOOKING_GRIDSRNO AS GRIDSRNO, MISCPURMASTER_UPLOAD.BOOKING_REMARKS AS REMARKS, MISCPURMASTER_UPLOAD.BOOKING_NAME AS NAME, MISCPURMASTER_UPLOAD.BOOKING_IMGPATH AS IMGPATH, MISCPURMASTER_UPLOAD.BOOKING_NEWIMGPATH AS NEWIMGPATH ", "", " MISCPURMASTER_UPLOAD INNER JOIN MISCPURMASTER ON MISCPURMASTER_UPLOAD.BOOKING_NO = MISCPURMASTER.BOOKING_NO AND MISCPURMASTER_UPLOAD.BOOKING_CMPID = MISCPURMASTER.BOOKING_CMPID AND MISCPURMASTER_UPLOAD.BOOKING_LOCATIONID = MISCPURMASTER.BOOKING_LOCATIONID AND MISCPURMASTER_UPLOAD.BOOKING_YEARID = MISCPURMASTER.BOOKING_YEARID AND MISCPURMASTER_UPLOAD.BOOKING_PURREGID = MISCPURMASTER.BOOKING_PURCHASEREGISTERID ", " AND MISCPURMASTER.BOOKING_NO = " & TEMPBOOKINGNO & " AND MISCPURMASTER.BOOKING_CMPID = " & CmpId & " AND MISCPURMASTER.BOOKING_PURCHASEREGISTERID = " & PURregid & " AND MISCPURMASTER.BOOKING_LOCATIONID  = " & Locationid & " AND MISCPURMASTER.BOOKING_YEARID = " & YearId & " ORDER BY MISCPURMASTER_UPLOAD.BOOKING_GRIDSRNO")
                        If dttable.Rows.Count > 0 Then
                            For Each DTR As DataRow In dttable.Rows
                                gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                            Next
                        End If

                        PURCHASETOTAL()
                        tstxtbillno.Clear()
                        'cmdok_Click(sender, e)
                    Else
                        clear()
                        edit = False
                        CMBNAME.Focus()
                    End If
                    chkchange.CheckState = CheckState.Checked

                Else
                    MsgBox("Invalid Voucher No.", MsgBoxStyle.Critical)
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

            Dim OBJBOOKING As New MiscSaleDetails
            OBJBOOKING.MdiParent = MDIMain
            OBJBOOKING.Show()
            OBJBOOKING.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBOOKINGNO > 0 Then
                edit = True
                MiscSale_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDTRANS.RowCount = 0 And TEMPBOOKINGNO > 1 Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDTRANS.RowCount = 0
LINE1:
            TEMPBOOKINGNO = Val(txtbookingno.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            getmaxno_PURCHASEmaster()
            Dim MAXNO As Integer = txtbookingno.Text.Trim
            clear()
            If Val(txtbookingno.Text) - 1 >= TEMPBOOKINGNO Then
                edit = True
                MiscSale_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDTRANS.RowCount = 0 And TEMPBOOKINGNO < MAXNO Then
                txtbookingno.Text = TEMPBOOKINGNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub CNNOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CNNOTE.Click
        Try
            If PBPAID.Visible = True Or PBRECD.Visible = True Then
                MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If


            'If PBDN.Visible = True Then
            '    MsgBox("Rec/Pay made, Delete Rec/Pay First", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            'If checknote(GRIDPUR, GPURCANCELLED) = True Then
            '    MsgBox("Booking Locked", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If edit = True Then
                Dim OBJdN As New CREDITNOTE
                OBJdN.MdiParent = MDIMain
                OBJdN.BILLNO = PURreginitial & "-" & txtbookingno.Text.Trim
                'OBJdN.FRMSTRING = ""
                'If FRMSTRING = "DOMESTIC" Then
                '    OBJdN.BILLNO = "AP-" & txtbookingno.Text.Trim
                'Else
                '    OBJdN.BILLNO = "IAP-" & txtbookingno.Text.Trim
                'End If
                OBJdN.Show()
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

                If lbllocked.Visible = True Or lblcancelled.Visible = True Then
                    MsgBox("Voucher Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Entry Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJBOOKING As New ClsMiscSale
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPBOOKINGNO)
                    ALPARAVAL.Add(TEMPREGNAME)
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

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURreginitial & "-" & TEMPBOOKINGNO
            OBJRECPAY.SALEBILLINITIALS = PURreginitial & "-" & TEMPBOOKINGNO

            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripprint.Click
        Try
            If edit = True Then PRINTREPORT(TEMPBOOKINGNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub TXTEXTRACHGS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdotkeypress(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub TXTEXTRACHGS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub TXTPARTICULARS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPARTICULARS.Validated, CMBPARTICULARS.Validated
        If CMBPARTICULARS.Text.Trim <> "" Then
            TXTPARTICULARS.Text = CMBPARTICULARS.Text.Trim
            TXTGRIDDESC.Visible = True
            TXTGRIDDESC.Focus()
        Else
            TXTDISCRECDPER.Focus()
        End If
    End Sub

    Private Sub TXTGRIDDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGRIDDESC.Validated
        TXTGRIDDESC.Visible = False
        TXTQTY.Focus()
    End Sub

    Private Sub TXTPURADDTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPURADDTAX.Validated
        PURCHASETOTAL()
    End Sub

    Private Sub CHKTAXSERVCHGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTAXSERVCHGS.CheckedChanged
        PURCHASETOTAL()
    End Sub

    Private Sub CHKREVERSE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKREVERSE.CheckedChanged
        PURCHASETOTAL()
    End Sub

    Private Sub CMBTOUR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOUR.Validating
        Try
            If CMBTOUR.Text.Trim <> "" Then GROUPNAMEVALIDATE(CMBTOUR, e, Me, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOUR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOUR.Enter
        Try
            If CMBTOUR.Text.Trim = "" Then FILLGROUPNAME(CMBTOUR, " AND GROUPDEP_FROM < '" & Format(Convert.ToDateTime(BOOKINGDATE.Text).Date, "MM/dd/yyyy") & "'")
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

    Private Sub CMBHSNITEMDESC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Enter
        Try
            If CMBHSNITEMDESC.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNITEMDESC)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            If BOOKINGDATE.Text = "__/__/____" Then Exit Sub

            If CMBHSNITEMDESC.Text.Trim <> "" And Convert.ToDateTime(BOOKINGDATE.Text).Date >= "07/01/2017" Then
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
                '  Dim DT As DataTable = OBJCMN.search("  ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER, ISNULL(HSN_CGST, 0) AS PURCGSTPER, ISNULL(HSN_SGST, 0) AS PURSGSTPER, ISNULL(HSN_IGST, 0) AS PURIGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_ITEMDESC = '" & CMBHSNITEMDESC.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
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

    Private Sub CMBHSNITEMDESC_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNITEMDESC.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
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

    Private Sub CMDSELECTBILL_Click(sender As Object, e As EventArgs) Handles CMDSELECTBILL.Click
        Try
            Dim OBJBILL As New SelectPurForComm
            OBJBILL.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCELUPLOAD_Click(sender As Object, e As EventArgs) Handles TOOLEXCELUPLOAD.Click
        Try
            If cmbregister.Text.Trim = "" Then
                MsgBox("First Select Register", MsgBoxStyle.Critical)
                Exit Sub
            End If


            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("DATE")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("SALENAME")
            DTSAVE.Columns.Add("SALESTATE")
            DTSAVE.Columns.Add("REFNO")
            DTSAVE.Columns.Add("PARTICULARS")
            DTSAVE.Columns.Add("SALESACCODE")
            DTSAVE.Columns.Add("AMOUNT")
            DTSAVE.Columns.Add("SALEDISC")
            DTSAVE.Columns.Add("SALESERVCHGS")
            DTSAVE.Columns.Add("GSTSERVCHGS")
            DTSAVE.Columns.Add("SOURCE")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("INVOICENO")


            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()


            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                DIRECTUPLOAD = True

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("DATE") = Format(Convert.ToDateTime(oSheet.Range("A" & I.ToString).Text).Date, "dd/MM/yyyy")
                Else
                    DTROWSAVE("DATE") = 0
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("SALENAME") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("SALENAME") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESTATE") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("SALESTATE") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("REFNO") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("REFNO") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("PARTICULARS") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("PARTICULARS") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESACCODE") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("SALESACCODE") = ""
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("AMOUNT") = Val(oSheet.Range("H" & I.ToString).Text)
                Else
                    DTROWSAVE("AMOUNT") = 0
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("SALEDISC") = Val(oSheet.Range("I" & I.ToString).Text)
                Else
                    DTROWSAVE("SALEDISC") = 0
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESERVCHGS") = Val(oSheet.Range("J" & I.ToString).Text)
                Else
                    DTROWSAVE("SALESERVCHGS") = 0
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTSERVCHGS") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("GSTSERVCHGS") = 0
                End If

                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("SOURCE") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("SOURCE") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("INVOICENO") = Val(oSheet.Range("N" & I.ToString).Text)
                Else
                    DTROWSAVE("INVOICENO") = 0
                End If



                Dim DTTABLE As New DataTable
                Dim DT As New DataTable
                Dim OBJCMN As New ClsCommon
                Dim OBJSYNC As New SyncDate

                txtbookingno.Text = Val(DTROWSAVE("INVOICENO"))
                BOOKINGDATE.Text = DTROWSAVE("DATE")
                CMBNAME.Text = DTROWSAVE("SALENAME")
                'CHECK WHETHER SALENAME IS PRESENT OR NOT
                'IF NOT THEN ADD SALENAME
                DT = OBJCMN.search("ACC_CMPNAME AS NAME", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then OBJSYNC.ADDLEDGERS(CMBNAME.Text.Trim, "Sundry Debtors", DTROWSAVE("SALESTATE"))


                txtrefno.Text = DTROWSAVE("REFNO")
                CMBHSNITEMDESC.Text = DTROWSAVE("SALESACCODE")
                'TXTPARTICULARS.Text = DTROWSAVE("PARTICULARS")
                CMBPARTICULARS.Text = DTROWSAVE("PARTICULARS")
                TXTQTY.Text = 1
                TXTRATE.Text = Val(DTROWSAVE("AMOUNT"))
                TXTTOTAL.Text = Val(DTROWSAVE("AMOUNT"))
                TXTDISCRECDRS.Text = Val(DTROWSAVE("SALEDISC"))
                TXTEXTRACHGS.Text = Val(DTROWSAVE("SALESERVCHGS"))
                If UCase(DTROWSAVE("GSTSERVCHGS")) = "YES" Then
                    CHKTAXSERVCHGS.CheckState = CheckState.Checked
                Else
                    CHKTAXSERVCHGS.CheckState = CheckState.Unchecked
                End If

                CMBBOOKEDBY.Text = "Admin"


                fillgrid()
                CMBNAME_Validated(sender, e)
                CMBHSNITEMDESC_Validated(sender, e)
                PURCHASETOTAL()

                CMBSOURCE.Text = DTROWSAVE("SOURCE")
                'CHECK WHETHER SOURCE IS ADDED OR NOT
                'IF NOT THEN ADD SOURCE
                DT = OBJCMN.search("SOURCE_NAME AS SOURCENAME", "", " SOURCEMASTER ", " AND SOURCE_NAME = '" & CMBSOURCE.Text.Trim & "' AND SOURCE_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then OBJSYNC.ADDSOURCE(CMBSOURCE.Text.Trim)

                txtremarks.Text = DTROWSAVE("REMARKS")


                Call CMDOK_Click(sender, e)
                GRIDTRANS.RowCount = 0

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next
            oBook.Close()
            DIRECTUPLOAD = False
            clear()
            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBPURNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPURNAME.Validated
    '    Try
    '        If CMBPURNAME.Text.Trim <> "" Then
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As DataTable = OBJCMN.search(" ISNULL(STATEMASTER.state_remark, '') AS PURSTATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBPURNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.acc_YEARid = " & YearId)
    '            If DT.Rows.Count > 0 Then
    '                TXTPURSTATECODE.Text = DT.Rows(0).Item("PURSTATECODE")
    '            End If
    '            GETBALANCE()
    '            GETHSNCODE()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBPURNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPURNAME.Validating
        Try
            If CMBPURNAME.Text.Trim <> "" Then namevalidate(CMBPURNAME, CMBPURCODE, e, Me, txtpuradd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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

            Cursor.Current = Cursors.WaitCursor
            Dim objselectproforma As New SelectMiscProforma
            objselectproforma.ShowDialog()
            Dim SELECTPROFORMA As DataTable = objselectproforma.DT

            If SELECTPROFORMA.Rows.Count > 0 Then
                TXTPROFORMANO.Text = Val(SELECTPROFORMA.Rows(0).Item("MISCENQNO"))
                TXTPROFORMAREGNAME.Text = SELECTPROFORMA.Rows(0).Item("REGNAME")
                Dim ALPARAVAL As New ArrayList
                Dim OBJPROFORMAS As New ClsProformaMiscSale

                ALPARAVAL.Add(Val(TXTPROFORMANO.Text.Trim))
                ALPARAVAL.Add(TXTPROFORMAREGNAME.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(0)
                ALPARAVAL.Add(YearId)

                OBJPROFORMAS.alParaval = ALPARAVAL
                Dim DT As DataTable = OBJPROFORMAS.SELECTBOOKING()
                If DT.Rows.Count > 0 Then
                    COPYDATA(DT)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbookingno_Validating(sender As Object, e As CancelEventArgs) Handles txtbookingno.Validating
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
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim TEMPREG As DataTable = OBJCMN.search("REGISTER_INITIALS AS INITIALS ", "", " REGISTERMASTER ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId)
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
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

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'HOTELBOOKING','" & TOKEN & "','','" & TEMPSTATUS & "','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                Dim DTINI As DataTable = OBJCMN.search("BOOKING_PRINTINITIALS AS PRINTINITIALS", "", " MISCSALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BOOKING_PURCHASEREGISTERID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'SALE' AND BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND BOOKING_YEARID = " & YearId)
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

                Dim TEMPOTHERAMT As Double = 0.0
                Dim TEMPTOTALITEMAMT As Double = 0.0
                If CHKTAXSERVCHGS.Checked = True Then
                    TEMPOTHERAMT = Val(TXTFINALPURAMT.Text.Trim) - Val(TXTDISCRS.Text.Trim) + Val(TXTPURTAX.Text.Trim) + Val(TXTPURADDTAX.Text.Trim) + Val(TXTPUROTHERCHGS.Text.Trim)
                    TEMPTOTALITEMAMT = Val(TXTEXTRACHGS.Text.Trim) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)
                Else
                    TEMPOTHERAMT = Val(TXTPURTAX.Text.Trim) + Val(TXTPURADDTAX.Text.Trim) + Val(TXTPUROTHERCHGS.Text.Trim)
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
                If CHKTAXSERVCHGS.Checked = True Then j = j & """UnitPrice"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & "," Else j = j & """UnitPrice"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """TotAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & "," Else j = j & """TotAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","

                'j = j & """Discount"":" & Format(Val(TEMPLINECHARGES), "0.00") & "" & ","
                'j = j & """PreTaxVal"":" & "1" & "" & ","
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssAmt"":" & Format(Val(TXTEXTRACHGS.Text.Trim), "0.00") & "" & "," Else j = j & """AssAmt"":" & Format(Val(TXTSUBTOTAL.Text.Trim), "0.00") & "" & ","
                Dim DTHSN As DataTable = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId)
                j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & ","


                j = j & """IgstAmt"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CgstAmt"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstAmt"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                If APPLYCESS = True Then
                    j = j & """CesRt"":" & Val(TXTCESSPER.Text.Trim) & "" & ","
                    j = j & """CesAmt"":" & Val(TXTCESSAMT.Text.Trim) & "" & ","
                Else
                    j = j & """CesRt"":" & "0" & "" & ","
                    j = j & """CesAmt"":" & "0" & "" & ","
                End If
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
                If CHKTAXSERVCHGS.Checked = True Then j = j & """AssVal"":" & Val(TXTEXTRACHGS.Text.Trim) & "" & "," Else j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","

                j = j & """CesVal"":" & "0" & ","
                j = j & """StCesVal"":" & "0" & ","
                j = j & """Discount"":" & "0" & ","
                j = j & """OthChrg"":" & Val(TEMPOTHERAMT) & ","
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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','','FAILED','" & Replace(REQUESTEDTEXT, "'", "''") & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE MISCSALMASTER SET BOOKING_IRNNO = '" & TXTIRNNO.Text.Trim & "', BOOKING_ACKNO = '" & TXTACKNO.Text.Trim & "', BOOKING_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' FROM MISCSALMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BOOKING_PURCHASEREGISTERID WHERE BOOKING_NO = " & Val(txtbookingno.Text.Trim) & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'SALE' AND BOOKING_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                Dim TEMPREG As DataTable = OBJCMN.search("REGISTER_INITIALS AS INITIALS ", "", " REGISTERMASTER ", " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId)
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(txtbookingno.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()


                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsMiscSale
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(txtbookingno.Text.Trim)
                    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(txtbookingno.Text.Trim) & ",'MISCBOOKING','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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

    Private Sub DTPFROM_GotFocus(sender As Object, e As EventArgs) Handles DTPFROM.GotFocus
        DTPFROM.SelectAll()
    End Sub

    Private Sub DTPTO_GotFocus(sender As Object, e As EventArgs) Handles DTPTO.GotFocus
        DTPTO.SelectAll()
    End Sub

    Private Sub CMBPARTICULARS_Validating(sender As Object, e As CancelEventArgs) Handles CMBPARTICULARS.Validating
        'DONT ASK TO CREATE NEW FROM HERE
        'IF USER WANTS TO CREATE NEW THEN THEY CAN USE MASTERS AND CAN CREATE THERE
        'ONLY CREATE NEW PARTICULARS FOR SSR
        Try
            If CMBPARTICULARS.Text.Trim <> "" And ClientName = "SSR" Then PARTICULARVALIDATE(CMBPARTICULARS, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTICULARS_Enter(sender As Object, e As EventArgs) Handles CMBPARTICULARS.Enter
        Try
            If CMBPARTICULARS.Text.Trim = "" Then FILLPARTICULAR(CMBPARTICULARS, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COPYDATA(ByVal DT As DataTable)
        Try
            For Each DR As DataRow In DT.Rows

                cmbregister.Text = DR("PURREG")
                CMBPURCODE.Text = Convert.ToString(DR("PURCODE"))
                CMBHSNITEMDESC.Text = DR("ITEMDESC")
                CMBPURNAME.Text = Convert.ToString(DR("NAME"))
                CMBPURTAX.Text = DR("PURTAXNAME")
                CMBBOOKEDBY.Text = DR("BOOKEDBY")
                CMBPURADDTAX.Text = DR("PURADDTAXNAME")
                CMBSOURCE.Text = DR("SOURCE")
                txtrefno.Text = DR("REFNO")
                TXTFINALPURAMT.Text = DR("FINALPURAMT")
                TXTDISCRECDPER.Text = DR("DISCRECDPER")
                TXTDISCRECDRS.Text = DR("DISCRECDRS")
                TXTCOMMRECDPER.Text = DR("COMMRECDPER")
                TXTCOMMRECDRS.Text = DR("COMMRECDRS")
                TXTPURTDSPER.Text = DR("PURTDSPER")
                TXTPURTDSRS.Text = DR("PURTDSRS")
                TXTEXTRACHGS.Text = DR("PUREXTRACHGS")
                TXTSUBTOTAL.Text = DR("PURSUBTOTAL")
                TXTPURTAX.Text = DR("PURTAX")
                TXTPURADDTAX.Text = DR("PURADDTAX")

                CMBPUROTHERCHGS.Text = DR("PUROTHERCHGSNAME")
                If DR("PUROTHERCHGS") > 0 Then
                    TXTPUROTHERCHGS.Text = DR("PUROTHERCHGS")
                    CMBPURADDSUB.Text = "Add"
                Else
                    TXTPUROTHERCHGS.Text = DR("PUROTHERCHGS") * (-1)
                    CMBPURADDSUB.Text = "Sub."
                End If
                txtroundoff.Text = DR("PURROUNDOFF")
                txtgrandtotal.Text = DR("PURGRANDTOTAL")
                txtremarks.Text = DR("REMARKS")
                TXTBOOKINGDESC.Text = DR("BOOKINGDESC")
                TXTSPECIALREMARKS.Text = DR("SPECIALREMARKS")
                txtinwords.Text = DR("INWORDS")

                TXTPURAMTPAID.Text = 0
                TXTPUREXTRAAMT.Text = 0
                TXTPURRETURN.Text = 0
                TXTPURBAL.Text = 0

                CHKTAXSERVCHGS.Checked = Convert.ToBoolean(DR("TAXSERVCHGS"))
                CHKBILLCHECK.Checked = Convert.ToBoolean(DR("BILLCHECKED"))
                chkdispute.Checked = Convert.ToBoolean(DR("DISPUTE"))

                TXTHSNCODE.Text = DR("HSNCODE")

                If Convert.ToBoolean(DR("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                TXTCGSTPER.Text = DR("CGSTPER")
                TXTCGSTAMT.Text = DR("CGSTAMT")
                TXTSGSTPER.Text = DR("SGSTPER")
                TXTSGSTAMT.Text = DR("SGSTAMT")
                TXTIGSTPER.Text = DR("IGSTPER")
                TXTIGSTAMT.Text = DR("IGSTAMT")
                TXTCESSPER.Text = DR("CESSPER")
                TXTCESSAMT.Text = DR("CESSAMT")

                CMBNAME.Text = Convert.ToString(DR("PURNAME"))
                TXTBILLNO.Text = DR("BILLNO")
                TXTPROFORMANO.Text = DR("BOOKINGNO")
                TXTSTATECODE.Text = DR("STATECODE")

                Dim DFROM As String = Format(Convert.ToDateTime(DR("DFROM").ToString).Date, "dd/MM/yyyy")
                Dim DTO As String = Format(Convert.ToDateTime(DR("DTO").ToString).Date, "dd/MM/yyyy")
                If Convert.ToDateTime(DFROM).Date = "01/01/1900" Then DFROM = "__/__/____"
                If Convert.ToDateTime(DTO).Date = "01/01/1900" Then DTO = "__/__/____"

                GRIDTRANS.Rows.Add(DR("GRIDSRNO").ToString, DR("PARTICULARS").ToString, DR("GRIDDESC").ToString, DR("QTY").ToString, Format(Val(DR("RATE").ToString), "0.00"), DFROM, DTO, Format(Val(DR("TOTAL").ToString), "0.00"), 0, "", "")
            Next
            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGUESTNAME_Enter(sender As Object, e As EventArgs) Handles CMBGUESTNAME.Enter
        'Try
        '    If CMBGUESTNAME.Text.Trim = "" Then fillname(CMBGUESTNAME, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If CMBGUESTNAME.Text.Trim = "" Then FILLGUESTNAME(CMBGUESTNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBGUESTNAME_Validated(sender As Object, e As EventArgs) Handles CMBGUESTNAME.Validated
    '    Try
    '        If CMBNAME.Text.Trim <> "" Then
    '            Dim OBJCMN1 As New ClsCommon
    '            Dim DT1 As DataTable = OBJCMN1.search(" ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.acc_YEARid = " & YearId)
    '            If DT1.Rows.Count > 0 Then TXTSTATECODE.Text = DT1.Rows(0).Item("STATECODE")

    '            GETBALANCE()
    '            GETHSNCODE()
    '        End If


    '        If TXTMOBILE.Text.Trim = "" Then
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As DataTable = OBJCMN.search(" ISNULL(ACC_MOBILE,'') , ISNULL(ACC_EMAIL,'') ", "", " LEDGERS", " AND ACC_CMPNAME ='" & CMBNAME.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId)
    '            If DT.Rows.Count > 0 Then
    '                TXTMOBILE.Text = DT.Rows(0).Item(0)
    '                TXTEMAILADD.Text = DT.Rows(0).Item(1)
    '            End If
    '        End If

    '        'If CMBNAME.Text.Trim <> "" Then

    '        'End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBGUESTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBGUESTNAME.Validating
        'Try
        '    If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBACCCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If CMBGUESTNAME.Text.Trim <> "" Then GUESTNAMEVALIDATE(CMBGUESTNAME, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBGUESTNAME_Validated(sender As Object, e As EventArgs) Handles CMBGUESTNAME.Validated
        Try
            If CMBGUESTNAME.Text.Trim = "" And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(GUEST_NAME,'') ", "", " GUESTMASTER", " AND GUEST_NAME ='" & CMBGUESTNAME.Text.Trim & "' AND GUEST_CMPID = " & CmpId & " AND GUEST_LOCATIONID = " & Locationid & " AND GUEST_YEARID = " & YearId)
                'If DT.Rows.Count > 0 Then
                '    txtmobileno.Text = DT.Rows(0).Item(0)
                '    txtemailadd.Text = DT.Rows(0).Item(1)
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class