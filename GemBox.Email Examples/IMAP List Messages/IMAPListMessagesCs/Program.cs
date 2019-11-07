using System;
using System.Collections.Generic;
using GemBox.Email;
using GemBox.Email.Imap;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");

            // Select INBOX folder.
            imap.SelectInbox();

            // Get information about all available messages in INBOX folder.
            IList<ImapMessageInfo> infos = imap.ListMessages();

            // Display messages information.
            foreach (ImapMessageInfo info in infos)
                Console.WriteLine($"{info.Number} - [{info.Uid}] - {info.Size} Byte(s)");
        }
    }
}