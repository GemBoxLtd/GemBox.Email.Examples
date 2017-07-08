using System;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message
        MailMessage message = new MailMessage(new MailAddress("sender@example.com", "Sender"),
                              new MailAddress("first.receiver@example.com", "First receiver"));

        // Add second receiver to CC and set subject
        message.Cc.Add(new MailAddress("carbon.copy@example.com", "Carbon Copy receiver"));
        message.Subject = "GemBox.Email .NET component save example";

        // Add HTML and text body
        message.BodyHtml = "<html>" +
                              "<body>" +
                                 "<p>Hi!<br/><br/>This message was created and saved with " +
                                    "<b>GemBox.Email .NET component</b>.<br/>" +
                                    "More info can be found at <a href=\"http://www.gemboxsoftware.com/\">" +
                                    "GemBox Software website</a>.<br/><br/>" +
                                    "Regards,<br/>" +
                                    "GemBox" +
                                 "</p>" +
                              "</body>" +
                           "</html>";

        message.BodyText = "Hi!\r\n" +
                           "\r\n" +
                           "This message was created and saved with GemBox.Email .NET component.\r\n" +
                           "More info can be found at http://www.gemboxsoftware.com/.\r\n\r\n" +
                           "Regards,\r\n" +
                           "GemBox";

        message.Save("Save.eml");
    }
}
