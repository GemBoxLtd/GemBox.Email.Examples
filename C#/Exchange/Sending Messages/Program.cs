using GemBox.Email;
using GemBox.Email.Exchange;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new email message.
        MailMessage message = new MailMessage(
            new MailAddress("sender@example.com", "Sender"),
            new MailAddress("first.receiver@example.com", "First receiver"),
            new MailAddress("second.receiver@example.com", "Second receiver"));

        // Add additional receivers.
        message.Cc.Add(
            new MailAddress("third.receiver@example.com", "Third receiver"),
            new MailAddress("fourth.receiver@example.com", "Fourth receiver"));

        // Add subject and body.
        message.Subject = "Send Email in C# and VB.NET";
        message.BodyText = "Hi 👋,\n" +
            "This message was created and sent with GemBox.Email.\n" +
            "Read more about it on https://www.gemboxsoftware.com/email";

        // Create a new Exchange client and send an email message.
        var exchangeClient = new ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)");
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>");
        exchangeClient.SendMessage(message);
    }
}
