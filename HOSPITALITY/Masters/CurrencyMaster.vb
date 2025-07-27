
Imports BL
Imports System.Windows.Forms

Public Class CurrencyMaster

    Public edit As Boolean              'Used for edit
    Public tempname As String           'Used for edit name
    Public tempCODE As String           'Used for edit name
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
            Dim MS As New IO.MemoryStream

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(TXTCODE.Text.Trim)

            If PBIMG.Image IsNot Nothing Then
                PBIMG.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim objCity As New ClsCityMaster
            Dim objyear As New ClsYearMaster

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                objyear.alParaval = alParaval
                IntResult = objyear.savecurrency()
                MsgBox("Currency Added")
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempid)
                objCity.alParaval = alParaval
                IntResult = objCity.UpdateCcrrency()
                MsgBox("Currency Updated")
            End If
            clear()
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If TXTCODE.Text.Trim.Length = 0 Then
            Ep.SetError(TXTCODE, "Fill Code")
            bln = False
        End If

        If Not VALIDATENAME() Then
            Ep.SetError(txtname, "Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        TXTCODE.Clear()
        PBIMG.Image = Nothing
    End Sub

    Private Sub CurrencyMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub CurrencyMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'CURRENCY MASTER'")
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
                dttable = objCommon.search(" cur_name, CUR_CODE, CUR_LOGO AS IMGPATH", "", "CURRENCYMASTER", " and cur_id = " & tempid & " and cur_cmpid = " & CmpId & " and cur_Locationid = " & Locationid & " and cur_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    txtname.Text = dttable.Rows(0).Item(0).ToString
                    TXTCODE.Text = dttable.Rows(0).Item(1).ToString
                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then PBIMG.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(sender As Object, e As EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBIMG.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub cmdremove_Click(sender As Object, e As EventArgs) Handles cmdremove.Click
        Try
            PBIMG.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function VALIDATENAME() As Boolean
        Try
            Dim BLN As Boolean = True
            If (edit = False) Or (edit = True And LCase(tempname) <> LCase(txtname.Text.Trim)) Then
                ' search duplication 
                If txtname.Text.Trim <> Nothing Then
                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    dt = objclscommon.search("CUR_name", "", "CURRENCYMaster", " and CUR_name = '" & txtname.Text.Trim & "' and cur_cmpid = " & CmpId & " and cur_Locationid = " & Locationid & " and cur_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Currency Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                        BLN = False
                    End If
                    uppercase(txtname)
                End If

                If (edit = False) Or (edit = True And LCase(tempCODE) <> LCase(TXTCODE.Text.Trim)) Then
                    If TXTCODE.Text.Trim <> "" Then
                        Dim objclscommon As New ClsCommonMaster
                        Dim dt As DataTable = objclscommon.search("CUR_CODE", "", "currencyMaster", " and CUR_CODE = '" & TXTCODE.Text.Trim & "' and cur_cmpid = " & CmpId & " and cur_Locationid = " & Locationid & " and cur_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Code Name Already Exists", MsgBoxStyle.Critical, "TRAVELMATE")
                            BLN = False
                        End If
                        uppercase(TXTCODE)
                    End If
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

            If edit = True And txtname.Text.Trim <> "" Then
                Dim ALPARAVAL As New ArrayList
                Dim OBJ As New ClsCityMaster

                ALPARAVAL.Add(tempname)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(Userid)
                OBJ.alParaval = ALPARAVAL

                Dim DT As DataTable
                Dim tempmsg As Integer
                tempmsg = MsgBox("Delete Currency Permanently?", MsgBoxStyle.YesNo, "TRAVELMATE")
                If tempmsg = vbYes Then DT = OBJ.DELETECURRENCY() Else Exit Sub
                MsgBox(DT.Rows(0).Item(0))
                clear()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCODE.Validating
        Try
            If Not VALIDATENAME() Then e.Cancel = True
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class