Public Class GestorGrafico
    Private chart As DataVisualization.Charting.Chart

    Public Sub New(ByRef chart As DataVisualization.Charting.Chart)
        Me.chart = chart
    End Sub

    Public Sub CompletarGrafico(ByVal cantIntervalos As Integer, ByVal valores() As Double)
        Me.chart.Series(0).Points.Clear()

        For i As Integer = 1 / cantIntervalos To 1.0 Step 1 / cantIntervalos
            Me.chart.Series(0).Points.AddXY("" & i, valores((i / (1 / valores.Length)) - 1))
        Next

    End Sub
End Class
