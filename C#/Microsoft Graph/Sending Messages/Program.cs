using GemBox.Email;
using GemBox.Email.Graph;

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

        // Create a new email message.
        var message = new MailMessage(
            new MailAddress("sender@example.com", "Sender"),
            new MailAddress("first.receiver@example.com", "First receiver"),
            new MailAddress("second.receiver@example.com", "Second receiver"));

        // Add additional receivers.
        message.Cc.Add(
            new MailAddress("third.receiver@example.com", "Third receiver"),
            new MailAddress("fourth.receiver@example.com", "Fourth receiver"));

        // Add subject and body.
        message.Subject = "Send Email in C# and VB.NET";
        message.BodyText = "Hi 👋,\n" +
            "This message was created and sent with GemBox.Email.\n" +
            "Read more about it on https://www.gemboxsoftware.com/email";

        // Create a new Graph client and send an email message.
        var graphClient = new GraphClient();
        graphClient.Authenticate("<OAUTH2.0-TOKEN>");
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>");
        graphClient.SendMessage(message);
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new email message.
        var message = new MailMessage("sender@example.com", "receiver@example.com");

        // Add subject.
        message.Subject = "Send HTML Email with Image and Attachment";

        // Add HTML body with CID embedded image.
        string cid = "image001@gembox.com";
        message.BodyHtml = "<html><body>" +
            "<p>Hi 👋,</p>" +
            "<p>This message was created and sent with:</p>" +
            "<p><img src='cid:" + cid + "'/></p>" +
            "<p>Read more about it on <a href='https://www.gemboxsoftware.com/email'>GemBox.Email Overview</a> page.</p>" +
            "</body></html>";

        // Add image as an inline attachment.
        message.Attachments.Add(new Attachment("GemBoxEmailLogo.png") { ContentId = cid });

        // Add PDF as an attachment.
        message.Attachments.Add(new Attachment("GemBoxSampleFile.pdf"));

        // Create a new Graph client and send an email message.
        var graphClient = new GraphClient();
        graphClient.Authenticate("<OAUTH2.0-TOKEN>");
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>");
        graphClient.SendMessage(message);
    }
}
