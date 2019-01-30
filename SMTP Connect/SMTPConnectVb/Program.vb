Imports System
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new SMTP client.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            ' By default the connect timeout is 5 sec.
            smtp.ConnectTimeout = TimeSpan.FromSeconds(4)

            ' Connect to SMTP server.
            smtp.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate using the credentials; username and password.
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")
        End Using

        Console.WriteLine("Disconnected.")
    End Sub
End Module