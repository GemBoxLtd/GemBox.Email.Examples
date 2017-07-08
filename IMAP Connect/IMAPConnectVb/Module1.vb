Imports System
Imports GemBox.Email
Imports GemBox.Email.Imap

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            ' Connect to mail server
            imap.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username and password
            ' (ImapClient will use strongest possible authentication mechanism)
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

        End Using

    End Sub

End Module