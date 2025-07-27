
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ItineraryDesign

    Public TEMP As String
    Public SUBJECT As String
    Public strsearch As String
    Public FRMSTRING As String
    Public ITINERARYNO As Integer

    Dim RPTITINERARY_KHANNA As New Itinerary_KHANNA
    'Dim RPTITINERARY_AIRTRINITY As New Itinerary_AIRTRINITY
    'Dim RPTITINERARY_TNL As New Itinerary_TNL
    Dim RPTITINERARY_REPORT As New Itinerary_REPORT
    Dim RPTITINERARY_VIHAR As New Itinerary_VIHAR

    Private Sub ItineraryDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarBookingVoucherDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "ITINERARY" Then
                Me.Text = "Itinerary Details"
                If ClientName = "KHANNA" Then
                    crTables = RPTITINERARY_KHANNA.Database.Tables
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    crTables = RPTITINERARY_AIRTRINITY.Database.Tables
                    'ElseIf ClientName = "TNL" Then
                    '    crTables = RPTITINERARY_TNL.Database.Tables
                ElseIf ClientName = "VIHAR" Then
                    crTables = RPTITINERARY_VIHAR.Database.Tables
                Else
                    crTables = RPTITINERARY_REPORT.Database.Tables
                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            strsearch = strsearch & " {ITINERARYMASTER.ITINERARY_NO} = " & ITINERARYNO & " AND {ITINERARYMASTER.ITINERARY_YEARID} = " & YearId

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "ITINERARY" Then
                If ClientName = "KHANNA" Then
                    CRPO.ReportSource = RPTITINERARY_KHANNA
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    CRPO.ReportSource = RPTITINERARY_AIRTRINITY
                    '    Dim LOGO As BlobFieldObject = DirectCast(RPTITINERARY_AIRTRINITY.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    '    LOGO.Height = 1353.6
                    '    LOGO.Width = 3182.4
                    'ElseIf ClientName = "TNL" Then
                    '    CRPO.ReportSource = RPTITINERARY_TNL
                    '    Dim LOGO As BlobFieldObject = DirectCast(RPTITINERARY_TNL.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    '    LOGO.Height = 1353.6
                    '    LOGO.Width = 3182.4

                ElseIf ClientName = "VIHAR" Then
                    CRPO.ReportSource = RPTITINERARY_VIHAR
                Else
                    CRPO.ReportSource = RPTITINERARY_REPORT
                    'TRY INCH TO TWIP CONVERTOR FOR INCHES TO TWIPS
                    Dim LOGO As BlobFieldObject = DirectCast(RPTITINERARY_REPORT.Section2.ReportObjects("LOGO"), BlobFieldObject)
                    If ClientName = "AERO" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "APPLE" Then
                        LOGO.Height = 1036.8
                        LOGO.Width = 3182.4
                    ElseIf ClientName = "WAHWAH" Then
                        LOGO.Height = 719.2
                        LOGO.Width = 3339.2
                        RPTITINERARY_REPORT.ReportDefinition.ReportObjects.Item("SERVICEHEADER").ObjectFormat.EnableSuppress = False
                    ElseIf ClientName = "TRAVCON" Then
                        RPTITINERARY_REPORT.Section2.ReportObjects("LOGO").ObjectFormat.EnableSuppress = True
                        RPTITINERARY_REPORT.Section2.ReportObjects("LOGOARCH").ObjectFormat.EnableSuppress = False
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

        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\Itinerary No. " & ITINERARYNO & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
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

            If FRMSTRING = "ITINERARY" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Itinerary No. " & ITINERARYNO & ".PDF"
                If ClientName = "KHANNA" Then
                    expo = RPTITINERARY_KHANNA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTITINERARY_KHANNA.Export()
                    'ElseIf ClientName = "AIRTRINITY" Then
                    '    expo = RPTITINERARY_AIRTRINITY.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTITINERARY_AIRTRINITY.Export()
                    'ElseIf ClientName = "TNL" Then
                    '    expo = RPTITINERARY_TNL.ExportOptions
                    '    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    '    expo.DestinationOptions = oDfDopt
                    '    RPTITINERARY_TNL.Export()
                ElseIf ClientName = "VIHAR" Then
                    expo = RPTITINERARY_VIHAR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTITINERARY_VIHAR.Export()
                Else
                    expo = RPTITINERARY_REPORT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTITINERARY_REPORT.Export()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class