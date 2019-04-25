Public Class MenuNormal
    Private media As Double
    Private desvEstandar As Double
    Private tamMuestra As Integer

    Private Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        If Not VerificarTextBox() Then
            LeerTextBox()

            Me.Hide()
        End If
    End Sub

    Private Function VerificarTextBox() As Boolean
        Dim aux As TextBox
        For Each controlesForm In Me.Controls
            If (TypeOf controlesForm Is TextBox) Then
                aux = controlesForm
                If aux.Text Is "" Then
                    MessageBox.Show("Complete los parametros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub txt_a_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_media.KeyPress, txt_tamMuestra.KeyPress
        'Verifico que sean solo numeros en los textBox
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_a_KeyPressTamMuestra(sender As Object, e As KeyPressEventArgs) Handles txt_tamMuestra.KeyPress
        'Verifico que sean solo numeros en los textBox
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub LeerTextBox()
        Me.media = Double.Parse(Me.txt_media.Text, Globalization.CultureInfo.InvariantCulture)
        Me.desvEstandar = Double.Parse(Me.txt_desvEstandar.Text, Globalization.CultureInfo.InvariantCulture)
        Me.tamMuestra = Integer.Parse(Me.txt_tamMuestra.Text)
    End Sub

    Public Function GetMedia()
        Return Me.media
    End Function

    Public Function GetDesvEstandar()
        Return Me.desvEstandar
    End Function

    Public Function GetTamMuestra()
        Return Me.tamMuestra
    End Function
End Class