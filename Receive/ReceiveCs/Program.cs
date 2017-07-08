using System;
using System.Globalization;
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

            // Read the number of currently available email messages on the server.
            int count = pop.GetCount();
            Console.WriteLine("Number of available messages: " + count);

            // Write table header
            Console.WriteLine();
            Console.WriteLine(" NO. |         DATE        |        SUBJECT");
            Console.WriteLine("--------------------------------------------------");

            // Receive (download) and list all email messages.
            for (int i = 1; i <= count; i++)
            {
                MailMessage message = pop.GetMessage(i);
                Console.WriteLine("  {0,-2} | {1} | {2}", i, message.Date.ToString(CultureInfo.InvariantCulture), message.Subject);
            }
        }
    }
}
