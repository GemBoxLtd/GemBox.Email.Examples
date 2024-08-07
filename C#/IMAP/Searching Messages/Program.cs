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
            imap.SelectInbox();

            // Search for messages whose subject contains 'Example' text.
            IList<int> messageNumbers = imap.SearchMessageNumbers("SUBJECT Example");
            Console.WriteLine($"Number of messages with 'Example' in subject: {messageNumbers.Count}");

            // Search for 'unseen' messages sent by 'sender@example.com'.
            messageNumbers = imap.SearchMessageNumbers("UNSEEN FROM sender@example.com");
            Console.WriteLine($"Number of 'unseen' messages sent by 'sender@example.com': {messageNumbers.Count}");

            // Search for messages between the specified date.
            var fromDate = new DateTime(2019, 1, 1);
            var toDate = new DateTime(2020, 1, 1);
            messageNumbers = imap.SearchMessageNumbers($"SINCE {fromDate:d-MMM-yyyy} BEFORE {toDate:d-MMM-yyyy}");
            Console.WriteLine($"Number of messages within specified date: {messageNumbers.Count}");
        }
    }
}
