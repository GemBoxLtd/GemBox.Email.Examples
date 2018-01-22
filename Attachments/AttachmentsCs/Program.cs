using System;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message with specified 'from' and 'to' addresses
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        // Set subject and text body
        message.Subject = "Email message with attachments";
        message.BodyText = "This is a message body.";
        message.BodyHtml = "<h1>This is a message body.</h1>";

        // Add attachments
        message.Attachments.Add(new Attachment("Image.png"));
        message.Attachments.Add(new Attachment("Document.docx"));

        // Initialize new SMTP client and send an email message
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            Console.WriteLine("Connected.");

            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            smtp.SendMessage(message);
        }

        Console.WriteLine("Message sent successfully.");
    }
}
