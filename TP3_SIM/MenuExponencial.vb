Public Class MenuExponencial

    Private lambda As Double
    Private tamMuestra As Integer
    Private flag As Boolean

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

    Private Sub txt_a_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lambda.KeyPress, txt_tamMuestra.KeyPress
        'Verifico que sean solo numeros en los textBox
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub LeerTextBox()
        Me.lambda = Double.Parse(Me.txt_lambda.Text)
        Me.tamMuestra = Integer.Parse(Me.txt_tamMuestra.Text)
    End Sub

    Public Function GetLambda()
        Return lambda
    End Function

    Public Function GetTamMuestra()
        Return tamMuestra
    End Function
End Class