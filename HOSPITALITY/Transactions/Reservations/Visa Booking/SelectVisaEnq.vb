Imports BL
Imports System.Windows.Forms

Public Class SelectVisaEnq

    Dim tempindex, i As Integer
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public DT As New DataTable
    Public NAME As String = ""
   

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectVisaEnq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 100
        fillgrid("")
    End Sub

    Private Sub SelectVisaEnq_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If NAME <> "" Then WHERE = WHERE & " AND LEDGERS.Acc_cmpname = '" & NAME & "'"

            Dim objclspreq As New ClsCommon()
            Dim DT As New DataTable

            DT = objclspreq.search("CAST (0 AS BIT) AS CHK,  VISAENQMASTER.ENQ_NO AS ENQNO, ISNULL(VISAENQMASTER.ENQ_MISCENQNO, 0) AS MISCENQNO, VISAENQMASTER.ENQ_DATE AS DATE,ISNULL(LEDGERS.Acc_cmpname,'') AS NAME, ISNULL(BOOKEDBYMASTER.BOOKEDBY_NAME, '') AS BOOKEDBY, ISNULL(VISAENQMASTER.ENQ_ENQUIREDBY, '') AS ENQUIRBY, ISNULL(SOURCEMASTER.SOURCE_NAME, '') AS SOURCE, ISNULL(VISAENQMASTER.ENQ_REMARKS, '') AS REMARKS, ISNULL(VISAENQMASTER_DESC.ENQ_SRNO, 0) AS SRNO, ISNULL(GUESTMASTER.GUEST_NAME, '') AS GUEST, ISNULL(VISAENQMASTER_DESC.ENQ_PASSPORTNO, '') AS PASSPORT, ISNULL(COUNTRYMASTER.country_name, '') AS COUNTRY, ISNULL(VISAENQMASTER_DESC.ENQ_SUBDATE, '') AS SUBDATE, ISNULL(VISAENQMASTER_DESC.ENQ_COLDATE, '') AS COLDATE, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(VISAENQMASTER_DESC.ENQ_VISAFEES, 0) AS VISAFEES, ISNULL(VISAENQMASTER_DESC.ENQ_VFS, 0) AS VFS, ISNULL(VISAENQMASTER_DESC.ENQ_MISC, 0) AS MISC, ISNULL(VISAENQMASTER_DESC.ENQ_AMT, 0) AS AMT, ISNULL(VISAENQMASTER_DESC.ENQ_SERCHGS, 0) AS SERCHGS, ISNULL(VISAENQMASTER_DESC.ENQ_QUERY, '') AS QUERY ", "", " VISAENQMASTER INNER JOIN VISAENQMASTER_DESC ON VISAENQMASTER.ENQ_NO = VISAENQMASTER_DESC.ENQ_NO AND VISAENQMASTER.ENQ_YEARID = VISAENQMASTER_DESC.ENQ_YEARID INNER JOIN LEDGERS ON VISAENQMASTER.ENQ_LEDGERID = LEDGERS.Acc_id AND VISAENQMASTER.ENQ_YEARID = LEDGERS.Acc_yearid INNER JOIN GUESTMASTER ON VISAENQMASTER_DESC.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND VISAENQMASTER_DESC.ENQ_YEARID = GUESTMASTER.GUEST_YEARID LEFT OUTER JOIN BOOKEDBYMASTER ON VISAENQMASTER.ENQ_BOOKEDBYID = BOOKEDBYMASTER.BOOKEDBY_ID LEFT OUTER JOIN SOURCEMASTER ON VISAENQMASTER.ENQ_SOURCEID = SOURCEMASTER.SOURCE_ID LEFT OUTER JOIN COUNTRYMASTER ON VISAENQMASTER_DESC.ENQ_COUNTRYID = COUNTRYMASTER.country_id LEFT OUTER JOIN CITYMASTER ON VISAENQMASTER_DESC.ENQ_CITYID = CITYMASTER.city_id ", " AND VISAENQMASTER.ENQ_CLOSE=0 AND VISAENQMASTER_DESC.ENQ_GRIDDONE=0 " & WHERE & " AND VISAENQMASTER.ENQ_YEARID = " & YearId)

            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim n As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If n <> "" Then
                        If n = (dtrow("ENQNO")) Then
                            GoTo Line1
                        Else
                            MsgBox("Pls Select Same Enquiry !")
                            Exit Sub
                        End If
                    End If
Line1:
                    n = (dtrow("ENQNO"))
                End If
            Next


            DT.Columns.Add("ENQNO")
            DT.Columns.Add("BOOKEDBY")
            DT.Columns.Add("ENQUIRYBY")
            DT.Columns.Add("SOURCE")
            DT.Columns.Add("REMARKS")
            DT.Columns.Add("SRNO")
            DT.Columns.Add("GUEST")
            DT.Columns.Add("PASSPORT")
            DT.Columns.Add("COUNTRY")
            DT.Columns.Add("SUBDATE")
            DT.Columns.Add("COLDATE")
            DT.Columns.Add("CITY")
            DT.Columns.Add("VISAFEES")
            DT.Columns.Add("VFS")
            DT.Columns.Add("MISC")
            DT.Columns.Add("AMT")
            DT.Columns.Add("SERCHGS")
            DT.Columns.Add("QUERY")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("ENQNO"), dtrow("BOOKEDBY"), dtrow("ENQUIRBY"), dtrow("SOURCE"), dtrow("REMARKS"), dtrow("SRNO"), dtrow("GUEST"), dtrow("PASSPORT"), dtrow("COUNTRY"), dtrow("SUBDATE"), dtrow("COLDATE"), dtrow("CITY"), dtrow("VISAFEES"), dtrow("VFS"), dtrow("MISC"), dtrow("AMT"), dtrow("SERCHGS"), dtrow("QUERY"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class