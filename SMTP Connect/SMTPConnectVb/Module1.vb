Imports System
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            ' Connect to mail server
            smtp.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username and password
            ' (SmtpClient will use strongest possible authentication mechanism)
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

        End Using

    End Sub

End Module