using System.Linq;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Mime;
using GemBox.Email.Smtp;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Retrieve searched email.
        MailMessage originalMessage;
        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            imap.SelectInbox();

            string search = @"SUBJECT ""Are you coming to the party?""";
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(search).First());
        }

        // Create reply email with sender and receiver addresses swapped.
        MailMessage replyMessage = new MailMessage(
            originalMessage.To[0],
            originalMessage.From[0]);

        // Add 'In-Reply-To' and 'References' header.
        replyMessage.MimeEntity.Headers.Add(
            new Header(HeaderId.InReplyTo, originalMessage.Id));
        replyMessage.MimeEntity.Headers.Add(
            new Header(HeaderId.References, originalMessage.Id));

        // Set subject.
        replyMessage.Subject = $"Re: { originalMessage.Subject }";

        // Set reply message message.
        replyMessage.BodyHtml = "<div>Yes. See you there at 9.</div>";

        // Append original message text.
        replyMessage.BodyHtml +=
            $"<div>On {originalMessage.Date:G}, {originalMessage.From[0].Address} wrote:</div>" +
            $"<blockquote>{originalMessage.BodyHtml}</blockquote>";

        // Send reply email.
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            smtp.SendMessage(replyMessage);
        }
    }
}
