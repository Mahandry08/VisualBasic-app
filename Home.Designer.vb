<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.send_data = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'send_data
        '
        Me.send_data.BackColor = System.Drawing.Color.Silver
        Me.send_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send_data.Location = New System.Drawing.Point(103, 63)
        Me.send_data.Name = "send_data"
        Me.send_data.Size = New System.Drawing.Size(176, 57)
        Me.send_data.TabIndex = 0
        Me.send_data.Text = "SEND DATA"
        Me.send_data.UseVisualStyleBackColor = False
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(388, 189)
        Me.Controls.Add(Me.send_data)
        Me.Name = "Home"
        Me.Text = "Generation de QRCODE"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents send_data As Button
End Class
