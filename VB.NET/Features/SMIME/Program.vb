Imports GemBox.Email
Imports System
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main()
        Example1()
        Example2()
        Example3()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message from email file normally.
        Dim message = MailMessage.Load("Plain.eml")

        ' Signing an already signed message would throw an exception!
        If message.IsSigned Then Return

        ' Load certificate data.
        Dim options As New DigitalSignatureOptions() With
        {
            .Certificate = New X509Certificate2("GemBoxRSA4096.pfx", "GemBoxPassword"),
            .ClearSigned = True
        }

        ' Sign message as clear-signed.
        message.Sign(options)

        ' Save the signed message.
        message.Save("Signed.eml")
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message from email file normally.
        Dim message = MailMessage.Load("ValidSigned.eml")

        ' Check if it's signed and validate signature.
        Console.WriteLine($"Is signed: {message.IsSigned}")
        Console.WriteLine($"Is valid: {message.ValidateSignature()}")
    End Sub

    Sub Example3()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message from email file normally.
        Dim message = MailMessage.Load("ValidClearSigned.eml")

        ' To unsign a Not-signed message would throw an exception!
        If Not message.IsSigned Then Return

        message.Unsign()

        ' Save the unsigned message.
        message.Save("Unsigned.eml")
    End Sub

End Module
