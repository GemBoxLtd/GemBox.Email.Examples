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

            ' For this example we will use INBOX folder
            imap.SelectInbox()

            ' List folder flags for INBOX
            Dim folders As IList(Of ImapFolderInfo) = imap.ListFolders()

            Console.WriteLine("Listing '{0}' folder flags...", imap.SelectedFolder.Name)

            For Each flag As String In imap.SelectedFolder.Flags
                Console.WriteLine(flag)
            Next

        End Using

    End Sub

End Module