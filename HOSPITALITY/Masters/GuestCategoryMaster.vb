Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class GuestCategoryMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPCATEGORYNAME As String
    Public TEMPCATEGORYID As Integer
    Public edit As Boolean              'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GuestCategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        EP.Clear()
        TXTCATEGORYNAME.Clear()
    End Sub

    Private Sub TXTCATEGORYNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCATEGORYNAME.Validating
        Try
            If TXTCATEGORYNAME.Text.Trim <> "" Then
                'pcase(TXTITEMNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TXTCATEGORYNAME.Text) <> LCase(TEMPCATEGORYNAME)) Then
                    dt = objclscommon.search("CATEGORY_NAME", "", "GUESTCATEGORYMASTER", " and CATEGORY_NAME = '" & TXTCATEGORYNAME.Text.Trim & "'")
                    If dt.Rows.Count > 0 Then
                        MsgBox("Guest Category Name Already Exists", MsgBoxStyle.Critical)
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTCATEGORYNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTCATEGORYNAME, "Fill Guest Category Name")
            bln = False
        Else
            If TXTCATEGORYNAME.Text.Trim <> "" Then
                'pcase(TXTITEMNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TXTCATEGORYNAME.Text) <> LCase(TEMPCATEGORYNAME)) Then
                    dt = objclscommon.search("CATEGORY_NAME", "", "GUESTCATEGORYMASTER", " and CATEGORY_NAME = '" & TXTCATEGORYNAME.Text.Trim & "' ")
                    If dt.Rows.Count > 0 Then
                        EP.SetError(TXTCATEGORYNAME, "Guest Category Name Already Exists")
                        bln = False
                    End If
                End If
            End If
        End If
        Return bln
    End Function


    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTCATEGORYNAME.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim objCATEGORY As New ClsGuestCategoryMaster
            objCATEGORY.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objCATEGORY.save()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCATEGORYID)
                IntResult = objCATEGORY.update()
                MsgBox("Details Updated")
                edit = False
            End If
            clear()
            TXTCATEGORYNAME.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        TXTCATEGORYNAME.Focus()
    End Sub

    Private Sub GuestCategoryMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GUEST MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            clear()
            TXTCATEGORYNAME.Text = TEMPCATEGORYNAME

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster
                dttable = objCommon.search(" CATEGORY_name  ", "", "GUESTCATEGORYMASTER", " AND CATEGORY_yearid = " & YearId & " and CATEGORY_id = " & TEMPCATEGORYID)
                If dttable.Rows.Count > 0 Then
                    TXTCATEGORYNAME.Text = dttable.Rows(0).Item(0).ToString
                    TEMPCATEGORYNAME = dttable.Rows(0).Item(0).ToString
                End If
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

                Dim tempmsg As Integer = MsgBox("Delete Guest Category Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then

                    Dim OBJCAT As New ClsGuestCategoryMaster
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(TEMPCATEGORYID)
                    ALPARAVAL.Add(YearId)


                    OBJCAT.alParaval = ALPARAVAL
                    Dim intres As Integer = OBJCAT.DELETE()
                    edit = False
                    clear()

                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class