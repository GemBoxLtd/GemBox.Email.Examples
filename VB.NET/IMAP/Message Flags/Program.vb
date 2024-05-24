Imports GemBox.Email
Imports GemBox.Email.Imap
Imports System
Imports System.Collections.Generic

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Select INBOX folder.
            imap.SelectInbox()

            ' Add "Draft" flag to first message.
            imap.AddMessageFlags(1, ImapMessageFlags.Draft)

            ' Get first message flags and display them.
            ' Notice the presence of "Draft" flag.
            Dim flags As IList(Of String) = imap.GetMessageFlags(1)
            For Each flag As String In flags
                Console.WriteLine(flag)
            Next

            ' Remove "Draft" flag from first message.
            imap.RemoveMessageFlags(1, ImapMessageFlags.Draft)

            Console.WriteLine(New String("-"c, 10))

            ' Again, get first message flags and display them.
            ' Notice the absence of "Draft" flag.
            flags = imap.GetMessageFlags(1)
            For Each flag As String In flags
                Console.WriteLine(flag)
            Next
        End Using
    End Sub
End Module
