Public Class Form1
    Private menuUniforme As New MenuUniforme()
    Private menuExponencial As New MenuExponencial()
    Private menuPoisson As New MenuPoisson()

    Private Sub btn_uniforme_Click(sender As Object, e As EventArgs) Handles btn_uniforme.Click
        Me.ListBox1.Items.Clear()
        Me.menuUniforme.ShowDialog()
        Dim gestorUniforme As GestorUniforme = Nothing

        If Not menuUniforme.GetConstanteA = Nothing Then
            gestorUniforme = New GestorUniforme(Me.menuUniforme.GetConstanteA(), Me.menuUniforme.GetConstanteB(), Me.menuUniforme.GetTamMuestra())

            For i As Integer = 0 To Me.menuUniforme.GetTamMuestra()
                Me.ListBox1.Items.Add(gestorUniforme.GenerarUniforme())
            Next
        End If
    End Sub

    Private Sub btn_exponencial_Click(sender As Object, e As EventArgs) Handles btn_exponencial.Click
        Me.ListBox1.Items.Clear()
        Me.menuExponencial.ShowDialog()
        Dim gestorExponencial As GestorExponencial = Nothing

        If Not menuExponencial.GetLambda = Nothing Then
            gestorExponencial = New GestorExponencial(Me.menuExponencial.GetLambda(), Me.menuExponencial.GetTamMuestra())

            For i As Integer = 0 To Me.menuExponencial.GetTamMuestra()
                Me.ListBox1.Items.Add(gestorExponencial.GenerarExponencial())
            Next
        End If
    End Sub

    Private Sub btn_poisson_Click(sender As Object, e As EventArgs) Handles btn_poisson.Click
        Me.ListBox1.Items.Clear()
        Me.menuPoisson.ShowDialog()
        Dim gestorPoisson As GestorPoisson = Nothing

        If Not Me.menuPoisson.GetLambda = Nothing Then
            gestorPoisson = New GestorPoisson(Me.menuPoisson.GetLambda(), Me.menuPoisson.GetTamMuestra())

            For i As Integer = 0 To Me.menuPoisson.GetTamMuestra()
                Me.ListBox1.Items.Add(gestorPoisson.GenerarPoisson())
            Next
        End If
    End Sub

    Private Sub btn_grafico_Click(sender As Object, e As EventArgs) Handles btn_grafico.Click

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
