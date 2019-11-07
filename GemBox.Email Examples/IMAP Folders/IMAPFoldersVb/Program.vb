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

            ' Create new folder.
            imap.CreateFolder("GemBox")

            ' List all folders on the server and display their information.
            ' Notice the presence of new "GemBox" folder.
            Dim folders As IList(Of ImapFolderInfo) = imap.ListFolders()
            For Each folder As ImapFolderInfo In folders
                Console.WriteLine($"{folder.Name,-18}: {String.Join(", ", folder.Flags)}")
            Next

            ' Delete newly created folder.
            imap.DeleteFolder("GemBox")

            Console.WriteLine(New String("-"c, 40))

            ' Again, list folders and display their information.
            ' Notice the absence of new "GemBox" folder.
            folders = imap.ListFolders()
            For Each folder As ImapFolderInfo In folders
                Console.WriteLine($"{folder.Name,-18}: {String.Join(", ", folder.Flags)}")
            Next
        End Using
    End Sub
End Module