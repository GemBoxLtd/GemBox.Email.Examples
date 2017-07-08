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
            pop.Connect();
            Console.WriteLine("Connected.");

            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // Get number of available messages
            Console.WriteLine("Mailbox message count: " + pop.GetCount());

            // Get size of all available messages in bytes
            Console.WriteLine("Mailbox size: {0} Byte(s)", pop.GetSize());
        }
    }
}
