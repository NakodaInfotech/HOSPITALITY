
Imports BL
Imports System.Windows.Forms

Public Class FlightDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub FlightDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then       'for AddNew 
            Call cmdadd_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub FlightDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'FLIGHT MASTER'")
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
            Throw ex
        End Try

    End Sub

    Sub fillgridname()
        Dim dttable As New DataTable
        Dim OBJFLIGHT As New ClsFlightMaster
        OBJFLIGHT.alParaval.Add("")
        OBJFLIGHT.alParaval.Add(CmpId)
        OBJFLIGHT.alParaval.Add(Locationid)
        OBJFLIGHT.alParaval.Add(YearId)
        dttable = OBJFLIGHT.getFLIGHT
        If dttable.Rows.Count > 0 Then
            GRIDFLIGHT.DataSource = dttable
            gridflightdetails.Columns(0).Width = 70
            gridflightdetails.Columns(1).Width = 255
        End If
    End Sub

    Sub getdetails(ByRef name As String)
        If name = "" Then Exit Sub
        Dim dttable As New DataTable
        Dim OBJFLIGHT As New ClsFlightMaster
        OBJFLIGHT.alParaval.Add(name)
        OBJFLIGHT.alParaval.Add(CmpId)
        OBJFLIGHT.alParaval.Add(Locationid)
        OBJFLIGHT.alParaval.Add(YearId)
        dttable = OBJFLIGHT.getFLIGHT

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows
                TXTFLIGHTNAME.Text = ROW("NAME")
                txtcode.Text = ROW("CODE")
                TXTPERSON.Text = ROW("CONTACT")

                txtadd.Text = ROW("ADD")
                txtadd1.Text = ROW("ADD1")
                txtadd2.Text = ROW("ADD2")

                txtarea.Text = ROW("AREA")
                txtstd.Text = ROW("STD")
                txtcity.Text = ROW("CITY")
                txtzipcode.Text = ROW("ZIPCODE")
                txtstate.Text = ROW("STATE")
                txtcountry.Text = ROW("COUNTRY")
                TXTCRDAYS.Text = ROW("CRDAYS")
                TXTCRLIMIT.Text = ROW("CRLIMIT")

                TXTRESI.Text = ROW("RESINO")
                txtaltno.Text = ROW("ALTNO")
                TXTPHONE.Text = ROW("PHONE")
                txtmobile.Text = ROW("MOBILE")
                txtfax.Text = ROW("FAX")
                txtwebsite.Text = ROW("WEBSITE")
                txtemail.Text = ROW("EMAIL")

                TXTPREF.Text = ROW("PREF")
                TXTAIRLINECODE.Text = ROW("AIRLINECODE")

                If Convert.ToBoolean(ROW("BSPSTOCK")) = True Then
                    TXTBSP.Text = "YES"
                Else
                    TXTBSP.Text = "NO"
                End If

                TXTPSR.Text = ROW("PSRCODE")

                If Convert.ToBoolean(ROW("DOMESTIC")) = True Then
                    TXTDOMESTIC.Text = "YES"
                Else
                    TXTDOMESTIC.Text = "NO"
                End If

                If Convert.ToBoolean(ROW("LCC")) = True Then
                    TXTLCC.Text = "YES"
                Else
                    TXTLCC.Text = "NO"
                End If

                TXTBASIC.Text = ROW("BASIC")
                TXTCOMM.Text = ROW("COMM")
                TXTCOMMPSF.Text = ROW("COMMPSF")
                TXTCOMMTAX.Text = ROW("COMMTAX")
                TXTREMARKS.Text = ROW("REMARKS")


                If ROW("GRIDSRNO") <> 0 Then GRIDROUTE.Rows.Add(ROW("GRIDSRNO"), ROW("ROUTENAME"), ROW("FROMCITY"), ROW("TOCITY"), ROW("DEPARTURE"), ROW("ARRIVAL"))
            Next

        End If
    End Sub

    Sub cleartextbox()

        TXTFLIGHTNAME.Clear()
        txtcode.Clear()
        TXTPERSON.Clear()
        txtarea.Clear()
        txtstd.Clear()
        txtcity.Clear()
        txtzipcode.Clear()
        txtstate.Clear()
        txtcountry.Clear()
        TXTRESI.Clear()
        txtaltno.Clear()
        TXTPHONE.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()

        TXTPREF.Clear()
        TXTAIRLINECODE.Clear()
        TXTBSP.Clear()
        TXTPSR.Clear()
        TXTDOMESTIC.Clear()
        TXTLCC.Clear()
        TXTBASIC.Clear()
        TXTCOMM.Clear()
        TXTCOMMPSF.Clear()
        TXTCOMMTAX.Clear()
        GRIDROUTE.RowCount = 0

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
            showform(True, gridflightdetails.GetFocusedRowCellValue("NAME"))
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
            If (editval = False) Or (editval = True And gridflightdetails.RowCount > 0) Then
                Dim OBJFLIGHT As New FlightMaster
                OBJFLIGHT.MdiParent = MDIMain
                OBJFLIGHT.edit = editval
                OBJFLIGHT.TEMPFLIGHTNAME = name
                OBJFLIGHT.Show()
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

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridflightdetails.Click
        Try
            getdetails(gridflightdetails.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridflightdetails.DoubleClick
        Try
            showform(True, gridflightdetails.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridflightdetails.FocusedRowChanged
        Try
            getdetails(gridflightdetails.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub FlightDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "ELYSIUM" Or ClientName = "PLANET" Or ClientName = "TOPCOMM" Then Me.Close()
    End Sub
End Class