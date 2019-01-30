using System;
using System.Collections.Generic;
using GemBox.Email;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Incorrectly formatted mail address.
        string address = " <invalid.address@gemboxsoftware.com";
        MailAddressValidationStatus result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result}");

        // Non-existing mail address account.
        address = "no-address@gemboxsoftware.com";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result}");

        // Non-existing mail address domain.
        address = "no-domain@gemboxsoftware123.com";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result}");

        // Valid mail address.
        address = "Info <info@gemboxsoftware.com>";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result}");
    }

    static void Example2()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a list of mail addresses.
        List<MailAddress> addresses = new List<MailAddress>()
        {
            new MailAddress("no-address@gemboxsoftware.com"),
            new MailAddress("no-domain@gemboxsoftware123.com"),
            new MailAddress("info@gemboxsoftware.com")
        };

        // Validate address list and display results.
        IList<MailAddressValidationStatus> results = MailAddressValidator.Validate(addresses);

        Console.WriteLine($"| {"MAIL ADDRESS",-35} | {"RESULT",15} |");

        for (int i = 0; i < results.Count; i++)
            Console.WriteLine($"| {addresses[i],-35} | {results[i],15} |");
    }
}