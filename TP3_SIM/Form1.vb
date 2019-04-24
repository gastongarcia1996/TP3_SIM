Public Class Form1
    Private menuUniforme As New MenuUniforme()
    Private menuExponencial As New MenuExponencial()
    Private menuPoisson As New MenuPoisson()
    Private grafico As New Grafico()
    Private valMax As Double = 0.0
    Private valMin As Double = 0.0

    Private Sub btn_uniforme_Click(sender As Object, e As EventArgs) Handles btn_uniforme.Click
        Dim aux As Double = 0.0
        Dim flag As Boolean = True
        Me.valMax = 0.0
        Me.valMin = 0.0
        Me.ListBox1.Items.Clear()
        Me.menuUniforme.ShowDialog()
        Dim gestorUniforme As GestorUniforme = Nothing

        If Not menuUniforme.GetConstanteA = Nothing Then
            gestorUniforme = New GestorUniforme(Me.menuUniforme.GetConstanteA(), Me.menuUniforme.GetConstanteB(), Me.menuUniforme.GetTamMuestra())

            For i As Integer = 0 To Me.menuUniforme.GetTamMuestra()
                aux = gestorUniforme.GenerarUniforme()

                If flag = True Then
                    Me.valMin = aux
                End If

                If aux > Me.valMax Then
                    Me.valMax = aux
                End If

                If aux < Me.valMin Then
                    Me.valMin = aux
                End If
                Me.ListBox1.Items.Add(aux)
                flag = False
            Next
        End If
    End Sub

    Private Sub btn_exponencial_Click(sender As Object, e As EventArgs) Handles btn_exponencial.Click
        Dim aux As Double = 0.0
        Dim aux2 As Double = 0.0
        Dim flag As Boolean = True
        Me.valMax = 0.0
        Me.valMin = 0.0
        Me.ListBox1.Items.Clear()
        Me.menuExponencial.ShowDialog()
        Dim gestorExponencial As GestorExponencial = Nothing

        If Not menuExponencial.GetLambda = Nothing Then
            gestorExponencial = New GestorExponencial(Me.menuExponencial.GetLambda(), Me.menuExponencial.GetTamMuestra())

            For i As Integer = 0 To Me.menuExponencial.GetTamMuestra()
                aux = gestorExponencial.GenerarExponencial()
                If flag = True Then
                    Me.valMin = aux
                End If

                If aux > Me.valMax Then
                    Me.valMax = aux
                End If

                If aux < Me.valMin Then
                    Me.valMin = aux
                End If
                Me.ListBox1.Items.Add(aux)
                flag = False
            Next
        End If
    End Sub

    Private Sub btn_poisson_Click(sender As Object, e As EventArgs) Handles btn_poisson.Click
        Dim aux As Integer = 0
        Dim flag As Boolean = True
        Me.valMax = 0.0
        Me.valMin = 0.0
        Me.ListBox1.Items.Clear()
        Me.menuPoisson.ShowDialog()
        Dim gestorPoisson As GestorPoisson = Nothing

        If Not Me.menuPoisson.GetLambda = Nothing Then
            gestorPoisson = New GestorPoisson(Me.menuPoisson.GetLambda(), Me.menuPoisson.GetTamMuestra())

            For i As Integer = 0 To Me.menuPoisson.GetTamMuestra()
                aux = gestorPoisson.GenerarPoisson()
                If flag = True Then
                    Me.valMin = aux
                End If

                If aux > Me.valMax Then
                    Me.valMax = aux
                End If

                If aux < Me.valMin Then
                    Me.valMin = aux
                End If
                Me.ListBox1.Items.Add(aux)
                flag = False
            Next
        End If
    End Sub

    Private Sub btn_grafico_Click(sender As Object, e As EventArgs) Handles btn_grafico.Click
        If Me.ListBox1.Items.Count = 0 Then
            MessageBox.Show("No se generaron numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Dim gestorGrafico As New GestorGrafico(Me.grafico.Chart1)

            gestorGrafico.CompletarGrafico(Integer.Parse(lbl_numIntervalos.Text), Me.valMin, Me.valMax, Me.ListBox1.Items)

            Me.grafico.Show()
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        If Me.TrackBar1.Value = 1 Then
            Me.lbl_numIntervalos.Text = 3

        ElseIf Me.TrackBar1.Value = 2 Then
            Me.lbl_numIntervalos.Text = 5

        ElseIf Me.TrackBar1.Value = 3 Then
            Me.lbl_numIntervalos.Text = 7

        Else
            Me.lbl_numIntervalos.Text = 10
        End If
    End Sub
End Class
