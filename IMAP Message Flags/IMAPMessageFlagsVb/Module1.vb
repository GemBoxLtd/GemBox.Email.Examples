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

            ' For this example we will select INBOX folder
            imap.SelectInbox()

            ' Get first message flags
            Dim flags As IList(Of String) = imap.GetMessageFlags(1)

            Console.WriteLine("Listing message flags...")

            For Each flag As String In flags
                Console.WriteLine(" "c & flag)
            Next

            ' Add 'Draft' flag to message
            imap.AddMessageFlags(1, ImapMessageFlags.Draft)

            ' List message flags again
            Console.WriteLine("Listing message flags again...")

            For Each flag As String In imap.GetMessageFlags(1)
                Console.WriteLine(" "c & flag)
            Next

            ' Remove 'Draft' flag
            imap.RemoveMessageFlags(1, ImapMessageFlags.Draft)

            ' Final message listing
            Console.WriteLine("Final message flags listing...")

            For Each flag As String In imap.GetMessageFlags(1)
                Console.WriteLine(" "c & flag)
            Next

        End Using

    End Sub

End Module