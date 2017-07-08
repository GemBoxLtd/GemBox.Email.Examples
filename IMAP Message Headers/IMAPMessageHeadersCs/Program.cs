using System;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Mime;

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

            // Get headers for first available mail message
            HeaderCollection headers = imap.GetHeaders(1);

            Console.WriteLine("Listing message headers...");

            foreach (Header header in headers)
                Console.WriteLine("{0}: {1}", header.Name, header.Body);
        }
    }
}
