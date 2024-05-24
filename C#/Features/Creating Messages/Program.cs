using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage(
            new MailAddress("sender@example.com", "Sender"),
            new MailAddress("first.receiver@example.com", "First receiver"));

        // Set subject and text body.
        message.Subject = "Test email message with text body";
        message.BodyText = "This is a test message with text body.";

        message.Save("Create Message.eml");
    }
}
