Imports System.IO
Imports System.Net
Imports BL

Public Class TourMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridCurDoubleClick As Boolean
    Dim gridConDoubleClick As Boolean
    Dim gridServiceDoubleClick As Boolean
    Dim gridMiscDoubleClick As Boolean
    Dim gridAirDoubleClick As Boolean
    Dim gridCordiDoubleClick As Boolean
    Dim gridLeaderdoubleclick As Boolean
    Dim GRIDAddServDOUBLECLICK As Boolean
    Dim GRIDPurDOUBLECLICK As Boolean
    Dim gridTOURDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean

    Dim tempCURrow As Integer
    Dim tempCONTRYrow As Integer
    Dim tempSERVICErow As Integer
    Dim tempMISCrow As Integer
    Dim tempAIRrow As Integer
    Dim tempCORDrow As Integer
    Dim tempLEADERrow As Integer
    Dim tempADDSERVrow As Integer
    Dim tempPURCHASErow As Integer
    Dim tempTOURrow As Integer
    Dim tempUPLOADrow As Integer

    Dim PRESENT As Boolean

    Public edit As Boolean
    Public TEMPTOURNO As Integer
    Dim TEMPMSG As Integer

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_BOOKING_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max( TOUR_no),0) + 1 ", "TOURMASTER", " AND TOUR_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTTOURNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub clear()
        Try
            EP.Clear()
            TXTTOURNAME.Clear()
            TXTGROUPSTRENGTH.Clear()
            TXTDAYS.Clear()
            STARTDATE.Value = Mydate
            ENDDATE.Value = Mydate
            TXTVISA.Text = "MUMBAI"
            TXTPORT.Text = "NAJAF"
            TXTFAIZE.Clear()
            TXTVISANO.Clear()
            TXTCTC.Text = "+9647814576566"
            CHKVISA.CheckState = CheckState.Unchecked
            RDBPURCHASE.Checked = False
            RDBSELF.Checked = True
            TXTTOURNO.Clear()
            TOURDATE.Value = Mydate

            TXTCUTOFDAYS.Clear()
            CUTOFDATE.Value = Mydate

            TXTREMARKS.Clear()
            CHKAPPLYADULT.Checked = False
            CHKAPPLYCHILD.Checked = False
            CHKAPPLYINFANT.Checked = False
            ''currency
            TXTCURSRNO.Clear()
            CMBCURCURRENCY.Text = ""
            TXTCURRATE.Clear()
            GRIDCURRENCY.RowCount = 0

            ''country
            TXTCONSRNO.Clear()
            CMBCONCOUNTRY.Text = ""
            CMBCONCITY.Text = ""
            CONFROMDATE.Value = Mydate
            CONTODATE.Value = Mydate
            GRIDCOUNTRY.RowCount = 0

            TXTPKGADULT.Text = "0.0"
            TXTPKGCHILD.Text = "0.0"
            TXTPKGINFANT.Text = "0.0"

            TXTPROFFITADULT.Text = "0.0"
            TXTPROFFITCHILD.Text = "0.0"
            TXTPROFFITINFANT.Text = "0.0"

            TXTDECADULT.Text = "0.0"
            TXTDECCHILD.Text = "0.0"
            TXTDECINFANT.Text = "0.0"

            TXTDECPKGADULT.Text = "0.0"
            TXTDECPKGCHILD.Text = "0.0"
            TXTDECPKGINFANT.Text = "0.0"

            ''services
            CMBSERVICES.Text = ""
            TXTASRNO.Clear()
            CMBANAME.Text = ""
            CMBACURRENCY.Text = ""
            TXTAADULT.Clear()
            TXTAADULTINR.Clear()
            TXTACHILD.Clear()
            TXTACHILDINR.Clear()
            TXTAINFANT.Clear()
            TXTAINFANTINR.Clear()
            TXTAADULTTOTAL.Text = "0.0"
            TXTACHILDTOTAL.Text = "0.0"
            TXTAINFANTTOTAL.Text = "0.0"
            GRIDSERVICES.RowCount = 0


            ''misc expenses
            TXTBSRNO.Clear()
            CMBMISCEXP.Text = ""
            CMBBCURRENCY.Text = ""
            TXTBADULT.Clear()
            TXTBADULTINR.Clear()
            TXTBCHILD.Clear()
            TXTBCHILDINR.Clear()
            TXTBINFANT.Clear()
            TXTBINFANTINR.Clear()
            TXTBADULTTOTAL.Text = "0.0"
            TXTBCHILDTOTAL.Text = "0.0"
            TXTBINFANTTOTAL.Text = "0.0"
            GRIDMISC.RowCount = 0

            ''misc airline
            TXTCSRNO.Clear()
            CMBAIRLINE.Text = ""
            TXTFLIGHTDETAILS.Clear()
            TXTNARRATION.Clear()
            FLIGHTDATE.Value = Mydate
            TXTFLIGHTNO.Clear()
            TXTARRIVAL.Clear()
            CMBCCURRENCY.Text = ""
            TXTCADULT.Clear()
            TXTCADULTINR.Clear()
            TXTCCHILD.Clear()
            TXTCCHILDINR.Clear()
            TXTCINFANT.Clear()
            TXTCINFANTINR.Clear()
            TXTCADULTTOTAL.Text = "0.0"
            TXTCCHILDTOTAL.Text = "0.0"
            TXTCINFANTTOTAL.Text = "0.0"
            GRIDFLIGHT.RowCount = 0

            ''misc Co-Ordinator
            TXTDSRNO.Clear()
            CMBCORDINATOR.Text = ""
            CMBDCURRENCY.Text = ""
            TXTDADULT.Clear()
            TXTDADULTINR.Clear()
            TXTDCHILD.Clear()
            TXTDCHILDINR.Clear()
            TXTDINFANT.Clear()
            TXTDINFANTINR.Clear()
            TXTDADULTTOTAL.Text = "0.0"
            TXTDCHILDTOTAL.Text = "0.0"
            TXTDINFANTTOTAL.Text = "0.0"
            GRIDCORDINATOR.RowCount = 0


            ''Group Leader
            TXTESRNO.Clear()
            CMBLEADER.Text = ""
            TXTCONTRI.Clear()
            TXTINCENTIVES.Clear()
            TXTREBATE.Clear()
            TXTLEADERCOST.Clear()
            TXTCONTRITOTAL.Text = "0.0"
            TXTINCENTIVESTOTAL.Text = "0.0"
            TXTREBATETOTAL.Text = "0.0"
            TXTLEADERTOTAL.Text = "0.0"
            TXTEADULTTOTAL.Text = "0.0"
            TXTECHILDTOTAL.Text = "0.0"
            TXTEINFANTTOTAL.Text = "0.0"
            GRIDLEADER.RowCount = 0


            ''misc ADDITIONAL SERVICES
            TXTFSRNO.Clear()
            CMBADDSERVICES.Text = ""
            CMBFCURRENCY.Text = ""
            TXTFADULT.Clear()
            TXTFADULTINR.Clear()
            TXTFCHILD.Clear()
            TXTFCHILDINR.Clear()
            TXTFINFANT.Clear()
            TXTFINFANTINR.Clear()
            TXTFADULTTOTAL.Text = "0.0"
            TXTFCHILDTOTAL.Text = "0.0"
            TXTFINFANTTOTAL.Text = "0.0"
            GRIDADDSERVICES.RowCount = 0

            ''PURCHASE
            TXTPURSRNO.Clear()
            CMBSUPPLIER.Text = ""
            TXTPURADULT.Clear()
            TXTPURCHILD.Clear()
            TXTPURINFANT.Clear()
            TXTPURADULTTOTAL.Text = "0.0"
            TXTPURCHILDTOTAL.Text = "0.0"
            TXTPURINFANTTOTAL.Text = "0.0"
            GRIDPURCHASE.RowCount = 0


            ''TOURDETAILS
            TXTTOURSRNO.Clear()
            ITENARYDATE.Value = STARTDATE.Value.Date
            TXTTOURDETAILS.Clear()
            GRIDTOUR.RowCount = 0


            PBSOFTCOPY.Image = Nothing
            TXTUPLOADSRNO.Text = 1
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            TXTIMGPATH.Clear()
            gridupload.RowCount = 0

            EP.Clear()
            gridServiceDoubleClick = False
            gridMiscDoubleClick = False
            gridAirDoubleClick = False
            GRIDAddServDOUBLECLICK = False
            gridCordiDoubleClick = False
            gridLeaderdoubleclick = False
            GRIDPurDOUBLECLICK = False
            gridTOURDoubleClick = False
            gridUPLOADdoubleclick = False

            getmax_BOOKING_no()


            If GRIDSERVICES.RowCount > 0 Then
                TXTASRNO.Text = Val(GRIDSERVICES.Rows(GRIDSERVICES.RowCount - 1).Cells(GASrno.Index).Value) + 1
            Else
                TXTASRNO.Text = 1
            End If

            If GRIDMISC.RowCount > 0 Then
                TXTBSRNO.Text = Val(GRIDMISC.Rows(GRIDMISC.RowCount - 1).Cells(GBSrno.Index).Value) + 1
            Else
                TXTBSRNO.Text = 1
            End If

            If GRIDFLIGHT.RowCount > 0 Then
                TXTCSRNO.Text = Val(GRIDFLIGHT.Rows(GRIDFLIGHT.RowCount - 1).Cells(GCSrno.Index).Value) + 1
            Else
                TXTCSRNO.Text = 1
            End If

            If GRIDCORDINATOR.RowCount > 0 Then
                TXTDSRNO.Text = Val(GRIDCORDINATOR.Rows(GRIDCORDINATOR.RowCount - 1).Cells(GDSrno.Index).Value) + 1
            Else
                TXTDSRNO.Text = 1
            End If

            If GRIDLEADER.RowCount > 0 Then
                TXTESRNO.Text = Val(GRIDLEADER.Rows(GRIDLEADER.RowCount - 1).Cells(GESrno.Index).Value) + 1
            Else
                TXTESRNO.Text = 1
            End If

            If GRIDADDSERVICES.RowCount > 0 Then
                TXTFSRNO.Text = Val(GRIDADDSERVICES.Rows(GRIDADDSERVICES.RowCount - 1).Cells(GFSrno.Index).Value) + 1
            Else
                TXTFSRNO.Text = 1
            End If

            If GRIDPURCHASE.RowCount > 0 Then
                TXTPURSRNO.Text = Val(GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).Cells(GPURSRNO.Index).Value) + 1
            Else
                TXTPURSRNO.Text = 1
            End If

            If GRIDTOUR.RowCount > 0 Then
                TXTTOURSRNO.Text = Val(GRIDTOUR.Rows(GRIDTOUR.RowCount - 1).Cells(GTOURSRNO.Index).Value) + 1
            Else
                TXTTOURSRNO.Text = 1
            End If

            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            clear()
            edit = False
            TOURDATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TourMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNoCancel)
                If tempmsg = vbYes Then
                    If errorvalid() = True Then CMDOK_Click(sender, e)
                ElseIf tempmsg = vbCancel Then
                    Exit Sub
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 Then       'for tabselection
                TabControl1.SelectedIndex = 0
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for tabselection
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode = Windows.Forms.Keys.F3 Then       'for tabselection
                TabControl1.SelectedIndex = 2
            ElseIf e.KeyCode = Windows.Forms.Keys.F4 Then       'for tabselection
                TabControl1.SelectedIndex = 3
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'for tabselection
                TabControl1.SelectedIndex = 4
            ElseIf e.KeyCode = Windows.Forms.Keys.F6 Then       'for tabselection
                TabControl1.SelectedIndex = 5
            ElseIf e.KeyCode = Windows.Forms.Keys.F7 Then       'for tabselection
                TabControl1.SelectedIndex = 6
            ElseIf e.KeyCode = Windows.Forms.Keys.F8 Then       'for tabselection
                TabControl1.SelectedIndex = 7
            ElseIf e.KeyCode = Windows.Forms.Keys.F9 Then       'for tabselection
                TabControl1.SelectedIndex = 8
            ElseIf e.KeyCode = Windows.Forms.Keys.F10 Then       'for tabselection
                TabControl1.SelectedIndex = 9
            ElseIf e.KeyCode = Windows.Forms.Keys.F11 Then       'for tabselection
                TabControl1.SelectedIndex = 10
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F2 Then
                TXTTOURNO.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombo()
        If CMBCURCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURCURRENCY)

        If CMBACURRENCY.Text.Trim = "" Then fillCurrency(CMBACURRENCY)
        If CMBBCURRENCY.Text.Trim = "" Then fillCurrency(CMBBCURRENCY)
        If CMBCCURRENCY.Text.Trim = "" Then fillCurrency(CMBCCURRENCY)
        If CMBDCURRENCY.Text.Trim = "" Then fillCurrency(CMBDCURRENCY)
        If CMBFCURRENCY.Text.Trim = "" Then fillCurrency(CMBFCURRENCY)

        If CMBCONCITY.Text.Trim = "" Then fillCityCode(CMBCONCITY)
        If CMBCONCOUNTRY.Text.Trim = "" Then fillCountry(CMBCONCOUNTRY)

        If CMBAIRLINE.Text.Trim = "" Then FILLAIRLINE(CMBAIRLINE, edit, "")
        If CMBCORDINATOR.Text.Trim = "" Then FILLGUEST(CMBCORDINATOR, edit, " AND GUEST_CORDINATOR=1")
        If CMBLEADER.Text.Trim = "" Then FILLGUEST(CMBLEADER, edit, " AND GUEST_LEADER=1")
        If CMBADDSERVICES.Text.Trim = "" Then fillSERVICE(CMBADDSERVICES)
        If CMBSUPPLIER.Text.Trim = "" Then fillname(CMBSUPPLIER, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
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

            alParaval.Add(TOURDATE.Value.Date)
            alParaval.Add(TXTTOURNAME.Text.Trim)
            alParaval.Add(TXTGROUPSTRENGTH.Text.Trim)
            alParaval.Add(Val(TXTDAYS.Text.Trim))
            alParaval.Add((STARTDATE.Value.Date))
            alParaval.Add((ENDDATE.Value.Date))
            alParaval.Add(TXTVISA.Text.Trim)
            alParaval.Add(TXTPORT.Text.Trim)
            alParaval.Add(TXTFAIZE.Text.Trim)

            alParaval.Add(TXTCTC.Text.Trim)
            alParaval.Add(TXTVISANO.Text.Trim)
            alParaval.Add(CHKVISA.CheckState)

            alParaval.Add((CUTOFDATE.Value.Date))
            alParaval.Add(Val(TXTCUTOFDAYS.Text.Trim))

            If RDBSELF.Checked = True Then
                alParaval.Add("SELF")
            Else
                alParaval.Add("PURCHASE")
            End If

            ''SERVICE TOTAL
            alParaval.Add(Val(TXTAADULTTOTAL.Text))
            alParaval.Add(Val(TXTACHILDTOTAL.Text))
            alParaval.Add(Val(TXTAINFANTTOTAL.Text))

            ''MISC TOTAL
            alParaval.Add(Val(TXTBADULTTOTAL.Text))
            alParaval.Add(Val(TXTBCHILDTOTAL.Text))
            alParaval.Add(Val(TXTBINFANTTOTAL.Text))

            ''FLIGHT TOTAL
            alParaval.Add(Val(TXTCADULTTOTAL.Text))
            alParaval.Add(Val(TXTCCHILDTOTAL.Text))
            alParaval.Add(Val(TXTCINFANTTOTAL.Text))

            ''CORDINATOR TOTAL
            alParaval.Add(Val(TXTDADULTTOTAL.Text))
            alParaval.Add(Val(TXTDCHILDTOTAL.Text))
            alParaval.Add(Val(TXTDINFANTTOTAL.Text))

            '' LEADER TOTAL
            alParaval.Add(Val(TXTCONTRITOTAL.Text))
            alParaval.Add(Val(TXTINCENTIVESTOTAL.Text))
            alParaval.Add(Val(TXTREBATETOTAL.Text))
            alParaval.Add(Val(TXTLEADERTOTAL.Text))

            alParaval.Add(Val(TXTEADULTTOTAL.Text))
            alParaval.Add(Val(TXTECHILDTOTAL.Text))
            alParaval.Add(Val(TXTEINFANTTOTAL.Text))

            ''ADDITIONAL SERVICES
            alParaval.Add(Val(TXTFADULTTOTAL.Text))
            alParaval.Add(Val(TXTFCHILDTOTAL.Text))
            alParaval.Add(Val(TXTFINFANTTOTAL.Text))

            alParaval.Add(Val(TXTPURADULTTOTAL.Text))
            alParaval.Add(Val(TXTPURCHILDTOTAL.Text))
            alParaval.Add(Val(TXTPURINFANTTOTAL.Text))

            ''PKG COST
            alParaval.Add(Val(TXTPKGADULT.Text))
            alParaval.Add(Val(TXTPKGCHILD.Text))
            alParaval.Add(Val(TXTPKGINFANT.Text))

            ''PROFFIT
            alParaval.Add(Val(TXTPROFFITADULT.Text))
            alParaval.Add(Val(TXTPROFFITCHILD.Text))
            alParaval.Add(Val(TXTPROFFITINFANT.Text))

            ''DECLARE COST
            alParaval.Add(Val(TXTDECPKGADULT.Text))
            alParaval.Add(Val(TXTDECPKGCHILD.Text))
            alParaval.Add(Val(TXTDECPKGINFANT.Text))

            ''DECLARE COST + ADD SERVICE
            alParaval.Add(Val(TXTDECADULT.Text))
            alParaval.Add(Val(TXTDECCHILD.Text))
            alParaval.Add(Val(TXTDECINFANT.Text))

            ''REMARKS
            alParaval.Add(TXTREMARKS.Text)

            alParaval.Add(CHKAPPLYADULT.CheckState)
            alParaval.Add(CHKAPPLYCHILD.CheckState)
            alParaval.Add(CHKAPPLYINFANT.CheckState)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            'CURRENCY DETAILS
            Dim CURSRNO As String = ""
            Dim CURCURRENCY As String = ""
            Dim CURRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCURRENCY.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CURSRNO = "" Then
                        CURSRNO = row.Cells(GCURSRNO.Index).Value
                        CURCURRENCY = row.Cells(GCURCURRENCY.Index).Value.ToString
                        CURRATE = row.Cells(GCURRATE.Index).Value.ToString
                    Else
                        CURSRNO = CURSRNO & " | " & row.Cells(GCURSRNO.Index).Value.ToString
                        CURCURRENCY = CURCURRENCY & "|" & row.Cells(GCURCURRENCY.Index).Value.ToString
                        CURRATE = CURRATE & "|" & row.Cells(GCURRATE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(CURSRNO)
            alParaval.Add(CURCURRENCY)
            alParaval.Add(CURRATE)

            'COUNTRY DETAILS
            Dim CONSRNO As String = ""
            Dim CONCOUNTRY As String = ""
            Dim CONCITY As String = ""
            Dim CONFROMDATE As String = ""
            Dim CONTODATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCOUNTRY.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CONSRNO = "" Then
                        CONSRNO = row.Cells(GCONSRNO.Index).Value.ToString
                        CONCOUNTRY = row.Cells(GCONCOUNTRY.Index).Value.ToString
                        CONCITY = row.Cells(GCONCITY.Index).Value.ToString
                        CONFROMDATE = Format(Convert.ToDateTime(row.Cells(GCONFROMDATE.Index).Value).Date, "MM/dd/yyyy")
                        CONTODATE = Format(Convert.ToDateTime(row.Cells(GCONTODATE.Index).Value).Date, "MM/dd/yyyy")

                    Else
                        CONSRNO = CONSRNO & "|" & row.Cells(GCONSRNO.Index).Value.ToString
                        CONCOUNTRY = CONCOUNTRY & "|" & row.Cells(GCONCOUNTRY.Index).Value.ToString
                        CONCITY = CONCITY & "|" & row.Cells(GCONCITY.Index).Value.ToString
                        CONFROMDATE = CONFROMDATE & "|" & Format(Convert.ToDateTime(row.Cells(GCONFROMDATE.Index).Value).Date, "MM/dd/yyyy")
                        CONTODATE = CONTODATE & "|" & Format(Convert.ToDateTime(row.Cells(GCONTODATE.Index).Value).Date, "MM/dd/yyyy")
                    End If
                End If
            Next

            alParaval.Add(CONSRNO)
            alParaval.Add(CONCOUNTRY)
            alParaval.Add(CONCITY)
            alParaval.Add(CONFROMDATE)
            alParaval.Add(CONTODATE)

            'SERVICES (A) DETAILS
            Dim ASRNO As String = ""
            Dim ANAME As String = ""
            Dim ACURRENCY As String = ""
            Dim AADULT As String = ""
            Dim AADULTINR As String = ""
            Dim ACHILD As String = ""
            Dim ACHILDINR As String = ""
            Dim AINFANT As String = ""
            Dim AINFANTINR As String = ""
            Dim ATYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSERVICES.Rows
                If row.Cells(0).Value <> Nothing Then
                    If ASRNO = "" Then
                        ASRNO = row.Cells(GASrno.Index).Value
                        ANAME = row.Cells(GANAME.Index).Value.ToString
                        ACURRENCY = row.Cells(GACURRENCY.Index).Value.ToString
                        AADULT = row.Cells(GAADULT.Index).Value
                        AADULTINR = row.Cells(GAADULTINR.Index).Value
                        ACHILD = row.Cells(GACHILD.Index).Value
                        ACHILDINR = row.Cells(GACHILDINR.Index).Value
                        AINFANT = row.Cells(GAINFANT.Index).Value
                        AINFANTINR = row.Cells(GAINFANTINR.Index).Value
                        ATYPE = row.Cells(GType.Index).Value

                    Else

                        ASRNO = ASRNO & "|" & row.Cells(GASrno.Index).Value
                        ANAME = ANAME & "|" & row.Cells(GANAME.Index).Value.ToString
                        ACURRENCY = ACURRENCY & "|" & row.Cells(GACURRENCY.Index).Value.ToString
                        AADULT = AADULT & "|" & row.Cells(GAADULT.Index).Value
                        AADULTINR = AADULTINR & "|" & row.Cells(GAADULTINR.Index).Value
                        ACHILD = ACHILD & "|" & row.Cells(GACHILD.Index).Value
                        ACHILDINR = ACHILDINR & "|" & row.Cells(GACHILDINR.Index).Value
                        AINFANT = AINFANT & "|" & row.Cells(GAINFANT.Index).Value
                        AINFANTINR = AINFANTINR & "|" & row.Cells(GAINFANTINR.Index).Value
                        ATYPE = ATYPE & "|" & row.Cells(GType.Index).Value

                    End If
                End If
            Next

            alParaval.Add(ASRNO)
            alParaval.Add(ANAME)
            alParaval.Add(ACURRENCY)
            alParaval.Add(AADULT)
            alParaval.Add(AADULTINR)
            alParaval.Add(ACHILD)
            alParaval.Add(ACHILDINR)
            alParaval.Add(AINFANT)
            alParaval.Add(AINFANTINR)
            alParaval.Add(ATYPE)


            'MISC EXPENCES (B)DETAILS
            Dim BSRNO As String = ""
            Dim BMISCEXPENCE As String = ""
            Dim BCURRENCY As String = ""
            Dim BADULT As String = ""
            Dim BADULTINR As String = ""
            Dim BCHILD As String = ""
            Dim BCHILDINR As String = ""
            Dim BINFANT As String = ""
            Dim BINFANTINR As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDMISC.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If BSRNO = "" Then
                        BSRNO = ROW.Cells(GBSrno.Index).Value.ToString
                        BMISCEXPENCE = ROW.Cells(GBMISC.Index).Value.ToString
                        BCURRENCY = ROW.Cells(GBCURRENCY.Index).Value
                        BADULT = ROW.Cells(GBADULT.Index).Value
                        BADULTINR = ROW.Cells(GBADULTINR.Index).Value
                        BCHILD = ROW.Cells(GBCHILD.Index).Value
                        BCHILDINR = ROW.Cells(GBCHILDINR.Index).Value
                        BINFANT = ROW.Cells(GBINFANT.Index).Value
                        BINFANTINR = ROW.Cells(GBINFANTINR.Index).Value

                    Else
                        BSRNO = BSRNO & "|" & ROW.Cells(GBSrno.Index).Value.ToString
                        BMISCEXPENCE = BMISCEXPENCE & "|" & ROW.Cells(GBMISC.Index).Value.ToString
                        BCURRENCY = BCURRENCY & "|" & ROW.Cells(GBCURRENCY.Index).Value
                        BADULT = BADULT & "|" & ROW.Cells(GBADULT.Index).Value
                        BADULTINR = BADULTINR & "|" & ROW.Cells(GBADULTINR.Index).Value
                        BCHILD = BCHILD & "|" & ROW.Cells(GBCHILD.Index).Value
                        BCHILDINR = BCHILDINR & "|" & ROW.Cells(GBCHILDINR.Index).Value
                        BINFANT = BINFANT & "|" & ROW.Cells(GBINFANT.Index).Value
                        BINFANTINR = BINFANTINR & "|" & ROW.Cells(GBINFANTINR.Index).Value

                    End If
                End If
            Next

            alParaval.Add(BSRNO)
            alParaval.Add(BMISCEXPENCE)
            alParaval.Add(BCURRENCY)
            alParaval.Add(BADULT)
            alParaval.Add(BADULTINR)
            alParaval.Add(BCHILD)
            alParaval.Add(BCHILDINR)
            alParaval.Add(BINFANT)
            alParaval.Add(BINFANTINR)


            'AIRLINES (C) DETAILS
            Dim CSRNO As String = ""
            Dim CAIRLINE As String = ""
            Dim CFLIGHTDETAIL As String = ""
            Dim CNARRATION As String = ""
            Dim CFLIGHTDATE As String = ""
            Dim CFLIGHTNO As String = ""
            Dim CARRIVAL As String = ""
            Dim CCURRENCY As String = ""
            Dim CADULT As String = ""
            Dim CADULTINR As String = ""
            Dim CCHILD As String = ""
            Dim CCHILDINR As String = ""
            Dim CINFANT As String = ""
            Dim CINFANTINR As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFLIGHT.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(GCSrno.Index).Value.ToString
                        CAIRLINE = row.Cells(GCAIRLINE.Index).Value.ToString
                        CFLIGHTDETAIL = row.Cells(GCFLIGHTDETAIL.Index).Value.ToString
                        CNARRATION = row.Cells(GCNARRATION.Index).Value.ToString
                        CFLIGHTDATE = Format(Convert.ToDateTime(row.Cells(GCDATE.Index).Value).Date, "MM/dd/yyyy")
                        CFLIGHTNO = row.Cells(GCFLIGHTNO.Index).Value
                        CARRIVAL = row.Cells(GCARRIVAL.Index).Value.ToString
                        CCURRENCY = row.Cells(GCCURRENCY.Index).Value
                        CADULT = row.Cells(GCADULT.Index).Value
                        CADULTINR = row.Cells(GCADULTINR.Index).Value
                        CCHILD = row.Cells(GCCHILD.Index).Value
                        CCHILDINR = row.Cells(GCCHILDINR.Index).Value
                        CINFANT = row.Cells(GCINFANT.Index).Value
                        CINFANTINR = row.Cells(GCINFANTINR.Index).Value

                    Else

                        CSRNO = CSRNO & "|" & row.Cells(GCSrno.Index).Value.ToString
                        CAIRLINE = CAIRLINE & "|" & row.Cells(GCAIRLINE.Index).Value.ToString
                        CFLIGHTDETAIL = CFLIGHTDETAIL & "|" & row.Cells(GCFLIGHTDETAIL.Index).Value.ToString
                        CNARRATION = CNARRATION & "|" & row.Cells(GCNARRATION.Index).Value.ToString
                        CFLIGHTDATE = CFLIGHTDATE & "|" & Format(Convert.ToDateTime(row.Cells(GCDATE.Index).Value).Date, "MM/dd/yyyy")
                        CFLIGHTNO = CFLIGHTNO & "|" & row.Cells(GCFLIGHTNO.Index).Value
                        CARRIVAL = CARRIVAL & "|" & row.Cells(GCARRIVAL.Index).Value.ToString
                        CCURRENCY = CCURRENCY & "|" & row.Cells(GCCURRENCY.Index).Value
                        CADULT = CADULT & "|" & row.Cells(GCADULT.Index).Value
                        CADULTINR = CADULTINR & "|" & row.Cells(GCADULTINR.Index).Value
                        CCHILD = CCHILD & "|" & row.Cells(GCCHILD.Index).Value
                        CCHILDINR = CCHILDINR & "|" & row.Cells(GCCHILDINR.Index).Value
                        CINFANT = CINFANT & "|" & row.Cells(GCINFANT.Index).Value
                        CINFANTINR = CINFANTINR & "|" & row.Cells(GCINFANTINR.Index).Value
                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CAIRLINE)
            alParaval.Add(CFLIGHTDETAIL)
            alParaval.Add(CNARRATION)
            alParaval.Add(CFLIGHTDATE)
            alParaval.Add(CFLIGHTNO)
            alParaval.Add(CARRIVAL)
            alParaval.Add(CCURRENCY)
            alParaval.Add(CADULT)
            alParaval.Add(CADULTINR)
            alParaval.Add(CCHILD)
            alParaval.Add(CCHILDINR)
            alParaval.Add(CINFANT)
            alParaval.Add(CINFANTINR)


            'CO-ORDINATOR (D)DETAILS
            Dim DSRNO As String = ""
            Dim DCORDINATOR As String = ""
            Dim DCURRENCY As String = ""
            Dim DADULT As String = ""
            Dim DADULTINR As String = ""
            Dim DCHILD As String = ""
            Dim DCHILDINR As String = ""
            Dim DINFANT As String = ""
            Dim DINFANTINR As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDCORDINATOR.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If DSRNO = "" Then
                        DSRNO = ROW.Cells(GDSrno.Index).Value.ToString
                        DCORDINATOR = ROW.Cells(GDCORDINATOR.Index).Value.ToString
                        DCURRENCY = ROW.Cells(GDCURRENCY.Index).Value
                        DADULT = ROW.Cells(GDADULT.Index).Value
                        DADULTINR = ROW.Cells(GDADULTINR.Index).Value
                        DCHILD = ROW.Cells(GDCHILD.Index).Value
                        DCHILDINR = ROW.Cells(GDCHILDINR.Index).Value
                        DINFANT = ROW.Cells(GDINFANT.Index).Value
                        DINFANTINR = ROW.Cells(GDINFANTINR.Index).Value

                    Else
                        DSRNO = DSRNO & "|" & ROW.Cells(GDSrno.Index).Value.ToString
                        DCORDINATOR = DCORDINATOR & "|" & ROW.Cells(GDCORDINATOR.Index).Value.ToString
                        DCURRENCY = DCURRENCY & "|" & ROW.Cells(GDCURRENCY.Index).Value
                        DADULT = DADULT & "|" & ROW.Cells(GDADULT.Index).Value
                        DADULTINR = DADULTINR & "|" & ROW.Cells(GDADULTINR.Index).Value
                        DCHILD = DCHILD & "|" & ROW.Cells(GDCHILD.Index).Value
                        DCHILDINR = DCHILDINR & "|" & ROW.Cells(GDCHILDINR.Index).Value
                        DINFANT = DINFANT & "|" & ROW.Cells(GDINFANT.Index).Value
                        DINFANTINR = DINFANTINR & "|" & ROW.Cells(GDINFANTINR.Index).Value

                    End If
                End If
            Next

            alParaval.Add(DSRNO)
            alParaval.Add(DCORDINATOR)
            alParaval.Add(DCURRENCY)
            alParaval.Add(DADULT)
            alParaval.Add(DADULTINR)
            alParaval.Add(DCHILD)
            alParaval.Add(DCHILDINR)
            alParaval.Add(DINFANT)
            alParaval.Add(DINFANTINR)

            'LEADER (E)DETAILS
            Dim ESRNO As String = ""
            Dim ELEADER As String = ""
            Dim ECONTRIBUTION As String = ""
            Dim EINCENTIVES As String = ""
            Dim EREBATED As String = ""
            Dim ELEADERCOST As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDLEADER.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If ESRNO = "" Then
                        ESRNO = ROW.Cells(GESrno.Index).Value.ToString
                        ELEADER = ROW.Cells(GELEADER.Index).Value.ToString
                        ECONTRIBUTION = ROW.Cells(GECONTRIBUTION.Index).Value
                        EINCENTIVES = ROW.Cells(GEINCENTIVES.Index).Value
                        EREBATED = ROW.Cells(GEREBATED.Index).Value
                        ELEADERCOST = ROW.Cells(GELEADERCOST.Index).Value
                    Else
                        ESRNO = ESRNO & "|" & ROW.Cells(GESrno.Index).Value.ToString
                        ELEADER = ELEADER & "|" & ROW.Cells(GELEADER.Index).Value.ToString
                        ECONTRIBUTION = ECONTRIBUTION & "|" & ROW.Cells(GECONTRIBUTION.Index).Value
                        EINCENTIVES = EINCENTIVES & "|" & ROW.Cells(GEINCENTIVES.Index).Value
                        EREBATED = EREBATED & "|" & ROW.Cells(GEREBATED.Index).Value
                        ELEADERCOST = ELEADERCOST & "|" & ROW.Cells(GELEADERCOST.Index).Value
                    End If
                End If
            Next

            alParaval.Add(ESRNO)
            alParaval.Add(ELEADER)
            alParaval.Add(ECONTRIBUTION)
            alParaval.Add(EINCENTIVES)
            alParaval.Add(EREBATED)
            alParaval.Add(ELEADERCOST)

            'ADDITIONAL SERVICES (F)DETAILS
            Dim FSRNO As String = ""
            Dim FADDSERVICE As String = ""
            Dim FCURRENCY As String = ""
            Dim FADULT As String = ""
            Dim FADULTINR As String = ""
            Dim FCHILD As String = ""
            Dim FCHILDINR As String = ""
            Dim FINFANT As String = ""
            Dim FINFANTINR As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDADDSERVICES.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If FSRNO = "" Then
                        FSRNO = ROW.Cells(GFSrno.Index).Value.ToString
                        FADDSERVICE = ROW.Cells(GFADDSERVICE.Index).Value.ToString
                        FCURRENCY = ROW.Cells(GFCURRENCY.Index).Value
                        FADULT = ROW.Cells(GFADULT.Index).Value
                        FADULTINR = ROW.Cells(GFADULTINR.Index).Value
                        FCHILD = ROW.Cells(GFCHILD.Index).Value
                        FCHILDINR = ROW.Cells(GFCHILDINR.Index).Value
                        FINFANT = ROW.Cells(GFINFANT.Index).Value
                        FINFANTINR = ROW.Cells(GFINFANTINR.Index).Value

                    Else
                        FSRNO = FSRNO & "|" & ROW.Cells(GFSrno.Index).Value.ToString
                        FADDSERVICE = FADDSERVICE & "|" & ROW.Cells(GFADDSERVICE.Index).Value.ToString
                        FCURRENCY = FCURRENCY & "|" & ROW.Cells(GFCURRENCY.Index).Value
                        FADULT = FADULT & "|" & ROW.Cells(GFADULT.Index).Value
                        FADULTINR = FADULTINR & "|" & ROW.Cells(GFADULTINR.Index).Value
                        FCHILD = FCHILD & "|" & ROW.Cells(GFCHILD.Index).Value
                        FCHILDINR = FCHILDINR & "|" & ROW.Cells(GFCHILDINR.Index).Value
                        FINFANT = FINFANT & "|" & ROW.Cells(GFINFANT.Index).Value
                        FINFANTINR = FINFANTINR & "|" & ROW.Cells(GFINFANTINR.Index).Value
                    End If
                End If
            Next

            alParaval.Add(FSRNO)
            alParaval.Add(FADDSERVICE)
            alParaval.Add(FCURRENCY)
            alParaval.Add(FADULT)
            alParaval.Add(FADULTINR)
            alParaval.Add(FCHILD)
            alParaval.Add(FCHILDINR)
            alParaval.Add(FINFANT)
            alParaval.Add(FINFANTINR)


            'PURCHASE (G)DETAILS
            Dim PURSRNO As String = ""
            Dim PURCHASE As String = ""
            Dim PURADULT As String = ""
            Dim PURCHILD As String = ""
            Dim PURINFANT As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If PURSRNO = "" Then
                        PURSRNO = ROW.Cells(GPURSrno.Index).Value.ToString
                        PURCHASE = ROW.Cells(GPURNAME.Index).Value.ToString
                        PURADULT = ROW.Cells(GPURADULT.Index).Value
                        PURCHILD = ROW.Cells(GPURCHILD.Index).Value
                        PURINFANT = ROW.Cells(GPURINFANT.Index).Value
                    Else
                        PURSRNO = PURSRNO & "|" & ROW.Cells(GPURSrno.Index).Value.ToString
                        PURCHASE = PURCHASE & "|" & ROW.Cells(GPURNAME.Index).Value.ToString
                        PURADULT = PURADULT & "|" & ROW.Cells(GPURADULT.Index).Value
                        PURCHILD = PURCHILD & "|" & ROW.Cells(GPURCHILD.Index).Value
                        PURINFANT = PURINFANT & "|" & ROW.Cells(GPURINFANT.Index).Value

                    End If
                End If
            Next

            alParaval.Add(PURSRNO)
            alParaval.Add(PURCHASE)
            alParaval.Add(PURADULT)
            alParaval.Add(PURCHILD)
            alParaval.Add(PURINFANT)


            'TOUR DETAILS
            Dim TOURSRNO As String = ""
            Dim ITENARYDATE As String = ""
            Dim TOURDETAILS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTOUR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If TOURSRNO = "" Then
                        TOURSRNO = row.Cells(GTOURSRNO.Index).Value.ToString
                        ITENARYDATE = Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = row.Cells(GTOURDETAILS.Index).Value.ToString

                    Else

                        TOURSRNO = TOURSRNO & "|" & row.Cells(GTOURSRNO.Index).Value
                        ITENARYDATE = ITENARYDATE & "|" & Format(Convert.ToDateTime(row.Cells(GTOURDATE.Index).Value).Date, "MM/dd/yyyy")
                        TOURDETAILS = TOURDETAILS & "|" & row.Cells(GTOURDETAILS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(TOURSRNO)
            alParaval.Add(ITENARYDATE)
            alParaval.Add(TOURDETAILS)

            Dim OBJTOUR As New ClsTourMaster()
            OBJTOUR.alParaval = alParaval

            If edit = False Then
                Dim DTNO As DataTable = OBJTOUR.save()
                MessageBox.Show("Details Added")
                TEMPTOURNO = DTNO.Rows(0).Item(0)
            Else
                alParaval.Add(TEMPTOURNO)

                IntResult = OBJTOUR.update()
                MessageBox.Show("Details Updated")
                edit = False
            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            clear()
            TXTTOURNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim tempmsg As Integer = MsgBox("Delete Tour Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJCMN As New ClsCommon
                    Dim dt1 As DataTable
                    dt1 = OBJCMN.search(" TOUR_name as tourname ", "", " TOURMASTER RIGHT OUTER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID AND TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID ", " AND TOUR_NO=" & TEMPTOURNO & " AND TOUR_YEARID=" & YearId)
                    If dt1.Rows.Count > 0 Then
                        tempmsg = MsgBox("First Delete Registration !", MsgBoxStyle.Critical, "TRAVELMATE")
                    Else
                        Dim OBJBOOKING As New ClsTourMaster
                        Dim ALPARAVAL As New ArrayList

                        ALPARAVAL.Add(TEMPTOURNO)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        OBJBOOKING.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJBOOKING.Delete()
                        MsgBox("Tour Name '" & DT.Rows(0).Item(0) & "' Deleted ! ")

                        clear()
                        edit = False
                    End If

                    
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TourMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOLIDAY PACKAGES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            fillcombo()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJBOOKING As New ClsTourMaster()

                ALPARAVAL.Add(TEMPTOURNO)
                ALPARAVAL.Add(YearId)

                OBJBOOKING.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJBOOKING.SELECTTOUR()
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTTOURNO.Text = TEMPTOURNO
                        TOURDATE.Value = Convert.ToDateTime(dr("TOURDATE")).Date
                        TXTTOURNAME.Text = dr("NAME")
                        TXTGROUPSTRENGTH.Text = dr("STRENGTH")
                        TXTDAYS.Text = dr("DAYS")
                        STARTDATE.Value = Convert.ToDateTime(dr("STARTDATE")).Date
                        ENDDATE.Value = Convert.ToDateTime(dr("ENDDATE")).Date
                        CUTOFDATE.Value = Convert.ToDateTime(dr("CUTOFDATE")).Date
                        TXTCUTOFDAYS.Text = dr("CUTOFDAYS")
                        TXTVISA.Text = dr("VISA")
                        TXTPORT.Text = dr("PORT")
                        TXTFAIZE.Text = dr("FAIZE")
                        TXTCTC.Text = dr("CTC")
                        TXTVISANO.Text = dr("VISANO")

                        If dr("VISANOCHK") = True Then
                            CHKVISA.Checked = True
                        Else
                            CHKVISA.Checked = False
                        End If

                        TXTREMARKS.Text = dr("REMARKS")
                        If dr("CHKAPPLYADULT") = True Then
                            CHKAPPLYADULT.Checked = True
                        Else
                            CHKAPPLYADULT.Checked = False
                        End If

                        If dr("CHKAPPLYCHILD") = True Then
                            CHKAPPLYCHILD.Checked = True
                        Else
                            CHKAPPLYCHILD.Checked = False
                        End If

                        If dr("CHKAPPLYINFANT") = True Then
                            CHKAPPLYINFANT.Checked = True
                        Else
                            CHKAPPLYINFANT.Checked = False
                        End If

                        If dr("SELF") = "SELF" Then
                            RDBSELF.Checked = True
                        Else
                            RDBPURCHASE.Checked = True
                        End If

                        TXTDECPKGADULT.Text = dr("DECPKGADULTTOTAL")
                        TXTDECPKGCHILD.Text = dr("DECPKGCHILDTOTAL")
                        TXTDECPKGINFANT.Text = dr("DECPKGINFANTTOTAL")

                        'COUNTRY DETAILS
                        GRIDCOUNTRY.Rows.Add(dr("SRNO").ToString, dr("COUNTRY"), dr("CITY"), Format(Convert.ToDateTime(dr("CONFROMDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("CONTODATE")).Date))

                    Next
                    GRIDCOUNTRY.FirstDisplayedScrollingRowIndex = GRIDCOUNTRY.RowCount - 1

                Else
                    'IF ROWCOUNT = 0
                    clear()
                    edit = False
                    TOURDATE.Focus()
                End If

                'CURRENCY DETAILS
                Dim OBJCMN As New ClsCommon
                Dim dt1 As DataTable
                dt1 = OBJCMN.search(" TOUR_CURRENCY.TOUR_GRIDSRNO AS SRNO, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_CURRENCY.TOUR_RATE, 0) AS RATE ", "", " TOUR_CURRENCY LEFT OUTER JOIN CURRENCYMASTER ON TOUR_CURRENCY.TOUR_CURRENCYID = CURRENCYMASTER.cur_id AND TOUR_CURRENCY.TOUR_yearid = CURRENCYMASTER.cur_yearid", " AND TOUR_CURRENCY.TOUR_NO=" & TEMPTOURNO & " AND TOUR_CURRENCY.TOUR_YEARID=" & YearId & " ORDER BY TOUR_CURRENCY.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDCURRENCY.Rows.Add(DR("SRNO"), DR("CURRENCY"), Format(Val(DR("RATE")), "0.00"))
                    Next
                End If

                'Misc Exp. Detail
                dt1 = OBJCMN.search(" TOUR_EXPENSES.TOUR_GRIDSRNO AS SRNO, ISNULL(MISCEXPMASTER.MISC_name, '') AS MISCEXP, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_EXPENSES.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_EXPENSES.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_EXPENSES.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_EXPENSES.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_EXPENSES.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_EXPENSES.TOUR_INFANTINR, 0) AS INFANTINR", "", " TOUR_EXPENSES LEFT OUTER JOIN CURRENCYMASTER ON TOUR_EXPENSES.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_EXPENSES.TOUR_CURRENCYID = CURRENCYMASTER.cur_id LEFT OUTER JOIN MISCEXPMASTER ON TOUR_EXPENSES.TOUR_yearid = MISCEXPMASTER.MISC_yearid AND TOUR_EXPENSES.TOUR_MISCEXPID = MISCEXPMASTER.MISC_id ", " AND TOUR_EXPENSES.TOUR_NO=" & TEMPTOURNO & " AND TOUR_EXPENSES.TOUR_YEARID=" & YearId & " ORDER BY TOUR_EXPENSES.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDMISC.Rows.Add(DR("SRNO"), DR("MISCEXP"), DR("CURRENCY"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("ADULTINR")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("CHILDINR")), "0.00"), Format(Val(DR("INFANT")), "0.00"), Format(Val(DR("INFANTINR")), "0.00"))
                    Next
                End If

                'Flight Detail
                dt1 = OBJCMN.search(" TOUR_FLIGHT.TOUR_GRIDSRNO AS SRNO, ISNULL(FLIGHTMASTER.FLIGHT_NAME, '') AS FLIGHT, ISNULL(TOUR_FLIGHT.TOUR_FLIGHTDET, '') AS FLIGHTDETAIL, ISNULL(TOUR_FLIGHT.TOUR_NARRATION, '') AS NARRATION, TOUR_FLIGHT.TOUR_FLIGHTDATE AS FLIGHTDATE, ISNULL(TOUR_FLIGHT.TOUR_FLIGHTNO, '') AS FLIGHTNO, ISNULL(TOUR_FLIGHT.TOUR_ARRIVAL, '') AS ARRIVAL, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_FLIGHT.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_FLIGHT.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_FLIGHT.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_FLIGHT.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_FLIGHT.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_FLIGHT.TOUR_INFANTINR, 0) AS INFANTINR ", "", " TOUR_FLIGHT LEFT OUTER JOIN CURRENCYMASTER ON TOUR_FLIGHT.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_FLIGHT.TOUR_CURRENCYID = CURRENCYMASTER.cur_id LEFT OUTER JOIN FLIGHTMASTER ON TOUR_FLIGHT.TOUR_AIRLINEID = FLIGHTMASTER.FLIGHT_ID AND TOUR_FLIGHT.TOUR_yearid = FLIGHTMASTER.FLIGHT_YEARID ", " AND TOUR_FLIGHT.TOUR_NO=" & TEMPTOURNO & " AND TOUR_FLIGHT.TOUR_YEARID=" & YearId & " ORDER BY TOUR_FLIGHT.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDFLIGHT.Rows.Add(DR("SRNO"), DR("FLIGHT"), DR("FLIGHTDETAIL"), DR("NARRATION"), Format(Convert.ToDateTime(DR("FLIGHTDATE")).Date, "dd/MM/yyyy"), DR("FLIGHTNO"), DR("ARRIVAL"), DR("CURRENCY"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("ADULTINR")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("CHILDINR")), "0.00"), Format(Val(DR("INFANT")), "0.00"), Format(Val(DR("INFANTINR")), "0.00"))
                    Next
                End If

                'Cordinator Detail
                dt1 = OBJCMN.search(" TOUR_COORDINATOR.TOUR_GRIDSRNO AS SRNO, ISNULL(GUESTMASTER.GUEST_NAME, '') AS CORDINATOR, ISNULL(CURRENCYMASTER.cur_CODE, '') AS CURRENCY, ISNULL(TOUR_COORDINATOR.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_COORDINATOR.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_COORDINATOR.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_COORDINATOR.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_COORDINATOR.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_COORDINATOR.TOUR_INFANTINR, 0) AS INFANTINR ", "", " TOUR_COORDINATOR LEFT OUTER JOIN GUESTMASTER ON TOUR_COORDINATOR.TOUR_yearid = GUESTMASTER.GUEST_YEARID AND TOUR_COORDINATOR.TOUR_CORDINATORID = GUESTMASTER.GUEST_ID LEFT OUTER JOIN CURRENCYMASTER ON TOUR_COORDINATOR.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_COORDINATOR.TOUR_CURRENCYID = CURRENCYMASTER.cur_id ", " AND TOUR_COORDINATOR.TOUR_NO=" & TEMPTOURNO & " AND TOUR_COORDINATOR.TOUR_YEARID=" & YearId & " ORDER BY TOUR_COORDINATOR.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDCORDINATOR.Rows.Add(DR("SRNO"), DR("CORDINATOR"), DR("CURRENCY"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("ADULTINR")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("CHILDINR")), "0.00"), Format(Val(DR("INFANT")), "0.00"), Format(Val(DR("INFANTINR")), "0.00"))
                    Next
                End If

                'Leader Detail
                dt1 = OBJCMN.search(" TOUR_LEADER.TOUR_GRIDSRNO AS SRNO, ISNULL(GUESTMASTER.GUEST_NAME, '') AS LEADER, ISNULL(TOUR_LEADER.TOUR_CONTRI, 0) AS CONTRI, ISNULL(TOUR_LEADER.TOUR_INCENTIVES, 0) AS INCENTIVES, ISNULL(TOUR_LEADER.TOUR_REBATE, 0) AS REBATED, ISNULL(TOUR_LEADER.TOUR_LEADERCOST, 0) AS LEADERCOST  ", "", " TOUR_LEADER LEFT OUTER JOIN GUESTMASTER ON TOUR_LEADER.TOUR_LEADERID = GUESTMASTER.GUEST_ID AND TOUR_LEADER.TOUR_yearid = GUESTMASTER.GUEST_YEARID ", " AND TOUR_LEADER.TOUR_NO=" & TEMPTOURNO & " AND TOUR_LEADER.TOUR_YEARID=" & YearId & " ORDER BY TOUR_LEADER.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDLEADER.Rows.Add(DR("SRNO"), DR("LEADER"), Format(Val(DR("CONTRI")), "0.00"), Format(Val(DR("INCENTIVES")), "0.00"), Format(Val(DR("REBATED")), "0.00"), Format(Val(DR("LEADERCOST")), "0.00"))
                    Next
                End If

                'Additional Service Detail
                dt1 = OBJCMN.search(" TOUR_ADDSERVICES.TOUR_GRIDSRNO AS SRNO, ISNULL(SERVICEMASTER.SERVICE_name, '') AS SERVICE, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_ADDSERVICES.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_ADDSERVICES.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_ADDSERVICES.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_ADDSERVICES.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_ADDSERVICES.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_ADDSERVICES.TOUR_INFANTINR, 0) AS INFANTINR  ", "", " TOUR_ADDSERVICES LEFT OUTER JOIN CURRENCYMASTER ON TOUR_ADDSERVICES.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_ADDSERVICES.TOUR_CURRENCYID = CURRENCYMASTER.cur_id LEFT OUTER JOIN SERVICEMASTER ON TOUR_ADDSERVICES.TOUR_yearid = SERVICEMASTER.SERVICE_yearid AND TOUR_ADDSERVICES.TOUR_ADDSERVICEID = SERVICEMASTER.SERVICE_id ", " AND TOUR_ADDSERVICES.TOUR_NO=" & TEMPTOURNO & " AND TOUR_ADDSERVICES.TOUR_YEARID=" & YearId & " ORDER BY TOUR_ADDSERVICES.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDADDSERVICES.Rows.Add(DR("SRNO"), DR("SERVICE"), DR("CURRENCY"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("ADULTINR")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("CHILDINR")), "0.00"), Format(Val(DR("INFANT")), "0.00"), Format(Val(DR("INFANTINR")), "0.00"))
                    Next
                End If

                'Purchase Detail
                dt1 = OBJCMN.search(" TOUR_PURCHASE.TOUR_GRIDSRNO AS SRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS SUPPLIER, ISNULL(TOUR_PURCHASE.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_PURCHASE.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_PURCHASE.TOUR_INFANT, 0) AS INFANT ", "", " TOUR_PURCHASE LEFT OUTER JOIN LEDGERS ON TOUR_PURCHASE.TOUR_yearid = LEDGERS.Acc_yearid AND TOUR_PURCHASE.TOUR_NAMEID = LEDGERS.Acc_id ", " AND TOUR_PURCHASE.TOUR_NO=" & TEMPTOURNO & " AND TOUR_PURCHASE.TOUR_YEARID=" & YearId & " ORDER BY TOUR_PURCHASE.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDPURCHASE.Rows.Add(DR("SRNO"), DR("SUPPLIER"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("INFANT")), "0.00"))
                    Next
                End If

                '' SERVICE DETAILS
                dt1 = OBJCMN.search(" TOUR_SERVICES.TOUR_GRIDSRNO AS SRNO, ISNULL(SERVICE_VIEW.NAME, '') AS SERVICE, ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CURRENCY, ISNULL(TOUR_SERVICES.TOUR_ADULT, 0) AS ADULT, ISNULL(TOUR_SERVICES.TOUR_ADULTINR, 0) AS ADULTINR, ISNULL(TOUR_SERVICES.TOUR_CHILD, 0) AS CHILD, ISNULL(TOUR_SERVICES.TOUR_CHILDINR, 0) AS CHILDINR, ISNULL(TOUR_SERVICES.TOUR_INFANT, 0) AS INFANT, ISNULL(TOUR_SERVICES.TOUR_INFANTINR, 0) AS INFANTINR, ISNULL(TOUR_SERVICES.TOUR_TYPE, '') AS TYPE ", "", " TOUR_SERVICES LEFT OUTER JOIN SERVICE_VIEW ON TOUR_SERVICES.TOUR_TYPE = SERVICE_VIEW.TYPE AND TOUR_SERVICES.TOUR_yearid = SERVICE_VIEW.YEARID AND TOUR_SERVICES.TOUR_NAMEID = SERVICE_VIEW.ID LEFT OUTER JOIN CURRENCYMASTER ON TOUR_SERVICES.TOUR_yearid = CURRENCYMASTER.cur_yearid AND TOUR_SERVICES.TOUR_CURRENCYID = CURRENCYMASTER.cur_id", " AND TOUR_SERVICES.TOUR_NO=" & TEMPTOURNO & " AND TOUR_SERVICES.TOUR_YEARID=" & YearId & " ORDER BY TOUR_SERVICES.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDSERVICES.Rows.Add(DR("SRNO"), DR("SERVICE"), DR("CURRENCY"), Format(Val(DR("ADULT")), "0.00"), Format(Val(DR("ADULTINR")), "0.00"), Format(Val(DR("CHILD")), "0.00"), Format(Val(DR("CHILDINR")), "0.00"), Format(Val(DR("INFANT")), "0.00"), Format(Val(DR("INFANTINR")), "0.00"), DR("TYPE"))
                    Next
                End If

                '' TOUR DETAILS
                dt1 = OBJCMN.search(" ISNULL(TOUR_ITENARY.TOUR_GRIDSRNO, 0) AS SRNO, TOUR_ITENARY.TOUR_DATE AS DATE, ISNULL(TOUR_ITENARY.TOUR_DETAILS, '') AS TOURDETAIL ", "", " TOUR_ITENARY INNER JOIN TOURMASTER ON TOUR_ITENARY.TOUR_NO = TOURMASTER.TOUR_NO AND TOUR_ITENARY.TOUR_yearid = TOURMASTER.TOUR_YEARID", " AND TOURMASTER.TOUR_NO=" & TEMPTOURNO & " AND TOURMASTER.TOUR_YEARID=" & YearId & " ORDER BY TOUR_ITENARY.TOUR_GRIDSRNO")
                If dt1.Rows.Count > 0 Then
                    For Each DR As DataRow In dt1.Rows
                        GRIDTOUR.Rows.Add(DR("SRNO"), DR("DATE"), DR("TOURDETAIL"))
                    Next
                End If

                'UPLOAD GRID
                Dim OBJ As New ClsCommon
                Dim dt2 As DataTable = OBJ.search(" ISNULL(TOURMASTER_UPLOAD.TOUR_SRNO,0) AS GRIDSRNO, ISNULL(TOURMASTER_UPLOAD.TOUR_REMARKS,'') AS REMARKS, ISNULL(TOURMASTER_UPLOAD.TOUR_NAME,'') AS NAME, TOURMASTER_UPLOAD.TOUR_PHOTO AS IMGPATH ", "", "  TOURMASTER LEFT OUTER JOIN TOURMASTER_UPLOAD ON TOURMASTER.TOUR_NO = TOURMASTER_UPLOAD.TOUR_NO AND TOURMASTER.TOUR_YEARID = TOURMASTER_UPLOAD.TOUR_YEARID", " AND TOURMASTER_UPLOAD.TOUR_NO = " & TEMPTOURNO & " AND TOURMASTER_UPLOAD.TOUR_YEARID = " & YearId)

                If dt2.Rows.Count > 0 Then
                    For Each DTR3 As DataRow In dt2.Rows
                        gridupload.Rows.Add(DTR3("GRIDSRNO"), DTR3("REMARKS"), DTR3("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR3("IMGPATH"), Byte()))))
                    Next
                End If


                total()

            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable

        If edit = False Then
            DT = OBJCMN.search(" TOUR_NAME ", "", "  TOURMASTER ", " AND TOUR_NAME = '" & TXTTOURNAME.Text.Trim & "' AND TOUR_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                EP.SetError(TXTTOURNAME, "Tour Name Allready Exists !")
                bln = False
            End If

        End If

        If edit = True Then
            DT = OBJCMN.search(" ISNULL(TOURMASTER.TOUR_GRPSTRENGTH, 0) AS STRENGTH ", "", "  TOURMASTER LEFT OUTER JOIN REGISTRATIONMASTER ON TOURMASTER.TOUR_YEARID = REGISTRATIONMASTER.REG_YEARID AND TOURMASTER.TOUR_NO = REGISTRATIONMASTER.REG_TOURID", " AND REG_PERSONTYPE<>'INFANT' AND TOUR_NAME = '" & TXTTOURNAME.Text.Trim & "' AND TOUR_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Val(DT.Rows.Count) > Val(TXTGROUPSTRENGTH.Text) Then
                    EP.SetError(TXTGROUPSTRENGTH, "Registration has been made for this tour, You can't declare less than " & Val(DT.Rows.Count) & " !")
                    bln = False
                End If
            End If
        End If

        If TXTTOURNAME.Text.Trim = "" Then
            EP.SetError(TXTTOURNAME, " Please Fill Tour Name !")
            bln = False
        End If

        If TXTDAYS.Text.Trim = "" Then
            EP.SetError(TXTDAYS, " Please Fill No Of Days !")
            bln = False
        End If

        If TXTGROUPSTRENGTH.Text.Trim = "" Then
            EP.SetError(TXTGROUPSTRENGTH, " Please Fill Group Strength !")
            bln = False
        End If

        If GRIDCURRENCY.RowCount = 0 Then
            EP.SetError(GRIDCURRENCY, " Please Fill Currency Details !")
            bln = False
        End If

        If GRIDCOUNTRY.RowCount = 0 Then
            EP.SetError(GRIDCOUNTRY, " Please Fill Country Details !")
            bln = False
        End If

        If Val(TXTPKGADULT.Text.Trim) <= 0 Or Val(TXTPKGCHILD.Text.Trim) <= 0 Or Val(TXTPKGINFANT.Text.Trim) <= 0 Then
            EP.SetError(TXTPKGADULT, "Pls Fill Pkg Details !")
            bln = False
        End If

        If Val(TXTDECPKGADULT.Text.Trim) <= 0 Or Val(TXTDECPKGCHILD.Text.Trim) <= 0 Or Val(TXTDECPKGINFANT.Text.Trim) <= 0 Then
            EP.SetError(TXTDECPKGADULT, "Pls Fill Declare Pkg. Details !")
            bln = False
        End If

        If Val(TXTCUTOFDAYS.Text.Trim) = 0 Then
            EP.SetError(TXTCUTOFDAYS, "Pls Cut Of Date!")
            bln = False
        End If

        If RDBPURCHASE.Checked = True Then
            If GRIDPURCHASE.RowCount = 0 Then
                EP.SetError(GRIDPURCHASE, " Please Fill Purchase Details !")
                bln = False
            End If

            If Val(TXTPURADULTTOTAL.Text.Trim) <= 0 Or Val(TXTPURCHILDTOTAL.Text.Trim) <= 0 Or Val(TXTPURINFANTTOTAL.Text.Trim) <= 0 Then
                EP.SetError(TXTPURADULTTOTAL, "Pls Fill Purchase Details !")
                bln = False
            End If

        End If


        If Val(TXTPROFFITADULT.Text) < 0 Or Val(TXTPROFFITCHILD.Text) < 0 Or Val(TXTPROFFITINFANT.Text) < 0 Then
            TEMPMSG = MsgBox("Profit is in negative! Do You Want to Proceed ?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim PASS As String = InputBox("Enter Master Password", "HOSPITALITY")
                If PASS <> "finasta" Then
                    MsgBox("Invalid Password, You are not allowed to Continue", MsgBoxStyle.Critical)
                    TXTPROFFITADULT.Focus()
                    bln = False
                    'Exit Function
                End If
            Else
                EP.SetError(TXTPROFFITADULT, "Profit is in negative!")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub total()
        Try
            TXTAADULTTOTAL.Text = "0.0"
            TXTACHILDTOTAL.Text = "0.0"
            TXTAINFANTTOTAL.Text = "0.0"

            TXTBADULTTOTAL.Text = "0.0"
            TXTBCHILDTOTAL.Text = "0.0"
            TXTBINFANTTOTAL.Text = "0.0"

            TXTCADULTTOTAL.Text = "0.0"
            TXTCCHILDTOTAL.Text = "0.0"
            TXTCINFANTTOTAL.Text = "0.0"

            TXTDADULTTOTAL.Text = "0.0"
            TXTDCHILDTOTAL.Text = "0.0"
            TXTDINFANTTOTAL.Text = "0.0"

            TXTEADULTTOTAL.Text = "0.0"
            TXTECHILDTOTAL.Text = "0.0"
            TXTEINFANTTOTAL.Text = "0.0"

            TXTCONTRITOTAL.Text = "0.0"
            TXTINCENTIVESTOTAL.Text = "0.0"
            TXTREBATETOTAL.Text = "0.0"
            TXTLEADERTOTAL.Text = "0.0"

            TXTFADULTTOTAL.Text = "0.0"
            TXTFCHILDTOTAL.Text = "0.0"
            TXTFINFANTTOTAL.Text = "0.0"

            TXTPURADULTTOTAL.Text = "0.0"
            TXTPURCHILDTOTAL.Text = "0.0"
            TXTPURINFANTTOTAL.Text = "0.0"

            TXTPKGADULT.Text = "0.0"
            TXTPKGCHILD.Text = "0.0"
            TXTPKGINFANT.Text = "0.0"

            TXTPROFFITADULT.Text = "0.0"
            TXTPROFFITCHILD.Text = "0.0"
            TXTPROFFITINFANT.Text = "0.0"


            ''SERVICES
            If GRIDSERVICES.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDSERVICES.Rows
                    If Val(row.Cells(GAADULTINR.Index).Value) > 0 Then TXTAADULTTOTAL.Text = Format(Val(TXTAADULTTOTAL.Text) + Val(row.Cells(GAADULTINR.Index).Value), "0")
                    If Val(row.Cells(GACHILDINR.Index).Value) > 0 Then TXTACHILDTOTAL.Text = Format(Val(TXTACHILDTOTAL.Text) + Val(row.Cells(GACHILDINR.Index).Value), "0")
                    If Val(row.Cells(GAINFANTINR.Index).Value) > 0 Then TXTAINFANTTOTAL.Text = Format(Val(TXTAINFANTTOTAL.Text) + Val(row.Cells(GAINFANTINR.Index).Value), "0")
                Next
            End If

            ''MISC SERVICE
            If GRIDMISC.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDMISC.Rows
                    If Val(row.Cells(GBADULTINR.Index).Value) > 0 Then TXTBADULTTOTAL.Text = Format(Val(TXTBADULTTOTAL.Text) + Val(row.Cells(GBADULTINR.Index).Value), "0")
                    If Val(row.Cells(GBCHILDINR.Index).Value) > 0 Then TXTBCHILDTOTAL.Text = Format(Val(TXTBCHILDTOTAL.Text) + Val(row.Cells(GBCHILDINR.Index).Value), "0")
                    If Val(row.Cells(GBADULTINR.Index).Value) > 0 Then TXTBINFANTTOTAL.Text = Format(Val(TXTBINFANTTOTAL.Text) + Val(row.Cells(GBINFANTINR.Index).Value), "0")
                Next
            End If

            ''FLIGHT SERVICE
            If GRIDFLIGHT.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDFLIGHT.Rows
                    If Val(row.Cells(GCADULTINR.Index).Value) > 0 Then TXTCADULTTOTAL.Text = Format(Val(TXTCADULTTOTAL.Text) + Val(row.Cells(GCADULTINR.Index).Value), "0")
                    If Val(row.Cells(GCCHILDINR.Index).Value) > 0 Then TXTCCHILDTOTAL.Text = Format(Val(TXTCCHILDTOTAL.Text) + Val(row.Cells(GCCHILDINR.Index).Value), "0")
                    If Val(row.Cells(GCADULTINR.Index).Value) > 0 Then TXTCINFANTTOTAL.Text = Format(Val(TXTCINFANTTOTAL.Text) + Val(row.Cells(GCINFANTINR.Index).Value), "0")
                Next
            End If

            'CO-ORDINATOR
            If GRIDCORDINATOR.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCORDINATOR.Rows
                    If Val(row.Cells(GDADULTINR.Index).Value) > 0 Then TXTDADULTTOTAL.Text = Format(Val(TXTDADULTTOTAL.Text) + Val(row.Cells(GDADULTINR.Index).Value), "0")
                    If Val(row.Cells(GDCHILDINR.Index).Value) > 0 Then TXTDCHILDTOTAL.Text = Format(Val(TXTDCHILDTOTAL.Text) + Val(row.Cells(GDCHILDINR.Index).Value), "0")
                    If Val(row.Cells(GDADULTINR.Index).Value) > 0 Then TXTDINFANTTOTAL.Text = Format(Val(TXTDINFANTTOTAL.Text) + Val(row.Cells(GDINFANTINR.Index).Value), "0")
                Next
            End If

            ' ''GROUP LEADER
            'If GRIDLEADER.RowCount > 0 Then
            '    For Each row As DataGridViewRow In GRIDLEADER.Rows
            '        If Val(row.Cells(GECONTRIBUTION.Index).Value) > 0 Then TXTCONTRITOTAL.Text = Val(TXTCONTRITOTAL.Text) + Val(row.Cells(GECONTRIBUTION.Index).Value)
            '        If Val(row.Cells(GEINCENTIVES.Index).Value) > 0 Then TXTINCENTIVESTOTAL.Text = Val(TXTINCENTIVESTOTAL.Text) + Val(row.Cells(GEINCENTIVES.Index).Value)
            '        If Val(row.Cells(GEREBATED.Index).Value) > 0 Then TXTREBATETOTAL.Text = Val(TXTREBATETOTAL.Text) + Val(row.Cells(GEREBATED.Index).Value)
            '        If Val(row.Cells(GELEADERCOST.Index).Value) > 0 Then TXTLEADERTOTAL.Text = Val(TXTLEADERTOTAL.Text) + Val(row.Cells(GELEADERCOST.Index).Value)
            '    Next
            '    TXTEADULTTOTAL.Text = ((Val(TXTAADULTTOTAL.Text.Trim) + Val(TXTBADULTTOTAL.Text.Trim) + Val(TXTCADULTTOTAL.Text.Trim) + Val(TXTDADULTTOTAL.Text.Trim)) - (Val(TXTLEADERTOTAL.Text.Trim))) / Val(TXTGROUPSTRENGTH.Text.Trim)
            '    TXTECHILDTOTAL.Text = ((Val(TXTACHILDTOTAL.Text.Trim) + Val(TXTBCHILDTOTAL.Text.Trim) + Val(TXTCCHILDTOTAL.Text.Trim) + Val(TXTDCHILDTOTAL.Text.Trim)) - (Val(TXTLEADERTOTAL.Text.Trim))) / Val(TXTGROUPSTRENGTH.Text.Trim)
            '    TXTEINFANTTOTAL.Text = ((Val(TXTAINFANTTOTAL.Text.Trim) + Val(TXTBINFANTTOTAL.Text.Trim) + Val(TXTCINFANTTOTAL.Text.Trim) + Val(TXTDINFANTTOTAL.Text.Trim)) - (Val(TXTLEADERTOTAL.Text.Trim))) / Val(TXTGROUPSTRENGTH.Text.Trim)
            'End If

            '' as per Saiffudin sir leader (E) Cost should be common for child and infant as like adult
            If GRIDLEADER.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDLEADER.Rows
                    If Val(row.Cells(GECONTRIBUTION.Index).Value) > 0 Then TXTCONTRITOTAL.Text = Format(Val(TXTCONTRITOTAL.Text) + Val(row.Cells(GECONTRIBUTION.Index).Value), "0")
                    If Val(row.Cells(GEINCENTIVES.Index).Value) > 0 Then TXTINCENTIVESTOTAL.Text = Format(Val(TXTINCENTIVESTOTAL.Text) + Val(row.Cells(GEINCENTIVES.Index).Value), "0")
                    If Val(row.Cells(GEREBATED.Index).Value) > 0 Then TXTREBATETOTAL.Text = Format(Val(TXTREBATETOTAL.Text) + Val(row.Cells(GEREBATED.Index).Value), "0")
                    If Val(row.Cells(GELEADERCOST.Index).Value) <> Nothing Then TXTLEADERTOTAL.Text = Format(Val(TXTLEADERTOTAL.Text) + Val(row.Cells(GELEADERCOST.Index).Value), "0")
                Next

                If Val(TXTLEADERTOTAL.Text) < 0 Then
                    TXTLEADERTOTAL.Text = Val(TXTLEADERTOTAL.Text) * (-1)
                End If

                If CHKAPPLYADULT.CheckState = CheckState.Checked Then
                    TXTEADULTTOTAL.Text = Format((((Val(TXTAADULTTOTAL.Text.Trim) + Val(TXTBADULTTOTAL.Text.Trim) + Val(TXTCADULTTOTAL.Text.Trim) + Val(TXTDADULTTOTAL.Text.Trim)) * Val(GRIDLEADER.RowCount) - Val(TXTLEADERTOTAL.Text.Trim)) / Val(TXTGROUPSTRENGTH.Text)) * Val(GRIDLEADER.RowCount), "0")
                Else
                    TXTEADULTTOTAL.Text = "0.00"
                End If

                If CHKAPPLYCHILD.CheckState = CheckState.Checked Then
                    TXTECHILDTOTAL.Text = Format((((Val(TXTAADULTTOTAL.Text.Trim) + Val(TXTBADULTTOTAL.Text.Trim) + Val(TXTCADULTTOTAL.Text.Trim) + Val(TXTDADULTTOTAL.Text.Trim)) * Val(GRIDLEADER.RowCount) - Val(TXTLEADERTOTAL.Text.Trim)) / Val(TXTGROUPSTRENGTH.Text)) * Val(GRIDLEADER.RowCount), "0")
                Else
                    TXTECHILDTOTAL.Text = "0.00"
                End If

                If CHKAPPLYINFANT.CheckState = CheckState.Checked Then
                    TXTEINFANTTOTAL.Text = Format((((Val(TXTAADULTTOTAL.Text.Trim) + Val(TXTBADULTTOTAL.Text.Trim) + Val(TXTCADULTTOTAL.Text.Trim) + Val(TXTDADULTTOTAL.Text.Trim)) * Val(GRIDLEADER.RowCount) - Val(TXTLEADERTOTAL.Text.Trim)) / Val(TXTGROUPSTRENGTH.Text)) * Val(GRIDLEADER.RowCount), "0")
                Else
                    TXTEINFANTTOTAL.Text = "0.00"
                End If
            End If


                ''Additional Services
                If GRIDADDSERVICES.RowCount > 0 Then
                    For Each row As DataGridViewRow In GRIDADDSERVICES.Rows
                        If Val(row.Cells(GFADULTINR.Index).Value) > 0 Then TXTFADULTTOTAL.Text = Format(Val(TXTFADULTTOTAL.Text) + Val(row.Cells(GFADULTINR.Index).Value), "0")
                        If Val(row.Cells(GFCHILDINR.Index).Value) > 0 Then TXTFCHILDTOTAL.Text = Format(Val(TXTFCHILDTOTAL.Text) + Val(row.Cells(GFCHILDINR.Index).Value), "0")
                        If Val(row.Cells(GFADULTINR.Index).Value) > 0 Then TXTFINFANTTOTAL.Text = Format(Val(TXTFINFANTTOTAL.Text) + Val(row.Cells(GFINFANTINR.Index).Value), "0")
                    Next

                End If

                ''PURCHASE GRID
                If GRIDPURCHASE.RowCount > 0 Then
                    For Each row As DataGridViewRow In GRIDPURCHASE.Rows
                        If Val(row.Cells(GPURADULT.Index).Value) > 0 Then TXTPURADULTTOTAL.Text = Format(Val(TXTPURADULTTOTAL.Text) + Val(row.Cells(GPURADULT.Index).Value), "0")
                        If Val(row.Cells(GPURCHILD.Index).Value) > 0 Then TXTPURCHILDTOTAL.Text = Format(Val(TXTPURCHILDTOTAL.Text) + Val(row.Cells(GPURCHILD.Index).Value), "0")
                        If Val(row.Cells(GPURINFANT.Index).Value) > 0 Then TXTPURINFANTTOTAL.Text = Format(Val(TXTPURINFANTTOTAL.Text) + Val(row.Cells(GPURINFANT.Index).Value), "0")
                    Next
                End If

                TXTPKGADULT.Text = Format(((Val(TXTAADULTTOTAL.Text.Trim) + Val(TXTBADULTTOTAL.Text.Trim) + Val(TXTCADULTTOTAL.Text.Trim) + Val(TXTDADULTTOTAL.Text.Trim)) + Val(TXTEADULTTOTAL.Text.Trim) + Val(TXTPURADULTTOTAL.Text.Trim)), "0")
                TXTPKGCHILD.Text = Format(((Val(TXTACHILDTOTAL.Text.Trim) + Val(TXTBCHILDTOTAL.Text.Trim) + Val(TXTCCHILDTOTAL.Text.Trim) + Val(TXTDCHILDTOTAL.Text.Trim)) + Val(TXTECHILDTOTAL.Text.Trim) + Val(TXTPURCHILDTOTAL.Text.Trim)), "0")
                TXTPKGINFANT.Text = Format(((Val(TXTAINFANTTOTAL.Text.Trim) + Val(TXTBINFANTTOTAL.Text.Trim) + Val(TXTCINFANTTOTAL.Text.Trim) + Val(TXTDINFANTTOTAL.Text.Trim)) + Val(TXTEINFANTTOTAL.Text.Trim) + Val(TXTPURINFANTTOTAL.Text.Trim)), "0")

                TXTPROFFITADULT.Text = Format(Val(TXTDECPKGADULT.Text.Trim) - Val(TXTPKGADULT.Text.Trim), "0")
                TXTPROFFITCHILD.Text = Format(Val(TXTDECPKGCHILD.Text.Trim) - Val(TXTPKGCHILD.Text.Trim), "0")
                TXTPROFFITINFANT.Text = Format(Val(TXTDECPKGINFANT.Text.Trim) - Val(TXTPKGINFANT.Text.Trim), "0")

                TXTDECADULT.Text = Format(Val(TXTFADULTTOTAL.Text.Trim) + Val(TXTDECPKGADULT.Text.Trim), "0")
                TXTDECCHILD.Text = Format(Val(TXTFCHILDTOTAL.Text.Trim) + Val(TXTDECPKGCHILD.Text.Trim), "0")
                TXTDECINFANT.Text = Format(Val(TXTFINFANTTOTAL.Text.Trim) + Val(TXTDECPKGINFANT.Text.Trim), "0")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALCLEADERCOST()
        Try
            TXTLEADERCOST.Text = Val(TXTCONTRI.Text.Trim) + Val(TXTREBATE.Text.Trim) - Val(TXTINCENTIVES.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONTRI_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCONTRI.Validating
        Try
            CALCLEADERCOST()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTINCENTIVES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTINCENTIVES.Validating
        Try
            CALCLEADERCOST()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREBATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREBATE.Validating
        Try
            CALCLEADERCOST()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGROUPSTRENGTH_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROUPSTRENGTH.KeyPress
        Try
            numkeypress(e, TXTGROUPSTRENGTH, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDAYS.KeyPress
        Try
            numkeypress(e, TXTDAYS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCURRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCURRATE.KeyPress
        Try
            numdotkeypress(e, TXTCURRATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtCURsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCURSRNO.GotFocus
        If gridCurDoubleClick = False Then
            If GRIDCURRENCY.RowCount > 0 Then
                TXTCURSRNO.Text = Val(GRIDCURRENCY.Rows(GRIDCURRENCY.RowCount - 1).Cells(GCURSRNO.Index).Value) + 1
            Else
                TXTCURSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTCONSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCONSRNO.GotFocus
        If gridConDoubleClick = False Then
            If GRIDCOUNTRY.RowCount > 0 Then
                TXTCONSRNO.Text = Val(GRIDCOUNTRY.Rows(GRIDCOUNTRY.RowCount - 1).Cells(GCONSRNO.Index).Value) + 1
            Else
                TXTCONSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTASRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTASRNO.GotFocus
        If gridServiceDoubleClick = False Then
            If GRIDSERVICES.RowCount > 0 Then
                TXTASRNO.Text = Val(GRIDSERVICES.Rows(GRIDSERVICES.RowCount - 1).Cells(GASrno.Index).Value) + 1
            Else
                TXTASRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTBSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBSRNO.GotFocus
        If gridMiscDoubleClick = False Then
            If GRIDMISC.RowCount > 0 Then
                TXTBSRNO.Text = Val(GRIDMISC.Rows(GRIDMISC.RowCount - 1).Cells(GBSrno.Index).Value) + 1
            Else
                TXTBSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTCSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCSRNO.GotFocus
        If gridAirDoubleClick = False Then
            If GRIDFLIGHT.RowCount > 0 Then
                TXTCSRNO.Text = Val(GRIDFLIGHT.Rows(GRIDFLIGHT.RowCount - 1).Cells(GCSrno.Index).Value) + 1
            Else
                TXTCSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTDSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTDSRNO.GotFocus
        If gridCordiDoubleClick = False Then
            If GRIDCORDINATOR.RowCount > 0 Then
                TXTDSRNO.Text = Val(GRIDCORDINATOR.Rows(GRIDCORDINATOR.RowCount - 1).Cells(GDSrno.Index).Value) + 1
            Else
                TXTDSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTESRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTESRNO.GotFocus
        If gridLeaderdoubleclick = False Then
            If GRIDLEADER.RowCount > 0 Then
                TXTESRNO.Text = Val(GRIDLEADER.Rows(GRIDLEADER.RowCount - 1).Cells(GESrno.Index).Value) + 1
            Else
                TXTESRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTFSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFSRNO.GotFocus
        If GRIDAddServDOUBLECLICK = False Then
            If GRIDADDSERVICES.RowCount > 0 Then
                TXTFSRNO.Text = Val(GRIDADDSERVICES.Rows(GRIDADDSERVICES.RowCount - 1).Cells(GFSrno.Index).Value) + 1
            Else
                TXTFSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTPURSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPURSRNO.GotFocus
        If GRIDPurDOUBLECLICK = False Then
            If GRIDPURCHASE.RowCount > 0 Then
                TXTPURSRNO.Text = Val(GRIDPURCHASE.Rows(GRIDPURCHASE.RowCount - 1).Cells(GPURSrno.Index).Value) + 1
            Else
                TXTPURSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTDECPKGCHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDECPKGCHILD.KeyPress
        Try
            numdotkeypress(e, TXTDECPKGCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDECPKGINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDECPKGINFANT.KeyPress
        Try
            numdotkeypress(e, TXTDECPKGINFANT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAADULT.KeyPress
        Try
            numdotkeypress(e, TXTDECPKGADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDECPKGADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDECPKGADULT.KeyPress
        Try
            numdotkeypress(e, TXTDECPKGADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTACHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTACHILD.KeyPress
        Try
            numdotkeypress(e, TXTACHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAINFANT.KeyPress
        Try
            numdotkeypress(e, TXTAINFANT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBADULT.KeyPress
        Try
            numdotkeypress(e, TXTBADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBCHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBCHILD.KeyPress
        Try
            numdotkeypress(e, TXTBCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBINFANT.KeyPress
        Try
            numdotkeypress(e, TXTDECPKGADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONTRI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCONTRI.KeyPress
        Try
            numdotkeypress(e, TXTCONTRI, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTINCENTIVES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINCENTIVES.KeyPress
        Try
            numdotkeypress(e, TXTINCENTIVES, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREBATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREBATE.KeyPress
        Try
            numdotkeypress(e, TXTREBATE, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLEADERCOST_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLEADERCOST.KeyPress
        Try
            numdotkeypress(e, TXTLEADERCOST, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURADULT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURADULT.KeyPress
        Try
            numdotkeypress(e, TXTPURADULT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURCHILD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURCHILD.KeyPress
        Try
            numdotkeypress(e, TXTPURCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPURINFANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPURINFANT.KeyPress
        Try
            numdotkeypress(e, TXTPURINFANT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCURRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCURRATE.Validating
        If CMBCURCURRENCY.Text.Trim <> "" And Val(TXTCURRATE.Text.Trim) > 0 Then
            fillCurrencyGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillCurrencyGrid()

        GRIDCURRENCY.Enabled = True
        If gridCurDoubleClick = False Then
            GRIDCURRENCY.Rows.Add(Val(TXTCURSRNO.Text.Trim), CMBCURCURRENCY.Text.Trim, Val(TXTCURRATE.Text.Trim))
            getcursrno(GRIDCURRENCY)
        ElseIf gridCurDoubleClick = True Then
            GRIDCURRENCY.Item(GCURSRNO.Index, tempCURrow).Value = Val(TXTCURSRNO.Text.Trim)
            GRIDCURRENCY.Item(GCURCURRENCY.Index, tempCURrow).Value = CMBCURCURRENCY.Text.Trim
            GRIDCURRENCY.Item(GCURRATE.Index, tempCURrow).Value = Val(TXTCURRATE.Text.Trim)
            gridCurDoubleClick = False
        End If

        GRIDCURRENCY.FirstDisplayedScrollingRowIndex = GRIDCURRENCY.RowCount - 1

        TXTCURSRNO.Clear()
        CMBCURCURRENCY.Text = ""
        TXTCURRATE.Clear()
        TXTCURSRNO.Focus()

    End Sub

    Sub getcursrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CONTODATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CONTODATE.Validating
        If CMBCONCOUNTRY.Text.Trim <> "" And CMBCONCITY.Text.Trim <> "" And (CONFROMDATE.Value.Date >= STARTDATE.Value.Date) And (CONTODATE.Value.Date <= ENDDATE.Value.Date) And (CONTODATE.Value.Date >= CONFROMDATE.Value.Date) Then
            Dim objCommon As New ClsCommonMaster
            Dim DT As DataTable = objCommon.search(" BLOCK_FROMDATE, BLOCK_TODATE,BLOCK_REMARK", "", " COUNTRYMASTER RIGHT OUTER JOIN BLOCKDATEMASTER ON COUNTRYMASTER.country_id = BLOCKDATEMASTER.BLOCK_COUNTRYID AND COUNTRYMASTER.country_yearid = BLOCKDATEMASTER.BLOCK_yearid", " AND COUNTRYMASTER.country_NAME='" & CMBCONCOUNTRY.Text.Trim & "' AND BLOCKDATEMASTER.BLOCK_YEARID=" & YearId & "")
            Dim TEMPSTART As Date
            Dim TEMPEND As Date
            If DT.Rows.Count > 0 Then
                For Each dr As DataRow In DT.Rows
                    TEMPSTART = Convert.ToDateTime(DT.Rows(0).Item(0).ToString)
                    TEMPEND = Convert.ToDateTime(DT.Rows(0).Item(1).ToString)
                    If (CONFROMDATE.Value.Date >= TEMPSTART And CONFROMDATE.Value.Date <= TEMPEND) Or (CONTODATE.Value.Date >= TEMPSTART And CONTODATE.Value.Date <= TEMPEND) Or (TEMPSTART >= CONFROMDATE.Value.Date And TEMPSTART <= CONTODATE.Value.Date) Then
                        TEMPMSG = MsgBox("This Date is Blocked For " & CMBCONCOUNTRY.Text.Trim & "-" & (DT.Rows(0).Item(2).ToString) & ", Do You Want To Proceed ?", MsgBoxStyle.YesNo)
                        If TEMPMSG = vbYes Then
                            fillCountryGrid()
                            Exit For
                        Else
                            Exit Sub
                        End If
                    Else
                        fillCountryGrid()
                        Exit For
                    End If
                Next
            Else
                fillCountryGrid()
                total()
            End If

        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
        TOURNAME()
    End Sub

    Sub fillCountryGrid()

        GRIDCOUNTRY.Enabled = True
        If gridConDoubleClick = False Then
            GRIDCOUNTRY.Rows.Add(Val(TXTCONSRNO.Text.Trim), CMBCONCOUNTRY.Text.Trim, CMBCONCITY.Text.Trim, Format(CONFROMDATE.Value.Date, "dd/MM/yyyy"), Format(CONTODATE.Value.Date, "dd/MM/yyyy"))
            getConsrno(GRIDCOUNTRY)
        ElseIf gridConDoubleClick = True Then
            GRIDCOUNTRY.Item(GCONSRNO.Index, tempCONTRYrow).Value = Val(TXTCONSRNO.Text.Trim)
            GRIDCOUNTRY.Item(GCONCOUNTRY.Index, tempCONTRYrow).Value = CMBCONCOUNTRY.Text.Trim
            GRIDCOUNTRY.Item(GCONCITY.Index, tempCONTRYrow).Value = CMBCONCITY.Text.Trim
            GRIDCOUNTRY.Item(GCONFROMDATE.Index, tempCONTRYrow).Value = Format(CONFROMDATE.Value.Date, "dd/MM/yyyy")
            GRIDCOUNTRY.Item(GCONTODATE.Index, tempCONTRYrow).Value = Format(CONTODATE.Value.Date, "dd/MM/yyyy")
            gridConDoubleClick = False
        End If

        GRIDCOUNTRY.FirstDisplayedScrollingRowIndex = GRIDCOUNTRY.RowCount - 1

        TXTCONSRNO.Clear()
        CMBCONCOUNTRY.Text = ""
        CMBCONCITY.Text = ""
        CONFROMDATE.Value = CONTODATE.Value
        CONTODATE.Value = DateAdd(DateInterval.Day, 1, CONFROMDATE.Value)
        TXTCONSRNO.Focus()

    End Sub

    Sub getConsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTAINFANTINR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAINFANTINR.Validating
        If CMBANAME.Text.Trim <> "" And CMBACURRENCY.Text.Trim <> "" And Val(TXTAADULTINR.Text.Trim >= 0) And Val(TXTACHILDINR.Text.Trim >= 0) And Val(TXTAINFANTINR.Text.Trim >= 0) And CMBSERVICES.Text.Trim <> "" Then
            fillServiceGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillServiceGrid()

        GRIDSERVICES.Enabled = True
        If gridServiceDoubleClick = False Then
            GRIDSERVICES.Rows.Add(Val(TXTASRNO.Text.Trim), CMBANAME.Text.Trim, CMBACURRENCY.Text.Trim, Val(TXTAADULT.Text.Trim), Val(TXTAADULTINR.Text.Trim), Val(TXTACHILD.Text.Trim), Val(TXTACHILDINR.Text.Trim), Val(TXTAINFANT.Text.Trim), Val(TXTAINFANTINR.Text.Trim), CMBSERVICES.Text.Trim)
            getServicesrno(GRIDSERVICES)
        ElseIf gridServiceDoubleClick = True Then
            GRIDSERVICES.Item(GASrno.Index, tempSERVICErow).Value = Val(TXTASRNO.Text.Trim)
            GRIDSERVICES.Item(GANAME.Index, tempSERVICErow).Value = (CMBANAME.Text.Trim)
            GRIDSERVICES.Item(GACURRENCY.Index, tempSERVICErow).Value = (CMBACURRENCY.Text.Trim)
            GRIDSERVICES.Item(GAADULT.Index, tempSERVICErow).Value = Val(TXTAADULT.Text.Trim)
            GRIDSERVICES.Item(GAADULTINR.Index, tempSERVICErow).Value = Val(TXTAADULTINR.Text.Trim)
            GRIDSERVICES.Item(GACHILD.Index, tempSERVICErow).Value = Val(TXTACHILD.Text.Trim)
            GRIDSERVICES.Item(GACHILDINR.Index, tempSERVICErow).Value = Val(TXTACHILDINR.Text.Trim)
            GRIDSERVICES.Item(GAINFANT.Index, tempSERVICErow).Value = Val(TXTAINFANT.Text.Trim)
            GRIDSERVICES.Item(GAINFANTINR.Index, tempSERVICErow).Value = Val(TXTAINFANTINR.Text.Trim)
            GRIDSERVICES.Item(GType.Index, tempSERVICErow).Value = (CMBSERVICES.Text.Trim)

            gridServiceDoubleClick = False
        End If

        GRIDSERVICES.FirstDisplayedScrollingRowIndex = GRIDSERVICES.RowCount - 1

        TXTASRNO.Clear()
        CMBANAME.Text = ""
        CMBACURRENCY.Text = ""
        TXTAADULT.Clear()
        TXTAADULTINR.Clear()
        TXTACHILD.Clear()
        TXTACHILDINR.Clear()
        TXTAINFANT.Clear()
        TXTAINFANTINR.Clear()
        'CMBSERVICES.Text = ""
        CMBANAME.DataSource = Nothing
        CMBSERVICES.Focus()
    End Sub

    Sub getServicesrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTBINFANTINR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBINFANTINR.Validating
        If CMBMISCEXP.Text.Trim <> "" And CMBBCURRENCY.Text.Trim <> "" And Val(TXTBADULTINR.Text.Trim >= 0) And Val(TXTBCHILDINR.Text.Trim >= 0) And Val(TXTBINFANTINR.Text.Trim >= 0) Then
            fillMiscGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillMiscGrid()

        GRIDMISC.Enabled = True
        If gridMiscDoubleClick = False Then
            GRIDMISC.Rows.Add(Val(TXTBSRNO.Text.Trim), CMBMISCEXP.Text.Trim, CMBBCURRENCY.Text.Trim, Val(TXTBADULT.Text.Trim), Val(TXTBADULTINR.Text.Trim), Val(TXTBCHILD.Text.Trim), Val(TXTBCHILDINR.Text.Trim), Val(TXTBINFANT.Text.Trim), Val(TXTBINFANTINR.Text.Trim))
            getMISCsrno(GRIDMISC)
        ElseIf gridMiscDoubleClick = True Then
            GRIDMISC.Item(GBSrno.Index, tempMISCrow).Value = Val(TXTBSRNO.Text.Trim)
            GRIDMISC.Item(GBMISC.Index, tempMISCrow).Value = (CMBMISCEXP.Text.Trim)
            GRIDMISC.Item(GBCURRENCY.Index, tempMISCrow).Value = (CMBBCURRENCY.Text.Trim)
            GRIDMISC.Item(GBADULT.Index, tempMISCrow).Value = Val(TXTBADULT.Text.Trim)
            GRIDMISC.Item(GBADULTINR.Index, tempMISCrow).Value = Val(TXTBADULTINR.Text.Trim)
            GRIDMISC.Item(GBCHILD.Index, tempMISCrow).Value = Val(TXTBCHILD.Text.Trim)
            GRIDMISC.Item(GBCHILDINR.Index, tempMISCrow).Value = Val(TXTBCHILDINR.Text.Trim)
            GRIDMISC.Item(GBINFANT.Index, tempMISCrow).Value = Val(TXTBINFANT.Text.Trim)
            GRIDMISC.Item(GBINFANTINR.Index, tempMISCrow).Value = Val(TXTBINFANTINR.Text.Trim)
            gridMiscDoubleClick = False
        End If

        GRIDMISC.FirstDisplayedScrollingRowIndex = GRIDMISC.RowCount - 1

        TXTBSRNO.Clear()
        CMBMISCEXP.Text = ""
        CMBBCURRENCY.Text = ""
        TXTBADULT.Clear()
        TXTBADULTINR.Clear()
        TXTBCHILD.Clear()
        TXTBCHILDINR.Clear()
        TXTBINFANT.Clear()
        TXTBINFANTINR.Clear()
        TXTBSRNO.Focus()

    End Sub

    Sub getMISCsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCINFANTINR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCINFANTINR.Validating
        If CMBAIRLINE.Text.Trim <> "" And TXTFLIGHTDETAILS.Text.Trim <> "" And CMBCCURRENCY.Text.Trim <> "" And (TXTCADULTINR.Text.Trim >= 0) And Val(TXTCCHILDINR.Text.Trim >= 0) And Val(TXTCINFANTINR.Text.Trim >= 0) Then
            fillFlightGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillFlightGrid()

        GRIDFLIGHT.Enabled = True
        If gridAirDoubleClick = False Then
            GRIDFLIGHT.Rows.Add(Val(TXTCSRNO.Text.Trim), CMBAIRLINE.Text.Trim, TXTFLIGHTDETAILS.Text.Trim, TXTNARRATION.Text.Trim, Format(FLIGHTDATE.Value.Date, "dd/MM/yyyy"), TXTFLIGHTNO.Text.Trim, TXTARRIVAL.Text.Trim, CMBCCURRENCY.Text.Trim, Val(TXTCADULT.Text.Trim), Val(TXTCADULTINR.Text.Trim), Val(TXTCCHILD.Text.Trim), Val(TXTCCHILDINR.Text.Trim), Val(TXTCINFANT.Text.Trim), Val(TXTCINFANTINR.Text.Trim))
            getFLIGHTsrno(GRIDFLIGHT)
        ElseIf gridAirDoubleClick = True Then
            GRIDFLIGHT.Item(GCSrno.Index, tempAIRrow).Value = Val(TXTCSRNO.Text.Trim)
            GRIDFLIGHT.Item(GCAIRLINE.Index, tempAIRrow).Value = (CMBAIRLINE.Text.Trim)
            GRIDFLIGHT.Item(GCFLIGHTDETAIL.Index, tempAIRrow).Value = (TXTFLIGHTDETAILS.Text.Trim)
            GRIDFLIGHT.Item(GCNARRATION.Index, tempAIRrow).Value = (TXTNARRATION.Text.Trim)
            GRIDFLIGHT.Item(GCDATE.Index, tempAIRrow).Value = Format(FLIGHTDATE.Value.Date, "dd/MM/yyyy")
            GRIDFLIGHT.Item(GCFLIGHTNO.Index, tempAIRrow).Value = (TXTFLIGHTNO.Text.Trim)
            GRIDFLIGHT.Item(GCARRIVAL.Index, tempAIRrow).Value = (TXTARRIVAL.Text.Trim)
            GRIDFLIGHT.Item(GCCURRENCY.Index, tempAIRrow).Value = (CMBCCURRENCY.Text.Trim)
            GRIDFLIGHT.Item(GCADULT.Index, tempAIRrow).Value = Val(TXTCADULT.Text.Trim)
            GRIDFLIGHT.Item(GCADULTINR.Index, tempAIRrow).Value = Val(TXTCADULTINR.Text.Trim)
            GRIDFLIGHT.Item(GCCHILD.Index, tempAIRrow).Value = Val(TXTCCHILD.Text.Trim)
            GRIDFLIGHT.Item(GCCHILDINR.Index, tempAIRrow).Value = Val(TXTCCHILDINR.Text.Trim)
            GRIDFLIGHT.Item(GCINFANT.Index, tempAIRrow).Value = Val(TXTCINFANT.Text.Trim)
            GRIDFLIGHT.Item(GCINFANTINR.Index, tempAIRrow).Value = Val(TXTCINFANTINR.Text.Trim)
            gridAirDoubleClick = False
        End If

        GRIDFLIGHT.FirstDisplayedScrollingRowIndex = GRIDFLIGHT.RowCount - 1

        TXTCSRNO.Clear()
        CMBAIRLINE.Text = ""
        TXTFLIGHTDETAILS.Clear()
        TXTNARRATION.Clear()
        FLIGHTDATE.Value = Mydate
        TXTFLIGHTNO.Clear()
        TXTARRIVAL.Clear()
        CMBCCURRENCY.Text = ""
        TXTCADULT.Clear()
        TXTCADULTINR.Clear()
        TXTCCHILD.Clear()
        TXTCCHILDINR.Clear()
        TXTCINFANT.Clear()
        TXTCINFANTINR.Clear()
        TXTCSRNO.Focus()

    End Sub

    Sub getFLIGHTsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTDINFANTINR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDINFANTINR.Validating
        If CMBCORDINATOR.Text.Trim <> "" And CMBDCURRENCY.Text.Trim <> "" And Val(TXTDADULTINR.Text.Trim >= 0) And Val(TXTDCHILDINR.Text.Trim >= 0) And Val(TXTDINFANTINR.Text.Trim >= 0) Then
            fillCordinatorGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillCordinatorGrid()

        GRIDCORDINATOR.Enabled = True
        If gridCordiDoubleClick = False Then
            GRIDCORDINATOR.Rows.Add(Val(TXTDSRNO.Text.Trim), CMBCORDINATOR.Text.Trim, CMBDCURRENCY.Text.Trim, Val(TXTDADULT.Text.Trim), Val(TXTDADULTINR.Text.Trim), Val(TXTDCHILD.Text.Trim), Val(TXTDCHILDINR.Text.Trim), Val(TXTDINFANT.Text.Trim), Val(TXTDINFANTINR.Text.Trim))
            getCORDINATORsrno(GRIDCORDINATOR)
        ElseIf gridCordiDoubleClick = True Then
            GRIDCORDINATOR.Item(GDSrno.Index, tempCORDrow).Value = Val(TXTDSRNO.Text.Trim)
            GRIDCORDINATOR.Item(GDCORDINATOR.Index, tempCORDrow).Value = (CMBCORDINATOR.Text.Trim)
            GRIDCORDINATOR.Item(GDCURRENCY.Index, tempCORDrow).Value = (CMBDCURRENCY.Text.Trim)
            GRIDCORDINATOR.Item(GDADULT.Index, tempCORDrow).Value = Val(TXTDADULT.Text.Trim)
            GRIDCORDINATOR.Item(GDADULTINR.Index, tempCORDrow).Value = Val(TXTDADULTINR.Text.Trim)
            GRIDCORDINATOR.Item(GDCHILD.Index, tempCORDrow).Value = Val(TXTDCHILD.Text.Trim)
            GRIDCORDINATOR.Item(GDCHILDINR.Index, tempCORDrow).Value = Val(TXTDCHILDINR.Text.Trim)
            GRIDCORDINATOR.Item(GDINFANT.Index, tempCORDrow).Value = Val(TXTDINFANT.Text.Trim)
            GRIDCORDINATOR.Item(GDINFANTINR.Index, tempCORDrow).Value = Val(TXTDINFANTINR.Text.Trim)
            gridCordiDoubleClick = False
        End If

        GRIDCORDINATOR.FirstDisplayedScrollingRowIndex = GRIDCORDINATOR.RowCount - 1

        TXTDSRNO.Clear()
        CMBCORDINATOR.Text = ""
        CMBDCURRENCY.Text = ""
        TXTDADULT.Clear()
        TXTDADULTINR.Clear()
        TXTDCHILD.Clear()
        TXTDCHILDINR.Clear()
        TXTDINFANT.Clear()
        TXTDINFANTINR.Clear()
        TXTDSRNO.Focus()

    End Sub

    Sub getCORDINATORsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows

                row.Cells(0).Value = row.Index + 1

            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTLEADERCOST_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLEADERCOST.Validating
        If CMBLEADER.Text.Trim <> "" Then
            fillLeaderGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillLeaderGrid()

        GRIDLEADER.Enabled = True
        If gridLeaderdoubleclick = False Then
            GRIDLEADER.Rows.Add(Val(TXTESRNO.Text.Trim), CMBLEADER.Text.Trim, Val(TXTCONTRI.Text.Trim), Val(TXTINCENTIVES.Text.Trim), Val(TXTREBATE.Text.Trim), Val(TXTLEADERCOST.Text.Trim))
            getLEADERsrno(GRIDLEADER)
        ElseIf gridLeaderdoubleclick = True Then
            GRIDLEADER.Item(GESrno.Index, tempLEADERrow).Value = Val(TXTESRNO.Text.Trim)
            GRIDLEADER.Item(GELEADER.Index, tempLEADERrow).Value = (CMBLEADER.Text.Trim)
            GRIDLEADER.Item(GECONTRIBUTION.Index, tempLEADERrow).Value = Val(TXTCONTRI.Text.Trim)
            GRIDLEADER.Item(GEINCENTIVES.Index, tempLEADERrow).Value = Val(TXTINCENTIVES.Text.Trim)
            GRIDLEADER.Item(GEREBATED.Index, tempLEADERrow).Value = Val(TXTREBATE.Text.Trim)
            GRIDLEADER.Item(GELEADERCOST.Index, tempLEADERrow).Value = Val(TXTLEADERCOST.Text.Trim)
            gridLeaderdoubleclick = False
        End If

        GRIDLEADER.FirstDisplayedScrollingRowIndex = GRIDLEADER.RowCount - 1

        TXTESRNO.Clear()
        CMBLEADER.Text = ""
        TXTCONTRI.Clear()
        TXTINCENTIVES.Clear()
        TXTREBATE.Clear()
        TXTLEADERCOST.Clear()
        TXTESRNO.Focus()

    End Sub

    Sub getLEADERsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTFINFANTINR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFINFANTINR.Validating
        If CMBADDSERVICES.Text.Trim <> "" And CMBFCURRENCY.Text.Trim <> "" And Val(TXTFADULTINR.Text.Trim >= 0) And Val(TXTFCHILDINR.Text.Trim >= 0) And Val(TXTFINFANTINR.Text.Trim >= 0) Then
            fillAddServicesGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillAddServicesGrid()

        GRIDADDSERVICES.Enabled = True
        If GRIDAddServDOUBLECLICK = False Then
            GRIDADDSERVICES.Rows.Add(Val(TXTFSRNO.Text.Trim), CMBADDSERVICES.Text.Trim, CMBFCURRENCY.Text.Trim, Val(TXTFADULT.Text.Trim), Val(TXTFADULTINR.Text.Trim), Val(TXTFCHILD.Text.Trim), Val(TXTFCHILDINR.Text.Trim), Val(TXTFINFANT.Text.Trim), Val(TXTFINFANTINR.Text.Trim))
            getAddServicesrno(GRIDADDSERVICES)
        ElseIf GRIDAddServDOUBLECLICK = True Then
            GRIDADDSERVICES.Item(GFSrno.Index, tempADDSERVrow).Value = Val(TXTFSRNO.Text.Trim)
            GRIDADDSERVICES.Item(GFADDSERVICE.Index, tempADDSERVrow).Value = (CMBADDSERVICES.Text.Trim)
            GRIDADDSERVICES.Item(GFCURRENCY.Index, tempADDSERVrow).Value = (CMBFCURRENCY.Text.Trim)
            GRIDADDSERVICES.Item(GFADULT.Index, tempADDSERVrow).Value = Val(TXTFADULT.Text.Trim)
            GRIDADDSERVICES.Item(GFADULTINR.Index, tempADDSERVrow).Value = Val(TXTFADULTINR.Text.Trim)
            GRIDADDSERVICES.Item(GFCHILD.Index, tempADDSERVrow).Value = Val(TXTFCHILD.Text.Trim)
            GRIDADDSERVICES.Item(GFCHILDINR.Index, tempADDSERVrow).Value = Val(TXTFCHILDINR.Text.Trim)
            GRIDADDSERVICES.Item(GFINFANT.Index, tempADDSERVrow).Value = Val(TXTFINFANT.Text.Trim)
            GRIDADDSERVICES.Item(GFINFANTINR.Index, tempADDSERVrow).Value = Val(TXTFINFANTINR.Text.Trim)

            GRIDAddServDOUBLECLICK = False
        End If

        GRIDADDSERVICES.FirstDisplayedScrollingRowIndex = GRIDADDSERVICES.RowCount - 1

        TXTFSRNO.Clear()
        CMBADDSERVICES.Text = ""
        CMBFCURRENCY.Text = ""
        TXTFADULT.Clear()
        TXTFADULTINR.Clear()
        TXTFCHILD.Clear()
        TXTFCHILDINR.Clear()
        TXTFINFANT.Clear()
        TXTFINFANTINR.Clear()
        TXTFSRNO.Focus()

    End Sub

    Sub getAddServicesrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub TXTPURINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPURINFANT.Validating
        If CMBSUPPLIER.Text.Trim <> "" And Val(TXTPURADULT.Text.Trim) >= 0 And Val(TXTPURCHILD.Text.Trim) >= 0 And Val(TXTPURINFANT.Text.Trim) >= 0 Then
            fillPurchaseGrid()
            total()
        Else
            MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
            Exit Sub
        End If
    End Sub

    Sub fillPurchaseGrid()

        GRIDPURCHASE.Enabled = True
        If GRIDPurDOUBLECLICK = False Then
            GRIDPURCHASE.Rows.Add(Val(TXTPURSRNO.Text.Trim), CMBSUPPLIER.Text.Trim, Val(TXTPURADULT.Text.Trim), Val(TXTPURCHILD.Text.Trim), Val(TXTPURINFANT.Text.Trim))
            getPURCHASEsrno(GRIDPURCHASE)
        ElseIf GRIDPurDOUBLECLICK = True Then
            GRIDPURCHASE.Item(GPURSrno.Index, tempPURCHASErow).Value = Val(TXTPURSRNO.Text.Trim)
            GRIDPURCHASE.Item(GPURNAME.Index, tempPURCHASErow).Value = (CMBSUPPLIER.Text.Trim)
            GRIDPURCHASE.Item(GPURADULT.Index, tempPURCHASErow).Value = Val(TXTPURADULT.Text.Trim)
            GRIDPURCHASE.Item(GPURCHILD.Index, tempPURCHASErow).Value = Val(TXTPURCHILD.Text.Trim)
            GRIDPURCHASE.Item(GPURINFANT.Index, tempPURCHASErow).Value = Val(TXTPURINFANT.Text.Trim)

            GRIDPurDOUBLECLICK = False
        End If

        GRIDPURCHASE.FirstDisplayedScrollingRowIndex = GRIDPURCHASE.RowCount - 1

        TXTPURSRNO.Clear()
        CMBSUPPLIER.Text = ""
        TXTPURADULT.Clear()
        TXTPURCHILD.Clear()
        TXTPURINFANT.Clear()
        TXTPURSRNO.Focus()

    End Sub

    Sub getPURCHASEsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCURRENCY_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCURRENCY.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCURRENCY.Item(GCURSRNO.Index, e.RowIndex).Value <> Nothing Then
                gridCurDoubleClick = True
                TXTCURSRNO.Text = GRIDCURRENCY.Item(GCURSRNO.Index, e.RowIndex).Value.ToString
                CMBCURCURRENCY.Text = GRIDCURRENCY.Item(GCURCURRENCY.Index, e.RowIndex).Value.ToString
                TXTCURRATE.Text = GRIDCURRENCY.Item(GCURRATE.Index, e.RowIndex).Value.ToString
                tempCURrow = e.RowIndex
                TXTCURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOUNTRY_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOUNTRY.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCOUNTRY.Item(GCONSRNO.Index, e.RowIndex).Value <> Nothing Then
                gridConDoubleClick = True
                TXTCONSRNO.Text = GRIDCOUNTRY.Item(GCONSRNO.Index, e.RowIndex).Value.ToString
                CMBCONCOUNTRY.Text = GRIDCOUNTRY.Item(GCONCOUNTRY.Index, e.RowIndex).Value.ToString
                CMBCONCITY.Text = GRIDCOUNTRY.Item(GCONCITY.Index, e.RowIndex).Value.ToString
                CONFROMDATE.Value = GRIDCOUNTRY.Item(GCONFROMDATE.Index, e.RowIndex).Value
                CONTODATE.Value = GRIDCOUNTRY.Item(GCONTODATE.Index, e.RowIndex).Value
                tempCONTRYrow = e.RowIndex
                TXTCONSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSERVICES_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSERVICES.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDSERVICES.Item(GASrno.Index, e.RowIndex).Value <> Nothing Then
                gridServiceDoubleClick = True
                TXTASRNO.Text = GRIDSERVICES.Item(GASrno.Index, e.RowIndex).Value
                CMBANAME.Text = GRIDSERVICES.Item(GANAME.Index, e.RowIndex).Value.ToString
                CMBACURRENCY.Text = GRIDSERVICES.Item(GACURRENCY.Index, e.RowIndex).Value.ToString
                TXTAADULT.Text = GRIDSERVICES.Item(GAADULT.Index, e.RowIndex).Value.ToString
                TXTAADULTINR.Text = GRIDSERVICES.Item(GAADULTINR.Index, e.RowIndex).Value.ToString
                TXTACHILD.Text = GRIDSERVICES.Item(GACHILD.Index, e.RowIndex).Value.ToString
                TXTACHILDINR.Text = GRIDSERVICES.Item(GACHILDINR.Index, e.RowIndex).Value.ToString
                TXTAINFANT.Text = GRIDSERVICES.Item(GAINFANT.Index, e.RowIndex).Value.ToString
                TXTAINFANTINR.Text = GRIDSERVICES.Item(GAINFANTINR.Index, e.RowIndex).Value.ToString
                CMBSERVICES.Text = GRIDSERVICES.Item(GType.Index, e.RowIndex).Value.ToString
                tempSERVICErow = e.RowIndex
                TXTASRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDMISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDMISC.Item(GBSrno.Index, e.RowIndex).Value <> Nothing Then
                gridMiscDoubleClick = True
                TXTBSRNO.Text = GRIDMISC.Item(GBSrno.Index, e.RowIndex).Value
                CMBMISCEXP.Text = GRIDMISC.Item(GBMISC.Index, e.RowIndex).Value.ToString
                CMBBCURRENCY.Text = GRIDMISC.Item(GBCURRENCY.Index, e.RowIndex).Value.ToString
                TXTBADULT.Text = GRIDMISC.Item(GBADULT.Index, e.RowIndex).Value.ToString
                TXTBADULTINR.Text = GRIDMISC.Item(GBADULTINR.Index, e.RowIndex).Value.ToString
                TXTBCHILD.Text = GRIDMISC.Item(GBCHILD.Index, e.RowIndex).Value.ToString
                TXTBCHILDINR.Text = GRIDMISC.Item(GBCHILDINR.Index, e.RowIndex).Value.ToString
                TXTBINFANT.Text = GRIDMISC.Item(GBINFANT.Index, e.RowIndex).Value.ToString
                TXTBINFANTINR.Text = GRIDMISC.Item(GBINFANTINR.Index, e.RowIndex).Value.ToString

                tempMISCrow = e.RowIndex
                TXTBSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDFLIGHT_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDFLIGHT.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDFLIGHT.Item(GCSrno.Index, e.RowIndex).Value <> Nothing Then
                gridAirDoubleClick = True
                TXTCSRNO.Text = GRIDFLIGHT.Item(GCSrno.Index, e.RowIndex).Value
                CMBAIRLINE.Text = GRIDFLIGHT.Item(GCAIRLINE.Index, e.RowIndex).Value.ToString
                TXTFLIGHTDETAILS.Text = GRIDFLIGHT.Item(GCFLIGHTDETAIL.Index, e.RowIndex).Value.ToString
                TXTNARRATION.Text = GRIDFLIGHT.Item(GCNARRATION.Index, e.RowIndex).Value.ToString
                FLIGHTDATE.Value = GRIDFLIGHT.Item(GCDATE.Index, e.RowIndex).Value.ToString
                TXTFLIGHTNO.Text = GRIDFLIGHT.Item(GCFLIGHTNO.Index, e.RowIndex).Value.ToString
                TXTARRIVAL.Text = GRIDFLIGHT.Item(GCARRIVAL.Index, e.RowIndex).Value.ToString
                CMBCCURRENCY.Text = GRIDFLIGHT.Item(GCCURRENCY.Index, e.RowIndex).Value.ToString
                TXTCADULT.Text = GRIDFLIGHT.Item(GCADULT.Index, e.RowIndex).Value.ToString
                TXTCADULTINR.Text = GRIDFLIGHT.Item(GCADULTINR.Index, e.RowIndex).Value.ToString
                TXTCCHILD.Text = GRIDFLIGHT.Item(GCCHILD.Index, e.RowIndex).Value.ToString
                TXTCCHILDINR.Text = GRIDFLIGHT.Item(GCCHILDINR.Index, e.RowIndex).Value.ToString
                TXTCINFANT.Text = GRIDFLIGHT.Item(GCINFANT.Index, e.RowIndex).Value.ToString
                TXTCINFANTINR.Text = GRIDFLIGHT.Item(GCINFANTINR.Index, e.RowIndex).Value.ToString
                tempAIRrow = e.RowIndex
                TXTCSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCORDINATOR_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCORDINATOR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCORDINATOR.Item(GBSrno.Index, e.RowIndex).Value <> Nothing Then
                gridCordiDoubleClick = True
                TXTDSRNO.Text = GRIDCORDINATOR.Item(GDSrno.Index, e.RowIndex).Value
                CMBCORDINATOR.Text = GRIDCORDINATOR.Item(GDCORDINATOR.Index, e.RowIndex).Value.ToString
                CMBDCURRENCY.Text = GRIDCORDINATOR.Item(GDCURRENCY.Index, e.RowIndex).Value.ToString
                TXTDADULT.Text = GRIDCORDINATOR.Item(GDADULT.Index, e.RowIndex).Value.ToString
                TXTDADULTINR.Text = GRIDCORDINATOR.Item(GDADULTINR.Index, e.RowIndex).Value.ToString
                TXTDCHILD.Text = GRIDCORDINATOR.Item(GDCHILD.Index, e.RowIndex).Value.ToString
                TXTDCHILDINR.Text = GRIDCORDINATOR.Item(GDCHILDINR.Index, e.RowIndex).Value.ToString
                TXTDINFANT.Text = GRIDCORDINATOR.Item(GDINFANT.Index, e.RowIndex).Value.ToString
                TXTDINFANTINR.Text = GRIDCORDINATOR.Item(GDINFANTINR.Index, e.RowIndex).Value.ToString

                tempCORDrow = e.RowIndex
                TXTDSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDLEADER_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDLEADER.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDLEADER.Item(GESrno.Index, e.RowIndex).Value <> Nothing Then
                gridLeaderdoubleclick = True
                TXTESRNO.Text = GRIDLEADER.Item(GESrno.Index, e.RowIndex).Value
                CMBLEADER.Text = GRIDLEADER.Item(GELEADER.Index, e.RowIndex).Value.ToString
                TXTCONTRI.Text = GRIDLEADER.Item(GECONTRIBUTION.Index, e.RowIndex).Value.ToString
                TXTINCENTIVES.Text = GRIDLEADER.Item(GEINCENTIVES.Index, e.RowIndex).Value.ToString
                TXTREBATE.Text = GRIDLEADER.Item(GEREBATED.Index, e.RowIndex).Value.ToString
                TXTLEADERCOST.Text = GRIDLEADER.Item(GELEADERCOST.Index, e.RowIndex).Value.ToString
                tempLEADERrow = e.RowIndex
                TXTESRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDADDSERVICES_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDADDSERVICES.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDADDSERVICES.Item(GFSrno.Index, e.RowIndex).Value <> Nothing Then
                GRIDAddServDOUBLECLICK = True
                TXTFSRNO.Text = GRIDADDSERVICES.Item(GFSrno.Index, e.RowIndex).Value
                CMBADDSERVICES.Text = GRIDADDSERVICES.Item(GFADDSERVICE.Index, e.RowIndex).Value.ToString
                CMBFCURRENCY.Text = GRIDADDSERVICES.Item(GFCURRENCY.Index, e.RowIndex).Value.ToString
                TXTFADULT.Text = GRIDADDSERVICES.Item(GFADULT.Index, e.RowIndex).Value.ToString
                TXTFADULTINR.Text = GRIDADDSERVICES.Item(GFADULTINR.Index, e.RowIndex).Value.ToString
                TXTFCHILD.Text = GRIDADDSERVICES.Item(GFCHILD.Index, e.RowIndex).Value.ToString
                TXTFCHILDINR.Text = GRIDADDSERVICES.Item(GFCHILDINR.Index, e.RowIndex).Value.ToString
                TXTFINFANT.Text = GRIDADDSERVICES.Item(GFINFANT.Index, e.RowIndex).Value.ToString
                TXTFINFANTINR.Text = GRIDADDSERVICES.Item(GFINFANTINR.Index, e.RowIndex).Value.ToString

                tempADDSERVrow = e.RowIndex
                TXTFSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPURCHASE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDPURCHASE.Item(GPURSrno.Index, e.RowIndex).Value <> Nothing Then
                GRIDPurDOUBLECLICK = True
                TXTPURSRNO.Text = GRIDPURCHASE.Item(GPURSrno.Index, e.RowIndex).Value
                CMBSUPPLIER.Text = GRIDPURCHASE.Item(GPURNAME.Index, e.RowIndex).Value.ToString
                TXTPURADULT.Text = GRIDPURCHASE.Item(GPURADULT.Index, e.RowIndex).Value
                TXTPURCHILD.Text = GRIDPURCHASE.Item(GPURCHILD.Index, e.RowIndex).Value
                TXTPURINFANT.Text = GRIDPURCHASE.Item(GPURINFANT.Index, e.RowIndex).Value

                tempPURCHASErow = e.RowIndex
                TXTPURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSERVICES_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSERVICES.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSERVICES.RowCount > 0 Then
                If gridServiceDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSERVICES.Rows.RemoveAt(GRIDSERVICES.CurrentRow.Index)
                total()
                getServicesrno(GRIDSERVICES)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDMISC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDMISC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMISC.RowCount > 0 Then
                If gridMiscDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDMISC.Rows.RemoveAt(GRIDMISC.CurrentRow.Index)
                total()
                getMISCsrno(GRIDMISC)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDFLIGHT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFLIGHT.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDFLIGHT.RowCount > 0 Then
                If gridAirDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDFLIGHT.Rows.RemoveAt(GRIDFLIGHT.CurrentRow.Index)
                total()
                getFLIGHTsrno(GRIDFLIGHT)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCORDINATOR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCORDINATOR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCORDINATOR.RowCount > 0 Then
                If gridCordiDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDCORDINATOR.Rows.RemoveAt(GRIDCORDINATOR.CurrentRow.Index)
                total()
                getCORDINATORsrno(GRIDCORDINATOR)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDLEADER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDLEADER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDLEADER.RowCount > 0 Then
                If gridLeaderdoubleclick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDLEADER.Rows.RemoveAt(GRIDLEADER.CurrentRow.Index)
                total()
                getLEADERsrno(GRIDLEADER)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDADDSERVICES_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDADDSERVICES.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDADDSERVICES.RowCount > 0 Then
                If GRIDAddServDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDADDSERVICES.Rows.RemoveAt(GRIDADDSERVICES.CurrentRow.Index)
                total()
                getAddServicesrno(GRIDADDSERVICES)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPURCHASE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPURCHASE.RowCount > 0 Then
                If GRIDPurDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDPURCHASE.Rows.RemoveAt(GRIDPURCHASE.CurrentRow.Index)
                total()
                getPURCHASEsrno(GRIDPURCHASE)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCURRENCY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCURRENCY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCURRENCY.RowCount > 0 Then
                If GRIDPurDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDCURRENCY.Rows.RemoveAt(GRIDCURRENCY.CurrentRow.Index)
                getcursrno(GRIDCURRENCY)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDCOUNTRY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCOUNTRY.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCOUNTRY.RowCount > 0 Then
                If gridConDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDCOUNTRY.Rows.RemoveAt(GRIDCOUNTRY.CurrentRow.Index)
                getConsrno(GRIDCOUNTRY)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDSERVICES.RowCount = 0
            TEMPTOURNO = Val(tstxtbillno.Text)
            If TEMPTOURNO > 0 Then
                edit = True
                TourMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDSERVICES.RowCount = 0
LINE1:
            TEMPTOURNO = Val(TXTTOURNO.Text) - 1
Line2:
            If TEMPTOURNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOUR_NO ", "", "  TOURMASTER ", " AND TOUR_NO = '" & TEMPTOURNO & "' AND TOUR_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    TourMaster_Load(sender, e)
                Else
                    TEMPTOURNO = Val(TEMPTOURNO - 1)
                    GoTo Line2
                End If
            Else
                clear()
                edit = False
            End If

            If GRIDCURRENCY.RowCount = 0 And TEMPTOURNO > 1 Then
                TXTTOURNO.Text = TEMPTOURNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDSERVICES.RowCount = 0
LINE1:
            TEMPTOURNO = Val(TXTTOURNO.Text) + 1
            getmax_BOOKING_no()
            Dim MAXNO As Integer = TXTTOURNO.Text.Trim
            clear()
            If Val(TXTTOURNO.Text) - 1 >= TEMPTOURNO Then
                edit = True
                TourMaster_Load(sender, e)
            Else
                clear()
                edit = False
            End If
            If GRIDSERVICES.RowCount = 0 And TEMPTOURNO < MAXNO Then
                TXTTOURNO.Text = TEMPTOURNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub STARTDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STARTDATE.Validated
        If TXTDAYS.Text.Trim <> "" Then
            If edit = False Then ENDDATE.Value = DateAdd(DateInterval.Day, Val(TXTDAYS.Text.Trim) - 1, STARTDATE.Value)
            CONFROMDATE.Value = STARTDATE.Value.Date
            CONTODATE.Value = DateAdd(DateInterval.Day, 1, CONFROMDATE.Value)
        Else
            If edit = False Then ENDDATE.Value = DateAdd(DateInterval.Day, 1, STARTDATE.Value)
            CONFROMDATE.Value = STARTDATE.Value.Date
            CONTODATE.Value = DateAdd(DateInterval.Day, 1, CONFROMDATE.Value)
        End If
        FLIGHTDATE.Value = STARTDATE.Value.Date
    End Sub

    Private Sub CMBCURCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCURCURRENCY.Enter
        Try
            If CMBCURCURRENCY.Text.Trim = "" Then fillCurrency(CMBCURCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONCOUNTRY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCONCOUNTRY.Enter
        Try
            If CMBCONCOUNTRY.Text.Trim = "" Then fillCountry(CMBCONCOUNTRY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCONCITY.Enter
        Try
            If CMBCONCITY.Text.Trim = "" Then fillCityCode(CMBCONCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBACURRENCY.Enter
        Try
            If CMBACURRENCY.Text.Trim = "" Then fillCurrency(CMBACURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMISCEXP_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMISCEXP.Enter
        Try
            If CMBMISCEXP.Text.Trim = "" Then fillMISCEXP(CMBMISCEXP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBCURRENCY.Enter
        Try
            If CMBBCURRENCY.Text.Trim = "" Then fillCurrency(CMBBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRLINE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAIRLINE.Enter
        If CMBAIRLINE.Text.Trim = "" Then FILLAIRLINE(CMBAIRLINE, edit, "")
    End Sub

    Private Sub CMBCCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCCURRENCY.Enter
        Try
            If CMBCCURRENCY.Text.Trim = "" Then fillCurrency(CMBCCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCORDINATOR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCORDINATOR.Enter
        Try
            If CMBCORDINATOR.Text.Trim = "" Then FILLGUEST(CMBCORDINATOR, edit, " AND GUEST_CORDINATOR=1")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDCURRENCY.Enter
        Try
            If CMBDCURRENCY.Text.Trim = "" Then fillCurrency(CMBDCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBLEADER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBLEADER.Enter
        Try
            If CMBLEADER.Text.Trim = "" Then FILLGUEST(CMBLEADER, edit, " AND GUEST_LEADER=1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDSERVICES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBADDSERVICES.Enter
        Try
            If CMBADDSERVICES.Text.Trim = "" Then fillSERVICE(CMBADDSERVICES)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFCURRENCY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFCURRENCY.Enter
        Try
            If CMBFCURRENCY.Text.Trim = "" Then fillCurrency(CMBFCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMBSUPPLIER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSUPPLIER.Enter
        Try
            If CMBSUPPLIER.Text.Trim = "" Then fillname(CMBSUPPLIER, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCURCURRENCY.Validating
        Try
            If CMBCURCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCURCURRENCY, e, Me)
            If CMBCURCURRENCY.Text.Trim = "" Then TXTCONSRNO.Focus()
            If CMBCURCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As Windows.Forms.DataGridViewRow In GRIDCURRENCY.Rows
                    If gridCurDoubleClick = False Then
                        If CMBCURCURRENCY.Text = row.Cells(GCURCURRENCY.Index).Value.ToString Then
                            MsgBox("This Currency already exists")
                            e.Cancel = True
                            CMBCURCURRENCY.Focus()
                        End If
                    Else
                        If CMBCURCURRENCY.Text = row.Cells(GCURCURRENCY.Index).Value.ToString And row.Index <> tempCURrow Then
                            MsgBox("This Currency already exists")
                            e.Cancel = True
                            CMBCURCURRENCY.Focus()
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBACURRENCY.Validating
        Try
            If CMBACURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBACURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBCURRENCY.Validating
        Try
            If CMBBCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCCURRENCY.Validating
        Try
            If CMBCCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBCCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDCURRENCY.Validating
        Try
            If CMBDCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBDCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFCURRENCY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFCURRENCY.Validating
        Try
            If CMBFCURRENCY.Text.Trim <> "" Then CURRENCYvalidate(CMBFCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMISCEXP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMISCEXP.Validating
        Try
            If CMBMISCEXP.Text.Trim <> "" Then MISCVALIDATE(CMBMISCEXP, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAIRLINE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAIRLINE.Validating
        If CMBAIRLINE.Text.Trim <> "" Then AIRLINEVALIDATE(CMBAIRLINE, CMBAIRCODE, e, Me, "", , )
    End Sub

    Private Sub CMBCORDINATOR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCORDINATOR.Validating
        Try
            If CMBCORDINATOR.Text.Trim <> "" Then CORDINATORVALIDATE(CMBCORDINATOR, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLEADER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLEADER.Validating
        Try
            If CMBLEADER.Text.Trim <> "" Then LEADERVALIDATE(CMBLEADER, e, Me, TXTGUESTADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDSERVICES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDSERVICES.Validating
        Try
            If CMBADDSERVICES.Text.Trim <> "" Then ADDSERVICEVALIDATE(CMBADDSERVICES, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUPPLIER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSUPPLIER.Validating
        Try
            If CMBSUPPLIER.Text.Trim <> "" Then namevalidate(CMBSUPPLIER, CMBCODE, e, Me, TXTGUESTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSERVICES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSERVICES.Validating
        Try
            CMBANAME.Text = ""
            If CMBSERVICES.Text = "Lawazim" Then
                If CMBANAME.Text.Trim = "" Then fillLAWAZIM(CMBANAME)
            ElseIf CMBSERVICES.Text = "Visa" Then
                If CMBANAME.Text.Trim = "" Then fillVISA(CMBANAME)
            ElseIf CMBSERVICES.Text = "Gift" Then
                If CMBANAME.Text.Trim = "" Then fillGIFT(CMBANAME)
            ElseIf CMBSERVICES.Text = "Transport" Then
                If CMBANAME.Text.Trim = "" Then fillTRANSPORT(CMBANAME)
            ElseIf CMBSERVICES.Text = "Meals" Then
                If CMBANAME.Text.Trim = "" Then FILLPLAN(CMBANAME, edit)
            ElseIf CMBSERVICES.Text = "CountryTax" Then
                If CMBANAME.Text.Trim = "" Then FILLCOUNTRYTAX(CMBANAME, edit)
            Else

                CMBANAME.DataSource = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBANAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBANAME.Validating
        Try
            If CMBSERVICES.Text = "Lawazim" Then
                If CMBANAME.Text.Trim <> "" Then LAWAZIMVALIDATE(CMBANAME, e, Me)
            ElseIf CMBSERVICES.Text = "Visa" Then
                If CMBANAME.Text.Trim <> "" Then VISAVALIDATE(CMBANAME, e, Me)
            ElseIf CMBSERVICES.Text = "Gift" Then
                If CMBANAME.Text.Trim <> "" Then GIFTVALIDATE(CMBANAME, e, Me)
            ElseIf CMBSERVICES.Text = "Transport" Then
                If CMBANAME.Text.Trim <> "" Then TRANSPORTVALIDATE(CMBANAME, e, Me)
            ElseIf CMBSERVICES.Text = "Meals" Then
                If CMBANAME.Text.Trim <> "" Then MEALPLANVALIDATE(CMBANAME, e, Me)
            ElseIf CMBSERVICES.Text = "CountryTax" Then
                If CMBANAME.Text.Trim <> "" Then COUNTRYTAXVALIDATE(CMBANAME, e, Me)
            End If

            If CMBSERVICES.Text.Trim <> "" And CMBANAME.Text.Trim <> "" And GRIDSERVICES.RowCount > 0 Then

                For Each row As Windows.Forms.DataGridViewRow In GRIDSERVICES.Rows
                    If gridServiceDoubleClick = False Then
                        If CMBSERVICES.Text = row.Cells(GType.Index).Value.ToString And CMBANAME.Text = row.Cells(GANAME.Index).Value.ToString Then
                            MsgBox("This Service Type and Service Name already exists")
                            e.Cancel = True
                            CMBSERVICES.Focus()
                        End If
                    Else
                        If CMBSERVICES.Text = row.Cells(GType.Index).Value.ToString And CMBANAME.Text = row.Cells(GANAME.Index).Value.ToString And row.Index <> tempSERVICErow Then
                            MsgBox("This Service Type and Service Name already exists")
                            e.Cancel = True
                            CMBANAME.Focus()
                        End If
                    End If

                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMISCEXP_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBMISCEXP.Validated
        Try
            If CMBMISCEXP.Text.Trim <> "" Then
                TXTBADULT.Clear()
                TXTBADULTINR.Clear()
                TXTBCHILD.Clear()
                TXTBCHILDINR.Clear()
                TXTBINFANT.Clear()
                TXTBINFANTINR.Clear()
                CMBBCURRENCY.Text = ""

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster
                dttable = objCommon.search(" ISNULL(MISC_adult, 0) AS ADULT, ISNULL(MISC_child, 0) AS CHILD, ISNULL(MISC_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CODE", "", " MISCEXPMASTER LEFT OUTER JOIN CURRENCYMASTER ON MISCEXPMASTER.MISC_currencyid = CURRENCYMASTER.cur_id AND MISCEXPMASTER.MISC_yearid = CURRENCYMASTER.cur_yearid ", " and MISC_NAME = '" & CMBMISCEXP.Text.Trim & "' and MISC_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTBADULT.Text = dttable.Rows(0).Item(0).ToString
                    TXTBCHILD.Text = dttable.Rows(0).Item(1).ToString
                    TXTBINFANT.Text = dttable.Rows(0).Item(2).ToString
                    CMBBCURRENCY.Text = dttable.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBCURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBCURRENCY.Validated
        Try
            If CMBBCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then


                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBBCURRENCY.Text = STRCODE Then
                        PRESENT = True
                        TXTBADULTINR.Text = Val(TXTBADULT.Text.Trim) * Val(STRRATE)
                        TXTBCHILDINR.Text = Val(TXTBCHILD.Text.Trim) * Val(STRRATE)
                        TXTBINFANTINR.Text = Val(TXTBINFANT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")
                    CMBBCURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            Else
                MsgBox("Currency Not added !")
                CMBBCURRENCY.Text = ""
                CMBCURCURRENCY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCCURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCCURRENCY.Validated
        Try
            If CMBCCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBCCURRENCY.Text = STRCODE Then
                        PRESENT = True
                        TXTCADULTINR.Text = Val(TXTCADULT.Text.Trim) * Val(STRRATE)
                        TXTCCHILDINR.Text = Val(TXTCCHILD.Text.Trim) * Val(STRRATE)
                        TXTCINFANTINR.Text = Val(TXTCINFANT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")

                    CMBCCURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            Else
                MsgBox("Currency Not added !")
                CMBCCURRENCY.Text = ""
                CMBCURCURRENCY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBACURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBACURRENCY.Validated
        Try
            If CMBACURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBACURRENCY.Text = STRCODE Then
                        PRESENT = True
                        TXTAADULTINR.Text = Val(TXTAADULT.Text.Trim) * Val(STRRATE)
                        TXTACHILDINR.Text = Val(TXTACHILD.Text.Trim) * Val(STRRATE)
                        TXTAINFANTINR.Text = Val(TXTAINFANT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")
                    CMBACURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            Else
                MsgBox("Currency Not added !")
                CMBACURRENCY.Text = ""
                CMBCURCURRENCY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDCURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDCURRENCY.Validated
        Try
            If CMBDCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBDCURRENCY.Text = STRCODE Then
                        PRESENT = True
                        TXTDADULTINR.Text = Val(TXTDADULT.Text.Trim) * Val(STRRATE)
                        TXTDCHILDINR.Text = Val(TXTDCHILD.Text.Trim) * Val(STRRATE)
                        TXTDINFANTINR.Text = Val(TXTDINFANT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")
                    CMBDCURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            Else
                MsgBox("Currency Not added !")
                CMBDCURRENCY.Text = ""
                CMBCURCURRENCY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFCURRENCY_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFCURRENCY.Validated
        Try
            If CMBFCURRENCY.Text.Trim <> "" And GRIDCURRENCY.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCURRENCY.Rows
                    Dim STRCODE As String
                    Dim STRRATE As Double

                    STRCODE = row.Cells(GCURCURRENCY.Index).Value
                    STRRATE = Val(row.Cells(GCURRATE.Index).Value)
                    If CMBFCURRENCY.Text = STRCODE Then
                        PRESENT = True
                        TXTFADULTINR.Text = Val(TXTFADULT.Text.Trim) * Val(STRRATE)
                        TXTFCHILDINR.Text = Val(TXTFCHILD.Text.Trim) * Val(STRRATE)
                        TXTFINFANTINR.Text = Val(TXTFINFANT.Text.Trim) * Val(STRRATE)
                    End If
                Next
                If PRESENT = False Then
                    MsgBox("Currency Not added !")
                    CMBFCURRENCY.Text = ""
                    CMBCURCURRENCY.Focus()
                    Exit Sub
                End If
                PRESENT = False
            Else
                MsgBox("Currency Not added !")
                CMBFCURRENCY.Text = ""
                CMBCURCURRENCY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDSERVICES_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBADDSERVICES.Validated
        Try
            If CMBADDSERVICES.Text.Trim <> "" Then
                TXTFADULT.Clear()
                TXTFADULTINR.Clear()
                TXTFCHILD.Clear()
                TXTFCHILDINR.Clear()
                TXTFINFANT.Clear()
                TXTFINFANTINR.Clear()
                CMBFCURRENCY.Text = ""

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster
                dttable = objCommon.search(" ISNULL(SERVICE_adult, 0) AS ADULT, ISNULL(SERVICE_child, 0) AS CHILD, ISNULL(SERVICE_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE, '') AS CODE ", "", " SERVICEMASTER INNER JOIN CURRENCYMASTER ON SERVICEMASTER.SERVICE_currencyid = CURRENCYMASTER.cur_id AND SERVICEMASTER.SERVICE_yearid = CURRENCYMASTER.cur_yearid ", " and SERVICE_NAME = '" & CMBADDSERVICES.Text.Trim & "' and SERVICE_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTFADULT.Text = dttable.Rows(0).Item(0).ToString
                    TXTFCHILD.Text = dttable.Rows(0).Item(1).ToString
                    TXTFINFANT.Text = dttable.Rows(0).Item(2).ToString
                    CMBFCURRENCY.Text = dttable.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBANAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBANAME.Validated
        Try
            If CMBSERVICES.Text = "Lawazim" Then
                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()
                    CMBACURRENCY.Text = ""

                    Dim dttable As New DataTable
                    Dim objCommon As New ClsCommonMaster
                    dttable = objCommon.search(" ISNULL(LWZM_adult, 0) AS ADULT, ISNULL(LWZM_child, 0) AS CHILD, ISNULL(LWZM_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY ", "", "  LAWAZIMMASTER LEFT OUTER JOIN CURRENCYMASTER ON LAWAZIMMASTER.LWZM_currencyid = CURRENCYMASTER.cur_id ", " and LWZM_NAME = '" & CMBANAME.Text.Trim & "' and LWZM_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                        TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                        TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                        CMBACURRENCY.Text = dttable.Rows(0).Item(3).ToString
                    End If
                End If

            ElseIf CMBSERVICES.Text = "Visa" Then

                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()
                    CMBACURRENCY.Text = ""

                    Dim dttable As New DataTable
                    Dim objCommon As New ClsCommonMaster
                    dttable = objCommon.search(" ISNULL(VISA_adult, 0) AS ADULT, ISNULL(VISA_child, 0) AS CHILD, ISNULL(VISA_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY ", "", " VISAMASTER LEFT OUTER JOIN CURRENCYMASTER ON VISAMASTER.VISA_currencyid = CURRENCYMASTER.cur_id ", " and VISA_NAME = '" & CMBANAME.Text.Trim & "' and VISA_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                        TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                        TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                        CMBACURRENCY.Text = dttable.Rows(0).Item(3).ToString
                    End If
                End If

            ElseIf CMBSERVICES.Text = "Gift" Then

                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()

                    'Dim dttable As New DataTable
                    'Dim objCommon As New ClsCommonMaster
                    'dttable = objCommon.search(" ISNULL(GIFT_adult, 0) AS ADULT, ISNULL(GIFT_child, 0) AS CHILD, ISNULL(GIFT_infant, 0) AS INFANT", "", " GIFTMASTER ", " and GIFT_NAME = '" & CMBANAME.Text.Trim & "' and GIFT_yearid = " & YearId)
                    'If dttable.Rows.Count > 0 Then
                    '    TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                    '    TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                    '    TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                    'End If
                End If

            ElseIf CMBSERVICES.Text = "Transport" Then

                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()
                    CMBACURRENCY.Text = ""

                    Dim dttable As New DataTable
                    Dim objCommon As New ClsCommonMaster
                    dttable = objCommon.search(" ISNULL(TRANS_adult, 0) AS ADULT, ISNULL(TRANS_child, 0) AS CHILD, ISNULL(TRANS_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY  ", "", " TRANSPORTMASTER LEFT OUTER JOIN CURRENCYMASTER ON TRANSPORTMASTER.TRANS_currencyid = CURRENCYMASTER.cur_id   ", " and TRANS_NAME = '" & CMBANAME.Text.Trim & "' and TRANS_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                        TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                        TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                        CMBACURRENCY.Text = dttable.Rows(0).Item(3).ToString

                    End If
                End If

            ElseIf CMBSERVICES.Text = "Meals" Then

                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()
                    CMBACURRENCY.Text = ""
                    Dim dttable As New DataTable
                    Dim objCommon As New ClsCommonMaster
                    dttable = objCommon.search(" ISNULL(MEAL_adult, 0) AS ADULT, ISNULL(MEAL_child, 0) AS CHILD, ISNULL(MEAL_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY  ", "", "   MEALCONGIGMASTER LEFT OUTER JOIN CURRENCYMASTER ON MEALCONGIGMASTER.MEAL_yearid = CURRENCYMASTER.cur_yearid AND MEALCONGIGMASTER.MEAL_currencyid = CURRENCYMASTER.cur_id LEFT OUTER JOIN PLANMASTER ON MEALCONGIGMASTER.MEAL_yearid = PLANMASTER.PLAN_YEARID AND MEALCONGIGMASTER.MEAL_mealid = PLANMASTER.PLAN_ID ", " and PLAN_NAME = '" & CMBANAME.Text.Trim & "' and MEAL_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                        TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                        TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                        CMBACURRENCY.Text = dttable.Rows(0).Item(3).ToString
                    End If
                End If

            ElseIf CMBSERVICES.Text = "CountryTax" Then

                If CMBSERVICES.Text.Trim <> "" Then
                    TXTAADULT.Clear()
                    TXTAADULTINR.Clear()
                    TXTACHILD.Clear()
                    TXTACHILDINR.Clear()
                    TXTAINFANT.Clear()
                    TXTAINFANTINR.Clear()
                    CMBACURRENCY.Text = ""

                    Dim dttable As New DataTable
                    Dim objCommon As New ClsCommonMaster
                    dttable = objCommon.search(" ISNULL(TAX_adult, 0) AS ADULT, ISNULL(TAX_child, 0) AS CHILD, ISNULL(TAX_infant, 0) AS INFANT,ISNULL(CURRENCYMASTER.CUR_CODE,'') AS CURRENCY ", "", " COUNTRYTAXMASTER LEFT OUTER JOIN CURRENCYMASTER ON COUNTRYTAXMASTER.TAX_currencyid = CURRENCYMASTER.cur_id ", " and TAX_NAME = '" & CMBANAME.Text.Trim & "' and TAX_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        TXTAADULT.Text = dttable.Rows(0).Item(0).ToString
                        TXTACHILD.Text = dttable.Rows(0).Item(1).ToString
                        TXTAINFANT.Text = dttable.Rows(0).Item(2).ToString
                        CMBACURRENCY.Text = dttable.Rows(0).Item(3).ToString
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONCOUNTRY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONCOUNTRY.Validating
        Try
            If CMBCONCOUNTRY.Text.Trim <> "" Then CountryValidate(CMBCONCOUNTRY, e, Me)
            If CMBCONCOUNTRY.Text.Trim = "" Then TabControl1.SelectedIndex = 0 And CMBSERVICES.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCONCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCONCITY.Validating
        Try
            If CMBCONCITY.Text.Trim <> "" Then CityCodeValidate(CMBCONCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCADULT.Validating
        Call CMBCCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTCCHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCCHILD.Validating
        Call CMBCCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTCINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCINFANT.Validating
        Call CMBCCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTAADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAADULT.Validating
        Call CMBACURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTACHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTACHILD.Validating
        Call CMBACURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTAINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAINFANT.Validating
        Call CMBACURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTBADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBADULT.Validating
        Call CMBBCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTBCHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBCHILD.Validating
        Call CMBBCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTBINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBINFANT.Validating
        Call CMBBCURRENCY_Validated(sender, e)
    End Sub

    Private Sub CMBCORDINATOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCORDINATOR.Validated
        Try
            If CMBCORDINATOR.Text.Trim <> "" Then
                TXTDADULT.Clear()
                TXTDADULTINR.Clear()
                TXTDCHILD.Clear()
                TXTDCHILDINR.Clear()
                TXTDINFANT.Clear()
                TXTDINFANTINR.Clear()

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster
                dttable = objCommon.search(" ISNULL(GUEST_adult, 0) AS ADULT, ISNULL(GUEST_child, 0) AS CHILD, ISNULL(GUEST_infant, 0) AS INFANT ", "", " GUESTMASTER ", " and GUEST_NAME = '" & CMBCORDINATOR.Text.Trim & "' and GUEST_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    TXTDADULT.Text = dttable.Rows(0).Item(0).ToString
                    TXTDCHILD.Text = dttable.Rows(0).Item(1).ToString
                    TXTDINFANT.Text = dttable.Rows(0).Item(2).ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDADULT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTDADULT.Validated
        Call CMBDCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTDCHILD_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTDCHILD.Validated
        Call CMBDCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTDINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDINFANT.Validating
        Call CMBDCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTFADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFADULT.Validating
        Call CMBFCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTFCHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFCHILD.Validating
        Call CMBFCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTFINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFINFANT.Validating
        Call CMBFCURRENCY_Validated(sender, e)
    End Sub

    Private Sub TXTDECPKGADULT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDECPKGADULT.Validating
        total()
    End Sub

    Private Sub TXTDECPKGCHILD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDECPKGCHILD.Validating
        total()
    End Sub

    Private Sub TXTDECPKGINFANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDECPKGINFANT.Validating
        total()
    End Sub

    Private Sub TXTDAYS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTDAYS.Validated
        Call STARTDATE_Validated(sender, e)
    End Sub

    Sub TOURNAME()
        Try
            TXTTOURNAME.Clear()
            Dim COUNTRY As String = ""
            If TXTDAYS.Text.Trim <> "" And GRIDCOUNTRY.RowCount > 0 Then
                For Each row As Windows.Forms.DataGridViewRow In GRIDCOUNTRY.Rows
                    If COUNTRY = "" Then
                        COUNTRY = row.Cells(GCONCITY.Index).Value.ToString
                    Else
                        COUNTRY = COUNTRY & "-" & row.Cells(GCONCITY.Index).Value.ToString
                    End If
                Next
                TXTTOURNAME.Text = "MT" & "/" & Val(TXTTOURNO.Text.Trim) & "/" & COUNTRY & "-" & Format(STARTDATE.Value.Date, "dd-MMM") & "-" & Val(TXTDAYS.Text.Trim) & "DYS" & "     " & TXTFAIZE.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDAYS.Validating
        TOURNAME()
    End Sub

    Private Sub STARTDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles STARTDATE.Validating
        TOURNAME()
    End Sub

    Private Sub RDBPURCHASE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBPURCHASE.CheckedChanged
        Try
            TXTPURSRNO.Enabled = RDBPURCHASE.Checked
            CMBSUPPLIER.Enabled = RDBPURCHASE.Checked
            TXTPURADULT.Enabled = RDBPURCHASE.Checked
            TXTPURCHILD.Enabled = RDBPURCHASE.Checked
            TXTPURINFANT.Enabled = RDBPURCHASE.Checked

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ENDDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ENDDATE.Validating
        Try
            If ENDDATE.Value.Date < STARTDATE.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            TXTDAYS.Clear()
            TXTDAYS.Text = ENDDATE.Value.Date.Subtract(STARTDATE.Value.Date).Days + 1
            'If Val(TXTDAYS.Text.Trim) = 0 Then TXTDAYS.Text = 1
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
            Dim objTour As New TourDetails
            objTour.MdiParent = MDIMain
            objTour.Show()
            objTour.BringToFront()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKAPPLY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYINFANT.TextChanged
        Try
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTOURDETAILS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTTOURDETAILS.Validating
        Try
            If TXTTOURDETAILS.Text.Trim <> "" Then
                fillgridTOUR()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "TRAVELMATE")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridTOUR()

        GRIDTOUR.Enabled = True

        If gridTOURDoubleClick = False Then
            GRIDTOUR.Rows.Add(Val(TXTTOURSRNO.Text.Trim), Format(ITENARYDATE.Value.Date, "dd/MM/yyyy"), TXTTOURDETAILS.Text.Trim)
            getsrno(GRIDTOUR)
        ElseIf gridTOURDoubleClick = True Then
            GRIDTOUR.Item(GTOURSRNO.Index, tempTOURrow).Value = Val(TXTTOURSRNO.Text.Trim)
            GRIDTOUR.Item(GTOURDATE.Index, tempTOURrow).Value = Format(ITENARYDATE.Value.Date, "dd/MM/yyyy")
            GRIDTOUR.Item(GTOURDETAILS.Index, tempTOURrow).Value = TXTTOURDETAILS.Text.Trim
            gridTOURDoubleClick = False
        End If

        GRIDTOUR.FirstDisplayedScrollingRowIndex = GRIDTOUR.RowCount - 1

        TXTTOURSRNO.Clear()
        TXTTOURDETAILS.Clear()
        ITENARYDATE.Value = DateAdd(DateInterval.Day, 1, ITENARYDATE.Value)
        TXTTOURSRNO.Focus()

    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                If grid.Name = "GRIDPURCHASE" Then
                    row.Cells(1).Value = row.Index + 1
                Else
                    row.Cells(0).Value = row.Index + 1
                End If
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTOUR.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridTOURDoubleClick = True
                TXTTOURSRNO.Text = GRIDTOUR.Item(GTOURSRNO.Index, e.RowIndex).Value.ToString
                ITENARYDATE.Value = Convert.ToDateTime(GRIDTOUR.Item(GTOURDATE.Index, e.RowIndex).Value).Date
                TXTTOURDETAILS.Text = GRIDTOUR.Item(GTOURDETAILS.Index, e.RowIndex).Value.ToString

                tempTOURrow = e.RowIndex
                TXTTOURSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTOUR_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTOUR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTOUR.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridTOURDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDTOUR.Rows.RemoveAt(GRIDTOUR.CurrentRow.Index)
                total()
                getsrno(GRIDTOUR)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKAPPLY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYINFANT.CheckedChanged
        total()
    End Sub

    Private Sub TXTCUTOFDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUTOFDAYS.KeyPress
        Try
            numkeypress(e, TXTCUTOFDAYS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUTOFDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUTOFDAYS.Validating
        If TXTCUTOFDAYS.Text.Trim <> "" Then
            CUTOFDATE.Value = DateAdd(DateInterval.Day, (Val(TXTCUTOFDAYS.Text) * (-1)), STARTDATE.Value.Date)
        End If
    End Sub

    Private Sub CUTOFDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CUTOFDATE.Validating
        Try
            If CUTOFDATE.Value > STARTDATE.Value Then
                MsgBox("Enter proper Dates")
                e.Cancel = True
            End If
            TXTCUTOFDAYS.Text = Val(STARTDATE.Value.Date.Subtract(CUTOFDATE.Value.Date).Days)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKAPPLYCHILD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYCHILD.CheckedChanged
        total()
    End Sub

    Private Sub CHKAPPLYADULT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYADULT.CheckedChanged
        total()

    End Sub

    Private Sub CHKAPPLYCHILD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYCHILD.TextChanged
        total()
    End Sub

    Private Sub CHKAPPLYADULT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKAPPLYADULT.TextChanged
        total()

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

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridUPLOADdoubleclick = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                tempUPLOADrow = e.RowIndex
                txtuploadremarks.Focus()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GUSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            'dont allow user if any of the grid line is in edit mode.....
            If gridUPLOADdoubleclick = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If
            'end of block

            gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
            getsrno(gridupload)
        End If
    End Sub

    Sub FILLUPLOAD()

        If gridUPLOADdoubleclick = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf gridUPLOADdoubleclick = True Then

            gridupload.Item(GUSRNO.Index, tempUPLOADrow).Value = TXTUPLOADSRNO.Text.Trim
            gridupload.Item(GUREMARKS.Index, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, tempUPLOADrow).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, tempUPLOADrow).Value = PBSOFTCOPY.Image

            gridUPLOADdoubleclick = False

        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()

    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim

    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
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

    Sub SAVEUPLOAD()
        Try
            Dim OBJPO As New ClsTourMaster

            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If row.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPTOURNO)
                    ALPARAVAL.Add(row.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(row.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = row.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Userid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(0)

                    OBJPO.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJPO.SAVEUPLOAD()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            If edit = True And gridupload.RowCount > 0 Then
                If MsgBox("Print Documents?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJPRINT As New PrintBlankForm
                OBJPRINT.FRMSTRING = "TOURDOCUMENT"
                OBJPRINT.STRSEARCH = "{TOURMASTER_UPLOAD.TOUR_NO} = " & TEMPTOURNO & " AND {TOURMASTER_UPLOAD.TOUR_YEARID} = " & YearId
                OBJPRINT.MdiParent = MDIMain
                OBJPRINT.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class