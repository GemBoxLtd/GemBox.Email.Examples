using System;
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
            // Connect to mail server
            imap.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username and password 
            // (ImapClient will use strongest possible authentication mechanism)
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }
    }
}
