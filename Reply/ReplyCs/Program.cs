using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Mime;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        MailMessage message;

        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            Console.WriteLine("Connected.");

            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            imap.SelectInbox();
            IList<int> results = imap.SearchMessageNumbers("FROM sender@example.com SUBJECT " +
                                                           "\"Are you coming to the party\"");

            if (results.Count == 0)
                Console.WriteLine("Message not found.");

            message = imap.GetMessage(results[0]);
        }

        MailAddress fromAddress = message.From[0];
        MailMessage reply = new MailMessage(new MailAddress("receiver@example.com", "Receiver"),
                                            fromAddress);

        // Add 'In-Reply-To' header
        Header header = new Header(HeaderId.InReplyTo, message.Id);
        reply.MimeEntity.Headers.Add(header);

        // Check if 'References' header exists and its body is not null or empty
        if (message.MimeEntity.Headers.TryGetHeader(HeaderId.References, out header) && !string.IsNullOrEmpty(header.Body))
            // If found, copy original value and append last message id
            header = new Header(HeaderId.References, header.Body + ' ' + message.Id);
        else
            // If not found, create one with message id
            header = new Header(HeaderId.References, message.Id);

        // Add 'References' header to reply message
        reply.MimeEntity.Headers.Add(header);

        // Set subject
        reply.Subject = "Re: " + message.Subject;

        // Compose text body
        StringBuilder text = new StringBuilder();

        text.AppendLine("Yes. See you there at 9.");
        text.AppendLine();
        text.AppendFormat("On {0}, {1} wrote:", message.Date.ToString(CultureInfo.InvariantCulture), fromAddress);
        text.AppendLine();

        // Append original text body if it exists
        if (message.BodyText != null)
        {
            text.AppendLine();
            text.Append("> " + message.BodyText.Replace("\r\n", "\r\n> "));
        }

        reply.BodyText = text.ToString();

        // Compose HTML body
        text = new StringBuilder();

        text.Append("<div>Yes. See you there at 9.</div><br/>");
        text.AppendFormat("<div>On {0}, ", message.Date.ToString(CultureInfo.InvariantCulture));

        if (fromAddress.DisplayName != null)
            text.Append(fromAddress.DisplayName + ' ');

        text.AppendFormat("<<a href=\"mailto:{0}\">{0}</a>> wrote:<br/>", fromAddress.Address);

        // Append original text body if it exists
        if (message.BodyHtml != null)
        {
            text.Append("<blockquote style=\"margin: 0 0 0 5px;");
            text.Append(" border-left: 2px blue solid;");
            text.Append(" padding-left: 5px\">");
            text.Append(message.BodyHtml);
            text.Append("</blockquote><br/></div>");
        }

        reply.BodyHtml = text.ToString();

        Console.WriteLine("Sending reply...");

        // Initialize new SMTP client and send message
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            Console.WriteLine("Connected.");

            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            smtp.SendMessage(message);
        }

        Console.WriteLine("Reply sent successfully.");
    }
}
