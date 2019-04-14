Imports System.IO


Public Class IOArchivo
    Public Function LeerArchivo(nombreArchivo As String) As String()

        Dim datos() As String
        Dim linea As String = ""
        Dim texto As String = ""
        ':::Creamos nuestro objeto de tipo StreamReader que nos permite leer archivos
        Dim leer As New StreamReader(nombreArchivo)

        Try
            ':::Indicamos mediante un While que mientras no sea el ultimo caracter repita el proceso

            ':::Leemos cada linea del archivo TXT

            linea = leer.ReadToEnd()

            While Not linea Is ""

                texto = linea

                linea = leer.ReadToEnd()
            End While

            Dim separators() As String = {" ", vbCrLf}


            datos = texto.Split(separators, StringSplitOptions.RemoveEmptyEntries)

            leer.Close()
        Catch ex As Exception
            MessageBox.Show("Error al leer el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return datos
    End Function
End Class
