using GemBox.Email;
using GemBox.Email.Graph;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new Graph client.
        var graphClient = new GraphClient();
        graphClient.Authenticate("<OAUTH2.0-TOKEN>");
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>");

        // Search for messages in "Inbox" folder whose subject contains "Some subject" text.
        var messages = graphClient.SearchMessages("Inbox", "contains(subject, 'Some subject')");
        Console.WriteLine("Number of messages with \"Some subject\" in subject:");
        Console.WriteLine(messages.Count);

        // Search for messages in "Inbox" folder that were received this year.
        messages = graphClient.SearchMessages("Inbox", $"receivedDateTime ge {DateTime.Now.Year}-01-01");
        Console.WriteLine("Number of messages received this year:");
        Console.WriteLine(messages.Count);
    }
}
