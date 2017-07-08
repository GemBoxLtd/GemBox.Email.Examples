using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using GemBox.Email;
using GemBox.Email.Pop;
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

        // Create new PopClient and specify IP port, 
        // security type and certificate validation callback
        using (PopClient pop = new PopClient("<ADDRESS> (e.g. pop.gmail.com)",
                                             995,
                                             ConnectionSecurity.Ssl,
                                             validationDelegate))
        {
            // Connect to mail server
            pop.Connect();
            Console.WriteLine("Connected.");

            // Authenticate with specified username,
            // password and authentication mechanism
            pop.Authenticate("<USERNAME>", "<PASSWORD>", PopAuthentication.Plain);
            Console.WriteLine("Authenticated.");
        }
    }
}
