using System;
using System.Collections.Generic;
using GemBox.Email;
using GemBox.Email.Mime;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message
        MailMessage message = new MailMessage(new MailAddress("sender@example.com"),
                                              new MailAddress("receiver-1@example.com", "First"),
                                              new MailAddress("receiver-2@example.com", "Second"));

        // Get 'From' reference
        MailAddressCollection fromAddresses = message.From;

        // Get 'To' header
        Header headerTo = message.MimeEntity.Headers[HeaderId.To];

        Console.WriteLine("Original value of property 'To': " + message.To.ToString());

        // Change header value
        headerTo.Body = "new.receiver@example.com";
        Console.WriteLine("Header 'To' value changed to: " + headerTo.Body);
        Console.WriteLine("Modified value of property 'To': " + message.To.ToString());

        Header headerFrom = null;

        // Try to get 'From' header
        if (!message.MimeEntity.Headers.TryGetHeader("From", out headerFrom))
            throw new KeyNotFoundException("Header not found.");

        Console.WriteLine();
        Console.WriteLine("Original value of variable 'fromAddresses': " + fromAddresses.ToString());

        // Change header value
        headerFrom.Body = "New sender <new.sender@example.com>";
        Console.WriteLine("Header 'From' value changed to: " + headerFrom.Body);
        Console.WriteLine("Modified value of variable 'fromAddresses': " + fromAddresses.ToString());
    }
}
