Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new email message.
        Dim message As New MailMessage("sender@example.com", "receiver@example.com")

        ' Add subject.
        message.Subject = "Send HTML Email with Image and Attachment"

        ' Add HTML body with CID embeded image.
        Dim cid As String = "image001@gembox.com"
        message.BodyHtml = "<html><body>" &
            "<p>Hi 👋,</p>" &
            "<p>This message was created and sent with:</p>" &
            "<p><img src='cid:" & cid & "'/></p>" &
            "<p>Read more about it on <a href='https://www.gemboxsoftware.com/email'>GemBox.Email Overview</a> page.</p>" &
            "</body></html>"

        ' Add image as inline attachment.
        message.Attachments.Add(New Attachment("gembox-email-logo.png") With {.ContentId = cid})

        ' Add file as attachment.
        message.Attachments.Add(New Attachment("sample-file.pdf"))

        ' Create new SMTP client and send an email message.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(message)
        End Using

    End Sub
End Module