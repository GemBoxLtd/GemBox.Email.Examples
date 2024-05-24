using GemBox.Email;
using GemBox.Email.Pop;
using System;

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

            // Get number of available messages.
            Console.WriteLine($"Mailbox message count: {pop.GetCount()}");

            // Get size of all available messages in bytes.
            Console.WriteLine($"Mailbox size: {pop.GetSize()} Byte(s)");
        }
    }
}
