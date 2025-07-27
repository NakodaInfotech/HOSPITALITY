
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class CrDrNoteDesign

    Public BILLNO As Integer
    Public REGNAME As String
    Public FRMSTRING As String
    Dim OBJCRNOTE As New CreditNoteReport
    Dim OBJCRNOTESHREEJI As New CreditNoteReport_SHREEJI
    Dim OBJDRNOTE As New DebitNoteReport
    Dim OBJACRNOTE As New AirCreditNoteReport
    Dim OBJACRNOTE_AERO As New AirCreditNoteReport_AERO
    Dim OBJADRNOTE As New AirDebitNoteReport
    Public printst As Boolean
    Public printot As Boolean

    Private Sub CrDrNoteDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table

            'RPTINVOICE_AKS.DataDefinition.FormulaFields("SENDMAIL").Text = 1
            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "CREDIT" Then
                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    crTables = OBJCRNOTESHREEJI.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If

                    crTables = OBJCRNOTE.Database.Tables
                End If
            ElseIf FRMSTRING = "DEBIT" Then
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                crTables = OBJDRNOTE.Database.Tables
            ElseIf FRMSTRING = "AIRCREDIT" Then
                If ClientName = "AERO" Then
                    crTables = OBJACRNOTE_AERO.Database.Tables
                Else
                    If ClientName = "ROYALHOLIDAYS" Then
                        OBJACRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    End If
                    crTables = OBJACRNOTE.Database.Tables
                End If
            ElseIf FRMSTRING = "AIRDEBIT" Then
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJADRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                crTables = OBJADRNOTE.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CREDIT" Then
                strsearch = strsearch & "  {CREDITNOTEMASTER.CN_NO}= " & BILLNO & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {CREDITNOTEMASTER.CN_CMPID} = " & CmpId & " and {CREDITNOTEMASTER.CN_LOCATIONID} = " & Locationid & " and {CREDITNOTEMASTER.CN_YEARID} = " & YearId
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                CRPO.SelectionFormula = strsearch
                If ClientName = "SHREEJI" Or ClientName = "BARODA" Then
                    OBJCRNOTESHREEJI.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    CRPO.ReportSource = OBJCRNOTESHREEJI
                Else
                    OBJCRNOTE.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    CRPO.ReportSource = OBJCRNOTE
                End If

            ElseIf FRMSTRING = "DEBIT" Then
                strsearch = strsearch & "  {DEBITNOTEMASTER.DN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {DEBITNOTEMASTER.DN_CMPID} = " & CmpId & " and {DEBITNOTEMASTER.DN_LOCATIONID} = " & Locationid & " and {DEBITNOTEMASTER.DN_YEARID} = " & YearId
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                CRPO.SelectionFormula = strsearch
                OBJDRNOTE.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                CRPO.ReportSource = OBJDRNOTE
            ElseIf FRMSTRING = "AIRCREDIT" Then

                strsearch = strsearch & "  {AIRCREDITNOTEMASTER.AIRCN_NO}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {AIRCREDITNOTEMASTER.AIRCN_CMPID} = " & CmpId & " and {AIRCREDITNOTEMASTER.AIRCN_LOCATIONID} = " & Locationid & " and {AIRCREDITNOTEMASTER.AIRCN_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJACRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If

                If ClientName = "AERO" Then
                    OBJACRNOTE_AERO.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    CRPO.ReportSource = OBJACRNOTE_AERO
                    If printst = True Then
                        OBJACRNOTE_AERO.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        OBJACRNOTE_AERO.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If printot = True Then
                        OBJACRNOTE_AERO.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        OBJACRNOTE_AERO.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If
                Else
                    OBJACRNOTE.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                    CRPO.ReportSource = OBJACRNOTE
                    If printst = True Then
                        OBJACRNOTE.DataDefinition.FormulaFields("PRINTST").Text = 1
                    Else
                        OBJACRNOTE.DataDefinition.FormulaFields("PRINTST").Text = 0
                    End If
                    If printot = True Then
                        OBJACRNOTE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 1
                    Else
                        OBJACRNOTE.DataDefinition.FormulaFields("PRINTOTHERCHGS").Text = 0
                    End If
                End If

            ElseIf FRMSTRING = "AIRDEBIT" Then
                strsearch = strsearch & "  {AIRDEBITNOTEMASTER.AIRDN_no}= " & BILLNO & " AND {REGISTERMASTER.REGISTER_NAME}= '" & REGNAME & "' AND {AIRDEBITNOTEMASTER.AIRDN_CMPID} = " & CmpId & " and {AIRDEBITNOTEMASTER.AIRDN_LOCATIONID} = " & Locationid & " and {AIRDEBITNOTEMASTER.AIRDN_YEARID} = " & YearId
                If ClientName = "ROYALHOLIDAYS" Then
                    OBJADRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                End If
                CRPO.SelectionFormula = strsearch
                OBJADRNOTE.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                CRPO.ReportSource = OBJADRNOTE
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
        If FRMSTRING = "CREDIT" Then
            tempattachment = "CREDIT NOTE"
        ElseIf FRMSTRING = "AIRCREDIT" Then
            tempattachment = "AIR CREDIT NOTE"
        ElseIf FRMSTRING = "DEBIT" Then
            tempattachment = "DEBIT NOTE"
        ElseIf FRMSTRING = "AIRDEBIT" Then
            tempattachment = "AIR DEBIT NOTE"
        End If
        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.subject = tempattachment
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

            If FRMSTRING = "CREDIT" Then
                If ClientName = "KHANNA" Then OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\CREDIT NOTE.PDF"
                expo = OBJCRNOTE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                OBJCRNOTE.Export()
            ElseIf FRMSTRING = "DEBIT" Then
                If ClientName = "KHANNA" Then OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\DEBIT NOTE.PDF"
                expo = OBJDRNOTE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJDRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                OBJDRNOTE.Export()
            ElseIf FRMSTRING = "AIRCREDIT" Then

                oDfDopt.DiskFileName = Application.StartupPath & "\AIR CREDIT NOTE.PDF"
                If ClientName = "AERO" Or ClientName = "KHANNA" Then
                    expo = OBJACRNOTE_AERO.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJACRNOTE_AERO.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    OBJACRNOTE_AERO.Export()
                Else
                    If ClientName = "KHANNA" Then OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    expo = OBJACRNOTE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    OBJACRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                    OBJACRNOTE.Export()
                End If

            ElseIf FRMSTRING = "AIRDEBIT" Then
                If ClientName = "KHANNA" Then OBJCRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                oDfDopt.DiskFileName = Application.StartupPath & "\AIR DEBIT NOTE.PDF"
                expo = OBJADRNOTE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJADRNOTE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                OBJADRNOTE.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class