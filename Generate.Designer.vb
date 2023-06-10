<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Qrcodepic
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picbox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.generer_qrcode = New System.Windows.Forms.Button()
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picbox
        '
        Me.picbox.BackColor = System.Drawing.Color.White
        Me.picbox.Location = New System.Drawing.Point(79, 48)
        Me.picbox.Name = "picbox"
        Me.picbox.Size = New System.Drawing.Size(178, 184)
        Me.picbox.TabIndex = 0
        Me.picbox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 261)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(302, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Scanner ce QRCode pour obtenir les informations"
        '
        'generer_qrcode
        '
        Me.generer_qrcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generer_qrcode.Location = New System.Drawing.Point(115, 307)
        Me.generer_qrcode.Name = "generer_qrcode"
        Me.generer_qrcode.Size = New System.Drawing.Size(97, 29)
        Me.generer_qrcode.TabIndex = 2
        Me.generer_qrcode.Text = "GENERER"
        Me.generer_qrcode.UseVisualStyleBackColor = True
        '
        'Qrcodepic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 384)
        Me.Controls.Add(Me.generer_qrcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picbox)
        Me.Name = "Qrcodepic"
        Me.Text = "Generer"
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents generer_qrcode As Button
    Public WithEvents picbox As PictureBox
End Class
