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

            imap.SelectInbox();

            // Search for messages whose subject contains string 'Text'
            IList<int> messages = imap.SearchMessageNumbers("SUBJECT Test");
            Console.WriteLine("Number of messages with 'Test' string in subject: " + messages.Count);

            // Search for 'unseen' messages sent by 'sender@example.com'
            messages = imap.SearchMessageNumbers("UNSEEN FROM sender@example.com");
            Console.WriteLine("Number of unseen messages sent by 'sender@example.com': " + messages.Count);
        }
    }
}
