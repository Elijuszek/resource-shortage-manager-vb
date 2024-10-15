Namespace Models
    Public Enum Room
        None = 0
        MeetingRoom
        Bathroom
        Kitchen
    End Enum

    Public Enum Category
        None = 0
        Electronics
        Food
        Other
    End Enum

    Public Enum Status
        None = -1
        AlreadyExists = 0
        AddedSuccessfully = 1
        DoesNotExist = 2
        RemovedSuccessfully = 3
    End Enum
End Namespace