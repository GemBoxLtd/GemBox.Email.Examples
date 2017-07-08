using System;
using System.Text;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message
        MailMessage message = MailMessage.Load("Html.eml");
        StringBuilder sb = new StringBuilder();

        // Add date
        sb.AppendLine(string.Format("Date: {0}", message.Date));

        // Add addresses
        sb.AppendLine(string.Format("From: {0}", message.From.ToString()));
        sb.AppendLine(string.Format("To: {0}", message.To.ToString()));

        if (message.Cc.Count > 0)
            sb.AppendLine(string.Format("Cc: {0}", message.Cc.ToString()));

        if (message.Bcc.Count > 0)
            sb.AppendLine(string.Format("Bcc: {0}", message.Bcc.ToString()));

        if (message.Attachments.Count > 0)
            sb.AppendLine(string.Format("Attachments: {0}", message.Attachments.Count.ToString()));

        // Add subject
        sb.AppendLine(string.Format("Subject: {0}", message.Subject));

        // Add message body
        sb.AppendLine("------------------------------ BODY ------------------------------");
        if (string.IsNullOrEmpty(message.BodyHtml))
            sb.Append(message.BodyText);
        else
            sb.Append(message.BodyHtml);

        Console.WriteLine(sb.ToString());
    }
}
