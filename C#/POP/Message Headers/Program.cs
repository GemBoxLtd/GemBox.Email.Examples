using System;
using GemBox.Email;
using GemBox.Email.Mime;
using GemBox.Email.Pop;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            pop.Connect();
            pop.Authenticate("<USERNAME>", "<PASSWORD>");

            // Get headers for first available mail message.
            HeaderCollection headers = pop.GetHeaders(1);

            // Display message headers.
            foreach (Header header in headers)
                Console.WriteLine($"{header.Name}: {header.Body}");
        }
    }
}