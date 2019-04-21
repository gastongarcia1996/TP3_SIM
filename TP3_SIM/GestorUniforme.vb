Public Class GestorUniforme
    Private constanteA As Double
    Private constanteB As Double
    Private tamMuestra As Double
    Private random As New Random

    Public Sub New(ByVal constA As Double, ByVal constB As Double, ByVal tamMuestra As Integer)
        Me.constanteA = constA
        Me.constanteB = constB
        Me.tamMuestra = tamMuestra
    End Sub

    Public Function GenerarUniforme() As Double
        'Return Me.constanteA + (Math.Truncate(GenerarAleatorioLenguaje() * 10000) / 10000) * (Me.constanteB - Me.constanteA)
        Return Math.Truncate(Me.constanteA + GenerarAleatorioLenguaje() * (Me.constanteB - Me.constanteA) * 10000) / 10000
    End Function

    Public Function GenerarAleatorioLenguaje() As Double
        Return random.Next(1, 9999) / 10000
    End Function
End Class
