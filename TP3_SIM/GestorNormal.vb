Public Class GestorNormal
    Private desvEstandar As Double
    Private media As Double
    Private tamMuestra As Integer

    Public Sub New(ByVal desvEstandar As Double, ByVal media As Double, ByVal tamMuestra As Integer)
        Me.desvEstandar = desvEstandar
        Me.media = media
        Me.tamMuestra = tamMuestra
    End Sub

    Public Function GenerarNormal() As Double

    End Function

    Public Function GetDesvEstandar() As Double
        Return Me.desvEstandar
    End Function
    Public Function GetMedia() As Double
        Return Me.media
    End Function
    Public Function GetTamMuestra() As Integer
        Return Me.tamMuestra
    End Function
End Class
