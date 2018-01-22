Imports System
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create New message with specified 'from' and 'to' addresses
        Dim message As New MailMessage("sender@example.com", "receiver@example.com")

        ' Set subject And text body
        message.Subject = "Test email message with attachments"
        message.BodyText = "This is a test message body."
        message.BodyHtml = "<h1>This is a test message body.</h1>"

        ' Add attachments
        message.Attachments.Add(New Attachment("Image.png"))
        message.Attachments.Add(New Attachment("Document.docx"))

        Console.WriteLine("Sending message...")

        ' Initialize new SMTP client and send an email message
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            Console.WriteLine("Connected.")

            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            smtp.SendMessage(message)
        End Using

        Console.WriteLine("Message sent successfully.")

    End Sub

End Module