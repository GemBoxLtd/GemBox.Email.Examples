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
            imap.SelectInbox();

            // Search for messages whose subject contains 'Example' text.
            IList<int> messages = imap.SearchMessageNumbers("SUBJECT Example");
            Console.WriteLine($"Number of messages with 'Example' in subject: {messages.Count}");

            // Search for 'unseen' messages sent by 'sender@example.com'.
            messages = imap.SearchMessageNumbers("UNSEEN FROM sender@example.com");
            Console.WriteLine($"Number of 'unseen' messages sent by 'sender@example.com': {messages.Count}");
        }
    }
}