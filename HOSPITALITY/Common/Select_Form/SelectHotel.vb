
Imports BL

Public Class SelectHotel
    Public TEMPHOTELNAME, TEMPHOTELCODE As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SelectHotel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SelectHotel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  HOTELMASTER.HOTEL_NAME AS HOTELNAME, HOTELMASTER.HOTEL_CODE AS HOTELCODE, GROUPOFHOTELSMASTER.GROUPOFHOTELS_NAME AS GROUPOFHOTELS, ISNULL(HOTELTYPEMASTER.HOTELTYPE_NAME, '') AS HOTELTYPE, CITYMASTER.city_name AS CITYNAME, HOTELTYPEMASTER.HOTELTYPE_ID, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(HOTELMASTER.HOTEL_EMAILID, '') AS EMAIL", "", "  HOTELMASTER LEFT OUTER JOIN STATEMASTER ON HOTELMASTER.HOTEL_STATEID = STATEMASTER.state_id LEFT OUTER JOIN HOTELTYPEMASTER ON HOTELMASTER.HOTEL_YEARID = HOTELTYPEMASTER.HOTELTYPE_YEARID AND HOTELMASTER.HOTEL_TYPEID = HOTELTYPEMASTER.HOTELTYPE_ID LEFT OUTER JOIN GROUPOFHOTELSMASTER ON HOTELMASTER.HOTEL_HOTELGROUPID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_ID AND HOTELMASTER.HOTEL_CMPID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = GROUPOFHOTELSMASTER.GROUPOFHOTELS_YEARID LEFT OUTER JOIN CITYMASTER ON HOTELMASTER.HOTEL_CITYID = CITYMASTER.city_id AND HOTELMASTER.HOTEL_CMPID = CITYMASTER.city_cmpid AND HOTELMASTER.HOTEL_LOCATIONID = CITYMASTER.city_locationid AND HOTELMASTER.HOTEL_YEARID = CITYMASTER.city_yearid", " AND ISNULL(HOTEL_BLOCKED,0) = 'FALSE' AND HOTEL_YEARID = " & YearId & " ORDER BY HOTEL_NAME")
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            TEMPHOTELCODE = gridbill.GetFocusedRowCellValue("HOTELCODE")
            TEMPHOTELNAME = gridbill.GetFocusedRowCellValue("HOTELNAME")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class