Imports GemBox.Email
Imports System
Imports System.Collections.Generic

Module Program

    Sub Main()
        Example1()
        Example2()
        Example3()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Incorrectly formatted mail address.
        Dim address As String = " <invalid.address@gemboxsoftware.com"
        Dim result As MailAddressValidationResult = MailAddressValidator.Validate(address)
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}")

        ' Non-existing mail address account.
        address = "no-address@gemboxsoftware.com"
        result = MailAddressValidator.Validate(address)
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}")

        ' Non-existing mail address domain.
        address = "no-domain@gemboxsoftware123.com"
        result = MailAddressValidator.Validate(address)
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}")

        ' Valid mail address.
        address = "Info <info@gemboxsoftware.com>"
        result = MailAddressValidator.Validate(address)
        Console.WriteLine($"Address: {address,-40} | Result: {result.Status}")
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a list of mail addresses.
        Dim addresses As New List(Of MailAddress)() From
        {
            New MailAddress("no-address@gemboxsoftware.com"),
            New MailAddress("no-domain@gemboxsoftware123.com"),
            New MailAddress("info@gemboxsoftware.com")
        }

        ' Validate address list and display results.
        Dim results As IList(Of MailAddressValidationResult) = MailAddressValidator.Validate(addresses)

        Console.WriteLine($"| {"MAIL ADDRESS",-35} | {"RESULT",15} |")

        For i = 0 To results.Count - 1
            Console.WriteLine($"| {addresses(i),-35} | {results(i).Status,15} |")
        Next
    End Sub

    Sub Example3()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Console.WriteLine($"| {"OPTION",-10} | {"MAIL ADDRESS",-35} | {"RESULT",15} |")

        ' Creating email variables for validation
        Dim invalidSyntaxMail = "invalid.address_gemboxsoftware.com"
        Dim invalidDomainMail = "no-domain@gemboxsoftware123.com"
        Dim invalidAddressMail = "no-address@gemboxsoftware.com"
        Dim validMail = "info@gemboxsoftware.com"

        ' Incorrectly formatted mail address will fail syntax only validation.
        Dim [option] = MailAddressValidationOptions.Syntax
        Dim result = MailAddressValidator.Validate(invalidSyntaxMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidSyntaxMail,-35} | {result.Status,15} |")

        ' Non-existing mail address domain will succeed syntax only validation.
        [option] = MailAddressValidationOptions.Syntax
        result = MailAddressValidator.Validate(invalidDomainMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidDomainMail,-35} | {result.Status,15} |")

        ' Non-existing mail address domain will fail domain validation.
        [option] = MailAddressValidationOptions.Domain
        result = MailAddressValidator.Validate(invalidDomainMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidDomainMail,-35} | {result.Status,15} |")

        ' Non-existing mail address account in a valid domain will succeed domain validation.
        [option] = MailAddressValidationOptions.Domain
        result = MailAddressValidator.Validate(invalidAddressMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidAddressMail,-35} | {result.Status,15} |")

        ' Non-existing mail address account in a valid domain will also succeed server validation, because the mail server is reachable
        [option] = MailAddressValidationOptions.Server
        result = MailAddressValidator.Validate(invalidAddressMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidAddressMail,-35} | {result.Status,15} |")

        ' Non-existing mail address account in a valid domain will fail mailbox validation
        [option] = MailAddressValidationOptions.Mailbox
        result = MailAddressValidator.Validate(invalidAddressMail, [option])
        Console.WriteLine($"| {[option],-10} | {invalidAddressMail,-35} | {result.Status,15} |")

        ' Valid mail address will succeed all validation steps.
        [option] = MailAddressValidationOptions.Mailbox
        result = MailAddressValidator.Validate(validMail, [option])
        Console.WriteLine($"| {[option],-10} | {validMail,-35} | {result.Status,15} |")
    End Sub

End Module
