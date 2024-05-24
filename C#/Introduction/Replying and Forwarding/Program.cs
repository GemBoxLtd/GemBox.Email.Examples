using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Mime;
using GemBox.Email.Smtp;
using System.Linq;

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

        // Retrieve original message.
        MailMessage originalMessage;
        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            imap.SelectInbox();

            string searchQuery = @"SUBJECT ""Are you coming to the party?""";
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(searchQuery).First());
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

        // Set subject and body with appended original message.
        replyMessage.Subject = $"Re: { originalMessage.Subject }";
        replyMessage.BodyHtml = $@"<div>Yes, see you there at 9!</div>
<br><div>On {originalMessage.Date:G}, {originalMessage.From[0].Address} wrote:</div>
<blockquote style='border-left:1pt solid #E1E1E1;padding-left:5pt'>
  {originalMessage.BodyHtml}
</blockquote>";

        // Send reply email.
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            smtp.SendMessage(replyMessage);
        }
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Retrieve original message.
        MailMessage originalMessage;
        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            imap.SelectInbox();

            string searchQuery = @"SUBJECT ""Are you coming to the party?""";
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(searchQuery).First());
        }

        // Create forward email.
        MailMessage forwardMessage = new MailMessage(
            "receiver@example.com",
            "anoter.receiver@example.com");

        // Set subject and body with appended original message.
        forwardMessage.Subject = $"Fw: {originalMessage.Subject}";
        forwardMessage.BodyHtml = $@"<div>Are you interested in coming with me to this party?</div>
<br><div>On {originalMessage.Date:G}, {originalMessage.From[0].Address} wrote:</div>
<blockquote style='border-left:1pt solid #E1E1E1;padding-left:5pt'>
  {originalMessage.BodyHtml}
</blockquote>";

        // Add original attachments.
        foreach (var attachment in originalMessage.Attachments)
            forwardMessage.Attachments.Add(attachment);

        // Send forward email.
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            smtp.SendMessage(forwardMessage);
        }
    }
}
