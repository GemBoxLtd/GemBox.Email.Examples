using GemBox.Email;
using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
        Example3();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

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
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message from email file normally.
        MailMessage message = MailMessage.Load("ValidSigned.eml");

        // Check if it's signed and validate signature.
        Console.WriteLine($"Is signed: {message.IsSigned}");
        Console.WriteLine($"Is valid: {message.ValidateSignature()}");
    }

    static void Example3()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

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
