using System;
using System.Collections.Generic;
using GemBox.Email;
using GemBox.Email.Imap;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            Console.WriteLine("Connected.");

            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // List all folders on the server
            IList<ImapFolderInfo> folders = imap.ListFolders();

            Console.WriteLine("Listing folders...");

            foreach (ImapFolderInfo info in folders)
                Console.WriteLine(" {0,18}: {1}", info.Name, string.Join(", ", info.Flags));

            // Create new folder and list all folders again
            imap.CreateFolder("GemBox");

            Console.WriteLine("Listing folders again...");

            folders = imap.ListFolders();
            foreach (ImapFolderInfo info in folders)
                Console.WriteLine(" {0,18}: {1}", info.Name, string.Join(", ", info.Flags));

            // Delete newly created folder and repeat listing
            imap.DeleteFolder("GemBox");

            Console.WriteLine("Final folder listing...");

            folders = imap.ListFolders();
            foreach (ImapFolderInfo info in folders)
                Console.WriteLine(" {0,18}: {1}", info.Name, string.Join(", ", info.Flags));
        }
    }
}
