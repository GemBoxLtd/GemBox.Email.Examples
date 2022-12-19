using System;
using GemBox.Email;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load message from email file normally.
        MailMessage message = MailMessage.Load("ValidSigned.eml");

        // Check if it's signed and validate signature.
        Console.WriteLine($"Is signed: {message.IsSigned}");
        Console.WriteLine($"Is valid: {message.ValidateSignature()}");
    }
}