Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

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
        message.Subject = "Send Email in C# / VB.NET / ASP.NET"
        message.BodyText = "Hi 👋," & vbLf &
            "This message was created and sent with GemBox.Email." & vbLf &
            "Read more about it on https://www.gemboxsoftware.com/email"

        ' Create new SMTP client and send an email message.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(message)
        End Using

    End Sub
End Module