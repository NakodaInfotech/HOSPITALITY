Imports BL
Imports System.Windows.Forms

Public Class CustomerCategoryMaster
    Public frmstring As String          'Used for Area, City, State, Country Forms
    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempid As Integer            'Used for edit id
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

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

            alParaval.Add(txtcategory.Text.Trim)
            alParaval.Add(TXTBOOKING.Text.Trim)
            alParaval.Add(TXTREFFERENCE.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objCATEGORY As New ClsCustomerCategoryMaster
            objCATEGORY.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objCATEGORY.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                IntResult = objCATEGORY.update()
                edit = False
                MsgBox("Details Updated")
            End If

            clear()
            txtcategory.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtcategory.Text.Trim.Length = 0 Then
            Ep.SetError(txtcategory, "Fill Name")
            bln = False
        End If

        If TXTBOOKING.Text.Trim.Length = 0 Then
            Ep.SetError(TXTBOOKING, "Fill Booking %")
            bln = False
        End If

        If TXTREFFERENCE.Text.Trim.Length = 0 Then
            Ep.SetError(TXTREFFERENCE, "Fill Refference %")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        txtcategory.Clear()
        TXTBOOKING.Clear()
        TXTREFFERENCE.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub CustomerCategoryMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CustomerCategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
            End If


            If edit = True Then dttable = objCommon.search(" CATEGORY_NAME, CATEGORY_BOOKING, CATEGORY_REFFERENCE, CATEGORY_REMARKS", "", "CategoryMaster", " and category_id = " & tempid & " and category_cmpid = " & CmpId & " and category_Locationid = " & Locationid & " and category_yearid = " & YearId)

            If dttable.Rows.Count > 0 Then
                txtcategory.Text = dttable.Rows(0).Item(0).ToString
                txtcategory.Text = dttable.Rows(0).Item(1).ToString
                txtcategory.Text = dttable.Rows(0).Item(2).ToString
                txtremarks.Text = dttable.Rows(0).Item(3).ToString
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try


    End Sub


    Private Sub txtcategory_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcategory.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtcategory.Text.Trim)) Then
                ' search duplication 
                If txtcategory.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable


                    dt = objclscommon.search("category_name", "", "categoryMaster", " and category_name = '" & txtcategory.Text.Trim & "' and category_cmpid = " & CmpId & " and category_Locationid = " & Locationid & " and category_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Category Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                    pcase(txtcategory)
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class