using System;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            Console.WriteLine("Connected.");

            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // Create new message
            MailMessage message = new MailMessage(new MailAddress("sender@example.com"),
                                                  new MailAddress("receiver@example.com"));
            message.Subject = "SMTP test message";
            message.BodyText = "This is test message body.";

            Console.WriteLine("Sending message...");

            // Send message
            smtp.SendMessage(message);

            Console.WriteLine("Message sent.");
        }
    }
}
