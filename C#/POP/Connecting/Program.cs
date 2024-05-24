using GemBox.Email;
using GemBox.Email.Pop;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new POP client.
        using (var pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            // By default the connect timeout is 5 sec.
            pop.ConnectTimeout = TimeSpan.FromSeconds(4);

            // Connect to POP server.
            pop.Connect();
            Console.WriteLine("Connected.");

            // Authenticate using the credentials; username and password.
            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }

        Console.WriteLine("Disconnected.");
    }
}
