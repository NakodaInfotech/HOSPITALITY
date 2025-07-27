
Imports BL
Imports System.Windows.Forms

Public Class SelectMiscEnquiry

    Public FRMSTRING As String
    Dim ROW As Integer = 0
    Public DT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectMiscEnquiry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectMiscEnquiry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "HOTEL" Then fillgrid(" and MISC_STATUS = 'PENDING' and (MISC_TYPE = 'DOMESTIC HOTEL' OR MISC_TYPE = 'INTERNATIONAL HOTEL')  and MISC_yearid = " & YearId & " order by MISC_no ")
            If FRMSTRING = "CAR RENTAL" Then fillgrid(" and MISC_STATUS = 'PENDING' and MISC_TYPE = 'CAR RENTAL' and MISC_yearid = " & YearId & " order by MISC_no ")
            If FRMSTRING = "DOMESTIC" Then fillgrid(" and MISC_STATUS = 'PENDING' and (MISC_TYPE = 'DOMESTIC PACKAGE' OR MISC_TYPE = 'CRUISE PACKAGE') and MISC_yearid = " & YearId & " order by MISC_no ")
            If FRMSTRING = "INTERNATIONAL" Then fillgrid(" and MISC_STATUS = 'PENDING' and (MISC_TYPE = 'INTERNATIONAL PACKAGE' OR MISC_TYPE = 'CRUISE PACKAGE') and MISC_yearid = " & YearId & " order by MISC_no ")
            If FRMSTRING = "VISA" Then fillgrid(" and MISC_STATUS = 'PENDING' and MISC_TYPE = 'VISA' and MISC_yearid = " & YearId & " order by MISC_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, MISCENQUIRY.MISC_NO AS MISCNO, MISCENQUIRY.MISC_DATE AS DATE, ISNULL(MISCENQUIRY.MISC_GUESTNAME, '') AS GUESTNAME, ISNULL(MISCENQUIRY.MISC_MOBILENO, '') AS MOBILENO, ISNULL(MISCENQUIRY.MISC_TYPE, '') AS TYPE, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(CATEGORY_NAME, '') AS CATEGORY, ISNULL(MISC_BOOKER,'') AS BOOKER ", "", "   MISCENQUIRY LEFT OUTER JOIN SOURCEMASTER ON MISCENQUIRY.MISC_SOURCEID = SOURCEMASTER.SOURCE_ID AND MISCENQUIRY.MISC_YEARID = SOURCEMASTER.SOURCE_YEARID INNER JOIN BOOKEDBYMASTER ON MISCENQUIRY.MISC_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID AND MISCENQUIRY.MISC_YEARID = BOOKEDBYMASTER.BOOKEDBY_YEARID LEFT OUTER JOIN CATEGORYMASTER ON MISCENQUIRY.MISC_CATEGORYID = CATEGORY_ID ", TEMPCONDITION)
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            DT.Columns.Add("MISCNO")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("MISCNO"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs)
        Try
            e.ErrorText = "Only 1 row can be selected at a time"
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
        Try

LINE1:
            If ROW = 0 Then
                For I As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(I)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        ROW = I
                        Exit For
                    End If
                Next
            Else
                Dim dtrow As DataRow = gridbill.GetDataRow(ROW)
                If Convert.ToBoolean(dtrow("CHK")) = False Then
                    ROW = 0
                    GoTo LINE1
                End If
            End If

            If Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = True And e.RowHandle <> ROW Then
                e.Valid = False
                gridbill.SetColumnError(gridbill.Columns("CHK"), "Only 1 row can be selected at a time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)
            ElseIf Convert.ToBoolean(gridbill.GetFocusedRowCellValue("CHK")) = False And e.RowHandle = ROW Then
                ROW = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class