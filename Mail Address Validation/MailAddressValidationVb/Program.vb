Imports System
Imports System.Collections.Generic
Imports GemBox.Email

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using Professional version, put your serial key below.
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

    Private Sub Example2()
        ' If using Professional version, put your serial key below.
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
End Module