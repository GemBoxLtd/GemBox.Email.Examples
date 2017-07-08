using System;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            // Connect to mail server
            smtp.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username and password
            // (SmtpClient will use strongest possible authentication mechanism)
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }
    }
}
