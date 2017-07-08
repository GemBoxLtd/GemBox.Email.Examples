Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Imap

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            Console.WriteLine("Connected.")

            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            imap.SelectInbox()

            ' Search for messages whose subject contains string 'Text'
            Dim messages As IList(Of Integer) = imap.SearchMessageNumbers("SUBJECT Test")
            Console.WriteLine("Number of messages with 'Test' string in subject: " & messages.Count)

            ' Search for 'unseen' messages sent by 'sender@example.com'
            messages = imap.SearchMessageNumbers("UNSEEN FROM sender@example.com")
            Console.WriteLine("Number of unseen messages sent by 'sender@example.com': " & messages.Count)

        End Using

    End Sub

End Module