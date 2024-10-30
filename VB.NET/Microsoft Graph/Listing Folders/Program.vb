Imports GemBox.Email
Imports GemBox.Email.Graph
Imports System

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Graph client.
        Dim graphClient = New GraphClient()
        graphClient.Authenticate("<OAUTH2.0-TOKEN>")
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>")

        ' Create a new folder.
        graphClient.CreateFolder("GemBox Folder")

        ' List folders on the server.
        Dim folders = graphClient.ListFolders()

        ' Print folder info.
        Console.WriteLine("Folder name".PadRight(28, " "c) & " | Items | Unread items | Children folders")
        For Each folder In folders
            Console.WriteLine(
                $"{folder.Name,-28} | " +
                $"{folder.TotalCount,-5} | " +
                $"{folder.UnreadCount,-12} | " +
                $"{folder.ChildFolderCount,-16}")
        Next

        ' Delete a folder.
        graphClient.DeleteFolder("GemBox Folder")
    End Sub
End Module
