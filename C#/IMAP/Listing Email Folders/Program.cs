using System;
using System.Collections.Generic;
using GemBox.Email;
using GemBox.Email.Imap;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");

            // Create new folder.
            imap.CreateFolder("GemBox");

            // List all folders on the server and display their information.
            // Notice the presence of new "GemBox" folder.
            IList<ImapFolderInfo> folders = imap.ListFolders();
            foreach (ImapFolderInfo folder in folders)
                Console.WriteLine($"{folder.Name,-18}: {string.Join(", ", folder.Flags)}");

            // Delete newly created folder.
            imap.DeleteFolder("GemBox");

            Console.WriteLine(new string('-', 40));

            // Again, list folders and display their information.
            // Notice the absence of new "GemBox" folder.
            folders = imap.ListFolders();
            foreach (ImapFolderInfo folder in folders)
                Console.WriteLine($"{folder.Name,-18}: {string.Join(", ", folder.Flags)}");
        }
    }
}