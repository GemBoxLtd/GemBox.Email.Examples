using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Convert email from one format into another.
        MailMessage message = MailMessage.Load("Attachment.eml");
        message.Save("Convert.msg");
    }
}
