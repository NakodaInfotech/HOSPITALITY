
Imports System.ComponentModel
Imports BL

Public Class CmpExciseInf

    Public alParaval As New ArrayList
    Public EDIT As Boolean
    Public TEMPCMPNAME As String
    Public TEMPSTATENAME As String = ""

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Try
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If
            alParaval.Add(txtvatno.Text)
            alParaval.Add(txtcstno.Text)
            alParaval.Add(txtstno.Text)
            alParaval.Add(txtpanno.Text)
            alParaval.Add(txteccno.Text)
            alParaval.Add(txtexno.Text)
            alParaval.Add(txtplano.Text)
            alParaval.Add(txtrange.Text)
            alParaval.Add(txtdivision.Text)
            alParaval.Add(txtcentralexoff.Text)
            alParaval.Add(txtdivisionoff.Text)
            alParaval.Add(txtcommissionerate.Text)
            alParaval.Add(txtheadingno.Text)
            alParaval.Add(TXTGSTINNO.Text)

            'TDS DETAILS
            alParaval.Add(TXTTAXASSNO.Text.Trim)
            alParaval.Add(TXTITWARD.Text.Trim)
            alParaval.Add(CMBDEDUCTORTYPE.Text.Trim)
            alParaval.Add(TXTRESPONSIBLE.Text.Trim)
            alParaval.Add(TXTDESIGNATION.Text.Trim)

            alParaval.Add(CMBFROMCITY.Text)
            alParaval.Add(TXTEWBUSER.Text)
            alParaval.Add(TXTEWBPASS.Text)
            alParaval.Add(TXTDISPATCHFROM.Text)


            Me.Hide()
            Cmppassword.alParaval = alParaval
            Cmppassword.EDIT = EDIT
            Cmppassword.TEMPCMPNAME = TEMPCMPNAME
            Cmppassword.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Try
            Dim obj As New Cmpmaster
            Me.Hide()
            obj.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrange_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrange.Validated
        pcase(txtrange)
    End Sub

    Private Sub txtdivision_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdivision.Validated
        pcase(txtdivision)
    End Sub

    Private Sub txtcentralexoff_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentralexoff.Validated
        pcase(txtcentralexoff)
    End Sub

    Private Sub txtdivisionoff_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdivisionoff.Validated
        pcase(txtdivisionoff)
    End Sub

    Private Sub CmpExciseInf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTGSTINNO.Text.Trim.Length > 0 Then
            If txtpanno.Text.Trim = "" Then
                EP.SetError(txtpanno, "Enter Pan No")
                bln = False
            End If

            If txtpanno.Text.Trim.Length <> 10 Then
                EP.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            End If

            'CHECKING 2ND TO 11TH ALPHABETS WITH PANNO
            If txtpanno.Text.Trim <> TXTGSTINNO.Text.Substring(2, 10) Then
                EP.SetError(txtpanno, "Enter Proper PAN Details")
                bln = False
            End If

            If TXTGSTINNO.Text.Trim.Length <> 15 Then
                EP.SetError(TXTGSTINNO, "Enter Proper GST No")
                bln = False
            End If
        End If

        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If TEMPSTATENAME <> "" And TXTGSTINNO.Text.Trim <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & TEMPSTATENAME & "' AND state_yearid = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTINNO.Text.Substring(0, 2) Then
                EP.SetError(TXTGSTINNO, "State Code does not match with GST No")
                bln = False
            End If
        End If


        If txtpanno.Text.Trim <> "" Then
            For x = 1 To Len(txtpanno.Text.Trim)
                If x <= 5 Or x = 10 Then
                    If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                        EP.SetError(txtpanno, "Insert Proper PAN No")
                        bln = False
                    End If
                Else
                    If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                        EP.SetError(txtpanno, "Insert Proper PAN No")
                        bln = False
                    End If
                End If
            Next
        End If

        Return bln
    End Function

    Private Sub CmpExciseInf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If EDIT = True Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                DT = OBJCMN.search("CMP_VATNO, CMP_CSTNO, CMP_STNO, CMP_PANNO, CMP_ECCNO, CMP_EXCISENO, CMP_PLANO, CMP_RANGE, CMP_DIVISION, CMP_EXCISEOFF, CMP_DIVISIONOFF,CMP_COMMISSIONERATE, CMP_HEADINGNO,  CMP_GSTIN AS GSTIN, CMP_TAXASSNO, CMP_ITWARD, CMP_DEDUCTORTYPE, CMP_RESPONSIBLE, CMP_DESIGNATION, CMP_EWBUSER AS EWBUSER, CMP_EWBPASS AS EWBPASS, CMP_DISPATCHFROM AS DISPATCHFROM, ISNULL(CITY_NAME,'') AS FROMCITY ", "", " CMPMASTER LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID", " AND CMP_NAME = '" & TEMPCMPNAME & "'")
                Dim DTROW As DataRow = DT.Rows(0)

                txtvatno.Text = DTROW(0).ToString
                txtcstno.Text = DTROW(1).ToString
                txtstno.Text = DTROW(2).ToString
                txtpanno.Text = DTROW(3).ToString
                txteccno.Text = DTROW(4).ToString
                txtexno.Text = DTROW(5).ToString
                txtplano.Text = DTROW(6).ToString
                txtrange.Text = DTROW(7).ToString
                txtdivision.Text = DTROW(8).ToString
                txtcentralexoff.Text = DTROW(9).ToString
                txtdivisionoff.Text = DTROW(10).ToString
                txtcommissionerate.Text = DTROW(11).ToString
                txtheadingno.Text = DTROW(12).ToString
                TXTGSTINNO.Text = DTROW(13).ToString
                TXTTAXASSNO.Text = DTROW(14).ToString
                TXTITWARD.Text = DTROW(15).ToString
                CMBDEDUCTORTYPE.Text = DTROW(16).ToString
                TXTRESPONSIBLE.Text = DTROW(17).ToString
                TXTDESIGNATION.Text = DTROW(18).ToString

                CMBFROMCITY.Text = DTROW("FROMCITY").ToString
                TXTEWBUSER.Text = DTROW("EWBUSER").ToString
                TXTEWBPASS.Text = DTROW("EWBPASS").ToString
                TXTDISPATCHFROM.Text = DTROW("DISPATCHFROM").ToString


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Enter(sender As Object, e As EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class