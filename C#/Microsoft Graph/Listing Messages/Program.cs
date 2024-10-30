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

        // List the first ten messages in the Inbox folder.
        var messages = graphClient.ListMessages("Inbox", 0, 10);

        foreach (var message in messages)
        {
            if (!message.IsRead)
            {
                // Get the full mail message.
                var mailMessage = graphClient.GetMessage(message.MessageId);
                Console.WriteLine("From: " + string.Join(", ", mailMessage.From));
                Console.WriteLine(mailMessage.BodyHtml ?? mailMessage.BodyText);
                Console.WriteLine();

                // Mark message as read.
                graphClient.MarkMessageAsRead(message.MessageId);
            }
        }
    }
}
