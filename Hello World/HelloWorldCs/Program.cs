using System;
using GemBox.Email;
using GemBox.Email.Pop;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            // Connect and login.
            pop.Connect();
            Console.WriteLine("Connected.");

            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // Check if there are any messages available on the server.
            if (pop.GetCount() == 0)
                return;

            // Download message with sequence number 1 (the first message).
            MailMessage message = pop.GetMessage(1);

            // Display message sender and subject.
            Console.WriteLine();
            Console.WriteLine($"From: {message.From}");
            Console.WriteLine($"Subject: {message.Subject}");

            // Display message body.
            Console.WriteLine("Body:");
            string body = string.IsNullOrEmpty(message.BodyHtml) ?
                message.BodyText :
                message.BodyHtml;
            Console.WriteLine(body);
        }
    }
}
