using GemBox.Email;
using GemBox.Email.Imap;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");

            // Create new email message.
            MailMessage message = new MailMessage(
                new MailAddress("sender@example.com", "Sender"),
                new MailAddress("first.receiver@example.com", "First receiver"),
                new MailAddress("second.receiver@example.com", "Second receiver"));

            // Add additional receivers.
            message.Cc.Add(
                new MailAddress("third.receiver@example.com", "Third receiver"),
                new MailAddress("fourth.receiver@example.com", "Fourth receiver"));

            // Add subject and body.
            message.Subject = "Upload Email in C# / VB.NET / ASP.NET";
            message.BodyText = "Hi 👋,\n" +
                "This message was created and uploaded with GemBox.Email.\n" +
                "Read more about it on https://www.gemboxsoftware.com/email";

            // Uploads the message to the INBOX folder.
            imap.UploadMessage(message, "INBOX");
        }
    }
}
