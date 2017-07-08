using System;
using System.Globalization;
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

            // Select INBOX folder
            imap.SelectInbox();

            // Download message with sequence number 1 (first one) and list its properties
            MailMessage message = imap.GetMessage(1);
            Console.WriteLine("Listing message 1...");
            Console.WriteLine();

            Console.WriteLine("------------------ HEADERS ---------------");
            Console.WriteLine("From   : " + message.From.ToString());
            Console.WriteLine("To     : " + message.To.ToString());
            Console.WriteLine("Date   : " + message.Date.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine("Subject: " + message.Subject);
            Console.WriteLine("------------------- BODY -----------------");
            Console.WriteLine(message.BodyText);
            Console.WriteLine("------------------- END ------------------");

            // Save second message on server to file without parsing it
            imap.SaveMessage(2, "Message2.eml");

            Console.WriteLine();
            Console.WriteLine("Message 2 saved.");
        }
    }
}
