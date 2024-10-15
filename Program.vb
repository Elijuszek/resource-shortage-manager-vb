Imports System
Imports System.IO
Imports ResourceShortageManager.Utilities
Imports ResourceShortageManager.Models
Module Program
    Sub Main(args As String())
        Dim path As String = "..\..\..\shortages.json"
        'Dim username As String = PrintManager.PromptInput("Enter your username")

        'If username Is Nothing Then
        '    Console.WriteLine("Exiting...")
        '    Return
        'End If

        Dim shortages As Dictionary(Of String, Shortage) = FileManager.DeserializeShortages(path)

        PrintShortages(shortages)

    End Sub

    Public Sub PrintShortages(shortages As Dictionary(Of String, Shortage))
        Console.WriteLine(New String("-"c, 100))
        Console.WriteLine("| {0,-25} | {1,-10} | {2,-15} | {3,-12} | {4,-8} | {5,-25} |", "Title", "Name", "Room", "Category", "Priority", "Created On")
        Console.WriteLine(New String("-"c, 100))
        For Each shortage As Shortage In shortages.Values
            Console.WriteLine(shortage.ToString())
        Next
        Console.WriteLine(New String("-"c, 100))
    End Sub
End Module
