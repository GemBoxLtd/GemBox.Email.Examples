using System;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message with specified 'from' and 'to' addresses
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        // Set subject and text body
        message.Subject = "Test email message with text body";
        message.BodyText = "This is a test message with text body.";

        // Save message to disk
        message.Save("TextMessage.eml", MailMessageFormat.Eml);
    }
}
