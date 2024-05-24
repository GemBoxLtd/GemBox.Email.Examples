Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create New email message.
        Dim message = New MailMessage("sender@example.com", "receiver@example.com")

        ' Add subject.
        message.Subject = "GemBox.Email getting started example"

        ' Add HTML body.
        message.BodyHtml =
            "<html><body>" &
            "<p>Hi 👋,</p>" &
            "<p>This message was created and sent with <a href='https://www.gemboxsoftware.com/email'>GemBox.Email</a></p>" &
            "</body></html>"

        ' Add text body.
        message.BodyText =
            "Hi 👋,\n" &
            "This message was created and sent with GemBox.Email (https://www.gemboxsoftware.com/email)"

        ' Add file as attachment.
        message.Attachments.Add(New Attachment("GemBoxSampleFile.pdf"))

        ' Create New SMTP client And send an email message.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(message)

        End Using

    End Sub

End Module
