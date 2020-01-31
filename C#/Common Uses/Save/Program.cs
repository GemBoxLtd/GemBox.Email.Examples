using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage(
            new MailAddress("sender@example.com", "Sender"),
            new MailAddress("receiver@example.com", "Receiver"));

        // Add subject and body.
        message.Subject = "Save Example by GemBox.Email";
        message.BodyText = "Hi 👋,\n" +
            "This message was created and saved with GemBox.Email.\n" +
            "Read more about it on https://www.gemboxsoftware.com/email";

        // Save message to email file.
        message.Save("Save.eml");
    }
}