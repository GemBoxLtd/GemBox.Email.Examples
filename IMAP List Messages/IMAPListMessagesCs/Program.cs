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

            // To be able to list message, we need to select a folder first
            imap.SelectInbox();

            // Get info for all messages in INBOX
            IList<ImapMessageInfo> infoList = imap.ListMessages();

            Console.WriteLine("Listing messages for folder '{0}' ...", imap.SelectedFolder.Name);

            foreach (ImapMessageInfo info in infoList)
                Console.WriteLine("{0} - [{1}] - {2} Byte(s)", info.Number, info.Uid, info.Size);
        }
    }
}
