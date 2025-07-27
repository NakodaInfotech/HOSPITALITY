Imports BL
Imports System.Windows.Forms

Public Class BlockDateMaster
    Public frmstring As String          'Used for Area, City, State, Country Forms
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempCODE As String           'Used for edit name
    Public tempid As Integer            'Used for edit id
    Dim tempRow As Integer
    Dim gridDoubleClick As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmbcountry_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcountry.Enter
        Try
            If cmbcountry.Text = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and COUNTRY_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If

                If cmbcountry.Text.Trim <> "" Then
                    pcase(cmbcountry)

                    'GETTING DATA FOR EDIT MODE
                    Dim OBJCMN As New ClsCommon
                    dt = OBJCMN.search(" BLOCKDATEMASTER.BLOCK_FROMDATE AS FROMDATE, BLOCKDATEMASTER.BLOCK_TODATE AS TODATE,BLOCKDATEMASTER.BLOCK_REMARK AS REMARK", "", " BLOCKDATEMASTER LEFT OUTER JOIN COUNTRYMASTER ON BLOCKDATEMASTER.BLOCK_yearid = COUNTRYMASTER.country_yearid AND BLOCKDATEMASTER.BLOCK_COUNTRYID = COUNTRYMASTER.country_id", " AND COUNTRYMASTER.country_name = '" & cmbcountry.Text.Trim & "' AND BLOCKDATEMASTER.BLOCK_YEARID = " & YearId)

                    If DT.Rows.Count > 0 Then
                        GRIDBOOKINGS.RowCount = 0
                        For Each DTROW As DataRow In DT.Rows
                            GRIDBOOKINGS.Rows.Add(Format(Convert.ToDateTime(DTROW("FROMDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DTROW("TODATE")).Date, "dd/MM/yyyy"), DTROW("REMARK"))
                        Next
                        edit = True
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(cmbcountry.Text.Trim)

            Dim FROMDATE As String = ""
            Dim TODATE As String = ""
            Dim REMARK As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBOOKINGS.Rows
                If REMARK = "" Then
                    FROMDATE = Format(Convert.ToDateTime(row.Cells(GFromDate.Index).Value).Date, "MM/dd/yyyy")
                    TODATE = Format(Convert.ToDateTime(row.Cells(GTODATE.Index).Value).Date, "MM/dd/yyyy")
                    REMARK = row.Cells(GREMARKS.Index).Value
                Else
                    FROMDATE = FROMDATE & "|" & Format(Convert.ToDateTime(row.Cells(GFromDate.Index).Value).Date, "MM/dd/yyyy")
                    TODATE = TODATE & "|" & Format(Convert.ToDateTime(row.Cells(GTODATE.Index).Value).Date, "MM/dd/yyyy")
                    REMARK = REMARK & "|" & row.Cells(GREMARKS.Index).Value
                End If
            Next

            alParaval.Add(FROMDATE)
            alParaval.Add(TODATE)
            alParaval.Add(REMARK)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objLWZ As New ClsLawazim
           If frmstring = "BLOCKDATE" Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                objLWZ.alParaval = alParaval
                IntResult = objLWZ.saveBLOCKDATE()
                MsgBox("Block Dates Added")
            End If
            edit = False
            clear()
            cmbcountry.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbcountry.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcountry, "Fill Country")
            bln = False
        End If

        If fromdate.Value.Date > todate.Value.Date Then
            Ep.SetError(fromdate, "Fill Proper Dates")
            bln = False
        End If

        
        Return bln
    End Function

    Sub clear()
        cmbcountry.Text = ""
        cmbcountry.Enabled = True
        fromdate.Value = Mydate
        todate.Value = Mydate
        GRIDBOOKINGS.RowCount = 0
    End Sub

    Private Sub BlockDateMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            If frmstring = "FORMTYPE" Then
                DTROW = USERRIGHTS.Select("FormName = 'FORMTYPE MASTER'")
            Else
                DTROW = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If frmstring = "BLOCKDATE" Then
                Me.Text = "Block Date Master"
            End If

            If frmstring = "BLOCKDATE" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable
                If edit = True Then
                    DT = OBJCMN.search(" BLOCKDATEMASTER.BLOCK_FROMDATE AS FROMDATE, BLOCKDATEMASTER.BLOCK_TODATE AS TODATE,BLOCKDATEMASTER.BLOCK_REMARK AS REMARK", "", " BLOCKDATEMASTER LEFT OUTER JOIN COUNTRYMASTER ON BLOCKDATEMASTER.BLOCK_yearid = COUNTRYMASTER.country_yearid AND BLOCKDATEMASTER.BLOCK_COUNTRYID = COUNTRYMASTER.country_id", " AND COUNTRYMASTER.country_name = '" & tempname & "' AND BLOCKDATEMASTER.BLOCK_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        GRIDBOOKINGS.RowCount = 0
                        cmbcountry.Text = tempname
                        For Each DTNEW As DataRow In DT.Rows
                            GRIDBOOKINGS.Rows.Add(Format(Convert.ToDateTime(DTNEW("FROMDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(DTNEW("TODATE")).Date, "dd/MM/yyyy"), DTNEW("REMARK"))
                        Next
                        edit = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub BlockDateMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            Try
                If cmbcountry.Text.Trim <> "" Then
                    UCase(cmbcountry.Text.Trim)
                    Dim objClsCommon As New ClsCommonMaster
                    Dim objyearmaster As New ClsYearMaster
                    Dim DT As DataTable
                    DT = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
                    If dt.Rows.Count = 0 Then
                        Dim a As String = cmbcountry.Text.Trim
                        Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "TRAVELMATE")
                        If tempmsg = vbYes Then
                            cmbcountry.Text = a
                            objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_locationid = " & Locationid & " and country_yearid = " & YearId)
                            Dim dt1 As New DataTable
                            dt1 = cmbcountry.DataSource
                            If cmbcountry.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbcountry.Text)
                                    cmbcountry.Text = a
                                End If
                            End If
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If

                Dim OBJCMN As New ClsCommon
                Dim DTNEW As DataTable = OBJCMN.search(" BLOCKDATEMASTER.BLOCK_FROMDATE AS FROMDATE, BLOCKDATEMASTER.BLOCK_TODATE AS TODATE,BLOCKDATEMASTER.BLOCK_REMARK AS REMARK", "", " BLOCKDATEMASTER LEFT OUTER JOIN COUNTRYMASTER ON BLOCKDATEMASTER.BLOCK_yearid = COUNTRYMASTER.country_yearid AND BLOCKDATEMASTER.BLOCK_COUNTRYID = COUNTRYMASTER.country_id ", " AND COUNTRYMASTER.country_name = '" & cmbcountry.Text.Trim & "' AND BLOCKDATEMASTER.BLOCK_YEARID = " & YearId)
                If DTNEW.Rows.Count > 0 Then
                    GRIDBOOKINGS.RowCount = 0
                    For Each DTROW As DataRow In DTNEW.Rows
                        GRIDBOOKINGS.Rows.Add(DTROW("FROMDATE"), DTROW("TODATE"), DTROW("REMARK"))
                    Next
                Else
                    GRIDBOOKINGS.RowCount = 0
                End If

            Catch ex As Exception
                GoTo line1
                If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
            End Try

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True And cmbcountry.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsLawazim

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(tempid)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                If frmstring = "IMPDATE" Then
                    tempmsg = MsgBox("Delete Imp Date Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEIMPDATE() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                ElseIf frmstring = "BLOCKDATE" Then
                    tempmsg = MsgBox("Delete Block Date Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                    If tempmsg = vbYes Then DT = OBJ.DELETEBLOCKDATE() Else Exit Sub
                    MsgBox(DT.Rows(0).Item(0))
                End If
            End If
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREMARKS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREMARKS.Validating
        Try
            If cmbcountry.Text.Trim = "" Then
                MsgBox("Select Country First", MsgBoxStyle.Critical, CmpName)
                cmbcountry.Focus()
            End If
            If TXTREMARKS.Text.Trim <> "" And fromdate.Value.Date <= todate.Value.Date Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
                ''cmbcountry.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDBOOKINGS.Rows.Add(Format(fromdate.Value.Date, "dd/MM/yyyy"), Format(todate.Value.Date, "dd/MM/yyyy"), TXTREMARKS.Text.Trim)
        ElseIf gridDoubleClick = True Then
            GRIDBOOKINGS.Rows(tempRow).Cells(GFromDate.Index).Value = Format(fromdate.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Rows(tempRow).Cells(GTODATE.Index).Value = Format(todate.Value.Date, "dd/MM/yyyy")
            GRIDBOOKINGS.Rows(tempRow).Cells(GREMARKS.Index).Value = TXTREMARKS.Text.Trim

            gridDoubleClick = False
        End If
        GRIDBOOKINGS.FirstDisplayedScrollingRowIndex = GRIDBOOKINGS.RowCount - 1
        fromdate.Value = Mydate
        todate.Value = Mydate
        TXTREMARKS.Clear()

    End Sub

    Private Sub GRIDBOOKINGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBOOKINGS.CellDoubleClick
        If e.RowIndex >= 0 And GRIDBOOKINGS.Item(GREMARKS.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            fromdate.Value = Format(Convert.ToDateTime(GRIDBOOKINGS.Item(GFromDate.Index, e.RowIndex).Value).Date, "dd/MM/yyyy")
            todate.Value = Format(Convert.ToDateTime(GRIDBOOKINGS.Item(GTODATE.Index, e.RowIndex).Value).Date, "dd/MM/yyyy")
            TXTREMARKS.Text = GRIDBOOKINGS.Item(GREMARKS.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            'cmbcountry.Focus()
        End If
    End Sub

    Private Sub GRIDBOOKINGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBOOKINGS.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDBOOKINGS.Rows.RemoveAt(GRIDBOOKINGS.CurrentRow.Index)
        End If
    End Sub


End Class