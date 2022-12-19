using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using GemBox.Email;
using GemBox.Email.Pop;
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
        using (PopClient pop = new PopClient(
            "<ADDRESS> (e.g. pop.gmail.com)",
            995,
            ConnectionSecurity.Ssl,
            validationDelegate))
        {
            // Connect to email server.
            pop.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username, password and authentication mechanism.
            pop.Authenticate("<USERNAME>", "<PASSWORD>", PopAuthentication.Plain);
            Console.WriteLine("Authenticated.");
        }
    }
}