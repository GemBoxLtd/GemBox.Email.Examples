using System;
using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message collection.
        MailMessageCollection messages = MailMessageCollection.Load("Collection.mbox");

        // Display message information.
        foreach (MailMessage message in messages)
        {
            Console.WriteLine($"From: {message.From}");
            Console.WriteLine($"Subject: {message.Subject}");
            Console.WriteLine($"Body: {message.BodyText}");
            Console.WriteLine();
        }

        // Create new message.
        MailMessage newMessage = new MailMessage("sender@example.com", "receiver@example.com")
        {
            Subject = "Test email message with a text body",
            BodyText = "This is a test message with a text body."
        };

        // Add message to collection.
        messages.Add(newMessage);

        // Save message collection.
        messages.Save("Modified Collection.mbox");
    }
}