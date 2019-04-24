<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btn_uniforme = New System.Windows.Forms.Button()
        Me.btn_exponencial = New System.Windows.Forms.Button()
        Me.btn_poisson = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btn_normal = New System.Windows.Forms.Button()
        Me.btn_grafico = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.lbl_numIntervalos = New System.Windows.Forms.Label()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_uniforme
        '
        Me.btn_uniforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_uniforme.Location = New System.Drawing.Point(56, 30)
        Me.btn_uniforme.Name = "btn_uniforme"
        Me.btn_uniforme.Size = New System.Drawing.Size(187, 30)
        Me.btn_uniforme.TabIndex = 0
        Me.btn_uniforme.Text = "Generador Uniforme"
        Me.btn_uniforme.UseVisualStyleBackColor = True
        '
        'btn_exponencial
        '
        Me.btn_exponencial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exponencial.Location = New System.Drawing.Point(56, 86)
        Me.btn_exponencial.Name = "btn_exponencial"
        Me.btn_exponencial.Size = New System.Drawing.Size(187, 30)
        Me.btn_exponencial.TabIndex = 1
        Me.btn_exponencial.Text = "Generador Exponencial"
        Me.btn_exponencial.UseVisualStyleBackColor = True
        '
        'btn_poisson
        '
        Me.btn_poisson.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_poisson.Location = New System.Drawing.Point(319, 86)
        Me.btn_poisson.Name = "btn_poisson"
        Me.btn_poisson.Size = New System.Drawing.Size(187, 30)
        Me.btn_poisson.TabIndex = 2
        Me.btn_poisson.Text = "Generador Poisson"
        Me.btn_poisson.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 194)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(549, 329)
        Me.ListBox1.TabIndex = 3
        '
        'btn_normal
        '
        Me.btn_normal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_normal.Location = New System.Drawing.Point(319, 30)
        Me.btn_normal.Name = "btn_normal"
        Me.btn_normal.Size = New System.Drawing.Size(187, 30)
        Me.btn_normal.TabIndex = 4
        Me.btn_normal.Text = "Generador Normal"
        Me.btn_normal.UseVisualStyleBackColor = True
        '
        'btn_grafico
        '
        Me.btn_grafico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_grafico.Location = New System.Drawing.Point(356, 562)
        Me.btn_grafico.Name = "btn_grafico"
        Me.btn_grafico.Size = New System.Drawing.Size(173, 34)
        Me.btn_grafico.TabIndex = 5
        Me.btn_grafico.Text = "Grafico"
        Me.btn_grafico.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Número de intervalos:"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(197, 143)
        Me.TrackBar1.Maximum = 4
        Me.TrackBar1.Minimum = 1
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar1.TabIndex = 7
        Me.TrackBar1.Value = 1
        '
        'lbl_numIntervalos
        '
        Me.lbl_numIntervalos.AutoSize = True
        Me.lbl_numIntervalos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_numIntervalos.Location = New System.Drawing.Point(307, 143)
        Me.lbl_numIntervalos.Name = "lbl_numIntervalos"
        Me.lbl_numIntervalos.Size = New System.Drawing.Size(19, 20)
        Me.lbl_numIntervalos.TabIndex = 8
        Me.lbl_numIntervalos.Text = "5"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 608)
        Me.Controls.Add(Me.lbl_numIntervalos)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_grafico)
        Me.Controls.Add(Me.btn_normal)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btn_poisson)
        Me.Controls.Add(Me.btn_exponencial)
        Me.Controls.Add(Me.btn_uniforme)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_uniforme As Button
    Friend WithEvents btn_exponencial As Button
    Friend WithEvents btn_poisson As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btn_normal As Button
    Friend WithEvents btn_grafico As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents lbl_numIntervalos As Label
End Class
