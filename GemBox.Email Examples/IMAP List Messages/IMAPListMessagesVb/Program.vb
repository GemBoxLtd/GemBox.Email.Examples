Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Imap

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")

            ' Select INBOX folder.
            imap.SelectInbox()

            ' Get information about all available messages in INBOX folder.
            Dim infos As IList(Of ImapMessageInfo) = imap.ListMessages()

            ' Display messages information.
            For Each info As ImapMessageInfo In infos
                Console.WriteLine($"{info.Number} - [{info.Uid}] - {info.Size} Byte(s)")
            Next
        End Using
    End Sub
End Module