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

            ' List all folders on the server
            Dim folders As IList(Of ImapFolderInfo) = imap.ListFolders()

            Console.WriteLine("Listing folders...")

            For Each info As ImapFolderInfo In folders
                Console.WriteLine(" {0,18}: {1}", info.Name, String.Join(", ", info.Flags))
            Next

            ' Create new folder and list all folders again
            imap.CreateFolder("GemBox")

            Console.WriteLine("Listing folders again...")

            folders = imap.ListFolders()
            For Each info As ImapFolderInfo In folders
                Console.WriteLine(" {0,18}: {1}", info.Name, String.Join(", ", info.Flags))
            Next

            ' Delete newly created folder and repeat listing
            imap.DeleteFolder("GemBox")

            Console.WriteLine("Final folder listing...")

            folders = imap.ListFolders()
            For Each info As ImapFolderInfo In folders
                Console.WriteLine(" {0,18}: {1}", info.Name, String.Join(", ", info.Flags))
            Next

        End Using

    End Sub

End Module