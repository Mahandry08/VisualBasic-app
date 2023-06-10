Imports MySql.Data.MySqlClient

Public Class Database
    Dim conn As MySqlConnection

    'Connect to remote mysql database function
    Public Function connect_mysql_remote_database()
        conn = New MySqlConnection

        conn.ConnectionString = "server=borsxwiezfcrxqvq1tyb-mysql.services.clever-cloud.com;
                                userid=ukq3g0pwco5zd50a;
                                password=cWlTWdaigHjjwImqo4FK;
                                database=borsxwiezfcrxqvq1tyb"
        Try
            conn.Open()
            Console.WriteLine("Remote database connected")
        Catch ex As Exception
            Console.WriteLine("Remote database not connected" & ex.Message)
        End Try

        Return conn
    End Function

    'Connect to local mysql database function
    Public Function connect_mysql_local_database()
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;
                                 userid=root;
                                 password=root;
                                 database=locale_server"
        Try
            conn.Open()
            Console.WriteLine("Local database connected")
        Catch ex As Exception
            Console.WriteLine("Local database not connected" & ex.Message)
        End Try

        Return conn
    End Function



End Class
