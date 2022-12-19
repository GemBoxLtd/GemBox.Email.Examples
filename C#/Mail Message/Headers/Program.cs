using System;
using GemBox.Email;
using GemBox.Email.Mime;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        // Get 'From' property and 'From' header.
        MailAddressCollection fromAddresses = message.From;
        Header fromHeader = message.MimeEntity.Headers[HeaderId.From];

        Console.WriteLine($"Original 'From' property value: {fromAddresses}");

        // Change 'From' header value.
        fromHeader.Body = "new.sender@example.com";

        Console.WriteLine($"Modified 'From' property value: {fromAddresses}");

        // Get 'To' property and 'To' header.
        MailAddressCollection toAddresses = message.To;
        Header toHeader = message.MimeEntity.Headers[HeaderId.To];

        Console.WriteLine($"Original 'To' header value: {toHeader.Body}");

        // Change 'To' property value.
        toAddresses[0].Address = "new.receiver@example.com";

        Console.WriteLine($"Modified 'To' header value: {toHeader.Body}");
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com")
        {
            Subject = "Example Message",
            BodyText = "High priority email with comments."
        };

        // Add message comments.
        message.MimeEntity.Headers.Add(
            new Header(HeaderId.Comments, "Example of mail message comment"));

        // Add message priority.
        message.MimeEntity.Headers.Add(
            new Header("Importance", "high"));
        message.MimeEntity.Headers.Add(
            new Header("Priority", "urgent"));
        message.MimeEntity.Headers.Add(
            new Header("X-Priority", "1"));

        message.Save("High Priority Message.eml");
    }
}