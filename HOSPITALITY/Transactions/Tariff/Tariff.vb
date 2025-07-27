
Imports System.IO
Imports System.Net
Imports BL

Public Class Tariff

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public edit As Boolean
    Public TARIFFID As Integer
    Public TEMPTARIFFNAME As String
    Public TEMPHOTELNAME As String
    Dim TEMPMSG As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhotelcode.Enter
        Try
            If cmbhotelcode.Text.Trim = "" Then fillHOTELCODE(cmbhotelcode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbhotelcode.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then cmbhotelcode.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then cmbhotelname.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbhotelcode.Validating
        Try
            If cmbhotelcode.Text.Trim <> "" Then HOTELCODEVALIDATE(cmbhotelcode, cmbhotelname, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhotelname.Enter
        Try
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbhotelname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJHOTEL As New SelectHotel
                OBJHOTEL.ShowDialog()
                If OBJHOTEL.TEMPHOTELCODE <> "" Then cmbhotelcode.Text = OBJHOTEL.TEMPHOTELCODE
                If OBJHOTEL.TEMPHOTELNAME <> "" Then cmbhotelname.Text = OBJHOTEL.TEMPHOTELNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhotelname.Validated
        Try
            If cmbhotelname.Text.Trim <> "" Then
                FILLROOMTYPE()
                FILLTARIFF()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbhotelname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbhotelname.Validating
        Try
            If cmbhotelname.Text.Trim <> "" Then HOTELvalidate(cmbhotelname, cmbhotelcode, e, Me, TXTHOTELADD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLTARIFF()
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            Dim WHERECLAUSE As String = ""
            If cmbhotelname.Text.Trim <> "" Then WHERECLAUSE = " AND HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' "
            dt = objclscommon.search(" TARIFF_NAME ", "", " TARIFFMASTER INNER JOIN HOTELMASTER ON HOTEL_ID = TARIFF_HOTELID AND HOTEL_CMPID = TARIFF_CMPID AND HOTEL_LOCATIONID = TARIFF_LOCATIONID AND HOTEL_YEARID = TARIFF_YEARID ", " and TARIFF_cmpid=" & CmpId & " AND TARIFF_LOCATIONID = " & Locationid & " AND TARIFF_YEARID = " & YearId & WHERECLAUSE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "TARIFF_NAME"
                CMBTARIFF.DataSource = dt
                CMBTARIFF.DisplayMember = "TARIFF_NAME"
                CMBTARIFF.Text = ""
            End If
            CMBTARIFF.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FillCmb()
        Try
            If cmbhotelcode.Text.Trim = "" Then fillHOTELCODE(cmbhotelcode, "")
            If cmbhotelname.Text.Trim = "" Then fillHOTEL(cmbhotelname, "")
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, False)
            If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, False)
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, False)
            If CMBTARIFF.Text.Trim = "" Then FILLTARIFF()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLROOMTYPE()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT ROOMTYPEMASTER.ROOMTYPE_NAME AS ROOMTYPE", "", " HOTELMASTER_ROOMDESC INNER JOIN HOTELMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ID = HOTELMASTER.HOTEL_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = HOTELMASTER.HOTEL_YEARID INNER JOIN ROOMTYPEMASTER ON HOTELMASTER_ROOMDESC.HOTEL_ROOMTYPEID = ROOMTYPEMASTER.ROOMTYPE_ID AND HOTELMASTER_ROOMDESC.HOTEL_CMPID = ROOMTYPEMASTER.ROOMTYPE_CMPID AND HOTELMASTER_ROOMDESC.HOTEL_LOCATIONID = ROOMTYPEMASTER.ROOMTYPE_LOCATIONID AND HOTELMASTER_ROOMDESC.HOTEL_YEARID = ROOMTYPEMASTER.ROOMTYPE_YEARID", " AND HOTELMASTER.HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND HOTELMASTER.HOTEL_CMPID = " & CmpId & " AND HOTELMASTER.HOTEL_LOCATIONID = " & Locationid & " AND HOTELMASTER.HOTEL_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "ROOMTYPE"
                CMBROOMTYPE.DataSource = DT
                CMBROOMTYPE.DisplayMember = "ROOMTYPE"
                If edit = False Then CMBROOMTYPE.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Tariff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'HOTEL MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FillCmb()
            clear()

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim objhotel As New ClsTariffMaster

                objhotel.alParaval.Add(TEMPTARIFFNAME)
                objhotel.alParaval.Add(TEMPHOTELNAME)
                objhotel.alParaval.Add(CmpId)
                objhotel.alParaval.Add(Locationid)
                objhotel.alParaval.Add(YearId)

                dttable = objhotel.GETTARIFF()

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        cmbhotelname.Text = ROW("HOTELNAME")
                        cmbhotelcode.Text = ROW("HOTELCODE")
                        TXTHOTELADD.Text = ROW("HOTELADD")
                        CMBTARIFF.Text = ROW("TARIFFNAME")
                        TARIFFID = ROW("TARIFFID")
                        FROMDATE.Value = Convert.ToDateTime(ROW("FROMDATE")).Date
                        TODATE.Value = Convert.ToDateTime(ROW("TODATE")).Date
                        txtremarks.Text = ROW("REMARKS")

                        GRIDTRANS.Rows.Add(ROW("SRNO"), ROW("ROOMTYPE"), ROW("MEALPLAN"), ROW("WEEKDAYS"), ROW("WEEKEND"), ROW("ADULT"), ROW("CHILD"), ROW("BED"), ROW("DISC"), ROW("COMM"), ROW("TDS"), ROW("TAXNAME"), ROW("ADDTAXNAME"))

                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPLAN.Enter
        Try
            If CMBPLAN.Text.Trim = "" Then FILLPLAN(CMBPLAN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLAN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLAN.Validating
        Try
            If CMBPLAN.Text.Trim <> "" Then PLANvalidate(CMBPLAN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWEAKDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWEEKDAYS.KeyPress
        Try
            numdotkeypress(e, TXTWEEKDAYS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWEAKENDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWEEKENDS.KeyPress
        Try
            numdotkeypress(e, TXTWEEKENDS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADULTS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADULTS.KeyPress
        Try
            numdotkeypress(e, TXTADULTS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHILDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHILD.KeyPress
        Try
            numdotkeypress(e, TXTCHILD, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBEDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBEDS.KeyPress
        Try
            numdotkeypress(e, TXTBEDS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDISC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDISC.KeyPress
        Try
            numdotkeypress(e, TXTDISC, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOMM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOMM.KeyPress
        Try
            numdotkeypress(e, TXTCOMM, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTDS.KeyPress
        Try
            numdotkeypress(e, TXTTDS, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        Try
            cmbhotelcode.Text = ""
            cmbhotelname.Text = ""
            TXTHOTELADD.Clear()
            TODATE.Value = Mydate
            FROMDATE.Value = Mydate
            txtremarks.Clear()
            CMBTARIFF.Text = ""

            TXTSRNO.Clear()
            CMBROOMTYPE.Text = ""
            CMBPLAN.Text = ""
            TXTWEEKDAYS.Clear()
            TXTWEEKENDS.Clear()
            TXTADULTS.Clear()
            TXTCHILD.Clear()
            TXTBEDS.Clear()
            TXTDISC.Clear()
            TXTCOMM.Clear()
            TXTTDS.Clear()
            CMBTAX.Text = ""
            CMBADDTAX.Text = ""
            txtimgpath.Clear()
            txtimgpath.Clear()
            GRIDTRANS.RowCount = 0
            gridDoubleClick = False
            cmbhotelname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False
            TEMPTARIFFNAME = ""
            TARIFFID = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Tariff_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click


        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()

        If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\ROOM IMAGES") = False Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\ROOM IMAGES")

        'TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        'TXTOURLOCATION.Text = Application.StartupPath & "\ROOM IMAGES\" & CMBHOTELNAME.Text.Trim & cmbroomtype.Text.Trim & TXTFILENAME.Text.Trim
        'txtimgpath.Text = OpenFileDialog1.FileName

        'On Error Resume Next

        'If txtimgpath.Text.Trim.Length <> 0 Then
        '    PBIMG.ImageLocation = txtimgpath.Text.Trim
        '    txtsrno.Focus()
        'End If

        'If gridroomdesc.RowCount > 0 Then
        '    UPLOADIMG(gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GROOMTYPE.Index).Value, gridroomdesc.Rows(gridroomdesc.CurrentRow.Index).Cells(GSRNO.Index).Value)
        'End If
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click

        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            EP.Clear()
            If Not CHECKDATE(FROMDATE.Value.Date) Then
                Exit Sub
            End If

            EP.Clear()
            If Not CHECKDATE(TODATE.Value.Date) Then
                Exit Sub
            End If



            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(cmbhotelname.Text.Trim)
            alParaval.Add(CMBTARIFF.Text.Trim)
            alParaval.Add(FROMDATE.Value.Date)
            alParaval.Add(TODATE.Value.Date)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            'GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim ROOMTYPE As String = ""
            Dim PLAN As String = ""
            Dim WEEKDAYS As String = ""
            Dim WEEKENDS As String = ""
            Dim ADULTS As String = ""
            Dim CHILD As String = ""
            Dim BEDS As String = ""
            Dim DISC As String = ""
            Dim COMM As String = ""
            Dim TDS As String = ""
            Dim TAX As String = ""
            Dim ADDTAX As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANS.Rows
                If row.Cells(GSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        ROOMTYPE = row.Cells(GROOMTYPE.Index).Value.ToString
                        PLAN = row.Cells(GPLAN.Index).Value.ToString
                        WEEKDAYS = Val(row.Cells(GWEEKDAYS.Index).Value)
                        WEEKENDS = Val(row.Cells(GWEEKENDS.Index).Value)
                        ADULTS = Val(row.Cells(GADULTS.Index).Value)
                        CHILD = Val(row.Cells(GCHILD.Index).Value)
                        BEDS = Val(row.Cells(GBEDS.Index).Value)
                        DISC = Val(row.Cells(GDISC.Index).Value)
                        COMM = Val(row.Cells(GCOMM.Index).Value)
                        TDS = Val(row.Cells(GTDS.Index).Value)
                        TAX = row.Cells(GTAX.Index).Value
                        ADDTAX = row.Cells(GADDTAX.Index).Value
                    Else

                        GRIDSRNO = GRIDSRNO & "," & row.Cells(GSRNO.Index).Value.ToString
                        ROOMTYPE = ROOMTYPE & "," & row.Cells(GROOMTYPE.Index).Value
                        PLAN = PLAN & "," & row.Cells(GPLAN.Index).Value.ToString
                        WEEKDAYS = WEEKDAYS & "," & Val(row.Cells(GWEEKDAYS.Index).Value)
                        WEEKENDS = WEEKENDS & "," & Val(row.Cells(GWEEKENDS.Index).Value)
                        ADULTS = ADULTS & "," & Val(row.Cells(GADULTS.Index).Value)
                        CHILD = CHILD & "," & Val(row.Cells(GCHILD.Index).Value)
                        BEDS = BEDS & "," & Val(row.Cells(GBEDS.Index).Value)
                        DISC = DISC & "," & Val(row.Cells(GDISC.Index).Value)
                        COMM = COMM & "," & Val(row.Cells(GCOMM.Index).Value)
                        TDS = TDS & "," & Val(row.Cells(GTDS.Index).Value)
                        TAX = TAX & "," & row.Cells(GTAX.Index).Value
                        ADDTAX = ADDTAX & "," & row.Cells(GADDTAX.Index).Value
                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ROOMTYPE)
            alParaval.Add(PLAN)
            alParaval.Add(WEEKDAYS)
            alParaval.Add(WEEKENDS)
            alParaval.Add(ADULTS)
            alParaval.Add(CHILD)
            alParaval.Add(BEDS)
            alParaval.Add(DISC)
            alParaval.Add(COMM)
            alParaval.Add(TDS)
            alParaval.Add(TAX)
            alParaval.Add(ADDTAX)


            'Saving Upload Grid
            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

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

            Dim OBJTARIFF As New ClsTariffMaster
            OBJTARIFF.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = OBJTARIFF.SAVE()
                MsgBox("Details Added")

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TARIFFID)
                IntResult = OBJTARIFF.UPDATE()
                MsgBox("Details Updated")

            End If
            clear()
            edit = False
            cmbhotelname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDTRANS.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDTRANS.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridDoubleClick = True
                TXTSRNO.Text = GRIDTRANS.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBROOMTYPE.Text = GRIDTRANS.Item(GROOMTYPE.Index, e.RowIndex).Value.ToString
                CMBPLAN.Text = GRIDTRANS.Item(GPLAN.Index, e.RowIndex).Value.ToString
                TXTWEEKDAYS.Text = GRIDTRANS.Item(GWEEKDAYS.Index, e.RowIndex).Value.ToString
                TXTWEEKENDS.Text = GRIDTRANS.Item(GWEEKENDS.Index, e.RowIndex).Value.ToString
                TXTADULTS.Text = GRIDTRANS.Item(GADULTS.Index, e.RowIndex).Value.ToString
                TXTCHILD.Text = GRIDTRANS.Item(GCHILD.Index, e.RowIndex).Value.ToString
                TXTBEDS.Text = GRIDTRANS.Item(GBEDS.Index, e.RowIndex).Value.ToString
                TXTDISC.Text = GRIDTRANS.Item(GDISC.Index, e.RowIndex).Value.ToString
                TXTCOMM.Text = GRIDTRANS.Item(GCOMM.Index, e.RowIndex).Value.ToString
                TXTTDS.Text = GRIDTRANS.Item(GTDS.Index, e.RowIndex).Value.ToString
                CMBTAX.Text = GRIDTRANS.Item(GTAX.Index, e.RowIndex).Value.ToString
                CMBADDTAX.Text = GRIDTRANS.Item(GADDTAX.Index, e.RowIndex).Value.ToString
                temprow = e.RowIndex
                EP.Clear()
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbhotelname.Text.Trim.Length = 0 Then
            EP.SetError(cmbhotelname, "Fill Hotel Name")
            bln = False
        End If

        If CMBTARIFF.Text.Trim.Length = 0 Then
            EP.SetError(CMBTARIFF, "Fill Tariff Name")
            bln = False
        End If

        If GRIDTRANS.Rows.Count = 0 Then
            EP.SetError(cmbhotelname, "Fill Tariff Details")
            bln = False
        End If

        Return bln
    End Function

    Sub fillgrid()
        Try
            GRIDTRANS.Enabled = True
            If gridDoubleClick = False Then
                GRIDTRANS.Rows.Add(Val(TXTSRNO.Text.Trim), CMBROOMTYPE.Text.Trim, CMBPLAN.Text.Trim, Val(TXTWEEKDAYS.Text.Trim), Val(TXTWEEKENDS.Text.Trim), Val(TXTADULTS.Text.Trim), Val(TXTCHILD.Text.Trim), Val(TXTBEDS.Text.Trim), Val(TXTDISC.Text.Trim), Val(TXTCOMM.Text.Trim), Val(TXTTDS.Text.Trim), CMBTAX.Text.Trim, CMBADDTAX.Text.Trim)
                getsrno(GRIDTRANS)
            ElseIf gridDoubleClick = True Then
                GRIDTRANS.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDTRANS.Item(GROOMTYPE.Index, temprow).Value = CMBROOMTYPE.Text.Trim
                GRIDTRANS.Item(GPLAN.Index, temprow).Value = CMBPLAN.Text.Trim
                GRIDTRANS.Item(GWEEKDAYS.Index, temprow).Value = Format(Val(TXTWEEKDAYS.Text.Trim), "0.00")
                GRIDTRANS.Item(GWEEKENDS.Index, temprow).Value = Format(Val(TXTWEEKENDS.Text.Trim), "0.00")
                GRIDTRANS.Item(GADULTS.Index, temprow).Value = Format(Val(TXTADULTS.Text.Trim), "0.00")
                GRIDTRANS.Item(GCHILD.Index, temprow).Value = Format(Val(TXTCHILD.Text.Trim), "0.00")
                GRIDTRANS.Item(GBEDS.Index, temprow).Value = Format(Val(TXTBEDS.Text.Trim), "0.00")
                GRIDTRANS.Item(GDISC.Index, temprow).Value = Format(Val(TXTDISC.Text.Trim), "0.00")
                GRIDTRANS.Item(GCOMM.Index, temprow).Value = Format(Val(TXTCOMM.Text.Trim), "0.00")
                GRIDTRANS.Item(GTDS.Index, temprow).Value = Format(Val(TXTTDS.Text.Trim), "0.00")
                GRIDTRANS.Item(GTAX.Index, temprow).Value = CMBTAX.Text.Trim
                GRIDTRANS.Item(GADDTAX.Index, temprow).Value = CMBADDTAX.Text.Trim
                gridDoubleClick = False
            End If

            GRIDTRANS.FirstDisplayedScrollingRowIndex = GRIDTRANS.RowCount - 1

            TXTSRNO.Clear()
            CMBROOMTYPE.Text = ""
            CMBPLAN.Text = ""
            TXTWEEKDAYS.Clear()
            TXTWEEKENDS.Clear()
            TXTADULTS.Clear()
            TXTCHILD.Clear()
            TXTBEDS.Clear()
            TXTDISC.Clear()
            TXTCOMM.Clear()
            TXTTDS.Clear()
            CMBTAX.Text = ""
            CMBADDTAX.Text = ""
            TXTSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.Enter
        Try
            If CMBADDTAX.Text.Trim = "" Then filltax(CMBADDTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKROOMTYPE() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As DataGridViewRow In GRIDTRANS.Rows
                If ROW.Cells(GROOMTYPE.Index).Value = CMBROOMTYPE.Text.Trim And ROW.Cells(GPLAN.Index).Value = CMBPLAN.Text.Trim Then
                    EP.SetError(cmbhotelname, "Tariff of same Room Type and Plan already Present")
                    BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBADDTAX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBADDTAX.Validated
        Try
            If CMBROOMTYPE.Text.Trim <> "" And CMBPLAN.Text.Trim <> "" And Val(TXTWEEKDAYS.Text) > 0 And Val(TXTWEEKENDS.Text) > 0 Then
                EP.Clear()
                If gridDoubleClick = False Then
                    If Not CHECKROOMTYPE() Then
                        Exit Sub
                    End If
                End If
                fillgrid()
            ElseIf CMBROOMTYPE.Text.Trim = "" Then
                MsgBox("Enter Room Type")
                CMBROOMTYPE.Focus()
                Exit Sub
            ElseIf CMBPLAN.Text.Trim = "" Then
                MsgBox("Enter Plan")
                CMBPLAN.Focus()
                Exit Sub
            ElseIf Val(TXTWEEKDAYS.Text) = 0 Then
                MsgBox("Enter WeekDay's Rate")
                TXTWEEKDAYS.Focus()
                Exit Sub
            ElseIf Val(TXTWEEKENDS.Text) = 0 Then
                MsgBox("Enter WeekEnd's Rate")
                TXTWEEKENDS.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBADDTAX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBADDTAX.Validating
        Try
            If CMBTAX.Text.Trim <> "" Then TAXvalidate(CMBTAX, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True And cmbhotelname.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJHOTEL As New ClsHotelMaster
                Dim DT As DataTable

                ALPARAVAL.Add(TEMPTARIFFNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJHOTEL.alParaval = ALPARAVAL

                Dim tempmsg As Integer = MsgBox("Delete Tariff Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJHOTEL.DELETE() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                clear()
                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTARIFF_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTARIFF.Validating
        Try
            If CMBTARIFF.Text.Trim <> "" Then
                pcase(CMBTARIFF)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBTARIFF.Text) <> LCase(TEMPTARIFFNAME)) Then
                    dt = objclscommon.search("TARIFF_name", "", "TARIFFMaster INNER JOIN HOTELMASTER ON TARIFF_HOTELID = HOTEL_ID AND TARIFF_YEARID = HOTEL_YEARID ", " and TARIFF_name = '" & CMBTARIFF.Text.Trim & "' AND HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' And TARIFF_cmpid = " & CmpId & " And TARIFF_locationid = " & Locationid & " And TARIFF_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("TARIFF Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FROMDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FROMDATE.Validating
        Try
            EP.Clear()
            If Not CHECKDATE(FROMDATE.Value.Date) Then
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKDATE(ByVal DTDATE As Date) As Boolean
        Try
            Dim WHERE As String = ""
            If edit = True Then WHERE = " AND TARIFF_ID <> " & TARIFFID
            Dim BLN As Boolean = True
            'CHECK WHETHER THIS DATE IS ALREADY USED IN DIFFERENT TARIFF PLAN FOR SAME HTOEL OR NOT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" TARIFF_NAME AS TARIFFNAME ", "", " TARIFFMASTER INNER JOIN HOTELMASTER ON TARIFF_HOTELID = HOTEL_ID AND TARIFF_CMPID = HOTEL_CMPID AND TARIFF_LOCATIONID = HOTEL_LOCATIONID AND TARIFF_YEARID = HOTEL_YEARID ", WHERE & " AND HOTEL_NAME = '" & cmbhotelname.Text.Trim & "' AND TARIFF_FROMDATE <= '" & Format(DTDATE.Date, "MM/dd/yyyy") & "' AND TARIFF_TODATE >= '" & Format(DTDATE.Date, "MM/dd/yyyy") & "'")
            If DT.Rows.Count > 0 Then
                EP.SetError(FROMDATE, "Date already present in " & DT.Rows(0).Item("TARIFFNAME"))
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub TODATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TODATE.Validating
        Try
            EP.Clear()
            If Not CHECKDATE(TODATE.Value.Date) Then
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTAX_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTAX.Enter
        Try
            If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTAX.Validating
        Try
            If CMBTAX.Text.Trim <> "" Then TAXvalidate(CMBTAX, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTSRNO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If gridDoubleClick = False Then
            If GRIDTRANS.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDTRANS.Rows(GRIDTRANS.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJTARIFF As New TariffDetails
            OBJTARIFF.MdiParent = MDIMain
            OBJTARIFF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class