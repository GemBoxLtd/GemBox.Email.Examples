using GemBox.Email;
using GemBox.Email.Smtp;
using System;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new SMTP client.
        using (var smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            // By default the connect timeout is 5 sec.
            smtp.ConnectTimeout = TimeSpan.FromSeconds(4);

            // Connect to SMTP server.
            smtp.Connect();
            Console.WriteLine("Connected.");

            // Authenticate using the credentials; username and password.
            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");
        }

        Console.WriteLine("Disconnected.");
    }
}
