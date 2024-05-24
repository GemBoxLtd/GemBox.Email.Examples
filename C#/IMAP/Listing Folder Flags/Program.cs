using GemBox.Email;
using GemBox.Email.Imap;
using System;
using System.Collections.Generic;

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

            // Select INBOX folder.
            imap.SelectInbox();

            // List INBOX folder flags.
            IList<ImapFolderInfo> folders = imap.ListFolders();
            foreach (string flag in imap.SelectedFolder.Flags)
                Console.WriteLine(flag);
        }
    }
}
