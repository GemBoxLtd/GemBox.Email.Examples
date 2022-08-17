Imports GemBox.Email
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Example1()
        Example2()

    End Sub

    Sub Example1()
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
        ' Load message from email file normally.
        Dim message = MailMessage.Load("ValidClearSigned.eml")

        ' To unsign a Not-signed message would throw an exception!
        If Not message.IsSigned Then Return

        message.Unsign()

        ' Save the unsigned message.
        message.Save("Unsigned.eml")
    End Sub

End Module