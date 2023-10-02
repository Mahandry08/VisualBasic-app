Imports QRCoder
Public Class Qrcodepic
    Private ReadOnly urla As String

    Public Sub New(url As String)
        urla = url
    End Sub

    Private Sub generer_qrcode_Click(sender As Object, e As EventArgs) Handles generer_qrcode.Click
        Dim gen As New QRCodeGenerator
        Dim data = gen.CreateQrCode(urla, QRCodeGenerator.ECCLevel.Q)
        Dim code As New QRCode(data)
        If picbox IsNot Nothing Then
            picbox.Image = code.GetGraphic(6)
        End If
    End Sub
End Class
