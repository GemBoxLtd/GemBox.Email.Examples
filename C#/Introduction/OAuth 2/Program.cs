using GemBox.Email;
using GemBox.Email.Exchange;
using GemBox.Email.Imap;
using GemBox.Email.Pop;
using GemBox.Email.Smtp;
using System;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
        Example3();
        Example4();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new IMAP client.
        using (var imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            //  Connect and sign to IMAP server using OAuth 2.0.
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ImapAuthentication.XOAuth2);
            Console.WriteLine("Authenticated.");
        }
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new POP client.
        using (var pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)"))
        {
            //  Connect and sign to POP server using OAuth 2.0.
            pop.Connect();
            pop.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", PopAuthentication.XOAuth2);
            Console.WriteLine("Authenticated.");
        }
    }

    static void Example3()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new SMTP client.
        using (var smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            //  Connect and sign to SMTP server using OAuth 2.0.
            smtp.Connect();
            smtp.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", SmtpAuthentication.XOAuth2);
            Console.WriteLine("Authenticated.");
        }
    }

    static void Example4()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a new Exchange client.
        var exchangeClient = new ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)");
        // Authenticate the client using OAuth 2.0.
        exchangeClient.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ExchangeAuthentication.OAuth2);
    }
}
