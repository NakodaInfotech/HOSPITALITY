Imports BL
Imports System.Windows.Forms

Public Class DriverDetails
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean 'USED FOR RIGHT MANAGEMAENT

    Private Sub DriverDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub DriverDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CAR RENTAL'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgridname(Optional ByVal whereclause As String = "")

        Dim dttable As New DataTable
        Dim OBJDRIVER As New ClsDriverMaster
        Dim ALPARAVAL As New ArrayList

        ALPARAVAL.Add("")
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        OBJDRIVER.alParaval = ALPARAVAL

        dttable = OBJDRIVER.SELECTDRIVERDETAILS()

        gridname.DataSource = dttable

    End Sub

    Sub getdetails(ByRef name As String)
        If name = Nothing Then Exit Sub
        Dim dttable As New DataTable
        Dim OBJDRIVER As New ClsDriverMaster
        OBJDRIVER.alParaval.Add(name)
        OBJDRIVER.alParaval.Add(CmpId)
        OBJDRIVER.alParaval.Add(Locationid)
        OBJDRIVER.alParaval.Add(YearId)
        dttable = OBJDRIVER.SELECTDRIVERDETAILS

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows
                TXTNAME.Text = ROW("NAME")

                txtadd.Text = ROW("ADD")
                TXTREMARKS.Text = ROW("REMARKS")
                txtadd1.Text = ROW("ADD1")
                txtadd2.Text = ROW("ADD2")


                txtarea.Text = ROW("AREANAME")
                txtstd.Text = ROW("STD")
                txtcity.Text = ROW("CITYNAME")
                txtzipcode.Text = ROW("ZIPCODE")
                txtstate.Text = ROW("STATENAME")
                txtcountry.Text = ROW("COUNTRYNAME")
                TXTMEMBERSHIP.Text = ROW("MEMBERSHIPNO")

                If Convert.ToBoolean(ROW("ISDOB")) = True Then
                    chkdob.CheckState = CheckState.Checked
                    DOB.Value = ROW("DOB")
                End If

                txtresino.Text = ROW("RESINO")
                txtaltno.Text = ROW("ALTNO")
                txttel1.Text = ROW("PHONE")
                txtmobile.Text = ROW("MOBILE")
                txtfax.Text = ROW("FAX")
                txtwebsite.Text = ROW("WEBSITE")
                txtemail.Text = ROW("EMAIL")
                TXTREF.Text = ROW("REF")


            Next
        End If
    End Sub

    Sub cleartextbox()

        TXTNAME.Clear()
        txtarea.Clear()
        txtstd.Clear()
        txtcity.Clear()
        txtzipcode.Clear()
        txtstate.Clear()
        txtcountry.Clear()
        TXTMEMBERSHIP.Clear()

        chkdob.CheckState = CheckState.Unchecked
        DOB.Value = Mydate

        txtresino.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()
        TXTREF.Clear()

        txtadd1.Clear()
        txtadd2.Clear()
        txtadd.Clear()
        TXTREMARKS.Clear()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim OBJDRIVER As New DriverMaster
                OBJDRIVER.MdiParent = MDIMain
                OBJDRIVER.edit = editval
                OBJDRIVER.TEMPDRIVERNAME = name
                OBJDRIVER.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtstd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstd.KeyPress
        numdotkeypress(e, txtstd, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numdotkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub gettrans(ByRef name As String)

        'If USEREDIT = False And USERVIEW = False Then
        '    MsgBox("Insufficient Rights")
        '    Exit Sub
        'End If

        'Dim dttable As New DataTable
        'Dim objClsAcc As New ClsAccountsMaster
        'Dim ALPARAVAL As New ArrayList

        'ALPARAVAL.Add(name)
        'ALPARAVAL.Add(cmbfilter.Text.Trim)
        'If chkdate.CheckState = CheckState.Unchecked Then
        '    ALPARAVAL.Add(AccFrom)
        '    ALPARAVAL.Add(AccTo)
        'Else
        '    ALPARAVAL.Add(dtfromdate.Value)
        '    ALPARAVAL.Add(dttodate.Value)
        'End If

        'ALPARAVAL.Add(CmpId)
        'ALPARAVAL.Add(Locationid)
        'ALPARAVAL.Add(YearId)

        'objClsAcc.alParaval = ALPARAVAL
        'dttable = objClsAcc.gettrans()

        'griddetails.DataSource = dttable

    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class