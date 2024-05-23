using System;
using System.Collections.Generic;
using GemBox.Email;

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

        // Incorrectly formatted mail address.
        string address = " <invalid.address@gemboxsoftware.com";
        MailAddressValidationResult result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}");

        // Non-existing mail address account.
        address = "no-address@gemboxsoftware.com";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}");

        // Non-existing mail address domain.
        address = "no-domain@gemboxsoftware123.com";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}");

        // Valid mail address.
        address = "Info <info@gemboxsoftware.com>";
        result = MailAddressValidator.Validate(address);
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}");
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create a list of mail addresses.
        List<MailAddress> addresses = new List<MailAddress>()
        {
            new MailAddress("no-address@gemboxsoftware.com"),
            new MailAddress("no-domain@gemboxsoftware123.com"),
            new MailAddress("info@gemboxsoftware.com")
        };

        // Validate address list and display results.
        IList<MailAddressValidationResult> results = MailAddressValidator.Validate(addresses);

        Console.WriteLine($"| {"MAIL ADDRESS",-35} | {"RESULT",15} |");

        for (int i = 0; i < results.Count; i++)
            Console.WriteLine($"| {addresses[i],-35} | {results[i].Status,15} |");
    }

    static void Example3()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        Console.WriteLine($"| {"OPTION",-10} | {"MAIL ADDRESS",-35} | {"RESULT",15} |");

        // Creating email variables for validation
        string invalidSyntaxMail = "invalid.address_gemboxsoftware.com";
        string invalidDomainMail = "no-domain@gemboxsoftware123.com";
        string invalidAddressMail = "no-address@gemboxsoftware.com";
        string validMail = "info@gemboxsoftware.com";

        // Incorrectly formatted mail address will fail syntax only validation.
        var option = MailAddressValidationOptions.Syntax;
        var result = MailAddressValidator.Validate(invalidSyntaxMail, option);
        Console.WriteLine($"| {option,-10} | {invalidSyntaxMail,-35} | {result.Status,15} |");

        // Non-existing mail address domain will succeed syntax only validation.
        option = MailAddressValidationOptions.Syntax;
        result = MailAddressValidator.Validate(invalidDomainMail, option);
        Console.WriteLine($"| {option,-10} | {invalidDomainMail,-35} | {result.Status,15} |");

        // Non-existing mail address domain will fail domain validation.
        option = MailAddressValidationOptions.Domain;
        result = MailAddressValidator.Validate(invalidDomainMail, option);
        Console.WriteLine($"| {option,-10} | {invalidDomainMail,-35} | {result.Status,15} |");

        // Non-existing mail address account in a valid domain will succeed domain validation.
        option = MailAddressValidationOptions.Domain;
        result = MailAddressValidator.Validate(invalidAddressMail, option);
        Console.WriteLine($"| {option,-10} | {invalidAddressMail,-35} | {result.Status,15} |");

        // Non-existing mail address account in a valid domain will also succeed server validation, because the mail server is reachable
        option = MailAddressValidationOptions.Server;
        result = MailAddressValidator.Validate(invalidAddressMail, option);
        Console.WriteLine($"| {option,-10} | {invalidAddressMail,-35} | {result.Status,15} |");

        // Non-existing mail address account in a valid domain will fail mailbox validation
        option = MailAddressValidationOptions.Mailbox;
        result = MailAddressValidator.Validate(invalidAddressMail, option);
        Console.WriteLine($"| {option,-10} | {invalidAddressMail,-35} | {result.Status,15} |");

        // Valid mail address will succeed all validation steps.
        option = MailAddressValidationOptions.Mailbox;
        result = MailAddressValidator.Validate(validMail, option);
        Console.WriteLine($"| {option,-10} | {validMail,-35} | {result.Status,15} |");
    }
}
