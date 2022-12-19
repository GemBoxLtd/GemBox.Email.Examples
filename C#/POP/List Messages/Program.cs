using System;
using System.Collections.Generic;
using GemBox.Email;
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

            // Get information about all available messages.
            IList<PopMessageInfo> infos = pop.ListMessages();

            // Display messages information.
            foreach (PopMessageInfo info in infos)
                Console.WriteLine($"{info.Number} - [{info.Uid}] - {info.Size} Byte(s)");
        }
    }
}