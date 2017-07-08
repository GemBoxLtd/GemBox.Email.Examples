using System;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message with specified 'from' and 'to' addresses, including their display names
        MailMessage message = new MailMessage(new MailAddress("sender@example.com", "Mail sender"),
                                              new MailAddress("receiver@example.com", "Message receiver"));

        // Set subject and text body
        message.Subject = "HTML email message sample";

        // Set HTML body ...
        message.BodyHtml = "<html>" +
                              "<body style=\"background-color: #eae7e3;\">" +
                                 "<div style=\"background-color: lightblue; " +
                                             "width: 500px; " +
                                             "margin: auto; " +
                                             "padding: 10px; " +
                                             "text-align: center\">" +
                                    "<h1 style=\"color: red\">" +
                                       "GemBox.Email<br/>Html Message sample" +
                                    "</h1>" +
                                    "<p style=\"text-align: left\">" +
                                       "This sample demonstrates how to create " +
                                        "<code style=\"color: blue\">" +
                                           "GemBox.Email.MailMessage" +
                                        "</code> " +
                                        "with styled <b>HTML</b> body. " +
                                    "</p>" +
                                 "</div>" +
                              "</body>" +
                           "</html>";

        // ... and also, set text body for clients who doesn't support mail messages with HTML body
        message.BodyText = "GemBox.Email Html Message sample\r\n" +
                           "This sample demonstrates how to create " +
                           "GemBox.Email.MailMessage with styled HTML body.";

        // Save message to disk
        message.Save("HtmlMessage.eml", MailMessageFormat.Eml);
    }
}
