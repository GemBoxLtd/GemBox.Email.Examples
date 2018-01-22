Imports System
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            smtp.Connect()
            Console.WriteLine("Connected.")

            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            ' Create New message
            Dim message As New MailMessage("sender@example.com", "receiver@example.com")
            message.Subject = "SMTP test message"
            message.BodyText = "This is test message body."

            Console.WriteLine("Sending message...")

            ' Send message
            smtp.SendMessage(message)

            Console.WriteLine("Message sent.")

        End Using

    End Sub

End Module