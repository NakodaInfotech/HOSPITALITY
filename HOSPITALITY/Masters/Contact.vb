
Imports BL

Public Class Contact

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Public edit As Boolean
    Public tempMsg As Integer

    Dim TEMPCONTACTNO As Integer
    Dim TEMPCONTACTNAME As String
    Dim TEMPMOBILENO As String
    Dim TEMPEMAIL As String
    
    Sub CLEAR()
        TXTCONTACTNO.Clear()
        TXTSRNO.Clear()
        TXTNAME.Clear()
        TXTSURNAME.Clear()
        TXTMOBILE.Clear()
        TXTEMAIL.Clear()
        CMBCITY.Text = ""
        CMBCATEGORY.Text = ""
    End Sub

    Sub GETSRNO()
        Try
            For Each ROW As DataGridViewRow In GRIDCONT.Rows
                ROW.Cells(GSRNO.Index).Value = ROW.Index + 1
            Next
            TXTSRNO.Text = GRIDCONT.RowCount + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim BLN As Boolean = True

        If TXTNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTNAME, "Fill Name")
            BLN = False
        End If


        If TXTMOBILE.Text.Trim.Length = 0 Then
            EP.SetError(TXTMOBILE, "Fill Mobile Number")
            BLN = False
        End If

        'If TXTEMAIL.Text.Trim.Length = 0 Then
        '    EP.SetError(TXTEMAIL, "Fill Email Address")
        '    BLN = False
        'End If

        Return BLN
    End Function

    Private Sub Contact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If (e.KeyCode = Windows.Forms.Keys.Escape) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Sub FILLCMB()
        fillcity(CMBCITY)
        If CMBCATEGORY.Text.Trim = "" Then
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search(" Distinct CONTACT_CATEGORY AS CATEGORY ", "", " CONTACT", " and CONTACT_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "CATEGORY"
                CMBCATEGORY.DataSource = dt
                CMBCATEGORY.DisplayMember = "CATEGORY"
                CMBCATEGORY.Text = ""
            End If
            CMBCATEGORY.SelectAll()
        End If
    End Sub

    Sub FILLGRID()
        Try
            If gridDoubleClick = False Then

                GRIDCONT.Rows.Add(TXTCONTACTNO.Text, 0, TXTNAME.Text.Trim, TXTSURNAME.Text.Trim, TXTMOBILE.Text.Trim, TXTEMAIL.Text.Trim, CMBCITY.Text.Trim, CMBCATEGORY.Text.Trim)
            Else
                GRIDCONT.Item(GCONNO.Index, temprow).Value = TXTCONTACTNO.Text.Trim
                GRIDCONT.Item(GNAME.Index, temprow).Value = TXTNAME.Text.Trim
                GRIDCONT.Item(GSURNAME.Index, temprow).Value = TXTSURNAME.Text.Trim
                GRIDCONT.Item(GMOBILE.Index, temprow).Value = TXTMOBILE.Text.Trim
                GRIDCONT.Item(GEMAIL.Index, temprow).Value = TXTEMAIL.Text.Trim
                GRIDCONT.Item(GCITY.Index, temprow).Value = CMBCITY.Text.Trim
                GRIDCONT.Item(GCATEGORY.Index, temprow).Value = CMBCATEGORY.Text.Trim
                gridDoubleClick = False
            End If
            CLEAR()
            GETSRNO()


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Contact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim OBJSEARCH As New ClsCommon
        Dim dttable As New DataTable
        'OBJSEARCH.alParaval = ALPARAVAL

        dttable = OBJSEARCH.search("CONTACT_NO, CONTACT_SRNO, CONTACT_NAME, CONTACT_SURNAME, CONTACT_MOBILE, CONTACT_EMAIL, citymaster.city_name as city, CONTACT_CATEGORY", "", "CONTACT LEFT OUTER JOIN CITYMASTER ON CONTACT.CONTACT_CITYID = CITYMASTER.CITY_ID", " order by CONTACT_NO")

        If dttable.Rows.Count > 0 Then
            For Each DR As DataRow In dttable.Rows
                GRIDCONT.Rows.Add(DR("CONTACT_NO"), DR("CONTACT_SRNO"), DR("CONTACT_NAME"), DR("CONTACT_SURNAME"), DR("CONTACT_MOBILE"), DR("CONTACT_EMAIL"), DR("CITY"), DR("CONTACT_CATEGORY"))
            Next
            GRIDCONT.FirstDisplayedScrollingRowIndex = GRIDCONT.RowCount - 1
        End If

        GETSRNO()
        FILLCMB()
        TXTNAME.Focus()

    End Sub

    Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNAME.Validating
        Try
            'pcase(TXTNAME)
            'If TXTNAME.Text <> "" And GRIDCONT.RowCount > 0 Then
            '    If gridDoubleClick = False Or (gridDoubleClick = True And TXTNAME.Text.Trim <> (TEMPCONTACTNAME)) Then
            '        For Each ROW As DataGridViewRow In GRIDCONT.Rows
            '            If ROW.Cells(GNAME.Index).Value = TXTNAME.Text.Trim Then
            '                MsgBox("Name Already Exist")
            '                TXTNAME.Focus()
            '                Exit Sub
            '            End If
            '        Next
            '    End If
            'End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub TXTMOBILE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTMOBILE.Validating
        Try
            If TXTMOBILE.Text <> "" And GRIDCONT.RowCount > 0 Then
                If gridDoubleClick = False Or (gridDoubleClick = True And TXTMOBILE.Text.Trim <> TEMPMOBILENO) Then
                    For Each ROW As DataGridViewRow In GRIDCONT.Rows
                        If ROW.Cells(GMOBILE.Index).Value = TXTMOBILE.Text.Trim Then
                            MsgBox("Mobile No. Already Exist")
                            TXTMOBILE.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTEMAIL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTEMAIL.Validating
        Try
            If TXTMOBILE.Text <> "" And GRIDCONT.RowCount > 0 Then
                If gridDoubleClick = False Or (gridDoubleClick = True And TXTEMAIL.Text.Trim <> TEMPEMAIL) Then
                    For Each ROW As DataGridViewRow In GRIDCONT.Rows
                        If ROW.Cells(GEMAIL.Index).Value = TXTEMAIL.Text.Trim Then
                            MsgBox("Email Address Already Exist")
                            TXTEMAIL.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If TXTNAME.Text.Trim <> "" And TXTMOBILE.Text.Trim <> "" Then

                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TXTSRNO.Text.Trim)
                ALPARAVAL.Add(TXTNAME.Text.Trim)
                ALPARAVAL.Add(TXTSURNAME.Text.Trim)
                ALPARAVAL.Add(TXTMOBILE.Text.Trim)
                ALPARAVAL.Add(TXTEMAIL.Text.Trim)
                ALPARAVAL.Add(CMBCITY.Text.Trim)
                ALPARAVAL.Add(CMBCATEGORY.Text.Trim)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)

                Dim OBJCONTACT As New ClsContactMaster
                OBJCONTACT.alParaval = ALPARAVAL

                If edit = False Then
                    Dim DTTABLE As DataTable = OBJCONTACT.SAVE()
                    MsgBox("Details Added")
                    TXTCONTACTNO.Text = DTTABLE.Rows(0).Item(0)
                Else
                    ALPARAVAL.Add(TXTCONTACTNO.Text)
                    Dim INTRES As Integer = OBJCONTACT.UPDATE()
                    MsgBox("Details Update")
                End If

                EP.Clear()
                FILLGRID()
                CLEAR()
                FILLCMB()
                GETSRNO()
                TXTNAME.Focus()
            Else
                EP.Clear()
                If Not errorvalid() Then
                    MsgBox("Enter Proper Details")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCONT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONT.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            TEMPCONTACTNAME = GRIDCONT.Item(GNAME.Index, e.RowIndex).Value
            TEMPMOBILENO = GRIDCONT.Item(GMOBILE.Index, e.RowIndex).Value
            TEMPEMAIL = GRIDCONT.Item(GEMAIL.Index, e.RowIndex).Value

            TXTCONTACTNO.Text = GRIDCONT.Item(GCONNO.Index, e.RowIndex).Value
            TXTSRNO.Text = GRIDCONT.Item(GSRNO.Index, e.RowIndex).Value
            TXTNAME.Text = GRIDCONT.Item(GNAME.Index, e.RowIndex).Value
            TXTSURNAME.Text = GRIDCONT.Item(GSURNAME.Index, e.RowIndex).Value
            TXTMOBILE.Text = GRIDCONT.Item(GMOBILE.Index, e.RowIndex).Value
            TXTEMAIL.Text = GRIDCONT.Item(GEMAIL.Index, e.RowIndex).Value
            CMBCITY.Text = GRIDCONT.Item(GCITY.Index, e.RowIndex).Value
            CMBCATEGORY.Text = GRIDCONT.Item(GCATEGORY.Index, e.RowIndex).Value

            gridDoubleClick = True
            edit = True
            temprow = e.RowIndex
            TXTNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCONT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONT.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDCONT.SelectedRows.Count > 0 Then
                    Dim CONTACTNO As Integer
                    CONTACTNO = (GRIDCONT.Rows(GRIDCONT.CurrentRow.Index).Cells(GCONNO.Index).Value)

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJCONTACT As New ClsContactMaster

                    OBJCONTACT.alParaval = ALPARAVAL
                    ALPARAVAL.Add(CONTACTNO)

                    Dim TEMPMSG As Integer = MsgBox("Delete Details", MsgBoxStyle.YesNo)

                    If TEMPMSG = vbYes Then
                        Dim INTRES As Integer = OBJCONTACT.DELETE()
                        GRIDCONT.Rows.RemoveAt(GRIDCONT.SelectedRows(0).Index)
                    End If
                    GETSRNO()
                End If
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub CMBCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCITY.Validating
        If CMBCITY.Text.Trim <> "" Then
            CITYVALIDATE(CMBCITY, e, Me)
        End If
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub
End Class