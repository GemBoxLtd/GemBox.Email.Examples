using System;
using GemBox.Email;
using GemBox.Email.Pop;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            // Connect to mail server
            pop.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username and password
            // (PopClient will use strongest possible authentication mechanism)
            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }
    }
}
