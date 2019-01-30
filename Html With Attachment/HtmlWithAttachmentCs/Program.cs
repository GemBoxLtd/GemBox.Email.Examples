using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new email message.
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        // Add subject.
        message.Subject = "Send HTML Email with Image and Attachment";

        // Add HTML body with CID embeded image.
        string cid = "image001@gembox.com";
        message.BodyHtml = "<html><body>" +
            "<p>Hi 👋,</p>" +
            "<p>This message was created and sent with:</p>" +
            "<p><img src='cid:" + cid + "'/></p>" +
            "<p>Read more about it on <a href='https://www.gemboxsoftware.com/email'>GemBox.Email Overview</a> page.</p>" +
            "</body></html>";

        // Add image as inline attachment.
        message.Attachments.Add(new Attachment("gembox-email-logo.png") { ContentId = cid });

        // Add file as attachment.
        message.Attachments.Add(new Attachment("sample-file.pdf"));

        // Create new SMTP client and send an email message.
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            smtp.SendMessage(message);
        }
    }
}