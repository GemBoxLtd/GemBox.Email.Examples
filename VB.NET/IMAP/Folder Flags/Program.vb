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

            ' Select INBOX folder.
            imap.SelectInbox()

            ' List INBOX folder flags.
            Dim folders As IList(Of ImapFolderInfo) = imap.ListFolders()
            For Each flag As String In imap.SelectedFolder.Flags
                Console.WriteLine(flag)
            Next
        End Using
    End Sub
End Module