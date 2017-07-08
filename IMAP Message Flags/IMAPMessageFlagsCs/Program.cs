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

            // For this example we will select INBOX folder
            imap.SelectInbox();

            // Get first message flags
            IList<string> flags = imap.GetMessageFlags(1);

            Console.WriteLine("Listing message flags...");

            foreach (string flag in flags)
                Console.WriteLine(' ' + flag);

            // Add 'Draft' flag to message
            imap.AddMessageFlags(1, ImapMessageFlags.Draft);

            // List message flags again
            Console.WriteLine("Listing message flags again...");

            foreach (string flag in imap.GetMessageFlags(1))
                Console.WriteLine(' ' + flag);

            // Remove 'Draft' flag
            imap.RemoveMessageFlags(1, ImapMessageFlags.Draft);

            // Final message listing
            Console.WriteLine("Final message flags listing...");

            foreach (string flag in imap.GetMessageFlags(1))
                Console.WriteLine(' ' + flag);
        }
    }
}
