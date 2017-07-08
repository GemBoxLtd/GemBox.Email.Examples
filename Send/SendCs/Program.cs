using System;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        Console.WriteLine("Creating message...");

        // Create new email message
        MailMessage message = new MailMessage(new MailAddress("sender@example.com", "Sender"),
                                              new MailAddress("first.receiver@example.com", "First receiver"));

        // Add second receiver to CC and set subject
        message.Cc.Add(new MailAddress("second.receiver@example.com", "Second receiver"));
        message.Subject = "GemBox.Email .NET component";

        // Add HTML and text body
        message.BodyHtml = "<html>" +
                              "<body>" +
                                 "<p>Hi!<br/><br/>This message was created and sent with " +
                                    "<b>GemBox.Email .NET component</b>.<br/>" +
                                    "More info can be found at <a href=\"http://www.gemboxsoftware.com/\">" +
                                    "GemBox Software website</a>." +
                                 "</p>" +
                              "</body>" +
                           "</html>";

        message.BodyText = "Hi!\r\n" +
                           "\r\n" +
                           "This message was created and sent with GemBox.Email .NET component.\r\n" +
                           "More info can be found at http://www.gemboxsoftware.com/.";

        // Add attachment
        message.Attachments.Add(new Attachment("Picture.jpg"));

        Console.WriteLine("Sending message...");

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
