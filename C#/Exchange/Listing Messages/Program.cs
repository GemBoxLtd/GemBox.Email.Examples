using GemBox.Email;
using GemBox.Email.Exchange;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new Exchange client.
        var exchangeClient = new ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)");
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>");

        // List the first ten messages in the Inbox folder.
        var messageInfos = exchangeClient.ListMessages("Inbox", 0, 10);

        foreach (ExchangeMessageInfo messageInfo in messageInfos)
        {
            if (!messageInfo.IsRead)
            {
                // Get the full mail message.
                var mailMessage = exchangeClient.GetMessage(messageInfo.ExchangeMessageId);
                Console.WriteLine("From: " + string.Join(", ", mailMessage.From));
                Console.WriteLine(mailMessage.BodyHtml);
                Console.WriteLine();

                // Mark message as read.
                exchangeClient.MarkMessageAsRead(messageInfo.ExchangeMessageId);
            }
        }
    }
}
