using GemBox.Email;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        Example1();
        Example2();
    }

    static void Example1()
    {
        // Load message from email file normally.
        var message = MailMessage.Load("Plain.eml");

        // Signing an already signed message would throw an exception!
        if (message.IsSigned)
            return;

        var options = new DigitalSignatureOptions()
        {
            Certificate = new X509Certificate2("GemBoxRSA4096.pfx", "GemBoxPassword"),
            ClearSigned = true
        };

        // Sign message as clear-signed.
        message.Sign(options);

        // Save the signed message.
        message.Save("Signed.eml");
    }

    static void Example2()
    {
        // Load message from email file normally.
        var message = MailMessage.Load("ValidClearSigned.eml");

        // To unsign a not-signed message would throw an exception!
        if (!message.IsSigned)
            return;

        message.Unsign();

        // Save the unsigned message.
        message.Save("Unsigned.eml");
    }
}