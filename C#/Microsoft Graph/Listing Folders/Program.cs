using GemBox.Email;
using GemBox.Email.Graph;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new Graph client.
        var graphClient = new GraphClient();
        graphClient.Authenticate("<OAUTH2.0-TOKEN>");
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>");

        // Create a new folder.
        graphClient.CreateFolder("GemBox Folder");

        // List folders on the server.
        var folders = graphClient.ListFolders();

        // Print folder info.
        Console.WriteLine("Folder name".PadRight(28, ' ') + " | Items | Unread items | Children folders");
        foreach (var folder in folders)
            Console.WriteLine(
                $"{folder.Name,-28} | " +
                $"{folder.TotalCount,-5} | " +
                $"{folder.UnreadCount,-12} | " +
                $"{folder.ChildFolderCount,-16}");

        // Delete a folder.
        graphClient.DeleteFolder("GemBox Folder");
    }
}
