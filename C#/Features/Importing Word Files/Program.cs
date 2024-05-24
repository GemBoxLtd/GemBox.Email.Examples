using GemBox.Document;
using GemBox.Email;
using GemBox.Email.Smtp;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your GemBox.Email serial key below.
        GemBox.Email.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // If using the Professional version, put your GemBox.Document serial key below.
        GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load a Word file.
        var document = DocumentModel.Load("BodyTemplate.docx");

        using (var stream = new MemoryStream())
        {
            // Save as MHTML document.
            document.Save(stream, new HtmlSaveOptions()
            {
                HtmlType = HtmlType.Mhtml,
                UseContentIdHeaders = true
            });

            // Load MHTML content as a mail message.
            var message = MailMessage.Load(stream, MailMessageFormat.Mhtml);

            message.Subject = "Word message example";
            message.Date = DateTime.Now;

            message.From.Add(new MailAddress("sender@example.com"));
            message.To.Add(new MailAddress("receiver@example.com"));

            // Send the email.
            using (var smtp = new SmtpClient("<HOST>"))
            {
                smtp.Connect();
                smtp.Authenticate("<USERNAME>", "<PASSWORD>");
                smtp.SendMessage(message);
            }
        }
    }
}
