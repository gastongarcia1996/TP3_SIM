<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuNormal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_media = New System.Windows.Forms.TextBox()
        Me.txt_desvEstandar = New System.Windows.Forms.TextBox()
        Me.txt_tamMuestra = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(205, 197)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 0
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Media:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Desviación estándar:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tamaño de muestra:"
        '
        'txt_media
        '
        Me.txt_media.Location = New System.Drawing.Point(222, 40)
        Me.txt_media.Name = "txt_media"
        Me.txt_media.Size = New System.Drawing.Size(100, 20)
        Me.txt_media.TabIndex = 4
        '
        'txt_desvEstandar
        '
        Me.txt_desvEstandar.Location = New System.Drawing.Point(222, 88)
        Me.txt_desvEstandar.Name = "txt_desvEstandar"
        Me.txt_desvEstandar.Size = New System.Drawing.Size(100, 20)
        Me.txt_desvEstandar.TabIndex = 5
        '
        'txt_tamMuestra
        '
        Me.txt_tamMuestra.Location = New System.Drawing.Point(222, 135)
        Me.txt_tamMuestra.Name = "txt_tamMuestra"
        Me.txt_tamMuestra.Size = New System.Drawing.Size(100, 20)
        Me.txt_tamMuestra.TabIndex = 6
        '
        'MenuNormal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 232)
        Me.Controls.Add(Me.txt_tamMuestra)
        Me.Controls.Add(Me.txt_desvEstandar)
        Me.Controls.Add(Me.txt_media)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Name = "MenuNormal"
        Me.Text = "MenuNormal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_aceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_media As TextBox
    Friend WithEvents txt_desvEstandar As TextBox
    Friend WithEvents txt_tamMuestra As TextBox
End Class
