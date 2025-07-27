Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class EnquiryDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Dim RPTHOTELGUSETDTLS As New HotelEnquiryGuestWiseDetails
    Dim RPTHOTELGUESTSUMM As New HotelEnquiryGuestWiseSummary
    Dim RPTHOTELWISEDTLS As New HotelEnquiryHotelWiseDetails
    Dim RPTHOTELWISESUMM As New HotelEnquiryHotelWiseSummary
    Dim RPTHOTELBOOKEDBYDTLS As New HotelEnquiryBookedbyDetails
    Dim RPTHOTELBOOKEDBYSUMM As New HotelEnquiryBookedBySummary
    Dim RPTHOTELPENDING As New HotelEnquiryPendingEnquiry
    Dim RPTHOTELCLOSED As New HotelEnquiryClosedEnquiry
    Dim RPTHOTELCONFIRMED As New HotelEnquiryConfirmedEnquiry

    Dim RPTPACKAGEGUSETDTLS As New PackageEnquiryGuestWiseDetails
    Dim RPTPACKAGEGUESTSUMM As New PackageEnquiryGuestWiseSummary
    Dim RPTPACKAGEHOTELDTLS As New PackageEnquiryHotelWiseDetails
    Dim RPTPACKAGEHOTELSUMM As New PackageEnquiryHotelWiseSummary
    Dim RPTPACKAGEBOOKEDBYDTLS As New PackageEnquiryBookedByDetails
    Dim RPTPACKAGEBOOKEDBYSUMM As New PackageEnquiryBookedBySummary
    Dim RPTPACKAGEPENDING As New PackageEnquiryPendingEnquiry
    Dim RPTPACKAGECLOSED As New PackageEnquiryClosedEnquiry
    Dim RPTPACKAGECONFIRMED As New PackageEnquiryConfirmedEnquiry

    Dim RPTVISAGUSETDTLS As New VisaEnquiryGuestWiseDetails
    Dim RPTVISAGUESTSUMM As New VisaEnquiryGuestWiseSummary
    Dim RPTVISAHANDLEDBYDTLS As New VisaEnquiryHandledByDetails
    Dim RPTVISAHANDLEDBYSUMM As New VisaEnquiryHandledBySummary
    Dim RPTVISAPENDING As New VisaEnquiryPendingEnquiry
    Dim RPTVISACLOSED As New VisaEnquiryClosedEnquiry
    Dim RPTVISACONFIRMED As New VisaEnquiryConfirmedEnquiry

    Private Sub EnquiryDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub EnquiryDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

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


            If FRMSTRING = "HOTELGUESTWISEDTLS" Then crTables = RPTHOTELGUSETDTLS.Database.Tables
            If FRMSTRING = "HOTELGUESTWISESUMM" Then crTables = RPTHOTELGUESTSUMM.Database.Tables

            If FRMSTRING = "HOTELWISEDTLS" Then crTables = RPTHOTELWISEDTLS.Database.Tables
            If FRMSTRING = "HOTELWISESUMM" Then crTables = RPTHOTELWISESUMM.Database.Tables

            If FRMSTRING = "HOTELBOOKEDBYDTLS" Then crTables = RPTHOTELBOOKEDBYDTLS.Database.Tables
            If FRMSTRING = "HOTELBOOKEDBYSUMM" Then crTables = RPTHOTELBOOKEDBYSUMM.Database.Tables


            If FRMSTRING = "HOTELPENDINGENQ" Then crTables = RPTHOTELPENDING.Database.Tables
            If FRMSTRING = "HOTELCONFIRMEDENQ" Then crTables = RPTHOTELCONFIRMED.Database.Tables
            If FRMSTRING = "HOTELCLOSEDENQ" Then crTables = RPTHOTELCLOSED.Database.Tables


            If FRMSTRING = "PACKAGEGUESTWISEDTLS" Then crTables = RPTPACKAGEGUSETDTLS.Database.Tables
            If FRMSTRING = "PACKAGEGUESTWISESUMM" Then crTables = RPTPACKAGEGUESTSUMM.Database.Tables

            If FRMSTRING = "PACKAGEHOTELWISEDTLS" Then crTables = RPTPACKAGEHOTELDTLS.Database.Tables
            If FRMSTRING = "PACKAGEHOTELWISESUMM" Then crTables = RPTPACKAGEHOTELSUMM.Database.Tables

            If FRMSTRING = "PACKAGEBOOKEDBYDTLS" Then crTables = RPTPACKAGEBOOKEDBYDTLS.Database.Tables
            If FRMSTRING = "PACKAGEBOOKEDBYSUMM" Then crTables = RPTPACKAGEBOOKEDBYSUMM.Database.Tables

            If FRMSTRING = "PACKAGEPENDINGENQ" Then crTables = RPTPACKAGEPENDING.Database.Tables
            If FRMSTRING = "PACKAGECONFIRMEDENQ" Then crTables = RPTPACKAGECONFIRMED.Database.Tables
            If FRMSTRING = "PACKAGECLOSEDENQ" Then crTables = RPTPACKAGECLOSED.Database.Tables


            If FRMSTRING = "VISAGUESTWISEDTLS" Then crTables = RPTVISAGUSETDTLS.Database.Tables
            If FRMSTRING = "VISAGUESTWISESUMM" Then crTables = RPTVISAGUESTSUMM.Database.Tables

            If FRMSTRING = "VISABOOKEDBYDTLS" Then crTables = RPTVISAHANDLEDBYDTLS.Database.Tables
            If FRMSTRING = "VISABOOKEDBYSUMM" Then crTables = RPTVISAHANDLEDBYSUMM.Database.Tables

            If FRMSTRING = "VISAPENDINGENQ" Then crTables = RPTVISAPENDING.Database.Tables
            If FRMSTRING = "VISACONFIRMEDENQ" Then crTables = RPTVISACONFIRMED.Database.Tables
            If FRMSTRING = "VISACLOSEDENQ" Then crTables = RPTVISACLOSED.Database.Tables

            'If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "HOTELGUESTWISEDTLS" Then
                crpo.ReportSource = RPTHOTELGUSETDTLS
                RPTHOTELGUSETDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "HOTELGUESTWISESUMM" Then
                crpo.ReportSource = RPTHOTELGUESTSUMM
                RPTHOTELGUESTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
               
            ElseIf FRMSTRING = "HOTELWISEDTLS" Then
                crpo.ReportSource = RPTHOTELWISEDTLS
                RPTHOTELWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
             
            ElseIf FRMSTRING = "HOTELWISESUMM" Then
                crpo.ReportSource = RPTHOTELWISESUMM
                RPTHOTELWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "HOTELBOOKEDBYDTLS" Then
                crpo.ReportSource = RPTHOTELBOOKEDBYDTLS
                RPTHOTELBOOKEDBYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "HOTELBOOKEDBYSUMM" Then
                crpo.ReportSource = RPTHOTELBOOKEDBYSUMM
                RPTHOTELBOOKEDBYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
               
            ElseIf FRMSTRING = "HOTELPENDINGENQ" Then
                crpo.ReportSource = RPTHOTELPENDING
                RPTHOTELPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
               
            ElseIf FRMSTRING = "HOTELCONFIRMEDENQ" Then
                crpo.ReportSource = RPTHOTELCONFIRMED
                RPTHOTELCONFIRMED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "HOTELCLOSEDENQ" Then
                crpo.ReportSource = RPTHOTELCLOSED
                RPTHOTELCLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
             
            ElseIf FRMSTRING = "PACKAGEGUESTWISEDTLS" Then
                crpo.ReportSource = RPTPACKAGEGUSETDTLS
                RPTPACKAGEGUSETDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
               
            ElseIf FRMSTRING = "PACKAGEGUESTWISESUMM" Then
                crpo.ReportSource = RPTPACKAGEGUESTSUMM
                RPTPACKAGEGUESTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
              
            ElseIf FRMSTRING = "PACKAGEHOTELWISEDTLS" Then
                crpo.ReportSource = RPTPACKAGEHOTELDTLS
                RPTPACKAGEHOTELDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "PACKAGEHOTELWISESUMM" Then
                crpo.ReportSource = RPTPACKAGEHOTELSUMM
                RPTPACKAGEHOTELSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "PACKAGEBOOKEDBYDTLS" Then
                crpo.ReportSource = RPTPACKAGEBOOKEDBYDTLS
                RPTPACKAGEBOOKEDBYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "PACKAGEBOOKEDBYSUMM" Then
                crpo.ReportSource = RPTPACKAGEBOOKEDBYSUMM
                RPTPACKAGEBOOKEDBYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

               
            ElseIf FRMSTRING = "PACKAGEPENDINGENQ" Then
                crpo.ReportSource = RPTPACKAGEPENDING
                RPTPACKAGEPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "PACKAGECONFIRMEDENQ" Then
                crpo.ReportSource = RPTPACKAGECONFIRMED
                RPTPACKAGECONFIRMED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "PACKAGECLOSEDENQ" Then
                crpo.ReportSource = RPTPACKAGECLOSED
                RPTPACKAGECLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "VISAGUESTWISEDTLS" Then
                crpo.ReportSource = RPTVISAGUSETDTLS
                RPTVISAGUSETDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "VISAGUESTWISESUMM" Then
                crpo.ReportSource = RPTVISAGUESTSUMM
                RPTVISAGUESTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

      
            ElseIf FRMSTRING = "VISABOOKEDBYDTLS" Then
                crpo.ReportSource = RPTVISAHANDLEDBYDTLS
                RPTVISAHANDLEDBYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "VISABOOKEDBYSUMM" Then
                crpo.ReportSource = RPTVISAHANDLEDBYSUMM
                RPTVISAHANDLEDBYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "VISAPENDINGENQ" Then
                crpo.ReportSource = RPTVISAPENDING
                RPTVISAPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "VISACONFIRMEDENQ" Then
                crpo.ReportSource = RPTVISACONFIRMED
                RPTVISACONFIRMED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "VISACLOSEDENQ" Then
                crpo.ReportSource = RPTVISACLOSED
                RPTVISACLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                        
            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub


    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\ENQUIRY.pdf"

            If FRMSTRING = "HOTELGUESTWISEDTLS" Then
                expo = RPTHOTELGUSETDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELGUSETDTLS.Export()
            ElseIf FRMSTRING = "HOTELGUESTWISESUMM" Then
                expo = RPTHOTELGUESTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELGUESTSUMM.Export()
            ElseIf FRMSTRING = "HOTELWISEDTLS" Then
                expo = RPTHOTELWISEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELWISEDTLS.Export()
            ElseIf FRMSTRING = "HOTELWISESUMM" Then
                expo = RPTHOTELWISESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELWISESUMM.Export()
            ElseIf FRMSTRING = "HOTELBOOKEDBYDTLS" Then
                expo = RPTHOTELBOOKEDBYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELBOOKEDBYDTLS.Export()
            ElseIf FRMSTRING = "HOTELBOOKEDBYSUMM" Then
                expo = RPTHOTELBOOKEDBYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELBOOKEDBYSUMM.Export()
            ElseIf FRMSTRING = "HOTELPENDINGENQ" Then
                expo = RPTHOTELPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELPENDING.Export()
            ElseIf FRMSTRING = "HOTELCONFIRMEDENQ" Then
                expo = RPTHOTELCONFIRMED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELCONFIRMED.Export()
            ElseIf FRMSTRING = "HOTELCLOSEDENQ" Then
                expo = RPTHOTELCLOSED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTHOTELCLOSED.Export()
            ElseIf FRMSTRING = "PACKAGEGUESTWISEDTLS" Then
                expo = RPTPACKAGEGUSETDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEGUSETDTLS.Export()
            ElseIf FRMSTRING = "PACKAGEGUESTWISESUMM" Then
                expo = RPTPACKAGEGUESTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEGUESTSUMM.Export()
            ElseIf FRMSTRING = "PACKAGEHOTELWISEDTLS" Then
                expo = RPTPACKAGEHOTELDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEHOTELDTLS.Export()
            ElseIf FRMSTRING = "PACKAGEHOTELWISESUMM" Then
                expo = RPTPACKAGEHOTELSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEHOTELSUMM.Export()
            ElseIf FRMSTRING = "PACKAGEBOOKEDBYDTLS" Then
                expo = RPTPACKAGEBOOKEDBYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEBOOKEDBYDTLS.Export()
            ElseIf FRMSTRING = "PACKAGEBOOKEDBYSUMM" Then
                expo = RPTPACKAGEBOOKEDBYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEBOOKEDBYSUMM.Export()
            ElseIf FRMSTRING = "PACKAGEPENDINGENQ" Then
                expo = RPTPACKAGEPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGEPENDING.Export()
            ElseIf FRMSTRING = "PACKAGECONFIRMEDENQ" Then
                expo = RPTPACKAGECONFIRMED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGECONFIRMED.Export()
            ElseIf FRMSTRING = "PACKAGECLOSEDENQ" Then
                expo = RPTPACKAGECLOSED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPACKAGECLOSED.Export()
            ElseIf FRMSTRING = "VISAGUESTWISEDTLS" Then
                expo = RPTVISAGUSETDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISAGUSETDTLS.Export()
            ElseIf FRMSTRING = "VISAGUESTWISESUMM" Then
                expo = RPTVISAGUESTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISAGUESTSUMM.Export()
            ElseIf FRMSTRING = "VISABOOKEDBYDTLS" Then
                expo = RPTVISAHANDLEDBYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISAHANDLEDBYDTLS.Export()
            ElseIf FRMSTRING = "VISABOOKEDBYSUMM" Then
                expo = RPTVISAHANDLEDBYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISAHANDLEDBYSUMM.Export()
            ElseIf FRMSTRING = "VISAPENDINGENQ" Then
                expo = RPTVISAPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISAPENDING.Export()
            ElseIf FRMSTRING = "VISACONFIRMEDENQ" Then
                expo = RPTVISACONFIRMED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISACONFIRMED.Export()
            ElseIf FRMSTRING = "VISACLOSEDENQ" Then
                expo = RPTVISACLOSED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVISACLOSED.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub sendmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmail.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()

            Dim TEMPATTACHMENT As String = Application.StartupPath & "\Enquiry Details.pdf"
            Dim objmail As New SendMail
            objmail.attachment = TEMPATTACHMENT
            objmail.subject = "Enquiry Details"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

 
End Class