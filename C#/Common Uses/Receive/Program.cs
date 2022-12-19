using System;
using GemBox.Email;
using GemBox.Email.Pop;
using GemBox.Email.Imap;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create POP client.
        using (var pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            //  Connect and sign to POP server.
            pop.Connect();
            pop.Authenticate("<USERNAME>", "<PASSWORD>");

            // Read the number of currently available emails on the server.
            int count = pop.GetCount();

            Console.WriteLine(" NO. |     DATE     |          SUBJECT          ");
            Console.WriteLine("------------------------------------------------");

            // Download and receive all email messages.
            for (int number = 1; number <= count; number++)
            {
                MailMessage message = pop.GetMessage(number);

                // Read and display email's date and subject.
                Console.WriteLine($"  {number}  |  {message.Date.ToShortDateString()}  |  {message.Subject}");
            }
        }
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create IMAP client.
        using (var imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            //  Connect and sign to IMAP server.
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");

            // Select INBOX folder.
            imap.SelectInbox();

            // Read the number of currently available emails in selected mailbox folder.
            int count = imap.SelectedFolder.Count;

            Console.WriteLine(" NO. |     DATE     |          SUBJECT          ");
            Console.WriteLine("------------------------------------------------");

            // Download and receive all email messages from selected mailbox folder.
            for (int number = 1; number <= count; number++)
            {
                MailMessage message = imap.GetMessage(number);

                // Read and display email's date and subject.
                Console.WriteLine($"  {number}  |  {message.Date.ToShortDateString()}  |  {message.Subject}");
            }
        }
    }
}