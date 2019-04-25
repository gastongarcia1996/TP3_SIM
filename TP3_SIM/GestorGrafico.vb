Public Class GestorGrafico
    Private chart As DataVisualization.Charting.Chart

    Public Sub New(ByRef chart As DataVisualization.Charting.Chart)
        Me.chart = chart
    End Sub

    Public Sub CompletarGrafico(ByVal numIntervalos As Integer, ByVal valMin As Double, ByVal valMax As Double, ByVal coleccion As ListBox.ObjectCollection)
        Me.chart.Series(0).Points.Clear()
        Dim valores(numIntervalos - 1) As Double
        Dim amplitud = (valMax - valMin) / valores.Length
        Dim acuAmplitud As Double = valMin

        'For i As Integer = 1 / valores.Length To 1.0 Step 1 / valores.Length
        '    acuAmplitud += amplitud
        '    Me.chart.Series(0).Points.AddXY("" & acuAmplitud, valores((i / (1 / valores.Length)) - 1))
        'Next

        valores = ProcesarDatos(coleccion, amplitud, valMin, valores.Length - 1)

        For i As Integer = 0 To valores.Length - 1
            acuAmplitud += amplitud
            Me.chart.Series(0).Points.AddXY("" & acuAmplitud, valores(i))
        Next

    End Sub

    Private Function ProcesarDatos(ByVal coleccion As ListBox.ObjectCollection, ByVal amplitud As Double, ByVal valMin As Double, ByVal numIntervalos As Integer) As Double()
        Dim valores(numIntervalos) As Double
        Dim aux As Double = 0.0
        Dim acuAmplitud As Double = valMin + amplitud

        For i As Integer = 0 To coleccion.Count - 1

            aux = Double.Parse(coleccion(i))

            For j As Integer = 0 To valores.Length - 1
                If aux > acuAmplitud Then
                    acuAmplitud += amplitud

                Else
                    valores(j) += 1

                    Exit For
                End If
            Next

            acuAmplitud = valMin + amplitud
        Next
        Return valores
    End Function
End Class
