Imports System
Imports GemBox.Email
Imports GemBox.Email.Imap

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new IMAP client.
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            ' By default the connect timeout is 5 sec.
            imap.ConnectTimeout = TimeSpan.FromSeconds(4)

            ' Connect to IMAP server.
            imap.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate using the credentials; username and password.
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")
        End Using

        Console.WriteLine("Disconnected.")
    End Sub
End Module