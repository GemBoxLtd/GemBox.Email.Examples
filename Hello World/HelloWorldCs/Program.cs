using System;
using GemBox.Email;
using GemBox.Email.Pop;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        
        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            // Connect and login
            pop.Connect();
            Console.WriteLine("Connected.");

            pop.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            // Check if there are any messages available on the server
            if (pop.GetCount() == 0)
                return;

            // Download message with sequence number 1 (first one)
            MailMessage message = pop.GetMessage(1);

            // Display message sender and subject
            Console.WriteLine("From: " + message.From.ToString());
            Console.WriteLine("Subject: " + message.Subject);

            // Write message body
            Console.WriteLine("Body:");

            string text;

            if (message.BodyHtml != null)
                text = message.BodyHtml;
            else
                text = message.BodyText;

            foreach (string line in text.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                Console.WriteLine(' ' + line);
        }
    }
}
