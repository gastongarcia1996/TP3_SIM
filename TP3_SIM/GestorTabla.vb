Imports System.Numerics

Public Class GestorTabla
    Private tabla As DataGridView
    Private tipo As Integer

    Public Sub New(ByRef tabla As DataGridView, ByVal tipo As Integer)
        Me.tabla = tabla
        Me.tipo = tipo
    End Sub

    Public Sub CompletarTabla(ByVal numIntervalos As Integer, ByVal valMin As Double, ByVal valMax As Double, ByVal coleccion As ListBox.ObjectCollection, ByRef datosDist As Object)
        Dim sumaChi As Double = 0.0
        Dim valores(numIntervalos - 1) As Double
        Dim amplitud = (valMax - valMin) / valores.Length
        Dim acuAmplitud As Double = valMin + amplitud
        Dim intervalos(numIntervalos - 1) As Double

        For j As Integer = 0 To numIntervalos - 1
            intervalos(j) = acuAmplitud
            acuAmplitud += amplitud
            Me.tabla.Rows.Add()
        Next
        Me.tabla.Rows.Add()
        valores = ProcesarDatos(coleccion, amplitud, valMin, valores.Length - 1)
        acuAmplitud = valMin
        For i As Integer = 0 To numIntervalos - 1
            Me.tabla.Rows(i).Cells(0).Value = "" & acuAmplitud & " - " & acuAmplitud + amplitud

            Me.tabla.Rows(i).Cells(1).Value = valores(i)

            Select Case Me.tipo
                Case 1
                    Dim aux As MenuUniforme
                    aux = datosDist
                    Me.tabla.Rows(i).Cells(2).Value = (1 / (aux.GetConstanteB() - aux.GetConstanteA())) * aux.GetTamMuestra()
                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                Case 2
                    Dim aux As MenuExponencial
                    'Dim marcaClase As Double = 0.0
                    aux = datosDist

                    If i = 0 Then
                        'marcaClase = (intervalos(0) + valMin) / 2
                        Me.tabla.Rows(i).Cells(2).Value = ((1 - Math.Exp(-aux.GetLambda() * intervalos(i))) - (1 - Math.Exp(-aux.GetLambda() * valMin))) * aux.GetTamMuestra()
                    Else
                        'marcaClase = (intervalos(i) + intervalos(i - 1)) / 2
                        Me.tabla.Rows(i).Cells(2).Value = ((1 - Math.Exp(-aux.GetLambda() * intervalos(i))) - (1 - Math.Exp(-aux.GetLambda() * intervalos(i - 1)))) * aux.GetTamMuestra()
                    End If

                    'Me.tabla.Rows(i).Cells(2).Value = (aux.GetLambda() * Math.Exp(-aux.GetLambda() * marcaClase)) * aux.GetTamMuestra()
                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                Case 3
                    Dim aux As MenuNormal
                    Dim marcaClase As Double = 0.0
                    aux = datosDist

                    If i = 0 Then
                        marcaClase = intervalos(0) + valMin / 2

                    Else
                        marcaClase = (intervalos(i) + intervalos(i - 1)) / 2
                    End If

                    'Me.tabla.Rows(i).Cells(2).Value = ((1 / aux.GetDesvEstandar() * Math.Sqrt(2 * Math.PI)) * Math.Exp((-1 / 2) * Math.Pow((marcaClase - aux.GetMedia) / aux.GetDesvEstandar, 2))) * aux.GetTamMuestra()
                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                Case 4
                    Dim aux As MenuPoisson
                    Dim marcaClase As Double = 0.0
                    aux = datosDist

                    If i = 0 Then
                        marcaClase = intervalos(0) + valMin / 2

                    Else
                        marcaClase = (intervalos(i) + intervalos(i - 1)) / 2
                    End If

                    Me.tabla.Rows(i).Cells(2).Value = ((Math.Pow(aux.GetLambda(), marcaClase) * Math.Exp(-aux.GetLambda())) / Factorial(marcaClase)) * aux.GetTamMuestra()

                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
            End Select
            acuAmplitud += amplitud
        Next
        Me.tabla.Rows(numIntervalos).Cells(3).Value = sumaChi
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

    'Private Function Factorial(ByVal x As Integer) As BigInteger
    '    Dim fact As New BigInteger(1)

    '    For i = 1 To x
    '        fact = fact * i
    '    Next

    '    Return fact
    'End Function

    Private Function Factorial(ByVal x As Integer) As UInt64
        Dim fact As UInt64 = 1

        If x = 0 Then
            Return 1
        Else
            For i = 1 To x

                fact = fact * i
            Next

        End If

        Return fact
    End Function
End Class
