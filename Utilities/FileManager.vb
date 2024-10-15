Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports ResourceShortageManager.Models

Namespace Utilities

    Public NotInheritable Class FileManager
        Public Shared ReadOnly SerializerOptions As JsonSerializerOptions = New JsonSerializerOptions With {
            .WriteIndented = True
            }
        Shared Sub New()
            SerializerOptions.Converters.Add(New JsonStringEnumConverter())
        End Sub

        Public Shared Function DeserializeShortages(filePath As String) As Dictionary(Of String, Shortage)
            If Not File.Exists(filePath) Then
                Return New Dictionary(Of String, Shortage)()
            End If

            Using fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using reader As New StreamReader(fileStream)
                    Dim json As String = reader.ReadToEnd()
                    Dim shortages As Dictionary(Of String, Shortage) = JsonSerializer.Deserialize(Of Dictionary(Of String, Shortage))(json, SerializerOptions)
                    If shortages Is Nothing Then
                        Return New Dictionary(Of String, Shortage)()
                    End If

                    Return shortages
                End Using
            End Using
        End Function

        Public Shared Sub SerializeShortages(filePath As String, shortages As Dictionary(Of String, Shortage))
            Dim json As String = JsonSerializer.Serialize(shortages, SerializerOptions)

            Using fileStream As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
                Using writer As New StreamWriter(fileStream)
                    writer.Write(json)
                End Using
            End Using
        End Sub
    End Class
End Namespace
