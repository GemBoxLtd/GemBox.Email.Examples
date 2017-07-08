Imports System
Imports System.Collections.Generic
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        'Create a list of mail addresses
        Dim addresses As New List(Of MailAddress)

        addresses.Add(New MailAddress("invalid.domain@gemboxsoftware12345.com"))
        addresses.Add(New MailAddress("non.existing.address@gemboxsoftware.com"))
        addresses.Add(New MailAddress("non.existing.domain@gemboxsoftware12345.com"))
        addresses.Add(New MailAddress("info@gemboxsoftware.com"))

        Console.WriteLine("Validating addresses ... ")
        Console.WriteLine()

        ' Validate address list and display results
        Dim results As IList(Of MailAddressValidationStatus) = MailAddressValidator.Validate(addresses)

        Console.WriteLine("|                   MAIL ADDRESS                     |            RESULT            |")
        Console.WriteLine("|----------------------------------------------------|------------------------------|")

        For i As Integer = 0 To results.Count - 1
            Console.WriteLine("| {0,-50} | {1,18} |", addresses(i), results(i))
        Next

        Console.WriteLine("|----------------------------------------------------|------------------------------|")

    End Sub

End Module