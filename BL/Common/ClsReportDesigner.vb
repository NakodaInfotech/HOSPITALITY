
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data
Imports AccountingBL
Imports System.IO

Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try

                Dim workbook As String = SaveFilePath
                If FileIO.FileSystem.FileExists(SaveFilePath) = True Then Interaction.GetObject(workbook).close(False)
                GC.Collect()
                'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                '    proc.Kill()
                'Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheetGST(Optional ByVal SHEETNAME As String = "")
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                If System.IO.File.Exists(_SaveFilePath) = True Then
                    objBook = objExcel.Workbooks.Open(_SaveFilePath)
                    objSheet = objBook.Sheets.Add()
                Else
                    objBook = objExcel.Workbooks.Add
                    objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
                End If
                If SHEETNAME <> "" Then objSheet.Name = SHEETNAME
            End If
            If SHEETNAME = "B2B" Then _PreviewOption = 2 Else _PreviewOption = 3
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SaveAndCloseGST()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False

            'Dim WB As String = _SaveFilePath
            'If System.IO.File.Exists(_SaveFilePath) = True Then
            '    objBook.Worksheets.Add(objSheet)

            '    Interaction.GetObject(WB).close(False)
            '    GC.Collect()
            'End If
            objSheet.SaveAs(_SaveFilePath)

            'If _PreviewOption = 1 Then 'Open In Web Browser                
            '    objBook.WebPagePreview()
            If _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
                ReleaseObject(objBook)
                ReleaseObject(objExcel)
            Else
                Quit()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String)
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "BANKRECO"

    Public Function BANKRECO(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DT As System.Data.DataTable = OBJRECO.GETDATA()
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Reconciliation Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Booking No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Reco Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Ledger Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                'AS PER JEETU
                'GET ALL DEBIT AMOUNT RECOED
                'I = 0
                'RowIndex += 1
                'Write("Chques Deposited and Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next

                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))



                'AS PER JEETU
                'GET ALL CREDIT AMOUNT
                'I = 0
                'RowIndex += 2
                'Write("Chques Issused and Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next


                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))




                'GET ALL DEBIT AMOUNT
                I = 0
                RowIndex += 1
                Write("Chques Deposited but not Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                   
                    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))



                'GET ALL CREDIT AMOUNT
                I = 0
                RowIndex += 2
                Write("Chques Issused but not Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function BANKSTATEMENT(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0
            Dim BALANCE As Double = 0

            Dim DT As System.Data.DataTable = OBJCMN.search("DISTINCT RecoDate AS RECODATE, acc_initials AS BILLINITIALS, AGAINST AS NAME, ChqNo AS CHQNO, dr AS DR, cr AS CR", "", " BANKRECO", " AND BANKRECO.NAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " AND CAST(RECODATE AS DATE) >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(RECODATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "'  ORDER BY RECODATE")


            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Booking No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Bank Pass Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                BALANCE = Val(DTTOTAL.Rows(0).Item("BOOKBAL"))


                'GET ALL DEBIT AMOUNT
                I = 0
                Dim RDATE As Date = Now.Date
                Dim FROW As Boolean = True
                Dim FROMNO As Integer = 0
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    I += 1
                    RowIndex += 1
                    'GET REOCDATE ONLY ONCE
                    If RDATE <> DTROW("RECODATE") Then
                        If FROW = False Then
                            RowIndex += 1
                            Write(DTROW("RECODATE"), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & FROMNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & FROMNO & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)

                            'SET BALANCE
                            BALANCE = (BALANCE + Val(objSheet.Range(Range("7"), Range("7")).Text)) - Val(objSheet.Range(Range("6"), Range("6")).Text)

                            Write(Format(BALANCE, "0.00"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                            SetBorder(RowIndex, Range("1"), Range("8"))
                        End If

                        RowIndex += 2
                        Write(DTROW("RECODATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        RDATE = DTROW("RECODATE")
                        'GET TOTAL OF THE PARTICULAR DATE IF NOT FIRST ROW

                        FROMNO = RowIndex
                    End If
                    Write(DTROW("BILLINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    FROW = False
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))




                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "INVOICE SUMMARY REPORT"

    Public Function INVOICE_SUMMARY_EXCEL(ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_DATE AS DATE, CUSTOMERMASTER.Customer_cmpname AS NAME, INVOICEMASTER.INVOICE_ORDERNO AS PONO, INVOICEMASTER.INVOICE_ORDERDATE AS PODATE, SUM(INVOICEMASTER_DESC.INVOICE_QTY) AS TOTALSETS, INVOICEMASTER.INVOICE_GRANDTOTAL AS TOTALAMT, (CASE WHEN SUM(INVOICE_QTY) < SALEORDER.SO_TOTALQTY THEN 'PENDING' ELSE 'COMPLETED' END) AS STATUS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_INITIALS = INVOICEMASTER.INVOICE_INITIALS AND INVOICEMASTER_DESC.INVOICE_CMPID = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_DESC.INVOICE_LOCATIONID = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN CUSTOMERMASTER ON INVOICEMASTER.INVOICE_LEDGERID = CUSTOMERMASTER.Customer_id AND INVOICEMASTER.INVOICE_CMPID = CUSTOMERMASTER.Customer_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = CUSTOMERMASTER.Customer_locationid AND INVOICEMASTER.INVOICE_YEARID = CUSTOMERMASTER.Customer_yearid INNER JOIN CMPMASTER ON INVOICEMASTER.INVOICE_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN SALEORDER ON INVOICEMASTER.INVOICE_YEARID = SALEORDER.so_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = SALEORDER.so_locationid AND INVOICEMASTER.INVOICE_CMPID = SALEORDER.so_cmpid AND INVOICEMASTER.INVOICE_ORDERNO = SALEORDER.so_pono", CONDITION & " GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_DATE, CUSTOMERMASTER.Customer_cmpname, INVOICEMASTER.INVOICE_ORDERNO, INVOICEMASTER.INVOICE_ORDERDATE, INVOICEMASTER.INVOICE_GRANDTOTAL, SALEORDER.so_totalqty, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, CMPMASTER.cmp_invinitials")

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("H1", 15)
            SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD1
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD2
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            RowIndex += 1
            Write("INVOICE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("25"))


            RowIndex += 2
            Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Customer", Range("5"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            Write("PO No", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PO Date", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            Write("Total Sets", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            Write("Total Amt", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Transport Name", Range("17"), XlHAlign.xlHAlignCenter, Range("19"), True, 10)
            Write("LR No", Range("20"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            Write("LR Date", Range("22"), XlHAlign.xlHAlignCenter, Range("23"), True, 10)
            Write("Status", Range("24"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)

            SetBorder(RowIndex, Range("1"), Range("25"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("INVOICENO"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), False, 10)
                Write(dr("DATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("NAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                Write(dr("PONO"), Range("8"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PODATE"), Range("11"), XlHAlign.xlHAlignLeft, Range("12"), False, 10)
                Write(dr("TOTALSETS"), Range("13"), XlHAlign.xlHAlignRight, Range("14"), False, 10)
                Write(dr("TOTALAMT"), Range("15"), XlHAlign.xlHAlignRight, Range("16"), False, 10)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - DT.Rows.Count, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - DT.Rows.Count, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - DT.Rows.Count, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - DT.Rows.Count, Range("21"))
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex - DT.Rows.Count, Range("23"))
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex - DT.Rows.Count, Range("25"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            RowIndex += 1
            Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("25").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX DETAILS REPORT"

    Public Function SALES_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            ''**BEFORE       'Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_TAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID  FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_BOOKTYPE = 'BOOKING' AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TOTALSALEAMT AS NETT, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILL, 'PACKAGE' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, INTERNATIONALBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER.BOOKING_TAX AS TAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILL, 'INTERNATIONAL' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' union all SELECT CN_initials AS BILLNO, CN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (CN_GTOTAL * (-1)) AS GRANDTOTAL, (CN_TOTALAMT * (-1)) AS NETT  , (CN_SUBTOTAL * (-1)) AS SUBTOTAL,	CN_TAXID AS TAXID, (CN_TAX * (-1)) AS TAXAMT, CN_ADDTAXID AS ADDTAXID, (CN_ADDTAX  * (-1)) AS ADDTAXAMT, (CN_OTHERCHGS * (-1)) AS OTHERCHGS, (CN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, CN_no AS BILL, 'CREDITNOTE' AS TYPE, CN_cmpid AS CMPID, CN_locationid AS LOCATIONID, CN_yearid AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = CN_LEDGERID AND Acc_cmpid =  CN_cmpid AND Acc_locationid = CN_locationid AND Acc_yearid = CN_yearid INNER JOIN CMPMASTER ON CN_cmpid = cmp_id ) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_TAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID  FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id WHERE BOOKING_BOOKTYPE = 'BOOKING' AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TOTALSALEAMT AS NETT, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILL, 'PACKAGE' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, INTERNATIONALBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER.BOOKING_TAX AS TAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILL, 'INTERNATIONAL' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT CN_initials AS BILLNO, CN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (CN_GTOTAL * (-1)) AS GRANDTOTAL, (CN_TOTALAMT * (-1)) AS NETT  , (CN_SUBTOTAL * (-1)) AS SUBTOTAL,	CN_TAXID AS TAXID, (CN_TAX * (-1)) AS TAXAMT, CN_ADDTAXID AS ADDTAXID, (CN_ADDTAX  * (-1)) AS ADDTAXAMT, (CN_OTHERCHGS * (-1)) AS OTHERCHGS, (CN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, CN_no AS BILL, 'CREDITNOTE' AS TYPE, CN_cmpid AS CMPID, CN_locationid AS LOCATIONID, CN_yearid AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = CN_LEDGERID INNER JOIN CMPMASTER ON CN_cmpid = cmp_id WHERE SUBSTRING(CN_BILLNO,0,3) <> 'TS' UNION ALL SELECT AIRCN_initials AS BILLNO, AIRCN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (AIRCN_GTOTAL * (-1)) AS GRANDTOTAL, (AIRCN_TOTALAMT * (-1)) AS NETT  , (AIRCN_SUBTOTAL * (-1)) AS SUBTOTAL,	AIRCN_TAXID AS TAXID, (AIRCN_TAX * (-1)) AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, (AIRCN_OTHERCHGS * (-1)) AS OTHERCHGS, (AIRCN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, AIRCN_no AS BILL, 'AIRCREDITNOTE' AS TYPE, AIRCN_cmpid AS CMPID, AIRCN_locationid AS LOCATIONID, AIRCN_yearid AS YEARID FROM AIRCREDITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = AIRCN_LEDGERID AND Acc_cmpid =  AIRCN_cmpid AND Acc_locationid = AIRCN_locationid AND Acc_yearid = AIRCN_yearid INNER JOIN CMPMASTER ON AIRCN_cmpid = cmp_id UNION ALL SELECT AIRLINEBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, AIRLINEBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, AIRLINEBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, AIRLINEBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TAXID, 0) AS TAXID, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_TAX, 0) AS TAXAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_ADDTAXID, 0) AS ADDTAXID, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_ADDTAX, 0) AS ADDTAXAMT, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(AIRLINEBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, ISNULL(CMPMASTER.cmp_add1, '') AS ADD1, ISNULL(CMPMASTER.cmp_add2, '') AS ADD2, ISNULL(CMPMASTER.cmp_invinitials, '') AS CMPINTIALS, AIRLINEBOOKINGMASTER.BOOKING_NO AS BILL, 'AIRLINE' AS TYPE, AIRLINEBOOKINGMASTER.BOOKING_CMPID AS CMPID, AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, AIRLINEBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM AIRLINEBOOKINGMASTER INNER JOIN CMPMASTER ON AIRLINEBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid UNION ALL SELECT RAILBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, RAILBOOKINGMASTER.BOOKING_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(RAILBOOKINGMASTER.BOOKING_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_TOTALSALEAMT, 0) AS NETT, ISNULL(RAILBOOKINGMASTER.BOOKING_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(RAILBOOKINGMASTER.BOOKING_TAXID, 0) AS TAXID, ISNULL(RAILBOOKINGMASTER.BOOKING_TAX, 0) AS TAXAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_ADDTAXID, 0) AS ADDTAXID, ISNULL(RAILBOOKINGMASTER.BOOKING_ADDTAX, 0) AS ADDTAXAMT, ISNULL(RAILBOOKINGMASTER.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(RAILBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(CMPMASTER.cmp_name, '') AS CMPNAME, ISNULL(CMPMASTER.cmp_add1, '') AS ADD1, ISNULL(CMPMASTER.cmp_add2, '') AS ADD2, ISNULL(CMPMASTER.cmp_invinitials, '') AS CMPINITIALS, RAILBOOKINGMASTER.BOOKING_NO AS BILL, 'RAILBOOKING' AS TYPE, RAILBOOKINGMASTER.BOOKING_CMPID AS CMPID, RAILBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, RAILBOOKINGMASTER.BOOKING_YEARID AS YEARI FROM RAILBOOKINGMASTER INNER JOIN CMPMASTER ON RAILBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND RAILBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND RAILBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid WHERE (RAILBOOKINGMASTER.BOOKING_DONE = 0) AND (RAILBOOKINGMASTER.BOOKING_CANCELLED = 0) UNION ALL SELECT MISCSALMASTER.BOOKING_PURBILLINITIALS AS BILLNO, MISCSALMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME,  MISCSALMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, MISCSALMASTER.BOOKING_FINALPURAMT AS NETT, (CASE WHEN ISNULL(MISCSALMASTER.BOOKING_TAXSERVCHGS,0) = 'FALSE' THEN MISCSALMASTER.BOOKING_PURSUBTOTAL ELSE MISCSALMASTER.BOOKING_PUREXTRACHGS END) AS SUBTOTAL, MISCSALMASTER.BOOKING_PURTAXID AS TAXID, MISCSALMASTER.BOOKING_PURTAX AS TAXAMT, MISCSALMASTER.BOOKING_PURADDTAXID AS ADDTAXID, MISCSALMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, MISCSALMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCSALMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, MISCSALMASTER.BOOKING_NO AS BILL, 'MISCSALE' AS TYPE, MISCSALMASTER.BOOKING_CMPID AS CMPID, MISCSALMASTER.BOOKING_LOCATIONID AS LOCATIONID, MISCSALMASTER.BOOKING_YEARID AS YEARID FROM MISCSALMASTER INNER JOIN LEDGERS ON MISCSALMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND MISCSALMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND MISCSALMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND MISCSALMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON MISCSALMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE (MISCSALMASTER.BOOKING_CANCELLED = 0) AND (MISCSALMASTER.BOOKING_DONE = 0) UNION ALL SELECT CARBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, CARBOOKINGMASTER.BOOKING_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(CARBOOKINGMASTER.BOOKING_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(CARBOOKINGMASTER.BOOKING_TOTALSALEAMT, 0) AS NETT, ISNULL(CARBOOKINGMASTER.BOOKING_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(CARBOOKINGMASTER.BOOKING_TAXID, 0) AS TAXID, ISNULL(CARBOOKINGMASTER.BOOKING_TAX, 0) AS TAXAMT, ISNULL(CARBOOKINGMASTER.BOOKING_ADDTAXID, 0) AS ADDTAXID, ISNULL(CARBOOKINGMASTER.BOOKING_ADDTAX, 0) AS ADDTAXAMT, ISNULL(CARBOOKINGMASTER.BOOKING_OTHERCHGS, 0) AS OTHERCHGS, ISNULL(CARBOOKINGMASTER.BOOKING_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(CMPMASTER.cmp_name, '') AS CMPNAME, ISNULL(CMPMASTER.cmp_add1, '') AS ADD1, ISNULL(CMPMASTER.cmp_add2, '') AS ADD2, ISNULL(CMPMASTER.cmp_invinitials, '') AS CMPINITIALS, CARBOOKINGMASTER.BOOKING_NO AS BILL,'CARBOOKING' AS TYPE, CARBOOKINGMASTER.BOOKING_CMPID AS CMPID, CARBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, CARBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM CARBOOKINGMASTER INNER JOIN CMPMASTER ON CARBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON CARBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND CARBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND CARBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid And CARBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid WHERE (CARBOOKINGMASTER.BOOKING_DONE = 0) AND (CARBOOKINGMASTER.BOOKING_CANCELLED = 0) UNION ALL SELECT VISABOOKING.BOOKING_SALEBILLINITIALS AS BILLNO, VISABOOKING.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, VISABOOKING.BOOKING_GRANDTOTAL AS GRANDTOTAL, VISABOOKING.BOOKING_TOTALSALEAMT AS NETT, VISABOOKING.BOOKING_SERVICECHGS AS SUBTOTAL, VISABOOKING.BOOKING_TAXID AS TAXID, VISABOOKING.BOOKING_TAX AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, VISABOOKING.BOOKING_OTHERCHGS AS OTHERCHGS, VISABOOKING.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, VISABOOKING.BOOKING_NO AS BILL, 'VISABOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, 0 AS LOCATIONID , BOOKING_YEARID AS YEARID FROM VISABOOKING INNER JOIN LEDGERS ON VISABOOKING.BOOKING_LEDGERID = LEDGERS.Acc_id INNER JOIN CMPMASTER ON VISABOOKING.BOOKING_CMPID = CMPMASTER.cmp_id ) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then

                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_TAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM AIRLINEBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM RAILBOOKINGMASTER UNION ALL SELECT BOOKING_PURTAXID  FROM MISCSALMASTER UNION ALL SELECT BOOKING_TAXID  FROM CARBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID FROM VISABOOKING) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                'Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_ADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                'If DTADDTAX.Rows.Count > 0 Then
                '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                '        DT.Columns.Add(DRADDTAX("TAXNAME"))
                '        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID"))
                '            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                '            DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                '        Next
                '    Next
                'End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 52
                    SetColumn(I, Chr(65) + Chr(64 + I - 26))
                Next

                For I As Integer = 53 To 78
                    SetColumn(I, Chr(66) + Chr(64 + I - 52))
                Next

                For I As Integer = 79 To 104
                    SetColumn(I, Chr(67) + Chr(64 + I - 78))
                Next

                For I As Integer = 105 To 130
                    SetColumn(I, Chr(68) + Chr(64 + I - 104))
                Next

                For I As Integer = 131 To 156
                    SetColumn(I, Chr(69) + Chr(64 + I - 130))
                Next

                For I As Integer = 157 To 182
                    SetColumn(I, Chr(70) + Chr(64 + I - 156))
                Next

                For I As Integer = 183 To 208
                    SetColumn(I, Chr(71) + Chr(64 + I - 182))
                Next



                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("SALES-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GP SHEET"

    Public Function GP_SHEET(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DTGUEST As System.Data.DataTable = objCMN.search(" TOP 1 GUESTMASTER.GUEST_NAME AS GUESTNAME, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALPAX AS TOTALPAX, isnull(GUESTMASTER.GUEST_MOBILENO,'') AS [MOBILENO], ISNULL(GUESTMASTER.GUEST_EMAIL,'') AS EMAILID, ISNULL(CAST(GUESTMASTER.GUEST_ADD AS VARCHAR(8000)),'') AS GUESTADD", "", " INTERNATIONALBOOKINGMASTER_GUESTDETAILS INNER JOIN GUESTMASTER ON INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_GUESTID = GUESTMASTER.GUEST_ID AND  INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_CMPID = GUESTMASTER.GUEST_CMPID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_LOCATIONID = GUESTMASTER.GUEST_LOCATIONID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_YEARID = GUESTMASTER.GUEST_YEARID RIGHT OUTER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_GUESTDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID", CONDITION & " ")
            Dim DTPUR As System.Data.DataTable = objCMN.search(" LEDGERS.Acc_cmpname AS PURCHASENAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURRATE, '1' AS PURQTY, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMOUNT AS PURAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_AMTPAID + INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_EXTRAAMT AS PURPAIDAMT", "", " LEDGERS INNER JOIN INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS ON LEDGERS.Acc_id = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID AND LEDGERS.Acc_cmpid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID AND LEDGERS.Acc_locationid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID AND LEDGERS.Acc_yearid = INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID RIGHT OUTER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID", CONDITION & "")
            Dim DT As System.Data.DataTable = objCMN.search("HOTELMASTER.HOTEL_NAME AS HOTELNAME, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_ARRIVALDATE AS ARRIVAL, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_DEPARTUREDATE AS DEPARTURE, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_RATE AS SALERATE, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_NOOFROOMS AS SALEQTY, INTERNATIONALBOOKINGMASTER_DESC.BOOKING_AMOUNT AS SALEAMT, INTERNATIONALBOOKINGMASTER.BOOKING_SALEAMTREC + INTERNATIONALBOOKINGMASTER.BOOKING_SALEEXTRAAMT AS SALERECDAMT, INTERNATIONALBOOKINGMASTER.BOOKING_SALEBALANCE AS SALEBALANCE, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS SALETOTAL, CITYMASTER.city_name AS CITYNAME", "", " HOTELMASTER INNER JOIN INTERNATIONALBOOKINGMASTER INNER JOIN INTERNATIONALBOOKINGMASTER_DESC ON INTERNATIONALBOOKINGMASTER.BOOKING_NO = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_NO AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID ON HOTELMASTER.HOTEL_ID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_HOTELID AND HOTELMASTER.HOTEL_CMPID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID AND HOTELMASTER.HOTEL_LOCATIONID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID AND HOTELMASTER.HOTEL_YEARID = INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID LEFT OUTER JOIN CITYMASTER ON INTERNATIONALBOOKINGMASTER_DESC.BOOKING_YEARID = CITYMASTER.city_yearid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_LOCATIONID = CITYMASTER.city_locationid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_CMPID = CITYMASTER.city_cmpid AND INTERNATIONALBOOKINGMASTER_DESC.BOOKING_SECTORID = CITYMASTER.city_id", CONDITION & "")
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 30)
                SetColumnWidth("F1", 1.5)
                SetColumnWidth("C1", 5)
                SetColumnWidth("D1", 5)
                SetColumnWidth("E1", 13)
                SetColumnWidth("H1", 5)
                SetColumnWidth("I1", 5)
                SetColumnWidth("J1", 13)


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("10"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))

                RowIndex += 1
                Write("GP Sheet for " & DTGUEST.Rows(0).Item("GUESTNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
                SetBorder(RowIndex, Range("1"), Range("10"))

                SetBorder(RowIndex, Range("1"), Range("10"))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Select()
                objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("10").ToString & 6).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 1
                Write("Passenger Details :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

                RowIndex += 1
                Write("Pax Name", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("GUESTNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("No. Of Guest", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("TOTALPAX"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Mobile No.", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("MOBILENO"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Email ID", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTGUEST.Rows(0).Item("EMAILID"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)


                RowIndex += 1
                Write("Address", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                'Write(DTGUEST.Rows(0).Item("GUESTADD"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)



                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - 5, objColumn.Item("10").ToString & RowIndex)



                RowIndex += 1
                Write("Booking Details :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                RowIndex += 1
                Write("Hotel", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

                For Each DTROW As DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("CITYNAME"), Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("HOTELNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)

                    RowIndex += 1
                    Write("CHECK IN", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("ARRIVAL"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)

                    RowIndex += 1
                    Write("CHECK OUT", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                    Write(DTROW("DEPARTURE"), Range("2"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
                    RowIndex += 1
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - (RowIndex - 5), objColumn.Item("10").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("1").ToString & 6, objColumn.Item("1").ToString & RowIndex)



                RowIndex += 1
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
                Write("PURCHASE", Range("2"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
                Write("SALE", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



                RowIndex += 1
                Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Rate", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("ROE", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Qty.", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Amount in INR", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)

                Write("Rate", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("ROE", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Qty.", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Amount in INR", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 1
                Write("Package :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)


                'USED TO SAVE ROWCOUNT NO FOR CALCULATING SUM AT THE BOTTOM
                'DONT DELETE TESTED PROPERLY
                Dim TEMPROWCOUNT As Integer = RowIndex

                For Each DTROW As DataRow In DTPUR.Rows
                    RowIndex += 1
                    Write(DTROW("PURCHASENAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURRATE"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)

                    'ROE (RATE OF EXCHANGE) BY DEFAULT 1
                    Write("1", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURQTY"), Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=(" & Range("2") & "*" & Range("3") & "*" & Range("4") & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Next

                Dim TEMPFINISHCOUNT As Integer = RowIndex
                RowIndex = TEMPROWCOUNT

                For Each DTROW As DataRow In DT.Rows
                    RowIndex += 1
                    Write(DTROW("SALERATE"), Range("7"), XlHAlign.xlHAlignLeft, , True, 10)

                    'ROE (RATE OF EXCHANGE) BY DEFAULT 1
                    Write("1", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("SALEQTY"), Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=(" & Range("7") & "*" & Range("8") & "*" & Range("9") & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                Next


                If RowIndex < TEMPFINISHCOUNT Then RowIndex = TEMPFINISHCOUNT

                RowIndex += 2
                FORMULA("=SUM(" & objColumn.Item("5").ToString & TEMPROWCOUNT & ":" & objColumn.Item("5").ToString & RowIndex - 2 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("10").ToString & TEMPROWCOUNT & ":" & objColumn.Item("10").ToString & RowIndex - 2 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 2
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " > 0,""GROSS PROFIT"",""GROSS LOSS""", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " < 0," & objColumn.Item("5").ToString & RowIndex - 2 & "-" & objColumn.Item("10").ToString & RowIndex - 2 & ",""""", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=IF(" & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & " > 0," & objColumn.Item("10").ToString & RowIndex - 2 & "-" & objColumn.Item("5").ToString & RowIndex - 2 & ",""""", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


                RowIndex += 2
                Write("Purchased From :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For Each DTROW As DataRow In DTPUR.Rows
                    RowIndex += 1
                    Write(DTROW("PURCHASENAME"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                    Write(DTROW("PURAMT"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                    FORMULA("=IF(" & DTROW("PURAMT") & "-" & DTROW("PURPAIDAMT") & " = 0,""PAID"",""""", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Next



                RowIndex += 2
                Write("Invoice to be made as follows :", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("SALERECDAMT")) > 0 Then
                        RowIndex += 1
                        Write(DTROW("Amount received"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9, False, True)
                        Write(DTROW("SALERECDAMT"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                        FORMULA("=IF(" & DTROW("SALEAMT") & "-" & DTROW("SALERECDAMT") & " = 0,""RECD"",""""", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                    End If
                Next
                RowIndex += 1
                Write("Balance:", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, False, True)
                Write(DT.Rows(0).Item("SALEBALANCE"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)

                RowIndex += 3
                Write("Total Invoice", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DT.Rows(0).Item("SALETOTAL"), Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("10").ToString & RowIndex + 1)


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX DETAILS REPORT"

    Public Function PURCHASE_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE HOTELBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND HOTELBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE' UNION ALL Select DISTINCT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'PACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL Select DISTINCT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE (INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL SELECT DN_initials AS BILLNO, DN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (DN_GTOTAL * (-1)) AS GRANDTOTAL, (DN_TOTALAMT * (-1)) AS NETT  , (DN_SUBTOTAL * (-1)) AS SUBTOTAL,	DN_TAXID AS TAXID, (DN_TAX * (-1)) AS TAXAMT, DN_ADDTAXID AS ADDTAXID, (DN_ADDTAX  * (-1)) AS ADDTAXAMT, (DN_OTHERCHGS * (-1)) AS OTHERCHGS, (DN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, DN_no AS BILL, 'DEBITNOTE' AS TYPE, DN_cmpid AS CMPID, DN_locationid AS LOCATIONID, DN_yearid AS YEARID FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = DN_LEDGERID AND Acc_cmpid =  DN_cmpid AND Acc_locationid = DN_locationid AND Acc_yearid = DN_yearid INNER JOIN CMPMASTER ON DN_cmpid = cmp_id WHERE SUBSTRING(DN_BILLNO,0,3) <> 'TP' UNION ALL SELECT AIRDN_initials AS BILLNO, AIRDN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (AIRDN_GTOTAL * (-1)) AS GRANDTOTAL, (AIRDN_TOTALAMT * (-1)) AS NETT  , (AIRDN_SUBTOTAL * (-1)) AS SUBTOTAL,	AIRDN_TAXID AS TAXID, (AIRDN_TAX * (-1)) AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, (AIRDN_OTHERCHGS * (-1)) AS OTHERCHGS, (AIRDN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, AIRDN_no AS BILL, 'DEBITNOTE' AS TYPE, AIRDN_cmpid AS CMPID, AIRDN_locationid AS LOCATIONID, AIRDN_yearid AS YEARID FROM AIRDEBITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = AIRDN_LEDGERID AND Acc_cmpid =  AIRDN_cmpid AND Acc_locationid = AIRDN_locationid AND Acc_yearid = AIRDN_yearid INNER JOIN CMPMASTER ON AIRDN_cmpid = cmp_id UNION ALL SELECT AIRLINEBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, AIRLINEBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, AIRLINEBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, AIRLINEBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, AIRLINEBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, AIRLINEBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, AIRLINEBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, AIRLINEBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, AIRLINEBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, AIRLINEBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, AIRLINEBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, AIRLINEBOOKINGMASTER.BOOKING_NO AS BILL, 'AIRLINEBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM AIRLINEBOOKINGMASTER INNER JOIN CMPMASTER ON AIRLINEBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON AIRLINEBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND AIRLINEBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND AIRLINEBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND AIRLINEBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE AIRLINEBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' UNION ALL SELECT MISCPURMASTER.BOOKING_PURBILLINITIALS AS BILLNO, MISCPURMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, MISCPURMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, MISCPURMASTER.BOOKING_FINALPURAMT AS NETT, MISCPURMASTER.BOOKING_PURSUBTOTAL AS SUBTOTAL, MISCPURMASTER.BOOKING_PURTAXID AS TAXID, MISCPURMASTER.BOOKING_PURTAX AS TAXAMT, MISCPURMASTER.BOOKING_PURADDTAXID AS ADDTAXID, MISCPURMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, MISCPURMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, MISCPURMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, MISCPURMASTER.BOOKING_NO AS BILL, 'MISCBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM MISCPURMASTER INNER JOIN CMPMASTER ON MISCPURMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON MISCPURMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND MISCPURMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND MISCPURMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND MISCPURMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE MISCPURMASTER.BOOKING_CANCELLED = 'FALSE' UNION ALL SELECT RAILBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, RAILBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, RAILBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, RAILBOOKINGMASTER.BOOKING_TOTALPURAMT AS NETT, RAILBOOKINGMASTER.BOOKING_PURSUBTOTAL AS SUBTOTAL, RAILBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, RAILBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, RAILBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, RAILBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, RAILBOOKINGMASTER.BOOKING_NO AS BILL, 'RAILBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM RAILBOOKINGMASTER INNER JOIN CMPMASTER ON RAILBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON RAILBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND RAILBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND RAILBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND RAILBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE RAILBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' UNION ALL Select DISTINCT CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'CARBOOKING' AS TYPE, CARBOOKINGMASTER.BOOKING_CMPID AS CMPID, CARBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, CARBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM CARBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CARBOOKINGMASTER ON CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = CARBOOKINGMASTER.BOOKING_NO AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CARBOOKINGMASTER.BOOKING_CMPID AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = CARBOOKINGMASTER.BOOKING_LOCATIONID AND CARBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = CARBOOKINGMASTER.BOOKING_YEARID WHERE (CARBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') UNION ALL Select DISTINCT VISABOOKING_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, VISABOOKING_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, VISABOOKING_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, VISABOOKING_PURCHASEDETAILS.BOOKING_NETTAMT AS NETT, VISABOOKING_PURCHASEDETAILS.BOOKING_SERVCHGS AS SUBTOTAL, VISABOOKING_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, VISABOOKING_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, 0 AS ADDTAXID, 0 AS ADDTAXAMT, VISABOOKING_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, VISABOOKING_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, VISABOOKING_PURCHASEDETAILS.BOOKING_NO AS BILL, 'VISABOOKING' AS TYPE, VISABOOKING.BOOKING_CMPID AS CMPID, 0 AS LOCATIONID, VISABOOKING.BOOKING_YEARID AS YEARID FROM VISABOOKING_PURCHASEDETAILS INNER JOIN CMPMASTER ON VISABOOKING_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON VISABOOKING_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id INNER JOIN VISABOOKING ON VISABOOKING_PURCHASEDETAILS.BOOKING_NO = VISABOOKING.BOOKING_NO AND VISABOOKING_PURCHASEDETAILS.BOOKING_YEARID = VISABOOKING.BOOKING_YEARID ) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS UNION ALL SELECT BOOKING_PURTAXID FROM AIRLINEBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID FROM CARBOOKINGMASTER_PURCHASEDETAILS UNION ALL SELECT BOOKING_PURTAXID FROM MISCPURMASTER UNION ALL SELECT BOOKING_PURTAXID FROM RAILBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID FROM VISABOOKING_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                'Dim COLINDEX As Integer = 0
                'Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                'If DTADDTAX.Rows.Count > 0 Then
                '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                '        COLINDEX = DT.Columns.IndexOf(DRADDTAX("TAXNAME"))
                '        If COLINDEX = 0 Then DT.Columns.Add(DRADDTAX("TAXNAME"))
                '        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID") & " OR TAXID = " & DRADDTAX("TAXID"))
                '            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                '            If IsDBNull(DR(DRADDTAX("TAXNAME"))) = False Then
                '                DR(DRADDTAX("TAXNAME")) = Val(DR(DRADDTAX("TAXNAME"))) + DR("ADDTAXAMT")
                '            Else
                '                DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                '            End If
                '        Next
                '    Next
                'End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 52
                    SetColumn(I, Chr(65) + Chr(64 + I - 26))
                Next

                For I As Integer = 53 To 78
                    SetColumn(I, Chr(66) + Chr(64 + I - 52))
                Next

                For I As Integer = 79 To 104
                    SetColumn(I, Chr(67) + Chr(64 + I - 78))
                Next

                For I As Integer = 105 To 130
                    SetColumn(I, Chr(68) + Chr(64 + I - 104))
                Next

                For I As Integer = 131 To 156
                    SetColumn(I, Chr(69) + Chr(64 + I - 130))
                Next

                For I As Integer = 157 To 182
                    SetColumn(I, Chr(70) + Chr(64 + I - 156))
                Next

                For I As Integer = 183 To 208
                    SetColumn(I, Chr(71) + Chr(64 + I - 182))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("Purchase-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX SUMMARY REPORT"

    Public Function SALES_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS NETTAMT", "", " HOTELBOOKINGMASTER", " AND BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(BOOKING_DATE) = " & Val(DR("MONTH")) & " AND BOOKING_CMPID = " & CMPID & " AND BOOKING_LOCATIONID = " & LOCATIONID & " AND BOOKING_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            'Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN INVOICEMASTER ON EXCISEMASTER.EXCISE_yearid = INVOICEMASTER.INVOICE_YEARID AND EXCISEMASTER.EXCISE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = INVOICEMASTER.INVOICE_CMPID AND EXCISEMASTER.EXCISE_id = INVOICEMASTER.INVOICE_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            'If DTEXCISE.Rows.Count > 0 Then
            '    For Each DREXCISE As DataRow In DTEXCISE.Rows
            '        DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales")
            '        DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Sales")
            '        DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Sales")
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_HSECESSAMT),0) AS HSECESSAMT", "", " INVOICEMASTER", " AND INVOICE_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
            '            Else
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = 0.0
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = 0.0
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = 0.0
            '            End If
            '        Next
            '    Next
            'End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER ON TAXMASTER.TAX_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.TAX_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.TAX_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.TAX_id = HOTELBOOKINGMASTER.BOOKING_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_TAX),0) AS TAXAMT ", "", " HOTELBOOKINGMASTER", " AND HOTELBOOKINGMASTER.BOOKING_TAXID = " & DRTAX("TAXID") & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(HOTELBOOKINGMASTER.BOOKING_DATE) = " & Val(DR("MONTH")) & " AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CMPID & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & LOCATIONID & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            ''FOR ADDTAXAMT
            'Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN INVOICEMASTER ON TAXMASTER.TAX_yearid = INVOICEMASTER.INVOICE_YEARID AND TAXMASTER.TAX_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND TAXMASTER.TAX_cmpid = INVOICEMASTER.INVOICE_CMPID AND TAXMASTER.TAX_id = INVOICEMASTER.INVOICE_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            'If DTADDTAX.Rows.Count > 0 Then
            '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
            '        DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search("ISNULL(SUM(INVOICEMASTER.INVOICE_ADDTAXAMT),0) AS ADDTAXAMT", "", " INVOICEMASTER", " AND INVOICE_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(INVOICE_DATE)= " & DR("MONTH") & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
            '            Else
            '                DR(DRADDTAX("TAXNAME")) = 0.0
            '            End If
            '        Next
            '    Next
            'End If


            'DTMONTH.Columns.Add("FREIGHT")
            'DTMONTH.Columns.Add("OCTROIAMT")
            'DTMONTH.Columns.Add("INSAMT")
            'DTMONTH.Columns.Add("ROUNDOFF")
            'For Each DR As DataRow In DTMONTH.Rows
            '    DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_FREIGHT),0) AS FREIGHT, ISNULL(SUM(INVOICEMASTER.INVOICE_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_INSAMT),0) AS INSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_ROUNDOFF),0) AS ROUNDOFF", "", " INVOICEMASTER", " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '    If DTVAL.Rows.Count > 0 Then
            '        DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
            '        DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
            '        DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
            '        DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
            '    Else
            '        DR("FREIGHT") = 0.0
            '        DR("OCTROIAMT") = 0.0
            '        DR("INSAMT") = 0.0
            '        DR("ROUNDOFF") = 0.0
            '    End If
            'Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            'Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                'Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("SALES-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "FOREX REQUIREMENT"

    Public Function FOREX_REQUIREMENT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal CURRENCY As String) As Object
        Try

            SetWorkSheet()
            For I = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range(2), 6)
            SetColumnWidth(Range(3), 25)
            SetColumnWidth(Range(5), 6)
            For i As Integer = 16 To 26
                SetColumnWidth(Range(i), 6)
            Next

            ' **************************** CMPHEADER *************************
            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)


            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range((DT.Columns.Count + 9).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range((DT.Columns.Count + 9).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range((DT.Columns.Count + 9).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range((DT.Columns.Count + 9).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range((DT.Columns.Count + 9).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range((DT.Columns.Count + 9).ToString))


            RowIndex += 1
            Write("FOREX REQUIREMENT (" & DT.Rows(0).Item("TOURNAME") & " - " & CURRENCY & ")", Range("1"), XlHAlign.xlHAlignCenter, Range((DT.Columns.Count + 9).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range((DT.Columns.Count + 9).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item((DT.Columns.Count + 9).ToString).ToString & 7).Select()
            objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item((DT.Columns.Count + 9).ToString).ToString & 7).Application.ActiveWindow.FreezePanes = True

            ' **************************** CMPHEADER *************************


            RowIndex += 1
            Write("Age", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Sr No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Passenger Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            ' Write("DOB", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pax", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Lawazim", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Visa", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Gift", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Transport", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Meals", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Country Tax", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Misc Exp", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Airline", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Coordinator", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Add. Service", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)

            Dim DTNEW As System.Data.DataTable = OBJCMN.search(" (SUM(LAWAZIM) + SUM(VISA) + SUM(GIFT ) + SUM(TRANSPORT) + SUM(MEALS ) + SUM(COUNTRYTAX) + SUM(MISCEXP) + SUM(AIRLINE) + SUM(CORDINATOR) + SUM(ADDSERVICE) ) AS TOTALHEADER ", "", " FOREXVIEW ", " AND TOURNAME = '" & DT.Rows(0).Item("TOURNAME") & "' AND CURCODE = '" & CURRENCY & "' AND YEARID = " & YEARID)
            Write(DTNEW.Rows(0).Item(0), Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            Write(DTNEW.Rows(0).Item(0), Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("100", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("50", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("20", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("10", Range("21"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("5", Range("22"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("1", Range("23"), XlHAlign.xlHAlignCenter, , True, 10)


            SetBorder(RowIndex, Range("1"), Range((DT.Columns.Count + 9).ToString))


            Dim DOB As String = ""
            Dim HOF As String = ""
            Dim HOFCOUNT As Integer = 0
            Dim STARTHOFCOUNT As Integer = RowIndex + 1
            Dim TEMPADJUST As Integer = 0
            Dim TOTALTEMPADJUST As Integer = 0
            Dim SRNO As Integer = 1

            'IF HOF IS GREATER THEN 1 THEN WE NEED DIFF CALCULTAIONS
            DTNEW = OBJCMN.search(" HOF ", "", " FOREXVIEW ", " AND TOURNAME = '" & DT.Rows(0).Item("TOURNAME") & "' AND CURCODE = '" & CURRENCY & "' AND YEARID = " & YEARID & " GROUP BY HOF")
            HOFCOUNT = DTNEW.Rows.Count

            For Each DTROW As DataRow In DT.Rows

                'CODE TO GET AGE IN SPECIFIED FORMAT
                Dim YEARS As Integer = Now.Date.Year - Convert.ToDateTime(DTROW("DOB")).Date.Year
                Dim MONTHS As Integer = Now.Date.Month - Convert.ToDateTime(DTROW("DOB")).Date.Month
                Dim DAYS As Integer = Now.Date.Day - Convert.ToDateTime(DTROW("DOB")).Date.Day
                If Val(MONTHS) < 0 Then
                    YEARS = Val(YEARS) + Val(MONTHS)
                    MONTHS = 12 + Val(MONTHS)
                End If
                If Val(MONTHS) = 0 And DAYS < 0 Then
                    YEARS = Val(YEARS) - 1
                    MONTHS = 12 - 1
                End If
                If Val(DAYS) < 0 Then MONTHS = MONTHS - 1
                Dim CurrentMonthDays As Integer = DateTime.DaysInMonth(Now.Year, Now.Month)
                If Val(DAYS) < 0 Then DAYS = Val(CurrentMonthDays) + Val(DAYS)
                DOB = YEARS & " Y " & MONTHS & " M " & DAYS & " D"


                
                RowIndex += 1
                Write(DOB, Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
                Write(SRNO, Range("2"), XlHAlign.xlHAlignCenter, , False, 10)
                Write(DTROW("PASSNAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                ' Write(DTROW("DOB"), Range("4"), XlHAlign.xlHAlignCenter, , False, 10)

                If HOF <> DTROW("HOF") Then
                    If HOF <> "" Then
                        'MERGE CELLS 
                        objSheet.Range(objColumn.Item("5").ToString & STARTHOFCOUNT, objColumn.Item("5").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("16").ToString & STARTHOFCOUNT, objColumn.Item("16").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("17").ToString & STARTHOFCOUNT, objColumn.Item("17").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("18").ToString & STARTHOFCOUNT, objColumn.Item("18").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("19").ToString & STARTHOFCOUNT, objColumn.Item("19").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("20").ToString & STARTHOFCOUNT, objColumn.Item("20").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("21").ToString & STARTHOFCOUNT, objColumn.Item("21").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("22").ToString & STARTHOFCOUNT, objColumn.Item("22").ToString & RowIndex - 1).Merge()
                        objSheet.Range(objColumn.Item("23").ToString & STARTHOFCOUNT, objColumn.Item("23").ToString & RowIndex - 1).Merge()
                    End If

                 


                    DTNEW = OBJCMN.search(" PASSNAME ", "", " FOREXVIEW ", " AND HOF = '" & DTROW("HOF") & "' AND  TOURNAME = '" & DT.Rows(0).Item("TOURNAME") & "' AND CURCODE = '" & CURRENCY & "' AND YEARID = " & YEARID & " GROUP BY PASSNAME")
                    Write(DTNEW.Rows.Count, Range("5"), XlHAlign.xlHAlignRight, , False, 10)

                    DTNEW = OBJCMN.search(" (SUM(LAWAZIM) + SUM(VISA) + SUM(GIFT ) + SUM(TRANSPORT) + SUM(MEALS ) + SUM(COUNTRYTAX) + SUM(MISCEXP) + SUM(AIRLINE) + SUM(CORDINATOR) + SUM(ADDSERVICE) ) AS TOTALHEADER ", "", " FOREXVIEW ", " AND HOF = '" & DTROW("HOF") & "' AND TOURNAME = '" & DT.Rows(0).Item("TOURNAME") & "' AND CURCODE = '" & CURRENCY & "' AND YEARID = " & YEARID)
                    Write(DTNEW.Rows(0).Item(0), Range("16"), XlHAlign.xlHAlignRight, , False, 10)


                    If HOFCOUNT = 1 Then

                        DTNEW = OBJCMN.search(" (SUM(LAWAZIM) + SUM(VISA) + SUM(GIFT ) + SUM(TRANSPORT) + SUM(MEALS ) + SUM(COUNTRYTAX) + SUM(MISCEXP) + SUM(AIRLINE) + SUM(CORDINATOR) + SUM(ADDSERVICE) ) AS TOTALHEADER ", "", " FOREXVIEW ", " AND TOURNAME = '" & DT.Rows(0).Item("TOURNAME") & "' AND CURCODE = '" & CURRENCY & "' AND YEARID = " & YEARID)
                        TEMPADJUST = Val(DTNEW.Rows(0).Item(0)) - Val(TOTALTEMPADJUST)
                        Write(TEMPADJUST, Range("17"), XlHAlign.xlHAlignRight, , False, 10)
                        
                    Else

                        Dim temp As Integer = Val(DTNEW.Rows(0).Item(0)) Mod (10)
                        If temp = 0 Then
                            Write(Val(DTNEW.Rows(0).Item(0)), Range("17"), XlHAlign.xlHAlignRight, , False, 10)
                            TEMPADJUST = Val(DTNEW.Rows(0).Item(0))
                        Else
                            Write((10 - temp) + Val(DTNEW.Rows(0).Item(0)), Range("17"), XlHAlign.xlHAlignRight, , False, 10)
                            TEMPADJUST = (10 - temp) + Val(DTNEW.Rows(0).Item(0))
                        End If
                        TOTALTEMPADJUST = TOTALTEMPADJUST + TEMPADJUST

                    End If

                    
                    Dim TEMP100 As Integer
                    TEMP100 = Math.Floor((TEMPADJUST / (100)))
                    TEMPADJUST = Val(TEMPADJUST) Mod (100)
                    Write(TEMP100, Range("18"), XlHAlign.xlHAlignRight, , False, 10)

                    Dim TEMP50 As Integer
                    TEMP50 = Math.Floor((TEMPADJUST / (50)))
                    TEMPADJUST = Val(TEMPADJUST) Mod (50)
                    Write(TEMP50, Range("19"), XlHAlign.xlHAlignRight, , False, 10)


                    Dim TEMP20 As Integer
                    TEMP20 = Math.Floor((TEMPADJUST / (20)))
                    TEMPADJUST = Val(TEMPADJUST) Mod (20)
                    Write(TEMP20, Range("20"), XlHAlign.xlHAlignRight, , False, 10)


                    Dim TEMP10 As Integer
                    TEMP10 = Math.Floor((TEMPADJUST / (10)))
                    TEMPADJUST = Val(TEMPADJUST) Mod (10)
                    Write(TEMP10, Range("21"), XlHAlign.xlHAlignRight, , False, 10)


                    Dim TEMP5 As Integer
                    TEMP5 = Math.Floor((TEMPADJUST / (5)))
                    TEMPADJUST = Val(TEMPADJUST) Mod (5)
                    Write(TEMP5, Range("22"), XlHAlign.xlHAlignRight, , False, 10)


                    Write(TEMPADJUST, Range("23"), XlHAlign.xlHAlignRight, , False, 10)

                    HOFCOUNT -= 1
                    
                    STARTHOFCOUNT = RowIndex
                    HOF = DTROW("HOF")
                End If

                Write(DTROW("LAWAZIM"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("VISA"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("GIFT"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("TRANSPORT"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("MEALS"), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("COUNTRYTAX"), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("MISCEXP"), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("AIRLINE"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("CORDINATOR"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("ADDSERVICE"), Range("15"), XlHAlign.xlHAlignRight, , False, 10)

                SRNO += 1
            Next




            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("3"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 7 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 7 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 7 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 7 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 7 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 7 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 7 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 7 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("15").ToString & 7 & ":" & objColumn.Item("15").ToString & RowIndex - 1 & ")", Range("15"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("16").ToString & 7 & ":" & objColumn.Item("16").ToString & RowIndex - 1 & ")", Range("16"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("17").ToString & 7 & ":" & objColumn.Item("17").ToString & RowIndex - 1 & ")", Range("17"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("18").ToString & 7 & ":" & objColumn.Item("18").ToString & RowIndex - 1 & ")", Range("18"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("19").ToString & 7 & ":" & objColumn.Item("19").ToString & RowIndex - 1 & ")", Range("19"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("20").ToString & 7 & ":" & objColumn.Item("20").ToString & RowIndex - 1 & ")", Range("20"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("21").ToString & 7 & ":" & objColumn.Item("21").ToString & RowIndex - 1 & ")", Range("21"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("22").ToString & 7 & ":" & objColumn.Item("22").ToString & RowIndex - 1 & ")", Range("22"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("23").ToString & 7 & ":" & objColumn.Item("23").ToString & RowIndex - 1 & ")", Range("23"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("5"), Range((DT.Columns.Count + 9).ToString))

            For I As Integer = 1 To DT.Columns.Count + 9
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 6, objColumn.Item(I.ToString).ToString & RowIndex)
            Next

            
            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "CSV REPORT"

    Public Function CSVREPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

           
            Write("Passenger Type", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Title", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("First Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Last Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Nationality", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date Of Birrth", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Passport No", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date Of Expiry", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Issued Country Code", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Arrival Flight No", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Flight Arrival Date", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Flight Arrival Time", Range("12"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Departure Flight No", Range("13"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Flight Departure Date", Range("14"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Flight Departure Time", Range("15"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Group Id", Range("16"), XlHAlign.xlHAlignLeft, , True, 10)

            
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PERSONTYPE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PREFIX"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("FIRSTNAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("LASTNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NATIONALITY"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DOB"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PASSPORTNO"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("EXPIRYDATE"), Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
            Next

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX SUMMARY REPORT"

    Public Function PURCHASE_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_NETT),0) AS NETTAMT", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN PURCHASEMASTER ON EXCISEMASTER.EXCISE_yearid = PURCHASEMASTER.BILL_YEARID AND EXCISEMASTER.EXCISE_locationid = PURCHASEMASTER.BILL_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = PURCHASEMASTER.BILL_CMPID AND EXCISEMASTER.EXCISE_id = PURCHASEMASTER.BILL_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            If DTEXCISE.Rows.Count > 0 Then
                For Each DREXCISE As DataRow In DTEXCISE.Rows
                    DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase")
                    DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Purchase")
                    DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Purchase")
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(PURCHASEMASTER.BILL_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_HSECESSAMT),0) AS HSECESSAMT", "", " PURCHASEMASTER", " AND BILL_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
                        Else
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = 0.0
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = 0.0
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = 0.0
                        End If
                    Next
                Next
            End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_TAXAMT),0) AS TAXAMT ", "", " PURCHASEMASTER", " AND BILL_TAXID = " & DTTAX.Rows(0).Item("TAXID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            'FOR ADDTAXAMT
            Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTADDTAX.Rows.Count > 0 Then
                For Each DRADDTAX As DataRow In DTADDTAX.Rows
                    DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search("ISNULL(SUM(PURCHASEMASTER.BILL_ADDTAXAMT),0) AS ADDTAXAMT", "", " PURCHASEMASTER", " AND BILL_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(BILL_DATE)= " & DR("MONTH") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
                        Else
                            DR(DRADDTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            DTMONTH.Columns.Add("FREIGHT")
            DTMONTH.Columns.Add("OCTROIAMT")
            DTMONTH.Columns.Add("INSAMT")
            DTMONTH.Columns.Add("ROUNDOFF")
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_FREIGHT),0) AS FREIGHT, ISNULL(SUM(PURCHASEMASTER.BILL_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(PURCHASEMASTER.BILL_INSAMT),0) AS INSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_ROUNDOFF),0) AS ROUNDOFF", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
                    DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
                    DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
                    DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
                Else
                    DR("FREIGHT") = 0.0
                    DR("OCTROIAMT") = 0.0
                    DR("INSAMT") = 0.0
                    DR("ROUNDOFF") = 0.0
                End If
            Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("PURCHASE-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GROUP WISE TRANS DETAILS REPORT"

    Public Function GROUP_TRANS_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("B1", 40)


            'CMPHEADER
            CMPHEADER(CMPID, "GROUP-WISE TRANSACTION REPORT")



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bll No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim ALCOL(1) As String
            ALCOL(0) = ("ACC_INITIALS")
            ALCOL(1) = ("ACC_BILLNO")

            Dim OBJGROUP As New ClsCommon
            Dim DTALL As System.Data.DataTable = OBJGROUP.search("ACC_BILLDATE AS [DATE], NAME, ACC_TYPE AS [TYPE], ACC_BILLNO, ACC_INITIALS , DR,CR, PRIMARYGROUP ", "", " REGISTER ", CONDITION & " AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " ORDER BY ACC_BILLDATE")
            Dim DTMAIN As System.Data.DataTable = DTALL.DefaultView.ToTable(True, ALCOL)
            Dim DR() As System.Data.DataRow = DTMAIN.Select("ACC_INITIALS <> '0'", "ACC_BILLNO ASC")
            Dim DR1() As System.Data.DataRow
            For I As Integer = 0 To DR.GetUpperBound(0)

                DR1 = DTALL.Select("ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")

                Dim DTINITIALPARTY As System.Data.DataTable = OBJGROUP.search(" TOP(1) NAME", "", " REGISTER", " and acc_cmpid = " & CMPID & " and YEARID = " & YEARID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND name NOT IN (SELECT name FROM REGISTER WHERE REGISTER.acc_cmpid = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND REGISTER.YEARID = " & YEARID & CONDITION & ")  and acc_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")
                If DTINITIALPARTY.Rows.Count > 0 Then
                    RowIndex += 2
                    Write(Format(Convert.ToDateTime(DR1(0)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTINITIALPARTY.Rows(0).Item("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTALL.Compute("SUM(CR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTALL.Compute("SUM(DR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                    For A As Integer = 0 To DR1.GetUpperBound(0)

                        RowIndex += 1
                        Write(Format(Convert.ToDateTime(DR1(A)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("     " & DR1(A)("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(DR1(A)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("DR"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DR1(A)("cr"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Next
                End If

            Next



            For I As Integer = 1 To 6
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))


            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("6").ToString & RowIndex + 1)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PROFIT AND LOSS REPORT"

    Public Function PROFIT_AND_LOSS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth("A1", 35)
            SetColumnWidth("D1", 35)


            CMPHEADER(CMPID, "PROFIT & LOSS")


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("Particulars", Range("4"), XlHAlign.xlHAlignLeft, Range("6"), True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim DT As New System.Data.DataTable
            Dim OBJPL As New ClsProfitLoss
            OBJPL.alParaval = ALPARAVAL

            Dim RowIndexIncome As Integer = RowIndex
            Dim RowIndexexpense As Integer = RowIndex


            If CONDITION = "CONDENSED" Then
                DT = OBJPL.GETSUMMARY()

                'FORMATTING REPORT
                RowIndex += 1
                Write("Opening Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                RowIndexexpense = RowIndex

                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If

                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Gross Profit C/O" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        GoTo LINE1
                    End If


                    If DTROW(0) = "Gross Loss C/O" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        RowIndexIncome = RowIndex

                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''*************************************************************************


                    If DTROW(0) = "Indirect Expenses" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Indirect Income" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex


                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE1
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************

LINE1:
                Next


            Else
                If CONDITION = "DETAILS" Then
                    DT = OBJPL.GETDETAILS()
                Else
                    DT = OBJPL.GETLEDGER()
                End If

                'FORMATTING REPORT
                RowIndex += 1
                Write("Opening Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                RowIndexexpense = RowIndex

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) = 1 Or DTROW(2) = 2 Then
                        If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                            RowIndex = RowIndexexpense
                            RowIndex += 2
                            Write(DTROW("PRIMARYGP"), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexexpense
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) = 3 Or DTROW(2) = 4 Then
                        If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                            RowIndex = RowIndexIncome
                            RowIndex += 2
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexIncome
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Gross Profit C/O" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Closing Stock", Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 2
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Closing Stock", Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 2
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If


                    If DTROW(0) = "Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''*************************************************************************

                    If DTROW(2) = 11 Then
                        If DTROW(0) = "Indirect Expenses" Then
                            RowIndex = RowIndexexpense
                            RowIndex += 2
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexexpense
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexexpense = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    If DTROW(2) = 12 Then
                        If DTROW(0) = "Indirect Income" Then
                            RowIndex = RowIndexIncome
                            RowIndex += 2
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                            Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                            objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        Else
                            RowIndex = RowIndexIncome
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexIncome = RowIndex
                            GoTo LINE2
                        End If
                    End If

                    ''***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(0, 128, 0) 'Green
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        If RowIndexexpense > RowIndexIncome Then
                            RowIndexIncome = RowIndexexpense
                        Else
                            RowIndexexpense = RowIndexIncome
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex


                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexexpense = RowIndex

                        RowIndex = RowIndexexpense
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexexpense = RowIndex
                        GoTo LINE2
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                        RowIndexIncome = RowIndex

                        RowIndex = RowIndexIncome
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexIncome = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************
LINE2:

                Next

            End If

            If RowIndexexpense > RowIndexIncome Then
                RowIndex = RowIndexexpense
            Else
                RowIndex = RowIndexIncome
            End If
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("3").ToString & RowIndex + 1)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 7, objColumn.Item("6").ToString & RowIndex + 1)

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"




            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "BALANCE SHEET REPORT"

    Public Function BALANCE_SHEET_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth("A1", 35)
            SetColumnWidth("D1", 35)


            CMPHEADER(CMPID, "BALANCE SHEET")


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Particulars", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("Particulars", Range("4"), XlHAlign.xlHAlignLeft, Range("6"), True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim DT As New System.Data.DataTable
            Dim OBJBAL As New ClsBalanceSheet

            Dim OBJPL As New ClsProfitLoss
            Dim DTPL As New System.Data.DataTable

            OBJBAL.alParaval = ALPARAVAL
            OBJPL.alParaval = ALPARAVAL

            DTPL = OBJPL.GETSUMMARY()
            Dim DRPL() As DataRow = DTPL.Select("NAME = 'Nett Profit' OR NAME = 'Nett Loss'")


            Dim RowIndexAssets As Integer = RowIndex
            Dim RowIndexLiability As Integer = RowIndex


            If CONDITION = "CONDENSED" Then
                DT = OBJBAL.GETSUMMARY()

                'FORMATTING REPORT
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Then
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If

                    '*****************************************************************
                    '*****************************************************************



                    If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Profit" Then
                        If DRPL(0)(0) = "Nett Loss" Then GoTo LINE1
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                        Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Loss" Then
                        If DRPL(0)(0) = "Nett Profit" Then GoTo LINE1
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                        Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If

                    ''**************************************************************************************



                    If DTROW(0) = "Total Liability" Then

                        If RowIndexLiability > RowIndexAssets Then
                            RowIndexAssets = RowIndexLiability
                        Else
                            RowIndexLiability = RowIndexAssets
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE1
                    End If


                    If DTROW(0) = "Total Assets" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE1
                    End If
                    ''***************************************************************************************
LINE1:
                Next


            Else
                If CONDITION = "DETAILS" Then
                    DT = OBJBAL.GETDETAILS()
                Else
                    DT = OBJBAL.GETLEDGERDETAILS()
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(2) < 8 Then
                        If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Or (DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Profit" Then
                            If DTROW(0) <> "Profit" Then
                                RowIndex = RowIndexLiability
                                RowIndex += 2
                                Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                                Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 11)
                                objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                RowIndexLiability = RowIndex
                                GoTo LINE2
                            Else
                                If DTROW(0) = "Profit" Then
                                    If DRPL(0)(0) = "Nett Loss" Then GoTo LINE2
                                    RowIndex = RowIndexLiability
                                    RowIndex += 2
                                    Write("Profit & Loss", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, )
                                    Write(Val(DRPL(0)(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    RowIndexLiability = RowIndex
                                    GoTo LINE2
                                End If
                            End If

                        Else
                            RowIndex = RowIndexLiability
                            RowIndex += 1
                            Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexLiability = RowIndex
                            GoTo LINE2
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(2) > 7 And DTROW(2) < 14 Then
                        If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") <= 0 Then GoTo LINE2
                        If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Or (DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0) Or DTROW(0) = "Loss" Then
                            If DTROW(0) <> "Loss" Then
                                RowIndex = RowIndexAssets
                                RowIndex += 2
                                Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , True, 11, , True)
                                Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                                objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                RowIndexAssets = RowIndex
                                GoTo LINE2
                            Else
                                If DTROW(0) = "Loss" Then
                                    If DRPL(0)(0) = "Nett Profit" Then GoTo LINE2
                                    RowIndex = RowIndexAssets
                                    RowIndex += 2
                                    Write("Profit & Loss", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, )
                                    Write(Val(DRPL(0)(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                                    objSheet.Range(objColumn.Item("4").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = RGB(192, 0, 0) 'Maroon
                                    Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                                    ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                                    RowIndexAssets = RowIndex
                                    GoTo LINE2
                                End If
                            End If
                        Else
                            RowIndex = RowIndexAssets
                            RowIndex += 1
                            Write(DTROW(0), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(Val(DTROW(1)), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                            RowIndexAssets = RowIndex
                            GoTo LINE2
                        End If
                    End If


                    '*****************************************************************
                    '*****************************************************************
                    If DTROW(0) = "Total Liability" Then

                        If RowIndexLiability > RowIndexAssets Then
                            RowIndexAssets = RowIndexLiability
                        Else
                            RowIndexLiability = RowIndexAssets
                        End If

                        '***** FILLING TOTAL
                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("Total", Range("1"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexLiability = RowIndex

                        RowIndex = RowIndexLiability
                        RowIndex += 1
                        Write("'======================================", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexLiability = RowIndex
                        GoTo LINE2
                    End If


                    If DTROW(0) = "Total Assets" Then
                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("Total", Range("4"), XlHAlign.xlHAlignLeft, , True, 10, , True)
                        Write(Val(DTROW(1)), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                        RowIndexAssets = RowIndex

                        RowIndex = RowIndexAssets
                        RowIndex += 1
                        Write("'======================================", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("'==============", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                        RowIndexAssets = RowIndex
                        GoTo LINE2
                    End If
                    ''***************************************************************************************
LINE2:

                Next

            End If

            If RowIndexLiability > RowIndexAssets Then
                RowIndex = RowIndexLiability
            Else
                RowIndex = RowIndexAssets
            End If
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("3").ToString & RowIndex + 1)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 7, objColumn.Item("6").ToString & RowIndex + 1)

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"




            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TRIALBALANCE"

    Public Function TRIALBALANCE_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("TRIAL-BALANCE", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Name", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("O/P Dr", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("O/P Cr", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Dr", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Cr", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " TEMPTRIALBALANCEPRINT", " ORDER BY ROWNO")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                If DTROW("OPENINGDR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGDR")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("OPENINGCR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGCR")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

                If DTROW("CLOSINGDR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGDR")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("CLOSINGCR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGCR")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If Left(DTROW("NAME"), 1) = " " And Left(DTROW("NAME"), 6) <> "      " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                ElseIf Left(DTROW("NAME"), 1) <> " " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "ALLLEDGERBOOK"

    Public Function LEDGERBOOK_EXCEL(ByVal NAMEARRAY As ArrayList, ByVal ACCFROM As Date, ByVal ACCTO As Date, ByVal CHKARR As Boolean, ByVal ARRFROM As Date, ByVal ARRTO As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim OBJLEDGER As New ClsLedgerBook
            Dim DT As New System.Data.DataTable
            Dim OPBAL, TOTALDR, TOTALCR, CLOBAL As Double
            Dim OPBALDRCR, CLOBALDRCR As String

            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("LEDGER BOOK", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("PERIOD : " & ACCFROM & " - " & ACCTO, Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("9").ToString & 9).Select()
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("9").ToString & 9).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Hotel Name", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            Write("Guest Name", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
            Write("Ref No", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bill No", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            For I As Integer = 0 To NAMEARRAY.Count - 1

                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(NAMEARRAY(I))
                ALPARAVAL.Add(ACCFROM)
                ALPARAVAL.Add(ACCTO)
                ALPARAVAL.Add(CHKARR)
                ALPARAVAL.Add(ARRFROM)
                ALPARAVAL.Add(ARRTO)
                ALPARAVAL.Add(CMPID)
                ALPARAVAL.Add(LOCATIONID)
                ALPARAVAL.Add(YEARID)

                OBJLEDGER.alParaval = ALPARAVAL

                DT = OBJCMN.search("NAME", "", " REGISTER ", " AND NAME ='" & NAMEARRAY(I) & "' AND ACC_CMPID  = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
                If DT.Rows.Count = 0 Then GoTo LINENEXT

                RowIndex += 1
                Write(NAMEARRAY(I), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), True, 12)
                objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)

                Write("Opening Bal : ", Range("7"), XlHAlign.xlHAlignRight, Range("7"), True, 11)
                objSheet.Range(objColumn.Item("7").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Purple)
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


                '****************** OPBAL **************************
                DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR), 0)", "", " Register_Grouped", " and name = '" & NAMEARRAY(I) & "' and acc_billdate <'" & Format(ACCFROM, "MM/dd/yyyy") & "' and acc_cmpid = " & CMPID & " and acc_LOCATIONid = " & LOCATIONID & " and YEARID = " & YEARID)


                '' ADDED BY SHOHIN, FOR ADJUSTING OPENING BALANCE
                Dim dtOPEN As System.Data.DataTable = OBJCMN.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & NAMEARRAY(I) & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
                Dim OPEN_BAL As Double
                If dtOPEN.Rows.Count > 0 Then
                    If dtOPEN.Rows(0).Item(1).ToString = "Dr." Then
                        OPEN_BAL = Val(dtOPEN.Rows(0).Item(0).ToString)
                    Else
                        OPEN_BAL = Val(dtOPEN.Rows(0).Item(0).ToString) * (-1)
                    End If
                End If


                If DT.Rows.Count > 0 Then
                    DT.Rows(0).Item(0) = Val(DT.Rows(0).Item(0)) + OPEN_BAL
                    If Val(DT.Rows(0).Item(0).ToString) < 0 Then
                        OPBAL = Val(DT.Rows(0).Item(0).ToString) * (-1)
                        OPBALDRCR = "Cr"
                    Else
                        OPBAL = Val(DT.Rows(0).Item(0).ToString)
                        OPBALDRCR = "Dr"
                    End If
                End If
LINE1:
                'THIS CODE IS WRITTEN COZ ABOVE CODE DOES NT RETRIEVE OPBAL IF DATE IS FROM 1ST DAY OF ACCOUNTING YEAR
                'DONT DELETE THIS CODE IT IS CHECKED AND WORKING FINE
                If Val(OPBAL) = 0 Then
                    DT = OBJCMN.search("ACC_OPBAL, ACC_DRCR", "", "LEDGERS", " AND ACC_CMPNAME = '" & NAMEARRAY(I) & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        OPBAL = Val(DT.Rows(0).Item(0).ToString)
                        If DT.Rows(0).Item(1).ToString = "Dr." Then
                            OPBALDRCR = "Dr"
                        Else
                            OPBALDRCR = "Cr"
                        End If
                    End If
                End If

                OPBAL = Format(Val(OPBAL), "0.00")
                Write(OPBAL & "  " & OPBALDRCR, Range("8"), XlHAlign.xlHAlignLeft, Range("9"), True, 11)
                '****************** OPBAL **************************


                DT = OBJLEDGER.getSUMMARY()
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        RowIndex += 1
                        Write(DTROW("DATE"), Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
                        Write(DTROW("HOTELNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                        Write(DTROW("GUESTNAME"), Range("4"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                        Write(DTROW("REFNO"), Range("6"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
                        Write(DTROW("Bill No"), Range("7"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                        Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                    Next

                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("1").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("3").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("5").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("6").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("7").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("8").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - (DT.Rows.Count - 1), objColumn.Item("9").ToString & RowIndex)

                    '********************CLOSING BALANCE ***************
                    RowIndex += 1
                    Write("Total", Range("1"), XlHAlign.xlHAlignRight, Range("7"), True, 11)
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Purple)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

                    TOTALDR = Format(Val(DT.Compute("SUM(DEBIT)", "")), "0.00")
                    Write(Format(Val(DT.Compute("SUM(DEBIT)", "")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, Range("8"), True, 11)
                    SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

                    TOTALCR = Format(Val(DT.Compute("SUM(CREDIT)", "")), "0.00")
                    Write(Format(Val(DT.Compute("SUM(CREDIT)", "")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, Range("9"), True, 11)
                    SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)



                    RowIndex += 1
                    Write("Closing Bal : ", Range("1"), XlHAlign.xlHAlignRight, Range("7"), True, 11)
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Purple)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
                    SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

                    If OPBALDRCR = "Dr" Then
                        CLOBAL = Format((Val(TOTALDR) + Val(OPBAL)) - Val(TOTALCR), "0.00")
                    Else
                        CLOBAL = Format(Val(TOTALDR) - (Val(TOTALCR) + Val(OPBAL)), "0.00")
                    End If

                    If CLOBAL < 0 Then
                        CLOBAL = Format(Val(CLOBAL * (-1)), "0.00")
                        CLOBALDRCR = "Cr"
                    Else
                        CLOBALDRCR = "Dr"
                    End If

                    Write(CLOBAL & "  " & CLOBALDRCR, Range("8"), XlHAlign.xlHAlignLeft, Range("9"), True, 11)
                    '********************CLOSING BALANCE ***************

                    RowIndex += 3

LINENEXT:

                End If

            Next
            'NAMEARRAY ENDS HERE

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "ANALYTICAL REPORT"

    Public Function CHART_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional ByVal HEADER As String = "", Optional ByVal FRMSTRING As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)


            If FRMSTRING = "HOTELWISE" Then
                HEADER = "HOTEL WISE CHART REPORT"
            ElseIf FRMSTRING = "CITYWISE" Then
                HEADER = "CITY WISE CHART REPORT"
            ElseIf FRMSTRING = "BOOKEDBYWISE" Then
                HEADER = "EXECUTIVE WISE CHART REPORT"
            ElseIf FRMSTRING = "MONTHWISE" Then
                HEADER = "MONTH WISE CHART REPORT"
            ElseIf FRMSTRING = "AGENTWISE" Then
                HEADER = "AGENT WISE CHART REPORT"
            ElseIf FRMSTRING = "PURWISE" Then
                HEADER = "PURCHASE AGENT WISE CHART REPORT"
            ElseIf FRMSTRING = "GUESTWISE" Then
                HEADER = "GUEST WISE CHART REPORT"
            ElseIf FRMSTRING = "TOPHOTEL" Then
                HEADER = "TOP HOTELS CHART REPORT"
            ElseIf FRMSTRING = "TOPCITY" Then
                HEADER = "TOP CITIES CHART REPORT"
            ElseIf FRMSTRING = "TOPBOOKEDBY" Then
                HEADER = "TOP EXECUTIVES CHART REPORT"
            ElseIf FRMSTRING = "TOPAGENT" Then
                HEADER = "TOP AGENTS CHART REPORT"
            ElseIf FRMSTRING = "TOPPUR" Then
                HEADER = "TOP PURCHASE AGENTS CHART REPORT"
            ElseIf FRMSTRING = "TOPGUEST" Then
                HEADER = "TOP GUESTS CHART REPORT"
            End If
            CMPHEADER(CMPID, HEADER)


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            If FRMSTRING = "HOTELWISE" Then
                Write("Hotel Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "CITYWISE" Then
                Write("City Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "BOOKEDBYWISE" Then
                Write("Executives Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "MONTHWISE" Then
                Write("Month", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "AGENTWISE" Then
                Write("Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "PURWISE" Then
                Write("Purchase Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "GUESTWISE" Then
                Write("Guest Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPHOTEL" Then
                Write("Hotel Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPCITY" Then
                Write("City Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPBOOKEDBY" Then
                Write("Executives Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPAGENT" Then
                Write("Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPPUR" Then
                Write("Purchase Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "TOPGUEST" Then
                Write("Guest Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            End If
            Write("Amount", Range("2"), XlHAlign.xlHAlignLeft, , True, 11)


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 11)
                Write(DTROW(1), Range("2"), XlHAlign.xlHAlignRight, , False, 11)
            Next
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex)

            RowIndex += 1
            Write("Total", Range("1"), XlHAlign.xlHAlignRight, , False, 11)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 7 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)

            objSheet.Range(objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()


            'GENERATING CHART
            'create chart objects
            Dim oChart As Excel.Chart
            Dim MyCharts As Excel.ChartObjects
            Dim MyCharts1 As Excel.ChartObject
            MyCharts = objSheet.ChartObjects
            'set chart location
            MyCharts1 = MyCharts.Add(215, 135, 1200, 350)
            oChart = MyCharts1.Chart
            'use the follwoing line if u want to draw chart on the default location
            'ochart.Location(Excel.XlChartLocation.xlLocationAsObject, OBJSHEET.Name)
            With oChart
                'set data range for chart
                Dim chartRange As Excel.Range
                chartRange = objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("2").ToString & RowIndex - 1)
                .SetSourceData(chartRange)
                'set how you want to draw chart i.e column wise or row wise
                .PlotBy = Excel.XlRowCol.xlColumns
                'set data lables for bars
                .ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowNone)
                'set legend to be displayed or not
                .HasLegend = False
                'set legend location if legent is true
                '.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight
                'select chart type
                '.ChartType = Excel.XlChartType.xl3DBarClustered
                'chart title
                .HasTitle = True
                .ChartTitle.Text = "Analytical Chart"
                'set titles for Axis values and categories
                Dim xlAxisCategory, xlAxisValue As Excel.Axes
                xlAxisCategory = CType(oChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = objSheet.Range(objColumn.Item("1").ToString & 7).Value
                xlAxisValue = CType(oChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisValue.Item(Excel.XlAxisType.xlValue).HasTitle = True
                xlAxisValue.Item(Excel.XlAxisType.xlValue).AxisTitle.Characters.Text = "Amount"
            End With



            objBook.Application.ActiveWindow.Zoom = 80

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PACKAGEQUOTE"
    Public Function PACKAGEQUOTE_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal QUOTATIONNO As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next





            'FIRST WE WILL CHECK THE NO OF COLUMNS
            'THEN WITH RESPECT TO THAT WE WILL DEFINE THE RANGE
            Dim TOTALCOLUMNS As Integer = 1
            Dim OBJENQ As New ClsHolidayEnquiry
            OBJENQ.alParaval.Add(QUOTATIONNO)
            OBJENQ.alParaval.Add(CMPID)
            OBJENQ.alParaval.Add(0)
            OBJENQ.alParaval.Add(YEARID)
            Dim DT As System.Data.DataTable = OBJENQ.SELECTBOOKINGDESC()
            If DT.Rows.Count > 0 Then TOTALCOLUMNS = DT.Rows.Count



            RowIndex = 1
            SetColumnWidth(Range("1"), 30)
            For I As Integer = 2 To TOTALCOLUMNS + 1
                SetColumnWidth(Range(I), 40)
            Next


            TOTALCOLUMNS = TOTALCOLUMNS + 1

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_DISPLAYEDNAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            'Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(TOTALCOLUMNS.ToString), True, 14)
            'SetBorder(RowIndex, Range("1"), Range(TOTALCOLUMNS.ToString))

            'ADD1
            RowIndex += 1
            'Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(TOTALCOLUMNS.ToString), True, 10)
            'SetBorder(RowIndex, Range("1"), Range(TOTALCOLUMNS.ToString))

            'ADD2
            'RowIndex += 1
            'Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(TOTALCOLUMNS.ToString), True, 10)
            'SetBorder(RowIndex, Range("1"), Range(TOTALCOLUMNS.ToString))

            RowIndex += 1
            Write("HOTEL QUOTATION FOR " & UCase(DT.Rows(0).Item("HOTELCITY")) & "                      BOOKING NO - " & Val(QUOTATIONNO), Range("1"), XlHAlign.xlHAlignCenter, Range(TOTALCOLUMNS.ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(TOTALCOLUMNS.ToString))


            RowIndex += 1
            Write("CHECK IN - " & DT.Rows(0).Item("ARRIVAL") & "                    CHECK OUT - " & DT.Rows(0).Item("DEPARTURE"), Range("1"), XlHAlign.xlHAlignCenter, Range(TOTALCOLUMNS.ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(TOTALCOLUMNS.ToString))


            'FREEZE TOP 5 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item(TOTALCOLUMNS.ToString).ToString & 6).Select()
            objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item(TOTALCOLUMNS.ToString).ToString & 6).Application.ActiveWindow.FreezePanes = True


            RowIndex += 1

            For I As Integer = 1 To TOTALCOLUMNS
                RowIndex = 6

                If I = 1 Then
                    Write("TRIP ADVISOR RATINGS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("HOTEL NAME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("ADDRESS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("ROOM OCCUPANCY", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("ROOM TYPE", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("ROOM RATES", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("MEAL PLAN", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("INCLUSIONS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("CHECK IN TIME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("CHECK OUT TIME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("PAYMENT MODE", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("REMARKS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("CANCELLATION POLICY", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                    Write("NOTES", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(TOTALCOLUMNS.ToString).ToString & RowIndex)
                    RowIndex += 1

                Else

                    Dim DTROW As DataRow = DT.Rows(I - 2)
                    Write(DTROW("RATING"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("HOTELNAME"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("HOTELADD"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10, True)
                    RowIndex += 1
                    If Val(DTROW("BTOTALPAX")) = 1 Then
                        Write("SINGLE OCCUPANCY", Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    ElseIf Val(DTROW("BTOTALPAX")) = 2 Then
                        Write("DOUBLE OCCUPANCY", Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    ElseIf Val(DTROW("BTOTALPAX")) = 3 Then
                        Write("TRIPLE OCCUPANCY", Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    Else
                        Write("QUADRUPLE OCCUPANCY", Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    End If
                    RowIndex += 1
                    Write(DTROW("ROOMTYPE"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("RATE"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("PLAN"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("INCLUSIONS"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("CHECKIN"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("CHECKOUT"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("CONFBY"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10)
                    RowIndex += 1
                    Write(DTROW("REMARKS"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10, True)
                    RowIndex += 1
                    Write(DTROW("POLICY"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10, True)
                    RowIndex += 1
                    Write(DTROW("NOTES"), Range(I.ToString), XlHAlign.xlHAlignLeft, , False, 10, True)
                    RowIndex += 1

                End If

            Next



            'actual running code
            'SetColumnWidth(Range("2"), 150)


            ''''''''''''Report Title
            'Dim OBJCMN As New ClsCommon
            ''CMPNAME
            'Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            'RowIndex = 2
            'Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 14)
            'SetBorder(RowIndex, Range("1"), Range("2"))

            ''ADD1
            'RowIndex += 1
            'Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            'SetBorder(RowIndex, Range("1"), Range("2"))

            ''ADD2
            'RowIndex += 1
            'Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            'SetBorder(RowIndex, Range("1"), Range("2"))

            'RowIndex += 1
            'Write("HOTEL QUOTATION", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 12)
            'SetBorder(RowIndex, Range("1"), Range("2"))


            ''FREEZE TOP 5 ROWS
            'objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("2").ToString & 6).Select()
            'objSheet.Range(objColumn.Item("1").ToString & 6, objColumn.Item("2").ToString & 6).Application.ActiveWindow.FreezePanes = True


            'SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("2").ToString & RowIndex + 1)


            'RowIndex += 1

            'Dim OBJENQ As New ClsHolidayEnquiry
            'OBJENQ.alParaval.Add(QUOTATIONNO)
            'OBJENQ.alParaval.Add(CMPID)
            'OBJENQ.alParaval.Add(0)
            'OBJENQ.alParaval.Add(YEARID)
            'Dim DT As System.Data.DataTable = OBJENQ.SELECTBOOKINGDESC()

            'For Each DTROW As DataRow In DT.Rows
            '    Write("HOTEL NAME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("HOTELNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("ADDRESS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("HOTELADD"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("ROOM OCCUPANCY", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    If Val(DTROW("NOOFROOMS")) = 1 Then
            '        Write("SINGLE OCCUPANCY", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    ElseIf Val(DTROW("NOOFROOMS")) = 2 Then
            '        Write("DOUBLE OCCUPANCY", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    Else
            '        Write("TRIPLE OCCUPANCY", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    End If
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("ROOM TYPE", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("ROOMTYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("ROOM RATES", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("RATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("MEAL PLAN", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("PLAN"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("CHECK IN TIME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("CHECKIN"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("CHECK OUT TIME", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("CHECKOUT"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("REMARKS", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("REMARKS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1

            '    Write("CANCELLATION POLICY & NOTES", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            '    Write(DTROW("POLICY"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            '    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            '    RowIndex += 1
            '    objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(213, 228, 248)
            '    RowIndex += 2
            'Next

            For I As Integer = 1 To TOTALCOLUMNS
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 6, objColumn.Item(I.ToString).ToString & RowIndex)
            Next
            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function
#End Region

#Region "GSTREPORTS"

    Public Function GSTB2B_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            If objColumn.Count = 0 Then
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next
            End If

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("5"), 17)
            SetColumnWidth(Range("6"), 17)
            SetColumnWidth(Range("10"), 17)
            SetColumnWidth(Range("11"), 10)
            SetColumnWidth(Range("12"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2B (4)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("No Of Invoices", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Invoice Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("13")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            'FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            'FORMULA("=SUMPRODUCT((" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "," & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "&""""))", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 5 & ":" & objColumn.Item("12").ToString & 40000 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 5 & ":" & objColumn.Item("13").ToString & 40000 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 3, objColumn.Item("12").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            Write("GSTIN/UIN Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Receiver Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice No", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reverse Charge", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Type", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            'THIS IS DONE ADDITIONALLY
            Write("CGST Amount", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST Amount", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST Amount", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            WHERECLAUSE = " AND SALEPUR = 'SALE'"

            'SALE(REGISTERED)
            DT = OBJCMN.search(" BILLINITIALS AS INVNO, LEDGERNAME AS NAME, BOOKINGDATE AS DATE, GSTIN, STATECODE, STATENAME AS STATE,  TAXABLEAMT, 0 AS GSTPER, GTOTAL AS GRANDTOTAL, CGSTAMT, SGSTAMT, IGSTAMT  ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " AND ISNULL(GSTIN,'') <> '' ORDER BY BOOKINGDATE, BOOKINGNO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(UCase(DTROW("NAME")), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("N", Range("7"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("Regular", Range("9"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("10"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("GSTRATE AS GSTPER", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BILLINITIALS = '" & DTROW("INVNO") & "' AND YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("13"), XlHAlign.xlHAlignRight, , False, 10)

                Write(Val(DTROW("CGSTAMT")), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("16"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ": " & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", objColumn.Item("1").ToString & 3, XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT((" & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & "&""""))", objColumn.Item("3").ToString & 3, XlHAlign.xlHAlignCenter, , True, 10)



            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 5, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 5, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 5, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 5 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("15").ToString & 5 & ":" & objColumn.Item("15").ToString & RowIndex - 1 & ")", Range("15"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("16").ToString & 5 & ":" & objColumn.Item("16").ToString & RowIndex - 1 & ")", Range("16"), XlHAlign.xlHAlignRight, , True, 10)



            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            If objColumn.Count = 0 Then
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next
            End If

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)
            SetColumnWidth(Range("8"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CL (5)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Invoices", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("8")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT(1/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&"""")," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & ")", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            RowIndex += 1
            Write("Invoice No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            WHERECLAUSE = " AND SALEPUR = 'SALE'"

            'SALE(URD)
            DT = OBJCMN.search(" BILLINITIALS AS INVNO, BOOKINGDATE AS DATE, GSTIN, STATECODE, STATENAME AS STATE, TAXABLEAMT, 0 AS GSTPER, GTOTAL AS GRANDTOTAL  ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " AND ISNULL(GSTIN,'') = '' AND ISNULL(GTOTAL, 0) > 250000 ORDER BY BOOKINGDATE, BOOKINGNO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("GSTRATE AS GSTPER", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BILLINITIALS = '" & DTROW("INVNO") & "' AND YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)


            'objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            If objColumn.Count = 0 Then
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next
            End If

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CS (7)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("6")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)



            RowIndex += 1
            Write("Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            WHERECLAUSE = " AND SALEPUR = 'SALE'"


            'SALE(URD)<250000
            'DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")

            DT = OBJCMN.search(" BILLINITIALS AS INVNO, BOOKINGDATE AS DATE, GSTIN, STATECODE, STATENAME AS STATE,  TAXABLEAMT, 0 AS GSTPER, GTOTAL AS GRANDTOTAL ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " AND ISNULL(GSTIN,'') = '' AND ISNULL(GTOTAL, 0) <= 250000 ORDER BY BOOKINGDATE, BOOKINGNO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("OE", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("GSTRATE AS GSTPER", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BILLINITIALS = '" & DTROW("INVNO") & "' AND YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)


            'objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            If objColumn.Count = 0 Then
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next
            End If

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 25)
            Next

            SetColumnWidth(Range("8"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim TEMPDT As New System.Data.DataTable

            Write("GSTIN/UIN of Recipient", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Receiver Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt Number", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt date", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher Number", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Document Type", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Voucher Value", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pre GST", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)


            'THIS IS DONE ADDITIONALLY
            Write("CGST Amount", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST Amount", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST Amount", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            DT = OBJCMN.search(" GSTIN, NAME, PRINTINITIALS, INVDATE, INITIALS AS CNINITIALS, GSTCREDITDEBITNOTE.[DATE] AS CNDATE, CASE WHEN CNDN = 'CREDITNOTE' THEN 'C' ELSE 'D' END AS DOCTYPE , CASE WHEN CNDN = 'CREDITNOTE' THEN '01-Sales Return' ELSE '07-Others' END AS REASON, STATECODE , STATENAME AS [STATE], GTOTAL AS GRANDTOTAL, ISNULL(RATE,0) AS RATE, TAXABLEAMT, CGSTAMT, SGSTAMT, IGSTAMT", "", " GSTCREDITDEBITNOTE ", " AND GSTCREDITDEBITNOTE.[DATE] >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND GSTCREDITDEBITNOTE.[DATE] <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " AND GSTIN <> '' AND CNTYPE <> 'AIRDEBITNOTE' ORDER BY GSTCREDITDEBITNOTE.[DATE], CNNO ")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("=(""" & DTROW("PRINTINITIALS") & """)", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("INVDATE")).Date, "dd-MMM-yy"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("=(""" & DTROW("CNINITIALS") & """)", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("CNDATE")).Date, "dd-MMM-yy"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DOCTYPE"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write("N", Range("14"), XlHAlign.xlHAlignLeft, , False, 10)


                Write(Val(DTROW("CGSTAMT")), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("16"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("17"), XlHAlign.xlHAlignRight, , False, 10)

            Next

            objSheet.Range(objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 2, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 2, objColumn.Item("14").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 2 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 2 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("15").ToString & 2 & ":" & objColumn.Item("15").ToString & RowIndex - 1 & ")", Range("15"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("16").ToString & 2 & ":" & objColumn.Item("16").ToString & RowIndex - 1 & ")", Range("16"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("17").ToString & 2 & ":" & objColumn.Item("17").ToString & RowIndex - 1 & ")", Range("17"), XlHAlign.xlHAlignRight, , True, 10)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNUR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            If objColumn.Count = 0 Then
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next
            End If


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 25)
            Next

            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("UR Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher Number", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher date", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Document Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt Number", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Voucher Value", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Applicable %", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pre GST", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("13")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            DT = OBJCMN.search(" GSTIN, NAME, PRINTINITIALS, INVDATE, INITIALS AS CNINITIALS, GSTCREDITDEBITNOTE.[DATE] AS CNDATE, CASE WHEN CNDN = 'CREDITNOTE' THEN 'C' ELSE 'D' END AS DOCTYPE , CASE WHEN CNDN = 'CREDITNOTE' THEN '01-Sales Return' ELSE '07-Others' END AS REASON, STATECODE , STATENAME AS [STATE], GTOTAL AS GRANDTOTAL, ISNULL(RATE,0) AS RATE, TAXABLEAMT, CGSTAMT, SGSTAMT, IGSTAMT", "", " GSTCREDITDEBITNOTE ", " AND GSTCREDITDEBITNOTE.[DATE] >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND GSTCREDITDEBITNOTE.[DATE] <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " AND GSTIN = '' AND CNTYPE <> 'AIRDEBITNOTE' ORDER BY GSTCREDITDEBITNOTE.[DATE], CNNO ")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CNINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("CNDATE")).Date, "dd-MMM-yy"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DOCTYPE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("=(""" & DTROW("PRINTINITIALS") & """)", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("INVDATE")).Date, "dd-MMM-yy"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write("N", Range("13"), XlHAlign.xlHAlignLeft, , False, 10)
            Next

            objSheet.Range(objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 2, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 2, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 2, objColumn.Item("13").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 2 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 2 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTHSN_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "", Optional ByVal SHEETNAME As String = "") As Object
        Try

            SetWorkSheetGST(SHEETNAME)
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("7"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For HSN (12)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Integrated Tax", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Central Tax", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total State/UT Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & 40000 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            RowIndex += 1
            Write("HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Description", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UQC", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Integrated Tax Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Central Tax Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("State/UT Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            WHERECLAUSE = " AND SALEPUR = 'SALE'"


            'SALE(REGISTERED)
            DT = OBJCMN.search(" HSNCODE, HSNDESC, 1 AS QTY, ROUND(SUM(GTOTAL),0) AS GRANDTOTAL, SUM(TAXABLEAMT) AS TAXABLEAMT, SUM(IGSTAMT) AS IGSTAMT, SUM(CGSTAMT) AS CGSTAMT, SUM(SGSTAMT) AS SGSTAMT ", "", " RESERVATIONDETAILS ", WHERECLAUSE & " AND BOOKINGDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BOOKINGDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & " GROUP BY HSNCODE, HSNDESC")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("HSNCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("HSNDESC"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)


                'Dim DTINV As New System.Data.DataTable
                'WE CAN NOT GET GRAND TOTAL IN ABOVE QUERY COZ THIS WIL CALC GRANDTOTAL MULTIPLE TIMES COZ WE HAVE JOIN WITH INVOICEDESC
                'BELOW CODE WASS TAKING TIME 
                'If INVOICESCREENTYPE = "LINE GST" Then
                'Else
                '    DTINV = OBJCMN.search("DISTINCT INVOICEMASTER.INVOICE_NO  ROUND(SUM(ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)),0) AS GRANDTOTAL, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) ELSE SUM(ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0)) END) AS TAXABLEAMT,", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " AND HSN_CODE = '" & DTROW("HSNCODE") & "'")
                'End If

                Write(Val(DTROW("GRANDTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGSTAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"



            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)


            'objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndCloseGST()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region



End Class
