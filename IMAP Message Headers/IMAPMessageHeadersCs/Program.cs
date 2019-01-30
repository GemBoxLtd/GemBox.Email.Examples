using System;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Mime;

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

            // Get headers for first available mail message.
            HeaderCollection headers = imap.GetHeaders(1);

            // Display message headers.
            foreach (Header header in headers)
                Console.WriteLine($"{header.Name}: {header.Body}");
        }
    }
}