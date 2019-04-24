Public Class MenuUniforme

    Private constanteA As Integer
    Private constanteB As Integer
    Private tamMuestra As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

    Private Sub txt_a_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_constanteA.KeyPress, txt_constanteB.KeyPress, txt_tamMuestra.KeyPress
        'Verifico que sean solo numeros en los textBox
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub LeerTextBox()
        Me.constanteA = Integer.Parse(Me.txt_constanteA.Text)
        Me.constanteB = Integer.Parse(Me.txt_constanteB.Text)
        Me.tamMuestra = Integer.Parse(Me.txt_tamMuestra.Text)
    End Sub

    Public Function GetConstanteA() As Integer
        Return Me.constanteA
    End Function
    Public Function GetConstanteB() As Integer
        Return Me.constanteB
    End Function
    Public Function GetTamMuestra() As Integer
        Return Me.tamMuestra
    End Function

    Private Sub MenuUniforme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
End Class