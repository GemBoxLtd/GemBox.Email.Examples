Imports GemBox.Email
Imports GemBox.Email.Imap

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As ImapClient = New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Create new email message.
            Dim message As New MailMessage(
                New MailAddress("sender@example.com", "Sender"),
                New MailAddress("first.receiver@example.com", "First receiver"),
                New MailAddress("second.receiver@example.com", "Second receiver"))

            ' Add additional receivers.
            message.Cc.Add(
                New MailAddress("third.receiver@example.com", "Third receiver"),
                New MailAddress("fourth.receiver@example.com", "Fourth receiver"))

            ' Add subject and body.
            message.Subject = "Upload Email in C# / VB.NET / ASP.NET"
            message.BodyText = "Hi 👋," & vbLf &
                "This message was created and uploaded with GemBox.Email." & vbLf &
                "Read more about it on https://www.gemboxsoftware.com/email"

            ' Uploads the message to the INBOX folder.
            imap.UploadMessage(message, "INBOX")

        End Using
    End Sub
End Module
