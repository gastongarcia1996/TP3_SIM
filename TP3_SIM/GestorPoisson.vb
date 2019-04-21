Public Class GestorPoisson
    Private lambda As Double
    Private tamMuestra As Integer
    Private random As Random = New Random()

    Public Sub New(ByVal lambda As Double, ByVal tamMuestra As Integer)
        Me.lambda = lambda
        Me.tamMuestra = tamMuestra
    End Sub

    Public Function GenerarPoisson() As Integer
        Dim p As Double = 1
        Dim x As Integer = -1
        Dim a As Double = Math.Exp(-Me.lambda)
        Dim u As Double = 0.0

        Do
            u = GenerarAleatorioLenguaje()
            p = p * u
            x = x + 1
        Loop While p >= a

        Return x
    End Function

    Private Function GenerarAleatorioLenguaje() As Double
        Return Me.random.Next(1, 9999) / 10000
    End Function
End Class
