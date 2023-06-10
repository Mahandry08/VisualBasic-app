Imports QRCoder
Public Class Qrcodepic
    Private ReadOnly urla As String

    Public Sub New(url As String)
        urla = url
    End Sub

    Private Sub qrcodepic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim gen As New QRCodeGenerator
        Dim data = gen.CreateQrCode(urla, QRCodeGenerator.ECCLevel.Q)
        Dim code As New QRCode(data)
        If picbox IsNot Nothing Then
            picbox.Image = code.GetGraphic(6)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class