using GemBox.Email;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message from email file.
        MailMessage message = MailMessage.Load("Html.eml");

        // Read message information.
        Console.WriteLine($"Date: {message.Date}");
        Console.WriteLine($"Subject: {message.Subject}");
        Console.WriteLine($"From: {message.From}");
        Console.WriteLine($"To: {message.To}");

        if (message.Cc.Count > 0)
            Console.WriteLine($"Cc: {message.Cc}");

        if (message.Bcc.Count > 0)
            Console.WriteLine($"Bcc: {message.Bcc}");

        if (message.Attachments.Count > 0)
            Console.WriteLine($"Attachments: {message.Attachments.Count}");

        Console.WriteLine();
        if (string.IsNullOrEmpty(message.BodyHtml))
            Console.WriteLine(message.BodyText);
        else
            Console.WriteLine(message.BodyHtml);
    }
}
