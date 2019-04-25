Public Class MenuPoisson

    Private lambda As Double
    Private tamMuestra As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not VerificarTextBox() Then
            LeerTextBox()
        End If

        Me.Hide()
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

    Private Sub txt_a_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lambda.KeyPress
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
        Me.lambda = Double.Parse(Me.txt_lambda.Text)
        Me.tamMuestra = Integer.Parse(Me.txt_tamMuestra.Text)
    End Sub

    Public Function GetLambda() As Double
        Return Me.lambda
    End Function

    Public Function GetTamMuestra() As Integer
        Return Me.tamMuestra
    End Function

    Private Sub MenuPoisson_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
End Class