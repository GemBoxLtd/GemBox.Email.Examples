Imports GemBox.Email

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage(
            New MailAddress("sender@example.com", "Sender"),
            New MailAddress("receiver@example.com", "Receiver"))

        ' Add subject and body.
        message.Subject = "Save Example by GemBox.Email"
        message.BodyText = "Hi 👋," & vbLf &
            "This message was created and saved with GemBox.Email." & vbLf &
            "Read more about it on https://www.gemboxsoftware.com/email"

        ' Save message to email file.
        message.Save("Save.eml")
    End Sub
End Module