''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''   Gulkit Jain                                                                                            ''
''                                                                                                          ''
''                                                                                                          ''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class DBConnection
    Private objConnection As SqlConnection


    '' -------NOTEPAD CODE --------
    Public Shared oFile As System.IO.File
    Public Shared oRead As System.IO.StreamReader = File.OpenText("C:\CONNECTIONSTRING.txt")
    Public Shared CONNECTIONSTR As String = oRead.ReadToEnd
    '' ----------------- NOTEPAD CODE---------

    ''**KHANNA TRAVELS STATIC IP**''
    ' Public Shared ConnectionString As String = "Data Source=1.186.114.131;Initial Catalog=HOSPITALITY;User ID=sa;Password=infosys123;connection timeout=2000"


    'Public Shared ConnectionString As String = "Data Source=gulkit;Initial Catalog=HOSPITALITY;User ID=sa;Password=infosys123;connection timeout=2000"

    ''*** CLASSIC HOLIDAYS ***
    Public Shared ConnectionString As String = CONNECTIONSTR

    'Public Shared ConnectionString As String = "Data Source=GULKIT;Initial Catalog=HOSPITALITY;Integrated Security=True;connect timeout=9999"
    Public Shared CurrentYear As String
    Public Shared CurrentDB As String
    'Public Shared Servername As String = "GULKIT"
   
    Public WriteOnly Property SetConnection() As String
        Set(ByVal Value As String)
            objConnection = New SqlConnection(Value)
        End Set
    End Property
    ' This Property use for get connection object 
    Public ReadOnly Property GetConnection() As SqlConnection
        Get
            Return objConnection
        End Get
    End Property

    ' This Constrator use for set connection object 
    ' Argument : Connection string
    Public Sub New(ByVal ConnectionString As String)
        Try
            SetConnection = ConnectionString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' This Constrator use for set connection object 
    ' Connection String fetch from web.config 
    Public Sub New()
        Try
            Dim ConnectionString As String = DBConnection.ConnectionString
            SetConnection = ConnectionString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' This method use for Open connection 
    Public Sub OpenConnection()
        Try
            GetConnection.Open()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' This method use for Close connection 
    Public Sub CloseConnection()
        Try
            GetConnection.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
