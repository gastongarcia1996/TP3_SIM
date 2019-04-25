Public Class GestorNormal
    Private media As Double
    Private desvEstandar As Double
    Private tamMuestra As Integer
    Private random As New Random

    Public Sub New(ByVal media As Double, ByVal desvEstandar As Double, ByVal tamMuestra As Integer)
        Me.desvEstandar = desvEstandar
        Me.media = media
        Me.tamMuestra = tamMuestra
    End Sub

    Public Function GenerarNormal() As Double
        Dim n As Double = 0.0
        Dim z As Double = 0.0

        n = Math.Sqrt(-2 * Math.Log(GenerarAleatorioLenguaje())) * Math.Cos(2 * Math.PI * GenerarAleatorioLenguaje())

        z = Me.media + (Me.desvEstandar * n)

        Return z
    End Function

    Private Function GenerarAleatorioLenguaje() As Double
        Return Me.random.Next(1, 9999) / 10000
    End Function
End Class
