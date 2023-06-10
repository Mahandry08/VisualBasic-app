

Public Class Home
    Dim sql1 As String
    Dim sql2 As String
    Dim sql3 As String


    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub send_data_Click(sender As Object, e As EventArgs) Handles send_data.Click

        Dim service As New Services

        sql1 = "select max(dateetheure) as max_date_local from vente"
        sql2 = "select id_vente, id_produit, quantite, prix_totale from details_vente where id_vente in (select id from vente where dateetheure = (select max(dateetheure) from vente))"
        sql3 = "select max(dateetheure) as max_date_remote from vente"
        Try
            service.send_data_to_remote_db(sql1, sql2, sql3)


        Catch ex As Exception

        End Try
    End Sub

End Class
