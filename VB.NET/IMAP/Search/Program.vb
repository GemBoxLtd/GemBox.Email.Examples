Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Imap

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            imap.SelectInbox()

            ' Search for messages whose subject contains 'Example' text.
            Dim messages As IList(Of Integer) = imap.SearchMessageNumbers("SUBJECT Example")
            Console.WriteLine($"Number of messages with 'Example' in subject: {messages.Count}")

            ' Search for 'unseen' messages sent by 'sender@example.com'.
            messages = imap.SearchMessageNumbers("UNSEEN FROM sender@example.com")
            Console.WriteLine($"Number of 'unseen' messages sent by 'sender@example.com': {messages.Count}")
        End Using
    End Sub
End Module