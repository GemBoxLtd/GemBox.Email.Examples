using System;
using GemBox.Email;
using GemBox.Email.Exchange;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new Exchange client.
        var exchangeClient = new ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)");
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>");

        // Create a new folder.
        exchangeClient.CreateFolder("GemBox Folder");

        // List folders on the server.
        var folders = exchangeClient.ListFolders();

        // Print folder info.
        Console.WriteLine("Folder name".PadRight(28, ' ') + " | Items | Unread items | Children folders");
        foreach (ExchangeFolderInfo folder in folders)
            Console.WriteLine(
                $"{folder.Name,-28} | " +
                $"{folder.TotalCount,-5} | " +
                $"{folder.UnreadCount,-12} | " +
                $"{folder.ChildFolderCount,-16}");

        // Delete a folder.
        exchangeClient.DeleteFolder("GemBox Folder", false);
    }
}