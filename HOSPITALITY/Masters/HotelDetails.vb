
Imports BL
Imports System.Windows.Forms

Public Class HotelDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub HotelDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub HotelDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOTEL MASTER'")
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
        Dim OBJHOTEL As New ClsHotelMaster
        OBJHOTEL.alParaval.Add("")
        OBJHOTEL.alParaval.Add(CmpId)
        OBJHOTEL.alParaval.Add(Locationid)
        OBJHOTEL.alParaval.Add(YearId)
        dttable = OBJHOTEL.getHOTEL()
        If dttable.Rows.Count > 0 Then
            gridname.DataSource = dttable
            gridledger.Columns(0).Width = 180
            gridledger.Columns(1).Width = 80
            gridledger.Columns(2).Width = 150
        End If
    End Sub

    Sub getdetails(ByRef name As String)

        If name = Nothing Then Exit Sub
        Dim dttable As New DataTable
        Dim OBJHOTEL As New ClsHotelMaster
        OBJHOTEL.alParaval.Add(name)
        OBJHOTEL.alParaval.Add(CmpId)
        OBJHOTEL.alParaval.Add(Locationid)
        OBJHOTEL.alParaval.Add(YearId)
        dttable = OBJHOTEL.getHOTEL

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows
                TXTHOTELNAME.Text = ROW("HOTELNAME")
                TXTHOTELTYPE.Text = ROW("HOTELTYPE")
                TXTPERSON.Text = ROW("PERSON")
                txtcode.Text = ROW("CODE")
                SETIMAGE(ROW("GRADE"))
                TXTGROUPOFCMP.Text = ROW("GROUPOFHOTELS")
                txtcheckin.Text = ROW("CHECKIN")
                txtcheckout.Text = ROW("CHECKOUT")
                txtadd.Text = ROW("ADD")
                txtadd1.Text = ROW("ADD1")
                txtadd2.Text = ROW("ADD2")
                txtarea.Text = ROW("AREA")
                txtstd.Text = ROW("STD")
                txtcity.Text = ROW("CITY")
                txtzipcode.Text = ROW("ZIPCODE")
                txtstate.Text = ROW("STATE")
                txtcountry.Text = ROW("COUNTRY")
                txtaltno.Text = ROW("ALTNO")
                txttel1.Text = ROW("PHONENO")
                txtmobile.Text = ROW("MOBILENO")
                txtfax.Text = ROW("FAXNO")
                txtwebsite.Text = ROW("WEBSITE")
                txtemail.Text = ROW("EMAILID")
                If ROW("GRIDSRNO") <> 0 Then gridroomdesc.Rows.Add(ROW("GRIDSRNO"), ROW("ROOMTYPE"), ROW("NOOFROOMS"), ROW("RATE"), ROW("IMGPATH"), ROW("NEWIMGPATH"))
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("AMENITIESMASTER.AMENITIES_ID AS AMENITIESID, AMENITIESMASTER.AMENITIES_NAME AS AMENITIES", "", "HOTELMASTER_AMENITIES INNER JOIN AMENITIESMASTER ON HOTELMASTER_AMENITIES.HOTEL_AMENITIESID = AMENITIESMASTER.AMENITIES_ID AND HOTELMASTER_AMENITIES.HOTEL_CMPID = AMENITIESMASTER.AMENITIES_CMPID AND HOTELMASTER_AMENITIES.HOTEL_LOCATIONID = AMENITIESMASTER.AMENITIES_LOCATIONID AND HOTELMASTER_AMENITIES.HOTEL_YEARID = AMENITIESMASTER.AMENITIES_YEARID INNER JOIN HOTELMASTER ON HOTELMASTER_AMENITIES.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID AND HOTELMASTER_AMENITIES.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_AMENITIES.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_AMENITIES.HOTEL_ID = HOTELMASTER.HOTEL_ID", " AND HOTELMASTER.HOTEL_NAME = '" & name & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDAMNETIES.Rows.Add(DTROW("AMENITIESID"), DTROW("AMENITIES"))
                Next
            End If

            DT = OBJCMN.search("  HOTELMASTER_CONTACTDESC.HOTEL_CONTACT AS NAME, DESIGNATIONMASTER.DESIGNATION_NAME AS DESIGNATION, HOTELMASTER_CONTACTDESC.HOTEL_MOBILENO AS MOBILENO, HOTELMASTER_CONTACTDESC.HOTEL_EMAIL AS EMAIL ", "", " DESIGNATIONMASTER INNER JOIN HOTELMASTER_CONTACTDESC ON DESIGNATIONMASTER.DESIGNATION_ID = HOTELMASTER_CONTACTDESC.HOTEL_DESIGNATIONID AND DESIGNATIONMASTER.DESIGNATION_CMPID = HOTELMASTER_CONTACTDESC.HOTEL_CMPID AND DESIGNATIONMASTER.DESIGNATION_LOCATIONID = HOTELMASTER_CONTACTDESC.HOTEL_LOCATIONID AND DESIGNATIONMASTER.DESIGNATION_YEARID = HOTELMASTER_CONTACTDESC.HOTEL_YEARID INNER JOIN HOTELMASTER ON HOTELMASTER_CONTACTDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_CONTACTDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_CONTACTDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_CONTACTDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID ", " AND HOTELMASTER.HOTEL_NAME = '" & name & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    GRIDCONTACT.Rows.Add(DTR("NAME"), DTR("DESIGNATION"), DTR("MOBILENO"), DTR("EMAIL"))
                Next
            End If
        End If
    End Sub

    Private Sub gridroomdesc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridroomdesc.CellClick
        On Error Resume Next
        If gridroomdesc.RowCount > 0 Then
            PBIMG.ImageLocation = ""
            If gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value)
            ElseIf gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value)
            End If
        End If
    End Sub

    Private Sub gridroomdesc_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridroomdesc.RowEnter
        On Error Resume Next
        If gridroomdesc.RowCount > 0 Then
            PBIMG.ImageLocation = ""
            If gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(gimgpath.Index).Value)
            ElseIf gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value <> Nothing Then
                PBIMG.ImageLocation = gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value
                PBIMG.Load(gridroomdesc.Rows(e.RowIndex).Cells(GOURIMGPATH.Index).Value)
            End If
        End If
    End Sub

    Sub SETIMAGE(ByVal I As Integer)
        Try
            pb1.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb2.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb3.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb4.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb5.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb6.Image = Global.HOSPITALITY.My.Resources.star_grey
            pb7.Image = Global.HOSPITALITY.My.Resources.star_grey

            TXTGRADE.Text = I

            Select Case I
                Case 1
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 2
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 3
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 4
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 5
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 6
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb6.Image = Global.HOSPITALITY.My.Resources.star_yellow
                Case 7
                    pb1.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb2.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb3.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb4.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb5.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb6.Image = Global.HOSPITALITY.My.Resources.star_yellow
                    pb7.Image = Global.HOSPITALITY.My.Resources.star_yellow

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub cleartextbox()
        TXTHOTELNAME.Clear()
        TXTHOTELTYPE.Clear()
        TXTPERSON.Clear()
        SETIMAGE(0)
        TXTGROUPOFCMP.Clear()
        txtarea.Clear()
        txtstd.Clear()
        txtcity.Clear()
        txtzipcode.Clear()
        txtstate.Clear()
        txtcountry.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()

        gridroomdesc.RowCount = 0

        txtadd1.Clear()
        txtadd2.Clear()
        txtadd.Clear()
        GRIDAMNETIES.RowCount = 0
        GRIDCONTACT.RowCount = 0
       
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
                Dim OBJHOTEL As New HotelMaster
                OBJHOTEL.MdiParent = MDIMain
                OBJHOTEL.edit = editval
                OBJHOTEL.TEMPHOTELNAME = name
                OBJHOTEL.Show()
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

    Private Sub PBEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New HotelDetailsReport
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class