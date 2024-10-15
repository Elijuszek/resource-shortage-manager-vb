Imports System.Text.RegularExpressions

Namespace Models
    Public Class Shortage
        Public Property Title As String
        Public Property Name As String
        Public Property Room As Room
        Public Property Category As Category
        Public Property Priority As Integer
        Public Property CreatedOn As DateTime = DateTime.Now

        Public Overrides Function ToString() As String
            Return String.Format("| {0,-25} | {1,-10} | {2,-15} | {3,-12} | {4,-8} | {5,-25} |",
            Title, Name, Room, Category, Priority, CreatedOn.ToString("yyyy-MM-dd h:mm:ss tt"))
        End Function

        Public Function MakeKey() As String
            Return NormalizeString(Title).ToLower() + Room.ToString().ToLower
        End Function

        Public Shared Function MakeKey(title As String, room As Room)

            Return New String(NormalizeString(title) + room.ToString().ToLower())
        End Function

        Public Shared Function NormalizeString(str As String) As String
            Return Regex.Replace(str.Trim(), "\s+", "")
        End Function
    End Class
End Namespace