using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    const string Host = "<HOST>";
    const string Username = "<USERNAME>";
    const string Password = "<PASSWORD>";
    const string Sender = "<ADDRESS>";

    static int SentEmailCounter = 0;

    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        var mailingList = new List<string>()
        {
            "first.receiver@example.com",
            "second.receiver@example.com",
            "third.receiver@example.com",
            "..."
        };

        int chunkSize = 80;

        // Split "mailingList" to multiple lists of "chunkSize" size.
        var mailingChunks = SplitMany(mailingList, chunkSize);

        // Process each "mailingChunks" chunk as a separate Task.
        IEnumerable<Task> sendMailingChunks = mailingChunks.Select(
            mailingChunk => Task.Run(() => SendEmails(mailingChunk)));

        // Create a Task that will complete when emails were sent to all the "mailingList".
        Task sendBuilkEmails = Task.WhenAll(sendMailingChunks);

        // Displaying the progress of bulk email sending.
        while (!sendBuilkEmails.IsCompleted)
        {
            Console.WriteLine($"{SentEmailCounter,5} emails have been sent!");
            Task.Delay(1000).Wait();
        }
    }

    static void SendEmails(IEnumerable<string> recipients)
    {
        using (var smtp = new SmtpClient(Host))
        {
            smtp.Connect();
            smtp.Authenticate(Username, Password);

            foreach (var recipient in recipients)
            {
                MailMessage message = new MailMessage(Sender, recipient)
                {
                    Subject = "New Blog Post",
                    BodyText = "Dear reader,\n" +
                        "We have released a new blog post.\n" +
                        "You can find it on: https://www.gemboxsoftware.com/company/blog"
                };

                smtp.SendMessage(message);
                Interlocked.Increment(ref SentEmailCounter);
            }
        }
    }

    static List<List<string>> SplitMany(List<string> source, int size)
    {
        var sourceChunks = new List<List<string>>();

        for (int i = 0, count = source.Count; i < count; i += size)
            sourceChunks.Add(source.GetRange(i, Math.Min(size, count - i)));

        return sourceChunks;
    }
}