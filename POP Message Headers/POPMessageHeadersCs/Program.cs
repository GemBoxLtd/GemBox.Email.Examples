using System;
using GemBox.Email;
using GemBox.Email.Mime;
using GemBox.Email.Pop;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            pop.Connect();
            Console.WriteLine("Connected.");

            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // Get headers for first available mail message
            HeaderCollection headers = pop.GetHeaders(1);

            Console.WriteLine("Listing message headers...");

            foreach (Header header in headers)
                Console.WriteLine("{0}: {1}", header.Name, header.Body);
        }
    }
}
