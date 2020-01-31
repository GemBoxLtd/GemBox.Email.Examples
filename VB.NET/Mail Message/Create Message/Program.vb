Imports GemBox.Email

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage(
            New MailAddress("sender@example.com", "Sender"),
            New MailAddress("first.receiver@example.com", "First receiver"))

        ' Set subject And text body.
        message.Subject = "Test email message with text body"
        message.BodyText = "This is a test message with text body."

        message.Save("Create Message.eml")
    End Sub
End Module