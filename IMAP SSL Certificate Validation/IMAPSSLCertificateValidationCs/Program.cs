using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using GemBox.Email;
using GemBox.Email.Imap;
using GemBox.Email.Security;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Define certificate validation delegate which will ignore 
        // 'Certificate name mismatch' errors
        RemoteCertificateValidationCallback validationDelegate =
            (object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors sslPolicyErrors) =>
            {
                if (sslPolicyErrors == SslPolicyErrors.None ||
                    sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    Console.WriteLine("Server certificate is valid.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Server certificate is invalid. Errors: " +
                        sslPolicyErrors.ToString());
                    return false;
                }
            };

        // Create new ImapClient and specify IP port, 
        // security type and certificate validation callback
        using (ImapClient imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)",
                                                993,
                                                ConnectionSecurity.Ssl,
                                                validationDelegate))
        {
            // Connect to mail server
            imap.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username,
            // password and authentication mechanism
            imap.Authenticate("<USERNAME>", "<PASSWORD>", ImapAuthentication.Plain);
            Console.WriteLine("Authenticated.");
        }
    }
}
