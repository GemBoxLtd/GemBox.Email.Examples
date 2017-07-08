Imports System
Imports GemBox.Email
Imports GemBox.Email.Imap
Imports GemBox.Email.Mime

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            Console.WriteLine("Connected.")

            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            ' Get headers for first available mail message
            Dim headers As HeaderCollection = imap.GetHeaders(1)

            Console.WriteLine("Listing message headers...")

            For Each header As Header In headers
                Console.WriteLine("{0}: {1}", header.Name, header.Body)
            Next

        End Using

    End Sub

End Module