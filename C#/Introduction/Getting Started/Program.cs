using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new email message.
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        // Add subject.
        message.Subject = "GemBox.Email getting started example";

        // Add HTML body 
        message.BodyHtml = 
            "<html><body>" +
            "<p>Hi 👋,</p>" +
            "<p>This message was created and sent with <a href='https://www.gemboxsoftware.com/email'>GemBox.Email</a></p>" +
            "</body></html>";

        // Add text body 
        message.BodyText =
            "Hi 👋,\n" +
            "This message was created and sent with GemBox.Email (https://www.gemboxsoftware.com/email)";

        // Add file as attachment.
        message.Attachments.Add(new Attachment("GemBoxSampleFile.pdf"));

        // Create new SMTP client and send an email message.
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            smtp.SendMessage(message);
        }
    }
}
