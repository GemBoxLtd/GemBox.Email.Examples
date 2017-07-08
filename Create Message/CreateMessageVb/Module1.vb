Imports System
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create New message with specified 'from' and 'to' addresses
        Dim message As New MailMessage(New MailAddress("sender@example.com"),
                                       New MailAddress("receiver@example.com"))

        ' Set subject And text body
        message.Subject = "Test email message with text body"
        message.BodyText = "This is a test message with text body."

        ' Save message to disk
        message.Save("TextMessage.eml", MailMessageFormat.Eml)

    End Sub

End Module