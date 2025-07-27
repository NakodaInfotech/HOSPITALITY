Imports DB

Public Class ClsRegistrationMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_REGISTRATIONMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@REGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPSTRENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALSEATS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOFCHK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VISA", alParaval(I)))
                I = I + 1

                ''PURCHASE PKG AMT
                .Add(New SqlClient.SqlParameter("@PURPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPKGINFANT", alParaval(I)))
                I = I + 1

                ''ADDITIONAL SERVICE AMT
                .Add(New SqlClient.SqlParameter("@PURADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDINFANT", alParaval(I)))
                I = I + 1


                ''PURCHASE TOTAL WITH AD SERVICE AMT
                .Add(New SqlClient.SqlParameter("@PURTOTALADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTOTALCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTOTALINFANT", alParaval(I)))
                I = I + 1

                ''SALE DECLARE PKG
                .Add(New SqlClient.SqlParameter("@SALEPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEPKGINFANT", alParaval(I)))
                I = I + 1

                ''AS PER CUSTOMER FINALIZATION
                .Add(New SqlClient.SqlParameter("@CUSTADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTINFANT", alParaval(I)))
                I = I + 1

                ''CUSTOMER TAKEN ADDITIONAL SERVICES AMT
                .Add(New SqlClient.SqlParameter("@SALEADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEADDINFANT", alParaval(I)))
                I = I + 1

                ''CUSTOMER FINALISE AMT + ADD SERVICES
                .Add(New SqlClient.SqlParameter("@SALETOTALADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETOTALCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETOTALINFANT", alParaval(I)))
                I = I + 1

                ''ADD SERVICES TOTAL
                .Add(New SqlClient.SqlParameter("@ADDSERVADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVINFANT", alParaval(I)))
                I = I + 1

                ''PROFFIT AND GRAND TOTAL
                .Add(New SqlClient.SqlParameter("@PROFFIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PERSONTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CORDINATOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MEALPLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURCHASEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1



                ''COMPANY DATA
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTINR", alParaval(I)))
                I = I + 1

                ''GRID GIFT
                .Add(New SqlClient.SqlParameter("@GIFTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTRATE", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTREG() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_REGISTRATIONMASTER"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function update() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_BOOKING_REGISTRATIONMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@REGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOURNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRPSTRENGTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALSEATS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STARTDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GUESTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOFCHK", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@VISA", alParaval(I)))
                I = I + 1

                ''PURCHASE PKG AMT
                .Add(New SqlClient.SqlParameter("@PURPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURPKGINFANT", alParaval(I)))
                I = I + 1

                ''ADDITIONAL SERVICE AMT
                .Add(New SqlClient.SqlParameter("@PURADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURADDINFANT", alParaval(I)))
                I = I + 1


                ''PURCHASE TOTAL WITH AD SERVICE AMT
                .Add(New SqlClient.SqlParameter("@PURTOTALADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTOTALCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURTOTALINFANT", alParaval(I)))
                I = I + 1

                ''SALE DECLARE PKG
                .Add(New SqlClient.SqlParameter("@SALEPKGADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEPKGCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEPKGINFANT", alParaval(I)))
                I = I + 1

                ''AS PER CUSTOMER FINALIZATION
                .Add(New SqlClient.SqlParameter("@CUSTADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTINFANT", alParaval(I)))
                I = I + 1

                ''CUSTOMER TAKEN ADDITIONAL SERVICES AMT
                .Add(New SqlClient.SqlParameter("@SALEADDADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEADDCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEADDINFANT", alParaval(I)))
                I = I + 1

                ''CUSTOMER FINALISE AMT + ADD SERVICES
                .Add(New SqlClient.SqlParameter("@SALETOTALADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETOTALCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALETOTALINFANT", alParaval(I)))
                I = I + 1

                ''ADD SERVICES TOTAL
                .Add(New SqlClient.SqlParameter("@ADDSERVADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVCHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDSERVINFANT", alParaval(I)))
                I = I + 1

                ''PROFFIT AND GRAND TOTAL
                .Add(New SqlClient.SqlParameter("@PROFFIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PERSONTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CORDINATOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MEALPLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DECREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPURCHASEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICECHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1


                ''COMPANY DATA
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                ''GRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADULT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADULTINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHILDINR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INFANTINR", alParaval(I)))
                I = I + 1

                ''GRID GIFT
                .Add(New SqlClient.SqlParameter("@GIFTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GIFTRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REGNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable
        Dim DTTABLE As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_BOOKING_REGISTRATIONMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))

            End With
            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
