Imports System.Numerics

Public Class GestorTabla
    Private tabla As DataGridView
    Private tipo As Integer
    Private datosArchivoJI() As String
    Private datosArchivoKS() As String
    Private IOArchivo As New IOArchivo

    Public Sub New(ByRef tabla As DataGridView, ByVal tipo As Integer)
        Me.tabla = tabla
        Me.tipo = tipo
    End Sub

    Public Sub CompletarTabla(ByVal numIntervalos As Integer, ByVal valMin As Double, ByVal valMax As Double, ByVal coleccion As ListBox.ObjectCollection, ByVal datosDist As Object)
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
                    'Me.tabla.Rows(i).Cells(2).Value = (1 / (aux.GetConstanteB() - aux.GetConstanteA())) * aux.GetTamMuestra()
                    Me.tabla.Rows(i).Cells(2).Value = aux.GetTamMuestra / numIntervalos
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
                    Dim primerTermino As Double = 0.0
                    Dim exponenteFormula = 0.0
                    aux = datosDist

                    If i = 0 Then
                        marcaClase = (intervalos(0) + valMin) / 2

                    Else
                        marcaClase = (intervalos(i) + intervalos(i - 1)) / 2
                    End If
                    primerTermino = (1 / (aux.GetDesvEstandar() * Math.Sqrt(2 * Math.PI)))
                    exponenteFormula = (-1 / 2) * Math.Pow((marcaClase - aux.GetMedia) / aux.GetDesvEstandar, 2)
                    Me.tabla.Rows(i).Cells(2).Value = (primerTermino * Math.Exp(exponenteFormula)) * aux.GetTamMuestra()
                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
                Case 4
                    Dim aux As MenuPoisson
                    Dim marcaClase As Double = 0.0
                    Dim poisson As Double = 0.0
                    aux = datosDist

                    If i = 0 Then
                        marcaClase = intervalos(0) + valMin / 2
                    Else
                        marcaClase = (intervalos(i) + intervalos(i - 1)) / 2
                    End If

                    'poisson = ((Math.Pow(aux.GetLambda(), marcaClase) * Math.Exp(-aux.GetLambda())) / Factorial(marcaClase)) * aux.GetTamMuestra()
                    poisson = PoissonAcum(acuAmplitud, acuAmplitud + amplitud, aux)
                    Me.tabla.Rows(i).Cells(2).Value = poisson * aux.GetTamMuestra()

                    Me.tabla.Rows(i).Cells(3).Value = Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value.ToString()
                    sumaChi += Math.Pow(Me.tabla.Rows(i).Cells(1).Value - Me.tabla.Rows(i).Cells(2).Value, 2) / Me.tabla.Rows(i).Cells(2).Value
            End Select
            acuAmplitud += amplitud
        Next
        Me.tabla.Rows(numIntervalos).Cells(3).Value = sumaChi
        ValidarChiCuadrado(numIntervalos)
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

    Private Function PoissonAcum(ByVal intInf As Integer, ByVal intSup As Integer, ByRef aux As MenuPoisson) As Double
        Dim acuPoissonSup As Double = 0.0
        Dim acuPoissonInf As Double = 0.0
        Dim fact As Double = 1.0
        Dim retorno As Double = 0.0

        For i As Integer = 0 To intSup


            For j As Integer = 0 To i
                If j = 0 Then
                    fact *= 1 / 1
                Else
                    fact *= 1 / j
                End If
            Next
            acuPoissonSup += (Math.Pow(aux.GetLambda(), i) * Math.Exp(-aux.GetLambda())) * fact
            fact = 1.0
        Next

        For i As Integer = 0 To intInf

            For j As Integer = 0 To i
                If j = 0 Then
                    fact *= 1 / 1
                Else
                    fact *= 1 / j
                End If
            Next
            acuPoissonInf += (Math.Pow(aux.GetLambda(), i) * Math.Exp(-aux.GetLambda())) * fact
            fact = 1.0
        Next
        retorno = acuPoissonSup - acuPoissonInf

        Return retorno
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

    Public Sub ValidarChiCuadrado(ByVal numIntervalos As Integer)
        Dim r As New Globalization.CultureInfo("es-ES")
        r.NumberFormat.NumberDecimalSeparator = "."

        System.Threading.Thread.CurrentThread.CurrentCulture = r

        Me.datosArchivoJI = Me.IOArchivo.LeerArchivo("C:\Users\GyM\Desktop\Facultad\Simulacion\TP3_SIM\tablaJI.txt") 'Acordarse de cambiar las rutas

        Dim valorChi = Me.tabla.Rows(numIntervalos).Cells(3).Value.ToString()
        If valorChi.CompareTo("0") <> 0 Then

            If datosArchivoJI.Contains(numIntervalos.ToString()) Then
                If Double.Parse(valorChi) < Double.Parse(datosArchivoJI.ElementAt(Array.IndexOf(datosArchivoJI, (numIntervalos - 1).ToString()) + 1), Globalization.NumberStyles.AllowDecimalPoint) Then

                    MessageBox.Show("Para " & (numIntervalos - 1).ToString() & " grados de libertad y confianza %95, el valor de chi-cuadrado es: " & Convert.ToDouble(datosArchivoJI.ElementAt(Array.IndexOf(datosArchivoJI, (numIntervalos - 1).ToString()) + 1)) &
                                    " por lo tanto se acepta la hipotesis", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.tabla.Rows(numIntervalos).Cells(3).Style.BackColor = Color.Green
                Else
                    MessageBox.Show("Para " & (numIntervalos - 1).ToString() & "grados de libertad y confianza %95, el valor de chi-cuadrado es: " & Convert.ToDouble(datosArchivoJI.ElementAt(Array.IndexOf(datosArchivoJI, numIntervalos.ToString()) + 1)) &
                                    " por lo tanto se rechaza la hipotesis", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.tabla.Rows(numIntervalos).Cells(3).Style.BackColor = Color.Red
                End If
            End If


        End If
    End Sub
End Class
