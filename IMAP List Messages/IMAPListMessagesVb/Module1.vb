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

            ' To be able to list message, we need to select a folder first
            imap.SelectInbox()

            ' Get info for all messages in INBOX
            Dim infoList As IList(Of ImapMessageInfo) = imap.ListMessages()

            Console.WriteLine("Listing messages for folder '{0}' ...", imap.SelectedFolder.Name)

            For Each info As ImapMessageInfo In infoList
                Console.WriteLine("{0} - [{1}] - {2} Byte(s)", info.Number, info.Uid, info.Size)
            Next

        End Using

    End Sub

End Module