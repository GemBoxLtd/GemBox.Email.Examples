using System;
using GemBox.Email;
using GemBox.Email.Imap;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new IMAP client.
        using (var imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            // By default the connect timeout is 5 sec.
            imap.ConnectTimeout = TimeSpan.FromSeconds(4);

            // Connect to IMAP server.
            imap.Connect();
            Console.WriteLine("Connected.");

            // Authenticate using the credentials; username and password.
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }

        Console.WriteLine("Disconnected.");
    }
}