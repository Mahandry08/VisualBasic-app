Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class Services
    Dim conn_local As MySqlConnection
    Dim conn_remote As MySqlConnection
    Dim command1 As New MySqlCommand
    Dim command2 As New MySqlCommand
    Dim command3 As MySqlCommand
    Dim command4 As MySqlCommand
    Dim command5 As MySqlCommand
    Dim command6 As MySqlCommand
    Dim adapter1 As New MySqlDataAdapter
    Dim adapter2 As New MySqlDataAdapter
    Dim data_local As New DataTable
    Dim data_remote As New DataTable
    Dim insert_to_status_table_exception As String
    Dim insert_to_status_table_done As String
    Dim insert_to_vente_remote_table As String
    Dim insert_to_details_vente_remote_table As String
    Dim datetimevalue As String
    Dim urlget As String
    Dim database As New Database

    'function to modify datetime format

    Public Function changeDateTimeFormat(enter As String)

        Dim dateComponents As String() = Regex.Split(enter, "\s+")
        Dim datePart As String = dateComponents(0)
        Dim timePart As String = dateComponents(1)

        Dim dateComponents2 As String() = datePart.Split("/")
        Dim convertedDate As String = $"{dateComponents2(2)}-{dateComponents2(1)}-{dateComponents2(0)}"

        Dim convertedDateTime As String = $"{convertedDate} {timePart}"

        Return convertedDateTime

    End Function

    'function to retrieve data from local database
    Public Function retrieve_data_from_local_db(select_local_query As String)
        Try
            conn_local = database.connect_mysql_local_database()
            command1.Connection = conn_local
            command1.CommandText = select_local_query
            adapter1.SelectCommand = command1
            adapter1.Fill(data_local)

        Catch ex As Exception
            Console.WriteLine("This is the problem in retrieve local data function ==== " & ex.Message)

        End Try

        Return data_local

    End Function

    'function to retrieve data from remote database
    Public Function retrieve_data_from_remote_db(select_remote_query As String)
        Try
            conn_remote = database.connect_mysql_remote_database()
            command2.Connection = conn_remote
            command2.CommandText = select_remote_query
            adapter2.SelectCommand = command2
            adapter2.Fill(data_remote)

        Catch ex As Exception
            Console.WriteLine("This is the problem in retrieve remote data function ==== " & ex.Message)

        End Try

        Return data_remote

    End Function

    'function to send url to qrcode windows'

    Public Sub sendUrl(url As String)
        Dim gen As New Qrcodepic(url)
        gen.Show()
    End Sub




    'function to send data to remote db with constraints
    Public Sub send_data_to_remote_db(select_local_query1 As String, select_local_query2 As String, select_remote_query As String)

        Try
            'retrieve data from local database'

            Dim result1 As DataTable = retrieve_data_from_local_db(select_local_query1)

            Dim result2 As DataTable = retrieve_data_from_local_db(select_local_query2)



            'retrieve data from remote database'
            Dim result3 As DataTable = retrieve_data_from_remote_db(select_remote_query)

            'condition to insert or not data to remote database'
            'Testing if there is duplicated date while the program is saving data to remote server'
            If result1.Rows.Count > 0 Then
                For i As Integer = 0 To result1.Rows.Count
                    datetimevalue = changeDateTimeFormat(result1.Rows(i).Item("max_date_local"))
                    insert_to_vente_remote_table = "INSERT INTO vente(dateetheure) VALUES ('" & datetimevalue & "')"
                    insert_to_status_table_exception = "INSERT INTO status_table(status_code) VALUES (0)"
                    insert_to_status_table_done = "INSERT INTO status_table(status_code) VALUES (1)"
                    command3 = New MySqlCommand(insert_to_vente_remote_table, conn_remote)
                    command5 = New MySqlCommand(insert_to_status_table_exception, conn_local)
                    command6 = New MySqlCommand(insert_to_status_table_done, conn_local)
                    If result3.Rows.Count > 0 Then
                        For j As Integer = 0 To result3.Rows.Count

                            If result1.Rows(i).Item("max_date_local") < result3.Rows(j).Item("max_date_remote") Or result1.Rows(i).Item("max_date_local") = result3.Rows(j).Item("max_date_remote") Then
                                MessageBox.Show("L'insertion n'est pas possible")
                                Console.WriteLine("Tsy mety ilay insertion")
                                command5.ExecuteNonQuery()
                            Else

                                command3.ExecuteNonQuery()
                                Console.WriteLine("**** Nety ilay insertion anah vente ****")

                                If result2.Rows.Count > 0 Then
                                    result2.Rows.RemoveAt(0)
                                    Console.WriteLine(result2.Rows.Count)
                                    Console.WriteLine("Voalohany = " & result2.Rows(0).Item("id_produit"))
                                    Console.WriteLine("Faharoa = " & result2.Rows(1).Item("id_produit"))
                                    For k As Integer = 0 To result2.Rows.Count - 1
                                        insert_to_details_vente_remote_table = "INSERT INTO details_vente (id_vente,id_produit, quantite, prix_totale) VALUES 
                                                                        (
                                                                        '" & result2.Rows(k).Item("id_vente") & "', 
                                                                        '" & result2.Rows(k).Item("id_produit") & "',
                                                                        '" & result2.Rows(k).Item("quantite") & "',
                                                                        '" & result2.Rows(k).Item("prix_totale") & "'
                                                                        )"

                                        command4 = New MySqlCommand(insert_to_details_vente_remote_table, conn_remote)
                                        command4.ExecuteNonQuery()
                                    Next
                                    urlget = "https://idvente='" & result2.Rows(0).Item("id_vente") & "'/dateetheure='" & datetimevalue & "' "
                                    Console.WriteLine("Url généré = " & urlget)
                                    Console.WriteLine("**** Nety ilay insertion anah details vente ****")
                                    MessageBox.Show("Insertion done")
                                    command6.ExecuteNonQuery()

                                    'generate qr code'
                                    sendUrl(urlget)
                                Else
                                    Console.WriteLine("Aucune données")
                                End If


                            End If

                        Next
                    End If


                Next
            Else
                MessageBox.Show("Il n'existe aucune donnée")
            End If


        Catch ex As Exception
            Console.WriteLine("This is the problem in execution function ==== " & ex.Message)
        End Try

    End Sub


End Class
