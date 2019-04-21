Public Class GestorExponencial
    Private lambda As Double
    Private tamMuestra As Integer
    Private random As New Random()

    Public Sub New(ByVal lambda As Double, ByVal tamMuestra As Integer)
        Me.lambda = lambda
        Me.tamMuestra = tamMuestra
    End Sub

    Public Function GenerarExponencial() As Double
        'Return -(1 / Me.lambda) * Math.Log(1 - (Math.Truncate(GenerarAleatorioLenguaje() * 10000) / 10000))
        Return Math.Truncate(-(1 / Me.lambda) * Math.Log(1 - GenerarAleatorioLenguaje()) * 10000) / 10000
    End Function

    Private Function GenerarAleatorioLenguaje() As Double
        Return Me.random.Next(1, 9999) / 10000
    End Function
End Class
