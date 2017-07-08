using System;
using System.Collections.Generic;
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

            // Get info for all available messages
            IList<PopMessageInfo> infoList = pop.ListMessages();

            Console.WriteLine("Listing messages...");

            foreach (PopMessageInfo info in infoList)
                Console.WriteLine("{0} - [{1}] - {2} Byte(s)", info.Number, info.Uid, info.Size);
        }
    }
}
