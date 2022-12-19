using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Security;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create certificate validation delegate.
        RemoteCertificateValidationCallback validationDelegate =
            (object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors errors) =>
            {
                if (errors == SslPolicyErrors.None || errors == SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    Console.WriteLine("Server certificate is valid.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Server certificate is invalid: {errors}");
                    return false;
                }
            };

        // Create new PopClient and specify host, port, security and certificate validation callback.
        using (ImapClient imap = new ImapClient(
            "<ADDRESS> (e.g. imap.gmail.com)",
            993,
            ConnectionSecurity.Ssl,
            validationDelegate))
        {
            // Connect to email server.
            imap.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username, password and authentication mechanism.
            imap.Authenticate("<USERNAME>", "<PASSWORD>", ImapAuthentication.Plain);
            Console.WriteLine("Authenticated.");
        }
    }
}