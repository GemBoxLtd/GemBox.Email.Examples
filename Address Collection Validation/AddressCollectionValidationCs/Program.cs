using System;
using System.Collections.Generic;
using GemBox.Email;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        
        // Create a list of mail addresses
        List<MailAddress> addresses = new List<MailAddress>();

        addresses.Add(new MailAddress("invalid.domain@gemboxsoftware12345.com"));
        addresses.Add(new MailAddress("non.existing.address@gemboxsoftware.com"));
        addresses.Add(new MailAddress("non.existing.domain@gemboxsoftware12345.com"));
        addresses.Add(new MailAddress("info@gemboxsoftware.com"));

        Console.WriteLine("Validating addresses ... ");
        Console.WriteLine();

        // Validate address list and display results
        IList<MailAddressValidationStatus> results = MailAddressValidator.Validate(addresses);

        Console.WriteLine("|                   MAIL ADDRESS                     |            RESULT            |");
        Console.WriteLine("|----------------------------------------------------|------------------------------|");

        for (int i = 0; i < results.Count; i++)
            Console.WriteLine("| {0,-50} | {1,18} |", addresses[i], results[i]);

        Console.WriteLine("|----------------------------------------------------|------------------------------|");
    }
}
