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

            // For this example we will use INBOX folder
            imap.SelectInbox();

            // List folder flags for INBOX
            IList<ImapFolderInfo> folders = imap.ListFolders();

            Console.WriteLine("Listing '{0}' folder flags...", imap.SelectedFolder.Name);

            foreach (string flag in imap.SelectedFolder.Flags)
                Console.WriteLine(flag);
        }
    }
}
