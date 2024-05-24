Imports System
Imports GemBox.Email
Imports GemBox.Email.Exchange

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Exchange client.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>")

        ' Create a new folder.
        exchangeClient.CreateFolder("GemBox Folder")

        ' List folders on the server.
        Dim folders = exchangeClient.ListFolders()

        ' Print folder info.
        Console.WriteLine("Folder name".PadRight(28, " "c) + " | Items | Unread items | Children folders")
        For Each folder As ExchangeFolderInfo In folders
            Console.WriteLine(
                $"{folder.Name,-28} | " +
                $"{folder.TotalCount,-5} | " +
                $"{folder.UnreadCount,-12} | " +
                $"{folder.ChildFolderCount,-16}")
        Next

        ' Delete a folder.
        exchangeClient.DeleteFolder("GemBox Folder", False)

    End Sub
End Module