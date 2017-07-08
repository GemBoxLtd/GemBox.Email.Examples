using System;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message
        MailMessage message = MailMessage.Load("Attachment.eml");

        // In order to achieve the conversion of a loaded email message 
        // to some other file format, we just need to 
        // save a MailMessage object to desired output file format.
        message.Save("Convert.msg");
    }
}
