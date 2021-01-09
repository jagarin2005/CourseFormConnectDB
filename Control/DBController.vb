Imports MySql.Data.MySqlClient

Module DBController
    Public Conn As MySqlConnection = mysqldb()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet

    Public Function Query(ByVal str As String, ByVal tblName As String, Optional ByRef param As Dictionary(Of String, String) = Nothing) As DataSet
        If (Conn.State <> ConnectionState.Open)
            Conn.Open()
        End If
        
        Dim cmd As New MySqlCommand(str, Conn)
        Dim SQLda As New MySqlDataAdapter(cmd)
        Dim SQLrec As New DataSet

        If Not IsNothing(param) Then
            For Each kvp As KeyValuePair(Of String, String) In param
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
            Next
            param.Clear()
        End If

        SQLda.Fill(SQLrec, tblName)
        Query = SQLrec

        If (Conn.State <> ConnectionState.Closed)
            Conn.Close()
        End If
    End Function

    Public Function Command(ByVal str As String, Optional ByRef param As Dictionary(Of String, String) = Nothing) As Boolean
        If (Conn.State <> ConnectionState.Open)
            Conn.Open()
        End If
        
        Dim SQLcmd As New MySqlCommand With {
            .Connection = Conn,
            .CommandText = str
        }

        If Not IsNothing(param) Then
            For Each kvp As KeyValuePair(Of String, String) In param
                SQLcmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
            Next
            param.Clear()
        End If

        Command = SQLcmd.ExecuteNonQuery

        If (Conn.State <> ConnectionState.Closed)
            Conn.Close()
        End If
    End Function
End Module