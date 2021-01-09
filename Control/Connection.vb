Imports MySql.Data.MySqlClient
Module Connection
    Public Function mysqldb() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;password=;database=db_equipment;sslMode=none;Convert Zero Datetime=True")
    End Function
    Public con As MySqlConnection = mysqldb()
End Module
