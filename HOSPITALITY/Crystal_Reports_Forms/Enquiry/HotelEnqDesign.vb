
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class HotelEnqDesign

    ' Dim RPTENQ_TOPCOMM As New HotelEnqReport_TOPCOMM
    ' Dim RPTHOTELRATE_TOPCOMM As New HotelRateConfirmation_TOPCOMM
    Dim RPTHOTELENQINV_SSR As New HotelEnquiryInvoice_SSR
    Dim RPTHOTELRATE_SSR As New HotelRateConfirmation_SSR

    Dim RPTHOTELRATE As New HotelRateConfirmationReport
    Dim RPTHOTELQUOTE As New HotelQuoteReport

    Public strsearch As String
    Public FRMSTRING As String
    Public ENQNO As Integer
    Public HIDEAMT As Boolean
    Public SUBJECT As String = ""
    Public GUESTNAME As String = ""

    Private Sub HotelEnqDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With


            If FRMSTRING = "HOTELRATE" Then
                'If ClientName = "TOPCOMM" Then
                '    crTables = RPTHOTELRATE_TOPCOMM.Database.Tables
                If ClientName = "SSR" Then
                    crTables = RPTHOTELRATE_SSR.Database.Tables
                Else
                    crTables = RPTHOTELRATE.Database.Tables
                End If

            Else
                'If ClientName = "TOPCOMM" Then
                '    crTables = RPTENQ_TOPCOMM.Database.Tables
                If ClientName = "SSR" Then
                    crTables = RPTHOTELENQINV_SSR.Database.Tables
                Else
                    crTables = RPTHOTELQUOTE.Database.Tables
                End If
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            strsearch = strsearch & " {HOTELENQMASTER.ENQ_NO}= " & ENQNO & " and {HOTELENQMASTER.ENQ_yearid}=" & YearId
            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "HOTELRATE" Then
                If ClientName = "TOPCOMM" Then
                    'CRPO.ReportSource = RPTHOTELRATE_TOPCOMM
                ElseIf FRMSTRING = "SSR" Then
                    CRPO.ReportSource = RPTHOTELRATE_SSR
                Else
                    CRPO.ReportSource = RPTHOTELRATE
                    Dim LOGO As BlobFieldObject = DirectCast(RPTHOTELRATE.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    If ClientName = "AERO" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "APPLE" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "WAHWAH" Then
                        LOGO.Height = 719.2
                        LOGO.Width = 3339.2
                        RPTHOTELQUOTE.ReportDefinition.ReportObjects.Item("SERVICEHEADER").ObjectFormat.EnableSuppress = False
                    ElseIf ClientName = "TRAVCON" Then
                        RPTHOTELRATE.Section2.ReportObjects("LOGO").ObjectFormat.EnableSuppress = True
                        RPTHOTELRATE.Section2.ReportObjects("LOGOARCH").ObjectFormat.EnableSuppress = False
                    ElseIf ClientName = "KHANNA" Then
                        RPTHOTELRATE.Section2.ReportObjects("LOGO").ObjectFormat.EnableSuppress = True
                        RPTHOTELRATE.Section2.ReportObjects("LOGOKHANNA").ObjectFormat.EnableSuppress = False
                        RPTHOTELRATE.Section5.ReportObjects("FOOTERTEXT").ObjectFormat.EnableSuppress = True
                        RPTHOTELRATE.Section5.ReportObjects("FOOTERKHANNA").ObjectFormat.EnableSuppress = False
                    Else
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    End If
                End If

            Else
                If ClientName = "TOPCOMM" Then
                    'CRPO.ReportSource = RPTENQ_TOPCOMM
                ElseIf ClientName = "SSR" Then
                    CRPO.ReportSource = RPTHOTELENQINV_SSR
                Else
                    CRPO.ReportSource = RPTHOTELQUOTE
                    Dim LOGO As BlobFieldObject = DirectCast(RPTHOTELQUOTE.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    If ClientName = "AERO" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "APPLE" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "WAHWAH" Then
                        LOGO.Height = 719.2
                        LOGO.Width = 3339.2
                        RPTHOTELQUOTE.ReportDefinition.ReportObjects.Item("SERVICEHEADER").ObjectFormat.EnableSuppress = False
                    ElseIf ClientName = "KHANNA" Then
                        RPTHOTELQUOTE.Section2.ReportObjects("LOGO").ObjectFormat.EnableSuppress = True
                        RPTHOTELQUOTE.Section2.ReportObjects("LOGOKHANNA").ObjectFormat.EnableSuppress = False
                        RPTHOTELQUOTE.Section5.ReportObjects("FOOTERTEXT").ObjectFormat.EnableSuppress = True
                        RPTHOTELQUOTE.Section5.ReportObjects("FOOTERKHANNA").ObjectFormat.EnableSuppress = False
                    Else
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    End If
                End If
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        If FRMSTRING = "HOTELRATE" Then
            tempattachment = "Rate Confirmation"
        Else
            If SUBJECT = "" Then
                tempattachment = "Enquiry No. " & ENQNO
            Else
                tempattachment = SUBJECT
            End If
        End If


        If FRMSTRING = "HOTELRATE" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" HOTELMASTER.HOTEL_EMAILID AS EMAILID", "", "  HOTELENQMASTER INNER JOIN HOTELMASTER ON HOTELENQMASTER.ENQ_HOTELID = HOTELMASTER.HOTEL_ID AND HOTELENQMASTER.ENQ_CMPID = HOTELMASTER.HOTEL_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = HOTELMASTER.HOTEL_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = HOTELMASTER.HOTEL_YEARID ", " AND ENQ_NO = " & ENQNO & " AND ENQ_CMPID = " & CmpId & " AND ENQ_LOCATIONID = " & Locationid & " AND ENQ_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then emailid = DT.Rows(0).Item("EMAILID")
        Else
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" GUESTMASTER.GUEST_EMAIL AS EMAILID", "", "  HOTELENQMASTER INNER JOIN GUESTMASTER ON HOTELENQMASTER.ENQ_GUESTID = GUESTMASTER.GUEST_ID AND HOTELENQMASTER.ENQ_CMPID = GUESTMASTER.GUEST_CMPID AND HOTELENQMASTER.ENQ_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND HOTELENQMASTER.ENQ_YEARID = GUESTMASTER.GUEST_YEARID ", " AND ENQ_NO = " & ENQNO & " AND ENQ_CMPID = " & CmpId & " AND ENQ_LOCATIONID = " & Locationid & " AND ENQ_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then emailid = DT.Rows(0).Item("EMAILID")
        End If


        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If SUBJECT = "" Then
                objmail.subject = tempattachment
            Else
                objmail.subject = SUBJECT
            End If
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.GUESTNAME = GUESTNAME
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "HOTELRATE" Then
                If ClientName = "TOPCOMM" Then
                    'oDfDopt.DiskFileName = Application.StartupPath & "\Rate Confirmation.PDF"
                    'expo = RPTHOTELRATE_TOPCOMM.ExportOptions
                    'expo.ExportDestinationType = ExportDestinationType.DiskFile
                    'expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    'expo.DestinationOptions = oDfDopt
                    'RPTHOTELRATE_TOPCOMM.Export()
                ElseIf ClientName = "SSR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Rate Confirmation.PDF"
                    expo = RPTHOTELRATE_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTHOTELRATE_SSR.Export()
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\Rate Confirmation.PDF"
                    expo = RPTHOTELRATE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTHOTELRATE.Export()
                End If
            Else

                If SUBJECT = "" Then oDfDopt.DiskFileName = Application.StartupPath & "\Enquiry No. " & ENQNO & ".PDF" Else oDfDopt.DiskFileName = Application.StartupPath & "\" & SUBJECT & ".PDF"

                If ClientName = "TOPCOMM" Then
                    'expo = RPTENQ_TOPCOMM.ExportOptions
                    'expo.ExportDestinationType = ExportDestinationType.DiskFile
                    'expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    'expo.DestinationOptions = oDfDopt
                    'RPTENQ_TOPCOMM.Export()

                ElseIf ClientName = "SSR" Then
                    expo = RPTHOTELENQINV_SSR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTHOTELENQINV_SSR.Export()

                Else
                    expo = RPTHOTELQUOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTHOTELQUOTE.Export()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class