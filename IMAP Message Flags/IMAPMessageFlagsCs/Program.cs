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

            // Add "Draft" flag to first message.
            imap.AddMessageFlags(1, ImapMessageFlags.Draft);

            // Get first message flags and display them.
            // Notice the presence of "Draft" flag.
            IList<string> flags = imap.GetMessageFlags(1);
            foreach (string flag in flags)
                Console.WriteLine(flag);

            // Remove "Draft" flag from first message.
            imap.RemoveMessageFlags(1, ImapMessageFlags.Draft);

            Console.WriteLine(new string('-', 10));

            // Again, get first message flags and display them.
            // Notice the absence of "Draft" flag.
            flags = imap.GetMessageFlags(1);
            foreach (string flag in flags)
                Console.WriteLine(flag);
        }
    }
}