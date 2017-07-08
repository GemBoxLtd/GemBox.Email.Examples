Imports System
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Incorrectly formatted mail address
        Dim address As String = " <invalid.address@gemboxsoftware.com"
        Console.Write("Validating address {0,-40} ... ", address)
        Dim result As MailAddressValidationStatus = MailAddressValidator.Validate(address)
        Console.WriteLine("[{0}]", result)

        ' Non-existing mail address domain
        address = "invalid.domain@gemboxsoftware12345.com"
        Console.Write("Validating address {0,-40} ... ", address)
        result = MailAddressValidator.Validate(address)
        Console.WriteLine("[{0}]", result)

        ' Non-existing mail address account
        address = "non.existing.address@gemboxsoftware.com"
        Console.Write("Validating address {0,-40} ... ", address)
        result = MailAddressValidator.Validate(address)
        Console.WriteLine("[{0}]", result)

        ' Valid mail address
        address = "Info <info@gemboxsoftware.com>"
        Console.Write("Validating address {0,-40} ... ", address)
        result = MailAddressValidator.Validate(address)
        Console.WriteLine("[{0}]", result)

    End Sub

End Module