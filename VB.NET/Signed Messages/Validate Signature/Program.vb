Imports System
Imports GemBox.Email

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message from email file normally.
        Dim message = MailMessage.Load("ValidSigned.eml")

        ' Check if it's signed and validate signature.
        Console.WriteLine($"Is signed: {message.IsSigned}")
        Console.WriteLine($"Is valid: {message.ValidateSignature()}")

    End Sub

End Module