Imports System
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Console.WriteLine("Creating message...")

        ' Create new email message
        Dim message As New MailMessage(New MailAddress("sender@example.com", "Sender"),
                                       New MailAddress("first.receiver@example.com", "First receiver"))

        ' Add second receiver to CC And set subject
        message.Cc.Add(New MailAddress("second.receiver@example.com", "Second receiver"))
        message.Subject = "GemBox.Email .NET component"

        ' Add HTML And text body
        message.BodyHtml = "<html>" &
                              "<body>" &
                                "<p>Hi!<br/><br/>This message was created and sent with " &
                                  "<b>GemBox.Email .NET component</b>.<br/>" &
                                  "More info can be found at <a href=""http://www.gemboxsoftware.com/"">" &
                                  "GemBox Software website</a>." &
                                "</p>" &
                              "</body>" &
                            "</html>"

        message.BodyText = "Hi!" & vbCrLf &
                           vbCrLf &
                           "This message was created and sent with GemBox.Email .NET component." & vbCrLf &
                           "More info can be found at http://www.gemboxsoftware.com/."

        ' Add attachment
        message.Attachments.Add(New Attachment("Picture.jpg"))

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